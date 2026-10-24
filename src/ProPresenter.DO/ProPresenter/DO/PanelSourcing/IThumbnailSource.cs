using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Media;
using Pro.DO.Label;
using Pro.ssAPI;
using ProPresenter.DO.LiveVideo;

namespace ProPresenter.DO.PanelSourcing;

public interface IThumbnailSource : INotifyPropertyChanged, IUniformViewSource
{
	string Name { get; set; }

	bool IsEnabled { get; }

	bool IsValid { get; }

	bool IsMediaPending { get; }

	Color BackgroundColor { get; }

	LiveVideoInput? LiveVideoInput { get; }

	string LabelName { get; }

	Color LabelColor { get; }

	Brush LabelForeground { get; }

	GroupLabel? GroupLabel { get; }

	bool ShowGroupLabel { get; }

	bool ShowIndex { get; }

	IEnumerable<IScrimSource> ScrimItems { get; }

	int BuildCount { get; }

	int BuildPosition { get; }

	ScaleBehavior ScaleBehavior { get; }

	ScaleAlignment ScaleAlignment { get; }

	bool CanRename { get; }

	event Action? VisualInvalidated;
}
