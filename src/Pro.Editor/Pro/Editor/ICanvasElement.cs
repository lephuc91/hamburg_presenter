using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;
using Pro.Common.Collections;
using Pro.Common.Mathematics;
using Pro.Editor.Canvas.Handles;
using Pro.Editor.Canvas.Transforming;

namespace Pro.Editor;

public interface ICanvasElement : INotifyPropertyChanged
{
	ICanvasElement? CanvasParent { get; }

	ImmutableObservableCollection<ICanvasElement>? CanvasChildren { get; }

	HandleLocation SupportedCanvasHandles { get; }

	Color HandleColor { get; }

	ImmutableObservableCollection<IHandleData>? CustomHandles { get; }

	ImmutableObservableCollection<IPopover>? Popovers { get; }

	ImmutableObservableCollection<UIElement>? CustomChildren { get; }

	ChildVisibilityMode ChildVisibilityMode { get; }

	Vector2<double> Position { get; set; }

	Vector2<double> Size { get; set; }

	Angle<double> Rotation { get; set; }

	Rect<double> SnapBounds { get; }

	int ZOrder { get; set; }

	bool IsLocked { get; set; }

	bool IsHidden { get; set; }

	bool IsAspectRatioLocked { get; set; }

	bool IsAspectRatioLockForced { get; }

	bool IsEditModeActive { get; }

	bool SupportsEditMode { get; }

	bool MaskWhileEditing { get; }

	bool SupportsRotation { get; }

	bool IsSnappingSource { get; }

	bool IsSelectable { get; }

	bool UseBitmapCache { get; }

	event Action VisualInvalidated;

	bool DoesSelectionIntersect(Rect<double> selectionBounds);

	void OnSelected();

	void OnDeselected();

	void OnEnterEditMode(Vector2<double> point, double zoomFactor, bool isMaskForced);
}
