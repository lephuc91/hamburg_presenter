using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class NetworkIdentifier : IMessage<NetworkIdentifier>, IMessage, IEquatable<NetworkIdentifier>, IDeepCloneable<NetworkIdentifier>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class IndexOrName : IMessage<IndexOrName>, IMessage, IEquatable<IndexOrName>, IDeepCloneable<IndexOrName>
		{
			public enum ComponentOneofCase
			{
				None,
				Index,
				Name
			}

			private static readonly MessageParser<IndexOrName> _parser = new MessageParser<IndexOrName>(() => new IndexOrName());

			private UnknownFieldSet _unknownFields;

			public const int IndexFieldNumber = 1;

			public const int NameFieldNumber = 2;

			private object component_;

			private ComponentOneofCase componentCase_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<IndexOrName> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => NetworkIdentifier.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public int Index
			{
				get
				{
					if (!HasIndex)
					{
						return 0;
					}
					return (int)component_;
				}
				set
				{
					component_ = value;
					componentCase_ = ComponentOneofCase.Index;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool HasIndex => componentCase_ == ComponentOneofCase.Index;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string Name
			{
				get
				{
					if (!HasName)
					{
						return "";
					}
					return (string)component_;
				}
				set
				{
					component_ = ProtoPreconditions.CheckNotNull(value, "value");
					componentCase_ = ComponentOneofCase.Name;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool HasName => componentCase_ == ComponentOneofCase.Name;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ComponentOneofCase ComponentCase => componentCase_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public IndexOrName()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public IndexOrName(IndexOrName other)
				: this()
			{
				switch (other.ComponentCase)
				{
				case ComponentOneofCase.Index:
					Index = other.Index;
					break;
				case ComponentOneofCase.Name:
					Name = other.Name;
					break;
				}
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public IndexOrName Clone()
			{
				return new IndexOrName(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void ClearIndex()
			{
				if (HasIndex)
				{
					ClearComponent();
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void ClearName()
			{
				if (HasName)
				{
					ClearComponent();
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void ClearComponent()
			{
				componentCase_ = ComponentOneofCase.None;
				component_ = null;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as IndexOrName);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(IndexOrName other)
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
				if (Name != other.Name)
				{
					return false;
				}
				if (ComponentCase != other.ComponentCase)
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
				if (HasIndex)
				{
					num ^= Index.GetHashCode();
				}
				if (HasName)
				{
					num ^= Name.GetHashCode();
				}
				num ^= (int)componentCase_;
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
				if (HasIndex)
				{
					output.WriteRawTag(8);
					output.WriteInt32(Index);
				}
				if (HasName)
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
				if (HasIndex)
				{
					num += 1 + CodedOutputStream.ComputeInt32Size(Index);
				}
				if (HasName)
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
			public void MergeFrom(IndexOrName other)
			{
				if (other != null)
				{
					switch (other.ComponentCase)
					{
					case ComponentOneofCase.Index:
						Index = other.Index;
						break;
					case ComponentOneofCase.Name:
						Name = other.Name;
						break;
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
					case 18u:
						Name = input.ReadString();
						break;
					}
				}
			}
		}
	}

	private static readonly MessageParser<NetworkIdentifier> _parser = new MessageParser<NetworkIdentifier>(() => new NetworkIdentifier());

	private UnknownFieldSet _unknownFields;

	public const int IdentifiersFieldNumber = 1;

	private static readonly FieldCodec<Types.IndexOrName> _repeated_identifiers_codec = FieldCodec.ForMessage(10u, Types.IndexOrName.Parser);

	private readonly RepeatedField<Types.IndexOrName> identifiers_ = new RepeatedField<Types.IndexOrName>();

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<NetworkIdentifier> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProCoreReflection.Descriptor.MessageTypes[0];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<Types.IndexOrName> Identifiers => identifiers_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public NetworkIdentifier()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public NetworkIdentifier(NetworkIdentifier other)
		: this()
	{
		identifiers_ = other.identifiers_.Clone();
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public NetworkIdentifier Clone()
	{
		return new NetworkIdentifier(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as NetworkIdentifier);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(NetworkIdentifier other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!identifiers_.Equals(other.identifiers_))
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
		num ^= identifiers_.GetHashCode();
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
		identifiers_.WriteTo(output, _repeated_identifiers_codec);
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
		num += identifiers_.CalculateSize(_repeated_identifiers_codec);
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(NetworkIdentifier other)
	{
		if (other != null)
		{
			identifiers_.Add(other.identifiers_);
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
				identifiers_.AddEntriesFrom(input, _repeated_identifiers_codec);
			}
		}
	}
}
