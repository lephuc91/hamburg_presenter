using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.Trigger;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class TestPattern : IMessage<TestPattern>, IMessage, IEquatable<TestPattern>, IDeepCloneable<TestPattern>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		public enum Pattern
		{
			[OriginalName("AUDIO_VIDEO_SYNC")]
			AudioVideoSync,
			[OriginalName("BLEND_GRID")]
			BlendGrid,
			[OriginalName("COLOR_BARS")]
			ColorBars,
			[OriginalName("CUSTOM_COLORS")]
			CustomColors,
			[OriginalName("FOCUS")]
			Focus,
			[OriginalName("GRAY_SCALE")]
			GrayScale,
			[OriginalName("LINES")]
			Lines,
			[OriginalName("LOGO_BOUNCE")]
			LogoBounce,
			[OriginalName("RADAR")]
			Radar,
			[OriginalName("TEXT")]
			Text
		}

		public enum Logo
		{
			[OriginalName("NONE")]
			None,
			[OriginalName("PROPRESENTER")]
			Propresenter,
			[OriginalName("CUSTOM")]
			Custom
		}
	}

	private static readonly MessageParser<TestPattern> _parser = new MessageParser<TestPattern>(() => new TestPattern());

	private UnknownFieldSet _unknownFields;

	public const int PatternFieldNumber = 1;

	private Types.Pattern pattern_;

	public const int LogoFieldNumber = 2;

	private Types.Logo logo_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<TestPattern> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AnalyticsTriggerReflection.Descriptor.MessageTypes[12];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Pattern Pattern
	{
		get
		{
			return pattern_;
		}
		set
		{
			pattern_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Logo Logo
	{
		get
		{
			return logo_;
		}
		set
		{
			logo_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TestPattern()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TestPattern(TestPattern other)
		: this()
	{
		pattern_ = other.pattern_;
		logo_ = other.logo_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TestPattern Clone()
	{
		return new TestPattern(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as TestPattern);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(TestPattern other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (Pattern != other.Pattern)
		{
			return false;
		}
		if (Logo != other.Logo)
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
		if (Pattern != 0)
		{
			num ^= Pattern.GetHashCode();
		}
		if (Logo != 0)
		{
			num ^= Logo.GetHashCode();
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
		if (Pattern != 0)
		{
			output.WriteRawTag(8);
			output.WriteEnum((int)Pattern);
		}
		if (Logo != 0)
		{
			output.WriteRawTag(16);
			output.WriteEnum((int)Logo);
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
		if (Pattern != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)Pattern);
		}
		if (Logo != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)Logo);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(TestPattern other)
	{
		if (other != null)
		{
			if (other.Pattern != 0)
			{
				Pattern = other.Pattern;
			}
			if (other.Logo != 0)
			{
				Logo = other.Logo;
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
				Pattern = (Types.Pattern)input.ReadEnum();
				break;
			case 16u:
				Logo = (Types.Logo)input.ReadEnum();
				break;
			}
		}
	}
}
