using System;

namespace Pro.Common.ErrorReporting;

public interface IErrorPublisher
{
	void Error(Exception exception, string message);

	void Error(string message);

	void FatalError(Exception exception, string message);

	void FatalError(string message);
}
