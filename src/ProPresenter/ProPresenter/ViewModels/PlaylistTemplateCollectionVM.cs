using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
using System.Windows.Input;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Logging;
using Pro.Common.Utility;
using Pro.DO.Application;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;
using Pro.UI.Components;
using Pro.UI.Utility;
using ProPresenter.DO;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Analytics;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.Presentation;
using ProPresenter.UI.LibraryView;
using ProPresenter.UI.ViewModels;
using ProPresenter.ViewModels.Library;

namespace ProPresenter.ViewModels;

public class PlaylistTemplateCollectionVM : LinkedNotifyPropertyChangedBase, IPlaylistTemplateCollectionVM, INotifyPropertyChanged
{
	private readonly IPlaylistTemplatesService _service;

	private readonly IProPresenterCueFactory _cueFactory;

	private readonly ILogger _logger;

	private readonly IEntityFactory _entityFactory;

	private readonly Lazy<PlaylistTemplatesWindow> _editTemplatesWindow;

	private IPlaylistTemplateItemVM? _selectedTemplate;

	public ICollectionView Templates { get; }

	public ICollectionView TemplatesView { get; }

	public IPlaylistTemplateItemVM? SelectedTemplate
	{
		get
		{
			return _selectedTemplate;
		}
		set
		{
			SetValue("SelectedTemplate", ref _selectedTemplate, value);
		}
	}

	public ObservableCollection<IPlaylistTemplateItemVM> SelectedTemplates { get; } = new ObservableCollection<IPlaylistTemplateItemVM>();

	public ICommand<Playlist<ProPresenterCue>> SaveAsTemplateCommand => new RelayCommand<Playlist<ProPresenterCue>>(SaveAsTemplateCommandExecuted, (Playlist<ProPresenterCue> p) => p != null && p.Type != PlaylistType.Group);

	public ICommand EditTemplatesCommand => new RelayCommand(EditTemplatesCommandExecuted);

	public ICommand DeleteTemplateCommand => new RelayCommand(DeleteTemplateCommandExecuted, () => SelectedTemplates.Any());

	public PlaylistTemplateCollectionVM(IProPresenterResourceService resourceService, IProPresenterCueFactory cueFactory, IPlaylistTemplatesService templatesService, ILogger logger, IEntityFactory entityFactory)
	{
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		PlaylistTemplateCollectionVM dataContext = this;
		_editTemplatesWindow = new Lazy<PlaylistTemplatesWindow>(() => new PlaylistTemplatesWindow().WithDataContext(dataContext));
		_service = templatesService;
		_cueFactory = cueFactory;
		_logger = logger;
		_entityFactory = entityFactory;
		PairedCollection<IPlaylist<ProPresenterCue>, IPlaylistTemplateItemVM> source = new PairedCollection<IPlaylist<ProPresenterCue>, IPlaylistTemplateItemVM>(_service.Templates, (IPlaylist<ProPresenterCue> t) => new PlaylistTemplateItemVM((GeneralPlaylist)t, templatesService));
		TemplatesView = CollectionViewSource.GetDefaultView(source);
		if (TemplatesView is ListCollectionView listCollectionView)
		{
			((Collection<SortDescription>)(object)listCollectionView.SortDescriptions).Add(new SortDescription("Name", ListSortDirection.Ascending));
			listCollectionView.IsLiveSorting = true;
			listCollectionView.LiveSortingProperties.Add("Name");
			listCollectionView.CustomSort = new NaturalStringComparer<IPlaylistTemplateItemVM>((IPlaylistTemplateItemVM? d) => d?.Name ?? string.Empty);
		}
		Templates = CollectionViewSource.GetDefaultView(_service.Templates);
		if (Templates is ListCollectionView listCollectionView2)
		{
			((Collection<SortDescription>)(object)listCollectionView2.SortDescriptions).Add(new SortDescription("Name", ListSortDirection.Ascending));
			listCollectionView2.IsLiveSorting = true;
			listCollectionView2.LiveSortingProperties.Add("Name");
			listCollectionView2.CustomSort = new NaturalStringComparer<GeneralPlaylist>((GeneralPlaylist? d) => d?.Name ?? string.Empty);
		}
	}

	private void SaveAsTemplateCommandExecuted(Playlist<ProPresenterCue>? playlist)
	{
		if (playlist == null || !_service.ShowSaveAsTemplateDialog(playlist.Name, out string newName) || !_service.ResolveConflict(newName, out string newName2))
		{
			return;
		}
		bool flag = _service.Templates.Any((IPlaylist<ProPresenterCue> p) => p.Name == newName2);
		GeneralPlaylist generalPlaylist = new GeneralPlaylist(_logger, _cueFactory, null, newName2, isTemplate: true);
		if (playlist is PCOPlaylist pcoPlaylist)
		{
			playlist = pcoPlaylist.ConvertToStandardPlaylist(null, _entityFactory, _logger, _cueFactory);
		}
		IEnumerable<ProPresenterCue> enumerable = playlist;
		foreach (ProPresenterCue item in enumerable ?? Enumerable.Empty<ProPresenterCue>())
		{
			ProPresenterCue proPresenterCue = null;
			if (item is DocumentCue documentCue)
			{
				ProPresenter.DO.Presentation.IPresentation presentation = documentCue.DocumentAction.Presentation?.Clone();
				if (presentation != null)
				{
					PlaylistItem playlistItem = documentCue.ProtoSerializePlaylistItem();
					DocumentCue documentCue2 = new DocumentCue(new DocumentAction(presentation));
					documentCue2.ProtoDeserializePlaylistItem(playlistItem, new ApplicationData(ApplicationType.ProPresenter), "PlaylistTemplate");
					proPresenterCue = documentCue2;
				}
			}
			else
			{
				proPresenterCue = item.Clone() as ProPresenterCue;
			}
			if (proPresenterCue != null)
			{
				generalPlaylist.AddItem(proPresenterCue);
			}
		}
		int index = -1;
		if (flag)
		{
			IPlaylist<ProPresenterCue> playlist2 = _service.Templates.FirstOrDefault((IPlaylist<ProPresenterCue> d) => d.Name == newName2);
			if (playlist2 != null)
			{
				index = _service.Templates.IndexOf(playlist2);
				_service.Templates.RemovePlaylists(playlist2.ToEnumerable());
			}
		}
		TemplatePlaylistCreateEvent.Publish(generalPlaylist);
		_service.Templates.AddPlaylist(generalPlaylist, null, index);
	}

	private void EditTemplatesCommandExecuted()
	{
		_editTemplatesWindow.Value.Show();
	}

	private void DeleteTemplateCommandExecuted()
	{
		_service.Templates.RemovePlaylists(SelectedTemplates.Select((IPlaylistTemplateItemVM i) => i.Template).ToArray());
		SelectedTemplates.Clear();
	}
}
