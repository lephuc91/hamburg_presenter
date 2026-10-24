using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.IO.Abstractions;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using Microsoft.Win32;
using Pro.Common.Collections;
using Pro.Common.FileSystem;
using Pro.Common.Logging;
using Pro.Common.Nullability;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Common.Utility;
using Pro.DO.Label;
using Pro.DO.Storage;
using Pro.DO.Transitions;
using Pro.PDF;
using Pro.UI.Components;
using Pro.UI.Controls;
using Pro.UI.Utility;
using ProPresenter.DO;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.Cues;
using ProPresenter.DO.DependencyInjection;
using ProPresenter.DO.Hotkey;
using ProPresenter.DO.Import;
using ProPresenter.DO.Import.Requests;
using ProPresenter.DO.Label;
using ProPresenter.DO.LiveVideo;
using ProPresenter.DO.Media;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Slide.Custom;
using ProPresenter.UI.ViewModels;
using ProPresenter.UI.ViewModels.Editor;
using ProPresenter.UI.ViewModels.MediaLibrary;
using ProPresenter.UI.ViewModels.Thumbnails;

namespace ProPresenter.ViewModels.Editor;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { })]
public class SlideInspectorVM : ObservableObject, ISlideInspectorVM, IDisposable
{
	[CompilerGenerated]
	private sealed class _003Cget_GraphicMedia_003Ed__35 : IEnumerable<MediaCue>, IEnumerable, IEnumerator<MediaCue>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private MediaCue _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		public SlideInspectorVM _003C_003E4__this;

