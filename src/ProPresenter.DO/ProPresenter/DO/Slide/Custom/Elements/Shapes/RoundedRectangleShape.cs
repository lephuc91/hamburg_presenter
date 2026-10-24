using System.Collections.Generic;
using System.ComponentModel;
using Pro.Common.Components.Reversibility;
using Pro.Common.Mathematics;
using Pro.DO.Utility;
using Pro.Editor.Canvas.Handles;
using Pro.Editor.Canvas.ToolTips;
using Pro.Entity;
using Pro.Localization;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.DependencyInjection;
using ProPresenter.DO.Media;

namespace ProPresenter.DO.Slide.Custom.Elements.Shapes;

public class RoundedRectangleShape : ClosedBezierPath
{
	private const double MinRadius = 0.0;

	private const double MaxRadius = 1.0;

	private double _cornerRadius = 0.25;

	private bool _isScaledRadiusValid;

	private Vector2<double> _scaledRadius = Vector2<double>.Zero;

	private readonly ShapeToolTip _toolTip = new ShapeToolTip();

	public override string DefaultShapeName => LocalizedStrings.Get("GLOBAL_SHAPE_ROUNDED_RECTANGLE");

	public double CornerRadius
	{
		get
		{
			return _cornerRadius;
		}
		set
		{
			double num = value.Clamp(0.0, 1.0);
			if (_cornerRadius != num)
			{
				base.UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.ElementCornerRadius), this, "CornerRadius", _cornerRadius, num);
				_cornerRadius = num;
				_isScaledRadiusValid = false;
				InvalidatePoints();
				OnPropertyChanged("CornerRadius");
				OnDataModified();
			}
		}
	}

	private Vector2<double> ScaledRadius
	{
		get
		{
			if (!_isScaledRadiusValid)
			{
				double num = CornerRadius / 2.0;
				_scaledRadius = new Vector2<double>(num, num);
				if (num != 0.0)
				{
					Vector2<double> vector = Size.Abs();
					if (vector.X < vector.Y)
					{
						_scaledRadius.Y = vector.X * num / vector.Y;
					}
					else if (vector.Y < vector.X)
					{
						_scaledRadius.X = vector.Y * num / vector.X;
					}
				}
			}
			return _scaledRadius;
		}
	}

	public RoundedRectangleShape(IProPresenterDOFactoryProvider factoryProvider, string containerId)
		: this(factoryProvider.MediaFactory, factoryProvider.TextDocumentFactory, containerId)
	{
	}

	public RoundedRectangleShape(IMediaFactory mediaFactory, ITextDocumentFactory textDocumentFactory, string containerId)
		: base(mediaFactory, textDocumentFactory, containerId)
	{
		base.CustomHandlesCollection.Add(new ControlHandleData(() => base.FlipMode.FlipPoint(new Vector2<double>(ScaledRadius.X, 0.0)), CornerRadiusHandleDragged, DidCornerRadiusHandleMove, _toolTip));
	}

	protected override IEnumerable<BezierPoint> GeneratePoints()
	{
		Vector2<double> scaledRadius = ScaledRadius;
		return new global::_003C_003Ez__ReadOnlyArray<BezierPoint>(new BezierPoint[8]
		{
			GeneratePoint(new Vector2<double>(0.0, scaledRadius.Y), new Vector2<double>(0.0, 0.0), isLeading: false),
			GeneratePoint(new Vector2<double>(scaledRadius.X, 0.0), new Vector2<double>(0.0, 0.0), isLeading: true),
			GeneratePoint(new Vector2<double>(1.0 - scaledRadius.X, 0.0), new Vector2<double>(1.0, 0.0), isLeading: false),
			GeneratePoint(new Vector2<double>(1.0, scaledRadius.Y), new Vector2<double>(1.0, 0.0), isLeading: true),
			GeneratePoint(new Vector2<double>(1.0, 1.0 - scaledRadius.Y), new Vector2<double>(1.0, 1.0), isLeading: false),
			GeneratePoint(new Vector2<double>(1.0 - scaledRadius.X, 1.0), new Vector2<double>(1.0, 1.0), isLeading: true),
			GeneratePoint(new Vector2<double>(scaledRadius.X, 1.0), new Vector2<double>(0.0, 1.0), isLeading: false),
			GeneratePoint(new Vector2<double>(0.0, 1.0 - scaledRadius.Y), new Vector2<double>(0.0, 1.0), isLeading: true)
		});
	}

	public override SlideElementBase Clone()
	{
		RoundedRectangleShape roundedRectangleShape = new RoundedRectangleShape(base.MediaFactory, base.TextDocumentFactory, base.ContainerId);
		CopyProperties(roundedRectangleShape);
		return roundedRectangleShape;
	}

	protected internal override void CopyProperties(SlideElementBase slideElement)
	{
		if (slideElement is RoundedRectangleShape roundedRectangleShape)
		{
			roundedRectangleShape.CornerRadius = CornerRadius;
			base.CopyProperties((SlideElementBase)roundedRectangleShape);
		}
		else
		{
			base.CopyProperties(slideElement);
		}
	}

	private BezierPoint GeneratePoint(Vector2<double> position, Vector2<double> corner, bool isLeading)
	{
		double num = 1.0 - Kappa.Value;
		Vector2<double> vector = (position - corner) * num + corner;
		return new BezierPoint
		{
			IsCurved = true,
			Position = position,
			Q0 = (isLeading ? vector : position),
			Q1 = (isLeading ? position : vector)
		};
	}

	protected override void OnSizeChanged(Vector2<double> oldValue, Vector2<double> newValue, bool applySideEffects = true)
	{
		_isScaledRadiusValid = false;
		InvalidatePoints();
		base.OnSizeChanged(oldValue, newValue, applySideEffects);
	}

	private void CornerRadiusHandleDragged(Vector2<double> startPoint, Vector2<double> lastPoint, Vector2<double> currentPoint)
	{
		double num = ((CornerRadius != 0.0) ? (CornerRadius / ScaledRadius.X) : 1.0);
		CornerRadius = base.FlipMode.FlipPoint(currentPoint).X * num;
		_toolTip.TooltipLabel = LocalizedStrings.Get("EDITOR_POPOVER_ROUNDNESS_label", new object[1] { (int)(CornerRadius * 100.0) });
	}

	protected override Graphics.Types.Path.Types.Shape SerializeShape()
	{
		return new Graphics.Types.Path.Types.Shape
		{
			Type = Graphics.Types.Path.Types.Shape.Types.Type.RoundedRectangle,
			RoundedRectangle = new Graphics.Types.Path.Types.Shape.Types.RoundedRectangle
			{
				Roundness = CornerRadius
			}
		};
	}

	protected override void DeserializeShape(Graphics.Types.Path.Types.Shape shape)
	{
		CornerRadius = shape.RoundedRectangle.Roundness;
	}

	private static bool DidCornerRadiusHandleMove(PropertyChangedEventArgs e)
	{
		string propertyName = e.PropertyName;
		if (propertyName == "FlipMode" || propertyName == "CornerRadius")
		{
			return true;
		}
		return false;
	}

	protected override bool IsSyncCompatibleShape(IGraphics.Types.IPath.Types.Shape.Types.Type type)
	{
		return type == IGraphics.Types.IPath.Types.Shape.Types.Type.RoundedRectangle;
	}
}
