using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class API_v1_RTMPCapture : IMessage<API_v1_RTMPCapture>, IMessage, IEquatable<API_v1_RTMPCapture>, IDeepCloneable<API_v1_RTMPCapture>
{
	private static readonly MessageParser<API_v1_RTMPCapture> _parser = new MessageParser<API_v1_RTMPCapture>(() => new API_v1_RTMPCapture());

	private UnknownFieldSet _unknownFields;

	public const int ServerFieldNumber = 1;

	private string server_ = "";

	public const int KeyFieldNumber = 2;

	private string key_ = "";

	public const int EncodingFieldNumber = 3;

	private string encoding_ = "";

	public const int SaveLocalFieldNumber = 4;

	private bool saveLocal_;

	public const int FileLocationFieldNumber = 5;

	private string fileLocation_ = "";

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<API_v1_RTMPCapture> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProApiV1CaptureReflection.Descriptor.MessageTypes[3];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string Server
	{
		get
		{
			return server_;
		}
		set
		{
			server_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string Key
	{
		get
		{
			return key_;
		}
		set
		{
			key_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string Encoding
	{
		get
		{
			return encoding_;
		}
		set
		{
			encoding_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool SaveLocal
	{
		get
		{
			return saveLocal_;
		}
		set
		{
			saveLocal_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string FileLocation
	{
		get
		{
			return fileLocation_;
		}
		set
		{
			fileLocation_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_RTMPCapture()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_RTMPCapture(API_v1_RTMPCapture other)
		: this()
	{
		server_ = other.server_;
		key_ = other.key_;
		encoding_ = other.encoding_;
		saveLocal_ = other.saveLocal_;
		fileLocation_ = other.fileLocation_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_RTMPCapture Clone()
	{
		return new API_v1_RTMPCapture(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as API_v1_RTMPCapture);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(API_v1_RTMPCapture other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (Server != other.Server)
		{
			return false;
		}
		if (Key != other.Key)
		{
			return false;
		}
		if (Encoding != other.Encoding)
		{
			return false;
		}
		if (SaveLocal != other.SaveLocal)
		{
			return false;
		}
		if (FileLocation != other.FileLocation)
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
		if (Server.Length != 0)
		{
			num ^= Server.GetHashCode();
		}
		if (Key.Length != 0)
		{
			num ^= Key.GetHashCode();
		}
		if (Encoding.Length != 0)
		{
			num ^= Encoding.GetHashCode();
		}
		if (SaveLocal)
		{
			num ^= SaveLocal.GetHashCode();
		}
		if (FileLocation.Length != 0)
		{
			num ^= FileLocation.GetHashCode();
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
		if (Server.Length != 0)
		{
			output.WriteRawTag(10);
			output.WriteString(Server);
		}
		if (Key.Length != 0)
		{
			output.WriteRawTag(18);
			output.WriteString(Key);
		}
		if (Encoding.Length != 0)
		{
			output.WriteRawTag(26);
			output.WriteString(Encoding);
		}
		if (SaveLocal)
		{
			output.WriteRawTag(32);
			output.WriteBool(SaveLocal);
		}
		if (FileLocation.Length != 0)
		{
			output.WriteRawTag(42);
			output.WriteString(FileLocation);
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
		if (Server.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Server);
		}
		if (Key.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Key);
		}
		if (Encoding.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Encoding);
		}
		if (SaveLocal)
		{
			num += 2;
		}
		if (FileLocation.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(FileLocation);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(API_v1_RTMPCapture other)
	{
		if (other != null)
		{
			if (other.Server.Length != 0)
			{
				Server = other.Server;
			}
			if (other.Key.Length != 0)
			{
				Key = other.Key;
			}
			if (other.Encoding.Length != 0)
			{
				Encoding = other.Encoding;
			}
			if (other.SaveLocal)
			{
				SaveLocal = other.SaveLocal;
			}
			if (other.FileLocation.Length != 0)
			{
				FileLocation = other.FileLocation;
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
				Server = input.ReadString();
				break;
			case 18u:
				Key = input.ReadString();
				break;
			case 26u:
				Encoding = input.ReadString();
				break;
			case 32u:
				SaveLocal = input.ReadBool();
				break;
			case 42u:
				FileLocation = input.ReadString();
				break;
			}
		}
	}
}
