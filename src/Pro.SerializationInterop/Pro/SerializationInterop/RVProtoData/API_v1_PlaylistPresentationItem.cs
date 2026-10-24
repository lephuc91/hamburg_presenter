using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class API_v1_PlaylistPresentationItem : IMessage<API_v1_PlaylistPresentationItem>, IMessage, IEquatable<API_v1_PlaylistPresentationItem>, IDeepCloneable<API_v1_PlaylistPresentationItem>
{
	private static readonly MessageParser<API_v1_PlaylistPresentationItem> _parser = new MessageParser<API_v1_PlaylistPresentationItem>(() => new API_v1_PlaylistPresentationItem());

	private UnknownFieldSet _unknownFields;

	public const int PresentationUuidFieldNumber = 1;

	private string presentationUuid_ = "";

	public const int ArrangementNameFieldNumber = 2;

	private string arrangementName_ = "";

	public const int ArrangementUuidFieldNumber = 3;

	private string arrangementUuid_ = "";

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<API_v1_PlaylistPresentationItem> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProApiV1PresentationPlaylistItemReflection.Descriptor.MessageTypes[0];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string PresentationUuid
	{
		get
		{
			return presentationUuid_;
		}
		set
		{
			presentationUuid_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string ArrangementName
	{
		get
		{
			return arrangementName_;
		}
		set
		{
			arrangementName_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string ArrangementUuid
	{
		get
		{
			return arrangementUuid_;
		}
		set
		{
			arrangementUuid_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_PlaylistPresentationItem()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_PlaylistPresentationItem(API_v1_PlaylistPresentationItem other)
		: this()
	{
		presentationUuid_ = other.presentationUuid_;
		arrangementName_ = other.arrangementName_;
		arrangementUuid_ = other.arrangementUuid_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_PlaylistPresentationItem Clone()
	{
		return new API_v1_PlaylistPresentationItem(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as API_v1_PlaylistPresentationItem);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(API_v1_PlaylistPresentationItem other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (PresentationUuid != other.PresentationUuid)
		{
			return false;
		}
		if (ArrangementName != other.ArrangementName)
		{
			return false;
		}
		if (ArrangementUuid != other.ArrangementUuid)
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
		if (PresentationUuid.Length != 0)
		{
			num ^= PresentationUuid.GetHashCode();
		}
		if (ArrangementName.Length != 0)
		{
			num ^= ArrangementName.GetHashCode();
		}
		if (ArrangementUuid.Length != 0)
		{
			num ^= ArrangementUuid.GetHashCode();
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
		if (PresentationUuid.Length != 0)
		{
			output.WriteRawTag(10);
			output.WriteString(PresentationUuid);
		}
		if (ArrangementName.Length != 0)
		{
			output.WriteRawTag(18);
			output.WriteString(ArrangementName);
		}
		if (ArrangementUuid.Length != 0)
		{
			output.WriteRawTag(26);
			output.WriteString(ArrangementUuid);
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
		if (PresentationUuid.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(PresentationUuid);
		}
		if (ArrangementName.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(ArrangementName);
		}
		if (ArrangementUuid.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(ArrangementUuid);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(API_v1_PlaylistPresentationItem other)
	{
		if (other != null)
		{
			if (other.PresentationUuid.Length != 0)
			{
				PresentationUuid = other.PresentationUuid;
			}
			if (other.ArrangementName.Length != 0)
			{
				ArrangementName = other.ArrangementName;
			}
			if (other.ArrangementUuid.Length != 0)
			{
				ArrangementUuid = other.ArrangementUuid;
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
				PresentationUuid = input.ReadString();
				break;
			case 18u:
				ArrangementName = input.ReadString();
				break;
			case 26u:
				ArrangementUuid = input.ReadString();
				break;
			}
		}
	}
}
