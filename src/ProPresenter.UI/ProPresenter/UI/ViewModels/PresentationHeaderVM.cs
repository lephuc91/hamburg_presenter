using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using Pro.Common.Components;
using Pro.DO.Transitions;
using Pro.Text;
using Pro.UI.Components;
using Pro.UI.DialogService;
using ProPresenter.Controller;
using ProPresenter.Controller.Outputs;
using ProPresenter.DO;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Import;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.Settings;
using ProPresenter.UI.PresentationView;

namespace ProPresenter.UI.ViewModels;

public class PresentationHeaderVM : LinkedNotifyPropertyChangedBase, IPresentationHeaderVM, INotifyPropertyChanged
{
	private IDocumentCue? _documentCue;

	private PresentationHeaderViewType _activeHeaderView;

	private readonly IApp _app;

	private readonly ITimelineManager _timelineManager;

	private readonly ISizeSelectorVM _sizeSelectorVm;

	private readonly IMissingFontService _missingFontService;

	private readonly IMissingFontWindowProvider _missingFontWindowProvider;

	private bool? _cachedHasMissingFonts;

	private IPresentation? _subscribedPresentation;

	public TransitionHandler TransitionHandler { get; }

	public static ssAPIOutput? OutputController { get; private set; }

	public ISizeSelectorVM SizeSelector => _sizeSelectorVm;

	public IDocumentCue? DocumentCue
	{
		get
		{
			return _documentCue;
		}
		set
		{
			SetValue<IDocumentCue>("DocumentCue", ref _documentCue, value, delegate(IDocumentCue o, IDocumentCue n)
			{
				_activeHeaderView = PresentationHeaderViewType.None;
				if (o != null)
				{
					o.PropertyChanged -= base.RaiseLinkedValues;
				}
				if (n != null)
				{
					n.PropertyChanged += base.RaiseLinkedValues;
					if (_app.HeaderStates.TryGetValue(n.ID, out var value2))
					{
						_activeHeaderView = value2;
					}
				}
				_sizeSelectorVm.Target = DocumentAction?.Presentation;
				SubscribeToPresentationPropertyChanges();
				_cachedHasMissingFonts = null;
				OnPropertyChanged("DocumentAction");
				OnPropertyChanged("ActiveHeaderView");
				OnPropertyChanged("HasMissingFonts");
				OnPropertyChanged("HasAnyIssues");
				OnPropertyChanged("SizeIsConfigured");
			});
		}
	}

	public IDocumentAction? DocumentAction => _documentCue?.DocumentAction;

	public bool HasMissingFonts
	{
		get
		{
			if (DocumentAction?.Presentation == null)
			{
				return false;
			}
			if (_cachedHasMissingFonts.HasValue)
			{
				return _cachedHasMissingFonts.Value;
			}
			_cachedHasMissingFonts = CheckForMissingFonts(DocumentAction.Presentation);
			return _cachedHasMissingFonts.Value;
		}
	}

	public bool SizeIsConfigured => _sizeSelectorVm.SizeIsConfigured;

	public bool HasAnyIssues
	{
		get
		{
			if (SizeIsConfigured)
			{
				return HasMissingFonts;
			}
			return true;
		}
	}

	public PresentationHeaderViewType ActiveHeaderView
	{
		get
		{
			return _activeHeaderView;
		}
		set
		{
			SetValue("ActiveHeaderView", ref _activeHeaderView, value, delegate(PresentationHeaderViewType o, PresentationHeaderViewType n)
			{
				if (DocumentCue != null)
				{
					_app.HeaderStates[DocumentCue.ID] = n;
					if (n != PresentationHeaderViewType.Timeline)
					{
						_timelineManager.StopRecording(DocumentCue);
					}
				}
			});
		}
	}

	public double[] SlideShowDurations { get; } = new double[4] { 5.0, 10.0, 15.0, 20.0 };

	public ICommand RemoveSlideShowCommand => new RelayCommand(OnRemoveSlideShowCommand, IsDocumentValid);

	public ICommand<double> SetSlideShowCommand => new RelayCommand<double>(OnSetSlideShowCommand, (double d) => IsDocumentValid());

	public ICommand SetCustomSlideShowCommand => new RelayCommand(OnSetCustomSlideShowCommand, IsDocumentValid);

	public ICommand ResolveMissingFontsCommand => new RelayCommand(OnResolveMissingFonts);

