using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.Startup;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class Preferences : IMessage<Preferences>, IMessage, IEquatable<Preferences>, IDeepCloneable<Preferences>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		public enum CopyrightStyle
		{
			[OriginalName("COPYRIGHT_STYLE_UNKNOWN")]
			Unknown,
			[OriginalName("FIRST")]
			First,
			[OriginalName("LAST")]
			Last,
			[OriginalName("FIRST_AND_LAST")]
			FirstAndLast,
			[OriginalName("ALL_SLIDES")]
			AllSlides
		}

		public enum RenderMode
		{
			[OriginalName("RENDER_MODE_UNKNOWN")]
			Unknown,
			[OriginalName("OPENGL")]
			Opengl,
			[OriginalName("METAL")]
			Metal,
			[OriginalName("DIRECTX")]
			Directx
		}

		public enum UpdateChannel
		{
			[OriginalName("UPDATE_CHANNEL_UNKNOWN")]
			Unknown,
			[OriginalName("RELEASE")]
			Release,
			[OriginalName("BETA")]
			Beta
		}
	}

	private static readonly MessageParser<Preferences> _parser = new MessageParser<Preferences>(() => new Preferences());

	private UnknownFieldSet _unknownFields;

	public const int HouseOfWorshipFieldNumber = 1;

	private bool houseOfWorship_;

	public const int HasCustomLogoFieldNumber = 2;

	private bool hasCustomLogo_;

	public const int CopyrightEnabledFieldNumber = 3;

	private bool copyrightEnabled_;

	public const int CopyrightStyleFieldNumber = 4;

	private Types.CopyrightStyle copyrightStyle_;

	public const int CopyrightHasLicenseFieldNumber = 5;

	private bool copyrightHasLicense_;

	public const int RenderModeFieldNumber = 6;

	private Types.RenderMode renderMode_;

	public const int SuppressAutoStartFieldNumber = 7;

	private bool suppressAutoStart_;

	public const int ManageMediaAutomaticallyFieldNumber = 8;

	private bool manageMediaAutomatically_;

	public const int SearchPathsRelinkFieldNumber = 9;

	private bool searchPathsRelink_;

	public const int UpdateChannelFieldNumber = 10;

	private Types.UpdateChannel updateChannel_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<Preferences> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AnalyticsStartupReflection.Descriptor.MessageTypes[7];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool HouseOfWorship
	{
		get
		{
			return houseOfWorship_;
		}
		set
		{
			houseOfWorship_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool HasCustomLogo
	{
		get
		{
			return hasCustomLogo_;
		}
		set
		{
			hasCustomLogo_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool CopyrightEnabled
	{
		get
		{
			return copyrightEnabled_;
		}
		set
		{
			copyrightEnabled_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.CopyrightStyle CopyrightStyle
	{
		get
		{
			return copyrightStyle_;
		}
		set
		{
			copyrightStyle_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool CopyrightHasLicense
	{
		get
		{
			return copyrightHasLicense_;
		}
		set
		{
			copyrightHasLicense_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.RenderMode RenderMode
	{
		get
		{
			return renderMode_;
		}
		set
		{
			renderMode_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool SuppressAutoStart
	{
		get
		{
			return suppressAutoStart_;
		}
		set
		{
			suppressAutoStart_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool ManageMediaAutomatically
	{
		get
		{
			return manageMediaAutomatically_;
		}
		set
		{
			manageMediaAutomatically_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool SearchPathsRelink
	{
		get
		{
			return searchPathsRelink_;
		}
		set
		{
			searchPathsRelink_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.UpdateChannel UpdateChannel
	{
		get
		{
			return updateChannel_;
		}
		set
		{
			updateChannel_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Preferences()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Preferences(Preferences other)
		: this()
	{
		houseOfWorship_ = other.houseOfWorship_;
		hasCustomLogo_ = other.hasCustomLogo_;
		copyrightEnabled_ = other.copyrightEnabled_;
		copyrightStyle_ = other.copyrightStyle_;
		copyrightHasLicense_ = other.copyrightHasLicense_;
		renderMode_ = other.renderMode_;
		suppressAutoStart_ = other.suppressAutoStart_;
		manageMediaAutomatically_ = other.manageMediaAutomatically_;
		searchPathsRelink_ = other.searchPathsRelink_;
		updateChannel_ = other.updateChannel_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Preferences Clone()
	{
		return new Preferences(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as Preferences);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(Preferences other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (HouseOfWorship != other.HouseOfWorship)
		{
			return false;
		}
		if (HasCustomLogo != other.HasCustomLogo)
		{
			return false;
		}
		if (CopyrightEnabled != other.CopyrightEnabled)
		{
			return false;
		}
		if (CopyrightStyle != other.CopyrightStyle)
		{
			return false;
		}
		if (CopyrightHasLicense != other.CopyrightHasLicense)
		{
			return false;
		}
		if (RenderMode != other.RenderMode)
		{
			return false;
		}
		if (SuppressAutoStart != other.SuppressAutoStart)
		{
			return false;
		}
		if (ManageMediaAutomatically != other.ManageMediaAutomatically)
		{
			return false;
		}
		if (SearchPathsRelink != other.SearchPathsRelink)
		{
			return false;
		}
		if (UpdateChannel != other.UpdateChannel)
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
		if (HouseOfWorship)
		{
			num ^= HouseOfWorship.GetHashCode();
		}
		if (HasCustomLogo)
		{
			num ^= HasCustomLogo.GetHashCode();
		}
		if (CopyrightEnabled)
		{
			num ^= CopyrightEnabled.GetHashCode();
		}
		if (CopyrightStyle != 0)
		{
			num ^= CopyrightStyle.GetHashCode();
		}
		if (CopyrightHasLicense)
		{
			num ^= CopyrightHasLicense.GetHashCode();
		}
		if (RenderMode != 0)
		{
			num ^= RenderMode.GetHashCode();
		}
		if (SuppressAutoStart)
		{
			num ^= SuppressAutoStart.GetHashCode();
		}
		if (ManageMediaAutomatically)
		{
			num ^= ManageMediaAutomatically.GetHashCode();
		}
		if (SearchPathsRelink)
		{
			num ^= SearchPathsRelink.GetHashCode();
		}
		if (UpdateChannel != 0)
		{
			num ^= UpdateChannel.GetHashCode();
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
		if (HouseOfWorship)
		{
			output.WriteRawTag(8);
			output.WriteBool(HouseOfWorship);
		}
		if (HasCustomLogo)
		{
			output.WriteRawTag(16);
			output.WriteBool(HasCustomLogo);
		}
		if (CopyrightEnabled)
		{
			output.WriteRawTag(24);
			output.WriteBool(CopyrightEnabled);
		}
		if (CopyrightStyle != 0)
		{
			output.WriteRawTag(32);
			output.WriteEnum((int)CopyrightStyle);
		}
		if (CopyrightHasLicense)
		{
			output.WriteRawTag(40);
			output.WriteBool(CopyrightHasLicense);
		}
		if (RenderMode != 0)
		{
			output.WriteRawTag(48);
			output.WriteEnum((int)RenderMode);
		}
		if (SuppressAutoStart)
		{
			output.WriteRawTag(56);
			output.WriteBool(SuppressAutoStart);
		}
		if (ManageMediaAutomatically)
		{
			output.WriteRawTag(64);
			output.WriteBool(ManageMediaAutomatically);
		}
		if (SearchPathsRelink)
		{
			output.WriteRawTag(72);
			output.WriteBool(SearchPathsRelink);
		}
		if (UpdateChannel != 0)
		{
			output.WriteRawTag(80);
			output.WriteEnum((int)UpdateChannel);
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
		if (HouseOfWorship)
		{
			num += 2;
		}
		if (HasCustomLogo)
		{
			num += 2;
		}
		if (CopyrightEnabled)
		{
			num += 2;
		}
		if (CopyrightStyle != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)CopyrightStyle);
		}
		if (CopyrightHasLicense)
		{
			num += 2;
		}
		if (RenderMode != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)RenderMode);
		}
		if (SuppressAutoStart)
		{
			num += 2;
		}
		if (ManageMediaAutomatically)
		{
			num += 2;
		}
		if (SearchPathsRelink)
		{
			num += 2;
		}
		if (UpdateChannel != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)UpdateChannel);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(Preferences other)
	{
		if (other != null)
		{
			if (other.HouseOfWorship)
			{
				HouseOfWorship = other.HouseOfWorship;
			}
			if (other.HasCustomLogo)
			{
				HasCustomLogo = other.HasCustomLogo;
			}
			if (other.CopyrightEnabled)
			{
				CopyrightEnabled = other.CopyrightEnabled;
			}
			if (other.CopyrightStyle != 0)
			{
				CopyrightStyle = other.CopyrightStyle;
			}
			if (other.CopyrightHasLicense)
			{
				CopyrightHasLicense = other.CopyrightHasLicense;
			}
			if (other.RenderMode != 0)
			{
				RenderMode = other.RenderMode;
			}
			if (other.SuppressAutoStart)
			{
				SuppressAutoStart = other.SuppressAutoStart;
			}
			if (other.ManageMediaAutomatically)
			{
				ManageMediaAutomatically = other.ManageMediaAutomatically;
			}
			if (other.SearchPathsRelink)
			{
				SearchPathsRelink = other.SearchPathsRelink;
			}
			if (other.UpdateChannel != 0)
			{
				UpdateChannel = other.UpdateChannel;
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
				HouseOfWorship = input.ReadBool();
				break;
			case 16u:
				HasCustomLogo = input.ReadBool();
				break;
			case 24u:
				CopyrightEnabled = input.ReadBool();
				break;
			case 32u:
				CopyrightStyle = (Types.CopyrightStyle)input.ReadEnum();
				break;
			case 40u:
				CopyrightHasLicense = input.ReadBool();
				break;
			case 48u:
				RenderMode = (Types.RenderMode)input.ReadEnum();
				break;
			case 56u:
				SuppressAutoStart = input.ReadBool();
				break;
			case 64u:
				ManageMediaAutomatically = input.ReadBool();
				break;
			case 72u:
				SearchPathsRelink = input.ReadBool();
				break;
			case 80u:
				UpdateChannel = (Types.UpdateChannel)input.ReadEnum();
				break;
			}
		}
	}
}
