using System.Collections.Generic;

namespace Pro.Loro;

public interface IDiffBatch
{
	List<ContainerIdAndDiff> GetDiff();

	Diff? Push(ContainerId cid, Diff diff);
}
