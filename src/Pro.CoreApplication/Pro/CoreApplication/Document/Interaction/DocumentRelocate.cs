using System;

namespace Pro.CoreApplication.Document.Interaction;

public record DocumentRelocate(Guid DocumentId, string NewRelativeFilePath, DocumentType DocumentType);
