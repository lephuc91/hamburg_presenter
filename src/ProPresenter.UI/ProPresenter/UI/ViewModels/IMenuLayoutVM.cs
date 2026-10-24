using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Media;
using Pro.Common.Components.Reversibility;
using Pro.UI.Components;
using ProPresenter.DO.ClearGroups;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Looks;
using ProPresenter.DO.OutputConfiguration;
using ProPresenter.DO.Timer;
using ProPresenter.UI.Commands;
using ProPresenter.UI.PresentationView;
using ProPresenter.UI.ViewModels.Preview;
using ProPresenter.ViewModels.UserFeedback;

namespace ProPresenter.UI.ViewModels;

public interface IMenuLayoutVM : INotifyPropertyChanged
{
	bool ShowFeedbackMenu { get; }

	InlineType ActiveInlineType { get; set; }

	IEnumerable<ScreenArrangementBase> Screens { get; }

	IAudienceLookCollection AudienceLooks { get; }

	LiveAudienceLook LiveAudienceLook { get; }

	TimerCollection Timers { get; }

	IEnumerable<SlideCue> StageLayouts { get; }

	CommandTargetType EditorTextCommandTarget { get; }

	CommandTargetType EditorCommandTarget { get; }

	bool AudienceEnable { get; set; }

	bool StageEnable { get; set; }

	bool IsEditorMenuVisible { get; }

	bool IsOutputVisible { get; }

	bool IsRegistered { get; }

	bool IsRulerVisible { get; set; }

	bool ShowTemplateGuides { get; set; }

	bool ShowSlidesGuides { get; set; }

	bool IsScaleToFitActive { get; set; }

	bool SlideOnStageDisplayOnly { get; }

	bool CalendarEnabled { get; }

	bool IsCalendarVisible { get; set; }

	AudienceScreenArrangementCollection AudienceScreens { get; }

	StageScreenArrangementCollection StageScreens { get; }

	ImageSource? LogoImageSource { get; }

	bool IsRecording { get; set; }

	string StartStopButtonLabel { get; }

	bool ShowAdvancedOnScreenStats { get; }

	bool HiddenOptionsVisible { get; set; }

	ClearGroupCollection ClearGroups { get; }

	UndoStack? ActiveUndoStack { get; }

	ICommand UndoCommand { get; }

	ICommand RedoCommand { get; }

	ICommand<SlideCue> EditSelectedLayoutCommand { get; }

	ICommand<IOutputScreenVM> SetScreenPreviewCommand { get; }

	ICommand<ClearGroup> TriggerClearGroupCommand { get; }

	IAttachmentUploadVM AttachmentUploadVM { get; }

	PresentationViewType PresentationViewType { get; }
}
