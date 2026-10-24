using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class LayerIdentificationOverlay : IMessage<LayerIdentificationOverlay>, IMessage, IEquatable<LayerIdentificationOverlay>, IDeepCloneable<LayerIdentificationOverlay>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		public enum Layer
		{
			[OriginalName("LAYER_VIDEO_INPUT")]
			VideoInput,
			[OriginalName("LAYER_MEDIA")]
			Media,
			[OriginalName("LAYER_PRESENTATION")]
			Presentation,
			[OriginalName("LAYER_ANNOUNCEMENTS")]
			Announcements,
			[OriginalName("LAYER_PROPS")]
			Props,
			[OriginalName("LAYER_MESSAGES")]
			Messages
		}
	}

	private static readonly MessageParser<LayerIdentificationOverlay> _parser = new MessageParser<LayerIdentificationOverlay>(() => new LayerIdentificationOverlay());

	private UnknownFieldSet _unknownFields;

	public const int LayerFieldNumber = 1;

	private Types.Layer layer_;

	public const int LayerNameFieldNumber = 2;

	private string layerName_ = "";

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<LayerIdentificationOverlay> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => Rv2DReflection.Descriptor.MessageTypes[1];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Layer Layer
	{
		get
		{
			return layer_;
		}
		set
		{
			layer_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string LayerName
	{
		get
		{
			return layerName_;
		}
		set
		{
			layerName_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LayerIdentificationOverlay()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LayerIdentificationOverlay(LayerIdentificationOverlay other)
		: this()
	{
		layer_ = other.layer_;
		layerName_ = other.layerName_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LayerIdentificationOverlay Clone()
	{
		return new LayerIdentificationOverlay(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as LayerIdentificationOverlay);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(LayerIdentificationOverlay other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (Layer != other.Layer)
		{
			return false;
		}
		if (LayerName != other.LayerName)
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
		if (Layer != 0)
		{
			num ^= Layer.GetHashCode();
		}
		if (LayerName.Length != 0)
		{
			num ^= LayerName.GetHashCode();
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
		if (Layer != 0)
		{
			output.WriteRawTag(8);
			output.WriteEnum((int)Layer);
		}
		if (LayerName.Length != 0)
		{
			output.WriteRawTag(18);
			output.WriteString(LayerName);
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
		if (Layer != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)Layer);
		}
		if (LayerName.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(LayerName);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(LayerIdentificationOverlay other)
	{
		if (other != null)
		{
			if (other.Layer != 0)
			{
				Layer = other.Layer;
			}
			if (other.LayerName.Length != 0)
			{
				LayerName = other.LayerName;
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
				Layer = (Types.Layer)input.ReadEnum();
				break;
			case 18u:
				LayerName = input.ReadString();
				break;
			}
		}
	}
}
