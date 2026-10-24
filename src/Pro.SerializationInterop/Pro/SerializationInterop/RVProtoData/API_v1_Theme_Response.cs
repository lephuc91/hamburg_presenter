using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class API_v1_Theme_Response : IMessage<API_v1_Theme_Response>, IMessage, IEquatable<API_v1_Theme_Response>, IDeepCloneable<API_v1_Theme_Response>
{
	public enum ResponseOneofCase
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

			public const int GroupsFieldNumber = 1;

			private static readonly FieldCodec<API_v1_ThemeGroup> _repeated_groups_codec = FieldCodec.ForMessage(10u, API_v1_ThemeGroup.Parser);

			private readonly RepeatedField<API_v1_ThemeGroup> groups_ = new RepeatedField<API_v1_ThemeGroup>();

			public const int ThemesFieldNumber = 2;

			private static readonly FieldCodec<API_v1_Theme> _repeated_themes_codec = FieldCodec.ForMessage(18u, API_v1_Theme.Parser);

			private readonly RepeatedField<API_v1_Theme> themes_ = new RepeatedField<API_v1_Theme>();

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GetAll> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Theme_Response.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RepeatedField<API_v1_ThemeGroup> Groups => groups_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RepeatedField<API_v1_Theme> Themes => themes_;

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
				groups_ = other.groups_.Clone();
				themes_ = other.themes_.Clone();
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
				if (!groups_.Equals(other.groups_))
				{
					return false;
				}
				if (!themes_.Equals(other.themes_))
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
				num ^= groups_.GetHashCode();
				num ^= themes_.GetHashCode();
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
				groups_.WriteTo(output, _repeated_groups_codec);
				themes_.WriteTo(output, _repeated_themes_codec);
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
				num += groups_.CalculateSize(_repeated_groups_codec);
				num += themes_.CalculateSize(_repeated_themes_codec);
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
					groups_.Add(other.groups_);
					themes_.Add(other.themes_);
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
						groups_.AddEntriesFrom(input, _repeated_groups_codec);
						break;
					case 18u:
						themes_.AddEntriesFrom(input, _repeated_themes_codec);
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class GetTheme : IMessage<GetTheme>, IMessage, IEquatable<GetTheme>, IDeepCloneable<GetTheme>
		{
			public enum ValueOneofCase
			{
				None,
				Theme,
				Group
			}

			private static readonly MessageParser<GetTheme> _parser = new MessageParser<GetTheme>(() => new GetTheme());

			private UnknownFieldSet _unknownFields;

			public const int ThemeFieldNumber = 1;

			public const int GroupFieldNumber = 2;

			private object value_;

			private ValueOneofCase valueCase_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GetTheme> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Theme_Response.Descriptor.NestedTypes[1];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_Theme Theme
			{
				get
				{
					if (valueCase_ != ValueOneofCase.Theme)
					{
						return null;
					}
					return (API_v1_Theme)value_;
				}
				set
				{
					value_ = value;
					valueCase_ = ((value != null) ? ValueOneofCase.Theme : ValueOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_ThemeGroup Group
			{
				get
				{
					if (valueCase_ != ValueOneofCase.Group)
					{
						return null;
					}
					return (API_v1_ThemeGroup)value_;
				}
				set
				{
					value_ = value;
					valueCase_ = ((value != null) ? ValueOneofCase.Group : ValueOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ValueOneofCase ValueCase => valueCase_;

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
				switch (other.ValueCase)
				{
				case ValueOneofCase.Theme:
					Theme = other.Theme.Clone();
					break;
				case ValueOneofCase.Group:
					Group = other.Group.Clone();
					break;
				}
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
			public void ClearValue()
			{
				valueCase_ = ValueOneofCase.None;
				value_ = null;
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
				if (!object.Equals(Theme, other.Theme))
				{
					return false;
				}
				if (!object.Equals(Group, other.Group))
				{
					return false;
				}
				if (ValueCase != other.ValueCase)
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
				if (valueCase_ == ValueOneofCase.Theme)
				{
					num ^= Theme.GetHashCode();
				}
				if (valueCase_ == ValueOneofCase.Group)
				{
					num ^= Group.GetHashCode();
				}
				num ^= (int)valueCase_;
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
				if (valueCase_ == ValueOneofCase.Theme)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Theme);
				}
				if (valueCase_ == ValueOneofCase.Group)
				{
					output.WriteRawTag(18);
					output.WriteMessage(Group);
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
				if (valueCase_ == ValueOneofCase.Theme)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Theme);
				}
				if (valueCase_ == ValueOneofCase.Group)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Group);
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
				if (other == null)
				{
					return;
				}
				switch (other.ValueCase)
				{
				case ValueOneofCase.Theme:
					if (Theme == null)
					{
						Theme = new API_v1_Theme();
					}
					Theme.MergeFrom(other.Theme);
					break;
				case ValueOneofCase.Group:
					if (Group == null)
					{
						Group = new API_v1_ThemeGroup();
					}
					Group.MergeFrom(other.Group);
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
						API_v1_Theme aPI_v1_Theme = new API_v1_Theme();
						if (valueCase_ == ValueOneofCase.Theme)
						{
							aPI_v1_Theme.MergeFrom(Theme);
						}
						input.ReadMessage(aPI_v1_Theme);
						Theme = aPI_v1_Theme;
						break;
					}
					case 18u:
					{
						API_v1_ThemeGroup aPI_v1_ThemeGroup = new API_v1_ThemeGroup();
						if (valueCase_ == ValueOneofCase.Group)
						{
							aPI_v1_ThemeGroup.MergeFrom(Group);
						}
						input.ReadMessage(aPI_v1_ThemeGroup);
						Group = aPI_v1_ThemeGroup;
						break;
					}
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class DeleteTheme : IMessage<DeleteTheme>, IMessage, IEquatable<DeleteTheme>, IDeepCloneable<DeleteTheme>
		{
			private static readonly MessageParser<DeleteTheme> _parser = new MessageParser<DeleteTheme>(() => new DeleteTheme());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<DeleteTheme> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Theme_Response.Descriptor.NestedTypes[2];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

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
			public void MergeFrom(DeleteTheme other)
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
		public sealed class GetThemeName : IMessage<GetThemeName>, IMessage, IEquatable<GetThemeName>, IDeepCloneable<GetThemeName>
		{
			private static readonly MessageParser<GetThemeName> _parser = new MessageParser<GetThemeName>(() => new GetThemeName());

			private UnknownFieldSet _unknownFields;

			public const int NameFieldNumber = 1;

			private string name_ = "";

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GetThemeName> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Theme_Response.Descriptor.NestedTypes[3];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

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
			public GetThemeName()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetThemeName(GetThemeName other)
				: this()
			{
				name_ = other.name_;
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
				if (Name.Length != 0)
				{
					output.WriteRawTag(10);
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
			public void MergeFrom(GetThemeName other)
			{
				if (other != null)
				{
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
					if (num != 10)
					{
						_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
					}
					else
					{
						Name = input.ReadString();
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class PutThemeName : IMessage<PutThemeName>, IMessage, IEquatable<PutThemeName>, IDeepCloneable<PutThemeName>
		{
			private static readonly MessageParser<PutThemeName> _parser = new MessageParser<PutThemeName>(() => new PutThemeName());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<PutThemeName> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Theme_Response.Descriptor.NestedTypes[4];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

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
			public void MergeFrom(PutThemeName other)
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
		public sealed class GetThemeSlide : IMessage<GetThemeSlide>, IMessage, IEquatable<GetThemeSlide>, IDeepCloneable<GetThemeSlide>
		{
			private static readonly MessageParser<GetThemeSlide> _parser = new MessageParser<GetThemeSlide>(() => new GetThemeSlide());

			private UnknownFieldSet _unknownFields;

			public const int ThemeSlideFieldNumber = 1;

			private API_v1_ThemeSlide themeSlide_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GetThemeSlide> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Theme_Response.Descriptor.NestedTypes[5];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_ThemeSlide ThemeSlide
			{
				get
				{
					return themeSlide_;
				}
				set
				{
					themeSlide_ = value;
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
				themeSlide_ = ((other.themeSlide_ != null) ? other.themeSlide_.Clone() : null);
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
				if (!object.Equals(ThemeSlide, other.ThemeSlide))
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
				if (themeSlide_ != null)
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
				if (themeSlide_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(ThemeSlide);
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
				if (themeSlide_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(ThemeSlide);
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
				if (other == null)
				{
					return;
				}
				if (other.themeSlide_ != null)
				{
					if (themeSlide_ == null)
					{
						ThemeSlide = new API_v1_ThemeSlide();
					}
					ThemeSlide.MergeFrom(other.ThemeSlide);
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
					if (themeSlide_ == null)
					{
						ThemeSlide = new API_v1_ThemeSlide();
					}
					input.ReadMessage(ThemeSlide);
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class PutThemeSlide : IMessage<PutThemeSlide>, IMessage, IEquatable<PutThemeSlide>, IDeepCloneable<PutThemeSlide>
		{
			private static readonly MessageParser<PutThemeSlide> _parser = new MessageParser<PutThemeSlide>(() => new PutThemeSlide());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<PutThemeSlide> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Theme_Response.Descriptor.NestedTypes[6];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

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
			public void MergeFrom(PutThemeSlide other)
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
		public sealed class DeleteThemeSlide : IMessage<DeleteThemeSlide>, IMessage, IEquatable<DeleteThemeSlide>, IDeepCloneable<DeleteThemeSlide>
		{
			private static readonly MessageParser<DeleteThemeSlide> _parser = new MessageParser<DeleteThemeSlide>(() => new DeleteThemeSlide());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<DeleteThemeSlide> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Theme_Response.Descriptor.NestedTypes[7];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

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
			public void MergeFrom(DeleteThemeSlide other)
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
		public sealed class GetThemeSlideThumbnail : IMessage<GetThemeSlideThumbnail>, IMessage, IEquatable<GetThemeSlideThumbnail>, IDeepCloneable<GetThemeSlideThumbnail>
		{
			private static readonly MessageParser<GetThemeSlideThumbnail> _parser = new MessageParser<GetThemeSlideThumbnail>(() => new GetThemeSlideThumbnail());

			private UnknownFieldSet _unknownFields;

			public const int DataFieldNumber = 1;

			private ByteString data_ = ByteString.Empty;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GetThemeSlideThumbnail> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Theme_Response.Descriptor.NestedTypes[8];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ByteString Data
			{
				get
				{
					return data_;
				}
				set
				{
					data_ = ProtoPreconditions.CheckNotNull(value, "value");
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
				data_ = other.data_;
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
				if (Data != other.Data)
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
				if (Data.Length != 0)
				{
					num ^= Data.GetHashCode();
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
				if (Data.Length != 0)
				{
					output.WriteRawTag(10);
					output.WriteBytes(Data);
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
				if (Data.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeBytesSize(Data);
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
					if (other.Data.Length != 0)
					{
						Data = other.Data;
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
						Data = input.ReadBytes();
					}
				}
			}
		}
	}

	private static readonly MessageParser<API_v1_Theme_Response> _parser = new MessageParser<API_v1_Theme_Response>(() => new API_v1_Theme_Response());

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

	private object response_;

	private ResponseOneofCase responseCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<API_v1_Theme_Response> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProApiV1ThemeReflection.Descriptor.MessageTypes[4];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.GetAll GetAll
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.GetAll)
			{
				return null;
			}
			return (Types.GetAll)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.GetAll : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.GetTheme GetTheme
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.GetTheme)
			{
				return null;
			}
			return (Types.GetTheme)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.GetTheme : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.DeleteTheme DeleteTheme
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.DeleteTheme)
			{
				return null;
			}
			return (Types.DeleteTheme)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.DeleteTheme : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.GetThemeName GetThemeName
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.GetThemeName)
			{
				return null;
			}
			return (Types.GetThemeName)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.GetThemeName : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.PutThemeName PutThemeName
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.PutThemeName)
			{
				return null;
			}
			return (Types.PutThemeName)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.PutThemeName : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.GetThemeSlide GetThemeSlide
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.GetThemeSlide)
			{
				return null;
			}
			return (Types.GetThemeSlide)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.GetThemeSlide : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.PutThemeSlide PutThemeSlide
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.PutThemeSlide)
			{
				return null;
			}
			return (Types.PutThemeSlide)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.PutThemeSlide : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.DeleteThemeSlide DeleteThemeSlide
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.DeleteThemeSlide)
			{
				return null;
			}
			return (Types.DeleteThemeSlide)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.DeleteThemeSlide : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.GetThemeSlideThumbnail GetThemeSlideThumbnail
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.GetThemeSlideThumbnail)
			{
				return null;
			}
			return (Types.GetThemeSlideThumbnail)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.GetThemeSlideThumbnail : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ResponseOneofCase ResponseCase => responseCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Theme_Response()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Theme_Response(API_v1_Theme_Response other)
		: this()
	{
		switch (other.ResponseCase)
		{
		case ResponseOneofCase.GetAll:
			GetAll = other.GetAll.Clone();
			break;
		case ResponseOneofCase.GetTheme:
			GetTheme = other.GetTheme.Clone();
			break;
		case ResponseOneofCase.DeleteTheme:
			DeleteTheme = other.DeleteTheme.Clone();
			break;
		case ResponseOneofCase.GetThemeName:
			GetThemeName = other.GetThemeName.Clone();
			break;
		case ResponseOneofCase.PutThemeName:
			PutThemeName = other.PutThemeName.Clone();
			break;
		case ResponseOneofCase.GetThemeSlide:
			GetThemeSlide = other.GetThemeSlide.Clone();
			break;
		case ResponseOneofCase.PutThemeSlide:
			PutThemeSlide = other.PutThemeSlide.Clone();
			break;
		case ResponseOneofCase.DeleteThemeSlide:
			DeleteThemeSlide = other.DeleteThemeSlide.Clone();
			break;
		case ResponseOneofCase.GetThemeSlideThumbnail:
			GetThemeSlideThumbnail = other.GetThemeSlideThumbnail.Clone();
			break;
		}
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Theme_Response Clone()
	{
		return new API_v1_Theme_Response(this);
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
		return Equals(other as API_v1_Theme_Response);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(API_v1_Theme_Response other)
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
		if (responseCase_ == ResponseOneofCase.GetAll)
		{
			num ^= GetAll.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.GetTheme)
		{
			num ^= GetTheme.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.DeleteTheme)
		{
			num ^= DeleteTheme.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.GetThemeName)
		{
			num ^= GetThemeName.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.PutThemeName)
		{
			num ^= PutThemeName.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.GetThemeSlide)
		{
			num ^= GetThemeSlide.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.PutThemeSlide)
		{
			num ^= PutThemeSlide.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.DeleteThemeSlide)
		{
			num ^= DeleteThemeSlide.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.GetThemeSlideThumbnail)
		{
			num ^= GetThemeSlideThumbnail.GetHashCode();
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
		if (responseCase_ == ResponseOneofCase.GetAll)
		{
			output.WriteRawTag(10);
			output.WriteMessage(GetAll);
		}
		if (responseCase_ == ResponseOneofCase.GetTheme)
		{
			output.WriteRawTag(18);
			output.WriteMessage(GetTheme);
		}
		if (responseCase_ == ResponseOneofCase.DeleteTheme)
		{
			output.WriteRawTag(26);
			output.WriteMessage(DeleteTheme);
		}
		if (responseCase_ == ResponseOneofCase.GetThemeName)
		{
			output.WriteRawTag(34);
			output.WriteMessage(GetThemeName);
		}
		if (responseCase_ == ResponseOneofCase.PutThemeName)
		{
			output.WriteRawTag(42);
			output.WriteMessage(PutThemeName);
		}
		if (responseCase_ == ResponseOneofCase.GetThemeSlide)
		{
			output.WriteRawTag(50);
			output.WriteMessage(GetThemeSlide);
		}
		if (responseCase_ == ResponseOneofCase.PutThemeSlide)
		{
			output.WriteRawTag(58);
			output.WriteMessage(PutThemeSlide);
		}
		if (responseCase_ == ResponseOneofCase.DeleteThemeSlide)
		{
			output.WriteRawTag(66);
			output.WriteMessage(DeleteThemeSlide);
		}
		if (responseCase_ == ResponseOneofCase.GetThemeSlideThumbnail)
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
		if (responseCase_ == ResponseOneofCase.GetAll)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GetAll);
		}
		if (responseCase_ == ResponseOneofCase.GetTheme)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GetTheme);
		}
		if (responseCase_ == ResponseOneofCase.DeleteTheme)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(DeleteTheme);
		}
		if (responseCase_ == ResponseOneofCase.GetThemeName)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GetThemeName);
		}
		if (responseCase_ == ResponseOneofCase.PutThemeName)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PutThemeName);
		}
		if (responseCase_ == ResponseOneofCase.GetThemeSlide)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GetThemeSlide);
		}
		if (responseCase_ == ResponseOneofCase.PutThemeSlide)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PutThemeSlide);
		}
		if (responseCase_ == ResponseOneofCase.DeleteThemeSlide)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(DeleteThemeSlide);
		}
		if (responseCase_ == ResponseOneofCase.GetThemeSlideThumbnail)
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
	public void MergeFrom(API_v1_Theme_Response other)
	{
		if (other == null)
		{
			return;
		}
		switch (other.ResponseCase)
		{
		case ResponseOneofCase.GetAll:
			if (GetAll == null)
			{
				GetAll = new Types.GetAll();
			}
			GetAll.MergeFrom(other.GetAll);
			break;
		case ResponseOneofCase.GetTheme:
			if (GetTheme == null)
			{
				GetTheme = new Types.GetTheme();
			}
			GetTheme.MergeFrom(other.GetTheme);
			break;
		case ResponseOneofCase.DeleteTheme:
			if (DeleteTheme == null)
			{
				DeleteTheme = new Types.DeleteTheme();
			}
			DeleteTheme.MergeFrom(other.DeleteTheme);
			break;
		case ResponseOneofCase.GetThemeName:
			if (GetThemeName == null)
			{
				GetThemeName = new Types.GetThemeName();
			}
			GetThemeName.MergeFrom(other.GetThemeName);
			break;
		case ResponseOneofCase.PutThemeName:
			if (PutThemeName == null)
			{
				PutThemeName = new Types.PutThemeName();
			}
			PutThemeName.MergeFrom(other.PutThemeName);
			break;
		case ResponseOneofCase.GetThemeSlide:
			if (GetThemeSlide == null)
			{
				GetThemeSlide = new Types.GetThemeSlide();
			}
			GetThemeSlide.MergeFrom(other.GetThemeSlide);
			break;
		case ResponseOneofCase.PutThemeSlide:
			if (PutThemeSlide == null)
			{
				PutThemeSlide = new Types.PutThemeSlide();
			}
			PutThemeSlide.MergeFrom(other.PutThemeSlide);
			break;
		case ResponseOneofCase.DeleteThemeSlide:
			if (DeleteThemeSlide == null)
			{
				DeleteThemeSlide = new Types.DeleteThemeSlide();
			}
			DeleteThemeSlide.MergeFrom(other.DeleteThemeSlide);
			break;
		case ResponseOneofCase.GetThemeSlideThumbnail:
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
				if (responseCase_ == ResponseOneofCase.GetAll)
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
				if (responseCase_ == ResponseOneofCase.GetTheme)
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
				if (responseCase_ == ResponseOneofCase.DeleteTheme)
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
				if (responseCase_ == ResponseOneofCase.GetThemeName)
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
				if (responseCase_ == ResponseOneofCase.PutThemeName)
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
				if (responseCase_ == ResponseOneofCase.GetThemeSlide)
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
				if (responseCase_ == ResponseOneofCase.PutThemeSlide)
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
				if (responseCase_ == ResponseOneofCase.DeleteThemeSlide)
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
				if (responseCase_ == ResponseOneofCase.GetThemeSlideThumbnail)
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
