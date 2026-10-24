namespace Pro.Common.HTTP.Results;

public record SuccessResult<T>(T Data) : IRequestResult;
