using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Service.Document;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class Notification : IMessage<Notification>, IMessage, IEquatable<Notification>, IDeepCloneable<Notification>
{
	public enum NotificationOneofCase
	{
		None,
		Unsubscribe,
		Patch,
		Required,
		Available,
		Added,
		Moved,
		Removed
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class UnsubscribeComplete : IMessage<UnsubscribeComplete>, IMessage, IEquatable<UnsubscribeComplete>, IDeepCloneable<UnsubscribeComplete>
		{
			private static readonly MessageParser<UnsubscribeComplete> _parser = new MessageParser<UnsubscribeComplete>(() => new UnsubscribeComplete());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<UnsubscribeComplete> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Notification.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public UnsubscribeComplete()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public UnsubscribeComplete(UnsubscribeComplete other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public UnsubscribeComplete Clone()
			{
				return new UnsubscribeComplete(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as UnsubscribeComplete);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(UnsubscribeComplete other)
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
			public void MergeFrom(UnsubscribeComplete other)
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
		public sealed class Patch : IMessage<Patch>, IMessage, IEquatable<Patch>, IDeepCloneable<Patch>
		{
			private static readonly MessageParser<Patch> _parser = new MessageParser<Patch>(() => new Patch());

			private UnknownFieldSet _unknownFields;

			public const int UuidFieldNumber = 1;

			private string uuid_ = "";

			public const int BlobFieldNumber = 2;

			private ByteString blob_ = ByteString.Empty;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Patch> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Notification.Descriptor.NestedTypes[1];

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
			public ByteString Blob
			{
				get
				{
					return blob_;
				}
				set
				{
					blob_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Patch()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Patch(Patch other)
				: this()
			{
				uuid_ = other.uuid_;
				blob_ = other.blob_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Patch Clone()
			{
				return new Patch(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Patch);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Patch other)
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
				if (Blob != other.Blob)
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
				if (Blob.Length != 0)
				{
					num ^= Blob.GetHashCode();
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
				if (Uuid.Length != 0)
				{
					output.WriteRawTag(10);
					output.WriteString(Uuid);
				}
				if (Blob.Length != 0)
				{
					output.WriteRawTag(18);
					output.WriteBytes(Blob);
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
				if (Blob.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeBytesSize(Blob);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(Patch other)
			{
				if (other != null)
				{
					if (other.Uuid.Length != 0)
					{
						Uuid = other.Uuid;
					}
					if (other.Blob.Length != 0)
					{
						Blob = other.Blob;
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
						Uuid = input.ReadString();
						break;
					case 18u:
						Blob = input.ReadBytes();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Required : IMessage<Required>, IMessage, IEquatable<Required>, IDeepCloneable<Required>
		{
			private static readonly MessageParser<Required> _parser = new MessageParser<Required>(() => new Required());

			private UnknownFieldSet _unknownFields;

			public const int UuidFieldNumber = 1;

			private string uuid_ = "";

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Required> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Notification.Descriptor.NestedTypes[2];

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
			public Required()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Required(Required other)
				: this()
			{
				uuid_ = other.uuid_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Required Clone()
			{
				return new Required(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Required);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Required other)
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
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(Required other)
			{
				if (other != null)
				{
					if (other.Uuid.Length != 0)
					{
						Uuid = other.Uuid;
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
						Uuid = input.ReadString();
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Available : IMessage<Available>, IMessage, IEquatable<Available>, IDeepCloneable<Available>
		{
			private static readonly MessageParser<Available> _parser = new MessageParser<Available>(() => new Available());

			private UnknownFieldSet _unknownFields;

			public const int UuidFieldNumber = 1;

			private string uuid_ = "";

			public const int BlobFieldNumber = 2;

			private ByteString blob_ = ByteString.Empty;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Available> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Notification.Descriptor.NestedTypes[3];

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
			public ByteString Blob
			{
				get
				{
					return blob_;
				}
				set
				{
					blob_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Available()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Available(Available other)
				: this()
			{
				uuid_ = other.uuid_;
				blob_ = other.blob_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Available Clone()
			{
				return new Available(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Available);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Available other)
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
				if (Blob != other.Blob)
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
				if (Blob.Length != 0)
				{
					num ^= Blob.GetHashCode();
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
				if (Uuid.Length != 0)
				{
					output.WriteRawTag(10);
					output.WriteString(Uuid);
				}
				if (Blob.Length != 0)
				{
					output.WriteRawTag(18);
					output.WriteBytes(Blob);
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
				if (Blob.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeBytesSize(Blob);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(Available other)
			{
				if (other != null)
				{
					if (other.Uuid.Length != 0)
					{
						Uuid = other.Uuid;
					}
					if (other.Blob.Length != 0)
					{
						Blob = other.Blob;
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
						Uuid = input.ReadString();
						break;
					case 18u:
						Blob = input.ReadBytes();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Added : IMessage<Added>, IMessage, IEquatable<Added>, IDeepCloneable<Added>
		{
			private static readonly MessageParser<Added> _parser = new MessageParser<Added>(() => new Added());

			private UnknownFieldSet _unknownFields;

			public const int UuidFieldNumber = 1;

			private string uuid_ = "";

			public const int KindFieldNumber = 2;

			private Document.Types.Kind kind_;

			public const int PathFieldNumber = 3;

			private string path_ = "";

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Added> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Notification.Descriptor.NestedTypes[4];

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
			public Document.Types.Kind Kind
			{
				get
				{
					return kind_;
				}
				set
				{
					kind_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string Path
			{
				get
				{
					return path_;
				}
				set
				{
					path_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Added()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Added(Added other)
				: this()
			{
				uuid_ = other.uuid_;
				kind_ = other.kind_;
				path_ = other.path_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Added Clone()
			{
				return new Added(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Added);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Added other)
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
				if (Kind != other.Kind)
				{
					return false;
				}
				if (Path != other.Path)
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
				if (Kind != 0)
				{
					num ^= Kind.GetHashCode();
				}
				if (Path.Length != 0)
				{
					num ^= Path.GetHashCode();
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
				if (Uuid.Length != 0)
				{
					output.WriteRawTag(10);
					output.WriteString(Uuid);
				}
				if (Kind != 0)
				{
					output.WriteRawTag(16);
					output.WriteEnum((int)Kind);
				}
				if (Path.Length != 0)
				{
					output.WriteRawTag(26);
					output.WriteString(Path);
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
				if (Kind != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)Kind);
				}
				if (Path.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Path);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(Added other)
			{
				if (other != null)
				{
					if (other.Uuid.Length != 0)
					{
						Uuid = other.Uuid;
					}
					if (other.Kind != 0)
					{
						Kind = other.Kind;
					}
					if (other.Path.Length != 0)
					{
						Path = other.Path;
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
						Uuid = input.ReadString();
						break;
					case 16u:
						Kind = (Document.Types.Kind)input.ReadEnum();
						break;
					case 26u:
						Path = input.ReadString();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Moved : IMessage<Moved>, IMessage, IEquatable<Moved>, IDeepCloneable<Moved>
		{
			private static readonly MessageParser<Moved> _parser = new MessageParser<Moved>(() => new Moved());

			private UnknownFieldSet _unknownFields;

			public const int UuidFieldNumber = 1;

			private string uuid_ = "";

			public const int KindFieldNumber = 2;

			private Document.Types.Kind kind_;

			public const int PathFieldNumber = 3;

			private string path_ = "";

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Moved> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Notification.Descriptor.NestedTypes[5];

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
			public Document.Types.Kind Kind
			{
				get
				{
					return kind_;
				}
				set
				{
					kind_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string Path
			{
				get
				{
					return path_;
				}
				set
				{
					path_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Moved()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Moved(Moved other)
				: this()
			{
				uuid_ = other.uuid_;
				kind_ = other.kind_;
				path_ = other.path_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Moved Clone()
			{
				return new Moved(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Moved);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Moved other)
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
				if (Kind != other.Kind)
				{
					return false;
				}
				if (Path != other.Path)
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
				if (Kind != 0)
				{
					num ^= Kind.GetHashCode();
				}
				if (Path.Length != 0)
				{
					num ^= Path.GetHashCode();
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
				if (Uuid.Length != 0)
				{
					output.WriteRawTag(10);
					output.WriteString(Uuid);
				}
				if (Kind != 0)
				{
					output.WriteRawTag(16);
					output.WriteEnum((int)Kind);
				}
				if (Path.Length != 0)
				{
					output.WriteRawTag(26);
					output.WriteString(Path);
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
				if (Kind != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)Kind);
				}
				if (Path.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Path);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(Moved other)
			{
				if (other != null)
				{
					if (other.Uuid.Length != 0)
					{
						Uuid = other.Uuid;
					}
					if (other.Kind != 0)
					{
						Kind = other.Kind;
					}
					if (other.Path.Length != 0)
					{
						Path = other.Path;
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
						Uuid = input.ReadString();
						break;
					case 16u:
						Kind = (Document.Types.Kind)input.ReadEnum();
						break;
					case 26u:
						Path = input.ReadString();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Removed : IMessage<Removed>, IMessage, IEquatable<Removed>, IDeepCloneable<Removed>
		{
			private static readonly MessageParser<Removed> _parser = new MessageParser<Removed>(() => new Removed());

			private UnknownFieldSet _unknownFields;

			public const int UuidFieldNumber = 1;

			private string uuid_ = "";

			public const int KindFieldNumber = 2;

			private Document.Types.Kind kind_;

			public const int PathFieldNumber = 3;

			private string path_ = "";

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Removed> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Notification.Descriptor.NestedTypes[6];

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
			public Document.Types.Kind Kind
			{
				get
				{
					return kind_;
				}
				set
				{
					kind_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string Path
			{
				get
				{
					return path_;
				}
				set
				{
					path_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Removed()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Removed(Removed other)
				: this()
			{
				uuid_ = other.uuid_;
				kind_ = other.kind_;
				path_ = other.path_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Removed Clone()
			{
				return new Removed(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Removed);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Removed other)
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
				if (Kind != other.Kind)
				{
					return false;
				}
				if (Path != other.Path)
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
				if (Kind != 0)
				{
					num ^= Kind.GetHashCode();
				}
				if (Path.Length != 0)
				{
					num ^= Path.GetHashCode();
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
				if (Uuid.Length != 0)
				{
					output.WriteRawTag(10);
					output.WriteString(Uuid);
				}
				if (Kind != 0)
				{
					output.WriteRawTag(16);
					output.WriteEnum((int)Kind);
				}
				if (Path.Length != 0)
				{
					output.WriteRawTag(26);
					output.WriteString(Path);
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
				if (Kind != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)Kind);
				}
				if (Path.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Path);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(Removed other)
			{
				if (other != null)
				{
					if (other.Uuid.Length != 0)
					{
						Uuid = other.Uuid;
					}
					if (other.Kind != 0)
					{
						Kind = other.Kind;
					}
					if (other.Path.Length != 0)
					{
						Path = other.Path;
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
						Uuid = input.ReadString();
						break;
					case 16u:
						Kind = (Document.Types.Kind)input.ReadEnum();
						break;
					case 26u:
						Path = input.ReadString();
						break;
					}
				}
			}
		}
	}

	private static readonly MessageParser<Notification> _parser = new MessageParser<Notification>(() => new Notification());

	private UnknownFieldSet _unknownFields;

	public const int UnsubscribeFieldNumber = 1;

	public const int PatchFieldNumber = 2;

	public const int RequiredFieldNumber = 3;

	public const int AvailableFieldNumber = 4;

	public const int AddedFieldNumber = 5;

	public const int MovedFieldNumber = 6;

	public const int RemovedFieldNumber = 7;

	private object notification_;

	private NotificationOneofCase notificationCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<Notification> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => DocumentNotificationsReflection.Descriptor.MessageTypes[0];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.UnsubscribeComplete Unsubscribe
	{
		get
		{
			if (notificationCase_ != NotificationOneofCase.Unsubscribe)
			{
				return null;
			}
			return (Types.UnsubscribeComplete)notification_;
		}
		set
		{
			notification_ = value;
			notificationCase_ = ((value != null) ? NotificationOneofCase.Unsubscribe : NotificationOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Patch Patch
	{
		get
		{
			if (notificationCase_ != NotificationOneofCase.Patch)
			{
				return null;
			}
			return (Types.Patch)notification_;
		}
		set
		{
			notification_ = value;
			notificationCase_ = ((value != null) ? NotificationOneofCase.Patch : NotificationOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Required Required
	{
		get
		{
			if (notificationCase_ != NotificationOneofCase.Required)
			{
				return null;
			}
			return (Types.Required)notification_;
		}
		set
		{
			notification_ = value;
			notificationCase_ = ((value != null) ? NotificationOneofCase.Required : NotificationOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Available Available
	{
		get
		{
			if (notificationCase_ != NotificationOneofCase.Available)
			{
				return null;
			}
			return (Types.Available)notification_;
		}
		set
		{
			notification_ = value;
			notificationCase_ = ((value != null) ? NotificationOneofCase.Available : NotificationOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Added Added
	{
		get
		{
			if (notificationCase_ != NotificationOneofCase.Added)
			{
				return null;
			}
			return (Types.Added)notification_;
		}
		set
		{
			notification_ = value;
			notificationCase_ = ((value != null) ? NotificationOneofCase.Added : NotificationOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Moved Moved
	{
		get
		{
			if (notificationCase_ != NotificationOneofCase.Moved)
			{
				return null;
			}
			return (Types.Moved)notification_;
		}
		set
		{
			notification_ = value;
			notificationCase_ = ((value != null) ? NotificationOneofCase.Moved : NotificationOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Removed Removed
	{
		get
		{
			if (notificationCase_ != NotificationOneofCase.Removed)
			{
				return null;
			}
			return (Types.Removed)notification_;
		}
		set
		{
			notification_ = value;
			notificationCase_ = ((value != null) ? NotificationOneofCase.Removed : NotificationOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public NotificationOneofCase NotificationCase => notificationCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Notification()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Notification(Notification other)
		: this()
	{
		switch (other.NotificationCase)
		{
		case NotificationOneofCase.Unsubscribe:
			Unsubscribe = other.Unsubscribe.Clone();
			break;
		case NotificationOneofCase.Patch:
			Patch = other.Patch.Clone();
			break;
		case NotificationOneofCase.Required:
			Required = other.Required.Clone();
			break;
		case NotificationOneofCase.Available:
			Available = other.Available.Clone();
			break;
		case NotificationOneofCase.Added:
			Added = other.Added.Clone();
			break;
		case NotificationOneofCase.Moved:
			Moved = other.Moved.Clone();
			break;
		case NotificationOneofCase.Removed:
			Removed = other.Removed.Clone();
			break;
		}
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Notification Clone()
	{
		return new Notification(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void ClearNotification()
	{
		notificationCase_ = NotificationOneofCase.None;
		notification_ = null;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as Notification);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(Notification other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(Unsubscribe, other.Unsubscribe))
		{
			return false;
		}
		if (!object.Equals(Patch, other.Patch))
		{
			return false;
		}
		if (!object.Equals(Required, other.Required))
		{
			return false;
		}
		if (!object.Equals(Available, other.Available))
		{
			return false;
		}
		if (!object.Equals(Added, other.Added))
		{
			return false;
		}
		if (!object.Equals(Moved, other.Moved))
		{
			return false;
		}
		if (!object.Equals(Removed, other.Removed))
		{
			return false;
		}
		if (NotificationCase != other.NotificationCase)
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
		if (notificationCase_ == NotificationOneofCase.Unsubscribe)
		{
			num ^= Unsubscribe.GetHashCode();
		}
		if (notificationCase_ == NotificationOneofCase.Patch)
		{
			num ^= Patch.GetHashCode();
		}
		if (notificationCase_ == NotificationOneofCase.Required)
		{
			num ^= Required.GetHashCode();
		}
		if (notificationCase_ == NotificationOneofCase.Available)
		{
			num ^= Available.GetHashCode();
		}
		if (notificationCase_ == NotificationOneofCase.Added)
		{
			num ^= Added.GetHashCode();
		}
		if (notificationCase_ == NotificationOneofCase.Moved)
		{
			num ^= Moved.GetHashCode();
		}
		if (notificationCase_ == NotificationOneofCase.Removed)
		{
			num ^= Removed.GetHashCode();
		}
		num ^= (int)notificationCase_;
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
		if (notificationCase_ == NotificationOneofCase.Unsubscribe)
		{
			output.WriteRawTag(10);
			output.WriteMessage(Unsubscribe);
		}
		if (notificationCase_ == NotificationOneofCase.Patch)
		{
			output.WriteRawTag(18);
			output.WriteMessage(Patch);
		}
		if (notificationCase_ == NotificationOneofCase.Required)
		{
			output.WriteRawTag(26);
			output.WriteMessage(Required);
		}
		if (notificationCase_ == NotificationOneofCase.Available)
		{
			output.WriteRawTag(34);
			output.WriteMessage(Available);
		}
		if (notificationCase_ == NotificationOneofCase.Added)
		{
			output.WriteRawTag(42);
			output.WriteMessage(Added);
		}
		if (notificationCase_ == NotificationOneofCase.Moved)
		{
			output.WriteRawTag(50);
			output.WriteMessage(Moved);
		}
		if (notificationCase_ == NotificationOneofCase.Removed)
		{
			output.WriteRawTag(58);
			output.WriteMessage(Removed);
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
		if (notificationCase_ == NotificationOneofCase.Unsubscribe)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Unsubscribe);
		}
		if (notificationCase_ == NotificationOneofCase.Patch)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Patch);
		}
		if (notificationCase_ == NotificationOneofCase.Required)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Required);
		}
		if (notificationCase_ == NotificationOneofCase.Available)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Available);
		}
		if (notificationCase_ == NotificationOneofCase.Added)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Added);
		}
		if (notificationCase_ == NotificationOneofCase.Moved)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Moved);
		}
		if (notificationCase_ == NotificationOneofCase.Removed)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Removed);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(Notification other)
	{
		if (other == null)
		{
			return;
		}
		switch (other.NotificationCase)
		{
		case NotificationOneofCase.Unsubscribe:
			if (Unsubscribe == null)
			{
				Unsubscribe = new Types.UnsubscribeComplete();
			}
			Unsubscribe.MergeFrom(other.Unsubscribe);
			break;
		case NotificationOneofCase.Patch:
			if (Patch == null)
			{
				Patch = new Types.Patch();
			}
			Patch.MergeFrom(other.Patch);
			break;
		case NotificationOneofCase.Required:
			if (Required == null)
			{
				Required = new Types.Required();
			}
			Required.MergeFrom(other.Required);
			break;
		case NotificationOneofCase.Available:
			if (Available == null)
			{
				Available = new Types.Available();
			}
			Available.MergeFrom(other.Available);
			break;
		case NotificationOneofCase.Added:
			if (Added == null)
			{
				Added = new Types.Added();
			}
			Added.MergeFrom(other.Added);
			break;
		case NotificationOneofCase.Moved:
			if (Moved == null)
			{
				Moved = new Types.Moved();
			}
			Moved.MergeFrom(other.Moved);
			break;
		case NotificationOneofCase.Removed:
			if (Removed == null)
			{
				Removed = new Types.Removed();
			}
			Removed.MergeFrom(other.Removed);
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
				Types.UnsubscribeComplete unsubscribeComplete = new Types.UnsubscribeComplete();
				if (notificationCase_ == NotificationOneofCase.Unsubscribe)
				{
					unsubscribeComplete.MergeFrom(Unsubscribe);
				}
				input.ReadMessage(unsubscribeComplete);
				Unsubscribe = unsubscribeComplete;
				break;
			}
			case 18u:
			{
				Types.Patch patch = new Types.Patch();
				if (notificationCase_ == NotificationOneofCase.Patch)
				{
					patch.MergeFrom(Patch);
				}
				input.ReadMessage(patch);
				Patch = patch;
				break;
			}
			case 26u:
			{
				Types.Required required = new Types.Required();
				if (notificationCase_ == NotificationOneofCase.Required)
				{
					required.MergeFrom(Required);
				}
				input.ReadMessage(required);
				Required = required;
				break;
			}
			case 34u:
			{
				Types.Available available = new Types.Available();
				if (notificationCase_ == NotificationOneofCase.Available)
				{
					available.MergeFrom(Available);
				}
				input.ReadMessage(available);
				Available = available;
				break;
			}
			case 42u:
			{
				Types.Added added = new Types.Added();
				if (notificationCase_ == NotificationOneofCase.Added)
				{
					added.MergeFrom(Added);
				}
				input.ReadMessage(added);
				Added = added;
				break;
			}
			case 50u:
			{
				Types.Moved moved = new Types.Moved();
				if (notificationCase_ == NotificationOneofCase.Moved)
				{
					moved.MergeFrom(Moved);
				}
				input.ReadMessage(moved);
				Moved = moved;
				break;
			}
			case 58u:
			{
				Types.Removed removed = new Types.Removed();
				if (notificationCase_ == NotificationOneofCase.Removed)
				{
					removed.MergeFrom(Removed);
				}
				input.ReadMessage(removed);
				Removed = removed;
				break;
			}
			}
		}
	}
}
