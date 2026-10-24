using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace ProPresenter.UI;

public partial class CueTemplate : UserControl, IComponentConnector
{
	public static readonly DependencyProperty ShowItemDetailsProperty = DependencyProperty.Register("ShowItemDetails", typeof(bool), typeof(CueTemplate), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));

	public static readonly DependencyProperty ShowIconProperty = DependencyProperty.Register("ShowIcon", typeof(bool), typeof(CueTemplate), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));

	public static readonly DependencyProperty CanRenameProperty = DependencyProperty.Register("CanRename", typeof(bool), typeof(CueTemplate), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));

	public static readonly DependencyProperty ShowArrangementNameProperty = DependencyProperty.Register("ShowArrangementName", typeof(bool), typeof(CueTemplate), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false));

	public bool ShowItemDetails
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowItemDetailsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowItemDetailsProperty, (object)value);
		}
	}

	public bool ShowIcon
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowIconProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowIconProperty, (object)value);
		}
	}

	public bool CanRename
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(CanRenameProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CanRenameProperty, (object)value);
		}
	}

	public bool ShowArrangementName
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowArrangementNameProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowArrangementNameProperty, (object)value);
		}
	}

	public CueTemplate()
	{
		InitializeComponent();
	}

	private void CueTemplateGridSizeChanged(object? sender, SizeChangedEventArgs e)
	{
		if (ShowItemDetails)
		{
			double num = (TargetIcon.IsVisible ? (TargetIcon.ActualWidth + 8.0) : 0.0);
			InfoColumn.Width = ((Math.Truncate(AdditionalInfoColumn.ActualWidth - 1.0) <= num) ? new GridLength(TemplateGrid.ActualWidth - IconColumn.ActualWidth - num) : GridLength.Auto);
			AdditionalInfoColumn.Width = new GridLength(1.0, GridUnitType.Star);
		}
		else
		{
			InfoColumn.Width = new GridLength(1.0, GridUnitType.Star);
			AdditionalInfoColumn.Width = GridLength.Auto;
		}
	}
}
