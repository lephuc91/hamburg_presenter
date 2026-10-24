using System;

namespace Pro.CoreApplication.Document.Interaction;

public record DocumentPatch(Guid DocumentId, byte[] Data);
