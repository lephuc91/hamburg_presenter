using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class API_v1_StageLayoutMap : IMessage<API_v1_StageLayoutMap>, IMessage, IEquatable<API_v1_StageLayoutMap>, IDeepCloneable<API_v1_StageLayoutMap>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Entry : IMessage<Entry>, IMessage, IEquatable<Entry>, IDeepCloneable<Entry>
		{
			private static readonly MessageParser<Entry> _parser = new MessageParser<Entry>(() => new Entry());

			private UnknownFieldSet _unknownFields;

			public const int ScreenFieldNumber = 1;

			private API_v1_Identifier screen_;

			public const int LayoutFieldNumber = 2;

			private API_v1_Identifier layout_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Entry> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_StageLayoutMap.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_Identifier Screen
			{
				get
				{
					return screen_;
				}
				set
				{
					screen_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_Identifier Layout
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
			public Entry()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Entry(Entry other)
				: this()
			{
				screen_ = ((other.screen_ != null) ? other.screen_.Clone() : null);
				layout_ = ((other.layout_ != null) ? other.layout_.Clone() : null);
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Entry Clone()
			{
				return new Entry(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Entry);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Entry other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(Screen, other.Screen))
				{
					return false;
				}
				if (!object.Equals(Layout, other.Layout))
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
				if (screen_ != null)
				{
					num ^= Screen.GetHashCode();
				}
				if (layout_ != null)
				{
					num ^= Layout.GetHashCode();
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
				if (screen_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Screen);
				}
				if (layout_ != null)
				{
					output.WriteRawTag(18);
					output.WriteMessage(Layout);
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
				if (screen_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Screen);
				}
				if (layout_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Layout);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(Entry other)
			{
				if (other == null)
				{
					return;
				}
				if (other.screen_ != null)
				{
					if (screen_ == null)
					{
						Screen = new API_v1_Identifier();
					}
					Screen.MergeFrom(other.Screen);
				}
				if (other.layout_ != null)
				{
					if (layout_ == null)
					{
						Layout = new API_v1_Identifier();
					}
					Layout.MergeFrom(other.Layout);
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
						if (screen_ == null)
						{
							Screen = new API_v1_Identifier();
						}
						input.ReadMessage(Screen);
						break;
					case 18u:
						if (layout_ == null)
						{
							Layout = new API_v1_Identifier();
						}
						input.ReadMessage(Layout);
						break;
					}
				}
			}
		}
	}

	private static readonly MessageParser<API_v1_StageLayoutMap> _parser = new MessageParser<API_v1_StageLayoutMap>(() => new API_v1_StageLayoutMap());

	private UnknownFieldSet _unknownFields;

	public const int EntriesFieldNumber = 1;

	private static readonly FieldCodec<Types.Entry> _repeated_entries_codec = FieldCodec.ForMessage(10u, Types.Entry.Parser);

	private readonly RepeatedField<Types.Entry> entries_ = new RepeatedField<Types.Entry>();

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<API_v1_StageLayoutMap> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProApiV1StageReflection.Descriptor.MessageTypes[0];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<Types.Entry> Entries => entries_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_StageLayoutMap()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_StageLayoutMap(API_v1_StageLayoutMap other)
		: this()
	{
		entries_ = other.entries_.Clone();
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_StageLayoutMap Clone()
	{
		return new API_v1_StageLayoutMap(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as API_v1_StageLayoutMap);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(API_v1_StageLayoutMap other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!entries_.Equals(other.entries_))
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
		num ^= entries_.GetHashCode();
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
		entries_.WriteTo(output, _repeated_entries_codec);
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
		num += entries_.CalculateSize(_repeated_entries_codec);
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(API_v1_StageLayoutMap other)
	{
		if (other != null)
		{
			entries_.Add(other.entries_);
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
				entries_.AddEntriesFrom(input, _repeated_entries_codec);
			}
		}
	}
}
