using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reactive.Disposables;
using System.Windows;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using Pro.Common.Collections;
using Pro.Common.Nullability;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Common.Utility;
using Pro.UI.Components;
using Pro.UI.Utility;
using ProPresenter.Controller;
using ProPresenter.Controller.Outputs;
using ProPresenter.DO.Analytics;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Looks;
using ProPresenter.DO.Masks;
using ProPresenter.DO.OutputConfiguration;
using ProPresenter.DO.Themes;
using ProPresenter.UI;
using ProPresenter.UI.Commands;
using ProPresenter.UI.Looks;
using ProPresenter.UI.ViewModels.LooksDialog;

namespace ProPresenter.ViewModels.LooksDialog;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { })]
public class LooksDialogVM : ObservableObject, ILooksDialogVM, INotifyPropertyChanged, IDisposable
{
	[Pro.Common.SourceGenerator.Attributes.PropertyLink("IdentifyLook", "EnableIdentify")]
	private readonly ssAPIOutput _outputController;

	private readonly ITriggering _service;

	private readonly IOutputConfiguration _outputConfiguration;

	private readonly CompositeDisposable _disposables = new CompositeDisposable();

	private readonly PairedCollection<AudienceLook, AudienceLookVM> _audienceLooks;

	[ObservableProperty]
	private AudienceLookVM? _activeLook;

	[ObservableProperty]
	private IReadOnlyList<LiveAudienceLookVM> _liveLooks;

	private LiveAudienceLookVM? _selectedLiveLook;

	private AudienceLookVM? _selectedLook;

	private LiveAudienceLook _backingLiveAudienceLook;

	[ObservableProperty]
	private LiveAudienceLookVM _liveAudienceLook;

	[ObservableProperty]
	private bool _renameNextItem;

	private readonly Lazy<AudienceLookWindow> _audienceLookWindow;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public IThemeCollection Themes { get; }

	public IMaskCollection Masks { get; }

	public Theme DefaultTheme => Themes.DefaultTheme;

	public ImmutableObservableCollection<AudienceLookVM> AudienceLooks => _audienceLooks;

	public LiveAudienceLookVM? SelectedLiveLook
	{
		get
		{
			return _selectedLiveLook;
		}
		set
		{
			if (SetProperty(ref _selectedLiveLook, value, "SelectedLiveLook") && value != null)
			{
				SelectedLook = null;
				SelectedLooks.Clear();
				ActiveLook = value.AudienceLook;
			}
		}
	}

	public AudienceLookVM? SelectedLook
	{
		get
		{
			return _selectedLook;
		}
		set
		{
			if (SetProperty(ref _selectedLook, value, "SelectedLook") && value != null)
			{
				SelectedLiveLook = null;
				ActiveLook = value;
			}
		}
	}

	public ObservableCollection<AudienceLookVM> SelectedLooks { get; } = new ObservableCollection<AudienceLookVM>();

	public bool EnableIdentify
	{
		get
		{
			return _outputController.IdentifyLook;
		}
		set
		{
			_outputController.IdentifyLook = value;
		}
	}

	public ICommand EditLooksCommand => new RelayCommand(OnEditLooksCommand);

	public ICommand MakeLiveCommand => new RelayCommand(delegate
	{
		OnMakeLiveCommand(SelectedLook);
	}, () => SelectedLook != null && !LiveAudienceLook.IsLive(SelectedLook));

	public ICommand AddLookCommand => new RelayCommand(OnAddLookCommand);

	public ICommand RemoveLookCommand => new RelayCommand(OnRemoveLookCommand, () => SelectedLook != null);

	public ICommand CutLookCommand => new RelayCommand(OnCutCommand, () => SelectedLooks.Any());

	public ICommand CopyLookCommand => new RelayCommand(OnCopyCommand, () => SelectedLooks.Any());

	public ICommand PasteLookCommand => new RelayCommand(OnPasteCommand, () => ClipboardManagerHelper.CanPasteIntoCollection<AudienceLook>());

	public ICommand DuplicateLookCommand => new RelayCommand(OnDuplicateLookCommand, () => SelectedLook != null);

	public ICommand SaveCommand => new RelayCommand(OnSaveCommand);

	public ICommand ResetToDefaultCommand => new RelayCommand(OnResetToDefaultCommand);

	public ICommand SaveAsCommand => new RelayCommand(OnSaveAsCommand);

	public ICommand<ShowSource> EditMasksCommand => new RelayCommand<ShowSource>(delegate(ShowSource s)
	{
		OnEditMaskCommand(s, addNewMask: false);
	});

