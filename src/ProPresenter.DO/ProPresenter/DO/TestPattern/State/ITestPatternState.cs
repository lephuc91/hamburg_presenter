using System;
using System.ComponentModel;
using Pro.DO.Storage;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.TestPattern.State;

public interface ITestPatternState : INotifyPropertyChanged
{
	ITestPatternDefinition? Pattern { get; set; }

	bool ShowPattern { get; set; }

	DisplayLocation DisplayLocation { get; set; }

	Guid SpecificScreen { get; set; }

	bool IdentifyScreens { get; set; }

	LogoType LogoType { get; set; }

	RelativePath UserLogoLocation { get; set; }

	event System.Action LiveDataUpdated;

	event System.Action DataModified;

	void Deserialize(Pro.SerializationInterop.RVProtoData.TestPatternState protoTestPatternState);

	void Deserialize(TestPatternDocument.Types.TestPatternStateData protoTestPatternStateData);

	Pro.SerializationInterop.RVProtoData.TestPatternState Serialize();

	TestPatternDocument.Types.TestPatternStateData SerializeData();
}
