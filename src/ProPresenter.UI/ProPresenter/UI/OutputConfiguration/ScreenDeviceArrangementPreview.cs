using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using Pro.Common.Mathematics;
using Pro.Common.Nullability;
using Pro.Common.Utility;
using Pro.ssAPI.Devices;
using ProPresenter.DO;
using ProPresenter.DO.OutputConfiguration;
using ProPresenter.UI.Theming;

namespace ProPresenter.UI.OutputConfiguration;

public partial class ScreenDeviceArrangementPreview : UserControl, IComponentConnector
{
	public static readonly DependencyProperty TargetScreenProperty = DependencyProperty.Register("TargetScreen", typeof(PhysicalDevice), typeof(ScreenDeviceArrangementPreview), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, FrameworkPropertyMetadataOptions.AffectsRender));

	public PhysicalDevice? TargetScreen
	{
		get
		{
			return (PhysicalDevice)((DependencyObject)this).GetValue(TargetScreenProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TargetScreenProperty, (object)value);
		}
	}

	private VideoOutputDeviceCollection VideoOutputDeviceCollection
	{
		get
		{
			VideoOutputDeviceCollection? videoOuputDeviceCollection = OutputVault.VideoOuputDeviceCollection;
			videoOuputDeviceCollection.ThrowWhenNull("outputs");
			return videoOuputDeviceCollection;
		}
	}

	public ScreenDeviceArrangementPreview()
	{
		InitializeComponent();
	}

	protected override void OnRender(DrawingContext drawingContext)
	{
		dynamic val = AppTheme.Active.PANEL;
		object obj = AppTheme.Active.DARKCONTENT;
		object obj2 = AppTheme.Active.SECONDARY;
		Pen pen = new Pen(AppTheme.Active.DIVIDER, 0.5);
		Vector2<double> vector = new Vector2<double>(base.ActualWidth, base.ActualHeight);
		List<IVideoOutputDevice> list = VideoOutputDeviceCollection.Where((IVideoOutputDevice d) => d.DeviceType == VideoOutputDeviceType.DVI).ToList();
		Rect<double> boundingBox = list.Select((IVideoOutputDevice d) => d.SystemFrame).GetBoundingBox();
		Vector2<double> position = boundingBox.Position;
		double num = boundingBox.Size.ScaleToFitScalar(vector);
		Vector2<double> vector2 = (vector - boundingBox.Size * num) / 2.0;
		drawingContext.DrawRectangle(val, null, new Rect<double>(vector));
		foreach (IVideoOutputDevice item in list)
		{
			Rect<double> rect = new Rect<double>((item.SystemFrame.Position - position) * num + vector2, item.SystemFrame.Size * num);
			drawingContext.DrawRectangle((dynamic)((item.UUID == TargetScreen?.DeviceID) ? obj2 : obj), pen, rect);
		}
	}
}
