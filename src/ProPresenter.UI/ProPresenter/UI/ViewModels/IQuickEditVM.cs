using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Media;
using Pro.Common.Mathematics;
using Pro.UI.Components;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.Slide.Custom;
using ProPresenter.DO.Slide.Custom.Elements;

namespace ProPresenter.UI.ViewModels;

public interface IQuickEditVM : INotifyPropertyChanged
{
	Color BackgroundColor { get; }

	Vector2<double> TargetContainerSize { get; }

	Vector2<double> RenderSize { get; }

	Vector2<double> ScaleRatio { get; }

	IEnumerable<ClosedBezierPath> TextElements { get; }

	ICommand<(ClosedBezierPath, int)> BreakToNewSlideCommand { get; }

	void Edit(ArrangedCue? cue, Vector2<double> position, Vector2<double> containerSize, Vector2<double> renderSize);

	bool CanEdit(CustomSlide? slide);
}
