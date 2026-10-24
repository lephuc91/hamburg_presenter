using System;
using System.Collections.Generic;
using Pro.Common.Collections;
using Pro.DO.Label;
using ProPresenter.DO.Cues;

namespace ProPresenter.DO.Label;

public class SingleTargetSlideLabelContext : ISlideLabelContext, ILabelContext
{
	private readonly Func<SlideCue?> _slideProvider;

	public IEnumerable<SlideCue> Cues => _slideProvider().ToEnumerable();

	public ILabel? Target => _slideProvider()?.SlideAction?.Label;

	public IEnumerable<ILabel> Targets => Target.ToEnumerable();

	public SingleTargetSlideLabelContext(Func<SlideCue?> getSlide)
	{
		_slideProvider = getSlide;
	}
}
