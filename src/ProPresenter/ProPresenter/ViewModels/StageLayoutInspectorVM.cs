using System.ComponentModel;
using Pro.Common.Components;
using Pro.Common.Nullability;
using Pro.Common.Utility;
using Pro.UI.Components;
using ProPresenter.DO.Cues;
using ProPresenter.UI.ViewModels;

namespace ProPresenter.ViewModels;

public class StageLayoutInspectorVM : NotifyPropertyChangedBase, IStageLayoutInspectorVM, INotifyPropertyChanged
{
	private SlideCue? _slideCue;

	public SlideCue? SlideCue
	{
		get
		{
			return _slideCue;
		}
		set
		{
			SetValue("SlideCue", ref _slideCue, value);
		}
	}

	public ICommand<ColorPair> ColorChangeFinishedCommand => new RelayCommand<ColorPair>(delegate(ColorPair c)
	{
		c.OldColor.ThrowWhenNull("c.OldColor");
		SlideCue.ThrowWhenNull("SlideCue");
		SlideCue.SlideAction?.Slide.CompleteColorChange(c.OldColor.Value);
	}, (ColorPair c) => c.OldColor.HasValue && SlideCue != null);
}
