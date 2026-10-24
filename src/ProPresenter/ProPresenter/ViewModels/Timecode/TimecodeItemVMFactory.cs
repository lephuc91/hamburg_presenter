using ProPresenter.Controller;
using ProPresenter.DO;
using ProPresenter.UI.ViewModels;

namespace ProPresenter.ViewModels.Timecode;

public class TimecodeItemVMFactory : ITimecodeItemVMFactory
{
	private readonly ITimecodeService _timecodeService;

	public TimecodeItemVMFactory(ITimecodeService timecodeService)
	{
		_timecodeService = timecodeService;
	}

	public ITimecodeItemVM Create(ITimeTriggerable item)
	{
		return new TimecodeItemVM(item, _timecodeService);
	}
}
