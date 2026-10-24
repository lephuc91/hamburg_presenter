using ProPresenter.DO;
using ProPresenter.UI.ViewModels;

namespace ProPresenter.ViewModels.Timecode;

public interface ITimecodeItemVMFactory
{
	ITimecodeItemVM Create(ITimeTriggerable item);
}
