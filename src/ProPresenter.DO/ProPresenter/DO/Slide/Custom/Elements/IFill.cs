using System;
using System.ComponentModel;
using System.Windows.Media;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Mathematics;
using Pro.Editor;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Slide.Custom.Elements.Fills;

namespace ProPresenter.DO.Slide.Custom.Elements;

public interface IFill : INotifyPropertyChanged, IRenderEquatable<IFill>, IRenderHashable, ICloneable<IFill>, IHasMediaContainerId, ICanReceiveMediaContainerIdUpdates
{
	FillType Type { get; }

	string DisplayName { get; }

	bool IsEnabled { get; set; }

	bool IsAspectRatioLocked { get; set; }

	bool IsAspectRatioLockForced { get; }

	UndoStack? UndoStack { get; set; }

	event System.Action VisualInvalidated;

	event Action<IFill> DataModified;

	ICanvasElement[] GetEditableChildren(ICanvasElement parent);

	void OnSizeChanged(Vector2<double> oldSize, Vector2<double> newSize);

	System.Windows.Media.Color Sample();

	Graphics.Types.Fill Serialize();

	void Deserialize(Graphics.Types.Fill fill, string containerId);
}
