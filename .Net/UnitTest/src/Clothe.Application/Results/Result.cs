namespace Clothes.Application.Results;

public record Result(bool Success, string Message, object Data = null);
