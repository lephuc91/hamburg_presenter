using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.TestPattern.State;

public interface ITestPatternStateFactory
{
	ITestPatternState Create(Pro.SerializationInterop.RVProtoData.TestPatternState? protoTestPatternState);
}
