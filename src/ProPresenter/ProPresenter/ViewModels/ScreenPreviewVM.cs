using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using Pro.Common.Collections;
using Pro.Common.SourceGenerator.Attributes;
using Pro.UI.Components;
using ProPresenter.Controller;
using ProPresenter.DO;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Analytics;
using ProPresenter.DO.ClearGroups;
using ProPresenter.DO.OutputConfiguration;
using ProPresenter.DO.Repositories;
using ProPresenter.DO.Settings;
using ProPresenter.UI.ViewModels;
using ProPresenter.UI.ViewModels.Preview;
using ProPresenter.ViewModels.Preview;
using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.ViewModels;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { })]
public class ScreenPreviewVM : ObservableObject, IScreenPreviewVM, IDisposable
{
	[Pro.Common.SourceGenerator.Attributes.PropertyLink("AudienceEnable", "AudienceEnable")]
	[Pro.Common.SourceGenerator.Attributes.PropertyLink("AudienceEnable", "IsOutputOn")]
	[Pro.Common.SourceGenerator.Attributes.PropertyLink("StageEnable", "StageEnable")]
	[Pro.Common.SourceGenerator.Attributes.PropertyLink("Logo", "Logo")]
	private readonly ICoreManager _manager;

	[Pro.Common.SourceGenerator.Attributes.ActionLink("SelectedPreviewScreenID", "UpdateSelectedPreviewScreen")]
	private readonly IApp _app;

	private readonly IProPresenterResourceService _resourceService;

	private readonly IOutputRepository _outputRepository;

	private readonly List<ClearType> _activeLayers = new List<ClearType>();

	[ObservableProperty]
	[NotifyPropertyChangedFor("SelectedPreviewScreen")]
	private ScreenArrangementBase? _internalSelectedPreviewScreen;

	[ObservableProperty]
	[NotifyPropertyChangedFor("IsClearAllAvailable")]
	private bool _isMusicLayerActive;

	[ObservableProperty]
	[NotifyPropertyChangedFor("IsClearAllAvailable")]
	private bool _isMessageLayerActive;

	[ObservableProperty]
	[NotifyPropertyChangedFor("IsClearAllAvailable")]
	private bool _isPropsLayerActive;

	[ObservableProperty]
	[NotifyPropertyChangedFor("IsClearAllAvailable")]
	[NotifyPropertyChangedFor("IsAnnouncementLayerActive")]
	private bool _isAnnouncementForegroundActive;

	[ObservableProperty]
	[NotifyPropertyChangedFor("IsClearAllAvailable")]
	[NotifyPropertyChangedFor("IsAnnouncementLayerActive")]
	private bool _isAnnouncementBackgroundActive;

	[ObservableProperty]
	[NotifyPropertyChangedFor("IsClearAllAvailable")]
	private bool _isSlideLayerActive;

	[ObservableProperty]
	[NotifyPropertyChangedFor("IsClearAllAvailable")]
	private bool _isBackgroundLayerActive;

	[ObservableProperty]
	[NotifyPropertyChangedFor("IsClearAllAvailable")]
	private bool _isLiveVideoLayerActive;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public bool IsOutputOn => _manager.AudienceEnable;

	private IEnumerable<ScreenArrangementBase> AvailableScreenPreviews => _outputRepository.AudienceScreenArrangementCollection.Concat(_outputRepository.StageScreenArrangementCollection);

	public IOutputScreenVM? SelectedPreviewScreen
	{
		get
		{
			if (InternalSelectedPreviewScreen == null)
			{
				return null;
			}
			return new OutputScreenVM(InternalSelectedPreviewScreen);
		}
	}

	public AudienceScreenArrangementCollection AudienceScreens => _outputRepository.AudienceScreenArrangementCollection;

	public StageScreenArrangementCollection StageScreens => _outputRepository.StageScreenArrangementCollection;

	public bool IsClearAllAvailable
	{
		get
		{
			if (!IsMusicLayerActive && !IsMessageLayerActive && !IsPropsLayerActive && !IsAnnouncementLayerActive && !IsSlideLayerActive && !IsSlideLayerActive && !IsBackgroundLayerActive)
			{
				return IsLiveVideoLayerActive;
			}
			return true;
		}
	}

