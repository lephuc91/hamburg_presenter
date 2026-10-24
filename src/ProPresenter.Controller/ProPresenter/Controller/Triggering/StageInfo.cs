using System.Collections.Generic;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.Controller.Triggering;

public class StageInfo
{
	public IEnumerable<Stage.Types.ScreenAssignment>? Assignments { get; }

	public StageInfo(IEnumerable<Stage.Types.ScreenAssignment>? assignments)
	{
		Assignments = assignments;
	}
}
