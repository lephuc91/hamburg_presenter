using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class Workspace : IMessage<Workspace>, IMessage, IEquatable<Workspace>, IDeepCloneable<Workspace>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class EditorBackground : IMessage<EditorBackground>, IMessage, IEquatable<EditorBackground>, IDeepCloneable<EditorBackground>
		{
			private static readonly MessageParser<EditorBackground> _parser = new MessageParser<EditorBackground>(() => new EditorBackground());

			private UnknownFieldSet _unknownFields;

			public const int EnabledFieldNumber = 1;

			private bool enabled_;

			public const int FrameFieldNumber = 2;

			private Graphics.Types.Rect frame_;

			public const int UrlFieldNumber = 3;

			private URL url_;

			public const int OpacityFieldNumber = 4;

			private double opacity_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<EditorBackground> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Workspace.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Enabled
			{
				get
				{
					return enabled_;
				}
				set
				{
					enabled_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Graphics.Types.Rect Frame
			{
				get
				{
					return frame_;
				}
				set
				{
					frame_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public URL Url
			{
				get
				{
					return url_;
				}
				set
				{
					url_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public double Opacity
			{
				get
				{
					return opacity_;
				}
				set
				{
					opacity_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public EditorBackground()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public EditorBackground(EditorBackground other)
				: this()
			{
				enabled_ = other.enabled_;
				frame_ = ((other.frame_ != null) ? other.frame_.Clone() : null);
				url_ = ((other.url_ != null) ? other.url_.Clone() : null);
				opacity_ = other.opacity_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public EditorBackground Clone()
			{
				return new EditorBackground(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as EditorBackground);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(EditorBackground other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (Enabled != other.Enabled)
				{
					return false;
				}
				if (!object.Equals(Frame, other.Frame))
				{
					return false;
				}
				if (!object.Equals(Url, other.Url))
				{
					return false;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Opacity, other.Opacity))
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
				if (Enabled)
				{
					num ^= Enabled.GetHashCode();
				}
				if (frame_ != null)
				{
					num ^= Frame.GetHashCode();
				}
				if (url_ != null)
				{
					num ^= Url.GetHashCode();
				}
				if (Opacity != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Opacity);
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
				if (Enabled)
				{
					output.WriteRawTag(8);
					output.WriteBool(Enabled);
				}
				if (frame_ != null)
				{
					output.WriteRawTag(18);
					output.WriteMessage(Frame);
				}
				if (url_ != null)
				{
					output.WriteRawTag(26);
					output.WriteMessage(Url);
				}
				if (Opacity != 0.0)
				{
					output.WriteRawTag(33);
					output.WriteDouble(Opacity);
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
				if (Enabled)
				{
					num += 2;
				}
				if (frame_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Frame);
				}
				if (url_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Url);
				}
				if (Opacity != 0.0)
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
			public void MergeFrom(EditorBackground other)
			{
				if (other == null)
				{
					return;
				}
				if (other.Enabled)
				{
					Enabled = other.Enabled;
				}
				if (other.frame_ != null)
				{
					if (frame_ == null)
					{
						Frame = new Graphics.Types.Rect();
					}
					Frame.MergeFrom(other.Frame);
				}
				if (other.url_ != null)
				{
					if (url_ == null)
					{
						Url = new URL();
					}
					Url.MergeFrom(other.Url);
				}
				if (other.Opacity != 0.0)
				{
					Opacity = other.Opacity;
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
						Enabled = input.ReadBool();
						break;
					case 18u:
						if (frame_ == null)
						{
							Frame = new Graphics.Types.Rect();
						}
						input.ReadMessage(Frame);
						break;
					case 26u:
						if (url_ == null)
						{
							Url = new URL();
						}
						input.ReadMessage(Url);
						break;
					case 33u:
						Opacity = input.ReadDouble();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class UnitScaling : IMessage<UnitScaling>, IMessage, IEquatable<UnitScaling>, IDeepCloneable<UnitScaling>
		{
			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				public enum UnitType
				{
					[OriginalName("UNIT_TYPE_POINTS")]
					Points,
					[OriginalName("UNIT_TYPE_MILLIMETERS")]
					Millimeters,
					[OriginalName("UNIT_TYPE_CENTIMETERS")]
					Centimeters,
					[OriginalName("UNIT_TYPE_METERS")]
					Meters,
					[OriginalName("UNIT_TYPE_INCHES")]
					Inches,
					[OriginalName("UNIT_TYPE_FEET")]
					Feet
				}
			}

			private static readonly MessageParser<UnitScaling> _parser = new MessageParser<UnitScaling>(() => new UnitScaling());

			private UnknownFieldSet _unknownFields;

			public const int LengthFieldNumber = 1;

			private double length_;

			public const int UnitFieldNumber = 2;

			private Types.UnitType unit_;

			public const int PointsFieldNumber = 3;

			private double points_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<UnitScaling> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Workspace.Descriptor.NestedTypes[1];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public double Length
			{
				get
				{
					return length_;
				}
				set
				{
					length_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.UnitType Unit
			{
				get
				{
					return unit_;
				}
				set
				{
					unit_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public double Points
			{
				get
				{
					return points_;
				}
				set
				{
					points_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public UnitScaling()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public UnitScaling(UnitScaling other)
				: this()
			{
				length_ = other.length_;
				unit_ = other.unit_;
				points_ = other.points_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public UnitScaling Clone()
			{
				return new UnitScaling(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as UnitScaling);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(UnitScaling other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Length, other.Length))
				{
					return false;
				}
				if (Unit != other.Unit)
				{
					return false;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Points, other.Points))
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
				if (Length != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Length);
				}
				if (Unit != 0)
				{
					num ^= Unit.GetHashCode();
				}
				if (Points != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Points);
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
				if (Length != 0.0)
				{
					output.WriteRawTag(9);
					output.WriteDouble(Length);
				}
				if (Unit != 0)
				{
					output.WriteRawTag(16);
					output.WriteEnum((int)Unit);
				}
				if (Points != 0.0)
				{
					output.WriteRawTag(25);
					output.WriteDouble(Points);
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
				if (Length != 0.0)
				{
					num += 9;
				}
				if (Unit != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)Unit);
				}
				if (Points != 0.0)
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
			public void MergeFrom(UnitScaling other)
			{
				if (other != null)
				{
					if (other.Length != 0.0)
					{
						Length = other.Length;
					}
					if (other.Unit != 0)
					{
						Unit = other.Unit;
					}
					if (other.Points != 0.0)
					{
						Points = other.Points;
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
					case 9u:
						Length = input.ReadDouble();
						break;
					case 16u:
						Unit = (Types.UnitType)input.ReadEnum();
						break;
					case 25u:
						Points = input.ReadDouble();
						break;
					}
				}
			}
		}
	}

	private static readonly MessageParser<Workspace> _parser = new MessageParser<Workspace>(() => new Workspace());

	private UnknownFieldSet _unknownFields;

	public const int UuidFieldNumber = 1;

	private UUID uuid_;

	public const int MutedFieldNumber = 2;

	private bool muted_;

	public const int HiddenFieldNumber = 3;

	private bool hidden_;

	public const int EditorBackgroundFieldNumber = 4;

	private Types.EditorBackground editorBackground_;

	public const int EffectPresetUuidFieldNumber = 5;

	private UUID effectPresetUuid_;

	public const int EffectBuildDurationFieldNumber = 6;

	private double effectBuildDuration_;

	public const int TransitionFieldNumber = 7;

	private Transition transition_;

	public const int ActiveMaskUuidFieldNumber = 8;

	private UUID activeMaskUuid_;

	public const int PlaylistFieldNumber = 9;

	private Playlist playlist_;

	public const int UnitScalingFieldNumber = 10;

	private Types.UnitScaling unitScaling_;

	public const int EffectsFieldNumber = 16;

	private static readonly FieldCodec<Effect> _repeated_effects_codec = FieldCodec.ForMessage(130u, Effect.Parser);

	private readonly RepeatedField<Effect> effects_ = new RepeatedField<Effect>();

	public const int MasksFieldNumber = 17;

	private static readonly FieldCodec<Mask> _repeated_masks_codec = FieldCodec.ForMessage(138u, Mask.Parser);

	private readonly RepeatedField<Mask> masks_ = new RepeatedField<Mask>();

	public const int ScreensFieldNumber = 18;

	private static readonly FieldCodec<Screen> _repeated_screens_codec = FieldCodec.ForMessage(146u, Screen.Parser);

	private readonly RepeatedField<Screen> screens_ = new RepeatedField<Screen>();

	public const int EdgeBlendsFieldNumber = 19;

	private static readonly FieldCodec<EdgeBlend> _repeated_edgeBlends_codec = FieldCodec.ForMessage(154u, EdgeBlend.Parser);

	private readonly RepeatedField<EdgeBlend> edgeBlends_ = new RepeatedField<EdgeBlend>();

	public const int LayersFieldNumber = 20;

	private static readonly FieldCodec<Layer> _repeated_layers_codec = FieldCodec.ForMessage(162u, Layer.Parser);

	private readonly RepeatedField<Layer> layers_ = new RepeatedField<Layer>();

	public const int TargetSetsFieldNumber = 21;

	private static readonly FieldCodec<TargetSet> _repeated_targetSets_codec = FieldCodec.ForMessage(170u, TargetSet.Parser);

	private readonly RepeatedField<TargetSet> targetSets_ = new RepeatedField<TargetSet>();

	public const int HotKeysFieldNumber = 22;

	private static readonly FieldCodec<HotKey> _repeated_hotKeys_codec = FieldCodec.ForMessage(178u, HotKey.Parser);

	private readonly RepeatedField<HotKey> hotKeys_ = new RepeatedField<HotKey>();

	public const int CalendarFieldNumber = 23;

	private Calendar calendar_;

	public const int AlignmentGuidesFieldNumber = 24;

	private static readonly FieldCodec<AlignmentGuide> _repeated_alignmentGuides_codec = FieldCodec.ForMessage(194u, AlignmentGuide.Parser);

	private readonly RepeatedField<AlignmentGuide> alignmentGuides_ = new RepeatedField<AlignmentGuide>();

	public const int LiveVideoPlaylistFieldNumber = 25;

	private LiveVideoPlaylist liveVideoPlaylist_;

	public const int OutputPreviewDisplayFieldNumber = 26;

	private OutputDisplay outputPreviewDisplay_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<Workspace> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => WorkspaceReflection.Descriptor.MessageTypes[0];

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
	public bool Muted
	{
		get
		{
			return muted_;
		}
		set
		{
			muted_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Hidden
	{
		get
		{
			return hidden_;
		}
		set
		{
			hidden_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.EditorBackground EditorBackground
	{
		get
		{
			return editorBackground_;
		}
		set
		{
			editorBackground_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public UUID EffectPresetUuid
	{
		get
		{
			return effectPresetUuid_;
		}
		set
		{
			effectPresetUuid_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public double EffectBuildDuration
	{
		get
		{
			return effectBuildDuration_;
		}
		set
		{
			effectBuildDuration_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Transition Transition
	{
		get
		{
			return transition_;
		}
		set
		{
			transition_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public UUID ActiveMaskUuid
	{
		get
		{
			return activeMaskUuid_;
		}
		set
		{
			activeMaskUuid_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Playlist Playlist
	{
		get
		{
			return playlist_;
		}
		set
		{
			playlist_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.UnitScaling UnitScaling
	{
		get
		{
			return unitScaling_;
		}
		set
		{
			unitScaling_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<Effect> Effects => effects_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<Mask> Masks => masks_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<Screen> Screens => screens_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<EdgeBlend> EdgeBlends => edgeBlends_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<Layer> Layers => layers_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<TargetSet> TargetSets => targetSets_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<HotKey> HotKeys => hotKeys_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Calendar Calendar
	{
		get
		{
			return calendar_;
		}
		set
		{
			calendar_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<AlignmentGuide> AlignmentGuides => alignmentGuides_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LiveVideoPlaylist LiveVideoPlaylist
	{
		get
		{
			return liveVideoPlaylist_;
		}
		set
		{
			liveVideoPlaylist_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public OutputDisplay OutputPreviewDisplay
	{
		get
		{
			return outputPreviewDisplay_;
		}
		set
		{
			outputPreviewDisplay_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Workspace()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Workspace(Workspace other)
		: this()
	{
		uuid_ = ((other.uuid_ != null) ? other.uuid_.Clone() : null);
		muted_ = other.muted_;
		hidden_ = other.hidden_;
		editorBackground_ = ((other.editorBackground_ != null) ? other.editorBackground_.Clone() : null);
		effectPresetUuid_ = ((other.effectPresetUuid_ != null) ? other.effectPresetUuid_.Clone() : null);
		effectBuildDuration_ = other.effectBuildDuration_;
		transition_ = ((other.transition_ != null) ? other.transition_.Clone() : null);
		activeMaskUuid_ = ((other.activeMaskUuid_ != null) ? other.activeMaskUuid_.Clone() : null);
		playlist_ = ((other.playlist_ != null) ? other.playlist_.Clone() : null);
		unitScaling_ = ((other.unitScaling_ != null) ? other.unitScaling_.Clone() : null);
		effects_ = other.effects_.Clone();
		masks_ = other.masks_.Clone();
		screens_ = other.screens_.Clone();
		edgeBlends_ = other.edgeBlends_.Clone();
		layers_ = other.layers_.Clone();
		targetSets_ = other.targetSets_.Clone();
		hotKeys_ = other.hotKeys_.Clone();
		calendar_ = ((other.calendar_ != null) ? other.calendar_.Clone() : null);
		alignmentGuides_ = other.alignmentGuides_.Clone();
		liveVideoPlaylist_ = ((other.liveVideoPlaylist_ != null) ? other.liveVideoPlaylist_.Clone() : null);
		outputPreviewDisplay_ = ((other.outputPreviewDisplay_ != null) ? other.outputPreviewDisplay_.Clone() : null);
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Workspace Clone()
	{
		return new Workspace(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as Workspace);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(Workspace other)
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
		if (Muted != other.Muted)
		{
			return false;
		}
		if (Hidden != other.Hidden)
		{
			return false;
		}
		if (!object.Equals(EditorBackground, other.EditorBackground))
		{
			return false;
		}
		if (!object.Equals(EffectPresetUuid, other.EffectPresetUuid))
		{
			return false;
		}
		if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(EffectBuildDuration, other.EffectBuildDuration))
		{
			return false;
		}
		if (!object.Equals(Transition, other.Transition))
		{
			return false;
		}
		if (!object.Equals(ActiveMaskUuid, other.ActiveMaskUuid))
		{
			return false;
		}
		if (!object.Equals(Playlist, other.Playlist))
		{
			return false;
		}
		if (!object.Equals(UnitScaling, other.UnitScaling))
		{
			return false;
		}
		if (!effects_.Equals(other.effects_))
		{
			return false;
		}
		if (!masks_.Equals(other.masks_))
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
		if (!layers_.Equals(other.layers_))
		{
			return false;
		}
		if (!targetSets_.Equals(other.targetSets_))
		{
			return false;
		}
		if (!hotKeys_.Equals(other.hotKeys_))
		{
			return false;
		}
		if (!object.Equals(Calendar, other.Calendar))
		{
			return false;
		}
		if (!alignmentGuides_.Equals(other.alignmentGuides_))
		{
			return false;
		}
		if (!object.Equals(LiveVideoPlaylist, other.LiveVideoPlaylist))
		{
			return false;
		}
		if (!object.Equals(OutputPreviewDisplay, other.OutputPreviewDisplay))
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
		if (Muted)
		{
			num ^= Muted.GetHashCode();
		}
		if (Hidden)
		{
			num ^= Hidden.GetHashCode();
		}
		if (editorBackground_ != null)
		{
			num ^= EditorBackground.GetHashCode();
		}
		if (effectPresetUuid_ != null)
		{
			num ^= EffectPresetUuid.GetHashCode();
		}
		if (EffectBuildDuration != 0.0)
		{
			num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(EffectBuildDuration);
		}
		if (transition_ != null)
		{
			num ^= Transition.GetHashCode();
		}
		if (activeMaskUuid_ != null)
		{
			num ^= ActiveMaskUuid.GetHashCode();
		}
		if (playlist_ != null)
		{
			num ^= Playlist.GetHashCode();
		}
		if (unitScaling_ != null)
		{
			num ^= UnitScaling.GetHashCode();
		}
		num ^= effects_.GetHashCode();
		num ^= masks_.GetHashCode();
		num ^= screens_.GetHashCode();
		num ^= edgeBlends_.GetHashCode();
		num ^= layers_.GetHashCode();
		num ^= targetSets_.GetHashCode();
		num ^= hotKeys_.GetHashCode();
		if (calendar_ != null)
		{
			num ^= Calendar.GetHashCode();
		}
		num ^= alignmentGuides_.GetHashCode();
		if (liveVideoPlaylist_ != null)
		{
			num ^= LiveVideoPlaylist.GetHashCode();
		}
		if (outputPreviewDisplay_ != null)
		{
			num ^= OutputPreviewDisplay.GetHashCode();
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
		if (Muted)
		{
			output.WriteRawTag(16);
			output.WriteBool(Muted);
		}
		if (Hidden)
		{
			output.WriteRawTag(24);
			output.WriteBool(Hidden);
		}
		if (editorBackground_ != null)
		{
			output.WriteRawTag(34);
			output.WriteMessage(EditorBackground);
		}
		if (effectPresetUuid_ != null)
		{
			output.WriteRawTag(42);
			output.WriteMessage(EffectPresetUuid);
		}
		if (EffectBuildDuration != 0.0)
		{
			output.WriteRawTag(49);
			output.WriteDouble(EffectBuildDuration);
		}
		if (transition_ != null)
		{
			output.WriteRawTag(58);
			output.WriteMessage(Transition);
		}
		if (activeMaskUuid_ != null)
		{
			output.WriteRawTag(66);
			output.WriteMessage(ActiveMaskUuid);
		}
		if (playlist_ != null)
		{
			output.WriteRawTag(74);
			output.WriteMessage(Playlist);
		}
		if (unitScaling_ != null)
		{
			output.WriteRawTag(82);
			output.WriteMessage(UnitScaling);
		}
		effects_.WriteTo(output, _repeated_effects_codec);
		masks_.WriteTo(output, _repeated_masks_codec);
		screens_.WriteTo(output, _repeated_screens_codec);
		edgeBlends_.WriteTo(output, _repeated_edgeBlends_codec);
		layers_.WriteTo(output, _repeated_layers_codec);
		targetSets_.WriteTo(output, _repeated_targetSets_codec);
		hotKeys_.WriteTo(output, _repeated_hotKeys_codec);
		if (calendar_ != null)
		{
			output.WriteRawTag(186, 1);
			output.WriteMessage(Calendar);
		}
		alignmentGuides_.WriteTo(output, _repeated_alignmentGuides_codec);
		if (liveVideoPlaylist_ != null)
		{
			output.WriteRawTag(202, 1);
			output.WriteMessage(LiveVideoPlaylist);
		}
		if (outputPreviewDisplay_ != null)
		{
			output.WriteRawTag(210, 1);
			output.WriteMessage(OutputPreviewDisplay);
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
		if (Muted)
		{
			num += 2;
		}
		if (Hidden)
		{
			num += 2;
		}
		if (editorBackground_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(EditorBackground);
		}
		if (effectPresetUuid_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(EffectPresetUuid);
		}
		if (EffectBuildDuration != 0.0)
		{
			num += 9;
		}
		if (transition_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Transition);
		}
		if (activeMaskUuid_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(ActiveMaskUuid);
		}
		if (playlist_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Playlist);
		}
		if (unitScaling_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(UnitScaling);
		}
		num += effects_.CalculateSize(_repeated_effects_codec);
		num += masks_.CalculateSize(_repeated_masks_codec);
		num += screens_.CalculateSize(_repeated_screens_codec);
		num += edgeBlends_.CalculateSize(_repeated_edgeBlends_codec);
		num += layers_.CalculateSize(_repeated_layers_codec);
		num += targetSets_.CalculateSize(_repeated_targetSets_codec);
		num += hotKeys_.CalculateSize(_repeated_hotKeys_codec);
		if (calendar_ != null)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(Calendar);
		}
		num += alignmentGuides_.CalculateSize(_repeated_alignmentGuides_codec);
		if (liveVideoPlaylist_ != null)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(LiveVideoPlaylist);
		}
		if (outputPreviewDisplay_ != null)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(OutputPreviewDisplay);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(Workspace other)
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
		if (other.Muted)
		{
			Muted = other.Muted;
		}
		if (other.Hidden)
		{
			Hidden = other.Hidden;
		}
		if (other.editorBackground_ != null)
		{
			if (editorBackground_ == null)
			{
				EditorBackground = new Types.EditorBackground();
			}
			EditorBackground.MergeFrom(other.EditorBackground);
		}
		if (other.effectPresetUuid_ != null)
		{
			if (effectPresetUuid_ == null)
			{
				EffectPresetUuid = new UUID();
			}
			EffectPresetUuid.MergeFrom(other.EffectPresetUuid);
		}
		if (other.EffectBuildDuration != 0.0)
		{
			EffectBuildDuration = other.EffectBuildDuration;
		}
		if (other.transition_ != null)
		{
			if (transition_ == null)
			{
				Transition = new Transition();
			}
			Transition.MergeFrom(other.Transition);
		}
		if (other.activeMaskUuid_ != null)
		{
			if (activeMaskUuid_ == null)
			{
				ActiveMaskUuid = new UUID();
			}
			ActiveMaskUuid.MergeFrom(other.ActiveMaskUuid);
		}
		if (other.playlist_ != null)
		{
			if (playlist_ == null)
			{
				Playlist = new Playlist();
			}
			Playlist.MergeFrom(other.Playlist);
		}
		if (other.unitScaling_ != null)
		{
			if (unitScaling_ == null)
			{
				UnitScaling = new Types.UnitScaling();
			}
			UnitScaling.MergeFrom(other.UnitScaling);
		}
		effects_.Add(other.effects_);
		masks_.Add(other.masks_);
		screens_.Add(other.screens_);
		edgeBlends_.Add(other.edgeBlends_);
		layers_.Add(other.layers_);
		targetSets_.Add(other.targetSets_);
		hotKeys_.Add(other.hotKeys_);
		if (other.calendar_ != null)
		{
			if (calendar_ == null)
			{
				Calendar = new Calendar();
			}
			Calendar.MergeFrom(other.Calendar);
		}
		alignmentGuides_.Add(other.alignmentGuides_);
		if (other.liveVideoPlaylist_ != null)
		{
			if (liveVideoPlaylist_ == null)
			{
				LiveVideoPlaylist = new LiveVideoPlaylist();
			}
			LiveVideoPlaylist.MergeFrom(other.LiveVideoPlaylist);
		}
		if (other.outputPreviewDisplay_ != null)
		{
			if (outputPreviewDisplay_ == null)
			{
				OutputPreviewDisplay = new OutputDisplay();
			}
			OutputPreviewDisplay.MergeFrom(other.OutputPreviewDisplay);
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
				Muted = input.ReadBool();
				break;
			case 24u:
				Hidden = input.ReadBool();
				break;
			case 34u:
				if (editorBackground_ == null)
				{
					EditorBackground = new Types.EditorBackground();
				}
				input.ReadMessage(EditorBackground);
				break;
			case 42u:
				if (effectPresetUuid_ == null)
				{
					EffectPresetUuid = new UUID();
				}
				input.ReadMessage(EffectPresetUuid);
				break;
			case 49u:
				EffectBuildDuration = input.ReadDouble();
				break;
			case 58u:
				if (transition_ == null)
				{
					Transition = new Transition();
				}
				input.ReadMessage(Transition);
				break;
			case 66u:
				if (activeMaskUuid_ == null)
				{
					ActiveMaskUuid = new UUID();
				}
				input.ReadMessage(ActiveMaskUuid);
				break;
			case 74u:
				if (playlist_ == null)
				{
					Playlist = new Playlist();
				}
				input.ReadMessage(Playlist);
				break;
			case 82u:
				if (unitScaling_ == null)
				{
					UnitScaling = new Types.UnitScaling();
				}
				input.ReadMessage(UnitScaling);
				break;
			case 130u:
				effects_.AddEntriesFrom(input, _repeated_effects_codec);
				break;
			case 138u:
				masks_.AddEntriesFrom(input, _repeated_masks_codec);
				break;
			case 146u:
				screens_.AddEntriesFrom(input, _repeated_screens_codec);
				break;
			case 154u:
				edgeBlends_.AddEntriesFrom(input, _repeated_edgeBlends_codec);
				break;
			case 162u:
				layers_.AddEntriesFrom(input, _repeated_layers_codec);
				break;
			case 170u:
				targetSets_.AddEntriesFrom(input, _repeated_targetSets_codec);
				break;
			case 178u:
				hotKeys_.AddEntriesFrom(input, _repeated_hotKeys_codec);
				break;
			case 186u:
				if (calendar_ == null)
				{
					Calendar = new Calendar();
				}
				input.ReadMessage(Calendar);
				break;
			case 194u:
				alignmentGuides_.AddEntriesFrom(input, _repeated_alignmentGuides_codec);
				break;
			case 202u:
				if (liveVideoPlaylist_ == null)
				{
					LiveVideoPlaylist = new LiveVideoPlaylist();
				}
				input.ReadMessage(LiveVideoPlaylist);
				break;
			case 210u:
				if (outputPreviewDisplay_ == null)
				{
					OutputPreviewDisplay = new OutputDisplay();
				}
				input.ReadMessage(OutputPreviewDisplay);
				break;
			}
		}
	}
}
