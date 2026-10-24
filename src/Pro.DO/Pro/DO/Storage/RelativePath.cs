using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text.RegularExpressions.Generated;
using System.Threading;
using Pro.Common.Components;
using Pro.Common.FileSystem;
using Pro.Common.Nullability;
using Pro.Common.Utility;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;

namespace Pro.DO.Storage;

[DebuggerDisplay("{FullPath}")]
public sealed class RelativePath : NotifyPropertyChangedBase, ICloneable<RelativePath>, IEquatable<RelativePath?>
{
	private static readonly ReadOnlyDictionary<URL.Types.LocalRelativePath.Types.Root, Func<string>> _localRootMap;

	private static readonly URL.Types.LocalRelativePath.Types.Root[] _rootLookupOrder;

	private static Func<string>? _showRootProvider;

	private static Func<SearchRootCollection?>? _searchRootsProvider;

	private static readonly ThreadLocal<CurrentResourceRootHandle?> _currentResourceRootHandle;

	private static readonly List<WeakReference<RelativePath>> _searchRootPaths;

	private readonly URL _protoURL;

	private int? _hashCode;

	private string? _filename;

	private string? _extension;

	private bool _isResolved;

	private bool _isValid;

	private string? _rawRoot;

	private string? _rawPath;

	private string? _fullPath;

	private WeakReference<RelativePath>? _searchReference;

	public string Filename
	{
		get
		{
			if (_filename == null)
			{
				_filename = Path.GetFileName(RawPath);
			}
			return _filename ?? string.Empty;
		}
	}

	public string Extension
	{
		get
		{
			if (_extension == null)
			{
				_extension = Path.GetExtension(Filename);
			}
			return _extension;
		}
	}

	public bool IsValid
	{
		get
		{
			EnsurePathResolved();
			return _isValid;
		}
	}

	public bool IsEmpty => string.IsNullOrEmpty(RawRoot);

	public string? RawRoot
	{
		get
		{
			EnsurePathResolved();
			return _rawRoot;
		}
	}

	public string? RawPath
	{
		get
		{
			EnsurePathResolved();
			return _rawPath;
		}
	}

	public string? FullPath
	{
		get
		{
			EnsurePathResolved();
			return _fullPath;
		}
	}

	public string Name => Path.GetFileNameWithoutExtension(Filename);

	private static CurrentResourceRootHandle? CurrentResourceRootHandle
	{
		get
		{
			if (!_currentResourceRootHandle.IsValueCreated)
			{
				return null;
			}
			return _currentResourceRootHandle.Value;
		}
		set
		{
			_currentResourceRootHandle.Value = value;
		}
	}

	public static Url CreateWeb(string webUrl)
	{
		return new Url(Url.Types.Platform.Web, new Url.Types.Storage.AbsoluteString(webUrl), new Url.Types.RelativeFilePath.Local(new Url.Types.LocalRelativePath(Url.Types.LocalRelativePath.Types.Root.Unknown, "")));
	}

	public static Url Create(RelativePath model)
	{
		return new Url(ToEntityPlatform(model._protoURL.Platform), ToEntityStorage(model._protoURL), ToRelativeFilePath(model._protoURL));
	}

	public static RelativePath Create(Url url, out URL protoUrl)
	{
		protoUrl = new URL();
		ToProtoStorage(protoUrl, url);
		ToProtoPlatform(protoUrl, url);
		ToProtoRelativePath(protoUrl, url);
		return new RelativePath(protoUrl);
	}

	private static void ToProtoStorage(URL protoUrl, Url url)
	{
		Url.Types.Storage storage = url.Storage;
		if (!(storage is Url.Types.Storage.AbsoluteString absoluteString))
		{
			if (storage is Url.Types.Storage.RelativePath relativePath)
			{
				protoUrl.RelativePath = relativePath._RelativePath;
			}
		}
		else
		{
			protoUrl.AbsoluteString = absoluteString._AbsoluteString;
		}
	}

