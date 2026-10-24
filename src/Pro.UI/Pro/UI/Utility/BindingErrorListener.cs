using System;
using System.Diagnostics;
using System.Text;
using Pro.Common.ErrorReporting;

namespace Pro.UI.Utility;

public class BindingErrorListener : TraceListener
{
	private static BindingErrorListener? _listener;

	private readonly IErrorReporter _errorReporter;

	private readonly StringBuilder _buffer = new StringBuilder();

	private BindingErrorListener(IErrorReporter errorReporter)
	{
		_errorReporter = errorReporter;
	}

	public static void Attach(IErrorReporter errorReporter)
	{
		if (_listener != null)
		{
			throw new InvalidOperationException("Listener is already attached");
		}
		_listener = new BindingErrorListener(errorReporter);
		_listener.Filter = new BindingErrorFilter();
		PresentationTraceSources.DataBindingSource.Listeners.Add(_listener);
	}

	public static void Detach()
	{
		if (_listener == null)
		{
			throw new InvalidOperationException("Listener is already detached");
		}
		PresentationTraceSources.DataBindingSource.Listeners.Remove(_listener);
		_listener = null;
	}

	public override void Write(string? message)
	{
		_buffer.Append(message);
	}

	[DebuggerStepThrough]
	public override void WriteLine(string? message)
	{
		_buffer.Append(message);
		_errorReporter.Error("Binding Error: {0}", _buffer.ToString());
		_buffer.Clear();
	}
}
