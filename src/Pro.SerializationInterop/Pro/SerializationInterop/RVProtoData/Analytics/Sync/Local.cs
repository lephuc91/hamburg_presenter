using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.Sync;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class Local : IMessage<Local>, IMessage, IEquatable<Local>, IDeepCloneable<Local>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		public enum Type
		{
			[OriginalName("UP")]
			Up,
			[OriginalName("DOWN")]
			Down
		}
	}

	private static readonly MessageParser<Local> _parser = new MessageParser<Local>(() => new Local());

	private UnknownFieldSet _unknownFields;

	public const int SyncTypeFieldNumber = 1;

	private Types.Type syncType_;

	public const int IncludeLibraryFieldNumber = 2;

	private bool includeLibrary_;

	public const int IncludeMediaFieldNumber = 3;

	private bool includeMedia_;

	public const int IncludePlaylistsFieldNumber = 4;

	private bool includePlaylists_;

	public const int IncludeThemesFieldNumber = 5;

	private bool includeThemes_;

	public const int IncludeSupportFilesFieldNumber = 6;

	private bool includeSupportFiles_;

	public const int ReplaceFilesFieldNumber = 7;

	private bool replaceFiles_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<Local> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AnalyticsSyncReflection.Descriptor.MessageTypes[0];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Type SyncType
	{
		get
		{
			return syncType_;
		}
		set
		{
			syncType_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool IncludeLibrary
	{
		get
		{
			return includeLibrary_;
		}
		set
		{
			includeLibrary_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool IncludeMedia
	{
		get
		{
			return includeMedia_;
		}
		set
		{
			includeMedia_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool IncludePlaylists
	{
		get
		{
			return includePlaylists_;
		}
		set
		{
			includePlaylists_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool IncludeThemes
	{
		get
		{
			return includeThemes_;
		}
		set
		{
			includeThemes_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool IncludeSupportFiles
	{
		get
		{
			return includeSupportFiles_;
		}
		set
		{
			includeSupportFiles_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool ReplaceFiles
	{
		get
		{
			return replaceFiles_;
		}
		set
		{
			replaceFiles_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Local()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Local(Local other)
		: this()
	{
		syncType_ = other.syncType_;
		includeLibrary_ = other.includeLibrary_;
		includeMedia_ = other.includeMedia_;
		includePlaylists_ = other.includePlaylists_;
		includeThemes_ = other.includeThemes_;
		includeSupportFiles_ = other.includeSupportFiles_;
		replaceFiles_ = other.replaceFiles_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Local Clone()
	{
		return new Local(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as Local);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(Local other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (SyncType != other.SyncType)
		{
			return false;
		}
		if (IncludeLibrary != other.IncludeLibrary)
		{
			return false;
		}
		if (IncludeMedia != other.IncludeMedia)
		{
			return false;
		}
		if (IncludePlaylists != other.IncludePlaylists)
		{
			return false;
		}
		if (IncludeThemes != other.IncludeThemes)
		{
			return false;
		}
		if (IncludeSupportFiles != other.IncludeSupportFiles)
		{
			return false;
		}
		if (ReplaceFiles != other.ReplaceFiles)
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
		if (SyncType != 0)
		{
			num ^= SyncType.GetHashCode();
		}
		if (IncludeLibrary)
		{
			num ^= IncludeLibrary.GetHashCode();
		}
		if (IncludeMedia)
		{
			num ^= IncludeMedia.GetHashCode();
		}
		if (IncludePlaylists)
		{
			num ^= IncludePlaylists.GetHashCode();
		}
		if (IncludeThemes)
		{
			num ^= IncludeThemes.GetHashCode();
		}
		if (IncludeSupportFiles)
		{
			num ^= IncludeSupportFiles.GetHashCode();
		}
		if (ReplaceFiles)
		{
			num ^= ReplaceFiles.GetHashCode();
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
		if (SyncType != 0)
		{
			output.WriteRawTag(8);
			output.WriteEnum((int)SyncType);
		}
		if (IncludeLibrary)
		{
			output.WriteRawTag(16);
			output.WriteBool(IncludeLibrary);
		}
		if (IncludeMedia)
		{
			output.WriteRawTag(24);
			output.WriteBool(IncludeMedia);
		}
		if (IncludePlaylists)
		{
			output.WriteRawTag(32);
			output.WriteBool(IncludePlaylists);
		}
		if (IncludeThemes)
		{
			output.WriteRawTag(40);
			output.WriteBool(IncludeThemes);
		}
		if (IncludeSupportFiles)
		{
			output.WriteRawTag(48);
			output.WriteBool(IncludeSupportFiles);
		}
		if (ReplaceFiles)
		{
			output.WriteRawTag(56);
			output.WriteBool(ReplaceFiles);
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
		if (SyncType != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)SyncType);
		}
		if (IncludeLibrary)
		{
			num += 2;
		}
		if (IncludeMedia)
		{
			num += 2;
		}
		if (IncludePlaylists)
		{
			num += 2;
		}
		if (IncludeThemes)
		{
			num += 2;
		}
		if (IncludeSupportFiles)
		{
			num += 2;
		}
		if (ReplaceFiles)
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
	public void MergeFrom(Local other)
	{
		if (other != null)
		{
			if (other.SyncType != 0)
			{
				SyncType = other.SyncType;
			}
			if (other.IncludeLibrary)
			{
				IncludeLibrary = other.IncludeLibrary;
			}
			if (other.IncludeMedia)
			{
				IncludeMedia = other.IncludeMedia;
			}
			if (other.IncludePlaylists)
			{
				IncludePlaylists = other.IncludePlaylists;
			}
			if (other.IncludeThemes)
			{
				IncludeThemes = other.IncludeThemes;
			}
			if (other.IncludeSupportFiles)
			{
				IncludeSupportFiles = other.IncludeSupportFiles;
			}
			if (other.ReplaceFiles)
			{
				ReplaceFiles = other.ReplaceFiles;
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
				SyncType = (Types.Type)input.ReadEnum();
				break;
			case 16u:
				IncludeLibrary = input.ReadBool();
				break;
			case 24u:
				IncludeMedia = input.ReadBool();
				break;
			case 32u:
				IncludePlaylists = input.ReadBool();
				break;
			case 40u:
				IncludeThemes = input.ReadBool();
				break;
			case 48u:
				IncludeSupportFiles = input.ReadBool();
				break;
			case 56u:
				ReplaceFiles = input.ReadBool();
				break;
			}
		}
	}
}
