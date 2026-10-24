using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class CacheInfo : IMessage<CacheInfo>, IMessage, IEquatable<CacheInfo>, IDeepCloneable<CacheInfo>
{
	private static readonly MessageParser<CacheInfo> _parser = new MessageParser<CacheInfo>(() => new CacheInfo());

	private UnknownFieldSet _unknownFields;

	public const int UuidFieldNumber = 1;

	private UUID uuid_;

	public const int ApplicationVersionFieldNumber = 2;

	private Version applicationVersion_;

	public const int UrlFieldNumber = 3;

	private URL url_;

	public const int LastModifiedDateFieldNumber = 4;

	private double lastModifiedDate_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<CacheInfo> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => BaseDocumentReflection.Descriptor.MessageTypes[1];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public UUID Uuid
	{
		get
		{
			return uuid_;
		}
		set
		{
			uuid_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Version ApplicationVersion
	{
		get
		{
			return applicationVersion_;
		}
		set
		{
			applicationVersion_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public URL Url
	{
		get
		{
			return url_;
		}
		set
		{
			url_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public double LastModifiedDate
	{
		get
		{
			return lastModifiedDate_;
		}
		set
		{
			lastModifiedDate_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public CacheInfo()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public CacheInfo(CacheInfo other)
		: this()
	{
		uuid_ = ((other.uuid_ != null) ? other.uuid_.Clone() : null);
		applicationVersion_ = ((other.applicationVersion_ != null) ? other.applicationVersion_.Clone() : null);
		url_ = ((other.url_ != null) ? other.url_.Clone() : null);
		lastModifiedDate_ = other.lastModifiedDate_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public CacheInfo Clone()
	{
		return new CacheInfo(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as CacheInfo);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(CacheInfo other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(Uuid, other.Uuid))
		{
			return false;
		}
		if (!object.Equals(ApplicationVersion, other.ApplicationVersion))
		{
			return false;
		}
		if (!object.Equals(Url, other.Url))
		{
			return false;
		}
		if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(LastModifiedDate, other.LastModifiedDate))
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
		if (uuid_ != null)
		{
			num ^= Uuid.GetHashCode();
		}
		if (applicationVersion_ != null)
		{
			num ^= ApplicationVersion.GetHashCode();
		}
		if (url_ != null)
		{
			num ^= Url.GetHashCode();
		}
		if (LastModifiedDate != 0.0)
		{
			num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(LastModifiedDate);
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
		if (uuid_ != null)
		{
			output.WriteRawTag(10);
			output.WriteMessage(Uuid);
		}
		if (applicationVersion_ != null)
		{
			output.WriteRawTag(18);
			output.WriteMessage(ApplicationVersion);
		}
		if (url_ != null)
		{
			output.WriteRawTag(26);
			output.WriteMessage(Url);
		}
		if (LastModifiedDate != 0.0)
		{
			output.WriteRawTag(33);
			output.WriteDouble(LastModifiedDate);
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
		if (uuid_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Uuid);
		}
		if (applicationVersion_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(ApplicationVersion);
		}
		if (url_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Url);
		}
		if (LastModifiedDate != 0.0)
		{
			num += 9;
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(CacheInfo other)
	{
		if (other == null)
		{
			return;
		}
		if (other.uuid_ != null)
		{
			if (uuid_ == null)
			{
				Uuid = new UUID();
			}
			Uuid.MergeFrom(other.Uuid);
		}
		if (other.applicationVersion_ != null)
		{
			if (applicationVersion_ == null)
			{
				ApplicationVersion = new Version();
			}
			ApplicationVersion.MergeFrom(other.ApplicationVersion);
		}
		if (other.url_ != null)
		{
			if (url_ == null)
			{
				Url = new URL();
			}
			Url.MergeFrom(other.Url);
		}
		if (other.LastModifiedDate != 0.0)
		{
			LastModifiedDate = other.LastModifiedDate;
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
				if (uuid_ == null)
				{
					Uuid = new UUID();
				}
				input.ReadMessage(Uuid);
				break;
			case 18u:
				if (applicationVersion_ == null)
				{
					ApplicationVersion = new Version();
				}
				input.ReadMessage(ApplicationVersion);
				break;
			case 26u:
				if (url_ == null)
				{
					Url = new URL();
				}
				input.ReadMessage(Url);
				break;
			case 33u:
				LastModifiedDate = input.ReadDouble();
				break;
			}
		}
	}
}
