using System;
using System.ComponentModel;
using System.Windows.Input;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Text;
using Pro.Text.Reversibility;
using Pro.UI.Components;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.DependencyInjection;
using ProPresenter.DO.Slide.Custom;
using ProPresenter.DO.Slide.Custom.Elements.Shapes;

namespace ProPresenter.UI.ViewModels;

public class ReflowTextVM : NotifyPropertyChangedBase
{
	private ArrangedCue? _slide;

	private RunSettings? _activeRunSettings;

	private readonly IProPresenterDOFactoryProvider _factoryProvider;

	private readonly Func<FontInfo, FontInfo> _toggleBold;

	private readonly Func<FontInfo, FontInfo> _toggleItalic;

	public ArrangedCue? Slide
	{
		get
		{
			return _slide;
		}
		set
		{
			SetValue("Slide", ref _slide, value, OnSlideChanged);
		}
	}

	public TextDocument? Text => Slide?.Source.SlideAction?.Slide.Text;

	public Pro.Text.Range[]? SelectionRanges { get; set; }

	public RunSettings? ActiveRunSettings
	{
		get
		{
			return _activeRunSettings;
		}
		set
		{
			SetValue("ActiveRunSettings", ref _activeRunSettings, value);
		}
	}

	public ICommand BoldCommand => new RelayCommand(OnBoldCommand, () => ActiveRunSettings?.Font.IsBoldAvailable() ?? false);

	public ICommand ItalicCommand => new RelayCommand(OnItalicCommand, () => ActiveRunSettings?.Font.IsItalicAvailable() ?? false);

	public ICommand UnderlineCommand => new RelayCommand(OnUnderlineCommand, () => (object)ActiveRunSettings != null);

	public ICommand StrikethroughCommand => new RelayCommand(OnStrikethroughCommand, () => (object)ActiveRunSettings != null);

	public ICommand IncreaseFontSizeCommand => new RelayCommand(OnIncreaseFontSizeCommand, () => (object)ActiveRunSettings != null);

	public ICommand DecreaseFontSizeCommand => new RelayCommand(OnDecreaseFontSizeCommand, () => (object)ActiveRunSettings != null);

	public ICommand CreateDefaultTextBoxCommand => new RelayCommand(CreateDefaultTextBoxCommandExecuted);

	private UndoStack? UndoStack => Slide?.Source.UndoStack;

	public ReflowTextVM(IProPresenterDOFactoryProvider factoryProvider, Func<FontInfo, FontInfo>? toggleBold = null, Func<FontInfo, FontInfo>? toggleItalic = null)
	{
		_factoryProvider = factoryProvider;
		_toggleBold = toggleBold ?? new Func<FontInfo, FontInfo>(FontHelper.ToggleBold);
		_toggleItalic = toggleItalic ?? new Func<FontInfo, FontInfo>(FontHelper.ToggleItalic);
	}

	private void OnBoldCommand()
	{
		ApplyRunSettingsChange(delegate(RunSettings r)
		{
			r.Font = _toggleBold(ActiveRunSettings.Font);
		}, UndoActionTypes.Bold);
	}

	private void OnItalicCommand()
	{
		ApplyRunSettingsChange(delegate(RunSettings r)
		{
			r.Font = _toggleItalic(ActiveRunSettings.Font);
		}, UndoActionTypes.Italic);
	}

	private void OnUnderlineCommand()
	{
		ApplyRunSettingsChange(delegate(RunSettings r)
		{
			r.Underline = !ActiveRunSettings.Underline;
		});
	}

	private void OnStrikethroughCommand()
	{
		ApplyRunSettingsChange(delegate(RunSettings r)
		{
			r.Strikethrough = !ActiveRunSettings.Strikethrough;
		});
	}

	private void OnIncreaseFontSizeCommand()
	{
		ChangeFontSize(ActiveRunSettings.CharacterSize + 1);
	}

	private void OnDecreaseFontSizeCommand()
	{
		ChangeFontSize(ActiveRunSettings.CharacterSize - 1);
	}

	private void ChangeFontSize(int size)
	{
		ApplyRunSettingsChange(delegate(RunSettings r)
		{
			r.CharacterSize = size;
		}, UndoActionTypes.CharacterSize);
	}

	private void ApplyRunSettingsChange(Action<RunSettings> action, UndoActionTypes undoAction = UndoActionTypes.Font, bool autoFinalize = true)
	{
		UndoStack?.BeginCommit(undoAction.ToAction());
		Text?.IterateRuns(SelectionRanges, splitRuns: true, delegate(RunBase r)
		{
			action(r.Settings);
		});
		UndoStack?.EndCommit(null, null, autoFinalize);
	}

	private void OnSlideChanged(ArrangedCue oldValue, ArrangedCue newValue)
	{
		if (oldValue?.Source.SlideAction != null)
		{
			oldValue.Source.SlideAction.Slide.PropertyChanged -= SlideOnPropertyChanged;
		}
		if (newValue?.Source.SlideAction != null)
		{
			newValue.Source.SlideAction.Slide.PropertyChanged += SlideOnPropertyChanged;
		}
		OnPropertyChanged("Text");
	}

	private void SlideOnPropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "Text")
		{
			OnPropertyChanged("Text");
		}
	}

	private void CreateDefaultTextBoxCommandExecuted()
	{
		if ((object)Text == null && Slide != null && Slide?.Source.SlideAction?.Slide is CustomSlide customSlide)
		{
			TextShape textShape = new TextShape(_factoryProvider, Slide.Source.ContainerId);
			textShape.CenterAndScaleIn(customSlide.Size);
			customSlide.AddElement(textShape, userInitiated: true);
			OnPropertyChanged("Text");
		}
	}
}
