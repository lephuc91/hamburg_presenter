using System.Collections.Generic;
using System.ComponentModel;
using Pro.Common.Components.Reversibility;
using Pro.Common.Mathematics;
using Pro.DO.Utility;
using Pro.Editor.Canvas.Handles;
using Pro.Entity;
using Pro.Localization;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.DependencyInjection;
using ProPresenter.DO.Media;

namespace ProPresenter.DO.Slide.Custom.Elements.Shapes;

public class RightArrowShape : ClosedBezierPath
{
	private const double MinCornerX = 0.0;

	private const double MaxCornerX = 1.0;

	protected const double MinCornerY = 0.0;

	protected const double MaxCornerY = 0.5;

	private Vector2<double> _corner = new Vector2<double>(0.75, 0.25);

	public override string DefaultShapeName => LocalizedStrings.Get("GLOBAL_SHAPE_ARROW");

	public Vector2<double> Corner
	{
		get
		{
			return _corner;
		}
		set
		{
			SetValue("Corner", ref _corner, ClampCorner(value), delegate(Vector2<double> o, Vector2<double> n)
			{
				base.UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.ElementCornerRadius), this, "Corner", o, n);
				OnDataModified();
				InvalidatePoints();
			});
		}
	}

	public RightArrowShape(IProPresenterDOFactoryProvider factoryProvider, string containerId)
		: this(factoryProvider.MediaFactory, factoryProvider.TextDocumentFactory, containerId)
	{
	}

	public RightArrowShape(IMediaFactory mediaFactory, ITextDocumentFactory textDocumentFactory, string containerId)
		: base(mediaFactory, textDocumentFactory, containerId)
	{
		base.CustomHandlesCollection.Add(new ControlHandleData(() => base.FlipMode.FlipPoint(Corner), delegate(Vector2<double> start, Vector2<double> last, Vector2<double> current)
		{
			Corner = base.FlipMode.FlipPoint(current);
		}, DidCornerHandleMove));
	}

	protected override IEnumerable<BezierPoint> GeneratePoints()
	{
		Vector2<double> corner = Corner;
		return new global::_003C_003Ez__ReadOnlyArray<BezierPoint>(new BezierPoint[7]
		{
			new BezierPoint(new Vector2<double>(0.0, corner.Y)),
			new BezierPoint(new Vector2<double>(corner.X, corner.Y)),
			new BezierPoint(new Vector2<double>(corner.X, 0.0)),
			new BezierPoint(new Vector2<double>(1.0, 0.5)),
			new BezierPoint(new Vector2<double>(corner.X, 1.0)),
			new BezierPoint(new Vector2<double>(corner.X, 1.0 - corner.Y)),
			new BezierPoint(new Vector2<double>(0.0, 1.0 - corner.Y))
		});
	}

	public override SlideElementBase Clone()
	{
		RightArrowShape rightArrowShape = new RightArrowShape(base.MediaFactory, base.TextDocumentFactory, base.ContainerId);
		CopyProperties(rightArrowShape);
		return rightArrowShape;
	}

	protected internal override void CopyProperties(SlideElementBase slideElement)
	{
		if (slideElement is RightArrowShape)
		{
			RightArrowShape rightArrowShape = (RightArrowShape)slideElement;
			rightArrowShape.Corner = Corner;
			base.CopyProperties((SlideElementBase)rightArrowShape);
		}
		else
		{
			base.CopyProperties(slideElement);
		}
	}

	protected virtual Vector2<double> ClampCorner(Vector2<double> corner)
	{
		return new Vector2<double>(corner.X.Clamp(0.0, 1.0), corner.Y.Clamp(0.0, 0.5));
	}

	protected override Graphics.Types.Path.Types.Shape SerializeShape()
	{
		return new Graphics.Types.Path.Types.Shape
		{
			Type = Graphics.Types.Path.Types.Shape.Types.Type.RightArrow,
			Arrow = new Graphics.Types.Path.Types.Shape.Types.Arrow
			{
				Corner = Corner.ToProtoPoint()
			}
		};
	}

	protected override void DeserializeShape(Graphics.Types.Path.Types.Shape shape)
	{
		Corner = shape.Arrow.Corner.ToVector();
	}

	private bool DidCornerHandleMove(PropertyChangedEventArgs e)
	{
		string propertyName = e.PropertyName;
		if (propertyName == "FlipMode" || propertyName == "Corner")
		{
			return true;
		}
		return false;
	}

	protected override bool IsSyncCompatibleShape(IGraphics.Types.IPath.Types.Shape.Types.Type type)
	{
		return type == IGraphics.Types.IPath.Types.Shape.Types.Type.RightArrow;
	}
}
