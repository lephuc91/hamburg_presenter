using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.TestPattern.Properties;

namespace ProPresenter.DO.TestPattern;

public class TestPatternDefinitionFactory : ITestPatternDefinitionFactory
{
	private readonly ITestPatternPropertyFactory _factory;

	public TestPatternDefinitionFactory(ITestPatternPropertyFactory factory)
	{
		_factory = factory;
	}

	public ITestPatternDefinition Create(Pro.SerializationInterop.RVProtoData.TestPatternDefinition protoTestPatternDefinition)
	{
		TestPatternDefinition testPatternDefinition = new TestPatternDefinition(_factory);
		testPatternDefinition.Deserialize(protoTestPatternDefinition);
		return testPatternDefinition;
	}
}
