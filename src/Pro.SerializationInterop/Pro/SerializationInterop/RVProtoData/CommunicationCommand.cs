using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class CommunicationCommand : IMessage<CommunicationCommand>, IMessage, IEquatable<CommunicationCommand>, IDeepCloneable<CommunicationCommand>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Parameters : IMessage<Parameters>, IMessage, IEquatable<Parameters>, IDeepCloneable<Parameters>
		{
			private static readonly MessageParser<Parameters> _parser = new MessageParser<Parameters>(() => new Parameters());

			private UnknownFieldSet _unknownFields;

			public const int NameFieldNumber = 1;

			private string name_ = "";

			public const int ReplacementRangeFieldNumber = 2;

			private IntRange replacementRange_;

			public const int PossibleValuesFieldNumber = 3;

			private static readonly FieldCodec<string> _repeated_possibleValues_codec = FieldCodec.ForString(26u);

			private readonly RepeatedField<string> possibleValues_ = new RepeatedField<string>();

			public const int ValueFieldNumber = 4;

			private string value_ = "";

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Parameters> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => CommunicationCommand.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string Name
			{
				get
				{
					return name_;
				}
				set
				{
					name_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public IntRange ReplacementRange
			{
				get
				{
					return replacementRange_;
				}
				set
				{
					replacementRange_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RepeatedField<string> PossibleValues => possibleValues_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string Value
			{
				get
				{
					return value_;
				}
				set
				{
					value_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Parameters()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Parameters(Parameters other)
				: this()
			{
				name_ = other.name_;
				replacementRange_ = ((other.replacementRange_ != null) ? other.replacementRange_.Clone() : null);
				possibleValues_ = other.possibleValues_.Clone();
				value_ = other.value_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Parameters Clone()
			{
				return new Parameters(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Parameters);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Parameters other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (Name != other.Name)
				{
					return false;
				}
				if (!object.Equals(ReplacementRange, other.ReplacementRange))
				{
					return false;
				}
				if (!possibleValues_.Equals(other.possibleValues_))
				{
					return false;
				}
				if (Value != other.Value)
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
				if (Name.Length != 0)
				{
					num ^= Name.GetHashCode();
				}
				if (replacementRange_ != null)
				{
					num ^= ReplacementRange.GetHashCode();
				}
				num ^= possibleValues_.GetHashCode();
				if (Value.Length != 0)
				{
					num ^= Value.GetHashCode();
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
				if (Name.Length != 0)
				{
					output.WriteRawTag(10);
					output.WriteString(Name);
				}
				if (replacementRange_ != null)
				{
					output.WriteRawTag(18);
					output.WriteMessage(ReplacementRange);
				}
				possibleValues_.WriteTo(output, _repeated_possibleValues_codec);
				if (Value.Length != 0)
				{
					output.WriteRawTag(34);
					output.WriteString(Value);
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
				if (Name.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Name);
				}
				if (replacementRange_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(ReplacementRange);
				}
				num += possibleValues_.CalculateSize(_repeated_possibleValues_codec);
				if (Value.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Value);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(Parameters other)
			{
				if (other == null)
				{
					return;
				}
				if (other.Name.Length != 0)
				{
					Name = other.Name;
				}
				if (other.replacementRange_ != null)
				{
					if (replacementRange_ == null)
					{
						ReplacementRange = new IntRange();
					}
					ReplacementRange.MergeFrom(other.ReplacementRange);
				}
				possibleValues_.Add(other.possibleValues_);
				if (other.Value.Length != 0)
				{
					Value = other.Value;
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
						Name = input.ReadString();
						break;
					case 18u:
						if (replacementRange_ == null)
						{
							ReplacementRange = new IntRange();
						}
						input.ReadMessage(ReplacementRange);
						break;
					case 26u:
						possibleValues_.AddEntriesFrom(input, _repeated_possibleValues_codec);
						break;
					case 34u:
						Value = input.ReadString();
						break;
					}
				}
			}
		}
	}

	private static readonly MessageParser<CommunicationCommand> _parser = new MessageParser<CommunicationCommand>(() => new CommunicationCommand());

	private UnknownFieldSet _unknownFields;

	public const int NameFieldNumber = 1;

	private string name_ = "";

	public const int DescriptionFieldNumber = 2;

	private string description_ = "";

	public const int FormatFieldNumber = 3;

	private string format_ = "";

	public const int ParametersFieldNumber = 4;

	private static readonly FieldCodec<Types.Parameters> _repeated_parameters_codec = FieldCodec.ForMessage(34u, Types.Parameters.Parser);

	private readonly RepeatedField<Types.Parameters> parameters_ = new RepeatedField<Types.Parameters>();

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<CommunicationCommand> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => CommunicationsReflection.Descriptor.MessageTypes[5];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string Name
	{
		get
		{
			return name_;
		}
		set
		{
			name_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string Description
	{
		get
		{
			return description_;
		}
		set
		{
			description_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

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
	public RepeatedField<Types.Parameters> Parameters => parameters_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public CommunicationCommand()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public CommunicationCommand(CommunicationCommand other)
		: this()
	{
		name_ = other.name_;
		description_ = other.description_;
		format_ = other.format_;
		parameters_ = other.parameters_.Clone();
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public CommunicationCommand Clone()
	{
		return new CommunicationCommand(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as CommunicationCommand);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(CommunicationCommand other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (Name != other.Name)
		{
			return false;
		}
		if (Description != other.Description)
		{
			return false;
		}
		if (Format != other.Format)
		{
			return false;
		}
		if (!parameters_.Equals(other.parameters_))
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
		if (Name.Length != 0)
		{
			num ^= Name.GetHashCode();
		}
		if (Description.Length != 0)
		{
			num ^= Description.GetHashCode();
		}
		if (Format.Length != 0)
		{
			num ^= Format.GetHashCode();
		}
		num ^= parameters_.GetHashCode();
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
		if (Name.Length != 0)
		{
			output.WriteRawTag(10);
			output.WriteString(Name);
		}
		if (Description.Length != 0)
		{
			output.WriteRawTag(18);
			output.WriteString(Description);
		}
		if (Format.Length != 0)
		{
			output.WriteRawTag(26);
			output.WriteString(Format);
		}
		parameters_.WriteTo(output, _repeated_parameters_codec);
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
		if (Name.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Name);
		}
		if (Description.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Description);
		}
		if (Format.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Format);
		}
		num += parameters_.CalculateSize(_repeated_parameters_codec);
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(CommunicationCommand other)
	{
		if (other != null)
		{
			if (other.Name.Length != 0)
			{
				Name = other.Name;
			}
			if (other.Description.Length != 0)
			{
				Description = other.Description;
			}
			if (other.Format.Length != 0)
			{
				Format = other.Format;
			}
			parameters_.Add(other.parameters_);
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
				Name = input.ReadString();
				break;
			case 18u:
				Description = input.ReadString();
				break;
			case 26u:
				Format = input.ReadString();
				break;
			case 34u:
				parameters_.AddEntriesFrom(input, _repeated_parameters_codec);
				break;
			}
		}
	}
}
