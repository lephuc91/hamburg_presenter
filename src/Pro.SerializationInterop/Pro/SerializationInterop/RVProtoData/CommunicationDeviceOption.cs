using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class CommunicationDeviceOption : IMessage<CommunicationDeviceOption>, IMessage, IEquatable<CommunicationDeviceOption>, IDeepCloneable<CommunicationDeviceOption>
{
	public enum OptionTypeOneofCase
	{
		None,
		OesProMode
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class OESProMode : IMessage<OESProMode>, IMessage, IEquatable<OESProMode>, IDeepCloneable<OESProMode>
		{
			private static readonly MessageParser<OESProMode> _parser = new MessageParser<OESProMode>(() => new OESProMode());

			private UnknownFieldSet _unknownFields;

			public const int EnableFieldNumber = 1;

			private bool enable_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<OESProMode> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => CommunicationDeviceOption.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Enable
			{
				get
				{
					return enable_;
				}
				set
				{
					enable_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public OESProMode()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public OESProMode(OESProMode other)
				: this()
			{
				enable_ = other.enable_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public OESProMode Clone()
			{
				return new OESProMode(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as OESProMode);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(OESProMode other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (Enable != other.Enable)
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
				if (Enable)
				{
					num ^= Enable.GetHashCode();
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
				if (Enable)
				{
					output.WriteRawTag(8);
					output.WriteBool(Enable);
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
				if (Enable)
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
			public void MergeFrom(OESProMode other)
			{
				if (other != null)
				{
					if (other.Enable)
					{
						Enable = other.Enable;
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
					if (num != 8)
					{
						_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
					}
					else
					{
						Enable = input.ReadBool();
					}
				}
			}
		}
	}

	private static readonly MessageParser<CommunicationDeviceOption> _parser = new MessageParser<CommunicationDeviceOption>(() => new CommunicationDeviceOption());

	private UnknownFieldSet _unknownFields;

	public const int OesProModeFieldNumber = 1;

	private object optionType_;

	private OptionTypeOneofCase optionTypeCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<CommunicationDeviceOption> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => CommunicationsReflection.Descriptor.MessageTypes[6];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.OESProMode OesProMode
	{
		get
		{
			if (optionTypeCase_ != OptionTypeOneofCase.OesProMode)
			{
				return null;
			}
			return (Types.OESProMode)optionType_;
		}
		set
		{
			optionType_ = value;
			optionTypeCase_ = ((value != null) ? OptionTypeOneofCase.OesProMode : OptionTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public OptionTypeOneofCase OptionTypeCase => optionTypeCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public CommunicationDeviceOption()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public CommunicationDeviceOption(CommunicationDeviceOption other)
		: this()
	{
		if (other.OptionTypeCase == OptionTypeOneofCase.OesProMode)
		{
			OesProMode = other.OesProMode.Clone();
		}
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public CommunicationDeviceOption Clone()
	{
		return new CommunicationDeviceOption(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void ClearOptionType()
	{
		optionTypeCase_ = OptionTypeOneofCase.None;
		optionType_ = null;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as CommunicationDeviceOption);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(CommunicationDeviceOption other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(OesProMode, other.OesProMode))
		{
			return false;
		}
		if (OptionTypeCase != other.OptionTypeCase)
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
		if (optionTypeCase_ == OptionTypeOneofCase.OesProMode)
		{
			num ^= OesProMode.GetHashCode();
		}
		num ^= (int)optionTypeCase_;
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
		if (optionTypeCase_ == OptionTypeOneofCase.OesProMode)
		{
			output.WriteRawTag(10);
			output.WriteMessage(OesProMode);
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
		if (optionTypeCase_ == OptionTypeOneofCase.OesProMode)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(OesProMode);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(CommunicationDeviceOption other)
	{
		if (other == null)
		{
			return;
		}
		if (other.OptionTypeCase == OptionTypeOneofCase.OesProMode)
		{
			if (OesProMode == null)
			{
				OesProMode = new Types.OESProMode();
			}
			OesProMode.MergeFrom(other.OesProMode);
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
			if (num != 10)
			{
				_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
				continue;
			}
			Types.OESProMode oESProMode = new Types.OESProMode();
			if (optionTypeCase_ == OptionTypeOneofCase.OesProMode)
			{
				oESProMode.MergeFrom(OesProMode);
			}
			input.ReadMessage(oESProMode);
			OesProMode = oESProMode;
		}
	}
}
