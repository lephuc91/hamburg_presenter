using System;

namespace Pro.CoreApplication.Document.Interaction;

public record DocumentRemove(Guid DocumentId, DocumentType DocumentType);
