using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.MediaManagement.v2;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class UpdateSmartPlaylists : IMessage<UpdateSmartPlaylists>, IMessage, IEquatable<UpdateSmartPlaylists>, IDeepCloneable<UpdateSmartPlaylists>
{
	private static readonly MessageParser<UpdateSmartPlaylists> _parser = new MessageParser<UpdateSmartPlaylists>(() => new UpdateSmartPlaylists());

	private UnknownFieldSet _unknownFields;

	public const int PlaylistsFieldNumber = 1;

	private static readonly FieldCodec<SmartPlaylist> _repeated_playlists_codec = FieldCodec.ForMessage(10u, SmartPlaylist.Parser);

	private readonly RepeatedField<SmartPlaylist> playlists_ = new RepeatedField<SmartPlaylist>();

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<UpdateSmartPlaylists> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => V2HelperCommonReflection.Descriptor.MessageTypes[25];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<SmartPlaylist> Playlists => playlists_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public UpdateSmartPlaylists()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public UpdateSmartPlaylists(UpdateSmartPlaylists other)
		: this()
	{
		playlists_ = other.playlists_.Clone();
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public UpdateSmartPlaylists Clone()
	{
		return new UpdateSmartPlaylists(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as UpdateSmartPlaylists);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(UpdateSmartPlaylists other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!playlists_.Equals(other.playlists_))
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
		num ^= playlists_.GetHashCode();
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
		playlists_.WriteTo(output, _repeated_playlists_codec);
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
		num += playlists_.CalculateSize(_repeated_playlists_codec);
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(UpdateSmartPlaylists other)
	{
		if (other != null)
		{
			playlists_.Add(other.playlists_);
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
				playlists_.AddEntriesFrom(input, _repeated_playlists_codec);
			}
		}
	}
}
