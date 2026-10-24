using System.Collections.Generic;
using System.ComponentModel;
using Pro.Common.Components;
using Pro.Common.Mathematics;
using Pro.Common.Time;
using Pro.Common.Time.Timer;
using ProPresenter.UI.ViewModels.Welcome;

namespace ProPresenter.ViewModels.Welcome;

public class IntroVM : NotifyPropertyChangedBase, IIntroVM, INotifyPropertyChanged
{
	private int _currentPage = 1;

	private readonly IIntroContent[] _content;

	private readonly IOneShotTimer _pageTimer;

	public int PageCount => _content.Length;

	public int CurrentPage
	{
		get
		{
			return _currentPage;
		}
		set
		{
			SetValue("CurrentPage", ref _currentPage, value.Clamp(1, PageCount), ResetPageTimer);
		}
	}

	public IReadOnlyList<IIntroContent> SlideshowContent => _content;

	public bool ShowBubble => PageCount > 1;

	public IntroVM(IIntroContent[] content, ITimerFactory timerFactory)
	{
		_content = content;
		_pageTimer = timerFactory.CreateOneShotDispatched(TimeSlice.FromSeconds(10.0), delegate
		{
			CurrentPage++;
		});
	}

	public void Initialize()
	{
		if (CurrentPage == 1)
		{
			ResetPageTimer();
		}
		else
		{
			CurrentPage = 1;
		}
	}

	public void Complete()
	{
		_pageTimer.Stop();
	}

	public void AdvanceToNextSlide()
	{
		CurrentPage++;
	}

	private void ResetPageTimer()
	{
		_pageTimer.Stop();
		if (CurrentPage != PageCount)
		{
			_pageTimer.Start();
		}
	}
}
