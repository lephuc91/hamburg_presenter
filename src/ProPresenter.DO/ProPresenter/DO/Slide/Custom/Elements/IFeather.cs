using System;
using System.ComponentModel;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Slide.Custom.Elements.Feathers;

namespace ProPresenter.DO.Slide.Custom.Elements;

public interface IFeather : INotifyPropertyChanged, IRenderEquatable<IFeather>, IRenderHashable, ICloneable<IFeather>
{
	FeatherType Type { get; set; }

	double Radius { get; set; }

	bool IsEnabled { get; set; }

	UndoStack? UndoStack { get; set; }

	event System.Action VisualInvalidated;

	event Action<IFeather> DataModified;

	Graphics.Types.Feather Serialize();

	void Deserialize(Graphics.Types.Feather protoFeather);
}
