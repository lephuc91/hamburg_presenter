using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class API_v1_Status_Request : IMessage<API_v1_Status_Request>, IMessage, IEquatable<API_v1_Status_Request>, IDeepCloneable<API_v1_Status_Request>
{
	public enum RequestOneofCase
	{
		None,
		GetLayers,
		GetStageScreens,
		PutStageScreens,
		GetAudienceScreens,
		PutAudienceScreens,
		GetScreens,
		GetSlide
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class GetLayers : IMessage<GetLayers>, IMessage, IEquatable<GetLayers>, IDeepCloneable<GetLayers>
		{
			private static readonly MessageParser<GetLayers> _parser = new MessageParser<GetLayers>(() => new GetLayers());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GetLayers> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Status_Request.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetLayers()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetLayers(GetLayers other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetLayers Clone()
			{
				return new GetLayers(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as GetLayers);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(GetLayers other)
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
			public void MergeFrom(GetLayers other)
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
		public sealed class GetStageScreens : IMessage<GetStageScreens>, IMessage, IEquatable<GetStageScreens>, IDeepCloneable<GetStageScreens>
		{
			private static readonly MessageParser<GetStageScreens> _parser = new MessageParser<GetStageScreens>(() => new GetStageScreens());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GetStageScreens> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Status_Request.Descriptor.NestedTypes[1];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetStageScreens()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetStageScreens(GetStageScreens other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetStageScreens Clone()
			{
				return new GetStageScreens(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as GetStageScreens);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(GetStageScreens other)
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
			public void MergeFrom(GetStageScreens other)
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
		public sealed class PutStageScreens : IMessage<PutStageScreens>, IMessage, IEquatable<PutStageScreens>, IDeepCloneable<PutStageScreens>
		{
			private static readonly MessageParser<PutStageScreens> _parser = new MessageParser<PutStageScreens>(() => new PutStageScreens());

			private UnknownFieldSet _unknownFields;

			public const int EnabledFieldNumber = 1;

			private bool enabled_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<PutStageScreens> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Status_Request.Descriptor.NestedTypes[2];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Enabled
			{
				get
				{
					return enabled_;
				}
				set
				{
					enabled_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PutStageScreens()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PutStageScreens(PutStageScreens other)
				: this()
			{
				enabled_ = other.enabled_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PutStageScreens Clone()
			{
				return new PutStageScreens(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as PutStageScreens);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(PutStageScreens other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (Enabled != other.Enabled)
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
				if (Enabled)
				{
					num ^= Enabled.GetHashCode();
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
				if (Enabled)
				{
					output.WriteRawTag(8);
					output.WriteBool(Enabled);
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
				if (Enabled)
				{
					num += 2;
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(PutStageScreens other)
			{
				if (other != null)
				{
					if (other.Enabled)
					{
						Enabled = other.Enabled;
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
					if (num != 8)
					{
						_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
					}
					else
					{
						Enabled = input.ReadBool();
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class GetAudienceScreens : IMessage<GetAudienceScreens>, IMessage, IEquatable<GetAudienceScreens>, IDeepCloneable<GetAudienceScreens>
		{
			private static readonly MessageParser<GetAudienceScreens> _parser = new MessageParser<GetAudienceScreens>(() => new GetAudienceScreens());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GetAudienceScreens> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Status_Request.Descriptor.NestedTypes[3];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetAudienceScreens()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetAudienceScreens(GetAudienceScreens other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetAudienceScreens Clone()
			{
				return new GetAudienceScreens(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as GetAudienceScreens);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(GetAudienceScreens other)
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
			public void MergeFrom(GetAudienceScreens other)
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
		public sealed class PutAudienceScreens : IMessage<PutAudienceScreens>, IMessage, IEquatable<PutAudienceScreens>, IDeepCloneable<PutAudienceScreens>
		{
			private static readonly MessageParser<PutAudienceScreens> _parser = new MessageParser<PutAudienceScreens>(() => new PutAudienceScreens());

			private UnknownFieldSet _unknownFields;

			public const int EnabledFieldNumber = 1;

			private bool enabled_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<PutAudienceScreens> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Status_Request.Descriptor.NestedTypes[4];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Enabled
			{
				get
				{
					return enabled_;
				}
				set
				{
					enabled_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PutAudienceScreens()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PutAudienceScreens(PutAudienceScreens other)
				: this()
			{
				enabled_ = other.enabled_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PutAudienceScreens Clone()
			{
				return new PutAudienceScreens(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as PutAudienceScreens);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(PutAudienceScreens other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (Enabled != other.Enabled)
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
				if (Enabled)
				{
					num ^= Enabled.GetHashCode();
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
				if (Enabled)
				{
					output.WriteRawTag(8);
					output.WriteBool(Enabled);
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
				if (Enabled)
				{
					num += 2;
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(PutAudienceScreens other)
			{
				if (other != null)
				{
					if (other.Enabled)
					{
						Enabled = other.Enabled;
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
					if (num != 8)
					{
						_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
					}
					else
					{
						Enabled = input.ReadBool();
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class GetScreens : IMessage<GetScreens>, IMessage, IEquatable<GetScreens>, IDeepCloneable<GetScreens>
		{
			private static readonly MessageParser<GetScreens> _parser = new MessageParser<GetScreens>(() => new GetScreens());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GetScreens> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Status_Request.Descriptor.NestedTypes[5];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetScreens()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetScreens(GetScreens other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetScreens Clone()
			{
				return new GetScreens(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as GetScreens);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(GetScreens other)
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
			public void MergeFrom(GetScreens other)
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
		public sealed class GetSlide : IMessage<GetSlide>, IMessage, IEquatable<GetSlide>, IDeepCloneable<GetSlide>
		{
			private static readonly MessageParser<GetSlide> _parser = new MessageParser<GetSlide>(() => new GetSlide());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GetSlide> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Status_Request.Descriptor.NestedTypes[6];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetSlide()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetSlide(GetSlide other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetSlide Clone()
			{
				return new GetSlide(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as GetSlide);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(GetSlide other)
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
			public void MergeFrom(GetSlide other)
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

	private static readonly MessageParser<API_v1_Status_Request> _parser = new MessageParser<API_v1_Status_Request>(() => new API_v1_Status_Request());

	private UnknownFieldSet _unknownFields;

	public const int GetLayersFieldNumber = 1;

	public const int GetStageScreensFieldNumber = 2;

	public const int PutStageScreensFieldNumber = 3;

	public const int GetAudienceScreensFieldNumber = 4;

	public const int PutAudienceScreensFieldNumber = 5;

	public const int GetScreensFieldNumber = 6;

	public const int GetSlideFieldNumber = 7;

	private object request_;

	private RequestOneofCase requestCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<API_v1_Status_Request> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProApiV1StatusReflection.Descriptor.MessageTypes[2];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.GetLayers GetLayers
	{
		get
		{
			if (requestCase_ != RequestOneofCase.GetLayers)
			{
				return null;
			}
			return (Types.GetLayers)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.GetLayers : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.GetStageScreens GetStageScreens
	{
		get
		{
			if (requestCase_ != RequestOneofCase.GetStageScreens)
			{
				return null;
			}
			return (Types.GetStageScreens)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.GetStageScreens : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.PutStageScreens PutStageScreens
	{
		get
		{
			if (requestCase_ != RequestOneofCase.PutStageScreens)
			{
				return null;
			}
			return (Types.PutStageScreens)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.PutStageScreens : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.GetAudienceScreens GetAudienceScreens
	{
		get
		{
			if (requestCase_ != RequestOneofCase.GetAudienceScreens)
			{
				return null;
			}
			return (Types.GetAudienceScreens)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.GetAudienceScreens : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.PutAudienceScreens PutAudienceScreens
	{
		get
		{
			if (requestCase_ != RequestOneofCase.PutAudienceScreens)
			{
				return null;
			}
			return (Types.PutAudienceScreens)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.PutAudienceScreens : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.GetScreens GetScreens
	{
		get
		{
			if (requestCase_ != RequestOneofCase.GetScreens)
			{
				return null;
			}
			return (Types.GetScreens)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.GetScreens : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.GetSlide GetSlide
	{
		get
		{
			if (requestCase_ != RequestOneofCase.GetSlide)
			{
				return null;
			}
			return (Types.GetSlide)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.GetSlide : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RequestOneofCase RequestCase => requestCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Status_Request()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Status_Request(API_v1_Status_Request other)
		: this()
	{
		switch (other.RequestCase)
		{
		case RequestOneofCase.GetLayers:
			GetLayers = other.GetLayers.Clone();
			break;
		case RequestOneofCase.GetStageScreens:
			GetStageScreens = other.GetStageScreens.Clone();
			break;
		case RequestOneofCase.PutStageScreens:
			PutStageScreens = other.PutStageScreens.Clone();
			break;
		case RequestOneofCase.GetAudienceScreens:
			GetAudienceScreens = other.GetAudienceScreens.Clone();
			break;
		case RequestOneofCase.PutAudienceScreens:
			PutAudienceScreens = other.PutAudienceScreens.Clone();
			break;
		case RequestOneofCase.GetScreens:
			GetScreens = other.GetScreens.Clone();
			break;
		case RequestOneofCase.GetSlide:
			GetSlide = other.GetSlide.Clone();
			break;
		}
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Status_Request Clone()
	{
		return new API_v1_Status_Request(this);
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
		return Equals(other as API_v1_Status_Request);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(API_v1_Status_Request other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(GetLayers, other.GetLayers))
		{
			return false;
		}
		if (!object.Equals(GetStageScreens, other.GetStageScreens))
		{
			return false;
		}
		if (!object.Equals(PutStageScreens, other.PutStageScreens))
		{
			return false;
		}
		if (!object.Equals(GetAudienceScreens, other.GetAudienceScreens))
		{
			return false;
		}
		if (!object.Equals(PutAudienceScreens, other.PutAudienceScreens))
		{
			return false;
		}
		if (!object.Equals(GetScreens, other.GetScreens))
		{
			return false;
		}
		if (!object.Equals(GetSlide, other.GetSlide))
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
		if (requestCase_ == RequestOneofCase.GetLayers)
		{
			num ^= GetLayers.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.GetStageScreens)
		{
			num ^= GetStageScreens.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.PutStageScreens)
		{
			num ^= PutStageScreens.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.GetAudienceScreens)
		{
			num ^= GetAudienceScreens.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.PutAudienceScreens)
		{
			num ^= PutAudienceScreens.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.GetScreens)
		{
			num ^= GetScreens.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.GetSlide)
		{
			num ^= GetSlide.GetHashCode();
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
		if (requestCase_ == RequestOneofCase.GetLayers)
		{
			output.WriteRawTag(10);
			output.WriteMessage(GetLayers);
		}
		if (requestCase_ == RequestOneofCase.GetStageScreens)
		{
			output.WriteRawTag(18);
			output.WriteMessage(GetStageScreens);
		}
		if (requestCase_ == RequestOneofCase.PutStageScreens)
		{
			output.WriteRawTag(26);
			output.WriteMessage(PutStageScreens);
		}
		if (requestCase_ == RequestOneofCase.GetAudienceScreens)
		{
			output.WriteRawTag(34);
			output.WriteMessage(GetAudienceScreens);
		}
		if (requestCase_ == RequestOneofCase.PutAudienceScreens)
		{
			output.WriteRawTag(42);
			output.WriteMessage(PutAudienceScreens);
		}
		if (requestCase_ == RequestOneofCase.GetScreens)
		{
			output.WriteRawTag(50);
			output.WriteMessage(GetScreens);
		}
		if (requestCase_ == RequestOneofCase.GetSlide)
		{
			output.WriteRawTag(58);
			output.WriteMessage(GetSlide);
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
		if (requestCase_ == RequestOneofCase.GetLayers)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GetLayers);
		}
		if (requestCase_ == RequestOneofCase.GetStageScreens)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GetStageScreens);
		}
		if (requestCase_ == RequestOneofCase.PutStageScreens)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PutStageScreens);
		}
		if (requestCase_ == RequestOneofCase.GetAudienceScreens)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GetAudienceScreens);
		}
		if (requestCase_ == RequestOneofCase.PutAudienceScreens)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PutAudienceScreens);
		}
		if (requestCase_ == RequestOneofCase.GetScreens)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GetScreens);
		}
		if (requestCase_ == RequestOneofCase.GetSlide)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GetSlide);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(API_v1_Status_Request other)
	{
		if (other == null)
		{
			return;
		}
		switch (other.RequestCase)
		{
		case RequestOneofCase.GetLayers:
			if (GetLayers == null)
			{
				GetLayers = new Types.GetLayers();
			}
			GetLayers.MergeFrom(other.GetLayers);
			break;
		case RequestOneofCase.GetStageScreens:
			if (GetStageScreens == null)
			{
				GetStageScreens = new Types.GetStageScreens();
			}
			GetStageScreens.MergeFrom(other.GetStageScreens);
			break;
		case RequestOneofCase.PutStageScreens:
			if (PutStageScreens == null)
			{
				PutStageScreens = new Types.PutStageScreens();
			}
			PutStageScreens.MergeFrom(other.PutStageScreens);
			break;
		case RequestOneofCase.GetAudienceScreens:
			if (GetAudienceScreens == null)
			{
				GetAudienceScreens = new Types.GetAudienceScreens();
			}
			GetAudienceScreens.MergeFrom(other.GetAudienceScreens);
			break;
		case RequestOneofCase.PutAudienceScreens:
			if (PutAudienceScreens == null)
			{
				PutAudienceScreens = new Types.PutAudienceScreens();
			}
			PutAudienceScreens.MergeFrom(other.PutAudienceScreens);
			break;
		case RequestOneofCase.GetScreens:
			if (GetScreens == null)
			{
				GetScreens = new Types.GetScreens();
			}
			GetScreens.MergeFrom(other.GetScreens);
			break;
		case RequestOneofCase.GetSlide:
			if (GetSlide == null)
			{
				GetSlide = new Types.GetSlide();
			}
			GetSlide.MergeFrom(other.GetSlide);
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
				Types.GetLayers getLayers = new Types.GetLayers();
				if (requestCase_ == RequestOneofCase.GetLayers)
				{
					getLayers.MergeFrom(GetLayers);
				}
				input.ReadMessage(getLayers);
				GetLayers = getLayers;
				break;
			}
			case 18u:
			{
				Types.GetStageScreens getStageScreens = new Types.GetStageScreens();
				if (requestCase_ == RequestOneofCase.GetStageScreens)
				{
					getStageScreens.MergeFrom(GetStageScreens);
				}
				input.ReadMessage(getStageScreens);
				GetStageScreens = getStageScreens;
				break;
			}
			case 26u:
			{
				Types.PutStageScreens putStageScreens = new Types.PutStageScreens();
				if (requestCase_ == RequestOneofCase.PutStageScreens)
				{
					putStageScreens.MergeFrom(PutStageScreens);
				}
				input.ReadMessage(putStageScreens);
				PutStageScreens = putStageScreens;
				break;
			}
			case 34u:
			{
				Types.GetAudienceScreens getAudienceScreens = new Types.GetAudienceScreens();
				if (requestCase_ == RequestOneofCase.GetAudienceScreens)
				{
					getAudienceScreens.MergeFrom(GetAudienceScreens);
				}
				input.ReadMessage(getAudienceScreens);
				GetAudienceScreens = getAudienceScreens;
				break;
			}
			case 42u:
			{
				Types.PutAudienceScreens putAudienceScreens = new Types.PutAudienceScreens();
				if (requestCase_ == RequestOneofCase.PutAudienceScreens)
				{
					putAudienceScreens.MergeFrom(PutAudienceScreens);
				}
				input.ReadMessage(putAudienceScreens);
				PutAudienceScreens = putAudienceScreens;
				break;
			}
			case 50u:
			{
				Types.GetScreens getScreens = new Types.GetScreens();
				if (requestCase_ == RequestOneofCase.GetScreens)
				{
					getScreens.MergeFrom(GetScreens);
				}
				input.ReadMessage(getScreens);
				GetScreens = getScreens;
				break;
			}
			case 58u:
			{
				Types.GetSlide getSlide = new Types.GetSlide();
				if (requestCase_ == RequestOneofCase.GetSlide)
				{
					getSlide.MergeFrom(GetSlide);
				}
				input.ReadMessage(getSlide);
				GetSlide = getSlide;
				break;
			}
			}
		}
	}
}
