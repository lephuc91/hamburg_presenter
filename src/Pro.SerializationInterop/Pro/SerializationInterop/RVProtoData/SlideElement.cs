using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class SlideElement : IMessage<SlideElement>, IMessage, IEquatable<SlideElement>, IDeepCloneable<SlideElement>
{
	private static readonly MessageParser<SlideElement> _parser = new MessageParser<SlideElement>(() => new SlideElement());

	private UnknownFieldSet _unknownFields;

	public const int ElementFieldNumber = 1;

	private Slide.Types.Element element_;

	public const int BuildIndexFieldNumber = 2;

	private int buildIndex_;

	public const int BaseKeyFieldNumber = 3;

	private MusicKeyScale baseKey_;

	public const int TargetKeyFieldNumber = 4;

	private MusicKeyScale targetKey_;

	public const int CookiesFieldNumber = 5;

	private static readonly FieldCodec<WebFillTokenAndCookies.Types.Cookie> _repeated_cookies_codec = FieldCodec.ForMessage(42u, WebFillTokenAndCookies.Types.Cookie.Parser);

	private readonly RepeatedField<WebFillTokenAndCookies.Types.Cookie> cookies_ = new RepeatedField<WebFillTokenAndCookies.Types.Cookie>();

	public const int ForStageLayoutFieldNumber = 6;

	private bool forStageLayout_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<SlideElement> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => Rv2DReflection.Descriptor.MessageTypes[3];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Slide.Types.Element Element
	{
		get
		{
			return element_;
		}
		set
		{
			element_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int BuildIndex
	{
		get
		{
			return buildIndex_;
		}
		set
		{
			buildIndex_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public MusicKeyScale BaseKey
	{
		get
		{
			return baseKey_;
		}
		set
		{
			baseKey_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public MusicKeyScale TargetKey
	{
		get
		{
			return targetKey_;
		}
		set
		{
			targetKey_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<WebFillTokenAndCookies.Types.Cookie> Cookies => cookies_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool ForStageLayout
	{
		get
		{
			return forStageLayout_;
		}
		set
		{
			forStageLayout_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public SlideElement()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public SlideElement(SlideElement other)
		: this()
	{
		element_ = ((other.element_ != null) ? other.element_.Clone() : null);
		buildIndex_ = other.buildIndex_;
		baseKey_ = ((other.baseKey_ != null) ? other.baseKey_.Clone() : null);
		targetKey_ = ((other.targetKey_ != null) ? other.targetKey_.Clone() : null);
		cookies_ = other.cookies_.Clone();
		forStageLayout_ = other.forStageLayout_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public SlideElement Clone()
	{
		return new SlideElement(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as SlideElement);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(SlideElement other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(Element, other.Element))
		{
			return false;
		}
		if (BuildIndex != other.BuildIndex)
		{
			return false;
		}
		if (!object.Equals(BaseKey, other.BaseKey))
		{
			return false;
		}
		if (!object.Equals(TargetKey, other.TargetKey))
		{
			return false;
		}
		if (!cookies_.Equals(other.cookies_))
		{
			return false;
		}
		if (ForStageLayout != other.ForStageLayout)
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
		if (element_ != null)
		{
			num ^= Element.GetHashCode();
		}
		if (BuildIndex != 0)
		{
			num ^= BuildIndex.GetHashCode();
		}
		if (baseKey_ != null)
		{
			num ^= BaseKey.GetHashCode();
		}
		if (targetKey_ != null)
		{
			num ^= TargetKey.GetHashCode();
		}
		num ^= cookies_.GetHashCode();
		if (ForStageLayout)
		{
			num ^= ForStageLayout.GetHashCode();
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
		if (element_ != null)
		{
			output.WriteRawTag(10);
			output.WriteMessage(Element);
		}
		if (BuildIndex != 0)
		{
			output.WriteRawTag(16);
			output.WriteInt32(BuildIndex);
		}
		if (baseKey_ != null)
		{
			output.WriteRawTag(26);
			output.WriteMessage(BaseKey);
		}
		if (targetKey_ != null)
		{
			output.WriteRawTag(34);
			output.WriteMessage(TargetKey);
		}
		cookies_.WriteTo(output, _repeated_cookies_codec);
		if (ForStageLayout)
		{
			output.WriteRawTag(48);
			output.WriteBool(ForStageLayout);
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
		if (element_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Element);
		}
		if (BuildIndex != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(BuildIndex);
		}
		if (baseKey_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(BaseKey);
		}
		if (targetKey_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(TargetKey);
		}
		num += cookies_.CalculateSize(_repeated_cookies_codec);
		if (ForStageLayout)
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
	public void MergeFrom(SlideElement other)
	{
		if (other == null)
		{
			return;
		}
		if (other.element_ != null)
		{
			if (element_ == null)
			{
				Element = new Slide.Types.Element();
			}
			Element.MergeFrom(other.Element);
		}
		if (other.BuildIndex != 0)
		{
			BuildIndex = other.BuildIndex;
		}
		if (other.baseKey_ != null)
		{
			if (baseKey_ == null)
			{
				BaseKey = new MusicKeyScale();
			}
			BaseKey.MergeFrom(other.BaseKey);
		}
		if (other.targetKey_ != null)
		{
			if (targetKey_ == null)
			{
				TargetKey = new MusicKeyScale();
			}
			TargetKey.MergeFrom(other.TargetKey);
		}
		cookies_.Add(other.cookies_);
		if (other.ForStageLayout)
		{
			ForStageLayout = other.ForStageLayout;
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
				if (element_ == null)
				{
					Element = new Slide.Types.Element();
				}
				input.ReadMessage(Element);
				break;
			case 16u:
				BuildIndex = input.ReadInt32();
				break;
			case 26u:
				if (baseKey_ == null)
				{
					BaseKey = new MusicKeyScale();
				}
				input.ReadMessage(BaseKey);
				break;
			case 34u:
				if (targetKey_ == null)
				{
					TargetKey = new MusicKeyScale();
				}
				input.ReadMessage(TargetKey);
				break;
			case 42u:
				cookies_.AddEntriesFrom(input, _repeated_cookies_codec);
				break;
			case 48u:
				ForStageLayout = input.ReadBool();
				break;
			}
		}
	}
}
