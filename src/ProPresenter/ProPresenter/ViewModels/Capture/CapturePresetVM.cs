using System;
using System.Collections.Generic;
using System.Linq;
using CommunityToolkit.Mvvm.Input;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Strings;
using ProPresenter.DO;
using ProPresenter.DO.Capture;
using ProPresenter.DO.OutputConfiguration;

namespace ProPresenter.ViewModels.Capture;

public class CapturePresetVM : LinkedNotifyPropertyChangedBase, ICapturePresetVM
{
	private readonly ICaptureService _captureService;

	private readonly ICaptureNameVM _captureNameVM;

	private readonly IEnumerable<ScreenArrangementBase> _audienceScreens;

	public ICapturePresetCollection Presets => _captureService.CaptureSettings.Presets;

	public ICapturePreset? ActivePreset
	{
		get
		{
			return _captureService.CaptureSettings.ActivePreset;
		}
		set
		{
			_captureService.CaptureSettings.ActivePreset = value;
		}
	}

	public bool ExistingPresetSelected => Presets.Any(delegate(ICapturePreset p)
	{
		Guid iD = p.ID;
		Guid? obj = ActivePreset?.ID;
		return iD == obj;
	});

	public bool AnyPresets => Presets.Any();

	public IRelayCommand NoPresetCommand => new RelayCommand(NoPresetCommandExecuted);

	public IRelayCommand<ICapturePreset> SelectPresetCommand => new RelayCommand<ICapturePreset>(SelectPresetCommandExecuted);

	public IRelayCommand SaveAsPresetCommand => new RelayCommand(SavePresetAsCommandExecuted);

	public IRelayCommand RenamePresetCommand => new RelayCommand(RenamePresetCommandExecuted);

	public IRelayCommand DeletePresetCommand => new RelayCommand(DeletePresetCommandExecuted);

	private UndoStack UndoStack => _captureService.CaptureSettings.UndoStack;

	public CapturePresetVM(ICaptureService captureService, ICaptureNameVM captureNameVM)
	{
		_captureService = captureService;
		_captureNameVM = captureNameVM;
		_audienceScreens = _captureService.AudienceScreens;
		LinkProperties("ActivePreset", new string[3] { "ActivePreset", "ExistingPresetSelected", "AnyPresets" });
		_captureService.CaptureSettings.PropertyChanged += base.RaiseLinkedValues;
	}

	private void NoPresetCommandExecuted()
	{
		if (ActivePreset != null)
		{
			ICapturePreset capturePreset = ActivePreset.Clone();
			capturePreset.ID = Guid.NewGuid();
			capturePreset.Name = string.Empty;
			ActivePreset = capturePreset;
		}
	}

	private void SelectPresetCommandExecuted(ICapturePreset? preset)
	{
		if (preset != null)
		{
			ActivePreset = preset;
			ScreenArrangementBase screenArrangementBase = _audienceScreens?.FirstOrDefault();
			Guid? guid = ActivePreset?.DefaultStream?.ScreenID;
			Guid empty = Guid.Empty;
			if (guid.HasValue && guid.GetValueOrDefault() == empty && screenArrangementBase != null)
			{
				ActivePreset.DefaultStream.ScreenID = screenArrangementBase.ID;
				ActivePreset.DefaultStream.ScreenName = screenArrangementBase.Name;
			}
		}
	}

	private void SavePresetAsCommandExecuted()
	{
		if (ActivePreset == null)
		{
			return;
		}
		string nameValue = ActivePreset.Name.DuplicateName(Presets, (ICapturePreset p) => p.Name);
		if (!_captureNameVM.TryGetPresetName(out string presetName, nameValue))
		{
			return;
		}
		ICapturePreset oldPreset = ActivePreset;
		ICapturePreset newPreset = ActivePreset.Clone();
		if (newPreset != null)
		{
			newPreset.Name = presetName;
			SavePreset(newPreset);
			UndoStack?.Commit(UndoActionTypes.CreatePreset.ToAction(), delegate
			{
				UndoStack.StartIgnoring();
				ActivePreset = oldPreset;
				Presets.RemovePreset(newPreset);
				OnPropertyChanged("ExistingPresetSelected");
				UndoStack.StopIgnoring();
			}, delegate
			{
				SavePreset(newPreset);
			}, null, null, autoFinalize: true);
		}
	}

	private void SavePreset(ICapturePreset preset)
	{
		UndoStack?.StartIgnoring();
		ActivePreset = preset;
		Presets.AddPreset(preset);
		OnPropertyChanged("ExistingPresetSelected");
		preset.UndoStack?.StopIgnoring();
	}

	private void RenamePresetCommandExecuted()
	{
		if (ActivePreset != null && _captureNameVM.TryGetPresetName(out string presetName, ActivePreset.Name))
		{
			ActivePreset.Name = presetName;
		}
	}

	private void DeletePresetCommandExecuted()
	{
		if (ActivePreset != null)
		{
			_captureService.CaptureSettings.UndoStack?.BeginCommit();
			ICapturePreset preset = ActivePreset;
			RemovePreset();
			_captureService.CaptureSettings.UndoStack?.Commit(UndoActionTypes.DeletePreset.ToAction(), delegate
			{
				UndoStack.StartIgnoring();
				Presets.AddPreset(preset);
				ActivePreset = preset;
				UndoStack.StopIgnoring();
			}, RemovePreset);
			_captureService.CaptureSettings.UndoStack?.EndCommit(null, null, autoFinalize: true);
		}
	}

	private void RemovePreset()
	{
		if (ActivePreset != null)
		{
			UndoStack?.StartIgnoring();
			Presets.RemovePreset(ActivePreset);
			NoPresetCommandExecuted();
			UndoStack?.StopIgnoring();
		}
	}
}
