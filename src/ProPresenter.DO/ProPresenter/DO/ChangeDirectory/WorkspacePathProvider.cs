using System;
using System.IO;
using Pro.DO;

namespace ProPresenter.DO.ChangeDirectory;

public class WorkspacePathProvider(string relativePath, bool loadLegacy) : IWorkspacePathProvider
{
	private sealed class Registration(ChangeDirectoryListener listener) : IDisposable
	{
		public void Dispose()
		{
			ChangeDirectoryPrompt.UnregisterDelegate(listener);
		}
	}

	public string Current => Path.Combine(CommonPaths.Base, relativePath);

	public bool LoadLegacy { get; } = loadLegacy;

	public IDisposable RegisterChange(Action prepareSwitch, Action<string, bool> setupNewFolder)
	{
		ChangeDirectoryListener listener = new ChangeDirectoryListener(prepareSwitch, delegate(bool loadLegacy)
		{
			SetupNew(loadLegacy, setupNewFolder);
		});
		ChangeDirectoryPrompt.RegisterDelegate(listener);
		return new Registration(listener);
	}

	private void SetupNew(bool loadLegacy, Action<string, bool> setupNewFolder)
	{
		setupNewFolder(Current, loadLegacy);
	}
}
