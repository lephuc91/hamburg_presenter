using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.UI;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class BibleInstall : IMessage<BibleInstall>, IMessage, IEquatable<BibleInstall>, IDeepCloneable<BibleInstall>
{
	private static readonly MessageParser<BibleInstall> _parser = new MessageParser<BibleInstall>(() => new BibleInstall());

	private UnknownFieldSet _unknownFields;

	public const int FreeInstalledCountFieldNumber = 1;

	private int freeInstalledCount_;

	public const int PurchasedInstalledCountFieldNumber = 2;

	private int purchasedInstalledCount_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<BibleInstall> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AnalyticsUIReflection.Descriptor.MessageTypes[15];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int FreeInstalledCount
	{
		get
		{
			return freeInstalledCount_;
		}
		set
		{
			freeInstalledCount_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int PurchasedInstalledCount
	{
		get
		{
			return purchasedInstalledCount_;
		}
		set
		{
			purchasedInstalledCount_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public BibleInstall()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public BibleInstall(BibleInstall other)
		: this()
	{
		freeInstalledCount_ = other.freeInstalledCount_;
		purchasedInstalledCount_ = other.purchasedInstalledCount_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public BibleInstall Clone()
	{
		return new BibleInstall(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as BibleInstall);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(BibleInstall other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (FreeInstalledCount != other.FreeInstalledCount)
		{
			return false;
		}
		if (PurchasedInstalledCount != other.PurchasedInstalledCount)
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
		if (FreeInstalledCount != 0)
		{
			num ^= FreeInstalledCount.GetHashCode();
		}
		if (PurchasedInstalledCount != 0)
		{
			num ^= PurchasedInstalledCount.GetHashCode();
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
		if (FreeInstalledCount != 0)
		{
			output.WriteRawTag(8);
			output.WriteInt32(FreeInstalledCount);
		}
		if (PurchasedInstalledCount != 0)
		{
			output.WriteRawTag(16);
			output.WriteInt32(PurchasedInstalledCount);
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
		if (FreeInstalledCount != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(FreeInstalledCount);
		}
		if (PurchasedInstalledCount != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(PurchasedInstalledCount);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(BibleInstall other)
	{
		if (other != null)
		{
			if (other.FreeInstalledCount != 0)
			{
				FreeInstalledCount = other.FreeInstalledCount;
			}
			if (other.PurchasedInstalledCount != 0)
			{
				PurchasedInstalledCount = other.PurchasedInstalledCount;
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
				FreeInstalledCount = input.ReadInt32();
				break;
			case 16u:
				PurchasedInstalledCount = input.ReadInt32();
				break;
			}
		}
	}
}
