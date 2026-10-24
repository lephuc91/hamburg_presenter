using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class Preferences : IMessage<Preferences>, IMessage, IEquatable<Preferences>, IDeepCloneable<Preferences>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class General : IMessage<General>, IMessage, IEquatable<General>, IDeepCloneable<General>
		{
			private static readonly MessageParser<General> _parser = new MessageParser<General>(() => new General());

			private UnknownFieldSet _unknownFields;

			public const int HouseOfWorshipIntegrationsFieldNumber = 1;

			private bool houseOfWorshipIntegrations_;

			public const int CrashReportsFieldNumber = 2;

			private bool crashReports_;

			public const int AnalyticsFieldNumber = 3;

			private bool analytics_;

			public const int LogoPathFieldNumber = 4;

			private string logoPath_ = "";

			public const int LanguageFieldNumber = 5;

			private string language_ = "";

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<General> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Preferences.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool HouseOfWorshipIntegrations
			{
				get
				{
					return houseOfWorshipIntegrations_;
				}
				set
				{
					houseOfWorshipIntegrations_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool CrashReports
			{
				get
				{
					return crashReports_;
				}
				set
				{
					crashReports_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Analytics
			{
				get
				{
					return analytics_;
				}
				set
				{
					analytics_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string LogoPath
			{
				get
				{
					return logoPath_;
				}
				set
				{
					logoPath_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string Language
			{
				get
				{
					return language_;
				}
				set
				{
					language_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public General()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public General(General other)
				: this()
			{
				houseOfWorshipIntegrations_ = other.houseOfWorshipIntegrations_;
				crashReports_ = other.crashReports_;
				analytics_ = other.analytics_;
				logoPath_ = other.logoPath_;
				language_ = other.language_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public General Clone()
			{
				return new General(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as General);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(General other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (HouseOfWorshipIntegrations != other.HouseOfWorshipIntegrations)
				{
					return false;
				}
				if (CrashReports != other.CrashReports)
				{
					return false;
				}
				if (Analytics != other.Analytics)
				{
					return false;
				}
				if (LogoPath != other.LogoPath)
				{
					return false;
				}
				if (Language != other.Language)
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
				if (HouseOfWorshipIntegrations)
				{
					num ^= HouseOfWorshipIntegrations.GetHashCode();
				}
				if (CrashReports)
				{
					num ^= CrashReports.GetHashCode();
				}
				if (Analytics)
				{
					num ^= Analytics.GetHashCode();
				}
				if (LogoPath.Length != 0)
				{
					num ^= LogoPath.GetHashCode();
				}
				if (Language.Length != 0)
				{
					num ^= Language.GetHashCode();
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
				if (HouseOfWorshipIntegrations)
				{
					output.WriteRawTag(8);
					output.WriteBool(HouseOfWorshipIntegrations);
				}
				if (CrashReports)
				{
					output.WriteRawTag(16);
					output.WriteBool(CrashReports);
				}
				if (Analytics)
				{
					output.WriteRawTag(24);
					output.WriteBool(Analytics);
				}
				if (LogoPath.Length != 0)
				{
					output.WriteRawTag(34);
					output.WriteString(LogoPath);
				}
				if (Language.Length != 0)
				{
					output.WriteRawTag(42);
					output.WriteString(Language);
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
				if (HouseOfWorshipIntegrations)
				{
					num += 2;
				}
				if (CrashReports)
				{
					num += 2;
				}
				if (Analytics)
				{
					num += 2;
				}
				if (LogoPath.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(LogoPath);
				}
				if (Language.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Language);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(General other)
			{
				if (other != null)
				{
					if (other.HouseOfWorshipIntegrations)
					{
						HouseOfWorshipIntegrations = other.HouseOfWorshipIntegrations;
					}
					if (other.CrashReports)
					{
						CrashReports = other.CrashReports;
					}
					if (other.Analytics)
					{
						Analytics = other.Analytics;
					}
					if (other.LogoPath.Length != 0)
					{
						LogoPath = other.LogoPath;
					}
					if (other.Language.Length != 0)
					{
						Language = other.Language;
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
						HouseOfWorshipIntegrations = input.ReadBool();
						break;
					case 16u:
						CrashReports = input.ReadBool();
						break;
					case 24u:
						Analytics = input.ReadBool();
						break;
					case 34u:
						LogoPath = input.ReadString();
						break;
					case 42u:
						Language = input.ReadString();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Screens : IMessage<Screens>, IMessage, IEquatable<Screens>, IDeepCloneable<Screens>
		{
			private static readonly MessageParser<Screens> _parser = new MessageParser<Screens>(() => new Screens());

			private UnknownFieldSet _unknownFields;

			public const int EnableAtLaunchFieldNumber = 1;

			private bool enableAtLaunch_;

			public const int ShowPerformanceStatsFieldNumber = 2;

			private bool showPerformanceStats_;

			public const int IgnoreBackgroundColorsFieldNumber = 3;

			private bool ignoreBackgroundColors_;

			public const int ClockSourceFieldNumber = 4;

			private ProClockSource clockSource_;

			public const int ShowKeynoteAndPowerpointFieldNumber = 5;

			private bool showKeynoteAndPowerpoint_;

			public const int DisableBlackmagicSyncGroupsFieldNumber = 6;

			private bool disableBlackmagicSyncGroups_;

			public const int UseDirectxRenderingFieldNumber = 7;

			private bool useDirectxRendering_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Screens> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Preferences.Descriptor.NestedTypes[1];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool EnableAtLaunch
			{
				get
				{
					return enableAtLaunch_;
				}
				set
				{
					enableAtLaunch_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool ShowPerformanceStats
			{
				get
				{
					return showPerformanceStats_;
				}
				set
				{
					showPerformanceStats_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool IgnoreBackgroundColors
			{
				get
				{
					return ignoreBackgroundColors_;
				}
				set
				{
					ignoreBackgroundColors_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ProClockSource ClockSource
			{
				get
				{
					return clockSource_;
				}
				set
				{
					clockSource_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool ShowKeynoteAndPowerpoint
			{
				get
				{
					return showKeynoteAndPowerpoint_;
				}
				set
				{
					showKeynoteAndPowerpoint_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool DisableBlackmagicSyncGroups
			{
				get
				{
					return disableBlackmagicSyncGroups_;
				}
				set
				{
					disableBlackmagicSyncGroups_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool UseDirectxRendering
			{
				get
				{
					return useDirectxRendering_;
				}
				set
				{
					useDirectxRendering_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Screens()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Screens(Screens other)
				: this()
			{
				enableAtLaunch_ = other.enableAtLaunch_;
				showPerformanceStats_ = other.showPerformanceStats_;
				ignoreBackgroundColors_ = other.ignoreBackgroundColors_;
				clockSource_ = ((other.clockSource_ != null) ? other.clockSource_.Clone() : null);
				showKeynoteAndPowerpoint_ = other.showKeynoteAndPowerpoint_;
				disableBlackmagicSyncGroups_ = other.disableBlackmagicSyncGroups_;
				useDirectxRendering_ = other.useDirectxRendering_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Screens Clone()
			{
				return new Screens(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Screens);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Screens other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (EnableAtLaunch != other.EnableAtLaunch)
				{
					return false;
				}
				if (ShowPerformanceStats != other.ShowPerformanceStats)
				{
					return false;
				}
				if (IgnoreBackgroundColors != other.IgnoreBackgroundColors)
				{
					return false;
				}
				if (!object.Equals(ClockSource, other.ClockSource))
				{
					return false;
				}
				if (ShowKeynoteAndPowerpoint != other.ShowKeynoteAndPowerpoint)
				{
					return false;
				}
				if (DisableBlackmagicSyncGroups != other.DisableBlackmagicSyncGroups)
				{
					return false;
				}
				if (UseDirectxRendering != other.UseDirectxRendering)
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
				if (EnableAtLaunch)
				{
					num ^= EnableAtLaunch.GetHashCode();
				}
				if (ShowPerformanceStats)
				{
					num ^= ShowPerformanceStats.GetHashCode();
				}
				if (IgnoreBackgroundColors)
				{
					num ^= IgnoreBackgroundColors.GetHashCode();
				}
				if (clockSource_ != null)
				{
					num ^= ClockSource.GetHashCode();
				}
				if (ShowKeynoteAndPowerpoint)
				{
					num ^= ShowKeynoteAndPowerpoint.GetHashCode();
				}
				if (DisableBlackmagicSyncGroups)
				{
					num ^= DisableBlackmagicSyncGroups.GetHashCode();
				}
				if (UseDirectxRendering)
				{
					num ^= UseDirectxRendering.GetHashCode();
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
				if (EnableAtLaunch)
				{
					output.WriteRawTag(8);
					output.WriteBool(EnableAtLaunch);
				}
				if (ShowPerformanceStats)
				{
					output.WriteRawTag(16);
					output.WriteBool(ShowPerformanceStats);
				}
				if (IgnoreBackgroundColors)
				{
					output.WriteRawTag(24);
					output.WriteBool(IgnoreBackgroundColors);
				}
				if (clockSource_ != null)
				{
					output.WriteRawTag(34);
					output.WriteMessage(ClockSource);
				}
				if (ShowKeynoteAndPowerpoint)
				{
					output.WriteRawTag(40);
					output.WriteBool(ShowKeynoteAndPowerpoint);
				}
				if (DisableBlackmagicSyncGroups)
				{
					output.WriteRawTag(48);
					output.WriteBool(DisableBlackmagicSyncGroups);
				}
				if (UseDirectxRendering)
				{
					output.WriteRawTag(56);
					output.WriteBool(UseDirectxRendering);
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
				if (EnableAtLaunch)
				{
					num += 2;
				}
				if (ShowPerformanceStats)
				{
					num += 2;
				}
				if (IgnoreBackgroundColors)
				{
					num += 2;
				}
				if (clockSource_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(ClockSource);
				}
				if (ShowKeynoteAndPowerpoint)
				{
					num += 2;
				}
				if (DisableBlackmagicSyncGroups)
				{
					num += 2;
				}
				if (UseDirectxRendering)
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
			public void MergeFrom(Screens other)
			{
				if (other == null)
				{
					return;
				}
				if (other.EnableAtLaunch)
				{
					EnableAtLaunch = other.EnableAtLaunch;
				}
				if (other.ShowPerformanceStats)
				{
					ShowPerformanceStats = other.ShowPerformanceStats;
				}
				if (other.IgnoreBackgroundColors)
				{
					IgnoreBackgroundColors = other.IgnoreBackgroundColors;
				}
				if (other.clockSource_ != null)
				{
					if (clockSource_ == null)
					{
						ClockSource = new ProClockSource();
					}
					ClockSource.MergeFrom(other.ClockSource);
				}
				if (other.ShowKeynoteAndPowerpoint)
				{
					ShowKeynoteAndPowerpoint = other.ShowKeynoteAndPowerpoint;
				}
				if (other.DisableBlackmagicSyncGroups)
				{
					DisableBlackmagicSyncGroups = other.DisableBlackmagicSyncGroups;
				}
				if (other.UseDirectxRendering)
				{
					UseDirectxRendering = other.UseDirectxRendering;
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
					case 8u:
						EnableAtLaunch = input.ReadBool();
						break;
					case 16u:
						ShowPerformanceStats = input.ReadBool();
						break;
					case 24u:
						IgnoreBackgroundColors = input.ReadBool();
						break;
					case 34u:
						if (clockSource_ == null)
						{
							ClockSource = new ProClockSource();
						}
						input.ReadMessage(ClockSource);
						break;
					case 40u:
						ShowKeynoteAndPowerpoint = input.ReadBool();
						break;
					case 48u:
						DisableBlackmagicSyncGroups = input.ReadBool();
						break;
					case 56u:
						UseDirectxRendering = input.ReadBool();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Import : IMessage<Import>, IMessage, IEquatable<Import>, IDeepCloneable<Import>
		{
			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class Image : IMessage<Image>, IMessage, IEquatable<Image>, IDeepCloneable<Image>
				{
					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static class Types
					{
						[DebuggerDisplay("{ToString(),nq}")]
						public sealed class Duration : IMessage<Duration>, IMessage, IEquatable<Duration>, IDeepCloneable<Duration>
						{
							public enum DurationTypeOneofCase
							{
								None,
								None_,
								Time,
								Random
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static class Types
							{
								[DebuggerDisplay("{ToString(),nq}")]
								public sealed class None : IMessage<None>, IMessage, IEquatable<None>, IDeepCloneable<None>
								{
									private static readonly MessageParser<None> _parser = new MessageParser<None>(() => new None());

									private UnknownFieldSet _unknownFields;

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public static MessageParser<None> Parser => _parser;

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public static MessageDescriptor Descriptor => Duration.Descriptor.NestedTypes[0];

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									MessageDescriptor IMessage.Descriptor => Descriptor;

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public None()
									{
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public None(None other)
										: this()
									{
										_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public None Clone()
									{
										return new None(this);
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public override bool Equals(object other)
									{
										return Equals(other as None);
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public bool Equals(None other)
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
									public void MergeFrom(None other)
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
								public sealed class Time : IMessage<Time>, IMessage, IEquatable<Time>, IDeepCloneable<Time>
								{
									private static readonly MessageParser<Time> _parser = new MessageParser<Time>(() => new Time());

									private UnknownFieldSet _unknownFields;

									public const int Time_FieldNumber = 1;

									private double time_;

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public static MessageParser<Time> Parser => _parser;

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public static MessageDescriptor Descriptor => Duration.Descriptor.NestedTypes[1];

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									MessageDescriptor IMessage.Descriptor => Descriptor;

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public double Time_
									{
										get
										{
											return time_;
										}
										set
										{
											time_ = value;
										}
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public Time()
									{
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public Time(Time other)
										: this()
									{
										time_ = other.time_;
										_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public Time Clone()
									{
										return new Time(this);
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public override bool Equals(object other)
									{
										return Equals(other as Time);
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public bool Equals(Time other)
									{
										if (other == null)
										{
											return false;
										}
										if (other == this)
										{
											return true;
										}
										if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Time_, other.Time_))
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
										if (Time_ != 0.0)
										{
											num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Time_);
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
										if (Time_ != 0.0)
										{
											output.WriteRawTag(9);
											output.WriteDouble(Time_);
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
										if (Time_ != 0.0)
										{
											num += 9;
										}
										if (_unknownFields != null)
										{
											num += _unknownFields.CalculateSize();
										}
										return num;
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public void MergeFrom(Time other)
									{
										if (other != null)
										{
											if (other.Time_ != 0.0)
											{
												Time_ = other.Time_;
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
											if (num != 9)
											{
												_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
											}
											else
											{
												Time_ = input.ReadDouble();
											}
										}
									}
								}

								[DebuggerDisplay("{ToString(),nq}")]
								public sealed class Random : IMessage<Random>, IMessage, IEquatable<Random>, IDeepCloneable<Random>
								{
									private static readonly MessageParser<Random> _parser = new MessageParser<Random>(() => new Random());

									private UnknownFieldSet _unknownFields;

									public const int MinimumTimeFieldNumber = 1;

									private double minimumTime_;

									public const int MaximumTimeFieldNumber = 2;

									private double maximumTime_;

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public static MessageParser<Random> Parser => _parser;

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public static MessageDescriptor Descriptor => Duration.Descriptor.NestedTypes[2];

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									MessageDescriptor IMessage.Descriptor => Descriptor;

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public double MinimumTime
									{
										get
										{
											return minimumTime_;
										}
										set
										{
											minimumTime_ = value;
										}
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public double MaximumTime
									{
										get
										{
											return maximumTime_;
										}
										set
										{
											maximumTime_ = value;
										}
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public Random()
									{
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public Random(Random other)
										: this()
									{
										minimumTime_ = other.minimumTime_;
										maximumTime_ = other.maximumTime_;
										_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public Random Clone()
									{
										return new Random(this);
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public override bool Equals(object other)
									{
										return Equals(other as Random);
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public bool Equals(Random other)
									{
										if (other == null)
										{
											return false;
										}
										if (other == this)
										{
											return true;
										}
										if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(MinimumTime, other.MinimumTime))
										{
											return false;
										}
										if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(MaximumTime, other.MaximumTime))
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
										if (MinimumTime != 0.0)
										{
											num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(MinimumTime);
										}
										if (MaximumTime != 0.0)
										{
											num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(MaximumTime);
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
										if (MinimumTime != 0.0)
										{
											output.WriteRawTag(9);
											output.WriteDouble(MinimumTime);
										}
										if (MaximumTime != 0.0)
										{
											output.WriteRawTag(17);
											output.WriteDouble(MaximumTime);
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
										if (MinimumTime != 0.0)
										{
											num += 9;
										}
										if (MaximumTime != 0.0)
										{
											num += 9;
										}
										if (_unknownFields != null)
										{
											num += _unknownFields.CalculateSize();
										}
										return num;
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public void MergeFrom(Random other)
									{
										if (other != null)
										{
											if (other.MinimumTime != 0.0)
											{
												MinimumTime = other.MinimumTime;
											}
											if (other.MaximumTime != 0.0)
											{
												MaximumTime = other.MaximumTime;
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
											case 9u:
												MinimumTime = input.ReadDouble();
												break;
											case 17u:
												MaximumTime = input.ReadDouble();
												break;
											}
										}
									}
								}
							}

							private static readonly MessageParser<Duration> _parser = new MessageParser<Duration>(() => new Duration());

							private UnknownFieldSet _unknownFields;

							public const int NoneFieldNumber = 1;

							public const int TimeFieldNumber = 2;

							public const int RandomFieldNumber = 3;

							private object durationType_;

							private DurationTypeOneofCase durationTypeCase_;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageParser<Duration> Parser => _parser;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageDescriptor Descriptor => Image.Descriptor.NestedTypes[0];

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							MessageDescriptor IMessage.Descriptor => Descriptor;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Types.None None
							{
								get
								{
									if (durationTypeCase_ != DurationTypeOneofCase.None_)
									{
										return null;
									}
									return (Types.None)durationType_;
								}
								set
								{
									durationType_ = value;
									durationTypeCase_ = ((value != null) ? DurationTypeOneofCase.None_ : DurationTypeOneofCase.None);
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Types.Time Time
							{
								get
								{
									if (durationTypeCase_ != DurationTypeOneofCase.Time)
									{
										return null;
									}
									return (Types.Time)durationType_;
								}
								set
								{
									durationType_ = value;
									durationTypeCase_ = ((value != null) ? DurationTypeOneofCase.Time : DurationTypeOneofCase.None);
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Types.Random Random
							{
								get
								{
									if (durationTypeCase_ != DurationTypeOneofCase.Random)
									{
										return null;
									}
									return (Types.Random)durationType_;
								}
								set
								{
									durationType_ = value;
									durationTypeCase_ = ((value != null) ? DurationTypeOneofCase.Random : DurationTypeOneofCase.None);
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public DurationTypeOneofCase DurationTypeCase => durationTypeCase_;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Duration()
							{
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Duration(Duration other)
								: this()
							{
								switch (other.DurationTypeCase)
								{
								case DurationTypeOneofCase.None_:
									None = other.None.Clone();
									break;
								case DurationTypeOneofCase.Time:
									Time = other.Time.Clone();
									break;
								case DurationTypeOneofCase.Random:
									Random = other.Random.Clone();
									break;
								}
								_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Duration Clone()
							{
								return new Duration(this);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public void ClearDurationType()
							{
								durationTypeCase_ = DurationTypeOneofCase.None;
								durationType_ = null;
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public override bool Equals(object other)
							{
								return Equals(other as Duration);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool Equals(Duration other)
							{
								if (other == null)
								{
									return false;
								}
								if (other == this)
								{
									return true;
								}
								if (!object.Equals(None, other.None))
								{
									return false;
								}
								if (!object.Equals(Time, other.Time))
								{
									return false;
								}
								if (!object.Equals(Random, other.Random))
								{
									return false;
								}
								if (DurationTypeCase != other.DurationTypeCase)
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
								if (durationTypeCase_ == DurationTypeOneofCase.None_)
								{
									num ^= None.GetHashCode();
								}
								if (durationTypeCase_ == DurationTypeOneofCase.Time)
								{
									num ^= Time.GetHashCode();
								}
								if (durationTypeCase_ == DurationTypeOneofCase.Random)
								{
									num ^= Random.GetHashCode();
								}
								num ^= (int)durationTypeCase_;
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
								if (durationTypeCase_ == DurationTypeOneofCase.None_)
								{
									output.WriteRawTag(10);
									output.WriteMessage(None);
								}
								if (durationTypeCase_ == DurationTypeOneofCase.Time)
								{
									output.WriteRawTag(18);
									output.WriteMessage(Time);
								}
								if (durationTypeCase_ == DurationTypeOneofCase.Random)
								{
									output.WriteRawTag(26);
									output.WriteMessage(Random);
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
								if (durationTypeCase_ == DurationTypeOneofCase.None_)
								{
									num += 1 + CodedOutputStream.ComputeMessageSize(None);
								}
								if (durationTypeCase_ == DurationTypeOneofCase.Time)
								{
									num += 1 + CodedOutputStream.ComputeMessageSize(Time);
								}
								if (durationTypeCase_ == DurationTypeOneofCase.Random)
								{
									num += 1 + CodedOutputStream.ComputeMessageSize(Random);
								}
								if (_unknownFields != null)
								{
									num += _unknownFields.CalculateSize();
								}
								return num;
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public void MergeFrom(Duration other)
							{
								if (other == null)
								{
									return;
								}
								switch (other.DurationTypeCase)
								{
								case DurationTypeOneofCase.None_:
									if (None == null)
									{
										None = new Types.None();
									}
									None.MergeFrom(other.None);
									break;
								case DurationTypeOneofCase.Time:
									if (Time == null)
									{
										Time = new Types.Time();
									}
									Time.MergeFrom(other.Time);
									break;
								case DurationTypeOneofCase.Random:
									if (Random == null)
									{
										Random = new Types.Random();
									}
									Random.MergeFrom(other.Random);
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
										Types.None none = new Types.None();
										if (durationTypeCase_ == DurationTypeOneofCase.None_)
										{
											none.MergeFrom(None);
										}
										input.ReadMessage(none);
										None = none;
										break;
									}
									case 18u:
									{
										Types.Time time = new Types.Time();
										if (durationTypeCase_ == DurationTypeOneofCase.Time)
										{
											time.MergeFrom(Time);
										}
										input.ReadMessage(time);
										Time = time;
										break;
									}
									case 26u:
									{
										Types.Random random = new Types.Random();
										if (durationTypeCase_ == DurationTypeOneofCase.Random)
										{
											random.MergeFrom(Random);
										}
										input.ReadMessage(random);
										Random = random;
										break;
									}
									}
								}
							}
						}
					}

					private static readonly MessageParser<Image> _parser = new MessageParser<Image>(() => new Image());

					private UnknownFieldSet _unknownFields;

					public const int LayerTypeFieldNumber = 1;

					private Action.Types.LayerType layerType_;

					public const int DurationFieldNumber = 2;

					private Types.Duration duration_;

					public const int NextBehaviorFieldNumber = 3;

					private Cue.Types.CompletionTargetType nextBehavior_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<Image> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => Import.Descriptor.NestedTypes[0];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Action.Types.LayerType LayerType
					{
						get
						{
							return layerType_;
						}
						set
						{
							layerType_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Types.Duration Duration
					{
						get
						{
							return duration_;
						}
						set
						{
							duration_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Cue.Types.CompletionTargetType NextBehavior
					{
						get
						{
							return nextBehavior_;
						}
						set
						{
							nextBehavior_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Image()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Image(Image other)
						: this()
					{
						layerType_ = other.layerType_;
						duration_ = ((other.duration_ != null) ? other.duration_.Clone() : null);
						nextBehavior_ = other.nextBehavior_;
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Image Clone()
					{
						return new Image(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as Image);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(Image other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (LayerType != other.LayerType)
						{
							return false;
						}
						if (!object.Equals(Duration, other.Duration))
						{
							return false;
						}
						if (NextBehavior != other.NextBehavior)
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
						if (LayerType != 0)
						{
							num ^= LayerType.GetHashCode();
						}
						if (duration_ != null)
						{
							num ^= Duration.GetHashCode();
						}
						if (NextBehavior != 0)
						{
							num ^= NextBehavior.GetHashCode();
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
						if (LayerType != 0)
						{
							output.WriteRawTag(8);
							output.WriteEnum((int)LayerType);
						}
						if (duration_ != null)
						{
							output.WriteRawTag(18);
							output.WriteMessage(Duration);
						}
						if (NextBehavior != 0)
						{
							output.WriteRawTag(24);
							output.WriteEnum((int)NextBehavior);
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
						if (LayerType != 0)
						{
							num += 1 + CodedOutputStream.ComputeEnumSize((int)LayerType);
						}
						if (duration_ != null)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(Duration);
						}
						if (NextBehavior != 0)
						{
							num += 1 + CodedOutputStream.ComputeEnumSize((int)NextBehavior);
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(Image other)
					{
						if (other == null)
						{
							return;
						}
						if (other.LayerType != 0)
						{
							LayerType = other.LayerType;
						}
						if (other.duration_ != null)
						{
							if (duration_ == null)
							{
								Duration = new Types.Duration();
							}
							Duration.MergeFrom(other.Duration);
						}
						if (other.NextBehavior != 0)
						{
							NextBehavior = other.NextBehavior;
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
							case 8u:
								LayerType = (Action.Types.LayerType)input.ReadEnum();
								break;
							case 18u:
								if (duration_ == null)
								{
									Duration = new Types.Duration();
								}
								input.ReadMessage(Duration);
								break;
							case 24u:
								NextBehavior = (Cue.Types.CompletionTargetType)input.ReadEnum();
								break;
							}
						}
					}
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class Video : IMessage<Video>, IMessage, IEquatable<Video>, IDeepCloneable<Video>
				{
					private static readonly MessageParser<Video> _parser = new MessageParser<Video>(() => new Video());

					private UnknownFieldSet _unknownFields;

					public const int LayerTypeFieldNumber = 1;

					private Action.Types.LayerType layerType_;

					public const int PlaybackBehaviorFieldNumber = 2;

					private Media.Types.TransportProperties.Types.PlaybackBehavior playbackBehavior_;

					public const int EndBehaviorFieldNumber = 3;

					private Media.Types.VideoProperties.Types.EndBehavior endBehavior_;

					public const int NextBehaviorFieldNumber = 4;

					private Cue.Types.CompletionTargetType nextBehavior_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<Video> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => Import.Descriptor.NestedTypes[1];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Action.Types.LayerType LayerType
					{
						get
						{
							return layerType_;
						}
						set
						{
							layerType_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Media.Types.TransportProperties.Types.PlaybackBehavior PlaybackBehavior
					{
						get
						{
							return playbackBehavior_;
						}
						set
						{
							playbackBehavior_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Media.Types.VideoProperties.Types.EndBehavior EndBehavior
					{
						get
						{
							return endBehavior_;
						}
						set
						{
							endBehavior_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Cue.Types.CompletionTargetType NextBehavior
					{
						get
						{
							return nextBehavior_;
						}
						set
						{
							nextBehavior_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Video()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Video(Video other)
						: this()
					{
						layerType_ = other.layerType_;
						playbackBehavior_ = other.playbackBehavior_;
						endBehavior_ = other.endBehavior_;
						nextBehavior_ = other.nextBehavior_;
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Video Clone()
					{
						return new Video(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as Video);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(Video other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (LayerType != other.LayerType)
						{
							return false;
						}
						if (PlaybackBehavior != other.PlaybackBehavior)
						{
							return false;
						}
						if (EndBehavior != other.EndBehavior)
						{
							return false;
						}
						if (NextBehavior != other.NextBehavior)
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
						if (LayerType != 0)
						{
							num ^= LayerType.GetHashCode();
						}
						if (PlaybackBehavior != 0)
						{
							num ^= PlaybackBehavior.GetHashCode();
						}
						if (EndBehavior != 0)
						{
							num ^= EndBehavior.GetHashCode();
						}
						if (NextBehavior != 0)
						{
							num ^= NextBehavior.GetHashCode();
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
						if (LayerType != 0)
						{
							output.WriteRawTag(8);
							output.WriteEnum((int)LayerType);
						}
						if (PlaybackBehavior != 0)
						{
							output.WriteRawTag(16);
							output.WriteEnum((int)PlaybackBehavior);
						}
						if (EndBehavior != 0)
						{
							output.WriteRawTag(24);
							output.WriteEnum((int)EndBehavior);
						}
						if (NextBehavior != 0)
						{
							output.WriteRawTag(32);
							output.WriteEnum((int)NextBehavior);
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
						if (LayerType != 0)
						{
							num += 1 + CodedOutputStream.ComputeEnumSize((int)LayerType);
						}
						if (PlaybackBehavior != 0)
						{
							num += 1 + CodedOutputStream.ComputeEnumSize((int)PlaybackBehavior);
						}
						if (EndBehavior != 0)
						{
							num += 1 + CodedOutputStream.ComputeEnumSize((int)EndBehavior);
						}
						if (NextBehavior != 0)
						{
							num += 1 + CodedOutputStream.ComputeEnumSize((int)NextBehavior);
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(Video other)
					{
						if (other != null)
						{
							if (other.LayerType != 0)
							{
								LayerType = other.LayerType;
							}
							if (other.PlaybackBehavior != 0)
							{
								PlaybackBehavior = other.PlaybackBehavior;
							}
							if (other.EndBehavior != 0)
							{
								EndBehavior = other.EndBehavior;
							}
							if (other.NextBehavior != 0)
							{
								NextBehavior = other.NextBehavior;
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
								LayerType = (Action.Types.LayerType)input.ReadEnum();
								break;
							case 16u:
								PlaybackBehavior = (Media.Types.TransportProperties.Types.PlaybackBehavior)input.ReadEnum();
								break;
							case 24u:
								EndBehavior = (Media.Types.VideoProperties.Types.EndBehavior)input.ReadEnum();
								break;
							case 32u:
								NextBehavior = (Cue.Types.CompletionTargetType)input.ReadEnum();
								break;
							}
						}
					}
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class Audio : IMessage<Audio>, IMessage, IEquatable<Audio>, IDeepCloneable<Audio>
				{
					private static readonly MessageParser<Audio> _parser = new MessageParser<Audio>(() => new Audio());

					private UnknownFieldSet _unknownFields;

					public const int PlaybackBehaviorFieldNumber = 1;

					private Media.Types.TransportProperties.Types.PlaybackBehavior playbackBehavior_;

					public const int NextBehaviorFieldNumber = 2;

					private Cue.Types.CompletionTargetType nextBehavior_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<Audio> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => Import.Descriptor.NestedTypes[2];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Media.Types.TransportProperties.Types.PlaybackBehavior PlaybackBehavior
					{
						get
						{
							return playbackBehavior_;
						}
						set
						{
							playbackBehavior_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Cue.Types.CompletionTargetType NextBehavior
					{
						get
						{
							return nextBehavior_;
						}
						set
						{
							nextBehavior_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Audio()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Audio(Audio other)
						: this()
					{
						playbackBehavior_ = other.playbackBehavior_;
						nextBehavior_ = other.nextBehavior_;
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Audio Clone()
					{
						return new Audio(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as Audio);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(Audio other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (PlaybackBehavior != other.PlaybackBehavior)
						{
							return false;
						}
						if (NextBehavior != other.NextBehavior)
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
						if (PlaybackBehavior != 0)
						{
							num ^= PlaybackBehavior.GetHashCode();
						}
						if (NextBehavior != 0)
						{
							num ^= NextBehavior.GetHashCode();
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
						if (PlaybackBehavior != 0)
						{
							output.WriteRawTag(8);
							output.WriteEnum((int)PlaybackBehavior);
						}
						if (NextBehavior != 0)
						{
							output.WriteRawTag(16);
							output.WriteEnum((int)NextBehavior);
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
						if (PlaybackBehavior != 0)
						{
							num += 1 + CodedOutputStream.ComputeEnumSize((int)PlaybackBehavior);
						}
						if (NextBehavior != 0)
						{
							num += 1 + CodedOutputStream.ComputeEnumSize((int)NextBehavior);
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(Audio other)
					{
						if (other != null)
						{
							if (other.PlaybackBehavior != 0)
							{
								PlaybackBehavior = other.PlaybackBehavior;
							}
							if (other.NextBehavior != 0)
							{
								NextBehavior = other.NextBehavior;
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
								PlaybackBehavior = (Media.Types.TransportProperties.Types.PlaybackBehavior)input.ReadEnum();
								break;
							case 16u:
								NextBehavior = (Cue.Types.CompletionTargetType)input.ReadEnum();
								break;
							}
						}
					}
				}
			}

			private static readonly MessageParser<Import> _parser = new MessageParser<Import>(() => new Import());

			private UnknownFieldSet _unknownFields;

			public const int ForegroundScalingFieldNumber = 1;

			private Media.Types.ScaleBehavior foregroundScaling_;

			public const int ForegroundIsBlurredFieldNumber = 6;

			private bool foregroundIsBlurred_;

			public const int BackgroundScalingFieldNumber = 2;

			private Media.Types.ScaleBehavior backgroundScaling_;

			public const int BackgroundIsBlurredFieldNumber = 7;

			private bool backgroundIsBlurred_;

			public const int ImageFieldNumber = 3;

			private Types.Image image_;

			public const int VideoFieldNumber = 4;

			private Types.Video video_;

			public const int AudioFieldNumber = 5;

			private Types.Audio audio_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Import> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Preferences.Descriptor.NestedTypes[2];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Media.Types.ScaleBehavior ForegroundScaling
			{
				get
				{
					return foregroundScaling_;
				}
				set
				{
					foregroundScaling_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool ForegroundIsBlurred
			{
				get
				{
					return foregroundIsBlurred_;
				}
				set
				{
					foregroundIsBlurred_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Media.Types.ScaleBehavior BackgroundScaling
			{
				get
				{
					return backgroundScaling_;
				}
				set
				{
					backgroundScaling_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool BackgroundIsBlurred
			{
				get
				{
					return backgroundIsBlurred_;
				}
				set
				{
					backgroundIsBlurred_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.Image Image
			{
				get
				{
					return image_;
				}
				set
				{
					image_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.Video Video
			{
				get
				{
					return video_;
				}
				set
				{
					video_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.Audio Audio
			{
				get
				{
					return audio_;
				}
				set
				{
					audio_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Import()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Import(Import other)
				: this()
			{
				foregroundScaling_ = other.foregroundScaling_;
				foregroundIsBlurred_ = other.foregroundIsBlurred_;
				backgroundScaling_ = other.backgroundScaling_;
				backgroundIsBlurred_ = other.backgroundIsBlurred_;
				image_ = ((other.image_ != null) ? other.image_.Clone() : null);
				video_ = ((other.video_ != null) ? other.video_.Clone() : null);
				audio_ = ((other.audio_ != null) ? other.audio_.Clone() : null);
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Import Clone()
			{
				return new Import(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Import);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Import other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (ForegroundScaling != other.ForegroundScaling)
				{
					return false;
				}
				if (ForegroundIsBlurred != other.ForegroundIsBlurred)
				{
					return false;
				}
				if (BackgroundScaling != other.BackgroundScaling)
				{
					return false;
				}
				if (BackgroundIsBlurred != other.BackgroundIsBlurred)
				{
					return false;
				}
				if (!object.Equals(Image, other.Image))
				{
					return false;
				}
				if (!object.Equals(Video, other.Video))
				{
					return false;
				}
				if (!object.Equals(Audio, other.Audio))
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
				if (ForegroundScaling != 0)
				{
					num ^= ForegroundScaling.GetHashCode();
				}
				if (ForegroundIsBlurred)
				{
					num ^= ForegroundIsBlurred.GetHashCode();
				}
				if (BackgroundScaling != 0)
				{
					num ^= BackgroundScaling.GetHashCode();
				}
				if (BackgroundIsBlurred)
				{
					num ^= BackgroundIsBlurred.GetHashCode();
				}
				if (image_ != null)
				{
					num ^= Image.GetHashCode();
				}
				if (video_ != null)
				{
					num ^= Video.GetHashCode();
				}
				if (audio_ != null)
				{
					num ^= Audio.GetHashCode();
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
				if (ForegroundScaling != 0)
				{
					output.WriteRawTag(8);
					output.WriteEnum((int)ForegroundScaling);
				}
				if (BackgroundScaling != 0)
				{
					output.WriteRawTag(16);
					output.WriteEnum((int)BackgroundScaling);
				}
				if (image_ != null)
				{
					output.WriteRawTag(26);
					output.WriteMessage(Image);
				}
				if (video_ != null)
				{
					output.WriteRawTag(34);
					output.WriteMessage(Video);
				}
				if (audio_ != null)
				{
					output.WriteRawTag(42);
					output.WriteMessage(Audio);
				}
				if (ForegroundIsBlurred)
				{
					output.WriteRawTag(48);
					output.WriteBool(ForegroundIsBlurred);
				}
				if (BackgroundIsBlurred)
				{
					output.WriteRawTag(56);
					output.WriteBool(BackgroundIsBlurred);
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
				if (ForegroundScaling != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)ForegroundScaling);
				}
				if (ForegroundIsBlurred)
				{
					num += 2;
				}
				if (BackgroundScaling != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)BackgroundScaling);
				}
				if (BackgroundIsBlurred)
				{
					num += 2;
				}
				if (image_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Image);
				}
				if (video_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Video);
				}
				if (audio_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Audio);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(Import other)
			{
				if (other == null)
				{
					return;
				}
				if (other.ForegroundScaling != 0)
				{
					ForegroundScaling = other.ForegroundScaling;
				}
				if (other.ForegroundIsBlurred)
				{
					ForegroundIsBlurred = other.ForegroundIsBlurred;
				}
				if (other.BackgroundScaling != 0)
				{
					BackgroundScaling = other.BackgroundScaling;
				}
				if (other.BackgroundIsBlurred)
				{
					BackgroundIsBlurred = other.BackgroundIsBlurred;
				}
				if (other.image_ != null)
				{
					if (image_ == null)
					{
						Image = new Types.Image();
					}
					Image.MergeFrom(other.Image);
				}
				if (other.video_ != null)
				{
					if (video_ == null)
					{
						Video = new Types.Video();
					}
					Video.MergeFrom(other.Video);
				}
				if (other.audio_ != null)
				{
					if (audio_ == null)
					{
						Audio = new Types.Audio();
					}
					Audio.MergeFrom(other.Audio);
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
					case 8u:
						ForegroundScaling = (Media.Types.ScaleBehavior)input.ReadEnum();
						break;
					case 16u:
						BackgroundScaling = (Media.Types.ScaleBehavior)input.ReadEnum();
						break;
					case 26u:
						if (image_ == null)
						{
							Image = new Types.Image();
						}
						input.ReadMessage(Image);
						break;
					case 34u:
						if (video_ == null)
						{
							Video = new Types.Video();
						}
						input.ReadMessage(Video);
						break;
					case 42u:
						if (audio_ == null)
						{
							Audio = new Types.Audio();
						}
						input.ReadMessage(Audio);
						break;
					case 48u:
						ForegroundIsBlurred = input.ReadBool();
						break;
					case 56u:
						BackgroundIsBlurred = input.ReadBool();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Groups : IMessage<Groups>, IMessage, IEquatable<Groups>, IDeepCloneable<Groups>
		{
			private static readonly MessageParser<Groups> _parser = new MessageParser<Groups>(() => new Groups());

			private UnknownFieldSet _unknownFields;

			public const int Groups_FieldNumber = 1;

			private ProGroupsDocument groups_;

			public const int LabelsFieldNumber = 2;

			private ProLabelsDocument labels_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Groups> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Preferences.Descriptor.NestedTypes[3];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ProGroupsDocument Groups_
			{
				get
				{
					return groups_;
				}
				set
				{
					groups_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ProLabelsDocument Labels
			{
				get
				{
					return labels_;
				}
				set
				{
					labels_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Groups()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Groups(Groups other)
				: this()
			{
				groups_ = ((other.groups_ != null) ? other.groups_.Clone() : null);
				labels_ = ((other.labels_ != null) ? other.labels_.Clone() : null);
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Groups Clone()
			{
				return new Groups(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Groups);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Groups other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(Groups_, other.Groups_))
				{
					return false;
				}
				if (!object.Equals(Labels, other.Labels))
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
				if (groups_ != null)
				{
					num ^= Groups_.GetHashCode();
				}
				if (labels_ != null)
				{
					num ^= Labels.GetHashCode();
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
				if (groups_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Groups_);
				}
				if (labels_ != null)
				{
					output.WriteRawTag(18);
					output.WriteMessage(Labels);
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
				if (groups_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Groups_);
				}
				if (labels_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Labels);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(Groups other)
			{
				if (other == null)
				{
					return;
				}
				if (other.groups_ != null)
				{
					if (groups_ == null)
					{
						Groups_ = new ProGroupsDocument();
					}
					Groups_.MergeFrom(other.Groups_);
				}
				if (other.labels_ != null)
				{
					if (labels_ == null)
					{
						Labels = new ProLabelsDocument();
					}
					Labels.MergeFrom(other.Labels);
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
						if (groups_ == null)
						{
							Groups_ = new ProGroupsDocument();
						}
						input.ReadMessage(Groups_);
						break;
					case 18u:
						if (labels_ == null)
						{
							Labels = new ProLabelsDocument();
						}
						input.ReadMessage(Labels);
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Network : IMessage<Network>, IMessage, IEquatable<Network>, IDeepCloneable<Network>
		{
			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class Network : IMessage<Network>, IMessage, IEquatable<Network>, IDeepCloneable<Network>
				{
					private static readonly MessageParser<Network> _parser = new MessageParser<Network>(() => new Network());

					private UnknownFieldSet _unknownFields;

					public const int EnableFieldNumber = 1;

					private bool enable_;

					public const int NameFieldNumber = 2;

					private string name_ = "";

					public const int PortFieldNumber = 3;

					private uint port_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<Network> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => Preferences.Types.Network.Descriptor.NestedTypes[0];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Enable
					{
						get
						{
							return enable_;
						}
						set
						{
							enable_ = value;
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
					public uint Port
					{
						get
						{
							return port_;
						}
						set
						{
							port_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Network()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Network(Network other)
						: this()
					{
						enable_ = other.enable_;
						name_ = other.name_;
						port_ = other.port_;
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Network Clone()
					{
						return new Network(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as Network);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(Network other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (Enable != other.Enable)
						{
							return false;
						}
						if (Name != other.Name)
						{
							return false;
						}
						if (Port != other.Port)
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
						if (Enable)
						{
							num ^= Enable.GetHashCode();
						}
						if (Name.Length != 0)
						{
							num ^= Name.GetHashCode();
						}
						if (Port != 0)
						{
							num ^= Port.GetHashCode();
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
						if (Enable)
						{
							output.WriteRawTag(8);
							output.WriteBool(Enable);
						}
						if (Name.Length != 0)
						{
							output.WriteRawTag(18);
							output.WriteString(Name);
						}
						if (Port != 0)
						{
							output.WriteRawTag(24);
							output.WriteUInt32(Port);
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
						if (Enable)
						{
							num += 2;
						}
						if (Name.Length != 0)
						{
							num += 1 + CodedOutputStream.ComputeStringSize(Name);
						}
						if (Port != 0)
						{
							num += 1 + CodedOutputStream.ComputeUInt32Size(Port);
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(Network other)
					{
						if (other != null)
						{
							if (other.Enable)
							{
								Enable = other.Enable;
							}
							if (other.Name.Length != 0)
							{
								Name = other.Name;
							}
							if (other.Port != 0)
							{
								Port = other.Port;
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
								Enable = input.ReadBool();
								break;
							case 18u:
								Name = input.ReadString();
								break;
							case 24u:
								Port = input.ReadUInt32();
								break;
							}
						}
					}
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class Remotes : IMessage<Remotes>, IMessage, IEquatable<Remotes>, IDeepCloneable<Remotes>
				{
					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static class Types
					{
						[DebuggerDisplay("{ToString(),nq}")]
						public sealed class ProRemote : IMessage<ProRemote>, IMessage, IEquatable<ProRemote>, IDeepCloneable<ProRemote>
						{
							private static readonly MessageParser<ProRemote> _parser = new MessageParser<ProRemote>(() => new ProRemote());

							private UnknownFieldSet _unknownFields;

							public const int EnableFieldNumber = 1;

							private bool enable_;

							public const int EnableControllerFieldNumber = 2;

							private bool enableController_;

							public const int ControllerPasswordFieldNumber = 3;

							private string controllerPassword_ = "";

							public const int EnableObserverFieldNumber = 4;

							private bool enableObserver_;

							public const int ObserverPasswordFieldNumber = 5;

							private string observerPassword_ = "";

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageParser<ProRemote> Parser => _parser;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageDescriptor Descriptor => Remotes.Descriptor.NestedTypes[0];

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							MessageDescriptor IMessage.Descriptor => Descriptor;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool Enable
							{
								get
								{
									return enable_;
								}
								set
								{
									enable_ = value;
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool EnableController
							{
								get
								{
									return enableController_;
								}
								set
								{
									enableController_ = value;
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public string ControllerPassword
							{
								get
								{
									return controllerPassword_;
								}
								set
								{
									controllerPassword_ = ProtoPreconditions.CheckNotNull(value, "value");
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool EnableObserver
							{
								get
								{
									return enableObserver_;
								}
								set
								{
									enableObserver_ = value;
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public string ObserverPassword
							{
								get
								{
									return observerPassword_;
								}
								set
								{
									observerPassword_ = ProtoPreconditions.CheckNotNull(value, "value");
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public ProRemote()
							{
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public ProRemote(ProRemote other)
								: this()
							{
								enable_ = other.enable_;
								enableController_ = other.enableController_;
								controllerPassword_ = other.controllerPassword_;
								enableObserver_ = other.enableObserver_;
								observerPassword_ = other.observerPassword_;
								_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public ProRemote Clone()
							{
								return new ProRemote(this);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public override bool Equals(object other)
							{
								return Equals(other as ProRemote);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool Equals(ProRemote other)
							{
								if (other == null)
								{
									return false;
								}
								if (other == this)
								{
									return true;
								}
								if (Enable != other.Enable)
								{
									return false;
								}
								if (EnableController != other.EnableController)
								{
									return false;
								}
								if (ControllerPassword != other.ControllerPassword)
								{
									return false;
								}
								if (EnableObserver != other.EnableObserver)
								{
									return false;
								}
								if (ObserverPassword != other.ObserverPassword)
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
								if (Enable)
								{
									num ^= Enable.GetHashCode();
								}
								if (EnableController)
								{
									num ^= EnableController.GetHashCode();
								}
								if (ControllerPassword.Length != 0)
								{
									num ^= ControllerPassword.GetHashCode();
								}
								if (EnableObserver)
								{
									num ^= EnableObserver.GetHashCode();
								}
								if (ObserverPassword.Length != 0)
								{
									num ^= ObserverPassword.GetHashCode();
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
								if (Enable)
								{
									output.WriteRawTag(8);
									output.WriteBool(Enable);
								}
								if (EnableController)
								{
									output.WriteRawTag(16);
									output.WriteBool(EnableController);
								}
								if (ControllerPassword.Length != 0)
								{
									output.WriteRawTag(26);
									output.WriteString(ControllerPassword);
								}
								if (EnableObserver)
								{
									output.WriteRawTag(32);
									output.WriteBool(EnableObserver);
								}
								if (ObserverPassword.Length != 0)
								{
									output.WriteRawTag(42);
									output.WriteString(ObserverPassword);
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
								if (Enable)
								{
									num += 2;
								}
								if (EnableController)
								{
									num += 2;
								}
								if (ControllerPassword.Length != 0)
								{
									num += 1 + CodedOutputStream.ComputeStringSize(ControllerPassword);
								}
								if (EnableObserver)
								{
									num += 2;
								}
								if (ObserverPassword.Length != 0)
								{
									num += 1 + CodedOutputStream.ComputeStringSize(ObserverPassword);
								}
								if (_unknownFields != null)
								{
									num += _unknownFields.CalculateSize();
								}
								return num;
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public void MergeFrom(ProRemote other)
							{
								if (other != null)
								{
									if (other.Enable)
									{
										Enable = other.Enable;
									}
									if (other.EnableController)
									{
										EnableController = other.EnableController;
									}
									if (other.ControllerPassword.Length != 0)
									{
										ControllerPassword = other.ControllerPassword;
									}
									if (other.EnableObserver)
									{
										EnableObserver = other.EnableObserver;
									}
									if (other.ObserverPassword.Length != 0)
									{
										ObserverPassword = other.ObserverPassword;
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
										Enable = input.ReadBool();
										break;
									case 16u:
										EnableController = input.ReadBool();
										break;
									case 26u:
										ControllerPassword = input.ReadString();
										break;
									case 32u:
										EnableObserver = input.ReadBool();
										break;
									case 42u:
										ObserverPassword = input.ReadString();
										break;
									}
								}
							}
						}

						[DebuggerDisplay("{ToString(),nq}")]
						public sealed class StageApp : IMessage<StageApp>, IMessage, IEquatable<StageApp>, IDeepCloneable<StageApp>
						{
							private static readonly MessageParser<StageApp> _parser = new MessageParser<StageApp>(() => new StageApp());

							private UnknownFieldSet _unknownFields;

							public const int EnableFieldNumber = 1;

							private bool enable_;

							public const int PasswordFieldNumber = 2;

							private string password_ = "";

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageParser<StageApp> Parser => _parser;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageDescriptor Descriptor => Remotes.Descriptor.NestedTypes[1];

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							MessageDescriptor IMessage.Descriptor => Descriptor;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool Enable
							{
								get
								{
									return enable_;
								}
								set
								{
									enable_ = value;
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public string Password
							{
								get
								{
									return password_;
								}
								set
								{
									password_ = ProtoPreconditions.CheckNotNull(value, "value");
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public StageApp()
							{
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public StageApp(StageApp other)
								: this()
							{
								enable_ = other.enable_;
								password_ = other.password_;
								_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public StageApp Clone()
							{
								return new StageApp(this);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public override bool Equals(object other)
							{
								return Equals(other as StageApp);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool Equals(StageApp other)
							{
								if (other == null)
								{
									return false;
								}
								if (other == this)
								{
									return true;
								}
								if (Enable != other.Enable)
								{
									return false;
								}
								if (Password != other.Password)
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
								if (Enable)
								{
									num ^= Enable.GetHashCode();
								}
								if (Password.Length != 0)
								{
									num ^= Password.GetHashCode();
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
								if (Enable)
								{
									output.WriteRawTag(8);
									output.WriteBool(Enable);
								}
								if (Password.Length != 0)
								{
									output.WriteRawTag(18);
									output.WriteString(Password);
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
								if (Enable)
								{
									num += 2;
								}
								if (Password.Length != 0)
								{
									num += 1 + CodedOutputStream.ComputeStringSize(Password);
								}
								if (_unknownFields != null)
								{
									num += _unknownFields.CalculateSize();
								}
								return num;
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public void MergeFrom(StageApp other)
							{
								if (other != null)
								{
									if (other.Enable)
									{
										Enable = other.Enable;
									}
									if (other.Password.Length != 0)
									{
										Password = other.Password;
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
										Enable = input.ReadBool();
										break;
									case 18u:
										Password = input.ReadString();
										break;
									}
								}
							}
						}
					}

					private static readonly MessageParser<Remotes> _parser = new MessageParser<Remotes>(() => new Remotes());

					private UnknownFieldSet _unknownFields;

					public const int ProRemoteFieldNumber = 1;

					private Types.ProRemote proRemote_;

					public const int StageAppFieldNumber = 2;

					private Types.StageApp stageApp_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<Remotes> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => Preferences.Types.Network.Descriptor.NestedTypes[1];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Types.ProRemote ProRemote
					{
						get
						{
							return proRemote_;
						}
						set
						{
							proRemote_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Types.StageApp StageApp
					{
						get
						{
							return stageApp_;
						}
						set
						{
							stageApp_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Remotes()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Remotes(Remotes other)
						: this()
					{
						proRemote_ = ((other.proRemote_ != null) ? other.proRemote_.Clone() : null);
						stageApp_ = ((other.stageApp_ != null) ? other.stageApp_.Clone() : null);
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Remotes Clone()
					{
						return new Remotes(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as Remotes);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(Remotes other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (!object.Equals(ProRemote, other.ProRemote))
						{
							return false;
						}
						if (!object.Equals(StageApp, other.StageApp))
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
						if (proRemote_ != null)
						{
							num ^= ProRemote.GetHashCode();
						}
						if (stageApp_ != null)
						{
							num ^= StageApp.GetHashCode();
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
						if (proRemote_ != null)
						{
							output.WriteRawTag(10);
							output.WriteMessage(ProRemote);
						}
						if (stageApp_ != null)
						{
							output.WriteRawTag(18);
							output.WriteMessage(StageApp);
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
						if (proRemote_ != null)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(ProRemote);
						}
						if (stageApp_ != null)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(StageApp);
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(Remotes other)
					{
						if (other == null)
						{
							return;
						}
						if (other.proRemote_ != null)
						{
							if (proRemote_ == null)
							{
								ProRemote = new Types.ProRemote();
							}
							ProRemote.MergeFrom(other.ProRemote);
						}
						if (other.stageApp_ != null)
						{
							if (stageApp_ == null)
							{
								StageApp = new Types.StageApp();
							}
							StageApp.MergeFrom(other.StageApp);
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
								if (proRemote_ == null)
								{
									ProRemote = new Types.ProRemote();
								}
								input.ReadMessage(ProRemote);
								break;
							case 18u:
								if (stageApp_ == null)
								{
									StageApp = new Types.StageApp();
								}
								input.ReadMessage(StageApp);
								break;
							}
						}
					}
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class Link : IMessage<Link>, IMessage, IEquatable<Link>, IDeepCloneable<Link>
				{
					private static readonly MessageParser<Link> _parser = new MessageParser<Link>(() => new Link());

					private UnknownFieldSet _unknownFields;

					public const int EnableFieldNumber = 1;

					private bool enable_;

					public const int LinkGroupFieldNumber = 2;

					private string linkGroup_ = "";

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<Link> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => Preferences.Types.Network.Descriptor.NestedTypes[2];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Enable
					{
						get
						{
							return enable_;
						}
						set
						{
							enable_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public string LinkGroup
					{
						get
						{
							return linkGroup_;
						}
						set
						{
							linkGroup_ = ProtoPreconditions.CheckNotNull(value, "value");
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Link()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Link(Link other)
						: this()
					{
						enable_ = other.enable_;
						linkGroup_ = other.linkGroup_;
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Link Clone()
					{
						return new Link(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as Link);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(Link other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (Enable != other.Enable)
						{
							return false;
						}
						if (LinkGroup != other.LinkGroup)
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
						if (Enable)
						{
							num ^= Enable.GetHashCode();
						}
						if (LinkGroup.Length != 0)
						{
							num ^= LinkGroup.GetHashCode();
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
						if (Enable)
						{
							output.WriteRawTag(8);
							output.WriteBool(Enable);
						}
						if (LinkGroup.Length != 0)
						{
							output.WriteRawTag(18);
							output.WriteString(LinkGroup);
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
						if (Enable)
						{
							num += 2;
						}
						if (LinkGroup.Length != 0)
						{
							num += 1 + CodedOutputStream.ComputeStringSize(LinkGroup);
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(Link other)
					{
						if (other != null)
						{
							if (other.Enable)
							{
								Enable = other.Enable;
							}
							if (other.LinkGroup.Length != 0)
							{
								LinkGroup = other.LinkGroup;
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
								Enable = input.ReadBool();
								break;
							case 18u:
								LinkGroup = input.ReadString();
								break;
							}
						}
					}
				}
			}

			private static readonly MessageParser<Network> _parser = new MessageParser<Network>(() => new Network());

			private UnknownFieldSet _unknownFields;

			public const int Network_FieldNumber = 1;

			private Types.Network network_;

			public const int RemotesFieldNumber = 2;

			private Types.Remotes remotes_;

			public const int LinkFieldNumber = 3;

			private Types.Link link_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Network> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Preferences.Descriptor.NestedTypes[4];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.Network Network_
			{
				get
				{
					return network_;
				}
				set
				{
					network_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.Remotes Remotes
			{
				get
				{
					return remotes_;
				}
				set
				{
					remotes_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.Link Link
			{
				get
				{
					return link_;
				}
				set
				{
					link_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Network()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Network(Network other)
				: this()
			{
				network_ = ((other.network_ != null) ? other.network_.Clone() : null);
				remotes_ = ((other.remotes_ != null) ? other.remotes_.Clone() : null);
				link_ = ((other.link_ != null) ? other.link_.Clone() : null);
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Network Clone()
			{
				return new Network(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Network);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Network other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(Network_, other.Network_))
				{
					return false;
				}
				if (!object.Equals(Remotes, other.Remotes))
				{
					return false;
				}
				if (!object.Equals(Link, other.Link))
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
				if (network_ != null)
				{
					num ^= Network_.GetHashCode();
				}
				if (remotes_ != null)
				{
					num ^= Remotes.GetHashCode();
				}
				if (link_ != null)
				{
					num ^= Link.GetHashCode();
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
				if (network_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Network_);
				}
				if (remotes_ != null)
				{
					output.WriteRawTag(18);
					output.WriteMessage(Remotes);
				}
				if (link_ != null)
				{
					output.WriteRawTag(26);
					output.WriteMessage(Link);
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
				if (network_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Network_);
				}
				if (remotes_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Remotes);
				}
				if (link_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Link);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(Network other)
			{
				if (other == null)
				{
					return;
				}
				if (other.network_ != null)
				{
					if (network_ == null)
					{
						Network_ = new Types.Network();
					}
					Network_.MergeFrom(other.Network_);
				}
				if (other.remotes_ != null)
				{
					if (remotes_ == null)
					{
						Remotes = new Types.Remotes();
					}
					Remotes.MergeFrom(other.Remotes);
				}
				if (other.link_ != null)
				{
					if (link_ == null)
					{
						Link = new Types.Link();
					}
					Link.MergeFrom(other.Link);
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
						if (network_ == null)
						{
							Network_ = new Types.Network();
						}
						input.ReadMessage(Network_);
						break;
					case 18u:
						if (remotes_ == null)
						{
							Remotes = new Types.Remotes();
						}
						input.ReadMessage(Remotes);
						break;
					case 26u:
						if (link_ == null)
						{
							Link = new Types.Link();
						}
						input.ReadMessage(Link);
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Sync : IMessage<Sync>, IMessage, IEquatable<Sync>, IDeepCloneable<Sync>
		{
			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				public enum SyncDirection
				{
					[OriginalName("SYNC_DOWN")]
					SyncDown,
					[OriginalName("SYNC_UP")]
					SyncUp
				}
			}

			private static readonly MessageParser<Sync> _parser = new MessageParser<Sync>(() => new Sync());

			private UnknownFieldSet _unknownFields;

			public const int RepositoryFieldNumber = 1;

			private string repository_ = "";

			public const int IncludeLibrariesFieldNumber = 2;

			private bool includeLibraries_;

			public const int IncludeMediaFieldNumber = 3;

			private bool includeMedia_;

			public const int IncludePlaylistsFieldNumber = 4;

			private bool includePlaylists_;

			public const int IncludeThemesFieldNumber = 5;

			private bool includeThemes_;

			public const int IncludeSupportFilesFieldNumber = 6;

			private bool includeSupportFiles_;

			public const int DirectionFieldNumber = 7;

			private Types.SyncDirection direction_;

			public const int ReplaceDestinationFilesFieldNumber = 8;

			private bool replaceDestinationFiles_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Sync> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Preferences.Descriptor.NestedTypes[5];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string Repository
			{
				get
				{
					return repository_;
				}
				set
				{
					repository_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool IncludeLibraries
			{
				get
				{
					return includeLibraries_;
				}
				set
				{
					includeLibraries_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool IncludeMedia
			{
				get
				{
					return includeMedia_;
				}
				set
				{
					includeMedia_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool IncludePlaylists
			{
				get
				{
					return includePlaylists_;
				}
				set
				{
					includePlaylists_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool IncludeThemes
			{
				get
				{
					return includeThemes_;
				}
				set
				{
					includeThemes_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool IncludeSupportFiles
			{
				get
				{
					return includeSupportFiles_;
				}
				set
				{
					includeSupportFiles_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.SyncDirection Direction
			{
				get
				{
					return direction_;
				}
				set
				{
					direction_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool ReplaceDestinationFiles
			{
				get
				{
					return replaceDestinationFiles_;
				}
				set
				{
					replaceDestinationFiles_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Sync()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Sync(Sync other)
				: this()
			{
				repository_ = other.repository_;
				includeLibraries_ = other.includeLibraries_;
				includeMedia_ = other.includeMedia_;
				includePlaylists_ = other.includePlaylists_;
				includeThemes_ = other.includeThemes_;
				includeSupportFiles_ = other.includeSupportFiles_;
				direction_ = other.direction_;
				replaceDestinationFiles_ = other.replaceDestinationFiles_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Sync Clone()
			{
				return new Sync(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Sync);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Sync other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (Repository != other.Repository)
				{
					return false;
				}
				if (IncludeLibraries != other.IncludeLibraries)
				{
					return false;
				}
				if (IncludeMedia != other.IncludeMedia)
				{
					return false;
				}
				if (IncludePlaylists != other.IncludePlaylists)
				{
					return false;
				}
				if (IncludeThemes != other.IncludeThemes)
				{
					return false;
				}
				if (IncludeSupportFiles != other.IncludeSupportFiles)
				{
					return false;
				}
				if (Direction != other.Direction)
				{
					return false;
				}
				if (ReplaceDestinationFiles != other.ReplaceDestinationFiles)
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
				if (Repository.Length != 0)
				{
					num ^= Repository.GetHashCode();
				}
				if (IncludeLibraries)
				{
					num ^= IncludeLibraries.GetHashCode();
				}
				if (IncludeMedia)
				{
					num ^= IncludeMedia.GetHashCode();
				}
				if (IncludePlaylists)
				{
					num ^= IncludePlaylists.GetHashCode();
				}
				if (IncludeThemes)
				{
					num ^= IncludeThemes.GetHashCode();
				}
				if (IncludeSupportFiles)
				{
					num ^= IncludeSupportFiles.GetHashCode();
				}
				if (Direction != 0)
				{
					num ^= Direction.GetHashCode();
				}
				if (ReplaceDestinationFiles)
				{
					num ^= ReplaceDestinationFiles.GetHashCode();
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
				if (Repository.Length != 0)
				{
					output.WriteRawTag(10);
					output.WriteString(Repository);
				}
				if (IncludeLibraries)
				{
					output.WriteRawTag(16);
					output.WriteBool(IncludeLibraries);
				}
				if (IncludeMedia)
				{
					output.WriteRawTag(24);
					output.WriteBool(IncludeMedia);
				}
				if (IncludePlaylists)
				{
					output.WriteRawTag(32);
					output.WriteBool(IncludePlaylists);
				}
				if (IncludeThemes)
				{
					output.WriteRawTag(40);
					output.WriteBool(IncludeThemes);
				}
				if (IncludeSupportFiles)
				{
					output.WriteRawTag(48);
					output.WriteBool(IncludeSupportFiles);
				}
				if (Direction != 0)
				{
					output.WriteRawTag(56);
					output.WriteEnum((int)Direction);
				}
				if (ReplaceDestinationFiles)
				{
					output.WriteRawTag(64);
					output.WriteBool(ReplaceDestinationFiles);
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
				if (Repository.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Repository);
				}
				if (IncludeLibraries)
				{
					num += 2;
				}
				if (IncludeMedia)
				{
					num += 2;
				}
				if (IncludePlaylists)
				{
					num += 2;
				}
				if (IncludeThemes)
				{
					num += 2;
				}
				if (IncludeSupportFiles)
				{
					num += 2;
				}
				if (Direction != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)Direction);
				}
				if (ReplaceDestinationFiles)
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
			public void MergeFrom(Sync other)
			{
				if (other != null)
				{
					if (other.Repository.Length != 0)
					{
						Repository = other.Repository;
					}
					if (other.IncludeLibraries)
					{
						IncludeLibraries = other.IncludeLibraries;
					}
					if (other.IncludeMedia)
					{
						IncludeMedia = other.IncludeMedia;
					}
					if (other.IncludePlaylists)
					{
						IncludePlaylists = other.IncludePlaylists;
					}
					if (other.IncludeThemes)
					{
						IncludeThemes = other.IncludeThemes;
					}
					if (other.IncludeSupportFiles)
					{
						IncludeSupportFiles = other.IncludeSupportFiles;
					}
					if (other.Direction != 0)
					{
						Direction = other.Direction;
					}
					if (other.ReplaceDestinationFiles)
					{
						ReplaceDestinationFiles = other.ReplaceDestinationFiles;
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
						Repository = input.ReadString();
						break;
					case 16u:
						IncludeLibraries = input.ReadBool();
						break;
					case 24u:
						IncludeMedia = input.ReadBool();
						break;
					case 32u:
						IncludePlaylists = input.ReadBool();
						break;
					case 40u:
						IncludeThemes = input.ReadBool();
						break;
					case 48u:
						IncludeSupportFiles = input.ReadBool();
						break;
					case 56u:
						Direction = (Types.SyncDirection)input.ReadEnum();
						break;
					case 64u:
						ReplaceDestinationFiles = input.ReadBool();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Advanced : IMessage<Advanced>, IMessage, IEquatable<Advanced>, IDeepCloneable<Advanced>
		{
			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				public enum AudioForegroundMediaBehavior
				{
					[OriginalName("IGNORE_FOREGROUND_MEDIA")]
					IgnoreForegroundMedia,
					[OriginalName("CLEAR_FOR_ALL_MEDIA")]
					ClearForAllMedia,
					[OriginalName("CLEAR_IF_AUDIO")]
					ClearIfAudio,
					[OriginalName("PAUSE_FOR_ALL_MEDIA")]
					PauseForAllMedia,
					[OriginalName("PAUSE_IF_AUDIO")]
					PauseIfAudio
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class NDIDiscovery : IMessage<NDIDiscovery>, IMessage, IEquatable<NDIDiscovery>, IDeepCloneable<NDIDiscovery>
				{
					private static readonly MessageParser<NDIDiscovery> _parser = new MessageParser<NDIDiscovery>(() => new NDIDiscovery());

					private UnknownFieldSet _unknownFields;

					public const int ShowLocalSourcesFieldNumber = 1;

					private bool showLocalSources_;

					public const int ReceiveGroupsFieldNumber = 2;

					private string receiveGroups_ = "";

					public const int AdditionalSearchIpsFieldNumber = 3;

					private string additionalSearchIps_ = "";

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<NDIDiscovery> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => Advanced.Descriptor.NestedTypes[0];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool ShowLocalSources
					{
						get
						{
							return showLocalSources_;
						}
						set
						{
							showLocalSources_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public string ReceiveGroups
					{
						get
						{
							return receiveGroups_;
						}
						set
						{
							receiveGroups_ = ProtoPreconditions.CheckNotNull(value, "value");
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public string AdditionalSearchIps
					{
						get
						{
							return additionalSearchIps_;
						}
						set
						{
							additionalSearchIps_ = ProtoPreconditions.CheckNotNull(value, "value");
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public NDIDiscovery()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public NDIDiscovery(NDIDiscovery other)
						: this()
					{
						showLocalSources_ = other.showLocalSources_;
						receiveGroups_ = other.receiveGroups_;
						additionalSearchIps_ = other.additionalSearchIps_;
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public NDIDiscovery Clone()
					{
						return new NDIDiscovery(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as NDIDiscovery);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(NDIDiscovery other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (ShowLocalSources != other.ShowLocalSources)
						{
							return false;
						}
						if (ReceiveGroups != other.ReceiveGroups)
						{
							return false;
						}
						if (AdditionalSearchIps != other.AdditionalSearchIps)
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
						if (ShowLocalSources)
						{
							num ^= ShowLocalSources.GetHashCode();
						}
						if (ReceiveGroups.Length != 0)
						{
							num ^= ReceiveGroups.GetHashCode();
						}
						if (AdditionalSearchIps.Length != 0)
						{
							num ^= AdditionalSearchIps.GetHashCode();
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
						if (ShowLocalSources)
						{
							output.WriteRawTag(8);
							output.WriteBool(ShowLocalSources);
						}
						if (ReceiveGroups.Length != 0)
						{
							output.WriteRawTag(18);
							output.WriteString(ReceiveGroups);
						}
						if (AdditionalSearchIps.Length != 0)
						{
							output.WriteRawTag(26);
							output.WriteString(AdditionalSearchIps);
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
						if (ShowLocalSources)
						{
							num += 2;
						}
						if (ReceiveGroups.Length != 0)
						{
							num += 1 + CodedOutputStream.ComputeStringSize(ReceiveGroups);
						}
						if (AdditionalSearchIps.Length != 0)
						{
							num += 1 + CodedOutputStream.ComputeStringSize(AdditionalSearchIps);
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(NDIDiscovery other)
					{
						if (other != null)
						{
							if (other.ShowLocalSources)
							{
								ShowLocalSources = other.ShowLocalSources;
							}
							if (other.ReceiveGroups.Length != 0)
							{
								ReceiveGroups = other.ReceiveGroups;
							}
							if (other.AdditionalSearchIps.Length != 0)
							{
								AdditionalSearchIps = other.AdditionalSearchIps;
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
								ShowLocalSources = input.ReadBool();
								break;
							case 18u:
								ReceiveGroups = input.ReadString();
								break;
							case 26u:
								AdditionalSearchIps = input.ReadString();
								break;
							}
						}
					}
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class SearchPaths : IMessage<SearchPaths>, IMessage, IEquatable<SearchPaths>, IDeepCloneable<SearchPaths>
				{
					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static class Types
					{
						[DebuggerDisplay("{ToString(),nq}")]
						public sealed class Path : IMessage<Path>, IMessage, IEquatable<Path>, IDeepCloneable<Path>
						{
							private static readonly MessageParser<Path> _parser = new MessageParser<Path>(() => new Path());

							private UnknownFieldSet _unknownFields;

							public const int EnableFieldNumber = 1;

							private bool enable_;

							public const int NameFieldNumber = 2;

							private string name_ = "";

							public const int Path_FieldNumber = 3;

							private string path_ = "";

							public const int UrlRootFieldNumber = 4;

							private URL.Types.LocalRelativePath.Types.Root urlRoot_;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageParser<Path> Parser => _parser;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageDescriptor Descriptor => SearchPaths.Descriptor.NestedTypes[0];

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							MessageDescriptor IMessage.Descriptor => Descriptor;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool Enable
							{
								get
								{
									return enable_;
								}
								set
								{
									enable_ = value;
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
							public string Path_
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
							public URL.Types.LocalRelativePath.Types.Root UrlRoot
							{
								get
								{
									return urlRoot_;
								}
								set
								{
									urlRoot_ = value;
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Path()
							{
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Path(Path other)
								: this()
							{
								enable_ = other.enable_;
								name_ = other.name_;
								path_ = other.path_;
								urlRoot_ = other.urlRoot_;
								_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Path Clone()
							{
								return new Path(this);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public override bool Equals(object other)
							{
								return Equals(other as Path);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool Equals(Path other)
							{
								if (other == null)
								{
									return false;
								}
								if (other == this)
								{
									return true;
								}
								if (Enable != other.Enable)
								{
									return false;
								}
								if (Name != other.Name)
								{
									return false;
								}
								if (Path_ != other.Path_)
								{
									return false;
								}
								if (UrlRoot != other.UrlRoot)
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
								if (Enable)
								{
									num ^= Enable.GetHashCode();
								}
								if (Name.Length != 0)
								{
									num ^= Name.GetHashCode();
								}
								if (Path_.Length != 0)
								{
									num ^= Path_.GetHashCode();
								}
								if (UrlRoot != 0)
								{
									num ^= UrlRoot.GetHashCode();
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
								if (Enable)
								{
									output.WriteRawTag(8);
									output.WriteBool(Enable);
								}
								if (Name.Length != 0)
								{
									output.WriteRawTag(18);
									output.WriteString(Name);
								}
								if (Path_.Length != 0)
								{
									output.WriteRawTag(26);
									output.WriteString(Path_);
								}
								if (UrlRoot != 0)
								{
									output.WriteRawTag(32);
									output.WriteEnum((int)UrlRoot);
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
								if (Enable)
								{
									num += 2;
								}
								if (Name.Length != 0)
								{
									num += 1 + CodedOutputStream.ComputeStringSize(Name);
								}
								if (Path_.Length != 0)
								{
									num += 1 + CodedOutputStream.ComputeStringSize(Path_);
								}
								if (UrlRoot != 0)
								{
									num += 1 + CodedOutputStream.ComputeEnumSize((int)UrlRoot);
								}
								if (_unknownFields != null)
								{
									num += _unknownFields.CalculateSize();
								}
								return num;
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public void MergeFrom(Path other)
							{
								if (other != null)
								{
									if (other.Enable)
									{
										Enable = other.Enable;
									}
									if (other.Name.Length != 0)
									{
										Name = other.Name;
									}
									if (other.Path_.Length != 0)
									{
										Path_ = other.Path_;
									}
									if (other.UrlRoot != 0)
									{
										UrlRoot = other.UrlRoot;
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
										Enable = input.ReadBool();
										break;
									case 18u:
										Name = input.ReadString();
										break;
									case 26u:
										Path_ = input.ReadString();
										break;
									case 32u:
										UrlRoot = (URL.Types.LocalRelativePath.Types.Root)input.ReadEnum();
										break;
									}
								}
							}
						}
					}

					private static readonly MessageParser<SearchPaths> _parser = new MessageParser<SearchPaths>(() => new SearchPaths());

					private UnknownFieldSet _unknownFields;

					public const int AutomaticallyRelinkFieldNumber = 1;

					private bool automaticallyRelink_;

					public const int PathsFieldNumber = 2;

					private static readonly FieldCodec<Types.Path> _repeated_paths_codec = FieldCodec.ForMessage(18u, Types.Path.Parser);

					private readonly RepeatedField<Types.Path> paths_ = new RepeatedField<Types.Path>();

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<SearchPaths> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => Advanced.Descriptor.NestedTypes[1];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool AutomaticallyRelink
					{
						get
						{
							return automaticallyRelink_;
						}
						set
						{
							automaticallyRelink_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public RepeatedField<Types.Path> Paths => paths_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public SearchPaths()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public SearchPaths(SearchPaths other)
						: this()
					{
						automaticallyRelink_ = other.automaticallyRelink_;
						paths_ = other.paths_.Clone();
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public SearchPaths Clone()
					{
						return new SearchPaths(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as SearchPaths);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(SearchPaths other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (AutomaticallyRelink != other.AutomaticallyRelink)
						{
							return false;
						}
						if (!paths_.Equals(other.paths_))
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
						if (AutomaticallyRelink)
						{
							num ^= AutomaticallyRelink.GetHashCode();
						}
						num ^= paths_.GetHashCode();
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
						if (AutomaticallyRelink)
						{
							output.WriteRawTag(8);
							output.WriteBool(AutomaticallyRelink);
						}
						paths_.WriteTo(output, _repeated_paths_codec);
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
						if (AutomaticallyRelink)
						{
							num += 2;
						}
						num += paths_.CalculateSize(_repeated_paths_codec);
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(SearchPaths other)
					{
						if (other != null)
						{
							if (other.AutomaticallyRelink)
							{
								AutomaticallyRelink = other.AutomaticallyRelink;
							}
							paths_.Add(other.paths_);
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
								AutomaticallyRelink = input.ReadBool();
								break;
							case 18u:
								paths_.AddEntriesFrom(input, _repeated_paths_codec);
								break;
							}
						}
					}
				}
			}

			private static readonly MessageParser<Advanced> _parser = new MessageParser<Advanced>(() => new Advanced());

			private UnknownFieldSet _unknownFields;

			public const int SuppressAutoStartFieldNumber = 1;

			private bool suppressAutoStart_;

			public const int PresentationAudioBehaviorFieldNumber = 2;

			private Types.AudioForegroundMediaBehavior presentationAudioBehavior_;

			public const int AnnouncementsAudioBehaviorFieldNumber = 3;

			private Types.AudioForegroundMediaBehavior announcementsAudioBehavior_;

			public const int NdiDiscoveryFieldNumber = 4;

			private Types.NDIDiscovery ndiDiscovery_;

			public const int SupportFilesPathFieldNumber = 5;

			private string supportFilesPath_ = "";

			public const int ManageMediaAutomaticallyFieldNumber = 6;

			private bool manageMediaAutomatically_;

			public const int SearchPathsFieldNumber = 7;

			private Types.SearchPaths searchPaths_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Advanced> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Preferences.Descriptor.NestedTypes[6];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool SuppressAutoStart
			{
				get
				{
					return suppressAutoStart_;
				}
				set
				{
					suppressAutoStart_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.AudioForegroundMediaBehavior PresentationAudioBehavior
			{
				get
				{
					return presentationAudioBehavior_;
				}
				set
				{
					presentationAudioBehavior_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.AudioForegroundMediaBehavior AnnouncementsAudioBehavior
			{
				get
				{
					return announcementsAudioBehavior_;
				}
				set
				{
					announcementsAudioBehavior_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.NDIDiscovery NdiDiscovery
			{
				get
				{
					return ndiDiscovery_;
				}
				set
				{
					ndiDiscovery_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string SupportFilesPath
			{
				get
				{
					return supportFilesPath_;
				}
				set
				{
					supportFilesPath_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool ManageMediaAutomatically
			{
				get
				{
					return manageMediaAutomatically_;
				}
				set
				{
					manageMediaAutomatically_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.SearchPaths SearchPaths
			{
				get
				{
					return searchPaths_;
				}
				set
				{
					searchPaths_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Advanced()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Advanced(Advanced other)
				: this()
			{
				suppressAutoStart_ = other.suppressAutoStart_;
				presentationAudioBehavior_ = other.presentationAudioBehavior_;
				announcementsAudioBehavior_ = other.announcementsAudioBehavior_;
				ndiDiscovery_ = ((other.ndiDiscovery_ != null) ? other.ndiDiscovery_.Clone() : null);
				supportFilesPath_ = other.supportFilesPath_;
				manageMediaAutomatically_ = other.manageMediaAutomatically_;
				searchPaths_ = ((other.searchPaths_ != null) ? other.searchPaths_.Clone() : null);
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Advanced Clone()
			{
				return new Advanced(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Advanced);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Advanced other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (SuppressAutoStart != other.SuppressAutoStart)
				{
					return false;
				}
				if (PresentationAudioBehavior != other.PresentationAudioBehavior)
				{
					return false;
				}
				if (AnnouncementsAudioBehavior != other.AnnouncementsAudioBehavior)
				{
					return false;
				}
				if (!object.Equals(NdiDiscovery, other.NdiDiscovery))
				{
					return false;
				}
				if (SupportFilesPath != other.SupportFilesPath)
				{
					return false;
				}
				if (ManageMediaAutomatically != other.ManageMediaAutomatically)
				{
					return false;
				}
				if (!object.Equals(SearchPaths, other.SearchPaths))
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
				if (SuppressAutoStart)
				{
					num ^= SuppressAutoStart.GetHashCode();
				}
				if (PresentationAudioBehavior != 0)
				{
					num ^= PresentationAudioBehavior.GetHashCode();
				}
				if (AnnouncementsAudioBehavior != 0)
				{
					num ^= AnnouncementsAudioBehavior.GetHashCode();
				}
				if (ndiDiscovery_ != null)
				{
					num ^= NdiDiscovery.GetHashCode();
				}
				if (SupportFilesPath.Length != 0)
				{
					num ^= SupportFilesPath.GetHashCode();
				}
				if (ManageMediaAutomatically)
				{
					num ^= ManageMediaAutomatically.GetHashCode();
				}
				if (searchPaths_ != null)
				{
					num ^= SearchPaths.GetHashCode();
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
				if (SuppressAutoStart)
				{
					output.WriteRawTag(8);
					output.WriteBool(SuppressAutoStart);
				}
				if (PresentationAudioBehavior != 0)
				{
					output.WriteRawTag(16);
					output.WriteEnum((int)PresentationAudioBehavior);
				}
				if (AnnouncementsAudioBehavior != 0)
				{
					output.WriteRawTag(24);
					output.WriteEnum((int)AnnouncementsAudioBehavior);
				}
				if (ndiDiscovery_ != null)
				{
					output.WriteRawTag(34);
					output.WriteMessage(NdiDiscovery);
				}
				if (SupportFilesPath.Length != 0)
				{
					output.WriteRawTag(42);
					output.WriteString(SupportFilesPath);
				}
				if (ManageMediaAutomatically)
				{
					output.WriteRawTag(48);
					output.WriteBool(ManageMediaAutomatically);
				}
				if (searchPaths_ != null)
				{
					output.WriteRawTag(58);
					output.WriteMessage(SearchPaths);
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
				if (SuppressAutoStart)
				{
					num += 2;
				}
				if (PresentationAudioBehavior != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)PresentationAudioBehavior);
				}
				if (AnnouncementsAudioBehavior != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)AnnouncementsAudioBehavior);
				}
				if (ndiDiscovery_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(NdiDiscovery);
				}
				if (SupportFilesPath.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(SupportFilesPath);
				}
				if (ManageMediaAutomatically)
				{
					num += 2;
				}
				if (searchPaths_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(SearchPaths);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(Advanced other)
			{
				if (other == null)
				{
					return;
				}
				if (other.SuppressAutoStart)
				{
					SuppressAutoStart = other.SuppressAutoStart;
				}
				if (other.PresentationAudioBehavior != 0)
				{
					PresentationAudioBehavior = other.PresentationAudioBehavior;
				}
				if (other.AnnouncementsAudioBehavior != 0)
				{
					AnnouncementsAudioBehavior = other.AnnouncementsAudioBehavior;
				}
				if (other.ndiDiscovery_ != null)
				{
					if (ndiDiscovery_ == null)
					{
						NdiDiscovery = new Types.NDIDiscovery();
					}
					NdiDiscovery.MergeFrom(other.NdiDiscovery);
				}
				if (other.SupportFilesPath.Length != 0)
				{
					SupportFilesPath = other.SupportFilesPath;
				}
				if (other.ManageMediaAutomatically)
				{
					ManageMediaAutomatically = other.ManageMediaAutomatically;
				}
				if (other.searchPaths_ != null)
				{
					if (searchPaths_ == null)
					{
						SearchPaths = new Types.SearchPaths();
					}
					SearchPaths.MergeFrom(other.SearchPaths);
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
					case 8u:
						SuppressAutoStart = input.ReadBool();
						break;
					case 16u:
						PresentationAudioBehavior = (Types.AudioForegroundMediaBehavior)input.ReadEnum();
						break;
					case 24u:
						AnnouncementsAudioBehavior = (Types.AudioForegroundMediaBehavior)input.ReadEnum();
						break;
					case 34u:
						if (ndiDiscovery_ == null)
						{
							NdiDiscovery = new Types.NDIDiscovery();
						}
						input.ReadMessage(NdiDiscovery);
						break;
					case 42u:
						SupportFilesPath = input.ReadString();
						break;
					case 48u:
						ManageMediaAutomatically = input.ReadBool();
						break;
					case 58u:
						if (searchPaths_ == null)
						{
							SearchPaths = new Types.SearchPaths();
						}
						input.ReadMessage(SearchPaths);
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Updates : IMessage<Updates>, IMessage, IEquatable<Updates>, IDeepCloneable<Updates>
		{
			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				public enum Channel
				{
					[OriginalName("production")]
					Production,
					[OriginalName("beta")]
					Beta
				}
			}

			private static readonly MessageParser<Updates> _parser = new MessageParser<Updates>(() => new Updates());

			private UnknownFieldSet _unknownFields;

			public const int NotifyWhenAvailableFieldNumber = 1;

			private bool notifyWhenAvailable_;

			public const int UpdateChannelFieldNumber = 2;

			private Types.Channel updateChannel_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Updates> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Preferences.Descriptor.NestedTypes[7];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool NotifyWhenAvailable
			{
				get
				{
					return notifyWhenAvailable_;
				}
				set
				{
					notifyWhenAvailable_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.Channel UpdateChannel
			{
				get
				{
					return updateChannel_;
				}
				set
				{
					updateChannel_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Updates()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Updates(Updates other)
				: this()
			{
				notifyWhenAvailable_ = other.notifyWhenAvailable_;
				updateChannel_ = other.updateChannel_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Updates Clone()
			{
				return new Updates(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Updates);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Updates other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (NotifyWhenAvailable != other.NotifyWhenAvailable)
				{
					return false;
				}
				if (UpdateChannel != other.UpdateChannel)
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
				if (NotifyWhenAvailable)
				{
					num ^= NotifyWhenAvailable.GetHashCode();
				}
				if (UpdateChannel != 0)
				{
					num ^= UpdateChannel.GetHashCode();
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
				if (NotifyWhenAvailable)
				{
					output.WriteRawTag(8);
					output.WriteBool(NotifyWhenAvailable);
				}
				if (UpdateChannel != 0)
				{
					output.WriteRawTag(16);
					output.WriteEnum((int)UpdateChannel);
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
				if (NotifyWhenAvailable)
				{
					num += 2;
				}
				if (UpdateChannel != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)UpdateChannel);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(Updates other)
			{
				if (other != null)
				{
					if (other.NotifyWhenAvailable)
					{
						NotifyWhenAvailable = other.NotifyWhenAvailable;
					}
					if (other.UpdateChannel != 0)
					{
						UpdateChannel = other.UpdateChannel;
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
						NotifyWhenAvailable = input.ReadBool();
						break;
					case 16u:
						UpdateChannel = (Types.Channel)input.ReadEnum();
						break;
					}
				}
			}
		}
	}

	private static readonly MessageParser<Preferences> _parser = new MessageParser<Preferences>(() => new Preferences());

	private UnknownFieldSet _unknownFields;

	public const int GeneralFieldNumber = 1;

	private Types.General general_;

	public const int ScreensFieldNumber = 2;

	private Types.Screens screens_;

	public const int ImportFieldNumber = 3;

	private Types.Import import_;

	public const int GroupsFieldNumber = 4;

	private Types.Groups groups_;

	public const int NetworkFieldNumber = 5;

	private Types.Network network_;

	public const int SyncFieldNumber = 6;

	private Types.Sync sync_;

	public const int AdvancedFieldNumber = 7;

	private Types.Advanced advanced_;

	public const int UpdatesFieldNumber = 8;

	private Types.Updates updates_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<Preferences> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => PreferencesReflection.Descriptor.MessageTypes[0];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.General General
	{
		get
		{
			return general_;
		}
		set
		{
			general_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Screens Screens
	{
		get
		{
			return screens_;
		}
		set
		{
			screens_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Import Import
	{
		get
		{
			return import_;
		}
		set
		{
			import_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Groups Groups
	{
		get
		{
			return groups_;
		}
		set
		{
			groups_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Network Network
	{
		get
		{
			return network_;
		}
		set
		{
			network_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Sync Sync
	{
		get
		{
			return sync_;
		}
		set
		{
			sync_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Advanced Advanced
	{
		get
		{
			return advanced_;
		}
		set
		{
			advanced_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Updates Updates
	{
		get
		{
			return updates_;
		}
		set
		{
			updates_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Preferences()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Preferences(Preferences other)
		: this()
	{
		general_ = ((other.general_ != null) ? other.general_.Clone() : null);
		screens_ = ((other.screens_ != null) ? other.screens_.Clone() : null);
		import_ = ((other.import_ != null) ? other.import_.Clone() : null);
		groups_ = ((other.groups_ != null) ? other.groups_.Clone() : null);
		network_ = ((other.network_ != null) ? other.network_.Clone() : null);
		sync_ = ((other.sync_ != null) ? other.sync_.Clone() : null);
		advanced_ = ((other.advanced_ != null) ? other.advanced_.Clone() : null);
		updates_ = ((other.updates_ != null) ? other.updates_.Clone() : null);
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Preferences Clone()
	{
		return new Preferences(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as Preferences);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(Preferences other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(General, other.General))
		{
			return false;
		}
		if (!object.Equals(Screens, other.Screens))
		{
			return false;
		}
		if (!object.Equals(Import, other.Import))
		{
			return false;
		}
		if (!object.Equals(Groups, other.Groups))
		{
			return false;
		}
		if (!object.Equals(Network, other.Network))
		{
			return false;
		}
		if (!object.Equals(Sync, other.Sync))
		{
			return false;
		}
		if (!object.Equals(Advanced, other.Advanced))
		{
			return false;
		}
		if (!object.Equals(Updates, other.Updates))
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
		if (general_ != null)
		{
			num ^= General.GetHashCode();
		}
		if (screens_ != null)
		{
			num ^= Screens.GetHashCode();
		}
		if (import_ != null)
		{
			num ^= Import.GetHashCode();
		}
		if (groups_ != null)
		{
			num ^= Groups.GetHashCode();
		}
		if (network_ != null)
		{
			num ^= Network.GetHashCode();
		}
		if (sync_ != null)
		{
			num ^= Sync.GetHashCode();
		}
		if (advanced_ != null)
		{
			num ^= Advanced.GetHashCode();
		}
		if (updates_ != null)
		{
			num ^= Updates.GetHashCode();
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
		if (general_ != null)
		{
			output.WriteRawTag(10);
			output.WriteMessage(General);
		}
		if (screens_ != null)
		{
			output.WriteRawTag(18);
			output.WriteMessage(Screens);
		}
		if (import_ != null)
		{
			output.WriteRawTag(26);
			output.WriteMessage(Import);
		}
		if (groups_ != null)
		{
			output.WriteRawTag(34);
			output.WriteMessage(Groups);
		}
		if (network_ != null)
		{
			output.WriteRawTag(42);
			output.WriteMessage(Network);
		}
		if (sync_ != null)
		{
			output.WriteRawTag(50);
			output.WriteMessage(Sync);
		}
		if (advanced_ != null)
		{
			output.WriteRawTag(58);
			output.WriteMessage(Advanced);
		}
		if (updates_ != null)
		{
			output.WriteRawTag(66);
			output.WriteMessage(Updates);
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
		if (general_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(General);
		}
		if (screens_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Screens);
		}
		if (import_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Import);
		}
		if (groups_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Groups);
		}
		if (network_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Network);
		}
		if (sync_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Sync);
		}
		if (advanced_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Advanced);
		}
		if (updates_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Updates);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(Preferences other)
	{
		if (other == null)
		{
			return;
		}
		if (other.general_ != null)
		{
			if (general_ == null)
			{
				General = new Types.General();
			}
			General.MergeFrom(other.General);
		}
		if (other.screens_ != null)
		{
			if (screens_ == null)
			{
				Screens = new Types.Screens();
			}
			Screens.MergeFrom(other.Screens);
		}
		if (other.import_ != null)
		{
			if (import_ == null)
			{
				Import = new Types.Import();
			}
			Import.MergeFrom(other.Import);
		}
		if (other.groups_ != null)
		{
			if (groups_ == null)
			{
				Groups = new Types.Groups();
			}
			Groups.MergeFrom(other.Groups);
		}
		if (other.network_ != null)
		{
			if (network_ == null)
			{
				Network = new Types.Network();
			}
			Network.MergeFrom(other.Network);
		}
		if (other.sync_ != null)
		{
			if (sync_ == null)
			{
				Sync = new Types.Sync();
			}
			Sync.MergeFrom(other.Sync);
		}
		if (other.advanced_ != null)
		{
			if (advanced_ == null)
			{
				Advanced = new Types.Advanced();
			}
			Advanced.MergeFrom(other.Advanced);
		}
		if (other.updates_ != null)
		{
			if (updates_ == null)
			{
				Updates = new Types.Updates();
			}
			Updates.MergeFrom(other.Updates);
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
				if (general_ == null)
				{
					General = new Types.General();
				}
				input.ReadMessage(General);
				break;
			case 18u:
				if (screens_ == null)
				{
					Screens = new Types.Screens();
				}
				input.ReadMessage(Screens);
				break;
			case 26u:
				if (import_ == null)
				{
					Import = new Types.Import();
				}
				input.ReadMessage(Import);
				break;
			case 34u:
				if (groups_ == null)
				{
					Groups = new Types.Groups();
				}
				input.ReadMessage(Groups);
				break;
			case 42u:
				if (network_ == null)
				{
					Network = new Types.Network();
				}
				input.ReadMessage(Network);
				break;
			case 50u:
				if (sync_ == null)
				{
					Sync = new Types.Sync();
				}
				input.ReadMessage(Sync);
				break;
			case 58u:
				if (advanced_ == null)
				{
					Advanced = new Types.Advanced();
				}
				input.ReadMessage(Advanced);
				break;
			case 66u:
				if (updates_ == null)
				{
					Updates = new Types.Updates();
				}
				input.ReadMessage(Updates);
				break;
			}
		}
	}
}
