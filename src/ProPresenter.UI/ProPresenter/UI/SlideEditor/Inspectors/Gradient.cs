using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using Pro.Common.Mathematics;
using Pro.Text;
using Pro.Text.Reversibility;
using Pro.UI.Components;

namespace ProPresenter.UI.SlideEditor.Inspectors;

public partial class Gradient : UserControl, IComponentConnector
{
	private bool _ignoreChanges;

	public static readonly DependencyProperty FillProperty = DependencyProperty.Register("Fill", typeof(TextFillBase), typeof(Gradient), (PropertyMetadata)(object)new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(OnFillPropertyChanged)));

	private static readonly DependencyProperty StartColorProperty = DependencyProperty.Register("StartColor", typeof(Color), typeof(Gradient), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnStartColorPropertyChanged)));

	private static readonly DependencyProperty EndColorProperty = DependencyProperty.Register("EndColor", typeof(Color), typeof(Gradient), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnEndColorPropertyChanged)));

	private static readonly DependencyProperty AngleProperty = DependencyProperty.Register("Angle", typeof(Angle<double>), typeof(Gradient), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnAnglePropertyChanged)));

	private static readonly DependencyProperty StretchToDocumentBoundsProperty = DependencyProperty.Register("StretchToDocumentBounds", typeof(bool), typeof(Gradient), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnStretchToDocumentBoundsPropertyChanged)));

	public ApplyRunSettingsDelegate? ApplyRunSettingsProvider { get; set; }

	public ApplyParagraphSettingsDelegate? ApplyParagraphSettingsProvider { get; set; }

	public Func<IReadOnlyList<TextDocument>?>? GetDocumentsAction { get; set; }

	public TextFillBase? Fill
	{
		get
		{
			return (TextFillBase)((DependencyObject)this).GetValue(FillProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(FillProperty, (object)value);
		}
	}

	private Color StartColor
	{
		get
		{
			return (Color)((DependencyObject)this).GetValue(StartColorProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(StartColorProperty, (object)value);
		}
	}

	private Color EndColor
	{
		get
		{
			return (Color)((DependencyObject)this).GetValue(EndColorProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(EndColorProperty, (object)value);
		}
	}

	private Angle<double> Angle
	{
		get
		{
			return (Angle<double>)((DependencyObject)this).GetValue(AngleProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AngleProperty, (object)value);
		}
	}

	private bool StretchToDocumentBounds
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(StretchToDocumentBoundsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(StretchToDocumentBoundsProperty, (object)value);
		}
	}

	public ICommand SwapColorsCommand => new RelayCommand(OnSwapColors, () => Fill is GradientTextFill);

	private static void OnFillPropertyChanged(DependencyObject caller, DependencyPropertyChangedEventArgs e)
	{
		((Gradient)(object)caller).OnFillChanged((TextFillBase)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	private static void OnStartColorPropertyChanged(DependencyObject caller, DependencyPropertyChangedEventArgs e)
	{
		((Gradient)(object)caller).OnStartColorChanged((Color)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	private static void OnEndColorPropertyChanged(DependencyObject caller, DependencyPropertyChangedEventArgs e)
	{
		((Gradient)(object)caller).OnEndColorChanged((Color)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	private static void OnAnglePropertyChanged(DependencyObject caller, DependencyPropertyChangedEventArgs e)
	{
		((Gradient)(object)caller).OnAngleChanged((Angle<double>)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	private static void OnStretchToDocumentBoundsPropertyChanged(DependencyObject caller, DependencyPropertyChangedEventArgs e)
	{
		((Gradient)(object)caller).OnStretchToDocumentBoundsChanged((bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	public Gradient()
	{
		InitializeComponent();
	}

	private bool IgnoreChanges()
	{
		if (!_ignoreChanges)
		{
			return Fill == null;
		}
		return true;
	}

	private void OnFillChanged(TextFillBase newFill)
	{
		if (newFill is GradientTextFill gradientTextFill && !IgnoreChanges())
		{
			_ignoreChanges = true;
			StartColor = gradientTextFill.StartColor;
			EndColor = gradientTextFill.EndColor;
			Angle = gradientTextFill.Angle;
			StretchToDocumentBounds = gradientTextFill.StretchToDocumentBounds;
			_ignoreChanges = false;
		}
	}

	private void ChangeFill(GradientTextFill newFill, UndoActionTypes undoActionType)
	{
		TextFillUtility.ChangeFill(GetDocumentsAction, newFill, undoActionType, ApplyRunSettingsProvider, ApplyParagraphSettingsProvider, delegate(GradientTextFill f)
		{
			((DependencyObject)this).SetCurrentValue(FillProperty, (object)f);
		});
	}

	private void OnStartColorChanged(Color newColor)
	{
		if (Fill is GradientTextFill gradientTextFill && !IgnoreChanges())
		{
			ChangeFill(new GradientTextFill(newColor, gradientTextFill.EndColor, gradientTextFill.Angle, gradientTextFill.StretchToDocumentBounds), UndoActionTypes.TextGradientFillColor);
		}
	}

	private void OnEndColorChanged(Color newColor)
	{
		if (Fill is GradientTextFill gradientTextFill && !IgnoreChanges())
		{
			ChangeFill(new GradientTextFill(gradientTextFill.StartColor, newColor, gradientTextFill.Angle, gradientTextFill.StretchToDocumentBounds), UndoActionTypes.TextGradientFillColor);
		}
	}

	private void OnAngleChanged(Angle<double> newAngle)
	{
		if (Fill is GradientTextFill gradientTextFill && !IgnoreChanges())
		{
			ChangeFill(new GradientTextFill(gradientTextFill.StartColor, gradientTextFill.EndColor, newAngle, gradientTextFill.StretchToDocumentBounds), UndoActionTypes.TextGradientFillAngle);
		}
	}

	private void OnStretchToDocumentBoundsChanged(bool newStretchToDocumentBounds)
	{
		if (Fill is GradientTextFill gradientTextFill && !IgnoreChanges())
		{
			ChangeFill(new GradientTextFill(gradientTextFill.StartColor, gradientTextFill.EndColor, gradientTextFill.Angle, newStretchToDocumentBounds), UndoActionTypes.TextGradientFillStretchToDocument);
		}
	}

	private void OnSwapColors()
	{
		if (Fill is GradientTextFill gradientTextFill)
		{
			ChangeFill(new GradientTextFill(gradientTextFill.EndColor, gradientTextFill.StartColor, gradientTextFill.Angle, gradientTextFill.StretchToDocumentBounds), UndoActionTypes.TextGradientFillColor);
		}
	}
}
