using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class CCLIDocument : IMessage<CCLIDocument>, IMessage, IEquatable<CCLIDocument>, IDeepCloneable<CCLIDocument>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		public enum DisplayType
		{
			[OriginalName("DISPLAY_TYPE_FIRST_SLIDE")]
			FirstSlide,
			[OriginalName("DISPLAY_TYPE_LAST_SLIDE")]
			LastSlide,
			[OriginalName("DISPLAY_TYPE_FIRST_AND_LAST_SLIDE")]
			FirstAndLastSlide,
			[OriginalName("DISPLAY_TYPE_ALL_SLIDES")]
			AllSlides
		}
	}

	private static readonly MessageParser<CCLIDocument> _parser = new MessageParser<CCLIDocument>(() => new CCLIDocument());

	private UnknownFieldSet _unknownFields;

	public const int ApplicationInfoFieldNumber = 1;

	private ApplicationInfo applicationInfo_;

	public const int EnableCcliDisplayFieldNumber = 2;

	private bool enableCcliDisplay_;

	public const int CcliLicenseFieldNumber = 3;

	private string ccliLicense_ = "";

	public const int DisplayTypeFieldNumber = 4;

	private Types.DisplayType displayType_;

	public const int TemplateFieldNumber = 5;

	private Template.Types.Slide template_;

	public const int LayoutFieldNumber = 6;

	private CopyrightLayout layout_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<CCLIDocument> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => CcliReflection.Descriptor.MessageTypes[0];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ApplicationInfo ApplicationInfo
	{
		get
		{
			return applicationInfo_;
		}
		set
		{
			applicationInfo_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool EnableCcliDisplay
	{
		get
		{
			return enableCcliDisplay_;
		}
		set
		{
			enableCcliDisplay_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string CcliLicense
	{
		get
		{
			return ccliLicense_;
		}
		set
		{
			ccliLicense_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.DisplayType DisplayType
	{
		get
		{
			return displayType_;
		}
		set
		{
			displayType_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Template.Types.Slide Template
	{
		get
		{
			return template_;
		}
		set
		{
			template_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public CopyrightLayout Layout
	{
		get
		{
			return layout_;
		}
		set
		{
			layout_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public CCLIDocument()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public CCLIDocument(CCLIDocument other)
		: this()
	{
		applicationInfo_ = ((other.applicationInfo_ != null) ? other.applicationInfo_.Clone() : null);
		enableCcliDisplay_ = other.enableCcliDisplay_;
		ccliLicense_ = other.ccliLicense_;
		displayType_ = other.displayType_;
		template_ = ((other.template_ != null) ? other.template_.Clone() : null);
		layout_ = ((other.layout_ != null) ? other.layout_.Clone() : null);
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public CCLIDocument Clone()
	{
		return new CCLIDocument(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as CCLIDocument);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(CCLIDocument other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(ApplicationInfo, other.ApplicationInfo))
		{
			return false;
		}
		if (EnableCcliDisplay != other.EnableCcliDisplay)
		{
			return false;
		}
		if (CcliLicense != other.CcliLicense)
		{
			return false;
		}
		if (DisplayType != other.DisplayType)
		{
			return false;
		}
		if (!object.Equals(Template, other.Template))
		{
			return false;
		}
		if (!object.Equals(Layout, other.Layout))
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
		if (applicationInfo_ != null)
		{
			num ^= ApplicationInfo.GetHashCode();
		}
		if (EnableCcliDisplay)
		{
			num ^= EnableCcliDisplay.GetHashCode();
		}
		if (CcliLicense.Length != 0)
		{
			num ^= CcliLicense.GetHashCode();
		}
		if (DisplayType != 0)
		{
			num ^= DisplayType.GetHashCode();
		}
		if (template_ != null)
		{
			num ^= Template.GetHashCode();
		}
		if (layout_ != null)
		{
			num ^= Layout.GetHashCode();
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
		if (applicationInfo_ != null)
		{
			output.WriteRawTag(10);
			output.WriteMessage(ApplicationInfo);
		}
		if (EnableCcliDisplay)
		{
			output.WriteRawTag(16);
			output.WriteBool(EnableCcliDisplay);
		}
		if (CcliLicense.Length != 0)
		{
			output.WriteRawTag(26);
			output.WriteString(CcliLicense);
		}
		if (DisplayType != 0)
		{
			output.WriteRawTag(32);
			output.WriteEnum((int)DisplayType);
		}
		if (template_ != null)
		{
			output.WriteRawTag(42);
			output.WriteMessage(Template);
		}
		if (layout_ != null)
		{
			output.WriteRawTag(50);
			output.WriteMessage(Layout);
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
		if (applicationInfo_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(ApplicationInfo);
		}
		if (EnableCcliDisplay)
		{
			num += 2;
		}
		if (CcliLicense.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(CcliLicense);
		}
		if (DisplayType != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)DisplayType);
		}
		if (template_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Template);
		}
		if (layout_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Layout);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(CCLIDocument other)
	{
		if (other == null)
		{
			return;
		}
		if (other.applicationInfo_ != null)
		{
			if (applicationInfo_ == null)
			{
				ApplicationInfo = new ApplicationInfo();
			}
			ApplicationInfo.MergeFrom(other.ApplicationInfo);
		}
		if (other.EnableCcliDisplay)
		{
			EnableCcliDisplay = other.EnableCcliDisplay;
		}
		if (other.CcliLicense.Length != 0)
		{
			CcliLicense = other.CcliLicense;
		}
		if (other.DisplayType != 0)
		{
			DisplayType = other.DisplayType;
		}
		if (other.template_ != null)
		{
			if (template_ == null)
			{
				Template = new Template.Types.Slide();
			}
			Template.MergeFrom(other.Template);
		}
		if (other.layout_ != null)
		{
			if (layout_ == null)
			{
				Layout = new CopyrightLayout();
			}
			Layout.MergeFrom(other.Layout);
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
				if (applicationInfo_ == null)
				{
					ApplicationInfo = new ApplicationInfo();
				}
				input.ReadMessage(ApplicationInfo);
				break;
			case 16u:
				EnableCcliDisplay = input.ReadBool();
				break;
			case 26u:
				CcliLicense = input.ReadString();
				break;
			case 32u:
				DisplayType = (Types.DisplayType)input.ReadEnum();
				break;
			case 42u:
				if (template_ == null)
				{
					Template = new Template.Types.Slide();
				}
				input.ReadMessage(Template);
				break;
			case 50u:
				if (layout_ == null)
				{
					Layout = new CopyrightLayout();
				}
				input.ReadMessage(Layout);
				break;
			}
		}
	}
}
