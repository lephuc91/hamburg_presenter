using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class MusicKeyScale : IMessage<MusicKeyScale>, IMessage, IEquatable<MusicKeyScale>, IDeepCloneable<MusicKeyScale>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		public enum MusicKey
		{
			[OriginalName("MUSIC_KEY_A_FLAT")]
			AFlat,
			[OriginalName("MUSIC_KEY_A")]
			A,
			[OriginalName("MUSIC_KEY_A_SHARP")]
			ASharp,
			[OriginalName("MUSIC_KEY_B_FLAT")]
			BFlat,
			[OriginalName("MUSIC_KEY_B")]
			B,
			[OriginalName("MUSIC_KEY_B_SHARP")]
			BSharp,
			[OriginalName("MUSIC_KEY_C_FLAT")]
			CFlat,
			[OriginalName("MUSIC_KEY_C")]
			C,
			[OriginalName("MUSIC_KEY_C_SHARP")]
			CSharp,
			[OriginalName("MUSIC_KEY_D_FLAT")]
			DFlat,
			[OriginalName("MUSIC_KEY_D")]
			D,
			[OriginalName("MUSIC_KEY_D_SHARP")]
			DSharp,
			[OriginalName("MUSIC_KEY_E_FLAT")]
			EFlat,
			[OriginalName("MUSIC_KEY_E")]
			E,
			[OriginalName("MUSIC_KEY_E_SHARP")]
			ESharp,
			[OriginalName("MUSIC_KEY_F_FLAT")]
			FFlat,
			[OriginalName("MUSIC_KEY_F")]
			F,
			[OriginalName("MUSIC_KEY_F_SHARP")]
			FSharp,
			[OriginalName("MUSIC_KEY_G_FLAT")]
			GFlat,
			[OriginalName("MUSIC_KEY_G")]
			G,
			[OriginalName("MUSIC_KEY_G_SHARP")]
			GSharp
		}

		public enum MusicScale
		{
			[OriginalName("MUSIC_SCALE_MAJOR")]
			Major,
			[OriginalName("MUSIC_SCALE_MINOR")]
			Minor
		}
	}

	private static readonly MessageParser<MusicKeyScale> _parser = new MessageParser<MusicKeyScale>(() => new MusicKeyScale());

	private UnknownFieldSet _unknownFields;

	public const int MusicKeyFieldNumber = 1;

	private Types.MusicKey musicKey_;

	public const int MusicScaleFieldNumber = 2;

	private Types.MusicScale musicScale_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<MusicKeyScale> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => MusicKeyScaleReflection.Descriptor.MessageTypes[0];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.MusicKey MusicKey
	{
		get
		{
			return musicKey_;
		}
		set
		{
			musicKey_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.MusicScale MusicScale
	{
		get
		{
			return musicScale_;
		}
		set
		{
			musicScale_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public MusicKeyScale()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public MusicKeyScale(MusicKeyScale other)
		: this()
	{
		musicKey_ = other.musicKey_;
		musicScale_ = other.musicScale_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public MusicKeyScale Clone()
	{
		return new MusicKeyScale(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as MusicKeyScale);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(MusicKeyScale other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (MusicKey != other.MusicKey)
		{
			return false;
		}
		if (MusicScale != other.MusicScale)
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
		if (MusicKey != 0)
		{
			num ^= MusicKey.GetHashCode();
		}
		if (MusicScale != 0)
		{
			num ^= MusicScale.GetHashCode();
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
		if (MusicKey != 0)
		{
			output.WriteRawTag(8);
			output.WriteEnum((int)MusicKey);
		}
		if (MusicScale != 0)
		{
			output.WriteRawTag(16);
			output.WriteEnum((int)MusicScale);
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
		if (MusicKey != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)MusicKey);
		}
		if (MusicScale != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)MusicScale);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(MusicKeyScale other)
	{
		if (other != null)
		{
			if (other.MusicKey != 0)
			{
				MusicKey = other.MusicKey;
			}
			if (other.MusicScale != 0)
			{
				MusicScale = other.MusicScale;
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
				MusicKey = (Types.MusicKey)input.ReadEnum();
				break;
			case 16u:
				MusicScale = (Types.MusicScale)input.ReadEnum();
				break;
			}
		}
	}
}
