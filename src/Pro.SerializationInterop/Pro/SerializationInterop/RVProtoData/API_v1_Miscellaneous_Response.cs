using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class API_v1_Miscellaneous_Response : IMessage<API_v1_Miscellaneous_Response>, IMessage, IEquatable<API_v1_Miscellaneous_Response>, IDeepCloneable<API_v1_Miscellaneous_Response>
{
	public enum ResponseOneofCase
	{
		None,
		FindMyMouse
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class FindMyMouse : IMessage<FindMyMouse>, IMessage, IEquatable<FindMyMouse>, IDeepCloneable<FindMyMouse>
		{
			private static readonly MessageParser<FindMyMouse> _parser = new MessageParser<FindMyMouse>(() => new FindMyMouse());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<FindMyMouse> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Miscellaneous_Response.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public FindMyMouse()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public FindMyMouse(FindMyMouse other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public FindMyMouse Clone()
			{
				return new FindMyMouse(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as FindMyMouse);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(FindMyMouse other)
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
			public void MergeFrom(FindMyMouse other)
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

	private static readonly MessageParser<API_v1_Miscellaneous_Response> _parser = new MessageParser<API_v1_Miscellaneous_Response>(() => new API_v1_Miscellaneous_Response());

	private UnknownFieldSet _unknownFields;

	public const int FindMyMouseFieldNumber = 1;

	private object response_;

	private ResponseOneofCase responseCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<API_v1_Miscellaneous_Response> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProApiV1MiscellaneousReflection.Descriptor.MessageTypes[1];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.FindMyMouse FindMyMouse
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.FindMyMouse)
			{
				return null;
			}
			return (Types.FindMyMouse)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.FindMyMouse : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ResponseOneofCase ResponseCase => responseCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Miscellaneous_Response()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Miscellaneous_Response(API_v1_Miscellaneous_Response other)
		: this()
	{
		if (other.ResponseCase == ResponseOneofCase.FindMyMouse)
		{
			FindMyMouse = other.FindMyMouse.Clone();
		}
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Miscellaneous_Response Clone()
	{
		return new API_v1_Miscellaneous_Response(this);
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
		return Equals(other as API_v1_Miscellaneous_Response);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(API_v1_Miscellaneous_Response other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(FindMyMouse, other.FindMyMouse))
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
		if (responseCase_ == ResponseOneofCase.FindMyMouse)
		{
			num ^= FindMyMouse.GetHashCode();
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
		if (responseCase_ == ResponseOneofCase.FindMyMouse)
		{
			output.WriteRawTag(10);
			output.WriteMessage(FindMyMouse);
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
		if (responseCase_ == ResponseOneofCase.FindMyMouse)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(FindMyMouse);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(API_v1_Miscellaneous_Response other)
	{
		if (other == null)
		{
			return;
		}
		if (other.ResponseCase == ResponseOneofCase.FindMyMouse)
		{
			if (FindMyMouse == null)
			{
				FindMyMouse = new Types.FindMyMouse();
			}
			FindMyMouse.MergeFrom(other.FindMyMouse);
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
			if (num != 10)
			{
				_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
				continue;
			}
			Types.FindMyMouse findMyMouse = new Types.FindMyMouse();
			if (responseCase_ == ResponseOneofCase.FindMyMouse)
			{
				findMyMouse.MergeFrom(FindMyMouse);
			}
			input.ReadMessage(findMyMouse);
			FindMyMouse = findMyMouse;
		}
	}
}
