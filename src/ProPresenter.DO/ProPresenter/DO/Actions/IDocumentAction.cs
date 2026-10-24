using System;
using System.ComponentModel;
using Pro.Common.Components;
using Pro.Common.Dispatcher;
using Pro.Common.ObjectBinding;
using Pro.Common.Time;
using Pro.DO.Storage;
using Pro.DO.Triggering;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.Chords;
using ProPresenter.DO.Librarian;
using ProPresenter.DO.Presentation;

namespace ProPresenter.DO.Actions;

public interface IDocumentAction : Pro.DO.Triggering.IAction, ICloneable<Pro.DO.Triggering.IAction>, INotifyPropertyChanged, IDisposable, IHasMediaContainerId
{
	ProPresenter.DO.Presentation.IPresentation? Presentation { get; }

	PresentationType PresentationType { get; }

	string LibraryName { get; }

	string? ActiveArrangementName { get; }

	IArrangement? ActiveArrangement { get; set; }

	Key? TargetKey { get; set; }

	OutputDestination Destination { get; set; }

	TimeSlice? DocumentLoopTime { get; }

	RelativePath DocumentPath { get; }

	PlaylistItem.Types.Presentation OnProtoSerializePlaylistItem();

	void OnProtoDeserializePlaylistItem(PlaylistItem playlistItem);

	void StopWatchingMedia();

	void StartWatchingMedia();

	void EnsurePresentationResolved(ILibraryCollection library);

	ObjectBinder<DocumentAction, IPlaylistItem.Types.IPresentation> CreatePlaylistBinder(IUiScheduler scheduler, IEntityFactory entityFactory, IPlaylistItem.Types.IPresentation presentation);
}
