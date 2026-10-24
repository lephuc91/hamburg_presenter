using System.Collections.Generic;

namespace Pro.Loro;

public record VersionVectorDiff(Dictionary<ulong, CounterSpan> retreat, Dictionary<ulong, CounterSpan> forward);
