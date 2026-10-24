using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class Slide : IMessage<Slide>, IMessage, IEquatable<Slide>, IDeepCloneable<Slide>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Element : IMessage<Element>, IMessage, IEquatable<Element>, IDeepCloneable<Element>
		{
			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				public enum TextRevealType
				{
					[OriginalName("TEXT_REVEAL_TYPE_NONE")]
					None,
					[OriginalName("TEXT_REVEAL_TYPE_BULLET")]
					Bullet,
					[OriginalName("TEXT_REVEAL_TYPE_UNDERLINE")]
					Underline
				}

				public enum Info
				{
					[OriginalName("INFO_NONE")]
					None = 0,
					[OriginalName("INFO_IS_TEMPLATE_ELEMENT")]
					IsTemplateElement = 1,
					[OriginalName("INFO_IS_TEXT_ELEMENT")]
					IsTextElement = 2,
					[OriginalName("INFO_IS_TEXT_TICKER")]
					IsTextTicker = 4
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class Build : IMessage<Build>, IMessage, IEquatable<Build>, IDeepCloneable<Build>
				{
					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static class Types
					{
						public enum Start
						{
							[OriginalName("START_ON_CLICK")]
							OnClick,
							[OriginalName("START_WITH_PREVIOUS")]
							WithPrevious,
							[OriginalName("START_AFTER_PREVIOUS")]
							AfterPrevious,
							[OriginalName("START_WITH_SLIDE")]
							WithSlide
						}
					}

					private static readonly MessageParser<Build> _parser = new MessageParser<Build>(() => new Build());

					private UnknownFieldSet _unknownFields;

					public const int UuidFieldNumber = 1;

					private UUID uuid_;

					public const int ElementUUIDFieldNumber = 2;

					private UUID elementUUID_;

					public const int StartFieldNumber = 3;

					private Types.Start start_;

					public const int DelayTimeFieldNumber = 4;

					private double delayTime_;

					public const int TransitionFieldNumber = 5;

					private Transition transition_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<Build> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => Element.Descriptor.NestedTypes[0];

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
					public UUID ElementUUID
					{
						get
						{
							return elementUUID_;
						}
						set
						{
							elementUUID_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Types.Start Start
					{
						get
						{
							return start_;
						}
						set
						{
							start_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public double DelayTime
					{
						get
						{
							return delayTime_;
						}
						set
						{
							delayTime_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Transition Transition
					{
						get
						{
							return transition_;
						}
						set
						{
							transition_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Build()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Build(Build other)
						: this()
					{
						uuid_ = ((other.uuid_ != null) ? other.uuid_.Clone() : null);
						elementUUID_ = ((other.elementUUID_ != null) ? other.elementUUID_.Clone() : null);
						start_ = other.start_;
						delayTime_ = other.delayTime_;
						transition_ = ((other.transition_ != null) ? other.transition_.Clone() : null);
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Build Clone()
					{
						return new Build(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as Build);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(Build other)
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
						if (!object.Equals(ElementUUID, other.ElementUUID))
						{
							return false;
						}
						if (Start != other.Start)
						{
							return false;
						}
						if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(DelayTime, other.DelayTime))
						{
							return false;
						}
						if (!object.Equals(Transition, other.Transition))
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
						if (elementUUID_ != null)
						{
							num ^= ElementUUID.GetHashCode();
						}
						if (Start != 0)
						{
							num ^= Start.GetHashCode();
						}
						if (DelayTime != 0.0)
						{
							num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(DelayTime);
						}
						if (transition_ != null)
						{
							num ^= Transition.GetHashCode();
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
						if (uuid_ != null)
						{
							output.WriteRawTag(10);
							output.WriteMessage(Uuid);
						}
						if (elementUUID_ != null)
						{
							output.WriteRawTag(18);
							output.WriteMessage(ElementUUID);
						}
						if (Start != 0)
						{
							output.WriteRawTag(24);
							output.WriteEnum((int)Start);
						}
						if (DelayTime != 0.0)
						{
							output.WriteRawTag(33);
							output.WriteDouble(DelayTime);
						}
						if (transition_ != null)
						{
							output.WriteRawTag(42);
							output.WriteMessage(Transition);
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
						if (elementUUID_ != null)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(ElementUUID);
						}
						if (Start != 0)
						{
							num += 1 + CodedOutputStream.ComputeEnumSize((int)Start);
						}
						if (DelayTime != 0.0)
						{
							num += 9;
						}
						if (transition_ != null)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(Transition);
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(Build other)
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
						if (other.elementUUID_ != null)
						{
							if (elementUUID_ == null)
							{
								ElementUUID = new UUID();
							}
							ElementUUID.MergeFrom(other.ElementUUID);
						}
						if (other.Start != 0)
						{
							Start = other.Start;
						}
						if (other.DelayTime != 0.0)
						{
							DelayTime = other.DelayTime;
						}
						if (other.transition_ != null)
						{
							if (transition_ == null)
							{
								Transition = new Transition();
							}
							Transition.MergeFrom(other.Transition);
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
								if (elementUUID_ == null)
								{
									ElementUUID = new UUID();
								}
								input.ReadMessage(ElementUUID);
								break;
							case 24u:
								Start = (Types.Start)input.ReadEnum();
								break;
							case 33u:
								DelayTime = input.ReadDouble();
								break;
							case 42u:
								if (transition_ == null)
								{
									Transition = new Transition();
								}
								input.ReadMessage(Transition);
								break;
							}
						}
					}
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class ChildBuild : IMessage<ChildBuild>, IMessage, IEquatable<ChildBuild>, IDeepCloneable<ChildBuild>
				{
					private static readonly MessageParser<ChildBuild> _parser = new MessageParser<ChildBuild>(() => new ChildBuild());

					private UnknownFieldSet _unknownFields;

					public const int UuidFieldNumber = 1;

					private UUID uuid_;

					public const int StartFieldNumber = 2;

					private Build.Types.Start start_;

					public const int DelayTimeFieldNumber = 3;

					private double delayTime_;

					public const int IndexFieldNumber = 4;

					private uint index_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<ChildBuild> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => Element.Descriptor.NestedTypes[1];

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
					public Build.Types.Start Start
					{
						get
						{
							return start_;
						}
						set
						{
							start_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public double DelayTime
					{
						get
						{
							return delayTime_;
						}
						set
						{
							delayTime_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public uint Index
					{
						get
						{
							return index_;
						}
						set
						{
							index_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public ChildBuild()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public ChildBuild(ChildBuild other)
						: this()
					{
						uuid_ = ((other.uuid_ != null) ? other.uuid_.Clone() : null);
						start_ = other.start_;
						delayTime_ = other.delayTime_;
						index_ = other.index_;
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public ChildBuild Clone()
					{
						return new ChildBuild(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as ChildBuild);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(ChildBuild other)
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
						if (Start != other.Start)
						{
							return false;
						}
						if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(DelayTime, other.DelayTime))
						{
							return false;
						}
						if (Index != other.Index)
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
						if (Start != 0)
						{
							num ^= Start.GetHashCode();
						}
						if (DelayTime != 0.0)
						{
							num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(DelayTime);
						}
						if (Index != 0)
						{
							num ^= Index.GetHashCode();
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
						if (uuid_ != null)
						{
							output.WriteRawTag(10);
							output.WriteMessage(Uuid);
						}
						if (Start != 0)
						{
							output.WriteRawTag(16);
							output.WriteEnum((int)Start);
						}
						if (DelayTime != 0.0)
						{
							output.WriteRawTag(25);
							output.WriteDouble(DelayTime);
						}
						if (Index != 0)
						{
							output.WriteRawTag(32);
							output.WriteUInt32(Index);
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
						if (Start != 0)
						{
							num += 1 + CodedOutputStream.ComputeEnumSize((int)Start);
						}
						if (DelayTime != 0.0)
						{
							num += 9;
						}
						if (Index != 0)
						{
							num += 1 + CodedOutputStream.ComputeUInt32Size(Index);
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(ChildBuild other)
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
						if (other.Start != 0)
						{
							Start = other.Start;
						}
						if (other.DelayTime != 0.0)
						{
							DelayTime = other.DelayTime;
						}
						if (other.Index != 0)
						{
							Index = other.Index;
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
							case 16u:
								Start = (Build.Types.Start)input.ReadEnum();
								break;
							case 25u:
								DelayTime = input.ReadDouble();
								break;
							case 32u:
								Index = input.ReadUInt32();
								break;
							}
						}
					}
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class DataLink : IMessage<DataLink>, IMessage, IEquatable<DataLink>, IDeepCloneable<DataLink>
				{
					public enum PropertyTypeOneofCase
					{
						None = 0,
						Ticker = 1,
						AlternateText = 2,
						TimerText = 3,
						ClockText = 4,
						ChordChart = 5,
						OutputScreen = 6,
						PcoLive = 7,
						AlternateFill = 8,
						VisibilityLink = 9,
						SlideText = 10,
						StageMessage = 11,
						VideoCountdown = 12,
						SlideImage = 13,
						CcliText = 14,
						GroupName = 15,
						GroupColor = 16,
						PresentationNotes = 17,
						PlaylistItem = 18,
						AutoAdvanceTimeRemaining = 19,
						CaptureStatusText = 20,
						CaptureStatusColor = 21,
						SlideCount = 22,
						AudioCountdown = 23,
						Presentation = 24,
						SlideLabelText = 25,
						SlideLabelColor = 26,
						RssFeed = 27,
						FileFeed = 28,
						ChordProChart = 29,
						PlaybackMarkerText = 30,
						PlaybackMarkerColor = 32,
						TimecodeText = 33,
						TimecodeStatus = 34,
						MessageText = 35,
						KeyValueText = 36,
						KeyValueFill = 37,
						Zone = 38
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static class Types
					{
						public enum SlideSourceType
						{
							[OriginalName("SLIDE_SOURCE_TYPE_CURRENT_SLIDE")]
							CurrentSlide,
							[OriginalName("SLIDE_SOURCE_TYPE_NEXT_SLIDE")]
							NextSlide
						}

						public enum GroupSourceType
						{
							[OriginalName("GROUP_SOURCE_TYPE_CURRENT_SLIDE")]
							CurrentSlide,
							[OriginalName("GROUP_SOURCE_TYPE_NEXT_SLIDE")]
							NextSlide,
							[OriginalName("GROUP_SOURCE_TYPE_NEXT_GROUP")]
							NextGroup
						}

						public enum SlideLabelSource
						{
							[OriginalName("SLIDE_LABEL_SOURCE_CURRENT_SLIDE")]
							CurrentSlide,
							[OriginalName("SLIDE_LABEL_SOURCE_NEXT_SLIDE")]
							NextSlide
						}

						[DebuggerDisplay("{ToString(),nq}")]
						public sealed class RSSFeed : IMessage<RSSFeed>, IMessage, IEquatable<RSSFeed>, IDeepCloneable<RSSFeed>
						{
							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static class Types
							{
								public enum ContentType
								{
									[OriginalName("CONTENT_TYPE_TITLE_ONLY")]
									TitleOnly,
									[OriginalName("CONTENT_TYPE_TITLE_AND_DESCRIPTION")]
									TitleAndDescription
								}
							}

							private static readonly MessageParser<RSSFeed> _parser = new MessageParser<RSSFeed>(() => new RSSFeed());

							private UnknownFieldSet _unknownFields;

							public const int UrlFieldNumber = 1;

							private URL url_;

							public const int ContentFieldNumber = 2;

							private Types.ContentType content_;

							public const int TextDelimiterFieldNumber = 3;

							private string textDelimiter_ = "";

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageParser<RSSFeed> Parser => _parser;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageDescriptor Descriptor => DataLink.Descriptor.NestedTypes[0];

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							MessageDescriptor IMessage.Descriptor => Descriptor;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public URL Url
							{
								get
								{
									return url_;
								}
								set
								{
									url_ = value;
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Types.ContentType Content
							{
								get
								{
									return content_;
								}
								set
								{
									content_ = value;
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public string TextDelimiter
							{
								get
								{
									return textDelimiter_;
								}
								set
								{
									textDelimiter_ = ProtoPreconditions.CheckNotNull(value, "value");
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public RSSFeed()
							{
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public RSSFeed(RSSFeed other)
								: this()
							{
								url_ = ((other.url_ != null) ? other.url_.Clone() : null);
								content_ = other.content_;
								textDelimiter_ = other.textDelimiter_;
								_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public RSSFeed Clone()
							{
								return new RSSFeed(this);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public override bool Equals(object other)
							{
								return Equals(other as RSSFeed);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool Equals(RSSFeed other)
							{
								if (other == null)
								{
									return false;
								}
								if (other == this)
								{
									return true;
								}
								if (!object.Equals(Url, other.Url))
								{
									return false;
								}
								if (Content != other.Content)
								{
									return false;
								}
								if (TextDelimiter != other.TextDelimiter)
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
								if (url_ != null)
								{
									num ^= Url.GetHashCode();
								}
								if (Content != 0)
								{
									num ^= Content.GetHashCode();
								}
								if (TextDelimiter.Length != 0)
								{
									num ^= TextDelimiter.GetHashCode();
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
								if (url_ != null)
								{
									output.WriteRawTag(10);
									output.WriteMessage(Url);
								}
								if (Content != 0)
								{
									output.WriteRawTag(16);
									output.WriteEnum((int)Content);
								}
								if (TextDelimiter.Length != 0)
								{
									output.WriteRawTag(26);
									output.WriteString(TextDelimiter);
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
								if (url_ != null)
								{
									num += 1 + CodedOutputStream.ComputeMessageSize(Url);
								}
								if (Content != 0)
								{
									num += 1 + CodedOutputStream.ComputeEnumSize((int)Content);
								}
								if (TextDelimiter.Length != 0)
								{
									num += 1 + CodedOutputStream.ComputeStringSize(TextDelimiter);
								}
								if (_unknownFields != null)
								{
									num += _unknownFields.CalculateSize();
								}
								return num;
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public void MergeFrom(RSSFeed other)
							{
								if (other == null)
								{
									return;
								}
								if (other.url_ != null)
								{
									if (url_ == null)
									{
										Url = new URL();
									}
									Url.MergeFrom(other.Url);
								}
								if (other.Content != 0)
								{
									Content = other.Content;
								}
								if (other.TextDelimiter.Length != 0)
								{
									TextDelimiter = other.TextDelimiter;
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
										if (url_ == null)
										{
											Url = new URL();
										}
										input.ReadMessage(Url);
										break;
									case 16u:
										Content = (Types.ContentType)input.ReadEnum();
										break;
									case 26u:
										TextDelimiter = input.ReadString();
										break;
									}
								}
							}
						}

						[DebuggerDisplay("{ToString(),nq}")]
						public sealed class FileFeed : IMessage<FileFeed>, IMessage, IEquatable<FileFeed>, IDeepCloneable<FileFeed>
						{
							private static readonly MessageParser<FileFeed> _parser = new MessageParser<FileFeed>(() => new FileFeed());

							private UnknownFieldSet _unknownFields;

							public const int UrlFieldNumber = 1;

							private URL url_;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageParser<FileFeed> Parser => _parser;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageDescriptor Descriptor => DataLink.Descriptor.NestedTypes[1];

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							MessageDescriptor IMessage.Descriptor => Descriptor;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public URL Url
							{
								get
								{
									return url_;
								}
								set
								{
									url_ = value;
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public FileFeed()
							{
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public FileFeed(FileFeed other)
								: this()
							{
								url_ = ((other.url_ != null) ? other.url_.Clone() : null);
								_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public FileFeed Clone()
							{
								return new FileFeed(this);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public override bool Equals(object other)
							{
								return Equals(other as FileFeed);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool Equals(FileFeed other)
							{
								if (other == null)
								{
									return false;
								}
								if (other == this)
								{
									return true;
								}
								if (!object.Equals(Url, other.Url))
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
								if (url_ != null)
								{
									num ^= Url.GetHashCode();
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
								if (url_ != null)
								{
									output.WriteRawTag(10);
									output.WriteMessage(Url);
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
								if (url_ != null)
								{
									num += 1 + CodedOutputStream.ComputeMessageSize(Url);
								}
								if (_unknownFields != null)
								{
									num += _unknownFields.CalculateSize();
								}
								return num;
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public void MergeFrom(FileFeed other)
							{
								if (other == null)
								{
									return;
								}
								if (other.url_ != null)
								{
									if (url_ == null)
									{
										Url = new URL();
									}
									Url.MergeFrom(other.Url);
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
									if (url_ == null)
									{
										Url = new URL();
									}
									input.ReadMessage(Url);
								}
							}
						}

						[DebuggerDisplay("{ToString(),nq}")]
						public sealed class Ticker : IMessage<Ticker>, IMessage, IEquatable<Ticker>, IDeepCloneable<Ticker>
						{
							public enum SourceTypeOneofCase
							{
								None,
								TextType,
								RssType,
								FileType
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static class Types
							{
								[DebuggerDisplay("{ToString(),nq}")]
								public sealed class TextType : IMessage<TextType>, IMessage, IEquatable<TextType>, IDeepCloneable<TextType>
								{
									private static readonly MessageParser<TextType> _parser = new MessageParser<TextType>(() => new TextType());

									private UnknownFieldSet _unknownFields;

									public const int TextFieldNumber = 1;

									private string text_ = "";

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public static MessageParser<TextType> Parser => _parser;

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public static MessageDescriptor Descriptor => Ticker.Descriptor.NestedTypes[0];

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
									public TextType()
									{
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public TextType(TextType other)
										: this()
									{
										text_ = other.text_;
										_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public TextType Clone()
									{
										return new TextType(this);
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public override bool Equals(object other)
									{
										return Equals(other as TextType);
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public bool Equals(TextType other)
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
									public void MergeFrom(TextType other)
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
								public sealed class RSSType : IMessage<RSSType>, IMessage, IEquatable<RSSType>, IDeepCloneable<RSSType>
								{
									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public static class Types
									{
										public enum ContentType
										{
											[OriginalName("CONTENT_TYPE_TITLE_ONLY")]
											TitleOnly,
											[OriginalName("CONTENT_TYPE_TITLE_AND_DESCRIPTION")]
											TitleAndDescription
										}
									}

									private static readonly MessageParser<RSSType> _parser = new MessageParser<RSSType>(() => new RSSType());

									private UnknownFieldSet _unknownFields;

									public const int UrlFieldNumber = 1;

									private URL url_;

									public const int ContentFieldNumber = 2;

									private Types.ContentType content_;

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public static MessageParser<RSSType> Parser => _parser;

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public static MessageDescriptor Descriptor => Ticker.Descriptor.NestedTypes[1];

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									MessageDescriptor IMessage.Descriptor => Descriptor;

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public URL Url
									{
										get
										{
											return url_;
										}
										set
										{
											url_ = value;
										}
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public Types.ContentType Content
									{
										get
										{
											return content_;
										}
										set
										{
											content_ = value;
										}
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public RSSType()
									{
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public RSSType(RSSType other)
										: this()
									{
										url_ = ((other.url_ != null) ? other.url_.Clone() : null);
										content_ = other.content_;
										_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public RSSType Clone()
									{
										return new RSSType(this);
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public override bool Equals(object other)
									{
										return Equals(other as RSSType);
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public bool Equals(RSSType other)
									{
										if (other == null)
										{
											return false;
										}
										if (other == this)
										{
											return true;
										}
										if (!object.Equals(Url, other.Url))
										{
											return false;
										}
										if (Content != other.Content)
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
										if (url_ != null)
										{
											num ^= Url.GetHashCode();
										}
										if (Content != 0)
										{
											num ^= Content.GetHashCode();
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
										if (url_ != null)
										{
											output.WriteRawTag(10);
											output.WriteMessage(Url);
										}
										if (Content != 0)
										{
											output.WriteRawTag(16);
											output.WriteEnum((int)Content);
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
										if (url_ != null)
										{
											num += 1 + CodedOutputStream.ComputeMessageSize(Url);
										}
										if (Content != 0)
										{
											num += 1 + CodedOutputStream.ComputeEnumSize((int)Content);
										}
										if (_unknownFields != null)
										{
											num += _unknownFields.CalculateSize();
										}
										return num;
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public void MergeFrom(RSSType other)
									{
										if (other == null)
										{
											return;
										}
										if (other.url_ != null)
										{
											if (url_ == null)
											{
												Url = new URL();
											}
											Url.MergeFrom(other.Url);
										}
										if (other.Content != 0)
										{
											Content = other.Content;
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
												if (url_ == null)
												{
													Url = new URL();
												}
												input.ReadMessage(Url);
												break;
											case 16u:
												Content = (Types.ContentType)input.ReadEnum();
												break;
											}
										}
									}
								}

								[DebuggerDisplay("{ToString(),nq}")]
								public sealed class FileType : IMessage<FileType>, IMessage, IEquatable<FileType>, IDeepCloneable<FileType>
								{
									private static readonly MessageParser<FileType> _parser = new MessageParser<FileType>(() => new FileType());

									private UnknownFieldSet _unknownFields;

									public const int UrlFieldNumber = 1;

									private URL url_;

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public static MessageParser<FileType> Parser => _parser;

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public static MessageDescriptor Descriptor => Ticker.Descriptor.NestedTypes[2];

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									MessageDescriptor IMessage.Descriptor => Descriptor;

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public URL Url
									{
										get
										{
											return url_;
										}
										set
										{
											url_ = value;
										}
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public FileType()
									{
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public FileType(FileType other)
										: this()
									{
										url_ = ((other.url_ != null) ? other.url_.Clone() : null);
										_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public FileType Clone()
									{
										return new FileType(this);
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public override bool Equals(object other)
									{
										return Equals(other as FileType);
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public bool Equals(FileType other)
									{
										if (other == null)
										{
											return false;
										}
										if (other == this)
										{
											return true;
										}
										if (!object.Equals(Url, other.Url))
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
										if (url_ != null)
										{
											num ^= Url.GetHashCode();
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
										if (url_ != null)
										{
											output.WriteRawTag(10);
											output.WriteMessage(Url);
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
										if (url_ != null)
										{
											num += 1 + CodedOutputStream.ComputeMessageSize(Url);
										}
										if (_unknownFields != null)
										{
											num += _unknownFields.CalculateSize();
										}
										return num;
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public void MergeFrom(FileType other)
									{
										if (other == null)
										{
											return;
										}
										if (other.url_ != null)
										{
											if (url_ == null)
											{
												Url = new URL();
											}
											Url.MergeFrom(other.Url);
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
											if (url_ == null)
											{
												Url = new URL();
											}
											input.ReadMessage(Url);
										}
									}
								}
							}

							private static readonly MessageParser<Ticker> _parser = new MessageParser<Ticker>(() => new Ticker());

							private UnknownFieldSet _unknownFields;

							public const int TextTypeFieldNumber = 1;

							public const int RssTypeFieldNumber = 2;

							public const int FileTypeFieldNumber = 3;

							public const int PlayRateFieldNumber = 4;

							private double playRate_;

							public const int ShouldLoopFieldNumber = 5;

							private bool shouldLoop_;

							public const int LoopDelayFieldNumber = 6;

							private double loopDelay_;

							public const int TextDelimiterFieldNumber = 7;

							private string textDelimiter_ = "";

							private object sourceType_;

							private SourceTypeOneofCase sourceTypeCase_;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageParser<Ticker> Parser => _parser;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageDescriptor Descriptor => DataLink.Descriptor.NestedTypes[2];

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							MessageDescriptor IMessage.Descriptor => Descriptor;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Types.TextType TextType
							{
								get
								{
									if (sourceTypeCase_ != SourceTypeOneofCase.TextType)
									{
										return null;
									}
									return (Types.TextType)sourceType_;
								}
								set
								{
									sourceType_ = value;
									sourceTypeCase_ = ((value != null) ? SourceTypeOneofCase.TextType : SourceTypeOneofCase.None);
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Types.RSSType RssType
							{
								get
								{
									if (sourceTypeCase_ != SourceTypeOneofCase.RssType)
									{
										return null;
									}
									return (Types.RSSType)sourceType_;
								}
								set
								{
									sourceType_ = value;
									sourceTypeCase_ = ((value != null) ? SourceTypeOneofCase.RssType : SourceTypeOneofCase.None);
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Types.FileType FileType
							{
								get
								{
									if (sourceTypeCase_ != SourceTypeOneofCase.FileType)
									{
										return null;
									}
									return (Types.FileType)sourceType_;
								}
								set
								{
									sourceType_ = value;
									sourceTypeCase_ = ((value != null) ? SourceTypeOneofCase.FileType : SourceTypeOneofCase.None);
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public double PlayRate
							{
								get
								{
									return playRate_;
								}
								set
								{
									playRate_ = value;
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool ShouldLoop
							{
								get
								{
									return shouldLoop_;
								}
								set
								{
									shouldLoop_ = value;
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public double LoopDelay
							{
								get
								{
									return loopDelay_;
								}
								set
								{
									loopDelay_ = value;
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public string TextDelimiter
							{
								get
								{
									return textDelimiter_;
								}
								set
								{
									textDelimiter_ = ProtoPreconditions.CheckNotNull(value, "value");
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public SourceTypeOneofCase SourceTypeCase => sourceTypeCase_;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Ticker()
							{
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Ticker(Ticker other)
								: this()
							{
								playRate_ = other.playRate_;
								shouldLoop_ = other.shouldLoop_;
								loopDelay_ = other.loopDelay_;
								textDelimiter_ = other.textDelimiter_;
								switch (other.SourceTypeCase)
								{
								case SourceTypeOneofCase.TextType:
									TextType = other.TextType.Clone();
									break;
								case SourceTypeOneofCase.RssType:
									RssType = other.RssType.Clone();
									break;
								case SourceTypeOneofCase.FileType:
									FileType = other.FileType.Clone();
									break;
								}
								_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Ticker Clone()
							{
								return new Ticker(this);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public void ClearSourceType()
							{
								sourceTypeCase_ = SourceTypeOneofCase.None;
								sourceType_ = null;
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public override bool Equals(object other)
							{
								return Equals(other as Ticker);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool Equals(Ticker other)
							{
								if (other == null)
								{
									return false;
								}
								if (other == this)
								{
									return true;
								}
								if (!object.Equals(TextType, other.TextType))
								{
									return false;
								}
								if (!object.Equals(RssType, other.RssType))
								{
									return false;
								}
								if (!object.Equals(FileType, other.FileType))
								{
									return false;
								}
								if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(PlayRate, other.PlayRate))
								{
									return false;
								}
								if (ShouldLoop != other.ShouldLoop)
								{
									return false;
								}
								if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(LoopDelay, other.LoopDelay))
								{
									return false;
								}
								if (TextDelimiter != other.TextDelimiter)
								{
									return false;
								}
								if (SourceTypeCase != other.SourceTypeCase)
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
								if (sourceTypeCase_ == SourceTypeOneofCase.TextType)
								{
									num ^= TextType.GetHashCode();
								}
								if (sourceTypeCase_ == SourceTypeOneofCase.RssType)
								{
									num ^= RssType.GetHashCode();
								}
								if (sourceTypeCase_ == SourceTypeOneofCase.FileType)
								{
									num ^= FileType.GetHashCode();
								}
								if (PlayRate != 0.0)
								{
									num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(PlayRate);
								}
								if (ShouldLoop)
								{
									num ^= ShouldLoop.GetHashCode();
								}
								if (LoopDelay != 0.0)
								{
									num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(LoopDelay);
								}
								if (TextDelimiter.Length != 0)
								{
									num ^= TextDelimiter.GetHashCode();
								}
								num ^= (int)sourceTypeCase_;
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
								if (sourceTypeCase_ == SourceTypeOneofCase.TextType)
								{
									output.WriteRawTag(10);
									output.WriteMessage(TextType);
								}
								if (sourceTypeCase_ == SourceTypeOneofCase.RssType)
								{
									output.WriteRawTag(18);
									output.WriteMessage(RssType);
								}
								if (sourceTypeCase_ == SourceTypeOneofCase.FileType)
								{
									output.WriteRawTag(26);
									output.WriteMessage(FileType);
								}
								if (PlayRate != 0.0)
								{
									output.WriteRawTag(33);
									output.WriteDouble(PlayRate);
								}
								if (ShouldLoop)
								{
									output.WriteRawTag(40);
									output.WriteBool(ShouldLoop);
								}
								if (LoopDelay != 0.0)
								{
									output.WriteRawTag(49);
									output.WriteDouble(LoopDelay);
								}
								if (TextDelimiter.Length != 0)
								{
									output.WriteRawTag(58);
									output.WriteString(TextDelimiter);
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
								if (sourceTypeCase_ == SourceTypeOneofCase.TextType)
								{
									num += 1 + CodedOutputStream.ComputeMessageSize(TextType);
								}
								if (sourceTypeCase_ == SourceTypeOneofCase.RssType)
								{
									num += 1 + CodedOutputStream.ComputeMessageSize(RssType);
								}
								if (sourceTypeCase_ == SourceTypeOneofCase.FileType)
								{
									num += 1 + CodedOutputStream.ComputeMessageSize(FileType);
								}
								if (PlayRate != 0.0)
								{
									num += 9;
								}
								if (ShouldLoop)
								{
									num += 2;
								}
								if (LoopDelay != 0.0)
								{
									num += 9;
								}
								if (TextDelimiter.Length != 0)
								{
									num += 1 + CodedOutputStream.ComputeStringSize(TextDelimiter);
								}
								if (_unknownFields != null)
								{
									num += _unknownFields.CalculateSize();
								}
								return num;
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public void MergeFrom(Ticker other)
							{
								if (other == null)
								{
									return;
								}
								if (other.PlayRate != 0.0)
								{
									PlayRate = other.PlayRate;
								}
								if (other.ShouldLoop)
								{
									ShouldLoop = other.ShouldLoop;
								}
								if (other.LoopDelay != 0.0)
								{
									LoopDelay = other.LoopDelay;
								}
								if (other.TextDelimiter.Length != 0)
								{
									TextDelimiter = other.TextDelimiter;
								}
								switch (other.SourceTypeCase)
								{
								case SourceTypeOneofCase.TextType:
									if (TextType == null)
									{
										TextType = new Types.TextType();
									}
									TextType.MergeFrom(other.TextType);
									break;
								case SourceTypeOneofCase.RssType:
									if (RssType == null)
									{
										RssType = new Types.RSSType();
									}
									RssType.MergeFrom(other.RssType);
									break;
								case SourceTypeOneofCase.FileType:
									if (FileType == null)
									{
										FileType = new Types.FileType();
									}
									FileType.MergeFrom(other.FileType);
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
										Types.TextType textType = new Types.TextType();
										if (sourceTypeCase_ == SourceTypeOneofCase.TextType)
										{
											textType.MergeFrom(TextType);
										}
										input.ReadMessage(textType);
										TextType = textType;
										break;
									}
									case 18u:
									{
										Types.RSSType rSSType = new Types.RSSType();
										if (sourceTypeCase_ == SourceTypeOneofCase.RssType)
										{
											rSSType.MergeFrom(RssType);
										}
										input.ReadMessage(rSSType);
										RssType = rSSType;
										break;
									}
									case 26u:
									{
										Types.FileType fileType = new Types.FileType();
										if (sourceTypeCase_ == SourceTypeOneofCase.FileType)
										{
											fileType.MergeFrom(FileType);
										}
										input.ReadMessage(fileType);
										FileType = fileType;
										break;
									}
									case 33u:
										PlayRate = input.ReadDouble();
										break;
									case 40u:
										ShouldLoop = input.ReadBool();
										break;
									case 49u:
										LoopDelay = input.ReadDouble();
										break;
									case 58u:
										TextDelimiter = input.ReadString();
										break;
									}
								}
							}
						}

						[DebuggerDisplay("{ToString(),nq}")]
						public sealed class AlternateElementText : IMessage<AlternateElementText>, IMessage, IEquatable<AlternateElementText>, IDeepCloneable<AlternateElementText>
						{
							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static class Types
							{
								public enum TextTransformOption
								{
									[OriginalName("TEXT_TRANSFORM_OPTION_NONE")]
									None,
									[OriginalName("TEXT_TRANSFORM_OPTION_REMOVE_LINE_RETURNS")]
									RemoveLineReturns,
									[OriginalName("TEXT_TRANSFORM_OPTION_ONE_WORD_PER_LINE")]
									OneWordPerLine,
									[OriginalName("TEXT_TRANSFORM_OPTION_ONE_CHARACTER_PER_LINE")]
									OneCharacterPerLine
								}
							}

							private static readonly MessageParser<AlternateElementText> _parser = new MessageParser<AlternateElementText>(() => new AlternateElementText());

							private UnknownFieldSet _unknownFields;

							public const int OtherElementUuidFieldNumber = 1;

							private UUID otherElementUuid_;

							public const int OtherElementNameFieldNumber = 2;

							private string otherElementName_ = "";

							public const int TextTransformOptionsFieldNumber = 3;

							private uint textTransformOptions_;

							public const int TextTransformFieldNumber = 4;

							private Types.TextTransformOption textTransform_;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageParser<AlternateElementText> Parser => _parser;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageDescriptor Descriptor => DataLink.Descriptor.NestedTypes[3];

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							MessageDescriptor IMessage.Descriptor => Descriptor;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public UUID OtherElementUuid
							{
								get
								{
									return otherElementUuid_;
								}
								set
								{
									otherElementUuid_ = value;
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public string OtherElementName
							{
								get
								{
									return otherElementName_;
								}
								set
								{
									otherElementName_ = ProtoPreconditions.CheckNotNull(value, "value");
								}
							}

							[Obsolete]
							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public uint TextTransformOptions
							{
								get
								{
									return textTransformOptions_;
								}
								set
								{
									textTransformOptions_ = value;
								}
							}

							[Obsolete]
							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Types.TextTransformOption TextTransform
							{
								get
								{
									return textTransform_;
								}
								set
								{
									textTransform_ = value;
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public AlternateElementText()
							{
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public AlternateElementText(AlternateElementText other)
								: this()
							{
								otherElementUuid_ = ((other.otherElementUuid_ != null) ? other.otherElementUuid_.Clone() : null);
								otherElementName_ = other.otherElementName_;
								textTransformOptions_ = other.textTransformOptions_;
								textTransform_ = other.textTransform_;
								_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public AlternateElementText Clone()
							{
								return new AlternateElementText(this);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public override bool Equals(object other)
							{
								return Equals(other as AlternateElementText);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool Equals(AlternateElementText other)
							{
								if (other == null)
								{
									return false;
								}
								if (other == this)
								{
									return true;
								}
								if (!object.Equals(OtherElementUuid, other.OtherElementUuid))
								{
									return false;
								}
								if (OtherElementName != other.OtherElementName)
								{
									return false;
								}
								if (TextTransformOptions != other.TextTransformOptions)
								{
									return false;
								}
								if (TextTransform != other.TextTransform)
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
								if (otherElementUuid_ != null)
								{
									num ^= OtherElementUuid.GetHashCode();
								}
								if (OtherElementName.Length != 0)
								{
									num ^= OtherElementName.GetHashCode();
								}
								if (TextTransformOptions != 0)
								{
									num ^= TextTransformOptions.GetHashCode();
								}
								if (TextTransform != 0)
								{
									num ^= TextTransform.GetHashCode();
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
								if (otherElementUuid_ != null)
								{
									output.WriteRawTag(10);
									output.WriteMessage(OtherElementUuid);
								}
								if (OtherElementName.Length != 0)
								{
									output.WriteRawTag(18);
									output.WriteString(OtherElementName);
								}
								if (TextTransformOptions != 0)
								{
									output.WriteRawTag(24);
									output.WriteUInt32(TextTransformOptions);
								}
								if (TextTransform != 0)
								{
									output.WriteRawTag(32);
									output.WriteEnum((int)TextTransform);
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
								if (otherElementUuid_ != null)
								{
									num += 1 + CodedOutputStream.ComputeMessageSize(OtherElementUuid);
								}
								if (OtherElementName.Length != 0)
								{
									num += 1 + CodedOutputStream.ComputeStringSize(OtherElementName);
								}
								if (TextTransformOptions != 0)
								{
									num += 1 + CodedOutputStream.ComputeUInt32Size(TextTransformOptions);
								}
								if (TextTransform != 0)
								{
									num += 1 + CodedOutputStream.ComputeEnumSize((int)TextTransform);
								}
								if (_unknownFields != null)
								{
									num += _unknownFields.CalculateSize();
								}
								return num;
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public void MergeFrom(AlternateElementText other)
							{
								if (other == null)
								{
									return;
								}
								if (other.otherElementUuid_ != null)
								{
									if (otherElementUuid_ == null)
									{
										OtherElementUuid = new UUID();
									}
									OtherElementUuid.MergeFrom(other.OtherElementUuid);
								}
								if (other.OtherElementName.Length != 0)
								{
									OtherElementName = other.OtherElementName;
								}
								if (other.TextTransformOptions != 0)
								{
									TextTransformOptions = other.TextTransformOptions;
								}
								if (other.TextTransform != 0)
								{
									TextTransform = other.TextTransform;
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
										if (otherElementUuid_ == null)
										{
											OtherElementUuid = new UUID();
										}
										input.ReadMessage(OtherElementUuid);
										break;
									case 18u:
										OtherElementName = input.ReadString();
										break;
									case 24u:
										TextTransformOptions = input.ReadUInt32();
										break;
									case 32u:
										TextTransform = (Types.TextTransformOption)input.ReadEnum();
										break;
									}
								}
							}
						}

						[DebuggerDisplay("{ToString(),nq}")]
						public sealed class CCLIText : IMessage<CCLIText>, IMessage, IEquatable<CCLIText>, IDeepCloneable<CCLIText>
						{
							private static readonly MessageParser<CCLIText> _parser = new MessageParser<CCLIText>(() => new CCLIText());

							private UnknownFieldSet _unknownFields;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageParser<CCLIText> Parser => _parser;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageDescriptor Descriptor => DataLink.Descriptor.NestedTypes[4];

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							MessageDescriptor IMessage.Descriptor => Descriptor;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public CCLIText()
							{
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public CCLIText(CCLIText other)
								: this()
							{
								_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public CCLIText Clone()
							{
								return new CCLIText(this);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public override bool Equals(object other)
							{
								return Equals(other as CCLIText);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool Equals(CCLIText other)
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
							public void MergeFrom(CCLIText other)
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

						[DebuggerDisplay("{ToString(),nq}")]
						public sealed class ColorTrigger : IMessage<ColorTrigger>, IMessage, IEquatable<ColorTrigger>, IDeepCloneable<ColorTrigger>
						{
							private static readonly MessageParser<ColorTrigger> _parser = new MessageParser<ColorTrigger>(() => new ColorTrigger());

							private UnknownFieldSet _unknownFields;

							public const int TimeFieldNumber = 1;

							private double time_;

							public const int ColorFieldNumber = 2;

							private Color color_;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageParser<ColorTrigger> Parser => _parser;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageDescriptor Descriptor => DataLink.Descriptor.NestedTypes[5];

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							MessageDescriptor IMessage.Descriptor => Descriptor;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public double Time
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
							public Color Color
							{
								get
								{
									return color_;
								}
								set
								{
									color_ = value;
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public ColorTrigger()
							{
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public ColorTrigger(ColorTrigger other)
								: this()
							{
								time_ = other.time_;
								color_ = ((other.color_ != null) ? other.color_.Clone() : null);
								_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public ColorTrigger Clone()
							{
								return new ColorTrigger(this);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public override bool Equals(object other)
							{
								return Equals(other as ColorTrigger);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool Equals(ColorTrigger other)
							{
								if (other == null)
								{
									return false;
								}
								if (other == this)
								{
									return true;
								}
								if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Time, other.Time))
								{
									return false;
								}
								if (!object.Equals(Color, other.Color))
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
								if (Time != 0.0)
								{
									num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Time);
								}
								if (color_ != null)
								{
									num ^= Color.GetHashCode();
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
								if (Time != 0.0)
								{
									output.WriteRawTag(9);
									output.WriteDouble(Time);
								}
								if (color_ != null)
								{
									output.WriteRawTag(18);
									output.WriteMessage(Color);
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
								if (Time != 0.0)
								{
									num += 9;
								}
								if (color_ != null)
								{
									num += 1 + CodedOutputStream.ComputeMessageSize(Color);
								}
								if (_unknownFields != null)
								{
									num += _unknownFields.CalculateSize();
								}
								return num;
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public void MergeFrom(ColorTrigger other)
							{
								if (other == null)
								{
									return;
								}
								if (other.Time != 0.0)
								{
									Time = other.Time;
								}
								if (other.color_ != null)
								{
									if (color_ == null)
									{
										Color = new Color();
									}
									Color.MergeFrom(other.Color);
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
									case 9u:
										Time = input.ReadDouble();
										break;
									case 18u:
										if (color_ == null)
										{
											Color = new Color();
										}
										input.ReadMessage(Color);
										break;
									}
								}
							}
						}

						[DebuggerDisplay("{ToString(),nq}")]
						public sealed class TimerText : IMessage<TimerText>, IMessage, IEquatable<TimerText>, IDeepCloneable<TimerText>
						{
							private static readonly MessageParser<TimerText> _parser = new MessageParser<TimerText>(() => new TimerText());

							private UnknownFieldSet _unknownFields;

							public const int TimerUuidFieldNumber = 1;

							private UUID timerUuid_;

							public const int TimerNameFieldNumber = 2;

							private string timerName_ = "";

							public const int TimerFormatFieldNumber = 3;

							private Timer.Types.Format timerFormat_;

							public const int TimerFormatStringFieldNumber = 4;

							private string timerFormatString_ = "";

							public const int ColorTriggersFieldNumber = 5;

							private static readonly FieldCodec<ColorTrigger> _repeated_colorTriggers_codec = FieldCodec.ForMessage(42u, ColorTrigger.Parser);

							private readonly RepeatedField<ColorTrigger> colorTriggers_ = new RepeatedField<ColorTrigger>();

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageParser<TimerText> Parser => _parser;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageDescriptor Descriptor => DataLink.Descriptor.NestedTypes[6];

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							MessageDescriptor IMessage.Descriptor => Descriptor;

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
							public string TimerName
							{
								get
								{
									return timerName_;
								}
								set
								{
									timerName_ = ProtoPreconditions.CheckNotNull(value, "value");
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Timer.Types.Format TimerFormat
							{
								get
								{
									return timerFormat_;
								}
								set
								{
									timerFormat_ = value;
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public string TimerFormatString
							{
								get
								{
									return timerFormatString_;
								}
								set
								{
									timerFormatString_ = ProtoPreconditions.CheckNotNull(value, "value");
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public RepeatedField<ColorTrigger> ColorTriggers => colorTriggers_;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public TimerText()
							{
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public TimerText(TimerText other)
								: this()
							{
								timerUuid_ = ((other.timerUuid_ != null) ? other.timerUuid_.Clone() : null);
								timerName_ = other.timerName_;
								timerFormat_ = ((other.timerFormat_ != null) ? other.timerFormat_.Clone() : null);
								timerFormatString_ = other.timerFormatString_;
								colorTriggers_ = other.colorTriggers_.Clone();
								_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public TimerText Clone()
							{
								return new TimerText(this);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public override bool Equals(object other)
							{
								return Equals(other as TimerText);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool Equals(TimerText other)
							{
								if (other == null)
								{
									return false;
								}
								if (other == this)
								{
									return true;
								}
								if (!object.Equals(TimerUuid, other.TimerUuid))
								{
									return false;
								}
								if (TimerName != other.TimerName)
								{
									return false;
								}
								if (!object.Equals(TimerFormat, other.TimerFormat))
								{
									return false;
								}
								if (TimerFormatString != other.TimerFormatString)
								{
									return false;
								}
								if (!colorTriggers_.Equals(other.colorTriggers_))
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
								if (timerUuid_ != null)
								{
									num ^= TimerUuid.GetHashCode();
								}
								if (TimerName.Length != 0)
								{
									num ^= TimerName.GetHashCode();
								}
								if (timerFormat_ != null)
								{
									num ^= TimerFormat.GetHashCode();
								}
								if (TimerFormatString.Length != 0)
								{
									num ^= TimerFormatString.GetHashCode();
								}
								num ^= colorTriggers_.GetHashCode();
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
								if (timerUuid_ != null)
								{
									output.WriteRawTag(10);
									output.WriteMessage(TimerUuid);
								}
								if (TimerName.Length != 0)
								{
									output.WriteRawTag(18);
									output.WriteString(TimerName);
								}
								if (timerFormat_ != null)
								{
									output.WriteRawTag(26);
									output.WriteMessage(TimerFormat);
								}
								if (TimerFormatString.Length != 0)
								{
									output.WriteRawTag(34);
									output.WriteString(TimerFormatString);
								}
								colorTriggers_.WriteTo(output, _repeated_colorTriggers_codec);
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
								if (timerUuid_ != null)
								{
									num += 1 + CodedOutputStream.ComputeMessageSize(TimerUuid);
								}
								if (TimerName.Length != 0)
								{
									num += 1 + CodedOutputStream.ComputeStringSize(TimerName);
								}
								if (timerFormat_ != null)
								{
									num += 1 + CodedOutputStream.ComputeMessageSize(TimerFormat);
								}
								if (TimerFormatString.Length != 0)
								{
									num += 1 + CodedOutputStream.ComputeStringSize(TimerFormatString);
								}
								num += colorTriggers_.CalculateSize(_repeated_colorTriggers_codec);
								if (_unknownFields != null)
								{
									num += _unknownFields.CalculateSize();
								}
								return num;
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public void MergeFrom(TimerText other)
							{
								if (other == null)
								{
									return;
								}
								if (other.timerUuid_ != null)
								{
									if (timerUuid_ == null)
									{
										TimerUuid = new UUID();
									}
									TimerUuid.MergeFrom(other.TimerUuid);
								}
								if (other.TimerName.Length != 0)
								{
									TimerName = other.TimerName;
								}
								if (other.timerFormat_ != null)
								{
									if (timerFormat_ == null)
									{
										TimerFormat = new Timer.Types.Format();
									}
									TimerFormat.MergeFrom(other.TimerFormat);
								}
								if (other.TimerFormatString.Length != 0)
								{
									TimerFormatString = other.TimerFormatString;
								}
								colorTriggers_.Add(other.colorTriggers_);
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
										if (timerUuid_ == null)
										{
											TimerUuid = new UUID();
										}
										input.ReadMessage(TimerUuid);
										break;
									case 18u:
										TimerName = input.ReadString();
										break;
									case 26u:
										if (timerFormat_ == null)
										{
											TimerFormat = new Timer.Types.Format();
										}
										input.ReadMessage(TimerFormat);
										break;
									case 34u:
										TimerFormatString = input.ReadString();
										break;
									case 42u:
										colorTriggers_.AddEntriesFrom(input, _repeated_colorTriggers_codec);
										break;
									}
								}
							}
						}

						[DebuggerDisplay("{ToString(),nq}")]
						public sealed class ClockText : IMessage<ClockText>, IMessage, IEquatable<ClockText>, IDeepCloneable<ClockText>
						{
							private static readonly MessageParser<ClockText> _parser = new MessageParser<ClockText>(() => new ClockText());

							private UnknownFieldSet _unknownFields;

							public const int ClockFormatStringFieldNumber = 1;

							private string clockFormatString_ = "";

							public const int FormatFieldNumber = 5;

							private Clock.Types.Format format_;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageParser<ClockText> Parser => _parser;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageDescriptor Descriptor => DataLink.Descriptor.NestedTypes[7];

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							MessageDescriptor IMessage.Descriptor => Descriptor;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public string ClockFormatString
							{
								get
								{
									return clockFormatString_;
								}
								set
								{
									clockFormatString_ = ProtoPreconditions.CheckNotNull(value, "value");
								}
							}

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
							public ClockText()
							{
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public ClockText(ClockText other)
								: this()
							{
								clockFormatString_ = other.clockFormatString_;
								format_ = ((other.format_ != null) ? other.format_.Clone() : null);
								_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public ClockText Clone()
							{
								return new ClockText(this);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public override bool Equals(object other)
							{
								return Equals(other as ClockText);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool Equals(ClockText other)
							{
								if (other == null)
								{
									return false;
								}
								if (other == this)
								{
									return true;
								}
								if (ClockFormatString != other.ClockFormatString)
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
								if (ClockFormatString.Length != 0)
								{
									num ^= ClockFormatString.GetHashCode();
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
								if (ClockFormatString.Length != 0)
								{
									output.WriteRawTag(10);
									output.WriteString(ClockFormatString);
								}
								if (format_ != null)
								{
									output.WriteRawTag(42);
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
								if (ClockFormatString.Length != 0)
								{
									num += 1 + CodedOutputStream.ComputeStringSize(ClockFormatString);
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
							public void MergeFrom(ClockText other)
							{
								if (other == null)
								{
									return;
								}
								if (other.ClockFormatString.Length != 0)
								{
									ClockFormatString = other.ClockFormatString;
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
									switch (num)
									{
									default:
										_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
										break;
									case 10u:
										ClockFormatString = input.ReadString();
										break;
									case 42u:
										if (format_ == null)
										{
											Format = new Clock.Types.Format();
										}
										input.ReadMessage(Format);
										break;
									}
								}
							}
						}

						[DebuggerDisplay("{ToString(),nq}")]
						public sealed class ChordChart : IMessage<ChordChart>, IMessage, IEquatable<ChordChart>, IDeepCloneable<ChordChart>
						{
							private static readonly MessageParser<ChordChart> _parser = new MessageParser<ChordChart>(() => new ChordChart());

							private UnknownFieldSet _unknownFields;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageParser<ChordChart> Parser => _parser;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageDescriptor Descriptor => DataLink.Descriptor.NestedTypes[8];

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							MessageDescriptor IMessage.Descriptor => Descriptor;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public ChordChart()
							{
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public ChordChart(ChordChart other)
								: this()
							{
								_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public ChordChart Clone()
							{
								return new ChordChart(this);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public override bool Equals(object other)
							{
								return Equals(other as ChordChart);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool Equals(ChordChart other)
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
							public void MergeFrom(ChordChart other)
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

						[DebuggerDisplay("{ToString(),nq}")]
						public sealed class OutputScreen : IMessage<OutputScreen>, IMessage, IEquatable<OutputScreen>, IDeepCloneable<OutputScreen>
						{
							private static readonly MessageParser<OutputScreen> _parser = new MessageParser<OutputScreen>(() => new OutputScreen());

							private UnknownFieldSet _unknownFields;

							public const int ScreenIdFieldNumber = 1;

							private UUID screenId_;

							public const int ScreenNameFieldNumber = 2;

							private string screenName_ = "";

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageParser<OutputScreen> Parser => _parser;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageDescriptor Descriptor => DataLink.Descriptor.NestedTypes[9];

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							MessageDescriptor IMessage.Descriptor => Descriptor;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public UUID ScreenId
							{
								get
								{
									return screenId_;
								}
								set
								{
									screenId_ = value;
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public string ScreenName
							{
								get
								{
									return screenName_;
								}
								set
								{
									screenName_ = ProtoPreconditions.CheckNotNull(value, "value");
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public OutputScreen()
							{
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public OutputScreen(OutputScreen other)
								: this()
							{
								screenId_ = ((other.screenId_ != null) ? other.screenId_.Clone() : null);
								screenName_ = other.screenName_;
								_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public OutputScreen Clone()
							{
								return new OutputScreen(this);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public override bool Equals(object other)
							{
								return Equals(other as OutputScreen);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool Equals(OutputScreen other)
							{
								if (other == null)
								{
									return false;
								}
								if (other == this)
								{
									return true;
								}
								if (!object.Equals(ScreenId, other.ScreenId))
								{
									return false;
								}
								if (ScreenName != other.ScreenName)
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
								if (screenId_ != null)
								{
									num ^= ScreenId.GetHashCode();
								}
								if (ScreenName.Length != 0)
								{
									num ^= ScreenName.GetHashCode();
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
								if (screenId_ != null)
								{
									output.WriteRawTag(10);
									output.WriteMessage(ScreenId);
								}
								if (ScreenName.Length != 0)
								{
									output.WriteRawTag(18);
									output.WriteString(ScreenName);
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
								if (screenId_ != null)
								{
									num += 1 + CodedOutputStream.ComputeMessageSize(ScreenId);
								}
								if (ScreenName.Length != 0)
								{
									num += 1 + CodedOutputStream.ComputeStringSize(ScreenName);
								}
								if (_unknownFields != null)
								{
									num += _unknownFields.CalculateSize();
								}
								return num;
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public void MergeFrom(OutputScreen other)
							{
								if (other == null)
								{
									return;
								}
								if (other.screenId_ != null)
								{
									if (screenId_ == null)
									{
										ScreenId = new UUID();
									}
									ScreenId.MergeFrom(other.ScreenId);
								}
								if (other.ScreenName.Length != 0)
								{
									ScreenName = other.ScreenName;
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
										if (screenId_ == null)
										{
											ScreenId = new UUID();
										}
										input.ReadMessage(ScreenId);
										break;
									case 18u:
										ScreenName = input.ReadString();
										break;
									}
								}
							}
						}

						[DebuggerDisplay("{ToString(),nq}")]
						public sealed class PCOLive : IMessage<PCOLive>, IMessage, IEquatable<PCOLive>, IDeepCloneable<PCOLive>
						{
							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static class Types
							{
								public enum Theme
								{
									[OriginalName("PCOLIVE_THEME_LIGHT")]
									PcoliveThemeLight,
									[OriginalName("PCOLIVE_THEME_DARK")]
									PcoliveThemeDark
								}

								public enum CountdownType
								{
									[OriginalName("COUNTDOWN_TYPE_FULL_ITEM_LENGTH")]
									FullItemLength,
									[OriginalName("COUNTDOWN_TYPE_END_ITEM_ON_TIME")]
									EndItemOnTime,
									[OriginalName("COUNTDOWN_TYPE_END_SERVICE_ON_TIME")]
									EndServiceOnTime
								}
							}

							private static readonly MessageParser<PCOLive> _parser = new MessageParser<PCOLive>(() => new PCOLive());

							private UnknownFieldSet _unknownFields;

							public const int ThemeFieldNumber = 2;

							private Types.Theme theme_;

							public const int CountdownTypeFieldNumber = 3;

							private Types.CountdownType countdownType_;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageParser<PCOLive> Parser => _parser;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageDescriptor Descriptor => DataLink.Descriptor.NestedTypes[10];

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							MessageDescriptor IMessage.Descriptor => Descriptor;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Types.Theme Theme
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
							public Types.CountdownType CountdownType
							{
								get
								{
									return countdownType_;
								}
								set
								{
									countdownType_ = value;
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public PCOLive()
							{
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public PCOLive(PCOLive other)
								: this()
							{
								theme_ = other.theme_;
								countdownType_ = other.countdownType_;
								_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public PCOLive Clone()
							{
								return new PCOLive(this);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public override bool Equals(object other)
							{
								return Equals(other as PCOLive);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool Equals(PCOLive other)
							{
								if (other == null)
								{
									return false;
								}
								if (other == this)
								{
									return true;
								}
								if (Theme != other.Theme)
								{
									return false;
								}
								if (CountdownType != other.CountdownType)
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
								if (Theme != 0)
								{
									num ^= Theme.GetHashCode();
								}
								if (CountdownType != 0)
								{
									num ^= CountdownType.GetHashCode();
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
								if (Theme != 0)
								{
									output.WriteRawTag(16);
									output.WriteEnum((int)Theme);
								}
								if (CountdownType != 0)
								{
									output.WriteRawTag(24);
									output.WriteEnum((int)CountdownType);
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
								if (Theme != 0)
								{
									num += 1 + CodedOutputStream.ComputeEnumSize((int)Theme);
								}
								if (CountdownType != 0)
								{
									num += 1 + CodedOutputStream.ComputeEnumSize((int)CountdownType);
								}
								if (_unknownFields != null)
								{
									num += _unknownFields.CalculateSize();
								}
								return num;
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public void MergeFrom(PCOLive other)
							{
								if (other != null)
								{
									if (other.Theme != 0)
									{
										Theme = other.Theme;
									}
									if (other.CountdownType != 0)
									{
										CountdownType = other.CountdownType;
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
										Theme = (Types.Theme)input.ReadEnum();
										break;
									case 24u:
										CountdownType = (Types.CountdownType)input.ReadEnum();
										break;
									}
								}
							}
						}

						[DebuggerDisplay("{ToString(),nq}")]
						public sealed class AlternateElementFill : IMessage<AlternateElementFill>, IMessage, IEquatable<AlternateElementFill>, IDeepCloneable<AlternateElementFill>
						{
							private static readonly MessageParser<AlternateElementFill> _parser = new MessageParser<AlternateElementFill>(() => new AlternateElementFill());

							private UnknownFieldSet _unknownFields;

							public const int OtherElementUuidFieldNumber = 1;

							private UUID otherElementUuid_;

							public const int OtherElementNameFieldNumber = 2;

							private string otherElementName_ = "";

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageParser<AlternateElementFill> Parser => _parser;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageDescriptor Descriptor => DataLink.Descriptor.NestedTypes[11];

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							MessageDescriptor IMessage.Descriptor => Descriptor;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public UUID OtherElementUuid
							{
								get
								{
									return otherElementUuid_;
								}
								set
								{
									otherElementUuid_ = value;
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public string OtherElementName
							{
								get
								{
									return otherElementName_;
								}
								set
								{
									otherElementName_ = ProtoPreconditions.CheckNotNull(value, "value");
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public AlternateElementFill()
							{
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public AlternateElementFill(AlternateElementFill other)
								: this()
							{
								otherElementUuid_ = ((other.otherElementUuid_ != null) ? other.otherElementUuid_.Clone() : null);
								otherElementName_ = other.otherElementName_;
								_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public AlternateElementFill Clone()
							{
								return new AlternateElementFill(this);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public override bool Equals(object other)
							{
								return Equals(other as AlternateElementFill);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool Equals(AlternateElementFill other)
							{
								if (other == null)
								{
									return false;
								}
								if (other == this)
								{
									return true;
								}
								if (!object.Equals(OtherElementUuid, other.OtherElementUuid))
								{
									return false;
								}
								if (OtherElementName != other.OtherElementName)
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
								if (otherElementUuid_ != null)
								{
									num ^= OtherElementUuid.GetHashCode();
								}
								if (OtherElementName.Length != 0)
								{
									num ^= OtherElementName.GetHashCode();
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
								if (otherElementUuid_ != null)
								{
									output.WriteRawTag(10);
									output.WriteMessage(OtherElementUuid);
								}
								if (OtherElementName.Length != 0)
								{
									output.WriteRawTag(18);
									output.WriteString(OtherElementName);
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
								if (otherElementUuid_ != null)
								{
									num += 1 + CodedOutputStream.ComputeMessageSize(OtherElementUuid);
								}
								if (OtherElementName.Length != 0)
								{
									num += 1 + CodedOutputStream.ComputeStringSize(OtherElementName);
								}
								if (_unknownFields != null)
								{
									num += _unknownFields.CalculateSize();
								}
								return num;
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public void MergeFrom(AlternateElementFill other)
							{
								if (other == null)
								{
									return;
								}
								if (other.otherElementUuid_ != null)
								{
									if (otherElementUuid_ == null)
									{
										OtherElementUuid = new UUID();
									}
									OtherElementUuid.MergeFrom(other.OtherElementUuid);
								}
								if (other.OtherElementName.Length != 0)
								{
									OtherElementName = other.OtherElementName;
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
										if (otherElementUuid_ == null)
										{
											OtherElementUuid = new UUID();
										}
										input.ReadMessage(OtherElementUuid);
										break;
									case 18u:
										OtherElementName = input.ReadString();
										break;
									}
								}
							}
						}

						[DebuggerDisplay("{ToString(),nq}")]
						public sealed class VisibilityLink : IMessage<VisibilityLink>, IMessage, IEquatable<VisibilityLink>, IDeepCloneable<VisibilityLink>
						{
							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static class Types
							{
								public enum VisibilityCriterion
								{
									[OriginalName("VISIBILITY_CRITERION_ALL")]
									All,
									[OriginalName("VISIBILITY_CRITERION_ANY")]
									Any,
									[OriginalName("VISIBILITY_CRITERION_NONE")]
									None
								}

								[DebuggerDisplay("{ToString(),nq}")]
								public sealed class Condition : IMessage<Condition>, IMessage, IEquatable<Condition>, IDeepCloneable<Condition>
								{
									public enum ConditionTypeOneofCase
									{
										None,
										ElementVisibility,
										TimerVisibility,
										VideoCountdownVisibility,
										CaptureSessionVisibility,
										VideoInputVisibility,
										AudioCountdownVisibility
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public static class Types
									{
										[DebuggerDisplay("{ToString(),nq}")]
										public sealed class ElementVisibility : IMessage<ElementVisibility>, IMessage, IEquatable<ElementVisibility>, IDeepCloneable<ElementVisibility>
										{
											[DebuggerNonUserCode]
											[GeneratedCode("protoc", null)]
											public static class Types
											{
												public enum ElementVisibilityCriterion
												{
													[OriginalName("ELEMENT_VISIBILITY_CRITERION_HAS_TEXT")]
													HasText,
													[OriginalName("ELEMENT_VISIBILITY_CRITERION_HAS_NO_TEXT")]
													HasNoText
												}
											}

											private static readonly MessageParser<ElementVisibility> _parser = new MessageParser<ElementVisibility>(() => new ElementVisibility());

											private UnknownFieldSet _unknownFields;

											public const int OtherElementUuidFieldNumber = 1;

											private UUID otherElementUuid_;

											public const int OtherElementNameFieldNumber = 2;

											private string otherElementName_ = "";

											public const int VisibilityCriterionFieldNumber = 3;

											private Types.ElementVisibilityCriterion visibilityCriterion_;

											[DebuggerNonUserCode]
											[GeneratedCode("protoc", null)]
											public static MessageParser<ElementVisibility> Parser => _parser;

											[DebuggerNonUserCode]
											[GeneratedCode("protoc", null)]
											public static MessageDescriptor Descriptor => Condition.Descriptor.NestedTypes[0];

											[DebuggerNonUserCode]
											[GeneratedCode("protoc", null)]
											MessageDescriptor IMessage.Descriptor => Descriptor;

											[DebuggerNonUserCode]
											[GeneratedCode("protoc", null)]
											public UUID OtherElementUuid
											{
												get
												{
													return otherElementUuid_;
												}
												set
												{
													otherElementUuid_ = value;
												}
											}

											[DebuggerNonUserCode]
											[GeneratedCode("protoc", null)]
											public string OtherElementName
											{
												get
												{
													return otherElementName_;
												}
												set
												{
													otherElementName_ = ProtoPreconditions.CheckNotNull(value, "value");
												}
											}

											[DebuggerNonUserCode]
											[GeneratedCode("protoc", null)]
											public Types.ElementVisibilityCriterion VisibilityCriterion
											{
												get
												{
													return visibilityCriterion_;
												}
												set
												{
													visibilityCriterion_ = value;
												}
											}

											[DebuggerNonUserCode]
											[GeneratedCode("protoc", null)]
											public ElementVisibility()
											{
											}

											[DebuggerNonUserCode]
											[GeneratedCode("protoc", null)]
											public ElementVisibility(ElementVisibility other)
												: this()
											{
												otherElementUuid_ = ((other.otherElementUuid_ != null) ? other.otherElementUuid_.Clone() : null);
												otherElementName_ = other.otherElementName_;
												visibilityCriterion_ = other.visibilityCriterion_;
												_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
											}

											[DebuggerNonUserCode]
											[GeneratedCode("protoc", null)]
											public ElementVisibility Clone()
											{
												return new ElementVisibility(this);
											}

											[DebuggerNonUserCode]
											[GeneratedCode("protoc", null)]
											public override bool Equals(object other)
											{
												return Equals(other as ElementVisibility);
											}

											[DebuggerNonUserCode]
											[GeneratedCode("protoc", null)]
											public bool Equals(ElementVisibility other)
											{
												if (other == null)
												{
													return false;
												}
												if (other == this)
												{
													return true;
												}
												if (!object.Equals(OtherElementUuid, other.OtherElementUuid))
												{
													return false;
												}
												if (OtherElementName != other.OtherElementName)
												{
													return false;
												}
												if (VisibilityCriterion != other.VisibilityCriterion)
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
												if (otherElementUuid_ != null)
												{
													num ^= OtherElementUuid.GetHashCode();
												}
												if (OtherElementName.Length != 0)
												{
													num ^= OtherElementName.GetHashCode();
												}
												if (VisibilityCriterion != 0)
												{
													num ^= VisibilityCriterion.GetHashCode();
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
												if (otherElementUuid_ != null)
												{
													output.WriteRawTag(10);
													output.WriteMessage(OtherElementUuid);
												}
												if (OtherElementName.Length != 0)
												{
													output.WriteRawTag(18);
													output.WriteString(OtherElementName);
												}
												if (VisibilityCriterion != 0)
												{
													output.WriteRawTag(24);
													output.WriteEnum((int)VisibilityCriterion);
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
												if (otherElementUuid_ != null)
												{
													num += 1 + CodedOutputStream.ComputeMessageSize(OtherElementUuid);
												}
												if (OtherElementName.Length != 0)
												{
													num += 1 + CodedOutputStream.ComputeStringSize(OtherElementName);
												}
												if (VisibilityCriterion != 0)
												{
													num += 1 + CodedOutputStream.ComputeEnumSize((int)VisibilityCriterion);
												}
												if (_unknownFields != null)
												{
													num += _unknownFields.CalculateSize();
												}
												return num;
											}

											[DebuggerNonUserCode]
											[GeneratedCode("protoc", null)]
											public void MergeFrom(ElementVisibility other)
											{
												if (other == null)
												{
													return;
												}
												if (other.otherElementUuid_ != null)
												{
													if (otherElementUuid_ == null)
													{
														OtherElementUuid = new UUID();
													}
													OtherElementUuid.MergeFrom(other.OtherElementUuid);
												}
												if (other.OtherElementName.Length != 0)
												{
													OtherElementName = other.OtherElementName;
												}
												if (other.VisibilityCriterion != 0)
												{
													VisibilityCriterion = other.VisibilityCriterion;
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
														if (otherElementUuid_ == null)
														{
															OtherElementUuid = new UUID();
														}
														input.ReadMessage(OtherElementUuid);
														break;
													case 18u:
														OtherElementName = input.ReadString();
														break;
													case 24u:
														VisibilityCriterion = (Types.ElementVisibilityCriterion)input.ReadEnum();
														break;
													}
												}
											}
										}

										[DebuggerDisplay("{ToString(),nq}")]
										public sealed class TimerVisibility : IMessage<TimerVisibility>, IMessage, IEquatable<TimerVisibility>, IDeepCloneable<TimerVisibility>
										{
											[DebuggerNonUserCode]
											[GeneratedCode("protoc", null)]
											public static class Types
											{
												public enum TimerVisibilityCriterion
												{
													[OriginalName("TIMER_VISIBILITY_CRITERION_HAS_TIME_REMAINING")]
													HasTimeRemaining,
													[OriginalName("TIMER_VISIBILITY_CRITERION_HAS_EXPIRED")]
													HasExpired,
													[OriginalName("TIMER_VISIBILITY_CRITERION_IS_RUNNING")]
													IsRunning,
													[OriginalName("TIMER_VISIBILITY_CRITERION_NOT_RUNNING")]
													NotRunning
												}
											}

											private static readonly MessageParser<TimerVisibility> _parser = new MessageParser<TimerVisibility>(() => new TimerVisibility());

											private UnknownFieldSet _unknownFields;

											public const int TimerUuidFieldNumber = 1;

											private UUID timerUuid_;

											public const int TimerNameFieldNumber = 2;

											private string timerName_ = "";

											public const int VisibilityCriterionFieldNumber = 3;

											private Types.TimerVisibilityCriterion visibilityCriterion_;

											[DebuggerNonUserCode]
											[GeneratedCode("protoc", null)]
											public static MessageParser<TimerVisibility> Parser => _parser;

											[DebuggerNonUserCode]
											[GeneratedCode("protoc", null)]
											public static MessageDescriptor Descriptor => Condition.Descriptor.NestedTypes[1];

											[DebuggerNonUserCode]
											[GeneratedCode("protoc", null)]
											MessageDescriptor IMessage.Descriptor => Descriptor;

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
											public string TimerName
											{
												get
												{
													return timerName_;
												}
												set
												{
													timerName_ = ProtoPreconditions.CheckNotNull(value, "value");
												}
											}

											[DebuggerNonUserCode]
											[GeneratedCode("protoc", null)]
											public Types.TimerVisibilityCriterion VisibilityCriterion
											{
												get
												{
													return visibilityCriterion_;
												}
												set
												{
													visibilityCriterion_ = value;
												}
											}

											[DebuggerNonUserCode]
											[GeneratedCode("protoc", null)]
											public TimerVisibility()
											{
											}

											[DebuggerNonUserCode]
											[GeneratedCode("protoc", null)]
											public TimerVisibility(TimerVisibility other)
												: this()
											{
												timerUuid_ = ((other.timerUuid_ != null) ? other.timerUuid_.Clone() : null);
												timerName_ = other.timerName_;
												visibilityCriterion_ = other.visibilityCriterion_;
												_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
											}

											[DebuggerNonUserCode]
											[GeneratedCode("protoc", null)]
											public TimerVisibility Clone()
											{
												return new TimerVisibility(this);
											}

											[DebuggerNonUserCode]
											[GeneratedCode("protoc", null)]
											public override bool Equals(object other)
											{
												return Equals(other as TimerVisibility);
											}

											[DebuggerNonUserCode]
											[GeneratedCode("protoc", null)]
											public bool Equals(TimerVisibility other)
											{
												if (other == null)
												{
													return false;
												}
												if (other == this)
												{
													return true;
												}
												if (!object.Equals(TimerUuid, other.TimerUuid))
												{
													return false;
												}
												if (TimerName != other.TimerName)
												{
													return false;
												}
												if (VisibilityCriterion != other.VisibilityCriterion)
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
												if (timerUuid_ != null)
												{
													num ^= TimerUuid.GetHashCode();
												}
												if (TimerName.Length != 0)
												{
													num ^= TimerName.GetHashCode();
												}
												if (VisibilityCriterion != 0)
												{
													num ^= VisibilityCriterion.GetHashCode();
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
												if (timerUuid_ != null)
												{
													output.WriteRawTag(10);
													output.WriteMessage(TimerUuid);
												}
												if (TimerName.Length != 0)
												{
													output.WriteRawTag(18);
													output.WriteString(TimerName);
												}
												if (VisibilityCriterion != 0)
												{
													output.WriteRawTag(24);
													output.WriteEnum((int)VisibilityCriterion);
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
												if (timerUuid_ != null)
												{
													num += 1 + CodedOutputStream.ComputeMessageSize(TimerUuid);
												}
												if (TimerName.Length != 0)
												{
													num += 1 + CodedOutputStream.ComputeStringSize(TimerName);
												}
												if (VisibilityCriterion != 0)
												{
													num += 1 + CodedOutputStream.ComputeEnumSize((int)VisibilityCriterion);
												}
												if (_unknownFields != null)
												{
													num += _unknownFields.CalculateSize();
												}
												return num;
											}

											[DebuggerNonUserCode]
											[GeneratedCode("protoc", null)]
											public void MergeFrom(TimerVisibility other)
											{
												if (other == null)
												{
													return;
												}
												if (other.timerUuid_ != null)
												{
													if (timerUuid_ == null)
													{
														TimerUuid = new UUID();
													}
													TimerUuid.MergeFrom(other.TimerUuid);
												}
												if (other.TimerName.Length != 0)
												{
													TimerName = other.TimerName;
												}
												if (other.VisibilityCriterion != 0)
												{
													VisibilityCriterion = other.VisibilityCriterion;
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
														if (timerUuid_ == null)
														{
															TimerUuid = new UUID();
														}
														input.ReadMessage(TimerUuid);
														break;
													case 18u:
														TimerName = input.ReadString();
														break;
													case 24u:
														VisibilityCriterion = (Types.TimerVisibilityCriterion)input.ReadEnum();
														break;
													}
												}
											}
										}

										[DebuggerDisplay("{ToString(),nq}")]
										public sealed class VideoCountdownVisibility : IMessage<VideoCountdownVisibility>, IMessage, IEquatable<VideoCountdownVisibility>, IDeepCloneable<VideoCountdownVisibility>
										{
											[DebuggerNonUserCode]
											[GeneratedCode("protoc", null)]
											public static class Types
											{
												public enum VideoCountdownVisibilityCriterion
												{
													[OriginalName("VIDEO_COUNTDOWN_VISIBILITY_CRITERION_HAS_TIME_REMAINING")]
													HasTimeRemaining,
													[OriginalName("VIDEO_COUNTDOWN_VISIBILITY_CRITERION_HAS_EXPIRED")]
													HasExpired,
													[OriginalName("VIDEO_COUNTDOWN_VISIBILITY_CRITERION_IS_RUNNING")]
													IsRunning,
													[OriginalName("VIDEO_COUNTDOWN_VISIBILITY_CRITERION_NOT_RUNNING")]
													NotRunning,
													[OriginalName("VIDEO_COUNTDOWN_VISIBILITY_CRITERION_LOOPING")]
													Looping,
													[OriginalName("VIDEO_COUNTDOWN_VISIBILITY_CRITERION_NOT_LOOPING")]
													NotLooping
												}
											}

											private static readonly MessageParser<VideoCountdownVisibility> _parser = new MessageParser<VideoCountdownVisibility>(() => new VideoCountdownVisibility());

											private UnknownFieldSet _unknownFields;

											public const int VisibilityCriterionFieldNumber = 1;

											private Types.VideoCountdownVisibilityCriterion visibilityCriterion_;

											[DebuggerNonUserCode]
											[GeneratedCode("protoc", null)]
											public static MessageParser<VideoCountdownVisibility> Parser => _parser;

											[DebuggerNonUserCode]
											[GeneratedCode("protoc", null)]
											public static MessageDescriptor Descriptor => Condition.Descriptor.NestedTypes[2];

											[DebuggerNonUserCode]
											[GeneratedCode("protoc", null)]
											MessageDescriptor IMessage.Descriptor => Descriptor;

											[DebuggerNonUserCode]
											[GeneratedCode("protoc", null)]
											public Types.VideoCountdownVisibilityCriterion VisibilityCriterion
											{
												get
												{
													return visibilityCriterion_;
												}
												set
												{
													visibilityCriterion_ = value;
												}
											}

											[DebuggerNonUserCode]
											[GeneratedCode("protoc", null)]
											public VideoCountdownVisibility()
											{
											}

											[DebuggerNonUserCode]
											[GeneratedCode("protoc", null)]
											public VideoCountdownVisibility(VideoCountdownVisibility other)
												: this()
											{
												visibilityCriterion_ = other.visibilityCriterion_;
												_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
											}

											[DebuggerNonUserCode]
											[GeneratedCode("protoc", null)]
											public VideoCountdownVisibility Clone()
											{
												return new VideoCountdownVisibility(this);
											}

											[DebuggerNonUserCode]
											[GeneratedCode("protoc", null)]
											public override bool Equals(object other)
											{
												return Equals(other as VideoCountdownVisibility);
											}

											[DebuggerNonUserCode]
											[GeneratedCode("protoc", null)]
											public bool Equals(VideoCountdownVisibility other)
											{
												if (other == null)
												{
													return false;
												}
												if (other == this)
												{
													return true;
												}
												if (VisibilityCriterion != other.VisibilityCriterion)
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
												if (VisibilityCriterion != 0)
												{
													num ^= VisibilityCriterion.GetHashCode();
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
												if (VisibilityCriterion != 0)
												{
													output.WriteRawTag(8);
													output.WriteEnum((int)VisibilityCriterion);
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
												if (VisibilityCriterion != 0)
												{
													num += 1 + CodedOutputStream.ComputeEnumSize((int)VisibilityCriterion);
												}
												if (_unknownFields != null)
												{
													num += _unknownFields.CalculateSize();
												}
												return num;
											}

											[DebuggerNonUserCode]
											[GeneratedCode("protoc", null)]
											public void MergeFrom(VideoCountdownVisibility other)
											{
												if (other != null)
												{
													if (other.VisibilityCriterion != 0)
													{
														VisibilityCriterion = other.VisibilityCriterion;
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
														VisibilityCriterion = (Types.VideoCountdownVisibilityCriterion)input.ReadEnum();
													}
												}
											}
										}

										[DebuggerDisplay("{ToString(),nq}")]
										public sealed class AudioCountdownVisibility : IMessage<AudioCountdownVisibility>, IMessage, IEquatable<AudioCountdownVisibility>, IDeepCloneable<AudioCountdownVisibility>
										{
											[DebuggerNonUserCode]
											[GeneratedCode("protoc", null)]
											public static class Types
											{
												public enum AudioCountdownVisibilityCriterion
												{
													[OriginalName("AUDIO_COUNTDOWN_VISIBILITY_CRITERION_HAS_TIME_REMAINING")]
													HasTimeRemaining,
													[OriginalName("AUDIO_COUNTDOWN_VISIBILITY_CRITERION_HAS_EXPIRED")]
													HasExpired,
													[OriginalName("AUDIO_COUNTDOWN_VISIBILITY_CRITERION_IS_RUNNING")]
													IsRunning,
													[OriginalName("AUDIO_COUNTDOWN_VISIBILITY_CRITERION_NOT_RUNNING")]
													NotRunning,
													[OriginalName("AUDIO_COUNTDOWN_VISIBILITY_CRITERION_LOOPING")]
													Looping,
													[OriginalName("AUDIO_COUNTDOWN_VISIBILITY_CRITERION_NOT_LOOPING")]
													NotLooping
												}
											}

											private static readonly MessageParser<AudioCountdownVisibility> _parser = new MessageParser<AudioCountdownVisibility>(() => new AudioCountdownVisibility());

											private UnknownFieldSet _unknownFields;

											public const int VisibilityCriterionFieldNumber = 1;

											private Types.AudioCountdownVisibilityCriterion visibilityCriterion_;

											[DebuggerNonUserCode]
											[GeneratedCode("protoc", null)]
											public static MessageParser<AudioCountdownVisibility> Parser => _parser;

											[DebuggerNonUserCode]
											[GeneratedCode("protoc", null)]
											public static MessageDescriptor Descriptor => Condition.Descriptor.NestedTypes[3];

											[DebuggerNonUserCode]
											[GeneratedCode("protoc", null)]
											MessageDescriptor IMessage.Descriptor => Descriptor;

											[DebuggerNonUserCode]
											[GeneratedCode("protoc", null)]
											public Types.AudioCountdownVisibilityCriterion VisibilityCriterion
											{
												get
												{
													return visibilityCriterion_;
												}
												set
												{
													visibilityCriterion_ = value;
												}
											}

											[DebuggerNonUserCode]
											[GeneratedCode("protoc", null)]
											public AudioCountdownVisibility()
											{
											}

											[DebuggerNonUserCode]
											[GeneratedCode("protoc", null)]
											public AudioCountdownVisibility(AudioCountdownVisibility other)
												: this()
											{
												visibilityCriterion_ = other.visibilityCriterion_;
												_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
											}

											[DebuggerNonUserCode]
											[GeneratedCode("protoc", null)]
											public AudioCountdownVisibility Clone()
											{
												return new AudioCountdownVisibility(this);
											}

											[DebuggerNonUserCode]
											[GeneratedCode("protoc", null)]
											public override bool Equals(object other)
											{
												return Equals(other as AudioCountdownVisibility);
											}

											[DebuggerNonUserCode]
											[GeneratedCode("protoc", null)]
											public bool Equals(AudioCountdownVisibility other)
											{
												if (other == null)
												{
													return false;
												}
												if (other == this)
												{
													return true;
												}
												if (VisibilityCriterion != other.VisibilityCriterion)
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
												if (VisibilityCriterion != 0)
												{
													num ^= VisibilityCriterion.GetHashCode();
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
												if (VisibilityCriterion != 0)
												{
													output.WriteRawTag(8);
													output.WriteEnum((int)VisibilityCriterion);
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
												if (VisibilityCriterion != 0)
												{
													num += 1 + CodedOutputStream.ComputeEnumSize((int)VisibilityCriterion);
												}
												if (_unknownFields != null)
												{
													num += _unknownFields.CalculateSize();
												}
												return num;
											}

											[DebuggerNonUserCode]
											[GeneratedCode("protoc", null)]
											public void MergeFrom(AudioCountdownVisibility other)
											{
												if (other != null)
												{
													if (other.VisibilityCriterion != 0)
													{
														VisibilityCriterion = other.VisibilityCriterion;
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
														VisibilityCriterion = (Types.AudioCountdownVisibilityCriterion)input.ReadEnum();
													}
												}
											}
										}

										[DebuggerDisplay("{ToString(),nq}")]
										public sealed class CaptureSessionVisibility : IMessage<CaptureSessionVisibility>, IMessage, IEquatable<CaptureSessionVisibility>, IDeepCloneable<CaptureSessionVisibility>
										{
											[DebuggerNonUserCode]
											[GeneratedCode("protoc", null)]
											public static class Types
											{
												public enum CaptureSessionVisibilityCriterion
												{
													[OriginalName("CAPTURE_SESSION_VISIBILITY_CRITERION_ACTIVE")]
													Active,
													[OriginalName("CAPTURE_SESSION_VISIBILITY_CRITERION_INACTIVE")]
													Inactive
												}
											}

											private static readonly MessageParser<CaptureSessionVisibility> _parser = new MessageParser<CaptureSessionVisibility>(() => new CaptureSessionVisibility());

											private UnknownFieldSet _unknownFields;

											public const int VisibilityCriterionFieldNumber = 1;

											private Types.CaptureSessionVisibilityCriterion visibilityCriterion_;

											[DebuggerNonUserCode]
											[GeneratedCode("protoc", null)]
											public static MessageParser<CaptureSessionVisibility> Parser => _parser;

											[DebuggerNonUserCode]
											[GeneratedCode("protoc", null)]
											public static MessageDescriptor Descriptor => Condition.Descriptor.NestedTypes[4];

											[DebuggerNonUserCode]
											[GeneratedCode("protoc", null)]
											MessageDescriptor IMessage.Descriptor => Descriptor;

											[DebuggerNonUserCode]
											[GeneratedCode("protoc", null)]
											public Types.CaptureSessionVisibilityCriterion VisibilityCriterion
											{
												get
												{
													return visibilityCriterion_;
												}
												set
												{
													visibilityCriterion_ = value;
												}
											}

											[DebuggerNonUserCode]
											[GeneratedCode("protoc", null)]
											public CaptureSessionVisibility()
											{
											}

											[DebuggerNonUserCode]
											[GeneratedCode("protoc", null)]
											public CaptureSessionVisibility(CaptureSessionVisibility other)
												: this()
											{
												visibilityCriterion_ = other.visibilityCriterion_;
												_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
											}

											[DebuggerNonUserCode]
											[GeneratedCode("protoc", null)]
											public CaptureSessionVisibility Clone()
											{
												return new CaptureSessionVisibility(this);
											}

											[DebuggerNonUserCode]
											[GeneratedCode("protoc", null)]
											public override bool Equals(object other)
											{
												return Equals(other as CaptureSessionVisibility);
											}

											[DebuggerNonUserCode]
											[GeneratedCode("protoc", null)]
											public bool Equals(CaptureSessionVisibility other)
											{
												if (other == null)
												{
													return false;
												}
												if (other == this)
												{
													return true;
												}
												if (VisibilityCriterion != other.VisibilityCriterion)
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
												if (VisibilityCriterion != 0)
												{
													num ^= VisibilityCriterion.GetHashCode();
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
												if (VisibilityCriterion != 0)
												{
													output.WriteRawTag(8);
													output.WriteEnum((int)VisibilityCriterion);
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
												if (VisibilityCriterion != 0)
												{
													num += 1 + CodedOutputStream.ComputeEnumSize((int)VisibilityCriterion);
												}
												if (_unknownFields != null)
												{
													num += _unknownFields.CalculateSize();
												}
												return num;
											}

											[DebuggerNonUserCode]
											[GeneratedCode("protoc", null)]
											public void MergeFrom(CaptureSessionVisibility other)
											{
												if (other != null)
												{
													if (other.VisibilityCriterion != 0)
													{
														VisibilityCriterion = other.VisibilityCriterion;
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
														VisibilityCriterion = (Types.CaptureSessionVisibilityCriterion)input.ReadEnum();
													}
												}
											}
										}

										[DebuggerDisplay("{ToString(),nq}")]
										public sealed class VideoInputVisibility : IMessage<VideoInputVisibility>, IMessage, IEquatable<VideoInputVisibility>, IDeepCloneable<VideoInputVisibility>
										{
											[DebuggerNonUserCode]
											[GeneratedCode("protoc", null)]
											public static class Types
											{
												public enum VideoInputVisibilityCriterion
												{
													[OriginalName("VIDEO_INPUT_VISIBILITY_CRITERION_ACTIVE")]
													Active,
													[OriginalName("VIDEO_INPUT_VISIBILITY_CRITERION_INACTIVE")]
													Inactive
												}
											}

											private static readonly MessageParser<VideoInputVisibility> _parser = new MessageParser<VideoInputVisibility>(() => new VideoInputVisibility());

											private UnknownFieldSet _unknownFields;

											public const int VideoInputIndexFieldNumber = 1;

											private int videoInputIndex_;

											public const int VisibilityCriterionFieldNumber = 2;

											private Types.VideoInputVisibilityCriterion visibilityCriterion_;

											[DebuggerNonUserCode]
											[GeneratedCode("protoc", null)]
											public static MessageParser<VideoInputVisibility> Parser => _parser;

											[DebuggerNonUserCode]
											[GeneratedCode("protoc", null)]
											public static MessageDescriptor Descriptor => Condition.Descriptor.NestedTypes[5];

											[DebuggerNonUserCode]
											[GeneratedCode("protoc", null)]
											MessageDescriptor IMessage.Descriptor => Descriptor;

											[DebuggerNonUserCode]
											[GeneratedCode("protoc", null)]
											public int VideoInputIndex
											{
												get
												{
													return videoInputIndex_;
												}
												set
												{
													videoInputIndex_ = value;
												}
											}

											[DebuggerNonUserCode]
											[GeneratedCode("protoc", null)]
											public Types.VideoInputVisibilityCriterion VisibilityCriterion
											{
												get
												{
													return visibilityCriterion_;
												}
												set
												{
													visibilityCriterion_ = value;
												}
											}

											[DebuggerNonUserCode]
											[GeneratedCode("protoc", null)]
											public VideoInputVisibility()
											{
											}

											[DebuggerNonUserCode]
											[GeneratedCode("protoc", null)]
											public VideoInputVisibility(VideoInputVisibility other)
												: this()
											{
												videoInputIndex_ = other.videoInputIndex_;
												visibilityCriterion_ = other.visibilityCriterion_;
												_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
											}

											[DebuggerNonUserCode]
											[GeneratedCode("protoc", null)]
											public VideoInputVisibility Clone()
											{
												return new VideoInputVisibility(this);
											}

											[DebuggerNonUserCode]
											[GeneratedCode("protoc", null)]
											public override bool Equals(object other)
											{
												return Equals(other as VideoInputVisibility);
											}

											[DebuggerNonUserCode]
											[GeneratedCode("protoc", null)]
											public bool Equals(VideoInputVisibility other)
											{
												if (other == null)
												{
													return false;
												}
												if (other == this)
												{
													return true;
												}
												if (VideoInputIndex != other.VideoInputIndex)
												{
													return false;
												}
												if (VisibilityCriterion != other.VisibilityCriterion)
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
												if (VideoInputIndex != 0)
												{
													num ^= VideoInputIndex.GetHashCode();
												}
												if (VisibilityCriterion != 0)
												{
													num ^= VisibilityCriterion.GetHashCode();
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
												if (VideoInputIndex != 0)
												{
													output.WriteRawTag(8);
													output.WriteInt32(VideoInputIndex);
												}
												if (VisibilityCriterion != 0)
												{
													output.WriteRawTag(16);
													output.WriteEnum((int)VisibilityCriterion);
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
												if (VideoInputIndex != 0)
												{
													num += 1 + CodedOutputStream.ComputeInt32Size(VideoInputIndex);
												}
												if (VisibilityCriterion != 0)
												{
													num += 1 + CodedOutputStream.ComputeEnumSize((int)VisibilityCriterion);
												}
												if (_unknownFields != null)
												{
													num += _unknownFields.CalculateSize();
												}
												return num;
											}

											[DebuggerNonUserCode]
											[GeneratedCode("protoc", null)]
											public void MergeFrom(VideoInputVisibility other)
											{
												if (other != null)
												{
													if (other.VideoInputIndex != 0)
													{
														VideoInputIndex = other.VideoInputIndex;
													}
													if (other.VisibilityCriterion != 0)
													{
														VisibilityCriterion = other.VisibilityCriterion;
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
														VideoInputIndex = input.ReadInt32();
														break;
													case 16u:
														VisibilityCriterion = (Types.VideoInputVisibilityCriterion)input.ReadEnum();
														break;
													}
												}
											}
										}
									}

									private static readonly MessageParser<Condition> _parser = new MessageParser<Condition>(() => new Condition());

									private UnknownFieldSet _unknownFields;

									public const int ElementVisibilityFieldNumber = 1;

									public const int TimerVisibilityFieldNumber = 2;

									public const int VideoCountdownVisibilityFieldNumber = 3;

									public const int CaptureSessionVisibilityFieldNumber = 4;

									public const int VideoInputVisibilityFieldNumber = 5;

									public const int AudioCountdownVisibilityFieldNumber = 6;

									private object conditionType_;

									private ConditionTypeOneofCase conditionTypeCase_;

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public static MessageParser<Condition> Parser => _parser;

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public static MessageDescriptor Descriptor => VisibilityLink.Descriptor.NestedTypes[0];

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									MessageDescriptor IMessage.Descriptor => Descriptor;

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public Types.ElementVisibility ElementVisibility
									{
										get
										{
											if (conditionTypeCase_ != ConditionTypeOneofCase.ElementVisibility)
											{
												return null;
											}
											return (Types.ElementVisibility)conditionType_;
										}
										set
										{
											conditionType_ = value;
											conditionTypeCase_ = ((value != null) ? ConditionTypeOneofCase.ElementVisibility : ConditionTypeOneofCase.None);
										}
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public Types.TimerVisibility TimerVisibility
									{
										get
										{
											if (conditionTypeCase_ != ConditionTypeOneofCase.TimerVisibility)
											{
												return null;
											}
											return (Types.TimerVisibility)conditionType_;
										}
										set
										{
											conditionType_ = value;
											conditionTypeCase_ = ((value != null) ? ConditionTypeOneofCase.TimerVisibility : ConditionTypeOneofCase.None);
										}
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public Types.VideoCountdownVisibility VideoCountdownVisibility
									{
										get
										{
											if (conditionTypeCase_ != ConditionTypeOneofCase.VideoCountdownVisibility)
											{
												return null;
											}
											return (Types.VideoCountdownVisibility)conditionType_;
										}
										set
										{
											conditionType_ = value;
											conditionTypeCase_ = ((value != null) ? ConditionTypeOneofCase.VideoCountdownVisibility : ConditionTypeOneofCase.None);
										}
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public Types.CaptureSessionVisibility CaptureSessionVisibility
									{
										get
										{
											if (conditionTypeCase_ != ConditionTypeOneofCase.CaptureSessionVisibility)
											{
												return null;
											}
											return (Types.CaptureSessionVisibility)conditionType_;
										}
										set
										{
											conditionType_ = value;
											conditionTypeCase_ = ((value != null) ? ConditionTypeOneofCase.CaptureSessionVisibility : ConditionTypeOneofCase.None);
										}
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public Types.VideoInputVisibility VideoInputVisibility
									{
										get
										{
											if (conditionTypeCase_ != ConditionTypeOneofCase.VideoInputVisibility)
											{
												return null;
											}
											return (Types.VideoInputVisibility)conditionType_;
										}
										set
										{
											conditionType_ = value;
											conditionTypeCase_ = ((value != null) ? ConditionTypeOneofCase.VideoInputVisibility : ConditionTypeOneofCase.None);
										}
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public Types.AudioCountdownVisibility AudioCountdownVisibility
									{
										get
										{
											if (conditionTypeCase_ != ConditionTypeOneofCase.AudioCountdownVisibility)
											{
												return null;
											}
											return (Types.AudioCountdownVisibility)conditionType_;
										}
										set
										{
											conditionType_ = value;
											conditionTypeCase_ = ((value != null) ? ConditionTypeOneofCase.AudioCountdownVisibility : ConditionTypeOneofCase.None);
										}
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public ConditionTypeOneofCase ConditionTypeCase => conditionTypeCase_;

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public Condition()
									{
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public Condition(Condition other)
										: this()
									{
										switch (other.ConditionTypeCase)
										{
										case ConditionTypeOneofCase.ElementVisibility:
											ElementVisibility = other.ElementVisibility.Clone();
											break;
										case ConditionTypeOneofCase.TimerVisibility:
											TimerVisibility = other.TimerVisibility.Clone();
											break;
										case ConditionTypeOneofCase.VideoCountdownVisibility:
											VideoCountdownVisibility = other.VideoCountdownVisibility.Clone();
											break;
										case ConditionTypeOneofCase.CaptureSessionVisibility:
											CaptureSessionVisibility = other.CaptureSessionVisibility.Clone();
											break;
										case ConditionTypeOneofCase.VideoInputVisibility:
											VideoInputVisibility = other.VideoInputVisibility.Clone();
											break;
										case ConditionTypeOneofCase.AudioCountdownVisibility:
											AudioCountdownVisibility = other.AudioCountdownVisibility.Clone();
											break;
										}
										_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public Condition Clone()
									{
										return new Condition(this);
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public void ClearConditionType()
									{
										conditionTypeCase_ = ConditionTypeOneofCase.None;
										conditionType_ = null;
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public override bool Equals(object other)
									{
										return Equals(other as Condition);
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public bool Equals(Condition other)
									{
										if (other == null)
										{
											return false;
										}
										if (other == this)
										{
											return true;
										}
										if (!object.Equals(ElementVisibility, other.ElementVisibility))
										{
											return false;
										}
										if (!object.Equals(TimerVisibility, other.TimerVisibility))
										{
											return false;
										}
										if (!object.Equals(VideoCountdownVisibility, other.VideoCountdownVisibility))
										{
											return false;
										}
										if (!object.Equals(CaptureSessionVisibility, other.CaptureSessionVisibility))
										{
											return false;
										}
										if (!object.Equals(VideoInputVisibility, other.VideoInputVisibility))
										{
											return false;
										}
										if (!object.Equals(AudioCountdownVisibility, other.AudioCountdownVisibility))
										{
											return false;
										}
										if (ConditionTypeCase != other.ConditionTypeCase)
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
										if (conditionTypeCase_ == ConditionTypeOneofCase.ElementVisibility)
										{
											num ^= ElementVisibility.GetHashCode();
										}
										if (conditionTypeCase_ == ConditionTypeOneofCase.TimerVisibility)
										{
											num ^= TimerVisibility.GetHashCode();
										}
										if (conditionTypeCase_ == ConditionTypeOneofCase.VideoCountdownVisibility)
										{
											num ^= VideoCountdownVisibility.GetHashCode();
										}
										if (conditionTypeCase_ == ConditionTypeOneofCase.CaptureSessionVisibility)
										{
											num ^= CaptureSessionVisibility.GetHashCode();
										}
										if (conditionTypeCase_ == ConditionTypeOneofCase.VideoInputVisibility)
										{
											num ^= VideoInputVisibility.GetHashCode();
										}
										if (conditionTypeCase_ == ConditionTypeOneofCase.AudioCountdownVisibility)
										{
											num ^= AudioCountdownVisibility.GetHashCode();
										}
										num ^= (int)conditionTypeCase_;
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
										if (conditionTypeCase_ == ConditionTypeOneofCase.ElementVisibility)
										{
											output.WriteRawTag(10);
											output.WriteMessage(ElementVisibility);
										}
										if (conditionTypeCase_ == ConditionTypeOneofCase.TimerVisibility)
										{
											output.WriteRawTag(18);
											output.WriteMessage(TimerVisibility);
										}
										if (conditionTypeCase_ == ConditionTypeOneofCase.VideoCountdownVisibility)
										{
											output.WriteRawTag(26);
											output.WriteMessage(VideoCountdownVisibility);
										}
										if (conditionTypeCase_ == ConditionTypeOneofCase.CaptureSessionVisibility)
										{
											output.WriteRawTag(34);
											output.WriteMessage(CaptureSessionVisibility);
										}
										if (conditionTypeCase_ == ConditionTypeOneofCase.VideoInputVisibility)
										{
											output.WriteRawTag(42);
											output.WriteMessage(VideoInputVisibility);
										}
										if (conditionTypeCase_ == ConditionTypeOneofCase.AudioCountdownVisibility)
										{
											output.WriteRawTag(50);
											output.WriteMessage(AudioCountdownVisibility);
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
										if (conditionTypeCase_ == ConditionTypeOneofCase.ElementVisibility)
										{
											num += 1 + CodedOutputStream.ComputeMessageSize(ElementVisibility);
										}
										if (conditionTypeCase_ == ConditionTypeOneofCase.TimerVisibility)
										{
											num += 1 + CodedOutputStream.ComputeMessageSize(TimerVisibility);
										}
										if (conditionTypeCase_ == ConditionTypeOneofCase.VideoCountdownVisibility)
										{
											num += 1 + CodedOutputStream.ComputeMessageSize(VideoCountdownVisibility);
										}
										if (conditionTypeCase_ == ConditionTypeOneofCase.CaptureSessionVisibility)
										{
											num += 1 + CodedOutputStream.ComputeMessageSize(CaptureSessionVisibility);
										}
										if (conditionTypeCase_ == ConditionTypeOneofCase.VideoInputVisibility)
										{
											num += 1 + CodedOutputStream.ComputeMessageSize(VideoInputVisibility);
										}
										if (conditionTypeCase_ == ConditionTypeOneofCase.AudioCountdownVisibility)
										{
											num += 1 + CodedOutputStream.ComputeMessageSize(AudioCountdownVisibility);
										}
										if (_unknownFields != null)
										{
											num += _unknownFields.CalculateSize();
										}
										return num;
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public void MergeFrom(Condition other)
									{
										if (other == null)
										{
											return;
										}
										switch (other.ConditionTypeCase)
										{
										case ConditionTypeOneofCase.ElementVisibility:
											if (ElementVisibility == null)
											{
												ElementVisibility = new Types.ElementVisibility();
											}
											ElementVisibility.MergeFrom(other.ElementVisibility);
											break;
										case ConditionTypeOneofCase.TimerVisibility:
											if (TimerVisibility == null)
											{
												TimerVisibility = new Types.TimerVisibility();
											}
											TimerVisibility.MergeFrom(other.TimerVisibility);
											break;
										case ConditionTypeOneofCase.VideoCountdownVisibility:
											if (VideoCountdownVisibility == null)
											{
												VideoCountdownVisibility = new Types.VideoCountdownVisibility();
											}
											VideoCountdownVisibility.MergeFrom(other.VideoCountdownVisibility);
											break;
										case ConditionTypeOneofCase.CaptureSessionVisibility:
											if (CaptureSessionVisibility == null)
											{
												CaptureSessionVisibility = new Types.CaptureSessionVisibility();
											}
											CaptureSessionVisibility.MergeFrom(other.CaptureSessionVisibility);
											break;
										case ConditionTypeOneofCase.VideoInputVisibility:
											if (VideoInputVisibility == null)
											{
												VideoInputVisibility = new Types.VideoInputVisibility();
											}
											VideoInputVisibility.MergeFrom(other.VideoInputVisibility);
											break;
										case ConditionTypeOneofCase.AudioCountdownVisibility:
											if (AudioCountdownVisibility == null)
											{
												AudioCountdownVisibility = new Types.AudioCountdownVisibility();
											}
											AudioCountdownVisibility.MergeFrom(other.AudioCountdownVisibility);
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
												Types.ElementVisibility elementVisibility = new Types.ElementVisibility();
												if (conditionTypeCase_ == ConditionTypeOneofCase.ElementVisibility)
												{
													elementVisibility.MergeFrom(ElementVisibility);
												}
												input.ReadMessage(elementVisibility);
												ElementVisibility = elementVisibility;
												break;
											}
											case 18u:
											{
												Types.TimerVisibility timerVisibility = new Types.TimerVisibility();
												if (conditionTypeCase_ == ConditionTypeOneofCase.TimerVisibility)
												{
													timerVisibility.MergeFrom(TimerVisibility);
												}
												input.ReadMessage(timerVisibility);
												TimerVisibility = timerVisibility;
												break;
											}
											case 26u:
											{
												Types.VideoCountdownVisibility videoCountdownVisibility = new Types.VideoCountdownVisibility();
												if (conditionTypeCase_ == ConditionTypeOneofCase.VideoCountdownVisibility)
												{
													videoCountdownVisibility.MergeFrom(VideoCountdownVisibility);
												}
												input.ReadMessage(videoCountdownVisibility);
												VideoCountdownVisibility = videoCountdownVisibility;
												break;
											}
											case 34u:
											{
												Types.CaptureSessionVisibility captureSessionVisibility = new Types.CaptureSessionVisibility();
												if (conditionTypeCase_ == ConditionTypeOneofCase.CaptureSessionVisibility)
												{
													captureSessionVisibility.MergeFrom(CaptureSessionVisibility);
												}
												input.ReadMessage(captureSessionVisibility);
												CaptureSessionVisibility = captureSessionVisibility;
												break;
											}
											case 42u:
											{
												Types.VideoInputVisibility videoInputVisibility = new Types.VideoInputVisibility();
												if (conditionTypeCase_ == ConditionTypeOneofCase.VideoInputVisibility)
												{
													videoInputVisibility.MergeFrom(VideoInputVisibility);
												}
												input.ReadMessage(videoInputVisibility);
												VideoInputVisibility = videoInputVisibility;
												break;
											}
											case 50u:
											{
												Types.AudioCountdownVisibility audioCountdownVisibility = new Types.AudioCountdownVisibility();
												if (conditionTypeCase_ == ConditionTypeOneofCase.AudioCountdownVisibility)
												{
													audioCountdownVisibility.MergeFrom(AudioCountdownVisibility);
												}
												input.ReadMessage(audioCountdownVisibility);
												AudioCountdownVisibility = audioCountdownVisibility;
												break;
											}
											}
										}
									}
								}
							}

							private static readonly MessageParser<VisibilityLink> _parser = new MessageParser<VisibilityLink>(() => new VisibilityLink());

							private UnknownFieldSet _unknownFields;

							public const int VisibilityCriterionFieldNumber = 1;

							private Types.VisibilityCriterion visibilityCriterion_;

							public const int ConditionsFieldNumber = 2;

							private static readonly FieldCodec<Types.Condition> _repeated_conditions_codec = FieldCodec.ForMessage(18u, Types.Condition.Parser);

							private readonly RepeatedField<Types.Condition> conditions_ = new RepeatedField<Types.Condition>();

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageParser<VisibilityLink> Parser => _parser;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageDescriptor Descriptor => DataLink.Descriptor.NestedTypes[12];

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							MessageDescriptor IMessage.Descriptor => Descriptor;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Types.VisibilityCriterion VisibilityCriterion
							{
								get
								{
									return visibilityCriterion_;
								}
								set
								{
									visibilityCriterion_ = value;
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public RepeatedField<Types.Condition> Conditions => conditions_;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public VisibilityLink()
							{
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public VisibilityLink(VisibilityLink other)
								: this()
							{
								visibilityCriterion_ = other.visibilityCriterion_;
								conditions_ = other.conditions_.Clone();
								_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public VisibilityLink Clone()
							{
								return new VisibilityLink(this);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public override bool Equals(object other)
							{
								return Equals(other as VisibilityLink);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool Equals(VisibilityLink other)
							{
								if (other == null)
								{
									return false;
								}
								if (other == this)
								{
									return true;
								}
								if (VisibilityCriterion != other.VisibilityCriterion)
								{
									return false;
								}
								if (!conditions_.Equals(other.conditions_))
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
								if (VisibilityCriterion != 0)
								{
									num ^= VisibilityCriterion.GetHashCode();
								}
								num ^= conditions_.GetHashCode();
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
								if (VisibilityCriterion != 0)
								{
									output.WriteRawTag(8);
									output.WriteEnum((int)VisibilityCriterion);
								}
								conditions_.WriteTo(output, _repeated_conditions_codec);
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
								if (VisibilityCriterion != 0)
								{
									num += 1 + CodedOutputStream.ComputeEnumSize((int)VisibilityCriterion);
								}
								num += conditions_.CalculateSize(_repeated_conditions_codec);
								if (_unknownFields != null)
								{
									num += _unknownFields.CalculateSize();
								}
								return num;
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public void MergeFrom(VisibilityLink other)
							{
								if (other != null)
								{
									if (other.VisibilityCriterion != 0)
									{
										VisibilityCriterion = other.VisibilityCriterion;
									}
									conditions_.Add(other.conditions_);
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
										VisibilityCriterion = (Types.VisibilityCriterion)input.ReadEnum();
										break;
									case 18u:
										conditions_.AddEntriesFrom(input, _repeated_conditions_codec);
										break;
									}
								}
							}
						}

						[DebuggerDisplay("{ToString(),nq}")]
						public sealed class SlideText : IMessage<SlideText>, IMessage, IEquatable<SlideText>, IDeepCloneable<SlideText>
						{
							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static class Types
							{
								public enum TextSourceOption
								{
									[OriginalName("TEXT_SOURCE_OPTION_TEXT")]
									Text,
									[OriginalName("TEXT_SOURCE_OPTION_NOTES")]
									Notes,
									[OriginalName("TEXT_SOURCE_OPTION_ELEMENT_MATCHING_NAME")]
									ElementMatchingName
								}
							}

							private static readonly MessageParser<SlideText> _parser = new MessageParser<SlideText>(() => new SlideText());

							private UnknownFieldSet _unknownFields;

							public const int SourceSlideFieldNumber = 1;

							private SlideSourceType sourceSlide_;

							public const int SourceOptionFieldNumber = 2;

							private Types.TextSourceOption sourceOption_;

							public const int PreserveNotesFormatFieldNumber = 3;

							private bool preserveNotesFormat_;

							public const int NameToMatchFieldNumber = 4;

							private string nameToMatch_ = "";

							public const int ElementTextTransformFieldNumber = 5;

							private AlternateElementText.Types.TextTransformOption elementTextTransform_;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageParser<SlideText> Parser => _parser;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageDescriptor Descriptor => DataLink.Descriptor.NestedTypes[13];

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							MessageDescriptor IMessage.Descriptor => Descriptor;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public SlideSourceType SourceSlide
							{
								get
								{
									return sourceSlide_;
								}
								set
								{
									sourceSlide_ = value;
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Types.TextSourceOption SourceOption
							{
								get
								{
									return sourceOption_;
								}
								set
								{
									sourceOption_ = value;
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool PreserveNotesFormat
							{
								get
								{
									return preserveNotesFormat_;
								}
								set
								{
									preserveNotesFormat_ = value;
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public string NameToMatch
							{
								get
								{
									return nameToMatch_;
								}
								set
								{
									nameToMatch_ = ProtoPreconditions.CheckNotNull(value, "value");
								}
							}

							[Obsolete]
							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public AlternateElementText.Types.TextTransformOption ElementTextTransform
							{
								get
								{
									return elementTextTransform_;
								}
								set
								{
									elementTextTransform_ = value;
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public SlideText()
							{
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public SlideText(SlideText other)
								: this()
							{
								sourceSlide_ = other.sourceSlide_;
								sourceOption_ = other.sourceOption_;
								preserveNotesFormat_ = other.preserveNotesFormat_;
								nameToMatch_ = other.nameToMatch_;
								elementTextTransform_ = other.elementTextTransform_;
								_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public SlideText Clone()
							{
								return new SlideText(this);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public override bool Equals(object other)
							{
								return Equals(other as SlideText);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool Equals(SlideText other)
							{
								if (other == null)
								{
									return false;
								}
								if (other == this)
								{
									return true;
								}
								if (SourceSlide != other.SourceSlide)
								{
									return false;
								}
								if (SourceOption != other.SourceOption)
								{
									return false;
								}
								if (PreserveNotesFormat != other.PreserveNotesFormat)
								{
									return false;
								}
								if (NameToMatch != other.NameToMatch)
								{
									return false;
								}
								if (ElementTextTransform != other.ElementTextTransform)
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
								if (SourceSlide != 0)
								{
									num ^= SourceSlide.GetHashCode();
								}
								if (SourceOption != 0)
								{
									num ^= SourceOption.GetHashCode();
								}
								if (PreserveNotesFormat)
								{
									num ^= PreserveNotesFormat.GetHashCode();
								}
								if (NameToMatch.Length != 0)
								{
									num ^= NameToMatch.GetHashCode();
								}
								if (ElementTextTransform != 0)
								{
									num ^= ElementTextTransform.GetHashCode();
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
								if (SourceSlide != 0)
								{
									output.WriteRawTag(8);
									output.WriteEnum((int)SourceSlide);
								}
								if (SourceOption != 0)
								{
									output.WriteRawTag(16);
									output.WriteEnum((int)SourceOption);
								}
								if (PreserveNotesFormat)
								{
									output.WriteRawTag(24);
									output.WriteBool(PreserveNotesFormat);
								}
								if (NameToMatch.Length != 0)
								{
									output.WriteRawTag(34);
									output.WriteString(NameToMatch);
								}
								if (ElementTextTransform != 0)
								{
									output.WriteRawTag(40);
									output.WriteEnum((int)ElementTextTransform);
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
								if (SourceSlide != 0)
								{
									num += 1 + CodedOutputStream.ComputeEnumSize((int)SourceSlide);
								}
								if (SourceOption != 0)
								{
									num += 1 + CodedOutputStream.ComputeEnumSize((int)SourceOption);
								}
								if (PreserveNotesFormat)
								{
									num += 2;
								}
								if (NameToMatch.Length != 0)
								{
									num += 1 + CodedOutputStream.ComputeStringSize(NameToMatch);
								}
								if (ElementTextTransform != 0)
								{
									num += 1 + CodedOutputStream.ComputeEnumSize((int)ElementTextTransform);
								}
								if (_unknownFields != null)
								{
									num += _unknownFields.CalculateSize();
								}
								return num;
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public void MergeFrom(SlideText other)
							{
								if (other != null)
								{
									if (other.SourceSlide != 0)
									{
										SourceSlide = other.SourceSlide;
									}
									if (other.SourceOption != 0)
									{
										SourceOption = other.SourceOption;
									}
									if (other.PreserveNotesFormat)
									{
										PreserveNotesFormat = other.PreserveNotesFormat;
									}
									if (other.NameToMatch.Length != 0)
									{
										NameToMatch = other.NameToMatch;
									}
									if (other.ElementTextTransform != 0)
									{
										ElementTextTransform = other.ElementTextTransform;
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
										SourceSlide = (SlideSourceType)input.ReadEnum();
										break;
									case 16u:
										SourceOption = (Types.TextSourceOption)input.ReadEnum();
										break;
									case 24u:
										PreserveNotesFormat = input.ReadBool();
										break;
									case 34u:
										NameToMatch = input.ReadString();
										break;
									case 40u:
										ElementTextTransform = (AlternateElementText.Types.TextTransformOption)input.ReadEnum();
										break;
									}
								}
							}
						}

						[DebuggerDisplay("{ToString(),nq}")]
						public sealed class SlideImage : IMessage<SlideImage>, IMessage, IEquatable<SlideImage>, IDeepCloneable<SlideImage>
						{
							private static readonly MessageParser<SlideImage> _parser = new MessageParser<SlideImage>(() => new SlideImage());

							private UnknownFieldSet _unknownFields;

							public const int SourceSlideFieldNumber = 1;

							private SlideSourceType sourceSlide_;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageParser<SlideImage> Parser => _parser;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageDescriptor Descriptor => DataLink.Descriptor.NestedTypes[14];

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							MessageDescriptor IMessage.Descriptor => Descriptor;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public SlideSourceType SourceSlide
							{
								get
								{
									return sourceSlide_;
								}
								set
								{
									sourceSlide_ = value;
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public SlideImage()
							{
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public SlideImage(SlideImage other)
								: this()
							{
								sourceSlide_ = other.sourceSlide_;
								_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public SlideImage Clone()
							{
								return new SlideImage(this);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public override bool Equals(object other)
							{
								return Equals(other as SlideImage);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool Equals(SlideImage other)
							{
								if (other == null)
								{
									return false;
								}
								if (other == this)
								{
									return true;
								}
								if (SourceSlide != other.SourceSlide)
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
								if (SourceSlide != 0)
								{
									num ^= SourceSlide.GetHashCode();
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
								if (SourceSlide != 0)
								{
									output.WriteRawTag(8);
									output.WriteEnum((int)SourceSlide);
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
								if (SourceSlide != 0)
								{
									num += 1 + CodedOutputStream.ComputeEnumSize((int)SourceSlide);
								}
								if (_unknownFields != null)
								{
									num += _unknownFields.CalculateSize();
								}
								return num;
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public void MergeFrom(SlideImage other)
							{
								if (other != null)
								{
									if (other.SourceSlide != 0)
									{
										SourceSlide = other.SourceSlide;
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
										SourceSlide = (SlideSourceType)input.ReadEnum();
									}
								}
							}
						}

						[DebuggerDisplay("{ToString(),nq}")]
						public sealed class StageMessage : IMessage<StageMessage>, IMessage, IEquatable<StageMessage>, IDeepCloneable<StageMessage>
						{
							private static readonly MessageParser<StageMessage> _parser = new MessageParser<StageMessage>(() => new StageMessage());

							private UnknownFieldSet _unknownFields;

							public const int ShouldFlashFieldNumber = 1;

							private bool shouldFlash_;

							public const int FlashColorFieldNumber = 2;

							private Color flashColor_;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageParser<StageMessage> Parser => _parser;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageDescriptor Descriptor => DataLink.Descriptor.NestedTypes[15];

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							MessageDescriptor IMessage.Descriptor => Descriptor;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool ShouldFlash
							{
								get
								{
									return shouldFlash_;
								}
								set
								{
									shouldFlash_ = value;
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Color FlashColor
							{
								get
								{
									return flashColor_;
								}
								set
								{
									flashColor_ = value;
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public StageMessage()
							{
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public StageMessage(StageMessage other)
								: this()
							{
								shouldFlash_ = other.shouldFlash_;
								flashColor_ = ((other.flashColor_ != null) ? other.flashColor_.Clone() : null);
								_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public StageMessage Clone()
							{
								return new StageMessage(this);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public override bool Equals(object other)
							{
								return Equals(other as StageMessage);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool Equals(StageMessage other)
							{
								if (other == null)
								{
									return false;
								}
								if (other == this)
								{
									return true;
								}
								if (ShouldFlash != other.ShouldFlash)
								{
									return false;
								}
								if (!object.Equals(FlashColor, other.FlashColor))
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
								if (ShouldFlash)
								{
									num ^= ShouldFlash.GetHashCode();
								}
								if (flashColor_ != null)
								{
									num ^= FlashColor.GetHashCode();
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
								if (ShouldFlash)
								{
									output.WriteRawTag(8);
									output.WriteBool(ShouldFlash);
								}
								if (flashColor_ != null)
								{
									output.WriteRawTag(18);
									output.WriteMessage(FlashColor);
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
								if (ShouldFlash)
								{
									num += 2;
								}
								if (flashColor_ != null)
								{
									num += 1 + CodedOutputStream.ComputeMessageSize(FlashColor);
								}
								if (_unknownFields != null)
								{
									num += _unknownFields.CalculateSize();
								}
								return num;
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public void MergeFrom(StageMessage other)
							{
								if (other == null)
								{
									return;
								}
								if (other.ShouldFlash)
								{
									ShouldFlash = other.ShouldFlash;
								}
								if (other.flashColor_ != null)
								{
									if (flashColor_ == null)
									{
										FlashColor = new Color();
									}
									FlashColor.MergeFrom(other.FlashColor);
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
									case 8u:
										ShouldFlash = input.ReadBool();
										break;
									case 18u:
										if (flashColor_ == null)
										{
											FlashColor = new Color();
										}
										input.ReadMessage(FlashColor);
										break;
									}
								}
							}
						}

						[DebuggerDisplay("{ToString(),nq}")]
						public sealed class VideoCountdown : IMessage<VideoCountdown>, IMessage, IEquatable<VideoCountdown>, IDeepCloneable<VideoCountdown>
						{
							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static class Types
							{
								public enum VideoCountdownSource
								{
									[OriginalName("VIDEO_COUNTDOWN_SOURCE_PRESENTATION")]
									Presentation,
									[OriginalName("VIDEO_COUNTDOWN_SOURCE_ANNOUNCEMENT")]
									Announcement
								}
							}

							private static readonly MessageParser<VideoCountdown> _parser = new MessageParser<VideoCountdown>(() => new VideoCountdown());

							private UnknownFieldSet _unknownFields;

							public const int TimerFormatFieldNumber = 1;

							private Timer.Types.Format timerFormat_;

							public const int TimerFormatStringFieldNumber = 2;

							private string timerFormatString_ = "";

							public const int ColorTriggersFieldNumber = 3;

							private static readonly FieldCodec<ColorTrigger> _repeated_colorTriggers_codec = FieldCodec.ForMessage(26u, ColorTrigger.Parser);

							private readonly RepeatedField<ColorTrigger> colorTriggers_ = new RepeatedField<ColorTrigger>();

							public const int IgnoreLoopingVideosFieldNumber = 4;

							private bool ignoreLoopingVideos_;

							public const int VideoCountdownSourceFieldNumber = 5;

							private Types.VideoCountdownSource videoCountdownSource_;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageParser<VideoCountdown> Parser => _parser;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageDescriptor Descriptor => DataLink.Descriptor.NestedTypes[16];

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							MessageDescriptor IMessage.Descriptor => Descriptor;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Timer.Types.Format TimerFormat
							{
								get
								{
									return timerFormat_;
								}
								set
								{
									timerFormat_ = value;
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public string TimerFormatString
							{
								get
								{
									return timerFormatString_;
								}
								set
								{
									timerFormatString_ = ProtoPreconditions.CheckNotNull(value, "value");
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public RepeatedField<ColorTrigger> ColorTriggers => colorTriggers_;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool IgnoreLoopingVideos
							{
								get
								{
									return ignoreLoopingVideos_;
								}
								set
								{
									ignoreLoopingVideos_ = value;
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Types.VideoCountdownSource VideoCountdownSource
							{
								get
								{
									return videoCountdownSource_;
								}
								set
								{
									videoCountdownSource_ = value;
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public VideoCountdown()
							{
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public VideoCountdown(VideoCountdown other)
								: this()
							{
								timerFormat_ = ((other.timerFormat_ != null) ? other.timerFormat_.Clone() : null);
								timerFormatString_ = other.timerFormatString_;
								colorTriggers_ = other.colorTriggers_.Clone();
								ignoreLoopingVideos_ = other.ignoreLoopingVideos_;
								videoCountdownSource_ = other.videoCountdownSource_;
								_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public VideoCountdown Clone()
							{
								return new VideoCountdown(this);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public override bool Equals(object other)
							{
								return Equals(other as VideoCountdown);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool Equals(VideoCountdown other)
							{
								if (other == null)
								{
									return false;
								}
								if (other == this)
								{
									return true;
								}
								if (!object.Equals(TimerFormat, other.TimerFormat))
								{
									return false;
								}
								if (TimerFormatString != other.TimerFormatString)
								{
									return false;
								}
								if (!colorTriggers_.Equals(other.colorTriggers_))
								{
									return false;
								}
								if (IgnoreLoopingVideos != other.IgnoreLoopingVideos)
								{
									return false;
								}
								if (VideoCountdownSource != other.VideoCountdownSource)
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
								if (timerFormat_ != null)
								{
									num ^= TimerFormat.GetHashCode();
								}
								if (TimerFormatString.Length != 0)
								{
									num ^= TimerFormatString.GetHashCode();
								}
								num ^= colorTriggers_.GetHashCode();
								if (IgnoreLoopingVideos)
								{
									num ^= IgnoreLoopingVideos.GetHashCode();
								}
								if (VideoCountdownSource != 0)
								{
									num ^= VideoCountdownSource.GetHashCode();
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
								if (timerFormat_ != null)
								{
									output.WriteRawTag(10);
									output.WriteMessage(TimerFormat);
								}
								if (TimerFormatString.Length != 0)
								{
									output.WriteRawTag(18);
									output.WriteString(TimerFormatString);
								}
								colorTriggers_.WriteTo(output, _repeated_colorTriggers_codec);
								if (IgnoreLoopingVideos)
								{
									output.WriteRawTag(32);
									output.WriteBool(IgnoreLoopingVideos);
								}
								if (VideoCountdownSource != 0)
								{
									output.WriteRawTag(40);
									output.WriteEnum((int)VideoCountdownSource);
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
								if (timerFormat_ != null)
								{
									num += 1 + CodedOutputStream.ComputeMessageSize(TimerFormat);
								}
								if (TimerFormatString.Length != 0)
								{
									num += 1 + CodedOutputStream.ComputeStringSize(TimerFormatString);
								}
								num += colorTriggers_.CalculateSize(_repeated_colorTriggers_codec);
								if (IgnoreLoopingVideos)
								{
									num += 2;
								}
								if (VideoCountdownSource != 0)
								{
									num += 1 + CodedOutputStream.ComputeEnumSize((int)VideoCountdownSource);
								}
								if (_unknownFields != null)
								{
									num += _unknownFields.CalculateSize();
								}
								return num;
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public void MergeFrom(VideoCountdown other)
							{
								if (other == null)
								{
									return;
								}
								if (other.timerFormat_ != null)
								{
									if (timerFormat_ == null)
									{
										TimerFormat = new Timer.Types.Format();
									}
									TimerFormat.MergeFrom(other.TimerFormat);
								}
								if (other.TimerFormatString.Length != 0)
								{
									TimerFormatString = other.TimerFormatString;
								}
								colorTriggers_.Add(other.colorTriggers_);
								if (other.IgnoreLoopingVideos)
								{
									IgnoreLoopingVideos = other.IgnoreLoopingVideos;
								}
								if (other.VideoCountdownSource != 0)
								{
									VideoCountdownSource = other.VideoCountdownSource;
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
										if (timerFormat_ == null)
										{
											TimerFormat = new Timer.Types.Format();
										}
										input.ReadMessage(TimerFormat);
										break;
									case 18u:
										TimerFormatString = input.ReadString();
										break;
									case 26u:
										colorTriggers_.AddEntriesFrom(input, _repeated_colorTriggers_codec);
										break;
									case 32u:
										IgnoreLoopingVideos = input.ReadBool();
										break;
									case 40u:
										VideoCountdownSource = (Types.VideoCountdownSource)input.ReadEnum();
										break;
									}
								}
							}
						}

						[DebuggerDisplay("{ToString(),nq}")]
						public sealed class AudioCountdown : IMessage<AudioCountdown>, IMessage, IEquatable<AudioCountdown>, IDeepCloneable<AudioCountdown>
						{
							private static readonly MessageParser<AudioCountdown> _parser = new MessageParser<AudioCountdown>(() => new AudioCountdown());

							private UnknownFieldSet _unknownFields;

							public const int TimerFormatFieldNumber = 1;

							private Timer.Types.Format timerFormat_;

							public const int TimerFormatStringFieldNumber = 2;

							private string timerFormatString_ = "";

							public const int ColorTriggersFieldNumber = 3;

							private static readonly FieldCodec<ColorTrigger> _repeated_colorTriggers_codec = FieldCodec.ForMessage(26u, ColorTrigger.Parser);

							private readonly RepeatedField<ColorTrigger> colorTriggers_ = new RepeatedField<ColorTrigger>();

							public const int IgnoreLoopingAudioFieldNumber = 4;

							private bool ignoreLoopingAudio_;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageParser<AudioCountdown> Parser => _parser;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageDescriptor Descriptor => DataLink.Descriptor.NestedTypes[17];

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							MessageDescriptor IMessage.Descriptor => Descriptor;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Timer.Types.Format TimerFormat
							{
								get
								{
									return timerFormat_;
								}
								set
								{
									timerFormat_ = value;
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public string TimerFormatString
							{
								get
								{
									return timerFormatString_;
								}
								set
								{
									timerFormatString_ = ProtoPreconditions.CheckNotNull(value, "value");
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public RepeatedField<ColorTrigger> ColorTriggers => colorTriggers_;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool IgnoreLoopingAudio
							{
								get
								{
									return ignoreLoopingAudio_;
								}
								set
								{
									ignoreLoopingAudio_ = value;
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public AudioCountdown()
							{
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public AudioCountdown(AudioCountdown other)
								: this()
							{
								timerFormat_ = ((other.timerFormat_ != null) ? other.timerFormat_.Clone() : null);
								timerFormatString_ = other.timerFormatString_;
								colorTriggers_ = other.colorTriggers_.Clone();
								ignoreLoopingAudio_ = other.ignoreLoopingAudio_;
								_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public AudioCountdown Clone()
							{
								return new AudioCountdown(this);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public override bool Equals(object other)
							{
								return Equals(other as AudioCountdown);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool Equals(AudioCountdown other)
							{
								if (other == null)
								{
									return false;
								}
								if (other == this)
								{
									return true;
								}
								if (!object.Equals(TimerFormat, other.TimerFormat))
								{
									return false;
								}
								if (TimerFormatString != other.TimerFormatString)
								{
									return false;
								}
								if (!colorTriggers_.Equals(other.colorTriggers_))
								{
									return false;
								}
								if (IgnoreLoopingAudio != other.IgnoreLoopingAudio)
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
								if (timerFormat_ != null)
								{
									num ^= TimerFormat.GetHashCode();
								}
								if (TimerFormatString.Length != 0)
								{
									num ^= TimerFormatString.GetHashCode();
								}
								num ^= colorTriggers_.GetHashCode();
								if (IgnoreLoopingAudio)
								{
									num ^= IgnoreLoopingAudio.GetHashCode();
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
								if (timerFormat_ != null)
								{
									output.WriteRawTag(10);
									output.WriteMessage(TimerFormat);
								}
								if (TimerFormatString.Length != 0)
								{
									output.WriteRawTag(18);
									output.WriteString(TimerFormatString);
								}
								colorTriggers_.WriteTo(output, _repeated_colorTriggers_codec);
								if (IgnoreLoopingAudio)
								{
									output.WriteRawTag(32);
									output.WriteBool(IgnoreLoopingAudio);
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
								if (timerFormat_ != null)
								{
									num += 1 + CodedOutputStream.ComputeMessageSize(TimerFormat);
								}
								if (TimerFormatString.Length != 0)
								{
									num += 1 + CodedOutputStream.ComputeStringSize(TimerFormatString);
								}
								num += colorTriggers_.CalculateSize(_repeated_colorTriggers_codec);
								if (IgnoreLoopingAudio)
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
							public void MergeFrom(AudioCountdown other)
							{
								if (other == null)
								{
									return;
								}
								if (other.timerFormat_ != null)
								{
									if (timerFormat_ == null)
									{
										TimerFormat = new Timer.Types.Format();
									}
									TimerFormat.MergeFrom(other.TimerFormat);
								}
								if (other.TimerFormatString.Length != 0)
								{
									TimerFormatString = other.TimerFormatString;
								}
								colorTriggers_.Add(other.colorTriggers_);
								if (other.IgnoreLoopingAudio)
								{
									IgnoreLoopingAudio = other.IgnoreLoopingAudio;
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
										if (timerFormat_ == null)
										{
											TimerFormat = new Timer.Types.Format();
										}
										input.ReadMessage(TimerFormat);
										break;
									case 18u:
										TimerFormatString = input.ReadString();
										break;
									case 26u:
										colorTriggers_.AddEntriesFrom(input, _repeated_colorTriggers_codec);
										break;
									case 32u:
										IgnoreLoopingAudio = input.ReadBool();
										break;
									}
								}
							}
						}

						[DebuggerDisplay("{ToString(),nq}")]
						public sealed class GroupName : IMessage<GroupName>, IMessage, IEquatable<GroupName>, IDeepCloneable<GroupName>
						{
							private static readonly MessageParser<GroupName> _parser = new MessageParser<GroupName>(() => new GroupName());

							private UnknownFieldSet _unknownFields;

							public const int GroupSourceFieldNumber = 1;

							private GroupSourceType groupSource_;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageParser<GroupName> Parser => _parser;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageDescriptor Descriptor => DataLink.Descriptor.NestedTypes[18];

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							MessageDescriptor IMessage.Descriptor => Descriptor;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public GroupSourceType GroupSource
							{
								get
								{
									return groupSource_;
								}
								set
								{
									groupSource_ = value;
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public GroupName()
							{
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public GroupName(GroupName other)
								: this()
							{
								groupSource_ = other.groupSource_;
								_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public GroupName Clone()
							{
								return new GroupName(this);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public override bool Equals(object other)
							{
								return Equals(other as GroupName);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool Equals(GroupName other)
							{
								if (other == null)
								{
									return false;
								}
								if (other == this)
								{
									return true;
								}
								if (GroupSource != other.GroupSource)
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
								if (GroupSource != 0)
								{
									num ^= GroupSource.GetHashCode();
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
								if (GroupSource != 0)
								{
									output.WriteRawTag(8);
									output.WriteEnum((int)GroupSource);
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
								if (GroupSource != 0)
								{
									num += 1 + CodedOutputStream.ComputeEnumSize((int)GroupSource);
								}
								if (_unknownFields != null)
								{
									num += _unknownFields.CalculateSize();
								}
								return num;
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public void MergeFrom(GroupName other)
							{
								if (other != null)
								{
									if (other.GroupSource != 0)
									{
										GroupSource = other.GroupSource;
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
										GroupSource = (GroupSourceType)input.ReadEnum();
									}
								}
							}
						}

						[DebuggerDisplay("{ToString(),nq}")]
						public sealed class GroupColor : IMessage<GroupColor>, IMessage, IEquatable<GroupColor>, IDeepCloneable<GroupColor>
						{
							private static readonly MessageParser<GroupColor> _parser = new MessageParser<GroupColor>(() => new GroupColor());

							private UnknownFieldSet _unknownFields;

							public const int GroupSourceFieldNumber = 1;

							private GroupSourceType groupSource_;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageParser<GroupColor> Parser => _parser;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageDescriptor Descriptor => DataLink.Descriptor.NestedTypes[19];

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							MessageDescriptor IMessage.Descriptor => Descriptor;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public GroupSourceType GroupSource
							{
								get
								{
									return groupSource_;
								}
								set
								{
									groupSource_ = value;
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public GroupColor()
							{
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public GroupColor(GroupColor other)
								: this()
							{
								groupSource_ = other.groupSource_;
								_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public GroupColor Clone()
							{
								return new GroupColor(this);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public override bool Equals(object other)
							{
								return Equals(other as GroupColor);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool Equals(GroupColor other)
							{
								if (other == null)
								{
									return false;
								}
								if (other == this)
								{
									return true;
								}
								if (GroupSource != other.GroupSource)
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
								if (GroupSource != 0)
								{
									num ^= GroupSource.GetHashCode();
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
								if (GroupSource != 0)
								{
									output.WriteRawTag(8);
									output.WriteEnum((int)GroupSource);
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
								if (GroupSource != 0)
								{
									num += 1 + CodedOutputStream.ComputeEnumSize((int)GroupSource);
								}
								if (_unknownFields != null)
								{
									num += _unknownFields.CalculateSize();
								}
								return num;
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public void MergeFrom(GroupColor other)
							{
								if (other != null)
								{
									if (other.GroupSource != 0)
									{
										GroupSource = other.GroupSource;
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
										GroupSource = (GroupSourceType)input.ReadEnum();
									}
								}
							}
						}

						[DebuggerDisplay("{ToString(),nq}")]
						public sealed class SlideLabelText : IMessage<SlideLabelText>, IMessage, IEquatable<SlideLabelText>, IDeepCloneable<SlideLabelText>
						{
							private static readonly MessageParser<SlideLabelText> _parser = new MessageParser<SlideLabelText>(() => new SlideLabelText());

							private UnknownFieldSet _unknownFields;

							public const int SlideLabelSourceFieldNumber = 1;

							private SlideLabelSource slideLabelSource_;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageParser<SlideLabelText> Parser => _parser;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageDescriptor Descriptor => DataLink.Descriptor.NestedTypes[20];

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							MessageDescriptor IMessage.Descriptor => Descriptor;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public SlideLabelSource SlideLabelSource
							{
								get
								{
									return slideLabelSource_;
								}
								set
								{
									slideLabelSource_ = value;
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public SlideLabelText()
							{
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public SlideLabelText(SlideLabelText other)
								: this()
							{
								slideLabelSource_ = other.slideLabelSource_;
								_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public SlideLabelText Clone()
							{
								return new SlideLabelText(this);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public override bool Equals(object other)
							{
								return Equals(other as SlideLabelText);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool Equals(SlideLabelText other)
							{
								if (other == null)
								{
									return false;
								}
								if (other == this)
								{
									return true;
								}
								if (SlideLabelSource != other.SlideLabelSource)
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
								if (SlideLabelSource != 0)
								{
									num ^= SlideLabelSource.GetHashCode();
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
								if (SlideLabelSource != 0)
								{
									output.WriteRawTag(8);
									output.WriteEnum((int)SlideLabelSource);
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
								if (SlideLabelSource != 0)
								{
									num += 1 + CodedOutputStream.ComputeEnumSize((int)SlideLabelSource);
								}
								if (_unknownFields != null)
								{
									num += _unknownFields.CalculateSize();
								}
								return num;
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public void MergeFrom(SlideLabelText other)
							{
								if (other != null)
								{
									if (other.SlideLabelSource != 0)
									{
										SlideLabelSource = other.SlideLabelSource;
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
										SlideLabelSource = (SlideLabelSource)input.ReadEnum();
									}
								}
							}
						}

						[DebuggerDisplay("{ToString(),nq}")]
						public sealed class SlideLabelColor : IMessage<SlideLabelColor>, IMessage, IEquatable<SlideLabelColor>, IDeepCloneable<SlideLabelColor>
						{
							private static readonly MessageParser<SlideLabelColor> _parser = new MessageParser<SlideLabelColor>(() => new SlideLabelColor());

							private UnknownFieldSet _unknownFields;

							public const int SlideLabelSourceFieldNumber = 1;

							private SlideLabelSource slideLabelSource_;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageParser<SlideLabelColor> Parser => _parser;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageDescriptor Descriptor => DataLink.Descriptor.NestedTypes[21];

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							MessageDescriptor IMessage.Descriptor => Descriptor;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public SlideLabelSource SlideLabelSource
							{
								get
								{
									return slideLabelSource_;
								}
								set
								{
									slideLabelSource_ = value;
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public SlideLabelColor()
							{
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public SlideLabelColor(SlideLabelColor other)
								: this()
							{
								slideLabelSource_ = other.slideLabelSource_;
								_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public SlideLabelColor Clone()
							{
								return new SlideLabelColor(this);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public override bool Equals(object other)
							{
								return Equals(other as SlideLabelColor);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool Equals(SlideLabelColor other)
							{
								if (other == null)
								{
									return false;
								}
								if (other == this)
								{
									return true;
								}
								if (SlideLabelSource != other.SlideLabelSource)
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
								if (SlideLabelSource != 0)
								{
									num ^= SlideLabelSource.GetHashCode();
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
								if (SlideLabelSource != 0)
								{
									output.WriteRawTag(8);
									output.WriteEnum((int)SlideLabelSource);
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
								if (SlideLabelSource != 0)
								{
									num += 1 + CodedOutputStream.ComputeEnumSize((int)SlideLabelSource);
								}
								if (_unknownFields != null)
								{
									num += _unknownFields.CalculateSize();
								}
								return num;
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public void MergeFrom(SlideLabelColor other)
							{
								if (other != null)
								{
									if (other.SlideLabelSource != 0)
									{
										SlideLabelSource = other.SlideLabelSource;
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
										SlideLabelSource = (SlideLabelSource)input.ReadEnum();
									}
								}
							}
						}

						[DebuggerDisplay("{ToString(),nq}")]
						public sealed class PresentationNotes : IMessage<PresentationNotes>, IMessage, IEquatable<PresentationNotes>, IDeepCloneable<PresentationNotes>
						{
							private static readonly MessageParser<PresentationNotes> _parser = new MessageParser<PresentationNotes>(() => new PresentationNotes());

							private UnknownFieldSet _unknownFields;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageParser<PresentationNotes> Parser => _parser;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageDescriptor Descriptor => DataLink.Descriptor.NestedTypes[22];

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							MessageDescriptor IMessage.Descriptor => Descriptor;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public PresentationNotes()
							{
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public PresentationNotes(PresentationNotes other)
								: this()
							{
								_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public PresentationNotes Clone()
							{
								return new PresentationNotes(this);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public override bool Equals(object other)
							{
								return Equals(other as PresentationNotes);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool Equals(PresentationNotes other)
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
							public void MergeFrom(PresentationNotes other)
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

						[DebuggerDisplay("{ToString(),nq}")]
						public sealed class Presentation : IMessage<Presentation>, IMessage, IEquatable<Presentation>, IDeepCloneable<Presentation>
						{
							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static class Types
							{
								public enum PresentationSource
								{
									[OriginalName("PRESENTATION_SOURCE_PRESENTATION")]
									Presentation,
									[OriginalName("PRESENTATION_SOURCE_ANNOUNCEMENT")]
									Announcement
								}
							}

							private static readonly MessageParser<Presentation> _parser = new MessageParser<Presentation>(() => new Presentation());

							private UnknownFieldSet _unknownFields;

							public const int PresentationSourceFieldNumber = 1;

							private Types.PresentationSource presentationSource_;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageParser<Presentation> Parser => _parser;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageDescriptor Descriptor => DataLink.Descriptor.NestedTypes[23];

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							MessageDescriptor IMessage.Descriptor => Descriptor;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Types.PresentationSource PresentationSource
							{
								get
								{
									return presentationSource_;
								}
								set
								{
									presentationSource_ = value;
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Presentation()
							{
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Presentation(Presentation other)
								: this()
							{
								presentationSource_ = other.presentationSource_;
								_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Presentation Clone()
							{
								return new Presentation(this);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public override bool Equals(object other)
							{
								return Equals(other as Presentation);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool Equals(Presentation other)
							{
								if (other == null)
								{
									return false;
								}
								if (other == this)
								{
									return true;
								}
								if (PresentationSource != other.PresentationSource)
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
								if (PresentationSource != 0)
								{
									num ^= PresentationSource.GetHashCode();
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
								if (PresentationSource != 0)
								{
									output.WriteRawTag(8);
									output.WriteEnum((int)PresentationSource);
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
								if (PresentationSource != 0)
								{
									num += 1 + CodedOutputStream.ComputeEnumSize((int)PresentationSource);
								}
								if (_unknownFields != null)
								{
									num += _unknownFields.CalculateSize();
								}
								return num;
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public void MergeFrom(Presentation other)
							{
								if (other != null)
								{
									if (other.PresentationSource != 0)
									{
										PresentationSource = other.PresentationSource;
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
										PresentationSource = (Types.PresentationSource)input.ReadEnum();
									}
								}
							}
						}

						[DebuggerDisplay("{ToString(),nq}")]
						public sealed class PlaylistItem : IMessage<PlaylistItem>, IMessage, IEquatable<PlaylistItem>, IDeepCloneable<PlaylistItem>
						{
							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static class Types
							{
								public enum PlaylistItemSourceType
								{
									[OriginalName("PLAYLIST_ITEM_SOURCE_TYPE_CURRENT")]
									Current,
									[OriginalName("PLAYLIST_ITEM_SOURCE_TYPE_NEXT")]
									Next,
									[OriginalName("PLAYLIST_ITEM_SOURCE_TYPE_CURRENT_HEADER")]
									CurrentHeader,
									[OriginalName("PLAYLIST_ITEM_SOURCE_TYPE_NEXT_HEADER")]
									NextHeader,
									[OriginalName("PLAYLIST_ITEM_SOURCE_TYPE_PARENT_PLAYLIST")]
									ParentPlaylist
								}
							}

							private static readonly MessageParser<PlaylistItem> _parser = new MessageParser<PlaylistItem>(() => new PlaylistItem());

							private UnknownFieldSet _unknownFields;

							public const int PlaylistItemSourceFieldNumber = 1;

							private Types.PlaylistItemSourceType playlistItemSource_;

							public const int ShowArrangementFieldNumber = 2;

							private bool showArrangement_;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageParser<PlaylistItem> Parser => _parser;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageDescriptor Descriptor => DataLink.Descriptor.NestedTypes[24];

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							MessageDescriptor IMessage.Descriptor => Descriptor;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Types.PlaylistItemSourceType PlaylistItemSource
							{
								get
								{
									return playlistItemSource_;
								}
								set
								{
									playlistItemSource_ = value;
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool ShowArrangement
							{
								get
								{
									return showArrangement_;
								}
								set
								{
									showArrangement_ = value;
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public PlaylistItem()
							{
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public PlaylistItem(PlaylistItem other)
								: this()
							{
								playlistItemSource_ = other.playlistItemSource_;
								showArrangement_ = other.showArrangement_;
								_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public PlaylistItem Clone()
							{
								return new PlaylistItem(this);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public override bool Equals(object other)
							{
								return Equals(other as PlaylistItem);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool Equals(PlaylistItem other)
							{
								if (other == null)
								{
									return false;
								}
								if (other == this)
								{
									return true;
								}
								if (PlaylistItemSource != other.PlaylistItemSource)
								{
									return false;
								}
								if (ShowArrangement != other.ShowArrangement)
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
								if (PlaylistItemSource != 0)
								{
									num ^= PlaylistItemSource.GetHashCode();
								}
								if (ShowArrangement)
								{
									num ^= ShowArrangement.GetHashCode();
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
								if (PlaylistItemSource != 0)
								{
									output.WriteRawTag(8);
									output.WriteEnum((int)PlaylistItemSource);
								}
								if (ShowArrangement)
								{
									output.WriteRawTag(16);
									output.WriteBool(ShowArrangement);
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
								if (PlaylistItemSource != 0)
								{
									num += 1 + CodedOutputStream.ComputeEnumSize((int)PlaylistItemSource);
								}
								if (ShowArrangement)
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
							public void MergeFrom(PlaylistItem other)
							{
								if (other != null)
								{
									if (other.PlaylistItemSource != 0)
									{
										PlaylistItemSource = other.PlaylistItemSource;
									}
									if (other.ShowArrangement)
									{
										ShowArrangement = other.ShowArrangement;
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
										PlaylistItemSource = (Types.PlaylistItemSourceType)input.ReadEnum();
										break;
									case 16u:
										ShowArrangement = input.ReadBool();
										break;
									}
								}
							}
						}

						[DebuggerDisplay("{ToString(),nq}")]
						public sealed class AutoAdvanceTimeRemaining : IMessage<AutoAdvanceTimeRemaining>, IMessage, IEquatable<AutoAdvanceTimeRemaining>, IDeepCloneable<AutoAdvanceTimeRemaining>
						{
							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static class Types
							{
								public enum AutoAdvanceSource
								{
									[OriginalName("AUTO_ADVANCE_SOURCE_PRESENTATION")]
									Presentation,
									[OriginalName("AUTO_ADVANCE_SOURCE_ANNOUNCEMENT")]
									Announcement
								}
							}

							private static readonly MessageParser<AutoAdvanceTimeRemaining> _parser = new MessageParser<AutoAdvanceTimeRemaining>(() => new AutoAdvanceTimeRemaining());

							private UnknownFieldSet _unknownFields;

							public const int AutoAdvanceSourceFieldNumber = 1;

							private Types.AutoAdvanceSource autoAdvanceSource_;

							public const int TimerFormatFieldNumber = 2;

							private Timer.Types.Format timerFormat_;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageParser<AutoAdvanceTimeRemaining> Parser => _parser;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageDescriptor Descriptor => DataLink.Descriptor.NestedTypes[25];

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							MessageDescriptor IMessage.Descriptor => Descriptor;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Types.AutoAdvanceSource AutoAdvanceSource
							{
								get
								{
									return autoAdvanceSource_;
								}
								set
								{
									autoAdvanceSource_ = value;
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Timer.Types.Format TimerFormat
							{
								get
								{
									return timerFormat_;
								}
								set
								{
									timerFormat_ = value;
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public AutoAdvanceTimeRemaining()
							{
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public AutoAdvanceTimeRemaining(AutoAdvanceTimeRemaining other)
								: this()
							{
								autoAdvanceSource_ = other.autoAdvanceSource_;
								timerFormat_ = ((other.timerFormat_ != null) ? other.timerFormat_.Clone() : null);
								_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public AutoAdvanceTimeRemaining Clone()
							{
								return new AutoAdvanceTimeRemaining(this);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public override bool Equals(object other)
							{
								return Equals(other as AutoAdvanceTimeRemaining);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool Equals(AutoAdvanceTimeRemaining other)
							{
								if (other == null)
								{
									return false;
								}
								if (other == this)
								{
									return true;
								}
								if (AutoAdvanceSource != other.AutoAdvanceSource)
								{
									return false;
								}
								if (!object.Equals(TimerFormat, other.TimerFormat))
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
								if (AutoAdvanceSource != 0)
								{
									num ^= AutoAdvanceSource.GetHashCode();
								}
								if (timerFormat_ != null)
								{
									num ^= TimerFormat.GetHashCode();
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
								if (AutoAdvanceSource != 0)
								{
									output.WriteRawTag(8);
									output.WriteEnum((int)AutoAdvanceSource);
								}
								if (timerFormat_ != null)
								{
									output.WriteRawTag(18);
									output.WriteMessage(TimerFormat);
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
								if (AutoAdvanceSource != 0)
								{
									num += 1 + CodedOutputStream.ComputeEnumSize((int)AutoAdvanceSource);
								}
								if (timerFormat_ != null)
								{
									num += 1 + CodedOutputStream.ComputeMessageSize(TimerFormat);
								}
								if (_unknownFields != null)
								{
									num += _unknownFields.CalculateSize();
								}
								return num;
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public void MergeFrom(AutoAdvanceTimeRemaining other)
							{
								if (other == null)
								{
									return;
								}
								if (other.AutoAdvanceSource != 0)
								{
									AutoAdvanceSource = other.AutoAdvanceSource;
								}
								if (other.timerFormat_ != null)
								{
									if (timerFormat_ == null)
									{
										TimerFormat = new Timer.Types.Format();
									}
									TimerFormat.MergeFrom(other.TimerFormat);
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
									case 8u:
										AutoAdvanceSource = (Types.AutoAdvanceSource)input.ReadEnum();
										break;
									case 18u:
										if (timerFormat_ == null)
										{
											TimerFormat = new Timer.Types.Format();
										}
										input.ReadMessage(TimerFormat);
										break;
									}
								}
							}
						}

						[DebuggerDisplay("{ToString(),nq}")]
						public sealed class CaptureStatusText : IMessage<CaptureStatusText>, IMessage, IEquatable<CaptureStatusText>, IDeepCloneable<CaptureStatusText>
						{
							public enum TextTypeOneofCase
							{
								None,
								StatusText,
								ElapsedTime
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static class Types
							{
								[DebuggerDisplay("{ToString(),nq}")]
								public sealed class StatusText : IMessage<StatusText>, IMessage, IEquatable<StatusText>, IDeepCloneable<StatusText>
								{
									private static readonly MessageParser<StatusText> _parser = new MessageParser<StatusText>(() => new StatusText());

									private UnknownFieldSet _unknownFields;

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public static MessageParser<StatusText> Parser => _parser;

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public static MessageDescriptor Descriptor => CaptureStatusText.Descriptor.NestedTypes[0];

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									MessageDescriptor IMessage.Descriptor => Descriptor;

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public StatusText()
									{
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public StatusText(StatusText other)
										: this()
									{
										_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public StatusText Clone()
									{
										return new StatusText(this);
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public override bool Equals(object other)
									{
										return Equals(other as StatusText);
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public bool Equals(StatusText other)
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
									public void MergeFrom(StatusText other)
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

								[DebuggerDisplay("{ToString(),nq}")]
								public sealed class ElapsedTime : IMessage<ElapsedTime>, IMessage, IEquatable<ElapsedTime>, IDeepCloneable<ElapsedTime>
								{
									private static readonly MessageParser<ElapsedTime> _parser = new MessageParser<ElapsedTime>(() => new ElapsedTime());

									private UnknownFieldSet _unknownFields;

									public const int TimerFormatFieldNumber = 1;

									private Timer.Types.Format timerFormat_;

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public static MessageParser<ElapsedTime> Parser => _parser;

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public static MessageDescriptor Descriptor => CaptureStatusText.Descriptor.NestedTypes[1];

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									MessageDescriptor IMessage.Descriptor => Descriptor;

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public Timer.Types.Format TimerFormat
									{
										get
										{
											return timerFormat_;
										}
										set
										{
											timerFormat_ = value;
										}
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public ElapsedTime()
									{
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public ElapsedTime(ElapsedTime other)
										: this()
									{
										timerFormat_ = ((other.timerFormat_ != null) ? other.timerFormat_.Clone() : null);
										_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public ElapsedTime Clone()
									{
										return new ElapsedTime(this);
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public override bool Equals(object other)
									{
										return Equals(other as ElapsedTime);
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public bool Equals(ElapsedTime other)
									{
										if (other == null)
										{
											return false;
										}
										if (other == this)
										{
											return true;
										}
										if (!object.Equals(TimerFormat, other.TimerFormat))
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
										if (timerFormat_ != null)
										{
											num ^= TimerFormat.GetHashCode();
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
										if (timerFormat_ != null)
										{
											output.WriteRawTag(10);
											output.WriteMessage(TimerFormat);
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
										if (timerFormat_ != null)
										{
											num += 1 + CodedOutputStream.ComputeMessageSize(TimerFormat);
										}
										if (_unknownFields != null)
										{
											num += _unknownFields.CalculateSize();
										}
										return num;
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public void MergeFrom(ElapsedTime other)
									{
										if (other == null)
										{
											return;
										}
										if (other.timerFormat_ != null)
										{
											if (timerFormat_ == null)
											{
												TimerFormat = new Timer.Types.Format();
											}
											TimerFormat.MergeFrom(other.TimerFormat);
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
											if (timerFormat_ == null)
											{
												TimerFormat = new Timer.Types.Format();
											}
											input.ReadMessage(TimerFormat);
										}
									}
								}
							}

							private static readonly MessageParser<CaptureStatusText> _parser = new MessageParser<CaptureStatusText>(() => new CaptureStatusText());

							private UnknownFieldSet _unknownFields;

							public const int StatusTextFieldNumber = 1;

							public const int ElapsedTimeFieldNumber = 2;

							private object textType_;

							private TextTypeOneofCase textTypeCase_;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageParser<CaptureStatusText> Parser => _parser;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageDescriptor Descriptor => DataLink.Descriptor.NestedTypes[26];

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							MessageDescriptor IMessage.Descriptor => Descriptor;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Types.StatusText StatusText
							{
								get
								{
									if (textTypeCase_ != TextTypeOneofCase.StatusText)
									{
										return null;
									}
									return (Types.StatusText)textType_;
								}
								set
								{
									textType_ = value;
									textTypeCase_ = ((value != null) ? TextTypeOneofCase.StatusText : TextTypeOneofCase.None);
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Types.ElapsedTime ElapsedTime
							{
								get
								{
									if (textTypeCase_ != TextTypeOneofCase.ElapsedTime)
									{
										return null;
									}
									return (Types.ElapsedTime)textType_;
								}
								set
								{
									textType_ = value;
									textTypeCase_ = ((value != null) ? TextTypeOneofCase.ElapsedTime : TextTypeOneofCase.None);
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public TextTypeOneofCase TextTypeCase => textTypeCase_;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public CaptureStatusText()
							{
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public CaptureStatusText(CaptureStatusText other)
								: this()
							{
								switch (other.TextTypeCase)
								{
								case TextTypeOneofCase.StatusText:
									StatusText = other.StatusText.Clone();
									break;
								case TextTypeOneofCase.ElapsedTime:
									ElapsedTime = other.ElapsedTime.Clone();
									break;
								}
								_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public CaptureStatusText Clone()
							{
								return new CaptureStatusText(this);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public void ClearTextType()
							{
								textTypeCase_ = TextTypeOneofCase.None;
								textType_ = null;
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public override bool Equals(object other)
							{
								return Equals(other as CaptureStatusText);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool Equals(CaptureStatusText other)
							{
								if (other == null)
								{
									return false;
								}
								if (other == this)
								{
									return true;
								}
								if (!object.Equals(StatusText, other.StatusText))
								{
									return false;
								}
								if (!object.Equals(ElapsedTime, other.ElapsedTime))
								{
									return false;
								}
								if (TextTypeCase != other.TextTypeCase)
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
								if (textTypeCase_ == TextTypeOneofCase.StatusText)
								{
									num ^= StatusText.GetHashCode();
								}
								if (textTypeCase_ == TextTypeOneofCase.ElapsedTime)
								{
									num ^= ElapsedTime.GetHashCode();
								}
								num ^= (int)textTypeCase_;
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
								if (textTypeCase_ == TextTypeOneofCase.StatusText)
								{
									output.WriteRawTag(10);
									output.WriteMessage(StatusText);
								}
								if (textTypeCase_ == TextTypeOneofCase.ElapsedTime)
								{
									output.WriteRawTag(18);
									output.WriteMessage(ElapsedTime);
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
								if (textTypeCase_ == TextTypeOneofCase.StatusText)
								{
									num += 1 + CodedOutputStream.ComputeMessageSize(StatusText);
								}
								if (textTypeCase_ == TextTypeOneofCase.ElapsedTime)
								{
									num += 1 + CodedOutputStream.ComputeMessageSize(ElapsedTime);
								}
								if (_unknownFields != null)
								{
									num += _unknownFields.CalculateSize();
								}
								return num;
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public void MergeFrom(CaptureStatusText other)
							{
								if (other == null)
								{
									return;
								}
								switch (other.TextTypeCase)
								{
								case TextTypeOneofCase.StatusText:
									if (StatusText == null)
									{
										StatusText = new Types.StatusText();
									}
									StatusText.MergeFrom(other.StatusText);
									break;
								case TextTypeOneofCase.ElapsedTime:
									if (ElapsedTime == null)
									{
										ElapsedTime = new Types.ElapsedTime();
									}
									ElapsedTime.MergeFrom(other.ElapsedTime);
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
										Types.StatusText statusText = new Types.StatusText();
										if (textTypeCase_ == TextTypeOneofCase.StatusText)
										{
											statusText.MergeFrom(StatusText);
										}
										input.ReadMessage(statusText);
										StatusText = statusText;
										break;
									}
									case 18u:
									{
										Types.ElapsedTime elapsedTime = new Types.ElapsedTime();
										if (textTypeCase_ == TextTypeOneofCase.ElapsedTime)
										{
											elapsedTime.MergeFrom(ElapsedTime);
										}
										input.ReadMessage(elapsedTime);
										ElapsedTime = elapsedTime;
										break;
									}
									}
								}
							}
						}

						[DebuggerDisplay("{ToString(),nq}")]
						public sealed class CaptureStatusColor : IMessage<CaptureStatusColor>, IMessage, IEquatable<CaptureStatusColor>, IDeepCloneable<CaptureStatusColor>
						{
							private static readonly MessageParser<CaptureStatusColor> _parser = new MessageParser<CaptureStatusColor>(() => new CaptureStatusColor());

							private UnknownFieldSet _unknownFields;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageParser<CaptureStatusColor> Parser => _parser;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageDescriptor Descriptor => DataLink.Descriptor.NestedTypes[27];

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							MessageDescriptor IMessage.Descriptor => Descriptor;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public CaptureStatusColor()
							{
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public CaptureStatusColor(CaptureStatusColor other)
								: this()
							{
								_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public CaptureStatusColor Clone()
							{
								return new CaptureStatusColor(this);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public override bool Equals(object other)
							{
								return Equals(other as CaptureStatusColor);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool Equals(CaptureStatusColor other)
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
							public void MergeFrom(CaptureStatusColor other)
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

						[DebuggerDisplay("{ToString(),nq}")]
						public sealed class SlideCount : IMessage<SlideCount>, IMessage, IEquatable<SlideCount>, IDeepCloneable<SlideCount>
						{
							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static class Types
							{
								public enum SlideCountSourceType
								{
									[OriginalName("SLIDE_COUNT_SOURCE_TYPE_CURRENT")]
									Current,
									[OriginalName("SLIDE_COUNT_SOURCE_TYPE_REMAINING")]
									Remaining,
									[OriginalName("SLIDE_COUNT_SOURCE_TYPE_TOTAL")]
									Total
								}
							}

							private static readonly MessageParser<SlideCount> _parser = new MessageParser<SlideCount>(() => new SlideCount());

							private UnknownFieldSet _unknownFields;

							public const int SlideCountSourceTypeFieldNumber = 1;

							private Types.SlideCountSourceType slideCountSourceType_;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageParser<SlideCount> Parser => _parser;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageDescriptor Descriptor => DataLink.Descriptor.NestedTypes[28];

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							MessageDescriptor IMessage.Descriptor => Descriptor;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Types.SlideCountSourceType SlideCountSourceType
							{
								get
								{
									return slideCountSourceType_;
								}
								set
								{
									slideCountSourceType_ = value;
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public SlideCount()
							{
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public SlideCount(SlideCount other)
								: this()
							{
								slideCountSourceType_ = other.slideCountSourceType_;
								_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public SlideCount Clone()
							{
								return new SlideCount(this);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public override bool Equals(object other)
							{
								return Equals(other as SlideCount);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool Equals(SlideCount other)
							{
								if (other == null)
								{
									return false;
								}
								if (other == this)
								{
									return true;
								}
								if (SlideCountSourceType != other.SlideCountSourceType)
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
								if (SlideCountSourceType != 0)
								{
									num ^= SlideCountSourceType.GetHashCode();
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
								if (SlideCountSourceType != 0)
								{
									output.WriteRawTag(8);
									output.WriteEnum((int)SlideCountSourceType);
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
								if (SlideCountSourceType != 0)
								{
									num += 1 + CodedOutputStream.ComputeEnumSize((int)SlideCountSourceType);
								}
								if (_unknownFields != null)
								{
									num += _unknownFields.CalculateSize();
								}
								return num;
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public void MergeFrom(SlideCount other)
							{
								if (other != null)
								{
									if (other.SlideCountSourceType != 0)
									{
										SlideCountSourceType = other.SlideCountSourceType;
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
										SlideCountSourceType = (Types.SlideCountSourceType)input.ReadEnum();
									}
								}
							}
						}

						[DebuggerDisplay("{ToString(),nq}")]
						public sealed class PlaybackMarkerIdentifier : IMessage<PlaybackMarkerIdentifier>, IMessage, IEquatable<PlaybackMarkerIdentifier>, IDeepCloneable<PlaybackMarkerIdentifier>
						{
							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static class Types
							{
								public enum Type
								{
									[OriginalName("PLAYBACK_MARKER_IDENTIFIER_FIRST")]
									PlaybackMarkerIdentifierFirst,
									[OriginalName("PLAYBACK_MARKER_IDENTIFIER_PREVIOUS")]
									PlaybackMarkerIdentifierPrevious,
									[OriginalName("PLAYBACK_MARKER_IDENTIFIER_NEXT")]
									PlaybackMarkerIdentifierNext,
									[OriginalName("PLAYBACK_MARKER_IDENTIFIER_LAST")]
									PlaybackMarkerIdentifierLast,
									[OriginalName("PLAYBACK_MARKER_IDENTIFIER_NAME")]
									PlaybackMarkerIdentifierName
								}

								public enum Destination
								{
									[OriginalName("PLAYBACK_MARKER_DESTINATION_PRESENTATION")]
									PlaybackMarkerDestinationPresentation,
									[OriginalName("PLAYBACK_MARKER_DESTINATION_ANNOUNCEMENT")]
									PlaybackMarkerDestinationAnnouncement,
									[OriginalName("PLAYBACK_MARKER_DESTINATION_AUDIO")]
									PlaybackMarkerDestinationAudio
								}
							}

							private static readonly MessageParser<PlaybackMarkerIdentifier> _parser = new MessageParser<PlaybackMarkerIdentifier>(() => new PlaybackMarkerIdentifier());

							private UnknownFieldSet _unknownFields;

							public const int DestinationFieldNumber = 1;

							private Types.Destination destination_;

							public const int TypeFieldNumber = 2;

							private Types.Type type_;

							public const int NameFieldNumber = 3;

							private string name_ = "";

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageParser<PlaybackMarkerIdentifier> Parser => _parser;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageDescriptor Descriptor => DataLink.Descriptor.NestedTypes[29];

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							MessageDescriptor IMessage.Descriptor => Descriptor;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Types.Destination Destination
							{
								get
								{
									return destination_;
								}
								set
								{
									destination_ = value;
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Types.Type Type
							{
								get
								{
									return type_;
								}
								set
								{
									type_ = value;
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
							public PlaybackMarkerIdentifier()
							{
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public PlaybackMarkerIdentifier(PlaybackMarkerIdentifier other)
								: this()
							{
								destination_ = other.destination_;
								type_ = other.type_;
								name_ = other.name_;
								_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public PlaybackMarkerIdentifier Clone()
							{
								return new PlaybackMarkerIdentifier(this);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public override bool Equals(object other)
							{
								return Equals(other as PlaybackMarkerIdentifier);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool Equals(PlaybackMarkerIdentifier other)
							{
								if (other == null)
								{
									return false;
								}
								if (other == this)
								{
									return true;
								}
								if (Destination != other.Destination)
								{
									return false;
								}
								if (Type != other.Type)
								{
									return false;
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
								if (Destination != 0)
								{
									num ^= Destination.GetHashCode();
								}
								if (Type != 0)
								{
									num ^= Type.GetHashCode();
								}
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
								if (Destination != 0)
								{
									output.WriteRawTag(8);
									output.WriteEnum((int)Destination);
								}
								if (Type != 0)
								{
									output.WriteRawTag(16);
									output.WriteEnum((int)Type);
								}
								if (Name.Length != 0)
								{
									output.WriteRawTag(26);
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
								if (Destination != 0)
								{
									num += 1 + CodedOutputStream.ComputeEnumSize((int)Destination);
								}
								if (Type != 0)
								{
									num += 1 + CodedOutputStream.ComputeEnumSize((int)Type);
								}
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
							public void MergeFrom(PlaybackMarkerIdentifier other)
							{
								if (other != null)
								{
									if (other.Destination != 0)
									{
										Destination = other.Destination;
									}
									if (other.Type != 0)
									{
										Type = other.Type;
									}
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
									switch (num)
									{
									default:
										_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
										break;
									case 8u:
										Destination = (Types.Destination)input.ReadEnum();
										break;
									case 16u:
										Type = (Types.Type)input.ReadEnum();
										break;
									case 26u:
										Name = input.ReadString();
										break;
									}
								}
							}
						}

						[DebuggerDisplay("{ToString(),nq}")]
						public sealed class PlaybackMarkerText : IMessage<PlaybackMarkerText>, IMessage, IEquatable<PlaybackMarkerText>, IDeepCloneable<PlaybackMarkerText>
						{
							public enum TextTypeOneofCase
							{
								None = 0,
								Name = 2,
								Time = 3
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static class Types
							{
								[DebuggerDisplay("{ToString(),nq}")]
								public sealed class Name : IMessage<Name>, IMessage, IEquatable<Name>, IDeepCloneable<Name>
								{
									private static readonly MessageParser<Name> _parser = new MessageParser<Name>(() => new Name());

									private UnknownFieldSet _unknownFields;

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public static MessageParser<Name> Parser => _parser;

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public static MessageDescriptor Descriptor => PlaybackMarkerText.Descriptor.NestedTypes[0];

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									MessageDescriptor IMessage.Descriptor => Descriptor;

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public Name()
									{
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public Name(Name other)
										: this()
									{
										_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public Name Clone()
									{
										return new Name(this);
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public override bool Equals(object other)
									{
										return Equals(other as Name);
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public bool Equals(Name other)
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
									public void MergeFrom(Name other)
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

								[DebuggerDisplay("{ToString(),nq}")]
								public sealed class Time : IMessage<Time>, IMessage, IEquatable<Time>, IDeepCloneable<Time>
								{
									private static readonly MessageParser<Time> _parser = new MessageParser<Time>(() => new Time());

									private UnknownFieldSet _unknownFields;

									public const int FormatFieldNumber = 1;

									private Timer.Types.Format format_;

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public static MessageParser<Time> Parser => _parser;

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public static MessageDescriptor Descriptor => PlaybackMarkerText.Descriptor.NestedTypes[1];

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									MessageDescriptor IMessage.Descriptor => Descriptor;

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
									public Time()
									{
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public Time(Time other)
										: this()
									{
										format_ = ((other.format_ != null) ? other.format_.Clone() : null);
										_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public Time Clone()
									{
										return new Time(this);
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public override bool Equals(object other)
									{
										return Equals(other as Time);
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public bool Equals(Time other)
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
									public void MergeFrom(Time other)
									{
										if (other == null)
										{
											return;
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
											if (num != 10)
											{
												_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
												continue;
											}
											if (format_ == null)
											{
												Format = new Timer.Types.Format();
											}
											input.ReadMessage(Format);
										}
									}
								}
							}

							private static readonly MessageParser<PlaybackMarkerText> _parser = new MessageParser<PlaybackMarkerText>(() => new PlaybackMarkerText());

							private UnknownFieldSet _unknownFields;

							public const int IdentifierFieldNumber = 1;

							private PlaybackMarkerIdentifier identifier_;

							public const int NameFieldNumber = 2;

							public const int TimeFieldNumber = 3;

							public const int ShouldUseMarkerColorFieldNumber = 4;

							private bool shouldUseMarkerColor_;

							private object textType_;

							private TextTypeOneofCase textTypeCase_;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageParser<PlaybackMarkerText> Parser => _parser;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageDescriptor Descriptor => DataLink.Descriptor.NestedTypes[30];

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							MessageDescriptor IMessage.Descriptor => Descriptor;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public PlaybackMarkerIdentifier Identifier
							{
								get
								{
									return identifier_;
								}
								set
								{
									identifier_ = value;
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Types.Name Name
							{
								get
								{
									if (textTypeCase_ != TextTypeOneofCase.Name)
									{
										return null;
									}
									return (Types.Name)textType_;
								}
								set
								{
									textType_ = value;
									textTypeCase_ = ((value != null) ? TextTypeOneofCase.Name : TextTypeOneofCase.None);
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Types.Time Time
							{
								get
								{
									if (textTypeCase_ != TextTypeOneofCase.Time)
									{
										return null;
									}
									return (Types.Time)textType_;
								}
								set
								{
									textType_ = value;
									textTypeCase_ = ((value != null) ? TextTypeOneofCase.Time : TextTypeOneofCase.None);
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool ShouldUseMarkerColor
							{
								get
								{
									return shouldUseMarkerColor_;
								}
								set
								{
									shouldUseMarkerColor_ = value;
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public TextTypeOneofCase TextTypeCase => textTypeCase_;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public PlaybackMarkerText()
							{
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public PlaybackMarkerText(PlaybackMarkerText other)
								: this()
							{
								identifier_ = ((other.identifier_ != null) ? other.identifier_.Clone() : null);
								shouldUseMarkerColor_ = other.shouldUseMarkerColor_;
								switch (other.TextTypeCase)
								{
								case TextTypeOneofCase.Name:
									Name = other.Name.Clone();
									break;
								case TextTypeOneofCase.Time:
									Time = other.Time.Clone();
									break;
								}
								_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public PlaybackMarkerText Clone()
							{
								return new PlaybackMarkerText(this);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public void ClearTextType()
							{
								textTypeCase_ = TextTypeOneofCase.None;
								textType_ = null;
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public override bool Equals(object other)
							{
								return Equals(other as PlaybackMarkerText);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool Equals(PlaybackMarkerText other)
							{
								if (other == null)
								{
									return false;
								}
								if (other == this)
								{
									return true;
								}
								if (!object.Equals(Identifier, other.Identifier))
								{
									return false;
								}
								if (!object.Equals(Name, other.Name))
								{
									return false;
								}
								if (!object.Equals(Time, other.Time))
								{
									return false;
								}
								if (ShouldUseMarkerColor != other.ShouldUseMarkerColor)
								{
									return false;
								}
								if (TextTypeCase != other.TextTypeCase)
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
								if (identifier_ != null)
								{
									num ^= Identifier.GetHashCode();
								}
								if (textTypeCase_ == TextTypeOneofCase.Name)
								{
									num ^= Name.GetHashCode();
								}
								if (textTypeCase_ == TextTypeOneofCase.Time)
								{
									num ^= Time.GetHashCode();
								}
								if (ShouldUseMarkerColor)
								{
									num ^= ShouldUseMarkerColor.GetHashCode();
								}
								num ^= (int)textTypeCase_;
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
								if (identifier_ != null)
								{
									output.WriteRawTag(10);
									output.WriteMessage(Identifier);
								}
								if (textTypeCase_ == TextTypeOneofCase.Name)
								{
									output.WriteRawTag(18);
									output.WriteMessage(Name);
								}
								if (textTypeCase_ == TextTypeOneofCase.Time)
								{
									output.WriteRawTag(26);
									output.WriteMessage(Time);
								}
								if (ShouldUseMarkerColor)
								{
									output.WriteRawTag(32);
									output.WriteBool(ShouldUseMarkerColor);
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
								if (identifier_ != null)
								{
									num += 1 + CodedOutputStream.ComputeMessageSize(Identifier);
								}
								if (textTypeCase_ == TextTypeOneofCase.Name)
								{
									num += 1 + CodedOutputStream.ComputeMessageSize(Name);
								}
								if (textTypeCase_ == TextTypeOneofCase.Time)
								{
									num += 1 + CodedOutputStream.ComputeMessageSize(Time);
								}
								if (ShouldUseMarkerColor)
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
							public void MergeFrom(PlaybackMarkerText other)
							{
								if (other == null)
								{
									return;
								}
								if (other.identifier_ != null)
								{
									if (identifier_ == null)
									{
										Identifier = new PlaybackMarkerIdentifier();
									}
									Identifier.MergeFrom(other.Identifier);
								}
								if (other.ShouldUseMarkerColor)
								{
									ShouldUseMarkerColor = other.ShouldUseMarkerColor;
								}
								switch (other.TextTypeCase)
								{
								case TextTypeOneofCase.Name:
									if (Name == null)
									{
										Name = new Types.Name();
									}
									Name.MergeFrom(other.Name);
									break;
								case TextTypeOneofCase.Time:
									if (Time == null)
									{
										Time = new Types.Time();
									}
									Time.MergeFrom(other.Time);
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
										if (identifier_ == null)
										{
											Identifier = new PlaybackMarkerIdentifier();
										}
										input.ReadMessage(Identifier);
										break;
									case 18u:
									{
										Types.Name name = new Types.Name();
										if (textTypeCase_ == TextTypeOneofCase.Name)
										{
											name.MergeFrom(Name);
										}
										input.ReadMessage(name);
										Name = name;
										break;
									}
									case 26u:
									{
										Types.Time time = new Types.Time();
										if (textTypeCase_ == TextTypeOneofCase.Time)
										{
											time.MergeFrom(Time);
										}
										input.ReadMessage(time);
										Time = time;
										break;
									}
									case 32u:
										ShouldUseMarkerColor = input.ReadBool();
										break;
									}
								}
							}
						}

						[DebuggerDisplay("{ToString(),nq}")]
						public sealed class ChordProChart : IMessage<ChordProChart>, IMessage, IEquatable<ChordProChart>, IDeepCloneable<ChordProChart>
						{
							private static readonly MessageParser<ChordProChart> _parser = new MessageParser<ChordProChart>(() => new ChordProChart());

							private UnknownFieldSet _unknownFields;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageParser<ChordProChart> Parser => _parser;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageDescriptor Descriptor => DataLink.Descriptor.NestedTypes[31];

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							MessageDescriptor IMessage.Descriptor => Descriptor;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public ChordProChart()
							{
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public ChordProChart(ChordProChart other)
								: this()
							{
								_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public ChordProChart Clone()
							{
								return new ChordProChart(this);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public override bool Equals(object other)
							{
								return Equals(other as ChordProChart);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool Equals(ChordProChart other)
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
							public void MergeFrom(ChordProChart other)
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

						[DebuggerDisplay("{ToString(),nq}")]
						public sealed class TimecodeText : IMessage<TimecodeText>, IMessage, IEquatable<TimecodeText>, IDeepCloneable<TimecodeText>
						{
							private static readonly MessageParser<TimecodeText> _parser = new MessageParser<TimecodeText>(() => new TimecodeText());

							private UnknownFieldSet _unknownFields;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageParser<TimecodeText> Parser => _parser;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageDescriptor Descriptor => DataLink.Descriptor.NestedTypes[32];

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							MessageDescriptor IMessage.Descriptor => Descriptor;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public TimecodeText()
							{
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public TimecodeText(TimecodeText other)
								: this()
							{
								_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public TimecodeText Clone()
							{
								return new TimecodeText(this);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public override bool Equals(object other)
							{
								return Equals(other as TimecodeText);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool Equals(TimecodeText other)
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
							public void MergeFrom(TimecodeText other)
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

						[DebuggerDisplay("{ToString(),nq}")]
						public sealed class TimecodeStatus : IMessage<TimecodeStatus>, IMessage, IEquatable<TimecodeStatus>, IDeepCloneable<TimecodeStatus>
						{
							private static readonly MessageParser<TimecodeStatus> _parser = new MessageParser<TimecodeStatus>(() => new TimecodeStatus());

							private UnknownFieldSet _unknownFields;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageParser<TimecodeStatus> Parser => _parser;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageDescriptor Descriptor => DataLink.Descriptor.NestedTypes[33];

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							MessageDescriptor IMessage.Descriptor => Descriptor;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public TimecodeStatus()
							{
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public TimecodeStatus(TimecodeStatus other)
								: this()
							{
								_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public TimecodeStatus Clone()
							{
								return new TimecodeStatus(this);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public override bool Equals(object other)
							{
								return Equals(other as TimecodeStatus);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool Equals(TimecodeStatus other)
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
							public void MergeFrom(TimecodeStatus other)
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

						[DebuggerDisplay("{ToString(),nq}")]
						public sealed class KeyValueText : IMessage<KeyValueText>, IMessage, IEquatable<KeyValueText>, IDeepCloneable<KeyValueText>
						{
							private static readonly MessageParser<KeyValueText> _parser = new MessageParser<KeyValueText>(() => new KeyValueText());

							private UnknownFieldSet _unknownFields;

							public const int KeyFieldNumber = 1;

							private string key_ = "";

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageParser<KeyValueText> Parser => _parser;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageDescriptor Descriptor => DataLink.Descriptor.NestedTypes[34];

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							MessageDescriptor IMessage.Descriptor => Descriptor;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public string Key
							{
								get
								{
									return key_;
								}
								set
								{
									key_ = ProtoPreconditions.CheckNotNull(value, "value");
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public KeyValueText()
							{
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public KeyValueText(KeyValueText other)
								: this()
							{
								key_ = other.key_;
								_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public KeyValueText Clone()
							{
								return new KeyValueText(this);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public override bool Equals(object other)
							{
								return Equals(other as KeyValueText);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool Equals(KeyValueText other)
							{
								if (other == null)
								{
									return false;
								}
								if (other == this)
								{
									return true;
								}
								if (Key != other.Key)
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
								if (Key.Length != 0)
								{
									num ^= Key.GetHashCode();
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
								if (Key.Length != 0)
								{
									output.WriteRawTag(10);
									output.WriteString(Key);
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
								if (Key.Length != 0)
								{
									num += 1 + CodedOutputStream.ComputeStringSize(Key);
								}
								if (_unknownFields != null)
								{
									num += _unknownFields.CalculateSize();
								}
								return num;
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public void MergeFrom(KeyValueText other)
							{
								if (other != null)
								{
									if (other.Key.Length != 0)
									{
										Key = other.Key;
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
										Key = input.ReadString();
									}
								}
							}
						}

						[DebuggerDisplay("{ToString(),nq}")]
						public sealed class KeyValueFill : IMessage<KeyValueFill>, IMessage, IEquatable<KeyValueFill>, IDeepCloneable<KeyValueFill>
						{
							private static readonly MessageParser<KeyValueFill> _parser = new MessageParser<KeyValueFill>(() => new KeyValueFill());

							private UnknownFieldSet _unknownFields;

							public const int KeyFieldNumber = 1;

							private string key_ = "";

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageParser<KeyValueFill> Parser => _parser;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageDescriptor Descriptor => DataLink.Descriptor.NestedTypes[35];

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							MessageDescriptor IMessage.Descriptor => Descriptor;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public string Key
							{
								get
								{
									return key_;
								}
								set
								{
									key_ = ProtoPreconditions.CheckNotNull(value, "value");
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public KeyValueFill()
							{
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public KeyValueFill(KeyValueFill other)
								: this()
							{
								key_ = other.key_;
								_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public KeyValueFill Clone()
							{
								return new KeyValueFill(this);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public override bool Equals(object other)
							{
								return Equals(other as KeyValueFill);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool Equals(KeyValueFill other)
							{
								if (other == null)
								{
									return false;
								}
								if (other == this)
								{
									return true;
								}
								if (Key != other.Key)
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
								if (Key.Length != 0)
								{
									num ^= Key.GetHashCode();
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
								if (Key.Length != 0)
								{
									output.WriteRawTag(10);
									output.WriteString(Key);
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
								if (Key.Length != 0)
								{
									num += 1 + CodedOutputStream.ComputeStringSize(Key);
								}
								if (_unknownFields != null)
								{
									num += _unknownFields.CalculateSize();
								}
								return num;
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public void MergeFrom(KeyValueFill other)
							{
								if (other != null)
								{
									if (other.Key.Length != 0)
									{
										Key = other.Key;
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
										Key = input.ReadString();
									}
								}
							}
						}

						[DebuggerDisplay("{ToString(),nq}")]
						public sealed class Zone : IMessage<Zone>, IMessage, IEquatable<Zone>, IDeepCloneable<Zone>
						{
							private static readonly MessageParser<Zone> _parser = new MessageParser<Zone>(() => new Zone());

							private UnknownFieldSet _unknownFields;

							public const int UuidFieldNumber = 1;

							private UUID uuid_;

							public const int NameFieldNumber = 2;

							private string name_ = "";

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageParser<Zone> Parser => _parser;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageDescriptor Descriptor => DataLink.Descriptor.NestedTypes[36];

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
							public Zone()
							{
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Zone(Zone other)
								: this()
							{
								uuid_ = ((other.uuid_ != null) ? other.uuid_.Clone() : null);
								name_ = other.name_;
								_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Zone Clone()
							{
								return new Zone(this);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public override bool Equals(object other)
							{
								return Equals(other as Zone);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool Equals(Zone other)
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
								if (uuid_ != null)
								{
									num ^= Uuid.GetHashCode();
								}
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
								if (uuid_ != null)
								{
									output.WriteRawTag(10);
									output.WriteMessage(Uuid);
								}
								if (Name.Length != 0)
								{
									output.WriteRawTag(18);
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
								if (uuid_ != null)
								{
									num += 1 + CodedOutputStream.ComputeMessageSize(Uuid);
								}
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
							public void MergeFrom(Zone other)
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
								if (other.Name.Length != 0)
								{
									Name = other.Name;
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
										Name = input.ReadString();
										break;
									}
								}
							}
						}
					}

					private static readonly MessageParser<DataLink> _parser = new MessageParser<DataLink>(() => new DataLink());

					private UnknownFieldSet _unknownFields;

					public const int TickerFieldNumber = 1;

					public const int AlternateTextFieldNumber = 2;

					public const int TimerTextFieldNumber = 3;

					public const int ClockTextFieldNumber = 4;

					public const int ChordChartFieldNumber = 5;

					public const int OutputScreenFieldNumber = 6;

					public const int PcoLiveFieldNumber = 7;

					public const int AlternateFillFieldNumber = 8;

					public const int VisibilityLinkFieldNumber = 9;

					public const int SlideTextFieldNumber = 10;

					public const int StageMessageFieldNumber = 11;

					public const int VideoCountdownFieldNumber = 12;

					public const int SlideImageFieldNumber = 13;

					public const int CcliTextFieldNumber = 14;

					public const int GroupNameFieldNumber = 15;

					public const int GroupColorFieldNumber = 16;

					public const int PresentationNotesFieldNumber = 17;

					public const int PlaylistItemFieldNumber = 18;

					public const int AutoAdvanceTimeRemainingFieldNumber = 19;

					public const int CaptureStatusTextFieldNumber = 20;

					public const int CaptureStatusColorFieldNumber = 21;

					public const int SlideCountFieldNumber = 22;

					public const int AudioCountdownFieldNumber = 23;

					public const int PresentationFieldNumber = 24;

					public const int SlideLabelTextFieldNumber = 25;

					public const int SlideLabelColorFieldNumber = 26;

					public const int RssFeedFieldNumber = 27;

					public const int FileFeedFieldNumber = 28;

					public const int ChordProChartFieldNumber = 29;

					public const int PlaybackMarkerTextFieldNumber = 30;

					public const int PlaybackMarkerColorFieldNumber = 32;

					public const int TimecodeTextFieldNumber = 33;

					public const int TimecodeStatusFieldNumber = 34;

					public const int MessageTextFieldNumber = 35;

					public const int KeyValueTextFieldNumber = 36;

					public const int KeyValueFillFieldNumber = 37;

					public const int ZoneFieldNumber = 38;

					private object propertyType_;

					private PropertyTypeOneofCase propertyTypeCase_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<DataLink> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => Element.Descriptor.NestedTypes[2];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[Obsolete]
					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Types.Ticker Ticker
					{
						get
						{
							if (propertyTypeCase_ != PropertyTypeOneofCase.Ticker)
							{
								return null;
							}
							return (Types.Ticker)propertyType_;
						}
						set
						{
							propertyType_ = value;
							propertyTypeCase_ = ((value != null) ? PropertyTypeOneofCase.Ticker : PropertyTypeOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Types.AlternateElementText AlternateText
					{
						get
						{
							if (propertyTypeCase_ != PropertyTypeOneofCase.AlternateText)
							{
								return null;
							}
							return (Types.AlternateElementText)propertyType_;
						}
						set
						{
							propertyType_ = value;
							propertyTypeCase_ = ((value != null) ? PropertyTypeOneofCase.AlternateText : PropertyTypeOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Types.TimerText TimerText
					{
						get
						{
							if (propertyTypeCase_ != PropertyTypeOneofCase.TimerText)
							{
								return null;
							}
							return (Types.TimerText)propertyType_;
						}
						set
						{
							propertyType_ = value;
							propertyTypeCase_ = ((value != null) ? PropertyTypeOneofCase.TimerText : PropertyTypeOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Types.ClockText ClockText
					{
						get
						{
							if (propertyTypeCase_ != PropertyTypeOneofCase.ClockText)
							{
								return null;
							}
							return (Types.ClockText)propertyType_;
						}
						set
						{
							propertyType_ = value;
							propertyTypeCase_ = ((value != null) ? PropertyTypeOneofCase.ClockText : PropertyTypeOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Types.ChordChart ChordChart
					{
						get
						{
							if (propertyTypeCase_ != PropertyTypeOneofCase.ChordChart)
							{
								return null;
							}
							return (Types.ChordChart)propertyType_;
						}
						set
						{
							propertyType_ = value;
							propertyTypeCase_ = ((value != null) ? PropertyTypeOneofCase.ChordChart : PropertyTypeOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Types.OutputScreen OutputScreen
					{
						get
						{
							if (propertyTypeCase_ != PropertyTypeOneofCase.OutputScreen)
							{
								return null;
							}
							return (Types.OutputScreen)propertyType_;
						}
						set
						{
							propertyType_ = value;
							propertyTypeCase_ = ((value != null) ? PropertyTypeOneofCase.OutputScreen : PropertyTypeOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Types.PCOLive PcoLive
					{
						get
						{
							if (propertyTypeCase_ != PropertyTypeOneofCase.PcoLive)
							{
								return null;
							}
							return (Types.PCOLive)propertyType_;
						}
						set
						{
							propertyType_ = value;
							propertyTypeCase_ = ((value != null) ? PropertyTypeOneofCase.PcoLive : PropertyTypeOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Types.AlternateElementFill AlternateFill
					{
						get
						{
							if (propertyTypeCase_ != PropertyTypeOneofCase.AlternateFill)
							{
								return null;
							}
							return (Types.AlternateElementFill)propertyType_;
						}
						set
						{
							propertyType_ = value;
							propertyTypeCase_ = ((value != null) ? PropertyTypeOneofCase.AlternateFill : PropertyTypeOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Types.VisibilityLink VisibilityLink
					{
						get
						{
							if (propertyTypeCase_ != PropertyTypeOneofCase.VisibilityLink)
							{
								return null;
							}
							return (Types.VisibilityLink)propertyType_;
						}
						set
						{
							propertyType_ = value;
							propertyTypeCase_ = ((value != null) ? PropertyTypeOneofCase.VisibilityLink : PropertyTypeOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Types.SlideText SlideText
					{
						get
						{
							if (propertyTypeCase_ != PropertyTypeOneofCase.SlideText)
							{
								return null;
							}
							return (Types.SlideText)propertyType_;
						}
						set
						{
							propertyType_ = value;
							propertyTypeCase_ = ((value != null) ? PropertyTypeOneofCase.SlideText : PropertyTypeOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Types.StageMessage StageMessage
					{
						get
						{
							if (propertyTypeCase_ != PropertyTypeOneofCase.StageMessage)
							{
								return null;
							}
							return (Types.StageMessage)propertyType_;
						}
						set
						{
							propertyType_ = value;
							propertyTypeCase_ = ((value != null) ? PropertyTypeOneofCase.StageMessage : PropertyTypeOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Types.VideoCountdown VideoCountdown
					{
						get
						{
							if (propertyTypeCase_ != PropertyTypeOneofCase.VideoCountdown)
							{
								return null;
							}
							return (Types.VideoCountdown)propertyType_;
						}
						set
						{
							propertyType_ = value;
							propertyTypeCase_ = ((value != null) ? PropertyTypeOneofCase.VideoCountdown : PropertyTypeOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Types.SlideImage SlideImage
					{
						get
						{
							if (propertyTypeCase_ != PropertyTypeOneofCase.SlideImage)
							{
								return null;
							}
							return (Types.SlideImage)propertyType_;
						}
						set
						{
							propertyType_ = value;
							propertyTypeCase_ = ((value != null) ? PropertyTypeOneofCase.SlideImage : PropertyTypeOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Types.CCLIText CcliText
					{
						get
						{
							if (propertyTypeCase_ != PropertyTypeOneofCase.CcliText)
							{
								return null;
							}
							return (Types.CCLIText)propertyType_;
						}
						set
						{
							propertyType_ = value;
							propertyTypeCase_ = ((value != null) ? PropertyTypeOneofCase.CcliText : PropertyTypeOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Types.GroupName GroupName
					{
						get
						{
							if (propertyTypeCase_ != PropertyTypeOneofCase.GroupName)
							{
								return null;
							}
							return (Types.GroupName)propertyType_;
						}
						set
						{
							propertyType_ = value;
							propertyTypeCase_ = ((value != null) ? PropertyTypeOneofCase.GroupName : PropertyTypeOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Types.GroupColor GroupColor
					{
						get
						{
							if (propertyTypeCase_ != PropertyTypeOneofCase.GroupColor)
							{
								return null;
							}
							return (Types.GroupColor)propertyType_;
						}
						set
						{
							propertyType_ = value;
							propertyTypeCase_ = ((value != null) ? PropertyTypeOneofCase.GroupColor : PropertyTypeOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Types.PresentationNotes PresentationNotes
					{
						get
						{
							if (propertyTypeCase_ != PropertyTypeOneofCase.PresentationNotes)
							{
								return null;
							}
							return (Types.PresentationNotes)propertyType_;
						}
						set
						{
							propertyType_ = value;
							propertyTypeCase_ = ((value != null) ? PropertyTypeOneofCase.PresentationNotes : PropertyTypeOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Types.PlaylistItem PlaylistItem
					{
						get
						{
							if (propertyTypeCase_ != PropertyTypeOneofCase.PlaylistItem)
							{
								return null;
							}
							return (Types.PlaylistItem)propertyType_;
						}
						set
						{
							propertyType_ = value;
							propertyTypeCase_ = ((value != null) ? PropertyTypeOneofCase.PlaylistItem : PropertyTypeOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Types.AutoAdvanceTimeRemaining AutoAdvanceTimeRemaining
					{
						get
						{
							if (propertyTypeCase_ != PropertyTypeOneofCase.AutoAdvanceTimeRemaining)
							{
								return null;
							}
							return (Types.AutoAdvanceTimeRemaining)propertyType_;
						}
						set
						{
							propertyType_ = value;
							propertyTypeCase_ = ((value != null) ? PropertyTypeOneofCase.AutoAdvanceTimeRemaining : PropertyTypeOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Types.CaptureStatusText CaptureStatusText
					{
						get
						{
							if (propertyTypeCase_ != PropertyTypeOneofCase.CaptureStatusText)
							{
								return null;
							}
							return (Types.CaptureStatusText)propertyType_;
						}
						set
						{
							propertyType_ = value;
							propertyTypeCase_ = ((value != null) ? PropertyTypeOneofCase.CaptureStatusText : PropertyTypeOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Types.CaptureStatusColor CaptureStatusColor
					{
						get
						{
							if (propertyTypeCase_ != PropertyTypeOneofCase.CaptureStatusColor)
							{
								return null;
							}
							return (Types.CaptureStatusColor)propertyType_;
						}
						set
						{
							propertyType_ = value;
							propertyTypeCase_ = ((value != null) ? PropertyTypeOneofCase.CaptureStatusColor : PropertyTypeOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Types.SlideCount SlideCount
					{
						get
						{
							if (propertyTypeCase_ != PropertyTypeOneofCase.SlideCount)
							{
								return null;
							}
							return (Types.SlideCount)propertyType_;
						}
						set
						{
							propertyType_ = value;
							propertyTypeCase_ = ((value != null) ? PropertyTypeOneofCase.SlideCount : PropertyTypeOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Types.AudioCountdown AudioCountdown
					{
						get
						{
							if (propertyTypeCase_ != PropertyTypeOneofCase.AudioCountdown)
							{
								return null;
							}
							return (Types.AudioCountdown)propertyType_;
						}
						set
						{
							propertyType_ = value;
							propertyTypeCase_ = ((value != null) ? PropertyTypeOneofCase.AudioCountdown : PropertyTypeOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Types.Presentation Presentation
					{
						get
						{
							if (propertyTypeCase_ != PropertyTypeOneofCase.Presentation)
							{
								return null;
							}
							return (Types.Presentation)propertyType_;
						}
						set
						{
							propertyType_ = value;
							propertyTypeCase_ = ((value != null) ? PropertyTypeOneofCase.Presentation : PropertyTypeOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Types.SlideLabelText SlideLabelText
					{
						get
						{
							if (propertyTypeCase_ != PropertyTypeOneofCase.SlideLabelText)
							{
								return null;
							}
							return (Types.SlideLabelText)propertyType_;
						}
						set
						{
							propertyType_ = value;
							propertyTypeCase_ = ((value != null) ? PropertyTypeOneofCase.SlideLabelText : PropertyTypeOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Types.SlideLabelColor SlideLabelColor
					{
						get
						{
							if (propertyTypeCase_ != PropertyTypeOneofCase.SlideLabelColor)
							{
								return null;
							}
							return (Types.SlideLabelColor)propertyType_;
						}
						set
						{
							propertyType_ = value;
							propertyTypeCase_ = ((value != null) ? PropertyTypeOneofCase.SlideLabelColor : PropertyTypeOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Types.RSSFeed RssFeed
					{
						get
						{
							if (propertyTypeCase_ != PropertyTypeOneofCase.RssFeed)
							{
								return null;
							}
							return (Types.RSSFeed)propertyType_;
						}
						set
						{
							propertyType_ = value;
							propertyTypeCase_ = ((value != null) ? PropertyTypeOneofCase.RssFeed : PropertyTypeOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Types.FileFeed FileFeed
					{
						get
						{
							if (propertyTypeCase_ != PropertyTypeOneofCase.FileFeed)
							{
								return null;
							}
							return (Types.FileFeed)propertyType_;
						}
						set
						{
							propertyType_ = value;
							propertyTypeCase_ = ((value != null) ? PropertyTypeOneofCase.FileFeed : PropertyTypeOneofCase.None);
						}
					}

					[Obsolete]
					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Types.ChordProChart ChordProChart
					{
						get
						{
							if (propertyTypeCase_ != PropertyTypeOneofCase.ChordProChart)
							{
								return null;
							}
							return (Types.ChordProChart)propertyType_;
						}
						set
						{
							propertyType_ = value;
							propertyTypeCase_ = ((value != null) ? PropertyTypeOneofCase.ChordProChart : PropertyTypeOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Types.PlaybackMarkerText PlaybackMarkerText
					{
						get
						{
							if (propertyTypeCase_ != PropertyTypeOneofCase.PlaybackMarkerText)
							{
								return null;
							}
							return (Types.PlaybackMarkerText)propertyType_;
						}
						set
						{
							propertyType_ = value;
							propertyTypeCase_ = ((value != null) ? PropertyTypeOneofCase.PlaybackMarkerText : PropertyTypeOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Types.PlaybackMarkerIdentifier PlaybackMarkerColor
					{
						get
						{
							if (propertyTypeCase_ != PropertyTypeOneofCase.PlaybackMarkerColor)
							{
								return null;
							}
							return (Types.PlaybackMarkerIdentifier)propertyType_;
						}
						set
						{
							propertyType_ = value;
							propertyTypeCase_ = ((value != null) ? PropertyTypeOneofCase.PlaybackMarkerColor : PropertyTypeOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Types.TimecodeText TimecodeText
					{
						get
						{
							if (propertyTypeCase_ != PropertyTypeOneofCase.TimecodeText)
							{
								return null;
							}
							return (Types.TimecodeText)propertyType_;
						}
						set
						{
							propertyType_ = value;
							propertyTypeCase_ = ((value != null) ? PropertyTypeOneofCase.TimecodeText : PropertyTypeOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Types.TimecodeStatus TimecodeStatus
					{
						get
						{
							if (propertyTypeCase_ != PropertyTypeOneofCase.TimecodeStatus)
							{
								return null;
							}
							return (Types.TimecodeStatus)propertyType_;
						}
						set
						{
							propertyType_ = value;
							propertyTypeCase_ = ((value != null) ? PropertyTypeOneofCase.TimecodeStatus : PropertyTypeOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Message MessageText
					{
						get
						{
							if (propertyTypeCase_ != PropertyTypeOneofCase.MessageText)
							{
								return null;
							}
							return (Message)propertyType_;
						}
						set
						{
							propertyType_ = value;
							propertyTypeCase_ = ((value != null) ? PropertyTypeOneofCase.MessageText : PropertyTypeOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Types.KeyValueText KeyValueText
					{
						get
						{
							if (propertyTypeCase_ != PropertyTypeOneofCase.KeyValueText)
							{
								return null;
							}
							return (Types.KeyValueText)propertyType_;
						}
						set
						{
							propertyType_ = value;
							propertyTypeCase_ = ((value != null) ? PropertyTypeOneofCase.KeyValueText : PropertyTypeOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Types.KeyValueFill KeyValueFill
					{
						get
						{
							if (propertyTypeCase_ != PropertyTypeOneofCase.KeyValueFill)
							{
								return null;
							}
							return (Types.KeyValueFill)propertyType_;
						}
						set
						{
							propertyType_ = value;
							propertyTypeCase_ = ((value != null) ? PropertyTypeOneofCase.KeyValueFill : PropertyTypeOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Types.Zone Zone
					{
						get
						{
							if (propertyTypeCase_ != PropertyTypeOneofCase.Zone)
							{
								return null;
							}
							return (Types.Zone)propertyType_;
						}
						set
						{
							propertyType_ = value;
							propertyTypeCase_ = ((value != null) ? PropertyTypeOneofCase.Zone : PropertyTypeOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public PropertyTypeOneofCase PropertyTypeCase => propertyTypeCase_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public DataLink()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public DataLink(DataLink other)
						: this()
					{
						switch (other.PropertyTypeCase)
						{
						case PropertyTypeOneofCase.Ticker:
							Ticker = other.Ticker.Clone();
							break;
						case PropertyTypeOneofCase.AlternateText:
							AlternateText = other.AlternateText.Clone();
							break;
						case PropertyTypeOneofCase.TimerText:
							TimerText = other.TimerText.Clone();
							break;
						case PropertyTypeOneofCase.ClockText:
							ClockText = other.ClockText.Clone();
							break;
						case PropertyTypeOneofCase.ChordChart:
							ChordChart = other.ChordChart.Clone();
							break;
						case PropertyTypeOneofCase.OutputScreen:
							OutputScreen = other.OutputScreen.Clone();
							break;
						case PropertyTypeOneofCase.PcoLive:
							PcoLive = other.PcoLive.Clone();
							break;
						case PropertyTypeOneofCase.AlternateFill:
							AlternateFill = other.AlternateFill.Clone();
							break;
						case PropertyTypeOneofCase.VisibilityLink:
							VisibilityLink = other.VisibilityLink.Clone();
							break;
						case PropertyTypeOneofCase.SlideText:
							SlideText = other.SlideText.Clone();
							break;
						case PropertyTypeOneofCase.StageMessage:
							StageMessage = other.StageMessage.Clone();
							break;
						case PropertyTypeOneofCase.VideoCountdown:
							VideoCountdown = other.VideoCountdown.Clone();
							break;
						case PropertyTypeOneofCase.SlideImage:
							SlideImage = other.SlideImage.Clone();
							break;
						case PropertyTypeOneofCase.CcliText:
							CcliText = other.CcliText.Clone();
							break;
						case PropertyTypeOneofCase.GroupName:
							GroupName = other.GroupName.Clone();
							break;
						case PropertyTypeOneofCase.GroupColor:
							GroupColor = other.GroupColor.Clone();
							break;
						case PropertyTypeOneofCase.PresentationNotes:
							PresentationNotes = other.PresentationNotes.Clone();
							break;
						case PropertyTypeOneofCase.PlaylistItem:
							PlaylistItem = other.PlaylistItem.Clone();
							break;
						case PropertyTypeOneofCase.AutoAdvanceTimeRemaining:
							AutoAdvanceTimeRemaining = other.AutoAdvanceTimeRemaining.Clone();
							break;
						case PropertyTypeOneofCase.CaptureStatusText:
							CaptureStatusText = other.CaptureStatusText.Clone();
							break;
						case PropertyTypeOneofCase.CaptureStatusColor:
							CaptureStatusColor = other.CaptureStatusColor.Clone();
							break;
						case PropertyTypeOneofCase.SlideCount:
							SlideCount = other.SlideCount.Clone();
							break;
						case PropertyTypeOneofCase.AudioCountdown:
							AudioCountdown = other.AudioCountdown.Clone();
							break;
						case PropertyTypeOneofCase.Presentation:
							Presentation = other.Presentation.Clone();
							break;
						case PropertyTypeOneofCase.SlideLabelText:
							SlideLabelText = other.SlideLabelText.Clone();
							break;
						case PropertyTypeOneofCase.SlideLabelColor:
							SlideLabelColor = other.SlideLabelColor.Clone();
							break;
						case PropertyTypeOneofCase.RssFeed:
							RssFeed = other.RssFeed.Clone();
							break;
						case PropertyTypeOneofCase.FileFeed:
							FileFeed = other.FileFeed.Clone();
							break;
						case PropertyTypeOneofCase.ChordProChart:
							ChordProChart = other.ChordProChart.Clone();
							break;
						case PropertyTypeOneofCase.PlaybackMarkerText:
							PlaybackMarkerText = other.PlaybackMarkerText.Clone();
							break;
						case PropertyTypeOneofCase.PlaybackMarkerColor:
							PlaybackMarkerColor = other.PlaybackMarkerColor.Clone();
							break;
						case PropertyTypeOneofCase.TimecodeText:
							TimecodeText = other.TimecodeText.Clone();
							break;
						case PropertyTypeOneofCase.TimecodeStatus:
							TimecodeStatus = other.TimecodeStatus.Clone();
							break;
						case PropertyTypeOneofCase.MessageText:
							MessageText = other.MessageText.Clone();
							break;
						case PropertyTypeOneofCase.KeyValueText:
							KeyValueText = other.KeyValueText.Clone();
							break;
						case PropertyTypeOneofCase.KeyValueFill:
							KeyValueFill = other.KeyValueFill.Clone();
							break;
						case PropertyTypeOneofCase.Zone:
							Zone = other.Zone.Clone();
							break;
						}
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public DataLink Clone()
					{
						return new DataLink(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void ClearPropertyType()
					{
						propertyTypeCase_ = PropertyTypeOneofCase.None;
						propertyType_ = null;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as DataLink);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(DataLink other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (!object.Equals(Ticker, other.Ticker))
						{
							return false;
						}
						if (!object.Equals(AlternateText, other.AlternateText))
						{
							return false;
						}
						if (!object.Equals(TimerText, other.TimerText))
						{
							return false;
						}
						if (!object.Equals(ClockText, other.ClockText))
						{
							return false;
						}
						if (!object.Equals(ChordChart, other.ChordChart))
						{
							return false;
						}
						if (!object.Equals(OutputScreen, other.OutputScreen))
						{
							return false;
						}
						if (!object.Equals(PcoLive, other.PcoLive))
						{
							return false;
						}
						if (!object.Equals(AlternateFill, other.AlternateFill))
						{
							return false;
						}
						if (!object.Equals(VisibilityLink, other.VisibilityLink))
						{
							return false;
						}
						if (!object.Equals(SlideText, other.SlideText))
						{
							return false;
						}
						if (!object.Equals(StageMessage, other.StageMessage))
						{
							return false;
						}
						if (!object.Equals(VideoCountdown, other.VideoCountdown))
						{
							return false;
						}
						if (!object.Equals(SlideImage, other.SlideImage))
						{
							return false;
						}
						if (!object.Equals(CcliText, other.CcliText))
						{
							return false;
						}
						if (!object.Equals(GroupName, other.GroupName))
						{
							return false;
						}
						if (!object.Equals(GroupColor, other.GroupColor))
						{
							return false;
						}
						if (!object.Equals(PresentationNotes, other.PresentationNotes))
						{
							return false;
						}
						if (!object.Equals(PlaylistItem, other.PlaylistItem))
						{
							return false;
						}
						if (!object.Equals(AutoAdvanceTimeRemaining, other.AutoAdvanceTimeRemaining))
						{
							return false;
						}
						if (!object.Equals(CaptureStatusText, other.CaptureStatusText))
						{
							return false;
						}
						if (!object.Equals(CaptureStatusColor, other.CaptureStatusColor))
						{
							return false;
						}
						if (!object.Equals(SlideCount, other.SlideCount))
						{
							return false;
						}
						if (!object.Equals(AudioCountdown, other.AudioCountdown))
						{
							return false;
						}
						if (!object.Equals(Presentation, other.Presentation))
						{
							return false;
						}
						if (!object.Equals(SlideLabelText, other.SlideLabelText))
						{
							return false;
						}
						if (!object.Equals(SlideLabelColor, other.SlideLabelColor))
						{
							return false;
						}
						if (!object.Equals(RssFeed, other.RssFeed))
						{
							return false;
						}
						if (!object.Equals(FileFeed, other.FileFeed))
						{
							return false;
						}
						if (!object.Equals(ChordProChart, other.ChordProChart))
						{
							return false;
						}
						if (!object.Equals(PlaybackMarkerText, other.PlaybackMarkerText))
						{
							return false;
						}
						if (!object.Equals(PlaybackMarkerColor, other.PlaybackMarkerColor))
						{
							return false;
						}
						if (!object.Equals(TimecodeText, other.TimecodeText))
						{
							return false;
						}
						if (!object.Equals(TimecodeStatus, other.TimecodeStatus))
						{
							return false;
						}
						if (!object.Equals(MessageText, other.MessageText))
						{
							return false;
						}
						if (!object.Equals(KeyValueText, other.KeyValueText))
						{
							return false;
						}
						if (!object.Equals(KeyValueFill, other.KeyValueFill))
						{
							return false;
						}
						if (!object.Equals(Zone, other.Zone))
						{
							return false;
						}
						if (PropertyTypeCase != other.PropertyTypeCase)
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
						if (propertyTypeCase_ == PropertyTypeOneofCase.Ticker)
						{
							num ^= Ticker.GetHashCode();
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.AlternateText)
						{
							num ^= AlternateText.GetHashCode();
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.TimerText)
						{
							num ^= TimerText.GetHashCode();
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.ClockText)
						{
							num ^= ClockText.GetHashCode();
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.ChordChart)
						{
							num ^= ChordChart.GetHashCode();
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.OutputScreen)
						{
							num ^= OutputScreen.GetHashCode();
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.PcoLive)
						{
							num ^= PcoLive.GetHashCode();
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.AlternateFill)
						{
							num ^= AlternateFill.GetHashCode();
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.VisibilityLink)
						{
							num ^= VisibilityLink.GetHashCode();
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.SlideText)
						{
							num ^= SlideText.GetHashCode();
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.StageMessage)
						{
							num ^= StageMessage.GetHashCode();
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.VideoCountdown)
						{
							num ^= VideoCountdown.GetHashCode();
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.SlideImage)
						{
							num ^= SlideImage.GetHashCode();
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.CcliText)
						{
							num ^= CcliText.GetHashCode();
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.GroupName)
						{
							num ^= GroupName.GetHashCode();
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.GroupColor)
						{
							num ^= GroupColor.GetHashCode();
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.PresentationNotes)
						{
							num ^= PresentationNotes.GetHashCode();
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.PlaylistItem)
						{
							num ^= PlaylistItem.GetHashCode();
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.AutoAdvanceTimeRemaining)
						{
							num ^= AutoAdvanceTimeRemaining.GetHashCode();
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.CaptureStatusText)
						{
							num ^= CaptureStatusText.GetHashCode();
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.CaptureStatusColor)
						{
							num ^= CaptureStatusColor.GetHashCode();
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.SlideCount)
						{
							num ^= SlideCount.GetHashCode();
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.AudioCountdown)
						{
							num ^= AudioCountdown.GetHashCode();
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.Presentation)
						{
							num ^= Presentation.GetHashCode();
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.SlideLabelText)
						{
							num ^= SlideLabelText.GetHashCode();
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.SlideLabelColor)
						{
							num ^= SlideLabelColor.GetHashCode();
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.RssFeed)
						{
							num ^= RssFeed.GetHashCode();
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.FileFeed)
						{
							num ^= FileFeed.GetHashCode();
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.ChordProChart)
						{
							num ^= ChordProChart.GetHashCode();
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.PlaybackMarkerText)
						{
							num ^= PlaybackMarkerText.GetHashCode();
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.PlaybackMarkerColor)
						{
							num ^= PlaybackMarkerColor.GetHashCode();
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.TimecodeText)
						{
							num ^= TimecodeText.GetHashCode();
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.TimecodeStatus)
						{
							num ^= TimecodeStatus.GetHashCode();
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.MessageText)
						{
							num ^= MessageText.GetHashCode();
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.KeyValueText)
						{
							num ^= KeyValueText.GetHashCode();
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.KeyValueFill)
						{
							num ^= KeyValueFill.GetHashCode();
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.Zone)
						{
							num ^= Zone.GetHashCode();
						}
						num ^= (int)propertyTypeCase_;
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
						if (propertyTypeCase_ == PropertyTypeOneofCase.Ticker)
						{
							output.WriteRawTag(10);
							output.WriteMessage(Ticker);
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.AlternateText)
						{
							output.WriteRawTag(18);
							output.WriteMessage(AlternateText);
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.TimerText)
						{
							output.WriteRawTag(26);
							output.WriteMessage(TimerText);
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.ClockText)
						{
							output.WriteRawTag(34);
							output.WriteMessage(ClockText);
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.ChordChart)
						{
							output.WriteRawTag(42);
							output.WriteMessage(ChordChart);
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.OutputScreen)
						{
							output.WriteRawTag(50);
							output.WriteMessage(OutputScreen);
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.PcoLive)
						{
							output.WriteRawTag(58);
							output.WriteMessage(PcoLive);
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.AlternateFill)
						{
							output.WriteRawTag(66);
							output.WriteMessage(AlternateFill);
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.VisibilityLink)
						{
							output.WriteRawTag(74);
							output.WriteMessage(VisibilityLink);
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.SlideText)
						{
							output.WriteRawTag(82);
							output.WriteMessage(SlideText);
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.StageMessage)
						{
							output.WriteRawTag(90);
							output.WriteMessage(StageMessage);
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.VideoCountdown)
						{
							output.WriteRawTag(98);
							output.WriteMessage(VideoCountdown);
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.SlideImage)
						{
							output.WriteRawTag(106);
							output.WriteMessage(SlideImage);
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.CcliText)
						{
							output.WriteRawTag(114);
							output.WriteMessage(CcliText);
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.GroupName)
						{
							output.WriteRawTag(122);
							output.WriteMessage(GroupName);
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.GroupColor)
						{
							output.WriteRawTag(130, 1);
							output.WriteMessage(GroupColor);
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.PresentationNotes)
						{
							output.WriteRawTag(138, 1);
							output.WriteMessage(PresentationNotes);
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.PlaylistItem)
						{
							output.WriteRawTag(146, 1);
							output.WriteMessage(PlaylistItem);
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.AutoAdvanceTimeRemaining)
						{
							output.WriteRawTag(154, 1);
							output.WriteMessage(AutoAdvanceTimeRemaining);
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.CaptureStatusText)
						{
							output.WriteRawTag(162, 1);
							output.WriteMessage(CaptureStatusText);
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.CaptureStatusColor)
						{
							output.WriteRawTag(170, 1);
							output.WriteMessage(CaptureStatusColor);
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.SlideCount)
						{
							output.WriteRawTag(178, 1);
							output.WriteMessage(SlideCount);
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.AudioCountdown)
						{
							output.WriteRawTag(186, 1);
							output.WriteMessage(AudioCountdown);
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.Presentation)
						{
							output.WriteRawTag(194, 1);
							output.WriteMessage(Presentation);
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.SlideLabelText)
						{
							output.WriteRawTag(202, 1);
							output.WriteMessage(SlideLabelText);
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.SlideLabelColor)
						{
							output.WriteRawTag(210, 1);
							output.WriteMessage(SlideLabelColor);
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.RssFeed)
						{
							output.WriteRawTag(218, 1);
							output.WriteMessage(RssFeed);
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.FileFeed)
						{
							output.WriteRawTag(226, 1);
							output.WriteMessage(FileFeed);
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.ChordProChart)
						{
							output.WriteRawTag(234, 1);
							output.WriteMessage(ChordProChart);
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.PlaybackMarkerText)
						{
							output.WriteRawTag(242, 1);
							output.WriteMessage(PlaybackMarkerText);
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.PlaybackMarkerColor)
						{
							output.WriteRawTag(130, 2);
							output.WriteMessage(PlaybackMarkerColor);
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.TimecodeText)
						{
							output.WriteRawTag(138, 2);
							output.WriteMessage(TimecodeText);
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.TimecodeStatus)
						{
							output.WriteRawTag(146, 2);
							output.WriteMessage(TimecodeStatus);
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.MessageText)
						{
							output.WriteRawTag(154, 2);
							output.WriteMessage(MessageText);
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.KeyValueText)
						{
							output.WriteRawTag(162, 2);
							output.WriteMessage(KeyValueText);
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.KeyValueFill)
						{
							output.WriteRawTag(170, 2);
							output.WriteMessage(KeyValueFill);
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.Zone)
						{
							output.WriteRawTag(178, 2);
							output.WriteMessage(Zone);
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
						if (propertyTypeCase_ == PropertyTypeOneofCase.Ticker)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(Ticker);
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.AlternateText)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(AlternateText);
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.TimerText)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(TimerText);
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.ClockText)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(ClockText);
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.ChordChart)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(ChordChart);
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.OutputScreen)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(OutputScreen);
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.PcoLive)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(PcoLive);
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.AlternateFill)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(AlternateFill);
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.VisibilityLink)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(VisibilityLink);
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.SlideText)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(SlideText);
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.StageMessage)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(StageMessage);
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.VideoCountdown)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(VideoCountdown);
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.SlideImage)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(SlideImage);
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.CcliText)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(CcliText);
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.GroupName)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(GroupName);
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.GroupColor)
						{
							num += 2 + CodedOutputStream.ComputeMessageSize(GroupColor);
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.PresentationNotes)
						{
							num += 2 + CodedOutputStream.ComputeMessageSize(PresentationNotes);
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.PlaylistItem)
						{
							num += 2 + CodedOutputStream.ComputeMessageSize(PlaylistItem);
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.AutoAdvanceTimeRemaining)
						{
							num += 2 + CodedOutputStream.ComputeMessageSize(AutoAdvanceTimeRemaining);
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.CaptureStatusText)
						{
							num += 2 + CodedOutputStream.ComputeMessageSize(CaptureStatusText);
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.CaptureStatusColor)
						{
							num += 2 + CodedOutputStream.ComputeMessageSize(CaptureStatusColor);
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.SlideCount)
						{
							num += 2 + CodedOutputStream.ComputeMessageSize(SlideCount);
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.AudioCountdown)
						{
							num += 2 + CodedOutputStream.ComputeMessageSize(AudioCountdown);
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.Presentation)
						{
							num += 2 + CodedOutputStream.ComputeMessageSize(Presentation);
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.SlideLabelText)
						{
							num += 2 + CodedOutputStream.ComputeMessageSize(SlideLabelText);
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.SlideLabelColor)
						{
							num += 2 + CodedOutputStream.ComputeMessageSize(SlideLabelColor);
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.RssFeed)
						{
							num += 2 + CodedOutputStream.ComputeMessageSize(RssFeed);
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.FileFeed)
						{
							num += 2 + CodedOutputStream.ComputeMessageSize(FileFeed);
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.ChordProChart)
						{
							num += 2 + CodedOutputStream.ComputeMessageSize(ChordProChart);
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.PlaybackMarkerText)
						{
							num += 2 + CodedOutputStream.ComputeMessageSize(PlaybackMarkerText);
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.PlaybackMarkerColor)
						{
							num += 2 + CodedOutputStream.ComputeMessageSize(PlaybackMarkerColor);
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.TimecodeText)
						{
							num += 2 + CodedOutputStream.ComputeMessageSize(TimecodeText);
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.TimecodeStatus)
						{
							num += 2 + CodedOutputStream.ComputeMessageSize(TimecodeStatus);
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.MessageText)
						{
							num += 2 + CodedOutputStream.ComputeMessageSize(MessageText);
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.KeyValueText)
						{
							num += 2 + CodedOutputStream.ComputeMessageSize(KeyValueText);
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.KeyValueFill)
						{
							num += 2 + CodedOutputStream.ComputeMessageSize(KeyValueFill);
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.Zone)
						{
							num += 2 + CodedOutputStream.ComputeMessageSize(Zone);
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(DataLink other)
					{
						if (other == null)
						{
							return;
						}
						switch (other.PropertyTypeCase)
						{
						case PropertyTypeOneofCase.Ticker:
							if (Ticker == null)
							{
								Ticker = new Types.Ticker();
							}
							Ticker.MergeFrom(other.Ticker);
							break;
						case PropertyTypeOneofCase.AlternateText:
							if (AlternateText == null)
							{
								AlternateText = new Types.AlternateElementText();
							}
							AlternateText.MergeFrom(other.AlternateText);
							break;
						case PropertyTypeOneofCase.TimerText:
							if (TimerText == null)
							{
								TimerText = new Types.TimerText();
							}
							TimerText.MergeFrom(other.TimerText);
							break;
						case PropertyTypeOneofCase.ClockText:
							if (ClockText == null)
							{
								ClockText = new Types.ClockText();
							}
							ClockText.MergeFrom(other.ClockText);
							break;
						case PropertyTypeOneofCase.ChordChart:
							if (ChordChart == null)
							{
								ChordChart = new Types.ChordChart();
							}
							ChordChart.MergeFrom(other.ChordChart);
							break;
						case PropertyTypeOneofCase.OutputScreen:
							if (OutputScreen == null)
							{
								OutputScreen = new Types.OutputScreen();
							}
							OutputScreen.MergeFrom(other.OutputScreen);
							break;
						case PropertyTypeOneofCase.PcoLive:
							if (PcoLive == null)
							{
								PcoLive = new Types.PCOLive();
							}
							PcoLive.MergeFrom(other.PcoLive);
							break;
						case PropertyTypeOneofCase.AlternateFill:
							if (AlternateFill == null)
							{
								AlternateFill = new Types.AlternateElementFill();
							}
							AlternateFill.MergeFrom(other.AlternateFill);
							break;
						case PropertyTypeOneofCase.VisibilityLink:
							if (VisibilityLink == null)
							{
								VisibilityLink = new Types.VisibilityLink();
							}
							VisibilityLink.MergeFrom(other.VisibilityLink);
							break;
						case PropertyTypeOneofCase.SlideText:
							if (SlideText == null)
							{
								SlideText = new Types.SlideText();
							}
							SlideText.MergeFrom(other.SlideText);
							break;
						case PropertyTypeOneofCase.StageMessage:
							if (StageMessage == null)
							{
								StageMessage = new Types.StageMessage();
							}
							StageMessage.MergeFrom(other.StageMessage);
							break;
						case PropertyTypeOneofCase.VideoCountdown:
							if (VideoCountdown == null)
							{
								VideoCountdown = new Types.VideoCountdown();
							}
							VideoCountdown.MergeFrom(other.VideoCountdown);
							break;
						case PropertyTypeOneofCase.SlideImage:
							if (SlideImage == null)
							{
								SlideImage = new Types.SlideImage();
							}
							SlideImage.MergeFrom(other.SlideImage);
							break;
						case PropertyTypeOneofCase.CcliText:
							if (CcliText == null)
							{
								CcliText = new Types.CCLIText();
							}
							CcliText.MergeFrom(other.CcliText);
							break;
						case PropertyTypeOneofCase.GroupName:
							if (GroupName == null)
							{
								GroupName = new Types.GroupName();
							}
							GroupName.MergeFrom(other.GroupName);
							break;
						case PropertyTypeOneofCase.GroupColor:
							if (GroupColor == null)
							{
								GroupColor = new Types.GroupColor();
							}
							GroupColor.MergeFrom(other.GroupColor);
							break;
						case PropertyTypeOneofCase.PresentationNotes:
							if (PresentationNotes == null)
							{
								PresentationNotes = new Types.PresentationNotes();
							}
							PresentationNotes.MergeFrom(other.PresentationNotes);
							break;
						case PropertyTypeOneofCase.PlaylistItem:
							if (PlaylistItem == null)
							{
								PlaylistItem = new Types.PlaylistItem();
							}
							PlaylistItem.MergeFrom(other.PlaylistItem);
							break;
						case PropertyTypeOneofCase.AutoAdvanceTimeRemaining:
							if (AutoAdvanceTimeRemaining == null)
							{
								AutoAdvanceTimeRemaining = new Types.AutoAdvanceTimeRemaining();
							}
							AutoAdvanceTimeRemaining.MergeFrom(other.AutoAdvanceTimeRemaining);
							break;
						case PropertyTypeOneofCase.CaptureStatusText:
							if (CaptureStatusText == null)
							{
								CaptureStatusText = new Types.CaptureStatusText();
							}
							CaptureStatusText.MergeFrom(other.CaptureStatusText);
							break;
						case PropertyTypeOneofCase.CaptureStatusColor:
							if (CaptureStatusColor == null)
							{
								CaptureStatusColor = new Types.CaptureStatusColor();
							}
							CaptureStatusColor.MergeFrom(other.CaptureStatusColor);
							break;
						case PropertyTypeOneofCase.SlideCount:
							if (SlideCount == null)
							{
								SlideCount = new Types.SlideCount();
							}
							SlideCount.MergeFrom(other.SlideCount);
							break;
						case PropertyTypeOneofCase.AudioCountdown:
							if (AudioCountdown == null)
							{
								AudioCountdown = new Types.AudioCountdown();
							}
							AudioCountdown.MergeFrom(other.AudioCountdown);
							break;
						case PropertyTypeOneofCase.Presentation:
							if (Presentation == null)
							{
								Presentation = new Types.Presentation();
							}
							Presentation.MergeFrom(other.Presentation);
							break;
						case PropertyTypeOneofCase.SlideLabelText:
							if (SlideLabelText == null)
							{
								SlideLabelText = new Types.SlideLabelText();
							}
							SlideLabelText.MergeFrom(other.SlideLabelText);
							break;
						case PropertyTypeOneofCase.SlideLabelColor:
							if (SlideLabelColor == null)
							{
								SlideLabelColor = new Types.SlideLabelColor();
							}
							SlideLabelColor.MergeFrom(other.SlideLabelColor);
							break;
						case PropertyTypeOneofCase.RssFeed:
							if (RssFeed == null)
							{
								RssFeed = new Types.RSSFeed();
							}
							RssFeed.MergeFrom(other.RssFeed);
							break;
						case PropertyTypeOneofCase.FileFeed:
							if (FileFeed == null)
							{
								FileFeed = new Types.FileFeed();
							}
							FileFeed.MergeFrom(other.FileFeed);
							break;
						case PropertyTypeOneofCase.ChordProChart:
							if (ChordProChart == null)
							{
								ChordProChart = new Types.ChordProChart();
							}
							ChordProChart.MergeFrom(other.ChordProChart);
							break;
						case PropertyTypeOneofCase.PlaybackMarkerText:
							if (PlaybackMarkerText == null)
							{
								PlaybackMarkerText = new Types.PlaybackMarkerText();
							}
							PlaybackMarkerText.MergeFrom(other.PlaybackMarkerText);
							break;
						case PropertyTypeOneofCase.PlaybackMarkerColor:
							if (PlaybackMarkerColor == null)
							{
								PlaybackMarkerColor = new Types.PlaybackMarkerIdentifier();
							}
							PlaybackMarkerColor.MergeFrom(other.PlaybackMarkerColor);
							break;
						case PropertyTypeOneofCase.TimecodeText:
							if (TimecodeText == null)
							{
								TimecodeText = new Types.TimecodeText();
							}
							TimecodeText.MergeFrom(other.TimecodeText);
							break;
						case PropertyTypeOneofCase.TimecodeStatus:
							if (TimecodeStatus == null)
							{
								TimecodeStatus = new Types.TimecodeStatus();
							}
							TimecodeStatus.MergeFrom(other.TimecodeStatus);
							break;
						case PropertyTypeOneofCase.MessageText:
							if (MessageText == null)
							{
								MessageText = new Message();
							}
							MessageText.MergeFrom(other.MessageText);
							break;
						case PropertyTypeOneofCase.KeyValueText:
							if (KeyValueText == null)
							{
								KeyValueText = new Types.KeyValueText();
							}
							KeyValueText.MergeFrom(other.KeyValueText);
							break;
						case PropertyTypeOneofCase.KeyValueFill:
							if (KeyValueFill == null)
							{
								KeyValueFill = new Types.KeyValueFill();
							}
							KeyValueFill.MergeFrom(other.KeyValueFill);
							break;
						case PropertyTypeOneofCase.Zone:
							if (Zone == null)
							{
								Zone = new Types.Zone();
							}
							Zone.MergeFrom(other.Zone);
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
								Types.Ticker ticker = new Types.Ticker();
								if (propertyTypeCase_ == PropertyTypeOneofCase.Ticker)
								{
									ticker.MergeFrom(Ticker);
								}
								input.ReadMessage(ticker);
								Ticker = ticker;
								break;
							}
							case 18u:
							{
								Types.AlternateElementText alternateElementText = new Types.AlternateElementText();
								if (propertyTypeCase_ == PropertyTypeOneofCase.AlternateText)
								{
									alternateElementText.MergeFrom(AlternateText);
								}
								input.ReadMessage(alternateElementText);
								AlternateText = alternateElementText;
								break;
							}
							case 26u:
							{
								Types.TimerText timerText = new Types.TimerText();
								if (propertyTypeCase_ == PropertyTypeOneofCase.TimerText)
								{
									timerText.MergeFrom(TimerText);
								}
								input.ReadMessage(timerText);
								TimerText = timerText;
								break;
							}
							case 34u:
							{
								Types.ClockText clockText = new Types.ClockText();
								if (propertyTypeCase_ == PropertyTypeOneofCase.ClockText)
								{
									clockText.MergeFrom(ClockText);
								}
								input.ReadMessage(clockText);
								ClockText = clockText;
								break;
							}
							case 42u:
							{
								Types.ChordChart chordChart = new Types.ChordChart();
								if (propertyTypeCase_ == PropertyTypeOneofCase.ChordChart)
								{
									chordChart.MergeFrom(ChordChart);
								}
								input.ReadMessage(chordChart);
								ChordChart = chordChart;
								break;
							}
							case 50u:
							{
								Types.OutputScreen outputScreen = new Types.OutputScreen();
								if (propertyTypeCase_ == PropertyTypeOneofCase.OutputScreen)
								{
									outputScreen.MergeFrom(OutputScreen);
								}
								input.ReadMessage(outputScreen);
								OutputScreen = outputScreen;
								break;
							}
							case 58u:
							{
								Types.PCOLive pCOLive = new Types.PCOLive();
								if (propertyTypeCase_ == PropertyTypeOneofCase.PcoLive)
								{
									pCOLive.MergeFrom(PcoLive);
								}
								input.ReadMessage(pCOLive);
								PcoLive = pCOLive;
								break;
							}
							case 66u:
							{
								Types.AlternateElementFill alternateElementFill = new Types.AlternateElementFill();
								if (propertyTypeCase_ == PropertyTypeOneofCase.AlternateFill)
								{
									alternateElementFill.MergeFrom(AlternateFill);
								}
								input.ReadMessage(alternateElementFill);
								AlternateFill = alternateElementFill;
								break;
							}
							case 74u:
							{
								Types.VisibilityLink visibilityLink = new Types.VisibilityLink();
								if (propertyTypeCase_ == PropertyTypeOneofCase.VisibilityLink)
								{
									visibilityLink.MergeFrom(VisibilityLink);
								}
								input.ReadMessage(visibilityLink);
								VisibilityLink = visibilityLink;
								break;
							}
							case 82u:
							{
								Types.SlideText slideText = new Types.SlideText();
								if (propertyTypeCase_ == PropertyTypeOneofCase.SlideText)
								{
									slideText.MergeFrom(SlideText);
								}
								input.ReadMessage(slideText);
								SlideText = slideText;
								break;
							}
							case 90u:
							{
								Types.StageMessage stageMessage = new Types.StageMessage();
								if (propertyTypeCase_ == PropertyTypeOneofCase.StageMessage)
								{
									stageMessage.MergeFrom(StageMessage);
								}
								input.ReadMessage(stageMessage);
								StageMessage = stageMessage;
								break;
							}
							case 98u:
							{
								Types.VideoCountdown videoCountdown = new Types.VideoCountdown();
								if (propertyTypeCase_ == PropertyTypeOneofCase.VideoCountdown)
								{
									videoCountdown.MergeFrom(VideoCountdown);
								}
								input.ReadMessage(videoCountdown);
								VideoCountdown = videoCountdown;
								break;
							}
							case 106u:
							{
								Types.SlideImage slideImage = new Types.SlideImage();
								if (propertyTypeCase_ == PropertyTypeOneofCase.SlideImage)
								{
									slideImage.MergeFrom(SlideImage);
								}
								input.ReadMessage(slideImage);
								SlideImage = slideImage;
								break;
							}
							case 114u:
							{
								Types.CCLIText cCLIText = new Types.CCLIText();
								if (propertyTypeCase_ == PropertyTypeOneofCase.CcliText)
								{
									cCLIText.MergeFrom(CcliText);
								}
								input.ReadMessage(cCLIText);
								CcliText = cCLIText;
								break;
							}
							case 122u:
							{
								Types.GroupName groupName = new Types.GroupName();
								if (propertyTypeCase_ == PropertyTypeOneofCase.GroupName)
								{
									groupName.MergeFrom(GroupName);
								}
								input.ReadMessage(groupName);
								GroupName = groupName;
								break;
							}
							case 130u:
							{
								Types.GroupColor groupColor = new Types.GroupColor();
								if (propertyTypeCase_ == PropertyTypeOneofCase.GroupColor)
								{
									groupColor.MergeFrom(GroupColor);
								}
								input.ReadMessage(groupColor);
								GroupColor = groupColor;
								break;
							}
							case 138u:
							{
								Types.PresentationNotes presentationNotes = new Types.PresentationNotes();
								if (propertyTypeCase_ == PropertyTypeOneofCase.PresentationNotes)
								{
									presentationNotes.MergeFrom(PresentationNotes);
								}
								input.ReadMessage(presentationNotes);
								PresentationNotes = presentationNotes;
								break;
							}
							case 146u:
							{
								Types.PlaylistItem playlistItem = new Types.PlaylistItem();
								if (propertyTypeCase_ == PropertyTypeOneofCase.PlaylistItem)
								{
									playlistItem.MergeFrom(PlaylistItem);
								}
								input.ReadMessage(playlistItem);
								PlaylistItem = playlistItem;
								break;
							}
							case 154u:
							{
								Types.AutoAdvanceTimeRemaining autoAdvanceTimeRemaining = new Types.AutoAdvanceTimeRemaining();
								if (propertyTypeCase_ == PropertyTypeOneofCase.AutoAdvanceTimeRemaining)
								{
									autoAdvanceTimeRemaining.MergeFrom(AutoAdvanceTimeRemaining);
								}
								input.ReadMessage(autoAdvanceTimeRemaining);
								AutoAdvanceTimeRemaining = autoAdvanceTimeRemaining;
								break;
							}
							case 162u:
							{
								Types.CaptureStatusText captureStatusText = new Types.CaptureStatusText();
								if (propertyTypeCase_ == PropertyTypeOneofCase.CaptureStatusText)
								{
									captureStatusText.MergeFrom(CaptureStatusText);
								}
								input.ReadMessage(captureStatusText);
								CaptureStatusText = captureStatusText;
								break;
							}
							case 170u:
							{
								Types.CaptureStatusColor captureStatusColor = new Types.CaptureStatusColor();
								if (propertyTypeCase_ == PropertyTypeOneofCase.CaptureStatusColor)
								{
									captureStatusColor.MergeFrom(CaptureStatusColor);
								}
								input.ReadMessage(captureStatusColor);
								CaptureStatusColor = captureStatusColor;
								break;
							}
							case 178u:
							{
								Types.SlideCount slideCount = new Types.SlideCount();
								if (propertyTypeCase_ == PropertyTypeOneofCase.SlideCount)
								{
									slideCount.MergeFrom(SlideCount);
								}
								input.ReadMessage(slideCount);
								SlideCount = slideCount;
								break;
							}
							case 186u:
							{
								Types.AudioCountdown audioCountdown = new Types.AudioCountdown();
								if (propertyTypeCase_ == PropertyTypeOneofCase.AudioCountdown)
								{
									audioCountdown.MergeFrom(AudioCountdown);
								}
								input.ReadMessage(audioCountdown);
								AudioCountdown = audioCountdown;
								break;
							}
							case 194u:
							{
								Types.Presentation presentation = new Types.Presentation();
								if (propertyTypeCase_ == PropertyTypeOneofCase.Presentation)
								{
									presentation.MergeFrom(Presentation);
								}
								input.ReadMessage(presentation);
								Presentation = presentation;
								break;
							}
							case 202u:
							{
								Types.SlideLabelText slideLabelText = new Types.SlideLabelText();
								if (propertyTypeCase_ == PropertyTypeOneofCase.SlideLabelText)
								{
									slideLabelText.MergeFrom(SlideLabelText);
								}
								input.ReadMessage(slideLabelText);
								SlideLabelText = slideLabelText;
								break;
							}
							case 210u:
							{
								Types.SlideLabelColor slideLabelColor = new Types.SlideLabelColor();
								if (propertyTypeCase_ == PropertyTypeOneofCase.SlideLabelColor)
								{
									slideLabelColor.MergeFrom(SlideLabelColor);
								}
								input.ReadMessage(slideLabelColor);
								SlideLabelColor = slideLabelColor;
								break;
							}
							case 218u:
							{
								Types.RSSFeed rSSFeed = new Types.RSSFeed();
								if (propertyTypeCase_ == PropertyTypeOneofCase.RssFeed)
								{
									rSSFeed.MergeFrom(RssFeed);
								}
								input.ReadMessage(rSSFeed);
								RssFeed = rSSFeed;
								break;
							}
							case 226u:
							{
								Types.FileFeed fileFeed = new Types.FileFeed();
								if (propertyTypeCase_ == PropertyTypeOneofCase.FileFeed)
								{
									fileFeed.MergeFrom(FileFeed);
								}
								input.ReadMessage(fileFeed);
								FileFeed = fileFeed;
								break;
							}
							case 234u:
							{
								Types.ChordProChart chordProChart = new Types.ChordProChart();
								if (propertyTypeCase_ == PropertyTypeOneofCase.ChordProChart)
								{
									chordProChart.MergeFrom(ChordProChart);
								}
								input.ReadMessage(chordProChart);
								ChordProChart = chordProChart;
								break;
							}
							case 242u:
							{
								Types.PlaybackMarkerText playbackMarkerText = new Types.PlaybackMarkerText();
								if (propertyTypeCase_ == PropertyTypeOneofCase.PlaybackMarkerText)
								{
									playbackMarkerText.MergeFrom(PlaybackMarkerText);
								}
								input.ReadMessage(playbackMarkerText);
								PlaybackMarkerText = playbackMarkerText;
								break;
							}
							case 258u:
							{
								Types.PlaybackMarkerIdentifier playbackMarkerIdentifier = new Types.PlaybackMarkerIdentifier();
								if (propertyTypeCase_ == PropertyTypeOneofCase.PlaybackMarkerColor)
								{
									playbackMarkerIdentifier.MergeFrom(PlaybackMarkerColor);
								}
								input.ReadMessage(playbackMarkerIdentifier);
								PlaybackMarkerColor = playbackMarkerIdentifier;
								break;
							}
							case 266u:
							{
								Types.TimecodeText timecodeText = new Types.TimecodeText();
								if (propertyTypeCase_ == PropertyTypeOneofCase.TimecodeText)
								{
									timecodeText.MergeFrom(TimecodeText);
								}
								input.ReadMessage(timecodeText);
								TimecodeText = timecodeText;
								break;
							}
							case 274u:
							{
								Types.TimecodeStatus timecodeStatus = new Types.TimecodeStatus();
								if (propertyTypeCase_ == PropertyTypeOneofCase.TimecodeStatus)
								{
									timecodeStatus.MergeFrom(TimecodeStatus);
								}
								input.ReadMessage(timecodeStatus);
								TimecodeStatus = timecodeStatus;
								break;
							}
							case 282u:
							{
								Message message = new Message();
								if (propertyTypeCase_ == PropertyTypeOneofCase.MessageText)
								{
									message.MergeFrom(MessageText);
								}
								input.ReadMessage(message);
								MessageText = message;
								break;
							}
							case 290u:
							{
								Types.KeyValueText keyValueText = new Types.KeyValueText();
								if (propertyTypeCase_ == PropertyTypeOneofCase.KeyValueText)
								{
									keyValueText.MergeFrom(KeyValueText);
								}
								input.ReadMessage(keyValueText);
								KeyValueText = keyValueText;
								break;
							}
							case 298u:
							{
								Types.KeyValueFill keyValueFill = new Types.KeyValueFill();
								if (propertyTypeCase_ == PropertyTypeOneofCase.KeyValueFill)
								{
									keyValueFill.MergeFrom(KeyValueFill);
								}
								input.ReadMessage(keyValueFill);
								KeyValueFill = keyValueFill;
								break;
							}
							case 306u:
							{
								Types.Zone zone = new Types.Zone();
								if (propertyTypeCase_ == PropertyTypeOneofCase.Zone)
								{
									zone.MergeFrom(Zone);
								}
								input.ReadMessage(zone);
								Zone = zone;
								break;
							}
							}
						}
					}
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class TextScroller : IMessage<TextScroller>, IMessage, IEquatable<TextScroller>, IDeepCloneable<TextScroller>
				{
					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static class Types
					{
						public enum Direction
						{
							[OriginalName("DIRECTION_LEFT")]
							Left,
							[OriginalName("DIRECTION_RIGHT")]
							Right,
							[OriginalName("DIRECTION_UP")]
							Up,
							[OriginalName("DIRECTION_DOWN")]
							Down
						}
					}

					private static readonly MessageParser<TextScroller> _parser = new MessageParser<TextScroller>(() => new TextScroller());

					private UnknownFieldSet _unknownFields;

					public const int ShouldScrollFieldNumber = 1;

					private bool shouldScroll_;

					public const int ScrollRateFieldNumber = 2;

					private double scrollRate_;

					public const int ShouldRepeatFieldNumber = 3;

					private bool shouldRepeat_;

					public const int RepeatDistanceFieldNumber = 4;

					private double repeatDistance_;

					public const int ScrollingDirectionFieldNumber = 5;

					private Types.Direction scrollingDirection_;

					public const int StartsOffScreenFieldNumber = 6;

					private bool startsOffScreen_;

					public const int FadeLeftFieldNumber = 7;

					private double fadeLeft_;

					public const int FadeRightFieldNumber = 8;

					private double fadeRight_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<TextScroller> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => Element.Descriptor.NestedTypes[3];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool ShouldScroll
					{
						get
						{
							return shouldScroll_;
						}
						set
						{
							shouldScroll_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public double ScrollRate
					{
						get
						{
							return scrollRate_;
						}
						set
						{
							scrollRate_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool ShouldRepeat
					{
						get
						{
							return shouldRepeat_;
						}
						set
						{
							shouldRepeat_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public double RepeatDistance
					{
						get
						{
							return repeatDistance_;
						}
						set
						{
							repeatDistance_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Types.Direction ScrollingDirection
					{
						get
						{
							return scrollingDirection_;
						}
						set
						{
							scrollingDirection_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool StartsOffScreen
					{
						get
						{
							return startsOffScreen_;
						}
						set
						{
							startsOffScreen_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public double FadeLeft
					{
						get
						{
							return fadeLeft_;
						}
						set
						{
							fadeLeft_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public double FadeRight
					{
						get
						{
							return fadeRight_;
						}
						set
						{
							fadeRight_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public TextScroller()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public TextScroller(TextScroller other)
						: this()
					{
						shouldScroll_ = other.shouldScroll_;
						scrollRate_ = other.scrollRate_;
						shouldRepeat_ = other.shouldRepeat_;
						repeatDistance_ = other.repeatDistance_;
						scrollingDirection_ = other.scrollingDirection_;
						startsOffScreen_ = other.startsOffScreen_;
						fadeLeft_ = other.fadeLeft_;
						fadeRight_ = other.fadeRight_;
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public TextScroller Clone()
					{
						return new TextScroller(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as TextScroller);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(TextScroller other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (ShouldScroll != other.ShouldScroll)
						{
							return false;
						}
						if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(ScrollRate, other.ScrollRate))
						{
							return false;
						}
						if (ShouldRepeat != other.ShouldRepeat)
						{
							return false;
						}
						if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(RepeatDistance, other.RepeatDistance))
						{
							return false;
						}
						if (ScrollingDirection != other.ScrollingDirection)
						{
							return false;
						}
						if (StartsOffScreen != other.StartsOffScreen)
						{
							return false;
						}
						if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(FadeLeft, other.FadeLeft))
						{
							return false;
						}
						if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(FadeRight, other.FadeRight))
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
						if (ShouldScroll)
						{
							num ^= ShouldScroll.GetHashCode();
						}
						if (ScrollRate != 0.0)
						{
							num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(ScrollRate);
						}
						if (ShouldRepeat)
						{
							num ^= ShouldRepeat.GetHashCode();
						}
						if (RepeatDistance != 0.0)
						{
							num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(RepeatDistance);
						}
						if (ScrollingDirection != 0)
						{
							num ^= ScrollingDirection.GetHashCode();
						}
						if (StartsOffScreen)
						{
							num ^= StartsOffScreen.GetHashCode();
						}
						if (FadeLeft != 0.0)
						{
							num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(FadeLeft);
						}
						if (FadeRight != 0.0)
						{
							num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(FadeRight);
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
						if (ShouldScroll)
						{
							output.WriteRawTag(8);
							output.WriteBool(ShouldScroll);
						}
						if (ScrollRate != 0.0)
						{
							output.WriteRawTag(17);
							output.WriteDouble(ScrollRate);
						}
						if (ShouldRepeat)
						{
							output.WriteRawTag(24);
							output.WriteBool(ShouldRepeat);
						}
						if (RepeatDistance != 0.0)
						{
							output.WriteRawTag(33);
							output.WriteDouble(RepeatDistance);
						}
						if (ScrollingDirection != 0)
						{
							output.WriteRawTag(40);
							output.WriteEnum((int)ScrollingDirection);
						}
						if (StartsOffScreen)
						{
							output.WriteRawTag(48);
							output.WriteBool(StartsOffScreen);
						}
						if (FadeLeft != 0.0)
						{
							output.WriteRawTag(57);
							output.WriteDouble(FadeLeft);
						}
						if (FadeRight != 0.0)
						{
							output.WriteRawTag(65);
							output.WriteDouble(FadeRight);
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
						if (ShouldScroll)
						{
							num += 2;
						}
						if (ScrollRate != 0.0)
						{
							num += 9;
						}
						if (ShouldRepeat)
						{
							num += 2;
						}
						if (RepeatDistance != 0.0)
						{
							num += 9;
						}
						if (ScrollingDirection != 0)
						{
							num += 1 + CodedOutputStream.ComputeEnumSize((int)ScrollingDirection);
						}
						if (StartsOffScreen)
						{
							num += 2;
						}
						if (FadeLeft != 0.0)
						{
							num += 9;
						}
						if (FadeRight != 0.0)
						{
							num += 9;
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(TextScroller other)
					{
						if (other != null)
						{
							if (other.ShouldScroll)
							{
								ShouldScroll = other.ShouldScroll;
							}
							if (other.ScrollRate != 0.0)
							{
								ScrollRate = other.ScrollRate;
							}
							if (other.ShouldRepeat)
							{
								ShouldRepeat = other.ShouldRepeat;
							}
							if (other.RepeatDistance != 0.0)
							{
								RepeatDistance = other.RepeatDistance;
							}
							if (other.ScrollingDirection != 0)
							{
								ScrollingDirection = other.ScrollingDirection;
							}
							if (other.StartsOffScreen)
							{
								StartsOffScreen = other.StartsOffScreen;
							}
							if (other.FadeLeft != 0.0)
							{
								FadeLeft = other.FadeLeft;
							}
							if (other.FadeRight != 0.0)
							{
								FadeRight = other.FadeRight;
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
								ShouldScroll = input.ReadBool();
								break;
							case 17u:
								ScrollRate = input.ReadDouble();
								break;
							case 24u:
								ShouldRepeat = input.ReadBool();
								break;
							case 33u:
								RepeatDistance = input.ReadDouble();
								break;
							case 40u:
								ScrollingDirection = (Types.Direction)input.ReadEnum();
								break;
							case 48u:
								StartsOffScreen = input.ReadBool();
								break;
							case 57u:
								FadeLeft = input.ReadDouble();
								break;
							case 65u:
								FadeRight = input.ReadDouble();
								break;
							}
						}
					}
				}
			}

			private static readonly MessageParser<Element> _parser = new MessageParser<Element>(() => new Element());

			private UnknownFieldSet _unknownFields;

			public const int Element_FieldNumber = 1;

			private Graphics.Types.Element element_;

			public const int BuildInFieldNumber = 2;

			private Types.Build buildIn_;

			public const int BuildOutFieldNumber = 3;

			private Types.Build buildOut_;

			public const int InfoFieldNumber = 4;

			private uint info_;

			public const int RevealTypeFieldNumber = 5;

			private Types.TextRevealType revealType_;

			public const int DataLinksFieldNumber = 6;

			private static readonly FieldCodec<Types.DataLink> _repeated_dataLinks_codec = FieldCodec.ForMessage(50u, Types.DataLink.Parser);

			private readonly RepeatedField<Types.DataLink> dataLinks_ = new RepeatedField<Types.DataLink>();

			public const int ChildBuildsFieldNumber = 7;

			private static readonly FieldCodec<Types.ChildBuild> _repeated_childBuilds_codec = FieldCodec.ForMessage(58u, Types.ChildBuild.Parser);

			private readonly RepeatedField<Types.ChildBuild> childBuilds_ = new RepeatedField<Types.ChildBuild>();

			public const int RevealFromIndexFieldNumber = 8;

			private uint revealFromIndex_;

			public const int TextScrollerFieldNumber = 9;

			private Types.TextScroller textScroller_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Element> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Slide.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Graphics.Types.Element Element_
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
			public Types.Build BuildIn
			{
				get
				{
					return buildIn_;
				}
				set
				{
					buildIn_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.Build BuildOut
			{
				get
				{
					return buildOut_;
				}
				set
				{
					buildOut_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public uint Info
			{
				get
				{
					return info_;
				}
				set
				{
					info_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.TextRevealType RevealType
			{
				get
				{
					return revealType_;
				}
				set
				{
					revealType_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RepeatedField<Types.DataLink> DataLinks => dataLinks_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RepeatedField<Types.ChildBuild> ChildBuilds => childBuilds_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public uint RevealFromIndex
			{
				get
				{
					return revealFromIndex_;
				}
				set
				{
					revealFromIndex_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.TextScroller TextScroller
			{
				get
				{
					return textScroller_;
				}
				set
				{
					textScroller_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Element()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Element(Element other)
				: this()
			{
				element_ = ((other.element_ != null) ? other.element_.Clone() : null);
				buildIn_ = ((other.buildIn_ != null) ? other.buildIn_.Clone() : null);
				buildOut_ = ((other.buildOut_ != null) ? other.buildOut_.Clone() : null);
				info_ = other.info_;
				revealType_ = other.revealType_;
				dataLinks_ = other.dataLinks_.Clone();
				childBuilds_ = other.childBuilds_.Clone();
				revealFromIndex_ = other.revealFromIndex_;
				textScroller_ = ((other.textScroller_ != null) ? other.textScroller_.Clone() : null);
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Element Clone()
			{
				return new Element(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Element);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Element other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(Element_, other.Element_))
				{
					return false;
				}
				if (!object.Equals(BuildIn, other.BuildIn))
				{
					return false;
				}
				if (!object.Equals(BuildOut, other.BuildOut))
				{
					return false;
				}
				if (Info != other.Info)
				{
					return false;
				}
				if (RevealType != other.RevealType)
				{
					return false;
				}
				if (!dataLinks_.Equals(other.dataLinks_))
				{
					return false;
				}
				if (!childBuilds_.Equals(other.childBuilds_))
				{
					return false;
				}
				if (RevealFromIndex != other.RevealFromIndex)
				{
					return false;
				}
				if (!object.Equals(TextScroller, other.TextScroller))
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
					num ^= Element_.GetHashCode();
				}
				if (buildIn_ != null)
				{
					num ^= BuildIn.GetHashCode();
				}
				if (buildOut_ != null)
				{
					num ^= BuildOut.GetHashCode();
				}
				if (Info != 0)
				{
					num ^= Info.GetHashCode();
				}
				if (RevealType != 0)
				{
					num ^= RevealType.GetHashCode();
				}
				num ^= dataLinks_.GetHashCode();
				num ^= childBuilds_.GetHashCode();
				if (RevealFromIndex != 0)
				{
					num ^= RevealFromIndex.GetHashCode();
				}
				if (textScroller_ != null)
				{
					num ^= TextScroller.GetHashCode();
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
					output.WriteMessage(Element_);
				}
				if (buildIn_ != null)
				{
					output.WriteRawTag(18);
					output.WriteMessage(BuildIn);
				}
				if (buildOut_ != null)
				{
					output.WriteRawTag(26);
					output.WriteMessage(BuildOut);
				}
				if (Info != 0)
				{
					output.WriteRawTag(32);
					output.WriteUInt32(Info);
				}
				if (RevealType != 0)
				{
					output.WriteRawTag(40);
					output.WriteEnum((int)RevealType);
				}
				dataLinks_.WriteTo(output, _repeated_dataLinks_codec);
				childBuilds_.WriteTo(output, _repeated_childBuilds_codec);
				if (RevealFromIndex != 0)
				{
					output.WriteRawTag(64);
					output.WriteUInt32(RevealFromIndex);
				}
				if (textScroller_ != null)
				{
					output.WriteRawTag(74);
					output.WriteMessage(TextScroller);
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
					num += 1 + CodedOutputStream.ComputeMessageSize(Element_);
				}
				if (buildIn_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(BuildIn);
				}
				if (buildOut_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(BuildOut);
				}
				if (Info != 0)
				{
					num += 1 + CodedOutputStream.ComputeUInt32Size(Info);
				}
				if (RevealType != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)RevealType);
				}
				num += dataLinks_.CalculateSize(_repeated_dataLinks_codec);
				num += childBuilds_.CalculateSize(_repeated_childBuilds_codec);
				if (RevealFromIndex != 0)
				{
					num += 1 + CodedOutputStream.ComputeUInt32Size(RevealFromIndex);
				}
				if (textScroller_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(TextScroller);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(Element other)
			{
				if (other == null)
				{
					return;
				}
				if (other.element_ != null)
				{
					if (element_ == null)
					{
						Element_ = new Graphics.Types.Element();
					}
					Element_.MergeFrom(other.Element_);
				}
				if (other.buildIn_ != null)
				{
					if (buildIn_ == null)
					{
						BuildIn = new Types.Build();
					}
					BuildIn.MergeFrom(other.BuildIn);
				}
				if (other.buildOut_ != null)
				{
					if (buildOut_ == null)
					{
						BuildOut = new Types.Build();
					}
					BuildOut.MergeFrom(other.BuildOut);
				}
				if (other.Info != 0)
				{
					Info = other.Info;
				}
				if (other.RevealType != 0)
				{
					RevealType = other.RevealType;
				}
				dataLinks_.Add(other.dataLinks_);
				childBuilds_.Add(other.childBuilds_);
				if (other.RevealFromIndex != 0)
				{
					RevealFromIndex = other.RevealFromIndex;
				}
				if (other.textScroller_ != null)
				{
					if (textScroller_ == null)
					{
						TextScroller = new Types.TextScroller();
					}
					TextScroller.MergeFrom(other.TextScroller);
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
							Element_ = new Graphics.Types.Element();
						}
						input.ReadMessage(Element_);
						break;
					case 18u:
						if (buildIn_ == null)
						{
							BuildIn = new Types.Build();
						}
						input.ReadMessage(BuildIn);
						break;
					case 26u:
						if (buildOut_ == null)
						{
							BuildOut = new Types.Build();
						}
						input.ReadMessage(BuildOut);
						break;
					case 32u:
						Info = input.ReadUInt32();
						break;
					case 40u:
						RevealType = (Types.TextRevealType)input.ReadEnum();
						break;
					case 50u:
						dataLinks_.AddEntriesFrom(input, _repeated_dataLinks_codec);
						break;
					case 58u:
						childBuilds_.AddEntriesFrom(input, _repeated_childBuilds_codec);
						break;
					case 64u:
						RevealFromIndex = input.ReadUInt32();
						break;
					case 74u:
						if (textScroller_ == null)
						{
							TextScroller = new Types.TextScroller();
						}
						input.ReadMessage(TextScroller);
						break;
					}
				}
			}
		}
	}

	private static readonly MessageParser<Slide> _parser = new MessageParser<Slide>(() => new Slide());

	private UnknownFieldSet _unknownFields;

	public const int ElementsFieldNumber = 1;

	private static readonly FieldCodec<Types.Element> _repeated_elements_codec = FieldCodec.ForMessage(10u, Types.Element.Parser);

	private readonly RepeatedField<Types.Element> elements_ = new RepeatedField<Types.Element>();

	public const int ElementBuildOrderFieldNumber = 2;

	private static readonly FieldCodec<UUID> _repeated_elementBuildOrder_codec = FieldCodec.ForMessage(18u, UUID.Parser);

	private readonly RepeatedField<UUID> elementBuildOrder_ = new RepeatedField<UUID>();

	public const int GuidelinesFieldNumber = 3;

	private static readonly FieldCodec<AlignmentGuide> _repeated_guidelines_codec = FieldCodec.ForMessage(26u, AlignmentGuide.Parser);

	private readonly RepeatedField<AlignmentGuide> guidelines_ = new RepeatedField<AlignmentGuide>();

	public const int DrawsBackgroundColorFieldNumber = 4;

	private bool drawsBackgroundColor_;

	public const int BackgroundColorFieldNumber = 5;

	private Color backgroundColor_;

	public const int SizeFieldNumber = 6;

	private Graphics.Types.Size size_;

	public const int UuidFieldNumber = 7;

	private UUID uuid_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<Slide> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => SlideReflection.Descriptor.MessageTypes[0];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<Types.Element> Elements => elements_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<UUID> ElementBuildOrder => elementBuildOrder_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<AlignmentGuide> Guidelines => guidelines_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool DrawsBackgroundColor
	{
		get
		{
			return drawsBackgroundColor_;
		}
		set
		{
			drawsBackgroundColor_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Color BackgroundColor
	{
		get
		{
			return backgroundColor_;
		}
		set
		{
			backgroundColor_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Graphics.Types.Size Size
	{
		get
		{
			return size_;
		}
		set
		{
			size_ = value;
		}
	}

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
	public Slide()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Slide(Slide other)
		: this()
	{
		elements_ = other.elements_.Clone();
		elementBuildOrder_ = other.elementBuildOrder_.Clone();
		guidelines_ = other.guidelines_.Clone();
		drawsBackgroundColor_ = other.drawsBackgroundColor_;
		backgroundColor_ = ((other.backgroundColor_ != null) ? other.backgroundColor_.Clone() : null);
		size_ = ((other.size_ != null) ? other.size_.Clone() : null);
		uuid_ = ((other.uuid_ != null) ? other.uuid_.Clone() : null);
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Slide Clone()
	{
		return new Slide(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as Slide);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(Slide other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!elements_.Equals(other.elements_))
		{
			return false;
		}
		if (!elementBuildOrder_.Equals(other.elementBuildOrder_))
		{
			return false;
		}
		if (!guidelines_.Equals(other.guidelines_))
		{
			return false;
		}
		if (DrawsBackgroundColor != other.DrawsBackgroundColor)
		{
			return false;
		}
		if (!object.Equals(BackgroundColor, other.BackgroundColor))
		{
			return false;
		}
		if (!object.Equals(Size, other.Size))
		{
			return false;
		}
		if (!object.Equals(Uuid, other.Uuid))
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
		num ^= elements_.GetHashCode();
		num ^= elementBuildOrder_.GetHashCode();
		num ^= guidelines_.GetHashCode();
		if (DrawsBackgroundColor)
		{
			num ^= DrawsBackgroundColor.GetHashCode();
		}
		if (backgroundColor_ != null)
		{
			num ^= BackgroundColor.GetHashCode();
		}
		if (size_ != null)
		{
			num ^= Size.GetHashCode();
		}
		if (uuid_ != null)
		{
			num ^= Uuid.GetHashCode();
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
		elements_.WriteTo(output, _repeated_elements_codec);
		elementBuildOrder_.WriteTo(output, _repeated_elementBuildOrder_codec);
		guidelines_.WriteTo(output, _repeated_guidelines_codec);
		if (DrawsBackgroundColor)
		{
			output.WriteRawTag(32);
			output.WriteBool(DrawsBackgroundColor);
		}
		if (backgroundColor_ != null)
		{
			output.WriteRawTag(42);
			output.WriteMessage(BackgroundColor);
		}
		if (size_ != null)
		{
			output.WriteRawTag(50);
			output.WriteMessage(Size);
		}
		if (uuid_ != null)
		{
			output.WriteRawTag(58);
			output.WriteMessage(Uuid);
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
		num += elements_.CalculateSize(_repeated_elements_codec);
		num += elementBuildOrder_.CalculateSize(_repeated_elementBuildOrder_codec);
		num += guidelines_.CalculateSize(_repeated_guidelines_codec);
		if (DrawsBackgroundColor)
		{
			num += 2;
		}
		if (backgroundColor_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(BackgroundColor);
		}
		if (size_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Size);
		}
		if (uuid_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Uuid);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(Slide other)
	{
		if (other == null)
		{
			return;
		}
		elements_.Add(other.elements_);
		elementBuildOrder_.Add(other.elementBuildOrder_);
		guidelines_.Add(other.guidelines_);
		if (other.DrawsBackgroundColor)
		{
			DrawsBackgroundColor = other.DrawsBackgroundColor;
		}
		if (other.backgroundColor_ != null)
		{
			if (backgroundColor_ == null)
			{
				BackgroundColor = new Color();
			}
			BackgroundColor.MergeFrom(other.BackgroundColor);
		}
		if (other.size_ != null)
		{
			if (size_ == null)
			{
				Size = new Graphics.Types.Size();
			}
			Size.MergeFrom(other.Size);
		}
		if (other.uuid_ != null)
		{
			if (uuid_ == null)
			{
				Uuid = new UUID();
			}
			Uuid.MergeFrom(other.Uuid);
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
				elements_.AddEntriesFrom(input, _repeated_elements_codec);
				break;
			case 18u:
				elementBuildOrder_.AddEntriesFrom(input, _repeated_elementBuildOrder_codec);
				break;
			case 26u:
				guidelines_.AddEntriesFrom(input, _repeated_guidelines_codec);
				break;
			case 32u:
				DrawsBackgroundColor = input.ReadBool();
				break;
			case 42u:
				if (backgroundColor_ == null)
				{
					BackgroundColor = new Color();
				}
				input.ReadMessage(BackgroundColor);
				break;
			case 50u:
				if (size_ == null)
				{
					Size = new Graphics.Types.Size();
				}
				input.ReadMessage(Size);
				break;
			case 58u:
				if (uuid_ == null)
				{
					Uuid = new UUID();
				}
				input.ReadMessage(Uuid);
				break;
			}
		}
	}
}
