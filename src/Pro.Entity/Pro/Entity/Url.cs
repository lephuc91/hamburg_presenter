using System;
using System.Collections.Generic;
using Pro.Entity.Extensions;
using Pro.Loro;

namespace Pro.Entity;

public record Url(Types.Platform Platform, Types.Storage Storage, Types.RelativeFilePath RelativeFilePath)
{
	public class Types
	{
		public record ExternalRelativePath(Types.MacOsExternalVolume Macos, Types.Win32ExternalVolume Win32, string Path)
		{
			public class Types
			{
				public record MacOsExternalVolume(string VolumeName)
				{
					public virtual bool Equals(MacOsExternalVolume? other)
					{
						if ((object)other != null)
						{
							return VolumeName == other.VolumeName;
						}
						return false;
					}

					public override int GetHashCode()
					{
						HashCode hashCode = default(HashCode);
						hashCode.Add(VolumeName);
						return hashCode.ToHashCode();
					}
				}

				internal static class MacOsExternalVolumeExtension
				{
					internal static MacOsExternalVolume Deserialize(Dictionary<string, LoroValue> map)
					{
						return new MacOsExternalVolume(map.GetString("volume_name__1"));
					}

					internal static MacOsExternalVolume CreateDefault()
					{
						return new MacOsExternalVolume(string.Empty);
					}

					public static LoroValue Serialize(MacOsExternalVolume instance)
					{
						LoroMap loroMap = new LoroMap();
						loroMap.Insert("volume_name__1", instance.VolumeName.ToLoroValueLike());
						return loroMap.GetDeepValue();
					}
				}

				public record Win32ExternalVolume(string DriveLetter, string VolumeName, bool NetworkShare)
				{
					public virtual bool Equals(Win32ExternalVolume? other)
					{
						if ((object)other != null && DriveLetter == other.DriveLetter && VolumeName == other.VolumeName)
						{
							return NetworkShare == other.NetworkShare;
						}
						return false;
					}

					public override int GetHashCode()
					{
						HashCode hashCode = default(HashCode);
						hashCode.Add(DriveLetter);
						hashCode.Add(VolumeName);
						hashCode.Add(NetworkShare);
						return hashCode.ToHashCode();
					}
				}

				internal static class Win32ExternalVolumeExtension
				{
					internal static Win32ExternalVolume Deserialize(Dictionary<string, LoroValue> map)
					{
						return new Win32ExternalVolume(map.GetString("drive_letter__1"), map.GetString("volume_name__2"), map.GetBool("network_share__3"));
					}

					internal static Win32ExternalVolume CreateDefault()
					{
						return new Win32ExternalVolume(string.Empty, string.Empty, NetworkShare: false);
					}

					public static LoroValue Serialize(Win32ExternalVolume instance)
					{
						LoroMap loroMap = new LoroMap();
						loroMap.Insert("drive_letter__1", instance.DriveLetter.ToLoroValueLike());
						loroMap.Insert("volume_name__2", instance.VolumeName.ToLoroValueLike());
						loroMap.Insert("network_share__3", instance.NetworkShare.ToLoroValueLike());
						return loroMap.GetDeepValue();
					}
				}
			}

			public virtual bool Equals(ExternalRelativePath? other)
			{
				if ((object)other != null && Macos == other.Macos && Win32 == other.Win32)
				{
					return Path == other.Path;
				}
				return false;
			}

			public override int GetHashCode()
			{
				HashCode hashCode = default(HashCode);
				hashCode.Add(Macos);
				hashCode.Add(Win32);
				hashCode.Add(Path);
				return hashCode.ToHashCode();
			}
		}

		internal static class ExternalRelativePathExtension
		{
			internal static ExternalRelativePath Deserialize(Dictionary<string, LoroValue> map)
			{
				return new ExternalRelativePath(ExternalRelativePath.Types.MacOsExternalVolumeExtension.Deserialize(map.GetMap("macos__1")), ExternalRelativePath.Types.Win32ExternalVolumeExtension.Deserialize(map.GetMap("win32__2")), map.GetString("path__3"));
			}

			internal static ExternalRelativePath CreateDefault()
			{
				return new ExternalRelativePath(ExternalRelativePath.Types.MacOsExternalVolumeExtension.CreateDefault(), ExternalRelativePath.Types.Win32ExternalVolumeExtension.CreateDefault(), string.Empty);
			}

			public static LoroValue Serialize(ExternalRelativePath instance)
			{
				LoroMap loroMap = new LoroMap();
				loroMap.Insert("macos__1", ExternalRelativePath.Types.MacOsExternalVolumeExtension.Serialize(instance.Macos).AsValueLike());
				loroMap.Insert("win32__2", ExternalRelativePath.Types.Win32ExternalVolumeExtension.Serialize(instance.Win32).AsValueLike());
				loroMap.Insert("path__3", instance.Path.ToLoroValueLike());
				return loroMap.GetDeepValue();
			}
		}

		public record LocalRelativePath(Types.Root Root, string Path)
		{
			public class Types
			{
				public enum Root
				{
					Unknown,
					BootVolume,
					UserHome,
					UserDocuments,
					UserDownloads,
					UserMusic,
					UserPictures,
					UserVideos,
					UserAppSupport,
					Shared,
					Show,
					UserDesktop,
					CurrentResource
				}
			}

			public virtual bool Equals(LocalRelativePath? other)
			{
				if ((object)other != null && Root == other.Root)
				{
					return Path == other.Path;
				}
				return false;
			}

			public override int GetHashCode()
			{
				HashCode hashCode = default(HashCode);
				hashCode.Add(Root);
				hashCode.Add(Path);
				return hashCode.ToHashCode();
			}
		}

