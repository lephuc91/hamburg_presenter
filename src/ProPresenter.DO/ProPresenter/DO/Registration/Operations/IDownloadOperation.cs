using System;

namespace ProPresenter.DO.Registration.Operations;

public interface IDownloadOperation
{
	IObservable<double> WhenDownloadProgressChanged { get; }
}
