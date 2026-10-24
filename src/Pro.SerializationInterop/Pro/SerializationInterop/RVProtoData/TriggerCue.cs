using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class TriggerCue : IMessage<TriggerCue>, IMessage, IEquatable<TriggerCue>, IDeepCloneable<TriggerCue>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class PresentationCue : IMessage<PresentationCue>, IMessage, IEquatable<PresentationCue>, IDeepCloneable<PresentationCue>
		{
			private static readonly MessageParser<PresentationCue> _parser = new MessageParser<PresentationCue>(() => new PresentationCue());

			private UnknownFieldSet _unknownFields;

			public const int PresentationFieldNumber = 1;

			private Presentation presentation_;

			public const int ArrangementIdFieldNumber = 2;

			private UUID arrangementId_;

			public const int CueIndexFieldNumber = 3;

			private int cueIndex_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<PresentationCue> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => TriggerCue.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Presentation Presentation
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
			public UUID ArrangementId
			{
				get
				{
					return arrangementId_;
				}
				set
				{
					arrangementId_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public int CueIndex
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
			public PresentationCue()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PresentationCue(PresentationCue other)
				: this()
			{
				presentation_ = ((other.presentation_ != null) ? other.presentation_.Clone() : null);
				arrangementId_ = ((other.arrangementId_ != null) ? other.arrangementId_.Clone() : null);
				cueIndex_ = other.cueIndex_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PresentationCue Clone()
			{
				return new PresentationCue(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as PresentationCue);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(PresentationCue other)
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
				if (!object.Equals(ArrangementId, other.ArrangementId))
				{
					return false;
				}
				if (CueIndex != other.CueIndex)
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
				if (arrangementId_ != null)
				{
					num ^= ArrangementId.GetHashCode();
				}
				if (CueIndex != 0)
				{
					num ^= CueIndex.GetHashCode();
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
				if (arrangementId_ != null)
				{
					output.WriteRawTag(18);
					output.WriteMessage(ArrangementId);
				}
				if (CueIndex != 0)
				{
					output.WriteRawTag(24);
					output.WriteInt32(CueIndex);
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
				if (arrangementId_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(ArrangementId);
				}
				if (CueIndex != 0)
				{
					num += 1 + CodedOutputStream.ComputeInt32Size(CueIndex);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(PresentationCue other)
			{
				if (other == null)
				{
					return;
				}
				if (other.presentation_ != null)
				{
					if (presentation_ == null)
					{
						Presentation = new Presentation();
					}
					Presentation.MergeFrom(other.Presentation);
				}
				if (other.arrangementId_ != null)
				{
					if (arrangementId_ == null)
					{
						ArrangementId = new UUID();
					}
					ArrangementId.MergeFrom(other.ArrangementId);
				}
				if (other.CueIndex != 0)
				{
					CueIndex = other.CueIndex;
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
						if (presentation_ == null)
						{
							Presentation = new Presentation();
						}
						input.ReadMessage(Presentation);
						break;
					case 18u:
						if (arrangementId_ == null)
						{
							ArrangementId = new UUID();
						}
						input.ReadMessage(ArrangementId);
						break;
					case 24u:
						CueIndex = input.ReadInt32();
						break;
					}
				}
			}
		}
	}

	private static readonly MessageParser<TriggerCue> _parser = new MessageParser<TriggerCue>(() => new TriggerCue());

	private UnknownFieldSet _unknownFields;

	public const int TriggerHandleFieldNumber = 1;

	private ulong triggerHandle_;

	public const int TriggerOptionsFieldNumber = 2;

	private TriggerOptions triggerOptions_;

	public const int CueFieldNumber = 3;

	private Cue cue_;

	public const int PresentationFieldNumber = 4;

	private Types.PresentationCue presentation_;

	public const int PlaylistFieldNumber = 5;

	private Playlist playlist_;

	public const int ClientDataFieldNumber = 6;

	private ulong clientData_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<TriggerCue> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProCoreReflection.Descriptor.MessageTypes[7];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ulong TriggerHandle
	{
		get
		{
			return triggerHandle_;
		}
		set
		{
			triggerHandle_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TriggerOptions TriggerOptions
	{
		get
		{
			return triggerOptions_;
		}
		set
		{
			triggerOptions_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Cue Cue
	{
		get
		{
			return cue_;
		}
		set
		{
			cue_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.PresentationCue Presentation
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
	public ulong ClientData
	{
		get
		{
			return clientData_;
		}
		set
		{
			clientData_ = value;
		}
	}

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
		triggerHandle_ = other.triggerHandle_;
		triggerOptions_ = ((other.triggerOptions_ != null) ? other.triggerOptions_.Clone() : null);
		cue_ = ((other.cue_ != null) ? other.cue_.Clone() : null);
		presentation_ = ((other.presentation_ != null) ? other.presentation_.Clone() : null);
		playlist_ = ((other.playlist_ != null) ? other.playlist_.Clone() : null);
		clientData_ = other.clientData_;
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
		if (TriggerHandle != other.TriggerHandle)
		{
			return false;
		}
		if (!object.Equals(TriggerOptions, other.TriggerOptions))
		{
			return false;
		}
		if (!object.Equals(Cue, other.Cue))
		{
			return false;
		}
		if (!object.Equals(Presentation, other.Presentation))
		{
			return false;
		}
		if (!object.Equals(Playlist, other.Playlist))
		{
			return false;
		}
		if (ClientData != other.ClientData)
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
		if (TriggerHandle != 0L)
		{
			num ^= TriggerHandle.GetHashCode();
		}
		if (triggerOptions_ != null)
		{
			num ^= TriggerOptions.GetHashCode();
		}
		if (cue_ != null)
		{
			num ^= Cue.GetHashCode();
		}
		if (presentation_ != null)
		{
			num ^= Presentation.GetHashCode();
		}
		if (playlist_ != null)
		{
			num ^= Playlist.GetHashCode();
		}
		if (ClientData != 0L)
		{
			num ^= ClientData.GetHashCode();
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
		if (TriggerHandle != 0L)
		{
			output.WriteRawTag(8);
			output.WriteUInt64(TriggerHandle);
		}
		if (triggerOptions_ != null)
		{
			output.WriteRawTag(18);
			output.WriteMessage(TriggerOptions);
		}
		if (cue_ != null)
		{
			output.WriteRawTag(26);
			output.WriteMessage(Cue);
		}
		if (presentation_ != null)
		{
			output.WriteRawTag(34);
			output.WriteMessage(Presentation);
		}
		if (playlist_ != null)
		{
			output.WriteRawTag(42);
			output.WriteMessage(Playlist);
		}
		if (ClientData != 0L)
		{
			output.WriteRawTag(48);
			output.WriteUInt64(ClientData);
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
		if (TriggerHandle != 0L)
		{
			num += 1 + CodedOutputStream.ComputeUInt64Size(TriggerHandle);
		}
		if (triggerOptions_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(TriggerOptions);
		}
		if (cue_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Cue);
		}
		if (presentation_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Presentation);
		}
		if (playlist_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Playlist);
		}
		if (ClientData != 0L)
		{
			num += 1 + CodedOutputStream.ComputeUInt64Size(ClientData);
		}
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
		if (other == null)
		{
			return;
		}
		if (other.TriggerHandle != 0L)
		{
			TriggerHandle = other.TriggerHandle;
		}
		if (other.triggerOptions_ != null)
		{
			if (triggerOptions_ == null)
			{
				TriggerOptions = new TriggerOptions();
			}
			TriggerOptions.MergeFrom(other.TriggerOptions);
		}
		if (other.cue_ != null)
		{
			if (cue_ == null)
			{
				Cue = new Cue();
			}
			Cue.MergeFrom(other.Cue);
		}
		if (other.presentation_ != null)
		{
			if (presentation_ == null)
			{
				Presentation = new Types.PresentationCue();
			}
			Presentation.MergeFrom(other.Presentation);
		}
		if (other.playlist_ != null)
		{
			if (playlist_ == null)
			{
				Playlist = new Playlist();
			}
			Playlist.MergeFrom(other.Playlist);
		}
		if (other.ClientData != 0L)
		{
			ClientData = other.ClientData;
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
				TriggerHandle = input.ReadUInt64();
				break;
			case 18u:
				if (triggerOptions_ == null)
				{
					TriggerOptions = new TriggerOptions();
				}
				input.ReadMessage(TriggerOptions);
				break;
			case 26u:
				if (cue_ == null)
				{
					Cue = new Cue();
				}
				input.ReadMessage(Cue);
				break;
			case 34u:
				if (presentation_ == null)
				{
					Presentation = new Types.PresentationCue();
				}
				input.ReadMessage(Presentation);
				break;
			case 42u:
				if (playlist_ == null)
				{
					Playlist = new Playlist();
				}
				input.ReadMessage(Playlist);
				break;
			case 48u:
				ClientData = input.ReadUInt64();
				break;
			}
		}
	}
}
