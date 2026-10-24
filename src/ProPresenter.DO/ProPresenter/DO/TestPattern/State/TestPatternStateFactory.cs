using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.TestPattern.State;

public class TestPatternStateFactory : ITestPatternStateFactory
{
	public ITestPatternState Create(Pro.SerializationInterop.RVProtoData.TestPatternState? protoTestPatternState)
	{
		TestPatternState testPatternState = new TestPatternState();
		if (protoTestPatternState != null)
		{
			testPatternState.Deserialize(protoTestPatternState);
		}
		return testPatternState;
	}
}
