using System.Collections.Generic;
using Pro.DO.Label;

namespace ProPresenter.DO.Label;

public interface ILabelContext
{
	ILabel? Target { get; }

	IEnumerable<ILabel> Targets { get; }
}
