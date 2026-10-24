using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class Message : IMessage<Message>, IMessage, IEquatable<Message>, IDeepCloneable<Message>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		public enum ClearType
		{
			[OriginalName("CLEAR_TYPE_MANUAL")]
			Manual,
			[OriginalName("CLEAR_TYPE_AFTER_TIME")]
			AfterTime,
			[OriginalName("CLEAR_TYPE_AFTER_TIMERS")]
			AfterTimers
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Token : IMessage<Token>, IMessage, IEquatable<Token>, IDeepCloneable<Token>
		{
			public enum TokenTypeOneofCase
			{
				None = 0,
				Text = 2,
				Timer = 3,
				Clock = 4
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class TokenTypeText : IMessage<TokenTypeText>, IMessage, IEquatable<TokenTypeText>, IDeepCloneable<TokenTypeText>
				{
					private static readonly MessageParser<TokenTypeText> _parser = new MessageParser<TokenTypeText>(() => new TokenTypeText());

					private UnknownFieldSet _unknownFields;

					public const int NameFieldNumber = 1;

					private string name_ = "";

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<TokenTypeText> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => Token.Descriptor.NestedTypes[0];

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
					public TokenTypeText()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public TokenTypeText(TokenTypeText other)
						: this()
					{
						name_ = other.name_;
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public TokenTypeText Clone()
					{
						return new TokenTypeText(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as TokenTypeText);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(TokenTypeText other)
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
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(TokenTypeText other)
					{
						if (other != null)
						{
							if (other.Name.Length != 0)
							{
								Name = other.Name;
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
								Name = input.ReadString();
							}
						}
					}
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class TokenTypeTimer : IMessage<TokenTypeTimer>, IMessage, IEquatable<TokenTypeTimer>, IDeepCloneable<TokenTypeTimer>
				{
					private static readonly MessageParser<TokenTypeTimer> _parser = new MessageParser<TokenTypeTimer>(() => new TokenTypeTimer());

					private UnknownFieldSet _unknownFields;

					public const int NameFieldNumber = 1;

					private string name_ = "";

					public const int TimerUuidFieldNumber = 2;

					private UUID timerUuid_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<TokenTypeTimer> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => Token.Descriptor.NestedTypes[1];

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
					public UUID TimerUuid
					{
						get
						{
							return timerUuid_;
						}
						set
						{
							timerUuid_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public TokenTypeTimer()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public TokenTypeTimer(TokenTypeTimer other)
						: this()
					{
						name_ = other.name_;
						timerUuid_ = ((other.timerUuid_ != null) ? other.timerUuid_.Clone() : null);
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public TokenTypeTimer Clone()
					{
						return new TokenTypeTimer(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as TokenTypeTimer);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(TokenTypeTimer other)
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
						if (!object.Equals(TimerUuid, other.TimerUuid))
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
						if (timerUuid_ != null)
						{
							num ^= TimerUuid.GetHashCode();
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
						if (timerUuid_ != null)
						{
							output.WriteRawTag(18);
							output.WriteMessage(TimerUuid);
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
						if (timerUuid_ != null)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(TimerUuid);
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(TokenTypeTimer other)
					{
						if (other == null)
						{
							return;
						}
						if (other.Name.Length != 0)
						{
							Name = other.Name;
						}
						if (other.timerUuid_ != null)
						{
							if (timerUuid_ == null)
							{
								TimerUuid = new UUID();
							}
							TimerUuid.MergeFrom(other.TimerUuid);
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
								if (timerUuid_ == null)
								{
									TimerUuid = new UUID();
								}
								input.ReadMessage(TimerUuid);
								break;
							}
						}
					}
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class TokenTypeClock : IMessage<TokenTypeClock>, IMessage, IEquatable<TokenTypeClock>, IDeepCloneable<TokenTypeClock>
				{
					private static readonly MessageParser<TokenTypeClock> _parser = new MessageParser<TokenTypeClock>(() => new TokenTypeClock());

					private UnknownFieldSet _unknownFields;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<TokenTypeClock> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => Token.Descriptor.NestedTypes[2];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public TokenTypeClock()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public TokenTypeClock(TokenTypeClock other)
						: this()
					{
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public TokenTypeClock Clone()
					{
						return new TokenTypeClock(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as TokenTypeClock);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(TokenTypeClock other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						return object.Equals(_unknownFields, other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override int GetHashCode()
					{
						int num = 1;
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
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(TokenTypeClock other)
					{
						if (other != null)
						{
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
							_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
						}
					}
				}
			}

			private static readonly MessageParser<Token> _parser = new MessageParser<Token>(() => new Token());

			private UnknownFieldSet _unknownFields;

			public const int UuidFieldNumber = 1;

			private UUID uuid_;

			public const int TextFieldNumber = 2;

			public const int TimerFieldNumber = 3;

			public const int ClockFieldNumber = 4;

			private object tokenType_;

			private TokenTypeOneofCase tokenTypeCase_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Token> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Message.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public UUID Uuid
			{
				get
				{
					return uuid_;
				}
				set
				{
					uuid_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.TokenTypeText Text
			{
				get
				{
					if (tokenTypeCase_ != TokenTypeOneofCase.Text)
					{
						return null;
					}
					return (Types.TokenTypeText)tokenType_;
				}
				set
				{
					tokenType_ = value;
					tokenTypeCase_ = ((value != null) ? TokenTypeOneofCase.Text : TokenTypeOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.TokenTypeTimer Timer
			{
				get
				{
					if (tokenTypeCase_ != TokenTypeOneofCase.Timer)
					{
						return null;
					}
					return (Types.TokenTypeTimer)tokenType_;
				}
				set
				{
					tokenType_ = value;
					tokenTypeCase_ = ((value != null) ? TokenTypeOneofCase.Timer : TokenTypeOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.TokenTypeClock Clock
			{
				get
				{
					if (tokenTypeCase_ != TokenTypeOneofCase.Clock)
					{
						return null;
					}
					return (Types.TokenTypeClock)tokenType_;
				}
				set
				{
					tokenType_ = value;
					tokenTypeCase_ = ((value != null) ? TokenTypeOneofCase.Clock : TokenTypeOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TokenTypeOneofCase TokenTypeCase => tokenTypeCase_;

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
				uuid_ = ((other.uuid_ != null) ? other.uuid_.Clone() : null);
				switch (other.TokenTypeCase)
				{
				case TokenTypeOneofCase.Text:
					Text = other.Text.Clone();
					break;
				case TokenTypeOneofCase.Timer:
					Timer = other.Timer.Clone();
					break;
				case TokenTypeOneofCase.Clock:
					Clock = other.Clock.Clone();
					break;
				}
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
			public void ClearTokenType()
			{
				tokenTypeCase_ = TokenTypeOneofCase.None;
				tokenType_ = null;
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
				if (!object.Equals(Uuid, other.Uuid))
				{
					return false;
				}
				if (!object.Equals(Text, other.Text))
				{
					return false;
				}
				if (!object.Equals(Timer, other.Timer))
				{
					return false;
				}
				if (!object.Equals(Clock, other.Clock))
				{
					return false;
				}
				if (TokenTypeCase != other.TokenTypeCase)
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
				if (uuid_ != null)
				{
					num ^= Uuid.GetHashCode();
				}
				if (tokenTypeCase_ == TokenTypeOneofCase.Text)
				{
					num ^= Text.GetHashCode();
				}
				if (tokenTypeCase_ == TokenTypeOneofCase.Timer)
				{
					num ^= Timer.GetHashCode();
				}
				if (tokenTypeCase_ == TokenTypeOneofCase.Clock)
				{
					num ^= Clock.GetHashCode();
				}
				num ^= (int)tokenTypeCase_;
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
				if (uuid_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Uuid);
				}
				if (tokenTypeCase_ == TokenTypeOneofCase.Text)
				{
					output.WriteRawTag(18);
					output.WriteMessage(Text);
				}
				if (tokenTypeCase_ == TokenTypeOneofCase.Timer)
				{
					output.WriteRawTag(26);
					output.WriteMessage(Timer);
				}
				if (tokenTypeCase_ == TokenTypeOneofCase.Clock)
				{
					output.WriteRawTag(34);
					output.WriteMessage(Clock);
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
				if (uuid_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Uuid);
				}
				if (tokenTypeCase_ == TokenTypeOneofCase.Text)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Text);
				}
				if (tokenTypeCase_ == TokenTypeOneofCase.Timer)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Timer);
				}
				if (tokenTypeCase_ == TokenTypeOneofCase.Clock)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Clock);
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
				if (other == null)
				{
					return;
				}
				if (other.uuid_ != null)
				{
					if (uuid_ == null)
					{
						Uuid = new UUID();
					}
					Uuid.MergeFrom(other.Uuid);
				}
				switch (other.TokenTypeCase)
				{
				case TokenTypeOneofCase.Text:
					if (Text == null)
					{
						Text = new Types.TokenTypeText();
					}
					Text.MergeFrom(other.Text);
					break;
				case TokenTypeOneofCase.Timer:
					if (Timer == null)
					{
						Timer = new Types.TokenTypeTimer();
					}
					Timer.MergeFrom(other.Timer);
					break;
				case TokenTypeOneofCase.Clock:
					if (Clock == null)
					{
						Clock = new Types.TokenTypeClock();
					}
					Clock.MergeFrom(other.Clock);
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
						if (uuid_ == null)
						{
							Uuid = new UUID();
						}
						input.ReadMessage(Uuid);
						break;
					case 18u:
					{
						Types.TokenTypeText tokenTypeText = new Types.TokenTypeText();
						if (tokenTypeCase_ == TokenTypeOneofCase.Text)
						{
							tokenTypeText.MergeFrom(Text);
						}
						input.ReadMessage(tokenTypeText);
						Text = tokenTypeText;
						break;
					}
					case 26u:
					{
						Types.TokenTypeTimer tokenTypeTimer = new Types.TokenTypeTimer();
						if (tokenTypeCase_ == TokenTypeOneofCase.Timer)
						{
							tokenTypeTimer.MergeFrom(Timer);
						}
						input.ReadMessage(tokenTypeTimer);
						Timer = tokenTypeTimer;
						break;
					}
					case 34u:
					{
						Types.TokenTypeClock tokenTypeClock = new Types.TokenTypeClock();
						if (tokenTypeCase_ == TokenTypeOneofCase.Clock)
						{
							tokenTypeClock.MergeFrom(Clock);
						}
						input.ReadMessage(tokenTypeClock);
						Clock = tokenTypeClock;
						break;
					}
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class TokenValue : IMessage<TokenValue>, IMessage, IEquatable<TokenValue>, IDeepCloneable<TokenValue>
		{
			public enum TokenValueTypeOneofCase
			{
				None = 0,
				Text = 2,
				Timer = 3,
				Clock = 4
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class TokenValueText : IMessage<TokenValueText>, IMessage, IEquatable<TokenValueText>, IDeepCloneable<TokenValueText>
				{
					private static readonly MessageParser<TokenValueText> _parser = new MessageParser<TokenValueText>(() => new TokenValueText());

					private UnknownFieldSet _unknownFields;

					public const int ValueFieldNumber = 1;

					private string value_ = "";

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<TokenValueText> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => TokenValue.Descriptor.NestedTypes[0];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

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
					public TokenValueText()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public TokenValueText(TokenValueText other)
						: this()
					{
						value_ = other.value_;
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public TokenValueText Clone()
					{
						return new TokenValueText(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as TokenValueText);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(TokenValueText other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
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
						if (Value.Length != 0)
						{
							output.WriteRawTag(10);
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
					public void MergeFrom(TokenValueText other)
					{
						if (other != null)
						{
							if (other.Value.Length != 0)
							{
								Value = other.Value;
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
								Value = input.ReadString();
							}
						}
					}
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class TokenValueTimer : IMessage<TokenValueTimer>, IMessage, IEquatable<TokenValueTimer>, IDeepCloneable<TokenValueTimer>
				{
					private static readonly MessageParser<TokenValueTimer> _parser = new MessageParser<TokenValueTimer>(() => new TokenValueTimer());

					private UnknownFieldSet _unknownFields;

					public const int ConfigurationFieldNumber = 1;

					private Timer.Types.Configuration configuration_;

					public const int FormatFieldNumber = 2;

					private Timer.Types.Format format_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<TokenValueTimer> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => TokenValue.Descriptor.NestedTypes[1];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Timer.Types.Configuration Configuration
					{
						get
						{
							return configuration_;
						}
						set
						{
							configuration_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Timer.Types.Format Format
					{
						get
						{
							return format_;
						}
						set
						{
							format_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public TokenValueTimer()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public TokenValueTimer(TokenValueTimer other)
						: this()
					{
						configuration_ = ((other.configuration_ != null) ? other.configuration_.Clone() : null);
						format_ = ((other.format_ != null) ? other.format_.Clone() : null);
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public TokenValueTimer Clone()
					{
						return new TokenValueTimer(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as TokenValueTimer);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(TokenValueTimer other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (!object.Equals(Configuration, other.Configuration))
						{
							return false;
						}
						if (!object.Equals(Format, other.Format))
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
						if (configuration_ != null)
						{
							num ^= Configuration.GetHashCode();
						}
						if (format_ != null)
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
						if (configuration_ != null)
						{
							output.WriteRawTag(10);
							output.WriteMessage(Configuration);
						}
						if (format_ != null)
						{
							output.WriteRawTag(18);
							output.WriteMessage(Format);
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
						if (configuration_ != null)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(Configuration);
						}
						if (format_ != null)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(Format);
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(TokenValueTimer other)
					{
						if (other == null)
						{
							return;
						}
						if (other.configuration_ != null)
						{
							if (configuration_ == null)
							{
								Configuration = new Timer.Types.Configuration();
							}
							Configuration.MergeFrom(other.Configuration);
						}
						if (other.format_ != null)
						{
							if (format_ == null)
							{
								Format = new Timer.Types.Format();
							}
							Format.MergeFrom(other.Format);
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
								if (configuration_ == null)
								{
									Configuration = new Timer.Types.Configuration();
								}
								input.ReadMessage(Configuration);
								break;
							case 18u:
								if (format_ == null)
								{
									Format = new Timer.Types.Format();
								}
								input.ReadMessage(Format);
								break;
							}
						}
					}
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class TokenValueClock : IMessage<TokenValueClock>, IMessage, IEquatable<TokenValueClock>, IDeepCloneable<TokenValueClock>
				{
					private static readonly MessageParser<TokenValueClock> _parser = new MessageParser<TokenValueClock>(() => new TokenValueClock());

					private UnknownFieldSet _unknownFields;

					public const int FormatFieldNumber = 1;

					private Clock.Types.Format format_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<TokenValueClock> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => TokenValue.Descriptor.NestedTypes[2];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Clock.Types.Format Format
					{
						get
						{
							return format_;
						}
						set
						{
							format_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public TokenValueClock()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public TokenValueClock(TokenValueClock other)
						: this()
					{
						format_ = ((other.format_ != null) ? other.format_.Clone() : null);
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public TokenValueClock Clone()
					{
						return new TokenValueClock(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as TokenValueClock);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(TokenValueClock other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (!object.Equals(Format, other.Format))
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
						if (format_ != null)
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
						if (format_ != null)
						{
							output.WriteRawTag(10);
							output.WriteMessage(Format);
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
						if (format_ != null)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(Format);
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(TokenValueClock other)
					{
						if (other == null)
						{
							return;
						}
						if (other.format_ != null)
						{
							if (format_ == null)
							{
								Format = new Clock.Types.Format();
							}
							Format.MergeFrom(other.Format);
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
							if (format_ == null)
							{
								Format = new Clock.Types.Format();
							}
							input.ReadMessage(Format);
						}
					}
				}
			}

			private static readonly MessageParser<TokenValue> _parser = new MessageParser<TokenValue>(() => new TokenValue());

			private UnknownFieldSet _unknownFields;

			public const int TokenIdFieldNumber = 1;

			private UUID tokenId_;

			public const int TextFieldNumber = 2;

			public const int TimerFieldNumber = 3;

			public const int ClockFieldNumber = 4;

			public const int TokenNameFieldNumber = 5;

			private string tokenName_ = "";

			private object tokenValueType_;

			private TokenValueTypeOneofCase tokenValueTypeCase_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<TokenValue> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Message.Descriptor.NestedTypes[1];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public UUID TokenId
			{
				get
				{
					return tokenId_;
				}
				set
				{
					tokenId_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.TokenValueText Text
			{
				get
				{
					if (tokenValueTypeCase_ != TokenValueTypeOneofCase.Text)
					{
						return null;
					}
					return (Types.TokenValueText)tokenValueType_;
				}
				set
				{
					tokenValueType_ = value;
					tokenValueTypeCase_ = ((value != null) ? TokenValueTypeOneofCase.Text : TokenValueTypeOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.TokenValueTimer Timer
			{
				get
				{
					if (tokenValueTypeCase_ != TokenValueTypeOneofCase.Timer)
					{
						return null;
					}
					return (Types.TokenValueTimer)tokenValueType_;
				}
				set
				{
					tokenValueType_ = value;
					tokenValueTypeCase_ = ((value != null) ? TokenValueTypeOneofCase.Timer : TokenValueTypeOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.TokenValueClock Clock
			{
				get
				{
					if (tokenValueTypeCase_ != TokenValueTypeOneofCase.Clock)
					{
						return null;
					}
					return (Types.TokenValueClock)tokenValueType_;
				}
				set
				{
					tokenValueType_ = value;
					tokenValueTypeCase_ = ((value != null) ? TokenValueTypeOneofCase.Clock : TokenValueTypeOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string TokenName
			{
				get
				{
					return tokenName_;
				}
				set
				{
					tokenName_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TokenValueTypeOneofCase TokenValueTypeCase => tokenValueTypeCase_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TokenValue()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TokenValue(TokenValue other)
				: this()
			{
				tokenId_ = ((other.tokenId_ != null) ? other.tokenId_.Clone() : null);
				tokenName_ = other.tokenName_;
				switch (other.TokenValueTypeCase)
				{
				case TokenValueTypeOneofCase.Text:
					Text = other.Text.Clone();
					break;
				case TokenValueTypeOneofCase.Timer:
					Timer = other.Timer.Clone();
					break;
				case TokenValueTypeOneofCase.Clock:
					Clock = other.Clock.Clone();
					break;
				}
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TokenValue Clone()
			{
				return new TokenValue(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void ClearTokenValueType()
			{
				tokenValueTypeCase_ = TokenValueTypeOneofCase.None;
				tokenValueType_ = null;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as TokenValue);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(TokenValue other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(TokenId, other.TokenId))
				{
					return false;
				}
				if (!object.Equals(Text, other.Text))
				{
					return false;
				}
				if (!object.Equals(Timer, other.Timer))
				{
					return false;
				}
				if (!object.Equals(Clock, other.Clock))
				{
					return false;
				}
				if (TokenName != other.TokenName)
				{
					return false;
				}
				if (TokenValueTypeCase != other.TokenValueTypeCase)
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
				if (tokenId_ != null)
				{
					num ^= TokenId.GetHashCode();
				}
				if (tokenValueTypeCase_ == TokenValueTypeOneofCase.Text)
				{
					num ^= Text.GetHashCode();
				}
				if (tokenValueTypeCase_ == TokenValueTypeOneofCase.Timer)
				{
					num ^= Timer.GetHashCode();
				}
				if (tokenValueTypeCase_ == TokenValueTypeOneofCase.Clock)
				{
					num ^= Clock.GetHashCode();
				}
				if (TokenName.Length != 0)
				{
					num ^= TokenName.GetHashCode();
				}
				num ^= (int)tokenValueTypeCase_;
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
				if (tokenId_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(TokenId);
				}
				if (tokenValueTypeCase_ == TokenValueTypeOneofCase.Text)
				{
					output.WriteRawTag(18);
					output.WriteMessage(Text);
				}
				if (tokenValueTypeCase_ == TokenValueTypeOneofCase.Timer)
				{
					output.WriteRawTag(26);
					output.WriteMessage(Timer);
				}
				if (tokenValueTypeCase_ == TokenValueTypeOneofCase.Clock)
				{
					output.WriteRawTag(34);
					output.WriteMessage(Clock);
				}
				if (TokenName.Length != 0)
				{
					output.WriteRawTag(42);
					output.WriteString(TokenName);
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
				if (tokenId_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(TokenId);
				}
				if (tokenValueTypeCase_ == TokenValueTypeOneofCase.Text)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Text);
				}
				if (tokenValueTypeCase_ == TokenValueTypeOneofCase.Timer)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Timer);
				}
				if (tokenValueTypeCase_ == TokenValueTypeOneofCase.Clock)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Clock);
				}
				if (TokenName.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(TokenName);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(TokenValue other)
			{
				if (other == null)
				{
					return;
				}
				if (other.tokenId_ != null)
				{
					if (tokenId_ == null)
					{
						TokenId = new UUID();
					}
					TokenId.MergeFrom(other.TokenId);
				}
				if (other.TokenName.Length != 0)
				{
					TokenName = other.TokenName;
				}
				switch (other.TokenValueTypeCase)
				{
				case TokenValueTypeOneofCase.Text:
					if (Text == null)
					{
						Text = new Types.TokenValueText();
					}
					Text.MergeFrom(other.Text);
					break;
				case TokenValueTypeOneofCase.Timer:
					if (Timer == null)
					{
						Timer = new Types.TokenValueTimer();
					}
					Timer.MergeFrom(other.Timer);
					break;
				case TokenValueTypeOneofCase.Clock:
					if (Clock == null)
					{
						Clock = new Types.TokenValueClock();
					}
					Clock.MergeFrom(other.Clock);
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
						if (tokenId_ == null)
						{
							TokenId = new UUID();
						}
						input.ReadMessage(TokenId);
						break;
					case 18u:
					{
						Types.TokenValueText tokenValueText = new Types.TokenValueText();
						if (tokenValueTypeCase_ == TokenValueTypeOneofCase.Text)
						{
							tokenValueText.MergeFrom(Text);
						}
						input.ReadMessage(tokenValueText);
						Text = tokenValueText;
						break;
					}
					case 26u:
					{
						Types.TokenValueTimer tokenValueTimer = new Types.TokenValueTimer();
						if (tokenValueTypeCase_ == TokenValueTypeOneofCase.Timer)
						{
							tokenValueTimer.MergeFrom(Timer);
						}
						input.ReadMessage(tokenValueTimer);
						Timer = tokenValueTimer;
						break;
					}
					case 34u:
					{
						Types.TokenValueClock tokenValueClock = new Types.TokenValueClock();
						if (tokenValueTypeCase_ == TokenValueTypeOneofCase.Clock)
						{
							tokenValueClock.MergeFrom(Clock);
						}
						input.ReadMessage(tokenValueClock);
						Clock = tokenValueClock;
						break;
					}
					case 42u:
						TokenName = input.ReadString();
						break;
					}
				}
			}
		}
	}

	private static readonly MessageParser<Message> _parser = new MessageParser<Message>(() => new Message());

	private UnknownFieldSet _unknownFields;

	public const int UuidFieldNumber = 1;

	private UUID uuid_;

	public const int TitleFieldNumber = 2;

	private string title_ = "";

	public const int TimeToRemoveFieldNumber = 3;

	private double timeToRemove_;

	public const int VisibleOnNetworkFieldNumber = 4;

	private bool visibleOnNetwork_;

	public const int TemplateFieldNumber = 6;

	private TemplateIdentification template_;

	public const int ClearTypeFieldNumber = 9;

	private Types.ClearType clearType_;

	public const int MessageTextFieldNumber = 10;

	private string messageText_ = "";

	public const int TokensFieldNumber = 11;

	private static readonly FieldCodec<Types.Token> _repeated_tokens_codec = FieldCodec.ForMessage(90u, Types.Token.Parser);

	private readonly RepeatedField<Types.Token> tokens_ = new RepeatedField<Types.Token>();

	public const int TokenValuesFieldNumber = 12;

	private static readonly FieldCodec<Types.TokenValue> _repeated_tokenValues_codec = FieldCodec.ForMessage(98u, Types.TokenValue.Parser);

	private readonly RepeatedField<Types.TokenValue> tokenValues_ = new RepeatedField<Types.TokenValue>();

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<Message> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => MessagesReflection.Descriptor.MessageTypes[0];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public UUID Uuid
	{
		get
		{
			return uuid_;
		}
		set
		{
			uuid_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string Title
	{
		get
		{
			return title_;
		}
		set
		{
			title_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public double TimeToRemove
	{
		get
		{
			return timeToRemove_;
		}
		set
		{
			timeToRemove_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool VisibleOnNetwork
	{
		get
		{
			return visibleOnNetwork_;
		}
		set
		{
			visibleOnNetwork_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TemplateIdentification Template
	{
		get
		{
			return template_;
		}
		set
		{
			template_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.ClearType ClearType
	{
		get
		{
			return clearType_;
		}
		set
		{
			clearType_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string MessageText
	{
		get
		{
			return messageText_;
		}
		set
		{
			messageText_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<Types.Token> Tokens => tokens_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<Types.TokenValue> TokenValues => tokenValues_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Message()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Message(Message other)
		: this()
	{
		uuid_ = ((other.uuid_ != null) ? other.uuid_.Clone() : null);
		title_ = other.title_;
		timeToRemove_ = other.timeToRemove_;
		visibleOnNetwork_ = other.visibleOnNetwork_;
		template_ = ((other.template_ != null) ? other.template_.Clone() : null);
		clearType_ = other.clearType_;
		messageText_ = other.messageText_;
		tokens_ = other.tokens_.Clone();
		tokenValues_ = other.tokenValues_.Clone();
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Message Clone()
	{
		return new Message(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as Message);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(Message other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(Uuid, other.Uuid))
		{
			return false;
		}
		if (Title != other.Title)
		{
			return false;
		}
		if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(TimeToRemove, other.TimeToRemove))
		{
			return false;
		}
		if (VisibleOnNetwork != other.VisibleOnNetwork)
		{
			return false;
		}
		if (!object.Equals(Template, other.Template))
		{
			return false;
		}
		if (ClearType != other.ClearType)
		{
			return false;
		}
		if (MessageText != other.MessageText)
		{
			return false;
		}
		if (!tokens_.Equals(other.tokens_))
		{
			return false;
		}
		if (!tokenValues_.Equals(other.tokenValues_))
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
		if (uuid_ != null)
		{
			num ^= Uuid.GetHashCode();
		}
		if (Title.Length != 0)
		{
			num ^= Title.GetHashCode();
		}
		if (TimeToRemove != 0.0)
		{
			num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(TimeToRemove);
		}
		if (VisibleOnNetwork)
		{
			num ^= VisibleOnNetwork.GetHashCode();
		}
		if (template_ != null)
		{
			num ^= Template.GetHashCode();
		}
		if (ClearType != 0)
		{
			num ^= ClearType.GetHashCode();
		}
		if (MessageText.Length != 0)
		{
			num ^= MessageText.GetHashCode();
		}
		num ^= tokens_.GetHashCode();
		num ^= tokenValues_.GetHashCode();
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
		if (uuid_ != null)
		{
			output.WriteRawTag(10);
			output.WriteMessage(Uuid);
		}
		if (Title.Length != 0)
		{
			output.WriteRawTag(18);
			output.WriteString(Title);
		}
		if (TimeToRemove != 0.0)
		{
			output.WriteRawTag(25);
			output.WriteDouble(TimeToRemove);
		}
		if (VisibleOnNetwork)
		{
			output.WriteRawTag(32);
			output.WriteBool(VisibleOnNetwork);
		}
		if (template_ != null)
		{
			output.WriteRawTag(50);
			output.WriteMessage(Template);
		}
		if (ClearType != 0)
		{
			output.WriteRawTag(72);
			output.WriteEnum((int)ClearType);
		}
		if (MessageText.Length != 0)
		{
			output.WriteRawTag(82);
			output.WriteString(MessageText);
		}
		tokens_.WriteTo(output, _repeated_tokens_codec);
		tokenValues_.WriteTo(output, _repeated_tokenValues_codec);
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
		if (uuid_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Uuid);
		}
		if (Title.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Title);
		}
		if (TimeToRemove != 0.0)
		{
			num += 9;
		}
		if (VisibleOnNetwork)
		{
			num += 2;
		}
		if (template_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Template);
		}
		if (ClearType != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)ClearType);
		}
		if (MessageText.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(MessageText);
		}
		num += tokens_.CalculateSize(_repeated_tokens_codec);
		num += tokenValues_.CalculateSize(_repeated_tokenValues_codec);
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(Message other)
	{
		if (other == null)
		{
			return;
		}
		if (other.uuid_ != null)
		{
			if (uuid_ == null)
			{
				Uuid = new UUID();
			}
			Uuid.MergeFrom(other.Uuid);
		}
		if (other.Title.Length != 0)
		{
			Title = other.Title;
		}
		if (other.TimeToRemove != 0.0)
		{
			TimeToRemove = other.TimeToRemove;
		}
		if (other.VisibleOnNetwork)
		{
			VisibleOnNetwork = other.VisibleOnNetwork;
		}
		if (other.template_ != null)
		{
			if (template_ == null)
			{
				Template = new TemplateIdentification();
			}
			Template.MergeFrom(other.Template);
		}
		if (other.ClearType != 0)
		{
			ClearType = other.ClearType;
		}
		if (other.MessageText.Length != 0)
		{
			MessageText = other.MessageText;
		}
		tokens_.Add(other.tokens_);
		tokenValues_.Add(other.tokenValues_);
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
				if (uuid_ == null)
				{
					Uuid = new UUID();
				}
				input.ReadMessage(Uuid);
				break;
			case 18u:
				Title = input.ReadString();
				break;
			case 25u:
				TimeToRemove = input.ReadDouble();
				break;
			case 32u:
				VisibleOnNetwork = input.ReadBool();
				break;
			case 50u:
				if (template_ == null)
				{
					Template = new TemplateIdentification();
				}
				input.ReadMessage(Template);
				break;
			case 72u:
				ClearType = (Types.ClearType)input.ReadEnum();
				break;
			case 82u:
				MessageText = input.ReadString();
				break;
			case 90u:
				tokens_.AddEntriesFrom(input, _repeated_tokens_codec);
				break;
			case 98u:
				tokenValues_.AddEntriesFrom(input, _repeated_tokenValues_codec);
				break;
			}
		}
	}
}
