using System.Collections.Generic;
using Pro.Common.Collections;
using Pro.Common.Components.Reversibility;
using Pro.Common.Mathematics;
using Pro.DO.Utility;
using Pro.Editor;
using Pro.Entity;
using Pro.Localization;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.DependencyInjection;
using ProPresenter.DO.Media;

namespace ProPresenter.DO.Slide.Custom.Elements.Shapes;

public class PolygonShape : ClosedBezierPath
{
	private const int MinPoints = 3;

	private const int MaxPoints = 20;

	protected static readonly Vector2<double> Origin = new Vector2<double>(0.5, 0.5);

	private int _pointCount = 5;

	private ImmutableObservableCollection<IPopover> _popoverCollection;

	public virtual string SlidePopoverLabel => LocalizedStrings.Get("EDITOR_POPOVER_POLYGON_SIDES_title");

	public override string DefaultShapeName => LocalizedStrings.Get("GLOBAL_SHAPE_POLYGON");

	public override ImmutableObservableCollection<IPopover> Popovers => _popoverCollection;

	public int PointCount
	{
		get
		{
			return _pointCount;
		}
		set
		{
			int num = value.Clamp(3, 20);
			if (_pointCount != num)
			{
				base.UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.ElementPointCount), this, "PointCount", _pointCount, num);
				_pointCount = num;
				PointCountPopover.Value = num;
				InvalidatePoints();
				OnPropertyChanged("PointCount");
				OnDataModified();
			}
		}
	}

	public SliderPopoverModel PointCountPopover { get; }

	public PolygonShape(IProPresenterDOFactoryProvider factoryProvider, string containerId)
		: this(factoryProvider.MediaFactory, factoryProvider.TextDocumentFactory, containerId)
	{
	}

	public PolygonShape(IMediaFactory mediaFactory, ITextDocumentFactory textDocumentFactory, string containerId)
		: base(mediaFactory, textDocumentFactory, containerId)
	{
		PointCountPopover = new SliderPopoverModel(SlidePopoverLabel, delegate(int count)
		{
			PointCount = count;
		})
		{
			MinValue = 3,
			MaxValue = 20,
			Value = PointCount
		};
		_popoverCollection = new ImmutableObservableCollection<IPopover>(new SliderPopoverModel[1] { PointCountPopover });
	}

	protected override IEnumerable<BezierPoint> GeneratePoints()
	{
		List<BezierPoint> list = new List<BezierPoint>();
		double num = 360.0 / (double)PointCount;
		Vector2<double> point = new Vector2<double>(0.5, 0.0);
		for (double num2 = 0.0; num2 < 360.0; num2 += num)
		{
			list.Add(new BezierPoint(point.Rotate(Origin, num2)));
		}
		return list;
	}

	public override SlideElementBase Clone()
	{
		PolygonShape polygonShape = new PolygonShape(base.MediaFactory, base.TextDocumentFactory, base.ContainerId);
		CopyProperties(polygonShape);
		return polygonShape;
	}

	protected internal override void CopyProperties(SlideElementBase slideElement)
	{
		if (slideElement is PolygonShape polygonShape)
		{
			polygonShape._pointCount = PointCount;
			base.CopyProperties((SlideElementBase)polygonShape);
		}
		else
		{
			base.CopyProperties(slideElement);
		}
	}

	protected override Graphics.Types.Path.Types.Shape SerializeShape()
	{
		return new Graphics.Types.Path.Types.Shape
		{
			Type = Graphics.Types.Path.Types.Shape.Types.Type.Polygon,
			Polygon = new Graphics.Types.Path.Types.Shape.Types.Polygon
			{
				NumberSides = (uint)PointCount
			}
		};
	}

	protected override void DeserializeShape(Graphics.Types.Path.Types.Shape shape)
	{
		PointCount = (int)shape.Polygon.NumberSides;
	}

	protected override bool IsSyncCompatibleShape(IGraphics.Types.IPath.Types.Shape.Types.Type type)
	{
		return type == IGraphics.Types.IPath.Types.Shape.Types.Type.Polygon;
	}
}
