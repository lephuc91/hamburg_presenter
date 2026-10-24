using System.IO;
using System.Threading.Tasks;
using Pro.Common.Utility;
using Pro.Interprocess;
using ProPresenter.DO;

namespace ProPresenter.Utility;

public class InstallFileExecutor : IInstallFileExecutor
{
	private readonly string _installPath;

	private TaskCompletionSource<bool>? _installCompletion;

	public InstallFileExecutor(string installPath, IMessages<AppMessages> messages)
	{
		_installPath = installPath;
		messages.RegisterHandler(AppMessages.InstallFinished, OnInstallFinished);
	}

	public async Task DoInstallAsync(string sourceFile, string destination)
	{
		_installCompletion = new TaskCompletionSource<bool>();
		string text = Path.Combine(_installPath, "InstallHelper.exe");
		if (!File.Exists(text) || ProcessHelper.StartProcess(text, "\"" + sourceFile + "\" \"" + destination + "\""))
		{
			await _installCompletion.Task;
			_installCompletion = null;
		}
	}

	private void OnInstallFinished()
	{
		_installCompletion?.SetResult(result: true);
	}
}
