using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using Pro.DO.Storage;
using Pro.DO.Utility;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.TestPattern.State;

public class TestPatternState : ObservableObject, ITestPatternState, INotifyPropertyChanged
{
	[ObservableProperty]
	private ITestPatternDefinition? _pattern;

	[ObservableProperty]
	private bool _showPattern;

	[ObservableProperty]
	private DisplayLocation _displayLocation;

	[ObservableProperty]
	private Guid _specificScreen = Guid.Empty;

	[ObservableProperty]
	private bool _identifyScreens;

	[ObservableProperty]
	private LogoType _logoType;

	[ObservableProperty]
	private RelativePath _userLogoLocation = RelativePath.Empty();

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public ITestPatternDefinition? Pattern
	{
		get
		{
			return _pattern;
		}
		set
		{
			if (!EqualityComparer<ITestPatternDefinition>.Default.Equals(_pattern, value))
			{
				ITestPatternDefinition pattern = _pattern;
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.Pattern);
				_pattern = value;
				OnPatternChanged(pattern, value);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.Pattern);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool ShowPattern
	{
		get
		{
			return _showPattern;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_showPattern, value))
			{
				bool showPattern = _showPattern;
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.ShowPattern);
				_showPattern = value;
				OnShowPatternChanged(showPattern, value);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.ShowPattern);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public DisplayLocation DisplayLocation
	{
		get
		{
			return _displayLocation;
		}
		set
		{
			if (!EqualityComparer<DisplayLocation>.Default.Equals(_displayLocation, value))
			{
				DisplayLocation displayLocation = _displayLocation;
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.DisplayLocation);
				_displayLocation = value;
				OnDisplayLocationChanged(displayLocation, value);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.DisplayLocation);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public Guid SpecificScreen
	{
		get
		{
			return _specificScreen;
		}
		set
		{
			if (!EqualityComparer<Guid>.Default.Equals(_specificScreen, value))
			{
				Guid specificScreen = _specificScreen;
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.SpecificScreen);
				_specificScreen = value;
				OnSpecificScreenChanged(specificScreen, value);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.SpecificScreen);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IdentifyScreens
	{
		get
		{
			return _identifyScreens;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_identifyScreens, value))
			{
				bool identifyScreens = _identifyScreens;
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.IdentifyScreens);
				_identifyScreens = value;
				OnIdentifyScreensChanged(identifyScreens, value);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.IdentifyScreens);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public LogoType LogoType
	{
		get
		{
			return _logoType;
		}
		set
		{
			if (!EqualityComparer<LogoType>.Default.Equals(_logoType, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.LogoType);
				_logoType = value;
				OnLogoTypeChanged(value);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.LogoType);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public RelativePath UserLogoLocation
	{
		get
		{
			return _userLogoLocation;
		}
		[MemberNotNull("_userLogoLocation")]
		set
		{
			if (!EqualityComparer<RelativePath>.Default.Equals(_userLogoLocation, value))
			{
				RelativePath userLogoLocation = _userLogoLocation;
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.UserLogoLocation);
				_userLogoLocation = value;
				OnUserLogoLocationChanged(userLogoLocation, value);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.UserLogoLocation);
			}
		}
	}

	public event System.Action? LiveDataUpdated;

	public event System.Action? DataModified;

	public void Deserialize(Pro.SerializationInterop.RVProtoData.TestPatternState protoTestPatternState)
	{
		if (protoTestPatternState != null)
		{
			SpecificScreen = protoTestPatternState.SpecificScreen.ToGuid();
			IdentifyScreens = protoTestPatternState.IdentifyScreens;
			LogoType = protoTestPatternState.LogoType.ToLogoType();
			DisplayLocation = protoTestPatternState.DisplayLocation.ToDisplayLocation();
			UserLogoLocation = new RelativePath(protoTestPatternState.UserLogoLocation);
		}
	}

	public Pro.SerializationInterop.RVProtoData.TestPatternState Serialize()
	{
		return new Pro.SerializationInterop.RVProtoData.TestPatternState
		{
			ShowPattern = ShowPattern,
			SpecificScreen = SpecificScreen.ToUUID(),
			IdentifyScreens = IdentifyScreens,
			UserLogoLocation = UserLogoLocation?.Serialize(),
			LogoType = LogoType.ToProtoLogoType(),
			DisplayLocation = DisplayLocation.ToProtoDisplayLocation(),
			Pattern = Pattern?.Serialize()
		};
	}

	private void OnLiveDataUpdated()
	{
		this.LiveDataUpdated?.Invoke();
	}

	private void OnDataModified()
	{
		UpdateLiveData();
		this.DataModified?.Invoke();
	}

	private void UpdateLiveData()
	{
		if (ShowPattern)
		{
			OnLiveDataUpdated();
		}
	}

	public void Deserialize(TestPatternDocument.Types.TestPatternStateData protoTestPatternStateData)
	{
		SpecificScreen = protoTestPatternStateData.SpecificScreen.ToGuid();
		IdentifyScreens = protoTestPatternStateData.IdentifyScreens;
		LogoType = protoTestPatternStateData.LogoType.ToLogoType();
		DisplayLocation = protoTestPatternStateData.DisplayLocation.ToDisplayLocation();
		UserLogoLocation = new RelativePath(protoTestPatternStateData.UserLogoLocation);
	}

	public TestPatternDocument.Types.TestPatternStateData SerializeData()
	{
		return new TestPatternDocument.Types.TestPatternStateData
		{
			TestPatternId = (Pattern?.ID ?? Guid.Empty).ToUUID(),
			TestPatternNameLocalizationKey = (Pattern?.Name ?? string.Empty),
			SpecificScreen = SpecificScreen.ToUUID(),
			IdentifyScreens = IdentifyScreens,
			UserLogoLocation = UserLogoLocation?.Serialize(),
			LogoType = LogoType.ToProtoLogoType(),
			DisplayLocation = DisplayLocation.ToProtoDisplayLocation()
		};
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnPatternChanged(ITestPatternDefinition? oldValue, ITestPatternDefinition? newValue)
	{
		if (oldValue != null)
		{
			oldValue.DataModified -= OnDataModified;
		}
		if (newValue != null)
		{
			newValue.DataModified += OnDataModified;
		}
		OnDataModified();
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnShowPatternChanged(bool oldValue, bool newValue)
	{
		OnLiveDataUpdated();
		OnDataModified();
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnDisplayLocationChanged(DisplayLocation oldValue, DisplayLocation newValue)
	{
		OnDataModified();
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnSpecificScreenChanged(Guid oldValue, Guid newValue)
	{
		OnDataModified();
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnIdentifyScreensChanged(bool oldValue, bool newValue)
	{
		OnDataModified();
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnLogoTypeChanged(LogoType value)
	{
		OnDataModified();
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnUserLogoLocationChanged(RelativePath? oldValue, RelativePath newValue)
	{
		OnDataModified();
	}
}
