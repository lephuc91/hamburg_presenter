using System.Windows;
using System.Windows.Media;
using Pro.Common.Mathematics;
using ProPresenter.DO.Slide.Links;

namespace ProPresenter.Rendering.Drawing.Links;

internal abstract class LinkFillDrawerBase : IDrawer<ILinkedFillObject>
{
	public static readonly LinearGradientBrush ResolvedContentBrush;

	public static readonly LinearGradientBrush NonresolvedContentBrush;

	protected abstract bool EditorResolvedContent { get; }

	static LinkFillDrawerBase()
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		ResolvedContentBrush = new LinearGradientBrush
		{
			MappingMode = BrushMappingMode.Absolute,
			StartPoint = Vector2<double>.Zero,
			EndPoint = new Vector2<double>(30.0),
			SpreadMethod = GradientSpreadMethod.Repeat,
			GradientStops = 
			{
				new GradientStop(Colors.Transparent, 0.0),
				new GradientStop(Colors.Transparent, 0.75),
				new GradientStop(Color.FromRgb(131, 132, 37), 0.75),
				new GradientStop(Color.FromRgb(131, 132, 37), 1.0)
			},
			Transform = new RotateTransform(-90.0)
		};
		NonresolvedContentBrush = new LinearGradientBrush
		{
			MappingMode = BrushMappingMode.Absolute,
			StartPoint = Vector2<double>.Zero,
			EndPoint = new Vector2<double>(30.0),
			SpreadMethod = GradientSpreadMethod.Repeat,
			GradientStops = 
			{
				new GradientStop(Colors.Black, 0.0),
				new GradientStop(Colors.Black, 0.75),
				new GradientStop(Color.FromRgb(131, 132, 37), 0.75),
				new GradientStop(Color.FromRgb(131, 132, 37), 1.0)
			},
			Transform = new RotateTransform(-90.0)
		};
		((Freezable)ResolvedContentBrush).Freeze();
		((Freezable)NonresolvedContentBrush).Freeze();
	}

	public virtual void Draw(DrawingContext dc, RenderingMode renderMode, ILinkedFillObject data, DrawingParams drawingParams)
	{
		dc.DrawGeometry(EditorResolvedContent ? ResolvedContentBrush : NonresolvedContentBrush, null, drawingParams.FillGeometry);
	}
}
