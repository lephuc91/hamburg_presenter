using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class CopyrightLayout : IMessage<CopyrightLayout>, IMessage, IEquatable<CopyrightLayout>, IDeepCloneable<CopyrightLayout>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		public enum TokenType
		{
			[OriginalName("Text")]
			Text,
			[OriginalName("Artist")]
			Artist,
			[OriginalName("Author")]
			Author,
			[OriginalName("Publisher")]
			Publisher,
			[OriginalName("Title")]
			Title,
			[OriginalName("CopyrightYear")]
			CopyrightYear,
			[OriginalName("LicenseNumber")]
			LicenseNumber,
			[OriginalName("SongNumber")]
			SongNumber
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Token : IMessage<Token>, IMessage, IEquatable<Token>, IDeepCloneable<Token>
		{
			private static readonly MessageParser<Token> _parser = new MessageParser<Token>(() => new Token());

			private UnknownFieldSet _unknownFields;

			public const int TokenTypeFieldNumber = 1;

			private TokenType tokenType_;

			public const int TextFieldNumber = 2;

			private string text_ = "";

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Token> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => CopyrightLayout.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TokenType TokenType
			{
				get
				{
					return tokenType_;
				}
				set
				{
					tokenType_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string Text
			{
				get
				{
					return text_;
				}
				set
				{
					text_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Token()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Token(Token other)
				: this()
			{
				tokenType_ = other.tokenType_;
				text_ = other.text_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Token Clone()
			{
				return new Token(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Token);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Token other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (TokenType != other.TokenType)
				{
					return false;
				}
				if (Text != other.Text)
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
				if (TokenType != 0)
				{
					num ^= TokenType.GetHashCode();
				}
				if (Text.Length != 0)
				{
					num ^= Text.GetHashCode();
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
				if (TokenType != 0)
				{
					output.WriteRawTag(8);
					output.WriteEnum((int)TokenType);
				}
				if (Text.Length != 0)
				{
					output.WriteRawTag(18);
					output.WriteString(Text);
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
				if (TokenType != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)TokenType);
				}
				if (Text.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Text);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(Token other)
			{
				if (other != null)
				{
					if (other.TokenType != 0)
					{
						TokenType = other.TokenType;
					}
					if (other.Text.Length != 0)
					{
						Text = other.Text;
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
						TokenType = (TokenType)input.ReadEnum();
						break;
					case 18u:
						Text = input.ReadString();
						break;
					}
				}
			}
		}
	}

	private static readonly MessageParser<CopyrightLayout> _parser = new MessageParser<CopyrightLayout>(() => new CopyrightLayout());

	private UnknownFieldSet _unknownFields;

	public const int TokensFieldNumber = 2;

	private static readonly FieldCodec<Types.Token> _repeated_tokens_codec = FieldCodec.ForMessage(18u, Types.Token.Parser);

	private readonly RepeatedField<Types.Token> tokens_ = new RepeatedField<Types.Token>();

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<CopyrightLayout> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => CcliReflection.Descriptor.MessageTypes[1];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<Types.Token> Tokens => tokens_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public CopyrightLayout()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public CopyrightLayout(CopyrightLayout other)
		: this()
	{
		tokens_ = other.tokens_.Clone();
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public CopyrightLayout Clone()
	{
		return new CopyrightLayout(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as CopyrightLayout);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(CopyrightLayout other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!tokens_.Equals(other.tokens_))
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
		num ^= tokens_.GetHashCode();
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
		tokens_.WriteTo(output, _repeated_tokens_codec);
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
		num += tokens_.CalculateSize(_repeated_tokens_codec);
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(CopyrightLayout other)
	{
		if (other != null)
		{
			tokens_.Add(other.tokens_);
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
			if (num != 18)
			{
				_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
			}
			else
			{
				tokens_.AddEntriesFrom(input, _repeated_tokens_codec);
			}
		}
	}
}
