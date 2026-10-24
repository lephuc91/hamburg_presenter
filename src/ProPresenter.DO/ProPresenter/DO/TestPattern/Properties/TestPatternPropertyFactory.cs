using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.TestPattern.Properties;

public class TestPatternPropertyFactory : ITestPatternPropertyFactory
{
	public ITestPatternProperty? CreateProperty(Pro.SerializationInterop.RVProtoData.TestPatternDefinition.Types.Property protoProperty)
	{
		object obj = protoProperty.PropertyTypeCase switch
		{
			Pro.SerializationInterop.RVProtoData.TestPatternDefinition.Types.Property.PropertyTypeOneofCase.ColorProperty => new ColorProperty(), 
			Pro.SerializationInterop.RVProtoData.TestPatternDefinition.Types.Property.PropertyTypeOneofCase.DoubleProperty => new DoubleProperty(), 
			Pro.SerializationInterop.RVProtoData.TestPatternDefinition.Types.Property.PropertyTypeOneofCase.IntProperty => new IntProperty(), 
			Pro.SerializationInterop.RVProtoData.TestPatternDefinition.Types.Property.PropertyTypeOneofCase.BoolProperty => new BoolProperty(this), 
			Pro.SerializationInterop.RVProtoData.TestPatternDefinition.Types.Property.PropertyTypeOneofCase.StringProperty => new StringProperty(), 
			Pro.SerializationInterop.RVProtoData.TestPatternDefinition.Types.Property.PropertyTypeOneofCase.FontProperty => new FontProperty(), 
			Pro.SerializationInterop.RVProtoData.TestPatternDefinition.Types.Property.PropertyTypeOneofCase.SelectorProperty => new SelectorProperty(), 
			_ => null, 
		};
		if (obj != null)
		{
			((ITestPatternProperty)obj).Deserialize(protoProperty);
			return (ITestPatternProperty?)obj;
		}
		return (ITestPatternProperty?)obj;
	}
}
