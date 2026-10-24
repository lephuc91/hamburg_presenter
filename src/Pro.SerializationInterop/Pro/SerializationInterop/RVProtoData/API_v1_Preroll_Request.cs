using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class API_v1_Preroll_Request : IMessage<API_v1_Preroll_Request>, IMessage, IEquatable<API_v1_Preroll_Request>, IDeepCloneable<API_v1_Preroll_Request>
{
	public enum RequestOneofCase
	{
		None,
		PrerollCue,
		PrerollPlaylistItem,
		PrerollMediaItem,
		PrerollAudioItem,
		PrerollVideoInput,
		PrerollLibraryItem,
		PrerollNext,
		PrerollPrevious,
		ActivatePrerollItem,
		CancelPrerollItem
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class PrerollCue : IMessage<PrerollCue>, IMessage, IEquatable<PrerollCue>, IDeepCloneable<PrerollCue>
		{
			private static readonly MessageParser<PrerollCue> _parser = new MessageParser<PrerollCue>(() => new PrerollCue());

			private UnknownFieldSet _unknownFields;

			public const int IndexFieldNumber = 1;

			private int index_;

			public const int PrerollIdFieldNumber = 2;

			private ulong prerollId_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<PrerollCue> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Preroll_Request.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public int Index
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
			public ulong PrerollId
			{
				get
				{
					return prerollId_;
				}
				set
				{
					prerollId_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PrerollCue()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PrerollCue(PrerollCue other)
				: this()
			{
				index_ = other.index_;
				prerollId_ = other.prerollId_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PrerollCue Clone()
			{
				return new PrerollCue(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as PrerollCue);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(PrerollCue other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (Index != other.Index)
				{
					return false;
				}
				if (PrerollId != other.PrerollId)
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
				if (Index != 0)
				{
					num ^= Index.GetHashCode();
				}
				if (PrerollId != 0L)
				{
					num ^= PrerollId.GetHashCode();
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
				if (Index != 0)
				{
					output.WriteRawTag(8);
					output.WriteInt32(Index);
				}
				if (PrerollId != 0L)
				{
					output.WriteRawTag(16);
					output.WriteUInt64(PrerollId);
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
				if (Index != 0)
				{
					num += 1 + CodedOutputStream.ComputeInt32Size(Index);
				}
				if (PrerollId != 0L)
				{
					num += 1 + CodedOutputStream.ComputeUInt64Size(PrerollId);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(PrerollCue other)
			{
				if (other != null)
				{
					if (other.Index != 0)
					{
						Index = other.Index;
					}
					if (other.PrerollId != 0L)
					{
						PrerollId = other.PrerollId;
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
						Index = input.ReadInt32();
						break;
					case 16u:
						PrerollId = input.ReadUInt64();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class PrerollPlaylistItem : IMessage<PrerollPlaylistItem>, IMessage, IEquatable<PrerollPlaylistItem>, IDeepCloneable<PrerollPlaylistItem>
		{
			private static readonly MessageParser<PrerollPlaylistItem> _parser = new MessageParser<PrerollPlaylistItem>(() => new PrerollPlaylistItem());

			private UnknownFieldSet _unknownFields;

			public const int PathFieldNumber = 1;

			private static readonly FieldCodec<API_v1_Identifier> _repeated_path_codec = FieldCodec.ForMessage(10u, API_v1_Identifier.Parser);

			private readonly RepeatedField<API_v1_Identifier> path_ = new RepeatedField<API_v1_Identifier>();

			public const int PrerollIdFieldNumber = 2;

			private ulong prerollId_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<PrerollPlaylistItem> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Preroll_Request.Descriptor.NestedTypes[1];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RepeatedField<API_v1_Identifier> Path => path_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ulong PrerollId
			{
				get
				{
					return prerollId_;
				}
				set
				{
					prerollId_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PrerollPlaylistItem()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PrerollPlaylistItem(PrerollPlaylistItem other)
				: this()
			{
				path_ = other.path_.Clone();
				prerollId_ = other.prerollId_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PrerollPlaylistItem Clone()
			{
				return new PrerollPlaylistItem(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as PrerollPlaylistItem);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(PrerollPlaylistItem other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!path_.Equals(other.path_))
				{
					return false;
				}
				if (PrerollId != other.PrerollId)
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
				num ^= path_.GetHashCode();
				if (PrerollId != 0L)
				{
					num ^= PrerollId.GetHashCode();
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
				path_.WriteTo(output, _repeated_path_codec);
				if (PrerollId != 0L)
				{
					output.WriteRawTag(16);
					output.WriteUInt64(PrerollId);
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
				num += path_.CalculateSize(_repeated_path_codec);
				if (PrerollId != 0L)
				{
					num += 1 + CodedOutputStream.ComputeUInt64Size(PrerollId);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(PrerollPlaylistItem other)
			{
				if (other != null)
				{
					path_.Add(other.path_);
					if (other.PrerollId != 0L)
					{
						PrerollId = other.PrerollId;
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
						path_.AddEntriesFrom(input, _repeated_path_codec);
						break;
					case 16u:
						PrerollId = input.ReadUInt64();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class PrerollMediaItem : IMessage<PrerollMediaItem>, IMessage, IEquatable<PrerollMediaItem>, IDeepCloneable<PrerollMediaItem>
		{
			private static readonly MessageParser<PrerollMediaItem> _parser = new MessageParser<PrerollMediaItem>(() => new PrerollMediaItem());

			private UnknownFieldSet _unknownFields;

			public const int PathFieldNumber = 1;

			private static readonly FieldCodec<API_v1_Identifier> _repeated_path_codec = FieldCodec.ForMessage(10u, API_v1_Identifier.Parser);

			private readonly RepeatedField<API_v1_Identifier> path_ = new RepeatedField<API_v1_Identifier>();

			public const int PrerollIdFieldNumber = 2;

			private ulong prerollId_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<PrerollMediaItem> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Preroll_Request.Descriptor.NestedTypes[2];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RepeatedField<API_v1_Identifier> Path => path_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ulong PrerollId
			{
				get
				{
					return prerollId_;
				}
				set
				{
					prerollId_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PrerollMediaItem()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PrerollMediaItem(PrerollMediaItem other)
				: this()
			{
				path_ = other.path_.Clone();
				prerollId_ = other.prerollId_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PrerollMediaItem Clone()
			{
				return new PrerollMediaItem(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as PrerollMediaItem);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(PrerollMediaItem other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!path_.Equals(other.path_))
				{
					return false;
				}
				if (PrerollId != other.PrerollId)
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
				num ^= path_.GetHashCode();
				if (PrerollId != 0L)
				{
					num ^= PrerollId.GetHashCode();
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
				path_.WriteTo(output, _repeated_path_codec);
				if (PrerollId != 0L)
				{
					output.WriteRawTag(16);
					output.WriteUInt64(PrerollId);
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
				num += path_.CalculateSize(_repeated_path_codec);
				if (PrerollId != 0L)
				{
					num += 1 + CodedOutputStream.ComputeUInt64Size(PrerollId);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(PrerollMediaItem other)
			{
				if (other != null)
				{
					path_.Add(other.path_);
					if (other.PrerollId != 0L)
					{
						PrerollId = other.PrerollId;
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
						path_.AddEntriesFrom(input, _repeated_path_codec);
						break;
					case 16u:
						PrerollId = input.ReadUInt64();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class PrerollAudioItem : IMessage<PrerollAudioItem>, IMessage, IEquatable<PrerollAudioItem>, IDeepCloneable<PrerollAudioItem>
		{
			private static readonly MessageParser<PrerollAudioItem> _parser = new MessageParser<PrerollAudioItem>(() => new PrerollAudioItem());

			private UnknownFieldSet _unknownFields;

			public const int PathFieldNumber = 1;

			private static readonly FieldCodec<API_v1_Identifier> _repeated_path_codec = FieldCodec.ForMessage(10u, API_v1_Identifier.Parser);

			private readonly RepeatedField<API_v1_Identifier> path_ = new RepeatedField<API_v1_Identifier>();

			public const int PrerollIdFieldNumber = 2;

			private ulong prerollId_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<PrerollAudioItem> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Preroll_Request.Descriptor.NestedTypes[3];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RepeatedField<API_v1_Identifier> Path => path_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ulong PrerollId
			{
				get
				{
					return prerollId_;
				}
				set
				{
					prerollId_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PrerollAudioItem()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PrerollAudioItem(PrerollAudioItem other)
				: this()
			{
				path_ = other.path_.Clone();
				prerollId_ = other.prerollId_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PrerollAudioItem Clone()
			{
				return new PrerollAudioItem(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as PrerollAudioItem);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(PrerollAudioItem other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!path_.Equals(other.path_))
				{
					return false;
				}
				if (PrerollId != other.PrerollId)
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
				num ^= path_.GetHashCode();
				if (PrerollId != 0L)
				{
					num ^= PrerollId.GetHashCode();
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
				path_.WriteTo(output, _repeated_path_codec);
				if (PrerollId != 0L)
				{
					output.WriteRawTag(16);
					output.WriteUInt64(PrerollId);
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
				num += path_.CalculateSize(_repeated_path_codec);
				if (PrerollId != 0L)
				{
					num += 1 + CodedOutputStream.ComputeUInt64Size(PrerollId);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(PrerollAudioItem other)
			{
				if (other != null)
				{
					path_.Add(other.path_);
					if (other.PrerollId != 0L)
					{
						PrerollId = other.PrerollId;
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
						path_.AddEntriesFrom(input, _repeated_path_codec);
						break;
					case 16u:
						PrerollId = input.ReadUInt64();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class PrerollVideoInput : IMessage<PrerollVideoInput>, IMessage, IEquatable<PrerollVideoInput>, IDeepCloneable<PrerollVideoInput>
		{
			private static readonly MessageParser<PrerollVideoInput> _parser = new MessageParser<PrerollVideoInput>(() => new PrerollVideoInput());

			private UnknownFieldSet _unknownFields;

			public const int IdFieldNumber = 1;

			private string id_ = "";

			public const int PrerollIdFieldNumber = 2;

			private ulong prerollId_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<PrerollVideoInput> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Preroll_Request.Descriptor.NestedTypes[4];

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
			public ulong PrerollId
			{
				get
				{
					return prerollId_;
				}
				set
				{
					prerollId_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PrerollVideoInput()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PrerollVideoInput(PrerollVideoInput other)
				: this()
			{
				id_ = other.id_;
				prerollId_ = other.prerollId_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PrerollVideoInput Clone()
			{
				return new PrerollVideoInput(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as PrerollVideoInput);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(PrerollVideoInput other)
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
				if (PrerollId != other.PrerollId)
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
				if (PrerollId != 0L)
				{
					num ^= PrerollId.GetHashCode();
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
				if (PrerollId != 0L)
				{
					output.WriteRawTag(16);
					output.WriteUInt64(PrerollId);
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
				if (PrerollId != 0L)
				{
					num += 1 + CodedOutputStream.ComputeUInt64Size(PrerollId);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(PrerollVideoInput other)
			{
				if (other != null)
				{
					if (other.Id.Length != 0)
					{
						Id = other.Id;
					}
					if (other.PrerollId != 0L)
					{
						PrerollId = other.PrerollId;
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
						PrerollId = input.ReadUInt64();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class PrerollLibraryItem : IMessage<PrerollLibraryItem>, IMessage, IEquatable<PrerollLibraryItem>, IDeepCloneable<PrerollLibraryItem>
		{
			private static readonly MessageParser<PrerollLibraryItem> _parser = new MessageParser<PrerollLibraryItem>(() => new PrerollLibraryItem());

			private UnknownFieldSet _unknownFields;

			public const int PathFieldNumber = 1;

			private static readonly FieldCodec<API_v1_Identifier> _repeated_path_codec = FieldCodec.ForMessage(10u, API_v1_Identifier.Parser);

			private readonly RepeatedField<API_v1_Identifier> path_ = new RepeatedField<API_v1_Identifier>();

			public const int PrerollIdFieldNumber = 2;

			private ulong prerollId_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<PrerollLibraryItem> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Preroll_Request.Descriptor.NestedTypes[5];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RepeatedField<API_v1_Identifier> Path => path_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ulong PrerollId
			{
				get
				{
					return prerollId_;
				}
				set
				{
					prerollId_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PrerollLibraryItem()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PrerollLibraryItem(PrerollLibraryItem other)
				: this()
			{
				path_ = other.path_.Clone();
				prerollId_ = other.prerollId_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PrerollLibraryItem Clone()
			{
				return new PrerollLibraryItem(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as PrerollLibraryItem);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(PrerollLibraryItem other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!path_.Equals(other.path_))
				{
					return false;
				}
				if (PrerollId != other.PrerollId)
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
				num ^= path_.GetHashCode();
				if (PrerollId != 0L)
				{
					num ^= PrerollId.GetHashCode();
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
				path_.WriteTo(output, _repeated_path_codec);
				if (PrerollId != 0L)
				{
					output.WriteRawTag(16);
					output.WriteUInt64(PrerollId);
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
				num += path_.CalculateSize(_repeated_path_codec);
				if (PrerollId != 0L)
				{
					num += 1 + CodedOutputStream.ComputeUInt64Size(PrerollId);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(PrerollLibraryItem other)
			{
				if (other != null)
				{
					path_.Add(other.path_);
					if (other.PrerollId != 0L)
					{
						PrerollId = other.PrerollId;
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
						path_.AddEntriesFrom(input, _repeated_path_codec);
						break;
					case 16u:
						PrerollId = input.ReadUInt64();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class PrerollNext : IMessage<PrerollNext>, IMessage, IEquatable<PrerollNext>, IDeepCloneable<PrerollNext>
		{
			private static readonly MessageParser<PrerollNext> _parser = new MessageParser<PrerollNext>(() => new PrerollNext());

			private UnknownFieldSet _unknownFields;

			public const int PrerollIdFieldNumber = 1;

			private ulong prerollId_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<PrerollNext> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Preroll_Request.Descriptor.NestedTypes[6];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ulong PrerollId
			{
				get
				{
					return prerollId_;
				}
				set
				{
					prerollId_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PrerollNext()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PrerollNext(PrerollNext other)
				: this()
			{
				prerollId_ = other.prerollId_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PrerollNext Clone()
			{
				return new PrerollNext(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as PrerollNext);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(PrerollNext other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (PrerollId != other.PrerollId)
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
				if (PrerollId != 0L)
				{
					num ^= PrerollId.GetHashCode();
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
				if (PrerollId != 0L)
				{
					output.WriteRawTag(8);
					output.WriteUInt64(PrerollId);
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
				if (PrerollId != 0L)
				{
					num += 1 + CodedOutputStream.ComputeUInt64Size(PrerollId);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(PrerollNext other)
			{
				if (other != null)
				{
					if (other.PrerollId != 0L)
					{
						PrerollId = other.PrerollId;
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
						PrerollId = input.ReadUInt64();
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class PrerollPrevious : IMessage<PrerollPrevious>, IMessage, IEquatable<PrerollPrevious>, IDeepCloneable<PrerollPrevious>
		{
			private static readonly MessageParser<PrerollPrevious> _parser = new MessageParser<PrerollPrevious>(() => new PrerollPrevious());

			private UnknownFieldSet _unknownFields;

			public const int PrerollIdFieldNumber = 1;

			private ulong prerollId_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<PrerollPrevious> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Preroll_Request.Descriptor.NestedTypes[7];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ulong PrerollId
			{
				get
				{
					return prerollId_;
				}
				set
				{
					prerollId_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PrerollPrevious()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PrerollPrevious(PrerollPrevious other)
				: this()
			{
				prerollId_ = other.prerollId_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PrerollPrevious Clone()
			{
				return new PrerollPrevious(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as PrerollPrevious);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(PrerollPrevious other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (PrerollId != other.PrerollId)
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
				if (PrerollId != 0L)
				{
					num ^= PrerollId.GetHashCode();
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
				if (PrerollId != 0L)
				{
					output.WriteRawTag(8);
					output.WriteUInt64(PrerollId);
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
				if (PrerollId != 0L)
				{
					num += 1 + CodedOutputStream.ComputeUInt64Size(PrerollId);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(PrerollPrevious other)
			{
				if (other != null)
				{
					if (other.PrerollId != 0L)
					{
						PrerollId = other.PrerollId;
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
						PrerollId = input.ReadUInt64();
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class ActivatePrerollItem : IMessage<ActivatePrerollItem>, IMessage, IEquatable<ActivatePrerollItem>, IDeepCloneable<ActivatePrerollItem>
		{
			private static readonly MessageParser<ActivatePrerollItem> _parser = new MessageParser<ActivatePrerollItem>(() => new ActivatePrerollItem());

			private UnknownFieldSet _unknownFields;

			public const int IdFieldNumber = 1;

			private ulong id_;

			public const int TimeFieldNumber = 2;

			private ulong time_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<ActivatePrerollItem> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Preroll_Request.Descriptor.NestedTypes[8];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ulong Id
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
			public ulong Time
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
			public ActivatePrerollItem()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ActivatePrerollItem(ActivatePrerollItem other)
				: this()
			{
				id_ = other.id_;
				time_ = other.time_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ActivatePrerollItem Clone()
			{
				return new ActivatePrerollItem(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as ActivatePrerollItem);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(ActivatePrerollItem other)
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
				if (Time != other.Time)
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
				if (Id != 0L)
				{
					num ^= Id.GetHashCode();
				}
				if (Time != 0L)
				{
					num ^= Time.GetHashCode();
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
				if (Id != 0L)
				{
					output.WriteRawTag(8);
					output.WriteUInt64(Id);
				}
				if (Time != 0L)
				{
					output.WriteRawTag(16);
					output.WriteUInt64(Time);
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
				if (Id != 0L)
				{
					num += 1 + CodedOutputStream.ComputeUInt64Size(Id);
				}
				if (Time != 0L)
				{
					num += 1 + CodedOutputStream.ComputeUInt64Size(Time);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(ActivatePrerollItem other)
			{
				if (other != null)
				{
					if (other.Id != 0L)
					{
						Id = other.Id;
					}
					if (other.Time != 0L)
					{
						Time = other.Time;
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
						Id = input.ReadUInt64();
						break;
					case 16u:
						Time = input.ReadUInt64();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class CancelPrerollItem : IMessage<CancelPrerollItem>, IMessage, IEquatable<CancelPrerollItem>, IDeepCloneable<CancelPrerollItem>
		{
			private static readonly MessageParser<CancelPrerollItem> _parser = new MessageParser<CancelPrerollItem>(() => new CancelPrerollItem());

			private UnknownFieldSet _unknownFields;

			public const int IdFieldNumber = 1;

			private ulong id_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<CancelPrerollItem> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Preroll_Request.Descriptor.NestedTypes[9];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ulong Id
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
			public CancelPrerollItem()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public CancelPrerollItem(CancelPrerollItem other)
				: this()
			{
				id_ = other.id_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public CancelPrerollItem Clone()
			{
				return new CancelPrerollItem(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as CancelPrerollItem);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(CancelPrerollItem other)
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
				if (Id != 0L)
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
				if (Id != 0L)
				{
					output.WriteRawTag(8);
					output.WriteUInt64(Id);
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
				if (Id != 0L)
				{
					num += 1 + CodedOutputStream.ComputeUInt64Size(Id);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(CancelPrerollItem other)
			{
				if (other != null)
				{
					if (other.Id != 0L)
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
					if (num != 8)
					{
						_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
					}
					else
					{
						Id = input.ReadUInt64();
					}
				}
			}
		}
	}

	private static readonly MessageParser<API_v1_Preroll_Request> _parser = new MessageParser<API_v1_Preroll_Request>(() => new API_v1_Preroll_Request());

	private UnknownFieldSet _unknownFields;

	public const int PrerollCueFieldNumber = 1;

	public const int PrerollPlaylistItemFieldNumber = 2;

	public const int PrerollMediaItemFieldNumber = 3;

	public const int PrerollAudioItemFieldNumber = 4;

	public const int PrerollVideoInputFieldNumber = 5;

	public const int PrerollLibraryItemFieldNumber = 6;

	public const int PrerollNextFieldNumber = 7;

	public const int PrerollPreviousFieldNumber = 8;

	public const int ActivatePrerollItemFieldNumber = 9;

	public const int CancelPrerollItemFieldNumber = 10;

	private object request_;

	private RequestOneofCase requestCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<API_v1_Preroll_Request> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProApiV1PrerollReflection.Descriptor.MessageTypes[0];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.PrerollCue PrerollCue
	{
		get
		{
			if (requestCase_ != RequestOneofCase.PrerollCue)
			{
				return null;
			}
			return (Types.PrerollCue)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.PrerollCue : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.PrerollPlaylistItem PrerollPlaylistItem
	{
		get
		{
			if (requestCase_ != RequestOneofCase.PrerollPlaylistItem)
			{
				return null;
			}
			return (Types.PrerollPlaylistItem)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.PrerollPlaylistItem : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.PrerollMediaItem PrerollMediaItem
	{
		get
		{
			if (requestCase_ != RequestOneofCase.PrerollMediaItem)
			{
				return null;
			}
			return (Types.PrerollMediaItem)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.PrerollMediaItem : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.PrerollAudioItem PrerollAudioItem
	{
		get
		{
			if (requestCase_ != RequestOneofCase.PrerollAudioItem)
			{
				return null;
			}
			return (Types.PrerollAudioItem)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.PrerollAudioItem : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.PrerollVideoInput PrerollVideoInput
	{
		get
		{
			if (requestCase_ != RequestOneofCase.PrerollVideoInput)
			{
				return null;
			}
			return (Types.PrerollVideoInput)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.PrerollVideoInput : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.PrerollLibraryItem PrerollLibraryItem
	{
		get
		{
			if (requestCase_ != RequestOneofCase.PrerollLibraryItem)
			{
				return null;
			}
			return (Types.PrerollLibraryItem)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.PrerollLibraryItem : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.PrerollNext PrerollNext
	{
		get
		{
			if (requestCase_ != RequestOneofCase.PrerollNext)
			{
				return null;
			}
			return (Types.PrerollNext)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.PrerollNext : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.PrerollPrevious PrerollPrevious
	{
		get
		{
			if (requestCase_ != RequestOneofCase.PrerollPrevious)
			{
				return null;
			}
			return (Types.PrerollPrevious)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.PrerollPrevious : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.ActivatePrerollItem ActivatePrerollItem
	{
		get
		{
			if (requestCase_ != RequestOneofCase.ActivatePrerollItem)
			{
				return null;
			}
			return (Types.ActivatePrerollItem)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.ActivatePrerollItem : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.CancelPrerollItem CancelPrerollItem
	{
		get
		{
			if (requestCase_ != RequestOneofCase.CancelPrerollItem)
			{
				return null;
			}
			return (Types.CancelPrerollItem)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.CancelPrerollItem : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RequestOneofCase RequestCase => requestCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Preroll_Request()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Preroll_Request(API_v1_Preroll_Request other)
		: this()
	{
		switch (other.RequestCase)
		{
		case RequestOneofCase.PrerollCue:
			PrerollCue = other.PrerollCue.Clone();
			break;
		case RequestOneofCase.PrerollPlaylistItem:
			PrerollPlaylistItem = other.PrerollPlaylistItem.Clone();
			break;
		case RequestOneofCase.PrerollMediaItem:
			PrerollMediaItem = other.PrerollMediaItem.Clone();
			break;
		case RequestOneofCase.PrerollAudioItem:
			PrerollAudioItem = other.PrerollAudioItem.Clone();
			break;
		case RequestOneofCase.PrerollVideoInput:
			PrerollVideoInput = other.PrerollVideoInput.Clone();
			break;
		case RequestOneofCase.PrerollLibraryItem:
			PrerollLibraryItem = other.PrerollLibraryItem.Clone();
			break;
		case RequestOneofCase.PrerollNext:
			PrerollNext = other.PrerollNext.Clone();
			break;
		case RequestOneofCase.PrerollPrevious:
			PrerollPrevious = other.PrerollPrevious.Clone();
			break;
		case RequestOneofCase.ActivatePrerollItem:
			ActivatePrerollItem = other.ActivatePrerollItem.Clone();
			break;
		case RequestOneofCase.CancelPrerollItem:
			CancelPrerollItem = other.CancelPrerollItem.Clone();
			break;
		}
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Preroll_Request Clone()
	{
		return new API_v1_Preroll_Request(this);
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
		return Equals(other as API_v1_Preroll_Request);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(API_v1_Preroll_Request other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(PrerollCue, other.PrerollCue))
		{
			return false;
		}
		if (!object.Equals(PrerollPlaylistItem, other.PrerollPlaylistItem))
		{
			return false;
		}
		if (!object.Equals(PrerollMediaItem, other.PrerollMediaItem))
		{
			return false;
		}
		if (!object.Equals(PrerollAudioItem, other.PrerollAudioItem))
		{
			return false;
		}
		if (!object.Equals(PrerollVideoInput, other.PrerollVideoInput))
		{
			return false;
		}
		if (!object.Equals(PrerollLibraryItem, other.PrerollLibraryItem))
		{
			return false;
		}
		if (!object.Equals(PrerollNext, other.PrerollNext))
		{
			return false;
		}
		if (!object.Equals(PrerollPrevious, other.PrerollPrevious))
		{
			return false;
		}
		if (!object.Equals(ActivatePrerollItem, other.ActivatePrerollItem))
		{
			return false;
		}
		if (!object.Equals(CancelPrerollItem, other.CancelPrerollItem))
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
		if (requestCase_ == RequestOneofCase.PrerollCue)
		{
			num ^= PrerollCue.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.PrerollPlaylistItem)
		{
			num ^= PrerollPlaylistItem.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.PrerollMediaItem)
		{
			num ^= PrerollMediaItem.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.PrerollAudioItem)
		{
			num ^= PrerollAudioItem.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.PrerollVideoInput)
		{
			num ^= PrerollVideoInput.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.PrerollLibraryItem)
		{
			num ^= PrerollLibraryItem.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.PrerollNext)
		{
			num ^= PrerollNext.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.PrerollPrevious)
		{
			num ^= PrerollPrevious.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.ActivatePrerollItem)
		{
			num ^= ActivatePrerollItem.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.CancelPrerollItem)
		{
			num ^= CancelPrerollItem.GetHashCode();
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
		if (requestCase_ == RequestOneofCase.PrerollCue)
		{
			output.WriteRawTag(10);
			output.WriteMessage(PrerollCue);
		}
		if (requestCase_ == RequestOneofCase.PrerollPlaylistItem)
		{
			output.WriteRawTag(18);
			output.WriteMessage(PrerollPlaylistItem);
		}
		if (requestCase_ == RequestOneofCase.PrerollMediaItem)
		{
			output.WriteRawTag(26);
			output.WriteMessage(PrerollMediaItem);
		}
		if (requestCase_ == RequestOneofCase.PrerollAudioItem)
		{
			output.WriteRawTag(34);
			output.WriteMessage(PrerollAudioItem);
		}
		if (requestCase_ == RequestOneofCase.PrerollVideoInput)
		{
			output.WriteRawTag(42);
			output.WriteMessage(PrerollVideoInput);
		}
		if (requestCase_ == RequestOneofCase.PrerollLibraryItem)
		{
			output.WriteRawTag(50);
			output.WriteMessage(PrerollLibraryItem);
		}
		if (requestCase_ == RequestOneofCase.PrerollNext)
		{
			output.WriteRawTag(58);
			output.WriteMessage(PrerollNext);
		}
		if (requestCase_ == RequestOneofCase.PrerollPrevious)
		{
			output.WriteRawTag(66);
			output.WriteMessage(PrerollPrevious);
		}
		if (requestCase_ == RequestOneofCase.ActivatePrerollItem)
		{
			output.WriteRawTag(74);
			output.WriteMessage(ActivatePrerollItem);
		}
		if (requestCase_ == RequestOneofCase.CancelPrerollItem)
		{
			output.WriteRawTag(82);
			output.WriteMessage(CancelPrerollItem);
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
		if (requestCase_ == RequestOneofCase.PrerollCue)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PrerollCue);
		}
		if (requestCase_ == RequestOneofCase.PrerollPlaylistItem)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PrerollPlaylistItem);
		}
		if (requestCase_ == RequestOneofCase.PrerollMediaItem)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PrerollMediaItem);
		}
		if (requestCase_ == RequestOneofCase.PrerollAudioItem)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PrerollAudioItem);
		}
		if (requestCase_ == RequestOneofCase.PrerollVideoInput)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PrerollVideoInput);
		}
		if (requestCase_ == RequestOneofCase.PrerollLibraryItem)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PrerollLibraryItem);
		}
		if (requestCase_ == RequestOneofCase.PrerollNext)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PrerollNext);
		}
		if (requestCase_ == RequestOneofCase.PrerollPrevious)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PrerollPrevious);
		}
		if (requestCase_ == RequestOneofCase.ActivatePrerollItem)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(ActivatePrerollItem);
		}
		if (requestCase_ == RequestOneofCase.CancelPrerollItem)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(CancelPrerollItem);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(API_v1_Preroll_Request other)
	{
		if (other == null)
		{
			return;
		}
		switch (other.RequestCase)
		{
		case RequestOneofCase.PrerollCue:
			if (PrerollCue == null)
			{
				PrerollCue = new Types.PrerollCue();
			}
			PrerollCue.MergeFrom(other.PrerollCue);
			break;
		case RequestOneofCase.PrerollPlaylistItem:
			if (PrerollPlaylistItem == null)
			{
				PrerollPlaylistItem = new Types.PrerollPlaylistItem();
			}
			PrerollPlaylistItem.MergeFrom(other.PrerollPlaylistItem);
			break;
		case RequestOneofCase.PrerollMediaItem:
			if (PrerollMediaItem == null)
			{
				PrerollMediaItem = new Types.PrerollMediaItem();
			}
			PrerollMediaItem.MergeFrom(other.PrerollMediaItem);
			break;
		case RequestOneofCase.PrerollAudioItem:
			if (PrerollAudioItem == null)
			{
				PrerollAudioItem = new Types.PrerollAudioItem();
			}
			PrerollAudioItem.MergeFrom(other.PrerollAudioItem);
			break;
		case RequestOneofCase.PrerollVideoInput:
			if (PrerollVideoInput == null)
			{
				PrerollVideoInput = new Types.PrerollVideoInput();
			}
			PrerollVideoInput.MergeFrom(other.PrerollVideoInput);
			break;
		case RequestOneofCase.PrerollLibraryItem:
			if (PrerollLibraryItem == null)
			{
				PrerollLibraryItem = new Types.PrerollLibraryItem();
			}
			PrerollLibraryItem.MergeFrom(other.PrerollLibraryItem);
			break;
		case RequestOneofCase.PrerollNext:
			if (PrerollNext == null)
			{
				PrerollNext = new Types.PrerollNext();
			}
			PrerollNext.MergeFrom(other.PrerollNext);
			break;
		case RequestOneofCase.PrerollPrevious:
			if (PrerollPrevious == null)
			{
				PrerollPrevious = new Types.PrerollPrevious();
			}
			PrerollPrevious.MergeFrom(other.PrerollPrevious);
			break;
		case RequestOneofCase.ActivatePrerollItem:
			if (ActivatePrerollItem == null)
			{
				ActivatePrerollItem = new Types.ActivatePrerollItem();
			}
			ActivatePrerollItem.MergeFrom(other.ActivatePrerollItem);
			break;
		case RequestOneofCase.CancelPrerollItem:
			if (CancelPrerollItem == null)
			{
				CancelPrerollItem = new Types.CancelPrerollItem();
			}
			CancelPrerollItem.MergeFrom(other.CancelPrerollItem);
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
				Types.PrerollCue prerollCue = new Types.PrerollCue();
				if (requestCase_ == RequestOneofCase.PrerollCue)
				{
					prerollCue.MergeFrom(PrerollCue);
				}
				input.ReadMessage(prerollCue);
				PrerollCue = prerollCue;
				break;
			}
			case 18u:
			{
				Types.PrerollPlaylistItem prerollPlaylistItem = new Types.PrerollPlaylistItem();
				if (requestCase_ == RequestOneofCase.PrerollPlaylistItem)
				{
					prerollPlaylistItem.MergeFrom(PrerollPlaylistItem);
				}
				input.ReadMessage(prerollPlaylistItem);
				PrerollPlaylistItem = prerollPlaylistItem;
				break;
			}
			case 26u:
			{
				Types.PrerollMediaItem prerollMediaItem = new Types.PrerollMediaItem();
				if (requestCase_ == RequestOneofCase.PrerollMediaItem)
				{
					prerollMediaItem.MergeFrom(PrerollMediaItem);
				}
				input.ReadMessage(prerollMediaItem);
				PrerollMediaItem = prerollMediaItem;
				break;
			}
			case 34u:
			{
				Types.PrerollAudioItem prerollAudioItem = new Types.PrerollAudioItem();
				if (requestCase_ == RequestOneofCase.PrerollAudioItem)
				{
					prerollAudioItem.MergeFrom(PrerollAudioItem);
				}
				input.ReadMessage(prerollAudioItem);
				PrerollAudioItem = prerollAudioItem;
				break;
			}
			case 42u:
			{
				Types.PrerollVideoInput prerollVideoInput = new Types.PrerollVideoInput();
				if (requestCase_ == RequestOneofCase.PrerollVideoInput)
				{
					prerollVideoInput.MergeFrom(PrerollVideoInput);
				}
				input.ReadMessage(prerollVideoInput);
				PrerollVideoInput = prerollVideoInput;
				break;
			}
			case 50u:
			{
				Types.PrerollLibraryItem prerollLibraryItem = new Types.PrerollLibraryItem();
				if (requestCase_ == RequestOneofCase.PrerollLibraryItem)
				{
					prerollLibraryItem.MergeFrom(PrerollLibraryItem);
				}
				input.ReadMessage(prerollLibraryItem);
				PrerollLibraryItem = prerollLibraryItem;
				break;
			}
			case 58u:
			{
				Types.PrerollNext prerollNext = new Types.PrerollNext();
				if (requestCase_ == RequestOneofCase.PrerollNext)
				{
					prerollNext.MergeFrom(PrerollNext);
				}
				input.ReadMessage(prerollNext);
				PrerollNext = prerollNext;
				break;
			}
			case 66u:
			{
				Types.PrerollPrevious prerollPrevious = new Types.PrerollPrevious();
				if (requestCase_ == RequestOneofCase.PrerollPrevious)
				{
					prerollPrevious.MergeFrom(PrerollPrevious);
				}
				input.ReadMessage(prerollPrevious);
				PrerollPrevious = prerollPrevious;
				break;
			}
			case 74u:
			{
				Types.ActivatePrerollItem activatePrerollItem = new Types.ActivatePrerollItem();
				if (requestCase_ == RequestOneofCase.ActivatePrerollItem)
				{
					activatePrerollItem.MergeFrom(ActivatePrerollItem);
				}
				input.ReadMessage(activatePrerollItem);
				ActivatePrerollItem = activatePrerollItem;
				break;
			}
			case 82u:
			{
				Types.CancelPrerollItem cancelPrerollItem = new Types.CancelPrerollItem();
				if (requestCase_ == RequestOneofCase.CancelPrerollItem)
				{
					cancelPrerollItem.MergeFrom(CancelPrerollItem);
				}
				input.ReadMessage(cancelPrerollItem);
				CancelPrerollItem = cancelPrerollItem;
				break;
			}
			}
		}
	}
}
