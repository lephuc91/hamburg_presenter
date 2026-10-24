using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Mathematics;
using Pro.Editor.Canvas.Handles;
using Pro.Editor.Canvas.Transforming;

namespace Pro.Editor;

public abstract class SimpleCanvasElement : LinkedNotifyPropertyChangedBase, ICanvasElement, INotifyPropertyChanged
{
	protected virtual double CenteringScalar => 1.0;

	public abstract ICanvasElement? CanvasParent { get; }

	public abstract Vector2<double> Position { get; set; }

	public abstract Vector2<double> Size { get; set; }

	public abstract Angle<double> Rotation { get; set; }

	public abstract int ZOrder { get; set; }

	public abstract bool IsLocked { get; set; }

	public abstract bool IsHidden { get; set; }

	public abstract bool IsAspectRatioLocked { get; set; }

	public virtual bool IsAspectRatioLockForced => false;

	public virtual ImmutableObservableCollection<ICanvasElement>? CanvasChildren => null;

	public virtual HandleLocation SupportedCanvasHandles => HandleLocation.All;

	public virtual Color HandleColor => Colors.White;

	public virtual ImmutableObservableCollection<IHandleData>? CustomHandles => null;

	public virtual ImmutableObservableCollection<IPopover>? Popovers => null;

	public virtual ImmutableObservableCollection<UIElement>? CustomChildren => null;

	public virtual ChildVisibilityMode ChildVisibilityMode => ChildVisibilityMode.VisibleByDefault;

	public virtual Rect<double> SnapBounds => new Rect<double>(Position, Size).Rotate(Rotation.InvertedCartesianValue);

	public virtual bool IsEditModeActive { get; protected set; }

	public virtual bool SupportsEditMode => false;

	public virtual bool MaskWhileEditing => false;

	public virtual bool SupportsRotation => true;

	public virtual bool IsSnappingSource => true;

	public virtual bool IsSelectable => true;

	public virtual bool UseBitmapCache => false;

	public event Action? VisualInvalidated;

	protected void OnVisualInvalidated()
	{
		this.VisualInvalidated?.Invoke();
	}

	public virtual bool DoesSelectionIntersect(Rect<double> selectionBounds)
	{
		return selectionBounds.Intersects(SnapBounds);
	}

	public virtual void OnSelected()
	{
	}

	public virtual void OnDeselected()
	{
	}

	public virtual void OnEnterEditMode(Vector2<double> point, double zoomFactor, bool isMaskForced)
	{
	}

	public void CenterAndScaleIn(Vector2<double> container)
	{
		if (container.X < 0.0 || container.Y < 0.0)
		{
			throw new ArgumentOutOfRangeException("container", "Must have >= 0 components.");
		}
		if (CenteringScalar < 1.0)
		{
			Position = container * (1.0 - CenteringScalar) / 2.0;
			Size = container * CenteringScalar;
		}
		else
		{
			Position = container / 2.0;
		}
	}
}
