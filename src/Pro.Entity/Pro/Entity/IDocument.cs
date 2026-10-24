using System;

namespace Pro.Entity;

public interface IDocument : ICanExportSnapshot, IDisposable
{
	IObservable<(ICanExportSnapshot, bool)> WhenChangeHappened { get; }

	void Import(byte[] data);

	byte[] GetVersionVector();
}
