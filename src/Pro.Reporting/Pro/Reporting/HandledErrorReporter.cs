using System;
using Pro.Common.ErrorReporting;

namespace Pro.Reporting;

public class HandledErrorReporter : IErrorPublisher
{
	private const string SEVERITY_ERROR = "ERROR";

	private const string SEVERITY_FATAL_ERROR = "FATAL_ERROR";

	private const string BUILD_CONFIGURATION = "R";

	public void Error(Exception exception, string message)
	{
		Stargazer.ReportError(exception, ("Severity", "ERROR"), ("Build configuration", "R"), ("message", message));
	}

	public void Error(string message)
	{
		Stargazer.ReportError(message, ("Severity", "ERROR"), ("Build configuration", "R"), ("message", message));
	}

	public void FatalError(Exception exception, string message)
	{
		Stargazer.ReportError(exception, ("Severity", "FATAL_ERROR"), ("Build configuration", "R"), ("message", message));
	}

	public void FatalError(string message)
	{
		Stargazer.ReportError(message, ("Severity", "FATAL_ERROR"), ("Build configuration", "R"), ("message", message));
	}
}
