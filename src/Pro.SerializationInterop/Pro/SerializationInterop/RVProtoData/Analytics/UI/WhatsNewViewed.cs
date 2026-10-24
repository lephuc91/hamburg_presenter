using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.UI;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class WhatsNewViewed : IMessage<WhatsNewViewed>, IMessage, IEquatable<WhatsNewViewed>, IDeepCloneable<WhatsNewViewed>
{
	private static readonly MessageParser<WhatsNewViewed> _parser = new MessageParser<WhatsNewViewed>(() => new WhatsNewViewed());

	private UnknownFieldSet _unknownFields;

	public const int VersionFieldNumber = 1;

	private string version_ = "";

	public const int ViewTimeFieldNumber = 2;

	private int viewTime_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<WhatsNewViewed> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AnalyticsUIReflection.Descriptor.MessageTypes[58];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string Version
	{
		get
		{
			return version_;
		}
		set
		{
			version_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int ViewTime
	{
		get
		{
			return viewTime_;
		}
		set
		{
			viewTime_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public WhatsNewViewed()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public WhatsNewViewed(WhatsNewViewed other)
		: this()
	{
		version_ = other.version_;
		viewTime_ = other.viewTime_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public WhatsNewViewed Clone()
	{
		return new WhatsNewViewed(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as WhatsNewViewed);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(WhatsNewViewed other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (Version != other.Version)
		{
			return false;
		}
		if (ViewTime != other.ViewTime)
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
		if (Version.Length != 0)
		{
			num ^= Version.GetHashCode();
		}
		if (ViewTime != 0)
		{
			num ^= ViewTime.GetHashCode();
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
		if (Version.Length != 0)
		{
			output.WriteRawTag(10);
			output.WriteString(Version);
		}
		if (ViewTime != 0)
		{
			output.WriteRawTag(16);
			output.WriteInt32(ViewTime);
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
		if (Version.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Version);
		}
		if (ViewTime != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(ViewTime);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(WhatsNewViewed other)
	{
		if (other != null)
		{
			if (other.Version.Length != 0)
			{
				Version = other.Version;
			}
			if (other.ViewTime != 0)
			{
				ViewTime = other.ViewTime;
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
				Version = input.ReadString();
				break;
			case 16u:
				ViewTime = input.ReadInt32();
				break;
			}
		}
	}
}
