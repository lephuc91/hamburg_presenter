using System;
using System.CodeDom.Compiler;
using System.Reactive.Subjects;
using System.Windows.Threading;
using Pro.Common.Dispatcher;
using Pro.Common.MessageService;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Common.Utility;

namespace Pro.Common.Internet;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "_whenIsAvailableChanged" })]
public class InternetAccessCheckService : IInternetAccessCheck, IDisposable
{
	private bool _isInternetAccessAvailable;

	private readonly SubjectBase<bool> _whenIsAvailableChanged;

	private readonly IMessageService _messageService;

	private readonly IInternetAccess _accessCheck;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public IObservable<bool> WhenIsAvailableChanged => _whenIsAvailableChanged;

	public InternetAccessCheckService(IMessageService messageService, IInternetAccess accessCheck, IUiDispatcher uiDispatcher)
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		_whenIsAvailableChanged = new BehaviorSubject<bool>(_isInternetAccessAvailable);
		_messageService = messageService;
		_accessCheck = accessCheck;
		DispatcherTimer val = new DispatcherTimer((DispatcherPriority)4, uiDispatcher.Dispatcher)
		{
			Interval = new TimeSpan(0, 0, 5)
		};
		val.Tick += OnCheckInternetAccess;
		val.Start();
	}

	public bool Available()
	{
		CheckAccess();
		return _isInternetAccessAvailable;
	}

	private void OnCheckInternetAccess(object? sender, EventArgs e)
	{
		CheckAccess();
	}

	private void CheckAccess()
	{
		bool flag = _accessCheck.IsInternetAvailable();
		if (flag != _isInternetAccessAvailable)
		{
			_isInternetAccessAvailable = flag;
			_whenIsAvailableChanged.OnNext(flag);
			PublishInternetAccessMessage();
		}
	}

	private void PublishInternetAccessMessage()
	{
		_messageService.PublishMessage(new InternetAccessMessage(_isInternetAccessAvailable));
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
			_whenIsAvailableChanged.Dispose();
		}
	}
}
