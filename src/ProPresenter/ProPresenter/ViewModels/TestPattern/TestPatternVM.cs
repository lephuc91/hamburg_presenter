using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using CommunityToolkit.Mvvm.Input;
using Pro.Common.Background;
using Pro.Common.Collections;
using Pro.UI.Controls;
using ProPresenter.DO.TestPattern;
using ProPresenter.UI.ViewModels.TestPattern;

namespace ProPresenter.ViewModels.TestPattern;

public class TestPatternVM : ObservableObject, ITestPatternVM, INotifyPropertyChanged
{
	private readonly ITestPatternService _testPatternService;

	private readonly ITestPatternVMFactory _vmFactory;

	private bool _ignorePatternChanged;

	[ObservableProperty]
	private IEnumerable<ITestPatternItemVM> _testPatterns;

	[ObservableProperty]
	private ITestPatternItemVM? _selectedPattern;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand<RequestRenderParameter>? requestRenderCommand;

	public ITestPatternStateVM CurrentState { get; }

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IEnumerable<ITestPatternItemVM> TestPatterns
	{
		get
		{
			return _testPatterns;
		}
		[MemberNotNull("_testPatterns")]
		set
		{
			if (!EqualityComparer<IEnumerable<ITestPatternItemVM>>.Default.Equals(_testPatterns, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.TestPatterns);
				_testPatterns = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.TestPatterns);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public ITestPatternItemVM? SelectedPattern
	{
		get
		{
			return _selectedPattern;
		}
		set
		{
			if (!EqualityComparer<ITestPatternItemVM>.Default.Equals(_selectedPattern, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.SelectedPattern);
				_selectedPattern = value;
				OnSelectedPatternChanged(value);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.SelectedPattern);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand<RequestRenderParameter> RequestRenderCommand => requestRenderCommand ?? (requestRenderCommand = new RelayCommand<RequestRenderParameter>(RequestRender));

	public TestPatternVM(ITestPatternService testPatternService, ITestPatternVMFactory vmFactory)
	{
		_testPatternService = testPatternService;
		_vmFactory = vmFactory;
		_testPatterns = _testPatternService.TestPatterns?.Select((ITestPatternDefinition p) => _vmFactory.Create(p)).NotNull().ToArray() ?? Enumerable.Empty<ITestPatternItemVM>();
		_selectedPattern = _testPatterns.FirstOrDefault((ITestPatternItemVM t) => t is ITestPatternItemVMInternal testPatternItemVMInternal && testPatternItemVMInternal.Pattern == _testPatternService.SelectedPattern);
		CurrentState = vmFactory.Create();
		SetStateVMState();
		_testPatternService.PropertyChanged += TestPatternService_PropertyChanged;
	}

	[RelayCommand]
	private void RequestRender(RequestRenderParameter parameter)
	{
		_testPatternService.RenderPreview(parameter.Texture, parameter.TextureSize);
	}

	private void TestPatternService_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		switch (e.PropertyName)
		{
		case "TestPatterns":
			ConvertTestPatternsToVM();
			break;
		case "SelectedPattern":
			UpdateSelectedPattern();
			break;
		case "CurrentState":
			SetStateVMState();
			break;
		}
	}

	[MemberNotNull("TestPatterns")]
	private void ConvertTestPatternsToVM()
	{
		IEnumerable<ITestPatternItemVM> enumerable = _testPatternService.TestPatterns?.Select((ITestPatternDefinition p) => _vmFactory.Create(p)).NotNull().ToArray();
		TestPatterns = enumerable ?? Enumerable.Empty<ITestPatternItemVM>();
	}

	private void UpdateSelectedPattern()
	{
		if (!_ignorePatternChanged)
		{
			SelectedPattern = TestPatterns?.FirstOrDefault((ITestPatternItemVM t) => t is ITestPatternItemVMInternal testPatternItemVMInternal && testPatternItemVMInternal.Pattern == _testPatternService.SelectedPattern);
		}
	}

	private void SetStateVMState()
	{
		CurrentState?.SetState(_testPatternService.CurrentState);
	}

	public void LoadPatterns()
	{
		InitializeTestPatterns().ExecuteAsync();
	}

	private async Task InitializeTestPatterns()
	{
		await _testPatternService.LoadDefinitionsAsync();
		await _testPatternService.LoadThumbnailsAsync();
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnSelectedPatternChanged(ITestPatternItemVM? value)
	{
		_ignorePatternChanged = true;
		_testPatternService.SelectedPattern = ((value is ITestPatternItemVMInternal testPatternItemVMInternal) ? testPatternItemVMInternal.Pattern : null);
		_ignorePatternChanged = false;
	}
}
