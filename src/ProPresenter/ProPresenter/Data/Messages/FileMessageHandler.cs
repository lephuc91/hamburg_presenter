using System;
using System.IO.Abstractions;
using Pro.Interprocess;
using ProPresenter.DO;
using ProPresenter.UI.ViewModels;

namespace ProPresenter.Data.Messages;

public class FileMessageHandler : FileImporter, IMessageHandler
{
	private readonly ISharedData<AppData> _sharedData;

	private readonly IFileSystem _fileSystem;

	public AppMessages HandledMessage => AppMessages.HandleFile;

	public FileMessageHandler(ISharedData<AppData> sharedData, Func<IMainLayoutVM?> getMainLayoutVM, IFileSystem fileSystem)
		: base(getMainLayoutVM)
	{
		_sharedData = sharedData;
		_fileSystem = fileSystem;
	}

	public void Handle()
	{
		string text = _sharedData.ReadData(AppData.File);
		if (_fileSystem.File.Exists(text))
		{
			ImportFile(text);
		}
	}
}
