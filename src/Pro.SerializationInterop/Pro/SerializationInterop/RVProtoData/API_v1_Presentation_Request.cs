using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class API_v1_Presentation_Request : IMessage<API_v1_Presentation_Request>, IMessage, IEquatable<API_v1_Presentation_Request>, IDeepCloneable<API_v1_Presentation_Request>
{
	public enum RequestOneofCase
	{
		None,
		Active,
		Focused,
		SlideIndex,
		ChordChart,
		ChordChartUpdates,
		Presentation,
		DeletePresentation,
		TimelineOperation,
		ActivePresentationTimelineOperation,
		FocusedPresentationTimelineOperation,
		ActivePresentationTimelineStatus,
		FocusedPresentationTimelineStatus,
		Thumbnail,
		Focus,
		Trigger
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Active : IMessage<Active>, IMessage, IEquatable<Active>, IDeepCloneable<Active>
		{
			private static readonly MessageParser<Active> _parser = new MessageParser<Active>(() => new Active());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Active> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Presentation_Request.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Active()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Active(Active other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Active Clone()
			{
				return new Active(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Active);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Active other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				return object.Equals(_unknownFields, other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override int GetHashCode()
			{
				int num = 1;
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
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(Active other)
			{
				if (other != null)
				{
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
					_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class SlideIndex : IMessage<SlideIndex>, IMessage, IEquatable<SlideIndex>, IDeepCloneable<SlideIndex>
		{
			private static readonly MessageParser<SlideIndex> _parser = new MessageParser<SlideIndex>(() => new SlideIndex());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<SlideIndex> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Presentation_Request.Descriptor.NestedTypes[1];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public SlideIndex()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public SlideIndex(SlideIndex other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public SlideIndex Clone()
			{
				return new SlideIndex(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as SlideIndex);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(SlideIndex other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				return object.Equals(_unknownFields, other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override int GetHashCode()
			{
				int num = 1;
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
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(SlideIndex other)
			{
				if (other != null)
				{
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
					_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class ChordChart : IMessage<ChordChart>, IMessage, IEquatable<ChordChart>, IDeepCloneable<ChordChart>
		{
			private static readonly MessageParser<ChordChart> _parser = new MessageParser<ChordChart>(() => new ChordChart());

			private UnknownFieldSet _unknownFields;

			public const int QualityFieldNumber = 1;

			private int quality_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<ChordChart> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Presentation_Request.Descriptor.NestedTypes[2];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public int Quality
			{
				get
				{
					return quality_;
				}
				set
				{
					quality_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ChordChart()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ChordChart(ChordChart other)
				: this()
			{
				quality_ = other.quality_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ChordChart Clone()
			{
				return new ChordChart(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as ChordChart);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(ChordChart other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (Quality != other.Quality)
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
				if (Quality != 0)
				{
					num ^= Quality.GetHashCode();
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
				if (Quality != 0)
				{
					output.WriteRawTag(8);
					output.WriteInt32(Quality);
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
				if (Quality != 0)
				{
					num += 1 + CodedOutputStream.ComputeInt32Size(Quality);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(ChordChart other)
			{
				if (other != null)
				{
					if (other.Quality != 0)
					{
						Quality = other.Quality;
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
					if (num != 8)
					{
						_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
					}
					else
					{
						Quality = input.ReadInt32();
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class ChordChartUpdates : IMessage<ChordChartUpdates>, IMessage, IEquatable<ChordChartUpdates>, IDeepCloneable<ChordChartUpdates>
		{
			private static readonly MessageParser<ChordChartUpdates> _parser = new MessageParser<ChordChartUpdates>(() => new ChordChartUpdates());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<ChordChartUpdates> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Presentation_Request.Descriptor.NestedTypes[3];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ChordChartUpdates()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ChordChartUpdates(ChordChartUpdates other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ChordChartUpdates Clone()
			{
				return new ChordChartUpdates(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as ChordChartUpdates);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(ChordChartUpdates other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				return object.Equals(_unknownFields, other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override int GetHashCode()
			{
				int num = 1;
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
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(ChordChartUpdates other)
			{
				if (other != null)
				{
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
					_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Presentation : IMessage<Presentation>, IMessage, IEquatable<Presentation>, IDeepCloneable<Presentation>
		{
			private static readonly MessageParser<Presentation> _parser = new MessageParser<Presentation>(() => new Presentation());

			private UnknownFieldSet _unknownFields;

			public const int UuidFieldNumber = 1;

			private UUID uuid_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Presentation> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Presentation_Request.Descriptor.NestedTypes[4];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

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
			public Presentation()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Presentation(Presentation other)
				: this()
			{
				uuid_ = ((other.uuid_ != null) ? other.uuid_.Clone() : null);
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Presentation Clone()
			{
				return new Presentation(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Presentation);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Presentation other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(Uuid, other.Uuid))
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
				if (uuid_ != null)
				{
					num ^= Uuid.GetHashCode();
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
				if (uuid_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Uuid);
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
				if (uuid_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Uuid);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(Presentation other)
			{
				if (other == null)
				{
					return;
				}
				if (other.uuid_ != null)
				{
					if (uuid_ == null)
					{
						Uuid = new UUID();
					}
					Uuid.MergeFrom(other.Uuid);
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
					if (num != 10)
					{
						_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
						continue;
					}
					if (uuid_ == null)
					{
						Uuid = new UUID();
					}
					input.ReadMessage(Uuid);
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class DeletePresentation : IMessage<DeletePresentation>, IMessage, IEquatable<DeletePresentation>, IDeepCloneable<DeletePresentation>
		{
			private static readonly MessageParser<DeletePresentation> _parser = new MessageParser<DeletePresentation>(() => new DeletePresentation());

			private UnknownFieldSet _unknownFields;

			public const int UuidFieldNumber = 1;

			private UUID uuid_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<DeletePresentation> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Presentation_Request.Descriptor.NestedTypes[5];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

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
			public DeletePresentation()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public DeletePresentation(DeletePresentation other)
				: this()
			{
				uuid_ = ((other.uuid_ != null) ? other.uuid_.Clone() : null);
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public DeletePresentation Clone()
			{
				return new DeletePresentation(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as DeletePresentation);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(DeletePresentation other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(Uuid, other.Uuid))
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
				if (uuid_ != null)
				{
					num ^= Uuid.GetHashCode();
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
				if (uuid_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Uuid);
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
				if (uuid_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Uuid);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(DeletePresentation other)
			{
				if (other == null)
				{
					return;
				}
				if (other.uuid_ != null)
				{
					if (uuid_ == null)
					{
						Uuid = new UUID();
					}
					Uuid.MergeFrom(other.Uuid);
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
					if (num != 10)
					{
						_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
						continue;
					}
					if (uuid_ == null)
					{
						Uuid = new UUID();
					}
					input.ReadMessage(Uuid);
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class TimelineOperation : IMessage<TimelineOperation>, IMessage, IEquatable<TimelineOperation>, IDeepCloneable<TimelineOperation>
		{
			private static readonly MessageParser<TimelineOperation> _parser = new MessageParser<TimelineOperation>(() => new TimelineOperation());

			private UnknownFieldSet _unknownFields;

			public const int UuidFieldNumber = 1;

			private UUID uuid_;

			public const int OperationFieldNumber = 2;

			private API_v1_TimelineOperation operation_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<TimelineOperation> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Presentation_Request.Descriptor.NestedTypes[6];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

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
			public API_v1_TimelineOperation Operation
			{
				get
				{
					return operation_;
				}
				set
				{
					operation_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TimelineOperation()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TimelineOperation(TimelineOperation other)
				: this()
			{
				uuid_ = ((other.uuid_ != null) ? other.uuid_.Clone() : null);
				operation_ = other.operation_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TimelineOperation Clone()
			{
				return new TimelineOperation(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as TimelineOperation);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(TimelineOperation other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(Uuid, other.Uuid))
				{
					return false;
				}
				if (Operation != other.Operation)
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
				if (uuid_ != null)
				{
					num ^= Uuid.GetHashCode();
				}
				if (Operation != 0)
				{
					num ^= Operation.GetHashCode();
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
				if (uuid_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Uuid);
				}
				if (Operation != 0)
				{
					output.WriteRawTag(16);
					output.WriteEnum((int)Operation);
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
				if (uuid_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Uuid);
				}
				if (Operation != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)Operation);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(TimelineOperation other)
			{
				if (other == null)
				{
					return;
				}
				if (other.uuid_ != null)
				{
					if (uuid_ == null)
					{
						Uuid = new UUID();
					}
					Uuid.MergeFrom(other.Uuid);
				}
				if (other.Operation != 0)
				{
					Operation = other.Operation;
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
						if (uuid_ == null)
						{
							Uuid = new UUID();
						}
						input.ReadMessage(Uuid);
						break;
					case 16u:
						Operation = (API_v1_TimelineOperation)input.ReadEnum();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class ActivePresentationTimelineOperation : IMessage<ActivePresentationTimelineOperation>, IMessage, IEquatable<ActivePresentationTimelineOperation>, IDeepCloneable<ActivePresentationTimelineOperation>
		{
			private static readonly MessageParser<ActivePresentationTimelineOperation> _parser = new MessageParser<ActivePresentationTimelineOperation>(() => new ActivePresentationTimelineOperation());

			private UnknownFieldSet _unknownFields;

			public const int OperationFieldNumber = 1;

			private API_v1_TimelineOperation operation_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<ActivePresentationTimelineOperation> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Presentation_Request.Descriptor.NestedTypes[7];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_TimelineOperation Operation
			{
				get
				{
					return operation_;
				}
				set
				{
					operation_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ActivePresentationTimelineOperation()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ActivePresentationTimelineOperation(ActivePresentationTimelineOperation other)
				: this()
			{
				operation_ = other.operation_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ActivePresentationTimelineOperation Clone()
			{
				return new ActivePresentationTimelineOperation(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as ActivePresentationTimelineOperation);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(ActivePresentationTimelineOperation other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (Operation != other.Operation)
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
				if (Operation != 0)
				{
					num ^= Operation.GetHashCode();
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
				if (Operation != 0)
				{
					output.WriteRawTag(8);
					output.WriteEnum((int)Operation);
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
				if (Operation != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)Operation);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(ActivePresentationTimelineOperation other)
			{
				if (other != null)
				{
					if (other.Operation != 0)
					{
						Operation = other.Operation;
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
					if (num != 8)
					{
						_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
					}
					else
					{
						Operation = (API_v1_TimelineOperation)input.ReadEnum();
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class FocusedPresentationTimelineOperation : IMessage<FocusedPresentationTimelineOperation>, IMessage, IEquatable<FocusedPresentationTimelineOperation>, IDeepCloneable<FocusedPresentationTimelineOperation>
		{
			private static readonly MessageParser<FocusedPresentationTimelineOperation> _parser = new MessageParser<FocusedPresentationTimelineOperation>(() => new FocusedPresentationTimelineOperation());

			private UnknownFieldSet _unknownFields;

			public const int OperationFieldNumber = 1;

			private API_v1_TimelineOperation operation_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<FocusedPresentationTimelineOperation> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Presentation_Request.Descriptor.NestedTypes[8];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_TimelineOperation Operation
			{
				get
				{
					return operation_;
				}
				set
				{
					operation_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public FocusedPresentationTimelineOperation()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public FocusedPresentationTimelineOperation(FocusedPresentationTimelineOperation other)
				: this()
			{
				operation_ = other.operation_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public FocusedPresentationTimelineOperation Clone()
			{
				return new FocusedPresentationTimelineOperation(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as FocusedPresentationTimelineOperation);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(FocusedPresentationTimelineOperation other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (Operation != other.Operation)
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
				if (Operation != 0)
				{
					num ^= Operation.GetHashCode();
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
				if (Operation != 0)
				{
					output.WriteRawTag(8);
					output.WriteEnum((int)Operation);
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
				if (Operation != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)Operation);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(FocusedPresentationTimelineOperation other)
			{
				if (other != null)
				{
					if (other.Operation != 0)
					{
						Operation = other.Operation;
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
					if (num != 8)
					{
						_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
					}
					else
					{
						Operation = (API_v1_TimelineOperation)input.ReadEnum();
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class ActivePresentationTimelineStatus : IMessage<ActivePresentationTimelineStatus>, IMessage, IEquatable<ActivePresentationTimelineStatus>, IDeepCloneable<ActivePresentationTimelineStatus>
		{
			private static readonly MessageParser<ActivePresentationTimelineStatus> _parser = new MessageParser<ActivePresentationTimelineStatus>(() => new ActivePresentationTimelineStatus());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<ActivePresentationTimelineStatus> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Presentation_Request.Descriptor.NestedTypes[9];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ActivePresentationTimelineStatus()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ActivePresentationTimelineStatus(ActivePresentationTimelineStatus other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ActivePresentationTimelineStatus Clone()
			{
				return new ActivePresentationTimelineStatus(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as ActivePresentationTimelineStatus);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(ActivePresentationTimelineStatus other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				return object.Equals(_unknownFields, other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override int GetHashCode()
			{
				int num = 1;
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
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(ActivePresentationTimelineStatus other)
			{
				if (other != null)
				{
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
					_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class FocusedPresentationTimelineStatus : IMessage<FocusedPresentationTimelineStatus>, IMessage, IEquatable<FocusedPresentationTimelineStatus>, IDeepCloneable<FocusedPresentationTimelineStatus>
		{
			private static readonly MessageParser<FocusedPresentationTimelineStatus> _parser = new MessageParser<FocusedPresentationTimelineStatus>(() => new FocusedPresentationTimelineStatus());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<FocusedPresentationTimelineStatus> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Presentation_Request.Descriptor.NestedTypes[10];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public FocusedPresentationTimelineStatus()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public FocusedPresentationTimelineStatus(FocusedPresentationTimelineStatus other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public FocusedPresentationTimelineStatus Clone()
			{
				return new FocusedPresentationTimelineStatus(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as FocusedPresentationTimelineStatus);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(FocusedPresentationTimelineStatus other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				return object.Equals(_unknownFields, other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override int GetHashCode()
			{
				int num = 1;
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
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(FocusedPresentationTimelineStatus other)
			{
				if (other != null)
				{
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
					_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Thumbnail : IMessage<Thumbnail>, IMessage, IEquatable<Thumbnail>, IDeepCloneable<Thumbnail>
		{
			private static readonly MessageParser<Thumbnail> _parser = new MessageParser<Thumbnail>(() => new Thumbnail());

			private UnknownFieldSet _unknownFields;

			public const int UuidFieldNumber = 1;

			private UUID uuid_;

			public const int CueIndexFieldNumber = 2;

			private uint cueIndex_;

			public const int QualityFieldNumber = 3;

			private int quality_;

			public const int ContentTypeFieldNumber = 4;

			private API_v1_ContentType contentType_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Thumbnail> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Presentation_Request.Descriptor.NestedTypes[11];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

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
			public uint CueIndex
			{
				get
				{
					return cueIndex_;
				}
				set
				{
					cueIndex_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public int Quality
			{
				get
				{
					return quality_;
				}
				set
				{
					quality_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_ContentType ContentType
			{
				get
				{
					return contentType_;
				}
				set
				{
					contentType_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Thumbnail()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Thumbnail(Thumbnail other)
				: this()
			{
				uuid_ = ((other.uuid_ != null) ? other.uuid_.Clone() : null);
				cueIndex_ = other.cueIndex_;
				quality_ = other.quality_;
				contentType_ = other.contentType_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Thumbnail Clone()
			{
				return new Thumbnail(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Thumbnail);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Thumbnail other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(Uuid, other.Uuid))
				{
					return false;
				}
				if (CueIndex != other.CueIndex)
				{
					return false;
				}
				if (Quality != other.Quality)
				{
					return false;
				}
				if (ContentType != other.ContentType)
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
				if (uuid_ != null)
				{
					num ^= Uuid.GetHashCode();
				}
				if (CueIndex != 0)
				{
					num ^= CueIndex.GetHashCode();
				}
				if (Quality != 0)
				{
					num ^= Quality.GetHashCode();
				}
				if (ContentType != 0)
				{
					num ^= ContentType.GetHashCode();
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
				if (uuid_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Uuid);
				}
				if (CueIndex != 0)
				{
					output.WriteRawTag(16);
					output.WriteUInt32(CueIndex);
				}
				if (Quality != 0)
				{
					output.WriteRawTag(24);
					output.WriteInt32(Quality);
				}
				if (ContentType != 0)
				{
					output.WriteRawTag(32);
					output.WriteEnum((int)ContentType);
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
				if (uuid_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Uuid);
				}
				if (CueIndex != 0)
				{
					num += 1 + CodedOutputStream.ComputeUInt32Size(CueIndex);
				}
				if (Quality != 0)
				{
					num += 1 + CodedOutputStream.ComputeInt32Size(Quality);
				}
				if (ContentType != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)ContentType);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(Thumbnail other)
			{
				if (other == null)
				{
					return;
				}
				if (other.uuid_ != null)
				{
					if (uuid_ == null)
					{
						Uuid = new UUID();
					}
					Uuid.MergeFrom(other.Uuid);
				}
				if (other.CueIndex != 0)
				{
					CueIndex = other.CueIndex;
				}
				if (other.Quality != 0)
				{
					Quality = other.Quality;
				}
				if (other.ContentType != 0)
				{
					ContentType = other.ContentType;
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
						if (uuid_ == null)
						{
							Uuid = new UUID();
						}
						input.ReadMessage(Uuid);
						break;
					case 16u:
						CueIndex = input.ReadUInt32();
						break;
					case 24u:
						Quality = input.ReadInt32();
						break;
					case 32u:
						ContentType = (API_v1_ContentType)input.ReadEnum();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class EmptyMessage : IMessage<EmptyMessage>, IMessage, IEquatable<EmptyMessage>, IDeepCloneable<EmptyMessage>
		{
			private static readonly MessageParser<EmptyMessage> _parser = new MessageParser<EmptyMessage>(() => new EmptyMessage());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<EmptyMessage> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Presentation_Request.Descriptor.NestedTypes[12];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public EmptyMessage()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public EmptyMessage(EmptyMessage other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public EmptyMessage Clone()
			{
				return new EmptyMessage(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as EmptyMessage);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(EmptyMessage other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				return object.Equals(_unknownFields, other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override int GetHashCode()
			{
				int num = 1;
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
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(EmptyMessage other)
			{
				if (other != null)
				{
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
					_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class FocusMessage : IMessage<FocusMessage>, IMessage, IEquatable<FocusMessage>, IDeepCloneable<FocusMessage>
		{
			public enum PresentationOneofCase
			{
				None,
				Next,
				Previous,
				Active,
				Uuid
			}

			private static readonly MessageParser<FocusMessage> _parser = new MessageParser<FocusMessage>(() => new FocusMessage());

			private UnknownFieldSet _unknownFields;

			public const int NextFieldNumber = 1;

			public const int PreviousFieldNumber = 2;

			public const int ActiveFieldNumber = 3;

			public const int UuidFieldNumber = 4;

			private object presentation_;

			private PresentationOneofCase presentationCase_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<FocusMessage> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Presentation_Request.Descriptor.NestedTypes[13];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public EmptyMessage Next
			{
				get
				{
					if (presentationCase_ != PresentationOneofCase.Next)
					{
						return null;
					}
					return (EmptyMessage)presentation_;
				}
				set
				{
					presentation_ = value;
					presentationCase_ = ((value != null) ? PresentationOneofCase.Next : PresentationOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public EmptyMessage Previous
			{
				get
				{
					if (presentationCase_ != PresentationOneofCase.Previous)
					{
						return null;
					}
					return (EmptyMessage)presentation_;
				}
				set
				{
					presentation_ = value;
					presentationCase_ = ((value != null) ? PresentationOneofCase.Previous : PresentationOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public EmptyMessage Active
			{
				get
				{
					if (presentationCase_ != PresentationOneofCase.Active)
					{
						return null;
					}
					return (EmptyMessage)presentation_;
				}
				set
				{
					presentation_ = value;
					presentationCase_ = ((value != null) ? PresentationOneofCase.Active : PresentationOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string Uuid
			{
				get
				{
					if (!HasUuid)
					{
						return "";
					}
					return (string)presentation_;
				}
				set
				{
					presentation_ = ProtoPreconditions.CheckNotNull(value, "value");
					presentationCase_ = PresentationOneofCase.Uuid;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool HasUuid => presentationCase_ == PresentationOneofCase.Uuid;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PresentationOneofCase PresentationCase => presentationCase_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public FocusMessage()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public FocusMessage(FocusMessage other)
				: this()
			{
				switch (other.PresentationCase)
				{
				case PresentationOneofCase.Next:
					Next = other.Next.Clone();
					break;
				case PresentationOneofCase.Previous:
					Previous = other.Previous.Clone();
					break;
				case PresentationOneofCase.Active:
					Active = other.Active.Clone();
					break;
				case PresentationOneofCase.Uuid:
					Uuid = other.Uuid;
					break;
				}
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public FocusMessage Clone()
			{
				return new FocusMessage(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void ClearUuid()
			{
				if (HasUuid)
				{
					ClearPresentation();
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void ClearPresentation()
			{
				presentationCase_ = PresentationOneofCase.None;
				presentation_ = null;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as FocusMessage);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(FocusMessage other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(Next, other.Next))
				{
					return false;
				}
				if (!object.Equals(Previous, other.Previous))
				{
					return false;
				}
				if (!object.Equals(Active, other.Active))
				{
					return false;
				}
				if (Uuid != other.Uuid)
				{
					return false;
				}
				if (PresentationCase != other.PresentationCase)
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
				if (presentationCase_ == PresentationOneofCase.Next)
				{
					num ^= Next.GetHashCode();
				}
				if (presentationCase_ == PresentationOneofCase.Previous)
				{
					num ^= Previous.GetHashCode();
				}
				if (presentationCase_ == PresentationOneofCase.Active)
				{
					num ^= Active.GetHashCode();
				}
				if (HasUuid)
				{
					num ^= Uuid.GetHashCode();
				}
				num ^= (int)presentationCase_;
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
				if (presentationCase_ == PresentationOneofCase.Next)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Next);
				}
				if (presentationCase_ == PresentationOneofCase.Previous)
				{
					output.WriteRawTag(18);
					output.WriteMessage(Previous);
				}
				if (presentationCase_ == PresentationOneofCase.Active)
				{
					output.WriteRawTag(26);
					output.WriteMessage(Active);
				}
				if (HasUuid)
				{
					output.WriteRawTag(34);
					output.WriteString(Uuid);
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
				if (presentationCase_ == PresentationOneofCase.Next)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Next);
				}
				if (presentationCase_ == PresentationOneofCase.Previous)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Previous);
				}
				if (presentationCase_ == PresentationOneofCase.Active)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Active);
				}
				if (HasUuid)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Uuid);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(FocusMessage other)
			{
				if (other == null)
				{
					return;
				}
				switch (other.PresentationCase)
				{
				case PresentationOneofCase.Next:
					if (Next == null)
					{
						Next = new EmptyMessage();
					}
					Next.MergeFrom(other.Next);
					break;
				case PresentationOneofCase.Previous:
					if (Previous == null)
					{
						Previous = new EmptyMessage();
					}
					Previous.MergeFrom(other.Previous);
					break;
				case PresentationOneofCase.Active:
					if (Active == null)
					{
						Active = new EmptyMessage();
					}
					Active.MergeFrom(other.Active);
					break;
				case PresentationOneofCase.Uuid:
					Uuid = other.Uuid;
					break;
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
					{
						EmptyMessage emptyMessage2 = new EmptyMessage();
						if (presentationCase_ == PresentationOneofCase.Next)
						{
							emptyMessage2.MergeFrom(Next);
						}
						input.ReadMessage(emptyMessage2);
						Next = emptyMessage2;
						break;
					}
					case 18u:
					{
						EmptyMessage emptyMessage3 = new EmptyMessage();
						if (presentationCase_ == PresentationOneofCase.Previous)
						{
							emptyMessage3.MergeFrom(Previous);
						}
						input.ReadMessage(emptyMessage3);
						Previous = emptyMessage3;
						break;
					}
					case 26u:
					{
						EmptyMessage emptyMessage = new EmptyMessage();
						if (presentationCase_ == PresentationOneofCase.Active)
						{
							emptyMessage.MergeFrom(Active);
						}
						input.ReadMessage(emptyMessage);
						Active = emptyMessage;
						break;
					}
					case 34u:
						Uuid = input.ReadString();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class TriggerMessage : IMessage<TriggerMessage>, IMessage, IEquatable<TriggerMessage>, IDeepCloneable<TriggerMessage>
		{
			public enum PresentationOneofCase
			{
				None,
				Focused,
				Active,
				Uuid
			}

			public enum CueOneofCase
			{
				None = 0,
				First = 4,
				Next = 5,
				Previous = 6,
				Index = 7,
				Group = 8
			}

			private static readonly MessageParser<TriggerMessage> _parser = new MessageParser<TriggerMessage>(() => new TriggerMessage());

			private UnknownFieldSet _unknownFields;

			public const int FocusedFieldNumber = 1;

			public const int ActiveFieldNumber = 2;

			public const int UuidFieldNumber = 3;

			private static readonly FieldCodec<string> _oneof_uuid_codec = FieldCodec.ForClassWrapper<string>(26u);

			public const int FirstFieldNumber = 4;

			public const int NextFieldNumber = 5;

			public const int PreviousFieldNumber = 6;

			public const int IndexFieldNumber = 7;

			private static readonly FieldCodec<uint?> _oneof_index_codec = FieldCodec.ForStructWrapper<uint>(58u);

			public const int GroupFieldNumber = 8;

			private static readonly FieldCodec<string> _oneof_group_codec = FieldCodec.ForClassWrapper<string>(66u);

			private object presentation_;

			private PresentationOneofCase presentationCase_;

			private object cue_;

			private CueOneofCase cueCase_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<TriggerMessage> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Presentation_Request.Descriptor.NestedTypes[14];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public EmptyMessage Focused
			{
				get
				{
					if (presentationCase_ != PresentationOneofCase.Focused)
					{
						return null;
					}
					return (EmptyMessage)presentation_;
				}
				set
				{
					presentation_ = value;
					presentationCase_ = ((value != null) ? PresentationOneofCase.Focused : PresentationOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public EmptyMessage Active
			{
				get
				{
					if (presentationCase_ != PresentationOneofCase.Active)
					{
						return null;
					}
					return (EmptyMessage)presentation_;
				}
				set
				{
					presentation_ = value;
					presentationCase_ = ((value != null) ? PresentationOneofCase.Active : PresentationOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string Uuid
			{
				get
				{
					if (presentationCase_ != PresentationOneofCase.Uuid)
					{
						return null;
					}
					return (string)presentation_;
				}
				set
				{
					presentation_ = value;
					presentationCase_ = ((value != null) ? PresentationOneofCase.Uuid : PresentationOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public EmptyMessage First
			{
				get
				{
					if (cueCase_ != CueOneofCase.First)
					{
						return null;
					}
					return (EmptyMessage)cue_;
				}
				set
				{
					cue_ = value;
					cueCase_ = ((value != null) ? CueOneofCase.First : CueOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public EmptyMessage Next
			{
				get
				{
					if (cueCase_ != CueOneofCase.Next)
					{
						return null;
					}
					return (EmptyMessage)cue_;
				}
				set
				{
					cue_ = value;
					cueCase_ = ((value != null) ? CueOneofCase.Next : CueOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public EmptyMessage Previous
			{
				get
				{
					if (cueCase_ != CueOneofCase.Previous)
					{
						return null;
					}
					return (EmptyMessage)cue_;
				}
				set
				{
					cue_ = value;
					cueCase_ = ((value != null) ? CueOneofCase.Previous : CueOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public uint? Index
			{
				get
				{
					if (cueCase_ != CueOneofCase.Index)
					{
						return null;
					}
					return (uint?)cue_;
				}
				set
				{
					cue_ = value;
					cueCase_ = (value.HasValue ? CueOneofCase.Index : CueOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string Group
			{
				get
				{
					if (cueCase_ != CueOneofCase.Group)
					{
						return null;
					}
					return (string)cue_;
				}
				set
				{
					cue_ = value;
					cueCase_ = ((value != null) ? CueOneofCase.Group : CueOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PresentationOneofCase PresentationCase => presentationCase_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public CueOneofCase CueCase => cueCase_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TriggerMessage()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TriggerMessage(TriggerMessage other)
				: this()
			{
				switch (other.PresentationCase)
				{
				case PresentationOneofCase.Focused:
					Focused = other.Focused.Clone();
					break;
				case PresentationOneofCase.Active:
					Active = other.Active.Clone();
					break;
				case PresentationOneofCase.Uuid:
					Uuid = other.Uuid;
					break;
				}
				switch (other.CueCase)
				{
				case CueOneofCase.First:
					First = other.First.Clone();
					break;
				case CueOneofCase.Next:
					Next = other.Next.Clone();
					break;
				case CueOneofCase.Previous:
					Previous = other.Previous.Clone();
					break;
				case CueOneofCase.Index:
					Index = other.Index;
					break;
				case CueOneofCase.Group:
					Group = other.Group;
					break;
				}
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TriggerMessage Clone()
			{
				return new TriggerMessage(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void ClearPresentation()
			{
				presentationCase_ = PresentationOneofCase.None;
				presentation_ = null;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void ClearCue()
			{
				cueCase_ = CueOneofCase.None;
				cue_ = null;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as TriggerMessage);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(TriggerMessage other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(Focused, other.Focused))
				{
					return false;
				}
				if (!object.Equals(Active, other.Active))
				{
					return false;
				}
				if (Uuid != other.Uuid)
				{
					return false;
				}
				if (!object.Equals(First, other.First))
				{
					return false;
				}
				if (!object.Equals(Next, other.Next))
				{
					return false;
				}
				if (!object.Equals(Previous, other.Previous))
				{
					return false;
				}
				if (Index != other.Index)
				{
					return false;
				}
				if (Group != other.Group)
				{
					return false;
				}
				if (PresentationCase != other.PresentationCase)
				{
					return false;
				}
				if (CueCase != other.CueCase)
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
				if (presentationCase_ == PresentationOneofCase.Focused)
				{
					num ^= Focused.GetHashCode();
				}
				if (presentationCase_ == PresentationOneofCase.Active)
				{
					num ^= Active.GetHashCode();
				}
				if (presentationCase_ == PresentationOneofCase.Uuid)
				{
					num ^= Uuid.GetHashCode();
				}
				if (cueCase_ == CueOneofCase.First)
				{
					num ^= First.GetHashCode();
				}
				if (cueCase_ == CueOneofCase.Next)
				{
					num ^= Next.GetHashCode();
				}
				if (cueCase_ == CueOneofCase.Previous)
				{
					num ^= Previous.GetHashCode();
				}
				if (cueCase_ == CueOneofCase.Index)
				{
					num ^= Index.GetHashCode();
				}
				if (cueCase_ == CueOneofCase.Group)
				{
					num ^= Group.GetHashCode();
				}
				num ^= (int)presentationCase_;
				num ^= (int)cueCase_;
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
				if (presentationCase_ == PresentationOneofCase.Focused)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Focused);
				}
				if (presentationCase_ == PresentationOneofCase.Active)
				{
					output.WriteRawTag(18);
					output.WriteMessage(Active);
				}
				if (presentationCase_ == PresentationOneofCase.Uuid)
				{
					_oneof_uuid_codec.WriteTagAndValue(output, (string)presentation_);
				}
				if (cueCase_ == CueOneofCase.First)
				{
					output.WriteRawTag(34);
					output.WriteMessage(First);
				}
				if (cueCase_ == CueOneofCase.Next)
				{
					output.WriteRawTag(42);
					output.WriteMessage(Next);
				}
				if (cueCase_ == CueOneofCase.Previous)
				{
					output.WriteRawTag(50);
					output.WriteMessage(Previous);
				}
				if (cueCase_ == CueOneofCase.Index)
				{
					_oneof_index_codec.WriteTagAndValue(output, (uint?)cue_);
				}
				if (cueCase_ == CueOneofCase.Group)
				{
					_oneof_group_codec.WriteTagAndValue(output, (string)cue_);
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
				if (presentationCase_ == PresentationOneofCase.Focused)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Focused);
				}
				if (presentationCase_ == PresentationOneofCase.Active)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Active);
				}
				if (presentationCase_ == PresentationOneofCase.Uuid)
				{
					num += _oneof_uuid_codec.CalculateSizeWithTag(Uuid);
				}
				if (cueCase_ == CueOneofCase.First)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(First);
				}
				if (cueCase_ == CueOneofCase.Next)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Next);
				}
				if (cueCase_ == CueOneofCase.Previous)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Previous);
				}
				if (cueCase_ == CueOneofCase.Index)
				{
					num += _oneof_index_codec.CalculateSizeWithTag(Index);
				}
				if (cueCase_ == CueOneofCase.Group)
				{
					num += _oneof_group_codec.CalculateSizeWithTag(Group);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(TriggerMessage other)
			{
				if (other == null)
				{
					return;
				}
				switch (other.PresentationCase)
				{
				case PresentationOneofCase.Focused:
					if (Focused == null)
					{
						Focused = new EmptyMessage();
					}
					Focused.MergeFrom(other.Focused);
					break;
				case PresentationOneofCase.Active:
					if (Active == null)
					{
						Active = new EmptyMessage();
					}
					Active.MergeFrom(other.Active);
					break;
				case PresentationOneofCase.Uuid:
					Uuid = other.Uuid;
					break;
				}
				switch (other.CueCase)
				{
				case CueOneofCase.First:
					if (First == null)
					{
						First = new EmptyMessage();
					}
					First.MergeFrom(other.First);
					break;
				case CueOneofCase.Next:
					if (Next == null)
					{
						Next = new EmptyMessage();
					}
					Next.MergeFrom(other.Next);
					break;
				case CueOneofCase.Previous:
					if (Previous == null)
					{
						Previous = new EmptyMessage();
					}
					Previous.MergeFrom(other.Previous);
					break;
				case CueOneofCase.Index:
					Index = other.Index;
					break;
				case CueOneofCase.Group:
					Group = other.Group;
					break;
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
					{
						EmptyMessage emptyMessage2 = new EmptyMessage();
						if (presentationCase_ == PresentationOneofCase.Focused)
						{
							emptyMessage2.MergeFrom(Focused);
						}
						input.ReadMessage(emptyMessage2);
						Focused = emptyMessage2;
						break;
					}
					case 18u:
					{
						EmptyMessage emptyMessage4 = new EmptyMessage();
						if (presentationCase_ == PresentationOneofCase.Active)
						{
							emptyMessage4.MergeFrom(Active);
						}
						input.ReadMessage(emptyMessage4);
						Active = emptyMessage4;
						break;
					}
					case 26u:
						Uuid = _oneof_uuid_codec.Read(input);
						break;
					case 34u:
					{
						EmptyMessage emptyMessage5 = new EmptyMessage();
						if (cueCase_ == CueOneofCase.First)
						{
							emptyMessage5.MergeFrom(First);
						}
						input.ReadMessage(emptyMessage5);
						First = emptyMessage5;
						break;
					}
					case 42u:
					{
						EmptyMessage emptyMessage3 = new EmptyMessage();
						if (cueCase_ == CueOneofCase.Next)
						{
							emptyMessage3.MergeFrom(Next);
						}
						input.ReadMessage(emptyMessage3);
						Next = emptyMessage3;
						break;
					}
					case 50u:
					{
						EmptyMessage emptyMessage = new EmptyMessage();
						if (cueCase_ == CueOneofCase.Previous)
						{
							emptyMessage.MergeFrom(Previous);
						}
						input.ReadMessage(emptyMessage);
						Previous = emptyMessage;
						break;
					}
					case 58u:
						Index = _oneof_index_codec.Read(input);
						break;
					case 66u:
						Group = _oneof_group_codec.Read(input);
						break;
					}
				}
			}
		}
	}

	private static readonly MessageParser<API_v1_Presentation_Request> _parser = new MessageParser<API_v1_Presentation_Request>(() => new API_v1_Presentation_Request());

	private UnknownFieldSet _unknownFields;

	public const int ActiveFieldNumber = 1;

	public const int FocusedFieldNumber = 2;

	public const int SlideIndexFieldNumber = 3;

	public const int ChordChartFieldNumber = 4;

	public const int ChordChartUpdatesFieldNumber = 5;

	public const int PresentationFieldNumber = 6;

	public const int DeletePresentationFieldNumber = 7;

	public const int TimelineOperationFieldNumber = 8;

	public const int ActivePresentationTimelineOperationFieldNumber = 9;

	public const int FocusedPresentationTimelineOperationFieldNumber = 10;

	public const int ActivePresentationTimelineStatusFieldNumber = 11;

	public const int FocusedPresentationTimelineStatusFieldNumber = 12;

	public const int ThumbnailFieldNumber = 13;

	public const int FocusFieldNumber = 14;

	public const int TriggerFieldNumber = 15;

	private object request_;

	private RequestOneofCase requestCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<API_v1_Presentation_Request> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProApiV1PresentationReflection.Descriptor.MessageTypes[2];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Active Active
	{
		get
		{
			if (requestCase_ != RequestOneofCase.Active)
			{
				return null;
			}
			return (Types.Active)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.Active : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.EmptyMessage Focused
	{
		get
		{
			if (requestCase_ != RequestOneofCase.Focused)
			{
				return null;
			}
			return (Types.EmptyMessage)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.Focused : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.SlideIndex SlideIndex
	{
		get
		{
			if (requestCase_ != RequestOneofCase.SlideIndex)
			{
				return null;
			}
			return (Types.SlideIndex)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.SlideIndex : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.ChordChart ChordChart
	{
		get
		{
			if (requestCase_ != RequestOneofCase.ChordChart)
			{
				return null;
			}
			return (Types.ChordChart)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.ChordChart : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.ChordChartUpdates ChordChartUpdates
	{
		get
		{
			if (requestCase_ != RequestOneofCase.ChordChartUpdates)
			{
				return null;
			}
			return (Types.ChordChartUpdates)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.ChordChartUpdates : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Presentation Presentation
	{
		get
		{
			if (requestCase_ != RequestOneofCase.Presentation)
			{
				return null;
			}
			return (Types.Presentation)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.Presentation : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.DeletePresentation DeletePresentation
	{
		get
		{
			if (requestCase_ != RequestOneofCase.DeletePresentation)
			{
				return null;
			}
			return (Types.DeletePresentation)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.DeletePresentation : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.TimelineOperation TimelineOperation
	{
		get
		{
			if (requestCase_ != RequestOneofCase.TimelineOperation)
			{
				return null;
			}
			return (Types.TimelineOperation)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.TimelineOperation : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.ActivePresentationTimelineOperation ActivePresentationTimelineOperation
	{
		get
		{
			if (requestCase_ != RequestOneofCase.ActivePresentationTimelineOperation)
			{
				return null;
			}
			return (Types.ActivePresentationTimelineOperation)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.ActivePresentationTimelineOperation : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.FocusedPresentationTimelineOperation FocusedPresentationTimelineOperation
	{
		get
		{
			if (requestCase_ != RequestOneofCase.FocusedPresentationTimelineOperation)
			{
				return null;
			}
			return (Types.FocusedPresentationTimelineOperation)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.FocusedPresentationTimelineOperation : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.ActivePresentationTimelineStatus ActivePresentationTimelineStatus
	{
		get
		{
			if (requestCase_ != RequestOneofCase.ActivePresentationTimelineStatus)
			{
				return null;
			}
			return (Types.ActivePresentationTimelineStatus)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.ActivePresentationTimelineStatus : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.FocusedPresentationTimelineStatus FocusedPresentationTimelineStatus
	{
		get
		{
			if (requestCase_ != RequestOneofCase.FocusedPresentationTimelineStatus)
			{
				return null;
			}
			return (Types.FocusedPresentationTimelineStatus)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.FocusedPresentationTimelineStatus : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Thumbnail Thumbnail
	{
		get
		{
			if (requestCase_ != RequestOneofCase.Thumbnail)
			{
				return null;
			}
			return (Types.Thumbnail)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.Thumbnail : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.FocusMessage Focus
	{
		get
		{
			if (requestCase_ != RequestOneofCase.Focus)
			{
				return null;
			}
			return (Types.FocusMessage)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.Focus : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.TriggerMessage Trigger
	{
		get
		{
			if (requestCase_ != RequestOneofCase.Trigger)
			{
				return null;
			}
			return (Types.TriggerMessage)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.Trigger : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RequestOneofCase RequestCase => requestCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Presentation_Request()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Presentation_Request(API_v1_Presentation_Request other)
		: this()
	{
		switch (other.RequestCase)
		{
		case RequestOneofCase.Active:
			Active = other.Active.Clone();
			break;
		case RequestOneofCase.Focused:
			Focused = other.Focused.Clone();
			break;
		case RequestOneofCase.SlideIndex:
			SlideIndex = other.SlideIndex.Clone();
			break;
		case RequestOneofCase.ChordChart:
			ChordChart = other.ChordChart.Clone();
			break;
		case RequestOneofCase.ChordChartUpdates:
			ChordChartUpdates = other.ChordChartUpdates.Clone();
			break;
		case RequestOneofCase.Presentation:
			Presentation = other.Presentation.Clone();
			break;
		case RequestOneofCase.DeletePresentation:
			DeletePresentation = other.DeletePresentation.Clone();
			break;
		case RequestOneofCase.TimelineOperation:
			TimelineOperation = other.TimelineOperation.Clone();
			break;
		case RequestOneofCase.ActivePresentationTimelineOperation:
			ActivePresentationTimelineOperation = other.ActivePresentationTimelineOperation.Clone();
			break;
		case RequestOneofCase.FocusedPresentationTimelineOperation:
			FocusedPresentationTimelineOperation = other.FocusedPresentationTimelineOperation.Clone();
			break;
		case RequestOneofCase.ActivePresentationTimelineStatus:
			ActivePresentationTimelineStatus = other.ActivePresentationTimelineStatus.Clone();
			break;
		case RequestOneofCase.FocusedPresentationTimelineStatus:
			FocusedPresentationTimelineStatus = other.FocusedPresentationTimelineStatus.Clone();
			break;
		case RequestOneofCase.Thumbnail:
			Thumbnail = other.Thumbnail.Clone();
			break;
		case RequestOneofCase.Focus:
			Focus = other.Focus.Clone();
			break;
		case RequestOneofCase.Trigger:
			Trigger = other.Trigger.Clone();
			break;
		}
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Presentation_Request Clone()
	{
		return new API_v1_Presentation_Request(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void ClearRequest()
	{
		requestCase_ = RequestOneofCase.None;
		request_ = null;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as API_v1_Presentation_Request);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(API_v1_Presentation_Request other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(Active, other.Active))
		{
			return false;
		}
		if (!object.Equals(Focused, other.Focused))
		{
			return false;
		}
		if (!object.Equals(SlideIndex, other.SlideIndex))
		{
			return false;
		}
		if (!object.Equals(ChordChart, other.ChordChart))
		{
			return false;
		}
		if (!object.Equals(ChordChartUpdates, other.ChordChartUpdates))
		{
			return false;
		}
		if (!object.Equals(Presentation, other.Presentation))
		{
			return false;
		}
		if (!object.Equals(DeletePresentation, other.DeletePresentation))
		{
			return false;
		}
		if (!object.Equals(TimelineOperation, other.TimelineOperation))
		{
			return false;
		}
		if (!object.Equals(ActivePresentationTimelineOperation, other.ActivePresentationTimelineOperation))
		{
			return false;
		}
		if (!object.Equals(FocusedPresentationTimelineOperation, other.FocusedPresentationTimelineOperation))
		{
			return false;
		}
		if (!object.Equals(ActivePresentationTimelineStatus, other.ActivePresentationTimelineStatus))
		{
			return false;
		}
		if (!object.Equals(FocusedPresentationTimelineStatus, other.FocusedPresentationTimelineStatus))
		{
			return false;
		}
		if (!object.Equals(Thumbnail, other.Thumbnail))
		{
			return false;
		}
		if (!object.Equals(Focus, other.Focus))
		{
			return false;
		}
		if (!object.Equals(Trigger, other.Trigger))
		{
			return false;
		}
		if (RequestCase != other.RequestCase)
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
		if (requestCase_ == RequestOneofCase.Active)
		{
			num ^= Active.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.Focused)
		{
			num ^= Focused.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.SlideIndex)
		{
			num ^= SlideIndex.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.ChordChart)
		{
			num ^= ChordChart.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.ChordChartUpdates)
		{
			num ^= ChordChartUpdates.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.Presentation)
		{
			num ^= Presentation.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.DeletePresentation)
		{
			num ^= DeletePresentation.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.TimelineOperation)
		{
			num ^= TimelineOperation.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.ActivePresentationTimelineOperation)
		{
			num ^= ActivePresentationTimelineOperation.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.FocusedPresentationTimelineOperation)
		{
			num ^= FocusedPresentationTimelineOperation.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.ActivePresentationTimelineStatus)
		{
			num ^= ActivePresentationTimelineStatus.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.FocusedPresentationTimelineStatus)
		{
			num ^= FocusedPresentationTimelineStatus.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.Thumbnail)
		{
			num ^= Thumbnail.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.Focus)
		{
			num ^= Focus.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.Trigger)
		{
			num ^= Trigger.GetHashCode();
		}
		num ^= (int)requestCase_;
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
		if (requestCase_ == RequestOneofCase.Active)
		{
			output.WriteRawTag(10);
			output.WriteMessage(Active);
		}
		if (requestCase_ == RequestOneofCase.Focused)
		{
			output.WriteRawTag(18);
			output.WriteMessage(Focused);
		}
		if (requestCase_ == RequestOneofCase.SlideIndex)
		{
			output.WriteRawTag(26);
			output.WriteMessage(SlideIndex);
		}
		if (requestCase_ == RequestOneofCase.ChordChart)
		{
			output.WriteRawTag(34);
			output.WriteMessage(ChordChart);
		}
		if (requestCase_ == RequestOneofCase.ChordChartUpdates)
		{
			output.WriteRawTag(42);
			output.WriteMessage(ChordChartUpdates);
		}
		if (requestCase_ == RequestOneofCase.Presentation)
		{
			output.WriteRawTag(50);
			output.WriteMessage(Presentation);
		}
		if (requestCase_ == RequestOneofCase.DeletePresentation)
		{
			output.WriteRawTag(58);
			output.WriteMessage(DeletePresentation);
		}
		if (requestCase_ == RequestOneofCase.TimelineOperation)
		{
			output.WriteRawTag(66);
			output.WriteMessage(TimelineOperation);
		}
		if (requestCase_ == RequestOneofCase.ActivePresentationTimelineOperation)
		{
			output.WriteRawTag(74);
			output.WriteMessage(ActivePresentationTimelineOperation);
		}
		if (requestCase_ == RequestOneofCase.FocusedPresentationTimelineOperation)
		{
			output.WriteRawTag(82);
			output.WriteMessage(FocusedPresentationTimelineOperation);
		}
		if (requestCase_ == RequestOneofCase.ActivePresentationTimelineStatus)
		{
			output.WriteRawTag(90);
			output.WriteMessage(ActivePresentationTimelineStatus);
		}
		if (requestCase_ == RequestOneofCase.FocusedPresentationTimelineStatus)
		{
			output.WriteRawTag(98);
			output.WriteMessage(FocusedPresentationTimelineStatus);
		}
		if (requestCase_ == RequestOneofCase.Thumbnail)
		{
			output.WriteRawTag(106);
			output.WriteMessage(Thumbnail);
		}
		if (requestCase_ == RequestOneofCase.Focus)
		{
			output.WriteRawTag(114);
			output.WriteMessage(Focus);
		}
		if (requestCase_ == RequestOneofCase.Trigger)
		{
			output.WriteRawTag(122);
			output.WriteMessage(Trigger);
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
		if (requestCase_ == RequestOneofCase.Active)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Active);
		}
		if (requestCase_ == RequestOneofCase.Focused)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Focused);
		}
		if (requestCase_ == RequestOneofCase.SlideIndex)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(SlideIndex);
		}
		if (requestCase_ == RequestOneofCase.ChordChart)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(ChordChart);
		}
		if (requestCase_ == RequestOneofCase.ChordChartUpdates)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(ChordChartUpdates);
		}
		if (requestCase_ == RequestOneofCase.Presentation)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Presentation);
		}
		if (requestCase_ == RequestOneofCase.DeletePresentation)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(DeletePresentation);
		}
		if (requestCase_ == RequestOneofCase.TimelineOperation)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(TimelineOperation);
		}
		if (requestCase_ == RequestOneofCase.ActivePresentationTimelineOperation)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(ActivePresentationTimelineOperation);
		}
		if (requestCase_ == RequestOneofCase.FocusedPresentationTimelineOperation)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(FocusedPresentationTimelineOperation);
		}
		if (requestCase_ == RequestOneofCase.ActivePresentationTimelineStatus)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(ActivePresentationTimelineStatus);
		}
		if (requestCase_ == RequestOneofCase.FocusedPresentationTimelineStatus)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(FocusedPresentationTimelineStatus);
		}
		if (requestCase_ == RequestOneofCase.Thumbnail)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Thumbnail);
		}
		if (requestCase_ == RequestOneofCase.Focus)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Focus);
		}
		if (requestCase_ == RequestOneofCase.Trigger)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Trigger);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(API_v1_Presentation_Request other)
	{
		if (other == null)
		{
			return;
		}
		switch (other.RequestCase)
		{
		case RequestOneofCase.Active:
			if (Active == null)
			{
				Active = new Types.Active();
			}
			Active.MergeFrom(other.Active);
			break;
		case RequestOneofCase.Focused:
			if (Focused == null)
			{
				Focused = new Types.EmptyMessage();
			}
			Focused.MergeFrom(other.Focused);
			break;
		case RequestOneofCase.SlideIndex:
			if (SlideIndex == null)
			{
				SlideIndex = new Types.SlideIndex();
			}
			SlideIndex.MergeFrom(other.SlideIndex);
			break;
		case RequestOneofCase.ChordChart:
			if (ChordChart == null)
			{
				ChordChart = new Types.ChordChart();
			}
			ChordChart.MergeFrom(other.ChordChart);
			break;
		case RequestOneofCase.ChordChartUpdates:
			if (ChordChartUpdates == null)
			{
				ChordChartUpdates = new Types.ChordChartUpdates();
			}
			ChordChartUpdates.MergeFrom(other.ChordChartUpdates);
			break;
		case RequestOneofCase.Presentation:
			if (Presentation == null)
			{
				Presentation = new Types.Presentation();
			}
			Presentation.MergeFrom(other.Presentation);
			break;
		case RequestOneofCase.DeletePresentation:
			if (DeletePresentation == null)
			{
				DeletePresentation = new Types.DeletePresentation();
			}
			DeletePresentation.MergeFrom(other.DeletePresentation);
			break;
		case RequestOneofCase.TimelineOperation:
			if (TimelineOperation == null)
			{
				TimelineOperation = new Types.TimelineOperation();
			}
			TimelineOperation.MergeFrom(other.TimelineOperation);
			break;
		case RequestOneofCase.ActivePresentationTimelineOperation:
			if (ActivePresentationTimelineOperation == null)
			{
				ActivePresentationTimelineOperation = new Types.ActivePresentationTimelineOperation();
			}
			ActivePresentationTimelineOperation.MergeFrom(other.ActivePresentationTimelineOperation);
			break;
		case RequestOneofCase.FocusedPresentationTimelineOperation:
			if (FocusedPresentationTimelineOperation == null)
			{
				FocusedPresentationTimelineOperation = new Types.FocusedPresentationTimelineOperation();
			}
			FocusedPresentationTimelineOperation.MergeFrom(other.FocusedPresentationTimelineOperation);
			break;
		case RequestOneofCase.ActivePresentationTimelineStatus:
			if (ActivePresentationTimelineStatus == null)
			{
				ActivePresentationTimelineStatus = new Types.ActivePresentationTimelineStatus();
			}
			ActivePresentationTimelineStatus.MergeFrom(other.ActivePresentationTimelineStatus);
			break;
		case RequestOneofCase.FocusedPresentationTimelineStatus:
			if (FocusedPresentationTimelineStatus == null)
			{
				FocusedPresentationTimelineStatus = new Types.FocusedPresentationTimelineStatus();
			}
			FocusedPresentationTimelineStatus.MergeFrom(other.FocusedPresentationTimelineStatus);
			break;
		case RequestOneofCase.Thumbnail:
			if (Thumbnail == null)
			{
				Thumbnail = new Types.Thumbnail();
			}
			Thumbnail.MergeFrom(other.Thumbnail);
			break;
		case RequestOneofCase.Focus:
			if (Focus == null)
			{
				Focus = new Types.FocusMessage();
			}
			Focus.MergeFrom(other.Focus);
			break;
		case RequestOneofCase.Trigger:
			if (Trigger == null)
			{
				Trigger = new Types.TriggerMessage();
			}
			Trigger.MergeFrom(other.Trigger);
			break;
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
			{
				Types.Active active = new Types.Active();
				if (requestCase_ == RequestOneofCase.Active)
				{
					active.MergeFrom(Active);
				}
				input.ReadMessage(active);
				Active = active;
				break;
			}
			case 18u:
			{
				Types.EmptyMessage emptyMessage = new Types.EmptyMessage();
				if (requestCase_ == RequestOneofCase.Focused)
				{
					emptyMessage.MergeFrom(Focused);
				}
				input.ReadMessage(emptyMessage);
				Focused = emptyMessage;
				break;
			}
			case 26u:
			{
				Types.SlideIndex slideIndex = new Types.SlideIndex();
				if (requestCase_ == RequestOneofCase.SlideIndex)
				{
					slideIndex.MergeFrom(SlideIndex);
				}
				input.ReadMessage(slideIndex);
				SlideIndex = slideIndex;
				break;
			}
			case 34u:
			{
				Types.ChordChart chordChart = new Types.ChordChart();
				if (requestCase_ == RequestOneofCase.ChordChart)
				{
					chordChart.MergeFrom(ChordChart);
				}
				input.ReadMessage(chordChart);
				ChordChart = chordChart;
				break;
			}
			case 42u:
			{
				Types.ChordChartUpdates chordChartUpdates = new Types.ChordChartUpdates();
				if (requestCase_ == RequestOneofCase.ChordChartUpdates)
				{
					chordChartUpdates.MergeFrom(ChordChartUpdates);
				}
				input.ReadMessage(chordChartUpdates);
				ChordChartUpdates = chordChartUpdates;
				break;
			}
			case 50u:
			{
				Types.Presentation presentation = new Types.Presentation();
				if (requestCase_ == RequestOneofCase.Presentation)
				{
					presentation.MergeFrom(Presentation);
				}
				input.ReadMessage(presentation);
				Presentation = presentation;
				break;
			}
			case 58u:
			{
				Types.DeletePresentation deletePresentation = new Types.DeletePresentation();
				if (requestCase_ == RequestOneofCase.DeletePresentation)
				{
					deletePresentation.MergeFrom(DeletePresentation);
				}
				input.ReadMessage(deletePresentation);
				DeletePresentation = deletePresentation;
				break;
			}
			case 66u:
			{
				Types.TimelineOperation timelineOperation = new Types.TimelineOperation();
				if (requestCase_ == RequestOneofCase.TimelineOperation)
				{
					timelineOperation.MergeFrom(TimelineOperation);
				}
				input.ReadMessage(timelineOperation);
				TimelineOperation = timelineOperation;
				break;
			}
			case 74u:
			{
				Types.ActivePresentationTimelineOperation activePresentationTimelineOperation = new Types.ActivePresentationTimelineOperation();
				if (requestCase_ == RequestOneofCase.ActivePresentationTimelineOperation)
				{
					activePresentationTimelineOperation.MergeFrom(ActivePresentationTimelineOperation);
				}
				input.ReadMessage(activePresentationTimelineOperation);
				ActivePresentationTimelineOperation = activePresentationTimelineOperation;
				break;
			}
			case 82u:
			{
				Types.FocusedPresentationTimelineOperation focusedPresentationTimelineOperation = new Types.FocusedPresentationTimelineOperation();
				if (requestCase_ == RequestOneofCase.FocusedPresentationTimelineOperation)
				{
					focusedPresentationTimelineOperation.MergeFrom(FocusedPresentationTimelineOperation);
				}
				input.ReadMessage(focusedPresentationTimelineOperation);
				FocusedPresentationTimelineOperation = focusedPresentationTimelineOperation;
				break;
			}
			case 90u:
			{
				Types.ActivePresentationTimelineStatus activePresentationTimelineStatus = new Types.ActivePresentationTimelineStatus();
				if (requestCase_ == RequestOneofCase.ActivePresentationTimelineStatus)
				{
					activePresentationTimelineStatus.MergeFrom(ActivePresentationTimelineStatus);
				}
				input.ReadMessage(activePresentationTimelineStatus);
				ActivePresentationTimelineStatus = activePresentationTimelineStatus;
				break;
			}
			case 98u:
			{
				Types.FocusedPresentationTimelineStatus focusedPresentationTimelineStatus = new Types.FocusedPresentationTimelineStatus();
				if (requestCase_ == RequestOneofCase.FocusedPresentationTimelineStatus)
				{
					focusedPresentationTimelineStatus.MergeFrom(FocusedPresentationTimelineStatus);
				}
				input.ReadMessage(focusedPresentationTimelineStatus);
				FocusedPresentationTimelineStatus = focusedPresentationTimelineStatus;
				break;
			}
			case 106u:
			{
				Types.Thumbnail thumbnail = new Types.Thumbnail();
				if (requestCase_ == RequestOneofCase.Thumbnail)
				{
					thumbnail.MergeFrom(Thumbnail);
				}
				input.ReadMessage(thumbnail);
				Thumbnail = thumbnail;
				break;
			}
			case 114u:
			{
				Types.FocusMessage focusMessage = new Types.FocusMessage();
				if (requestCase_ == RequestOneofCase.Focus)
				{
					focusMessage.MergeFrom(Focus);
				}
				input.ReadMessage(focusMessage);
				Focus = focusMessage;
				break;
			}
			case 122u:
			{
				Types.TriggerMessage triggerMessage = new Types.TriggerMessage();
				if (requestCase_ == RequestOneofCase.Trigger)
				{
					triggerMessage.MergeFrom(Trigger);
				}
				input.ReadMessage(triggerMessage);
				Trigger = triggerMessage;
				break;
			}
			}
		}
	}
}
