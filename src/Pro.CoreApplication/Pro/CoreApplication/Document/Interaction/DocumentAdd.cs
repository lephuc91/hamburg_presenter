using System;

namespace Pro.CoreApplication.Document.Interaction;

public record DocumentAdd(Guid DocumentId, string RelativeFilePath, DocumentType DocumentType);
