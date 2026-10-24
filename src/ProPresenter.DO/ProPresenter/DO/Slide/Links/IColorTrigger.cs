using System;
using System.ComponentModel;
using System.Windows.Media;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Time;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Slide.Links;

public interface IColorTrigger : INotifyPropertyChanged, ICloneable<IColorTrigger>
{
	System.Windows.Media.Color Color { get; set; }

	TimeSlice Time { get; set; }

	UndoStack? UndoStack { get; set; }

	event System.Action DataModified;

	string Encode();

	Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.ColorTrigger Serialize();
}
