using System;
using System.CodeDom.Compiler;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using CommunityToolkit.Mvvm.Input;
using Pro.Common.Collections;
using Pro.Common.Dispatcher;
using Pro.Common.Mathematics;
using Pro.Common.Utility;
using Pro.DO.Utility;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.TestPattern.State;
using ProPresenterCore.ProCore.Interop;
using ProPresenterCore.ProCore.Interop.SendDataHandlers;

namespace ProPresenter.DO.TestPattern;

public class TestPatternService : ObservableObject, ITestPatternService, INotifyPropertyChanged, ISendDataResponseHandler
{
	private const int TESTPATTERN_THUMBNAIL_WIDTH = 120;

	private const int TESTPATTERN_THUMBNAIL_HEIGHT = 67;

	private readonly IProCoreInstance _proCore;

	private readonly ITestPatternDefinitionFactory _definitionFactory;

	private readonly ITestPatternStateFactory _stateFactory;

	private readonly IUiDispatcher _uiDispatcher;

	private readonly ITestPatternPersistence _testPatternPersistence;

	private readonly IDebouncerFactory _debouncerFactory;

	private readonly ConcurrentDictionary<Guid, TaskCompletionSource<bool>> _getThumbnailRequests = new ConcurrentDictionary<Guid, TaskCompletionSource<bool>>();

	private TaskCompletionSource<bool>? _getCurrentStateCompletionSource;

	private TaskCompletionSource<bool>? _loadDefinitionsCompletionSource;

	private readonly IDebouncer<ITestPatternState?> _stateDebouncer;

	private IEnumerable<Pro.SerializationInterop.RVProtoData.TestPatternDefinition>? _defaultTestPatterns;

	[ObservableProperty]
	private IEnumerable<ITestPatternDefinition> _testPatterns = Array.Empty<ITestPatternDefinition>();

	[ObservableProperty]
	private ITestPatternState? _currentState;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? showPatternCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? hidePatternCommand;