	private static Url.Types.Storage ToEntityStorage(URL protoURL)
	{
		return protoURL.StorageCase switch
		{
			URL.StorageOneofCase.None => new Url.Types.Storage.AbsoluteString(""), 
			URL.StorageOneofCase.AbsoluteString => new Url.Types.Storage.AbsoluteString(protoURL.AbsoluteString), 
			URL.StorageOneofCase.RelativePath => new Url.Types.Storage.RelativePath(protoURL.RelativePath), 
			_ => new Url.Types.Storage.AbsoluteString(""), 
		};
	}

	private static Url.Types.Platform ToEntityPlatform(URL.Types.Platform platform)
	{
		return platform switch
		{
			URL.Types.Platform.Unknown => Url.Types.Platform.Unknown, 
			URL.Types.Platform.Macos => Url.Types.Platform.Macos, 
			URL.Types.Platform.Win32 => Url.Types.Platform.Win32, 
			URL.Types.Platform.Web => Url.Types.Platform.Web, 
			_ => Url.Types.Platform.Unknown, 
		};
	}

	private static void ToProtoPlatform(URL protoUrl, Url url)
	{
		switch (url.Platform)
		{
		case Url.Types.Platform.Unknown:
			protoUrl.Platform = URL.Types.Platform.Unknown;
			break;
		case Url.Types.Platform.Macos:
			protoUrl.Platform = URL.Types.Platform.Macos;
			break;
		case Url.Types.Platform.Win32:
			protoUrl.Platform = URL.Types.Platform.Win32;
			break;
		case Url.Types.Platform.Web:
			protoUrl.Platform = URL.Types.Platform.Web;
			break;
		}
	}

	private static Url.Types.RelativeFilePath ToRelativeFilePath(URL protoURL)
	{
		return protoURL.RelativeFilePathCase switch
		{
			URL.RelativeFilePathOneofCase.None => new Url.Types.RelativeFilePath.Local(new Url.Types.LocalRelativePath(Url.Types.LocalRelativePath.Types.Root.Unknown, "")), 
			URL.RelativeFilePathOneofCase.Local => new Url.Types.RelativeFilePath.Local(new Url.Types.LocalRelativePath(ToEntityRoot(protoURL.Local.Root), protoURL.Local.Path)), 
			URL.RelativeFilePathOneofCase.External => new Url.Types.RelativeFilePath.External(new Url.Types.ExternalRelativePath(new Url.Types.ExternalRelativePath.Types.MacOsExternalVolume(protoURL.External.Macos?.VolumeName ?? string.Empty), new Url.Types.ExternalRelativePath.Types.Win32ExternalVolume(protoURL.External.Win32.DriveLetter, protoURL.External.Win32.VolumeName, protoURL.External.Win32.NetworkShare), protoURL.External.Path)), 
			_ => new Url.Types.RelativeFilePath.Local(new Url.Types.LocalRelativePath(Url.Types.LocalRelativePath.Types.Root.Unknown, "")), 
		};
	}

	private static void ToProtoRelativePath(URL protoUrl, Url url)
	{
		Url.Types.RelativeFilePath relativeFilePath = url.RelativeFilePath;
		if (!(relativeFilePath is Url.Types.RelativeFilePath.Local local))
		{
			if (relativeFilePath is Url.Types.RelativeFilePath.External external)
			{
				protoUrl.External = new URL.Types.ExternalRelativePath
				{
					Macos = new URL.Types.ExternalRelativePath.Types.MacOSExternalVolume
					{
						VolumeName = external._External.Macos.VolumeName
					},
					Win32 = new URL.Types.ExternalRelativePath.Types.Win32ExternalVolume
					{
						VolumeName = external._External.Win32.VolumeName,
						DriveLetter = external._External.Win32.DriveLetter,
						NetworkShare = external._External.Win32.NetworkShare
					},
					Path = external._External.Path
				};
			}
		}
		else
		{
			protoUrl.Local = new URL.Types.LocalRelativePath
			{
				Root = ToProtoRoot(local._Local.Root),
				Path = local._Local.Path
			};
		}
	}

