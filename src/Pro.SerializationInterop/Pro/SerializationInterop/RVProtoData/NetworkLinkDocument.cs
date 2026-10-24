using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class NetworkLinkDocument : IMessage<NetworkLinkDocument>, IMessage, IEquatable<NetworkLinkDocument>, IDeepCloneable<NetworkLinkDocument>
{
	private static readonly MessageParser<NetworkLinkDocument> _parser = new MessageParser<NetworkLinkDocument>(() => new NetworkLinkDocument());

	private UnknownFieldSet _unknownFields;

	public const int GroupInfoFieldNumber = 1;

	private ProLink.Types.GroupDefinition groupInfo_;

	public const int ApplicationInfoFieldNumber = 2;

	private ApplicationInfo applicationInfo_;

	public const int EnabledFieldNumber = 3;

	private bool enabled_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<NetworkLinkDocument> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => NetworklinkReflection.Descriptor.MessageTypes[0];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ProLink.Types.GroupDefinition GroupInfo
	{
		get
		{
			return groupInfo_;
		}
		set
		{
			groupInfo_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ApplicationInfo ApplicationInfo
	{
		get
		{
			return applicationInfo_;
		}
		set
		{
			applicationInfo_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Enabled
	{
		get
		{
			return enabled_;
		}
		set
		{
			enabled_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public NetworkLinkDocument()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public NetworkLinkDocument(NetworkLinkDocument other)
		: this()
	{
		groupInfo_ = ((other.groupInfo_ != null) ? other.groupInfo_.Clone() : null);
		applicationInfo_ = ((other.applicationInfo_ != null) ? other.applicationInfo_.Clone() : null);
		enabled_ = other.enabled_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public NetworkLinkDocument Clone()
	{
		return new NetworkLinkDocument(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as NetworkLinkDocument);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(NetworkLinkDocument other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(GroupInfo, other.GroupInfo))
		{
			return false;
		}
		if (!object.Equals(ApplicationInfo, other.ApplicationInfo))
		{
			return false;
		}
		if (Enabled != other.Enabled)
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
		if (groupInfo_ != null)
		{
			num ^= GroupInfo.GetHashCode();
		}
		if (applicationInfo_ != null)
		{
			num ^= ApplicationInfo.GetHashCode();
		}
		if (Enabled)
		{
			num ^= Enabled.GetHashCode();
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
		if (groupInfo_ != null)
		{
			output.WriteRawTag(10);
			output.WriteMessage(GroupInfo);
		}
		if (applicationInfo_ != null)
		{
			output.WriteRawTag(18);
			output.WriteMessage(ApplicationInfo);
		}
		if (Enabled)
		{
			output.WriteRawTag(24);
			output.WriteBool(Enabled);
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
		if (groupInfo_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GroupInfo);
		}
		if (applicationInfo_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(ApplicationInfo);
		}
		if (Enabled)
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
	public void MergeFrom(NetworkLinkDocument other)
	{
		if (other == null)
		{
			return;
		}
		if (other.groupInfo_ != null)
		{
			if (groupInfo_ == null)
			{
				GroupInfo = new ProLink.Types.GroupDefinition();
			}
			GroupInfo.MergeFrom(other.GroupInfo);
		}
		if (other.applicationInfo_ != null)
		{
			if (applicationInfo_ == null)
			{
				ApplicationInfo = new ApplicationInfo();
			}
			ApplicationInfo.MergeFrom(other.ApplicationInfo);
		}
		if (other.Enabled)
		{
			Enabled = other.Enabled;
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
				if (groupInfo_ == null)
				{
					GroupInfo = new ProLink.Types.GroupDefinition();
				}
				input.ReadMessage(GroupInfo);
				break;
			case 18u:
				if (applicationInfo_ == null)
				{
					ApplicationInfo = new ApplicationInfo();
				}
				input.ReadMessage(ApplicationInfo);
				break;
			case 24u:
				Enabled = input.ReadBool();
				break;
			}
		}
	}
}
