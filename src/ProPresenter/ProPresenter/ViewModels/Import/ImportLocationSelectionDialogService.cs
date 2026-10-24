using System;
using System.Runtime.CompilerServices;
using Pro.Common.Mathematics;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Import;
using ProPresenter.DO.Import.Requests;
using ProPresenter.DO.Import.Results;
using ProPresenter.DO.Librarian;
using ProPresenter.DO.Playlists;
using ProPresenter.UI.LibraryView;
using ProPresenter.ViewModels.Library;

namespace ProPresenter.ViewModels.Import;

public class ImportLocationSelectionDialogService : IImportLocationSelectionDialogService
{
	private record LibraryAndPlaylistDestinationSelection(ILibrary? Library, IPlaylist<ProPresenterCue>? Playlist) : ILibraryAndPlaylistDestinationSelection
	{
		public bool IsCancel => Library == null;

		public LibraryAndPlaylistDestinationSelection()
			: this(null, null)
		{
		}
	}

	private sealed record PowerpointDestinationSelection : LibraryAndPlaylistDestinationSelection, IPowerpointDestinationSelection, ILibraryAndPlaylistDestinationSelection
	{
		public Vector2<double> Size { get; init; }

		public PowerpointDestinationSelection(ILibrary? Library, IPlaylist<ProPresenterCue>? Playlist, Vector2<double> Size)
		{
			this.Size = Size;
			base._002Ector(Library, Playlist);
		}

		public PowerpointDestinationSelection()
			: this(null, null, Vector2<double>.Zero)
		{
		}

		[CompilerGenerated]
		public void Deconstruct(out ILibrary? Library, out IPlaylist<ProPresenterCue>? Playlist, out Vector2<double> Size)
		{
			Library = base.Library;
			Playlist = base.Playlist;
			Size = this.Size;
		}
	}

	private readonly Lazy<ILibraryService> _libraryService;

	public ImportLocationSelectionDialogService(Lazy<ILibraryService> libraryService)
	{
		_libraryService = libraryService;
	}

	public ILibraryAndPlaylistDestinationSelection ShowImportLocationSelectionDialog(IImportProcess importProcess)
	{
		bool flag = AllowSelectPlaylist(importProcess);
		ILibraryService value = _libraryService.Value;
		if (value.Libraries.Count == 1 && (!flag || value.Playlists.Count <= 0))
		{
			return new LibraryAndPlaylistDestinationSelection(value.Libraries[0], null);
		}
		ImportSelectionVM importSelectionVM = new ImportSelectionVM
		{
			AllowPlaylistSelection = flag,
			Playlists = value.Playlists,
			Libraries = value.Libraries,
			Playlist = (importProcess.SelectedPlaylist ?? value.ActivePlaylist),
			Library = (importProcess.SelectedLibrary ?? value.ActiveLibrary ?? value.Libraries[0])
		};
		if (new ImportSelector
		{
			DataContext = importSelectionVM
		}.ShowDialog() != true)
		{
			return new LibraryAndPlaylistDestinationSelection();
		}
		return new LibraryAndPlaylistDestinationSelection(importSelectionVM.Library, importSelectionVM.Playlist);
	}

	public IPowerpointDestinationSelection ShowImportPowerpointSelectionDialog(IImportProcess importProcess)
	{
		ILibraryService value = _libraryService.Value;
		ImportPowerpointSelectionVM importPowerpointSelectionVM = new ImportPowerpointSelectionVM
		{
			AllowPlaylistSelection = AllowSelectPlaylist(importProcess),
			Playlists = value.Playlists,
			Libraries = value.Libraries,
			Playlist = (importProcess.SelectedPlaylist ?? value.ActivePlaylist),
			Library = (importProcess.SelectedLibrary ?? value.ActiveLibrary ?? value.Libraries[0])
		};
		if (new PowerpointImportSelector
		{
			DataContext = importPowerpointSelectionVM
		}.ShowDialog() != true)
		{
			return new PowerpointDestinationSelection();
		}
		return new PowerpointDestinationSelection(importPowerpointSelectionVM.Library, importPowerpointSelectionVM.Playlist, importPowerpointSelectionVM.Size);
	}

	private static bool AllowSelectPlaylist(IImportProcess process)
	{
		if (!process.AllowSelectPlaylist)
		{
			return false;
		}
		IPlaylist<ProPresenterCue>? selectedPlaylist = process.SelectedPlaylist;
		if (selectedPlaylist != null && selectedPlaylist.Type == PlaylistType.PCO)
		{
			return false;
		}
		FileImportRequest fileImportRequest2 = default(FileImportRequest);
		int num;
		if (process.CurrentRequest is FileImportRequest fileImportRequest)
		{
			fileImportRequest2 = fileImportRequest.ParentRequest as FileImportRequest;
			num = ((fileImportRequest2 != null) ? 1 : 0);
		}
		else
		{
			num = 0;
		}
		bool flag = num == 0;
		if (!flag)
		{
			string fileExtension = fileImportRequest2.FileExtension;
			bool flag2 = ((fileExtension == ".proPlaylist" || fileExtension == ".proTheme") ? true : false);
			flag = !flag2;
		}
		return flag;
	}
}