	public ITestPatternDefinition? SelectedPattern
	{
		get
		{
			return CurrentState?.Pattern;
		}
		set
		{
			if (CurrentState != null)
			{
				CurrentState.Pattern = value;
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IEnumerable<ITestPatternDefinition> TestPatterns
	{
		get
		{
			return _testPatterns;
		}
		[MemberNotNull("_testPatterns")]
		set
		{
			if (!EqualityComparer<IEnumerable<ITestPatternDefinition>>.Default.Equals(_testPatterns, value))
			{
				IEnumerable<ITestPatternDefinition> testPatterns = _testPatterns;
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.TestPatterns);
				_testPatterns = value;
				OnTestPatternsChanged(testPatterns, value);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.TestPatterns);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public ITestPatternState? CurrentState
	{
		get
		{
			return _currentState;
		}
		set
		{
			if (!EqualityComparer<ITestPatternState>.Default.Equals(_currentState, value))
			{
				ITestPatternState currentState = _currentState;
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.CurrentState);
				_currentState = value;
				OnCurrentStateChanged(currentState, value);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.CurrentState);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand ShowPatternCommand => showPatternCommand ?? (showPatternCommand = new RelayCommand(ShowPattern, CanShowPattern));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand HidePatternCommand => hidePatternCommand ?? (hidePatternCommand = new RelayCommand(HidePattern, CanHidePattern));

	public TestPatternService(IProCoreInstance proCore, ITestPatternDefinitionFactory definitionFactory, ITestPatternStateFactory stateFactory, IUiDispatcher uiDispatcher, ITestPatternPersistence testPatternPersistence, IDebouncerFactory debouncerFactory)
	{
		_proCore = proCore;
		_definitionFactory = definitionFactory;
		_stateFactory = stateFactory;
		_uiDispatcher = uiDispatcher;
		_testPatternPersistence = testPatternPersistence;
		_debouncerFactory = debouncerFactory;
		_currentState = stateFactory.Create(null);
		_stateDebouncer = _debouncerFactory.Create<ITestPatternState>(OnSetCurrentState);
	}

	[RelayCommand(CanExecute = "CanShowPattern")]
	private void ShowPattern()
	{
		CurrentState.Pattern = SelectedPattern;
		if (!CurrentState.ShowPattern)
		{
			CurrentState.ShowPattern = true;
		}
		else
		{
			SetCurrentState();
		}
	}

	private bool CanShowPattern()
	{
		ITestPatternState? currentState = CurrentState;
		if (currentState == null)
		{
			return false;
		}
		return !currentState.ShowPattern;
	}

	[RelayCommand(CanExecute = "CanHidePattern")]
	private void HidePattern()
	{
		CurrentState.ShowPattern = false;
	}

	private bool CanHidePattern()
	{
		return CurrentState?.ShowPattern ?? false;
	}

	private void NotifyCanExecute()
	{
		ShowPatternCommand.NotifyCanExecuteChanged();
		HidePatternCommand.NotifyCanExecuteChanged();
	}

	public void RenderPreview(nint texture, Vector2<int> textureSize)
	{
		if (CurrentState != null)
		{
			_proCore.RenderTestPatternPreview(CurrentState.Serialize(), texture, textureSize.X, textureSize.Y);
		}
	}

	public async Task LoadDefinitionsAsync()
	{
		SendData sendData = new SendData
		{
			TestPattern = new TestPatternRequest
			{
				GetDefinitions = new TestPatternRequest.Types.GetDefinitions()
			}
		};
		if (_loadDefinitionsCompletionSource?.TrySetResult(result: false) ?? false)
		{
			_loadDefinitionsCompletionSource = null;
		}
		_loadDefinitionsCompletionSource = new TaskCompletionSource<bool>();
		await SendData(sendData, _loadDefinitionsCompletionSource);
	}

	public async Task LoadThumbnailsAsync()
	{
		if (_getThumbnailRequests.Any())
		{
			_getThumbnailRequests.Where<KeyValuePair<Guid, TaskCompletionSource<bool>>>((KeyValuePair<Guid, TaskCompletionSource<bool>> t) => !t.Value.Task.IsCompleted).ForEach(delegate(KeyValuePair<Guid, TaskCompletionSource<bool>> t)
			{
				t.Value.TrySetResult(result: false);
			});
			_getThumbnailRequests.Clear();
		}
		foreach (Pro.SerializationInterop.RVProtoData.TestPatternDefinition item in _defaultTestPatterns ?? Array.Empty<Pro.SerializationInterop.RVProtoData.TestPatternDefinition>())
		{
			SendData sendData = new SendData();
			TaskCompletionSource<bool> taskCompletionSource = new TaskCompletionSource<bool>();
			sendData.TestPattern = new TestPatternRequest
			{
				GetThumbnail = new TestPatternRequest.Types.GetThumbnail
				{
					Pattern = item,
					Height = 67,
					Width = 120
				}
			};
			_getThumbnailRequests.TryAdd(item.Uuid.ToGuid(), taskCompletionSource);
			if (_proCore.SendData(sendData, out var _) != 0)
			{
				taskCompletionSource.TrySetResult(result: false);
			}
		}
		await Task.WhenAll(_getThumbnailRequests.Select<KeyValuePair<Guid, TaskCompletionSource<bool>>, Task<bool>>((KeyValuePair<Guid, TaskCompletionSource<bool>> t) => t.Value.Task));
	}

	public async Task GetCurrentStateAsync()
	{
		if (_getCurrentStateCompletionSource?.TrySetResult(result: false) ?? false)
		{
			_getCurrentStateCompletionSource = null;
		}
		SendData sendData = new SendData
		{
			TestPattern = new TestPatternRequest
			{
				GetCurrentState = new TestPatternRequest.Types.GetCurrentState()
			}
		};
		_getCurrentStateCompletionSource = new TaskCompletionSource<bool>();
		await SendData(sendData, _getCurrentStateCompletionSource);
	}

	public void SetCurrentState()
	{
		_stateDebouncer.Invoke(CurrentState);
	}

	private void OnSetCurrentState(ITestPatternState? state)
	{
		SendData data = new SendData
		{
			TestPattern = new TestPatternRequest
			{
				SetCurrentState = state?.Serialize()
			}
		};
		_proCore.SendData(data, out var _);
	}

	private async Task SendData(SendData sendData, TaskCompletionSource<bool> completionSource)
	{
		if (_proCore.SendData(sendData, out var _) == ProResult.Success)
		{
			await completionSource.Task;
		}
		else
		{
			completionSource.TrySetResult(result: false);
		}
	}

	private void TestPattern_DataModified()
	{
		_testPatternPersistence.Save(CurrentState, TestPatterns);
	}

	private void TestPatternState_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		string propertyName = e.PropertyName;
		if (!(propertyName == "ShowPattern"))
		{
			if (propertyName == "Pattern")
			{
				OnPropertyChanged("SelectedPattern");
			}
		}
		else
		{
			NotifyCanExecute();
		}
	}

	public bool CanHandle(SendDataResponse.MessageTypeOneofCase sendDataResponseType)
	{
		return sendDataResponseType == SendDataResponse.MessageTypeOneofCase.TestPattern;
	}

	public async Task Handle(SendDataResponse sendDataResponse)
	{
		if (sendDataResponse == null)
		{
			return;
		}
		TestPatternResponse response = sendDataResponse.TestPattern;
		switch (response.ResponseCase)
		{
		case TestPatternResponse.ResponseOneofCase.GetDefinitions:
			await _uiDispatcher.InvokeAsync(delegate
			{
				_defaultTestPatterns = response.GetDefinitions.Patterns;
				ITestPatternDefinition[] testPatterns = response.GetDefinitions.Patterns.Select(_definitionFactory.Create).ToArray();
				_testPatternPersistence.LoadTestPatterns(testPatterns);
				TestPatterns = testPatterns;
				if (CurrentState != null && CurrentState.Pattern == null)
				{
					CurrentState.Pattern = TestPatterns.FirstOrDefault();
				}
			});
			_loadDefinitionsCompletionSource?.TrySetResult(result: true);
			break;
		case TestPatternResponse.ResponseOneofCase.GetCurrentState:
		{
			ITestPatternState state = _stateFactory.Create(response.GetCurrentState);
			_testPatternPersistence.LoadState(state, TestPatterns);
			if (state.Pattern == null)
			{
				ITestPatternDefinition pattern2 = ((response.GetCurrentState.Pattern == null) ? TestPatterns?.FirstOrDefault() : TestPatterns?.FirstOrDefaultBy((ITestPatternDefinition p) => p.ID == response.GetCurrentState.Pattern.Uuid.ToGuid(), (ITestPatternDefinition p) => p.Name == response.GetCurrentState.Pattern.NameLocalizationKey));
				state.Pattern = pattern2;
			}
			await _uiDispatcher.InvokeAsync(delegate
			{
				CurrentState = state;
			});
			_getCurrentStateCompletionSource?.TrySetResult(result: true);
			break;
		}
		case TestPatternResponse.ResponseOneofCase.GetThumbnail:
		{
			Guid patternId = response.GetThumbnail.Pattern.ToGuid();
			if (!_getThumbnailRequests.TryGetValue(patternId, out TaskCompletionSource<bool> thumbnailCompletionSource))
			{
				break;
			}
			ITestPatternDefinition pattern = TestPatterns?.FirstOrDefault((ITestPatternDefinition p) => p.ID == patternId);
			if (pattern != null)
			{
				await _uiDispatcher.InvokeAsync(delegate
				{
					pattern.Thumbnail = response.GetThumbnail.Image.ToByteArray().ToBitmapSource();
				});
			}
			thumbnailCompletionSource.TrySetResult(result: true);
			break;
		}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnTestPatternsChanged(IEnumerable<ITestPatternDefinition>? oldValue, IEnumerable<ITestPatternDefinition> newValue)
	{
		if (oldValue != null && oldValue.NonNull().Any())
		{
			foreach (ITestPatternDefinition item in oldValue)
			{
				item.DataModified -= TestPattern_DataModified;
			}
		}
		if (newValue != null && newValue.NonNull().Any())
		{
			foreach (ITestPatternDefinition item2 in newValue)
			{
				item2.DataModified += TestPattern_DataModified;
			}
		}
		TestPattern_DataModified();
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnCurrentStateChanged(ITestPatternState? oldValue, ITestPatternState? newValue)
	{
		if (oldValue != null)
		{
			oldValue.LiveDataUpdated -= SetCurrentState;
			oldValue.PropertyChanged -= TestPatternState_PropertyChanged;
			oldValue.DataModified -= TestPattern_DataModified;
		}
		if (newValue != null)
		{
			newValue.LiveDataUpdated += SetCurrentState;
			newValue.PropertyChanged += TestPatternState_PropertyChanged;
			newValue.DataModified += TestPattern_DataModified;
			if (newValue.ShowPattern)
			{
				SetCurrentState();
			}
		}
		NotifyCanExecute();
		OnPropertyChanged("SelectedPattern");
		TestPattern_DataModified();
	}
}
