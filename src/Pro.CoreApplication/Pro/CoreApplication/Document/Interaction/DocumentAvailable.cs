using System;

namespace Pro.CoreApplication.Document.Interaction;

public record DocumentAvailable(Guid DocumentId, byte[] Data);
