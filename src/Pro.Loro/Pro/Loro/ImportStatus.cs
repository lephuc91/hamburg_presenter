using System.Collections.Generic;

namespace Pro.Loro;

public record ImportStatus(Dictionary<ulong, CounterSpan> success, Dictionary<ulong, CounterSpan>? pending);
