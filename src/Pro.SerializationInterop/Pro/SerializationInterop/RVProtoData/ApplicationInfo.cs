using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class ApplicationInfo : IMessage<ApplicationInfo>, IMessage, IEquatable<ApplicationInfo>, IDeepCloneable<ApplicationInfo>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		public enum Platform
		{
			[OriginalName("PLATFORM_UNDEFINED")]
			Undefined,
			[OriginalName("PLATFORM_MACOS")]
			Macos,
			[OriginalName("PLATFORM_WINDOWS")]
			Windows
		}

		public enum Application
		{
			[OriginalName("APPLICATION_UNDEFINED")]
			Undefined,
			[OriginalName("APPLICATION_PROPRESENTER")]
			Propresenter,
			[OriginalName("APPLICATION_PVP")]
			Pvp,
			[OriginalName("APPLICATION_PROVIDEOSERVER")]
			Provideoserver,
			[OriginalName("APPLICATION_SCOREBOARD")]
			Scoreboard
		}
	}

	private static readonly MessageParser<ApplicationInfo> _parser = new MessageParser<ApplicationInfo>(() => new ApplicationInfo());

	private UnknownFieldSet _unknownFields;

	public const int PlatformFieldNumber = 1;

	private Types.Platform platform_;

	public const int PlatformVersionFieldNumber = 2;

	private Version platformVersion_;

	public const int ApplicationFieldNumber = 3;

	private Types.Application application_;

	public const int ApplicationVersionFieldNumber = 4;

	private Version applicationVersion_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<ApplicationInfo> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ApplicationInfoReflection.Descriptor.MessageTypes[0];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Platform Platform
	{
		get
		{
			return platform_;
		}
		set
		{
			platform_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Version PlatformVersion
	{
		get
		{
			return platformVersion_;
		}
		set
		{
			platformVersion_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Application Application
	{
		get
		{
			return application_;
		}
		set
		{
			application_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Version ApplicationVersion
	{
		get
		{
			return applicationVersion_;
		}
		set
		{
			applicationVersion_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ApplicationInfo()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ApplicationInfo(ApplicationInfo other)
		: this()
	{
		platform_ = other.platform_;
		platformVersion_ = ((other.platformVersion_ != null) ? other.platformVersion_.Clone() : null);
		application_ = other.application_;
		applicationVersion_ = ((other.applicationVersion_ != null) ? other.applicationVersion_.Clone() : null);
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ApplicationInfo Clone()
	{
		return new ApplicationInfo(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as ApplicationInfo);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(ApplicationInfo other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (Platform != other.Platform)
		{
			return false;
		}
		if (!object.Equals(PlatformVersion, other.PlatformVersion))
		{
			return false;
		}
		if (Application != other.Application)
		{
			return false;
		}
		if (!object.Equals(ApplicationVersion, other.ApplicationVersion))
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
		if (Platform != 0)
		{
			num ^= Platform.GetHashCode();
		}
		if (platformVersion_ != null)
		{
			num ^= PlatformVersion.GetHashCode();
		}
		if (Application != 0)
		{
			num ^= Application.GetHashCode();
		}
		if (applicationVersion_ != null)
		{
			num ^= ApplicationVersion.GetHashCode();
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
		if (Platform != 0)
		{
			output.WriteRawTag(8);
			output.WriteEnum((int)Platform);
		}
		if (platformVersion_ != null)
		{
			output.WriteRawTag(18);
			output.WriteMessage(PlatformVersion);
		}
		if (Application != 0)
		{
			output.WriteRawTag(24);
			output.WriteEnum((int)Application);
		}
		if (applicationVersion_ != null)
		{
			output.WriteRawTag(34);
			output.WriteMessage(ApplicationVersion);
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
		if (Platform != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)Platform);
		}
		if (platformVersion_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PlatformVersion);
		}
		if (Application != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)Application);
		}
		if (applicationVersion_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(ApplicationVersion);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(ApplicationInfo other)
	{
		if (other == null)
		{
			return;
		}
		if (other.Platform != 0)
		{
			Platform = other.Platform;
		}
		if (other.platformVersion_ != null)
		{
			if (platformVersion_ == null)
			{
				PlatformVersion = new Version();
			}
			PlatformVersion.MergeFrom(other.PlatformVersion);
		}
		if (other.Application != 0)
		{
			Application = other.Application;
		}
		if (other.applicationVersion_ != null)
		{
			if (applicationVersion_ == null)
			{
				ApplicationVersion = new Version();
			}
			ApplicationVersion.MergeFrom(other.ApplicationVersion);
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
			case 8u:
				Platform = (Types.Platform)input.ReadEnum();
				break;
			case 18u:
				if (platformVersion_ == null)
				{
					PlatformVersion = new Version();
				}
				input.ReadMessage(PlatformVersion);
				break;
			case 24u:
				Application = (Types.Application)input.ReadEnum();
				break;
			case 34u:
				if (applicationVersion_ == null)
				{
					ApplicationVersion = new Version();
				}
				input.ReadMessage(ApplicationVersion);
				break;
			}
		}
	}
}
