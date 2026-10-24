using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class API_v1_Theme_Request : IMessage<API_v1_Theme_Request>, IMessage, IEquatable<API_v1_Theme_Request>, IDeepCloneable<API_v1_Theme_Request>
{
	public enum RequestOneofCase
	{
		None,
		GetAll,
		GetTheme,
		DeleteTheme,
		GetThemeName,
		PutThemeName,
		GetThemeSlide,
		PutThemeSlide,
		DeleteThemeSlide,
		GetThemeSlideThumbnail
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class GetAll : IMessage<GetAll>, IMessage, IEquatable<GetAll>, IDeepCloneable<GetAll>
		{
			private static readonly MessageParser<GetAll> _parser = new MessageParser<GetAll>(() => new GetAll());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GetAll> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Theme_Request.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetAll()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetAll(GetAll other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetAll Clone()
			{
				return new GetAll(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as GetAll);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(GetAll other)
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
			public void MergeFrom(GetAll other)
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
		public sealed class GetTheme : IMessage<GetTheme>, IMessage, IEquatable<GetTheme>, IDeepCloneable<GetTheme>
		{
			private static readonly MessageParser<GetTheme> _parser = new MessageParser<GetTheme>(() => new GetTheme());

			private UnknownFieldSet _unknownFields;

			public const int IdFieldNumber = 1;

			private string id_ = "";

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GetTheme> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Theme_Request.Descriptor.NestedTypes[1];

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
			public GetTheme()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetTheme(GetTheme other)
				: this()
			{
				id_ = other.id_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetTheme Clone()
			{
				return new GetTheme(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as GetTheme);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(GetTheme other)
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
			public void MergeFrom(GetTheme other)
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
		public sealed class DeleteTheme : IMessage<DeleteTheme>, IMessage, IEquatable<DeleteTheme>, IDeepCloneable<DeleteTheme>
		{
			private static readonly MessageParser<DeleteTheme> _parser = new MessageParser<DeleteTheme>(() => new DeleteTheme());

			private UnknownFieldSet _unknownFields;

			public const int IdFieldNumber = 1;

			private string id_ = "";

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<DeleteTheme> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Theme_Request.Descriptor.NestedTypes[2];

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
			public DeleteTheme()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public DeleteTheme(DeleteTheme other)
				: this()
			{
				id_ = other.id_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public DeleteTheme Clone()
			{
				return new DeleteTheme(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as DeleteTheme);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(DeleteTheme other)
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
			public void MergeFrom(DeleteTheme other)
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
		public sealed class GetThemeName : IMessage<GetThemeName>, IMessage, IEquatable<GetThemeName>, IDeepCloneable<GetThemeName>
		{
			private static readonly MessageParser<GetThemeName> _parser = new MessageParser<GetThemeName>(() => new GetThemeName());

			private UnknownFieldSet _unknownFields;

			public const int IdFieldNumber = 1;

			private string id_ = "";

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GetThemeName> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Theme_Request.Descriptor.NestedTypes[3];

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
			public GetThemeName()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetThemeName(GetThemeName other)
				: this()
			{
				id_ = other.id_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetThemeName Clone()
			{
				return new GetThemeName(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as GetThemeName);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(GetThemeName other)
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
			public void MergeFrom(GetThemeName other)
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
		public sealed class PutThemeName : IMessage<PutThemeName>, IMessage, IEquatable<PutThemeName>, IDeepCloneable<PutThemeName>
		{
			private static readonly MessageParser<PutThemeName> _parser = new MessageParser<PutThemeName>(() => new PutThemeName());

			private UnknownFieldSet _unknownFields;

			public const int IdFieldNumber = 1;

			private string id_ = "";

			public const int NameFieldNumber = 2;

			private string name_ = "";

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<PutThemeName> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Theme_Request.Descriptor.NestedTypes[4];

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
			public string Name
			{
				get
				{
					return name_;
				}
				set
				{
					name_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PutThemeName()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PutThemeName(PutThemeName other)
				: this()
			{
				id_ = other.id_;
				name_ = other.name_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PutThemeName Clone()
			{
				return new PutThemeName(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as PutThemeName);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(PutThemeName other)
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
				if (Name != other.Name)
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
				if (Name.Length != 0)
				{
					num ^= Name.GetHashCode();
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
				if (Name.Length != 0)
				{
					output.WriteRawTag(18);
					output.WriteString(Name);
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
				if (Name.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Name);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(PutThemeName other)
			{
				if (other != null)
				{
					if (other.Id.Length != 0)
					{
						Id = other.Id;
					}
					if (other.Name.Length != 0)
					{
						Name = other.Name;
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
						Id = input.ReadString();
						break;
					case 18u:
						Name = input.ReadString();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class GetThemeSlide : IMessage<GetThemeSlide>, IMessage, IEquatable<GetThemeSlide>, IDeepCloneable<GetThemeSlide>
		{
			private static readonly MessageParser<GetThemeSlide> _parser = new MessageParser<GetThemeSlide>(() => new GetThemeSlide());

			private UnknownFieldSet _unknownFields;

			public const int IdFieldNumber = 1;

			private string id_ = "";

			public const int ThemeSlideFieldNumber = 2;

			private string themeSlide_ = "";

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GetThemeSlide> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Theme_Request.Descriptor.NestedTypes[5];

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
			public string ThemeSlide
			{
				get
				{
					return themeSlide_;
				}
				set
				{
					themeSlide_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetThemeSlide()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetThemeSlide(GetThemeSlide other)
				: this()
			{
				id_ = other.id_;
				themeSlide_ = other.themeSlide_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetThemeSlide Clone()
			{
				return new GetThemeSlide(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as GetThemeSlide);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(GetThemeSlide other)
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
				if (ThemeSlide != other.ThemeSlide)
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
				if (ThemeSlide.Length != 0)
				{
					num ^= ThemeSlide.GetHashCode();
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
				if (ThemeSlide.Length != 0)
				{
					output.WriteRawTag(18);
					output.WriteString(ThemeSlide);
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
				if (ThemeSlide.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(ThemeSlide);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(GetThemeSlide other)
			{
				if (other != null)
				{
					if (other.Id.Length != 0)
					{
						Id = other.Id;
					}
					if (other.ThemeSlide.Length != 0)
					{
						ThemeSlide = other.ThemeSlide;
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
						Id = input.ReadString();
						break;
					case 18u:
						ThemeSlide = input.ReadString();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class PutThemeSlide : IMessage<PutThemeSlide>, IMessage, IEquatable<PutThemeSlide>, IDeepCloneable<PutThemeSlide>
		{
			private static readonly MessageParser<PutThemeSlide> _parser = new MessageParser<PutThemeSlide>(() => new PutThemeSlide());

			private UnknownFieldSet _unknownFields;

			public const int IdFieldNumber = 1;

			private string id_ = "";

			public const int ThemeSlideFieldNumber = 2;

			private string themeSlide_ = "";

			public const int SlideFieldNumber = 3;

			private API_v1_ThemeSlide slide_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<PutThemeSlide> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Theme_Request.Descriptor.NestedTypes[6];

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
			public string ThemeSlide
			{
				get
				{
					return themeSlide_;
				}
				set
				{
					themeSlide_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_ThemeSlide Slide
			{
				get
				{
					return slide_;
				}
				set
				{
					slide_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PutThemeSlide()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PutThemeSlide(PutThemeSlide other)
				: this()
			{
				id_ = other.id_;
				themeSlide_ = other.themeSlide_;
				slide_ = ((other.slide_ != null) ? other.slide_.Clone() : null);
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PutThemeSlide Clone()
			{
				return new PutThemeSlide(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as PutThemeSlide);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(PutThemeSlide other)
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
				if (ThemeSlide != other.ThemeSlide)
				{
					return false;
				}
				if (!object.Equals(Slide, other.Slide))
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
				if (ThemeSlide.Length != 0)
				{
					num ^= ThemeSlide.GetHashCode();
				}
				if (slide_ != null)
				{
					num ^= Slide.GetHashCode();
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
				if (ThemeSlide.Length != 0)
				{
					output.WriteRawTag(18);
					output.WriteString(ThemeSlide);
				}
				if (slide_ != null)
				{
					output.WriteRawTag(26);
					output.WriteMessage(Slide);
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
				if (ThemeSlide.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(ThemeSlide);
				}
				if (slide_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Slide);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(PutThemeSlide other)
			{
				if (other == null)
				{
					return;
				}
				if (other.Id.Length != 0)
				{
					Id = other.Id;
				}
				if (other.ThemeSlide.Length != 0)
				{
					ThemeSlide = other.ThemeSlide;
				}
				if (other.slide_ != null)
				{
					if (slide_ == null)
					{
						Slide = new API_v1_ThemeSlide();
					}
					Slide.MergeFrom(other.Slide);
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
						Id = input.ReadString();
						break;
					case 18u:
						ThemeSlide = input.ReadString();
						break;
					case 26u:
						if (slide_ == null)
						{
							Slide = new API_v1_ThemeSlide();
						}
						input.ReadMessage(Slide);
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class DeleteThemeSlide : IMessage<DeleteThemeSlide>, IMessage, IEquatable<DeleteThemeSlide>, IDeepCloneable<DeleteThemeSlide>
		{
			private static readonly MessageParser<DeleteThemeSlide> _parser = new MessageParser<DeleteThemeSlide>(() => new DeleteThemeSlide());

			private UnknownFieldSet _unknownFields;

			public const int IdFieldNumber = 1;

			private string id_ = "";

			public const int ThemeSlideFieldNumber = 2;

			private string themeSlide_ = "";

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<DeleteThemeSlide> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Theme_Request.Descriptor.NestedTypes[7];

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
			public string ThemeSlide
			{
				get
				{
					return themeSlide_;
				}
				set
				{
					themeSlide_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public DeleteThemeSlide()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public DeleteThemeSlide(DeleteThemeSlide other)
				: this()
			{
				id_ = other.id_;
				themeSlide_ = other.themeSlide_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public DeleteThemeSlide Clone()
			{
				return new DeleteThemeSlide(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as DeleteThemeSlide);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(DeleteThemeSlide other)
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
				if (ThemeSlide != other.ThemeSlide)
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
				if (ThemeSlide.Length != 0)
				{
					num ^= ThemeSlide.GetHashCode();
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
				if (ThemeSlide.Length != 0)
				{
					output.WriteRawTag(18);
					output.WriteString(ThemeSlide);
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
				if (ThemeSlide.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(ThemeSlide);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(DeleteThemeSlide other)
			{
				if (other != null)
				{
					if (other.Id.Length != 0)
					{
						Id = other.Id;
					}
					if (other.ThemeSlide.Length != 0)
					{
						ThemeSlide = other.ThemeSlide;
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
						Id = input.ReadString();
						break;
					case 18u:
						ThemeSlide = input.ReadString();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class GetThemeSlideThumbnail : IMessage<GetThemeSlideThumbnail>, IMessage, IEquatable<GetThemeSlideThumbnail>, IDeepCloneable<GetThemeSlideThumbnail>
		{
			private static readonly MessageParser<GetThemeSlideThumbnail> _parser = new MessageParser<GetThemeSlideThumbnail>(() => new GetThemeSlideThumbnail());

			private UnknownFieldSet _unknownFields;

			public const int IdFieldNumber = 1;

			private string id_ = "";

			public const int ThemeSlideFieldNumber = 2;

			private string themeSlide_ = "";

			public const int QualityFieldNumber = 3;

			private int quality_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GetThemeSlideThumbnail> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Theme_Request.Descriptor.NestedTypes[8];

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
			public string ThemeSlide
			{
				get
				{
					return themeSlide_;
				}
				set
				{
					themeSlide_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public int Quality
			{
				get
				{
					return quality_;
				}
				set
				{
					quality_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetThemeSlideThumbnail()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetThemeSlideThumbnail(GetThemeSlideThumbnail other)
				: this()
			{
				id_ = other.id_;
				themeSlide_ = other.themeSlide_;
				quality_ = other.quality_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetThemeSlideThumbnail Clone()
			{
				return new GetThemeSlideThumbnail(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as GetThemeSlideThumbnail);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(GetThemeSlideThumbnail other)
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
				if (ThemeSlide != other.ThemeSlide)
				{
					return false;
				}
				if (Quality != other.Quality)
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
				if (ThemeSlide.Length != 0)
				{
					num ^= ThemeSlide.GetHashCode();
				}
				if (Quality != 0)
				{
					num ^= Quality.GetHashCode();
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
				if (ThemeSlide.Length != 0)
				{
					output.WriteRawTag(18);
					output.WriteString(ThemeSlide);
				}
				if (Quality != 0)
				{
					output.WriteRawTag(24);
					output.WriteInt32(Quality);
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
				if (ThemeSlide.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(ThemeSlide);
				}
				if (Quality != 0)
				{
					num += 1 + CodedOutputStream.ComputeInt32Size(Quality);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(GetThemeSlideThumbnail other)
			{
				if (other != null)
				{
					if (other.Id.Length != 0)
					{
						Id = other.Id;
					}
					if (other.ThemeSlide.Length != 0)
					{
						ThemeSlide = other.ThemeSlide;
					}
					if (other.Quality != 0)
					{
						Quality = other.Quality;
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
						Id = input.ReadString();
						break;
					case 18u:
						ThemeSlide = input.ReadString();
						break;
					case 24u:
						Quality = input.ReadInt32();
						break;
					}
				}
			}
		}
	}

	private static readonly MessageParser<API_v1_Theme_Request> _parser = new MessageParser<API_v1_Theme_Request>(() => new API_v1_Theme_Request());

	private UnknownFieldSet _unknownFields;

	public const int GetAllFieldNumber = 1;

	public const int GetThemeFieldNumber = 2;

	public const int DeleteThemeFieldNumber = 3;

	public const int GetThemeNameFieldNumber = 4;

	public const int PutThemeNameFieldNumber = 5;

	public const int GetThemeSlideFieldNumber = 6;

	public const int PutThemeSlideFieldNumber = 7;

	public const int DeleteThemeSlideFieldNumber = 8;

	public const int GetThemeSlideThumbnailFieldNumber = 9;

	private object request_;

	private RequestOneofCase requestCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<API_v1_Theme_Request> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProApiV1ThemeReflection.Descriptor.MessageTypes[3];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.GetAll GetAll
	{
		get
		{
			if (requestCase_ != RequestOneofCase.GetAll)
			{
				return null;
			}
			return (Types.GetAll)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.GetAll : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.GetTheme GetTheme
	{
		get
		{
			if (requestCase_ != RequestOneofCase.GetTheme)
			{
				return null;
			}
			return (Types.GetTheme)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.GetTheme : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.DeleteTheme DeleteTheme
	{
		get
		{
			if (requestCase_ != RequestOneofCase.DeleteTheme)
			{
				return null;
			}
			return (Types.DeleteTheme)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.DeleteTheme : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.GetThemeName GetThemeName
	{
		get
		{
			if (requestCase_ != RequestOneofCase.GetThemeName)
			{
				return null;
			}
			return (Types.GetThemeName)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.GetThemeName : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.PutThemeName PutThemeName
	{
		get
		{
			if (requestCase_ != RequestOneofCase.PutThemeName)
			{
				return null;
			}
			return (Types.PutThemeName)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.PutThemeName : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.GetThemeSlide GetThemeSlide
	{
		get
		{
			if (requestCase_ != RequestOneofCase.GetThemeSlide)
			{
				return null;
			}
			return (Types.GetThemeSlide)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.GetThemeSlide : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.PutThemeSlide PutThemeSlide
	{
		get
		{
			if (requestCase_ != RequestOneofCase.PutThemeSlide)
			{
				return null;
			}
			return (Types.PutThemeSlide)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.PutThemeSlide : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.DeleteThemeSlide DeleteThemeSlide
	{
		get
		{
			if (requestCase_ != RequestOneofCase.DeleteThemeSlide)
			{
				return null;
			}
			return (Types.DeleteThemeSlide)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.DeleteThemeSlide : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.GetThemeSlideThumbnail GetThemeSlideThumbnail
	{
		get
		{
			if (requestCase_ != RequestOneofCase.GetThemeSlideThumbnail)
			{
				return null;
			}
			return (Types.GetThemeSlideThumbnail)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.GetThemeSlideThumbnail : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RequestOneofCase RequestCase => requestCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Theme_Request()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Theme_Request(API_v1_Theme_Request other)
		: this()
	{
		switch (other.RequestCase)
		{
		case RequestOneofCase.GetAll:
			GetAll = other.GetAll.Clone();
			break;
		case RequestOneofCase.GetTheme:
			GetTheme = other.GetTheme.Clone();
			break;
		case RequestOneofCase.DeleteTheme:
			DeleteTheme = other.DeleteTheme.Clone();
			break;
		case RequestOneofCase.GetThemeName:
			GetThemeName = other.GetThemeName.Clone();
			break;
		case RequestOneofCase.PutThemeName:
			PutThemeName = other.PutThemeName.Clone();
			break;
		case RequestOneofCase.GetThemeSlide:
			GetThemeSlide = other.GetThemeSlide.Clone();
			break;
		case RequestOneofCase.PutThemeSlide:
			PutThemeSlide = other.PutThemeSlide.Clone();
			break;
		case RequestOneofCase.DeleteThemeSlide:
			DeleteThemeSlide = other.DeleteThemeSlide.Clone();
			break;
		case RequestOneofCase.GetThemeSlideThumbnail:
			GetThemeSlideThumbnail = other.GetThemeSlideThumbnail.Clone();
			break;
		}
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Theme_Request Clone()
	{
		return new API_v1_Theme_Request(this);
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
		return Equals(other as API_v1_Theme_Request);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(API_v1_Theme_Request other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(GetAll, other.GetAll))
		{
			return false;
		}
		if (!object.Equals(GetTheme, other.GetTheme))
		{
			return false;
		}
		if (!object.Equals(DeleteTheme, other.DeleteTheme))
		{
			return false;
		}
		if (!object.Equals(GetThemeName, other.GetThemeName))
		{
			return false;
		}
		if (!object.Equals(PutThemeName, other.PutThemeName))
		{
			return false;
		}
		if (!object.Equals(GetThemeSlide, other.GetThemeSlide))
		{
			return false;
		}
		if (!object.Equals(PutThemeSlide, other.PutThemeSlide))
		{
			return false;
		}
		if (!object.Equals(DeleteThemeSlide, other.DeleteThemeSlide))
		{
			return false;
		}
		if (!object.Equals(GetThemeSlideThumbnail, other.GetThemeSlideThumbnail))
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
		if (requestCase_ == RequestOneofCase.GetAll)
		{
			num ^= GetAll.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.GetTheme)
		{
			num ^= GetTheme.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.DeleteTheme)
		{
			num ^= DeleteTheme.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.GetThemeName)
		{
			num ^= GetThemeName.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.PutThemeName)
		{
			num ^= PutThemeName.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.GetThemeSlide)
		{
			num ^= GetThemeSlide.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.PutThemeSlide)
		{
			num ^= PutThemeSlide.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.DeleteThemeSlide)
		{
			num ^= DeleteThemeSlide.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.GetThemeSlideThumbnail)
		{
			num ^= GetThemeSlideThumbnail.GetHashCode();
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
		if (requestCase_ == RequestOneofCase.GetAll)
		{
			output.WriteRawTag(10);
			output.WriteMessage(GetAll);
		}
		if (requestCase_ == RequestOneofCase.GetTheme)
		{
			output.WriteRawTag(18);
			output.WriteMessage(GetTheme);
		}
		if (requestCase_ == RequestOneofCase.DeleteTheme)
		{
			output.WriteRawTag(26);
			output.WriteMessage(DeleteTheme);
		}
		if (requestCase_ == RequestOneofCase.GetThemeName)
		{
			output.WriteRawTag(34);
			output.WriteMessage(GetThemeName);
		}
		if (requestCase_ == RequestOneofCase.PutThemeName)
		{
			output.WriteRawTag(42);
			output.WriteMessage(PutThemeName);
		}
		if (requestCase_ == RequestOneofCase.GetThemeSlide)
		{
			output.WriteRawTag(50);
			output.WriteMessage(GetThemeSlide);
		}
		if (requestCase_ == RequestOneofCase.PutThemeSlide)
		{
			output.WriteRawTag(58);
			output.WriteMessage(PutThemeSlide);
		}
		if (requestCase_ == RequestOneofCase.DeleteThemeSlide)
		{
			output.WriteRawTag(66);
			output.WriteMessage(DeleteThemeSlide);
		}
		if (requestCase_ == RequestOneofCase.GetThemeSlideThumbnail)
		{
			output.WriteRawTag(74);
			output.WriteMessage(GetThemeSlideThumbnail);
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
		if (requestCase_ == RequestOneofCase.GetAll)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GetAll);
		}
		if (requestCase_ == RequestOneofCase.GetTheme)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GetTheme);
		}
		if (requestCase_ == RequestOneofCase.DeleteTheme)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(DeleteTheme);
		}
		if (requestCase_ == RequestOneofCase.GetThemeName)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GetThemeName);
		}
		if (requestCase_ == RequestOneofCase.PutThemeName)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PutThemeName);
		}
		if (requestCase_ == RequestOneofCase.GetThemeSlide)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GetThemeSlide);
		}
		if (requestCase_ == RequestOneofCase.PutThemeSlide)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PutThemeSlide);
		}
		if (requestCase_ == RequestOneofCase.DeleteThemeSlide)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(DeleteThemeSlide);
		}
		if (requestCase_ == RequestOneofCase.GetThemeSlideThumbnail)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GetThemeSlideThumbnail);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(API_v1_Theme_Request other)
	{
		if (other == null)
		{
			return;
		}
		switch (other.RequestCase)
		{
		case RequestOneofCase.GetAll:
			if (GetAll == null)
			{
				GetAll = new Types.GetAll();
			}
			GetAll.MergeFrom(other.GetAll);
			break;
		case RequestOneofCase.GetTheme:
			if (GetTheme == null)
			{
				GetTheme = new Types.GetTheme();
			}
			GetTheme.MergeFrom(other.GetTheme);
			break;
		case RequestOneofCase.DeleteTheme:
			if (DeleteTheme == null)
			{
				DeleteTheme = new Types.DeleteTheme();
			}
			DeleteTheme.MergeFrom(other.DeleteTheme);
			break;
		case RequestOneofCase.GetThemeName:
			if (GetThemeName == null)
			{
				GetThemeName = new Types.GetThemeName();
			}
			GetThemeName.MergeFrom(other.GetThemeName);
			break;
		case RequestOneofCase.PutThemeName:
			if (PutThemeName == null)
			{
				PutThemeName = new Types.PutThemeName();
			}
			PutThemeName.MergeFrom(other.PutThemeName);
			break;
		case RequestOneofCase.GetThemeSlide:
			if (GetThemeSlide == null)
			{
				GetThemeSlide = new Types.GetThemeSlide();
			}
			GetThemeSlide.MergeFrom(other.GetThemeSlide);
			break;
		case RequestOneofCase.PutThemeSlide:
			if (PutThemeSlide == null)
			{
				PutThemeSlide = new Types.PutThemeSlide();
			}
			PutThemeSlide.MergeFrom(other.PutThemeSlide);
			break;
		case RequestOneofCase.DeleteThemeSlide:
			if (DeleteThemeSlide == null)
			{
				DeleteThemeSlide = new Types.DeleteThemeSlide();
			}
			DeleteThemeSlide.MergeFrom(other.DeleteThemeSlide);
			break;
		case RequestOneofCase.GetThemeSlideThumbnail:
			if (GetThemeSlideThumbnail == null)
			{
				GetThemeSlideThumbnail = new Types.GetThemeSlideThumbnail();
			}
			GetThemeSlideThumbnail.MergeFrom(other.GetThemeSlideThumbnail);
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
				Types.GetAll getAll = new Types.GetAll();
				if (requestCase_ == RequestOneofCase.GetAll)
				{
					getAll.MergeFrom(GetAll);
				}
				input.ReadMessage(getAll);
				GetAll = getAll;
				break;
			}
			case 18u:
			{
				Types.GetTheme getTheme = new Types.GetTheme();
				if (requestCase_ == RequestOneofCase.GetTheme)
				{
					getTheme.MergeFrom(GetTheme);
				}
				input.ReadMessage(getTheme);
				GetTheme = getTheme;
				break;
			}
			case 26u:
			{
				Types.DeleteTheme deleteTheme = new Types.DeleteTheme();
				if (requestCase_ == RequestOneofCase.DeleteTheme)
				{
					deleteTheme.MergeFrom(DeleteTheme);
				}
				input.ReadMessage(deleteTheme);
				DeleteTheme = deleteTheme;
				break;
			}
			case 34u:
			{
				Types.GetThemeName getThemeName = new Types.GetThemeName();
				if (requestCase_ == RequestOneofCase.GetThemeName)
				{
					getThemeName.MergeFrom(GetThemeName);
				}
				input.ReadMessage(getThemeName);
				GetThemeName = getThemeName;
				break;
			}
			case 42u:
			{
				Types.PutThemeName putThemeName = new Types.PutThemeName();
				if (requestCase_ == RequestOneofCase.PutThemeName)
				{
					putThemeName.MergeFrom(PutThemeName);
				}
				input.ReadMessage(putThemeName);
				PutThemeName = putThemeName;
				break;
			}
			case 50u:
			{
				Types.GetThemeSlide getThemeSlide = new Types.GetThemeSlide();
				if (requestCase_ == RequestOneofCase.GetThemeSlide)
				{
					getThemeSlide.MergeFrom(GetThemeSlide);
				}
				input.ReadMessage(getThemeSlide);
				GetThemeSlide = getThemeSlide;
				break;
			}
			case 58u:
			{
				Types.PutThemeSlide putThemeSlide = new Types.PutThemeSlide();
				if (requestCase_ == RequestOneofCase.PutThemeSlide)
				{
					putThemeSlide.MergeFrom(PutThemeSlide);
				}
				input.ReadMessage(putThemeSlide);
				PutThemeSlide = putThemeSlide;
				break;
			}
			case 66u:
			{
				Types.DeleteThemeSlide deleteThemeSlide = new Types.DeleteThemeSlide();
				if (requestCase_ == RequestOneofCase.DeleteThemeSlide)
				{
					deleteThemeSlide.MergeFrom(DeleteThemeSlide);
				}
				input.ReadMessage(deleteThemeSlide);
				DeleteThemeSlide = deleteThemeSlide;
				break;
			}
			case 74u:
			{
				Types.GetThemeSlideThumbnail getThemeSlideThumbnail = new Types.GetThemeSlideThumbnail();
				if (requestCase_ == RequestOneofCase.GetThemeSlideThumbnail)
				{
					getThemeSlideThumbnail.MergeFrom(GetThemeSlideThumbnail);
				}
				input.ReadMessage(getThemeSlideThumbnail);
				GetThemeSlideThumbnail = getThemeSlideThumbnail;
				break;
			}
			}
		}
	}
}
