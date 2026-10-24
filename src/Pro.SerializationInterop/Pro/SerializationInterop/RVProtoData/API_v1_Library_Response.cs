using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class API_v1_Library_Response : IMessage<API_v1_Library_Response>, IMessage, IEquatable<API_v1_Library_Response>, IDeepCloneable<API_v1_Library_Response>
{
	public enum ResponseOneofCase
	{
		None,
		Libraries,
		Library,
		Triggger
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

			public const int Libraries_FieldNumber = 1;

			private static readonly FieldCodec<API_v1_Identifier> _repeated_libraries_codec = FieldCodec.ForMessage(10u, API_v1_Identifier.Parser);

			private readonly RepeatedField<API_v1_Identifier> libraries_ = new RepeatedField<API_v1_Identifier>();

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Libraries> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Library_Response.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RepeatedField<API_v1_Identifier> Libraries_ => libraries_;

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
				libraries_ = other.libraries_.Clone();
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
				if (!libraries_.Equals(other.libraries_))
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
				num ^= libraries_.GetHashCode();
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
				libraries_.WriteTo(output, _repeated_libraries_codec);
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
				num += libraries_.CalculateSize(_repeated_libraries_codec);
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
					libraries_.Add(other.libraries_);
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
						libraries_.AddEntriesFrom(input, _repeated_libraries_codec);
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Library : IMessage<Library>, IMessage, IEquatable<Library>, IDeepCloneable<Library>
		{
			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				public enum UpdateType
				{
					[OriginalName("all")]
					All,
					[OriginalName("add")]
					Add,
					[OriginalName("remove")]
					Remove
				}
			}

			private static readonly MessageParser<Library> _parser = new MessageParser<Library>(() => new Library());

			private UnknownFieldSet _unknownFields;

			public const int UpdateTypeFieldNumber = 1;

			private Types.UpdateType updateType_;

			public const int ItemsFieldNumber = 2;

			private static readonly FieldCodec<API_v1_Identifier> _repeated_items_codec = FieldCodec.ForMessage(18u, API_v1_Identifier.Parser);

			private readonly RepeatedField<API_v1_Identifier> items_ = new RepeatedField<API_v1_Identifier>();

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Library> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Library_Response.Descriptor.NestedTypes[1];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.UpdateType UpdateType
			{
				get
				{
					return updateType_;
				}
				set
				{
					updateType_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RepeatedField<API_v1_Identifier> Items => items_;

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
				updateType_ = other.updateType_;
				items_ = other.items_.Clone();
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
				if (UpdateType != other.UpdateType)
				{
					return false;
				}
				if (!items_.Equals(other.items_))
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
				if (UpdateType != 0)
				{
					num ^= UpdateType.GetHashCode();
				}
				num ^= items_.GetHashCode();
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
				if (UpdateType != 0)
				{
					output.WriteRawTag(8);
					output.WriteEnum((int)UpdateType);
				}
				items_.WriteTo(output, _repeated_items_codec);
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
				if (UpdateType != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)UpdateType);
				}
				num += items_.CalculateSize(_repeated_items_codec);
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
					if (other.UpdateType != 0)
					{
						UpdateType = other.UpdateType;
					}
					items_.Add(other.items_);
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
						UpdateType = (Types.UpdateType)input.ReadEnum();
						break;
					case 18u:
						items_.AddEntriesFrom(input, _repeated_items_codec);
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Trigger : IMessage<Trigger>, IMessage, IEquatable<Trigger>, IDeepCloneable<Trigger>
		{
			private static readonly MessageParser<Trigger> _parser = new MessageParser<Trigger>(() => new Trigger());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Trigger> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Library_Response.Descriptor.NestedTypes[2];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

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
			public void MergeFrom(Trigger other)
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

	private static readonly MessageParser<API_v1_Library_Response> _parser = new MessageParser<API_v1_Library_Response>(() => new API_v1_Library_Response());

	private UnknownFieldSet _unknownFields;

	public const int LibrariesFieldNumber = 1;

	public const int LibraryFieldNumber = 2;

	public const int TrigggerFieldNumber = 3;

	private object response_;

	private ResponseOneofCase responseCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<API_v1_Library_Response> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProApiV1LibraryReflection.Descriptor.MessageTypes[1];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Libraries Libraries
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.Libraries)
			{
				return null;
			}
			return (Types.Libraries)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.Libraries : ResponseOneofCase.None);
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
	public Types.Trigger Triggger
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.Triggger)
			{
				return null;
			}
			return (Types.Trigger)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.Triggger : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ResponseOneofCase ResponseCase => responseCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Library_Response()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Library_Response(API_v1_Library_Response other)
		: this()
	{
		switch (other.ResponseCase)
		{
		case ResponseOneofCase.Libraries:
			Libraries = other.Libraries.Clone();
			break;
		case ResponseOneofCase.Library:
			Library = other.Library.Clone();
			break;
		case ResponseOneofCase.Triggger:
			Triggger = other.Triggger.Clone();
			break;
		}
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Library_Response Clone()
	{
		return new API_v1_Library_Response(this);
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
		return Equals(other as API_v1_Library_Response);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(API_v1_Library_Response other)
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
		if (!object.Equals(Triggger, other.Triggger))
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
		if (responseCase_ == ResponseOneofCase.Libraries)
		{
			num ^= Libraries.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.Library)
		{
			num ^= Library.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.Triggger)
		{
			num ^= Triggger.GetHashCode();
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
		if (responseCase_ == ResponseOneofCase.Libraries)
		{
			output.WriteRawTag(10);
			output.WriteMessage(Libraries);
		}
		if (responseCase_ == ResponseOneofCase.Library)
		{
			output.WriteRawTag(18);
			output.WriteMessage(Library);
		}
		if (responseCase_ == ResponseOneofCase.Triggger)
		{
			output.WriteRawTag(26);
			output.WriteMessage(Triggger);
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
		if (responseCase_ == ResponseOneofCase.Libraries)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Libraries);
		}
		if (responseCase_ == ResponseOneofCase.Library)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Library);
		}
		if (responseCase_ == ResponseOneofCase.Triggger)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Triggger);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(API_v1_Library_Response other)
	{
		if (other == null)
		{
			return;
		}
		switch (other.ResponseCase)
		{
		case ResponseOneofCase.Libraries:
			if (Libraries == null)
			{
				Libraries = new Types.Libraries();
			}
			Libraries.MergeFrom(other.Libraries);
			break;
		case ResponseOneofCase.Library:
			if (Library == null)
			{
				Library = new Types.Library();
			}
			Library.MergeFrom(other.Library);
			break;
		case ResponseOneofCase.Triggger:
			if (Triggger == null)
			{
				Triggger = new Types.Trigger();
			}
			Triggger.MergeFrom(other.Triggger);
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
				if (responseCase_ == ResponseOneofCase.Libraries)
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
				if (responseCase_ == ResponseOneofCase.Library)
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
				if (responseCase_ == ResponseOneofCase.Triggger)
				{
					trigger.MergeFrom(Triggger);
				}
				input.ReadMessage(trigger);
				Triggger = trigger;
				break;
			}
			}
		}
	}
}
