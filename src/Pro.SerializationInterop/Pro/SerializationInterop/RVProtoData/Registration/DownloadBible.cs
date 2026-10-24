using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Registration;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class DownloadBible : IMessage<DownloadBible>, IMessage, IEquatable<DownloadBible>, IDeepCloneable<DownloadBible>
{
	private static readonly MessageParser<DownloadBible> _parser = new MessageParser<DownloadBible>(() => new DownloadBible());

	private UnknownFieldSet _unknownFields;

	public const int BibleIdFieldNumber = 1;

	private string bibleId_ = "";

	public const int FilenameFieldNumber = 2;

	private string filename_ = "";

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<DownloadBible> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => RegistrationReflection.Descriptor.MessageTypes[10];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string BibleId
	{
		get
		{
			return bibleId_;
		}
		set
		{
			bibleId_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string Filename
	{
		get
		{
			return filename_;
		}
		set
		{
			filename_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public DownloadBible()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public DownloadBible(DownloadBible other)
		: this()
	{
		bibleId_ = other.bibleId_;
		filename_ = other.filename_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public DownloadBible Clone()
	{
		return new DownloadBible(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as DownloadBible);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(DownloadBible other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (BibleId != other.BibleId)
		{
			return false;
		}
		if (Filename != other.Filename)
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
		if (BibleId.Length != 0)
		{
			num ^= BibleId.GetHashCode();
		}
		if (Filename.Length != 0)
		{
			num ^= Filename.GetHashCode();
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
		if (BibleId.Length != 0)
		{
			output.WriteRawTag(10);
			output.WriteString(BibleId);
		}
		if (Filename.Length != 0)
		{
			output.WriteRawTag(18);
			output.WriteString(Filename);
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
		if (BibleId.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(BibleId);
		}
		if (Filename.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Filename);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(DownloadBible other)
	{
		if (other != null)
		{
			if (other.BibleId.Length != 0)
			{
				BibleId = other.BibleId;
			}
			if (other.Filename.Length != 0)
			{
				Filename = other.Filename;
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
				BibleId = input.ReadString();
				break;
			case 18u:
				Filename = input.ReadString();
				break;
			}
		}
	}
}
