using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Pro.DO.Storage;
using ProPresenter.DO.Import;
using ProPresenter.DO.Media;

namespace ProPresenter.DO.Playlists;

public class MediaImportService : IMediaImportService
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass2_0
	{
		public IEnumerable<RelativePath> filenames;

		public Action<string, string, FileMediaBase?> importCallback;

		public bool manageMedia;

		public PlaylistType playlistType;

		public string containerId;
	}

	private readonly IImportProcessFactory _importProcessFactory;

	public MediaImportService(IImportProcessFactory importProcessFactory)
	{
		_importProcessFactory = importProcessFactory;
	}

	public void Import(IEnumerable<RelativePath> filenames, bool manageMedia, Action<string, string, FileMediaBase?> importCallback, PlaylistType playlistType, string containerId)
	{
		_003C_003Ec__DisplayClass2_0 CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass2_0();
		CS_0024_003C_003E8__locals6.filenames = filenames;
		CS_0024_003C_003E8__locals6.importCallback = importCallback;
		CS_0024_003C_003E8__locals6.manageMedia = manageMedia;
		CS_0024_003C_003E8__locals6.playlistType = playlistType;
		CS_0024_003C_003E8__locals6.containerId = containerId;
		_importProcessFactory.Create(generateRequests()).StartImport();
		[IteratorStateMachine(typeof(_003C_003Ec__DisplayClass2_0._003C_003CImport_003Eg__generateRequests_007C0_003Ed))]
		IEnumerable<IImportRequest> generateRequests()
		{
			//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
			return new _003C_003Ec__DisplayClass2_0._003C_003CImport_003Eg__generateRequests_007C0_003Ed(-2)
			{
				_003C_003E4__this = CS_0024_003C_003E8__locals6
			};
		}
	}
}
