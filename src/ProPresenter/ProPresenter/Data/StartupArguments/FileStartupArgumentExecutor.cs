using System;
using System.IO.Abstractions;
using Pro.Interprocess;
using ProPresenter.DO;
using ProPresenter.UI.ViewModels;

namespace ProPresenter.Data.StartupArguments;

public class FileStartupArgumentExecutor : FileImporter, IStartupArgumentsExecutor
{
	private readonly ISharedData<AppData> _sharedData;

	private readonly IMessages<AppMessages> _messages;

	private readonly IFileSystem _fileSystem;

	private string _fileName = string.Empty;

	public FileStartupArgumentExecutor(ISharedData<AppData> sharedData, IMessages<AppMessages> messages, Func<IMainLayoutVM?> getMainLayoutVM, IFileSystem fileSystem)
		: base(getMainLayoutVM)
	{
		_sharedData = sharedData;
		_messages = messages;
		_fileSystem = fileSystem;
	}

	public void UseLocally()
	{
		if (!string.IsNullOrEmpty(_fileName))
		{
			ImportFile(_fileName);
		}
	}

	public bool ProcessArgument(string argument)
	{
		if (_fileSystem.File.Exists(argument))
		{
			_fileName = argument;
			return true;
		}
		return false;
	}

	public void Send()
	{
		if (!string.IsNullOrEmpty(_fileName))
		{
			_sharedData.SendData(AppData.File, _fileName);
			_messages.SendMessage(AppMessages.HandleFile);
		}
	}
}
