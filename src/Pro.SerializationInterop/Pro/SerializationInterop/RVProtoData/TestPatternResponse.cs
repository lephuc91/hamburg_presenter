using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class TestPatternResponse : IMessage<TestPatternResponse>, IMessage, IEquatable<TestPatternResponse>, IDeepCloneable<TestPatternResponse>
{
	public enum ResponseOneofCase
	{
		None,
		GetDefinitions,
		GetCurrentState,
		GetThumbnail
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class GetDefinitions : IMessage<GetDefinitions>, IMessage, IEquatable<GetDefinitions>, IDeepCloneable<GetDefinitions>
		{
			private static readonly MessageParser<GetDefinitions> _parser = new MessageParser<GetDefinitions>(() => new GetDefinitions());

			private UnknownFieldSet _unknownFields;

			public const int PatternsFieldNumber = 1;

			private static readonly FieldCodec<TestPatternDefinition> _repeated_patterns_codec = FieldCodec.ForMessage(10u, TestPatternDefinition.Parser);

			private readonly RepeatedField<TestPatternDefinition> patterns_ = new RepeatedField<TestPatternDefinition>();

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GetDefinitions> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => TestPatternResponse.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RepeatedField<TestPatternDefinition> Patterns => patterns_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetDefinitions()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetDefinitions(GetDefinitions other)
				: this()
			{
				patterns_ = other.patterns_.Clone();
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetDefinitions Clone()
			{
				return new GetDefinitions(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as GetDefinitions);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(GetDefinitions other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!patterns_.Equals(other.patterns_))
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
				num ^= patterns_.GetHashCode();
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
				patterns_.WriteTo(output, _repeated_patterns_codec);
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
				num += patterns_.CalculateSize(_repeated_patterns_codec);
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(GetDefinitions other)
			{
				if (other != null)
				{
					patterns_.Add(other.patterns_);
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
						patterns_.AddEntriesFrom(input, _repeated_patterns_codec);
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class GetThumbnail : IMessage<GetThumbnail>, IMessage, IEquatable<GetThumbnail>, IDeepCloneable<GetThumbnail>
		{
			private static readonly MessageParser<GetThumbnail> _parser = new MessageParser<GetThumbnail>(() => new GetThumbnail());

			private UnknownFieldSet _unknownFields;

			public const int PatternFieldNumber = 1;

			private UUID pattern_;

			public const int ImageFieldNumber = 2;

			private ByteString image_ = ByteString.Empty;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GetThumbnail> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => TestPatternResponse.Descriptor.NestedTypes[1];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public UUID Pattern
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
			public ByteString Image
			{
				get
				{
					return image_;
				}
				set
				{
					image_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetThumbnail()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetThumbnail(GetThumbnail other)
				: this()
			{
				pattern_ = ((other.pattern_ != null) ? other.pattern_.Clone() : null);
				image_ = other.image_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetThumbnail Clone()
			{
				return new GetThumbnail(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as GetThumbnail);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(GetThumbnail other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(Pattern, other.Pattern))
				{
					return false;
				}
				if (Image != other.Image)
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
				if (pattern_ != null)
				{
					num ^= Pattern.GetHashCode();
				}
				if (Image.Length != 0)
				{
					num ^= Image.GetHashCode();
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
				if (pattern_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Pattern);
				}
				if (Image.Length != 0)
				{
					output.WriteRawTag(18);
					output.WriteBytes(Image);
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
				if (pattern_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Pattern);
				}
				if (Image.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeBytesSize(Image);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(GetThumbnail other)
			{
				if (other == null)
				{
					return;
				}
				if (other.pattern_ != null)
				{
					if (pattern_ == null)
					{
						Pattern = new UUID();
					}
					Pattern.MergeFrom(other.Pattern);
				}
				if (other.Image.Length != 0)
				{
					Image = other.Image;
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
						if (pattern_ == null)
						{
							Pattern = new UUID();
						}
						input.ReadMessage(Pattern);
						break;
					case 18u:
						Image = input.ReadBytes();
						break;
					}
				}
			}
		}
	}

	private static readonly MessageParser<TestPatternResponse> _parser = new MessageParser<TestPatternResponse>(() => new TestPatternResponse());

	private UnknownFieldSet _unknownFields;

	public const int GetDefinitionsFieldNumber = 1;

	public const int GetCurrentStateFieldNumber = 2;

	public const int GetThumbnailFieldNumber = 3;

	private object response_;

	private ResponseOneofCase responseCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<TestPatternResponse> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProCoreTestPatternsReflection.Descriptor.MessageTypes[1];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.GetDefinitions GetDefinitions
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.GetDefinitions)
			{
				return null;
			}
			return (Types.GetDefinitions)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.GetDefinitions : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TestPatternState GetCurrentState
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.GetCurrentState)
			{
				return null;
			}
			return (TestPatternState)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.GetCurrentState : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.GetThumbnail GetThumbnail
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.GetThumbnail)
			{
				return null;
			}
			return (Types.GetThumbnail)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.GetThumbnail : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ResponseOneofCase ResponseCase => responseCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TestPatternResponse()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TestPatternResponse(TestPatternResponse other)
		: this()
	{
		switch (other.ResponseCase)
		{
		case ResponseOneofCase.GetDefinitions:
			GetDefinitions = other.GetDefinitions.Clone();
			break;
		case ResponseOneofCase.GetCurrentState:
			GetCurrentState = other.GetCurrentState.Clone();
			break;
		case ResponseOneofCase.GetThumbnail:
			GetThumbnail = other.GetThumbnail.Clone();
			break;
		}
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TestPatternResponse Clone()
	{
		return new TestPatternResponse(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void ClearResponse()
	{
		responseCase_ = ResponseOneofCase.None;
		response_ = null;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as TestPatternResponse);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(TestPatternResponse other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(GetDefinitions, other.GetDefinitions))
		{
			return false;
		}
		if (!object.Equals(GetCurrentState, other.GetCurrentState))
		{
			return false;
		}
		if (!object.Equals(GetThumbnail, other.GetThumbnail))
		{
			return false;
		}
		if (ResponseCase != other.ResponseCase)
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
		if (responseCase_ == ResponseOneofCase.GetDefinitions)
		{
			num ^= GetDefinitions.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.GetCurrentState)
		{
			num ^= GetCurrentState.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.GetThumbnail)
		{
			num ^= GetThumbnail.GetHashCode();
		}
		num ^= (int)responseCase_;
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
		if (responseCase_ == ResponseOneofCase.GetDefinitions)
		{
			output.WriteRawTag(10);
			output.WriteMessage(GetDefinitions);
		}
		if (responseCase_ == ResponseOneofCase.GetCurrentState)
		{
			output.WriteRawTag(18);
			output.WriteMessage(GetCurrentState);
		}
		if (responseCase_ == ResponseOneofCase.GetThumbnail)
		{
			output.WriteRawTag(26);
			output.WriteMessage(GetThumbnail);
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
		if (responseCase_ == ResponseOneofCase.GetDefinitions)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GetDefinitions);
		}
		if (responseCase_ == ResponseOneofCase.GetCurrentState)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GetCurrentState);
		}
		if (responseCase_ == ResponseOneofCase.GetThumbnail)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GetThumbnail);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(TestPatternResponse other)
	{
		if (other == null)
		{
			return;
		}
		switch (other.ResponseCase)
		{
		case ResponseOneofCase.GetDefinitions:
			if (GetDefinitions == null)
			{
				GetDefinitions = new Types.GetDefinitions();
			}
			GetDefinitions.MergeFrom(other.GetDefinitions);
			break;
		case ResponseOneofCase.GetCurrentState:
			if (GetCurrentState == null)
			{
				GetCurrentState = new TestPatternState();
			}
			GetCurrentState.MergeFrom(other.GetCurrentState);
			break;
		case ResponseOneofCase.GetThumbnail:
			if (GetThumbnail == null)
			{
				GetThumbnail = new Types.GetThumbnail();
			}
			GetThumbnail.MergeFrom(other.GetThumbnail);
			break;
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
			{
				Types.GetDefinitions getDefinitions = new Types.GetDefinitions();
				if (responseCase_ == ResponseOneofCase.GetDefinitions)
				{
					getDefinitions.MergeFrom(GetDefinitions);
				}
				input.ReadMessage(getDefinitions);
				GetDefinitions = getDefinitions;
				break;
			}
			case 18u:
			{
				TestPatternState testPatternState = new TestPatternState();
				if (responseCase_ == ResponseOneofCase.GetCurrentState)
				{
					testPatternState.MergeFrom(GetCurrentState);
				}
				input.ReadMessage(testPatternState);
				GetCurrentState = testPatternState;
				break;
			}
			case 26u:
			{
				Types.GetThumbnail getThumbnail = new Types.GetThumbnail();
				if (responseCase_ == ResponseOneofCase.GetThumbnail)
				{
					getThumbnail.MergeFrom(GetThumbnail);
				}
				input.ReadMessage(getThumbnail);
				GetThumbnail = getThumbnail;
				break;
			}
			}
		}
	}
}
