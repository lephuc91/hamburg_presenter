using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class TestPatternState : IMessage<TestPatternState>, IMessage, IEquatable<TestPatternState>, IDeepCloneable<TestPatternState>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		public enum DisplayLocation
		{
			[OriginalName("DISPLAY_LOCATION_ALL_SCREENS")]
			AllScreens,
			[OriginalName("DISPLAY_LOCATION_AUDIENCE_SCREENS")]
			AudienceScreens,
			[OriginalName("DISPLAY_LOCATION_STAGE_SCREENS")]
			StageScreens,
			[OriginalName("DISPLAY_LOCATION_SPECIFIC_SCREEN")]
			SpecificScreen
		}
	}

	private static readonly MessageParser<TestPatternState> _parser = new MessageParser<TestPatternState>(() => new TestPatternState());

	private UnknownFieldSet _unknownFields;

	public const int PatternFieldNumber = 1;

	private TestPatternDefinition pattern_;

	public const int ShowPatternFieldNumber = 2;

	private bool showPattern_;

	public const int DisplayLocationFieldNumber = 3;

	private Types.DisplayLocation displayLocation_;

	public const int SpecificScreenFieldNumber = 4;

	private UUID specificScreen_;

	public const int IdentifyScreensFieldNumber = 5;

	private bool identifyScreens_;

	public const int LogoTypeFieldNumber = 6;

	private LogoType logoType_;

	public const int UserLogoLocationFieldNumber = 7;

	private URL userLogoLocation_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<TestPatternState> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => TestPatternReflection.Descriptor.MessageTypes[3];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TestPatternDefinition Pattern
	{
		get
		{
			return pattern_;
		}
		set
		{
			pattern_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool ShowPattern
	{
		get
		{
			return showPattern_;
		}
		set
		{
			showPattern_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.DisplayLocation DisplayLocation
	{
		get
		{
			return displayLocation_;
		}
		set
		{
			displayLocation_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public UUID SpecificScreen
	{
		get
		{
			return specificScreen_;
		}
		set
		{
			specificScreen_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool IdentifyScreens
	{
		get
		{
			return identifyScreens_;
		}
		set
		{
			identifyScreens_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LogoType LogoType
	{
		get
		{
			return logoType_;
		}
		set
		{
			logoType_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public URL UserLogoLocation
	{
		get
		{
			return userLogoLocation_;
		}
		set
		{
			userLogoLocation_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TestPatternState()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TestPatternState(TestPatternState other)
		: this()
	{
		pattern_ = ((other.pattern_ != null) ? other.pattern_.Clone() : null);
		showPattern_ = other.showPattern_;
		displayLocation_ = other.displayLocation_;
		specificScreen_ = ((other.specificScreen_ != null) ? other.specificScreen_.Clone() : null);
		identifyScreens_ = other.identifyScreens_;
		logoType_ = other.logoType_;
		userLogoLocation_ = ((other.userLogoLocation_ != null) ? other.userLogoLocation_.Clone() : null);
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TestPatternState Clone()
	{
		return new TestPatternState(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as TestPatternState);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(TestPatternState other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(Pattern, other.Pattern))
		{
			return false;
		}
		if (ShowPattern != other.ShowPattern)
		{
			return false;
		}
		if (DisplayLocation != other.DisplayLocation)
		{
			return false;
		}
		if (!object.Equals(SpecificScreen, other.SpecificScreen))
		{
			return false;
		}
		if (IdentifyScreens != other.IdentifyScreens)
		{
			return false;
		}
		if (LogoType != other.LogoType)
		{
			return false;
		}
		if (!object.Equals(UserLogoLocation, other.UserLogoLocation))
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
		if (pattern_ != null)
		{
			num ^= Pattern.GetHashCode();
		}
		if (ShowPattern)
		{
			num ^= ShowPattern.GetHashCode();
		}
		if (DisplayLocation != 0)
		{
			num ^= DisplayLocation.GetHashCode();
		}
		if (specificScreen_ != null)
		{
			num ^= SpecificScreen.GetHashCode();
		}
		if (IdentifyScreens)
		{
			num ^= IdentifyScreens.GetHashCode();
		}
		if (LogoType != 0)
		{
			num ^= LogoType.GetHashCode();
		}
		if (userLogoLocation_ != null)
		{
			num ^= UserLogoLocation.GetHashCode();
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
		if (pattern_ != null)
		{
			output.WriteRawTag(10);
			output.WriteMessage(Pattern);
		}
		if (ShowPattern)
		{
			output.WriteRawTag(16);
			output.WriteBool(ShowPattern);
		}
		if (DisplayLocation != 0)
		{
			output.WriteRawTag(24);
			output.WriteEnum((int)DisplayLocation);
		}
		if (specificScreen_ != null)
		{
			output.WriteRawTag(34);
			output.WriteMessage(SpecificScreen);
		}
		if (IdentifyScreens)
		{
			output.WriteRawTag(40);
			output.WriteBool(IdentifyScreens);
		}
		if (LogoType != 0)
		{
			output.WriteRawTag(48);
			output.WriteEnum((int)LogoType);
		}
		if (userLogoLocation_ != null)
		{
			output.WriteRawTag(58);
			output.WriteMessage(UserLogoLocation);
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
		if (pattern_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Pattern);
		}
		if (ShowPattern)
		{
			num += 2;
		}
		if (DisplayLocation != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)DisplayLocation);
		}
		if (specificScreen_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(SpecificScreen);
		}
		if (IdentifyScreens)
		{
			num += 2;
		}
		if (LogoType != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)LogoType);
		}
		if (userLogoLocation_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(UserLogoLocation);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(TestPatternState other)
	{
		if (other == null)
		{
			return;
		}
		if (other.pattern_ != null)
		{
			if (pattern_ == null)
			{
				Pattern = new TestPatternDefinition();
			}
			Pattern.MergeFrom(other.Pattern);
		}
		if (other.ShowPattern)
		{
			ShowPattern = other.ShowPattern;
		}
		if (other.DisplayLocation != 0)
		{
			DisplayLocation = other.DisplayLocation;
		}
		if (other.specificScreen_ != null)
		{
			if (specificScreen_ == null)
			{
				SpecificScreen = new UUID();
			}
			SpecificScreen.MergeFrom(other.SpecificScreen);
		}
		if (other.IdentifyScreens)
		{
			IdentifyScreens = other.IdentifyScreens;
		}
		if (other.LogoType != 0)
		{
			LogoType = other.LogoType;
		}
		if (other.userLogoLocation_ != null)
		{
			if (userLogoLocation_ == null)
			{
				UserLogoLocation = new URL();
			}
			UserLogoLocation.MergeFrom(other.UserLogoLocation);
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
				if (pattern_ == null)
				{
					Pattern = new TestPatternDefinition();
				}
				input.ReadMessage(Pattern);
				break;
			case 16u:
				ShowPattern = input.ReadBool();
				break;
			case 24u:
				DisplayLocation = (Types.DisplayLocation)input.ReadEnum();
				break;
			case 34u:
				if (specificScreen_ == null)
				{
					SpecificScreen = new UUID();
				}
				input.ReadMessage(SpecificScreen);
				break;
			case 40u:
				IdentifyScreens = input.ReadBool();
				break;
			case 48u:
				LogoType = (LogoType)input.ReadEnum();
				break;
			case 58u:
				if (userLogoLocation_ == null)
				{
					UserLogoLocation = new URL();
				}
				input.ReadMessage(UserLogoLocation);
				break;
			}
		}
	}
}
