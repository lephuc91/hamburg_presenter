using System;

namespace Pro.Common.Logging;

public class Logger : ILogger
{
	public void Debug(string message, params object?[] args)
	{
		Log.Debug(message, args);
	}

	public void DebugWarning(string message, params object?[] args)
	{
		Log.DebugWarning(message, args);
	}

	public void Error(string message, params object?[] args)
	{
		Log.Error(message, args);
	}

	public void Error(Exception ex)
	{
		Log.Error(ex.ToString());
	}

	public void FatalError(string message, params object?[] args)
	{
		Log.FatalError(message, args);
	}

	public void Info(string message, params object?[] args)
	{
		Log.Info(message, args);
	}

	public void Warning(string message, params object?[] args)
	{
		Log.Warning(message, args);
	}
}