	private static URL.Types.LocalRelativePath.Types.Root ToProtoRoot(Url.Types.LocalRelativePath.Types.Root root)
	{
		return root switch
		{
			Url.Types.LocalRelativePath.Types.Root.Unknown => URL.Types.LocalRelativePath.Types.Root.Unknown, 
			Url.Types.LocalRelativePath.Types.Root.BootVolume => URL.Types.LocalRelativePath.Types.Root.BootVolume, 
			Url.Types.LocalRelativePath.Types.Root.UserHome => URL.Types.LocalRelativePath.Types.Root.UserHome, 
			Url.Types.LocalRelativePath.Types.Root.UserDocuments => URL.Types.LocalRelativePath.Types.Root.UserDocuments, 
			Url.Types.LocalRelativePath.Types.Root.UserDownloads => URL.Types.LocalRelativePath.Types.Root.UserDownloads, 
			Url.Types.LocalRelativePath.Types.Root.UserMusic => URL.Types.LocalRelativePath.Types.Root.UserMusic, 
			Url.Types.LocalRelativePath.Types.Root.UserPictures => URL.Types.LocalRelativePath.Types.Root.UserPictures, 
			Url.Types.LocalRelativePath.Types.Root.UserVideos => URL.Types.LocalRelativePath.Types.Root.UserVideos, 
			Url.Types.LocalRelativePath.Types.Root.UserAppSupport => URL.Types.LocalRelativePath.Types.Root.UserAppSupport, 
			Url.Types.LocalRelativePath.Types.Root.Shared => URL.Types.LocalRelativePath.Types.Root.Shared, 
			Url.Types.LocalRelativePath.Types.Root.Show => URL.Types.LocalRelativePath.Types.Root.Show, 
			Url.Types.LocalRelativePath.Types.Root.UserDesktop => URL.Types.LocalRelativePath.Types.Root.UserDesktop, 
			Url.Types.LocalRelativePath.Types.Root.CurrentResource => URL.Types.LocalRelativePath.Types.Root.CurrentResource, 
			_ => URL.Types.LocalRelativePath.Types.Root.Unknown, 
		};
	}

	private static Url.Types.LocalRelativePath.Types.Root ToEntityRoot(URL.Types.LocalRelativePath.Types.Root root)
	{
		return root switch
		{
			URL.Types.LocalRelativePath.Types.Root.Unknown => Url.Types.LocalRelativePath.Types.Root.Unknown, 
			URL.Types.LocalRelativePath.Types.Root.BootVolume => Url.Types.LocalRelativePath.Types.Root.BootVolume, 
			URL.Types.LocalRelativePath.Types.Root.UserHome => Url.Types.LocalRelativePath.Types.Root.UserHome, 
			URL.Types.LocalRelativePath.Types.Root.UserDocuments => Url.Types.LocalRelativePath.Types.Root.UserDocuments, 
			URL.Types.LocalRelativePath.Types.Root.UserDownloads => Url.Types.LocalRelativePath.Types.Root.UserDownloads, 
			URL.Types.LocalRelativePath.Types.Root.UserMusic => Url.Types.LocalRelativePath.Types.Root.UserMusic, 
			URL.Types.LocalRelativePath.Types.Root.UserPictures => Url.Types.LocalRelativePath.Types.Root.UserPictures, 
			URL.Types.LocalRelativePath.Types.Root.UserVideos => Url.Types.LocalRelativePath.Types.Root.UserVideos, 
			URL.Types.LocalRelativePath.Types.Root.UserDesktop => Url.Types.LocalRelativePath.Types.Root.UserDesktop, 
			URL.Types.LocalRelativePath.Types.Root.UserAppSupport => Url.Types.LocalRelativePath.Types.Root.UserAppSupport, 
			URL.Types.LocalRelativePath.Types.Root.Shared => Url.Types.LocalRelativePath.Types.Root.Shared, 
			URL.Types.LocalRelativePath.Types.Root.Show => Url.Types.LocalRelativePath.Types.Root.Show, 
			URL.Types.LocalRelativePath.Types.Root.CurrentResource => Url.Types.LocalRelativePath.Types.Root.CurrentResource, 
			_ => Url.Types.LocalRelativePath.Types.Root.Unknown, 
		};
	}

