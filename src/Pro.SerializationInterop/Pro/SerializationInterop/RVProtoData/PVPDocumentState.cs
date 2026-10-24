using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class PVPDocumentState : IMessage<PVPDocumentState>, IMessage, IEquatable<PVPDocumentState>, IDeepCloneable<PVPDocumentState>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class PlaylistState : IMessage<PlaylistState>, IMessage, IEquatable<PlaylistState>, IDeepCloneable<PlaylistState>
		{
			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				public enum LayoutType
				{
					[OriginalName("LAYOUT_TYPE_CUE")]
					Cue,
					[OriginalName("LAYOUT_TYPE_ACTION")]
					Action,
					[OriginalName("LAYOUT_TYPE_LIVE_VIDEO")]
					LiveVideo
				}
			}

			private static readonly MessageParser<PlaylistState> _parser = new MessageParser<PlaylistState>(() => new PlaylistState());

			private UnknownFieldSet _unknownFields;

			public const int UuidFieldNumber = 2;

			private UUID uuid_;

			public const int LayoutFieldNumber = 3;

			private Types.LayoutType layout_;

			public const int ItemScaleFieldNumber = 4;

			private double itemScale_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<PlaylistState> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => PVPDocumentState.Descriptor.NestedTypes[0];

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
			public Types.LayoutType Layout
			{
				get
				{
					return layout_;
				}
				set
				{
					layout_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public double ItemScale
			{
				get
				{
					return itemScale_;
				}
				set
				{
					itemScale_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PlaylistState()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PlaylistState(PlaylistState other)
				: this()
			{
				uuid_ = ((other.uuid_ != null) ? other.uuid_.Clone() : null);
				layout_ = other.layout_;
				itemScale_ = other.itemScale_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PlaylistState Clone()
			{
				return new PlaylistState(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as PlaylistState);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(PlaylistState other)
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
				if (Layout != other.Layout)
				{
					return false;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(ItemScale, other.ItemScale))
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
				if (Layout != 0)
				{
					num ^= Layout.GetHashCode();
				}
				if (ItemScale != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(ItemScale);
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
					output.WriteRawTag(18);
					output.WriteMessage(Uuid);
				}
				if (Layout != 0)
				{
					output.WriteRawTag(24);
					output.WriteEnum((int)Layout);
				}
				if (ItemScale != 0.0)
				{
					output.WriteRawTag(33);
					output.WriteDouble(ItemScale);
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
				if (Layout != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)Layout);
				}
				if (ItemScale != 0.0)
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
			public void MergeFrom(PlaylistState other)
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
				if (other.Layout != 0)
				{
					Layout = other.Layout;
				}
				if (other.ItemScale != 0.0)
				{
					ItemScale = other.ItemScale;
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
					case 18u:
						if (uuid_ == null)
						{
							Uuid = new UUID();
						}
						input.ReadMessage(Uuid);
						break;
					case 24u:
						Layout = (Types.LayoutType)input.ReadEnum();
						break;
					case 33u:
						ItemScale = input.ReadDouble();
						break;
					}
				}
			}
		}
	}

	private static readonly MessageParser<PVPDocumentState> _parser = new MessageParser<PVPDocumentState>(() => new PVPDocumentState());

	private UnknownFieldSet _unknownFields;

	public const int PrimaryPlaylistFieldNumber = 1;

	private Types.PlaylistState primaryPlaylist_;

	public const int AlternatePlaylistFieldNumber = 2;

	private Types.PlaylistState alternatePlaylist_;

	public const int PlaylistSplitIsVerticalFieldNumber = 3;

	private bool playlistSplitIsVertical_;

	public const int TargetedLayerFieldNumber = 4;

	private UUID targetedLayer_;

	public const int SelectedLayerFieldNumber = 5;

	private UUID selectedLayer_;

	public const int LockedLayerFieldNumber = 6;

	private UUID lockedLayer_;

	public const int LiveVideoPlaylistScaleFieldNumber = 7;

	private double liveVideoPlaylistScale_;

	public const int SplitViewDividerPositionFieldNumber = 8;

	private double splitViewDividerPosition_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<PVPDocumentState> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => BaseDocumentReflection.Descriptor.MessageTypes[2];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.PlaylistState PrimaryPlaylist
	{
		get
		{
			return primaryPlaylist_;
		}
		set
		{
			primaryPlaylist_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.PlaylistState AlternatePlaylist
	{
		get
		{
			return alternatePlaylist_;
		}
		set
		{
			alternatePlaylist_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool PlaylistSplitIsVertical
	{
		get
		{
			return playlistSplitIsVertical_;
		}
		set
		{
			playlistSplitIsVertical_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public UUID TargetedLayer
	{
		get
		{
			return targetedLayer_;
		}
		set
		{
			targetedLayer_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public UUID SelectedLayer
	{
		get
		{
			return selectedLayer_;
		}
		set
		{
			selectedLayer_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public UUID LockedLayer
	{
		get
		{
			return lockedLayer_;
		}
		set
		{
			lockedLayer_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public double LiveVideoPlaylistScale
	{
		get
		{
			return liveVideoPlaylistScale_;
		}
		set
		{
			liveVideoPlaylistScale_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public double SplitViewDividerPosition
	{
		get
		{
			return splitViewDividerPosition_;
		}
		set
		{
			splitViewDividerPosition_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public PVPDocumentState()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public PVPDocumentState(PVPDocumentState other)
		: this()
	{
		primaryPlaylist_ = ((other.primaryPlaylist_ != null) ? other.primaryPlaylist_.Clone() : null);
		alternatePlaylist_ = ((other.alternatePlaylist_ != null) ? other.alternatePlaylist_.Clone() : null);
		playlistSplitIsVertical_ = other.playlistSplitIsVertical_;
		targetedLayer_ = ((other.targetedLayer_ != null) ? other.targetedLayer_.Clone() : null);
		selectedLayer_ = ((other.selectedLayer_ != null) ? other.selectedLayer_.Clone() : null);
		lockedLayer_ = ((other.lockedLayer_ != null) ? other.lockedLayer_.Clone() : null);
		liveVideoPlaylistScale_ = other.liveVideoPlaylistScale_;
		splitViewDividerPosition_ = other.splitViewDividerPosition_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public PVPDocumentState Clone()
	{
		return new PVPDocumentState(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as PVPDocumentState);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(PVPDocumentState other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(PrimaryPlaylist, other.PrimaryPlaylist))
		{
			return false;
		}
		if (!object.Equals(AlternatePlaylist, other.AlternatePlaylist))
		{
			return false;
		}
		if (PlaylistSplitIsVertical != other.PlaylistSplitIsVertical)
		{
			return false;
		}
		if (!object.Equals(TargetedLayer, other.TargetedLayer))
		{
			return false;
		}
		if (!object.Equals(SelectedLayer, other.SelectedLayer))
		{
			return false;
		}
		if (!object.Equals(LockedLayer, other.LockedLayer))
		{
			return false;
		}
		if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(LiveVideoPlaylistScale, other.LiveVideoPlaylistScale))
		{
			return false;
		}
		if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(SplitViewDividerPosition, other.SplitViewDividerPosition))
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
		if (primaryPlaylist_ != null)
		{
			num ^= PrimaryPlaylist.GetHashCode();
		}
		if (alternatePlaylist_ != null)
		{
			num ^= AlternatePlaylist.GetHashCode();
		}
		if (PlaylistSplitIsVertical)
		{
			num ^= PlaylistSplitIsVertical.GetHashCode();
		}
		if (targetedLayer_ != null)
		{
			num ^= TargetedLayer.GetHashCode();
		}
		if (selectedLayer_ != null)
		{
			num ^= SelectedLayer.GetHashCode();
		}
		if (lockedLayer_ != null)
		{
			num ^= LockedLayer.GetHashCode();
		}
		if (LiveVideoPlaylistScale != 0.0)
		{
			num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(LiveVideoPlaylistScale);
		}
		if (SplitViewDividerPosition != 0.0)
		{
			num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(SplitViewDividerPosition);
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
		if (primaryPlaylist_ != null)
		{
			output.WriteRawTag(10);
			output.WriteMessage(PrimaryPlaylist);
		}
		if (alternatePlaylist_ != null)
		{
			output.WriteRawTag(18);
			output.WriteMessage(AlternatePlaylist);
		}
		if (PlaylistSplitIsVertical)
		{
			output.WriteRawTag(24);
			output.WriteBool(PlaylistSplitIsVertical);
		}
		if (targetedLayer_ != null)
		{
			output.WriteRawTag(34);
			output.WriteMessage(TargetedLayer);
		}
		if (selectedLayer_ != null)
		{
			output.WriteRawTag(42);
			output.WriteMessage(SelectedLayer);
		}
		if (lockedLayer_ != null)
		{
			output.WriteRawTag(50);
			output.WriteMessage(LockedLayer);
		}
		if (LiveVideoPlaylistScale != 0.0)
		{
			output.WriteRawTag(57);
			output.WriteDouble(LiveVideoPlaylistScale);
		}
		if (SplitViewDividerPosition != 0.0)
		{
			output.WriteRawTag(65);
			output.WriteDouble(SplitViewDividerPosition);
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
		if (primaryPlaylist_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PrimaryPlaylist);
		}
		if (alternatePlaylist_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(AlternatePlaylist);
		}
		if (PlaylistSplitIsVertical)
		{
			num += 2;
		}
		if (targetedLayer_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(TargetedLayer);
		}
		if (selectedLayer_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(SelectedLayer);
		}
		if (lockedLayer_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(LockedLayer);
		}
		if (LiveVideoPlaylistScale != 0.0)
		{
			num += 9;
		}
		if (SplitViewDividerPosition != 0.0)
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
	public void MergeFrom(PVPDocumentState other)
	{
		if (other == null)
		{
			return;
		}
		if (other.primaryPlaylist_ != null)
		{
			if (primaryPlaylist_ == null)
			{
				PrimaryPlaylist = new Types.PlaylistState();
			}
			PrimaryPlaylist.MergeFrom(other.PrimaryPlaylist);
		}
		if (other.alternatePlaylist_ != null)
		{
			if (alternatePlaylist_ == null)
			{
				AlternatePlaylist = new Types.PlaylistState();
			}
			AlternatePlaylist.MergeFrom(other.AlternatePlaylist);
		}
		if (other.PlaylistSplitIsVertical)
		{
			PlaylistSplitIsVertical = other.PlaylistSplitIsVertical;
		}
		if (other.targetedLayer_ != null)
		{
			if (targetedLayer_ == null)
			{
				TargetedLayer = new UUID();
			}
			TargetedLayer.MergeFrom(other.TargetedLayer);
		}
		if (other.selectedLayer_ != null)
		{
			if (selectedLayer_ == null)
			{
				SelectedLayer = new UUID();
			}
			SelectedLayer.MergeFrom(other.SelectedLayer);
		}
		if (other.lockedLayer_ != null)
		{
			if (lockedLayer_ == null)
			{
				LockedLayer = new UUID();
			}
			LockedLayer.MergeFrom(other.LockedLayer);
		}
		if (other.LiveVideoPlaylistScale != 0.0)
		{
			LiveVideoPlaylistScale = other.LiveVideoPlaylistScale;
		}
		if (other.SplitViewDividerPosition != 0.0)
		{
			SplitViewDividerPosition = other.SplitViewDividerPosition;
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
				if (primaryPlaylist_ == null)
				{
					PrimaryPlaylist = new Types.PlaylistState();
				}
				input.ReadMessage(PrimaryPlaylist);
				break;
			case 18u:
				if (alternatePlaylist_ == null)
				{
					AlternatePlaylist = new Types.PlaylistState();
				}
				input.ReadMessage(AlternatePlaylist);
				break;
			case 24u:
				PlaylistSplitIsVertical = input.ReadBool();
				break;
			case 34u:
				if (targetedLayer_ == null)
				{
					TargetedLayer = new UUID();
				}
				input.ReadMessage(TargetedLayer);
				break;
			case 42u:
				if (selectedLayer_ == null)
				{
					SelectedLayer = new UUID();
				}
				input.ReadMessage(SelectedLayer);
				break;
			case 50u:
				if (lockedLayer_ == null)
				{
					LockedLayer = new UUID();
				}
				input.ReadMessage(LockedLayer);
				break;
			case 57u:
				LiveVideoPlaylistScale = input.ReadDouble();
				break;
			case 65u:
				SplitViewDividerPosition = input.ReadDouble();
				break;
			}
		}
	}
}
