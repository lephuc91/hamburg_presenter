using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class OnboardingFlowOutcome : IMessage<OnboardingFlowOutcome>, IMessage, IEquatable<OnboardingFlowOutcome>, IDeepCloneable<OnboardingFlowOutcome>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		public enum OnboardingType
		{
			[OriginalName("NEW_TO_CLOUD")]
			NewToCloud,
			[OriginalName("NEW_USER")]
			NewUser
		}

		public enum Result
		{
			[OriginalName("SKIP_FOR_NOW")]
			SkipForNow,
			[OriginalName("CONTINUE_WITH_LOCAL")]
			ContinueWithLocal,
			[OriginalName("CREATE_CLOUD")]
			CreateCloud,
			[OriginalName("JOIN_CLOUD")]
			JoinCloud
		}
	}

	private static readonly MessageParser<OnboardingFlowOutcome> _parser = new MessageParser<OnboardingFlowOutcome>(() => new OnboardingFlowOutcome());

	private UnknownFieldSet _unknownFields;

	public const int OnboardingTypeFieldNumber = 1;

	private Types.OnboardingType onboardingType_;

	public const int ResultFieldNumber = 2;

	private Types.Result result_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<OnboardingFlowOutcome> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AnalyticsTrackedEventsReflection.Descriptor.MessageTypes[38];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.OnboardingType OnboardingType
	{
		get
		{
			return onboardingType_;
		}
		set
		{
			onboardingType_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Result Result
	{
		get
		{
			return result_;
		}
		set
		{
			result_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public OnboardingFlowOutcome()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public OnboardingFlowOutcome(OnboardingFlowOutcome other)
		: this()
	{
		onboardingType_ = other.onboardingType_;
		result_ = other.result_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public OnboardingFlowOutcome Clone()
	{
		return new OnboardingFlowOutcome(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as OnboardingFlowOutcome);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(OnboardingFlowOutcome other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (OnboardingType != other.OnboardingType)
		{
			return false;
		}
		if (Result != other.Result)
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
		if (OnboardingType != 0)
		{
			num ^= OnboardingType.GetHashCode();
		}
		if (Result != 0)
		{
			num ^= Result.GetHashCode();
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
		if (OnboardingType != 0)
		{
			output.WriteRawTag(8);
			output.WriteEnum((int)OnboardingType);
		}
		if (Result != 0)
		{
			output.WriteRawTag(16);
			output.WriteEnum((int)Result);
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
		if (OnboardingType != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)OnboardingType);
		}
		if (Result != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)Result);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(OnboardingFlowOutcome other)
	{
		if (other != null)
		{
			if (other.OnboardingType != 0)
			{
				OnboardingType = other.OnboardingType;
			}
			if (other.Result != 0)
			{
				Result = other.Result;
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
				OnboardingType = (Types.OnboardingType)input.ReadEnum();
				break;
			case 16u:
				Result = (Types.Result)input.ReadEnum();
				break;
			}
		}
	}
}
