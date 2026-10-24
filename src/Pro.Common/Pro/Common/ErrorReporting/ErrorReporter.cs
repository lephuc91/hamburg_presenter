using System;
using System.Diagnostics;
using System.Linq;
using Pro.Common.Logging;

namespace Pro.Common.ErrorReporting;

public class ErrorReporter : IErrorReporter
{
	private readonly IErrorPublisher _publisher;

	private readonly ILogger _logger;

	public ErrorReporter(ILogger logger, IErrorPublisher publisher)
	{
		_logger = logger;
		_publisher = publisher;
	}

	public void Error(Exception e, string message, params object[] args)
	{
		DoLog(e, message, args, _logger.Error, _publisher.Error);
	}

	public void Error(string message, params object[] args)
	{
		DoLog(message, args, _logger.Error, _publisher.Error);
	}

	public void FatalError(Exception e, string message, params object[] args)
	{
		DoLog(e, message, args, _logger.FatalError, _publisher.FatalError);
	}

	public void FatalError(string message, params object[] args)
	{
		DoLog(message, args, _logger.FatalError, _publisher.FatalError);
	}

	private static void DoLog(Exception e, string message, object[] args, Action<string, object[]> logMethod, Action<Exception, string> publishError)
	{
		string arg = $"{message}\nException:\n{{{args.Length}}}";
		logMethod(arg, args.Append(e).ToArray());
		publishError?.Invoke(e, string.Format(message, args));
	}

	private static void DoLog(string message, object[] args, Action<string, object[]> logMethod, Action<string> publishError)
	{
		string arg = $"{message}\nStackTrace:\n{{{args.Length}}}";
		logMethod(arg, args.Append(new StackTrace()).ToArray());
		publishError?.Invoke(string.Format(message, args));
	}
}
