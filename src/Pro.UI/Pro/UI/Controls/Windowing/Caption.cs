using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Pro.Common.Mathematics;
using Pro.Common.Win32;

namespace Pro.UI.Controls.Windowing;

public class Caption : ContentControl, INonClientSpace
{
	static Caption()
	{
		Control.BackgroundProperty.OverrideMetadata(typeof(Caption), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)Brushes.Transparent, FrameworkPropertyMetadataOptions.AffectsRender));
	}

	public HT DoHitTest(Vector2<double> point)
	{
		return HT.CAPTION;
	}

	protected override void OnRender(DrawingContext drawingContext)
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		drawingContext.DrawRectangle(base.Background, null, new Rect<double>(0.0, 0.0, base.ActualWidth, base.ActualHeight));
	}

	protected override void OnPreviewMouseMove(MouseEventArgs e)
	{
		if (e.LeftButton == MouseButtonState.Pressed)
		{
			if (Mouse.Captured == null)
			{
				CaptureMouse();
			}
		}
		else if (Mouse.Captured != null)
		{
			ReleaseMouseCapture();
		}
	}
}
