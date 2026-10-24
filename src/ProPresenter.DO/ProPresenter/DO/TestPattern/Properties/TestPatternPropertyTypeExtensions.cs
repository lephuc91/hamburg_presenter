using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.TestPattern.Properties;

public static class TestPatternPropertyTypeExtensions
{
	public static TestPatternPropertyType ToPropertyType(this Pro.SerializationInterop.RVProtoData.TestPatternDefinition.Types.Property.PropertyTypeOneofCase type)
	{
		return type switch
		{
			Pro.SerializationInterop.RVProtoData.TestPatternDefinition.Types.Property.PropertyTypeOneofCase.ColorProperty => TestPatternPropertyType.Color, 
			Pro.SerializationInterop.RVProtoData.TestPatternDefinition.Types.Property.PropertyTypeOneofCase.DoubleProperty => TestPatternPropertyType.Double, 
			Pro.SerializationInterop.RVProtoData.TestPatternDefinition.Types.Property.PropertyTypeOneofCase.IntProperty => TestPatternPropertyType.Int, 
			Pro.SerializationInterop.RVProtoData.TestPatternDefinition.Types.Property.PropertyTypeOneofCase.BoolProperty => TestPatternPropertyType.Bool, 
			Pro.SerializationInterop.RVProtoData.TestPatternDefinition.Types.Property.PropertyTypeOneofCase.StringProperty => TestPatternPropertyType.String, 
			Pro.SerializationInterop.RVProtoData.TestPatternDefinition.Types.Property.PropertyTypeOneofCase.FontProperty => TestPatternPropertyType.Font, 
			Pro.SerializationInterop.RVProtoData.TestPatternDefinition.Types.Property.PropertyTypeOneofCase.SelectorProperty => TestPatternPropertyType.Selector, 
			_ => TestPatternPropertyType.None, 
		};
	}

	public static TestPatternPropertyType ToPropertyType(this TestPatternDocument.Types.TestPatternData.Types.Property.PropertyTypeOneofCase type)
	{
		return type switch
		{
			TestPatternDocument.Types.TestPatternData.Types.Property.PropertyTypeOneofCase.ColorProperty => TestPatternPropertyType.Color, 
			TestPatternDocument.Types.TestPatternData.Types.Property.PropertyTypeOneofCase.DoubleProperty => TestPatternPropertyType.Double, 
			TestPatternDocument.Types.TestPatternData.Types.Property.PropertyTypeOneofCase.IntProperty => TestPatternPropertyType.Int, 
			TestPatternDocument.Types.TestPatternData.Types.Property.PropertyTypeOneofCase.BoolProperty => TestPatternPropertyType.Bool, 
			TestPatternDocument.Types.TestPatternData.Types.Property.PropertyTypeOneofCase.StringProperty => TestPatternPropertyType.String, 
			TestPatternDocument.Types.TestPatternData.Types.Property.PropertyTypeOneofCase.FontProperty => TestPatternPropertyType.Font, 
			TestPatternDocument.Types.TestPatternData.Types.Property.PropertyTypeOneofCase.SelectorProperty => TestPatternPropertyType.Selector, 
			_ => TestPatternPropertyType.None, 
		};
	}
}
