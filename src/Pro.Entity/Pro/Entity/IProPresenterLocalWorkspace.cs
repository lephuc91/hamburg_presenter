using System;
using Pro.Entity.Collections;
using Pro.Entity.Properties;

namespace Pro.Entity;

public interface IProPresenterLocalWorkspace : IEntity, IDisposable
{
	IComplexObservableProperty<IDigitalAudio.Types.ISetup?> DigitalAudioSetup { get; }

	IComplexCollection<IProPresenterScreen> ProScreens { get; }

	IComplexCollection<IVideoInput> VideoInputs { get; }

	IComplexCollection<IAudioInput> AudioInputs { get; }

	IComplexObservableProperty<IProAudienceLook> LiveAudienceLook { get; }

	IComplexCollection<IStage.Types.IScreenAssignment> StageLayoutMappings { get; }
}
