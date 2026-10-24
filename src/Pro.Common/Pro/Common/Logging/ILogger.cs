using System;

namespace Pro.Common.Logging;

public interface ILogger
{
	void Debug(string message, params object?[] args);

	void DebugWarning(string message, params object?[] args);

	void Info(string message, params object?[] args);

	void Warning(string message, params object?[] args);

	void Error(string message, params object?[] args);

	void Error(Exception ex);

	void FatalError(string message, params object?[] args);
}
