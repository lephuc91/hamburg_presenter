using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.MediaManagement.v2;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class AddProContentReference : IMessage<AddProContentReference>, IMessage, IEquatable<AddProContentReference>, IDeepCloneable<AddProContentReference>
{
	private static readonly MessageParser<AddProContentReference> _parser = new MessageParser<AddProContentReference>(() => new AddProContentReference());

	private UnknownFieldSet _unknownFields;

	private int _hasBits0;

	public const int IdFieldNumber = 1;

	private ReferenceIdentifier id_;

	public const int DownloadDetailsFieldNumber = 2;

	private ProContentDownloadDetails downloadDetails_;

	public const int TransformationFieldNumber = 3;

	private Transformation transformation_;

	public const int PriorityFieldNumber = 4;

	private Priority priority_;

	public const int UserInitiatedFieldNumber = 5;

	private static readonly bool UserInitiatedDefaultValue = false;

	private bool userInitiated_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<AddProContentReference> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => V2HelperCommonReflection.Descriptor.MessageTypes[18];

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
	public ProContentDownloadDetails DownloadDetails
	{
		get
		{
			return downloadDetails_;
		}
		set
		{
			downloadDetails_ = value;
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
	public bool UserInitiated
	{
		get
		{
			if ((_hasBits0 & 1) != 0)
			{
				return userInitiated_;
			}
			return UserInitiatedDefaultValue;
		}
		set
		{
			_hasBits0 |= 1;
			userInitiated_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool HasUserInitiated => (_hasBits0 & 1) != 0;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AddProContentReference()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AddProContentReference(AddProContentReference other)
		: this()
	{
		_hasBits0 = other._hasBits0;
		id_ = ((other.id_ != null) ? other.id_.Clone() : null);
		downloadDetails_ = ((other.downloadDetails_ != null) ? other.downloadDetails_.Clone() : null);
		transformation_ = ((other.transformation_ != null) ? other.transformation_.Clone() : null);
		priority_ = other.priority_;
		userInitiated_ = other.userInitiated_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AddProContentReference Clone()
	{
		return new AddProContentReference(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void ClearUserInitiated()
	{
		_hasBits0 &= -2;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as AddProContentReference);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(AddProContentReference other)
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
		if (!object.Equals(DownloadDetails, other.DownloadDetails))
		{
			return false;
		}
		if (!object.Equals(Transformation, other.Transformation))
		{
			return false;
		}
		if (Priority != other.Priority)
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
		if (downloadDetails_ != null)
		{
			num ^= DownloadDetails.GetHashCode();
		}
		if (transformation_ != null)
		{
			num ^= Transformation.GetHashCode();
		}
		if (Priority != 0)
		{
			num ^= Priority.GetHashCode();
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
		if (downloadDetails_ != null)
		{
			output.WriteRawTag(18);
			output.WriteMessage(DownloadDetails);
		}
		if (transformation_ != null)
		{
			output.WriteRawTag(26);
			output.WriteMessage(Transformation);
		}
		if (Priority != 0)
		{
			output.WriteRawTag(32);
			output.WriteEnum((int)Priority);
		}
		if (HasUserInitiated)
		{
			output.WriteRawTag(40);
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
		if (downloadDetails_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(DownloadDetails);
		}
		if (transformation_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Transformation);
		}
		if (Priority != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)Priority);
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
	public void MergeFrom(AddProContentReference other)
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
		if (other.downloadDetails_ != null)
		{
			if (downloadDetails_ == null)
			{
				DownloadDetails = new ProContentDownloadDetails();
			}
			DownloadDetails.MergeFrom(other.DownloadDetails);
		}
		if (other.transformation_ != null)
		{
			if (transformation_ == null)
			{
				Transformation = new Transformation();
			}
			Transformation.MergeFrom(other.Transformation);
		}
		if (other.Priority != 0)
		{
			Priority = other.Priority;
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
				if (downloadDetails_ == null)
				{
					DownloadDetails = new ProContentDownloadDetails();
				}
				input.ReadMessage(DownloadDetails);
				break;
			case 26u:
				if (transformation_ == null)
				{
					Transformation = new Transformation();
				}
				input.ReadMessage(Transformation);
				break;
			case 32u:
				Priority = (Priority)input.ReadEnum();
				break;
			case 40u:
				UserInitiated = input.ReadBool();
				break;
			}
		}
	}
}
