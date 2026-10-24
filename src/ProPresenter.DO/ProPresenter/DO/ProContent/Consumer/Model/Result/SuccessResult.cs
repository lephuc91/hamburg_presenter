namespace ProPresenter.DO.ProContent.Consumer.Model.Result;

public record SuccessResult<T>(T Data) : IRequestResult;
