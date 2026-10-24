using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Pro.DO.Effects;
using Pro.DO.Effects.Descriptions;
using Pro.UI.Components;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Media;
using ProPresenter.UI.CueInspector;

namespace ProPresenter.UI.ViewModels.CueInspector;

public interface IEffectsVM : INotifyPropertyChanged
{
	MediaCue? ActiveMediaCue { get; set; }

	IReadOnlyList<EffectDescription> AvailableEffects { get; }

	EffectsCollection? MediaEffects { get; }

	ObservableCollection<EffectParameters> SelectedEffects { get; }

	EffectsPresetCollection PresetCollection { get; }

	ICommand<EffectsCollection> AddNewEffectsPresetCommand { get; }

	ICommand RemoveAllEffectsCommand { get; }

	ICommand<EffectsCollection> RemoveEffectsPresetCommand { get; }

	ICommand<EffectsCollection> RenameEffectsPresetCommand { get; }

	ICommand<EffectCommandParameters> RemoveEffectCommand { get; }

	ICommand<EffectsCollection> SetEffectsPresetCommand { get; }

	ICommand SaveEffectsPresetCommand { get; }

	ICommand<EffectCommandParameters> UpdateEffectCommand { get; }

	ICommand UnlinkPresetCommand { get; }

	ICommand SaveAsNewEffectPresetCommand { get; }
}
