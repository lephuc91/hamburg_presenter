using System.Collections.Generic;
using ProPresenter.DO.Cues;

namespace ProPresenter.DO.Label;

public interface ISlideLabelContext : ILabelContext
{
	IEnumerable<SlideCue> Cues { get; }
}
