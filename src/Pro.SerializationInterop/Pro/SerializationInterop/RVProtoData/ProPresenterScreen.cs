using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class ProPresenterScreen : IMessage<ProPresenterScreen>, IMessage, IEquatable<ProPresenterScreen>, IDeepCloneable<ProPresenterScreen>
{
	public enum ArrangementOneofCase
	{
		None = 0,
		ArrangementSingle = 3,
		ArrangementCombined = 4,
		ArrangementEdgeBlend = 5
	}

	public enum RenderingEnabledOptionalOneofCase
	{
		None = 0,
		RenderingEnabled = 9
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		public enum ScreenType
		{
			[OriginalName("SCREEN_TYPE_UNKNOWN")]
			Unknown,
			[OriginalName("SCREEN_TYPE_AUDIENCE")]
			Audience,
			[OriginalName("SCREEN_TYPE_STAGE")]
			Stage
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class SingleArrangement : IMessage<SingleArrangement>, IMessage, IEquatable<SingleArrangement>, IDeepCloneable<SingleArrangement>
		{
			private static readonly MessageParser<SingleArrangement> _parser = new MessageParser<SingleArrangement>(() => new SingleArrangement());

			private UnknownFieldSet _unknownFields;

			public const int ScreensFieldNumber = 1;

			private static readonly FieldCodec<Screen> _repeated_screens_codec = FieldCodec.ForMessage(10u, Screen.Parser);

			private readonly RepeatedField<Screen> screens_ = new RepeatedField<Screen>();

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<SingleArrangement> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => ProPresenterScreen.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RepeatedField<Screen> Screens => screens_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public SingleArrangement()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public SingleArrangement(SingleArrangement other)
				: this()
			{
				screens_ = other.screens_.Clone();
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public SingleArrangement Clone()
			{
				return new SingleArrangement(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as SingleArrangement);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(SingleArrangement other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!screens_.Equals(other.screens_))
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
				num ^= screens_.GetHashCode();
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
				screens_.WriteTo(output, _repeated_screens_codec);
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
				num += screens_.CalculateSize(_repeated_screens_codec);
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(SingleArrangement other)
			{
				if (other != null)
				{
					screens_.Add(other.screens_);
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
						screens_.AddEntriesFrom(input, _repeated_screens_codec);
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class CombinedArrangement : IMessage<CombinedArrangement>, IMessage, IEquatable<CombinedArrangement>, IDeepCloneable<CombinedArrangement>
		{
			private static readonly MessageParser<CombinedArrangement> _parser = new MessageParser<CombinedArrangement>(() => new CombinedArrangement());

			private UnknownFieldSet _unknownFields;

			public const int ScreensFieldNumber = 1;

			private static readonly FieldCodec<Screen> _repeated_screens_codec = FieldCodec.ForMessage(10u, Screen.Parser);

			private readonly RepeatedField<Screen> screens_ = new RepeatedField<Screen>();

			public const int RowsFieldNumber = 2;

			private uint rows_;

			public const int ColumnsFieldNumber = 3;

			private uint columns_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<CombinedArrangement> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => ProPresenterScreen.Descriptor.NestedTypes[1];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RepeatedField<Screen> Screens => screens_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public uint Rows
			{
				get
				{
					return rows_;
				}
				set
				{
					rows_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public uint Columns
			{
				get
				{
					return columns_;
				}
				set
				{
					columns_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public CombinedArrangement()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public CombinedArrangement(CombinedArrangement other)
				: this()
			{
				screens_ = other.screens_.Clone();
				rows_ = other.rows_;
				columns_ = other.columns_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public CombinedArrangement Clone()
			{
				return new CombinedArrangement(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as CombinedArrangement);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(CombinedArrangement other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!screens_.Equals(other.screens_))
				{
					return false;
				}
				if (Rows != other.Rows)
				{
					return false;
				}
				if (Columns != other.Columns)
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
				num ^= screens_.GetHashCode();
				if (Rows != 0)
				{
					num ^= Rows.GetHashCode();
				}
				if (Columns != 0)
				{
					num ^= Columns.GetHashCode();
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
				screens_.WriteTo(output, _repeated_screens_codec);
				if (Rows != 0)
				{
					output.WriteRawTag(16);
					output.WriteUInt32(Rows);
				}
				if (Columns != 0)
				{
					output.WriteRawTag(24);
					output.WriteUInt32(Columns);
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
				num += screens_.CalculateSize(_repeated_screens_codec);
				if (Rows != 0)
				{
					num += 1 + CodedOutputStream.ComputeUInt32Size(Rows);
				}
				if (Columns != 0)
				{
					num += 1 + CodedOutputStream.ComputeUInt32Size(Columns);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(CombinedArrangement other)
			{
				if (other != null)
				{
					screens_.Add(other.screens_);
					if (other.Rows != 0)
					{
						Rows = other.Rows;
					}
					if (other.Columns != 0)
					{
						Columns = other.Columns;
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
						screens_.AddEntriesFrom(input, _repeated_screens_codec);
						break;
					case 16u:
						Rows = input.ReadUInt32();
						break;
					case 24u:
						Columns = input.ReadUInt32();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class EdgeBlendArrangement : IMessage<EdgeBlendArrangement>, IMessage, IEquatable<EdgeBlendArrangement>, IDeepCloneable<EdgeBlendArrangement>
		{
			private static readonly MessageParser<EdgeBlendArrangement> _parser = new MessageParser<EdgeBlendArrangement>(() => new EdgeBlendArrangement());

			private UnknownFieldSet _unknownFields;

			public const int ScreenCountFieldNumber = 1;

			private uint screenCount_;

			public const int ScreensFieldNumber = 2;

			private static readonly FieldCodec<Screen> _repeated_screens_codec = FieldCodec.ForMessage(18u, Screen.Parser);

			private readonly RepeatedField<Screen> screens_ = new RepeatedField<Screen>();

			public const int EdgeBlendsFieldNumber = 3;

			private static readonly FieldCodec<EdgeBlend> _repeated_edgeBlends_codec = FieldCodec.ForMessage(26u, EdgeBlend.Parser);

			private readonly RepeatedField<EdgeBlend> edgeBlends_ = new RepeatedField<EdgeBlend>();

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<EdgeBlendArrangement> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => ProPresenterScreen.Descriptor.NestedTypes[2];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public uint ScreenCount
			{
				get
				{
					return screenCount_;
				}
				set
				{
					screenCount_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RepeatedField<Screen> Screens => screens_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RepeatedField<EdgeBlend> EdgeBlends => edgeBlends_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public EdgeBlendArrangement()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public EdgeBlendArrangement(EdgeBlendArrangement other)
				: this()
			{
				screenCount_ = other.screenCount_;
				screens_ = other.screens_.Clone();
				edgeBlends_ = other.edgeBlends_.Clone();
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public EdgeBlendArrangement Clone()
			{
				return new EdgeBlendArrangement(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as EdgeBlendArrangement);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(EdgeBlendArrangement other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (ScreenCount != other.ScreenCount)
				{
					return false;
				}
				if (!screens_.Equals(other.screens_))
				{
					return false;
				}
				if (!edgeBlends_.Equals(other.edgeBlends_))
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
				if (ScreenCount != 0)
				{
					num ^= ScreenCount.GetHashCode();
				}
				num ^= screens_.GetHashCode();
				num ^= edgeBlends_.GetHashCode();
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
				if (ScreenCount != 0)
				{
					output.WriteRawTag(8);
					output.WriteUInt32(ScreenCount);
				}
				screens_.WriteTo(output, _repeated_screens_codec);
				edgeBlends_.WriteTo(output, _repeated_edgeBlends_codec);
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
				if (ScreenCount != 0)
				{
					num += 1 + CodedOutputStream.ComputeUInt32Size(ScreenCount);
				}
				num += screens_.CalculateSize(_repeated_screens_codec);
				num += edgeBlends_.CalculateSize(_repeated_edgeBlends_codec);
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(EdgeBlendArrangement other)
			{
				if (other != null)
				{
					if (other.ScreenCount != 0)
					{
						ScreenCount = other.ScreenCount;
					}
					screens_.Add(other.screens_);
					edgeBlends_.Add(other.edgeBlends_);
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
						ScreenCount = input.ReadUInt32();
						break;
					case 18u:
						screens_.AddEntriesFrom(input, _repeated_screens_codec);
						break;
					case 26u:
						edgeBlends_.AddEntriesFrom(input, _repeated_edgeBlends_codec);
						break;
					}
				}
			}
		}
	}

	private static readonly MessageParser<ProPresenterScreen> _parser = new MessageParser<ProPresenterScreen>(() => new ProPresenterScreen());

	private UnknownFieldSet _unknownFields;

	public const int NameFieldNumber = 1;

	private string name_ = "";

	public const int ScreenTypeFieldNumber = 2;

	private Types.ScreenType screenType_;

	public const int ArrangementSingleFieldNumber = 3;

	public const int ArrangementCombinedFieldNumber = 4;

	public const int ArrangementEdgeBlendFieldNumber = 5;

	public const int BackgroundColorFieldNumber = 6;

	private Color backgroundColor_;

	public const int UuidFieldNumber = 7;

	private UUID uuid_;

	public const int BackgroundColorEnabledFieldNumber = 8;

	private bool backgroundColorEnabled_;

	public const int RenderingEnabledFieldNumber = 9;

	private object arrangement_;

	private ArrangementOneofCase arrangementCase_;

	private object renderingEnabledOptional_;

	private RenderingEnabledOptionalOneofCase renderingEnabledOptionalCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<ProPresenterScreen> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProscreenReflection.Descriptor.MessageTypes[0];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string Name
	{
		get
		{
			return name_;
		}
		set
		{
			name_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.ScreenType ScreenType
	{
		get
		{
			return screenType_;
		}
		set
		{
			screenType_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.SingleArrangement ArrangementSingle
	{
		get
		{
			if (arrangementCase_ != ArrangementOneofCase.ArrangementSingle)
			{
				return null;
			}
			return (Types.SingleArrangement)arrangement_;
		}
		set
		{
			arrangement_ = value;
			arrangementCase_ = ((value != null) ? ArrangementOneofCase.ArrangementSingle : ArrangementOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.CombinedArrangement ArrangementCombined
	{
		get
		{
			if (arrangementCase_ != ArrangementOneofCase.ArrangementCombined)
			{
				return null;
			}
			return (Types.CombinedArrangement)arrangement_;
		}
		set
		{
			arrangement_ = value;
			arrangementCase_ = ((value != null) ? ArrangementOneofCase.ArrangementCombined : ArrangementOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.EdgeBlendArrangement ArrangementEdgeBlend
	{
		get
		{
			if (arrangementCase_ != ArrangementOneofCase.ArrangementEdgeBlend)
			{
				return null;
			}
			return (Types.EdgeBlendArrangement)arrangement_;
		}
		set
		{
			arrangement_ = value;
			arrangementCase_ = ((value != null) ? ArrangementOneofCase.ArrangementEdgeBlend : ArrangementOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Color BackgroundColor
	{
		get
		{
			return backgroundColor_;
		}
		set
		{
			backgroundColor_ = value;
		}
	}

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
	public bool BackgroundColorEnabled
	{
		get
		{
			return backgroundColorEnabled_;
		}
		set
		{
			backgroundColorEnabled_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool RenderingEnabled
	{
		get
		{
			if (!HasRenderingEnabled)
			{
				return false;
			}
			return (bool)renderingEnabledOptional_;
		}
		set
		{
			renderingEnabledOptional_ = value;
			renderingEnabledOptionalCase_ = RenderingEnabledOptionalOneofCase.RenderingEnabled;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool HasRenderingEnabled => renderingEnabledOptionalCase_ == RenderingEnabledOptionalOneofCase.RenderingEnabled;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ArrangementOneofCase ArrangementCase => arrangementCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RenderingEnabledOptionalOneofCase RenderingEnabledOptionalCase => renderingEnabledOptionalCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ProPresenterScreen()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ProPresenterScreen(ProPresenterScreen other)
		: this()
	{
		name_ = other.name_;
		screenType_ = other.screenType_;
		backgroundColor_ = ((other.backgroundColor_ != null) ? other.backgroundColor_.Clone() : null);
		uuid_ = ((other.uuid_ != null) ? other.uuid_.Clone() : null);
		backgroundColorEnabled_ = other.backgroundColorEnabled_;
		switch (other.ArrangementCase)
		{
		case ArrangementOneofCase.ArrangementSingle:
			ArrangementSingle = other.ArrangementSingle.Clone();
			break;
		case ArrangementOneofCase.ArrangementCombined:
			ArrangementCombined = other.ArrangementCombined.Clone();
			break;
		case ArrangementOneofCase.ArrangementEdgeBlend:
			ArrangementEdgeBlend = other.ArrangementEdgeBlend.Clone();
			break;
		}
		if (other.RenderingEnabledOptionalCase == RenderingEnabledOptionalOneofCase.RenderingEnabled)
		{
			RenderingEnabled = other.RenderingEnabled;
		}
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ProPresenterScreen Clone()
	{
		return new ProPresenterScreen(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void ClearRenderingEnabled()
	{
		if (HasRenderingEnabled)
		{
			ClearRenderingEnabledOptional();
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void ClearArrangement()
	{
		arrangementCase_ = ArrangementOneofCase.None;
		arrangement_ = null;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void ClearRenderingEnabledOptional()
	{
		renderingEnabledOptionalCase_ = RenderingEnabledOptionalOneofCase.None;
		renderingEnabledOptional_ = null;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as ProPresenterScreen);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(ProPresenterScreen other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (Name != other.Name)
		{
			return false;
		}
		if (ScreenType != other.ScreenType)
		{
			return false;
		}
		if (!object.Equals(ArrangementSingle, other.ArrangementSingle))
		{
			return false;
		}
		if (!object.Equals(ArrangementCombined, other.ArrangementCombined))
		{
			return false;
		}
		if (!object.Equals(ArrangementEdgeBlend, other.ArrangementEdgeBlend))
		{
			return false;
		}
		if (!object.Equals(BackgroundColor, other.BackgroundColor))
		{
			return false;
		}
		if (!object.Equals(Uuid, other.Uuid))
		{
			return false;
		}
		if (BackgroundColorEnabled != other.BackgroundColorEnabled)
		{
			return false;
		}
		if (RenderingEnabled != other.RenderingEnabled)
		{
			return false;
		}
		if (ArrangementCase != other.ArrangementCase)
		{
			return false;
		}
		if (RenderingEnabledOptionalCase != other.RenderingEnabledOptionalCase)
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
		if (Name.Length != 0)
		{
			num ^= Name.GetHashCode();
		}
		if (ScreenType != 0)
		{
			num ^= ScreenType.GetHashCode();
		}
		if (arrangementCase_ == ArrangementOneofCase.ArrangementSingle)
		{
			num ^= ArrangementSingle.GetHashCode();
		}
		if (arrangementCase_ == ArrangementOneofCase.ArrangementCombined)
		{
			num ^= ArrangementCombined.GetHashCode();
		}
		if (arrangementCase_ == ArrangementOneofCase.ArrangementEdgeBlend)
		{
			num ^= ArrangementEdgeBlend.GetHashCode();
		}
		if (backgroundColor_ != null)
		{
			num ^= BackgroundColor.GetHashCode();
		}
		if (uuid_ != null)
		{
			num ^= Uuid.GetHashCode();
		}
		if (BackgroundColorEnabled)
		{
			num ^= BackgroundColorEnabled.GetHashCode();
		}
		if (HasRenderingEnabled)
		{
			num ^= RenderingEnabled.GetHashCode();
		}
		num ^= (int)arrangementCase_;
		num ^= (int)renderingEnabledOptionalCase_;
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
		if (Name.Length != 0)
		{
			output.WriteRawTag(10);
			output.WriteString(Name);
		}
		if (ScreenType != 0)
		{
			output.WriteRawTag(16);
			output.WriteEnum((int)ScreenType);
		}
		if (arrangementCase_ == ArrangementOneofCase.ArrangementSingle)
		{
			output.WriteRawTag(26);
			output.WriteMessage(ArrangementSingle);
		}
		if (arrangementCase_ == ArrangementOneofCase.ArrangementCombined)
		{
			output.WriteRawTag(34);
			output.WriteMessage(ArrangementCombined);
		}
		if (arrangementCase_ == ArrangementOneofCase.ArrangementEdgeBlend)
		{
			output.WriteRawTag(42);
			output.WriteMessage(ArrangementEdgeBlend);
		}
		if (backgroundColor_ != null)
		{
			output.WriteRawTag(50);
			output.WriteMessage(BackgroundColor);
		}
		if (uuid_ != null)
		{
			output.WriteRawTag(58);
			output.WriteMessage(Uuid);
		}
		if (BackgroundColorEnabled)
		{
			output.WriteRawTag(64);
			output.WriteBool(BackgroundColorEnabled);
		}
		if (HasRenderingEnabled)
		{
			output.WriteRawTag(72);
			output.WriteBool(RenderingEnabled);
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
		if (Name.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Name);
		}
		if (ScreenType != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)ScreenType);
		}
		if (arrangementCase_ == ArrangementOneofCase.ArrangementSingle)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(ArrangementSingle);
		}
		if (arrangementCase_ == ArrangementOneofCase.ArrangementCombined)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(ArrangementCombined);
		}
		if (arrangementCase_ == ArrangementOneofCase.ArrangementEdgeBlend)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(ArrangementEdgeBlend);
		}
		if (backgroundColor_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(BackgroundColor);
		}
		if (uuid_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Uuid);
		}
		if (BackgroundColorEnabled)
		{
			num += 2;
		}
		if (HasRenderingEnabled)
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
	public void MergeFrom(ProPresenterScreen other)
	{
		if (other == null)
		{
			return;
		}
		if (other.Name.Length != 0)
		{
			Name = other.Name;
		}
		if (other.ScreenType != 0)
		{
			ScreenType = other.ScreenType;
		}
		if (other.backgroundColor_ != null)
		{
			if (backgroundColor_ == null)
			{
				BackgroundColor = new Color();
			}
			BackgroundColor.MergeFrom(other.BackgroundColor);
		}
		if (other.uuid_ != null)
		{
			if (uuid_ == null)
			{
				Uuid = new UUID();
			}
			Uuid.MergeFrom(other.Uuid);
		}
		if (other.BackgroundColorEnabled)
		{
			BackgroundColorEnabled = other.BackgroundColorEnabled;
		}
		switch (other.ArrangementCase)
		{
		case ArrangementOneofCase.ArrangementSingle:
			if (ArrangementSingle == null)
			{
				ArrangementSingle = new Types.SingleArrangement();
			}
			ArrangementSingle.MergeFrom(other.ArrangementSingle);
			break;
		case ArrangementOneofCase.ArrangementCombined:
			if (ArrangementCombined == null)
			{
				ArrangementCombined = new Types.CombinedArrangement();
			}
			ArrangementCombined.MergeFrom(other.ArrangementCombined);
			break;
		case ArrangementOneofCase.ArrangementEdgeBlend:
			if (ArrangementEdgeBlend == null)
			{
				ArrangementEdgeBlend = new Types.EdgeBlendArrangement();
			}
			ArrangementEdgeBlend.MergeFrom(other.ArrangementEdgeBlend);
			break;
		}
		if (other.RenderingEnabledOptionalCase == RenderingEnabledOptionalOneofCase.RenderingEnabled)
		{
			RenderingEnabled = other.RenderingEnabled;
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
				Name = input.ReadString();
				break;
			case 16u:
				ScreenType = (Types.ScreenType)input.ReadEnum();
				break;
			case 26u:
			{
				Types.SingleArrangement singleArrangement = new Types.SingleArrangement();
				if (arrangementCase_ == ArrangementOneofCase.ArrangementSingle)
				{
					singleArrangement.MergeFrom(ArrangementSingle);
				}
				input.ReadMessage(singleArrangement);
				ArrangementSingle = singleArrangement;
				break;
			}
			case 34u:
			{
				Types.CombinedArrangement combinedArrangement = new Types.CombinedArrangement();
				if (arrangementCase_ == ArrangementOneofCase.ArrangementCombined)
				{
					combinedArrangement.MergeFrom(ArrangementCombined);
				}
				input.ReadMessage(combinedArrangement);
				ArrangementCombined = combinedArrangement;
				break;
			}
			case 42u:
			{
				Types.EdgeBlendArrangement edgeBlendArrangement = new Types.EdgeBlendArrangement();
				if (arrangementCase_ == ArrangementOneofCase.ArrangementEdgeBlend)
				{
					edgeBlendArrangement.MergeFrom(ArrangementEdgeBlend);
				}
				input.ReadMessage(edgeBlendArrangement);
				ArrangementEdgeBlend = edgeBlendArrangement;
				break;
			}
			case 50u:
				if (backgroundColor_ == null)
				{
					BackgroundColor = new Color();
				}
				input.ReadMessage(BackgroundColor);
				break;
			case 58u:
				if (uuid_ == null)
				{
					Uuid = new UUID();
				}
				input.ReadMessage(Uuid);
				break;
			case 64u:
				BackgroundColorEnabled = input.ReadBool();
				break;
			case 72u:
				RenderingEnabled = input.ReadBool();
				break;
			}
		}
	}
}
