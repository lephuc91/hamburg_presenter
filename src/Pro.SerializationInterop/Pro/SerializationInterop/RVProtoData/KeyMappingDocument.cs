using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class KeyMappingDocument : IMessage<KeyMappingDocument>, IMessage, IEquatable<KeyMappingDocument>, IDeepCloneable<KeyMappingDocument>
{
	private static readonly MessageParser<KeyMappingDocument> _parser = new MessageParser<KeyMappingDocument>(() => new KeyMappingDocument());

	private UnknownFieldSet _unknownFields;

	public const int ApplicationInfoFieldNumber = 1;

	private ApplicationInfo applicationInfo_;

	public const int KeymappingsFieldNumber = 2;

	private static readonly FieldCodec<KeyMapping> _repeated_keymappings_codec = FieldCodec.ForMessage(18u, KeyMapping.Parser);

	private readonly RepeatedField<KeyMapping> keymappings_ = new RepeatedField<KeyMapping>();

	public const int MacosKeymappingsFieldNumber = 3;

	private static readonly FieldCodec<KeyMapping> _repeated_macosKeymappings_codec = FieldCodec.ForMessage(26u, KeyMapping.Parser);

	private readonly RepeatedField<KeyMapping> macosKeymappings_ = new RepeatedField<KeyMapping>();

	public const int WindowsKeymappingsFieldNumber = 4;

	private static readonly FieldCodec<KeyMapping> _repeated_windowsKeymappings_codec = FieldCodec.ForMessage(34u, KeyMapping.Parser);

	private readonly RepeatedField<KeyMapping> windowsKeymappings_ = new RepeatedField<KeyMapping>();

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<KeyMappingDocument> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => KeymappingReflection.Descriptor.MessageTypes[1];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

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
	public RepeatedField<KeyMapping> Keymappings => keymappings_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<KeyMapping> MacosKeymappings => macosKeymappings_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<KeyMapping> WindowsKeymappings => windowsKeymappings_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public KeyMappingDocument()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public KeyMappingDocument(KeyMappingDocument other)
		: this()
	{
		applicationInfo_ = ((other.applicationInfo_ != null) ? other.applicationInfo_.Clone() : null);
		keymappings_ = other.keymappings_.Clone();
		macosKeymappings_ = other.macosKeymappings_.Clone();
		windowsKeymappings_ = other.windowsKeymappings_.Clone();
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public KeyMappingDocument Clone()
	{
		return new KeyMappingDocument(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as KeyMappingDocument);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(KeyMappingDocument other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(ApplicationInfo, other.ApplicationInfo))
		{
			return false;
		}
		if (!keymappings_.Equals(other.keymappings_))
		{
			return false;
		}
		if (!macosKeymappings_.Equals(other.macosKeymappings_))
		{
			return false;
		}
		if (!windowsKeymappings_.Equals(other.windowsKeymappings_))
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
		if (applicationInfo_ != null)
		{
			num ^= ApplicationInfo.GetHashCode();
		}
		num ^= keymappings_.GetHashCode();
		num ^= macosKeymappings_.GetHashCode();
		num ^= windowsKeymappings_.GetHashCode();
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
		if (applicationInfo_ != null)
		{
			output.WriteRawTag(10);
			output.WriteMessage(ApplicationInfo);
		}
		keymappings_.WriteTo(output, _repeated_keymappings_codec);
		macosKeymappings_.WriteTo(output, _repeated_macosKeymappings_codec);
		windowsKeymappings_.WriteTo(output, _repeated_windowsKeymappings_codec);
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
		if (applicationInfo_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(ApplicationInfo);
		}
		num += keymappings_.CalculateSize(_repeated_keymappings_codec);
		num += macosKeymappings_.CalculateSize(_repeated_macosKeymappings_codec);
		num += windowsKeymappings_.CalculateSize(_repeated_windowsKeymappings_codec);
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(KeyMappingDocument other)
	{
		if (other == null)
		{
			return;
		}
		if (other.applicationInfo_ != null)
		{
			if (applicationInfo_ == null)
			{
				ApplicationInfo = new ApplicationInfo();
			}
			ApplicationInfo.MergeFrom(other.ApplicationInfo);
		}
		keymappings_.Add(other.keymappings_);
		macosKeymappings_.Add(other.macosKeymappings_);
		windowsKeymappings_.Add(other.windowsKeymappings_);
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
				if (applicationInfo_ == null)
				{
					ApplicationInfo = new ApplicationInfo();
				}
				input.ReadMessage(ApplicationInfo);
				break;
			case 18u:
				keymappings_.AddEntriesFrom(input, _repeated_keymappings_codec);
				break;
			case 26u:
				macosKeymappings_.AddEntriesFrom(input, _repeated_macosKeymappings_codec);
				break;
			case 34u:
				windowsKeymappings_.AddEntriesFrom(input, _repeated_windowsKeymappings_codec);
				break;
			}
		}
	}
}