		MediaCue IEnumerator<MediaCue>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003Cget_GraphicMedia_003Ed__35(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
			_003C_003El__initialThreadId = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			int num = _003C_003E1__state;
			SlideInspectorVM slideInspectorVM = _003C_003E4__this;
			switch (num)
			{
			default:
				return false;
			case 0:
			{
				_003C_003E1__state = -1;
				MediaCue mediaCue = slideInspectorVM.GraphicMediaAction?.Media?.ToCue(slideInspectorVM._app, slideInspectorVM._transitionDescriptions);
				if (mediaCue != null)
				{
					_003C_003E2__current = mediaCue;
					_003C_003E1__state = 1;
					return true;
				}
				break;
			}
			case 1:
				_003C_003E1__state = -1;
				break;
			}
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<MediaCue> IEnumerable<MediaCue>.GetEnumerator()
		{
			_003Cget_GraphicMedia_003Ed__35 result;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				result = this;
			}
			else
			{
				result = new _003Cget_GraphicMedia_003Ed__35(0)
				{
					_003C_003E4__this = _003C_003E4__this
				};
			}
			return result;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<MediaCue>)this).GetEnumerator();
		}
	}

	[CompilerGenerated]
	private sealed class _003Cget_VideoInputMedia_003Ed__41 : IEnumerable<MediaCue>, IEnumerable, IEnumerator<MediaCue>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private MediaCue _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		public SlideInspectorVM _003C_003E4__this;

		MediaCue IEnumerator<MediaCue>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003Cget_VideoInputMedia_003Ed__41(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
			_003C_003El__initialThreadId = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			int num = _003C_003E1__state;
			SlideInspectorVM slideInspectorVM = _003C_003E4__this;
			switch (num)
			{
			default:
				return false;
			case 0:
			{
				_003C_003E1__state = -1;
				MediaCue mediaCue = slideInspectorVM.VideoInputMediaAction?.Media?.ToCue(slideInspectorVM._app, slideInspectorVM._transitionDescriptions);
				if (mediaCue != null)
				{
					_003C_003E2__current = mediaCue;
					_003C_003E1__state = 1;
					return true;
				}
				break;
			}
			case 1:
				_003C_003E1__state = -1;
				break;
			}
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<MediaCue> IEnumerable<MediaCue>.GetEnumerator()
		{
			_003Cget_VideoInputMedia_003Ed__41 result;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				result = this;
			}
			else
			{
				result = new _003Cget_VideoInputMedia_003Ed__41(0)
				{
					_003C_003E4__this = _003C_003E4__this
				};
			}
			return result;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<MediaCue>)this).GetEnumerator();
		}
	}

	private readonly IMediaProvider _mediaProvider;

	private readonly IMediaCueThumbnailOverlayVMFactory? _overlayVMFactory;

	private readonly IApp _app;

	private readonly ITransitionDescriptionCollection _transitionDescriptions;

	private readonly IImport _import;

	private readonly IProcessHelper _processHelper;

	private readonly IFileSystem _fileSystem;

	[Pro.Common.SourceGenerator.Attributes.PropertyLink("IgnoreBackgroundColors", "IgnoreBackgroundColors")]
	private readonly IAdvanced _advanced;

	private readonly IImportProcessFactory _importProcessFactory;

	private readonly IMediaFactory _mediaFactory;

	private SlideCue? _selectedCue;

	[ObservableProperty]
	private CustomPresentation? _presentation;

	[ObservableProperty]
	[NotifyPropertyChangedFor("ItemEnabled", new string[] { "Hotkey", "SelectedLabel", "GraphicMediaActionPresent", "GraphicMediaAction", "GraphicMedia", "VideoInputMediaActionPresent", "VideoInputMediaAction", "VideoInputMedia", "TransportMedia" })]
	private CustomSlide? _selectedSlide;

	[ObservableProperty]
	private IMediaOverlayVM? _overlayVM;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public LabelEditorVM LabelEditorVM { get; }

	public IEnumerable<ActionLabel> ActionLabels { get; } = DataVault.SlideLabels;

	public bool ItemEnabled
	{
		get
		{
			return _selectedCue?.IsEnabled ?? false;
		}
		set
		{
			if (_selectedCue != null)
			{
				_selectedCue.IsEnabled = value;
			}
		}
	}

	public Key Hotkey
	{
		get
		{
			//IL_0029: Unknown result type (might be due to invalid IL or missing references)
			//IL_0036: Unknown result type (might be due to invalid IL or missing references)
			return (_selectedCue?.Hotkey?.Key).GetValueOrDefault();
		}
		set
		{
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			if (_selectedCue != null)
			{
				HotkeyHelper.AssignHotkey(_selectedCue, new SlideHotkey(value));
				OnPropertyChanged("Hotkey");
			}
		}
	}

	public ActionLabel? SelectedLabel
	{
		get
		{
			return _selectedCue?.SlideAction?.Label;
		}
		set
		{
			if (_selectedCue?.SlideAction != null)
			{
				_selectedCue.SlideAction.Label = value;
				OnPropertyChanged("SelectedLabel");
			}
		}
	}

	[MemberNotNullWhen(true, "GraphicMediaAction")]
	public bool GraphicMediaActionPresent
	{
		[MemberNotNullWhen(true, "GraphicMediaAction")]
		get
		{
			return GraphicMediaAction != null;
		}
	}

	public MediaAction? GraphicMediaAction => _selectedCue?.Actions.FirstOrDefaultOf((MediaAction mediaAction) => mediaAction?.IsGraphicMedia ?? false);

	public ITransportMedia? TransportMedia => _selectedCue?.Actions?.FirstOrDefaultOf((MediaAction mediaAction) => mediaAction?.Media is ITransportMedia)?.Media as ITransportMedia;

	public IEnumerable<MediaCue> GraphicMedia
	{
		[IteratorStateMachine(typeof(_003Cget_GraphicMedia_003Ed__35))]
		get
		{
			//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
			return new _003Cget_GraphicMedia_003Ed__35(-2)
			{
				_003C_003E4__this = this
			};
		}
	}

	[MemberNotNullWhen(true, "VideoInputMediaAction")]
	public bool VideoInputMediaActionPresent
	{
		[MemberNotNullWhen(true, "VideoInputMediaAction")]
		get
		{
			return VideoInputMediaAction != null;
		}
	}

	public MediaAction? VideoInputMediaAction => _selectedCue?.Actions.FirstOrDefaultOf((MediaAction mediaAction) => mediaAction?.LiveVideo != null);

	public IEnumerable<MediaCue> VideoInputMedia
	{
		[IteratorStateMachine(typeof(_003Cget_VideoInputMedia_003Ed__41))]
		get
		{
			//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
			return new _003Cget_VideoInputMedia_003Ed__41(-2)
			{
				_003C_003E4__this = this
			};
		}
	}

	public ILiveVideoInputCollection AvailableInputs
	{
		get
		{
			ILiveVideoInputCollection? availableLiveVideoInputs = OutputVault.AvailableLiveVideoInputs;
			availableLiveVideoInputs.ThrowWhenNull("inputs");
			return availableLiveVideoInputs;
		}
	}

	public ICommand<Color> SlideColorChangedCommand => new RelayCommand<Color>(delegate(Color c)
	{
		SelectedSlide.CompleteColorChange(c);
	}, (Color c) => SelectedSlide != null);

	public ICommand ChangeChordChartCommand => new RelayCommand(OnChangeChordChartCommand, () => SelectedSlide != null);

	public ICommand RemoveChordChartCommand => new RelayCommand(delegate
	{
		SelectedSlide.RemoveChordChart();
	}, () => SelectedSlide?.ChordChart?.IsValid == true);

	public ICommand<FileInfo> DropChordChartCommand => new RelayCommand<FileInfo>(delegate(FileInfo f)
	{
		OnAddChordChart(f.FullName);
	}, (FileInfo f) => f?.FullName.IsChordChartFile() ?? false);

	public ICommand ShowInFileExplorerCommand => new RelayCommand(OnShowInFileExplorer);

	public ICommand ShowCordChartInFileExplorerCommand => new RelayCommand(OnShowCordChartInFileExplorer, () => SelectedSlide?.ChordChart?.FullPath != null);

	public ICommand ChooseGraphicMediaFileCommand => new RelayCommand(OnChooseGraphicMediaFile);

	public ICommand OpenLiveVideoSetupCommand => new RelayCommand(OnOpenLiveVideoSetup);

	public ICommand AddMediaActionCommand => new RelayCommand(OnAddMediaAction);

	public ICommand RemoveMediaActionCommand => new RelayCommand(OnRemoveMediaAction);

	public ICommand AddVideoInputActionCommand => new RelayCommand(OnAddVideoInputAction);

	public ICommand RemoveVideoInputActionCommand => new RelayCommand(OnRemoveVideoInputAction);

	public bool IgnoreBackgroundColors => _advanced.IgnoreBackgroundColors;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public CustomPresentation? Presentation
	{
		get
		{
			return _presentation;
		}
		set
		{
			if (!EqualityComparer<CustomPresentation>.Default.Equals(_presentation, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.Presentation);
				_presentation = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.Presentation);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public CustomSlide? SelectedSlide
	{
		get
		{
			return _selectedSlide;
		}
		set
		{
			if (!EqualityComparer<CustomSlide>.Default.Equals(_selectedSlide, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.SelectedSlide);
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.ItemEnabled);
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.Hotkey);
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.SelectedLabel);
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.GraphicMediaActionPresent);
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.GraphicMediaAction);
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.GraphicMedia);
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.VideoInputMediaActionPresent);
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.VideoInputMediaAction);
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.VideoInputMedia);
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.TransportMedia);
				_selectedSlide = value;
				OnSelectedSlideChanged(value);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.SelectedSlide);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.ItemEnabled);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.Hotkey);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.SelectedLabel);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.GraphicMediaActionPresent);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.GraphicMediaAction);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.GraphicMedia);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.VideoInputMediaActionPresent);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.VideoInputMediaAction);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.VideoInputMedia);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.TransportMedia);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IMediaOverlayVM? OverlayVM
	{
		get
		{
			return _overlayVM;
		}
		set
		{
			if (!EqualityComparer<IMediaOverlayVM>.Default.Equals(_overlayVM, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.OverlayVM);
				_overlayVM = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.OverlayVM);
			}
		}
	}

	public event Action<LiveVideoInput>? OpenLiveVideoSetup;

	public SlideInspectorVM(IMediaProvider mediaProvider, IMediaCueThumbnailOverlayVMFactory? overlayVMFactory, IApp app, IImport import, IProcessHelper processHelper, IFileSystem fileSystem, IAdvanced advanced, IImportProcessFactory importProcessFactory, IProPresenterDOFactoryProvider factoryProvider, ITransitionDescriptionCollection transitionDescriptions)
	{
		_mediaProvider = mediaProvider;
		_overlayVMFactory = overlayVMFactory;
		_app = app;
		_import = import;
		_processHelper = processHelper;
		LabelEditorVM = new LabelEditorVM(new SlideLabelInteractor(new SingleTargetSlideLabelContext(() => _selectedCue), DataVault.SlideLabels, new SlideLabelPrompt()));
		_fileSystem = fileSystem;
		_advanced = advanced;
		_importProcessFactory = importProcessFactory;
		_transitionDescriptions = transitionDescriptions;
		_mediaFactory = factoryProvider.MediaFactory;
		AddPropertyLinks();
	}

	private void OnChangeChordChartCommand()
	{
		OpenFileDialog openFileDialog = new OpenFileDialog
		{
			Filter = FileFilters.ChordChartFileFilter
		};
		if (openFileDialog.ShowDialog() == true)
		{
			string fileName = openFileDialog.FileName;
			OnAddChordChart(fileName);
		}
	}

	private void OnAddChordChart(string filename)
	{
		if (filename.IsPDFFile())
		{
			try
			{
				using PdfRenderer pdfRenderer = new PdfRenderer(filename);
				if (pdfRenderer.PageCount > 1)
				{
					PdfViewerDialog pdfViewerDialog = new PdfViewerDialog(pdfRenderer);
					if (DialogHelper.ShowDialog(pdfViewerDialog, null, new PdfViewerDialogPositionProvider()))
					{
						SelectedSlide?.ChangeChordChart((RelativePath)filename, pdfViewerDialog.SelectedPageNumber);
					}
				}
				else
				{
					SelectedSlide?.ChangeChordChart((RelativePath)filename, 1);
				}
				return;
			}
			catch (Exception exception)
			{
				Log.Error(exception);
				return;
			}
		}
		if (!filename.IsImageFile())
		{
			return;
		}
		_importProcessFactory.Create(new string[1] { filename }.Select((string f) => new FileImportRequest(f, delegate(string o, string n, FileMediaBase? media)
		{
			SelectedSlide?.ChangeChordChart((RelativePath)n);
		})
		{
			IsChordChartImport = true
		})).StartImport();
	}

	private void SelectedSlideActionPropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "Label")
		{
			OnPropertyChanged("SelectedLabel");
		}
	}

	private void OnShowInFileExplorer()
	{
		RelativePath relativePath = GraphicMediaAction?.FileMedia?.SourceFile;
		if (!(relativePath == null))
		{
			_processHelper.OpenFileInExplorer(relativePath);
		}
	}

	private void OnShowCordChartInFileExplorer()
	{
		if (SelectedSlide?.ChordChart?.FullPath != null && _fileSystem.File.Exists(SelectedSlide.ChordChart.FullPath))
		{
			_processHelper.OpenFileInExplorer(SelectedSlide.ChordChart.FullPath);
		}
	}

	private void OnChooseGraphicMediaFile()
	{
		if (!GraphicMediaActionPresent || SelectedSlide == null)
		{
			return;
		}
		_mediaProvider?.GetMedia(SelectedSlide.ContainerId, delegate(MediaBase? m)
		{
			if (m != null)
			{
				_selectedCue?.AddAction(new MediaAction(m, _app, _transitionDescriptions));
				OnPropertyChanged("GraphicMediaAction");
				OnPropertyChanged("GraphicMedia");
			}
		});
	}

	private void OnOpenLiveVideoSetup()
	{
		if (VideoInputMediaAction?.LiveVideo?.LiveVideo?.Input != null)
		{
			this.OpenLiveVideoSetup?.Invoke(VideoInputMediaAction.LiveVideo.LiveVideo.Input);
		}
	}

	private void OnAddMediaAction()
	{
		if (GraphicMediaActionPresent)
		{
			return;
		}
		_mediaProvider.GetMedia(SelectedSlide?.ContainerId ?? string.Empty, delegate(MediaBase? m)
		{
			if (m != null)
			{
				m.ApplyImportSetingsForSlideMediaAction(_import);
				MediaAction mediaAction = new MediaAction(m, _app, _transitionDescriptions);
				if (m.MediaType != MediaType.Audio)
				{
					mediaAction.TriggerLayer = TriggerLayer.Background;
				}
				_selectedCue?.AddAction(mediaAction);
				OnPropertyChanged("GraphicMediaAction");
				OnPropertyChanged("GraphicMedia");
			}
		});
	}

	private void OnRemoveMediaAction()
	{
		if (GraphicMediaActionPresent)
		{
			_selectedCue?.RemoveAction(GraphicMediaAction);
		}
	}

	private void OnAddVideoInputAction()
	{
		if (!VideoInputMediaActionPresent)
		{
			LiveVideoMedia liveVideoMedia = _mediaFactory.CreateLiveVideoMedia();
			_selectedCue?.AddAction(new MediaAction(liveVideoMedia, _app, _transitionDescriptions)
			{
				Name = (liveVideoMedia.LiveVideo?.Input?.LongName ?? string.Empty)
			});
		}
	}

	private void OnRemoveVideoInputAction()
	{
		if (VideoInputMediaActionPresent)
		{
			_selectedCue?.RemoveAction(VideoInputMediaAction);
		}
	}

	private void Actions_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		OnPropertyChanged("GraphicMediaActionPresent");
		OnPropertyChanged("GraphicMediaAction");
		OnPropertyChanged("GraphicMedia");
		OnPropertyChanged("VideoInputMediaActionPresent");
		OnPropertyChanged("VideoInputMediaAction");
		OnPropertyChanged("VideoInputMedia");
		OnPropertyChanged("TransportMedia");
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnSelectedSlideChanged(CustomSlide? value)
	{
		if (_selectedCue?.SlideAction != null)
		{
			_selectedCue.SlideAction.PropertyChanged -= SelectedSlideActionPropertyChanged;
			_selectedCue.Actions.CollectionChanged -= Actions_CollectionChanged;
		}
		_selectedCue = Presentation?.ArrangementGroups.SelectMany((CueGroup g) => g.Cues).FirstOrDefault((SlideCue c) => c.SlideAction != null && c.SlideAction.Slide == SelectedSlide);
		if (_selectedCue?.SlideAction != null)
		{
			OverlayVM = _overlayVMFactory?.Create(_selectedCue);
			_selectedCue.SlideAction.PropertyChanged += SelectedSlideActionPropertyChanged;
			_selectedCue.Actions.CollectionChanged += Actions_CollectionChanged;
		}
		LabelEditorVM.Reload();
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	protected virtual void Dispose(bool disposing)
	{
		if (!_disposed && disposing)
		{
			_disposed = true;
			OnDispose();
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void OnDispose()
	{
		RemovePropertyLinks();
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void _advanced_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "IgnoreBackgroundColors")
		{
			OnPropertyChanged("IgnoreBackgroundColors");
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void AddPropertyLinks()
	{
		_advanced.PropertyChanged += _advanced_PropertyChanged;
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void RemovePropertyLinks()
	{
		_advanced.PropertyChanged -= _advanced_PropertyChanged;
	}
}
