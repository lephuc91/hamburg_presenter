using System.Collections.Generic;

namespace Pro.Loro;

public record AwarenessPeerUpdate(List<ulong> updated, List<ulong> added);
