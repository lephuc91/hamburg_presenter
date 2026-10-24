using System;
using System.Collections.Generic;
using Pro.Common.Components;
using Pro.DO.Storage;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Playlists;

public interface ISmartFolderRepo : ICloneable<ISmartFolderRepo?>
{
	string Name { get; }

	string TargetPath { get; }

	event Action<RelativePath> FileCreated;

	event Action<RelativePath> FileDeleted;

	event Action<RelativePath, RelativePath> FileRenamed;

	event Action<RelativePath> FileChanged;

	event Action<IEnumerable<RelativePath>> FilesParsed;

	void ParseFiles();

	void ImportFiles(IEnumerable<string> filenames);

	URL? Serialize();

	void Deserialize(Playlist.Types.FolderDirectory protoFolderDirectory);
}
