using System;
using System.Windows;
using Pro.Common.Logging;
using Pro.Common.Mathematics;
using Pro.Common.Utility;
using Pro.UI.Controls;
using Pro.UI.DependencyInjection;

namespace ProPresenter.UI;

public class PreviewRenderTarget : RenderTarget
{
	private readonly ILogger _logger;

	public static DependencyProperty AspectRatioProperty = DependencyProperty.Register("AspectRatio", typeof(double), typeof(PreviewRenderTarget), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)1.7777777777777777, FrameworkPropertyMetadataOptions.AffectsMeasure));

	public double AspectRatio
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(AspectRatioProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AspectRatioProperty, (object)value);
		}
	}

	public PreviewRenderTarget(Func<nint, nint> createWindow, Action<nint> closeWindow)
		: base(createWindow, closeWindow)
	{
		base.HorizontalAlignment = HorizontalAlignment.Center;
		base.VerticalAlignment = VerticalAlignment.Center;
		_logger = UIServiceProvider.GetService<ILogger>();
	}

	protected override Size MeasureOverride(Size constraint)
	{
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		if (double.IsNegative(((Size)(ref constraint)).Width) || double.IsNegative(((Size)(ref constraint)).Height))
		{
			_logger.Error($"{"PreviewRenderTarget"} measured with Width:{((Size)(ref constraint)).Width} and Height:{((Size)(ref constraint)).Height}");
			return new Size(1.0, 1.0);
		}
		return new Vector2<double>(AspectRatio, 1.0).ScaleToFitSize((Vector2<double>)constraint);
	}
}
