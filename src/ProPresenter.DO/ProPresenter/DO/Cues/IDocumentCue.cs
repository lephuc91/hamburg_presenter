using System;
using System.ComponentModel;
using Pro.Common.Components;
using Pro.DO.Storage;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Playlists;

namespace ProPresenter.DO.Cues;

public interface IDocumentCue : IFileResource, INotifyPropertyChanged, IActionRepoContainer, IHasMediaContainerId
{
	Guid ID { get; }

	IDocumentAction? DocumentAction { get; }

	string? LibraryName { get; }

	Playlist<ProPresenterCue>? PlaylistParent { get; set; }
}
