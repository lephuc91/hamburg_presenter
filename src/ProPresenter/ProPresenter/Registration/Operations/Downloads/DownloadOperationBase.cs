using System;
using System.CodeDom.Compiler;
using System.Reactive.Subjects;
using Pro.Common.SourceGenerator.Attributes;
using Pro.CoreApplication.Registration.Interaction;
using Pro.SerializationInterop.RVProtoData.Registration;
using ProPresenter.DO.Registration;
using ProPresenter.DO.Registration.Operations;

namespace ProPresenter.Registration.Operations.Downloads;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "_downloadProgressSubject" })]
public abstract class DownloadOperationBase : IDownloadRegistrationOperation, IRegistrationOperation, IDownloadOperation, IDisposable
{
	private readonly SubjectBase<double> _downloadProgressSubject = new BehaviorSubject<double>(0.0);

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public IObservable<double> WhenDownloadProgressChanged => _downloadProgressSubject;

	public abstract RegistrationOperationHandleResponse HandleResponse(Callback responseCallback, IRegistrationRequestSender requestSender);

	public abstract Request Start();

	protected bool HandleDownloadProgress(Status status, double progress, bool isComplete)
	{
		if (status != 0)
		{
			_downloadProgressSubject.OnError(new RegistrationException(status));
			return true;
		}
		if (isComplete)
		{
			_downloadProgressSubject.OnNext(1.0);
			_downloadProgressSubject.OnCompleted();
			return true;
		}
		_downloadProgressSubject.OnNext(progress);
		return false;
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	protected virtual void Dispose(bool disposing)
	{
		if (!_disposed && disposing)
		{
			_disposed = true;
			_downloadProgressSubject.Dispose();
		}
	}
}
