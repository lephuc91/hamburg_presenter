using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using Pro.Common.Components;
using Pro.Common.Mathematics;
using Pro.Localization;

namespace ProPresenter.DO.OutputConfiguration;

public class HardwareScreenRectangleOptions : ObservableObject, ICloneable<HardwareScreenRectangleOptions>, IOutputSizeProvider, INotifyPropertyChanged
{
	private static readonly Vector2<double> UnconfiguredOutputSize = new Vector2<double>(1920.0, 1080.0);

	private bool _subrectUpdateInProgress;

	[ObservableProperty]
	private Rect<double> _subrect = Rect<double>.Empty;

	[ObservableProperty]
	[NotifyPropertyChangedFor("OutputName")]
	[NotifyPropertyChangedFor("IsConfigured")]
	[NotifyPropertyChangedFor("OutputSize")]
	private IDevice? _outputDevice;

	[ObservableProperty]
	private SubrectTargetMode _subrectTargetMode;

	[ObservableProperty]
	private int _subrectTargetIndex;

	[ObservableProperty]
	private bool _isConflicting;

	public string OutputName
	{
		get
		{
			IDevice? outputDevice = OutputDevice;
			if (outputDevice == null || !outputDevice.IsAttached)
			{
				return LocalizedStrings.Get("SCREEN_CONFIGURATION_HARDWARE_TAB_DEVICE_MENU_UNCONFIGURED_title");
			}
			return OutputDevice.Name;
		}
	}

	public Vector2<double> OutputSize
	{
		get
		{
			IDevice? outputDevice = OutputDevice;
			if (outputDevice == null || !outputDevice.IsAttached)
			{
				return UnconfiguredOutputSize;
			}
			return OutputDevice.DeviceMode.Size.Cast<double>();
		}
	}

