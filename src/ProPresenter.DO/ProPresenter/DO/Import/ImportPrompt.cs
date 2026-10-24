using System;
using System.Collections.Generic;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Playlists;

namespace ProPresenter.DO.Import;

public static class ImportPrompt
{
	public delegate void ImportStartedDelegate(ImportProcess process);

	public delegate void ImportCompletedDelegate(IImportProcess process);

	public delegate void ResolveConflictDelegate(IImportRequest request, string name, out bool applyToAll, out bool skip, out bool overwrite, out bool abort);

	public delegate void HandleOptionsDelegate(ImportProcess process, DocumentOptions[] options, Action<DocumentOptions> singleImport, out bool importRemaining, out bool abort);

	public delegate void AddToSelectedPlaylistDelegate(DocumentCue documentCue);

	public delegate void AddToPlaylistDelegate(DocumentCue documentCue, IPlaylist<ProPresenterCue> playlist);

	public delegate LibraryAndPlaylist? SelectLibraryAndPlaylistDelegate(IImportProcess process);

	public delegate bool ItemExistsDelegate(ImportProcess process, string name, IImportRequest request);

	public delegate string DuplicateNameDelegate(ImportProcess process, string name, IImportRequest request);

	private static readonly Dictionary<RequestHandlerType, ResolveConflictDelegate> _conflictDelegates = new Dictionary<RequestHandlerType, ResolveConflictDelegate>();

	private static readonly Dictionary<RequestHandlerType, ItemExistsDelegate> _itemExistsDelegates = new Dictionary<RequestHandlerType, ItemExistsDelegate>();

	private static readonly Dictionary<RequestHandlerType, DuplicateNameDelegate> _duplicateNamesDelegates = new Dictionary<RequestHandlerType, DuplicateNameDelegate>();

	private static ImportStartedDelegate? _importStarted = null;

	private static ImportCompletedDelegate? _importCompleted = null;

	private static HandleOptionsDelegate? _handleOptions = null;

	private static AddToSelectedPlaylistDelegate? _addToSelectedPlaylist = null;

	private static AddToPlaylistDelegate? _addToPlaylist = null;

	public static void SetImportStarted(ImportStartedDelegate importStarted)
	{
		if (_importStarted != null)
		{
			throw new InvalidOperationException();
		}
		_importStarted = importStarted;
	}

	public static void SetImportCompleted(ImportCompletedDelegate importCompleted)
	{
		if (_importCompleted != null)
		{
			throw new InvalidOperationException();
		}
		_importCompleted = importCompleted;
	}

	public static void RegisterResolveConflictPrompt(RequestHandlerType handlerType, ResolveConflictDelegate resolveConflict)
	{
		if (!_conflictDelegates.TryAdd(handlerType, resolveConflict))
		{
			throw new InvalidOperationException();
		}
	}

	public static void RegisterItemExistsPrompt(RequestHandlerType handlerType, ItemExistsDelegate itemExists)
	{
		if (!_itemExistsDelegates.TryAdd(handlerType, itemExists))
		{
			throw new InvalidOperationException();
		}
	}

	public static void RegisterDuplicateNamePrompt(RequestHandlerType handlerType, DuplicateNameDelegate duplicateName)
	{
		if (!_duplicateNamesDelegates.TryAdd(handlerType, duplicateName))
		{
			throw new InvalidOperationException();
		}
	}

	public static void SetHandleOptions(HandleOptionsDelegate handleOptions)
	{
		if (_handleOptions != null)
		{
			throw new InvalidOperationException();
		}
		_handleOptions = handleOptions;
	}

	public static void SetAddToSelectedPlaylist(AddToSelectedPlaylistDelegate addToSelectedPlaylist)
	{
		if (_addToSelectedPlaylist != null)
		{
			throw new InvalidOperationException();
		}
		_addToSelectedPlaylist = addToSelectedPlaylist;
	}

	public static void SetAddToPlaylist(AddToPlaylistDelegate? addToPlaylist)
	{
		_addToPlaylist = addToPlaylist;
	}

	internal static void ImportStarted(ImportProcess process)
	{
		_importStarted?.Invoke(process);
	}

	internal static void ImportCompleted(ImportProcess process)
	{
		_importCompleted?.Invoke(process);
	}

	public static void ResolveConflict(RequestHandlerType handlerType, IImportRequest request, string name, out bool applyToAll, out bool skip, out bool overwrite, out bool abort)
	{
		applyToAll = false;
		skip = false;
		overwrite = true;
		abort = false;
		if (_conflictDelegates.TryGetValue(handlerType, out ResolveConflictDelegate value))
		{
			value(request, name, out applyToAll, out skip, out overwrite, out abort);
		}
	}

	public static void HandleOptions(ImportProcess process, DocumentOptions[] options, Action<DocumentOptions> singleImport, out bool importRemaining, out bool abort)
	{
		if (_handleOptions == null)
		{
			importRemaining = true;
			abort = false;
		}
		else
		{
			_handleOptions(process, options, singleImport, out importRemaining, out abort);
		}
	}

	public static void AddToPlaylist(DocumentCue documentCue, IPlaylist<ProPresenterCue> playlist)
	{
		_addToPlaylist?.Invoke(documentCue, playlist);
	}

	internal static bool? ItemExists(ImportProcess process, RequestHandlerType type, string name, IImportRequest request)
	{
		ItemExistsDelegate value;
		return _itemExistsDelegates.TryGetValue(type, out value) && value(process, name, request);
	}

	internal static string DuplicateName(ImportProcess process, RequestHandlerType type, string name, IImportRequest request)
	{
		if (!_duplicateNamesDelegates.TryGetValue(type, out DuplicateNameDelegate value))
		{
			return name;
		}
		return value(process, name, request);
	}
}
