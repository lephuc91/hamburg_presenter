using System;
using System.ComponentModel;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Mathematics;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Slide.Custom.Elements.Scrollers;

namespace ProPresenter.DO.Slide.Custom.Elements;

public interface ITextScroller : INotifyPropertyChanged, ICloneable<ITextScroller>, IRenderEquatable<ITextScroller>, IRenderHashable
{
	bool IsLinked { get; set; }

	bool ShouldScrollText { get; set; }

	double ScrollRate { get; set; }

	bool ShouldRepeat { get; set; }

	Vector2<double> MaxSize { get; }

	double RepeatDistance { get; set; }

	ScrollingType ScrollDirection { get; set; }

	bool StartsOffScreen { get; set; }

	double FadeLeft { get; set; }

	double FadeRight { get; set; }

	UndoStack? UndoStack { get; set; }

	event System.Action DataModified;

	Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.TextScroller Serialize();

	void Deserialize(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.TextScroller textScroller);

	void UpdateMaxSize(Vector2<double> value, bool applySideEffects = true);
}
