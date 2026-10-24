using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.DO.Analytics;
using Pro.DO.Label;
using Pro.UI.Components;
using Pro.UI.Controls;
using Pro.UI.Utility;
using ProPresenter.DO.Label;

namespace ProPresenter.UI.ViewModels;

public class LabelEditorVM : LinkedNotifyPropertyChangedBase
{
	private readonly Lazy<AnchoredPopup>? _popover;

	private ILabelInteractor? _interactor;

	private bool _ignoreChanges;

	private bool _saveToPreferences;

	private Color _color;

	private string _name = string.Empty;

	public IEnumerable<ILabel>? Labels => _interactor?.Labels;

	public string Name
	{
		get
		{
			return _name;
		}
		set
		{
			SetValue("Name", ref _name, value, OnNameChanged);
		}
	}

	public Color Color
	{
		get
		{
			return _color;
		}
		private set
		{
			SetValue("Color", ref _color, value, ApplyChanges);
		}
	}

	public string SaveLabel => _interactor?.SaveLabel ?? string.Empty;

	public bool CanSaveToPreferences
	{
		get
		{
			if (!string.IsNullOrEmpty(Name) && Labels != null)
			{
				return Labels.None((ILabel l) => l.Text == Name);
			}
			return false;
		}
	}

	public bool SaveToPreferences
	{
		get
		{
			return _saveToPreferences;
		}
		set
		{
			SetValue("SaveToPreferences", ref _saveToPreferences, value);
		}
	}

	public bool MultipleValues => _interactor?.MultipleTargets ?? false;

	public bool MultipleColors => _interactor?.MultipleColors ?? false;

	public ICommand<ILabel> SelectLabelCommand => new RelayCommand<ILabel>(OnSelectLabelCommand);

	public ICommand<Color> SelectColorCommand => new RelayCommand<Color>(delegate(Color c)
	{
		Color = c;
	});

	public ICommand SaveToPreferencesCommand => new RelayCommand(OnSaveToPreferences);

	private AnchoredPopup? Popover => _popover?.Value;

	public LabelEditorVM(ILabelInteractor interactor)
	{
		_interactor = interactor;
	}

	public LabelEditorVM()
	{
		_popover = new Lazy<AnchoredPopup>(delegate
		{
			AnchoredPopup anchoredPopup = new AnchoredPopup
			{
				AllowsTransparency = true,
				HorizontalAlignment = HorizontalAlignment.Center,
				Child = new LabelEditorView().WithDataContext(this)
			};
			(Application.Current?.MainWindow.Content as MainLayout)?.mainLayoutGrid.Children.Add(anchoredPopup);
			anchoredPopup.Closed += OnPopoverClosed;
			return anchoredPopup;
		});
	}

	public void ShowPopover(FrameworkElement? placementTarget, ILabelInteractor interactor)
	{
		if (Popover != null)
		{
			_interactor = interactor;
			Reload();
			Popover.PlacementTarget = placementTarget;
			Popover.IsOpen = true;
			EventPublisher.Publish(interactor.ToShownEvent());
		}
	}

	public void Reload()
	{
		IgnoreFor(OnReload);
	}

	private void OnReload()
	{
		Name = (MultipleValues ? null : _interactor?.Target?.Text) ?? string.Empty;
		ILabelInteractor? interactor = _interactor;
		Color = ((interactor != null && interactor.MultipleColors) ? ((Color?)null) : _interactor?.Target?.Color) ?? Colors.Transparent;
		OnPropertyChanged("MultipleValues");
		OnPropertyChanged("MultipleColors");
	}

	private void OnNameChanged()
	{
		ApplyChanges();
		OnPropertyChanged("CanSaveToPreferences");
	}

	private void OnSelectLabelCommand(ILabel label)
	{
		IgnoreFor(delegate
		{
			Name = label.Text;
			Color = label.Color ?? Colors.Transparent;
		});
		ApplyChanges(label);
	}

	private void OnSaveToPreferences()
	{
		_interactor?.SaveToPreferences(Name, Color);
		OnPropertyChanged("CanSaveToPreferences");
	}

	private void ApplyChanges()
	{
		ApplyChanges(null);
	}

	private void ApplyChanges(ILabel? preset)
	{
		if (!_ignoreChanges && (preset != null || !string.IsNullOrEmpty(Name)))
		{
			if (Popover != null)
			{
				StayOpenFor(applyChange);
			}
			else
			{
				applyChange();
			}
			Reload();
		}
		void applyChange()
		{
			if (preset != null)
			{
				_interactor?.ApplyChange(preset);
			}
			else
			{
				_interactor?.ApplyChange(Name, Color);
			}
		}
	}

	private void StayOpenFor(Action action)
	{
		if (Popover != null)
		{
			Popover.StaysOpen = true;
			action();
			Popover.StaysOpen = false;
			Keyboard.Focus(((DependencyObject)(object)Popover.Child)?.FindVisualChild<TextBox>());
		}
	}

	private void IgnoreFor(Action action)
	{
		_ignoreChanges = true;
		action();
		_ignoreChanges = false;
	}

	private void OnPopoverClosed(object? sender, EventArgs e)
	{
		if (SaveToPreferences)
		{
			OnSaveToPreferences();
		}
	}
}