	public bool IsAnnouncementLayerActive
	{
		get
		{
			if (!IsAnnouncementBackgroundActive)
			{
				return IsAnnouncementForegroundActive;
			}
			return true;
		}
	}

	public bool AudienceEnable => _manager.AudienceEnable;

	public bool StageEnable => _manager.StageEnable;

	public MediaAction? Logo => _manager.Logo;

	public ClearGroup[] ClearGroups => _resourceService.ClearGroups.Where((ClearGroup c) => !c.IsHiddenInPreview).Take(5).ToArray();

	public ClearType[] ActiveLayers => _activeLayers.ToArray();

	public ICommand<CreateRenderViewParameters> LoadPreviewCommand => new RelayCommand<CreateRenderViewParameters>(_manager.CreateRenderView);

	public ICommand<DestroyRenderViewParameters> UnloadPreviewCommand => new RelayCommand<DestroyRenderViewParameters>(_manager.DestroyRenderView);

	public ICommand ToggleOutputCommand => new RelayCommand(OnToggleOutputCommand);

	public ICommand TriggerLogoCommand => new RelayCommand(_manager.TriggerLogo, () => _manager.Logo != null);

	public ICommand<IOutputScreenVM> SetScreenIDCommand => new RelayCommand<IOutputScreenVM>(OnSetScreenIDCommand);

	public ICaptureVM CaptureVM { get; }

