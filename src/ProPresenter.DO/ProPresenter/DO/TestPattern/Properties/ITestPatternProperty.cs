using System;
using System.ComponentModel;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.TestPattern.Properties;

public interface ITestPatternProperty : INotifyPropertyChanged
{
	string Name { get; }

	TestPatternPropertyType Type { get; }

	event System.Action DataModified;

	void Deserialize(Pro.SerializationInterop.RVProtoData.TestPatternDefinition.Types.Property protoProperty);

	void DeserializeValue(TestPatternDocument.Types.TestPatternData.Types.Property protoProperty);

	Pro.SerializationInterop.RVProtoData.TestPatternDefinition.Types.Property Serialize();

	TestPatternDocument.Types.TestPatternData.Types.Property SerializeValue();
}
