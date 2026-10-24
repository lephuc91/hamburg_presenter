using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.TestPattern.Properties;

public interface ITestPatternPropertyFactory
{
	ITestPatternProperty? CreateProperty(Pro.SerializationInterop.RVProtoData.TestPatternDefinition.Types.Property protoProperty);
}
