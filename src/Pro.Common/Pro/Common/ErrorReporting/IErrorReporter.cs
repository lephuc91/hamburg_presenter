using System;

namespace Pro.Common.ErrorReporting;

public interface IErrorReporter
{
	void Error(Exception e, string message, params object[] args);

	void Error(string message, params object[] args);

	void FatalError(Exception e, string message, params object[] args);

	void FatalError(string message, params object[] args);
}
