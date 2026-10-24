using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;
using Pro.SerializationInterop.RVProtoData.Analytics.MultiTracks;

namespace Pro.SerializationInterop.RVProtoData.Analytics.Import;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class SongSelect : IMessage<SongSelect>, IMessage, IEquatable<SongSelect>, IDeepCloneable<SongSelect>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		public enum LineDelimiter
		{
			[OriginalName("UNKNOWN")]
			Unknown,
			[OriginalName("LINE_BREAK")]
			LineBreak,
			[OriginalName("PARAGRAPH_BREAK")]
			ParagraphBreak
		}
	}

	private static readonly MessageParser<SongSelect> _parser = new MessageParser<SongSelect>(() => new SongSelect());

	private UnknownFieldSet _unknownFields;

	public const int TemplateSlideTextElementCountFieldNumber = 1;

	private int templateSlideTextElementCount_;

	public const int ImportIntoPlaylistFieldNumber = 2;

	private bool importIntoPlaylist_;

	public const int LineDelimiterFieldNumber = 3;

	private Types.LineDelimiter lineDelimiter_;

	public const int LineDelimiterCountFieldNumber = 4;

	private int lineDelimiterCount_;

	public const int DidOpenEditViewFieldNumber = 5;

	private bool didOpenEditView_;

	public const int MultitracksFieldNumber = 6;

	private Pro.SerializationInterop.RVProtoData.Analytics.MultiTracks.Import multitracks_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<SongSelect> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AnalyticsImportReflection.Descriptor.MessageTypes[0];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int TemplateSlideTextElementCount
	{
		get
		{
			return templateSlideTextElementCount_;
		}
		set
		{
			templateSlideTextElementCount_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool ImportIntoPlaylist
	{
		get
		{
			return importIntoPlaylist_;
		}
		set
		{
			importIntoPlaylist_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.LineDelimiter LineDelimiter
	{
		get
		{
			return lineDelimiter_;
		}
		set
		{
			lineDelimiter_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int LineDelimiterCount
	{
		get
		{
			return lineDelimiterCount_;
		}
		set
		{
			lineDelimiterCount_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool DidOpenEditView
	{
		get
		{
			return didOpenEditView_;
		}
		set
		{
			didOpenEditView_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Pro.SerializationInterop.RVProtoData.Analytics.MultiTracks.Import Multitracks
	{
		get
		{
			return multitracks_;
		}
		set
		{
			multitracks_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public SongSelect()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public SongSelect(SongSelect other)
		: this()
	{
		templateSlideTextElementCount_ = other.templateSlideTextElementCount_;
		importIntoPlaylist_ = other.importIntoPlaylist_;
		lineDelimiter_ = other.lineDelimiter_;
		lineDelimiterCount_ = other.lineDelimiterCount_;
		didOpenEditView_ = other.didOpenEditView_;
		multitracks_ = ((other.multitracks_ != null) ? other.multitracks_.Clone() : null);
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public SongSelect Clone()
	{
		return new SongSelect(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as SongSelect);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(SongSelect other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (TemplateSlideTextElementCount != other.TemplateSlideTextElementCount)
		{
			return false;
		}
		if (ImportIntoPlaylist != other.ImportIntoPlaylist)
		{
			return false;
		}
		if (LineDelimiter != other.LineDelimiter)
		{
			return false;
		}
		if (LineDelimiterCount != other.LineDelimiterCount)
		{
			return false;
		}
		if (DidOpenEditView != other.DidOpenEditView)
		{
			return false;
		}
		if (!object.Equals(Multitracks, other.Multitracks))
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
		if (TemplateSlideTextElementCount != 0)
		{
			num ^= TemplateSlideTextElementCount.GetHashCode();
		}
		if (ImportIntoPlaylist)
		{
			num ^= ImportIntoPlaylist.GetHashCode();
		}
		if (LineDelimiter != 0)
		{
			num ^= LineDelimiter.GetHashCode();
		}
		if (LineDelimiterCount != 0)
		{
			num ^= LineDelimiterCount.GetHashCode();
		}
		if (DidOpenEditView)
		{
			num ^= DidOpenEditView.GetHashCode();
		}
		if (multitracks_ != null)
		{
			num ^= Multitracks.GetHashCode();
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
		if (TemplateSlideTextElementCount != 0)
		{
			output.WriteRawTag(8);
			output.WriteInt32(TemplateSlideTextElementCount);
		}
		if (ImportIntoPlaylist)
		{
			output.WriteRawTag(16);
			output.WriteBool(ImportIntoPlaylist);
		}
		if (LineDelimiter != 0)
		{
			output.WriteRawTag(24);
			output.WriteEnum((int)LineDelimiter);
		}
		if (LineDelimiterCount != 0)
		{
			output.WriteRawTag(32);
			output.WriteInt32(LineDelimiterCount);
		}
		if (DidOpenEditView)
		{
			output.WriteRawTag(40);
			output.WriteBool(DidOpenEditView);
		}
		if (multitracks_ != null)
		{
			output.WriteRawTag(50);
			output.WriteMessage(Multitracks);
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
		if (TemplateSlideTextElementCount != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(TemplateSlideTextElementCount);
		}
		if (ImportIntoPlaylist)
		{
			num += 2;
		}
		if (LineDelimiter != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)LineDelimiter);
		}
		if (LineDelimiterCount != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(LineDelimiterCount);
		}
		if (DidOpenEditView)
		{
			num += 2;
		}
		if (multitracks_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Multitracks);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(SongSelect other)
	{
		if (other == null)
		{
			return;
		}
		if (other.TemplateSlideTextElementCount != 0)
		{
			TemplateSlideTextElementCount = other.TemplateSlideTextElementCount;
		}
		if (other.ImportIntoPlaylist)
		{
			ImportIntoPlaylist = other.ImportIntoPlaylist;
		}
		if (other.LineDelimiter != 0)
		{
			LineDelimiter = other.LineDelimiter;
		}
		if (other.LineDelimiterCount != 0)
		{
			LineDelimiterCount = other.LineDelimiterCount;
		}
		if (other.DidOpenEditView)
		{
			DidOpenEditView = other.DidOpenEditView;
		}
		if (other.multitracks_ != null)
		{
			if (multitracks_ == null)
			{
				Multitracks = new Pro.SerializationInterop.RVProtoData.Analytics.MultiTracks.Import();
			}
			Multitracks.MergeFrom(other.Multitracks);
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
				TemplateSlideTextElementCount = input.ReadInt32();
				break;
			case 16u:
				ImportIntoPlaylist = input.ReadBool();
				break;
			case 24u:
				LineDelimiter = (Types.LineDelimiter)input.ReadEnum();
				break;
			case 32u:
				LineDelimiterCount = input.ReadInt32();
				break;
			case 40u:
				DidOpenEditView = input.ReadBool();
				break;
			case 50u:
				if (multitracks_ == null)
				{
					Multitracks = new Pro.SerializationInterop.RVProtoData.Analytics.MultiTracks.Import();
				}
				input.ReadMessage(Multitracks);
				break;
			}
		}
	}
}
