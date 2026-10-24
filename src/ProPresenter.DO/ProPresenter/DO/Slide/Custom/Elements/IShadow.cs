using System;
using System.ComponentModel;
using System.Windows.Media;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Mathematics;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Slide.Custom.Elements;

public interface IShadow : INotifyPropertyChanged, ICloneable<IShadow>, IRenderEquatable<IShadow>, IRenderHashable
{
	ShadowType Type { get; }

	bool IsEnabled { get; set; }

	double BlurRadius { get; set; }

	double Offset { get; set; }

	double Opacity { get; set; }

	Angle<double> Angle { get; set; }

	System.Windows.Media.Color Color { get; set; }

	UndoStack? UndoStack { get; set; }

	event System.Action VisualInvalidated;

	event Action<IShadow> DataModified;

	Graphics.Types.Shadow Serialize();

	void Deserialize(Graphics.Types.Shadow protoShadow);
}
