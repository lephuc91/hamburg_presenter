using System.Collections.Generic;
using System.IO;
using Pro.DO.Storage;

namespace ProPresenter.DO.Sync.Local;

public interface ISyncDataProvider
{
	IReadOnlyCollection<ISyncData> GetSyncData(RelativePath folder, FileAccess fileAccess);

	IReadOnlyCollection<ISyncData> GetSyncData(RelativePath folder, bool includeLibrary, bool includePlaylists, bool includeMedia, bool includeThemes, bool includeConfiguration, FileAccess fileAccess);
}
