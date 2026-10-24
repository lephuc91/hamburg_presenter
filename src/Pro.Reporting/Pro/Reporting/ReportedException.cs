using System;

namespace Pro.Reporting;

public class ReportedException : Exception
{
	public override string StackTrace { get; }

	public ReportedException(string error, string stackTrace)
		: base(error)
	{
		StackTrace = stackTrace;
	}
}
