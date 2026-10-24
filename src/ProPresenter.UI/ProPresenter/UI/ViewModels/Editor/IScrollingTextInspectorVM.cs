using System.Windows.Input;
using ProPresenter.DO.Slide.Custom.Elements.Scrollers;

namespace ProPresenter.UI.ViewModels.Editor;

public interface IScrollingTextInspectorVM
{
	bool ShouldScrollText { get; set; }

	double ScrollRate { get; set; }

	bool ShouldRepeat { get; set; }

	double RepeatDistance { get; set; }

	ScrollingType ScrollDirection { get; set; }

	bool StartsOffScreen { get; set; }

	bool IsLinked { get; set; }

	double FadeLeft { get; set; }

	double FadeRight { get; set; }

	ICommand EnableStartPositionCommand { get; }

	ICommand DisableStartPositionCommand { get; }
}
