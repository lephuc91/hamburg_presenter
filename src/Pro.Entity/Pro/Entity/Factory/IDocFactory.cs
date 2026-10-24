namespace Pro.Entity.Factory;

public interface IDocFactory
{
	IDocument CreateDocument(byte[] document, ulong peerId);
}
public interface IDocFactory<out T> : IDocFactory where T : IEntityDocument
{
	T CreateInstance(ulong peerId);

	T CreateInstance(byte[] document, ulong peerId);
}
