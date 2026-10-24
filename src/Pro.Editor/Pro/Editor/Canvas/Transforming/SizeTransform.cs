using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Pro.Common.Collections;
using Pro.Common.Mathematics;
using Pro.Editor.Canvas.Snapping;
using Pro.Editor.Canvas.Snapping.Sources;

namespace Pro.Editor.Canvas.Transforming;

public class SizeTransform : TransformBase
{
	private HandleLocation _handleLocation;

	private bool _handleFlippedX;

	private bool _handleFlippedY;

	private SizeTransformSS? _snappingSource;

	private readonly Dictionary<ICanvasElement, Rect<double>> _originalBounds = new Dictionary<ICanvasElement, Rect<double>>();

	public HandleLocation EffectiveHandleLocation { get; private set; }

	public SizeTransform(HandleLocation handleLocation)
	{
		_handleLocation = handleLocation;
		EffectiveHandleLocation = handleLocation;
	}

	public override void StartTransform(IEnumerable<ICanvasElement> elements, SnapController snapController)
	{
		base.StartTransform(elements, snapController);
		if (base.Elements.Any())
		{
			_snappingSource = new SizeTransformSS(base.Elements.First(), _handleLocation);
			base.Elements.ForEach(delegate(ICanvasElement e)
			{
				_originalBounds[e] = new Rect<double>(e.Position, e.Size);
			});
		}
	}

	public override void TransformElements(Vector2<double> startPoint, Vector2<double> lastPoint, Vector2<double> currentPoint, ModifierKeys modifierKeys)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		if (!base.Elements.Any())
		{
			return;
		}
		bool lockCenter = ((Enum)modifierKeys).HasFlag((Enum)(object)(ModifierKeys)2);
		bool lockAspectRatio = base.Elements.Any((ICanvasElement e) => e.IsAspectRatioLockForced) || (!base.Elements.Any((ICanvasElement e) => e.IsAspectRatioLocked) && ((Enum)modifierKeys).HasFlag((Enum)(object)(ModifierKeys)4)) || (base.Elements.Any((ICanvasElement e) => e.IsAspectRatioLocked) && !((Enum)modifierKeys).HasFlag((Enum)(object)(ModifierKeys)4));
		bool flag = !((Enum)modifierKeys).HasFlag((Enum)(object)(ModifierKeys)1);
		foreach (ICanvasElement element in base.Elements)
		{
			Vector2<double> origin = element.Position + element.Size / 2.0;
			Vector2<double> vector = currentPoint.Rotate(origin, element.Rotation.CartesianValue);
			Vector2<double> vector2 = startPoint.Rotate(origin, element.Rotation.CartesianValue);
			Vector2<double> deltaSize = vector - vector2;
			_originalBounds.TryGetValue(element, out var value);
			ResizeElement(element, value, deltaSize, lockAspectRatio, lockCenter);
		}
		SnappingResult snappingResult = SnappingResult.EmptyResults;
		if (_snappingSource != null && base.SnapController != null && flag)
		{
			snappingResult = base.SnapController.FindMatchingSnaps(_snappingSource);
		}
		if (snappingResult.DidSnap)
		{
			foreach (ICanvasElement element2 in base.Elements)
			{
				Vector2<double> origin2 = element2.Position + element2.Size / 2.0;
				Vector2<double> snapDelta = snappingResult.SnapDelta;
				snapDelta = snapDelta.Rotate(Vector2<double>.Zero, (element2.CanvasParent?.Rotation ?? Angle<double>.Zero).CartesianValue);
				Vector2<double> vector3 = (currentPoint + snapDelta).Rotate(origin2, element2.Rotation.CartesianValue);
				Vector2<double> vector4 = startPoint.Rotate(origin2, element2.Rotation.CartesianValue);
				Vector2<double> deltaSize2 = vector3 - vector4;
				_originalBounds.TryGetValue(element2, out var value2);
				ResizeElement(element2, value2, deltaSize2, lockAspectRatio, lockCenter);
			}
		}
		if (_snappingSource != null && flag)
		{
			base.SnapController?.UpdateFinalBounds(_snappingSource.Bounds);
		}
		else
		{
			base.SnapController?.ClearResults();
		}
		base.TooltipLabel = $"W: {Math.Round(base.Elements.First().Size.X, 1).ToString()}, H: {Math.Round(base.Elements.First().Size.Y, 1).ToString()}";
	}

	private void ResizeElement(ICanvasElement element, Rect<double> originalBounds, Vector2<double> deltaSize, bool lockAspectRatio, bool lockCenter)
	{
		Vector2<double> scale = new Vector2<double>(_handleLocation.IsLeft() ? (-1.0) : (_handleLocation.IsRight() ? 1.0 : 0.0), _handleLocation.IsTop() ? (-1.0) : (_handleLocation.IsBottom() ? 1.0 : 0.0));
		Vector2<double> vector = deltaSize.ComponentwiseProduct(scale) * (lockCenter ? 2.0 : 1.0);
		Vector2<double> point = originalBounds.Size + vector;
		if (element == base.Elements.First())
		{
			_handleFlippedX = point.X < 0.0;
			_handleFlippedY = point.Y < 0.0;
			EffectiveHandleLocation = ((_handleFlippedX && _handleFlippedY) ? _handleLocation.GetOppositeHandle() : (_handleFlippedX ? _handleLocation.GetHorizontallyOppositeHandle() : (_handleFlippedY ? _handleLocation.GetVerticallyOppositeHandle() : _handleLocation)));
			if (_snappingSource != null)
			{
				_snappingSource.HandleLocation = EffectiveHandleLocation;
			}
		}
		if (lockAspectRatio)
		{
			Vector2<double> vector2 = vector;
			vector2.Y = vector.X * originalBounds.Height / originalBounds.Width;
			Vector2<double> vector3 = vector;
			vector3.X = vector.Y * originalBounds.Width / originalBounds.Height;
			Vector2<double> vector4 = (originalBounds.Size + vector2).Abs();
			Vector2<double> vector5 = (originalBounds.Size + vector3).Abs();
			double num = vector4.X * vector4.Y;
			double num2 = vector5.X * vector5.Y;
			bool flag = (_handleLocation.IsCorner() ? (num < num2) : _handleLocation.AdjustsWidth());
			point = (flag ? vector4 : vector5);
			point = element.EnsurePositiveSize(point);
			if (_snappingSource != null)
			{
				_snappingSource.AllowHorizontalSnap = !flag;
				_snappingSource.AllowVerticalSnap = flag;
			}
		}
		else if (_snappingSource != null)
		{
			_snappingSource.AllowHorizontalSnap = true;
			_snappingSource.AllowVerticalSnap = true;
		}
		point = point.Abs();
		Vector2<double> center = originalBounds.Center;
		if (!lockCenter)
		{
			center += ((point - originalBounds.Size) * 0.5).ComponentwiseProduct(scale).Rotate(Vector2<double>.Zero, element.Rotation.InvertedCartesianValue);
		}
		Vector2<double> position = center - point * 0.5;
		if (!lockCenter)
		{
			position -= new Vector2<double>(_handleFlippedX ? (point.X * (_handleLocation.IsRight() ? 1.0 : (-1.0))) : 0.0, _handleFlippedY ? (point.Y * (_handleLocation.IsBottom() ? 1.0 : (-1.0))) : 0.0).Rotate(Vector2<double>.Zero, element.Rotation.InvertedCartesianValue);
		}
		element.Position = position;
		element.Size = point;
	}

	public override void CompleteTransform()
	{
		base.CompleteTransform();
		_originalBounds.Clear();
	}
}
