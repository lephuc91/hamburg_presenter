using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.TestPattern;

public interface ITestPatternDefinitionFactory
{
	ITestPatternDefinition Create(Pro.SerializationInterop.RVProtoData.TestPatternDefinition protoTestPatternDefinition);
}
