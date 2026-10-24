using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class TestPatternRequest : IMessage<TestPatternRequest>, IMessage, IEquatable<TestPatternRequest>, IDeepCloneable<TestPatternRequest>
{
	public enum RequestOneofCase
	{
		None,
		GetDefinitions,
		SetCurrentState,
		GetCurrentState,
		GetThumbnail
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class GetDefinitions : IMessage<GetDefinitions>, IMessage, IEquatable<GetDefinitions>, IDeepCloneable<GetDefinitions>
		{
			private static readonly MessageParser<GetDefinitions> _parser = new MessageParser<GetDefinitions>(() => new GetDefinitions());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GetDefinitions> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => TestPatternRequest.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetDefinitions()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetDefinitions(GetDefinitions other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetDefinitions Clone()
			{
				return new GetDefinitions(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as GetDefinitions);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(GetDefinitions other)
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
			public void MergeFrom(GetDefinitions other)
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
		public sealed class GetCurrentState : IMessage<GetCurrentState>, IMessage, IEquatable<GetCurrentState>, IDeepCloneable<GetCurrentState>
		{
			private static readonly MessageParser<GetCurrentState> _parser = new MessageParser<GetCurrentState>(() => new GetCurrentState());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GetCurrentState> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => TestPatternRequest.Descriptor.NestedTypes[1];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetCurrentState()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetCurrentState(GetCurrentState other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetCurrentState Clone()
			{
				return new GetCurrentState(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as GetCurrentState);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(GetCurrentState other)
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
			public void MergeFrom(GetCurrentState other)
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
		public sealed class GetThumbnail : IMessage<GetThumbnail>, IMessage, IEquatable<GetThumbnail>, IDeepCloneable<GetThumbnail>
		{
			private static readonly MessageParser<GetThumbnail> _parser = new MessageParser<GetThumbnail>(() => new GetThumbnail());

			private UnknownFieldSet _unknownFields;

			public const int PatternFieldNumber = 1;

			private TestPatternDefinition pattern_;

			public const int WidthFieldNumber = 2;

			private int width_;

			public const int HeightFieldNumber = 3;

			private int height_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GetThumbnail> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => TestPatternRequest.Descriptor.NestedTypes[2];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TestPatternDefinition Pattern
			{
				get
				{
					return pattern_;
				}
				set
				{
					pattern_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public int Width
			{
				get
				{
					return width_;
				}
				set
				{
					width_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public int Height
			{
				get
				{
					return height_;
				}
				set
				{
					height_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetThumbnail()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetThumbnail(GetThumbnail other)
				: this()
			{
				pattern_ = ((other.pattern_ != null) ? other.pattern_.Clone() : null);
				width_ = other.width_;
				height_ = other.height_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetThumbnail Clone()
			{
				return new GetThumbnail(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as GetThumbnail);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(GetThumbnail other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(Pattern, other.Pattern))
				{
					return false;
				}
				if (Width != other.Width)
				{
					return false;
				}
				if (Height != other.Height)
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
				if (pattern_ != null)
				{
					num ^= Pattern.GetHashCode();
				}
				if (Width != 0)
				{
					num ^= Width.GetHashCode();
				}
				if (Height != 0)
				{
					num ^= Height.GetHashCode();
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
				if (pattern_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Pattern);
				}
				if (Width != 0)
				{
					output.WriteRawTag(16);
					output.WriteInt32(Width);
				}
				if (Height != 0)
				{
					output.WriteRawTag(24);
					output.WriteInt32(Height);
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
				if (pattern_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Pattern);
				}
				if (Width != 0)
				{
					num += 1 + CodedOutputStream.ComputeInt32Size(Width);
				}
				if (Height != 0)
				{
					num += 1 + CodedOutputStream.ComputeInt32Size(Height);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(GetThumbnail other)
			{
				if (other == null)
				{
					return;
				}
				if (other.pattern_ != null)
				{
					if (pattern_ == null)
					{
						Pattern = new TestPatternDefinition();
					}
					Pattern.MergeFrom(other.Pattern);
				}
				if (other.Width != 0)
				{
					Width = other.Width;
				}
				if (other.Height != 0)
				{
					Height = other.Height;
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
						if (pattern_ == null)
						{
							Pattern = new TestPatternDefinition();
						}
						input.ReadMessage(Pattern);
						break;
					case 16u:
						Width = input.ReadInt32();
						break;
					case 24u:
						Height = input.ReadInt32();
						break;
					}
				}
			}
		}
	}

	private static readonly MessageParser<TestPatternRequest> _parser = new MessageParser<TestPatternRequest>(() => new TestPatternRequest());

	private UnknownFieldSet _unknownFields;

	public const int GetDefinitionsFieldNumber = 1;

	public const int SetCurrentStateFieldNumber = 2;

	public const int GetCurrentStateFieldNumber = 3;

	public const int GetThumbnailFieldNumber = 4;

	private object request_;

	private RequestOneofCase requestCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<TestPatternRequest> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProCoreTestPatternsReflection.Descriptor.MessageTypes[0];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.GetDefinitions GetDefinitions
	{
		get
		{
			if (requestCase_ != RequestOneofCase.GetDefinitions)
			{
				return null;
			}
			return (Types.GetDefinitions)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.GetDefinitions : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TestPatternState SetCurrentState
	{
		get
		{
			if (requestCase_ != RequestOneofCase.SetCurrentState)
			{
				return null;
			}
			return (TestPatternState)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.SetCurrentState : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.GetCurrentState GetCurrentState
	{
		get
		{
			if (requestCase_ != RequestOneofCase.GetCurrentState)
			{
				return null;
			}
			return (Types.GetCurrentState)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.GetCurrentState : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.GetThumbnail GetThumbnail
	{
		get
		{
			if (requestCase_ != RequestOneofCase.GetThumbnail)
			{
				return null;
			}
			return (Types.GetThumbnail)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.GetThumbnail : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RequestOneofCase RequestCase => requestCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TestPatternRequest()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TestPatternRequest(TestPatternRequest other)
		: this()
	{
		switch (other.RequestCase)
		{
		case RequestOneofCase.GetDefinitions:
			GetDefinitions = other.GetDefinitions.Clone();
			break;
		case RequestOneofCase.SetCurrentState:
			SetCurrentState = other.SetCurrentState.Clone();
			break;
		case RequestOneofCase.GetCurrentState:
			GetCurrentState = other.GetCurrentState.Clone();
			break;
		case RequestOneofCase.GetThumbnail:
			GetThumbnail = other.GetThumbnail.Clone();
			break;
		}
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TestPatternRequest Clone()
	{
		return new TestPatternRequest(this);
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
		return Equals(other as TestPatternRequest);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(TestPatternRequest other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(GetDefinitions, other.GetDefinitions))
		{
			return false;
		}
		if (!object.Equals(SetCurrentState, other.SetCurrentState))
		{
			return false;
		}
		if (!object.Equals(GetCurrentState, other.GetCurrentState))
		{
			return false;
		}
		if (!object.Equals(GetThumbnail, other.GetThumbnail))
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
		if (requestCase_ == RequestOneofCase.GetDefinitions)
		{
			num ^= GetDefinitions.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.SetCurrentState)
		{
			num ^= SetCurrentState.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.GetCurrentState)
		{
			num ^= GetCurrentState.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.GetThumbnail)
		{
			num ^= GetThumbnail.GetHashCode();
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
		if (requestCase_ == RequestOneofCase.GetDefinitions)
		{
			output.WriteRawTag(10);
			output.WriteMessage(GetDefinitions);
		}
		if (requestCase_ == RequestOneofCase.SetCurrentState)
		{
			output.WriteRawTag(18);
			output.WriteMessage(SetCurrentState);
		}
		if (requestCase_ == RequestOneofCase.GetCurrentState)
		{
			output.WriteRawTag(26);
			output.WriteMessage(GetCurrentState);
		}
		if (requestCase_ == RequestOneofCase.GetThumbnail)
		{
			output.WriteRawTag(34);
			output.WriteMessage(GetThumbnail);
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
		if (requestCase_ == RequestOneofCase.GetDefinitions)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GetDefinitions);
		}
		if (requestCase_ == RequestOneofCase.SetCurrentState)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(SetCurrentState);
		}
		if (requestCase_ == RequestOneofCase.GetCurrentState)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GetCurrentState);
		}
		if (requestCase_ == RequestOneofCase.GetThumbnail)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GetThumbnail);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(TestPatternRequest other)
	{
		if (other == null)
		{
			return;
		}
		switch (other.RequestCase)
		{
		case RequestOneofCase.GetDefinitions:
			if (GetDefinitions == null)
			{
				GetDefinitions = new Types.GetDefinitions();
			}
			GetDefinitions.MergeFrom(other.GetDefinitions);
			break;
		case RequestOneofCase.SetCurrentState:
			if (SetCurrentState == null)
			{
				SetCurrentState = new TestPatternState();
			}
			SetCurrentState.MergeFrom(other.SetCurrentState);
			break;
		case RequestOneofCase.GetCurrentState:
			if (GetCurrentState == null)
			{
				GetCurrentState = new Types.GetCurrentState();
			}
			GetCurrentState.MergeFrom(other.GetCurrentState);
			break;
		case RequestOneofCase.GetThumbnail:
			if (GetThumbnail == null)
			{
				GetThumbnail = new Types.GetThumbnail();
			}
			GetThumbnail.MergeFrom(other.GetThumbnail);
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
				Types.GetDefinitions getDefinitions = new Types.GetDefinitions();
				if (requestCase_ == RequestOneofCase.GetDefinitions)
				{
					getDefinitions.MergeFrom(GetDefinitions);
				}
				input.ReadMessage(getDefinitions);
				GetDefinitions = getDefinitions;
				break;
			}
			case 18u:
			{
				TestPatternState testPatternState = new TestPatternState();
				if (requestCase_ == RequestOneofCase.SetCurrentState)
				{
					testPatternState.MergeFrom(SetCurrentState);
				}
				input.ReadMessage(testPatternState);
				SetCurrentState = testPatternState;
				break;
			}
			case 26u:
			{
				Types.GetCurrentState getCurrentState = new Types.GetCurrentState();
				if (requestCase_ == RequestOneofCase.GetCurrentState)
				{
					getCurrentState.MergeFrom(GetCurrentState);
				}
				input.ReadMessage(getCurrentState);
				GetCurrentState = getCurrentState;
				break;
			}
			case 34u:
			{
				Types.GetThumbnail getThumbnail = new Types.GetThumbnail();
				if (requestCase_ == RequestOneofCase.GetThumbnail)
				{
					getThumbnail.MergeFrom(GetThumbnail);
				}
				input.ReadMessage(getThumbnail);
				GetThumbnail = getThumbnail;
				break;
			}
			}
		}
	}
}
