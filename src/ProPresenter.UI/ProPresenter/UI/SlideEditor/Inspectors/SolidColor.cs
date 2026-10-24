using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using Pro.Text;
using Pro.Text.Reversibility;

namespace ProPresenter.UI.SlideEditor.Inspectors;

public partial class SolidColor : UserControl, IComponentConnector
{
	private bool _ignoreChanges;

	public static readonly DependencyProperty FillProperty = DependencyProperty.Register("Fill", typeof(TextFillBase), typeof(SolidColor), (PropertyMetadata)(object)new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(OnFillPropertyChanged)));

	private static readonly DependencyProperty ColorProperty = DependencyProperty.Register("Color", typeof(Color), typeof(SolidColor), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnColorPropertyChanged)));

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

	private Color Color
	{
		get
		{
			return (Color)((DependencyObject)this).GetValue(ColorProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ColorProperty, (object)value);
		}
	}

	private static void OnFillPropertyChanged(DependencyObject caller, DependencyPropertyChangedEventArgs e)
	{
		((SolidColor)(object)caller).OnFillChanged(((DependencyPropertyChangedEventArgs)(ref e)).NewValue as TextFillBase);
	}

	private static void OnColorPropertyChanged(DependencyObject caller, DependencyPropertyChangedEventArgs e)
	{
		((SolidColor)(object)caller).OnColorChanged((Color)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	public SolidColor()
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

	private void OnFillChanged(TextFillBase? newFill)
	{
		if (newFill is SolidTextFill solidTextFill && !IgnoreChanges())
		{
			_ignoreChanges = true;
			Color = solidTextFill.Color;
			_ignoreChanges = false;
		}
	}

	private void ChangeFill(SolidTextFill newFill, UndoActionTypes undoActionType)
	{
		TextFillUtility.ChangeFill(GetDocumentsAction, newFill, undoActionType, ApplyRunSettingsProvider, ApplyParagraphSettingsProvider, delegate(SolidTextFill f)
		{
			((DependencyObject)this).SetCurrentValue(FillProperty, (object)f);
		});
	}

	private void OnColorChanged(Color newColor)
	{
		if (!IgnoreChanges())
		{
			ChangeFill(new SolidTextFill(newColor), UndoActionTypes.TextSolidFill);
		}
	}
}
