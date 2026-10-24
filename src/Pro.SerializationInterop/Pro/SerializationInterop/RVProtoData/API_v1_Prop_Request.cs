using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class API_v1_Prop_Request : IMessage<API_v1_Prop_Request>, IMessage, IEquatable<API_v1_Prop_Request>, IDeepCloneable<API_v1_Prop_Request>
{
	public enum RequestOneofCase
	{
		None,
		Props,
		GetProp,
		PutProp,
		DeleteProp,
		TriggerProp,
		ClearProp,
		GetThumbnail,
		GetPropCollections,
		GetPropCollection,
		PostPropCollections,
		PutPropCollection,
		DeletePropCollection,
		PauseProp,
		ResumeProp
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Props : IMessage<Props>, IMessage, IEquatable<Props>, IDeepCloneable<Props>
		{
			private static readonly MessageParser<Props> _parser = new MessageParser<Props>(() => new Props());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Props> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Prop_Request.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Props()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Props(Props other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Props Clone()
			{
				return new Props(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Props);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Props other)
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
			public void MergeFrom(Props other)
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
		public sealed class GetProp : IMessage<GetProp>, IMessage, IEquatable<GetProp>, IDeepCloneable<GetProp>
		{
			private static readonly MessageParser<GetProp> _parser = new MessageParser<GetProp>(() => new GetProp());

			private UnknownFieldSet _unknownFields;

			public const int IdFieldNumber = 1;

			private string id_ = "";

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GetProp> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Prop_Request.Descriptor.NestedTypes[1];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string Id
			{
				get
				{
					return id_;
				}
				set
				{
					id_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetProp()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetProp(GetProp other)
				: this()
			{
				id_ = other.id_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetProp Clone()
			{
				return new GetProp(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as GetProp);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(GetProp other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (Id != other.Id)
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
				if (Id.Length != 0)
				{
					num ^= Id.GetHashCode();
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
				if (Id.Length != 0)
				{
					output.WriteRawTag(10);
					output.WriteString(Id);
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
				if (Id.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Id);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(GetProp other)
			{
				if (other != null)
				{
					if (other.Id.Length != 0)
					{
						Id = other.Id;
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
						Id = input.ReadString();
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class PutProp : IMessage<PutProp>, IMessage, IEquatable<PutProp>, IDeepCloneable<PutProp>
		{
			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class AutoClearChange : IMessage<AutoClearChange>, IMessage, IEquatable<AutoClearChange>, IDeepCloneable<AutoClearChange>
				{
					private static readonly MessageParser<AutoClearChange> _parser = new MessageParser<AutoClearChange>(() => new AutoClearChange());

					private UnknownFieldSet _unknownFields;

					public const int AutoClearEnabledFieldNumber = 1;

					private bool autoClearEnabled_;

					public const int AutoClearDurationFieldNumber = 2;

					private double autoClearDuration_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<AutoClearChange> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => PutProp.Descriptor.NestedTypes[0];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool AutoClearEnabled
					{
						get
						{
							return autoClearEnabled_;
						}
						set
						{
							autoClearEnabled_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public double AutoClearDuration
					{
						get
						{
							return autoClearDuration_;
						}
						set
						{
							autoClearDuration_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public AutoClearChange()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public AutoClearChange(AutoClearChange other)
						: this()
					{
						autoClearEnabled_ = other.autoClearEnabled_;
						autoClearDuration_ = other.autoClearDuration_;
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public AutoClearChange Clone()
					{
						return new AutoClearChange(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as AutoClearChange);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(AutoClearChange other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (AutoClearEnabled != other.AutoClearEnabled)
						{
							return false;
						}
						if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(AutoClearDuration, other.AutoClearDuration))
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
						if (AutoClearEnabled)
						{
							num ^= AutoClearEnabled.GetHashCode();
						}
						if (AutoClearDuration != 0.0)
						{
							num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(AutoClearDuration);
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
						if (AutoClearEnabled)
						{
							output.WriteRawTag(8);
							output.WriteBool(AutoClearEnabled);
						}
						if (AutoClearDuration != 0.0)
						{
							output.WriteRawTag(17);
							output.WriteDouble(AutoClearDuration);
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
						if (AutoClearEnabled)
						{
							num += 2;
						}
						if (AutoClearDuration != 0.0)
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
					public void MergeFrom(AutoClearChange other)
					{
						if (other != null)
						{
							if (other.AutoClearEnabled)
							{
								AutoClearEnabled = other.AutoClearEnabled;
							}
							if (other.AutoClearDuration != 0.0)
							{
								AutoClearDuration = other.AutoClearDuration;
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
								AutoClearEnabled = input.ReadBool();
								break;
							case 17u:
								AutoClearDuration = input.ReadDouble();
								break;
							}
						}
					}
				}
			}

			private static readonly MessageParser<PutProp> _parser = new MessageParser<PutProp>(() => new PutProp());

			private UnknownFieldSet _unknownFields;

			public const int IdFieldNumber = 1;

			private string id_ = "";

			public const int NameChangeFieldNumber = 2;

			private string nameChange_ = "";

			public const int AutoClearChangeFieldNumber = 3;

			private Types.AutoClearChange autoClearChange_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<PutProp> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Prop_Request.Descriptor.NestedTypes[2];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string Id
			{
				get
				{
					return id_;
				}
				set
				{
					id_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string NameChange
			{
				get
				{
					return nameChange_;
				}
				set
				{
					nameChange_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.AutoClearChange AutoClearChange
			{
				get
				{
					return autoClearChange_;
				}
				set
				{
					autoClearChange_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PutProp()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PutProp(PutProp other)
				: this()
			{
				id_ = other.id_;
				nameChange_ = other.nameChange_;
				autoClearChange_ = ((other.autoClearChange_ != null) ? other.autoClearChange_.Clone() : null);
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PutProp Clone()
			{
				return new PutProp(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as PutProp);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(PutProp other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (Id != other.Id)
				{
					return false;
				}
				if (NameChange != other.NameChange)
				{
					return false;
				}
				if (!object.Equals(AutoClearChange, other.AutoClearChange))
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
				if (Id.Length != 0)
				{
					num ^= Id.GetHashCode();
				}
				if (NameChange.Length != 0)
				{
					num ^= NameChange.GetHashCode();
				}
				if (autoClearChange_ != null)
				{
					num ^= AutoClearChange.GetHashCode();
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
				if (Id.Length != 0)
				{
					output.WriteRawTag(10);
					output.WriteString(Id);
				}
				if (NameChange.Length != 0)
				{
					output.WriteRawTag(18);
					output.WriteString(NameChange);
				}
				if (autoClearChange_ != null)
				{
					output.WriteRawTag(26);
					output.WriteMessage(AutoClearChange);
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
				if (Id.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Id);
				}
				if (NameChange.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(NameChange);
				}
				if (autoClearChange_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(AutoClearChange);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(PutProp other)
			{
				if (other == null)
				{
					return;
				}
				if (other.Id.Length != 0)
				{
					Id = other.Id;
				}
				if (other.NameChange.Length != 0)
				{
					NameChange = other.NameChange;
				}
				if (other.autoClearChange_ != null)
				{
					if (autoClearChange_ == null)
					{
						AutoClearChange = new Types.AutoClearChange();
					}
					AutoClearChange.MergeFrom(other.AutoClearChange);
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
						Id = input.ReadString();
						break;
					case 18u:
						NameChange = input.ReadString();
						break;
					case 26u:
						if (autoClearChange_ == null)
						{
							AutoClearChange = new Types.AutoClearChange();
						}
						input.ReadMessage(AutoClearChange);
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class DeleteProp : IMessage<DeleteProp>, IMessage, IEquatable<DeleteProp>, IDeepCloneable<DeleteProp>
		{
			private static readonly MessageParser<DeleteProp> _parser = new MessageParser<DeleteProp>(() => new DeleteProp());

			private UnknownFieldSet _unknownFields;

			public const int IdFieldNumber = 1;

			private string id_ = "";

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<DeleteProp> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Prop_Request.Descriptor.NestedTypes[3];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string Id
			{
				get
				{
					return id_;
				}
				set
				{
					id_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public DeleteProp()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public DeleteProp(DeleteProp other)
				: this()
			{
				id_ = other.id_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public DeleteProp Clone()
			{
				return new DeleteProp(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as DeleteProp);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(DeleteProp other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (Id != other.Id)
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
				if (Id.Length != 0)
				{
					num ^= Id.GetHashCode();
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
				if (Id.Length != 0)
				{
					output.WriteRawTag(10);
					output.WriteString(Id);
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
				if (Id.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Id);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(DeleteProp other)
			{
				if (other != null)
				{
					if (other.Id.Length != 0)
					{
						Id = other.Id;
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
						Id = input.ReadString();
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class TriggerProp : IMessage<TriggerProp>, IMessage, IEquatable<TriggerProp>, IDeepCloneable<TriggerProp>
		{
			private static readonly MessageParser<TriggerProp> _parser = new MessageParser<TriggerProp>(() => new TriggerProp());

			private UnknownFieldSet _unknownFields;

			public const int IdFieldNumber = 1;

			private string id_ = "";

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<TriggerProp> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Prop_Request.Descriptor.NestedTypes[4];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string Id
			{
				get
				{
					return id_;
				}
				set
				{
					id_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TriggerProp()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TriggerProp(TriggerProp other)
				: this()
			{
				id_ = other.id_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TriggerProp Clone()
			{
				return new TriggerProp(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as TriggerProp);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(TriggerProp other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (Id != other.Id)
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
				if (Id.Length != 0)
				{
					num ^= Id.GetHashCode();
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
				if (Id.Length != 0)
				{
					output.WriteRawTag(10);
					output.WriteString(Id);
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
				if (Id.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Id);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(TriggerProp other)
			{
				if (other != null)
				{
					if (other.Id.Length != 0)
					{
						Id = other.Id;
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
						Id = input.ReadString();
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class ClearProp : IMessage<ClearProp>, IMessage, IEquatable<ClearProp>, IDeepCloneable<ClearProp>
		{
			private static readonly MessageParser<ClearProp> _parser = new MessageParser<ClearProp>(() => new ClearProp());

			private UnknownFieldSet _unknownFields;

			public const int IdFieldNumber = 1;

			private string id_ = "";

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<ClearProp> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Prop_Request.Descriptor.NestedTypes[5];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string Id
			{
				get
				{
					return id_;
				}
				set
				{
					id_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ClearProp()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ClearProp(ClearProp other)
				: this()
			{
				id_ = other.id_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ClearProp Clone()
			{
				return new ClearProp(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as ClearProp);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(ClearProp other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (Id != other.Id)
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
				if (Id.Length != 0)
				{
					num ^= Id.GetHashCode();
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
				if (Id.Length != 0)
				{
					output.WriteRawTag(10);
					output.WriteString(Id);
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
				if (Id.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Id);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(ClearProp other)
			{
				if (other != null)
				{
					if (other.Id.Length != 0)
					{
						Id = other.Id;
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
						Id = input.ReadString();
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class PauseProp : IMessage<PauseProp>, IMessage, IEquatable<PauseProp>, IDeepCloneable<PauseProp>
		{
			private static readonly MessageParser<PauseProp> _parser = new MessageParser<PauseProp>(() => new PauseProp());

			private UnknownFieldSet _unknownFields;

			public const int IdFieldNumber = 1;

			private string id_ = "";

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<PauseProp> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Prop_Request.Descriptor.NestedTypes[6];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string Id
			{
				get
				{
					return id_;
				}
				set
				{
					id_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PauseProp()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PauseProp(PauseProp other)
				: this()
			{
				id_ = other.id_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PauseProp Clone()
			{
				return new PauseProp(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as PauseProp);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(PauseProp other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (Id != other.Id)
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
				if (Id.Length != 0)
				{
					num ^= Id.GetHashCode();
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
				if (Id.Length != 0)
				{
					output.WriteRawTag(10);
					output.WriteString(Id);
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
				if (Id.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Id);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(PauseProp other)
			{
				if (other != null)
				{
					if (other.Id.Length != 0)
					{
						Id = other.Id;
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
						Id = input.ReadString();
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class ResumeProp : IMessage<ResumeProp>, IMessage, IEquatable<ResumeProp>, IDeepCloneable<ResumeProp>
		{
			private static readonly MessageParser<ResumeProp> _parser = new MessageParser<ResumeProp>(() => new ResumeProp());

			private UnknownFieldSet _unknownFields;

			public const int IdFieldNumber = 1;

			private string id_ = "";

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<ResumeProp> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Prop_Request.Descriptor.NestedTypes[7];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string Id
			{
				get
				{
					return id_;
				}
				set
				{
					id_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ResumeProp()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ResumeProp(ResumeProp other)
				: this()
			{
				id_ = other.id_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ResumeProp Clone()
			{
				return new ResumeProp(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as ResumeProp);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(ResumeProp other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (Id != other.Id)
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
				if (Id.Length != 0)
				{
					num ^= Id.GetHashCode();
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
				if (Id.Length != 0)
				{
					output.WriteRawTag(10);
					output.WriteString(Id);
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
				if (Id.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Id);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(ResumeProp other)
			{
				if (other != null)
				{
					if (other.Id.Length != 0)
					{
						Id = other.Id;
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
						Id = input.ReadString();
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class GetThumbnail : IMessage<GetThumbnail>, IMessage, IEquatable<GetThumbnail>, IDeepCloneable<GetThumbnail>
		{
			private static readonly MessageParser<GetThumbnail> _parser = new MessageParser<GetThumbnail>(() => new GetThumbnail());

			private UnknownFieldSet _unknownFields;

			public const int IdFieldNumber = 1;

			private string id_ = "";

			public const int QualityFieldNumber = 2;

			private int quality_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GetThumbnail> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Prop_Request.Descriptor.NestedTypes[8];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string Id
			{
				get
				{
					return id_;
				}
				set
				{
					id_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public int Quality
			{
				get
				{
					return quality_;
				}
				set
				{
					quality_ = value;
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
				id_ = other.id_;
				quality_ = other.quality_;
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
				if (Id != other.Id)
				{
					return false;
				}
				if (Quality != other.Quality)
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
				if (Id.Length != 0)
				{
					num ^= Id.GetHashCode();
				}
				if (Quality != 0)
				{
					num ^= Quality.GetHashCode();
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
				if (Id.Length != 0)
				{
					output.WriteRawTag(10);
					output.WriteString(Id);
				}
				if (Quality != 0)
				{
					output.WriteRawTag(16);
					output.WriteInt32(Quality);
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
				if (Id.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Id);
				}
				if (Quality != 0)
				{
					num += 1 + CodedOutputStream.ComputeInt32Size(Quality);
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
				if (other != null)
				{
					if (other.Id.Length != 0)
					{
						Id = other.Id;
					}
					if (other.Quality != 0)
					{
						Quality = other.Quality;
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
					case 10u:
						Id = input.ReadString();
						break;
					case 16u:
						Quality = input.ReadInt32();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class GetPropCollections : IMessage<GetPropCollections>, IMessage, IEquatable<GetPropCollections>, IDeepCloneable<GetPropCollections>
		{
			private static readonly MessageParser<GetPropCollections> _parser = new MessageParser<GetPropCollections>(() => new GetPropCollections());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GetPropCollections> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Prop_Request.Descriptor.NestedTypes[9];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetPropCollections()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetPropCollections(GetPropCollections other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetPropCollections Clone()
			{
				return new GetPropCollections(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as GetPropCollections);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(GetPropCollections other)
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
			public void MergeFrom(GetPropCollections other)
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
		public sealed class GetPropCollection : IMessage<GetPropCollection>, IMessage, IEquatable<GetPropCollection>, IDeepCloneable<GetPropCollection>
		{
			private static readonly MessageParser<GetPropCollection> _parser = new MessageParser<GetPropCollection>(() => new GetPropCollection());

			private UnknownFieldSet _unknownFields;

			public const int IdFieldNumber = 1;

			private string id_ = "";

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GetPropCollection> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Prop_Request.Descriptor.NestedTypes[10];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string Id
			{
				get
				{
					return id_;
				}
				set
				{
					id_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetPropCollection()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetPropCollection(GetPropCollection other)
				: this()
			{
				id_ = other.id_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetPropCollection Clone()
			{
				return new GetPropCollection(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as GetPropCollection);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(GetPropCollection other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (Id != other.Id)
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
				if (Id.Length != 0)
				{
					num ^= Id.GetHashCode();
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
				if (Id.Length != 0)
				{
					output.WriteRawTag(10);
					output.WriteString(Id);
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
				if (Id.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Id);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(GetPropCollection other)
			{
				if (other != null)
				{
					if (other.Id.Length != 0)
					{
						Id = other.Id;
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
						Id = input.ReadString();
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class PostPropCollections : IMessage<PostPropCollections>, IMessage, IEquatable<PostPropCollections>, IDeepCloneable<PostPropCollections>
		{
			private static readonly MessageParser<PostPropCollections> _parser = new MessageParser<PostPropCollections>(() => new PostPropCollections());

			private UnknownFieldSet _unknownFields;

			public const int NameFieldNumber = 1;

			private string name_ = "";

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<PostPropCollections> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Prop_Request.Descriptor.NestedTypes[11];

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
			public PostPropCollections()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PostPropCollections(PostPropCollections other)
				: this()
			{
				name_ = other.name_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PostPropCollections Clone()
			{
				return new PostPropCollections(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as PostPropCollections);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(PostPropCollections other)
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
			public void MergeFrom(PostPropCollections other)
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
		public sealed class PutPropCollection : IMessage<PutPropCollection>, IMessage, IEquatable<PutPropCollection>, IDeepCloneable<PutPropCollection>
		{
			private static readonly MessageParser<PutPropCollection> _parser = new MessageParser<PutPropCollection>(() => new PutPropCollection());

			private UnknownFieldSet _unknownFields;

			public const int IdFieldNumber = 1;

			private string id_ = "";

			public const int ChangesFieldNumber = 2;

			private API_v1_PropCollection changes_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<PutPropCollection> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Prop_Request.Descriptor.NestedTypes[12];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string Id
			{
				get
				{
					return id_;
				}
				set
				{
					id_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_PropCollection Changes
			{
				get
				{
					return changes_;
				}
				set
				{
					changes_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PutPropCollection()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PutPropCollection(PutPropCollection other)
				: this()
			{
				id_ = other.id_;
				changes_ = ((other.changes_ != null) ? other.changes_.Clone() : null);
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PutPropCollection Clone()
			{
				return new PutPropCollection(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as PutPropCollection);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(PutPropCollection other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (Id != other.Id)
				{
					return false;
				}
				if (!object.Equals(Changes, other.Changes))
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
				if (Id.Length != 0)
				{
					num ^= Id.GetHashCode();
				}
				if (changes_ != null)
				{
					num ^= Changes.GetHashCode();
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
				if (Id.Length != 0)
				{
					output.WriteRawTag(10);
					output.WriteString(Id);
				}
				if (changes_ != null)
				{
					output.WriteRawTag(18);
					output.WriteMessage(Changes);
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
				if (Id.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Id);
				}
				if (changes_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Changes);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(PutPropCollection other)
			{
				if (other == null)
				{
					return;
				}
				if (other.Id.Length != 0)
				{
					Id = other.Id;
				}
				if (other.changes_ != null)
				{
					if (changes_ == null)
					{
						Changes = new API_v1_PropCollection();
					}
					Changes.MergeFrom(other.Changes);
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
						Id = input.ReadString();
						break;
					case 18u:
						if (changes_ == null)
						{
							Changes = new API_v1_PropCollection();
						}
						input.ReadMessage(Changes);
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class DeletePropCollection : IMessage<DeletePropCollection>, IMessage, IEquatable<DeletePropCollection>, IDeepCloneable<DeletePropCollection>
		{
			private static readonly MessageParser<DeletePropCollection> _parser = new MessageParser<DeletePropCollection>(() => new DeletePropCollection());

			private UnknownFieldSet _unknownFields;

			public const int IdFieldNumber = 1;

			private string id_ = "";

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<DeletePropCollection> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Prop_Request.Descriptor.NestedTypes[13];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string Id
			{
				get
				{
					return id_;
				}
				set
				{
					id_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public DeletePropCollection()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public DeletePropCollection(DeletePropCollection other)
				: this()
			{
				id_ = other.id_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public DeletePropCollection Clone()
			{
				return new DeletePropCollection(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as DeletePropCollection);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(DeletePropCollection other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (Id != other.Id)
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
				if (Id.Length != 0)
				{
					num ^= Id.GetHashCode();
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
				if (Id.Length != 0)
				{
					output.WriteRawTag(10);
					output.WriteString(Id);
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
				if (Id.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Id);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(DeletePropCollection other)
			{
				if (other != null)
				{
					if (other.Id.Length != 0)
					{
						Id = other.Id;
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
						Id = input.ReadString();
					}
				}
			}
		}
	}

	private static readonly MessageParser<API_v1_Prop_Request> _parser = new MessageParser<API_v1_Prop_Request>(() => new API_v1_Prop_Request());

	private UnknownFieldSet _unknownFields;

	public const int PropsFieldNumber = 1;

	public const int GetPropFieldNumber = 2;

	public const int PutPropFieldNumber = 3;

	public const int DeletePropFieldNumber = 4;

	public const int TriggerPropFieldNumber = 5;

	public const int ClearPropFieldNumber = 6;

	public const int GetThumbnailFieldNumber = 7;

	public const int GetPropCollectionsFieldNumber = 8;

	public const int GetPropCollectionFieldNumber = 9;

	public const int PostPropCollectionsFieldNumber = 10;

	public const int PutPropCollectionFieldNumber = 11;

	public const int DeletePropCollectionFieldNumber = 12;

	public const int PausePropFieldNumber = 13;

	public const int ResumePropFieldNumber = 14;

	private object request_;

	private RequestOneofCase requestCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<API_v1_Prop_Request> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProApiV1PropReflection.Descriptor.MessageTypes[3];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Props Props
	{
		get
		{
			if (requestCase_ != RequestOneofCase.Props)
			{
				return null;
			}
			return (Types.Props)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.Props : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.GetProp GetProp
	{
		get
		{
			if (requestCase_ != RequestOneofCase.GetProp)
			{
				return null;
			}
			return (Types.GetProp)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.GetProp : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.PutProp PutProp
	{
		get
		{
			if (requestCase_ != RequestOneofCase.PutProp)
			{
				return null;
			}
			return (Types.PutProp)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.PutProp : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.DeleteProp DeleteProp
	{
		get
		{
			if (requestCase_ != RequestOneofCase.DeleteProp)
			{
				return null;
			}
			return (Types.DeleteProp)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.DeleteProp : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.TriggerProp TriggerProp
	{
		get
		{
			if (requestCase_ != RequestOneofCase.TriggerProp)
			{
				return null;
			}
			return (Types.TriggerProp)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.TriggerProp : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.ClearProp ClearProp
	{
		get
		{
			if (requestCase_ != RequestOneofCase.ClearProp)
			{
				return null;
			}
			return (Types.ClearProp)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.ClearProp : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.GetThumbnail GetThumbnail
	{
		get
		{
			if (requestCase_ != RequestOneofCase.GetThumbnail)
			{
				return null;
			}
			return (Types.GetThumbnail)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.GetThumbnail : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.GetPropCollections GetPropCollections
	{
		get
		{
			if (requestCase_ != RequestOneofCase.GetPropCollections)
			{
				return null;
			}
			return (Types.GetPropCollections)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.GetPropCollections : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.GetPropCollection GetPropCollection
	{
		get
		{
			if (requestCase_ != RequestOneofCase.GetPropCollection)
			{
				return null;
			}
			return (Types.GetPropCollection)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.GetPropCollection : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.PostPropCollections PostPropCollections
	{
		get
		{
			if (requestCase_ != RequestOneofCase.PostPropCollections)
			{
				return null;
			}
			return (Types.PostPropCollections)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.PostPropCollections : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.PutPropCollection PutPropCollection
	{
		get
		{
			if (requestCase_ != RequestOneofCase.PutPropCollection)
			{
				return null;
			}
			return (Types.PutPropCollection)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.PutPropCollection : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.DeletePropCollection DeletePropCollection
	{
		get
		{
			if (requestCase_ != RequestOneofCase.DeletePropCollection)
			{
				return null;
			}
			return (Types.DeletePropCollection)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.DeletePropCollection : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.PauseProp PauseProp
	{
		get
		{
			if (requestCase_ != RequestOneofCase.PauseProp)
			{
				return null;
			}
			return (Types.PauseProp)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.PauseProp : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.ResumeProp ResumeProp
	{
		get
		{
			if (requestCase_ != RequestOneofCase.ResumeProp)
			{
				return null;
			}
			return (Types.ResumeProp)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.ResumeProp : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RequestOneofCase RequestCase => requestCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Prop_Request()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Prop_Request(API_v1_Prop_Request other)
		: this()
	{
		switch (other.RequestCase)
		{
		case RequestOneofCase.Props:
			Props = other.Props.Clone();
			break;
		case RequestOneofCase.GetProp:
			GetProp = other.GetProp.Clone();
			break;
		case RequestOneofCase.PutProp:
			PutProp = other.PutProp.Clone();
			break;
		case RequestOneofCase.DeleteProp:
			DeleteProp = other.DeleteProp.Clone();
			break;
		case RequestOneofCase.TriggerProp:
			TriggerProp = other.TriggerProp.Clone();
			break;
		case RequestOneofCase.ClearProp:
			ClearProp = other.ClearProp.Clone();
			break;
		case RequestOneofCase.GetThumbnail:
			GetThumbnail = other.GetThumbnail.Clone();
			break;
		case RequestOneofCase.GetPropCollections:
			GetPropCollections = other.GetPropCollections.Clone();
			break;
		case RequestOneofCase.GetPropCollection:
			GetPropCollection = other.GetPropCollection.Clone();
			break;
		case RequestOneofCase.PostPropCollections:
			PostPropCollections = other.PostPropCollections.Clone();
			break;
		case RequestOneofCase.PutPropCollection:
			PutPropCollection = other.PutPropCollection.Clone();
			break;
		case RequestOneofCase.DeletePropCollection:
			DeletePropCollection = other.DeletePropCollection.Clone();
			break;
		case RequestOneofCase.PauseProp:
			PauseProp = other.PauseProp.Clone();
			break;
		case RequestOneofCase.ResumeProp:
			ResumeProp = other.ResumeProp.Clone();
			break;
		}
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Prop_Request Clone()
	{
		return new API_v1_Prop_Request(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void ClearRequest()
	{
		requestCase_ = RequestOneofCase.None;
		request_ = null;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as API_v1_Prop_Request);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(API_v1_Prop_Request other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(Props, other.Props))
		{
			return false;
		}
		if (!object.Equals(GetProp, other.GetProp))
		{
			return false;
		}
		if (!object.Equals(PutProp, other.PutProp))
		{
			return false;
		}
		if (!object.Equals(DeleteProp, other.DeleteProp))
		{
			return false;
		}
		if (!object.Equals(TriggerProp, other.TriggerProp))
		{
			return false;
		}
		if (!object.Equals(ClearProp, other.ClearProp))
		{
			return false;
		}
		if (!object.Equals(GetThumbnail, other.GetThumbnail))
		{
			return false;
		}
		if (!object.Equals(GetPropCollections, other.GetPropCollections))
		{
			return false;
		}
		if (!object.Equals(GetPropCollection, other.GetPropCollection))
		{
			return false;
		}
		if (!object.Equals(PostPropCollections, other.PostPropCollections))
		{
			return false;
		}
		if (!object.Equals(PutPropCollection, other.PutPropCollection))
		{
			return false;
		}
		if (!object.Equals(DeletePropCollection, other.DeletePropCollection))
		{
			return false;
		}
		if (!object.Equals(PauseProp, other.PauseProp))
		{
			return false;
		}
		if (!object.Equals(ResumeProp, other.ResumeProp))
		{
			return false;
		}
		if (RequestCase != other.RequestCase)
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
		if (requestCase_ == RequestOneofCase.Props)
		{
			num ^= Props.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.GetProp)
		{
			num ^= GetProp.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.PutProp)
		{
			num ^= PutProp.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.DeleteProp)
		{
			num ^= DeleteProp.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.TriggerProp)
		{
			num ^= TriggerProp.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.ClearProp)
		{
			num ^= ClearProp.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.GetThumbnail)
		{
			num ^= GetThumbnail.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.GetPropCollections)
		{
			num ^= GetPropCollections.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.GetPropCollection)
		{
			num ^= GetPropCollection.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.PostPropCollections)
		{
			num ^= PostPropCollections.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.PutPropCollection)
		{
			num ^= PutPropCollection.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.DeletePropCollection)
		{
			num ^= DeletePropCollection.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.PauseProp)
		{
			num ^= PauseProp.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.ResumeProp)
		{
			num ^= ResumeProp.GetHashCode();
		}
		num ^= (int)requestCase_;
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
		if (requestCase_ == RequestOneofCase.Props)
		{
			output.WriteRawTag(10);
			output.WriteMessage(Props);
		}
		if (requestCase_ == RequestOneofCase.GetProp)
		{
			output.WriteRawTag(18);
			output.WriteMessage(GetProp);
		}
		if (requestCase_ == RequestOneofCase.PutProp)
		{
			output.WriteRawTag(26);
			output.WriteMessage(PutProp);
		}
		if (requestCase_ == RequestOneofCase.DeleteProp)
		{
			output.WriteRawTag(34);
			output.WriteMessage(DeleteProp);
		}
		if (requestCase_ == RequestOneofCase.TriggerProp)
		{
			output.WriteRawTag(42);
			output.WriteMessage(TriggerProp);
		}
		if (requestCase_ == RequestOneofCase.ClearProp)
		{
			output.WriteRawTag(50);
			output.WriteMessage(ClearProp);
		}
		if (requestCase_ == RequestOneofCase.GetThumbnail)
		{
			output.WriteRawTag(58);
			output.WriteMessage(GetThumbnail);
		}
		if (requestCase_ == RequestOneofCase.GetPropCollections)
		{
			output.WriteRawTag(66);
			output.WriteMessage(GetPropCollections);
		}
		if (requestCase_ == RequestOneofCase.GetPropCollection)
		{
			output.WriteRawTag(74);
			output.WriteMessage(GetPropCollection);
		}
		if (requestCase_ == RequestOneofCase.PostPropCollections)
		{
			output.WriteRawTag(82);
			output.WriteMessage(PostPropCollections);
		}
		if (requestCase_ == RequestOneofCase.PutPropCollection)
		{
			output.WriteRawTag(90);
			output.WriteMessage(PutPropCollection);
		}
		if (requestCase_ == RequestOneofCase.DeletePropCollection)
		{
			output.WriteRawTag(98);
			output.WriteMessage(DeletePropCollection);
		}
		if (requestCase_ == RequestOneofCase.PauseProp)
		{
			output.WriteRawTag(106);
			output.WriteMessage(PauseProp);
		}
		if (requestCase_ == RequestOneofCase.ResumeProp)
		{
			output.WriteRawTag(114);
			output.WriteMessage(ResumeProp);
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
		if (requestCase_ == RequestOneofCase.Props)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Props);
		}
		if (requestCase_ == RequestOneofCase.GetProp)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GetProp);
		}
		if (requestCase_ == RequestOneofCase.PutProp)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PutProp);
		}
		if (requestCase_ == RequestOneofCase.DeleteProp)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(DeleteProp);
		}
		if (requestCase_ == RequestOneofCase.TriggerProp)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(TriggerProp);
		}
		if (requestCase_ == RequestOneofCase.ClearProp)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(ClearProp);
		}
		if (requestCase_ == RequestOneofCase.GetThumbnail)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GetThumbnail);
		}
		if (requestCase_ == RequestOneofCase.GetPropCollections)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GetPropCollections);
		}
		if (requestCase_ == RequestOneofCase.GetPropCollection)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GetPropCollection);
		}
		if (requestCase_ == RequestOneofCase.PostPropCollections)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PostPropCollections);
		}
		if (requestCase_ == RequestOneofCase.PutPropCollection)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PutPropCollection);
		}
		if (requestCase_ == RequestOneofCase.DeletePropCollection)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(DeletePropCollection);
		}
		if (requestCase_ == RequestOneofCase.PauseProp)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PauseProp);
		}
		if (requestCase_ == RequestOneofCase.ResumeProp)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(ResumeProp);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(API_v1_Prop_Request other)
	{
		if (other == null)
		{
			return;
		}
		switch (other.RequestCase)
		{
		case RequestOneofCase.Props:
			if (Props == null)
			{
				Props = new Types.Props();
			}
			Props.MergeFrom(other.Props);
			break;
		case RequestOneofCase.GetProp:
			if (GetProp == null)
			{
				GetProp = new Types.GetProp();
			}
			GetProp.MergeFrom(other.GetProp);
			break;
		case RequestOneofCase.PutProp:
			if (PutProp == null)
			{
				PutProp = new Types.PutProp();
			}
			PutProp.MergeFrom(other.PutProp);
			break;
		case RequestOneofCase.DeleteProp:
			if (DeleteProp == null)
			{
				DeleteProp = new Types.DeleteProp();
			}
			DeleteProp.MergeFrom(other.DeleteProp);
			break;
		case RequestOneofCase.TriggerProp:
			if (TriggerProp == null)
			{
				TriggerProp = new Types.TriggerProp();
			}
			TriggerProp.MergeFrom(other.TriggerProp);
			break;
		case RequestOneofCase.ClearProp:
			if (ClearProp == null)
			{
				ClearProp = new Types.ClearProp();
			}
			ClearProp.MergeFrom(other.ClearProp);
			break;
		case RequestOneofCase.GetThumbnail:
			if (GetThumbnail == null)
			{
				GetThumbnail = new Types.GetThumbnail();
			}
			GetThumbnail.MergeFrom(other.GetThumbnail);
			break;
		case RequestOneofCase.GetPropCollections:
			if (GetPropCollections == null)
			{
				GetPropCollections = new Types.GetPropCollections();
			}
			GetPropCollections.MergeFrom(other.GetPropCollections);
			break;
		case RequestOneofCase.GetPropCollection:
			if (GetPropCollection == null)
			{
				GetPropCollection = new Types.GetPropCollection();
			}
			GetPropCollection.MergeFrom(other.GetPropCollection);
			break;
		case RequestOneofCase.PostPropCollections:
			if (PostPropCollections == null)
			{
				PostPropCollections = new Types.PostPropCollections();
			}
			PostPropCollections.MergeFrom(other.PostPropCollections);
			break;
		case RequestOneofCase.PutPropCollection:
			if (PutPropCollection == null)
			{
				PutPropCollection = new Types.PutPropCollection();
			}
			PutPropCollection.MergeFrom(other.PutPropCollection);
			break;
		case RequestOneofCase.DeletePropCollection:
			if (DeletePropCollection == null)
			{
				DeletePropCollection = new Types.DeletePropCollection();
			}
			DeletePropCollection.MergeFrom(other.DeletePropCollection);
			break;
		case RequestOneofCase.PauseProp:
			if (PauseProp == null)
			{
				PauseProp = new Types.PauseProp();
			}
			PauseProp.MergeFrom(other.PauseProp);
			break;
		case RequestOneofCase.ResumeProp:
			if (ResumeProp == null)
			{
				ResumeProp = new Types.ResumeProp();
			}
			ResumeProp.MergeFrom(other.ResumeProp);
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
				Types.Props props = new Types.Props();
				if (requestCase_ == RequestOneofCase.Props)
				{
					props.MergeFrom(Props);
				}
				input.ReadMessage(props);
				Props = props;
				break;
			}
			case 18u:
			{
				Types.GetProp getProp = new Types.GetProp();
				if (requestCase_ == RequestOneofCase.GetProp)
				{
					getProp.MergeFrom(GetProp);
				}
				input.ReadMessage(getProp);
				GetProp = getProp;
				break;
			}
			case 26u:
			{
				Types.PutProp putProp = new Types.PutProp();
				if (requestCase_ == RequestOneofCase.PutProp)
				{
					putProp.MergeFrom(PutProp);
				}
				input.ReadMessage(putProp);
				PutProp = putProp;
				break;
			}
			case 34u:
			{
				Types.DeleteProp deleteProp = new Types.DeleteProp();
				if (requestCase_ == RequestOneofCase.DeleteProp)
				{
					deleteProp.MergeFrom(DeleteProp);
				}
				input.ReadMessage(deleteProp);
				DeleteProp = deleteProp;
				break;
			}
			case 42u:
			{
				Types.TriggerProp triggerProp = new Types.TriggerProp();
				if (requestCase_ == RequestOneofCase.TriggerProp)
				{
					triggerProp.MergeFrom(TriggerProp);
				}
				input.ReadMessage(triggerProp);
				TriggerProp = triggerProp;
				break;
			}
			case 50u:
			{
				Types.ClearProp clearProp = new Types.ClearProp();
				if (requestCase_ == RequestOneofCase.ClearProp)
				{
					clearProp.MergeFrom(ClearProp);
				}
				input.ReadMessage(clearProp);
				ClearProp = clearProp;
				break;
			}
			case 58u:
			{
				Types.GetThumbnail getThumbnail = new Types.GetThumbnail();
				if (requestCase_ == RequestOneofCase.GetThumbnail)
				{
					getThumbnail.MergeFrom(GetThumbnail);
				}
				input.ReadMessage(getThumbnail);
				GetThumbnail = getThumbnail;
				break;
			}
			case 66u:
			{
				Types.GetPropCollections getPropCollections = new Types.GetPropCollections();
				if (requestCase_ == RequestOneofCase.GetPropCollections)
				{
					getPropCollections.MergeFrom(GetPropCollections);
				}
				input.ReadMessage(getPropCollections);
				GetPropCollections = getPropCollections;
				break;
			}
			case 74u:
			{
				Types.GetPropCollection getPropCollection = new Types.GetPropCollection();
				if (requestCase_ == RequestOneofCase.GetPropCollection)
				{
					getPropCollection.MergeFrom(GetPropCollection);
				}
				input.ReadMessage(getPropCollection);
				GetPropCollection = getPropCollection;
				break;
			}
			case 82u:
			{
				Types.PostPropCollections postPropCollections = new Types.PostPropCollections();
				if (requestCase_ == RequestOneofCase.PostPropCollections)
				{
					postPropCollections.MergeFrom(PostPropCollections);
				}
				input.ReadMessage(postPropCollections);
				PostPropCollections = postPropCollections;
				break;
			}
			case 90u:
			{
				Types.PutPropCollection putPropCollection = new Types.PutPropCollection();
				if (requestCase_ == RequestOneofCase.PutPropCollection)
				{
					putPropCollection.MergeFrom(PutPropCollection);
				}
				input.ReadMessage(putPropCollection);
				PutPropCollection = putPropCollection;
				break;
			}
			case 98u:
			{
				Types.DeletePropCollection deletePropCollection = new Types.DeletePropCollection();
				if (requestCase_ == RequestOneofCase.DeletePropCollection)
				{
					deletePropCollection.MergeFrom(DeletePropCollection);
				}
				input.ReadMessage(deletePropCollection);
				DeletePropCollection = deletePropCollection;
				break;
			}
			case 106u:
			{
				Types.PauseProp pauseProp = new Types.PauseProp();
				if (requestCase_ == RequestOneofCase.PauseProp)
				{
					pauseProp.MergeFrom(PauseProp);
				}
				input.ReadMessage(pauseProp);
				PauseProp = pauseProp;
				break;
			}
			case 114u:
			{
				Types.ResumeProp resumeProp = new Types.ResumeProp();
				if (requestCase_ == RequestOneofCase.ResumeProp)
				{
					resumeProp.MergeFrom(ResumeProp);
				}
				input.ReadMessage(resumeProp);
				ResumeProp = resumeProp;
				break;
			}
			}
		}
	}
}
