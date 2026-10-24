using System;

namespace ProPresenter.DO.ProContent.Consumer.Model.Result;

public record RedirectResult(Uri RedirectUrl) : IRequestResult;
