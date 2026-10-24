using System.Collections.Generic;
using System.ComponentModel;
using ProPresenter.DO;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.Themes;
using ProPresenter.UI.ViewModels;

namespace ProPresenter.ViewModels.TextStyle;

public interface ITextStyleFacade : INotifyPropertyChanged
{
	bool CanShowTextStylePopover { get; }

	ProPresenter.DO.TextStyle? GetCurrentTextStyle(TargetStrategy strategy);

	bool CanCopyTextStyle(TargetStrategy strategy);

	IEnumerable<ClosedBezierPath> GetTargetElements(TargetStrategy targetStrategy);

	void ApplyTemplate(TemplateSlide template);
}
