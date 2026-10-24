using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class CloudProPresenterScreen : IMessage<CloudProPresenterScreen>, IMessage, IEquatable<CloudProPresenterScreen>, IDeepCloneable<CloudProPresenterScreen>
{
	private static readonly MessageParser<CloudProPresenterScreen> _parser = new MessageParser<CloudProPresenterScreen>(() => new CloudProPresenterScreen());

	private UnknownFieldSet _unknownFields;

	public const int NameFieldNumber = 1;

	private string name_ = "";

	public const int ScreenTypeFieldNumber = 2;

	private ProPresenterScreen.Types.ScreenType screenType_;

	public const int UuidFieldNumber = 6;

	private UUID uuid_;

	public const int SizeFieldNumber = 7;

	private Graphics.Types.Size size_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<CloudProPresenterScreen> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProscreenReflection.Descriptor.MessageTypes[1];

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
	public ProPresenterScreen.Types.ScreenType ScreenType
	{
		get
		{
			return screenType_;
		}
		set
		{
			screenType_ = value;
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
	public CloudProPresenterScreen()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public CloudProPresenterScreen(CloudProPresenterScreen other)
		: this()
	{
		name_ = other.name_;
		screenType_ = other.screenType_;
		uuid_ = ((other.uuid_ != null) ? other.uuid_.Clone() : null);
		size_ = ((other.size_ != null) ? other.size_.Clone() : null);
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public CloudProPresenterScreen Clone()
	{
		return new CloudProPresenterScreen(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as CloudProPresenterScreen);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(CloudProPresenterScreen other)
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
		if (ScreenType != other.ScreenType)
		{
			return false;
		}
		if (!object.Equals(Uuid, other.Uuid))
		{
			return false;
		}
		if (!object.Equals(Size, other.Size))
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
		if (ScreenType != 0)
		{
			num ^= ScreenType.GetHashCode();
		}
		if (uuid_ != null)
		{
			num ^= Uuid.GetHashCode();
		}
		if (size_ != null)
		{
			num ^= Size.GetHashCode();
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
		if (ScreenType != 0)
		{
			output.WriteRawTag(16);
			output.WriteEnum((int)ScreenType);
		}
		if (uuid_ != null)
		{
			output.WriteRawTag(50);
			output.WriteMessage(Uuid);
		}
		if (size_ != null)
		{
			output.WriteRawTag(58);
			output.WriteMessage(Size);
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
		if (ScreenType != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)ScreenType);
		}
		if (uuid_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Uuid);
		}
		if (size_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Size);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(CloudProPresenterScreen other)
	{
		if (other == null)
		{
			return;
		}
		if (other.Name.Length != 0)
		{
			Name = other.Name;
		}
		if (other.ScreenType != 0)
		{
			ScreenType = other.ScreenType;
		}
		if (other.uuid_ != null)
		{
			if (uuid_ == null)
			{
				Uuid = new UUID();
			}
			Uuid.MergeFrom(other.Uuid);
		}
		if (other.size_ != null)
		{
			if (size_ == null)
			{
				Size = new Graphics.Types.Size();
			}
			Size.MergeFrom(other.Size);
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
			case 16u:
				ScreenType = (ProPresenterScreen.Types.ScreenType)input.ReadEnum();
				break;
			case 50u:
				if (uuid_ == null)
				{
					Uuid = new UUID();
				}
				input.ReadMessage(Uuid);
				break;
			case 58u:
				if (size_ == null)
				{
					Size = new Graphics.Types.Size();
				}
				input.ReadMessage(Size);
				break;
			}
		}
	}
}
