using System.Diagnostics;

namespace Pro.UI.Utility;

public class BindingErrorFilter : TraceFilter
{
	public override bool ShouldTrace(TraceEventCache? cache, string source, TraceEventType eventType, int id, string? formatOrMessage, object?[]? args, object? data1, object?[]? data)
	{
		return true;
	}
}
