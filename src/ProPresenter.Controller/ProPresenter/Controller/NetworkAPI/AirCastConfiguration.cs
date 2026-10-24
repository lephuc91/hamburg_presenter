using System.CodeDom.Compiler;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.IO.Abstractions;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using Pro.Common.SourceGenerator.Attributes;
using Pro.ssAPI.Devices;
using ProPresenter.DO;

namespace ProPresenter.Controller.NetworkAPI;

public class AirCastConfiguration : ObservableObject, IAirCastConfiguration, INotifyPropertyChanged
{
	private static readonly string FairPlayExecutable = Path.Combine(CommonPaths.InstallLocation, "AirCast", "fairplay.exe");

	private readonly IFileSystem _fileSystem;

	[Pro.Common.SourceGenerator.Attributes.PropertyLink("ServiceName", "ServiceName")]
	[Pro.Common.SourceGenerator.Attributes.PropertyLink("Password", "Password")]
	[Pro.Common.SourceGenerator.Attributes.PropertyLink("PasswordEnabled", "PasswordEnabled")]
	private IAirCastVideoInputDevice? _airCastVideoInputDevice;

	private IVideoInputDeviceCollection? _videoInputDevices;

	public string DeviceID => _airCastVideoInputDevice?.UUID ?? string.Empty;

	[MemberNotNullWhen(true, "_airCastVideoInputDevice")]
	public bool Enabled
	{
		[MemberNotNullWhen(true, "_airCastVideoInputDevice")]
		get
		{
			return _airCastVideoInputDevice != null;
		}
	}

	public bool PluginExists => _fileSystem.File.Exists(PluginPath);

	public string? ServiceName
	{
		get
		{
			return _airCastVideoInputDevice?.ServiceName;
		}
		set
		{
			if (Enabled)
			{
				_airCastVideoInputDevice.ServiceName = value;
			}
		}
	}

	public string? Password
	{
		get
		{
			return _airCastVideoInputDevice?.Password;
		}
		set
		{
			if (Enabled)
			{
				_airCastVideoInputDevice.Password = value;
			}
		}
	}

	public bool PasswordEnabled
	{
		get
		{
			return _airCastVideoInputDevice?.PasswordEnabled ?? false;
		}
		set
		{
			if (Enabled)
			{
				_airCastVideoInputDevice.PasswordEnabled = value;
			}
		}
	}

	public string PluginPath { get; }

	public AirCastConfiguration(IFileSystem fileSystem)
	{
		_fileSystem = fileSystem;
		PluginPath = FairPlayExecutable;
	}

	public void SetDeviceInputs(IVideoInputDeviceCollection videoInputDevices)
	{
		_videoInputDevices = videoInputDevices;
		_videoInputDevices.CollectionChanged += VideoInputDevices_CollectionChanged;
		CheckAirCastEnabled();
	}

	private void VideoInputDevices_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		CheckAirCastEnabled();
	}

	private void CheckAirCastEnabled()
	{
		IAirCastVideoInputDevice configuredAirCastInput = _videoInputDevices?.FirstOrDefault((IVideoInputDevice v) => v.Type == VideoDeviceType.Aircast) as IAirCastVideoInputDevice;
		SetConfiguredAirCastInput(configuredAirCastInput);
		OnPropertyChanged("ServiceName");
		OnPropertyChanged("Password");
		OnPropertyChanged("PasswordEnabled");
		OnPropertyChanged("Enabled");
	}

	private void SetConfiguredAirCastInput(IAirCastVideoInputDevice? airCastVideoInputDevice)
	{
		if (_airCastVideoInputDevice != null)
		{
			RemovePropertyLinks();
		}
		_airCastVideoInputDevice = airCastVideoInputDevice;
		if (_airCastVideoInputDevice != null)
		{
			AddPropertyLinks();
		}
	}

	public void NotifyPluginInstalled()
	{
		OnPropertyChanged("PluginExists");
		OnPropertyChanged("PluginPath");
	}

	public bool GetShouldRequirePassword()
	{
		if (Enabled && PasswordEnabled)
		{
			return string.IsNullOrEmpty(Password);
		}
		return false;
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void _airCastVideoInputDevice_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		switch (e.PropertyName)
		{
		case "ServiceName":
			OnPropertyChanged("ServiceName");
			break;
		case "Password":
			OnPropertyChanged("Password");
			break;
		case "PasswordEnabled":
			OnPropertyChanged("PasswordEnabled");
			break;
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void AddPropertyLinks()
	{
		_airCastVideoInputDevice.PropertyChanged += _airCastVideoInputDevice_PropertyChanged;
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void RemovePropertyLinks()
	{
		if (_airCastVideoInputDevice != null)
		{
			_airCastVideoInputDevice.PropertyChanged -= _airCastVideoInputDevice_PropertyChanged;
		}
	}
}
