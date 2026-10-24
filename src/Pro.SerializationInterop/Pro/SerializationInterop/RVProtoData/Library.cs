using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class Library : IMessage<Library>, IMessage, IEquatable<Library>, IDeepCloneable<Library>
{
	public enum ChildTypeOneofCase
	{
		None = 0,
		LibraryChildren = 2,
		LibraryItems = 3
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class LibraryArray : IMessage<LibraryArray>, IMessage, IEquatable<LibraryArray>, IDeepCloneable<LibraryArray>
		{
			private static readonly MessageParser<LibraryArray> _parser = new MessageParser<LibraryArray>(() => new LibraryArray());

			private UnknownFieldSet _unknownFields;

			public const int LibrariesFieldNumber = 1;

			private static readonly FieldCodec<Library> _repeated_libraries_codec = FieldCodec.ForMessage(10u, Library.Parser);

			private readonly RepeatedField<Library> libraries_ = new RepeatedField<Library>();

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<LibraryArray> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Library.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RepeatedField<Library> Libraries => libraries_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public LibraryArray()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public LibraryArray(LibraryArray other)
				: this()
			{
				libraries_ = other.libraries_.Clone();
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public LibraryArray Clone()
			{
				return new LibraryArray(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as LibraryArray);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(LibraryArray other)
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
			public void MergeFrom(LibraryArray other)
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
		public sealed class LibraryItems : IMessage<LibraryItems>, IMessage, IEquatable<LibraryItems>, IDeepCloneable<LibraryItems>
		{
			private static readonly MessageParser<LibraryItems> _parser = new MessageParser<LibraryItems>(() => new LibraryItems());

			private UnknownFieldSet _unknownFields;

			public const int ItemsFieldNumber = 1;

			private static readonly FieldCodec<LibraryItem> _repeated_items_codec = FieldCodec.ForMessage(10u, LibraryItem.Parser);

			private readonly RepeatedField<LibraryItem> items_ = new RepeatedField<LibraryItem>();

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<LibraryItems> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Library.Descriptor.NestedTypes[1];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RepeatedField<LibraryItem> Items => items_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public LibraryItems()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public LibraryItems(LibraryItems other)
				: this()
			{
				items_ = other.items_.Clone();
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public LibraryItems Clone()
			{
				return new LibraryItems(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as LibraryItems);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(LibraryItems other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
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
				num += items_.CalculateSize(_repeated_items_codec);
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(LibraryItems other)
			{
				if (other != null)
				{
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
					if (num != 10)
					{
						_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
					}
					else
					{
						items_.AddEntriesFrom(input, _repeated_items_codec);
					}
				}
			}
		}
	}

	private static readonly MessageParser<Library> _parser = new MessageParser<Library>(() => new Library());

	private UnknownFieldSet _unknownFields;

	public const int UrlFieldNumber = 1;

	private URL url_;

	public const int LibraryChildrenFieldNumber = 2;

	public const int LibraryItemsFieldNumber = 3;

	private object childType_;

	private ChildTypeOneofCase childTypeCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<Library> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => LibraryReflection.Descriptor.MessageTypes[0];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

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
	public Types.LibraryArray LibraryChildren
	{
		get
		{
			if (childTypeCase_ != ChildTypeOneofCase.LibraryChildren)
			{
				return null;
			}
			return (Types.LibraryArray)childType_;
		}
		set
		{
			childType_ = value;
			childTypeCase_ = ((value != null) ? ChildTypeOneofCase.LibraryChildren : ChildTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.LibraryItems LibraryItems
	{
		get
		{
			if (childTypeCase_ != ChildTypeOneofCase.LibraryItems)
			{
				return null;
			}
			return (Types.LibraryItems)childType_;
		}
		set
		{
			childType_ = value;
			childTypeCase_ = ((value != null) ? ChildTypeOneofCase.LibraryItems : ChildTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ChildTypeOneofCase ChildTypeCase => childTypeCase_;

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
		url_ = ((other.url_ != null) ? other.url_.Clone() : null);
		switch (other.ChildTypeCase)
		{
		case ChildTypeOneofCase.LibraryChildren:
			LibraryChildren = other.LibraryChildren.Clone();
			break;
		case ChildTypeOneofCase.LibraryItems:
			LibraryItems = other.LibraryItems.Clone();
			break;
		}
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
	public void ClearChildType()
	{
		childTypeCase_ = ChildTypeOneofCase.None;
		childType_ = null;
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
		if (!object.Equals(Url, other.Url))
		{
			return false;
		}
		if (!object.Equals(LibraryChildren, other.LibraryChildren))
		{
			return false;
		}
		if (!object.Equals(LibraryItems, other.LibraryItems))
		{
			return false;
		}
		if (ChildTypeCase != other.ChildTypeCase)
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
		if (url_ != null)
		{
			num ^= Url.GetHashCode();
		}
		if (childTypeCase_ == ChildTypeOneofCase.LibraryChildren)
		{
			num ^= LibraryChildren.GetHashCode();
		}
		if (childTypeCase_ == ChildTypeOneofCase.LibraryItems)
		{
			num ^= LibraryItems.GetHashCode();
		}
		num ^= (int)childTypeCase_;
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
		if (url_ != null)
		{
			output.WriteRawTag(10);
			output.WriteMessage(Url);
		}
		if (childTypeCase_ == ChildTypeOneofCase.LibraryChildren)
		{
			output.WriteRawTag(18);
			output.WriteMessage(LibraryChildren);
		}
		if (childTypeCase_ == ChildTypeOneofCase.LibraryItems)
		{
			output.WriteRawTag(26);
			output.WriteMessage(LibraryItems);
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
		if (url_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Url);
		}
		if (childTypeCase_ == ChildTypeOneofCase.LibraryChildren)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(LibraryChildren);
		}
		if (childTypeCase_ == ChildTypeOneofCase.LibraryItems)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(LibraryItems);
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
		if (other == null)
		{
			return;
		}
		if (other.url_ != null)
		{
			if (url_ == null)
			{
				Url = new URL();
			}
			Url.MergeFrom(other.Url);
		}
		switch (other.ChildTypeCase)
		{
		case ChildTypeOneofCase.LibraryChildren:
			if (LibraryChildren == null)
			{
				LibraryChildren = new Types.LibraryArray();
			}
			LibraryChildren.MergeFrom(other.LibraryChildren);
			break;
		case ChildTypeOneofCase.LibraryItems:
			if (LibraryItems == null)
			{
				LibraryItems = new Types.LibraryItems();
			}
			LibraryItems.MergeFrom(other.LibraryItems);
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
				if (url_ == null)
				{
					Url = new URL();
				}
				input.ReadMessage(Url);
				break;
			case 18u:
			{
				Types.LibraryArray libraryArray = new Types.LibraryArray();
				if (childTypeCase_ == ChildTypeOneofCase.LibraryChildren)
				{
					libraryArray.MergeFrom(LibraryChildren);
				}
				input.ReadMessage(libraryArray);
				LibraryChildren = libraryArray;
				break;
			}
			case 26u:
			{
				Types.LibraryItems libraryItems = new Types.LibraryItems();
				if (childTypeCase_ == ChildTypeOneofCase.LibraryItems)
				{
					libraryItems.MergeFrom(LibraryItems);
				}
				input.ReadMessage(libraryItems);
				LibraryItems = libraryItems;
				break;
			}
			}
		}
	}
}
