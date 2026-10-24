using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Pro.Common.Mathematics;
using Pro.Common.Utility;
using ProPresenter.DO.ClearGroups;

namespace ProPresenter.UI.ClearGroups;

public partial class ClearGroupImageControl : UserControl, IComponentConnector
{
	public static readonly DependencyProperty ClearGroupProperty = DependencyProperty.Register("ClearGroup", typeof(ClearGroup), typeof(ClearGroupImageControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnClearGroupPropertyChanged)));

	public static readonly DependencyProperty DiscardTintProperty = DependencyProperty.Register("DiscardTint", typeof(bool), typeof(ClearGroupImageControl), new PropertyMetadata((object)false));

	public static readonly DependencyProperty ImageSizeProperty = DependencyProperty.Register("ImageSize", typeof(Vector2<double>), typeof(ClearGroupImageControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)new Vector2<double>(16.0, 16.0)));

	public ClearGroup? ClearGroup
	{
		get
		{
			return (ClearGroup)((DependencyObject)this).GetValue(ClearGroupProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ClearGroupProperty, (object)value);
		}
	}

	public bool DiscardTint
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(DiscardTintProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DiscardTintProperty, (object)value);
		}
	}

	public Vector2<double> ImageSize
	{
		get
		{
			return (Vector2<double>)((DependencyObject)this).GetValue(ImageSizeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ImageSizeProperty, (object)value);
		}
	}

	private static void OnClearGroupPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		(d as ClearGroupImageControl)?.OnClearGroupChanged(((DependencyPropertyChangedEventArgs)(ref e)).OldValue as ClearGroup, ((DependencyPropertyChangedEventArgs)(ref e)).NewValue as ClearGroup);
	}

	public ClearGroupImageControl()
	{
		InitializeComponent();
	}

	private void OnClearGroupChanged(ClearGroup? oldValue, ClearGroup? newValue)
	{
		if (oldValue != null)
		{
			oldValue.PropertyChanged -= ClearGroup_PropertyChanged;
		}
		if (newValue != null)
		{
			newValue.PropertyChanged += ClearGroup_PropertyChanged;
		}
		CheckCustomIconHasAlpha();
	}

	private void ClearGroup_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		string propertyName = e.PropertyName;
		if (propertyName == "Icon" || propertyName == "ImageType")
		{
			CheckCustomIconHasAlpha();
		}
	}

	private void CheckCustomIconHasAlpha()
	{
		if (ClearGroup != null && ClearGroup.ImageType == ImageType.Custom && ClearGroup.Icon != null)
		{
			DiscardTint = !ClearGroup.Icon.Format.HasTransparency();
		}
	}
}
