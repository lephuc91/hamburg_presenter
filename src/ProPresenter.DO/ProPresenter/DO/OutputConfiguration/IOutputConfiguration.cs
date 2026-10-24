using System;
using System.Collections.Generic;
using System.ComponentModel;
using Pro.Common.Components.Reversibility;
using Pro.Common.Time;
using Pro.DO.Audio;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Audio;
using ProPresenter.DO.Capture;
using ProPresenter.DO.Looks;
using ProPresenter.DO.Masks;
using ProPresenter.DO.Workspaces;

namespace ProPresenter.DO.OutputConfiguration;

public interface IOutputConfiguration : INotifyPropertyChanged, IDocumentProvider
{
	AudienceScreenArrangementCollection AudienceArrangementScreens { get; }

	StageScreenArrangementCollection StageArrangementScreens { get; }

	UndoStack UndoStack { get; }

	bool CanAddMoreScreens { get; }

	IEnumerable<ScreenArrangementBase> ArrangementScreens { get; }

	ICaptureSettingsDocument CaptureSettings { get; }

	StageScreenLayoutMap StageScreenLayoutMap { get; }

	LiveAudienceLook LiveLook { get; }

	IAudienceLookCollection AudienceLooks { get; }

	IMaskCollection Masks { get; }

	TimeSlice AudioInputTransitionTime { get; set; }

	IAudioInputCollection AvailableAudioInputs { get; }

	IAudioSetup DigitalAudioSettings { get; }

	event System.Action ConfigurationChanged;

	event Action<WorkspaceChangedArgs> WorkspaceChanged;

	ProPresenterWorkspace Serialize();

	void Deserialize(ProPresenterWorkspace workspace, bool removeExisting);

	void Save();
}
