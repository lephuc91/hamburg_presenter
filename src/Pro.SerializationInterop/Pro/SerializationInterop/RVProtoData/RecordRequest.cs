using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class RecordRequest : IMessage<RecordRequest>, IMessage, IEquatable<RecordRequest>, IDeepCloneable<RecordRequest>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Resi : IMessage<Resi>, IMessage, IEquatable<Resi>, IDeepCloneable<Resi>
		{
			private static readonly MessageParser<Resi> _parser = new MessageParser<Resi>(() => new Resi());

			private UnknownFieldSet _unknownFields;

			public const int GopFieldNumber = 1;

			private uint gop_;

			public const int SegmentSizeFieldNumber = 2;

			private double segmentSize_;

			public const int DestinationGroupIdFieldNumber = 3;

			private string destinationGroupId_ = "";

			public const int BufSizeFieldNumber = 4;

			private uint bufSize_;

			public const int MinRateFieldNumber = 5;

			private uint minRate_;

			public const int MaxRateFieldNumber = 6;

			private uint maxRate_;

			public const int EventNameFieldNumber = 7;

			private string eventName_ = "";

			public const int SocialDescriptionFieldNumber = 8;

			private string socialDescription_ = "";

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Resi> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => RecordRequest.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public uint Gop
			{
				get
				{
					return gop_;
				}
				set
				{
					gop_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public double SegmentSize
			{
				get
				{
					return segmentSize_;
				}
				set
				{
					segmentSize_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string DestinationGroupId
			{
				get
				{
					return destinationGroupId_;
				}
				set
				{
					destinationGroupId_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public uint BufSize
			{
				get
				{
					return bufSize_;
				}
				set
				{
					bufSize_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public uint MinRate
			{
				get
				{
					return minRate_;
				}
				set
				{
					minRate_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public uint MaxRate
			{
				get
				{
					return maxRate_;
				}
				set
				{
					maxRate_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string EventName
			{
				get
				{
					return eventName_;
				}
				set
				{
					eventName_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string SocialDescription
			{
				get
				{
					return socialDescription_;
				}
				set
				{
					socialDescription_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Resi()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Resi(Resi other)
				: this()
			{
				gop_ = other.gop_;
				segmentSize_ = other.segmentSize_;
				destinationGroupId_ = other.destinationGroupId_;
				bufSize_ = other.bufSize_;
				minRate_ = other.minRate_;
				maxRate_ = other.maxRate_;
				eventName_ = other.eventName_;
				socialDescription_ = other.socialDescription_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Resi Clone()
			{
				return new Resi(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Resi);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Resi other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (Gop != other.Gop)
				{
					return false;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(SegmentSize, other.SegmentSize))
				{
					return false;
				}
				if (DestinationGroupId != other.DestinationGroupId)
				{
					return false;
				}
				if (BufSize != other.BufSize)
				{
					return false;
				}
				if (MinRate != other.MinRate)
				{
					return false;
				}
				if (MaxRate != other.MaxRate)
				{
					return false;
				}
				if (EventName != other.EventName)
				{
					return false;
				}
				if (SocialDescription != other.SocialDescription)
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
				if (Gop != 0)
				{
					num ^= Gop.GetHashCode();
				}
				if (SegmentSize != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(SegmentSize);
				}
				if (DestinationGroupId.Length != 0)
				{
					num ^= DestinationGroupId.GetHashCode();
				}
				if (BufSize != 0)
				{
					num ^= BufSize.GetHashCode();
				}
				if (MinRate != 0)
				{
					num ^= MinRate.GetHashCode();
				}
				if (MaxRate != 0)
				{
					num ^= MaxRate.GetHashCode();
				}
				if (EventName.Length != 0)
				{
					num ^= EventName.GetHashCode();
				}
				if (SocialDescription.Length != 0)
				{
					num ^= SocialDescription.GetHashCode();
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
				if (Gop != 0)
				{
					output.WriteRawTag(8);
					output.WriteUInt32(Gop);
				}
				if (SegmentSize != 0.0)
				{
					output.WriteRawTag(17);
					output.WriteDouble(SegmentSize);
				}
				if (DestinationGroupId.Length != 0)
				{
					output.WriteRawTag(26);
					output.WriteString(DestinationGroupId);
				}
				if (BufSize != 0)
				{
					output.WriteRawTag(32);
					output.WriteUInt32(BufSize);
				}
				if (MinRate != 0)
				{
					output.WriteRawTag(40);
					output.WriteUInt32(MinRate);
				}
				if (MaxRate != 0)
				{
					output.WriteRawTag(48);
					output.WriteUInt32(MaxRate);
				}
				if (EventName.Length != 0)
				{
					output.WriteRawTag(58);
					output.WriteString(EventName);
				}
				if (SocialDescription.Length != 0)
				{
					output.WriteRawTag(66);
					output.WriteString(SocialDescription);
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
				if (Gop != 0)
				{
					num += 1 + CodedOutputStream.ComputeUInt32Size(Gop);
				}
				if (SegmentSize != 0.0)
				{
					num += 9;
				}
				if (DestinationGroupId.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(DestinationGroupId);
				}
				if (BufSize != 0)
				{
					num += 1 + CodedOutputStream.ComputeUInt32Size(BufSize);
				}
				if (MinRate != 0)
				{
					num += 1 + CodedOutputStream.ComputeUInt32Size(MinRate);
				}
				if (MaxRate != 0)
				{
					num += 1 + CodedOutputStream.ComputeUInt32Size(MaxRate);
				}
				if (EventName.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(EventName);
				}
				if (SocialDescription.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(SocialDescription);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(Resi other)
			{
				if (other != null)
				{
					if (other.Gop != 0)
					{
						Gop = other.Gop;
					}
					if (other.SegmentSize != 0.0)
					{
						SegmentSize = other.SegmentSize;
					}
					if (other.DestinationGroupId.Length != 0)
					{
						DestinationGroupId = other.DestinationGroupId;
					}
					if (other.BufSize != 0)
					{
						BufSize = other.BufSize;
					}
					if (other.MinRate != 0)
					{
						MinRate = other.MinRate;
					}
					if (other.MaxRate != 0)
					{
						MaxRate = other.MaxRate;
					}
					if (other.EventName.Length != 0)
					{
						EventName = other.EventName;
					}
					if (other.SocialDescription.Length != 0)
					{
						SocialDescription = other.SocialDescription;
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
						Gop = input.ReadUInt32();
						break;
					case 17u:
						SegmentSize = input.ReadDouble();
						break;
					case 26u:
						DestinationGroupId = input.ReadString();
						break;
					case 32u:
						BufSize = input.ReadUInt32();
						break;
					case 40u:
						MinRate = input.ReadUInt32();
						break;
					case 48u:
						MaxRate = input.ReadUInt32();
						break;
					case 58u:
						EventName = input.ReadString();
						break;
					case 66u:
						SocialDescription = input.ReadString();
						break;
					}
				}
			}
		}
	}

	private static readonly MessageParser<RecordRequest> _parser = new MessageParser<RecordRequest>(() => new RecordRequest());

	private UnknownFieldSet _unknownFields;

	public const int StreamFieldNumber = 1;

	private Recording.Types.Stream stream_;

	public const int WorkingDirectoryFieldNumber = 2;

	private URL workingDirectory_;

	public const int ResiFieldNumber = 3;

	private Types.Resi resi_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<RecordRequest> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProCoreReflection.Descriptor.MessageTypes[5];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Recording.Types.Stream Stream
	{
		get
		{
			return stream_;
		}
		set
		{
			stream_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public URL WorkingDirectory
	{
		get
		{
			return workingDirectory_;
		}
		set
		{
			workingDirectory_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Resi Resi
	{
		get
		{
			return resi_;
		}
		set
		{
			resi_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RecordRequest()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RecordRequest(RecordRequest other)
		: this()
	{
		stream_ = ((other.stream_ != null) ? other.stream_.Clone() : null);
		workingDirectory_ = ((other.workingDirectory_ != null) ? other.workingDirectory_.Clone() : null);
		resi_ = ((other.resi_ != null) ? other.resi_.Clone() : null);
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RecordRequest Clone()
	{
		return new RecordRequest(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as RecordRequest);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(RecordRequest other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(Stream, other.Stream))
		{
			return false;
		}
		if (!object.Equals(WorkingDirectory, other.WorkingDirectory))
		{
			return false;
		}
		if (!object.Equals(Resi, other.Resi))
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
		if (stream_ != null)
		{
			num ^= Stream.GetHashCode();
		}
		if (workingDirectory_ != null)
		{
			num ^= WorkingDirectory.GetHashCode();
		}
		if (resi_ != null)
		{
			num ^= Resi.GetHashCode();
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
		if (stream_ != null)
		{
			output.WriteRawTag(10);
			output.WriteMessage(Stream);
		}
		if (workingDirectory_ != null)
		{
			output.WriteRawTag(18);
			output.WriteMessage(WorkingDirectory);
		}
		if (resi_ != null)
		{
			output.WriteRawTag(26);
			output.WriteMessage(Resi);
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
		if (stream_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Stream);
		}
		if (workingDirectory_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(WorkingDirectory);
		}
		if (resi_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Resi);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(RecordRequest other)
	{
		if (other == null)
		{
			return;
		}
		if (other.stream_ != null)
		{
			if (stream_ == null)
			{
				Stream = new Recording.Types.Stream();
			}
			Stream.MergeFrom(other.Stream);
		}
		if (other.workingDirectory_ != null)
		{
			if (workingDirectory_ == null)
			{
				WorkingDirectory = new URL();
			}
			WorkingDirectory.MergeFrom(other.WorkingDirectory);
		}
		if (other.resi_ != null)
		{
			if (resi_ == null)
			{
				Resi = new Types.Resi();
			}
			Resi.MergeFrom(other.Resi);
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
				if (stream_ == null)
				{
					Stream = new Recording.Types.Stream();
				}
				input.ReadMessage(Stream);
				break;
			case 18u:
				if (workingDirectory_ == null)
				{
					WorkingDirectory = new URL();
				}
				input.ReadMessage(WorkingDirectory);
				break;
			case 26u:
				if (resi_ == null)
				{
					Resi = new Types.Resi();
				}
				input.ReadMessage(Resi);
				break;
			}
		}
	}
}
