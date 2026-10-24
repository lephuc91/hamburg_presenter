using System;
using System.Windows.Input;
using Pro.Common.Collections;
using Pro.UI.Components;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Actions.Capture;
using ProPresenter.DO.Capture;
using ProPresenter.UI.ViewModels;

namespace ProPresenter.ViewModels.Actions;

public class CaptureActionDialogVM : ActionDialogContentVM
{
	private CaptureAction? _captureAction;

	public INotifyEnumerableChanged<ICapturePreset> Presets { get; }

	public CaptureType CaptureType
	{
		get
		{
			return CaptureAction?.CaptureType ?? CaptureType.Start;
		}
		set
		{
			if (CaptureAction != null)
			{
				CaptureAction.CaptureType = value;
			}
		}
	}

	public CaptureStart? CaptureStart => _captureAction?.Capture as CaptureStart;

	public CaptureStop? CaptureStop => _captureAction?.Capture as CaptureStop;

	public ICommand SelectActivePresetCommand => new RelayCommand(SelectActivePresetCommandExecute);

	public ICommand<CapturePreset> SelectPresetCommand => new RelayCommand<CapturePreset>(SelectPresetCommandExecute, (CapturePreset p) => base.ActionStore?.CanAssign(p, base.Action) ?? false);

	private CaptureAction? CaptureAction => _captureAction;

	public CaptureActionDialogVM(INotifyEnumerableChanged<ICapturePreset> presets)
	{
		LinkAction("CaptureType", NotifyPropertyChanged);
		Presets = presets;
	}

	protected override void OnContextChanged(IActionDialogContext? oldValue, IActionDialogContext? newValue)
	{
		if (oldValue?.Action is CaptureAction captureAction)
		{
			captureAction.PropertyChanged -= base.RaiseLinkedValues;
		}
		_captureAction = newValue?.Action as CaptureAction;
		if (_captureAction != null)
		{
			_captureAction.PropertyChanged += base.RaiseLinkedValues;
		}
		NotifyPropertyChanged();
	}

	private void SelectActivePresetCommandExecute()
	{
		SelectPreset(Guid.Empty, string.Empty);
	}

	private void SelectPresetCommandExecute(CapturePreset preset)
	{
		if (base.ActionStore.CanAssignData(preset, base.Action))
		{
			SelectPreset(preset.ID, preset.Name);
		}
	}

	private void SelectPreset(Guid id, string name)
	{
		if (base.Action is CaptureAction captureAction)
		{
			captureAction.SetIdentifier(id, name);
		}
		NotifyPropertyChanged();
	}

	private void NotifyPropertyChanged()
	{
		OnPropertyChanged("CaptureType");
		OnPropertyChanged("CaptureStop");
		OnPropertyChanged("CaptureStart");
	}
}
