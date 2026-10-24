using System;
using System.Collections.Generic;
using Pro.DO.Storage;
using ProPresenter.DO.Media;

namespace ProPresenter.DO.Playlists;

public interface IMediaImportService
{
	void Import(IEnumerable<RelativePath> filenames, bool manageMedia, Action<string, string, FileMediaBase?> importCallback, PlaylistType playlistType, string containerId);
}
