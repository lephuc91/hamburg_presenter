using System;
using System.Collections.Generic;
using System.IO;
using Pro.Common.ErrorReporting;
using Pro.Common.FileSystem;
using Pro.DO.Storage;

namespace ProPresenter.DO.Sync.Local;

public abstract class SyncFileRepositoryBase : ISyncRepository<ISyncData>
{
	private ISyncDataProvider _dataProvider;

	private readonly IErrorReporter _errorReporter;

	protected abstract RelativePath Repo { get; }

	protected SyncFileRepositoryBase(ISyncDataProvider dataProvider, IErrorReporter errorReporter)
	{
		_dataProvider = dataProvider;
		_errorReporter = errorReporter;
	}

	public ISyncData? Read(ISyncData data)
	{
		if (data is SyncFileData syncFileData)
		{
			string text = Convert(syncFileData.FullPath);
			if (!File.Exists(text))
			{
				return null;
			}
			return new SyncFileData(text, syncFileData.FileType);
		}
		return null;
	}

	public void Write(ISyncData data, Action<double> progress)
	{
		if (data is SyncFileData syncFileData)
		{
			try
			{
				string destination = Convert(syncFileData.FullPath);
				FileHelper.Copy(syncFileData.FullPath, destination, null, progress, null, _errorReporter);
			}
			catch (Exception ex)
			{
				_errorReporter.Error("Error encountered while trying to write file: \"{0}\"; \"{1}\"", syncFileData.FullPath, ex);
			}
		}
	}

	public void Modify(ISyncData data, Action<double> progress)
	{
		OnModify(data, progress);
	}

	public void Delete(ISyncData data, Action<double> progress)
	{
		if (data is SyncFileData syncFileData)
		{
			FileHelper.DeleteFile(syncFileData.FullPath);
		}
	}

	public IReadOnlyCollection<ISyncData> GetAll(FileAccess fileAccess)
	{
		return _dataProvider.GetSyncData(Repo, fileAccess);
	}

	protected abstract string Convert(string path);

	protected abstract void OnModify(ISyncData data, Action<double> progress);
}
