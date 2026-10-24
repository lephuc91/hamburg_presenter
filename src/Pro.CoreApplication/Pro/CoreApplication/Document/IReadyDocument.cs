using System;

namespace Pro.CoreApplication.Document;

public interface IReadyDocument : IDocument
{
	Guid Id { get; }
}
