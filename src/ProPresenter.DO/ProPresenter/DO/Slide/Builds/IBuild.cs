using System;
using System.ComponentModel;
using Pro.Common.Components.Reversibility;
using Pro.Common.Time;
using ProPresenter.DO.Slide.Custom.Elements;

namespace ProPresenter.DO.Slide.Builds;

public interface IBuild : IRenderEquatable<IBuild>, IRenderHashable, INotifyPropertyChanged
{
	Guid ID { get; }

	SlideElementBase Element { get; }

	string Name { get; }

	string Description { get; }

	StartMode Start { get; set; }

	TimeSlice Delay { get; set; }

	UndoStack? UndoStack { get; set; }

	double GetBuildDuration();
}
