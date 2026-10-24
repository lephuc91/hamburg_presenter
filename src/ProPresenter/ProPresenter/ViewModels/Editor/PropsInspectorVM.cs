using System;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Media;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Mathematics;
using Pro.Common.Nullability;
using Pro.Common.Utility;
using Pro.DO.Transitions;
using Pro.Localization;
using Pro.UI.Components;
using Pro.UI.DialogService;
using ProPresenter.Controller.Outputs;
using ProPresenter.DO;
using ProPresenter.DO.Props;
using ProPresenter.DO.Slide;
using ProPresenter.UI.ViewModels.Editor;
using ProPresenter.UI.ViewModels.Props;

namespace ProPresenter.ViewModels.Editor;

public class PropsInspectorVM : LinkedNotifyPropertyChangedBase, IPropsInspectorVM, INotifyPropertyChanged
{
	private IPropCue? _selectedProp;

	private readonly IPropPrompts _propPrompts;

	public IPropCue? SelectedProp
	{
		get
		{
			return _selectedProp;
		}
		set
		{
			SetValue<IPropCue>("SelectedProp", ref _selectedProp, value, delegate(IPropCue o, IPropCue n)
			{
				if (o?.SlideAction != null)
				{
					o.SlideAction.Slide.PropertyChanged -= base.RaiseLinkedValues;
				}
				if (n?.SlideAction != null)
				{
					n.SlideAction.Slide.PropertyChanged += base.RaiseLinkedValues;
				}
				OnPropertyChanged("UseBackgroundColor");
				OnPropertyChanged("BackgroundColor");
				OnPropertyChanged("SelectedTransition");
				OnPropertyChanged("Slide");
			});
		}
	}

	public SlideBase? Slide => SelectedProp?.SlideAction?.Slide;

	public ssAPIOutput OutputController { get; }

	public bool UseBackgroundColor
	{
		get
		{
			return SelectedProp?.SlideAction?.Slide.UseBackgroundColor == true;
		}
		set
		{
			if (SelectedProp?.SlideAction != null)
			{
				SelectedProp.SlideAction.Slide.UseBackgroundColor = value;
			}
		}
	}

	public Color BackgroundColor
	{
		get
		{
			return SelectedProp?.SlideAction?.Slide.BackgroundColor ?? Colors.Transparent;
		}
		set
		{
			if (SelectedProp?.SlideAction != null)
			{
				SelectedProp.SlideAction.Slide.BackgroundColor = value;
			}
		}
	}

	public TransitionHandler TransitionHandler { get; } = new TransitionHandler(DataVault.Transitions);

	public TransitionParameters? SelectedTransition
	{
		get
		{
			return SelectedProp?.SlideAction?.Slide.SelectedTransition;
		}
		set
		{
			if (SelectedProp?.SlideAction?.Slide.SelectedTransition != value)
			{
				TransitionHandler.ActivateTransition(value);
				if (SelectedProp?.SlideAction != null)
				{
					SelectedProp.SlideAction.Slide.SelectedTransition = value;
				}
			}
		}
	}

	public Func<Vector2<double>, bool> ConfirmResize => (Vector2<double> s) => MessageDialogService.ShowDialog(string.Empty, LocalizedStrings.Get("EDITOR_PROP_INSPECTOR_RESIZE_alert"), DefaultButtons.YES | DefaultButtons.NO, DefaultButtons.YES) == DefaultButtons.YES;

	public ICommand<ColorPair> ColorChangeStartedCommand => new RelayCommand<ColorPair>(delegate
	{
		DataVault.PropCueCollection.UndoStack?.BeginCommit(UndoActionTypes.ChangeDocumentColor.ToAction());
	}, (ColorPair c) => c.OldColor.HasValue);

	public ICommand<ColorPair> ColorChangeFinishedCommand => new RelayCommand<ColorPair>(delegate
	{
		DataVault.PropCueCollection.UndoStack?.EndCommit(null, null, autoFinalize: true);
	}, (ColorPair c) => c.OldColor.HasValue && (DataVault.PropCueCollection.UndoStack?.IsRecording ?? false));

	public ICommand RemoveTransitionCommand => new RelayCommand(TransitionHandler.RemoveTransition);

	public ICommand<double> SetAutoClearCommand => new RelayCommand<double>(delegate(double t)
	{
		(SelectedProp?.SlideAction).ThrowWhenNull("SelectedProp?.SlideAction");
		SelectedProp.SlideAction.AutoClearDuration = t;
		SelectedProp.SlideAction.AutoClearEnabled = t > 0.0;
	}, (double s) => SelectedProp != null);

	public ICommand SetCustomAutoClearCommand => new RelayCommand(SetCustomAutoClearCommandExecuted, () => SelectedProp != null);

	public PropsInspectorVM(ssAPIOutput outputController, IPropPrompts propPrompts)
	{
		OutputController = outputController;
		_propPrompts = propPrompts;
		TransitionHandler.TransitionFinalized += delegate(TransitionParameters? t)
		{
			SelectedTransition = t;
		};
		LinkProperties("SelectedTransition", "SelectedTransition");
		LinkProperties("UseBackgroundColor", "UseBackgroundColor");
		LinkProperties("BackgroundColor", "BackgroundColor");
		LinkProperties("SelectedTransition", "SelectedTransition");
		if (DataVault.PropCueCollection != null)
		{
			DataVault.PropCueCollection.PropertyChanged += base.RaiseLinkedValues;
		}
	}

	private void SetCustomAutoClearCommandExecuted()
	{
		(SelectedProp?.SlideAction).ThrowWhenNull("SelectedProp?.SlideAction");
		double? num = _propPrompts.ShowDialogAutoClearCustomTimePrompt(SelectedProp.SlideAction.AutoClearDuration);
		if (num.HasValue)
		{
			SelectedProp.SlideAction.AutoClearDuration = num.Value;
		}
	}
}
