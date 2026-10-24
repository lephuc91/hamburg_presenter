using System;

namespace Pro.DO;

public interface IWorkspacePathProvider
{
	string Current { get; }

	bool LoadLegacy { get; }

	IDisposable RegisterChange(Action prepareSwitch, Action<string, bool> setupNewFolder);
}
