using System.Collections.Generic;
using System.Linq;
using Pro.Common.Collections;
using Pro.DO.Label;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.Cues;

namespace ProPresenter.DO.Label;

public class MultiTargetSlideLabelContext : ISlideLabelContext, ILabelContext
{
	private readonly ArrangedCue? _target;

	private readonly IEnumerable<ArrangedCue> _cues;

	public IEnumerable<SlideCue> Cues => _cues.Select((ArrangedCue s) => s.Source);

	public ILabel? Target => _target?.Source.SlideAction?.Label;

	public IEnumerable<ILabel> Targets => Cues.Select((SlideCue s) => s.SlideAction?.Label).NotNull();

	public MultiTargetSlideLabelContext(IEnumerable<ArrangedCue> targetCues, ArrangedCue? targetCue)
	{
		_cues = targetCues.ToArray();
		_target = targetCue;
	}
}
