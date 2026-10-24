using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Media;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.Mathematics;
using Pro.Common.ObjectBinding;
using Pro.Common.Time;
using Pro.DO.Label;
using Pro.DO.Storage;
using Pro.DO.Transitions;
using Pro.DO.Triggering;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.Chords;
using ProPresenter.DO.Cues;
using ProPresenter.DO.DependencyInjection;
using ProPresenter.DO.Hotkey;
using ProPresenter.DO.Librarian;

namespace ProPresenter.DO.Presentation;

public interface IPresentation : ICloneable<IPresentation>, ISizeableTarget, INotifyPropertyChanged, ICutPasteCollection<SlidesCopyData>, ICutCollection<SlidesCopyData>
{
	Guid ID { get; }

	PresentationType PresentationType { get; }

	bool IsAvailable { get; }

	bool HasDataLoaded { get; }

	bool IsPendingLoad { get; }

	Arrangement DefaultArrangement { get; }

	IArrangement? ActiveArrangement { get; set; }

	string? ActiveArrangementName { get; set; }

	Key? BaseKey { get; set; }

	Key? TargetKey { get; set; }

	bool SupportsChords { get; }

	ArrangementCollection Arrangements { get; }

	CueGroupCollection ArrangementGroups { get; }

	TransitionParameters? SelectedTransition { get; set; }

	OutputDestination Destination { get; set; }

	CCLIData CCLIInfo { get; }

	string Name { get; set; }

	RelativePath? SourceFile { get; set; }

	new Vector2<double> Size { get; }

	string Notes { get; set; }

	IEnumerable<string> Content { get; }

	DateTime? LastUsed { get; set; }

	bool UseBackgroundColor { get; set; }

	System.Windows.Media.Color BackgroundColor { get; set; }

	Timeline PresentationTimeline { get; }

	double SlideShowDuration { get; set; }

	bool SlideShowEnabled { get; set; }

	UndoStack UndoStack { get; }

	ICopyPresentationIdentifier CopyIdentifier { get; }

	bool HasMissingFonts { get; }

	string ContainerId { get; }

	event Action<IPresentation>? DataFirstLoaded;

	event Action<IPresentation>? DataModified;

	event Action<IPresentation, string>? FileNameModified;

	event Action<IPresentation>? NameChanging;

	event Action<IPresentation>? NameChanged;

	new IPresentation Clone();

	IEnumerable<string> GetAllMediaFilePaths();

	IPresentation CloneWithID();

	Pro.DO.Triggering.IAction? AddSlideAction(IEnumerable<SlideCue> targetSlideCues, Pro.DO.Triggering.IAction action, bool cloneAction, ArrangedCue? selectedSlide = null);

	void AddGoToNextTimer(IEnumerable<SlideCue> targetSlideCues, TimeSlice time, bool loopToBeginning);

	void AssignSlideLabel(ActionLabel? label, IEnumerable<SlideCue> cues);

	void AssignSlideColor(System.Windows.Media.Color color, IEnumerable<SlideCue> cues);

	void AssignGroupLabel(GroupLabel? label, IEnumerable<ArrangedCue>? cues);

	void AssignGroupColor(System.Windows.Media.Color color, IEnumerable<ArrangedCue>? cues);

	void UngroupCues(IEnumerable<ArrangedCue> cues, IArrangement? activeArrangement = null);

	void ResetCueClick();

	void IncreaseCueClick(ArrangedCue clickedCue);

	void ToggleCues(IEnumerable<ArrangedCue> cues, bool isEnabled);

	void AssignHotkey(SlideCue cue, SlideHotkey? hotkey);

	void CuesDroppedInto(IEnumerable<SlideCue> cues, SlideCue targetCue, bool droppedBefore, bool insertNewGroup, CueGroup targetGroup);

	void MoveCuesTo(IEnumerable<SlideCue> cues, SlideCue targetCue, bool droppedBefore, bool insertNewGroup, CueGroup targetGroup, bool copy, IArrangement? activeArrangement = null);

	new void CutFrom(IEnumerable<SlidesCopyData> data);

	new void PasteInto(IEnumerable<SlidesCopyData> data, int index);

	Pro.SerializationInterop.RVProtoData.Presentation Serialize();

	void EnsureLoaded();

	int FixDuplicatedFillMediaIds();

	void ResetID(bool notifyDataModified);

	void Deserialize(IPresentationLoadData data, string filename);

	void InvalidateMissingFontsCache();

	ObjectBinder<PresentationBase, Pro.Entity.IPresentation> Bind(IUiScheduler scheduler, IProPresenterDOFactoryProvider factoryProvider, IActionBinderFactory actionBinderFactory, Pro.Entity.IPresentation entityDoc);
}
