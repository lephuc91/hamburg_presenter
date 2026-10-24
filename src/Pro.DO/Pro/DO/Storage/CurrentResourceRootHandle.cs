using Pro.Common.Components;

namespace Pro.DO.Storage;

public class CurrentResourceRootHandle : DisposableBase
{
	public string RootPath { get; }

	internal CurrentResourceRootHandle(string rootPath)
	{
		RootPath = rootPath;
	}

	protected override void OnDispose(bool disposeObjects)
	{
		RelativePath.ClearCurrentResourceRoot();
	}
}