		internal static class LocalRelativePathExtension
		{
			internal static LocalRelativePath Deserialize(Dictionary<string, LoroValue> map)
			{
				return new LocalRelativePath(map.GetEnum<LocalRelativePath.Types.Root>("root__1"), map.GetString("path__2"));
			}

			internal static LocalRelativePath CreateDefault()
			{
				return new LocalRelativePath(LocalRelativePath.Types.Root.Unknown, string.Empty);
			}

			public static LoroValue Serialize(LocalRelativePath instance)
			{
				LoroMap loroMap = new LoroMap();
				loroMap.Insert("root__1", instance.Root.ToLoroValueLike());
				loroMap.Insert("path__2", instance.Path.ToLoroValueLike());
				return loroMap.GetDeepValue();
			}
		}

		public enum Platform
		{
			Unknown,
			Macos,
			Win32,
			Web
		}

		public abstract record Storage
		{
			public record AbsoluteString(string _AbsoluteString) : Storage()
			{
				public virtual bool Equals(AbsoluteString? other)
				{
					if ((object)other != null)
					{
						return _AbsoluteString == other._AbsoluteString;
					}
					return false;
				}

				public override int GetHashCode()
				{
					HashCode hashCode = default(HashCode);
					hashCode.Add(_AbsoluteString);
					return hashCode.ToHashCode();
				}

				internal override LoroValue Serialize()
				{
					LoroMap loroMap = new LoroMap();
					loroMap.Insert("absolute_string__1", _AbsoluteString.ToLoroValueLike());
					loroMap.Insert("__tag", "absolute_string__1".ToLoroValueLike());
					return loroMap.GetDeepValue();
				}
			}

			public record RelativePath(string _RelativePath) : Storage()
			{
				public virtual bool Equals(RelativePath? other)
				{
					if ((object)other != null)
					{
						return _RelativePath == other._RelativePath;
					}
					return false;
				}

				public override int GetHashCode()
				{
					HashCode hashCode = default(HashCode);
					hashCode.Add(_RelativePath);
					return hashCode.ToHashCode();
				}

				internal override LoroValue Serialize()
				{
					LoroMap loroMap = new LoroMap();
					loroMap.Insert("relative_path__2", _RelativePath.ToLoroValueLike());
					loroMap.Insert("__tag", "relative_path__2".ToLoroValueLike());
					return loroMap.GetDeepValue();
				}
			}

			internal abstract LoroValue Serialize();
		}

		internal static class StorageExtension
		{
			internal static Storage Deserialize(Dictionary<string, LoroValue> map)
			{
				if (map.GetString("__tag") == "relative_path__2")
				{
					return new Storage.RelativePath(map.GetString("relative_path__2"));
				}
				return new Storage.AbsoluteString(map.GetString("absolute_string__1"));
			}

			internal static Storage CreateDefault()
			{
				return new Storage.AbsoluteString(string.Empty);
			}

			public static LoroValue Serialize(Storage instance)
			{
				return instance.Serialize();
			}
		}

		public abstract record RelativeFilePath
		{
			public record Local(LocalRelativePath _Local) : RelativeFilePath()
			{
				public virtual bool Equals(Local? other)
				{
					if ((object)other != null)
					{
						return _Local == other._Local;
					}
					return false;
				}

				public override int GetHashCode()
				{
					HashCode hashCode = default(HashCode);
					hashCode.Add(_Local);
					return hashCode.ToHashCode();
				}

				internal override LoroValue Serialize()
				{
					LoroMap loroMap = new LoroMap();
					loroMap.Insert("local__4", LocalRelativePathExtension.Serialize(_Local).AsValueLike());
					loroMap.Insert("__tag", "local__4".ToLoroValueLike());
					return loroMap.GetDeepValue();
				}
			}

			public record External(ExternalRelativePath _External) : RelativeFilePath()
			{
				public virtual bool Equals(External? other)
				{
					if ((object)other != null)
					{
						return _External == other._External;
					}
					return false;
				}

				public override int GetHashCode()
				{
					HashCode hashCode = default(HashCode);
					hashCode.Add(_External);
					return hashCode.ToHashCode();
				}

				internal override LoroValue Serialize()
				{
					LoroMap loroMap = new LoroMap();
					loroMap.Insert("external__5", ExternalRelativePathExtension.Serialize(_External).AsValueLike());
					loroMap.Insert("__tag", "external__5".ToLoroValueLike());
					return loroMap.GetDeepValue();
				}
			}

			internal abstract LoroValue Serialize();
		}

		internal static class RelativeFilePathExtension
		{
			internal static RelativeFilePath Deserialize(Dictionary<string, LoroValue> map)
			{
				if (map.GetString("__tag") == "external__5")
				{
					return new RelativeFilePath.External(ExternalRelativePathExtension.Deserialize(map.GetMap("external__5")));
				}
				return new RelativeFilePath.Local(LocalRelativePathExtension.Deserialize(map.GetMap("local__4")));
			}

			internal static RelativeFilePath CreateDefault()
			{
				return new RelativeFilePath.Local(LocalRelativePathExtension.CreateDefault());
			}

			public static LoroValue Serialize(RelativeFilePath instance)
			{
				return instance.Serialize();
			}
		}
	}

	public virtual bool Equals(Url? other)
	{
		if ((object)other != null && Platform == other.Platform && Storage == other.Storage)
		{
			return RelativeFilePath == other.RelativeFilePath;
		}
		return false;
	}

	public override int GetHashCode()
	{
		HashCode hashCode = default(HashCode);
		hashCode.Add(Platform);
		hashCode.Add(Storage);
		hashCode.Add(RelativeFilePath);
		return hashCode.ToHashCode();
	}
}
