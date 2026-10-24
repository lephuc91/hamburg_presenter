using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class PlanningCenterPlan : IMessage<PlanningCenterPlan>, IMessage, IEquatable<PlanningCenterPlan>, IDeepCloneable<PlanningCenterPlan>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class PlanItem : IMessage<PlanItem>, IMessage, IEquatable<PlanItem>, IDeepCloneable<PlanItem>
		{
			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				public enum PlanItemType
				{
					[OriginalName("PLAN_ITEM_TYPE_ITEM")]
					Item,
					[OriginalName("PLAN_ITEM_TYPE_SONG")]
					Song,
					[OriginalName("PLAN_ITEM_TYPE_MEDIA")]
					Media,
					[OriginalName("PLAN_ITEM_TYPE_HEADER")]
					Header
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class Attachment : IMessage<Attachment>, IMessage, IEquatable<Attachment>, IDeepCloneable<Attachment>
				{
					private static readonly MessageParser<Attachment> _parser = new MessageParser<Attachment>(() => new Attachment());

					private UnknownFieldSet _unknownFields;

					public const int NameFieldNumber = 1;

					private string name_ = "";

					public const int UrlFieldNumber = 2;

					private URL url_;

					public const int CreatedDateFieldNumber = 3;

					private Timestamp createdDate_;

					public const int LinkedPathFieldNumber = 4;

					private URL linkedPath_;

					public const int PcoIdNumFieldNumber = 5;

					private uint pcoIdNum_;

					public const int NeedsUpdateFieldNumber = 6;

					private bool needsUpdate_;

					public const int UpdateDateFieldNumber = 7;

					private Timestamp updateDate_;

					public const int PcoIdStrFieldNumber = 8;

					private string pcoIdStr_ = "";

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<Attachment> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => PlanItem.Descriptor.NestedTypes[0];

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
					public Timestamp CreatedDate
					{
						get
						{
							return createdDate_;
						}
						set
						{
							createdDate_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public URL LinkedPath
					{
						get
						{
							return linkedPath_;
						}
						set
						{
							linkedPath_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public uint PcoIdNum
					{
						get
						{
							return pcoIdNum_;
						}
						set
						{
							pcoIdNum_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool NeedsUpdate
					{
						get
						{
							return needsUpdate_;
						}
						set
						{
							needsUpdate_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Timestamp UpdateDate
					{
						get
						{
							return updateDate_;
						}
						set
						{
							updateDate_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public string PcoIdStr
					{
						get
						{
							return pcoIdStr_;
						}
						set
						{
							pcoIdStr_ = ProtoPreconditions.CheckNotNull(value, "value");
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Attachment()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Attachment(Attachment other)
						: this()
					{
						name_ = other.name_;
						url_ = ((other.url_ != null) ? other.url_.Clone() : null);
						createdDate_ = ((other.createdDate_ != null) ? other.createdDate_.Clone() : null);
						linkedPath_ = ((other.linkedPath_ != null) ? other.linkedPath_.Clone() : null);
						pcoIdNum_ = other.pcoIdNum_;
						needsUpdate_ = other.needsUpdate_;
						updateDate_ = ((other.updateDate_ != null) ? other.updateDate_.Clone() : null);
						pcoIdStr_ = other.pcoIdStr_;
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Attachment Clone()
					{
						return new Attachment(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as Attachment);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(Attachment other)
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
						if (!object.Equals(Url, other.Url))
						{
							return false;
						}
						if (!object.Equals(CreatedDate, other.CreatedDate))
						{
							return false;
						}
						if (!object.Equals(LinkedPath, other.LinkedPath))
						{
							return false;
						}
						if (PcoIdNum != other.PcoIdNum)
						{
							return false;
						}
						if (NeedsUpdate != other.NeedsUpdate)
						{
							return false;
						}
						if (!object.Equals(UpdateDate, other.UpdateDate))
						{
							return false;
						}
						if (PcoIdStr != other.PcoIdStr)
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
						if (url_ != null)
						{
							num ^= Url.GetHashCode();
						}
						if (createdDate_ != null)
						{
							num ^= CreatedDate.GetHashCode();
						}
						if (linkedPath_ != null)
						{
							num ^= LinkedPath.GetHashCode();
						}
						if (PcoIdNum != 0)
						{
							num ^= PcoIdNum.GetHashCode();
						}
						if (NeedsUpdate)
						{
							num ^= NeedsUpdate.GetHashCode();
						}
						if (updateDate_ != null)
						{
							num ^= UpdateDate.GetHashCode();
						}
						if (PcoIdStr.Length != 0)
						{
							num ^= PcoIdStr.GetHashCode();
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
						if (url_ != null)
						{
							output.WriteRawTag(18);
							output.WriteMessage(Url);
						}
						if (createdDate_ != null)
						{
							output.WriteRawTag(26);
							output.WriteMessage(CreatedDate);
						}
						if (linkedPath_ != null)
						{
							output.WriteRawTag(34);
							output.WriteMessage(LinkedPath);
						}
						if (PcoIdNum != 0)
						{
							output.WriteRawTag(40);
							output.WriteUInt32(PcoIdNum);
						}
						if (NeedsUpdate)
						{
							output.WriteRawTag(48);
							output.WriteBool(NeedsUpdate);
						}
						if (updateDate_ != null)
						{
							output.WriteRawTag(58);
							output.WriteMessage(UpdateDate);
						}
						if (PcoIdStr.Length != 0)
						{
							output.WriteRawTag(66);
							output.WriteString(PcoIdStr);
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
						if (url_ != null)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(Url);
						}
						if (createdDate_ != null)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(CreatedDate);
						}
						if (linkedPath_ != null)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(LinkedPath);
						}
						if (PcoIdNum != 0)
						{
							num += 1 + CodedOutputStream.ComputeUInt32Size(PcoIdNum);
						}
						if (NeedsUpdate)
						{
							num += 2;
						}
						if (updateDate_ != null)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(UpdateDate);
						}
						if (PcoIdStr.Length != 0)
						{
							num += 1 + CodedOutputStream.ComputeStringSize(PcoIdStr);
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(Attachment other)
					{
						if (other == null)
						{
							return;
						}
						if (other.Name.Length != 0)
						{
							Name = other.Name;
						}
						if (other.url_ != null)
						{
							if (url_ == null)
							{
								Url = new URL();
							}
							Url.MergeFrom(other.Url);
						}
						if (other.createdDate_ != null)
						{
							if (createdDate_ == null)
							{
								CreatedDate = new Timestamp();
							}
							CreatedDate.MergeFrom(other.CreatedDate);
						}
						if (other.linkedPath_ != null)
						{
							if (linkedPath_ == null)
							{
								LinkedPath = new URL();
							}
							LinkedPath.MergeFrom(other.LinkedPath);
						}
						if (other.PcoIdNum != 0)
						{
							PcoIdNum = other.PcoIdNum;
						}
						if (other.NeedsUpdate)
						{
							NeedsUpdate = other.NeedsUpdate;
						}
						if (other.updateDate_ != null)
						{
							if (updateDate_ == null)
							{
								UpdateDate = new Timestamp();
							}
							UpdateDate.MergeFrom(other.UpdateDate);
						}
						if (other.PcoIdStr.Length != 0)
						{
							PcoIdStr = other.PcoIdStr;
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
								if (url_ == null)
								{
									Url = new URL();
								}
								input.ReadMessage(Url);
								break;
							case 26u:
								if (createdDate_ == null)
								{
									CreatedDate = new Timestamp();
								}
								input.ReadMessage(CreatedDate);
								break;
							case 34u:
								if (linkedPath_ == null)
								{
									LinkedPath = new URL();
								}
								input.ReadMessage(LinkedPath);
								break;
							case 40u:
								PcoIdNum = input.ReadUInt32();
								break;
							case 48u:
								NeedsUpdate = input.ReadBool();
								break;
							case 58u:
								if (updateDate_ == null)
								{
									UpdateDate = new Timestamp();
								}
								input.ReadMessage(UpdateDate);
								break;
							case 66u:
								PcoIdStr = input.ReadString();
								break;
							}
						}
					}
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class SongItem : IMessage<SongItem>, IMessage, IEquatable<SongItem>, IDeepCloneable<SongItem>
				{
					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static class Types
					{
						[DebuggerDisplay("{ToString(),nq}")]
						public sealed class Sequence : IMessage<Sequence>, IMessage, IEquatable<Sequence>, IDeepCloneable<Sequence>
						{
							private static readonly MessageParser<Sequence> _parser = new MessageParser<Sequence>(() => new Sequence());

							private UnknownFieldSet _unknownFields;

							public const int PcoIdNumFieldNumber = 1;

							private uint pcoIdNum_;

							public const int NameFieldNumber = 2;

							private string name_ = "";

							public const int GroupNamesFieldNumber = 3;

							private static readonly FieldCodec<string> _repeated_groupNames_codec = FieldCodec.ForString(26u);

							private readonly RepeatedField<string> groupNames_ = new RepeatedField<string>();

							public const int PcoIdStrFieldNumber = 4;

							private string pcoIdStr_ = "";

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageParser<Sequence> Parser => _parser;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageDescriptor Descriptor => SongItem.Descriptor.NestedTypes[0];

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							MessageDescriptor IMessage.Descriptor => Descriptor;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public uint PcoIdNum
							{
								get
								{
									return pcoIdNum_;
								}
								set
								{
									pcoIdNum_ = value;
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
							public RepeatedField<string> GroupNames => groupNames_;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public string PcoIdStr
							{
								get
								{
									return pcoIdStr_;
								}
								set
								{
									pcoIdStr_ = ProtoPreconditions.CheckNotNull(value, "value");
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Sequence()
							{
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Sequence(Sequence other)
								: this()
							{
								pcoIdNum_ = other.pcoIdNum_;
								name_ = other.name_;
								groupNames_ = other.groupNames_.Clone();
								pcoIdStr_ = other.pcoIdStr_;
								_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Sequence Clone()
							{
								return new Sequence(this);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public override bool Equals(object other)
							{
								return Equals(other as Sequence);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool Equals(Sequence other)
							{
								if (other == null)
								{
									return false;
								}
								if (other == this)
								{
									return true;
								}
								if (PcoIdNum != other.PcoIdNum)
								{
									return false;
								}
								if (Name != other.Name)
								{
									return false;
								}
								if (!groupNames_.Equals(other.groupNames_))
								{
									return false;
								}
								if (PcoIdStr != other.PcoIdStr)
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
								if (PcoIdNum != 0)
								{
									num ^= PcoIdNum.GetHashCode();
								}
								if (Name.Length != 0)
								{
									num ^= Name.GetHashCode();
								}
								num ^= groupNames_.GetHashCode();
								if (PcoIdStr.Length != 0)
								{
									num ^= PcoIdStr.GetHashCode();
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
								if (PcoIdNum != 0)
								{
									output.WriteRawTag(8);
									output.WriteUInt32(PcoIdNum);
								}
								if (Name.Length != 0)
								{
									output.WriteRawTag(18);
									output.WriteString(Name);
								}
								groupNames_.WriteTo(output, _repeated_groupNames_codec);
								if (PcoIdStr.Length != 0)
								{
									output.WriteRawTag(34);
									output.WriteString(PcoIdStr);
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
								if (PcoIdNum != 0)
								{
									num += 1 + CodedOutputStream.ComputeUInt32Size(PcoIdNum);
								}
								if (Name.Length != 0)
								{
									num += 1 + CodedOutputStream.ComputeStringSize(Name);
								}
								num += groupNames_.CalculateSize(_repeated_groupNames_codec);
								if (PcoIdStr.Length != 0)
								{
									num += 1 + CodedOutputStream.ComputeStringSize(PcoIdStr);
								}
								if (_unknownFields != null)
								{
									num += _unknownFields.CalculateSize();
								}
								return num;
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public void MergeFrom(Sequence other)
							{
								if (other != null)
								{
									if (other.PcoIdNum != 0)
									{
										PcoIdNum = other.PcoIdNum;
									}
									if (other.Name.Length != 0)
									{
										Name = other.Name;
									}
									groupNames_.Add(other.groupNames_);
									if (other.PcoIdStr.Length != 0)
									{
										PcoIdStr = other.PcoIdStr;
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
										PcoIdNum = input.ReadUInt32();
										break;
									case 18u:
										Name = input.ReadString();
										break;
									case 26u:
										groupNames_.AddEntriesFrom(input, _repeated_groupNames_codec);
										break;
									case 34u:
										PcoIdStr = input.ReadString();
										break;
									}
								}
							}
						}
					}

					private static readonly MessageParser<SongItem> _parser = new MessageParser<SongItem>(() => new SongItem());

					private UnknownFieldSet _unknownFields;

					public const int PcoIdNumFieldNumber = 1;

					private uint pcoIdNum_;

					public const int ArrangementIdNumFieldNumber = 2;

					private uint arrangementIdNum_;

					public const int CcliFieldNumber = 3;

					private Presentation.Types.CCLI ccli_;

					public const int SequenceFieldNumber = 4;

					private Types.Sequence sequence_;

					public const int PcoIdStrFieldNumber = 5;

					private string pcoIdStr_ = "";

					public const int ArrangementIdStrFieldNumber = 6;

					private string arrangementIdStr_ = "";

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<SongItem> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => PlanItem.Descriptor.NestedTypes[1];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public uint PcoIdNum
					{
						get
						{
							return pcoIdNum_;
						}
						set
						{
							pcoIdNum_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public uint ArrangementIdNum
					{
						get
						{
							return arrangementIdNum_;
						}
						set
						{
							arrangementIdNum_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Presentation.Types.CCLI Ccli
					{
						get
						{
							return ccli_;
						}
						set
						{
							ccli_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Types.Sequence Sequence
					{
						get
						{
							return sequence_;
						}
						set
						{
							sequence_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public string PcoIdStr
					{
						get
						{
							return pcoIdStr_;
						}
						set
						{
							pcoIdStr_ = ProtoPreconditions.CheckNotNull(value, "value");
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public string ArrangementIdStr
					{
						get
						{
							return arrangementIdStr_;
						}
						set
						{
							arrangementIdStr_ = ProtoPreconditions.CheckNotNull(value, "value");
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public SongItem()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public SongItem(SongItem other)
						: this()
					{
						pcoIdNum_ = other.pcoIdNum_;
						arrangementIdNum_ = other.arrangementIdNum_;
						ccli_ = ((other.ccli_ != null) ? other.ccli_.Clone() : null);
						sequence_ = ((other.sequence_ != null) ? other.sequence_.Clone() : null);
						pcoIdStr_ = other.pcoIdStr_;
						arrangementIdStr_ = other.arrangementIdStr_;
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public SongItem Clone()
					{
						return new SongItem(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as SongItem);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(SongItem other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (PcoIdNum != other.PcoIdNum)
						{
							return false;
						}
						if (ArrangementIdNum != other.ArrangementIdNum)
						{
							return false;
						}
						if (!object.Equals(Ccli, other.Ccli))
						{
							return false;
						}
						if (!object.Equals(Sequence, other.Sequence))
						{
							return false;
						}
						if (PcoIdStr != other.PcoIdStr)
						{
							return false;
						}
						if (ArrangementIdStr != other.ArrangementIdStr)
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
						if (PcoIdNum != 0)
						{
							num ^= PcoIdNum.GetHashCode();
						}
						if (ArrangementIdNum != 0)
						{
							num ^= ArrangementIdNum.GetHashCode();
						}
						if (ccli_ != null)
						{
							num ^= Ccli.GetHashCode();
						}
						if (sequence_ != null)
						{
							num ^= Sequence.GetHashCode();
						}
						if (PcoIdStr.Length != 0)
						{
							num ^= PcoIdStr.GetHashCode();
						}
						if (ArrangementIdStr.Length != 0)
						{
							num ^= ArrangementIdStr.GetHashCode();
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
						if (PcoIdNum != 0)
						{
							output.WriteRawTag(8);
							output.WriteUInt32(PcoIdNum);
						}
						if (ArrangementIdNum != 0)
						{
							output.WriteRawTag(16);
							output.WriteUInt32(ArrangementIdNum);
						}
						if (ccli_ != null)
						{
							output.WriteRawTag(26);
							output.WriteMessage(Ccli);
						}
						if (sequence_ != null)
						{
							output.WriteRawTag(34);
							output.WriteMessage(Sequence);
						}
						if (PcoIdStr.Length != 0)
						{
							output.WriteRawTag(42);
							output.WriteString(PcoIdStr);
						}
						if (ArrangementIdStr.Length != 0)
						{
							output.WriteRawTag(50);
							output.WriteString(ArrangementIdStr);
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
						if (PcoIdNum != 0)
						{
							num += 1 + CodedOutputStream.ComputeUInt32Size(PcoIdNum);
						}
						if (ArrangementIdNum != 0)
						{
							num += 1 + CodedOutputStream.ComputeUInt32Size(ArrangementIdNum);
						}
						if (ccli_ != null)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(Ccli);
						}
						if (sequence_ != null)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(Sequence);
						}
						if (PcoIdStr.Length != 0)
						{
							num += 1 + CodedOutputStream.ComputeStringSize(PcoIdStr);
						}
						if (ArrangementIdStr.Length != 0)
						{
							num += 1 + CodedOutputStream.ComputeStringSize(ArrangementIdStr);
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(SongItem other)
					{
						if (other == null)
						{
							return;
						}
						if (other.PcoIdNum != 0)
						{
							PcoIdNum = other.PcoIdNum;
						}
						if (other.ArrangementIdNum != 0)
						{
							ArrangementIdNum = other.ArrangementIdNum;
						}
						if (other.ccli_ != null)
						{
							if (ccli_ == null)
							{
								Ccli = new Presentation.Types.CCLI();
							}
							Ccli.MergeFrom(other.Ccli);
						}
						if (other.sequence_ != null)
						{
							if (sequence_ == null)
							{
								Sequence = new Types.Sequence();
							}
							Sequence.MergeFrom(other.Sequence);
						}
						if (other.PcoIdStr.Length != 0)
						{
							PcoIdStr = other.PcoIdStr;
						}
						if (other.ArrangementIdStr.Length != 0)
						{
							ArrangementIdStr = other.ArrangementIdStr;
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
								PcoIdNum = input.ReadUInt32();
								break;
							case 16u:
								ArrangementIdNum = input.ReadUInt32();
								break;
							case 26u:
								if (ccli_ == null)
								{
									Ccli = new Presentation.Types.CCLI();
								}
								input.ReadMessage(Ccli);
								break;
							case 34u:
								if (sequence_ == null)
								{
									Sequence = new Types.Sequence();
								}
								input.ReadMessage(Sequence);
								break;
							case 42u:
								PcoIdStr = input.ReadString();
								break;
							case 50u:
								ArrangementIdStr = input.ReadString();
								break;
							}
						}
					}
				}
			}

			private static readonly MessageParser<PlanItem> _parser = new MessageParser<PlanItem>(() => new PlanItem());

			private UnknownFieldSet _unknownFields;

			public const int ItemTypeFieldNumber = 1;

			private Types.PlanItemType itemType_;

			public const int PcoIdNumFieldNumber = 2;

			private uint pcoIdNum_;

			public const int ServiceIdNumFieldNumber = 3;

			private uint serviceIdNum_;

			public const int ParentIdNumFieldNumber = 4;

			private uint parentIdNum_;

			public const int NameFieldNumber = 5;

			private string name_ = "";

			public const int AttachmentsFieldNumber = 6;

			private static readonly FieldCodec<Types.Attachment> _repeated_attachments_codec = FieldCodec.ForMessage(50u, Types.Attachment.Parser);

			private readonly RepeatedField<Types.Attachment> attachments_ = new RepeatedField<Types.Attachment>();

			public const int UpdateDateFieldNumber = 7;

			private Timestamp updateDate_;

			public const int LinkedSongFieldNumber = 8;

			private Types.SongItem linkedSong_;

			public const int PcoIdStrFieldNumber = 9;

			private string pcoIdStr_ = "";

			public const int ServiceIdStrFieldNumber = 10;

			private string serviceIdStr_ = "";

			public const int ParentIdStrFieldNumber = 11;

			private string parentIdStr_ = "";

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<PlanItem> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => PlanningCenterPlan.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.PlanItemType ItemType
			{
				get
				{
					return itemType_;
				}
				set
				{
					itemType_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public uint PcoIdNum
			{
				get
				{
					return pcoIdNum_;
				}
				set
				{
					pcoIdNum_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public uint ServiceIdNum
			{
				get
				{
					return serviceIdNum_;
				}
				set
				{
					serviceIdNum_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public uint ParentIdNum
			{
				get
				{
					return parentIdNum_;
				}
				set
				{
					parentIdNum_ = value;
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
			public RepeatedField<Types.Attachment> Attachments => attachments_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Timestamp UpdateDate
			{
				get
				{
					return updateDate_;
				}
				set
				{
					updateDate_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.SongItem LinkedSong
			{
				get
				{
					return linkedSong_;
				}
				set
				{
					linkedSong_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string PcoIdStr
			{
				get
				{
					return pcoIdStr_;
				}
				set
				{
					pcoIdStr_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string ServiceIdStr
			{
				get
				{
					return serviceIdStr_;
				}
				set
				{
					serviceIdStr_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string ParentIdStr
			{
				get
				{
					return parentIdStr_;
				}
				set
				{
					parentIdStr_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PlanItem()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PlanItem(PlanItem other)
				: this()
			{
				itemType_ = other.itemType_;
				pcoIdNum_ = other.pcoIdNum_;
				serviceIdNum_ = other.serviceIdNum_;
				parentIdNum_ = other.parentIdNum_;
				name_ = other.name_;
				attachments_ = other.attachments_.Clone();
				updateDate_ = ((other.updateDate_ != null) ? other.updateDate_.Clone() : null);
				linkedSong_ = ((other.linkedSong_ != null) ? other.linkedSong_.Clone() : null);
				pcoIdStr_ = other.pcoIdStr_;
				serviceIdStr_ = other.serviceIdStr_;
				parentIdStr_ = other.parentIdStr_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PlanItem Clone()
			{
				return new PlanItem(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as PlanItem);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(PlanItem other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (ItemType != other.ItemType)
				{
					return false;
				}
				if (PcoIdNum != other.PcoIdNum)
				{
					return false;
				}
				if (ServiceIdNum != other.ServiceIdNum)
				{
					return false;
				}
				if (ParentIdNum != other.ParentIdNum)
				{
					return false;
				}
				if (Name != other.Name)
				{
					return false;
				}
				if (!attachments_.Equals(other.attachments_))
				{
					return false;
				}
				if (!object.Equals(UpdateDate, other.UpdateDate))
				{
					return false;
				}
				if (!object.Equals(LinkedSong, other.LinkedSong))
				{
					return false;
				}
				if (PcoIdStr != other.PcoIdStr)
				{
					return false;
				}
				if (ServiceIdStr != other.ServiceIdStr)
				{
					return false;
				}
				if (ParentIdStr != other.ParentIdStr)
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
				if (ItemType != 0)
				{
					num ^= ItemType.GetHashCode();
				}
				if (PcoIdNum != 0)
				{
					num ^= PcoIdNum.GetHashCode();
				}
				if (ServiceIdNum != 0)
				{
					num ^= ServiceIdNum.GetHashCode();
				}
				if (ParentIdNum != 0)
				{
					num ^= ParentIdNum.GetHashCode();
				}
				if (Name.Length != 0)
				{
					num ^= Name.GetHashCode();
				}
				num ^= attachments_.GetHashCode();
				if (updateDate_ != null)
				{
					num ^= UpdateDate.GetHashCode();
				}
				if (linkedSong_ != null)
				{
					num ^= LinkedSong.GetHashCode();
				}
				if (PcoIdStr.Length != 0)
				{
					num ^= PcoIdStr.GetHashCode();
				}
				if (ServiceIdStr.Length != 0)
				{
					num ^= ServiceIdStr.GetHashCode();
				}
				if (ParentIdStr.Length != 0)
				{
					num ^= ParentIdStr.GetHashCode();
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
				if (ItemType != 0)
				{
					output.WriteRawTag(8);
					output.WriteEnum((int)ItemType);
				}
				if (PcoIdNum != 0)
				{
					output.WriteRawTag(16);
					output.WriteUInt32(PcoIdNum);
				}
				if (ServiceIdNum != 0)
				{
					output.WriteRawTag(24);
					output.WriteUInt32(ServiceIdNum);
				}
				if (ParentIdNum != 0)
				{
					output.WriteRawTag(32);
					output.WriteUInt32(ParentIdNum);
				}
				if (Name.Length != 0)
				{
					output.WriteRawTag(42);
					output.WriteString(Name);
				}
				attachments_.WriteTo(output, _repeated_attachments_codec);
				if (updateDate_ != null)
				{
					output.WriteRawTag(58);
					output.WriteMessage(UpdateDate);
				}
				if (linkedSong_ != null)
				{
					output.WriteRawTag(66);
					output.WriteMessage(LinkedSong);
				}
				if (PcoIdStr.Length != 0)
				{
					output.WriteRawTag(74);
					output.WriteString(PcoIdStr);
				}
				if (ServiceIdStr.Length != 0)
				{
					output.WriteRawTag(82);
					output.WriteString(ServiceIdStr);
				}
				if (ParentIdStr.Length != 0)
				{
					output.WriteRawTag(90);
					output.WriteString(ParentIdStr);
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
				if (ItemType != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)ItemType);
				}
				if (PcoIdNum != 0)
				{
					num += 1 + CodedOutputStream.ComputeUInt32Size(PcoIdNum);
				}
				if (ServiceIdNum != 0)
				{
					num += 1 + CodedOutputStream.ComputeUInt32Size(ServiceIdNum);
				}
				if (ParentIdNum != 0)
				{
					num += 1 + CodedOutputStream.ComputeUInt32Size(ParentIdNum);
				}
				if (Name.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Name);
				}
				num += attachments_.CalculateSize(_repeated_attachments_codec);
				if (updateDate_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(UpdateDate);
				}
				if (linkedSong_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(LinkedSong);
				}
				if (PcoIdStr.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(PcoIdStr);
				}
				if (ServiceIdStr.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(ServiceIdStr);
				}
				if (ParentIdStr.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(ParentIdStr);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(PlanItem other)
			{
				if (other == null)
				{
					return;
				}
				if (other.ItemType != 0)
				{
					ItemType = other.ItemType;
				}
				if (other.PcoIdNum != 0)
				{
					PcoIdNum = other.PcoIdNum;
				}
				if (other.ServiceIdNum != 0)
				{
					ServiceIdNum = other.ServiceIdNum;
				}
				if (other.ParentIdNum != 0)
				{
					ParentIdNum = other.ParentIdNum;
				}
				if (other.Name.Length != 0)
				{
					Name = other.Name;
				}
				attachments_.Add(other.attachments_);
				if (other.updateDate_ != null)
				{
					if (updateDate_ == null)
					{
						UpdateDate = new Timestamp();
					}
					UpdateDate.MergeFrom(other.UpdateDate);
				}
				if (other.linkedSong_ != null)
				{
					if (linkedSong_ == null)
					{
						LinkedSong = new Types.SongItem();
					}
					LinkedSong.MergeFrom(other.LinkedSong);
				}
				if (other.PcoIdStr.Length != 0)
				{
					PcoIdStr = other.PcoIdStr;
				}
				if (other.ServiceIdStr.Length != 0)
				{
					ServiceIdStr = other.ServiceIdStr;
				}
				if (other.ParentIdStr.Length != 0)
				{
					ParentIdStr = other.ParentIdStr;
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
						ItemType = (Types.PlanItemType)input.ReadEnum();
						break;
					case 16u:
						PcoIdNum = input.ReadUInt32();
						break;
					case 24u:
						ServiceIdNum = input.ReadUInt32();
						break;
					case 32u:
						ParentIdNum = input.ReadUInt32();
						break;
					case 42u:
						Name = input.ReadString();
						break;
					case 50u:
						attachments_.AddEntriesFrom(input, _repeated_attachments_codec);
						break;
					case 58u:
						if (updateDate_ == null)
						{
							UpdateDate = new Timestamp();
						}
						input.ReadMessage(UpdateDate);
						break;
					case 66u:
						if (linkedSong_ == null)
						{
							LinkedSong = new Types.SongItem();
						}
						input.ReadMessage(LinkedSong);
						break;
					case 74u:
						PcoIdStr = input.ReadString();
						break;
					case 82u:
						ServiceIdStr = input.ReadString();
						break;
					case 90u:
						ParentIdStr = input.ReadString();
						break;
					}
				}
			}
		}
	}

	private static readonly MessageParser<PlanningCenterPlan> _parser = new MessageParser<PlanningCenterPlan>(() => new PlanningCenterPlan());

	private UnknownFieldSet _unknownFields;

	public const int PlanIdNumFieldNumber = 1;

	private uint planIdNum_;

	public const int ParentIdNumFieldNumber = 2;

	private uint parentIdNum_;

	public const int SeriesTitleFieldNumber = 3;

	private string seriesTitle_ = "";

	public const int PlanTitleFieldNumber = 4;

	private string planTitle_ = "";

	public const int DateListFieldNumber = 5;

	private string dateList_ = "";

	public const int CreatedDateFieldNumber = 6;

	private Timestamp createdDate_;

	public const int UpdateDateFieldNumber = 7;

	private Timestamp updateDate_;

	public const int LastUpdateCheckDateFieldNumber = 8;

	private Timestamp lastUpdateCheckDate_;

	public const int PlanIdStrFieldNumber = 9;

	private string planIdStr_ = "";

	public const int ParentIdStrFieldNumber = 10;

	private string parentIdStr_ = "";

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<PlanningCenterPlan> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => PlanningCenterReflection.Descriptor.MessageTypes[0];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public uint PlanIdNum
	{
		get
		{
			return planIdNum_;
		}
		set
		{
			planIdNum_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public uint ParentIdNum
	{
		get
		{
			return parentIdNum_;
		}
		set
		{
			parentIdNum_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string SeriesTitle
	{
		get
		{
			return seriesTitle_;
		}
		set
		{
			seriesTitle_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string PlanTitle
	{
		get
		{
			return planTitle_;
		}
		set
		{
			planTitle_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string DateList
	{
		get
		{
			return dateList_;
		}
		set
		{
			dateList_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Timestamp CreatedDate
	{
		get
		{
			return createdDate_;
		}
		set
		{
			createdDate_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Timestamp UpdateDate
	{
		get
		{
			return updateDate_;
		}
		set
		{
			updateDate_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Timestamp LastUpdateCheckDate
	{
		get
		{
			return lastUpdateCheckDate_;
		}
		set
		{
			lastUpdateCheckDate_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string PlanIdStr
	{
		get
		{
			return planIdStr_;
		}
		set
		{
			planIdStr_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string ParentIdStr
	{
		get
		{
			return parentIdStr_;
		}
		set
		{
			parentIdStr_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public PlanningCenterPlan()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public PlanningCenterPlan(PlanningCenterPlan other)
		: this()
	{
		planIdNum_ = other.planIdNum_;
		parentIdNum_ = other.parentIdNum_;
		seriesTitle_ = other.seriesTitle_;
		planTitle_ = other.planTitle_;
		dateList_ = other.dateList_;
		createdDate_ = ((other.createdDate_ != null) ? other.createdDate_.Clone() : null);
		updateDate_ = ((other.updateDate_ != null) ? other.updateDate_.Clone() : null);
		lastUpdateCheckDate_ = ((other.lastUpdateCheckDate_ != null) ? other.lastUpdateCheckDate_.Clone() : null);
		planIdStr_ = other.planIdStr_;
		parentIdStr_ = other.parentIdStr_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public PlanningCenterPlan Clone()
	{
		return new PlanningCenterPlan(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as PlanningCenterPlan);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(PlanningCenterPlan other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (PlanIdNum != other.PlanIdNum)
		{
			return false;
		}
		if (ParentIdNum != other.ParentIdNum)
		{
			return false;
		}
		if (SeriesTitle != other.SeriesTitle)
		{
			return false;
		}
		if (PlanTitle != other.PlanTitle)
		{
			return false;
		}
		if (DateList != other.DateList)
		{
			return false;
		}
		if (!object.Equals(CreatedDate, other.CreatedDate))
		{
			return false;
		}
		if (!object.Equals(UpdateDate, other.UpdateDate))
		{
			return false;
		}
		if (!object.Equals(LastUpdateCheckDate, other.LastUpdateCheckDate))
		{
			return false;
		}
		if (PlanIdStr != other.PlanIdStr)
		{
			return false;
		}
		if (ParentIdStr != other.ParentIdStr)
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
		if (PlanIdNum != 0)
		{
			num ^= PlanIdNum.GetHashCode();
		}
		if (ParentIdNum != 0)
		{
			num ^= ParentIdNum.GetHashCode();
		}
		if (SeriesTitle.Length != 0)
		{
			num ^= SeriesTitle.GetHashCode();
		}
		if (PlanTitle.Length != 0)
		{
			num ^= PlanTitle.GetHashCode();
		}
		if (DateList.Length != 0)
		{
			num ^= DateList.GetHashCode();
		}
		if (createdDate_ != null)
		{
			num ^= CreatedDate.GetHashCode();
		}
		if (updateDate_ != null)
		{
			num ^= UpdateDate.GetHashCode();
		}
		if (lastUpdateCheckDate_ != null)
		{
			num ^= LastUpdateCheckDate.GetHashCode();
		}
		if (PlanIdStr.Length != 0)
		{
			num ^= PlanIdStr.GetHashCode();
		}
		if (ParentIdStr.Length != 0)
		{
			num ^= ParentIdStr.GetHashCode();
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
		if (PlanIdNum != 0)
		{
			output.WriteRawTag(8);
			output.WriteUInt32(PlanIdNum);
		}
		if (ParentIdNum != 0)
		{
			output.WriteRawTag(16);
			output.WriteUInt32(ParentIdNum);
		}
		if (SeriesTitle.Length != 0)
		{
			output.WriteRawTag(26);
			output.WriteString(SeriesTitle);
		}
		if (PlanTitle.Length != 0)
		{
			output.WriteRawTag(34);
			output.WriteString(PlanTitle);
		}
		if (DateList.Length != 0)
		{
			output.WriteRawTag(42);
			output.WriteString(DateList);
		}
		if (createdDate_ != null)
		{
			output.WriteRawTag(50);
			output.WriteMessage(CreatedDate);
		}
		if (updateDate_ != null)
		{
			output.WriteRawTag(58);
			output.WriteMessage(UpdateDate);
		}
		if (lastUpdateCheckDate_ != null)
		{
			output.WriteRawTag(66);
			output.WriteMessage(LastUpdateCheckDate);
		}
		if (PlanIdStr.Length != 0)
		{
			output.WriteRawTag(74);
			output.WriteString(PlanIdStr);
		}
		if (ParentIdStr.Length != 0)
		{
			output.WriteRawTag(82);
			output.WriteString(ParentIdStr);
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
		if (PlanIdNum != 0)
		{
			num += 1 + CodedOutputStream.ComputeUInt32Size(PlanIdNum);
		}
		if (ParentIdNum != 0)
		{
			num += 1 + CodedOutputStream.ComputeUInt32Size(ParentIdNum);
		}
		if (SeriesTitle.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(SeriesTitle);
		}
		if (PlanTitle.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(PlanTitle);
		}
		if (DateList.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(DateList);
		}
		if (createdDate_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(CreatedDate);
		}
		if (updateDate_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(UpdateDate);
		}
		if (lastUpdateCheckDate_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(LastUpdateCheckDate);
		}
		if (PlanIdStr.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(PlanIdStr);
		}
		if (ParentIdStr.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(ParentIdStr);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(PlanningCenterPlan other)
	{
		if (other == null)
		{
			return;
		}
		if (other.PlanIdNum != 0)
		{
			PlanIdNum = other.PlanIdNum;
		}
		if (other.ParentIdNum != 0)
		{
			ParentIdNum = other.ParentIdNum;
		}
		if (other.SeriesTitle.Length != 0)
		{
			SeriesTitle = other.SeriesTitle;
		}
		if (other.PlanTitle.Length != 0)
		{
			PlanTitle = other.PlanTitle;
		}
		if (other.DateList.Length != 0)
		{
			DateList = other.DateList;
		}
		if (other.createdDate_ != null)
		{
			if (createdDate_ == null)
			{
				CreatedDate = new Timestamp();
			}
			CreatedDate.MergeFrom(other.CreatedDate);
		}
		if (other.updateDate_ != null)
		{
			if (updateDate_ == null)
			{
				UpdateDate = new Timestamp();
			}
			UpdateDate.MergeFrom(other.UpdateDate);
		}
		if (other.lastUpdateCheckDate_ != null)
		{
			if (lastUpdateCheckDate_ == null)
			{
				LastUpdateCheckDate = new Timestamp();
			}
			LastUpdateCheckDate.MergeFrom(other.LastUpdateCheckDate);
		}
		if (other.PlanIdStr.Length != 0)
		{
			PlanIdStr = other.PlanIdStr;
		}
		if (other.ParentIdStr.Length != 0)
		{
			ParentIdStr = other.ParentIdStr;
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
				PlanIdNum = input.ReadUInt32();
				break;
			case 16u:
				ParentIdNum = input.ReadUInt32();
				break;
			case 26u:
				SeriesTitle = input.ReadString();
				break;
			case 34u:
				PlanTitle = input.ReadString();
				break;
			case 42u:
				DateList = input.ReadString();
				break;
			case 50u:
				if (createdDate_ == null)
				{
					CreatedDate = new Timestamp();
				}
				input.ReadMessage(CreatedDate);
				break;
			case 58u:
				if (updateDate_ == null)
				{
					UpdateDate = new Timestamp();
				}
				input.ReadMessage(UpdateDate);
				break;
			case 66u:
				if (lastUpdateCheckDate_ == null)
				{
					LastUpdateCheckDate = new Timestamp();
				}
				input.ReadMessage(LastUpdateCheckDate);
				break;
			case 74u:
				PlanIdStr = input.ReadString();
				break;
			case 82u:
				ParentIdStr = input.ReadString();
				break;
			}
		}
	}
}
