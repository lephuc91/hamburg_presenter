using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.Startup;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class Screens : IMessage<Screens>, IMessage, IEquatable<Screens>, IDeepCloneable<Screens>
{
	private static readonly MessageParser<Screens> _parser = new MessageParser<Screens>(() => new Screens());

	private UnknownFieldSet _unknownFields;

	public const int ShowScreensLaunchFieldNumber = 1;

	private bool showScreensLaunch_;

	public const int ShowPerformanceOnScreenFieldNumber = 2;

	private bool showPerformanceOnScreen_;

	public const int IgnoreBackgroundColorsFieldNumber = 3;

	private bool ignoreBackgroundColors_;

	public const int ShowKeynotePptScreensFieldNumber = 4;

	private bool showKeynotePptScreens_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<Screens> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AnalyticsStartupReflection.Descriptor.MessageTypes[8];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool ShowScreensLaunch
	{
		get
		{
			return showScreensLaunch_;
		}
		set
		{
			showScreensLaunch_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool ShowPerformanceOnScreen
	{
		get
		{
			return showPerformanceOnScreen_;
		}
		set
		{
			showPerformanceOnScreen_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool IgnoreBackgroundColors
	{
		get
		{
			return ignoreBackgroundColors_;
		}
		set
		{
			ignoreBackgroundColors_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool ShowKeynotePptScreens
	{
		get
		{
			return showKeynotePptScreens_;
		}
		set
		{
			showKeynotePptScreens_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Screens()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Screens(Screens other)
		: this()
	{
		showScreensLaunch_ = other.showScreensLaunch_;
		showPerformanceOnScreen_ = other.showPerformanceOnScreen_;
		ignoreBackgroundColors_ = other.ignoreBackgroundColors_;
		showKeynotePptScreens_ = other.showKeynotePptScreens_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Screens Clone()
	{
		return new Screens(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as Screens);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(Screens other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (ShowScreensLaunch != other.ShowScreensLaunch)
		{
			return false;
		}
		if (ShowPerformanceOnScreen != other.ShowPerformanceOnScreen)
		{
			return false;
		}
		if (IgnoreBackgroundColors != other.IgnoreBackgroundColors)
		{
			return false;
		}
		if (ShowKeynotePptScreens != other.ShowKeynotePptScreens)
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
		if (ShowScreensLaunch)
		{
			num ^= ShowScreensLaunch.GetHashCode();
		}
		if (ShowPerformanceOnScreen)
		{
			num ^= ShowPerformanceOnScreen.GetHashCode();
		}
		if (IgnoreBackgroundColors)
		{
			num ^= IgnoreBackgroundColors.GetHashCode();
		}
		if (ShowKeynotePptScreens)
		{
			num ^= ShowKeynotePptScreens.GetHashCode();
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
		if (ShowScreensLaunch)
		{
			output.WriteRawTag(8);
			output.WriteBool(ShowScreensLaunch);
		}
		if (ShowPerformanceOnScreen)
		{
			output.WriteRawTag(16);
			output.WriteBool(ShowPerformanceOnScreen);
		}
		if (IgnoreBackgroundColors)
		{
			output.WriteRawTag(24);
			output.WriteBool(IgnoreBackgroundColors);
		}
		if (ShowKeynotePptScreens)
		{
			output.WriteRawTag(32);
			output.WriteBool(ShowKeynotePptScreens);
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
		if (ShowScreensLaunch)
		{
			num += 2;
		}
		if (ShowPerformanceOnScreen)
		{
			num += 2;
		}
		if (IgnoreBackgroundColors)
		{
			num += 2;
		}
		if (ShowKeynotePptScreens)
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
	public void MergeFrom(Screens other)
	{
		if (other != null)
		{
			if (other.ShowScreensLaunch)
			{
				ShowScreensLaunch = other.ShowScreensLaunch;
			}
			if (other.ShowPerformanceOnScreen)
			{
				ShowPerformanceOnScreen = other.ShowPerformanceOnScreen;
			}
			if (other.IgnoreBackgroundColors)
			{
				IgnoreBackgroundColors = other.IgnoreBackgroundColors;
			}
			if (other.ShowKeynotePptScreens)
			{
				ShowKeynotePptScreens = other.ShowKeynotePptScreens;
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
				ShowScreensLaunch = input.ReadBool();
				break;
			case 16u:
				ShowPerformanceOnScreen = input.ReadBool();
				break;
			case 24u:
				IgnoreBackgroundColors = input.ReadBool();
				break;
			case 32u:
				ShowKeynotePptScreens = input.ReadBool();
				break;
			}
		}
	}
}
