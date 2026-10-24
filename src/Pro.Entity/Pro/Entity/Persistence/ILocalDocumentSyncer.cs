using System;

namespace Pro.Entity.Persistence;

public interface ILocalDocumentSyncer<out T> : IDisposable where T : IDocument
{
	T Document { get; }
}
