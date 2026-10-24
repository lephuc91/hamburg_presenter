using System;
using Pro.Common.ErrorReporting;
using Pro.DO.Storage;
using ProPresenter.DO.Settings;

namespace ProPresenter.DO.Sync.Local;

public class RemoteFileRepository : SyncFileRepositoryBase
{
	protected override RelativePath Repo => new RelativePath(ProPresenter.DO.Settings.Sync.Settings.LocalSyncSource, isDirectory: true);

	public RemoteFileRepository(ISyncDataProvider dataProvider, IErrorReporter errorReporter)
		: base(dataProvider, errorReporter)
	{
	}

	protected override string Convert(string path)
	{
		return path.ConvertToRepoFile(ProPresenter.DO.Settings.Sync.Settings.LocalSyncSource);
	}

	protected override void OnModify(ISyncData data, Action<double> progress)
	{
		Write(data, progress);
	}
}
