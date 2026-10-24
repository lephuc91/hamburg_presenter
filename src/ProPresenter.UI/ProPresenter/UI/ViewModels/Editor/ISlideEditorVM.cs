using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Pro.Common.Collections;
using Pro.Common.Mathematics;
using Pro.Editor;
using Pro.Editor.Canvas;
using Pro.UI.Components;
using Pro.ssAPI;
using ProPresenter.Controller.Outputs;
using ProPresenter.DO;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.Slide.Custom;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.Themes;
using ProPresenter.UI.Commands;
using ProPresenter.UI.SlideEditor;
using ProPresenter.UI.Thumbnails;

namespace ProPresenter.UI.ViewModels.Editor;

public interface ISlideEditorVM : INotifyPropertyChanged
{
	ssAPIOutput OutputController { get; }

	EditMode EditMode { get; set; }

	CommandTargetType CommandTargetType { get; }

	ObservableCollection<CustomSlide> Slides { get; }

	CustomSlide? SelectedSlide { get; }

	ImmutableObservableCollection<CustomSlide> SelectedSlides { get; }

	ObservableCollection<SlideElementBase> SelectedSlideElements { get; }

	ObservableCollection<ICanvasElement> SelectedCanvasElements { get; }

	IShapeInspectorVM ShapeInspectorVM { get; }

	ITextInspectorVM TextInspectorVM { get; }

	IBuildInspectorVM BuildInspectorVM { get; }

	IPropsInspectorVM PropsInspectorVM { get; }

	string SelectedItemName { get; set; }

	Color SlidesGuidesColor { get; set; }

	Color TemplateGuidesColor { get; set; }

	Color AlignmentGuidesColor { get; set; }

	Color Background { get; }

	Color SecondaryBackground { get; }

	Color CanvasGridColor { get; set; }

	Color SlideNoteBackground { get; set; }

	bool ShowSlideNotesRuler { get; set; }

	bool ShowFullAddMenu { get; }

	bool IsLocked { get; }

	bool IsHidden { get; }

	bool UsePrimaryBackground { get; set; }

	bool UseSecondaryBackground { get; set; }

	bool ShowCanvasGrid { get; set; }

	bool IsScaleToFitActive { get; set; }

	bool ShowSlidesGuides { get; set; }

	bool ShowTemplateGuides { get; set; }

	bool ShowRelativeSpacing { get; set; }

	bool ShowRelativeSizing { get; set; }

	bool ShowCenterGuides { get; set; }

	bool ShowEdgeGuides { get; set; }

	bool GuidelinesEnabled { get; }

	bool IsRulerVisible { get; set; }

	bool IsTemplateEditMode { get; }

	bool IsSlideEditMode { get; }

	bool IsCustomZoomInput { get; set; }

	double ZoomFactor { get; set; }

	double CanvasGridSpacing { get; set; }

	int CanvasGridSubdivisions { get; set; }

	bool ShowCheckerboard { get; set; }

	bool IsNotesInspectorVisible { get; }

	bool CanShowSlideNotes { get; }

	bool SlideNotesVisible { get; set; }

	IPenTool? ActivePen { get; set; }

	bool ShowPenHelper { get; }

	string PenHelperText { get; }

	ObservableCollection<double> SortedZoomFactors { get; }

	InspectorTab AvailableInspectorTabs { get; }

	InspectorTab SelectedInspectorTab { get; set; }

	ViewportRequestor ViewportRequestor { get; }

	ICommand DuplicateCommand { get; }

	ICommand CopyCommand { get; }

	ICommand CutCommand { get; }

	ICommand PasteSlidesCommand { get; }

	ICommand PasteCommand { get; }

	ICommand DeleteCommand { get; }

	ICommand? BreakTextToNewSlideCommand { get; }

	ICommand? BreakTextToNextSlideCommand { get; }

	ICommand DuplicateElementsCommand { get; }

	ICommand<TemplateSlide> AddCommand { get; }

	ICommand<double> ChangeZoomFactorCommand { get; }

	ICommand ToggleScaleToFitCommand { get; }

	ICommand<InsertEditorObjectSourceType> ActivatePenCommand { get; }

	ICommand ActivateCustomZoomFactorInputCommand { get; }

	ICommand<AddElementCommandParameters?> AddShapeCommand { get; }

