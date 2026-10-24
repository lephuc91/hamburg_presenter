using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class Clock : IMessage<Clock>, IMessage, IEquatable<Clock>, IDeepCloneable<Clock>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Format : IMessage<Format>, IMessage, IEquatable<Format>, IDeepCloneable<Format>
		{
			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				public enum DateFormatterStyle
				{
					[OriginalName("DATE_FORMATTER_STYLE_NONE")]
					None,
					[OriginalName("DATE_FORMATTER_STYLE_SHORT")]
					Short,
					[OriginalName("DATE_FORMATTER_STYLE_MEDIUM")]
					Medium,
					[OriginalName("DATE_FORMATTER_STYLE_LONG")]
					Long,
					[OriginalName("DATE_FORMATTER_STYLE_FULL")]
					Full
				}
			}

			private static readonly MessageParser<Format> _parser = new MessageParser<Format>(() => new Format());

			private UnknownFieldSet _unknownFields;

			public const int DateTypeFieldNumber = 2;

			private Types.DateFormatterStyle dateType_;

			public const int TimeFormatFieldNumber = 3;

			private Types.DateFormatterStyle timeFormat_;

			public const int MilitaryTimeEnabledFieldNumber = 4;

			private bool militaryTimeEnabled_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Format> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Clock.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.DateFormatterStyle DateType
			{
				get
				{
					return dateType_;
				}
				set
				{
					dateType_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.DateFormatterStyle TimeFormat
			{
				get
				{
					return timeFormat_;
				}
				set
				{
					timeFormat_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool MilitaryTimeEnabled
			{
				get
				{
					return militaryTimeEnabled_;
				}
				set
				{
					militaryTimeEnabled_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Format()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Format(Format other)
				: this()
			{
				dateType_ = other.dateType_;
				timeFormat_ = other.timeFormat_;
				militaryTimeEnabled_ = other.militaryTimeEnabled_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Format Clone()
			{
				return new Format(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Format);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Format other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (DateType != other.DateType)
				{
					return false;
				}
				if (TimeFormat != other.TimeFormat)
				{
					return false;
				}
				if (MilitaryTimeEnabled != other.MilitaryTimeEnabled)
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
				if (DateType != 0)
				{
					num ^= DateType.GetHashCode();
				}
				if (TimeFormat != 0)
				{
					num ^= TimeFormat.GetHashCode();
				}
				if (MilitaryTimeEnabled)
				{
					num ^= MilitaryTimeEnabled.GetHashCode();
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
				if (DateType != 0)
				{
					output.WriteRawTag(16);
					output.WriteEnum((int)DateType);
				}
				if (TimeFormat != 0)
				{
					output.WriteRawTag(24);
					output.WriteEnum((int)TimeFormat);
				}
				if (MilitaryTimeEnabled)
				{
					output.WriteRawTag(32);
					output.WriteBool(MilitaryTimeEnabled);
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
				if (DateType != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)DateType);
				}
				if (TimeFormat != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)TimeFormat);
				}
				if (MilitaryTimeEnabled)
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
			public void MergeFrom(Format other)
			{
				if (other != null)
				{
					if (other.DateType != 0)
					{
						DateType = other.DateType;
					}
					if (other.TimeFormat != 0)
					{
						TimeFormat = other.TimeFormat;
					}
					if (other.MilitaryTimeEnabled)
					{
						MilitaryTimeEnabled = other.MilitaryTimeEnabled;
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
					case 16u:
						DateType = (Types.DateFormatterStyle)input.ReadEnum();
						break;
					case 24u:
						TimeFormat = (Types.DateFormatterStyle)input.ReadEnum();
						break;
					case 32u:
						MilitaryTimeEnabled = input.ReadBool();
						break;
					}
				}
			}
		}
	}

	private static readonly MessageParser<Clock> _parser = new MessageParser<Clock>(() => new Clock());

	private UnknownFieldSet _unknownFields;

	public const int FormatFieldNumber = 1;

	private string format_ = "";

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<Clock> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => TimersReflection.Descriptor.MessageTypes[0];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string Format
	{
		get
		{
			return format_;
		}
		set
		{
			format_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Clock()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Clock(Clock other)
		: this()
	{
		format_ = other.format_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Clock Clone()
	{
		return new Clock(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as Clock);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(Clock other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (Format != other.Format)
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
		if (Format.Length != 0)
		{
			num ^= Format.GetHashCode();
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
		if (Format.Length != 0)
		{
			output.WriteRawTag(10);
			output.WriteString(Format);
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
		if (Format.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Format);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(Clock other)
	{
		if (other != null)
		{
			if (other.Format.Length != 0)
			{
				Format = other.Format;
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
			if (num != 10)
			{
				_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
			}
			else
			{
				Format = input.ReadString();
			}
		}
	}
}
