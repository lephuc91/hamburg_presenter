using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class API_v1_Library_Request : IMessage<API_v1_Library_Request>, IMessage, IEquatable<API_v1_Library_Request>, IDeepCloneable<API_v1_Library_Request>
{
	public enum RequestOneofCase
	{
		None,
		Libraries,
		Library,
		Trigger
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Libraries : IMessage<Libraries>, IMessage, IEquatable<Libraries>, IDeepCloneable<Libraries>
		{
			private static readonly MessageParser<Libraries> _parser = new MessageParser<Libraries>(() => new Libraries());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Libraries> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Library_Request.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Libraries()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Libraries(Libraries other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Libraries Clone()
			{
				return new Libraries(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Libraries);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Libraries other)
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
			public void MergeFrom(Libraries other)
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

			public const int IdFieldNumber = 1;

			private string id_ = "";

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Library> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Library_Request.Descriptor.NestedTypes[1];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string Id
			{
				get
				{
					return id_;
				}
				set
				{
					id_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

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
				id_ = other.id_;
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
				if (Id != other.Id)
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
				if (Id.Length != 0)
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
				if (Id.Length != 0)
				{
					output.WriteRawTag(10);
					output.WriteString(Id);
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
				if (Id.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Id);
				}
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
					if (other.Id.Length != 0)
					{
						Id = other.Id;
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
						Id = input.ReadString();
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Trigger : IMessage<Trigger>, IMessage, IEquatable<Trigger>, IDeepCloneable<Trigger>
		{
			private static readonly MessageParser<Trigger> _parser = new MessageParser<Trigger>(() => new Trigger());

			private UnknownFieldSet _unknownFields;

			public const int LibraryIdFieldNumber = 1;

			private string libraryId_ = "";

			public const int PresentationIdFieldNumber = 2;

			private string presentationId_ = "";

			public const int IndexFieldNumber = 3;

			private uint index_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Trigger> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Library_Request.Descriptor.NestedTypes[2];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string LibraryId
			{
				get
				{
					return libraryId_;
				}
				set
				{
					libraryId_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string PresentationId
			{
				get
				{
					return presentationId_;
				}
				set
				{
					presentationId_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public uint Index
			{
				get
				{
					return index_;
				}
				set
				{
					index_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Trigger()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Trigger(Trigger other)
				: this()
			{
				libraryId_ = other.libraryId_;
				presentationId_ = other.presentationId_;
				index_ = other.index_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Trigger Clone()
			{
				return new Trigger(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Trigger);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Trigger other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (LibraryId != other.LibraryId)
				{
					return false;
				}
				if (PresentationId != other.PresentationId)
				{
					return false;
				}
				if (Index != other.Index)
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
				if (LibraryId.Length != 0)
				{
					num ^= LibraryId.GetHashCode();
				}
				if (PresentationId.Length != 0)
				{
					num ^= PresentationId.GetHashCode();
				}
				if (Index != 0)
				{
					num ^= Index.GetHashCode();
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
				if (LibraryId.Length != 0)
				{
					output.WriteRawTag(10);
					output.WriteString(LibraryId);
				}
				if (PresentationId.Length != 0)
				{
					output.WriteRawTag(18);
					output.WriteString(PresentationId);
				}
				if (Index != 0)
				{
					output.WriteRawTag(24);
					output.WriteUInt32(Index);
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
				if (LibraryId.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(LibraryId);
				}
				if (PresentationId.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(PresentationId);
				}
				if (Index != 0)
				{
					num += 1 + CodedOutputStream.ComputeUInt32Size(Index);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(Trigger other)
			{
				if (other != null)
				{
					if (other.LibraryId.Length != 0)
					{
						LibraryId = other.LibraryId;
					}
					if (other.PresentationId.Length != 0)
					{
						PresentationId = other.PresentationId;
					}
					if (other.Index != 0)
					{
						Index = other.Index;
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
						LibraryId = input.ReadString();
						break;
					case 18u:
						PresentationId = input.ReadString();
						break;
					case 24u:
						Index = input.ReadUInt32();
						break;
					}
				}
			}
		}
	}

	private static readonly MessageParser<API_v1_Library_Request> _parser = new MessageParser<API_v1_Library_Request>(() => new API_v1_Library_Request());

	private UnknownFieldSet _unknownFields;

	public const int LibrariesFieldNumber = 1;

	public const int LibraryFieldNumber = 2;

	public const int TriggerFieldNumber = 3;

	private object request_;

	private RequestOneofCase requestCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<API_v1_Library_Request> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProApiV1LibraryReflection.Descriptor.MessageTypes[0];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Libraries Libraries
	{
		get
		{
			if (requestCase_ != RequestOneofCase.Libraries)
			{
				return null;
			}
			return (Types.Libraries)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.Libraries : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Library Library
	{
		get
		{
			if (requestCase_ != RequestOneofCase.Library)
			{
				return null;
			}
			return (Types.Library)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.Library : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Trigger Trigger
	{
		get
		{
			if (requestCase_ != RequestOneofCase.Trigger)
			{
				return null;
			}
			return (Types.Trigger)request_;
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
	public API_v1_Library_Request()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Library_Request(API_v1_Library_Request other)
		: this()
	{
		switch (other.RequestCase)
		{
		case RequestOneofCase.Libraries:
			Libraries = other.Libraries.Clone();
			break;
		case RequestOneofCase.Library:
			Library = other.Library.Clone();
			break;
		case RequestOneofCase.Trigger:
			Trigger = other.Trigger.Clone();
			break;
		}
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Library_Request Clone()
	{
		return new API_v1_Library_Request(this);
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
		return Equals(other as API_v1_Library_Request);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(API_v1_Library_Request other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(Libraries, other.Libraries))
		{
			return false;
		}
		if (!object.Equals(Library, other.Library))
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
		if (requestCase_ == RequestOneofCase.Libraries)
		{
			num ^= Libraries.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.Library)
		{
			num ^= Library.GetHashCode();
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
		if (requestCase_ == RequestOneofCase.Libraries)
		{
			output.WriteRawTag(10);
			output.WriteMessage(Libraries);
		}
		if (requestCase_ == RequestOneofCase.Library)
		{
			output.WriteRawTag(18);
			output.WriteMessage(Library);
		}
		if (requestCase_ == RequestOneofCase.Trigger)
		{
			output.WriteRawTag(26);
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
		if (requestCase_ == RequestOneofCase.Libraries)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Libraries);
		}
		if (requestCase_ == RequestOneofCase.Library)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Library);
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
	public void MergeFrom(API_v1_Library_Request other)
	{
		if (other == null)
		{
			return;
		}
		switch (other.RequestCase)
		{
		case RequestOneofCase.Libraries:
			if (Libraries == null)
			{
				Libraries = new Types.Libraries();
			}
			Libraries.MergeFrom(other.Libraries);
			break;
		case RequestOneofCase.Library:
			if (Library == null)
			{
				Library = new Types.Library();
			}
			Library.MergeFrom(other.Library);
			break;
		case RequestOneofCase.Trigger:
			if (Trigger == null)
			{
				Trigger = new Types.Trigger();
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
				Types.Libraries libraries = new Types.Libraries();
				if (requestCase_ == RequestOneofCase.Libraries)
				{
					libraries.MergeFrom(Libraries);
				}
				input.ReadMessage(libraries);
				Libraries = libraries;
				break;
			}
			case 18u:
			{
				Types.Library library = new Types.Library();
				if (requestCase_ == RequestOneofCase.Library)
				{
					library.MergeFrom(Library);
				}
				input.ReadMessage(library);
				Library = library;
				break;
			}
			case 26u:
			{
				Types.Trigger trigger = new Types.Trigger();
				if (requestCase_ == RequestOneofCase.Trigger)
				{
					trigger.MergeFrom(Trigger);
				}
				input.ReadMessage(trigger);
				Trigger = trigger;
				break;
			}
			}
		}
	}
}
