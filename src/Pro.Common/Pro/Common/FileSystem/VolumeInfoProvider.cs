using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Management;
using System.Text.RegularExpressions;
using System.Text.RegularExpressions.Generated;
using System.Threading;
using Pro.Common.Collections;
using Pro.Common.Collections.Concurrency.Locking;

namespace Pro.Common.FileSystem;

public static class VolumeInfoProvider
{
	private enum DriveType : uint
	{
		Unknown,
		NoRootDirectory,
		RemovableDisk,
		LocalDisk,
		NetworkDrive,
		CompactDisc,
		RAMDisk
	}

	private static readonly DriveType[] SupportedDriveTypes;

	private static volatile VolumeInfo _bootVolume;

	private static volatile LockingList<VolumeInfo> _externalVolumes;

	private static readonly Dictionary<string, VolumeInfo> _letterMap;

	private static readonly Dictionary<string, VolumeInfo[]> _nameMap;

	private static readonly ManagementEventWatcher _deviceChangeWatcher;

	private static readonly ManagementEventWatcher _volumeChangeWatcher;

	private static ManagementOperationObserver? _volumeOperationObserver;

	private static readonly Lock _letterMapLock;

	private static readonly Lock _nameMapLock;

	public static VolumeInfo BootVolume => _bootVolume;

	public static IReadOnlyList<VolumeInfo> ExternalVolumes => _externalVolumes;

	[GeneratedRegex("^([a-zA-Z])\\:?\\\\?$")]
	[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
	private static Regex DriveLetterRegex()
	{
		return _003CRegexGenerator_g_003EFECC16A9B7A861F0F789D0D378F6C778D0DFD3729E6059AC897218766952A5328__DriveLetterRegex_1.Instance;
	}

	static VolumeInfoProvider()
	{
		SupportedDriveTypes = new DriveType[3]
		{
			DriveType.RemovableDisk,
			DriveType.LocalDisk,
			DriveType.NetworkDrive
		};
		_externalVolumes = new LockingList<VolumeInfo>();
		_letterMap = new Dictionary<string, VolumeInfo>();
		_nameMap = new Dictionary<string, VolumeInfo[]>();
		_volumeOperationObserver = null;
		_letterMapLock = new Lock();
		_nameMapLock = new Lock();
		UpdateDriveInfo();
		_deviceChangeWatcher = new ManagementEventWatcher("SELECT * FROM Win32_DeviceChangeEvent WHERE EventType = 2 OR EventType = 3");
		_deviceChangeWatcher.EventArrived += delegate
		{
			UpdateDriveInfo();
		};
		_deviceChangeWatcher.Start();
		_volumeChangeWatcher = new ManagementEventWatcher("SELECT * FROM Win32_VolumeChangeEvent WHERE EventType = 2 OR EventType = 3");
		_volumeChangeWatcher.EventArrived += delegate
		{
			UpdateDriveInfo();
		};
		_volumeChangeWatcher.Start();
	}

	[MemberNotNull("_bootVolume")]
	private static void UpdateDriveInfo()
	{
		using (_letterMapLock.EnterScope())
		{
			using (_nameMapLock.EnterScope())
			{
				_letterMap.Clear();
				_nameMap.Clear();
				_externalVolumes.Reset(Array.Empty<VolumeInfo>());
				using ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("SELECT DriveType, DeviceID, ProviderName, VolumeName, VolumeSerialNumber FROM Win32_LogicalDisk WHERE DriveType = 3");
				foreach (ManagementBaseObject item in managementObjectSearcher.Get())
				{
					ProcessDriveVolume(item);
				}
				_bootVolume = _letterMap[Path.GetFullPath(Environment.GetFolderPath(Environment.SpecialFolder.Windows)).Substring(0, 1).ToUpperInvariant()];
				using ManagementObjectSearcher managementObjectSearcher2 = new ManagementObjectSearcher("SELECT DriveType, DeviceID, ProviderName, VolumeName, VolumeSerialNumber FROM Win32_LogicalDisk WHERE DriveType = 4");
				if (_volumeOperationObserver == null)
				{
					_volumeOperationObserver = new ManagementOperationObserver();
					_volumeOperationObserver.ObjectReady += ProcessObjectReady;
					_volumeOperationObserver.Completed += ProcessQueryCompleted;
				}
				managementObjectSearcher2.Get(_volumeOperationObserver);
			}
		}
	}

	private static void ProcessDriveVolume(ManagementBaseObject disk)
	{
		object obj = disk["DriveType"];
		DriveType driveType = ((obj is uint num) ? ((DriveType)num) : ((obj is int num2) ? ((DriveType)num2) : DriveType.Unknown));
		DriveType driveType2 = driveType;
		if (!SupportedDriveTypes.Contains(driveType2))
		{
			return;
		}
		string letter = ((string)disk["DeviceID"]) ?? string.Empty;
		string name = ((string)disk[(driveType2 == DriveType.NetworkDrive) ? "ProviderName" : "VolumeName"]) ?? string.Empty;
		string serialNumber = ((string)disk["VolumeSerialNumber"]) ?? string.Empty;
		if (!TrySanitizeDriveLetter(ref letter))
		{
			return;
		}
		VolumeInfo volume = new VolumeInfo(letter, name, serialNumber);
		if (_letterMap.ContainsKey(volume.Letter))
		{
			_letterMap[volume.Letter] = volume;
		}
		else
		{
			_letterMap.Add(volume.Letter, volume);
		}
		if (!_externalVolumes.Any((VolumeInfo v) => v.Name == volume.Name))
		{
			_externalVolumes.Add(volume);
		}
		if (!string.IsNullOrEmpty(volume.Name))
		{
			if (!_nameMap.ContainsKey(volume.Name))
			{
				_nameMap.Add(volume.Name, new VolumeInfo[1] { volume });
			}
			else
			{
				_nameMap[volume.Name] = _nameMap[volume.Name].Concat(new VolumeInfo[1] { volume }).ToArray();
			}
		}
	}

	private static void ProcessObjectReady(object sender, ObjectReadyEventArgs obj)
	{
		using (_letterMapLock.EnterScope())
		{
			using (_nameMapLock.EnterScope())
			{
				ProcessDriveVolume(obj.NewObject);
			}
		}
	}

	private static void ProcessQueryCompleted(object sender, CompletedEventArgs obj)
	{
		_externalVolumes.Reset((_bootVolume != null) ? (from v in _externalVolumes.Except(_bootVolume)
			orderby v.Letter
			select v).ToArray() : _externalVolumes.OrderBy((VolumeInfo v) => v.Letter).ToArray());
	}

	private static bool TrySanitizeDriveLetter(ref string letter)
	{
		Match match = DriveLetterRegex().Match(letter);
		if (match.Success)
		{
			letter = match.Groups[1].Value;
		}
		return match.Success;
	}

	public static bool TryGetByLetter(string letter, [MaybeNullWhen(false)] out VolumeInfo info)
	{
		TrySanitizeDriveLetter(ref letter);
		using (_letterMapLock.EnterScope())
		{
			return _letterMap.TryGetValue(letter.ToUpperInvariant(), out info);
		}
	}

	public static bool TryGetByVolumeName(string volumeName, [MaybeNullWhen(false)] out VolumeInfo[] info)
	{
		using (_nameMapLock.EnterScope())
		{
			return _nameMap.TryGetValue(volumeName, out info);
		}
	}
}