	ICommand<InsertEditorObjectSourceType> AddMediaCommand { get; }

	ICommand<(FileInfo[], Vector2<double>)> ImportMediaCommand { get; }

	ICommand<InsertEditorObjectSourceType> AddLiveVideoElementCommand { get; }

	ICommand<InsertEditorObjectSourceType> AddHTMLElementCommand { get; }

	ICommand<AddElementCommandParameters?> AddCurrentStageSlideCommand { get; }

	ICommand<AddElementCommandParameters?> AddNextStageSlideCommand { get; }

	ICommand<AddElementCommandParameters?> AddTimerStageItemCommand { get; }

	ICommand<InsertEditorObjectSourceType> AddMessageCommand { get; }

	ICommand<InsertEditorObjectSourceType> AddStageVideoCountDownElementCommand { get; }

	ICommand<InsertEditorObjectSourceType> AddAudioCountDownElementCommand { get; }

	ICommand<AddElementCommandParameters?> AddPlaybackMarkerElementCommand { get; }

	ICommand<InsertEditorObjectSourceType> AddTimecodeElementCommand { get; }

	ICommand<InsertEditorObjectSourceType> AddSystemClockElementCommand { get; }

	ICommand<InsertEditorObjectSourceType> AddChordChartElementCommand { get; }

	ICommand<AddElementCommandParameters?> AddScreenPreviewElementCommand { get; }

	ICommand<InsertEditorObjectSourceType> AddPCOLiveElementCommand { get; }

	ICommand<AddElementCommandParameters?> AddGroupElementCommand { get; }

	ICommand<AddElementCommandParameters?> AddSlideLabelElementCommand { get; }

	ICommand<InsertEditorObjectSourceType> AddCaptureStatusElementCommand { get; }

	ICommand<AddElementCommandParameters?> AddStaticSlideImageCommand { get; }

	ICommand<BezierPoint> RemovePointCommand { get; }

	ICommand HideElementsCommand { get; }

	ICommand LockElementsCommand { get; }

	ICommand CutElementsCommand { get; }

	ICommand CopyElementsCommand { get; }

	ICommand PasteElementsCommand { get; }

	ICommand DeleteElementsCommand { get; }

	ICommand DeleteUnlockedElementsCommand { get; }

	ICommand CopyStaticGuidesCommand { get; }

	ICommand PasteStaticGuidesCommand { get; }

	ICommand RemoveAllGuidesCommand { get; }

	ICommand<CustomSlide> SelectSlideCommand { get; }

	ICommand SelectAllSlidesCommand { get; }

	ICommand MovePreviousSlideCommand { get; }

	ICommand MoveNextSlideCommand { get; }

	ICommand<DragDropCommandParameters<CustomSlide, PresentationBase>> MoveSlidesCommand { get; }

	ICommand<CustomSlide> UpdateSelectedSlidesCommand { get; }

	ICommand<bool> ZoomCommand { get; }

	ICommand ZoomToActualSizeCommand { get; }

	ICommand<TemplateSlide>? SelectTemplateCommand { get; }

	ICommand SlideNoteTextBoxGotFocusCommand { get; }

	ICommand CanvasGotFocusCommand { get; }

	ICommand<int> SelectSlideByIndexCommand { get; }

	ICommand ToggleGridCommand { get; }

	ICommand<SlideElementBase> SelectElementCommand { get; }

	BitmapSource? BackgroundImage { get; }

	ScaleBehavior BackgroundImageScale { get; }

	ScaleAlignment BackgroundImageAlignment { get; }

	ICommand ToggleAllGuidelinesCommand { get; }

	ICommand<ClosedBezierPath> FitToTextCommand { get; }

	ICommand<ClosedBezierPath> OverlayEditCommand { get; }

	ICommand BringForwardElementsCommand { get; }

	ICommand BringToFrontElementsCommand { get; }

	ICommand SendBackwardElementsCommand { get; }

	ICommand SendToBackElementsCommand { get; }

	bool IncludeBackground { get; }

	BitmapSource? VideoInputThumbnailImage { get; }

	ICommand CreateNewSlideFromSelectedSlideCommand { get; }

	event Action RequestCanvasScroll;

	void SelectSlide(CustomSlide slide);

	void SelectSlides(IEnumerable<CustomSlide> slides);
}