	public ICommand<OutputDestination> ChangeOutputDestinationCommand => new RelayCommand<OutputDestination>(OnChangeOutputDestinationCommand, (OutputDestination d) => IsDocumentValid());

	public PresentationHeaderVM(IApp app, ITimelineManager timelineManager, IMissingFontService missingFontService, IMissingFontWindowProvider missingFontWindowProvider, IOutputService outputService)
	{
		TransitionHandler = new TransitionHandler(DataVault.Transitions);
		TransitionHandler.TransitionFinalized += TransitionUpdated;
		LinkProperties("DocumentAction", "DocumentAction");
		_app = app;
		_timelineManager = timelineManager;
		_missingFontService = missingFontService;
		_missingFontWindowProvider = missingFontWindowProvider;
		_sizeSelectorVm = new SizeSelectorVM(outputService);
		_sizeSelectorVm.PropertyChanged += delegate(object? s, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == "SizeIsConfigured")
			{
				OnPropertyChanged("SizeIsConfigured");
				OnPropertyChanged("HasAnyIssues");
			}
		};
		LinkAction("DocumentAction", delegate
		{
			_sizeSelectorVm.Target = DocumentAction?.Presentation;
			SubscribeToPresentationPropertyChanges();
		});
	}

	public static void Initialize(ssAPIOutput outputController)
	{
		if (OutputController != null)
		{
			throw new NotSupportedException();
		}
		OutputController = outputController;
	}

	private void SubscribeToPresentationPropertyChanges()
	{
		if (_subscribedPresentation != null)
		{
			_subscribedPresentation.PropertyChanged -= OnPresentationPropertyChanged;
			_subscribedPresentation = null;
		}
		IPresentation presentation = DocumentAction?.Presentation;
		if (presentation != null)
		{
			_subscribedPresentation = presentation;
			_subscribedPresentation.PropertyChanged += OnPresentationPropertyChanged;
		}
	}

	private void OnPresentationPropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (!(e.PropertyName != "HasMissingFonts"))
		{
			_cachedHasMissingFonts = null;
			OnPropertyChanged("HasMissingFonts");
			OnPropertyChanged("HasAnyIssues");
		}
	}

	private void OnRemoveSlideShowCommand()
	{
		if (DocumentAction?.Presentation != null)
		{
			DocumentAction.Presentation.SlideShowEnabled = false;
		}
	}

	private void OnSetSlideShowCommand(double duration)
	{
		if (DocumentAction?.Presentation != null)
		{
			DocumentAction.Presentation.SlideShowDuration = duration;
			DocumentAction.Presentation.SlideShowEnabled = true;
		}
	}

	private void OnSetCustomSlideShowCommand()
	{
		if (DocumentAction?.Presentation != null)
		{
			CustomSlideShowDuration customSlideShowDuration = new CustomSlideShowDuration(DocumentAction.Presentation.SlideShowDuration);
			if (MessageDialogService.ShowSimpleContent(string.Empty, (DependencyObject)(object)customSlideShowDuration))
			{
				OnSetSlideShowCommand(customSlideShowDuration.CustomDuration);
			}
		}
	}

	private void OnChangeOutputDestinationCommand(OutputDestination destination)
	{
		DocumentAction.Destination = destination;
	}

	private void OnResolveMissingFonts()
	{
		if (DocumentAction?.Presentation == null)
		{
			return;
		}
		IReadOnlyCollection<MissingFontInfo> readOnlyCollection = _missingFontService.DetectMissingFonts(DocumentAction.Presentation);
		if (readOnlyCollection.Count != 0)
		{
			Dictionary<FontInfo, FontInfo> dictionary = _missingFontWindowProvider.ShowMissingFontDialog(readOnlyCollection, MissingFontContext.Standalone);
			if (dictionary != null)
			{
				_missingFontService.ApplyFontReplacements(DocumentAction.Presentation, dictionary);
				DocumentAction.Presentation.InvalidateMissingFontsCache();
			}
		}
	}

	private bool IsDocumentValid()
	{
		return DocumentAction?.Presentation != null;
	}

	private void TransitionUpdated(TransitionParameters? newTransition)
	{
		if (IsDocumentValid())
		{
			DocumentAction.Presentation.SelectedTransition = newTransition;
		}
	}

	private bool CheckForMissingFonts(IPresentation presentation)
	{
		if (!presentation.IsAvailable)
		{
			return false;
		}
		return _missingFontService.DetectMissingFonts(presentation).Count > 0;
	}
}
