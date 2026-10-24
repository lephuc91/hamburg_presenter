using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Registration;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class DownloadNewVersion : IMessage<DownloadNewVersion>, IMessage, IEquatable<DownloadNewVersion>, IDeepCloneable<DownloadNewVersion>
{
	private static readonly MessageParser<DownloadNewVersion> _parser = new MessageParser<DownloadNewVersion>(() => new DownloadNewVersion());

	private UnknownFieldSet _unknownFields;

	public const int UrlFieldNumber = 1;

	private string url_ = "";

	public const int FilenameFieldNumber = 2;

	private string filename_ = "";

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<DownloadNewVersion> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => RegistrationReflection.Descriptor.MessageTypes[14];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string Url
	{
		get
		{
			return url_;
		}
		set
		{
			url_ = ProtoPreconditions.CheckNotNull(value, "value");
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
	public DownloadNewVersion()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public DownloadNewVersion(DownloadNewVersion other)
		: this()
	{
		url_ = other.url_;
		filename_ = other.filename_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public DownloadNewVersion Clone()
	{
		return new DownloadNewVersion(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as DownloadNewVersion);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(DownloadNewVersion other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (Url != other.Url)
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
		if (Url.Length != 0)
		{
			num ^= Url.GetHashCode();
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
		if (Url.Length != 0)
		{
			output.WriteRawTag(10);
			output.WriteString(Url);
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
		if (Url.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Url);
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
	public void MergeFrom(DownloadNewVersion other)
	{
		if (other != null)
		{
			if (other.Url.Length != 0)
			{
				Url = other.Url;
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
				Url = input.ReadString();
				break;
			case 18u:
				Filename = input.ReadString();
				break;
			}
		}
	}
}
