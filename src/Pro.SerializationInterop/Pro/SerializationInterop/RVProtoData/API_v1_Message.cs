using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class API_v1_Message : IMessage<API_v1_Message>, IMessage, IEquatable<API_v1_Message>, IDeepCloneable<API_v1_Message>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class API_v1_MessageToken : IMessage<API_v1_MessageToken>, IMessage, IEquatable<API_v1_MessageToken>, IDeepCloneable<API_v1_MessageToken>
		{
			public enum TokenTypeOneofCase
			{
				None = 0,
				Text = 3,
				Timer = 4,
				Clock = 5
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class API_v1_TextToken : IMessage<API_v1_TextToken>, IMessage, IEquatable<API_v1_TextToken>, IDeepCloneable<API_v1_TextToken>
				{
					private static readonly MessageParser<API_v1_TextToken> _parser = new MessageParser<API_v1_TextToken>(() => new API_v1_TextToken());

					private UnknownFieldSet _unknownFields;

					public const int TextFieldNumber = 1;

					private string text_ = "";

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<API_v1_TextToken> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => API_v1_MessageToken.Descriptor.NestedTypes[0];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

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
					public API_v1_TextToken()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public API_v1_TextToken(API_v1_TextToken other)
						: this()
					{
						text_ = other.text_;
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public API_v1_TextToken Clone()
					{
						return new API_v1_TextToken(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as API_v1_TextToken);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(API_v1_TextToken other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
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
						if (Text.Length != 0)
						{
							output.WriteRawTag(10);
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
					public void MergeFrom(API_v1_TextToken other)
					{
						if (other != null)
						{
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
							if (num != 10)
							{
								_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
							}
							else
							{
								Text = input.ReadString();
							}
						}
					}
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class API_v1_TimerToken : IMessage<API_v1_TimerToken>, IMessage, IEquatable<API_v1_TimerToken>, IDeepCloneable<API_v1_TimerToken>
				{
					public enum TimerConfigurationOneofCase
					{
						None = 0,
						Countdown = 3,
						CountDownToTime = 4,
						Elapsed = 5
					}

					private static readonly MessageParser<API_v1_TimerToken> _parser = new MessageParser<API_v1_TimerToken>(() => new API_v1_TimerToken());

					private UnknownFieldSet _unknownFields;

					public const int IdFieldNumber = 1;

					private API_v1_Identifier id_;

					public const int AllowsOverrunFieldNumber = 2;

					private bool allowsOverrun_;

					public const int CountdownFieldNumber = 3;

					public const int CountDownToTimeFieldNumber = 4;

					public const int ElapsedFieldNumber = 5;

					public const int FormatFieldNumber = 6;

					private API_v1_TimerFormat format_;

					private object timerConfiguration_;

					private TimerConfigurationOneofCase timerConfigurationCase_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<API_v1_TimerToken> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => API_v1_MessageToken.Descriptor.NestedTypes[1];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public API_v1_Identifier Id
					{
						get
						{
							return id_;
						}
						set
						{
							id_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool AllowsOverrun
					{
						get
						{
							return allowsOverrun_;
						}
						set
						{
							allowsOverrun_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public API_v1_Timer.Types.API_v1_Timer_Countdown Countdown
					{
						get
						{
							if (timerConfigurationCase_ != TimerConfigurationOneofCase.Countdown)
							{
								return null;
							}
							return (API_v1_Timer.Types.API_v1_Timer_Countdown)timerConfiguration_;
						}
						set
						{
							timerConfiguration_ = value;
							timerConfigurationCase_ = ((value != null) ? TimerConfigurationOneofCase.Countdown : TimerConfigurationOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public API_v1_Timer.Types.API_v1_Timer_CountdownToTime CountDownToTime
					{
						get
						{
							if (timerConfigurationCase_ != TimerConfigurationOneofCase.CountDownToTime)
							{
								return null;
							}
							return (API_v1_Timer.Types.API_v1_Timer_CountdownToTime)timerConfiguration_;
						}
						set
						{
							timerConfiguration_ = value;
							timerConfigurationCase_ = ((value != null) ? TimerConfigurationOneofCase.CountDownToTime : TimerConfigurationOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public API_v1_Timer.Types.API_v1_Timer_Elapsed Elapsed
					{
						get
						{
							if (timerConfigurationCase_ != TimerConfigurationOneofCase.Elapsed)
							{
								return null;
							}
							return (API_v1_Timer.Types.API_v1_Timer_Elapsed)timerConfiguration_;
						}
						set
						{
							timerConfiguration_ = value;
							timerConfigurationCase_ = ((value != null) ? TimerConfigurationOneofCase.Elapsed : TimerConfigurationOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public API_v1_TimerFormat Format
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
					public TimerConfigurationOneofCase TimerConfigurationCase => timerConfigurationCase_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public API_v1_TimerToken()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public API_v1_TimerToken(API_v1_TimerToken other)
						: this()
					{
						id_ = ((other.id_ != null) ? other.id_.Clone() : null);
						allowsOverrun_ = other.allowsOverrun_;
						format_ = ((other.format_ != null) ? other.format_.Clone() : null);
						switch (other.TimerConfigurationCase)
						{
						case TimerConfigurationOneofCase.Countdown:
							Countdown = other.Countdown.Clone();
							break;
						case TimerConfigurationOneofCase.CountDownToTime:
							CountDownToTime = other.CountDownToTime.Clone();
							break;
						case TimerConfigurationOneofCase.Elapsed:
							Elapsed = other.Elapsed.Clone();
							break;
						}
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public API_v1_TimerToken Clone()
					{
						return new API_v1_TimerToken(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void ClearTimerConfiguration()
					{
						timerConfigurationCase_ = TimerConfigurationOneofCase.None;
						timerConfiguration_ = null;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as API_v1_TimerToken);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(API_v1_TimerToken other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (!object.Equals(Id, other.Id))
						{
							return false;
						}
						if (AllowsOverrun != other.AllowsOverrun)
						{
							return false;
						}
						if (!object.Equals(Countdown, other.Countdown))
						{
							return false;
						}
						if (!object.Equals(CountDownToTime, other.CountDownToTime))
						{
							return false;
						}
						if (!object.Equals(Elapsed, other.Elapsed))
						{
							return false;
						}
						if (!object.Equals(Format, other.Format))
						{
							return false;
						}
						if (TimerConfigurationCase != other.TimerConfigurationCase)
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
						if (id_ != null)
						{
							num ^= Id.GetHashCode();
						}
						if (AllowsOverrun)
						{
							num ^= AllowsOverrun.GetHashCode();
						}
						if (timerConfigurationCase_ == TimerConfigurationOneofCase.Countdown)
						{
							num ^= Countdown.GetHashCode();
						}
						if (timerConfigurationCase_ == TimerConfigurationOneofCase.CountDownToTime)
						{
							num ^= CountDownToTime.GetHashCode();
						}
						if (timerConfigurationCase_ == TimerConfigurationOneofCase.Elapsed)
						{
							num ^= Elapsed.GetHashCode();
						}
						if (format_ != null)
						{
							num ^= Format.GetHashCode();
						}
						num ^= (int)timerConfigurationCase_;
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
						if (id_ != null)
						{
							output.WriteRawTag(10);
							output.WriteMessage(Id);
						}
						if (AllowsOverrun)
						{
							output.WriteRawTag(16);
							output.WriteBool(AllowsOverrun);
						}
						if (timerConfigurationCase_ == TimerConfigurationOneofCase.Countdown)
						{
							output.WriteRawTag(26);
							output.WriteMessage(Countdown);
						}
						if (timerConfigurationCase_ == TimerConfigurationOneofCase.CountDownToTime)
						{
							output.WriteRawTag(34);
							output.WriteMessage(CountDownToTime);
						}
						if (timerConfigurationCase_ == TimerConfigurationOneofCase.Elapsed)
						{
							output.WriteRawTag(42);
							output.WriteMessage(Elapsed);
						}
						if (format_ != null)
						{
							output.WriteRawTag(50);
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
						if (id_ != null)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(Id);
						}
						if (AllowsOverrun)
						{
							num += 2;
						}
						if (timerConfigurationCase_ == TimerConfigurationOneofCase.Countdown)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(Countdown);
						}
						if (timerConfigurationCase_ == TimerConfigurationOneofCase.CountDownToTime)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(CountDownToTime);
						}
						if (timerConfigurationCase_ == TimerConfigurationOneofCase.Elapsed)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(Elapsed);
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
					public void MergeFrom(API_v1_TimerToken other)
					{
						if (other == null)
						{
							return;
						}
						if (other.id_ != null)
						{
							if (id_ == null)
							{
								Id = new API_v1_Identifier();
							}
							Id.MergeFrom(other.Id);
						}
						if (other.AllowsOverrun)
						{
							AllowsOverrun = other.AllowsOverrun;
						}
						if (other.format_ != null)
						{
							if (format_ == null)
							{
								Format = new API_v1_TimerFormat();
							}
							Format.MergeFrom(other.Format);
						}
						switch (other.TimerConfigurationCase)
						{
						case TimerConfigurationOneofCase.Countdown:
							if (Countdown == null)
							{
								Countdown = new API_v1_Timer.Types.API_v1_Timer_Countdown();
							}
							Countdown.MergeFrom(other.Countdown);
							break;
						case TimerConfigurationOneofCase.CountDownToTime:
							if (CountDownToTime == null)
							{
								CountDownToTime = new API_v1_Timer.Types.API_v1_Timer_CountdownToTime();
							}
							CountDownToTime.MergeFrom(other.CountDownToTime);
							break;
						case TimerConfigurationOneofCase.Elapsed:
							if (Elapsed == null)
							{
								Elapsed = new API_v1_Timer.Types.API_v1_Timer_Elapsed();
							}
							Elapsed.MergeFrom(other.Elapsed);
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
								if (id_ == null)
								{
									Id = new API_v1_Identifier();
								}
								input.ReadMessage(Id);
								break;
							case 16u:
								AllowsOverrun = input.ReadBool();
								break;
							case 26u:
							{
								API_v1_Timer.Types.API_v1_Timer_Countdown aPI_v1_Timer_Countdown = new API_v1_Timer.Types.API_v1_Timer_Countdown();
								if (timerConfigurationCase_ == TimerConfigurationOneofCase.Countdown)
								{
									aPI_v1_Timer_Countdown.MergeFrom(Countdown);
								}
								input.ReadMessage(aPI_v1_Timer_Countdown);
								Countdown = aPI_v1_Timer_Countdown;
								break;
							}
							case 34u:
							{
								API_v1_Timer.Types.API_v1_Timer_CountdownToTime aPI_v1_Timer_CountdownToTime = new API_v1_Timer.Types.API_v1_Timer_CountdownToTime();
								if (timerConfigurationCase_ == TimerConfigurationOneofCase.CountDownToTime)
								{
									aPI_v1_Timer_CountdownToTime.MergeFrom(CountDownToTime);
								}
								input.ReadMessage(aPI_v1_Timer_CountdownToTime);
								CountDownToTime = aPI_v1_Timer_CountdownToTime;
								break;
							}
							case 42u:
							{
								API_v1_Timer.Types.API_v1_Timer_Elapsed aPI_v1_Timer_Elapsed = new API_v1_Timer.Types.API_v1_Timer_Elapsed();
								if (timerConfigurationCase_ == TimerConfigurationOneofCase.Elapsed)
								{
									aPI_v1_Timer_Elapsed.MergeFrom(Elapsed);
								}
								input.ReadMessage(aPI_v1_Timer_Elapsed);
								Elapsed = aPI_v1_Timer_Elapsed;
								break;
							}
							case 50u:
								if (format_ == null)
								{
									Format = new API_v1_TimerFormat();
								}
								input.ReadMessage(Format);
								break;
							}
						}
					}
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class API_v1_ClockToken : IMessage<API_v1_ClockToken>, IMessage, IEquatable<API_v1_ClockToken>, IDeepCloneable<API_v1_ClockToken>
				{
					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static class Types
					{
						public enum API_v1_ClockTokenFormat
						{
							[OriginalName("none")]
							None,
							[OriginalName("short")]
							Short,
							[OriginalName("medium")]
							Medium,
							[OriginalName("long")]
							Long,
							[OriginalName("full")]
							Full
						}
					}

					private static readonly MessageParser<API_v1_ClockToken> _parser = new MessageParser<API_v1_ClockToken>(() => new API_v1_ClockToken());

					private UnknownFieldSet _unknownFields;

					public const int DateFieldNumber = 1;

					private Types.API_v1_ClockTokenFormat date_;

					public const int TimeFieldNumber = 2;

					private Types.API_v1_ClockTokenFormat time_;

					public const int Is24HoursFieldNumber = 3;

					private bool is24Hours_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<API_v1_ClockToken> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => API_v1_MessageToken.Descriptor.NestedTypes[2];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Types.API_v1_ClockTokenFormat Date
					{
						get
						{
							return date_;
						}
						set
						{
							date_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Types.API_v1_ClockTokenFormat Time
					{
						get
						{
							return time_;
						}
						set
						{
							time_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Is24Hours
					{
						get
						{
							return is24Hours_;
						}
						set
						{
							is24Hours_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public API_v1_ClockToken()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public API_v1_ClockToken(API_v1_ClockToken other)
						: this()
					{
						date_ = other.date_;
						time_ = other.time_;
						is24Hours_ = other.is24Hours_;
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public API_v1_ClockToken Clone()
					{
						return new API_v1_ClockToken(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as API_v1_ClockToken);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(API_v1_ClockToken other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (Date != other.Date)
						{
							return false;
						}
						if (Time != other.Time)
						{
							return false;
						}
						if (Is24Hours != other.Is24Hours)
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
						if (Date != 0)
						{
							num ^= Date.GetHashCode();
						}
						if (Time != 0)
						{
							num ^= Time.GetHashCode();
						}
						if (Is24Hours)
						{
							num ^= Is24Hours.GetHashCode();
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
						if (Date != 0)
						{
							output.WriteRawTag(8);
							output.WriteEnum((int)Date);
						}
						if (Time != 0)
						{
							output.WriteRawTag(16);
							output.WriteEnum((int)Time);
						}
						if (Is24Hours)
						{
							output.WriteRawTag(24);
							output.WriteBool(Is24Hours);
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
						if (Date != 0)
						{
							num += 1 + CodedOutputStream.ComputeEnumSize((int)Date);
						}
						if (Time != 0)
						{
							num += 1 + CodedOutputStream.ComputeEnumSize((int)Time);
						}
						if (Is24Hours)
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
					public void MergeFrom(API_v1_ClockToken other)
					{
						if (other != null)
						{
							if (other.Date != 0)
							{
								Date = other.Date;
							}
							if (other.Time != 0)
							{
								Time = other.Time;
							}
							if (other.Is24Hours)
							{
								Is24Hours = other.Is24Hours;
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
								Date = (Types.API_v1_ClockTokenFormat)input.ReadEnum();
								break;
							case 16u:
								Time = (Types.API_v1_ClockTokenFormat)input.ReadEnum();
								break;
							case 24u:
								Is24Hours = input.ReadBool();
								break;
							}
						}
					}
				}
			}

			private static readonly MessageParser<API_v1_MessageToken> _parser = new MessageParser<API_v1_MessageToken>(() => new API_v1_MessageToken());

			private UnknownFieldSet _unknownFields;

			public const int UuidFieldNumber = 1;

			private string uuid_ = "";

			public const int NameFieldNumber = 2;

			private string name_ = "";

			public const int TextFieldNumber = 3;

			public const int TimerFieldNumber = 4;

			public const int ClockFieldNumber = 5;

			private object tokenType_;

			private TokenTypeOneofCase tokenTypeCase_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<API_v1_MessageToken> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Message.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string Uuid
			{
				get
				{
					return uuid_;
				}
				set
				{
					uuid_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

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
			public Types.API_v1_TextToken Text
			{
				get
				{
					if (tokenTypeCase_ != TokenTypeOneofCase.Text)
					{
						return null;
					}
					return (Types.API_v1_TextToken)tokenType_;
				}
				set
				{
					tokenType_ = value;
					tokenTypeCase_ = ((value != null) ? TokenTypeOneofCase.Text : TokenTypeOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.API_v1_TimerToken Timer
			{
				get
				{
					if (tokenTypeCase_ != TokenTypeOneofCase.Timer)
					{
						return null;
					}
					return (Types.API_v1_TimerToken)tokenType_;
				}
				set
				{
					tokenType_ = value;
					tokenTypeCase_ = ((value != null) ? TokenTypeOneofCase.Timer : TokenTypeOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.API_v1_ClockToken Clock
			{
				get
				{
					if (tokenTypeCase_ != TokenTypeOneofCase.Clock)
					{
						return null;
					}
					return (Types.API_v1_ClockToken)tokenType_;
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
			public API_v1_MessageToken()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_MessageToken(API_v1_MessageToken other)
				: this()
			{
				uuid_ = other.uuid_;
				name_ = other.name_;
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
			public API_v1_MessageToken Clone()
			{
				return new API_v1_MessageToken(this);
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
				return Equals(other as API_v1_MessageToken);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(API_v1_MessageToken other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (Uuid != other.Uuid)
				{
					return false;
				}
				if (Name != other.Name)
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
				if (Uuid.Length != 0)
				{
					num ^= Uuid.GetHashCode();
				}
				if (Name.Length != 0)
				{
					num ^= Name.GetHashCode();
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
				if (Uuid.Length != 0)
				{
					output.WriteRawTag(10);
					output.WriteString(Uuid);
				}
				if (Name.Length != 0)
				{
					output.WriteRawTag(18);
					output.WriteString(Name);
				}
				if (tokenTypeCase_ == TokenTypeOneofCase.Text)
				{
					output.WriteRawTag(26);
					output.WriteMessage(Text);
				}
				if (tokenTypeCase_ == TokenTypeOneofCase.Timer)
				{
					output.WriteRawTag(34);
					output.WriteMessage(Timer);
				}
				if (tokenTypeCase_ == TokenTypeOneofCase.Clock)
				{
					output.WriteRawTag(42);
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
				if (Uuid.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Uuid);
				}
				if (Name.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Name);
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
			public void MergeFrom(API_v1_MessageToken other)
			{
				if (other == null)
				{
					return;
				}
				if (other.Uuid.Length != 0)
				{
					Uuid = other.Uuid;
				}
				if (other.Name.Length != 0)
				{
					Name = other.Name;
				}
				switch (other.TokenTypeCase)
				{
				case TokenTypeOneofCase.Text:
					if (Text == null)
					{
						Text = new Types.API_v1_TextToken();
					}
					Text.MergeFrom(other.Text);
					break;
				case TokenTypeOneofCase.Timer:
					if (Timer == null)
					{
						Timer = new Types.API_v1_TimerToken();
					}
					Timer.MergeFrom(other.Timer);
					break;
				case TokenTypeOneofCase.Clock:
					if (Clock == null)
					{
						Clock = new Types.API_v1_ClockToken();
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
						Uuid = input.ReadString();
						break;
					case 18u:
						Name = input.ReadString();
						break;
					case 26u:
					{
						Types.API_v1_TextToken aPI_v1_TextToken = new Types.API_v1_TextToken();
						if (tokenTypeCase_ == TokenTypeOneofCase.Text)
						{
							aPI_v1_TextToken.MergeFrom(Text);
						}
						input.ReadMessage(aPI_v1_TextToken);
						Text = aPI_v1_TextToken;
						break;
					}
					case 34u:
					{
						Types.API_v1_TimerToken aPI_v1_TimerToken = new Types.API_v1_TimerToken();
						if (tokenTypeCase_ == TokenTypeOneofCase.Timer)
						{
							aPI_v1_TimerToken.MergeFrom(Timer);
						}
						input.ReadMessage(aPI_v1_TimerToken);
						Timer = aPI_v1_TimerToken;
						break;
					}
					case 42u:
					{
						Types.API_v1_ClockToken aPI_v1_ClockToken = new Types.API_v1_ClockToken();
						if (tokenTypeCase_ == TokenTypeOneofCase.Clock)
						{
							aPI_v1_ClockToken.MergeFrom(Clock);
						}
						input.ReadMessage(aPI_v1_ClockToken);
						Clock = aPI_v1_ClockToken;
						break;
					}
					}
				}
			}
		}
	}

	private static readonly MessageParser<API_v1_Message> _parser = new MessageParser<API_v1_Message>(() => new API_v1_Message());

	private UnknownFieldSet _unknownFields;

	public const int IdFieldNumber = 1;

	private API_v1_Identifier id_;

	public const int MessageFieldNumber = 2;

	private string message_ = "";

	public const int TokensFieldNumber = 3;

	private static readonly FieldCodec<Types.API_v1_MessageToken> _repeated_tokens_codec = FieldCodec.ForMessage(26u, Types.API_v1_MessageToken.Parser);

	private readonly RepeatedField<Types.API_v1_MessageToken> tokens_ = new RepeatedField<Types.API_v1_MessageToken>();

	public const int ThemeFieldNumber = 4;

	private API_v1_Identifier theme_;

	public const int VisibleOnNetworkFieldNumber = 5;

	private bool visibleOnNetwork_;

	public const int IsActiveFieldNumber = 6;

	private bool isActive_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<API_v1_Message> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProApiV1MessageReflection.Descriptor.MessageTypes[0];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Identifier Id
	{
		get
		{
			return id_;
		}
		set
		{
			id_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string Message
	{
		get
		{
			return message_;
		}
		set
		{
			message_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<Types.API_v1_MessageToken> Tokens => tokens_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Identifier Theme
	{
		get
		{
			return theme_;
		}
		set
		{
			theme_ = value;
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
	public bool IsActive
	{
		get
		{
			return isActive_;
		}
		set
		{
			isActive_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Message()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Message(API_v1_Message other)
		: this()
	{
		id_ = ((other.id_ != null) ? other.id_.Clone() : null);
		message_ = other.message_;
		tokens_ = other.tokens_.Clone();
		theme_ = ((other.theme_ != null) ? other.theme_.Clone() : null);
		visibleOnNetwork_ = other.visibleOnNetwork_;
		isActive_ = other.isActive_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Message Clone()
	{
		return new API_v1_Message(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as API_v1_Message);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(API_v1_Message other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(Id, other.Id))
		{
			return false;
		}
		if (Message != other.Message)
		{
			return false;
		}
		if (!tokens_.Equals(other.tokens_))
		{
			return false;
		}
		if (!object.Equals(Theme, other.Theme))
		{
			return false;
		}
		if (VisibleOnNetwork != other.VisibleOnNetwork)
		{
			return false;
		}
		if (IsActive != other.IsActive)
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
		if (id_ != null)
		{
			num ^= Id.GetHashCode();
		}
		if (Message.Length != 0)
		{
			num ^= Message.GetHashCode();
		}
		num ^= tokens_.GetHashCode();
		if (theme_ != null)
		{
			num ^= Theme.GetHashCode();
		}
		if (VisibleOnNetwork)
		{
			num ^= VisibleOnNetwork.GetHashCode();
		}
		if (IsActive)
		{
			num ^= IsActive.GetHashCode();
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
		if (id_ != null)
		{
			output.WriteRawTag(10);
			output.WriteMessage(Id);
		}
		if (Message.Length != 0)
		{
			output.WriteRawTag(18);
			output.WriteString(Message);
		}
		tokens_.WriteTo(output, _repeated_tokens_codec);
		if (theme_ != null)
		{
			output.WriteRawTag(34);
			output.WriteMessage(Theme);
		}
		if (VisibleOnNetwork)
		{
			output.WriteRawTag(40);
			output.WriteBool(VisibleOnNetwork);
		}
		if (IsActive)
		{
			output.WriteRawTag(48);
			output.WriteBool(IsActive);
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
		if (id_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Id);
		}
		if (Message.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Message);
		}
		num += tokens_.CalculateSize(_repeated_tokens_codec);
		if (theme_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Theme);
		}
		if (VisibleOnNetwork)
		{
			num += 2;
		}
		if (IsActive)
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
	public void MergeFrom(API_v1_Message other)
	{
		if (other == null)
		{
			return;
		}
		if (other.id_ != null)
		{
			if (id_ == null)
			{
				Id = new API_v1_Identifier();
			}
			Id.MergeFrom(other.Id);
		}
		if (other.Message.Length != 0)
		{
			Message = other.Message;
		}
		tokens_.Add(other.tokens_);
		if (other.theme_ != null)
		{
			if (theme_ == null)
			{
				Theme = new API_v1_Identifier();
			}
			Theme.MergeFrom(other.Theme);
		}
		if (other.VisibleOnNetwork)
		{
			VisibleOnNetwork = other.VisibleOnNetwork;
		}
		if (other.IsActive)
		{
			IsActive = other.IsActive;
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
				if (id_ == null)
				{
					Id = new API_v1_Identifier();
				}
				input.ReadMessage(Id);
				break;
			case 18u:
				Message = input.ReadString();
				break;
			case 26u:
				tokens_.AddEntriesFrom(input, _repeated_tokens_codec);
				break;
			case 34u:
				if (theme_ == null)
				{
					Theme = new API_v1_Identifier();
				}
				input.ReadMessage(Theme);
				break;
			case 40u:
				VisibleOnNetwork = input.ReadBool();
				break;
			case 48u:
				IsActive = input.ReadBool();
				break;
			}
		}
	}
}
