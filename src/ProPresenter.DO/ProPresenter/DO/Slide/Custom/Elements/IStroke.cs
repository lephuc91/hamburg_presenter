using System;
using System.ComponentModel;
using System.Windows.Media;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Slide.Custom.Elements.Strokes;

namespace ProPresenter.DO.Slide.Custom.Elements;

public interface IStroke : INotifyPropertyChanged, IRenderEquatable<IStroke>, IRenderHashable, ICloneable<IStroke>
{
	StrokeType Type { get; }

	StrokeStyle Style { get; set; }

	bool IsEnabled { get; set; }

	double StrokeThickness { get; set; }

	System.Windows.Media.Color StrokeColor { get; set; }

	double[] Pattern { get; }

	UndoStack? UndoStack { get; set; }

	event System.Action VisualInvalidated;

	event Action<IStroke> DataModified;

	Graphics.Types.Stroke Serialize();

	void Deserialize(Graphics.Types.Stroke protoStroke);
}
