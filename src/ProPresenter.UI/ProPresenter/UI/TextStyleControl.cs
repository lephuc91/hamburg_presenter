using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using Pro.Common.Mathematics;
using Pro.Text;
using Pro.Text.Reversibility;
using Pro.UI.Controls;
using Pro.UI.Utility;
using ProPresenter.UI.ViewModels;

namespace ProPresenter.UI;

public partial class TextStyleControl : UserControl, IComponentConnector
{
	private bool _updateInProgress;

	private bool _isCharacterSizeUpdatedByCustom;

	private bool _isStrokeThicknessUpdatedByCustom;

	private bool _isStrokeColorControlReset;

	private bool _isFontColorControlReset;

	private bool _isShadowBlurUpdatedByCustom;

	private bool _isShadowOpacityUpdatedByCustom;

	private bool _isShadowOffsetUpdatedByCustom;

	private bool _isShadowAngleUpdatedByCustom;

	private bool _isShadowColorControlReset;

	public FontGroup[] FontGroups => SharedTypefaceLibrary.Library.AvailableTypefaces.FontGroups;

	private ITextStyleVM? TextStyleVM => base.DataContext as ITextStyleVM;

	public TextStyleControl()
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected O, but got Unknown
		InitializeComponent();
		Reset();
		base.IsVisibleChanged += new DependencyPropertyChangedEventHandler(TemplateSettingsControl_IsVisibleChanged);
	}

	private void TemplateSettingsControl_IsVisibleChanged(object? sender, DependencyPropertyChangedEventArgs e)
	{
		if (!base.IsVisible)
		{
			Reset();
		}
	}

	private void ApplyRunSettings(Action<RunSettings> runCallback, UndoActionTypes undoType, bool autoFinalize = true)
	{
		ApplyChange(delegate
		{
			TextStyleVM?.ApplyRunSettingsCommand?.Invoke((runCallback, undoType, autoFinalize));
		});
	}

	private void ApplyParagraphSettings(Action<ParagraphSettings> paragraphCallback, UndoActionTypes undoType, bool autoFinalize = true)
	{
		ApplyChange(delegate
		{
			TextStyleVM?.ApplyParagraphSettingsCommand?.Invoke((paragraphCallback, undoType, autoFinalize));
		});
	}

	private void ApplyTextDocumentSettings(Action<TextDocumentSettings> documentCallback, UndoActionTypes undoType, bool autoFinalize = true)
	{
		ApplyChange(delegate
		{
			TextStyleVM?.ApplyDocumentSettingsCommand?.Invoke((documentCallback, undoType, autoFinalize));
		});
	}

	private void ApplyChange(Action action)
	{
		_updateInProgress = true;
		action();
		_updateInProgress = false;
	}

	private void FontFamilySelectionChanged(object? sender, SelectionChangedEventArgs e)
	{
		if (_updateInProgress || !((sender as ComboBox)?.SelectedItem is FontGroup fontGroup))
		{
			return;
		}
		Font font = ((fontGroup.Fonts.Count() == 1) ? fontGroup.Fonts[0] : FontHelper.FindFont(fontGroup, fontGroup.Fonts.First().Info.IsBold, fontGroup.Fonts.First().Info.IsItalic));
		if ((object)font == null)
		{
			_updateInProgress = false;
			return;
		}
		ApplyRunSettings(delegate(RunSettings s)
		{
			s.Font = font.Info;
			s.UpdateOriginalFont();
		}, UndoActionTypes.Font);
	}

	private void WeightSelector_SelectionChanged(object? sender, SelectionChangedEventArgs e)
	{
		if (_updateInProgress)
		{
			return;
		}
		Font font = (sender as ComboBox)?.SelectedItem as Font;
		if ((object)font == null)
		{
			_updateInProgress = false;
			return;
		}
		ApplyRunSettings(delegate(RunSettings s)
		{
			s.Font = font.Info;
			s.UpdateOriginalFont();
		}, UndoActionTypes.Font);
	}

	private void FontColorChanged(object? sender, RoutedPropertyChangedEventArgs<Color?> e)
	{
		if (!_updateInProgress && !_isFontColorControlReset)
		{
			ApplyRunSettings(delegate(RunSettings s)
			{
				s.Fill = new SolidTextFill(e.NewValue ?? Colors.Transparent);
			}, UndoActionTypes.TextSolidFill);
		}
	}

	private void CapitalizationUpdate(object? sender, RoutedEventArgs e)
	{
		if (!_updateInProgress && sender is RadioToggleButton { Tag: var tag } && tag is CapitalizationType)
		{
			CapitalizationType capitalizationType = (CapitalizationType)tag;
			ApplyRunSettings(delegate(RunSettings s)
			{
				s.CapitalizationType = capitalizationType;
			}, UndoActionTypes.Capitalization);
		}
	}

	private void CharacterSizeStepperValueChanged(object? sender, RoutedPropertyChangedEventArgs<object> e)
	{
		if (e.OldValue != null && e.NewValue != null && !_updateInProgress)
		{
			int updatedCharSize = 0;
			ApplyRunSettings(delegate(RunSettings s)
			{
				updatedCharSize = IncreaseFontSize(s, (int)e.NewValue - (int)e.OldValue);
			}, UndoActionTypes.CharacterSize, autoFinalize: false);
			if (_isCharacterSizeUpdatedByCustom)
			{
				CustomCharacterSizeInput.Value = updatedCharSize;
			}
		}
	}

	private static int IncreaseFontSize(RunSettings settings, int diff)
	{
		settings.CharacterSize += diff;
		return settings.CharacterSize;
	}

	private void CustomCharacterSizeValueChanged(object? sender, RoutedPropertyChangedEventArgs<object> e)
	{
		if (e.NewValue != null && !_updateInProgress)
		{
			ApplyRunSettings(delegate(RunSettings s)
			{
				s.CharacterSize = (int)e.NewValue;
			}, UndoActionTypes.CharacterSize, autoFinalize: false);
			_isCharacterSizeUpdatedByCustom = true;
		}
	}

	private void ParagraphAlignmentChanged(ParagraphAlignment? alignment)
	{
		if (!_updateInProgress && alignment.HasValue)
		{
			ApplyParagraphSettings(delegate(ParagraphSettings s)
			{
				s.Alignment = alignment.Value;
			}, UndoActionTypes.ParagraphAlignment);
		}
	}

	private void DocumentAlignmentChanged(DocumentAlignment? alignment)
	{
		if (!_updateInProgress && alignment.HasValue)
		{
			ApplyTextDocumentSettings(delegate(TextDocumentSettings t)
			{
				t.Alignment = alignment.Value;
			}, UndoActionTypes.DocumentAlignment);
		}
	}

	private void EnableStrokeBtn_Click(object? sender, RoutedEventArgs e)
	{
		if (!_updateInProgress)
		{
			ApplyRunSettings(delegate(RunSettings s)
			{
				s.IsStrokeVisible = true;
			}, UndoActionTypes.TextStrokeEnabled);
		}
	}

	private void DisableStrokeBtn_Click(object? sender, RoutedEventArgs e)
	{
		if (!_updateInProgress)
		{
			ApplyRunSettings(delegate(RunSettings s)
			{
				s.IsStrokeVisible = false;
			}, UndoActionTypes.TextStrokeEnabled);
		}
	}

	private void CustomStrokeThicknessInputValueChanged(object? sender, RoutedPropertyChangedEventArgs<object> e)
	{
		if (e.NewValue != null && !_updateInProgress)
		{
			ApplyRunSettings(delegate(RunSettings s)
			{
				double strokeThickness = (double)e.NewValue;
				s.StrokeThickness = strokeThickness;
			}, UndoActionTypes.TextStrokeThickness);
			_isStrokeThicknessUpdatedByCustom = true;
		}
	}

	private void StrokeThicknessStepperValueChanged(object? sender, RoutedPropertyChangedEventArgs<object> e)
	{
		if (e.OldValue != null && e.NewValue != null && !_updateInProgress)
		{
			double updatedThickness = 0.0;
			ApplyRunSettings(delegate(RunSettings s)
			{
				updatedThickness = IncreaseStrokeThickness(s, (double)e.NewValue - (double)e.OldValue);
			}, UndoActionTypes.TextStrokeThickness, autoFinalize: false);
			if (_isStrokeThicknessUpdatedByCustom)
			{
				CustomStrokeThicknessInput.Value = updatedThickness;
			}
		}
	}

	private static double IncreaseStrokeThickness(RunSettings settings, double diff)
	{
		double num = (settings.StrokeThickness + diff).Clamp(0.0, 10000.0);
		settings.StrokeThickness = Math.Max(num, 1.0);
		return num;
	}

	private void StrokeColorChanged(object? sender, RoutedPropertyChangedEventArgs<Color?> e)
	{
		if (!_updateInProgress && !_isStrokeColorControlReset)
		{
			ApplyRunSettings(delegate(RunSettings s)
			{
				s.StrokeColor = (e.NewValue.HasValue ? e.NewValue.Value : Colors.Transparent);
			}, UndoActionTypes.TextStrokeColor);
		}
	}

	private void EnableShadowBtn_Click(object? sender, RoutedEventArgs e)
	{
		if (!_updateInProgress)
		{
			ApplyTextDocumentSettings(delegate(TextDocumentSettings s)
			{
				s.Shadow.IsEnabled = true;
			}, UndoActionTypes.TextShadowEnabled);
		}
	}

	private void DisableShadowBtn_Click(object? sender, RoutedEventArgs e)
	{
		if (!_updateInProgress)
		{
			ApplyTextDocumentSettings(delegate(TextDocumentSettings s)
			{
				s.Shadow.IsEnabled = false;
			}, UndoActionTypes.TextShadowEnabled);
		}
	}

	private void CustomShadowBlurInputValueChanged(object? sender, RoutedPropertyChangedEventArgs<object> e)
	{
		if (e.NewValue != null && !_updateInProgress)
		{
			ApplyTextDocumentSettings(delegate(TextDocumentSettings s)
			{
				s.Shadow.BlurRadius = (double)e.NewValue;
			}, UndoActionTypes.TextShadowBlurRadius, autoFinalize: false);
			_isShadowBlurUpdatedByCustom = true;
		}
	}

	private void ShadowBlurStepperValueChanged(object? sender, RoutedPropertyChangedEventArgs<object> e)
	{
		if (e.OldValue != null && e.NewValue != null && !_updateInProgress)
		{
			double updatedRadius = 0.0;
			ApplyTextDocumentSettings(delegate(TextDocumentSettings s)
			{
				updatedRadius = IncreaseBlurRadius(s, (double)e.NewValue - (double)e.OldValue);
			}, UndoActionTypes.TextShadowBlurRadius, autoFinalize: false);
			if (_isShadowBlurUpdatedByCustom)
			{
				CustomShadowBlurInput.Value = updatedRadius;
			}
		}
	}

	private static double IncreaseBlurRadius(TextDocumentSettings settings, double diff)
	{
		double a = settings.Shadow.BlurRadius + diff;
		return settings.Shadow.BlurRadius = a.Clamp(1.0, 100.0);
	}

	private void CustomShadowOpacityInputValueChanged(object? sender, RoutedPropertyChangedEventArgs<object> e)
	{
		if (e.NewValue != null && !_updateInProgress)
		{
			ApplyTextDocumentSettings(delegate(TextDocumentSettings s)
			{
				s.Shadow.Opacity = (double)e.NewValue;
			}, UndoActionTypes.TextShadowOpacity, autoFinalize: false);
			_isShadowOpacityUpdatedByCustom = true;
		}
	}

	private void ShadowOpacityStepperValueChanged(object? sender, RoutedPropertyChangedEventArgs<object> e)
	{
		if (e.OldValue != null && e.NewValue != null && !_updateInProgress)
		{
			double updatedOpacity = 0.0;
			ApplyTextDocumentSettings(delegate(TextDocumentSettings s)
			{
				updatedOpacity = IncreaseOpacity(s, (double)e.NewValue - (double)e.OldValue);
			}, UndoActionTypes.TextShadowOpacity, autoFinalize: false);
			if (_isShadowOpacityUpdatedByCustom)
			{
				CustomShadowOpacityInput.Value = updatedOpacity;
			}
		}
	}

	private static double IncreaseOpacity(TextDocumentSettings settings, double diff)
	{
		if (settings.Shadow.Opacity <= 0.05 && diff < 0.0)
		{
			settings.Shadow.Opacity = 0.0;
		}
		else if (settings.Shadow.Opacity > 1.0 || settings.Shadow.Opacity + diff > 1.0)
		{
			settings.Shadow.Opacity = 1.0;
		}
		else
		{
			settings.Shadow.Opacity += diff;
		}
		return settings.Shadow.Opacity;
	}

	private void ShadowAngleRotatorAngleUpdated(Angle<double> angle)
	{
		if (!_updateInProgress)
		{
			ApplyTextDocumentSettings(delegate(TextDocumentSettings s)
			{
				s.Shadow.Angle = angle;
			}, UndoActionTypes.TextShadowAngle, autoFinalize: false);
			CustomShadowAngleInput.Value = angle.CartesianValue;
		}
	}

	private void CustomShadowAngleInputValueChanged(object? sender, RoutedPropertyChangedEventArgs<object> e)
	{
		if (e.NewValue != null && !_updateInProgress)
		{
			ApplyTextDocumentSettings(delegate(TextDocumentSettings s)
			{
				s.Shadow.Angle = new Angle<double>((double)e.NewValue, isCartesian: true);
			}, UndoActionTypes.TextShadowAngle);
			_isShadowAngleUpdatedByCustom = true;
		}
	}

	private void ShadowAngleStepperValueChanged(object? sender, RoutedPropertyChangedEventArgs<object> e)
	{
		if (e.OldValue != null && e.NewValue != null && !_updateInProgress)
		{
			Angle<double> updatedAngle = Angle<double>.Zero;
			ApplyTextDocumentSettings(delegate(TextDocumentSettings s)
			{
				updatedAngle = IncreaseAngle(s, (double)e.NewValue - (double)e.OldValue);
			}, UndoActionTypes.TextShadowAngle, autoFinalize: false);
			if (_isShadowAngleUpdatedByCustom)
			{
				CustomShadowAngleInput.Value = updatedAngle.CartesianValue;
				ShadowAngleRotator.Angle = updatedAngle;
			}
		}
	}

	private static Angle<double> IncreaseAngle(TextDocumentSettings settings, double diff)
	{
		settings.Shadow.Angle = new Angle<double>(settings.Shadow.Angle.CartesianValue + diff, isCartesian: true);
		return settings.Shadow.Angle;
	}

	private void CustomShadowOffsetInputValueChanged(object? sender, RoutedPropertyChangedEventArgs<object> e)
	{
		if (e.NewValue != null && !_updateInProgress)
		{
			ApplyTextDocumentSettings(delegate(TextDocumentSettings s)
			{
				s.Shadow.Offset = (double)e.NewValue;
			}, UndoActionTypes.TextShadowOffset, autoFinalize: false);
			_isShadowOffsetUpdatedByCustom = true;
		}
	}

	private void ShadowOffsetStepperValueChanged(object? sender, RoutedPropertyChangedEventArgs<object> e)
	{
		if (e.OldValue != null && e.NewValue != null && !_updateInProgress)
		{
			double updatedOffset = 0.0;
			ApplyTextDocumentSettings(delegate(TextDocumentSettings s)
			{
				updatedOffset = IncreaseOffset(s, (double)e.NewValue - (double)e.OldValue);
			}, UndoActionTypes.TextShadowOffset, autoFinalize: false);
			if (_isShadowOffsetUpdatedByCustom)
			{
				CustomShadowOffsetInput.Value = updatedOffset;
			}
		}
	}

	private static double IncreaseOffset(TextDocumentSettings settings, double diff)
	{
		double a = settings.Shadow.Offset + diff;
		return settings.Shadow.Offset = a.Clamp(1.0, 100.0);
	}

	private void ShadowColorChanged(object? sender, RoutedPropertyChangedEventArgs<Color?> e)
	{
		if (!_updateInProgress && !_isShadowColorControlReset)
		{
			ApplyTextDocumentSettings(delegate(TextDocumentSettings s)
			{
				s.Shadow.Color = (e.NewValue.HasValue ? e.NewValue.Value : Colors.Transparent);
			}, UndoActionTypes.TextShadowColor);
		}
	}

	private void Reset()
	{
		FontFamilySelector.SelectedItem = null;
		_isFontColorControlReset = true;
		FontColorPicker.SelectedColor = Colors.Transparent;
		_isFontColorControlReset = false;
		CustomCharacterSizeInput.Value = null;
		CharacterSizeStepper.Value = null;
		CharacterSizeStepper.Value = 1;
		_isCharacterSizeUpdatedByCustom = false;
		None.IsChecked = false;
		AllCaps.IsChecked = false;
		SmallCaps.IsChecked = false;
		ParagraphAlignmentControl.SelectedAlignment = null;
		DocumentAlignmentControl.SelectedAlignment = null;
		EnableStrokeBtn.IsChecked = false;
		DisableStrokeBtn.IsChecked = false;
		CustomStrokeThicknessInput.Value = null;
		StrokeThicknessStepper.Value = null;
		StrokeThicknessStepper.Value = 1.0;
		_isStrokeThicknessUpdatedByCustom = false;
		_isStrokeColorControlReset = true;
		StrokeColorPicker.SelectedColor = Colors.Transparent;
		_isStrokeColorControlReset = false;
		EnableShadowBtn.IsChecked = false;
		DisableShadowBtn.IsChecked = false;
		CustomShadowBlurInput.Value = null;
		ShadowBlurStepper.Value = null;
		ShadowBlurStepper.Value = 1.0;
		_isShadowBlurUpdatedByCustom = false;
		CustomShadowOpacityInput.Value = null;
		ShadowOpacityStepper.Value = null;
		ShadowOpacityStepper.Value = 0.05;
		_isShadowOpacityUpdatedByCustom = false;
		ShadowAngleRotator.Angle = Angle<double>.Zero;
		CustomShadowAngleInput.Value = null;
		ShadowAngleStepper.Value = null;
		ShadowAngleStepper.Value = 1.0;
		_isShadowAngleUpdatedByCustom = false;
		CustomShadowOffsetInput.Value = null;
		ShadowOffsetStepper.Value = null;
		ShadowOffsetStepper.Value = 1.0;
		_isShadowOffsetUpdatedByCustom = false;
		_isShadowColorControlReset = true;
		ShadowColorPicker.SelectedColor = Colors.Transparent;
		_isShadowColorControlReset = false;
	}
}
