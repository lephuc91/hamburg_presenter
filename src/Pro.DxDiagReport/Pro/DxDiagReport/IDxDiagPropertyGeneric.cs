namespace Pro.DxDiagReport;

public interface IDxDiagPropertyGeneric<T> : IDxDiagProperty
{
	T Value { get; }
}
