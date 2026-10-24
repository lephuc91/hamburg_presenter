using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class UserFeedback : IMessage<UserFeedback>, IMessage, IEquatable<UserFeedback>, IDeepCloneable<UserFeedback>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class ApplicationMetadata : IMessage<ApplicationMetadata>, IMessage, IEquatable<ApplicationMetadata>, IDeepCloneable<ApplicationMetadata>
		{
			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class ApplicationInstance : IMessage<ApplicationInstance>, IMessage, IEquatable<ApplicationInstance>, IDeepCloneable<ApplicationInstance>
				{
					private static readonly MessageParser<ApplicationInstance> _parser = new MessageParser<ApplicationInstance>(() => new ApplicationInstance());

					private UnknownFieldSet _unknownFields;

					public const int PathFieldNumber = 1;

					private string path_ = "";

					public const int VersionFieldNumber = 2;

					private string version_ = "";

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<ApplicationInstance> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => ApplicationMetadata.Descriptor.NestedTypes[0];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public string Path
					{
						get
						{
							return path_;
						}
						set
						{
							path_ = ProtoPreconditions.CheckNotNull(value, "value");
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public string Version
					{
						get
						{
							return version_;
						}
						set
						{
							version_ = ProtoPreconditions.CheckNotNull(value, "value");
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public ApplicationInstance()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public ApplicationInstance(ApplicationInstance other)
						: this()
					{
						path_ = other.path_;
						version_ = other.version_;
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public ApplicationInstance Clone()
					{
						return new ApplicationInstance(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as ApplicationInstance);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(ApplicationInstance other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (Path != other.Path)
						{
							return false;
						}
						if (Version != other.Version)
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
						if (Path.Length != 0)
						{
							num ^= Path.GetHashCode();
						}
						if (Version.Length != 0)
						{
							num ^= Version.GetHashCode();
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
						if (Path.Length != 0)
						{
							output.WriteRawTag(10);
							output.WriteString(Path);
						}
						if (Version.Length != 0)
						{
							output.WriteRawTag(18);
							output.WriteString(Version);
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
						if (Path.Length != 0)
						{
							num += 1 + CodedOutputStream.ComputeStringSize(Path);
						}
						if (Version.Length != 0)
						{
							num += 1 + CodedOutputStream.ComputeStringSize(Version);
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(ApplicationInstance other)
					{
						if (other != null)
						{
							if (other.Path.Length != 0)
							{
								Path = other.Path;
							}
							if (other.Version.Length != 0)
							{
								Version = other.Version;
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
								Path = input.ReadString();
								break;
							case 18u:
								Version = input.ReadString();
								break;
							}
						}
					}
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class Screen : IMessage<Screen>, IMessage, IEquatable<Screen>, IDeepCloneable<Screen>
				{
					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static class Types
					{
						public enum Type
						{
							[OriginalName("UNKNOWN")]
							Unknown,
							[OriginalName("AUDIENCE")]
							Audience,
							[OriginalName("STAGE")]
							Stage
						}

						[DebuggerDisplay("{ToString(),nq}")]
						public sealed class Resolution : IMessage<Resolution>, IMessage, IEquatable<Resolution>, IDeepCloneable<Resolution>
						{
							private static readonly MessageParser<Resolution> _parser = new MessageParser<Resolution>(() => new Resolution());

							private UnknownFieldSet _unknownFields;

							public const int WidthFieldNumber = 1;

							private uint width_;

							public const int HeightFieldNumber = 2;

							private uint height_;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageParser<Resolution> Parser => _parser;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageDescriptor Descriptor => Screen.Descriptor.NestedTypes[0];

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							MessageDescriptor IMessage.Descriptor => Descriptor;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public uint Width
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
							public uint Height
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
							public Resolution()
							{
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Resolution(Resolution other)
								: this()
							{
								width_ = other.width_;
								height_ = other.height_;
								_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Resolution Clone()
							{
								return new Resolution(this);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public override bool Equals(object other)
							{
								return Equals(other as Resolution);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool Equals(Resolution other)
							{
								if (other == null)
								{
									return false;
								}
								if (other == this)
								{
									return true;
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
								if (Width != 0)
								{
									output.WriteRawTag(8);
									output.WriteUInt32(Width);
								}
								if (Height != 0)
								{
									output.WriteRawTag(16);
									output.WriteUInt32(Height);
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
								if (Width != 0)
								{
									num += 1 + CodedOutputStream.ComputeUInt32Size(Width);
								}
								if (Height != 0)
								{
									num += 1 + CodedOutputStream.ComputeUInt32Size(Height);
								}
								if (_unknownFields != null)
								{
									num += _unknownFields.CalculateSize();
								}
								return num;
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public void MergeFrom(Resolution other)
							{
								if (other != null)
								{
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
										Width = input.ReadUInt32();
										break;
									case 16u:
										Height = input.ReadUInt32();
										break;
									}
								}
							}
						}
					}

					private static readonly MessageParser<Screen> _parser = new MessageParser<Screen>(() => new Screen());

					private UnknownFieldSet _unknownFields;

					public const int NameFieldNumber = 1;

					private string name_ = "";

					public const int ResolutionFieldNumber = 2;

					private Types.Resolution resolution_;

					public const int TypeFieldNumber = 3;

					private Types.Type type_;

					public const int OutputNameFieldNumber = 4;

					private string outputName_ = "";

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<Screen> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => ApplicationMetadata.Descriptor.NestedTypes[1];

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
					public Types.Resolution Resolution
					{
						get
						{
							return resolution_;
						}
						set
						{
							resolution_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Types.Type Type
					{
						get
						{
							return type_;
						}
						set
						{
							type_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public string OutputName
					{
						get
						{
							return outputName_;
						}
						set
						{
							outputName_ = ProtoPreconditions.CheckNotNull(value, "value");
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Screen()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Screen(Screen other)
						: this()
					{
						name_ = other.name_;
						resolution_ = ((other.resolution_ != null) ? other.resolution_.Clone() : null);
						type_ = other.type_;
						outputName_ = other.outputName_;
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Screen Clone()
					{
						return new Screen(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as Screen);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(Screen other)
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
						if (!object.Equals(Resolution, other.Resolution))
						{
							return false;
						}
						if (Type != other.Type)
						{
							return false;
						}
						if (OutputName != other.OutputName)
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
						if (resolution_ != null)
						{
							num ^= Resolution.GetHashCode();
						}
						if (Type != 0)
						{
							num ^= Type.GetHashCode();
						}
						if (OutputName.Length != 0)
						{
							num ^= OutputName.GetHashCode();
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
						if (resolution_ != null)
						{
							output.WriteRawTag(18);
							output.WriteMessage(Resolution);
						}
						if (Type != 0)
						{
							output.WriteRawTag(24);
							output.WriteEnum((int)Type);
						}
						if (OutputName.Length != 0)
						{
							output.WriteRawTag(34);
							output.WriteString(OutputName);
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
						if (resolution_ != null)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(Resolution);
						}
						if (Type != 0)
						{
							num += 1 + CodedOutputStream.ComputeEnumSize((int)Type);
						}
						if (OutputName.Length != 0)
						{
							num += 1 + CodedOutputStream.ComputeStringSize(OutputName);
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(Screen other)
					{
						if (other == null)
						{
							return;
						}
						if (other.Name.Length != 0)
						{
							Name = other.Name;
						}
						if (other.resolution_ != null)
						{
							if (resolution_ == null)
							{
								Resolution = new Types.Resolution();
							}
							Resolution.MergeFrom(other.Resolution);
						}
						if (other.Type != 0)
						{
							Type = other.Type;
						}
						if (other.OutputName.Length != 0)
						{
							OutputName = other.OutputName;
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
								Name = input.ReadString();
								break;
							case 18u:
								if (resolution_ == null)
								{
									Resolution = new Types.Resolution();
								}
								input.ReadMessage(Resolution);
								break;
							case 24u:
								Type = (Types.Type)input.ReadEnum();
								break;
							case 34u:
								OutputName = input.ReadString();
								break;
							}
						}
					}
				}
			}

			private static readonly MessageParser<ApplicationMetadata> _parser = new MessageParser<ApplicationMetadata>(() => new ApplicationMetadata());

			private UnknownFieldSet _unknownFields;

			public const int ApplicationVersionFieldNumber = 1;

			private string applicationVersion_ = "";

			public const int OsVersionFieldNumber = 2;

			private string osVersion_ = "";

			public const int ApplicationInstancesFieldNumber = 3;

			private static readonly FieldCodec<Types.ApplicationInstance> _repeated_applicationInstances_codec = FieldCodec.ForMessage(26u, Types.ApplicationInstance.Parser);

			private readonly RepeatedField<Types.ApplicationInstance> applicationInstances_ = new RepeatedField<Types.ApplicationInstance>();

			public const int BlackmagicDesktopVideoInstancesFieldNumber = 4;

			private static readonly FieldCodec<Types.ApplicationInstance> _repeated_blackmagicDesktopVideoInstances_codec = FieldCodec.ForMessage(34u, Types.ApplicationInstance.Parser);

			private readonly RepeatedField<Types.ApplicationInstance> blackmagicDesktopVideoInstances_ = new RepeatedField<Types.ApplicationInstance>();

			public const int ScreensFieldNumber = 5;

			private static readonly FieldCodec<Types.Screen> _repeated_screens_codec = FieldCodec.ForMessage(42u, Types.Screen.Parser);

			private readonly RepeatedField<Types.Screen> screens_ = new RepeatedField<Types.Screen>();

			public const int CrashReportingEnabledFieldNumber = 6;

			private bool crashReportingEnabled_;

			public const int AnalyticsReportingEnabledFieldNumber = 7;

			private bool analyticsReportingEnabled_;

			public const int EnabledFeatureFlagsFieldNumber = 8;

			private static readonly FieldCodec<string> _repeated_enabledFeatureFlags_codec = FieldCodec.ForString(66u);

			private readonly RepeatedField<string> enabledFeatureFlags_ = new RepeatedField<string>();

			public const int OrganizationIdFieldNumber = 9;

			private string organizationId_ = "";

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<ApplicationMetadata> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => UserFeedback.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string ApplicationVersion
			{
				get
				{
					return applicationVersion_;
				}
				set
				{
					applicationVersion_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string OsVersion
			{
				get
				{
					return osVersion_;
				}
				set
				{
					osVersion_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RepeatedField<Types.ApplicationInstance> ApplicationInstances => applicationInstances_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RepeatedField<Types.ApplicationInstance> BlackmagicDesktopVideoInstances => blackmagicDesktopVideoInstances_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RepeatedField<Types.Screen> Screens => screens_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool CrashReportingEnabled
			{
				get
				{
					return crashReportingEnabled_;
				}
				set
				{
					crashReportingEnabled_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool AnalyticsReportingEnabled
			{
				get
				{
					return analyticsReportingEnabled_;
				}
				set
				{
					analyticsReportingEnabled_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RepeatedField<string> EnabledFeatureFlags => enabledFeatureFlags_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string OrganizationId
			{
				get
				{
					return organizationId_;
				}
				set
				{
					organizationId_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ApplicationMetadata()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ApplicationMetadata(ApplicationMetadata other)
				: this()
			{
				applicationVersion_ = other.applicationVersion_;
				osVersion_ = other.osVersion_;
				applicationInstances_ = other.applicationInstances_.Clone();
				blackmagicDesktopVideoInstances_ = other.blackmagicDesktopVideoInstances_.Clone();
				screens_ = other.screens_.Clone();
				crashReportingEnabled_ = other.crashReportingEnabled_;
				analyticsReportingEnabled_ = other.analyticsReportingEnabled_;
				enabledFeatureFlags_ = other.enabledFeatureFlags_.Clone();
				organizationId_ = other.organizationId_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ApplicationMetadata Clone()
			{
				return new ApplicationMetadata(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as ApplicationMetadata);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(ApplicationMetadata other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (ApplicationVersion != other.ApplicationVersion)
				{
					return false;
				}
				if (OsVersion != other.OsVersion)
				{
					return false;
				}
				if (!applicationInstances_.Equals(other.applicationInstances_))
				{
					return false;
				}
				if (!blackmagicDesktopVideoInstances_.Equals(other.blackmagicDesktopVideoInstances_))
				{
					return false;
				}
				if (!screens_.Equals(other.screens_))
				{
					return false;
				}
				if (CrashReportingEnabled != other.CrashReportingEnabled)
				{
					return false;
				}
				if (AnalyticsReportingEnabled != other.AnalyticsReportingEnabled)
				{
					return false;
				}
				if (!enabledFeatureFlags_.Equals(other.enabledFeatureFlags_))
				{
					return false;
				}
				if (OrganizationId != other.OrganizationId)
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
				if (ApplicationVersion.Length != 0)
				{
					num ^= ApplicationVersion.GetHashCode();
				}
				if (OsVersion.Length != 0)
				{
					num ^= OsVersion.GetHashCode();
				}
				num ^= applicationInstances_.GetHashCode();
				num ^= blackmagicDesktopVideoInstances_.GetHashCode();
				num ^= screens_.GetHashCode();
				if (CrashReportingEnabled)
				{
					num ^= CrashReportingEnabled.GetHashCode();
				}
				if (AnalyticsReportingEnabled)
				{
					num ^= AnalyticsReportingEnabled.GetHashCode();
				}
				num ^= enabledFeatureFlags_.GetHashCode();
				if (OrganizationId.Length != 0)
				{
					num ^= OrganizationId.GetHashCode();
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
				if (ApplicationVersion.Length != 0)
				{
					output.WriteRawTag(10);
					output.WriteString(ApplicationVersion);
				}
				if (OsVersion.Length != 0)
				{
					output.WriteRawTag(18);
					output.WriteString(OsVersion);
				}
				applicationInstances_.WriteTo(output, _repeated_applicationInstances_codec);
				blackmagicDesktopVideoInstances_.WriteTo(output, _repeated_blackmagicDesktopVideoInstances_codec);
				screens_.WriteTo(output, _repeated_screens_codec);
				if (CrashReportingEnabled)
				{
					output.WriteRawTag(48);
					output.WriteBool(CrashReportingEnabled);
				}
				if (AnalyticsReportingEnabled)
				{
					output.WriteRawTag(56);
					output.WriteBool(AnalyticsReportingEnabled);
				}
				enabledFeatureFlags_.WriteTo(output, _repeated_enabledFeatureFlags_codec);
				if (OrganizationId.Length != 0)
				{
					output.WriteRawTag(74);
					output.WriteString(OrganizationId);
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
				if (ApplicationVersion.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(ApplicationVersion);
				}
				if (OsVersion.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(OsVersion);
				}
				num += applicationInstances_.CalculateSize(_repeated_applicationInstances_codec);
				num += blackmagicDesktopVideoInstances_.CalculateSize(_repeated_blackmagicDesktopVideoInstances_codec);
				num += screens_.CalculateSize(_repeated_screens_codec);
				if (CrashReportingEnabled)
				{
					num += 2;
				}
				if (AnalyticsReportingEnabled)
				{
					num += 2;
				}
				num += enabledFeatureFlags_.CalculateSize(_repeated_enabledFeatureFlags_codec);
				if (OrganizationId.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(OrganizationId);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(ApplicationMetadata other)
			{
				if (other != null)
				{
					if (other.ApplicationVersion.Length != 0)
					{
						ApplicationVersion = other.ApplicationVersion;
					}
					if (other.OsVersion.Length != 0)
					{
						OsVersion = other.OsVersion;
					}
					applicationInstances_.Add(other.applicationInstances_);
					blackmagicDesktopVideoInstances_.Add(other.blackmagicDesktopVideoInstances_);
					screens_.Add(other.screens_);
					if (other.CrashReportingEnabled)
					{
						CrashReportingEnabled = other.CrashReportingEnabled;
					}
					if (other.AnalyticsReportingEnabled)
					{
						AnalyticsReportingEnabled = other.AnalyticsReportingEnabled;
					}
					enabledFeatureFlags_.Add(other.enabledFeatureFlags_);
					if (other.OrganizationId.Length != 0)
					{
						OrganizationId = other.OrganizationId;
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
						ApplicationVersion = input.ReadString();
						break;
					case 18u:
						OsVersion = input.ReadString();
						break;
					case 26u:
						applicationInstances_.AddEntriesFrom(input, _repeated_applicationInstances_codec);
						break;
					case 34u:
						blackmagicDesktopVideoInstances_.AddEntriesFrom(input, _repeated_blackmagicDesktopVideoInstances_codec);
						break;
					case 42u:
						screens_.AddEntriesFrom(input, _repeated_screens_codec);
						break;
					case 48u:
						CrashReportingEnabled = input.ReadBool();
						break;
					case 56u:
						AnalyticsReportingEnabled = input.ReadBool();
						break;
					case 66u:
						enabledFeatureFlags_.AddEntriesFrom(input, _repeated_enabledFeatureFlags_codec);
						break;
					case 74u:
						OrganizationId = input.ReadString();
						break;
					}
				}
			}
		}
	}

	private static readonly MessageParser<UserFeedback> _parser = new MessageParser<UserFeedback>(() => new UserFeedback());

	private UnknownFieldSet _unknownFields;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<UserFeedback> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => UserFeedbackReflection.Descriptor.MessageTypes[0];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public UserFeedback()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public UserFeedback(UserFeedback other)
		: this()
	{
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public UserFeedback Clone()
	{
		return new UserFeedback(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as UserFeedback);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(UserFeedback other)
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
	public void MergeFrom(UserFeedback other)
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