	[GeneratedRegex("^\\\\\\\\([^\\\\]+)\\\\(.+)$")]
	[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
	private static Regex UNCRegex()
	{
		return _003CRegexGenerator_g_003EF4B46D4405B96F7F86721807D0124240ED0698A31136D53C12CA4050B432BB578__UNCRegex_0.Instance;
	}

	static RelativePath()
	{
		_showRootProvider = null;
		_searchRootsProvider = null;
		_currentResourceRootHandle = new ThreadLocal<CurrentResourceRootHandle>();
		_searchRootPaths = new List<WeakReference<RelativePath>>();
		_localRootMap = new ReadOnlyDictionary<URL.Types.LocalRelativePath.Types.Root, Func<string>>(new Dictionary<URL.Types.LocalRelativePath.Types.Root, Func<string>>
		{
			{
				URL.Types.LocalRelativePath.Types.Root.BootVolume,
				createRootProvider(VolumeInfoProvider.BootVolume.Path.NormalizePath())
			},
			{
				URL.Types.LocalRelativePath.Types.Root.UserHome,
				createRootProvider(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile).NormalizePath())
			},
			{
				URL.Types.LocalRelativePath.Types.Root.UserDocuments,
				createRootProvider(Environment.GetFolderPath(Environment.SpecialFolder.Personal).NormalizePath())
			},
			{
				URL.Types.LocalRelativePath.Types.Root.UserDownloads,
				createRootProvider(KnownFolder.Downloads.GetPath().NormalizePath())
			},
			{
				URL.Types.LocalRelativePath.Types.Root.UserMusic,
				createRootProvider(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic).NormalizePath())
			},
			{
				URL.Types.LocalRelativePath.Types.Root.UserPictures,
				createRootProvider(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures).NormalizePath())
			},
			{
				URL.Types.LocalRelativePath.Types.Root.UserVideos,
				createRootProvider(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos).NormalizePath())
			},
			{
				URL.Types.LocalRelativePath.Types.Root.UserDesktop,
				createRootProvider(Environment.GetFolderPath(Environment.SpecialFolder.Desktop).NormalizePath())
			},
			{
				URL.Types.LocalRelativePath.Types.Root.UserAppSupport,
				createRootProvider(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).NormalizePath())
			},
			{
				URL.Types.LocalRelativePath.Types.Root.Shared,
				createRootProvider(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData).NormalizePath())
			},
			{
				URL.Types.LocalRelativePath.Types.Root.Show,
				() => _showRootProvider?.Invoke()?.NormalizePath() ?? string.Empty
			},
			{
				URL.Types.LocalRelativePath.Types.Root.CurrentResource,
				() => CurrentResourceRootHandle?.RootPath ?? string.Empty
			},
			{
				URL.Types.LocalRelativePath.Types.Root.Unknown,
				() => string.Empty
			}
		});
		_rootLookupOrder = (from r in Enum.GetValues<URL.Types.LocalRelativePath.Types.Root>()
			where r != URL.Types.LocalRelativePath.Types.Root.Unknown
			select r).Reverse().ToArray();
		static Func<string> createRootProvider(string root)
		{
			return () => root;
		}
	}

	public RelativePath()
	{
		_protoURL = new URL();
	}

	public RelativePath(URL? url)
	{
		_protoURL = url?.Clone() ?? new URL();
		if (_protoURL.RelativeFilePathCase == URL.RelativeFilePathOneofCase.Local && _protoURL.Local.Root == URL.Types.LocalRelativePath.Types.Root.CurrentResource && IsValid)
		{
			_protoURL.AbsoluteString = FullPath;
			_protoURL.Platform = URL.Types.Platform.Win32;
		}
	}

	public RelativePath(string? path, bool isDirectory = false)
	{
		if (string.IsNullOrWhiteSpace(path))
		{
			_protoURL = new URL();
			return;
		}
		path = Uri.UnescapeDataString(path).NormalizePath(isDirectory);
		_protoURL = new URL
		{
			AbsoluteString = path,
			Platform = URL.Types.Platform.Win32
		};
		bool flag = false;
		URL.Types.LocalRelativePath.Types.Root[] rootLookupOrder = _rootLookupOrder;
		foreach (URL.Types.LocalRelativePath.Types.Root root in rootLookupOrder)
		{
			string text = _localRootMap[root]();
			if (!string.IsNullOrEmpty(text) && TryMatchLocalRootPath(path, root, text, out URL.Types.LocalRelativePath localPath))
			{
				_protoURL.Local = localPath;
				flag = true;
				break;
			}
		}
		if (flag)
		{
			return;
		}
		if (!path.IsUNC())
		{
			string text2 = Path.GetPathRoot(path)?.TrimTrailingSlashes() ?? string.Empty;
			if (VolumeInfoProvider.TryGetByLetter(text2, out VolumeInfo info))
			{
				_protoURL.External = new URL.Types.ExternalRelativePath
				{
					Win32 = new URL.Types.ExternalRelativePath.Types.Win32ExternalVolume
					{
						DriveLetter = info.Letter,
						VolumeName = info.Name,
						NetworkShare = false
					},
					Path = path.Substring(Math.Min(info.Path.Length, path.Length)).Replace('\\', '/')
				};
			}
			else
			{
				_protoURL.External = new URL.Types.ExternalRelativePath
				{
					Win32 = new URL.Types.ExternalRelativePath.Types.Win32ExternalVolume
					{
						DriveLetter = text2.ToUpperInvariant(),
						VolumeName = string.Empty,
						NetworkShare = false
					},
					Path = (path.NullableIsNullOrEmpty() ? string.Empty : path.Substring(Math.Min(Path.GetPathRoot(path).Length, path.Length)).Replace('\\', '/'))
				};
			}
		}
		else
		{
			Match match = UNCRegex().Match(path);
			if (!match.Success)
			{
				throw new NotSupportedException("Invalid UNC (network) path format (" + path + ")");
			}
			_protoURL.External = new URL.Types.ExternalRelativePath
			{
				Win32 = new URL.Types.ExternalRelativePath.Types.Win32ExternalVolume
				{
					DriveLetter = string.Empty,
					VolumeName = match.Groups[1].Value,
					NetworkShare = true
				},
				Path = match.Groups[2].Value.Replace('\\', '/')
			};
		}
	}

	public static RelativePath Empty()
	{
		return new RelativePath();
	}

	public static void SetShowRootProvider(Func<string> provider)
	{
		if (_showRootProvider != null)
		{
			throw new InvalidOperationException();
		}
		_showRootProvider = provider;
	}

	public static void SetSearchRootsProvider(Func<SearchRootCollection?> provider)
	{
		if (_searchRootsProvider != null)
		{
			throw new InvalidOperationException();
		}
		_searchRootsProvider = provider;
	}

	public static CurrentResourceRootHandle? SetCurrentResourceRoot(string rootPath)
	{
		if (string.IsNullOrEmpty(rootPath))
		{
			throw new ArgumentException("path was null or empty", "rootPath");
		}
		if (CurrentResourceRootHandle != null)
		{
			throw new InvalidOperationException("Only a single current resource root may be set at a time until the previous handle is released");
		}
		return CurrentResourceRootHandle = new CurrentResourceRootHandle(rootPath.NormalizePath());
	}

	internal static void ClearCurrentResourceRoot()
	{
		CurrentResourceRootHandle = null;
	}

	public static void NotifySearchRootsUpdated()
	{
		if (_searchRootsProvider == null)
		{
			throw new InvalidOperationException();
		}
		lock (_searchRootPaths)
		{
			int num = 0;
			while (num < _searchRootPaths.Count)
			{
				if (_searchRootPaths[num].TryGetTarget(out RelativePath target))
				{
					target.TryResolve();
					num++;
				}
				else
				{
					_searchRootPaths.RemoveAt(num);
				}
			}
		}
	}

	public static string GetSearchRootPath(ISearchRoot searchRoot)
	{
		return GetSearchRootPath(searchRoot as SearchRoot);
	}

	public static string GetSearchRootPath(SearchRoot? searchRoot)
	{
		if (searchRoot == null)
		{
			return string.Empty;
		}
		if (searchRoot.Type != SearchRootType.OtherVolumes)
		{
			return _localRootMap[searchRoot.Type.ToProtoLocalRoot()]();
		}
		return string.Empty;
	}

	private static bool TryMatchLocalRootPath(string path, URL.Types.LocalRelativePath.Types.Root root, string rootPath, out URL.Types.LocalRelativePath? localPath)
	{
		if (path.StartsWith(rootPath, StringComparison.OrdinalIgnoreCase))
		{
			localPath = new URL.Types.LocalRelativePath
			{
				Root = root,
				Path = path.Substring(rootPath.Length).Replace('\\', '/')
			};
			return true;
		}
		localPath = null;
		return false;
	}

	public void UpdateValidity()
	{
		if (!_isResolved)
		{
			return;
		}
		if (_searchReference == null)
		{
			_isValid = File.Exists(_fullPath) || Directory.Exists(_fullPath);
			if (!_isValid)
			{
				TryResolve();
			}
		}
		else
		{
			TryResolve(resolveImmediately: true);
		}
	}

	public void TryResolve(bool resolveImmediately = false)
	{
		string fullPath = _fullPath;
		_isResolved = false;
		_isValid = false;
		_rawRoot = null;
		_rawPath = null;
		_fullPath = null;
		if (resolveImmediately)
		{
			EnsurePathResolved();
		}
		OnPropertyChanged("IsValid");
		OnPropertyChanged("IsEmpty");
		if (!resolveImmediately || fullPath != _fullPath)
		{
			OnPropertyChanged("RawRoot");
			OnPropertyChanged("RawPath");
			OnPropertyChanged("FullPath");
		}
	}

	public RelativePath Clone()
	{
		return new RelativePath(_protoURL);
	}

	public URL Serialize()
	{
		if (_protoURL.Platform == URL.Types.Platform.Win32 && _protoURL.StorageCase == URL.StorageOneofCase.AbsoluteString && _protoURL.RelativeFilePathCase == URL.RelativeFilePathOneofCase.Local && _protoURL.Local.Root != URL.Types.LocalRelativePath.Types.Root.CurrentResource)
		{
			string text = CurrentResourceRootHandle?.RootPath ?? string.Empty;
			if (!string.IsNullOrEmpty(text) && TryMatchLocalRootPath(_protoURL.AbsoluteString, URL.Types.LocalRelativePath.Types.Root.CurrentResource, text, out URL.Types.LocalRelativePath localPath))
			{
				_protoURL.Local = localPath;
			}
		}
		return _protoURL.Clone();
	}

	private void EnsurePathResolved()
	{
		if (_isResolved)
		{
			return;
		}
		_isResolved = true;
		_rawRoot = string.Empty;
		_rawPath = string.Empty;
		_fullPath = string.Empty;
		URL protoURL = _protoURL;
		if (protoURL != null && protoURL.RelativeFilePathCase == URL.RelativeFilePathOneofCase.Local)
		{
			if (TryValidate(GetLocalRoot(_protoURL.Local), _protoURL.Local.Path, isSearchPath: false))
			{
				return;
			}
		}
		else
		{
			URL protoURL2 = _protoURL;
			if (protoURL2 != null && protoURL2.RelativeFilePathCase == URL.RelativeFilePathOneofCase.External)
			{
				URL.Types.ExternalRelativePath.Types.Win32ExternalVolume win = _protoURL.External.Win32;
				if (win != null && win.NetworkShare)
				{
					if (TryValidate("\\\\" + _protoURL.External.Win32.VolumeName + "\\", _protoURL.External.Path.Replace('/', '\\'), isSearchPath: false))
					{
						return;
					}
				}
				else
				{
					VolumeInfo[] externalVolumes = GetExternalVolumes(_protoURL.External);
					foreach (VolumeInfo volumeInfo in externalVolumes)
					{
						if (TryValidate(volumeInfo.Path, _protoURL.External.Path, isSearchPath: false))
						{
							_protoURL.External.Win32 = new URL.Types.ExternalRelativePath.Types.Win32ExternalVolume
							{
								DriveLetter = volumeInfo.Letter,
								VolumeName = volumeInfo.Name
							};
							return;
						}
					}
				}
			}
		}
		URL protoURL3 = _protoURL;
		if (protoURL3 != null && protoURL3.StorageCase == URL.StorageOneofCase.AbsoluteString && (_protoURL.Platform == URL.Types.Platform.Unknown || _protoURL.Platform == URL.Types.Platform.Win32))
		{
			string normalizedPath = Uri.UnescapeDataString(_protoURL.AbsoluteString);
			if (_protoURL.Platform == URL.Types.Platform.Unknown && !normalizedPath.TryNormalizePath(out normalizedPath, isDirectory: false))
			{
				normalizedPath = null;
			}
			if (normalizedPath != null)
			{
				string pathRoot = Path.GetPathRoot(normalizedPath);
				string path = normalizedPath.Substring(Math.Min(pathRoot?.Length ?? 0, normalizedPath.Length));
				if (TryValidate(pathRoot, path, isSearchPath: false))
				{
					return;
				}
			}
		}
		SearchRootCollection searchRootCollection = _searchRootsProvider?.Invoke();
		if (searchRootCollection != null)
		{
			URL protoURL4 = _protoURL;
			string text;
			if (protoURL4 != null && protoURL4.RelativeFilePathCase == URL.RelativeFilePathOneofCase.Local)
			{
				text = _protoURL.Local.Path;
			}
			else
			{
				URL protoURL5 = _protoURL;
				text = ((protoURL5 != null && protoURL5.RelativeFilePathCase == URL.RelativeFilePathOneofCase.External) ? _protoURL.External.Path : null);
			}
			if (!text.NullableIsNullOrWhiteSpace())
			{
				foreach (ISearchRoot item in searchRootCollection.Where((ISearchRoot r) => r.IsActive))
				{
					if (item.Type != SearchRootType.OtherVolumes)
					{
						if (TryValidate(GetSearchRootPath(item), text, isSearchPath: true))
						{
							return;
						}
						continue;
					}
					foreach (VolumeInfo externalVolume in VolumeInfoProvider.ExternalVolumes)
					{
						if (TryValidate(externalVolume.Path, text, isSearchPath: true))
						{
							return;
						}
					}
				}
			}
		}
		AddSearchReference();
	}

	private static string GetLocalRoot(URL.Types.LocalRelativePath localPath)
	{
		return _localRootMap[localPath.Root]();
	}

	private static VolumeInfo[] GetExternalVolumes(URL.Types.ExternalRelativePath externalPath)
	{
		if (externalPath.Win32 != null && VolumeInfoProvider.TryGetByLetter(externalPath.Win32.DriveLetter, out VolumeInfo info))
		{
			return new VolumeInfo[1] { info };
		}
		string text = externalPath.Win32?.VolumeName ?? externalPath.Macos?.VolumeName;
		if (!string.IsNullOrEmpty(text) && VolumeInfoProvider.TryGetByVolumeName(text, out VolumeInfo[] info2))
		{
			return info2;
		}
		return Array.Empty<VolumeInfo>();
	}

	private bool TryValidate(string? root, string path, bool isSearchPath)
	{
		if (string.IsNullOrEmpty(root) || string.IsNullOrEmpty(path))
		{
			return false;
		}
		if (!TryGetFileToValidate(root, path, out string fullPath))
		{
			_isValid = false;
			return _isValid;
		}
		_isValid = File.Exists(fullPath) || Directory.Exists(fullPath);
		if (!_isValid && isSearchPath && !TryGetFileToValidate(root, Path.GetFileName(path), out fullPath))
		{
			_isValid = false;
			return _isValid;
		}
		_isValid = File.Exists(fullPath) || Directory.Exists(fullPath);
		if (_isValid || !isSearchPath)
		{
			_rawRoot = root.Replace('/', '\\');
			_rawPath = path.Replace('/', '\\');
			_fullPath = fullPath.Replace('/', '\\');
		}
		if (_isValid)
		{
			if (!isSearchPath)
			{
				RemoveSearchReference();
			}
			else
			{
				AddSearchReference();
			}
		}
		return _isValid;
	}

	private static bool TryGetFileToValidate(string? root, string? path, out string fullPath)
	{
		fullPath = string.Empty;
		if (string.IsNullOrEmpty(root) || string.IsNullOrEmpty(path))
		{
			return false;
		}
		try
		{
			fullPath = Path.Combine(root, path);
			return true;
		}
		catch (Exception)
		{
			return false;
		}
	}

	private void AddSearchReference()
	{
		if (_searchReference == null)
		{
			_searchReference = new WeakReference<RelativePath>(this);
			lock (_searchRootPaths)
			{
				_searchRootPaths.Add(_searchReference);
			}
		}
	}

	private void RemoveSearchReference()
	{
		if (_searchReference != null)
		{
			lock (_searchRootPaths)
			{
				_searchRootPaths.Remove(_searchReference);
			}
			_searchReference = null;
		}
	}

	public override bool Equals(object? obj)
	{
		if (obj is RelativePath)
		{
			return Equals((RelativePath)obj);
		}
		return false;
	}

	public bool Equals(RelativePath? other)
	{
		if (_isResolved && !IsValid)
		{
			TryResolve(resolveImmediately: true);
		}
		if ((object)other != null && other._isResolved && !other.IsValid)
		{
			other.TryResolve(resolveImmediately: true);
		}
		if (IsValid != other?.IsValid)
		{
			return false;
		}
		if (!IsValid)
		{
			return string.Equals(FullPath, other.FullPath, StringComparison.OrdinalIgnoreCase);
		}
		if (FullPath != null && other.FullPath != null)
		{
			return FullPath.IsPathEqual(other.FullPath);
		}
		return false;
	}

	public override int GetHashCode()
	{
		if (!_hashCode.HasValue)
		{
			_hashCode = HashCodeHelper.GenerateHashCode(RawRoot, RawPath, FullPath);
		}
		return _hashCode.Value;
	}

	public static bool operator ==(RelativePath? lhs, RelativePath? rhs)
	{
		return lhs.NullableEquals(rhs);
	}

	public static bool operator !=(RelativePath? lhs, RelativePath? rhs)
	{
		return !lhs.NullableEquals(rhs);
	}

	public static implicit operator string(RelativePath? path)
	{
		return path?.FullPath ?? string.Empty;
	}

	public static explicit operator RelativePath(string path)
	{
		return new RelativePath(path);
	}
}