	public ICommand AddNewMaskCommand => new RelayCommand(delegate
	{
		OnEditMaskCommand(ShowSource.LooksWindow, addNewMask: true);
	});

	public ICommand<AudienceLookVM> MakeSelectedLookLiveCommand => new RelayCommand<AudienceLookVM>(OnMakeLiveCommand, (AudienceLookVM l) => l != null && !LiveAudienceLook.IsLive(l));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public AudienceLookVM? ActiveLook
	{
		get
		{
			return _activeLook;
		}
		set
		{
			if (!EqualityComparer<AudienceLookVM>.Default.Equals(_activeLook, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.ActiveLook);
				_activeLook = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.ActiveLook);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IReadOnlyList<LiveAudienceLookVM> LiveLooks
	{
		get
		{
			return _liveLooks;
		}
		[MemberNotNull("_liveLooks")]
		set
		{
			if (!EqualityComparer<IReadOnlyList<LiveAudienceLookVM>>.Default.Equals(_liveLooks, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.LiveLooks);
				_liveLooks = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.LiveLooks);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public LiveAudienceLookVM LiveAudienceLook
	{
		get
		{
			return _liveAudienceLook;
		}
		[MemberNotNull("_liveAudienceLook")]
		set
		{
			if (!EqualityComparer<LiveAudienceLookVM>.Default.Equals(_liveAudienceLook, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.LiveAudienceLook);
				_liveAudienceLook = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.LiveAudienceLook);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool RenameNextItem
	{
		get
		{
			return _renameNextItem;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_renameNextItem, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.RenameNextItem);
				_renameNextItem = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.RenameNextItem);
			}
		}
	}

	public event Action<bool>? EditMasks;

	public LooksDialogVM(ssAPIOutput outputController, ITriggeringFactory triggeringFactory, IOutputService outputService, IThemeCollection themes, IMaskCollection masks, AudienceScreenArrangementCollection audienceScreens)
	{
		LooksDialogVM looksDialogVM = this;
		_outputController = outputController;
		_service = triggeringFactory.Create();
		_outputConfiguration = outputService.OutputConfiguration;
		Themes = themes;
		Masks = masks;
		_audienceLooks = new PairedCollection<AudienceLook, AudienceLookVM>(_outputConfiguration.AudienceLooks, (AudienceLook s) => new AudienceLookVM(looksDialogVM.Themes, looksDialogVM.Masks, audienceScreens, s), delegate(AudienceLookVM t)
		{
			t.Dispose();
		});
		_backingLiveAudienceLook = _outputConfiguration.LiveLook;
		_liveLooks = new global::_003C_003Ez__ReadOnlySingleElementList<LiveAudienceLookVM>(new LiveAudienceLookVM(Themes, Masks, audienceScreens, _backingLiveAudienceLook));
		_liveAudienceLook = _liveLooks[0];
		_audienceLookWindow = new Lazy<AudienceLookWindow>(delegate
		{
			//IL_0030: Unknown result type (might be due to invalid IL or missing references)
			//IL_003a: Expected O, but got Unknown
			AudienceLookWindow audienceLookWindow = new AudienceLookWindow().WithDataContext(looksDialogVM);
			audienceLookWindow.IsVisibleChanged += (DependencyPropertyChangedEventHandler)delegate
			{
				if (!audienceLookWindow.IsVisible)
				{
					looksDialogVM.EnableIdentify = false;
				}
			};
			return audienceLookWindow;
		});
		SelectedLiveLook = _liveAudienceLook;
		Masks.CollectionChanged += delegate(object? s, NotifyCollectionChangedEventArgs e)
		{
			IEnumerable<ScreenLookVM> screenLooks = looksDialogVM.AudienceLooks.Union(looksDialogVM.LiveAudienceLook.AudienceLook.ToEnumerable()).SelectMany((AudienceLookVM l) => l.ScreenLooks);
			e.OldItems?.Cast<SlideCue>().ForEach(delegate(SlideCue m)
			{
				screenLooks.Where((ScreenLookVM l) => l.Mask?.ID == m.ID).ForEach(delegate(ScreenLookVM l)
				{
					l.Mask = null;
				});
			});
		};
		AddPropertyLinks();
		_outputConfiguration.WhenPropertyChanges("LiveLook").Subscribe(delegate
		{
			LiveAudienceLookVM liveAudienceLook = looksDialogVM.LiveAudienceLook;
			looksDialogVM.LiveAudienceLook?.Dispose();
			looksDialogVM._backingLiveAudienceLook = looksDialogVM._outputConfiguration.LiveLook;
			looksDialogVM.LiveLooks = new global::_003C_003Ez__ReadOnlySingleElementList<LiveAudienceLookVM>(new LiveAudienceLookVM(themes, masks, audienceScreens, looksDialogVM._backingLiveAudienceLook));
			looksDialogVM.LiveAudienceLook = looksDialogVM.LiveLooks[0];
			if (looksDialogVM.SelectedLiveLook == liveAudienceLook)
			{
				looksDialogVM.SelectedLiveLook = looksDialogVM.LiveAudienceLook;
			}
		}).DisposeWith(_disposables);
		_liveAudienceLook.DisposeWith(_disposables);
	}

	private void OnEditLooksCommand()
	{
		if (_audienceLookWindow.Value.IsActive)
		{
			_audienceLookWindow.Value.Visibility = Visibility.Hidden;
		}
		else if (_audienceLookWindow.Value.Visibility == Visibility.Visible)
		{
			_audienceLookWindow.Value.Activate();
		}
		else
		{
			_audienceLookWindow.Value.Visibility = Visibility.Visible;
		}
	}

	private void OnMakeLiveCommand(AudienceLookVM? look)
	{
		look.ThrowWhenNull("look");
		look.Trigger(_service);
	}

	private void OnAddLookCommand()
	{
		RenameNextItem = true;
		AudienceLook sourceItem = _outputConfiguration.AudienceLooks.Add();
		SelectLook(_audienceLooks.GetTargetForSource(sourceItem));
	}

	private void OnRemoveLookCommand()
	{
		AudienceLookVM[] source = SelectedLooks.OrderBy(AudienceLooks.IndexOf).ToArray();
		AudienceLookVM target = source.FirstOrDefault();
		AudienceLookVM target2 = source.LastOrDefault();
		AudienceLookVM look = AudienceLooks.GetPrevious(target) ?? AudienceLooks.GetNext(target2);
		SelectedLooks.ForEach(delegate(AudienceLookVM x)
		{
			_outputConfiguration.AudienceLooks.Remove(_audienceLooks.GetSourceForTarget(x));
		});
		SelectLook(look);
	}

	private void OnCutCommand()
	{
		ClipboardManagerHelper.CutFromCollection(_outputConfiguration.AudienceLooks, SelectedLooks.Select((AudienceLookVM t) => _audienceLooks.GetSourceForTarget(t)));
	}

	private void OnCopyCommand()
	{
		ClipboardManagerHelper.CopyFromCollection(SelectedLooks.Select((AudienceLookVM t) => _audienceLooks.GetSourceForTarget(t)));
	}

	private void OnPasteCommand()
	{
		if (SelectedLooks.Count > 0)
		{
			ClipboardManagerHelper.PasteIntoCollection<IAudienceLookCollection, AudienceLook>(_outputConfiguration.AudienceLooks, AudienceLooks.IndexOf(SelectedLooks.OrderBy(AudienceLooks.IndexOf).Last()) + 1);
		}
		else
		{
			ClipboardManagerHelper.PasteIntoCollection<IAudienceLookCollection, AudienceLook>(_outputConfiguration.AudienceLooks, AudienceLooks.Count + 1);
		}
	}

	private void OnDuplicateLookCommand()
	{
		OnCopyCommand();
		OnPasteCommand();
	}

	private void OnSaveCommand()
	{
		_backingLiveAudienceLook.Save();
	}

	private void OnResetToDefaultCommand()
	{
		_backingLiveAudienceLook.Reset();
	}

	private void OnSaveAsCommand()
	{
		RenameNextItem = true;
		AudienceLook audienceLook = _backingLiveAudienceLook.Live.Clone();
		_outputConfiguration.AudienceLooks.Add(audienceLook);
		SelectLook(_audienceLooks.GetTargetForSource(audienceLook));
	}

	private void OnEditMaskCommand(ShowSource source, bool addNewMask)
	{
		this.EditMasks?.Invoke(addNewMask);
		switch (source)
		{
		case ShowSource.Toolbar:
			MainViewMaskEditorEvent.Publish(MainViewSource.Toolbar);
			break;
		case ShowSource.LooksWindow:
			MainViewMaskEditorEvent.Publish(MainViewSource.LooksWindow);
			break;
		}
	}

	private void SelectLook(AudienceLookVM? look)
	{
		SelectedLooks.Clear();
		SelectedLook = look;
		if (look != null)
		{
			SelectedLooks.Add(look);
		}
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
		_disposables.Dispose();
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void _outputController_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "IdentifyLook")
		{
			OnPropertyChanged("EnableIdentify");
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void AddPropertyLinks()
	{
		_outputController.PropertyChanged += _outputController_PropertyChanged;
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void RemovePropertyLinks()
	{
		_outputController.PropertyChanged -= _outputController_PropertyChanged;
	}
}
