using System.Collections.Generic;

namespace Pro.Loro;

public record EphemeralStoreEvent(EphemeralEventTrigger by, List<string> added, List<string> removed, List<string> updated);