	public bool IsConfigured
	{
		get
		{
			if (OutputDevice != null)
			{
				return OutputDevice.IsAttached;
			}
			return false;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public Rect<double> Subrect
	{
		get
		{
			return _subrect;
		}
		set
		{
			if (!EqualityComparer<Rect<double>>.Default.Equals(_subrect, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.Subrect);
				_subrect = value;
				OnSubrectChanged(value);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.Subrect);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IDevice? OutputDevice
	{
		get
		{
			return _outputDevice;
		}
		set
		{
			if (!EqualityComparer<IDevice>.Default.Equals(_outputDevice, value))
			{
				IDevice outputDevice = _outputDevice;
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.OutputDevice);
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.OutputName);
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.IsConfigured);
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.OutputSize);
				_outputDevice = value;
				OnOutputDeviceChanged(outputDevice, value);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.OutputDevice);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.OutputName);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.IsConfigured);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.OutputSize);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public SubrectTargetMode SubrectTargetMode
	{
		get
		{
			return _subrectTargetMode;
		}
		set
		{
			if (!EqualityComparer<SubrectTargetMode>.Default.Equals(_subrectTargetMode, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.SubrectTargetMode);
				_subrectTargetMode = value;
				OnSubrectTargetModeChanged(value);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.SubrectTargetMode);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public int SubrectTargetIndex
	{
		get
		{
			return _subrectTargetIndex;
		}
		set
		{
			if (!EqualityComparer<int>.Default.Equals(_subrectTargetIndex, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.SubrectTargetIndex);
				_subrectTargetIndex = value;
				OnSubrectTargetIndexChanged(value);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.SubrectTargetIndex);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsConflicting
	{
		get
		{
			return _isConflicting;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isConflicting, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.IsConflicting);
				_isConflicting = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.IsConflicting);
			}
		}
	}

	public event Action? OutputDataChanged;

	public event Action<IDevice?, IDevice?>? OutputDeviceChanged;

	public HardwareScreenRectangleOptions()
	{
		UpdateSubrect();
	}

	public HardwareScreenRectangleOptions Clone()
	{
		return new HardwareScreenRectangleOptions
		{
			Subrect = Subrect,
			OutputDevice = OutputDevice,
			SubrectTargetMode = SubrectTargetMode,
			SubrectTargetIndex = SubrectTargetIndex
		};
	}

	private void OutputDevice_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		switch (e.PropertyName)
		{
		case "Name":
			OnPropertyChanged("OutputName");
			break;
		case "IsAttached":
			OnPropertyChanged("OutputName");
			OnPropertyChanged("OutputSize");
			OnPropertyChanged("IsConfigured");
			break;
		case "DeviceMode":
		case "Bounds":
			UpdateSubrect();
			OnPropertyChanged("OutputSize");
			break;
		}
	}

	private void NotifyOutputDataChanged()
	{
		this.OutputDataChanged?.Invoke();
	}

	private void NotifyOutputDeviceChanged(IDevice? oldDevice, IDevice? newDevice)
	{
		this.OutputDeviceChanged?.Invoke(oldDevice, newDevice);
	}

	private void UpdateSubrect()
	{
		if (!_subrectUpdateInProgress && SubrectTargetMode != SubrectTargetMode.Custom)
		{
			_subrectUpdateInProgress = true;
			int subrectRowCount = GetSubrectRowCount(SubrectTargetMode);
			int subrectColumnCount = GetSubrectColumnCount(SubrectTargetMode);
			int num = (int)Math.Floor((double)SubrectTargetIndex / (double)subrectColumnCount);
			int num2 = SubrectTargetIndex.Mod(subrectColumnCount);
			Vector2<double> vector = OutputSize.ComponentwiseQuotient(new Vector2<double>(subrectColumnCount, subrectRowCount));
			Vector2<double> position = vector.ComponentwiseProduct(new Vector2<double>(num2, num));
			Subrect = new Rect<double>(position, vector);
			_subrectUpdateInProgress = false;
		}
	}

	private void UpdateSubrectTarget()
	{
		if (_subrectUpdateInProgress || SubrectTargetMode == SubrectTargetMode.Custom)
		{
			return;
		}
		_subrectUpdateInProgress = true;
		Vector2<double> vector = Subrect.Size.ComponentwiseQuotient(OutputSize);
		SubrectTargetMode? subrectTargetMode = null;
		foreach (SubrectTargetMode item in from s in Enum.GetValues<SubrectTargetMode>()
			where s != SubrectTargetMode.Custom
			select s)
		{
			Vector2<double> subrectScalar = GetSubrectScalar(item);
			if (!(vector == subrectScalar))
			{
				continue;
			}
			for (int i = 0; i < GetSubrectColumnCount(item); i++)
			{
				if (subrectTargetMode.HasValue)
				{
					break;
				}
				for (int j = 0; j < GetSubrectRowCount(item); j++)
				{
					if (Subrect.Size.ComponentwiseProduct(new Vector2<double>(i, j)) == Subrect.Position)
					{
						subrectTargetMode = item;
						break;
					}
				}
			}
			if (subrectTargetMode.HasValue)
			{
				break;
			}
		}
		SubrectTargetMode = subrectTargetMode ?? SubrectTargetMode.Custom;
		if (SubrectTargetMode != SubrectTargetMode.Custom && SubrectTargetMode != 0)
		{
			Vector2<int> vector2 = Subrect.Position.ComponentwiseQuotient(Subrect.Size).Cast<int>();
			int subrectColumnCount = GetSubrectColumnCount(SubrectTargetMode);
			SubrectTargetIndex = vector2.X + vector2.Y * subrectColumnCount;
		}
		else
		{
			SubrectTargetIndex = 0;
		}
		_subrectUpdateInProgress = false;
	}

	private static Vector2<double> GetSubrectScalar(SubrectTargetMode mode)
	{
		return mode switch
		{
			SubrectTargetMode.TwoByOne => new Vector2<double>(0.5, 1.0), 
			SubrectTargetMode.TwoByTwo => new Vector2<double>(0.5, 0.5), 
			SubrectTargetMode.ThreeByOne => new Vector2<double>(1.0 / 3.0, 1.0), 
			SubrectTargetMode.Full => Vector2<double>.One, 
			_ => throw new NotSupportedException(), 
		};
	}

	private static int GetSubrectRowCount(SubrectTargetMode mode)
	{
		switch (mode)
		{
		case SubrectTargetMode.Full:
		case SubrectTargetMode.TwoByOne:
		case SubrectTargetMode.ThreeByOne:
			return 1;
		case SubrectTargetMode.TwoByTwo:
			return 2;
		default:
			throw new NotSupportedException();
		}
	}

	private static int GetSubrectColumnCount(SubrectTargetMode mode)
	{
		switch (mode)
		{
		case SubrectTargetMode.TwoByOne:
		case SubrectTargetMode.TwoByTwo:
			return 2;
		case SubrectTargetMode.ThreeByOne:
			return 3;
		case SubrectTargetMode.Full:
			return 1;
		default:
			throw new NotSupportedException();
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnSubrectChanged(Rect<double> value)
	{
		UpdateSubrectTarget();
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnOutputDeviceChanged(IDevice? oldValue, IDevice? newValue)
	{
		if (oldValue != null)
		{
			oldValue.PropertyChanged -= OutputDevice_PropertyChanged;
			oldValue.DataChanged -= NotifyOutputDataChanged;
		}
		if (newValue != null)
		{
			newValue.PropertyChanged += OutputDevice_PropertyChanged;
			newValue.DataChanged += NotifyOutputDataChanged;
		}
		UpdateSubrect();
		NotifyOutputDataChanged();
		NotifyOutputDeviceChanged(oldValue, newValue);
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnSubrectTargetModeChanged(SubrectTargetMode value)
	{
		if (SubrectTargetIndex != 0)
		{
			SubrectTargetIndex = 0;
		}
		else
		{
			UpdateSubrect();
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnSubrectTargetIndexChanged(int value)
	{
		UpdateSubrect();
	}
}
