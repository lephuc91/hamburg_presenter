using ProPresenter.DO.Cues;
using ProPresenter.DO.OutputConfiguration;

namespace ProPresenter.UI.Stage;

public class StageCueAssignmentParameter
{
	public ScreenArrangementBase? ScreenArrangement { get; }

	public SlideCue? StageCue { get; }

	public StageCueAssignmentParameter(ScreenArrangementBase? screenArrangement, SlideCue? cue)
	{
		ScreenArrangement = screenArrangement;
		StageCue = cue;
	}
}
