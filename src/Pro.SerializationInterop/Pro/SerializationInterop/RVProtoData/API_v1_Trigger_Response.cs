using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class API_v1_Trigger_Response : IMessage<API_v1_Trigger_Response>, IMessage, IEquatable<API_v1_Trigger_Response>, IDeepCloneable<API_v1_Trigger_Response>
{
	public enum ResponseOneofCase
	{
		None,
		Cue,
		Playlist,
		Media,
		Audio,
		VideoInput,
		Library,
		Next,
		Previous,
		MediaNext,
		MediaPrevious,
		AudioNext,
		AudioPrevious
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Cue : IMessage<Cue>, IMessage, IEquatable<Cue>, IDeepCloneable<Cue>
		{
			private static readonly MessageParser<Cue> _parser = new MessageParser<Cue>(() => new Cue());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Cue> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Trigger_Response.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Cue()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Cue(Cue other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Cue Clone()
			{
				return new Cue(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Cue);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Cue other)
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
			public void MergeFrom(Cue other)
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
		public sealed class Playlist : IMessage<Playlist>, IMessage, IEquatable<Playlist>, IDeepCloneable<Playlist>
		{
			private static readonly MessageParser<Playlist> _parser = new MessageParser<Playlist>(() => new Playlist());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Playlist> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Trigger_Response.Descriptor.NestedTypes[1];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Playlist()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Playlist(Playlist other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Playlist Clone()
			{
				return new Playlist(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Playlist);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Playlist other)
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
			public void MergeFrom(Playlist other)
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
		public sealed class Media : IMessage<Media>, IMessage, IEquatable<Media>, IDeepCloneable<Media>
		{
			private static readonly MessageParser<Media> _parser = new MessageParser<Media>(() => new Media());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Media> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Trigger_Response.Descriptor.NestedTypes[2];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Media()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Media(Media other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Media Clone()
			{
				return new Media(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Media);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Media other)
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
			public void MergeFrom(Media other)
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
		public sealed class MediaNext : IMessage<MediaNext>, IMessage, IEquatable<MediaNext>, IDeepCloneable<MediaNext>
		{
			private static readonly MessageParser<MediaNext> _parser = new MessageParser<MediaNext>(() => new MediaNext());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<MediaNext> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Trigger_Response.Descriptor.NestedTypes[3];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public MediaNext()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public MediaNext(MediaNext other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public MediaNext Clone()
			{
				return new MediaNext(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as MediaNext);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(MediaNext other)
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
			public void MergeFrom(MediaNext other)
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
		public sealed class MediaPrevious : IMessage<MediaPrevious>, IMessage, IEquatable<MediaPrevious>, IDeepCloneable<MediaPrevious>
		{
			private static readonly MessageParser<MediaPrevious> _parser = new MessageParser<MediaPrevious>(() => new MediaPrevious());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<MediaPrevious> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Trigger_Response.Descriptor.NestedTypes[4];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public MediaPrevious()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public MediaPrevious(MediaPrevious other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public MediaPrevious Clone()
			{
				return new MediaPrevious(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as MediaPrevious);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(MediaPrevious other)
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
			public void MergeFrom(MediaPrevious other)
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
		public sealed class Audio : IMessage<Audio>, IMessage, IEquatable<Audio>, IDeepCloneable<Audio>
		{
			private static readonly MessageParser<Audio> _parser = new MessageParser<Audio>(() => new Audio());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Audio> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Trigger_Response.Descriptor.NestedTypes[5];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Audio()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Audio(Audio other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Audio Clone()
			{
				return new Audio(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Audio);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Audio other)
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
			public void MergeFrom(Audio other)
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
		public sealed class AudioNext : IMessage<AudioNext>, IMessage, IEquatable<AudioNext>, IDeepCloneable<AudioNext>
		{
			private static readonly MessageParser<AudioNext> _parser = new MessageParser<AudioNext>(() => new AudioNext());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<AudioNext> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Trigger_Response.Descriptor.NestedTypes[6];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public AudioNext()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public AudioNext(AudioNext other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public AudioNext Clone()
			{
				return new AudioNext(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as AudioNext);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(AudioNext other)
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
			public void MergeFrom(AudioNext other)
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
		public sealed class AudioPrevious : IMessage<AudioPrevious>, IMessage, IEquatable<AudioPrevious>, IDeepCloneable<AudioPrevious>
		{
			private static readonly MessageParser<AudioPrevious> _parser = new MessageParser<AudioPrevious>(() => new AudioPrevious());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<AudioPrevious> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Trigger_Response.Descriptor.NestedTypes[7];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public AudioPrevious()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public AudioPrevious(AudioPrevious other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public AudioPrevious Clone()
			{
				return new AudioPrevious(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as AudioPrevious);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(AudioPrevious other)
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
			public void MergeFrom(AudioPrevious other)
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
		public sealed class VideoInput : IMessage<VideoInput>, IMessage, IEquatable<VideoInput>, IDeepCloneable<VideoInput>
		{
			private static readonly MessageParser<VideoInput> _parser = new MessageParser<VideoInput>(() => new VideoInput());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<VideoInput> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Trigger_Response.Descriptor.NestedTypes[8];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public VideoInput()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public VideoInput(VideoInput other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public VideoInput Clone()
			{
				return new VideoInput(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as VideoInput);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(VideoInput other)
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
			public void MergeFrom(VideoInput other)
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
		public sealed class Library : IMessage<Library>, IMessage, IEquatable<Library>, IDeepCloneable<Library>
		{
			private static readonly MessageParser<Library> _parser = new MessageParser<Library>(() => new Library());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Library> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Trigger_Response.Descriptor.NestedTypes[9];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Library()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Library(Library other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Library Clone()
			{
				return new Library(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Library);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Library other)
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
			public void MergeFrom(Library other)
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
		public sealed class Next : IMessage<Next>, IMessage, IEquatable<Next>, IDeepCloneable<Next>
		{
			private static readonly MessageParser<Next> _parser = new MessageParser<Next>(() => new Next());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Next> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Trigger_Response.Descriptor.NestedTypes[10];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Next()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Next(Next other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Next Clone()
			{
				return new Next(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Next);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Next other)
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
			public void MergeFrom(Next other)
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
		public sealed class Previous : IMessage<Previous>, IMessage, IEquatable<Previous>, IDeepCloneable<Previous>
		{
			private static readonly MessageParser<Previous> _parser = new MessageParser<Previous>(() => new Previous());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Previous> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Trigger_Response.Descriptor.NestedTypes[11];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Previous()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Previous(Previous other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Previous Clone()
			{
				return new Previous(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Previous);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Previous other)
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
			public void MergeFrom(Previous other)
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

	private static readonly MessageParser<API_v1_Trigger_Response> _parser = new MessageParser<API_v1_Trigger_Response>(() => new API_v1_Trigger_Response());

	private UnknownFieldSet _unknownFields;

	public const int CueFieldNumber = 1;

	public const int PlaylistFieldNumber = 2;

	public const int MediaFieldNumber = 3;

	public const int AudioFieldNumber = 4;

	public const int VideoInputFieldNumber = 5;

	public const int LibraryFieldNumber = 6;

	public const int NextFieldNumber = 7;

	public const int PreviousFieldNumber = 8;

	public const int MediaNextFieldNumber = 9;

	public const int MediaPreviousFieldNumber = 10;

	public const int AudioNextFieldNumber = 11;

	public const int AudioPreviousFieldNumber = 12;

	private object response_;

	private ResponseOneofCase responseCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<API_v1_Trigger_Response> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProApiV1TriggerReflection.Descriptor.MessageTypes[1];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Cue Cue
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.Cue)
			{
				return null;
			}
			return (Types.Cue)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.Cue : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Playlist Playlist
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.Playlist)
			{
				return null;
			}
			return (Types.Playlist)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.Playlist : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Media Media
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.Media)
			{
				return null;
			}
			return (Types.Media)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.Media : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Audio Audio
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.Audio)
			{
				return null;
			}
			return (Types.Audio)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.Audio : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.VideoInput VideoInput
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.VideoInput)
			{
				return null;
			}
			return (Types.VideoInput)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.VideoInput : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Library Library
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.Library)
			{
				return null;
			}
			return (Types.Library)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.Library : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Next Next
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.Next)
			{
				return null;
			}
			return (Types.Next)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.Next : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Previous Previous
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.Previous)
			{
				return null;
			}
			return (Types.Previous)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.Previous : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.MediaNext MediaNext
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.MediaNext)
			{
				return null;
			}
			return (Types.MediaNext)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.MediaNext : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.MediaPrevious MediaPrevious
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.MediaPrevious)
			{
				return null;
			}
			return (Types.MediaPrevious)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.MediaPrevious : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.AudioNext AudioNext
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.AudioNext)
			{
				return null;
			}
			return (Types.AudioNext)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.AudioNext : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.AudioPrevious AudioPrevious
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.AudioPrevious)
			{
				return null;
			}
			return (Types.AudioPrevious)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.AudioPrevious : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ResponseOneofCase ResponseCase => responseCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Trigger_Response()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Trigger_Response(API_v1_Trigger_Response other)
		: this()
	{
		switch (other.ResponseCase)
		{
		case ResponseOneofCase.Cue:
			Cue = other.Cue.Clone();
			break;
		case ResponseOneofCase.Playlist:
			Playlist = other.Playlist.Clone();
			break;
		case ResponseOneofCase.Media:
			Media = other.Media.Clone();
			break;
		case ResponseOneofCase.Audio:
			Audio = other.Audio.Clone();
			break;
		case ResponseOneofCase.VideoInput:
			VideoInput = other.VideoInput.Clone();
			break;
		case ResponseOneofCase.Library:
			Library = other.Library.Clone();
			break;
		case ResponseOneofCase.Next:
			Next = other.Next.Clone();
			break;
		case ResponseOneofCase.Previous:
			Previous = other.Previous.Clone();
			break;
		case ResponseOneofCase.MediaNext:
			MediaNext = other.MediaNext.Clone();
			break;
		case ResponseOneofCase.MediaPrevious:
			MediaPrevious = other.MediaPrevious.Clone();
			break;
		case ResponseOneofCase.AudioNext:
			AudioNext = other.AudioNext.Clone();
			break;
		case ResponseOneofCase.AudioPrevious:
			AudioPrevious = other.AudioPrevious.Clone();
			break;
		}
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Trigger_Response Clone()
	{
		return new API_v1_Trigger_Response(this);
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
		return Equals(other as API_v1_Trigger_Response);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(API_v1_Trigger_Response other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(Cue, other.Cue))
		{
			return false;
		}
		if (!object.Equals(Playlist, other.Playlist))
		{
			return false;
		}
		if (!object.Equals(Media, other.Media))
		{
			return false;
		}
		if (!object.Equals(Audio, other.Audio))
		{
			return false;
		}
		if (!object.Equals(VideoInput, other.VideoInput))
		{
			return false;
		}
		if (!object.Equals(Library, other.Library))
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
		if (!object.Equals(MediaNext, other.MediaNext))
		{
			return false;
		}
		if (!object.Equals(MediaPrevious, other.MediaPrevious))
		{
			return false;
		}
		if (!object.Equals(AudioNext, other.AudioNext))
		{
			return false;
		}
		if (!object.Equals(AudioPrevious, other.AudioPrevious))
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
		if (responseCase_ == ResponseOneofCase.Cue)
		{
			num ^= Cue.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.Playlist)
		{
			num ^= Playlist.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.Media)
		{
			num ^= Media.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.Audio)
		{
			num ^= Audio.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.VideoInput)
		{
			num ^= VideoInput.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.Library)
		{
			num ^= Library.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.Next)
		{
			num ^= Next.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.Previous)
		{
			num ^= Previous.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.MediaNext)
		{
			num ^= MediaNext.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.MediaPrevious)
		{
			num ^= MediaPrevious.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.AudioNext)
		{
			num ^= AudioNext.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.AudioPrevious)
		{
			num ^= AudioPrevious.GetHashCode();
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
		if (responseCase_ == ResponseOneofCase.Cue)
		{
			output.WriteRawTag(10);
			output.WriteMessage(Cue);
		}
		if (responseCase_ == ResponseOneofCase.Playlist)
		{
			output.WriteRawTag(18);
			output.WriteMessage(Playlist);
		}
		if (responseCase_ == ResponseOneofCase.Media)
		{
			output.WriteRawTag(26);
			output.WriteMessage(Media);
		}
		if (responseCase_ == ResponseOneofCase.Audio)
		{
			output.WriteRawTag(34);
			output.WriteMessage(Audio);
		}
		if (responseCase_ == ResponseOneofCase.VideoInput)
		{
			output.WriteRawTag(42);
			output.WriteMessage(VideoInput);
		}
		if (responseCase_ == ResponseOneofCase.Library)
		{
			output.WriteRawTag(50);
			output.WriteMessage(Library);
		}
		if (responseCase_ == ResponseOneofCase.Next)
		{
			output.WriteRawTag(58);
			output.WriteMessage(Next);
		}
		if (responseCase_ == ResponseOneofCase.Previous)
		{
			output.WriteRawTag(66);
			output.WriteMessage(Previous);
		}
		if (responseCase_ == ResponseOneofCase.MediaNext)
		{
			output.WriteRawTag(74);
			output.WriteMessage(MediaNext);
		}
		if (responseCase_ == ResponseOneofCase.MediaPrevious)
		{
			output.WriteRawTag(82);
			output.WriteMessage(MediaPrevious);
		}
		if (responseCase_ == ResponseOneofCase.AudioNext)
		{
			output.WriteRawTag(90);
			output.WriteMessage(AudioNext);
		}
		if (responseCase_ == ResponseOneofCase.AudioPrevious)
		{
			output.WriteRawTag(98);
			output.WriteMessage(AudioPrevious);
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
		if (responseCase_ == ResponseOneofCase.Cue)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Cue);
		}
		if (responseCase_ == ResponseOneofCase.Playlist)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Playlist);
		}
		if (responseCase_ == ResponseOneofCase.Media)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Media);
		}
		if (responseCase_ == ResponseOneofCase.Audio)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Audio);
		}
		if (responseCase_ == ResponseOneofCase.VideoInput)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(VideoInput);
		}
		if (responseCase_ == ResponseOneofCase.Library)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Library);
		}
		if (responseCase_ == ResponseOneofCase.Next)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Next);
		}
		if (responseCase_ == ResponseOneofCase.Previous)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Previous);
		}
		if (responseCase_ == ResponseOneofCase.MediaNext)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(MediaNext);
		}
		if (responseCase_ == ResponseOneofCase.MediaPrevious)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(MediaPrevious);
		}
		if (responseCase_ == ResponseOneofCase.AudioNext)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(AudioNext);
		}
		if (responseCase_ == ResponseOneofCase.AudioPrevious)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(AudioPrevious);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(API_v1_Trigger_Response other)
	{
		if (other == null)
		{
			return;
		}
		switch (other.ResponseCase)
		{
		case ResponseOneofCase.Cue:
			if (Cue == null)
			{
				Cue = new Types.Cue();
			}
			Cue.MergeFrom(other.Cue);
			break;
		case ResponseOneofCase.Playlist:
			if (Playlist == null)
			{
				Playlist = new Types.Playlist();
			}
			Playlist.MergeFrom(other.Playlist);
			break;
		case ResponseOneofCase.Media:
			if (Media == null)
			{
				Media = new Types.Media();
			}
			Media.MergeFrom(other.Media);
			break;
		case ResponseOneofCase.Audio:
			if (Audio == null)
			{
				Audio = new Types.Audio();
			}
			Audio.MergeFrom(other.Audio);
			break;
		case ResponseOneofCase.VideoInput:
			if (VideoInput == null)
			{
				VideoInput = new Types.VideoInput();
			}
			VideoInput.MergeFrom(other.VideoInput);
			break;
		case ResponseOneofCase.Library:
			if (Library == null)
			{
				Library = new Types.Library();
			}
			Library.MergeFrom(other.Library);
			break;
		case ResponseOneofCase.Next:
			if (Next == null)
			{
				Next = new Types.Next();
			}
			Next.MergeFrom(other.Next);
			break;
		case ResponseOneofCase.Previous:
			if (Previous == null)
			{
				Previous = new Types.Previous();
			}
			Previous.MergeFrom(other.Previous);
			break;
		case ResponseOneofCase.MediaNext:
			if (MediaNext == null)
			{
				MediaNext = new Types.MediaNext();
			}
			MediaNext.MergeFrom(other.MediaNext);
			break;
		case ResponseOneofCase.MediaPrevious:
			if (MediaPrevious == null)
			{
				MediaPrevious = new Types.MediaPrevious();
			}
			MediaPrevious.MergeFrom(other.MediaPrevious);
			break;
		case ResponseOneofCase.AudioNext:
			if (AudioNext == null)
			{
				AudioNext = new Types.AudioNext();
			}
			AudioNext.MergeFrom(other.AudioNext);
			break;
		case ResponseOneofCase.AudioPrevious:
			if (AudioPrevious == null)
			{
				AudioPrevious = new Types.AudioPrevious();
			}
			AudioPrevious.MergeFrom(other.AudioPrevious);
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
				Types.Cue cue = new Types.Cue();
				if (responseCase_ == ResponseOneofCase.Cue)
				{
					cue.MergeFrom(Cue);
				}
				input.ReadMessage(cue);
				Cue = cue;
				break;
			}
			case 18u:
			{
				Types.Playlist playlist = new Types.Playlist();
				if (responseCase_ == ResponseOneofCase.Playlist)
				{
					playlist.MergeFrom(Playlist);
				}
				input.ReadMessage(playlist);
				Playlist = playlist;
				break;
			}
			case 26u:
			{
				Types.Media media = new Types.Media();
				if (responseCase_ == ResponseOneofCase.Media)
				{
					media.MergeFrom(Media);
				}
				input.ReadMessage(media);
				Media = media;
				break;
			}
			case 34u:
			{
				Types.Audio audio = new Types.Audio();
				if (responseCase_ == ResponseOneofCase.Audio)
				{
					audio.MergeFrom(Audio);
				}
				input.ReadMessage(audio);
				Audio = audio;
				break;
			}
			case 42u:
			{
				Types.VideoInput videoInput = new Types.VideoInput();
				if (responseCase_ == ResponseOneofCase.VideoInput)
				{
					videoInput.MergeFrom(VideoInput);
				}
				input.ReadMessage(videoInput);
				VideoInput = videoInput;
				break;
			}
			case 50u:
			{
				Types.Library library = new Types.Library();
				if (responseCase_ == ResponseOneofCase.Library)
				{
					library.MergeFrom(Library);
				}
				input.ReadMessage(library);
				Library = library;
				break;
			}
			case 58u:
			{
				Types.Next next = new Types.Next();
				if (responseCase_ == ResponseOneofCase.Next)
				{
					next.MergeFrom(Next);
				}
				input.ReadMessage(next);
				Next = next;
				break;
			}
			case 66u:
			{
				Types.Previous previous = new Types.Previous();
				if (responseCase_ == ResponseOneofCase.Previous)
				{
					previous.MergeFrom(Previous);
				}
				input.ReadMessage(previous);
				Previous = previous;
				break;
			}
			case 74u:
			{
				Types.MediaNext mediaNext = new Types.MediaNext();
				if (responseCase_ == ResponseOneofCase.MediaNext)
				{
					mediaNext.MergeFrom(MediaNext);
				}
				input.ReadMessage(mediaNext);
				MediaNext = mediaNext;
				break;
			}
			case 82u:
			{
				Types.MediaPrevious mediaPrevious = new Types.MediaPrevious();
				if (responseCase_ == ResponseOneofCase.MediaPrevious)
				{
					mediaPrevious.MergeFrom(MediaPrevious);
				}
				input.ReadMessage(mediaPrevious);
				MediaPrevious = mediaPrevious;
				break;
			}
			case 90u:
			{
				Types.AudioNext audioNext = new Types.AudioNext();
				if (responseCase_ == ResponseOneofCase.AudioNext)
				{
					audioNext.MergeFrom(AudioNext);
				}
				input.ReadMessage(audioNext);
				AudioNext = audioNext;
				break;
			}
			case 98u:
			{
				Types.AudioPrevious audioPrevious = new Types.AudioPrevious();
				if (responseCase_ == ResponseOneofCase.AudioPrevious)
				{
					audioPrevious.MergeFrom(AudioPrevious);
				}
				input.ReadMessage(audioPrevious);
				AudioPrevious = audioPrevious;
				break;
			}
			}
		}
	}
}
