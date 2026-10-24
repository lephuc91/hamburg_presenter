using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class URL : IMessage<URL>, IMessage, IEquatable<URL>, IDeepCloneable<URL>
{
	public enum StorageOneofCase
	{
		None,
		AbsoluteString,
		RelativePath
	}

	public enum RelativeFilePathOneofCase
	{
		None = 0,
		Local = 4,
		External = 5
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		public enum Platform
		{
			[OriginalName("PLATFORM_UNKNOWN")]
			Unknown,
			[OriginalName("PLATFORM_MACOS")]
			Macos,
			[OriginalName("PLATFORM_WIN32")]
			Win32,
			[OriginalName("PLATFORM_WEB")]
			Web
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class LocalRelativePath : IMessage<LocalRelativePath>, IMessage, IEquatable<LocalRelativePath>, IDeepCloneable<LocalRelativePath>
		{
			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				public enum Root
				{
					[OriginalName("ROOT_UNKNOWN")]
					Unknown = 0,
					[OriginalName("ROOT_BOOT_VOLUME")]
					BootVolume = 1,
					[OriginalName("ROOT_USER_HOME")]
					UserHome = 2,
					[OriginalName("ROOT_USER_DOCUMENTS")]
					UserDocuments = 3,
					[OriginalName("ROOT_USER_DOWNLOADS")]
					UserDownloads = 4,
					[OriginalName("ROOT_USER_MUSIC")]
					UserMusic = 5,
					[OriginalName("ROOT_USER_PICTURES")]
					UserPictures = 6,
					[OriginalName("ROOT_USER_VIDEOS")]
					UserVideos = 7,
					[OriginalName("ROOT_USER_DESKTOP")]
					UserDesktop = 11,
					[OriginalName("ROOT_USER_APP_SUPPORT")]
					UserAppSupport = 8,
					[OriginalName("ROOT_SHARED")]
					Shared = 9,
					[OriginalName("ROOT_SHOW")]
					Show = 10,
					[OriginalName("ROOT_CURRENT_RESOURCE")]
					CurrentResource = 12
				}
			}

			private static readonly MessageParser<LocalRelativePath> _parser = new MessageParser<LocalRelativePath>(() => new LocalRelativePath());

			private UnknownFieldSet _unknownFields;

			public const int RootFieldNumber = 1;

			private Types.Root root_;

			public const int PathFieldNumber = 2;

			private string path_ = "";

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<LocalRelativePath> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => URL.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.Root Root
			{
				get
				{
					return root_;
				}
				set
				{
					root_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string Path
			{
				get
				{
					return path_;
				}
				set
				{
					path_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public LocalRelativePath()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public LocalRelativePath(LocalRelativePath other)
				: this()
			{
				root_ = other.root_;
				path_ = other.path_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public LocalRelativePath Clone()
			{
				return new LocalRelativePath(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as LocalRelativePath);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(LocalRelativePath other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (Root != other.Root)
				{
					return false;
				}
				if (Path != other.Path)
				{
					return false;
				}
				return object.Equals(_unknownFields, other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override int GetHashCode()
			{
				int num = 1;
				if (Root != 0)
				{
					num ^= Root.GetHashCode();
				}
				if (Path.Length != 0)
				{
					num ^= Path.GetHashCode();
				}
				if (_unknownFields != null)
				{
					num ^= _unknownFields.GetHashCode();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override string ToString()
			{
				return JsonFormatter.ToDiagnosticString(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void WriteTo(CodedOutputStream output)
			{
				if (Root != 0)
				{
					output.WriteRawTag(8);
					output.WriteEnum((int)Root);
				}
				if (Path.Length != 0)
				{
					output.WriteRawTag(18);
					output.WriteString(Path);
				}
				if (_unknownFields != null)
				{
					_unknownFields.WriteTo(output);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public int CalculateSize()
			{
				int num = 0;
				if (Root != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)Root);
				}
				if (Path.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Path);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(LocalRelativePath other)
			{
				if (other != null)
				{
					if (other.Root != 0)
					{
						Root = other.Root;
					}
					if (other.Path.Length != 0)
					{
						Path = other.Path;
					}
					_unknownFields = UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(CodedInputStream input)
			{
				uint num;
				while ((num = input.ReadTag()) != 0 && (num & 7) != 4)
				{
					switch (num)
					{
					default:
						_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
						break;
					case 8u:
						Root = (Types.Root)input.ReadEnum();
						break;
					case 18u:
						Path = input.ReadString();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class ExternalRelativePath : IMessage<ExternalRelativePath>, IMessage, IEquatable<ExternalRelativePath>, IDeepCloneable<ExternalRelativePath>
		{
			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class MacOSExternalVolume : IMessage<MacOSExternalVolume>, IMessage, IEquatable<MacOSExternalVolume>, IDeepCloneable<MacOSExternalVolume>
				{
					private static readonly MessageParser<MacOSExternalVolume> _parser = new MessageParser<MacOSExternalVolume>(() => new MacOSExternalVolume());

					private UnknownFieldSet _unknownFields;

					public const int VolumeNameFieldNumber = 1;

					private string volumeName_ = "";

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<MacOSExternalVolume> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => ExternalRelativePath.Descriptor.NestedTypes[0];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public string VolumeName
					{
						get
						{
							return volumeName_;
						}
						set
						{
							volumeName_ = ProtoPreconditions.CheckNotNull(value, "value");
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public MacOSExternalVolume()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public MacOSExternalVolume(MacOSExternalVolume other)
						: this()
					{
						volumeName_ = other.volumeName_;
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public MacOSExternalVolume Clone()
					{
						return new MacOSExternalVolume(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as MacOSExternalVolume);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(MacOSExternalVolume other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (VolumeName != other.VolumeName)
						{
							return false;
						}
						return object.Equals(_unknownFields, other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override int GetHashCode()
					{
						int num = 1;
						if (VolumeName.Length != 0)
						{
							num ^= VolumeName.GetHashCode();
						}
						if (_unknownFields != null)
						{
							num ^= _unknownFields.GetHashCode();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override string ToString()
					{
						return JsonFormatter.ToDiagnosticString(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void WriteTo(CodedOutputStream output)
					{
						if (VolumeName.Length != 0)
						{
							output.WriteRawTag(10);
							output.WriteString(VolumeName);
						}
						if (_unknownFields != null)
						{
							_unknownFields.WriteTo(output);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public int CalculateSize()
					{
						int num = 0;
						if (VolumeName.Length != 0)
						{
							num += 1 + CodedOutputStream.ComputeStringSize(VolumeName);
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(MacOSExternalVolume other)
					{
						if (other != null)
						{
							if (other.VolumeName.Length != 0)
							{
								VolumeName = other.VolumeName;
							}
							_unknownFields = UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(CodedInputStream input)
					{
						uint num;
						while ((num = input.ReadTag()) != 0 && (num & 7) != 4)
						{
							if (num != 10)
							{
								_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
							}
							else
							{
								VolumeName = input.ReadString();
							}
						}
					}
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class Win32ExternalVolume : IMessage<Win32ExternalVolume>, IMessage, IEquatable<Win32ExternalVolume>, IDeepCloneable<Win32ExternalVolume>
				{
					private static readonly MessageParser<Win32ExternalVolume> _parser = new MessageParser<Win32ExternalVolume>(() => new Win32ExternalVolume());

					private UnknownFieldSet _unknownFields;

					public const int DriveLetterFieldNumber = 1;

					private string driveLetter_ = "";

					public const int VolumeNameFieldNumber = 2;

					private string volumeName_ = "";

					public const int NetworkShareFieldNumber = 3;

					private bool networkShare_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<Win32ExternalVolume> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => ExternalRelativePath.Descriptor.NestedTypes[1];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public string DriveLetter
					{
						get
						{
							return driveLetter_;
						}
						set
						{
							driveLetter_ = ProtoPreconditions.CheckNotNull(value, "value");
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public string VolumeName
					{
						get
						{
							return volumeName_;
						}
						set
						{
							volumeName_ = ProtoPreconditions.CheckNotNull(value, "value");
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool NetworkShare
					{
						get
						{
							return networkShare_;
						}
						set
						{
							networkShare_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Win32ExternalVolume()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Win32ExternalVolume(Win32ExternalVolume other)
						: this()
					{
						driveLetter_ = other.driveLetter_;
						volumeName_ = other.volumeName_;
						networkShare_ = other.networkShare_;
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Win32ExternalVolume Clone()
					{
						return new Win32ExternalVolume(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as Win32ExternalVolume);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(Win32ExternalVolume other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (DriveLetter != other.DriveLetter)
						{
							return false;
						}
						if (VolumeName != other.VolumeName)
						{
							return false;
						}
						if (NetworkShare != other.NetworkShare)
						{
							return false;
						}
						return object.Equals(_unknownFields, other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override int GetHashCode()
					{
						int num = 1;
						if (DriveLetter.Length != 0)
						{
							num ^= DriveLetter.GetHashCode();
						}
						if (VolumeName.Length != 0)
						{
							num ^= VolumeName.GetHashCode();
						}
						if (NetworkShare)
						{
							num ^= NetworkShare.GetHashCode();
						}
						if (_unknownFields != null)
						{
							num ^= _unknownFields.GetHashCode();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override string ToString()
					{
						return JsonFormatter.ToDiagnosticString(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void WriteTo(CodedOutputStream output)
					{
						if (DriveLetter.Length != 0)
						{
							output.WriteRawTag(10);
							output.WriteString(DriveLetter);
						}
						if (VolumeName.Length != 0)
						{
							output.WriteRawTag(18);
							output.WriteString(VolumeName);
						}
						if (NetworkShare)
						{
							output.WriteRawTag(24);
							output.WriteBool(NetworkShare);
						}
						if (_unknownFields != null)
						{
							_unknownFields.WriteTo(output);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public int CalculateSize()
					{
						int num = 0;
						if (DriveLetter.Length != 0)
						{
							num += 1 + CodedOutputStream.ComputeStringSize(DriveLetter);
						}
						if (VolumeName.Length != 0)
						{
							num += 1 + CodedOutputStream.ComputeStringSize(VolumeName);
						}
						if (NetworkShare)
						{
							num += 2;
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(Win32ExternalVolume other)
					{
						if (other != null)
						{
							if (other.DriveLetter.Length != 0)
							{
								DriveLetter = other.DriveLetter;
							}
							if (other.VolumeName.Length != 0)
							{
								VolumeName = other.VolumeName;
							}
							if (other.NetworkShare)
							{
								NetworkShare = other.NetworkShare;
							}
							_unknownFields = UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(CodedInputStream input)
					{
						uint num;
						while ((num = input.ReadTag()) != 0 && (num & 7) != 4)
						{
							switch (num)
							{
							default:
								_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
								break;
							case 10u:
								DriveLetter = input.ReadString();
								break;
							case 18u:
								VolumeName = input.ReadString();
								break;
							case 24u:
								NetworkShare = input.ReadBool();
								break;
							}
						}
					}
				}
			}

			private static readonly MessageParser<ExternalRelativePath> _parser = new MessageParser<ExternalRelativePath>(() => new ExternalRelativePath());

			private UnknownFieldSet _unknownFields;

			public const int MacosFieldNumber = 1;

			private Types.MacOSExternalVolume macos_;

			public const int Win32FieldNumber = 2;

			private Types.Win32ExternalVolume win32_;

			public const int PathFieldNumber = 3;

			private string path_ = "";

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<ExternalRelativePath> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => URL.Descriptor.NestedTypes[1];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.MacOSExternalVolume Macos
			{
				get
				{
					return macos_;
				}
				set
				{
					macos_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.Win32ExternalVolume Win32
			{
				get
				{
					return win32_;
				}
				set
				{
					win32_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string Path
			{
				get
				{
					return path_;
				}
				set
				{
					path_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ExternalRelativePath()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ExternalRelativePath(ExternalRelativePath other)
				: this()
			{
				macos_ = ((other.macos_ != null) ? other.macos_.Clone() : null);
				win32_ = ((other.win32_ != null) ? other.win32_.Clone() : null);
				path_ = other.path_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ExternalRelativePath Clone()
			{
				return new ExternalRelativePath(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as ExternalRelativePath);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(ExternalRelativePath other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(Macos, other.Macos))
				{
					return false;
				}
				if (!object.Equals(Win32, other.Win32))
				{
					return false;
				}
				if (Path != other.Path)
				{
					return false;
				}
				return object.Equals(_unknownFields, other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override int GetHashCode()
			{
				int num = 1;
				if (macos_ != null)
				{
					num ^= Macos.GetHashCode();
				}
				if (win32_ != null)
				{
					num ^= Win32.GetHashCode();
				}
				if (Path.Length != 0)
				{
					num ^= Path.GetHashCode();
				}
				if (_unknownFields != null)
				{
					num ^= _unknownFields.GetHashCode();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override string ToString()
			{
				return JsonFormatter.ToDiagnosticString(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void WriteTo(CodedOutputStream output)
			{
				if (macos_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Macos);
				}
				if (win32_ != null)
				{
					output.WriteRawTag(18);
					output.WriteMessage(Win32);
				}
				if (Path.Length != 0)
				{
					output.WriteRawTag(26);
					output.WriteString(Path);
				}
				if (_unknownFields != null)
				{
					_unknownFields.WriteTo(output);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public int CalculateSize()
			{
				int num = 0;
				if (macos_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Macos);
				}
				if (win32_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Win32);
				}
				if (Path.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Path);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(ExternalRelativePath other)
			{
				if (other == null)
				{
					return;
				}
				if (other.macos_ != null)
				{
					if (macos_ == null)
					{
						Macos = new Types.MacOSExternalVolume();
					}
					Macos.MergeFrom(other.Macos);
				}
				if (other.win32_ != null)
				{
					if (win32_ == null)
					{
						Win32 = new Types.Win32ExternalVolume();
					}
					Win32.MergeFrom(other.Win32);
				}
				if (other.Path.Length != 0)
				{
					Path = other.Path;
				}
				_unknownFields = UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(CodedInputStream input)
			{
				uint num;
				while ((num = input.ReadTag()) != 0 && (num & 7) != 4)
				{
					switch (num)
					{
					default:
						_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
						break;
					case 10u:
						if (macos_ == null)
						{
							Macos = new Types.MacOSExternalVolume();
						}
						input.ReadMessage(Macos);
						break;
					case 18u:
						if (win32_ == null)
						{
							Win32 = new Types.Win32ExternalVolume();
						}
						input.ReadMessage(Win32);
						break;
					case 26u:
						Path = input.ReadString();
						break;
					}
				}
			}
		}
	}

	private static readonly MessageParser<URL> _parser = new MessageParser<URL>(() => new URL());

	private UnknownFieldSet _unknownFields;

	public const int AbsoluteStringFieldNumber = 1;

	public const int RelativePathFieldNumber = 2;

	public const int PlatformFieldNumber = 3;

	private Types.Platform platform_;

	public const int LocalFieldNumber = 4;

	public const int ExternalFieldNumber = 5;

	private object storage_;

	private StorageOneofCase storageCase_;

	private object relativeFilePath_;

	private RelativeFilePathOneofCase relativeFilePathCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<URL> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => UrlReflection.Descriptor.MessageTypes[0];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string AbsoluteString
	{
		get
		{
			if (!HasAbsoluteString)
			{
				return "";
			}
			return (string)storage_;
		}
		set
		{
			storage_ = ProtoPreconditions.CheckNotNull(value, "value");
			storageCase_ = StorageOneofCase.AbsoluteString;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool HasAbsoluteString => storageCase_ == StorageOneofCase.AbsoluteString;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string RelativePath
	{
		get
		{
			if (!HasRelativePath)
			{
				return "";
			}
			return (string)storage_;
		}
		set
		{
			storage_ = ProtoPreconditions.CheckNotNull(value, "value");
			storageCase_ = StorageOneofCase.RelativePath;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool HasRelativePath => storageCase_ == StorageOneofCase.RelativePath;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Platform Platform
	{
		get
		{
			return platform_;
		}
		set
		{
			platform_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.LocalRelativePath Local
	{
		get
		{
			if (relativeFilePathCase_ != RelativeFilePathOneofCase.Local)
			{
				return null;
			}
			return (Types.LocalRelativePath)relativeFilePath_;
		}
		set
		{
			relativeFilePath_ = value;
			relativeFilePathCase_ = ((value != null) ? RelativeFilePathOneofCase.Local : RelativeFilePathOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.ExternalRelativePath External
	{
		get
		{
			if (relativeFilePathCase_ != RelativeFilePathOneofCase.External)
			{
				return null;
			}
			return (Types.ExternalRelativePath)relativeFilePath_;
		}
		set
		{
			relativeFilePath_ = value;
			relativeFilePathCase_ = ((value != null) ? RelativeFilePathOneofCase.External : RelativeFilePathOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public StorageOneofCase StorageCase => storageCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RelativeFilePathOneofCase RelativeFilePathCase => relativeFilePathCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public URL()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public URL(URL other)
		: this()
	{
		platform_ = other.platform_;
		switch (other.StorageCase)
		{
		case StorageOneofCase.AbsoluteString:
			AbsoluteString = other.AbsoluteString;
			break;
		case StorageOneofCase.RelativePath:
			RelativePath = other.RelativePath;
			break;
		}
		switch (other.RelativeFilePathCase)
		{
		case RelativeFilePathOneofCase.Local:
			Local = other.Local.Clone();
			break;
		case RelativeFilePathOneofCase.External:
			External = other.External.Clone();
			break;
		}
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public URL Clone()
	{
		return new URL(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void ClearAbsoluteString()
	{
		if (HasAbsoluteString)
		{
			ClearStorage();
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void ClearRelativePath()
	{
		if (HasRelativePath)
		{
			ClearStorage();
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void ClearStorage()
	{
		storageCase_ = StorageOneofCase.None;
		storage_ = null;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void ClearRelativeFilePath()
	{
		relativeFilePathCase_ = RelativeFilePathOneofCase.None;
		relativeFilePath_ = null;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as URL);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(URL other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (AbsoluteString != other.AbsoluteString)
		{
			return false;
		}
		if (RelativePath != other.RelativePath)
		{
			return false;
		}
		if (Platform != other.Platform)
		{
			return false;
		}
		if (!object.Equals(Local, other.Local))
		{
			return false;
		}
		if (!object.Equals(External, other.External))
		{
			return false;
		}
		if (StorageCase != other.StorageCase)
		{
			return false;
		}
		if (RelativeFilePathCase != other.RelativeFilePathCase)
		{
			return false;
		}
		return object.Equals(_unknownFields, other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override int GetHashCode()
	{
		int num = 1;
		if (HasAbsoluteString)
		{
			num ^= AbsoluteString.GetHashCode();
		}
		if (HasRelativePath)
		{
			num ^= RelativePath.GetHashCode();
		}
		if (Platform != 0)
		{
			num ^= Platform.GetHashCode();
		}
		if (relativeFilePathCase_ == RelativeFilePathOneofCase.Local)
		{
			num ^= Local.GetHashCode();
		}
		if (relativeFilePathCase_ == RelativeFilePathOneofCase.External)
		{
			num ^= External.GetHashCode();
		}
		num ^= (int)storageCase_;
		num ^= (int)relativeFilePathCase_;
		if (_unknownFields != null)
		{
			num ^= _unknownFields.GetHashCode();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override string ToString()
	{
		return JsonFormatter.ToDiagnosticString(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void WriteTo(CodedOutputStream output)
	{
		if (HasAbsoluteString)
		{
			output.WriteRawTag(10);
			output.WriteString(AbsoluteString);
		}
		if (HasRelativePath)
		{
			output.WriteRawTag(18);
			output.WriteString(RelativePath);
		}
		if (Platform != 0)
		{
			output.WriteRawTag(24);
			output.WriteEnum((int)Platform);
		}
		if (relativeFilePathCase_ == RelativeFilePathOneofCase.Local)
		{
			output.WriteRawTag(34);
			output.WriteMessage(Local);
		}
		if (relativeFilePathCase_ == RelativeFilePathOneofCase.External)
		{
			output.WriteRawTag(42);
			output.WriteMessage(External);
		}
		if (_unknownFields != null)
		{
			_unknownFields.WriteTo(output);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int CalculateSize()
	{
		int num = 0;
		if (HasAbsoluteString)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(AbsoluteString);
		}
		if (HasRelativePath)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(RelativePath);
		}
		if (Platform != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)Platform);
		}
		if (relativeFilePathCase_ == RelativeFilePathOneofCase.Local)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Local);
		}
		if (relativeFilePathCase_ == RelativeFilePathOneofCase.External)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(External);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(URL other)
	{
		if (other == null)
		{
			return;
		}
		if (other.Platform != 0)
		{
			Platform = other.Platform;
		}
		switch (other.StorageCase)
		{
		case StorageOneofCase.AbsoluteString:
			AbsoluteString = other.AbsoluteString;
			break;
		case StorageOneofCase.RelativePath:
			RelativePath = other.RelativePath;
			break;
		}
		switch (other.RelativeFilePathCase)
		{
		case RelativeFilePathOneofCase.Local:
			if (Local == null)
			{
				Local = new Types.LocalRelativePath();
			}
			Local.MergeFrom(other.Local);
			break;
		case RelativeFilePathOneofCase.External:
			if (External == null)
			{
				External = new Types.ExternalRelativePath();
			}
			External.MergeFrom(other.External);
			break;
		}
		_unknownFields = UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(CodedInputStream input)
	{
		uint num;
		while ((num = input.ReadTag()) != 0 && (num & 7) != 4)
		{
			switch (num)
			{
			default:
				_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
				break;
			case 10u:
				AbsoluteString = input.ReadString();
				break;
			case 18u:
				RelativePath = input.ReadString();
				break;
			case 24u:
				Platform = (Types.Platform)input.ReadEnum();
				break;
			case 34u:
			{
				Types.LocalRelativePath localRelativePath = new Types.LocalRelativePath();
				if (relativeFilePathCase_ == RelativeFilePathOneofCase.Local)
				{
					localRelativePath.MergeFrom(Local);
				}
				input.ReadMessage(localRelativePath);
				Local = localRelativePath;
				break;
			}
			case 42u:
			{
				Types.ExternalRelativePath externalRelativePath = new Types.ExternalRelativePath();
				if (relativeFilePathCase_ == RelativeFilePathOneofCase.External)
				{
					externalRelativePath.MergeFrom(External);
				}
				input.ReadMessage(externalRelativePath);
				External = externalRelativePath;
				break;
			}
			}
		}
	}
}
