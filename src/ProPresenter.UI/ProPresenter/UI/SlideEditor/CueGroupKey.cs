using Pro.Common.Components;
using ProPresenter.DO.Arrangements;

namespace ProPresenter.UI.SlideEditor;

public class CueGroupKey : NotifyPropertyChangedBase
{
	private bool _isVisible = true;

	public bool IsVisible
	{
		get
		{
			return _isVisible;
		}
		set
		{
			SetValue("IsVisible", ref _isVisible, value);
		}
	}

	public CueGroup CueGroup { get; }

	public CueGroupKey(CueGroup cueGroup)
	{
		CueGroup = cueGroup;
	}
}
