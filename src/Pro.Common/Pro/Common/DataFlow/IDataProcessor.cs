namespace Pro.Common.DataFlow;

public interface IDataProcessor<TData>
{
	void Process(TData data);
}
