using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Utility;
using Pro.DO.Effects;
using Pro.DO.Effects.Descriptions;
using Pro.DO.Effects.Extensions;
using Pro.Localization;
using Pro.UI.Components;
using Pro.UI.DialogService;
using ProPresenter.Controller;
using ProPresenter.DO;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Media;
using ProPresenter.DO.Media.Properties;
using ProPresenter.DO.Playlists;
using ProPresenter.UI.CueInspector;
using ProPresenter.UI.ViewModels.CueInspector;

namespace ProPresenter.ViewModels.CueInspector;

public class EffectsVM : NotifyPropertyChangedBase, IEffectsVM, INotifyPropertyChanged
{
	private readonly ICoreManager _manager;

	private readonly IDebouncer _refreshThumbnailDebouncer;

	private readonly SavePresetContent _savePresetContent = new SavePresetContent();

	private MediaCue? _activeMediaCue;

	public MediaCue? ActiveMediaCue
	{
		get
		{
			return _activeMediaCue;
		}
		set
		{
			SetValue<MediaCue>("ActiveMediaCue", ref _activeMediaCue, value, delegate(MediaCue o, MediaCue n)
			{
				if (o != null && o.MediaAction?.Media is IDrawMedia drawMedia)
				{
					EffectsCollection effects = drawMedia.Drawing.Effects;
					effects.ForEach(delegate(EffectParameters p)
					{
						p.ParametersChanged -= EffectParameterChanged;
						p.PropertyChanged -= EffectPropertyChanged;
					});
					effects.CollectionChanged -= Effects_CollectionChanged;
				}
				if (n != null && n.MediaAction?.Media is IDrawMedia drawMedia2)
				{
					EffectsCollection effects2 = drawMedia2.Drawing.Effects;
					effects2.ForEach(delegate(EffectParameters p)
					{
						p.ParametersChanged += EffectParameterChanged;
						p.PropertyChanged += EffectPropertyChanged;
					});
					effects2.CollectionChanged += Effects_CollectionChanged;
				}
				OnPropertyChanged("MediaEffects");
			});
		}
	}

	private VisualMedia? VisualMedia => _activeMediaCue?.MediaAction?.VisualMedia;

	private DrawingProperties? Drawing => (_activeMediaCue?.MediaAction?.Media as IDrawMedia)?.Drawing;

	public IReadOnlyList<EffectDescription> AvailableEffects => OutputVault.AvailableEffects ?? Array.Empty<EffectDescription>();

	public EffectsCollection? MediaEffects => Drawing?.Effects;

	public ObservableCollection<EffectParameters> SelectedEffects { get; } = new ObservableCollection<EffectParameters>();

	public EffectsPresetCollection PresetCollection => DataVault.EffectsPresetCollection;

	public ICommand<EffectsCollection> AddNewEffectsPresetCommand => new RelayCommand<EffectsCollection>(OnAddNewEffectsPresetCommand);

	public ICommand RemoveAllEffectsCommand => new RelayCommand(OnRemoveAllEffectsCommand, () => Drawing != null);

	public ICommand<EffectsCollection> RemoveEffectsPresetCommand => new RelayCommand<EffectsCollection>(OnRemoveEffectsPresetCommand);

	public ICommand<EffectsCollection> RenameEffectsPresetCommand => new RelayCommand<EffectsCollection>(OnRenameEffectsPresetCommand, (EffectsCollection p) => p != null);

	public ICommand<EffectCommandParameters> RemoveEffectCommand => new RelayCommand<EffectCommandParameters>(OnRemoveEffectCommand, (EffectCommandParameters e) => Drawing != null);

	public ICommand<EffectsCollection> SetEffectsPresetCommand => new RelayCommand<EffectsCollection>(OnSetEffectsPresetCommand);

	public ICommand SaveEffectsPresetCommand => new RelayCommand(OnSaveEffectsPresetCommand);

	public ICommand<EffectCommandParameters> UpdateEffectCommand => new RelayCommand<EffectCommandParameters>(OnUpdateEffectsCommand, (EffectCommandParameters e) => _activeMediaCue != null && Drawing != null);

	public ICommand UnlinkPresetCommand => new RelayCommand(OnUnlinkPresetCommand, () => Drawing != null);

	public ICommand SaveAsNewEffectPresetCommand => new RelayCommand(OnSaveAsNewEffectPresetCommand);

	public EffectsVM(ICoreManager manager, IDebouncerFactory debouncerFactory)
	{
		_manager = manager;
		_refreshThumbnailDebouncer = debouncerFactory.CreateDispatched(delegate
		{
			VisualMedia?.RefreshThumbnail(userInitiated: true);
		});
	}

