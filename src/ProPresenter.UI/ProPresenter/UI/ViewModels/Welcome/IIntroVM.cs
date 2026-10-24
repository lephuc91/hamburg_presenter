using System.Collections.Generic;
using System.ComponentModel;

namespace ProPresenter.UI.ViewModels.Welcome;

public interface IIntroVM : INotifyPropertyChanged
{
	int PageCount { get; }

	int CurrentPage { get; set; }

	IReadOnlyList<IIntroContent> SlideshowContent { get; }

	bool ShowBubble { get; }

	void Initialize();

	void Complete();

	void AdvanceToNextSlide();
}
