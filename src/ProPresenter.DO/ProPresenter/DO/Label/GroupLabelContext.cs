using System.Collections.Generic;
using System.Linq;
using Pro.Common.Collections;
using Pro.DO.Label;
using ProPresenter.DO.Arrangements;

namespace ProPresenter.DO.Label;

public class GroupLabelContext : ILabelContext
{
	private readonly ArrangedCue? _targetCue;

	public IReadOnlyCollection<ArrangedCue> Cues { get; }

	public ILabel? Target => _targetCue?.GroupLabel;

	public IEnumerable<ILabel> Targets => Cues.Select((ArrangedCue s) => s.GroupLabel).NonNull();

	public GroupLabelContext(IReadOnlyCollection<ArrangedCue> targetCues, ArrangedCue? targetCue)
	{
		Cues = targetCues;
		_targetCue = targetCue;
	}
}
