using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.MediaManagement.v2;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class AddMediaReference : IMessage<AddMediaReference>, IMessage, IEquatable<AddMediaReference>, IDeepCloneable<AddMediaReference>
{
	private static readonly MessageParser<AddMediaReference> _parser = new MessageParser<AddMediaReference>(() => new AddMediaReference());

	private UnknownFieldSet _unknownFields;

	private int _hasBits0;

	public const int IdFieldNumber = 1;

	private ReferenceIdentifier id_;

	public const int UrlFieldNumber = 2;

	private string url_ = "";

	public const int PriorityFieldNumber = 3;

	private Priority priority_;

	public const int TransformationFieldNumber = 4;

	private Transformation transformation_;

	public const int ManageMediaFieldNumber = 5;

	private static readonly bool ManageMediaDefaultValue = false;

	private bool manageMedia_;

	public const int UserInitiatedFieldNumber = 6;

	private static readonly bool UserInitiatedDefaultValue = false;

	private bool userInitiated_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<AddMediaReference> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => V2HelperCommonReflection.Descriptor.MessageTypes[16];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ReferenceIdentifier Id
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
	public string Url
	{
		get
		{
			return url_;
		}
		set
		{
			url_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Priority Priority
	{
		get
		{
			return priority_;
		}
		set
		{
			priority_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Transformation Transformation
	{
		get
		{
			return transformation_;
		}
		set
		{
			transformation_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool ManageMedia
	{
		get
		{
			if ((_hasBits0 & 1) != 0)
			{
				return manageMedia_;
			}
			return ManageMediaDefaultValue;
		}
		set
		{
			_hasBits0 |= 1;
			manageMedia_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool HasManageMedia => (_hasBits0 & 1) != 0;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool UserInitiated
	{
		get
		{
			if ((_hasBits0 & 2) != 0)
			{
				return userInitiated_;
			}
			return UserInitiatedDefaultValue;
		}
		set
		{
			_hasBits0 |= 2;
			userInitiated_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool HasUserInitiated => (_hasBits0 & 2) != 0;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AddMediaReference()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AddMediaReference(AddMediaReference other)
		: this()
	{
		_hasBits0 = other._hasBits0;
		id_ = ((other.id_ != null) ? other.id_.Clone() : null);
		url_ = other.url_;
		priority_ = other.priority_;
		transformation_ = ((other.transformation_ != null) ? other.transformation_.Clone() : null);
		manageMedia_ = other.manageMedia_;
		userInitiated_ = other.userInitiated_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AddMediaReference Clone()
	{
		return new AddMediaReference(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void ClearManageMedia()
	{
		_hasBits0 &= -2;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void ClearUserInitiated()
	{
		_hasBits0 &= -3;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as AddMediaReference);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(AddMediaReference other)
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
		if (Url != other.Url)
		{
			return false;
		}
		if (Priority != other.Priority)
		{
			return false;
		}
		if (!object.Equals(Transformation, other.Transformation))
		{
			return false;
		}
		if (ManageMedia != other.ManageMedia)
		{
			return false;
		}
		if (UserInitiated != other.UserInitiated)
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
		if (Url.Length != 0)
		{
			num ^= Url.GetHashCode();
		}
		if (Priority != 0)
		{
			num ^= Priority.GetHashCode();
		}
		if (transformation_ != null)
		{
			num ^= Transformation.GetHashCode();
		}
		if (HasManageMedia)
		{
			num ^= ManageMedia.GetHashCode();
		}
		if (HasUserInitiated)
		{
			num ^= UserInitiated.GetHashCode();
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
		if (Url.Length != 0)
		{
			output.WriteRawTag(18);
			output.WriteString(Url);
		}
		if (Priority != 0)
		{
			output.WriteRawTag(24);
			output.WriteEnum((int)Priority);
		}
		if (transformation_ != null)
		{
			output.WriteRawTag(34);
			output.WriteMessage(Transformation);
		}
		if (HasManageMedia)
		{
			output.WriteRawTag(40);
			output.WriteBool(ManageMedia);
		}
		if (HasUserInitiated)
		{
			output.WriteRawTag(48);
			output.WriteBool(UserInitiated);
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
		if (Url.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Url);
		}
		if (Priority != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)Priority);
		}
		if (transformation_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Transformation);
		}
		if (HasManageMedia)
		{
			num += 2;
		}
		if (HasUserInitiated)
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
	public void MergeFrom(AddMediaReference other)
	{
		if (other == null)
		{
			return;
		}
		if (other.id_ != null)
		{
			if (id_ == null)
			{
				Id = new ReferenceIdentifier();
			}
			Id.MergeFrom(other.Id);
		}
		if (other.Url.Length != 0)
		{
			Url = other.Url;
		}
		if (other.Priority != 0)
		{
			Priority = other.Priority;
		}
		if (other.transformation_ != null)
		{
			if (transformation_ == null)
			{
				Transformation = new Transformation();
			}
			Transformation.MergeFrom(other.Transformation);
		}
		if (other.HasManageMedia)
		{
			ManageMedia = other.ManageMedia;
		}
		if (other.HasUserInitiated)
		{
			UserInitiated = other.UserInitiated;
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
					Id = new ReferenceIdentifier();
				}
				input.ReadMessage(Id);
				break;
			case 18u:
				Url = input.ReadString();
				break;
			case 24u:
				Priority = (Priority)input.ReadEnum();
				break;
			case 34u:
				if (transformation_ == null)
				{
					Transformation = new Transformation();
				}
				input.ReadMessage(Transformation);
				break;
			case 40u:
				ManageMedia = input.ReadBool();
				break;
			case 48u:
				UserInitiated = input.ReadBool();
				break;
			}
		}
	}
}
