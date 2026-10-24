using System;

namespace Pro.Loro;

public record ImportBlobMetadata(VersionVector partialStartVv, VersionVector partialEndVv, long startTimestamp, Frontiers startFrontiers, long endTimestamp, uint changeNum, string mode) : IDisposable
{
	public void Dispose()
	{
		FFIObjectUtil.DisposeAll(partialStartVv, partialEndVv, startTimestamp, startFrontiers, endTimestamp, changeNum, mode);
	}
}
