using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class API_v1_Presentation_Response : IMessage<API_v1_Presentation_Response>, IMessage, IEquatable<API_v1_Presentation_Response>, IDeepCloneable<API_v1_Presentation_Response>
{
	public enum ResponseOneofCase
	{
		None,
		Active,
		SlideIndex,
		ChordChart,
		ChordChartUpdate,
		Presentation,
		DeletePresentation,
		TriggerPresentation,
		TriggerCue,
		TimelineOperation,
		ActivePresentationTimelineOperation,
		FocusedPresentationTimelineOperation,
		ActivePresentationTimelineStatus,
		FocusedPresentationTimelineStatus,
		Thumbnail,
		Focused,
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

			public const int PresentationFieldNumber = 1;

			private API_v1_Presentation presentation_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Active> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Presentation_Response.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_Presentation Presentation
			{
				get
				{
					return presentation_;
				}
				set
				{
					presentation_ = value;
				}
			}

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
				presentation_ = ((other.presentation_ != null) ? other.presentation_.Clone() : null);
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
				if (!object.Equals(Presentation, other.Presentation))
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
				if (presentation_ != null)
				{
					num ^= Presentation.GetHashCode();
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
				if (presentation_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Presentation);
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
				if (presentation_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Presentation);
				}
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
				if (other == null)
				{
					return;
				}
				if (other.presentation_ != null)
				{
					if (presentation_ == null)
					{
						Presentation = new API_v1_Presentation();
					}
					Presentation.MergeFrom(other.Presentation);
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
					if (presentation_ == null)
					{
						Presentation = new API_v1_Presentation();
					}
					input.ReadMessage(Presentation);
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class SlideIndex : IMessage<SlideIndex>, IMessage, IEquatable<SlideIndex>, IDeepCloneable<SlideIndex>
		{
			private static readonly MessageParser<SlideIndex> _parser = new MessageParser<SlideIndex>(() => new SlideIndex());

			private UnknownFieldSet _unknownFields;

			public const int PresentationIndexFieldNumber = 1;

			private API_v1_SlideIndex presentationIndex_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<SlideIndex> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Presentation_Response.Descriptor.NestedTypes[1];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_SlideIndex PresentationIndex
			{
				get
				{
					return presentationIndex_;
				}
				set
				{
					presentationIndex_ = value;
				}
			}

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
				presentationIndex_ = ((other.presentationIndex_ != null) ? other.presentationIndex_.Clone() : null);
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
				if (!object.Equals(PresentationIndex, other.PresentationIndex))
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
				if (presentationIndex_ != null)
				{
					num ^= PresentationIndex.GetHashCode();
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
				if (presentationIndex_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(PresentationIndex);
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
				if (presentationIndex_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(PresentationIndex);
				}
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
				if (other == null)
				{
					return;
				}
				if (other.presentationIndex_ != null)
				{
					if (presentationIndex_ == null)
					{
						PresentationIndex = new API_v1_SlideIndex();
					}
					PresentationIndex.MergeFrom(other.PresentationIndex);
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
					if (presentationIndex_ == null)
					{
						PresentationIndex = new API_v1_SlideIndex();
					}
					input.ReadMessage(PresentationIndex);
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class ChordChart : IMessage<ChordChart>, IMessage, IEquatable<ChordChart>, IDeepCloneable<ChordChart>
		{
			private static readonly MessageParser<ChordChart> _parser = new MessageParser<ChordChart>(() => new ChordChart());

			private UnknownFieldSet _unknownFields;

			public const int ChordChart_FieldNumber = 1;

			private ByteString chordChart_ = ByteString.Empty;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<ChordChart> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Presentation_Response.Descriptor.NestedTypes[2];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ByteString ChordChart_
			{
				get
				{
					return chordChart_;
				}
				set
				{
					chordChart_ = ProtoPreconditions.CheckNotNull(value, "value");
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
				chordChart_ = other.chordChart_;
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
				if (ChordChart_ != other.ChordChart_)
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
				if (ChordChart_.Length != 0)
				{
					num ^= ChordChart_.GetHashCode();
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
				if (ChordChart_.Length != 0)
				{
					output.WriteRawTag(10);
					output.WriteBytes(ChordChart_);
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
				if (ChordChart_.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeBytesSize(ChordChart_);
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
					if (other.ChordChart_.Length != 0)
					{
						ChordChart_ = other.ChordChart_;
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
					if (num != 10)
					{
						_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
					}
					else
					{
						ChordChart_ = input.ReadBytes();
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
			public static MessageDescriptor Descriptor => API_v1_Presentation_Response.Descriptor.NestedTypes[3];

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

			public const int Presentation_FieldNumber = 1;

			private API_v1_Presentation presentation_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Presentation> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Presentation_Response.Descriptor.NestedTypes[4];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_Presentation Presentation_
			{
				get
				{
					return presentation_;
				}
				set
				{
					presentation_ = value;
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
				presentation_ = ((other.presentation_ != null) ? other.presentation_.Clone() : null);
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
				if (!object.Equals(Presentation_, other.Presentation_))
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
				if (presentation_ != null)
				{
					num ^= Presentation_.GetHashCode();
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
				if (presentation_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Presentation_);
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
				if (presentation_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Presentation_);
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
				if (other.presentation_ != null)
				{
					if (presentation_ == null)
					{
						Presentation_ = new API_v1_Presentation();
					}
					Presentation_.MergeFrom(other.Presentation_);
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
					if (presentation_ == null)
					{
						Presentation_ = new API_v1_Presentation();
					}
					input.ReadMessage(Presentation_);
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class DeletePresentation : IMessage<DeletePresentation>, IMessage, IEquatable<DeletePresentation>, IDeepCloneable<DeletePresentation>
		{
			private static readonly MessageParser<DeletePresentation> _parser = new MessageParser<DeletePresentation>(() => new DeletePresentation());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<DeletePresentation> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Presentation_Response.Descriptor.NestedTypes[5];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

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
			public void MergeFrom(DeletePresentation other)
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
		public sealed class TriggerPresentation : IMessage<TriggerPresentation>, IMessage, IEquatable<TriggerPresentation>, IDeepCloneable<TriggerPresentation>
		{
			private static readonly MessageParser<TriggerPresentation> _parser = new MessageParser<TriggerPresentation>(() => new TriggerPresentation());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<TriggerPresentation> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Presentation_Response.Descriptor.NestedTypes[6];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TriggerPresentation()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TriggerPresentation(TriggerPresentation other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TriggerPresentation Clone()
			{
				return new TriggerPresentation(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as TriggerPresentation);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(TriggerPresentation other)
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
			public void MergeFrom(TriggerPresentation other)
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
		public sealed class TriggerCue : IMessage<TriggerCue>, IMessage, IEquatable<TriggerCue>, IDeepCloneable<TriggerCue>
		{
			private static readonly MessageParser<TriggerCue> _parser = new MessageParser<TriggerCue>(() => new TriggerCue());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<TriggerCue> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Presentation_Response.Descriptor.NestedTypes[7];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TriggerCue()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TriggerCue(TriggerCue other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TriggerCue Clone()
			{
				return new TriggerCue(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as TriggerCue);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(TriggerCue other)
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
			public void MergeFrom(TriggerCue other)
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
		public sealed class TimelineOperation : IMessage<TimelineOperation>, IMessage, IEquatable<TimelineOperation>, IDeepCloneable<TimelineOperation>
		{
			private static readonly MessageParser<TimelineOperation> _parser = new MessageParser<TimelineOperation>(() => new TimelineOperation());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<TimelineOperation> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Presentation_Response.Descriptor.NestedTypes[8];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

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
			public void MergeFrom(TimelineOperation other)
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
		public sealed class ActivePresentationTimelineOperation : IMessage<ActivePresentationTimelineOperation>, IMessage, IEquatable<ActivePresentationTimelineOperation>, IDeepCloneable<ActivePresentationTimelineOperation>
		{
			private static readonly MessageParser<ActivePresentationTimelineOperation> _parser = new MessageParser<ActivePresentationTimelineOperation>(() => new ActivePresentationTimelineOperation());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<ActivePresentationTimelineOperation> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Presentation_Response.Descriptor.NestedTypes[9];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

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
			public void MergeFrom(ActivePresentationTimelineOperation other)
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
		public sealed class FocusedPresentationTimelineOperation : IMessage<FocusedPresentationTimelineOperation>, IMessage, IEquatable<FocusedPresentationTimelineOperation>, IDeepCloneable<FocusedPresentationTimelineOperation>
		{
			private static readonly MessageParser<FocusedPresentationTimelineOperation> _parser = new MessageParser<FocusedPresentationTimelineOperation>(() => new FocusedPresentationTimelineOperation());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<FocusedPresentationTimelineOperation> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Presentation_Response.Descriptor.NestedTypes[10];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

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
			public void MergeFrom(FocusedPresentationTimelineOperation other)
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
		public sealed class ActivePresentationTimelineStatus : IMessage<ActivePresentationTimelineStatus>, IMessage, IEquatable<ActivePresentationTimelineStatus>, IDeepCloneable<ActivePresentationTimelineStatus>
		{
			private static readonly MessageParser<ActivePresentationTimelineStatus> _parser = new MessageParser<ActivePresentationTimelineStatus>(() => new ActivePresentationTimelineStatus());

			private UnknownFieldSet _unknownFields;

			public const int IsRunningFieldNumber = 1;

			private bool isRunning_;

			public const int CurrentTimeFieldNumber = 2;

			private double currentTime_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<ActivePresentationTimelineStatus> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Presentation_Response.Descriptor.NestedTypes[11];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool IsRunning
			{
				get
				{
					return isRunning_;
				}
				set
				{
					isRunning_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public double CurrentTime
			{
				get
				{
					return currentTime_;
				}
				set
				{
					currentTime_ = value;
				}
			}

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
				isRunning_ = other.isRunning_;
				currentTime_ = other.currentTime_;
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
				if (IsRunning != other.IsRunning)
				{
					return false;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(CurrentTime, other.CurrentTime))
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
				if (IsRunning)
				{
					num ^= IsRunning.GetHashCode();
				}
				if (CurrentTime != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(CurrentTime);
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
				if (IsRunning)
				{
					output.WriteRawTag(8);
					output.WriteBool(IsRunning);
				}
				if (CurrentTime != 0.0)
				{
					output.WriteRawTag(17);
					output.WriteDouble(CurrentTime);
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
				if (IsRunning)
				{
					num += 2;
				}
				if (CurrentTime != 0.0)
				{
					num += 9;
				}
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
					if (other.IsRunning)
					{
						IsRunning = other.IsRunning;
					}
					if (other.CurrentTime != 0.0)
					{
						CurrentTime = other.CurrentTime;
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
						IsRunning = input.ReadBool();
						break;
					case 17u:
						CurrentTime = input.ReadDouble();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class FocusedPresentationTimelineStatus : IMessage<FocusedPresentationTimelineStatus>, IMessage, IEquatable<FocusedPresentationTimelineStatus>, IDeepCloneable<FocusedPresentationTimelineStatus>
		{
			private static readonly MessageParser<FocusedPresentationTimelineStatus> _parser = new MessageParser<FocusedPresentationTimelineStatus>(() => new FocusedPresentationTimelineStatus());

			private UnknownFieldSet _unknownFields;

			public const int IsRunningFieldNumber = 1;

			private bool isRunning_;

			public const int CurrentTimeFieldNumber = 2;

			private double currentTime_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<FocusedPresentationTimelineStatus> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Presentation_Response.Descriptor.NestedTypes[12];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool IsRunning
			{
				get
				{
					return isRunning_;
				}
				set
				{
					isRunning_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public double CurrentTime
			{
				get
				{
					return currentTime_;
				}
				set
				{
					currentTime_ = value;
				}
			}

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
				isRunning_ = other.isRunning_;
				currentTime_ = other.currentTime_;
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
				if (IsRunning != other.IsRunning)
				{
					return false;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(CurrentTime, other.CurrentTime))
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
				if (IsRunning)
				{
					num ^= IsRunning.GetHashCode();
				}
				if (CurrentTime != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(CurrentTime);
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
				if (IsRunning)
				{
					output.WriteRawTag(8);
					output.WriteBool(IsRunning);
				}
				if (CurrentTime != 0.0)
				{
					output.WriteRawTag(17);
					output.WriteDouble(CurrentTime);
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
				if (IsRunning)
				{
					num += 2;
				}
				if (CurrentTime != 0.0)
				{
					num += 9;
				}
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
					if (other.IsRunning)
					{
						IsRunning = other.IsRunning;
					}
					if (other.CurrentTime != 0.0)
					{
						CurrentTime = other.CurrentTime;
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
						IsRunning = input.ReadBool();
						break;
					case 17u:
						CurrentTime = input.ReadDouble();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Thumbnail : IMessage<Thumbnail>, IMessage, IEquatable<Thumbnail>, IDeepCloneable<Thumbnail>
		{
			private static readonly MessageParser<Thumbnail> _parser = new MessageParser<Thumbnail>(() => new Thumbnail());

			private UnknownFieldSet _unknownFields;

			public const int DataFieldNumber = 1;

			private ByteString data_ = ByteString.Empty;

			public const int ContentTypeFieldNumber = 2;

			private API_v1_ContentType contentType_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Thumbnail> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Presentation_Response.Descriptor.NestedTypes[13];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ByteString Data
			{
				get
				{
					return data_;
				}
				set
				{
					data_ = ProtoPreconditions.CheckNotNull(value, "value");
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
				data_ = other.data_;
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
				if (Data != other.Data)
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
				if (Data.Length != 0)
				{
					num ^= Data.GetHashCode();
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
				if (Data.Length != 0)
				{
					output.WriteRawTag(10);
					output.WriteBytes(Data);
				}
				if (ContentType != 0)
				{
					output.WriteRawTag(16);
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
				if (Data.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeBytesSize(Data);
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
				if (other != null)
				{
					if (other.Data.Length != 0)
					{
						Data = other.Data;
					}
					if (other.ContentType != 0)
					{
						ContentType = other.ContentType;
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
					case 10u:
						Data = input.ReadBytes();
						break;
					case 16u:
						ContentType = (API_v1_ContentType)input.ReadEnum();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Focused : IMessage<Focused>, IMessage, IEquatable<Focused>, IDeepCloneable<Focused>
		{
			private static readonly MessageParser<Focused> _parser = new MessageParser<Focused>(() => new Focused());

			private UnknownFieldSet _unknownFields;

			public const int IdFieldNumber = 1;

			private API_v1_Identifier id_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Focused> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Presentation_Response.Descriptor.NestedTypes[14];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_Identifier Id
			{
				get
				{
					return id_;
				}
				set
				{
					id_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Focused()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Focused(Focused other)
				: this()
			{
				id_ = ((other.id_ != null) ? other.id_.Clone() : null);
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Focused Clone()
			{
				return new Focused(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Focused);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Focused other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(Id, other.Id))
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
				if (id_ != null)
				{
					num ^= Id.GetHashCode();
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
				if (id_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Id);
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
				if (id_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Id);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(Focused other)
			{
				if (other == null)
				{
					return;
				}
				if (other.id_ != null)
				{
					if (id_ == null)
					{
						Id = new API_v1_Identifier();
					}
					Id.MergeFrom(other.Id);
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
					if (id_ == null)
					{
						Id = new API_v1_Identifier();
					}
					input.ReadMessage(Id);
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
			public static MessageDescriptor Descriptor => API_v1_Presentation_Response.Descriptor.NestedTypes[15];

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
	}

	private static readonly MessageParser<API_v1_Presentation_Response> _parser = new MessageParser<API_v1_Presentation_Response>(() => new API_v1_Presentation_Response());

	private UnknownFieldSet _unknownFields;

	public const int ActiveFieldNumber = 1;

	public const int SlideIndexFieldNumber = 2;

	public const int ChordChartFieldNumber = 3;

	public const int ChordChartUpdateFieldNumber = 4;

	public const int PresentationFieldNumber = 5;

	public const int DeletePresentationFieldNumber = 6;

	public const int TriggerPresentationFieldNumber = 7;

	public const int TriggerCueFieldNumber = 8;

	public const int TimelineOperationFieldNumber = 9;

	public const int ActivePresentationTimelineOperationFieldNumber = 10;

	public const int FocusedPresentationTimelineOperationFieldNumber = 11;

	public const int ActivePresentationTimelineStatusFieldNumber = 12;

	public const int FocusedPresentationTimelineStatusFieldNumber = 13;

	public const int ThumbnailFieldNumber = 14;

	public const int FocusedFieldNumber = 15;

	public const int FocusFieldNumber = 16;

	public const int TriggerFieldNumber = 17;

	private object response_;

	private ResponseOneofCase responseCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<API_v1_Presentation_Response> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProApiV1PresentationReflection.Descriptor.MessageTypes[3];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Active Active
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.Active)
			{
				return null;
			}
			return (Types.Active)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.Active : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.SlideIndex SlideIndex
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.SlideIndex)
			{
				return null;
			}
			return (Types.SlideIndex)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.SlideIndex : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.ChordChart ChordChart
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.ChordChart)
			{
				return null;
			}
			return (Types.ChordChart)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.ChordChart : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.ChordChartUpdates ChordChartUpdate
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.ChordChartUpdate)
			{
				return null;
			}
			return (Types.ChordChartUpdates)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.ChordChartUpdate : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Presentation Presentation
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.Presentation)
			{
				return null;
			}
			return (Types.Presentation)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.Presentation : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.DeletePresentation DeletePresentation
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.DeletePresentation)
			{
				return null;
			}
			return (Types.DeletePresentation)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.DeletePresentation : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.TriggerPresentation TriggerPresentation
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.TriggerPresentation)
			{
				return null;
			}
			return (Types.TriggerPresentation)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.TriggerPresentation : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.TriggerCue TriggerCue
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.TriggerCue)
			{
				return null;
			}
			return (Types.TriggerCue)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.TriggerCue : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.TimelineOperation TimelineOperation
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.TimelineOperation)
			{
				return null;
			}
			return (Types.TimelineOperation)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.TimelineOperation : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.ActivePresentationTimelineOperation ActivePresentationTimelineOperation
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.ActivePresentationTimelineOperation)
			{
				return null;
			}
			return (Types.ActivePresentationTimelineOperation)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.ActivePresentationTimelineOperation : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.FocusedPresentationTimelineOperation FocusedPresentationTimelineOperation
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.FocusedPresentationTimelineOperation)
			{
				return null;
			}
			return (Types.FocusedPresentationTimelineOperation)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.FocusedPresentationTimelineOperation : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.ActivePresentationTimelineStatus ActivePresentationTimelineStatus
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.ActivePresentationTimelineStatus)
			{
				return null;
			}
			return (Types.ActivePresentationTimelineStatus)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.ActivePresentationTimelineStatus : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.FocusedPresentationTimelineStatus FocusedPresentationTimelineStatus
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.FocusedPresentationTimelineStatus)
			{
				return null;
			}
			return (Types.FocusedPresentationTimelineStatus)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.FocusedPresentationTimelineStatus : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Thumbnail Thumbnail
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.Thumbnail)
			{
				return null;
			}
			return (Types.Thumbnail)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.Thumbnail : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Focused Focused
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.Focused)
			{
				return null;
			}
			return (Types.Focused)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.Focused : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.EmptyMessage Focus
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.Focus)
			{
				return null;
			}
			return (Types.EmptyMessage)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.Focus : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.EmptyMessage Trigger
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.Trigger)
			{
				return null;
			}
			return (Types.EmptyMessage)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.Trigger : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ResponseOneofCase ResponseCase => responseCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Presentation_Response()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Presentation_Response(API_v1_Presentation_Response other)
		: this()
	{
		switch (other.ResponseCase)
		{
		case ResponseOneofCase.Active:
			Active = other.Active.Clone();
			break;
		case ResponseOneofCase.SlideIndex:
			SlideIndex = other.SlideIndex.Clone();
			break;
		case ResponseOneofCase.ChordChart:
			ChordChart = other.ChordChart.Clone();
			break;
		case ResponseOneofCase.ChordChartUpdate:
			ChordChartUpdate = other.ChordChartUpdate.Clone();
			break;
		case ResponseOneofCase.Presentation:
			Presentation = other.Presentation.Clone();
			break;
		case ResponseOneofCase.DeletePresentation:
			DeletePresentation = other.DeletePresentation.Clone();
			break;
		case ResponseOneofCase.TriggerPresentation:
			TriggerPresentation = other.TriggerPresentation.Clone();
			break;
		case ResponseOneofCase.TriggerCue:
			TriggerCue = other.TriggerCue.Clone();
			break;
		case ResponseOneofCase.TimelineOperation:
			TimelineOperation = other.TimelineOperation.Clone();
			break;
		case ResponseOneofCase.ActivePresentationTimelineOperation:
			ActivePresentationTimelineOperation = other.ActivePresentationTimelineOperation.Clone();
			break;
		case ResponseOneofCase.FocusedPresentationTimelineOperation:
			FocusedPresentationTimelineOperation = other.FocusedPresentationTimelineOperation.Clone();
			break;
		case ResponseOneofCase.ActivePresentationTimelineStatus:
			ActivePresentationTimelineStatus = other.ActivePresentationTimelineStatus.Clone();
			break;
		case ResponseOneofCase.FocusedPresentationTimelineStatus:
			FocusedPresentationTimelineStatus = other.FocusedPresentationTimelineStatus.Clone();
			break;
		case ResponseOneofCase.Thumbnail:
			Thumbnail = other.Thumbnail.Clone();
			break;
		case ResponseOneofCase.Focused:
			Focused = other.Focused.Clone();
			break;
		case ResponseOneofCase.Focus:
			Focus = other.Focus.Clone();
			break;
		case ResponseOneofCase.Trigger:
			Trigger = other.Trigger.Clone();
			break;
		}
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Presentation_Response Clone()
	{
		return new API_v1_Presentation_Response(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void ClearResponse()
	{
		responseCase_ = ResponseOneofCase.None;
		response_ = null;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as API_v1_Presentation_Response);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(API_v1_Presentation_Response other)
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
		if (!object.Equals(SlideIndex, other.SlideIndex))
		{
			return false;
		}
		if (!object.Equals(ChordChart, other.ChordChart))
		{
			return false;
		}
		if (!object.Equals(ChordChartUpdate, other.ChordChartUpdate))
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
		if (!object.Equals(TriggerPresentation, other.TriggerPresentation))
		{
			return false;
		}
		if (!object.Equals(TriggerCue, other.TriggerCue))
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
		if (!object.Equals(Focused, other.Focused))
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
		if (ResponseCase != other.ResponseCase)
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
		if (responseCase_ == ResponseOneofCase.Active)
		{
			num ^= Active.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.SlideIndex)
		{
			num ^= SlideIndex.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.ChordChart)
		{
			num ^= ChordChart.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.ChordChartUpdate)
		{
			num ^= ChordChartUpdate.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.Presentation)
		{
			num ^= Presentation.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.DeletePresentation)
		{
			num ^= DeletePresentation.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.TriggerPresentation)
		{
			num ^= TriggerPresentation.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.TriggerCue)
		{
			num ^= TriggerCue.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.TimelineOperation)
		{
			num ^= TimelineOperation.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.ActivePresentationTimelineOperation)
		{
			num ^= ActivePresentationTimelineOperation.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.FocusedPresentationTimelineOperation)
		{
			num ^= FocusedPresentationTimelineOperation.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.ActivePresentationTimelineStatus)
		{
			num ^= ActivePresentationTimelineStatus.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.FocusedPresentationTimelineStatus)
		{
			num ^= FocusedPresentationTimelineStatus.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.Thumbnail)
		{
			num ^= Thumbnail.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.Focused)
		{
			num ^= Focused.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.Focus)
		{
			num ^= Focus.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.Trigger)
		{
			num ^= Trigger.GetHashCode();
		}
		num ^= (int)responseCase_;
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
		if (responseCase_ == ResponseOneofCase.Active)
		{
			output.WriteRawTag(10);
			output.WriteMessage(Active);
		}
		if (responseCase_ == ResponseOneofCase.SlideIndex)
		{
			output.WriteRawTag(18);
			output.WriteMessage(SlideIndex);
		}
		if (responseCase_ == ResponseOneofCase.ChordChart)
		{
			output.WriteRawTag(26);
			output.WriteMessage(ChordChart);
		}
		if (responseCase_ == ResponseOneofCase.ChordChartUpdate)
		{
			output.WriteRawTag(34);
			output.WriteMessage(ChordChartUpdate);
		}
		if (responseCase_ == ResponseOneofCase.Presentation)
		{
			output.WriteRawTag(42);
			output.WriteMessage(Presentation);
		}
		if (responseCase_ == ResponseOneofCase.DeletePresentation)
		{
			output.WriteRawTag(50);
			output.WriteMessage(DeletePresentation);
		}
		if (responseCase_ == ResponseOneofCase.TriggerPresentation)
		{
			output.WriteRawTag(58);
			output.WriteMessage(TriggerPresentation);
		}
		if (responseCase_ == ResponseOneofCase.TriggerCue)
		{
			output.WriteRawTag(66);
			output.WriteMessage(TriggerCue);
		}
		if (responseCase_ == ResponseOneofCase.TimelineOperation)
		{
			output.WriteRawTag(74);
			output.WriteMessage(TimelineOperation);
		}
		if (responseCase_ == ResponseOneofCase.ActivePresentationTimelineOperation)
		{
			output.WriteRawTag(82);
			output.WriteMessage(ActivePresentationTimelineOperation);
		}
		if (responseCase_ == ResponseOneofCase.FocusedPresentationTimelineOperation)
		{
			output.WriteRawTag(90);
			output.WriteMessage(FocusedPresentationTimelineOperation);
		}
		if (responseCase_ == ResponseOneofCase.ActivePresentationTimelineStatus)
		{
			output.WriteRawTag(98);
			output.WriteMessage(ActivePresentationTimelineStatus);
		}
		if (responseCase_ == ResponseOneofCase.FocusedPresentationTimelineStatus)
		{
			output.WriteRawTag(106);
			output.WriteMessage(FocusedPresentationTimelineStatus);
		}
		if (responseCase_ == ResponseOneofCase.Thumbnail)
		{
			output.WriteRawTag(114);
			output.WriteMessage(Thumbnail);
		}
		if (responseCase_ == ResponseOneofCase.Focused)
		{
			output.WriteRawTag(122);
			output.WriteMessage(Focused);
		}
		if (responseCase_ == ResponseOneofCase.Focus)
		{
			output.WriteRawTag(130, 1);
			output.WriteMessage(Focus);
		}
		if (responseCase_ == ResponseOneofCase.Trigger)
		{
			output.WriteRawTag(138, 1);
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
		if (responseCase_ == ResponseOneofCase.Active)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Active);
		}
		if (responseCase_ == ResponseOneofCase.SlideIndex)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(SlideIndex);
		}
		if (responseCase_ == ResponseOneofCase.ChordChart)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(ChordChart);
		}
		if (responseCase_ == ResponseOneofCase.ChordChartUpdate)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(ChordChartUpdate);
		}
		if (responseCase_ == ResponseOneofCase.Presentation)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Presentation);
		}
		if (responseCase_ == ResponseOneofCase.DeletePresentation)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(DeletePresentation);
		}
		if (responseCase_ == ResponseOneofCase.TriggerPresentation)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(TriggerPresentation);
		}
		if (responseCase_ == ResponseOneofCase.TriggerCue)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(TriggerCue);
		}
		if (responseCase_ == ResponseOneofCase.TimelineOperation)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(TimelineOperation);
		}
		if (responseCase_ == ResponseOneofCase.ActivePresentationTimelineOperation)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(ActivePresentationTimelineOperation);
		}
		if (responseCase_ == ResponseOneofCase.FocusedPresentationTimelineOperation)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(FocusedPresentationTimelineOperation);
		}
		if (responseCase_ == ResponseOneofCase.ActivePresentationTimelineStatus)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(ActivePresentationTimelineStatus);
		}
		if (responseCase_ == ResponseOneofCase.FocusedPresentationTimelineStatus)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(FocusedPresentationTimelineStatus);
		}
		if (responseCase_ == ResponseOneofCase.Thumbnail)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Thumbnail);
		}
		if (responseCase_ == ResponseOneofCase.Focused)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Focused);
		}
		if (responseCase_ == ResponseOneofCase.Focus)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(Focus);
		}
		if (responseCase_ == ResponseOneofCase.Trigger)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(Trigger);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(API_v1_Presentation_Response other)
	{
		if (other == null)
		{
			return;
		}
		switch (other.ResponseCase)
		{
		case ResponseOneofCase.Active:
			if (Active == null)
			{
				Active = new Types.Active();
			}
			Active.MergeFrom(other.Active);
			break;
		case ResponseOneofCase.SlideIndex:
			if (SlideIndex == null)
			{
				SlideIndex = new Types.SlideIndex();
			}
			SlideIndex.MergeFrom(other.SlideIndex);
			break;
		case ResponseOneofCase.ChordChart:
			if (ChordChart == null)
			{
				ChordChart = new Types.ChordChart();
			}
			ChordChart.MergeFrom(other.ChordChart);
			break;
		case ResponseOneofCase.ChordChartUpdate:
			if (ChordChartUpdate == null)
			{
				ChordChartUpdate = new Types.ChordChartUpdates();
			}
			ChordChartUpdate.MergeFrom(other.ChordChartUpdate);
			break;
		case ResponseOneofCase.Presentation:
			if (Presentation == null)
			{
				Presentation = new Types.Presentation();
			}
			Presentation.MergeFrom(other.Presentation);
			break;
		case ResponseOneofCase.DeletePresentation:
			if (DeletePresentation == null)
			{
				DeletePresentation = new Types.DeletePresentation();
			}
			DeletePresentation.MergeFrom(other.DeletePresentation);
			break;
		case ResponseOneofCase.TriggerPresentation:
			if (TriggerPresentation == null)
			{
				TriggerPresentation = new Types.TriggerPresentation();
			}
			TriggerPresentation.MergeFrom(other.TriggerPresentation);
			break;
		case ResponseOneofCase.TriggerCue:
			if (TriggerCue == null)
			{
				TriggerCue = new Types.TriggerCue();
			}
			TriggerCue.MergeFrom(other.TriggerCue);
			break;
		case ResponseOneofCase.TimelineOperation:
			if (TimelineOperation == null)
			{
				TimelineOperation = new Types.TimelineOperation();
			}
			TimelineOperation.MergeFrom(other.TimelineOperation);
			break;
		case ResponseOneofCase.ActivePresentationTimelineOperation:
			if (ActivePresentationTimelineOperation == null)
			{
				ActivePresentationTimelineOperation = new Types.ActivePresentationTimelineOperation();
			}
			ActivePresentationTimelineOperation.MergeFrom(other.ActivePresentationTimelineOperation);
			break;
		case ResponseOneofCase.FocusedPresentationTimelineOperation:
			if (FocusedPresentationTimelineOperation == null)
			{
				FocusedPresentationTimelineOperation = new Types.FocusedPresentationTimelineOperation();
			}
			FocusedPresentationTimelineOperation.MergeFrom(other.FocusedPresentationTimelineOperation);
			break;
		case ResponseOneofCase.ActivePresentationTimelineStatus:
			if (ActivePresentationTimelineStatus == null)
			{
				ActivePresentationTimelineStatus = new Types.ActivePresentationTimelineStatus();
			}
			ActivePresentationTimelineStatus.MergeFrom(other.ActivePresentationTimelineStatus);
			break;
		case ResponseOneofCase.FocusedPresentationTimelineStatus:
			if (FocusedPresentationTimelineStatus == null)
			{
				FocusedPresentationTimelineStatus = new Types.FocusedPresentationTimelineStatus();
			}
			FocusedPresentationTimelineStatus.MergeFrom(other.FocusedPresentationTimelineStatus);
			break;
		case ResponseOneofCase.Thumbnail:
			if (Thumbnail == null)
			{
				Thumbnail = new Types.Thumbnail();
			}
			Thumbnail.MergeFrom(other.Thumbnail);
			break;
		case ResponseOneofCase.Focused:
			if (Focused == null)
			{
				Focused = new Types.Focused();
			}
			Focused.MergeFrom(other.Focused);
			break;
		case ResponseOneofCase.Focus:
			if (Focus == null)
			{
				Focus = new Types.EmptyMessage();
			}
			Focus.MergeFrom(other.Focus);
			break;
		case ResponseOneofCase.Trigger:
			if (Trigger == null)
			{
				Trigger = new Types.EmptyMessage();
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
				if (responseCase_ == ResponseOneofCase.Active)
				{
					active.MergeFrom(Active);
				}
				input.ReadMessage(active);
				Active = active;
				break;
			}
			case 18u:
			{
				Types.SlideIndex slideIndex = new Types.SlideIndex();
				if (responseCase_ == ResponseOneofCase.SlideIndex)
				{
					slideIndex.MergeFrom(SlideIndex);
				}
				input.ReadMessage(slideIndex);
				SlideIndex = slideIndex;
				break;
			}
			case 26u:
			{
				Types.ChordChart chordChart = new Types.ChordChart();
				if (responseCase_ == ResponseOneofCase.ChordChart)
				{
					chordChart.MergeFrom(ChordChart);
				}
				input.ReadMessage(chordChart);
				ChordChart = chordChart;
				break;
			}
			case 34u:
			{
				Types.ChordChartUpdates chordChartUpdates = new Types.ChordChartUpdates();
				if (responseCase_ == ResponseOneofCase.ChordChartUpdate)
				{
					chordChartUpdates.MergeFrom(ChordChartUpdate);
				}
				input.ReadMessage(chordChartUpdates);
				ChordChartUpdate = chordChartUpdates;
				break;
			}
			case 42u:
			{
				Types.Presentation presentation = new Types.Presentation();
				if (responseCase_ == ResponseOneofCase.Presentation)
				{
					presentation.MergeFrom(Presentation);
				}
				input.ReadMessage(presentation);
				Presentation = presentation;
				break;
			}
			case 50u:
			{
				Types.DeletePresentation deletePresentation = new Types.DeletePresentation();
				if (responseCase_ == ResponseOneofCase.DeletePresentation)
				{
					deletePresentation.MergeFrom(DeletePresentation);
				}
				input.ReadMessage(deletePresentation);
				DeletePresentation = deletePresentation;
				break;
			}
			case 58u:
			{
				Types.TriggerPresentation triggerPresentation = new Types.TriggerPresentation();
				if (responseCase_ == ResponseOneofCase.TriggerPresentation)
				{
					triggerPresentation.MergeFrom(TriggerPresentation);
				}
				input.ReadMessage(triggerPresentation);
				TriggerPresentation = triggerPresentation;
				break;
			}
			case 66u:
			{
				Types.TriggerCue triggerCue = new Types.TriggerCue();
				if (responseCase_ == ResponseOneofCase.TriggerCue)
				{
					triggerCue.MergeFrom(TriggerCue);
				}
				input.ReadMessage(triggerCue);
				TriggerCue = triggerCue;
				break;
			}
			case 74u:
			{
				Types.TimelineOperation timelineOperation = new Types.TimelineOperation();
				if (responseCase_ == ResponseOneofCase.TimelineOperation)
				{
					timelineOperation.MergeFrom(TimelineOperation);
				}
				input.ReadMessage(timelineOperation);
				TimelineOperation = timelineOperation;
				break;
			}
			case 82u:
			{
				Types.ActivePresentationTimelineOperation activePresentationTimelineOperation = new Types.ActivePresentationTimelineOperation();
				if (responseCase_ == ResponseOneofCase.ActivePresentationTimelineOperation)
				{
					activePresentationTimelineOperation.MergeFrom(ActivePresentationTimelineOperation);
				}
				input.ReadMessage(activePresentationTimelineOperation);
				ActivePresentationTimelineOperation = activePresentationTimelineOperation;
				break;
			}
			case 90u:
			{
				Types.FocusedPresentationTimelineOperation focusedPresentationTimelineOperation = new Types.FocusedPresentationTimelineOperation();
				if (responseCase_ == ResponseOneofCase.FocusedPresentationTimelineOperation)
				{
					focusedPresentationTimelineOperation.MergeFrom(FocusedPresentationTimelineOperation);
				}
				input.ReadMessage(focusedPresentationTimelineOperation);
				FocusedPresentationTimelineOperation = focusedPresentationTimelineOperation;
				break;
			}
			case 98u:
			{
				Types.ActivePresentationTimelineStatus activePresentationTimelineStatus = new Types.ActivePresentationTimelineStatus();
				if (responseCase_ == ResponseOneofCase.ActivePresentationTimelineStatus)
				{
					activePresentationTimelineStatus.MergeFrom(ActivePresentationTimelineStatus);
				}
				input.ReadMessage(activePresentationTimelineStatus);
				ActivePresentationTimelineStatus = activePresentationTimelineStatus;
				break;
			}
			case 106u:
			{
				Types.FocusedPresentationTimelineStatus focusedPresentationTimelineStatus = new Types.FocusedPresentationTimelineStatus();
				if (responseCase_ == ResponseOneofCase.FocusedPresentationTimelineStatus)
				{
					focusedPresentationTimelineStatus.MergeFrom(FocusedPresentationTimelineStatus);
				}
				input.ReadMessage(focusedPresentationTimelineStatus);
				FocusedPresentationTimelineStatus = focusedPresentationTimelineStatus;
				break;
			}
			case 114u:
			{
				Types.Thumbnail thumbnail = new Types.Thumbnail();
				if (responseCase_ == ResponseOneofCase.Thumbnail)
				{
					thumbnail.MergeFrom(Thumbnail);
				}
				input.ReadMessage(thumbnail);
				Thumbnail = thumbnail;
				break;
			}
			case 122u:
			{
				Types.Focused focused = new Types.Focused();
				if (responseCase_ == ResponseOneofCase.Focused)
				{
					focused.MergeFrom(Focused);
				}
				input.ReadMessage(focused);
				Focused = focused;
				break;
			}
			case 130u:
			{
				Types.EmptyMessage emptyMessage2 = new Types.EmptyMessage();
				if (responseCase_ == ResponseOneofCase.Focus)
				{
					emptyMessage2.MergeFrom(Focus);
				}
				input.ReadMessage(emptyMessage2);
				Focus = emptyMessage2;
				break;
			}
			case 138u:
			{
				Types.EmptyMessage emptyMessage = new Types.EmptyMessage();
				if (responseCase_ == ResponseOneofCase.Trigger)
				{
					emptyMessage.MergeFrom(Trigger);
				}
				input.ReadMessage(emptyMessage);
				Trigger = emptyMessage;
				break;
			}
			}
		}
	}
}
