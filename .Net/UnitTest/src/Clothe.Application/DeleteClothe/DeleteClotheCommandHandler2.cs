using MediatR;
using Clothes.Application.Results;
using Clothes.Domain.Entities;
using Clothes.Domain.Repositories;
using System.Net.Http;
using System.Text.Json;

namespace Clothes.Application.DeleteClothe;

public class DeleteClotheCommandHandler2(IRepository<ClotheEntity> _repository, HttpClient _httpClient, DeleteClotheCommandValidator _validator) : IRequestHandler<DeleteClotheCommand, Result>
{
    public  const string ApiUrl = "http://127.0.0.1/api/allowDelete";
    public async Task<Result> Handle(DeleteClotheCommand request, CancellationToken cancellationToken)
    {
        var isValid = await _validator.ValidateAsync(request, cancellationToken);
        if (!isValid.IsValid)
        {
            return new Result(false, "Invalid data", isValid.Errors);
        }
        var Clothe = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (Clothe is null)
        {
            return new Result(false, "Clothe not found");
        }
        var response = await _httpClient.GetAsync(ApiUrl);
        response.EnsureSuccessStatusCode();
        var responseContent = await response.Content.ReadAsStringAsync();

        // Step 2: Process the API response
        var apiData = JsonSerializer.Deserialize<Result>(responseContent);
        if (apiData == null)
        {
            throw new InvalidOperationException("Invalid API data received.");
        }
        if (apiData.Success)
        {
            _repository.Delete(Clothe);
            await _repository.SaveChangesAsync(cancellationToken);
            return new Result(true, "Clothe deleted successfully", Clothe.Id);
        }
        else
        {
            return apiData;
        }
        
    }
}
