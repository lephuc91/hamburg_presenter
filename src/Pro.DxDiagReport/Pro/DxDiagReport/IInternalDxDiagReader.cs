namespace Pro.DxDiagReport;

public interface IInternalDxDiagReader : IDxDiagReader
{
	DxDiagReaderGetNextResult TryGetNext(uint nextIndex);
}
