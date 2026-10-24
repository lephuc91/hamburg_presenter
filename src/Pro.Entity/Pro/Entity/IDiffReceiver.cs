using System;
using Pro.Loro;

namespace Pro.Entity;

internal interface IDiffReceiver
{
	void OnDiff(ReadOnlySpan<PathItem> updatedPaths, Diff diff);
}