	private void Effects_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		SetCIEffects();
		e.OldItems?.OfType<EffectParameters>().ForEach(delegate(EffectParameters p)
		{
			p.ParametersChanged -= EffectParameterChanged;
			p.PropertyChanged -= EffectPropertyChanged;
		});
		e.NewItems?.OfType<EffectParameters>().ForEach(delegate(EffectParameters p)
		{
			p.ParametersChanged += EffectParameterChanged;
			p.PropertyChanged += EffectPropertyChanged;
		});
	}

	private void EffectPropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		SetCIEffects();
	}

	private void EffectParameterChanged(EffectParameters param)
	{
		_manager.UpdateCIEffect(param);
		_refreshThumbnailDebouncer.Invoke();
	}

	private void OnAddNewEffectsPresetCommand(EffectsCollection preset)
	{
		if (Drawing != null)
		{
			preset.ID = Guid.NewGuid();
			Drawing.Effects.ForEach(delegate(EffectParameters i)
			{
				preset.AddEffect(i.MakeCopy());
			});
			Drawing.Effects.Name = preset.Name;
			Drawing.Effects.ID = preset.ID;
			Drawing.Effects.HasChanges = false;
			preset.Lock();
			PresetCollection.AddNewEffectsPreset(preset);
		}
	}

	private void OnRemoveEffectsPresetCommand(EffectsCollection preset)
	{
		SearchAllVisualMedia(preset, delegate(MediaBase m, EffectsCollection p)
		{
			OnRemoveAllEffectsCommand((m as IDrawMedia)?.Drawing);
		});
		PresetCollection.RemoveEffectsPreset(preset);
	}

	private void OnRenameEffectsPresetCommand(EffectsCollection preset)
	{
		ShowSavePresetDialog(LocalizedStrings.Get("CUE_INSPECTOR_EFFECTS_TAB_RENAME_PRESET_title"), preset.Name, onRename);
		void onRename(string name)
		{
			preset.Name = name;
			SearchAllVisualMedia(preset, delegate(MediaBase m, EffectsCollection e)
			{
				((IDrawMedia)m).Drawing.Effects.Name = e.Name;
			});
		}
	}

	private void OnSetEffectsPresetCommand(EffectsCollection preset)
	{
		if (Drawing != null)
		{
			Drawing.Effects.Name = preset.Name;
			Drawing.Effects.ID = preset.ID;
			Drawing.Effects.UpdateEffects(preset.Select((EffectParameters p) => p.MakeCopy()));
		}
	}

	private void OnRemoveEffectCommand(EffectCommandParameters parameter)
	{
		if ((object)parameter.TargetEffectParameters != null)
		{
			Drawing?.Effects.RemoveEffect(parameter.TargetEffectParameters);
		}
	}

	private void OnRemoveAllEffectsCommand()
	{
		RemoveEffects(Drawing);
	}

	private static void OnRemoveAllEffectsCommand(DrawingProperties? drawing)
	{
		RemoveEffects(drawing);
	}

	private static void RemoveEffects(DrawingProperties? drawing)
	{
		if (drawing != null)
		{
			drawing.Effects.ID = Guid.Empty;
			drawing.Effects.RemoveAllEffects();
		}
	}

	private void OnSaveEffectsPresetCommand()
	{
		EffectsCollection effectsCollection = PresetCollection.FirstOrDefault(delegate(EffectsCollection e)
		{
			Guid iD = e.ID;
			Guid? obj = MediaEffects?.ID;
			return iD == obj;
		});
		if (effectsCollection == null)
		{
			return;
		}
		effectsCollection.UpdateEffects(MediaEffects?.Collect((EffectParameters p) => p.MakeCopy()) ?? Enumerable.Empty<EffectParameters>());
		SearchAllVisualMedia(effectsCollection, delegate(MediaBase m, EffectsCollection p)
		{
			((IDrawMedia)m).Drawing.Effects.UpdateEffects(p.Select((EffectParameters e) => e.MakeCopy()));
		});
		if (Drawing != null)
		{
			Drawing.Effects.HasChanges = false;
		}
	}

	private void OnUpdateEffectsCommand(EffectCommandParameters parameter)
	{
		EffectParameters targetEffectParameters = parameter.TargetEffectParameters;
		if (parameter.IsReplace)
		{
			if ((object)targetEffectParameters != null)
			{
				Drawing?.Effects.ReplaceEffect(targetEffectParameters, new EffectParameters(parameter.NewEffect, targetEffectParameters.IsEnabled));
			}
		}
		else
		{
			Drawing?.Effects.AddEffect(new EffectParameters(parameter.NewEffect, isEnabled: true));
		}
	}

	private static void SearchAllVisualMedia(EffectsCollection preset, Action<MediaBase, EffectsCollection> action)
	{
		(from m in DataVault.VisualPlaylistCollection.GetPlaylists((IPlaylist<MediaCue> p) => true).OfType<VisualPlaylist>().SelectMany((VisualPlaylist p) => p.OfType<MediaCue>())
			where m.MediaAction?.Media is IDrawMedia drawMedia && drawMedia.Drawing.Effects.ID == preset.ID
			select m).ForEach(delegate(MediaCue i)
		{
			action(i.MediaAction.Media, preset);
		});
	}

	private void OnUnlinkPresetCommand()
	{
		if (Drawing != null)
		{
			Drawing.Effects.ID = Guid.Empty;
		}
	}

	private void SetCIEffects()
	{
		_manager.SetCIEffects(MediaEffects ?? new EffectsCollection());
		_refreshThumbnailDebouncer.Invoke();
	}

	private void OnSaveAsNewEffectPresetCommand()
	{
		ShowSavePresetDialog(LocalizedStrings.Get("CUE_INSPECTOR_EFFECTS_TAB_NEW_PRESET_title"), string.Empty, delegate(string n)
		{
			OnAddNewEffectsPresetCommand(new EffectsCollection(n));
		});
	}

	private void ShowSavePresetDialog(string title, string name, Action<string> newNameCallback)
	{
		((DependencyObject)_savePresetContent).SetCurrentValue(SavePresetContent.PresetNameProperty, (object)name);
		if (MessageDialogService.ShowSimpleContent(title, (DependencyObject)(object)_savePresetContent))
		{
			string newName = _savePresetContent.PresetName;
			if (PresetCollection.Any((EffectsCollection p) => p.Name.Equals(newName)))
			{
				MessageDialogService.ShowAlert(LocalizedStrings.Get("CUE_INSPECTOR_EFFECTS_TAB_PRESET_ALERT_info"));
			}
			else
			{
				newNameCallback?.Invoke(newName ?? string.Empty);
			}
		}
	}
}