	public IOutputPreviewVM PreviewVM { get; }

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public ScreenArrangementBase? InternalSelectedPreviewScreen
	{
		get
		{
			return _internalSelectedPreviewScreen;
		}
		set
		{
			if (!EqualityComparer<ScreenArrangementBase>.Default.Equals(_internalSelectedPreviewScreen, value))
			{
				ScreenArrangementBase internalSelectedPreviewScreen = _internalSelectedPreviewScreen;
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.InternalSelectedPreviewScreen);
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.SelectedPreviewScreen);
				_internalSelectedPreviewScreen = value;
				OnInternalSelectedPreviewScreenChanged(internalSelectedPreviewScreen, value);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.InternalSelectedPreviewScreen);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.SelectedPreviewScreen);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsMusicLayerActive
	{
		get
		{
			return _isMusicLayerActive;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isMusicLayerActive, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.IsMusicLayerActive);
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.IsClearAllAvailable);
				_isMusicLayerActive = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.IsMusicLayerActive);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.IsClearAllAvailable);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsMessageLayerActive
	{
		get
		{
			return _isMessageLayerActive;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isMessageLayerActive, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.IsMessageLayerActive);
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.IsClearAllAvailable);
				_isMessageLayerActive = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.IsMessageLayerActive);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.IsClearAllAvailable);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsPropsLayerActive
	{
		get
		{
			return _isPropsLayerActive;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isPropsLayerActive, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.IsPropsLayerActive);
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.IsClearAllAvailable);
				_isPropsLayerActive = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.IsPropsLayerActive);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.IsClearAllAvailable);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsAnnouncementForegroundActive
	{
		get
		{
			return _isAnnouncementForegroundActive;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isAnnouncementForegroundActive, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.IsAnnouncementForegroundActive);
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.IsClearAllAvailable);
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.IsAnnouncementLayerActive);
				_isAnnouncementForegroundActive = value;
				OnIsAnnouncementForegroundActiveChanged(value);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.IsAnnouncementForegroundActive);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.IsClearAllAvailable);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.IsAnnouncementLayerActive);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsAnnouncementBackgroundActive
	{
		get
		{
			return _isAnnouncementBackgroundActive;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isAnnouncementBackgroundActive, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.IsAnnouncementBackgroundActive);
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.IsClearAllAvailable);
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.IsAnnouncementLayerActive);
				_isAnnouncementBackgroundActive = value;
				OnIsAnnouncementBackgroundActiveChanged(value);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.IsAnnouncementBackgroundActive);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.IsClearAllAvailable);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.IsAnnouncementLayerActive);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsSlideLayerActive
	{
		get
		{
			return _isSlideLayerActive;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isSlideLayerActive, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.IsSlideLayerActive);
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.IsClearAllAvailable);
				_isSlideLayerActive = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.IsSlideLayerActive);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.IsClearAllAvailable);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsBackgroundLayerActive
	{
		get
		{
			return _isBackgroundLayerActive;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isBackgroundLayerActive, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.IsBackgroundLayerActive);
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.IsClearAllAvailable);
				_isBackgroundLayerActive = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.IsBackgroundLayerActive);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.IsClearAllAvailable);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsLiveVideoLayerActive
	{
		get
		{
			return _isLiveVideoLayerActive;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isLiveVideoLayerActive, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.IsLiveVideoLayerActive);
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.IsClearAllAvailable);
				_isLiveVideoLayerActive = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.IsLiveVideoLayerActive);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.IsClearAllAvailable);
			}
		}
	}

	public ScreenPreviewVM(ICoreManager manager, ICaptureVM recordingVM, IApp app, IOutputPreviewVMFactory previewVMFactory, IProPresenterResourceService resourceService, IOutputRepository ouptutRepository)
	{
		_manager = manager;
		_manager.LayerTriggered += UpdateActiveLayerStatus;
		CaptureVM = recordingVM;
		_app = app;
		_resourceService = resourceService;
		_outputRepository = ouptutRepository;
		PreviewVM = previewVMFactory.Create(RenderViewType.Preview);
		_outputRepository.AudienceScreenArrangementCollection.CollectionChanged += ScreenCollectionUpdated;
		_outputRepository.StageScreenArrangementCollection.CollectionChanged += ScreenCollectionUpdated;
		AddPropertyLinks();
		UpdateSelectedPreviewScreen();
		InitializePreviewScreen();
		_resourceService.ClearGroups.CollectionChanged += ClearGroups_CollectionChanged;
		_resourceService.ClearGroups.ForEach(delegate(ClearGroup c)
		{
			c.PropertyChanged += ClearGroup_PropertyChanged;
		});
	}

	private void ClearGroup_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "IsHiddenInPreview")
		{
			UpdateClearGroups();
		}
	}

	private void ClearGroups_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		e.OldItems?.OfType<ClearGroup>().ForEach(delegate(ClearGroup c)
		{
			c.PropertyChanged -= ClearGroup_PropertyChanged;
		});
		e.NewItems?.OfType<ClearGroup>().ForEach(delegate(ClearGroup c)
		{
			c.PropertyChanged += ClearGroup_PropertyChanged;
		});
		UpdateClearGroups();
	}

	private void UpdateClearGroups()
	{
		OnPropertyChanged("ClearGroups");
		PreviewAreaClearGroupChangedEvent.Publish(ClearGroups.Length);
	}

	private void InitializePreviewScreen()
	{
		if (SelectedPreviewScreen != null)
		{
			OnSetScreenIDCommand(SelectedPreviewScreen);
		}
	}

	private void ScreenCollectionUpdated(object? sender, NotifyCollectionChangedEventArgs e)
	{
		if (AvailableScreenPreviews.Any() && (SelectedPreviewScreen == null || !AvailableScreenPreviews.Any((ScreenArrangementBase s) => s == SelectedPreviewScreen)))
		{
			OnSetScreenIDCommand(AvailableScreenPreviews.First());
		}
		else
		{
			OnPropertyChanged("SelectedPreviewScreen");
		}
	}

	private void OnSetScreenIDCommand(IOutputScreenVM screenVM)
	{
		if (screenVM is IOutputScreenVMInternal { Screen: not null } outputScreenVMInternal)
		{
			OnSetScreenIDCommand(outputScreenVMInternal.Screen);
		}
	}

	private void OnSetScreenIDCommand(ScreenArrangementBase screen)
	{
		_manager.SetPreviewScreenID(screen.ID);
		_app.SelectedPreviewScreenID = screen.ID;
	}

	private void OnToggleOutputCommand()
	{
		if (_manager.AudienceEnable)
		{
			_manager.HideAudienceScreens();
		}
		else
		{
			_manager.ShowAudienceScreens();
		}
	}

	public void UpdateActiveLayerStatus(ProLayerIndex layer, ProResourceState state)
	{
		switch (layer)
		{
		case ProLayerIndex.UserLayerBegin:
			IsLiveVideoLayerActive = state == ProResourceState.Activated;
			SetLayerActivity(ClearType.LiveVideo, IsLiveVideoLayerActive);
			break;
		case ProLayerIndex.PresentationForeground:
			IsSlideLayerActive = state == ProResourceState.Activated;
			SetLayerActivity(ClearType.Slide, IsSlideLayerActive);
			break;
		case ProLayerIndex.PresentationBackground:
			IsBackgroundLayerActive = state == ProResourceState.Activated;
			SetLayerActivity(ClearType.Background, IsBackgroundLayerActive);
			break;
		case ProLayerIndex.AnnouncementsBackground:
			IsAnnouncementBackgroundActive = state == ProResourceState.Activated;
			break;
		case ProLayerIndex.AnnouncementsForeground:
			IsAnnouncementForegroundActive = state == ProResourceState.Activated;
			break;
		case ProLayerIndex.Props:
			IsPropsLayerActive = _manager.ActiveProps.Any();
			SetLayerActivity(ClearType.Props, IsPropsLayerActive);
			break;
		case ProLayerIndex.Messages:
			IsMessageLayerActive = _manager.ActiveMessages.Any();
			SetLayerActivity(ClearType.Messages, IsMessageLayerActive);
			break;
		case ProLayerIndex.Music:
			IsMusicLayerActive = state == ProResourceState.Activated;
			SetLayerActivity(ClearType.Audio, IsMusicLayerActive);
			break;
		}
	}

	private void SetLayerActivity(ClearType layer, bool isActive)
	{
		if (isActive)
		{
			if (!_activeLayers.Contains(layer))
			{
				_activeLayers.Add(layer);
			}
		}
		else if (_activeLayers.Contains(layer))
		{
			_activeLayers.Remove(layer);
		}
		OnPropertyChanged("ActiveLayers");
	}

	private void UpdateSelectedPreviewScreen()
	{
		InternalSelectedPreviewScreen = AvailableScreenPreviews.FirstOrDefault((ScreenArrangementBase p) => p.ID == _app.SelectedPreviewScreenID) ?? AvailableScreenPreviews.FirstOrDefault();
	}

	private void OnSelectedPreviewScreenPropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "AspectRatio")
		{
			UpdateAspectRatio();
		}
	}

	private void UpdateAspectRatio()
	{
		PreviewVM.AspectRatio = InternalSelectedPreviewScreen?.AspectRatio ?? 1.0;
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnInternalSelectedPreviewScreenChanged(ScreenArrangementBase? oldValue, ScreenArrangementBase? newValue)
	{
		if (oldValue != null)
		{
			oldValue.PropertyChanged -= OnSelectedPreviewScreenPropertyChanged;
		}
		if (newValue != null)
		{
			newValue.PropertyChanged += OnSelectedPreviewScreenPropertyChanged;
		}
		UpdateAspectRatio();
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnIsAnnouncementForegroundActiveChanged(bool value)
	{
		SetLayerActivity(ClearType.Announcement, IsAnnouncementLayerActive);
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnIsAnnouncementBackgroundActiveChanged(bool value)
	{
		SetLayerActivity(ClearType.Announcement, IsAnnouncementLayerActive);
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
		_resourceService.ClearGroups.ForEach(delegate(ClearGroup c)
		{
			c.PropertyChanged -= ClearGroup_PropertyChanged;
		});
		if (InternalSelectedPreviewScreen != null)
		{
			InternalSelectedPreviewScreen.PropertyChanged -= OnSelectedPreviewScreenPropertyChanged;
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void _manager_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		switch (e.PropertyName)
		{
		case "AudienceEnable":
			OnPropertyChanged("AudienceEnable");
			OnPropertyChanged("IsOutputOn");
			break;
		case "StageEnable":
			OnPropertyChanged("StageEnable");
			break;
		case "Logo":
			OnPropertyChanged("Logo");
			break;
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void _app_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "SelectedPreviewScreenID")
		{
			UpdateSelectedPreviewScreen();
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void AddPropertyLinks()
	{
		_manager.PropertyChanged += _manager_PropertyChanged;
		_app.PropertyChanged += _app_PropertyChanged;
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void RemovePropertyLinks()
	{
		_manager.PropertyChanged -= _manager_PropertyChanged;
		_app.PropertyChanged -= _app_PropertyChanged;
	}
}
