using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.MediaManagement.v2;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class Preferences : IMessage<Preferences>, IMessage, IEquatable<Preferences>, IDeepCloneable<Preferences>
{
	private static readonly MessageParser<Preferences> _parser = new MessageParser<Preferences>(() => new Preferences());

	private UnknownFieldSet _unknownFields;

	public const int ManageMediaFieldNumber = 1;

	private bool manageMedia_;

	public const int ShareAnalyticsFieldNumber = 2;

	private bool shareAnalytics_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<Preferences> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => V2HelperCommonReflection.Descriptor.MessageTypes[4];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool ManageMedia
	{
		get
		{
			return manageMedia_;
		}
		set
		{
			manageMedia_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool ShareAnalytics
	{
		get
		{
			return shareAnalytics_;
		}
		set
		{
			shareAnalytics_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Preferences()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Preferences(Preferences other)
		: this()
	{
		manageMedia_ = other.manageMedia_;
		shareAnalytics_ = other.shareAnalytics_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Preferences Clone()
	{
		return new Preferences(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as Preferences);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(Preferences other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (ManageMedia != other.ManageMedia)
		{
			return false;
		}
		if (ShareAnalytics != other.ShareAnalytics)
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
		if (ManageMedia)
		{
			num ^= ManageMedia.GetHashCode();
		}
		if (ShareAnalytics)
		{
			num ^= ShareAnalytics.GetHashCode();
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
		if (ManageMedia)
		{
			output.WriteRawTag(8);
			output.WriteBool(ManageMedia);
		}
		if (ShareAnalytics)
		{
			output.WriteRawTag(16);
			output.WriteBool(ShareAnalytics);
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
		if (ManageMedia)
		{
			num += 2;
		}
		if (ShareAnalytics)
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
	public void MergeFrom(Preferences other)
	{
		if (other != null)
		{
			if (other.ManageMedia)
			{
				ManageMedia = other.ManageMedia;
			}
			if (other.ShareAnalytics)
			{
				ShareAnalytics = other.ShareAnalytics;
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
				ManageMedia = input.ReadBool();
				break;
			case 16u:
				ShareAnalytics = input.ReadBool();
				break;
			}
		}
	}
}
