package application.delete;

import application.results.Result;
import domain.entities.ClotheEntity;
import domain.repositories.IRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.web.client.RestTemplate;
import org.springframework.http.ResponseEntity;

import javax.validation.ConstraintViolation;
import javax.validation.Validator;
import java.util.Optional;
import java.util.Set;
import java.util.UUID;

@Service
public class DeleteClotheCommandHandler2 {

    public static final String API_URL = "http://127.0.0.1/api/allowDelete";

    private final IRepository repository;
    private final RestTemplate restTemplate;
    private final Validator validator;

    @Autowired
    public DeleteClotheCommandHandler2(IRepository repository, RestTemplate restTemplate, Validator validator) {
        this.repository = repository;
        this.restTemplate = restTemplate;
        this.validator = validator;
    }

    public Result handle(DeleteClotheCommand request) {
        // Validate the command
        Set<ConstraintViolation<DeleteClotheCommand>> violations = validator.validate(request);
        if (!violations.isEmpty()) {
            return new Result(false, "Invalid data", null);
        }

        // Fetch the entity from the repository
        Optional<ClotheEntity> clothe = repository.findById(request.getId());
        if (clothe.isEmpty()) {
            return new Result(false, "Clothe not found", null);
        }

        // Make the HTTP request to check if deletion is allowed
        ResponseEntity<Result> response = restTemplate.getForEntity(API_URL, Result.class);

        if (!response.getStatusCode().is2xxSuccessful()) {
            return new Result(false, "Failed to call external API", null);
        }

        // Process the API response
        Result apiData = response.getBody();
        if (apiData == null) {
            throw new IllegalStateException("Invalid API data received.");
        }

        if (apiData.isSuccess()) {
            // Perform the deletion
            repository.delete(clothe.get());
            return new Result(true, "Clothe deleted successfully", clothe.get().getId());
        } else {
            return apiData;
        }
    }
}
