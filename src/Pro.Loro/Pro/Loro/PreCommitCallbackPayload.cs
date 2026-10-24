using System;

namespace Pro.Loro;

public record PreCommitCallbackPayload(ChangeMeta changeMeta, string origin, ChangeModifier modifier) : IDisposable
{
	public void Dispose()
	{
		FFIObjectUtil.DisposeAll(changeMeta, origin, modifier);
	}
}
