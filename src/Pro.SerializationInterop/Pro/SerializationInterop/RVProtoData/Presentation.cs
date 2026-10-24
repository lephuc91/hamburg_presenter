using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class Presentation : IMessage<Presentation>, IMessage, IEquatable<Presentation>, IDeepCloneable<Presentation>
{
	public enum SlideShowOneofCase
	{
		None = 0,
		SlideShowDuration = 20
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class CCLI : IMessage<CCLI>, IMessage, IEquatable<CCLI>, IDeepCloneable<CCLI>
		{
			private static readonly MessageParser<CCLI> _parser = new MessageParser<CCLI>(() => new CCLI());

			private UnknownFieldSet _unknownFields;

			public const int AuthorFieldNumber = 1;

			private string author_ = "";

			public const int ArtistCreditsFieldNumber = 2;

			private string artistCredits_ = "";

			public const int SongTitleFieldNumber = 3;

			private string songTitle_ = "";

			public const int PublisherFieldNumber = 4;

			private string publisher_ = "";

			public const int CopyrightYearFieldNumber = 5;

			private uint copyrightYear_;

			public const int SongNumberFieldNumber = 6;

			private uint songNumber_;

			public const int DisplayFieldNumber = 7;

			private bool display_;

			public const int AlbumFieldNumber = 8;

			private string album_ = "";

			public const int ArtworkFieldNumber = 9;

			private ByteString artwork_ = ByteString.Empty;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<CCLI> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Presentation.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string Author
			{
				get
				{
					return author_;
				}
				set
				{
					author_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string ArtistCredits
			{
				get
				{
					return artistCredits_;
				}
				set
				{
					artistCredits_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string SongTitle
			{
				get
				{
					return songTitle_;
				}
				set
				{
					songTitle_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string Publisher
			{
				get
				{
					return publisher_;
				}
				set
				{
					publisher_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public uint CopyrightYear
			{
				get
				{
					return copyrightYear_;
				}
				set
				{
					copyrightYear_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public uint SongNumber
			{
				get
				{
					return songNumber_;
				}
				set
				{
					songNumber_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Display
			{
				get
				{
					return display_;
				}
				set
				{
					display_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string Album
			{
				get
				{
					return album_;
				}
				set
				{
					album_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ByteString Artwork
			{
				get
				{
					return artwork_;
				}
				set
				{
					artwork_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public CCLI()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public CCLI(CCLI other)
				: this()
			{
				author_ = other.author_;
				artistCredits_ = other.artistCredits_;
				songTitle_ = other.songTitle_;
				publisher_ = other.publisher_;
				copyrightYear_ = other.copyrightYear_;
				songNumber_ = other.songNumber_;
				display_ = other.display_;
				album_ = other.album_;
				artwork_ = other.artwork_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public CCLI Clone()
			{
				return new CCLI(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as CCLI);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(CCLI other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (Author != other.Author)
				{
					return false;
				}
				if (ArtistCredits != other.ArtistCredits)
				{
					return false;
				}
				if (SongTitle != other.SongTitle)
				{
					return false;
				}
				if (Publisher != other.Publisher)
				{
					return false;
				}
				if (CopyrightYear != other.CopyrightYear)
				{
					return false;
				}
				if (SongNumber != other.SongNumber)
				{
					return false;
				}
				if (Display != other.Display)
				{
					return false;
				}
				if (Album != other.Album)
				{
					return false;
				}
				if (Artwork != other.Artwork)
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
				if (Author.Length != 0)
				{
					num ^= Author.GetHashCode();
				}
				if (ArtistCredits.Length != 0)
				{
					num ^= ArtistCredits.GetHashCode();
				}
				if (SongTitle.Length != 0)
				{
					num ^= SongTitle.GetHashCode();
				}
				if (Publisher.Length != 0)
				{
					num ^= Publisher.GetHashCode();
				}
				if (CopyrightYear != 0)
				{
					num ^= CopyrightYear.GetHashCode();
				}
				if (SongNumber != 0)
				{
					num ^= SongNumber.GetHashCode();
				}
				if (Display)
				{
					num ^= Display.GetHashCode();
				}
				if (Album.Length != 0)
				{
					num ^= Album.GetHashCode();
				}
				if (Artwork.Length != 0)
				{
					num ^= Artwork.GetHashCode();
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
				if (Author.Length != 0)
				{
					output.WriteRawTag(10);
					output.WriteString(Author);
				}
				if (ArtistCredits.Length != 0)
				{
					output.WriteRawTag(18);
					output.WriteString(ArtistCredits);
				}
				if (SongTitle.Length != 0)
				{
					output.WriteRawTag(26);
					output.WriteString(SongTitle);
				}
				if (Publisher.Length != 0)
				{
					output.WriteRawTag(34);
					output.WriteString(Publisher);
				}
				if (CopyrightYear != 0)
				{
					output.WriteRawTag(40);
					output.WriteUInt32(CopyrightYear);
				}
				if (SongNumber != 0)
				{
					output.WriteRawTag(48);
					output.WriteUInt32(SongNumber);
				}
				if (Display)
				{
					output.WriteRawTag(56);
					output.WriteBool(Display);
				}
				if (Album.Length != 0)
				{
					output.WriteRawTag(66);
					output.WriteString(Album);
				}
				if (Artwork.Length != 0)
				{
					output.WriteRawTag(74);
					output.WriteBytes(Artwork);
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
				if (Author.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Author);
				}
				if (ArtistCredits.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(ArtistCredits);
				}
				if (SongTitle.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(SongTitle);
				}
				if (Publisher.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Publisher);
				}
				if (CopyrightYear != 0)
				{
					num += 1 + CodedOutputStream.ComputeUInt32Size(CopyrightYear);
				}
				if (SongNumber != 0)
				{
					num += 1 + CodedOutputStream.ComputeUInt32Size(SongNumber);
				}
				if (Display)
				{
					num += 2;
				}
				if (Album.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Album);
				}
				if (Artwork.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeBytesSize(Artwork);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(CCLI other)
			{
				if (other != null)
				{
					if (other.Author.Length != 0)
					{
						Author = other.Author;
					}
					if (other.ArtistCredits.Length != 0)
					{
						ArtistCredits = other.ArtistCredits;
					}
					if (other.SongTitle.Length != 0)
					{
						SongTitle = other.SongTitle;
					}
					if (other.Publisher.Length != 0)
					{
						Publisher = other.Publisher;
					}
					if (other.CopyrightYear != 0)
					{
						CopyrightYear = other.CopyrightYear;
					}
					if (other.SongNumber != 0)
					{
						SongNumber = other.SongNumber;
					}
					if (other.Display)
					{
						Display = other.Display;
					}
					if (other.Album.Length != 0)
					{
						Album = other.Album;
					}
					if (other.Artwork.Length != 0)
					{
						Artwork = other.Artwork;
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
						Author = input.ReadString();
						break;
					case 18u:
						ArtistCredits = input.ReadString();
						break;
					case 26u:
						SongTitle = input.ReadString();
						break;
					case 34u:
						Publisher = input.ReadString();
						break;
					case 40u:
						CopyrightYear = input.ReadUInt32();
						break;
					case 48u:
						SongNumber = input.ReadUInt32();
						break;
					case 56u:
						Display = input.ReadBool();
						break;
					case 66u:
						Album = input.ReadString();
						break;
					case 74u:
						Artwork = input.ReadBytes();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class BibleReference : IMessage<BibleReference>, IMessage, IEquatable<BibleReference>, IDeepCloneable<BibleReference>
		{
			private static readonly MessageParser<BibleReference> _parser = new MessageParser<BibleReference>(() => new BibleReference());

			private UnknownFieldSet _unknownFields;

			public const int BookIndexFieldNumber = 1;

			private uint bookIndex_;

			public const int BookNameFieldNumber = 2;

			private string bookName_ = "";

			public const int ChapterRangeFieldNumber = 3;

			private IntRange chapterRange_;

			public const int VerseRangeFieldNumber = 4;

			private IntRange verseRange_;

			public const int TranslationNameFieldNumber = 5;

			private string translationName_ = "";

			public const int TranslationDisplayAbbreviationFieldNumber = 6;

			private string translationDisplayAbbreviation_ = "";

			public const int TranslationInternalAbbreviationFieldNumber = 7;

			private string translationInternalAbbreviation_ = "";

			public const int BookKeyFieldNumber = 8;

			private string bookKey_ = "";

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<BibleReference> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Presentation.Descriptor.NestedTypes[1];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public uint BookIndex
			{
				get
				{
					return bookIndex_;
				}
				set
				{
					bookIndex_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string BookName
			{
				get
				{
					return bookName_;
				}
				set
				{
					bookName_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public IntRange ChapterRange
			{
				get
				{
					return chapterRange_;
				}
				set
				{
					chapterRange_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public IntRange VerseRange
			{
				get
				{
					return verseRange_;
				}
				set
				{
					verseRange_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string TranslationName
			{
				get
				{
					return translationName_;
				}
				set
				{
					translationName_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string TranslationDisplayAbbreviation
			{
				get
				{
					return translationDisplayAbbreviation_;
				}
				set
				{
					translationDisplayAbbreviation_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string TranslationInternalAbbreviation
			{
				get
				{
					return translationInternalAbbreviation_;
				}
				set
				{
					translationInternalAbbreviation_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string BookKey
			{
				get
				{
					return bookKey_;
				}
				set
				{
					bookKey_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public BibleReference()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public BibleReference(BibleReference other)
				: this()
			{
				bookIndex_ = other.bookIndex_;
				bookName_ = other.bookName_;
				chapterRange_ = ((other.chapterRange_ != null) ? other.chapterRange_.Clone() : null);
				verseRange_ = ((other.verseRange_ != null) ? other.verseRange_.Clone() : null);
				translationName_ = other.translationName_;
				translationDisplayAbbreviation_ = other.translationDisplayAbbreviation_;
				translationInternalAbbreviation_ = other.translationInternalAbbreviation_;
				bookKey_ = other.bookKey_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public BibleReference Clone()
			{
				return new BibleReference(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as BibleReference);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(BibleReference other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (BookIndex != other.BookIndex)
				{
					return false;
				}
				if (BookName != other.BookName)
				{
					return false;
				}
				if (!object.Equals(ChapterRange, other.ChapterRange))
				{
					return false;
				}
				if (!object.Equals(VerseRange, other.VerseRange))
				{
					return false;
				}
				if (TranslationName != other.TranslationName)
				{
					return false;
				}
				if (TranslationDisplayAbbreviation != other.TranslationDisplayAbbreviation)
				{
					return false;
				}
				if (TranslationInternalAbbreviation != other.TranslationInternalAbbreviation)
				{
					return false;
				}
				if (BookKey != other.BookKey)
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
				if (BookIndex != 0)
				{
					num ^= BookIndex.GetHashCode();
				}
				if (BookName.Length != 0)
				{
					num ^= BookName.GetHashCode();
				}
				if (chapterRange_ != null)
				{
					num ^= ChapterRange.GetHashCode();
				}
				if (verseRange_ != null)
				{
					num ^= VerseRange.GetHashCode();
				}
				if (TranslationName.Length != 0)
				{
					num ^= TranslationName.GetHashCode();
				}
				if (TranslationDisplayAbbreviation.Length != 0)
				{
					num ^= TranslationDisplayAbbreviation.GetHashCode();
				}
				if (TranslationInternalAbbreviation.Length != 0)
				{
					num ^= TranslationInternalAbbreviation.GetHashCode();
				}
				if (BookKey.Length != 0)
				{
					num ^= BookKey.GetHashCode();
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
				if (BookIndex != 0)
				{
					output.WriteRawTag(8);
					output.WriteUInt32(BookIndex);
				}
				if (BookName.Length != 0)
				{
					output.WriteRawTag(18);
					output.WriteString(BookName);
				}
				if (chapterRange_ != null)
				{
					output.WriteRawTag(26);
					output.WriteMessage(ChapterRange);
				}
				if (verseRange_ != null)
				{
					output.WriteRawTag(34);
					output.WriteMessage(VerseRange);
				}
				if (TranslationName.Length != 0)
				{
					output.WriteRawTag(42);
					output.WriteString(TranslationName);
				}
				if (TranslationDisplayAbbreviation.Length != 0)
				{
					output.WriteRawTag(50);
					output.WriteString(TranslationDisplayAbbreviation);
				}
				if (TranslationInternalAbbreviation.Length != 0)
				{
					output.WriteRawTag(58);
					output.WriteString(TranslationInternalAbbreviation);
				}
				if (BookKey.Length != 0)
				{
					output.WriteRawTag(66);
					output.WriteString(BookKey);
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
				if (BookIndex != 0)
				{
					num += 1 + CodedOutputStream.ComputeUInt32Size(BookIndex);
				}
				if (BookName.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(BookName);
				}
				if (chapterRange_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(ChapterRange);
				}
				if (verseRange_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(VerseRange);
				}
				if (TranslationName.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(TranslationName);
				}
				if (TranslationDisplayAbbreviation.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(TranslationDisplayAbbreviation);
				}
				if (TranslationInternalAbbreviation.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(TranslationInternalAbbreviation);
				}
				if (BookKey.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(BookKey);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(BibleReference other)
			{
				if (other == null)
				{
					return;
				}
				if (other.BookIndex != 0)
				{
					BookIndex = other.BookIndex;
				}
				if (other.BookName.Length != 0)
				{
					BookName = other.BookName;
				}
				if (other.chapterRange_ != null)
				{
					if (chapterRange_ == null)
					{
						ChapterRange = new IntRange();
					}
					ChapterRange.MergeFrom(other.ChapterRange);
				}
				if (other.verseRange_ != null)
				{
					if (verseRange_ == null)
					{
						VerseRange = new IntRange();
					}
					VerseRange.MergeFrom(other.VerseRange);
				}
				if (other.TranslationName.Length != 0)
				{
					TranslationName = other.TranslationName;
				}
				if (other.TranslationDisplayAbbreviation.Length != 0)
				{
					TranslationDisplayAbbreviation = other.TranslationDisplayAbbreviation;
				}
				if (other.TranslationInternalAbbreviation.Length != 0)
				{
					TranslationInternalAbbreviation = other.TranslationInternalAbbreviation;
				}
				if (other.BookKey.Length != 0)
				{
					BookKey = other.BookKey;
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
						BookIndex = input.ReadUInt32();
						break;
					case 18u:
						BookName = input.ReadString();
						break;
					case 26u:
						if (chapterRange_ == null)
						{
							ChapterRange = new IntRange();
						}
						input.ReadMessage(ChapterRange);
						break;
					case 34u:
						if (verseRange_ == null)
						{
							VerseRange = new IntRange();
						}
						input.ReadMessage(VerseRange);
						break;
					case 42u:
						TranslationName = input.ReadString();
						break;
					case 50u:
						TranslationDisplayAbbreviation = input.ReadString();
						break;
					case 58u:
						TranslationInternalAbbreviation = input.ReadString();
						break;
					case 66u:
						BookKey = input.ReadString();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Timeline : IMessage<Timeline>, IMessage, IEquatable<Timeline>, IDeepCloneable<Timeline>
		{
			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class Cue : IMessage<Cue>, IMessage, IEquatable<Cue>, IDeepCloneable<Cue>
				{
					public enum TriggerInfoOneofCase
					{
						None = 0,
						CueId = 2,
						Action = 4
					}

					private static readonly MessageParser<Cue> _parser = new MessageParser<Cue>(() => new Cue());

					private UnknownFieldSet _unknownFields;

					public const int TriggerTimeFieldNumber = 1;

					private double triggerTime_;

					public const int NameFieldNumber = 3;

					private string name_ = "";

					public const int CueIdFieldNumber = 2;

					public const int ActionFieldNumber = 4;

					private object triggerInfo_;

					private TriggerInfoOneofCase triggerInfoCase_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<Cue> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => Timeline.Descriptor.NestedTypes[0];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public double TriggerTime
					{
						get
						{
							return triggerTime_;
						}
						set
						{
							triggerTime_ = value;
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
					public UUID CueId
					{
						get
						{
							if (triggerInfoCase_ != TriggerInfoOneofCase.CueId)
							{
								return null;
							}
							return (UUID)triggerInfo_;
						}
						set
						{
							triggerInfo_ = value;
							triggerInfoCase_ = ((value != null) ? TriggerInfoOneofCase.CueId : TriggerInfoOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Action Action
					{
						get
						{
							if (triggerInfoCase_ != TriggerInfoOneofCase.Action)
							{
								return null;
							}
							return (Action)triggerInfo_;
						}
						set
						{
							triggerInfo_ = value;
							triggerInfoCase_ = ((value != null) ? TriggerInfoOneofCase.Action : TriggerInfoOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public TriggerInfoOneofCase TriggerInfoCase => triggerInfoCase_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Cue()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Cue(Cue other)
						: this()
					{
						triggerTime_ = other.triggerTime_;
						name_ = other.name_;
						switch (other.TriggerInfoCase)
						{
						case TriggerInfoOneofCase.CueId:
							CueId = other.CueId.Clone();
							break;
						case TriggerInfoOneofCase.Action:
							Action = other.Action.Clone();
							break;
						}
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Cue Clone()
					{
						return new Cue(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void ClearTriggerInfo()
					{
						triggerInfoCase_ = TriggerInfoOneofCase.None;
						triggerInfo_ = null;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as Cue);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(Cue other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(TriggerTime, other.TriggerTime))
						{
							return false;
						}
						if (Name != other.Name)
						{
							return false;
						}
						if (!object.Equals(CueId, other.CueId))
						{
							return false;
						}
						if (!object.Equals(Action, other.Action))
						{
							return false;
						}
						if (TriggerInfoCase != other.TriggerInfoCase)
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
						if (TriggerTime != 0.0)
						{
							num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(TriggerTime);
						}
						if (Name.Length != 0)
						{
							num ^= Name.GetHashCode();
						}
						if (triggerInfoCase_ == TriggerInfoOneofCase.CueId)
						{
							num ^= CueId.GetHashCode();
						}
						if (triggerInfoCase_ == TriggerInfoOneofCase.Action)
						{
							num ^= Action.GetHashCode();
						}
						num ^= (int)triggerInfoCase_;
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
						if (TriggerTime != 0.0)
						{
							output.WriteRawTag(9);
							output.WriteDouble(TriggerTime);
						}
						if (triggerInfoCase_ == TriggerInfoOneofCase.CueId)
						{
							output.WriteRawTag(18);
							output.WriteMessage(CueId);
						}
						if (Name.Length != 0)
						{
							output.WriteRawTag(26);
							output.WriteString(Name);
						}
						if (triggerInfoCase_ == TriggerInfoOneofCase.Action)
						{
							output.WriteRawTag(34);
							output.WriteMessage(Action);
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
						if (TriggerTime != 0.0)
						{
							num += 9;
						}
						if (Name.Length != 0)
						{
							num += 1 + CodedOutputStream.ComputeStringSize(Name);
						}
						if (triggerInfoCase_ == TriggerInfoOneofCase.CueId)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(CueId);
						}
						if (triggerInfoCase_ == TriggerInfoOneofCase.Action)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(Action);
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(Cue other)
					{
						if (other == null)
						{
							return;
						}
						if (other.TriggerTime != 0.0)
						{
							TriggerTime = other.TriggerTime;
						}
						if (other.Name.Length != 0)
						{
							Name = other.Name;
						}
						switch (other.TriggerInfoCase)
						{
						case TriggerInfoOneofCase.CueId:
							if (CueId == null)
							{
								CueId = new UUID();
							}
							CueId.MergeFrom(other.CueId);
							break;
						case TriggerInfoOneofCase.Action:
							if (Action == null)
							{
								Action = new Action();
							}
							Action.MergeFrom(other.Action);
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
							case 9u:
								TriggerTime = input.ReadDouble();
								break;
							case 18u:
							{
								UUID uUID = new UUID();
								if (triggerInfoCase_ == TriggerInfoOneofCase.CueId)
								{
									uUID.MergeFrom(CueId);
								}
								input.ReadMessage(uUID);
								CueId = uUID;
								break;
							}
							case 26u:
								Name = input.ReadString();
								break;
							case 34u:
							{
								Action action = new Action();
								if (triggerInfoCase_ == TriggerInfoOneofCase.Action)
								{
									action.MergeFrom(Action);
								}
								input.ReadMessage(action);
								Action = action;
								break;
							}
							}
						}
					}
				}
			}

			private static readonly MessageParser<Timeline> _parser = new MessageParser<Timeline>(() => new Timeline());

			private UnknownFieldSet _unknownFields;

			public const int CuesFieldNumber = 1;

			private static readonly FieldCodec<Types.Cue> _repeated_cues_codec = FieldCodec.ForMessage(10u, Types.Cue.Parser);

			private readonly RepeatedField<Types.Cue> cues_ = new RepeatedField<Types.Cue>();

			public const int DurationFieldNumber = 5;

			private double duration_;

			public const int LoopFieldNumber = 6;

			private bool loop_;

			public const int AudioActionFieldNumber = 8;

			private Action audioAction_;

			public const int TimecodeEnableFieldNumber = 9;

			private bool timecodeEnable_;

			public const int TimecodeOffsetFieldNumber = 10;

			private double timecodeOffset_;

			public const int CuesV2FieldNumber = 11;

			private static readonly FieldCodec<Types.Cue> _repeated_cuesV2_codec = FieldCodec.ForMessage(90u, Types.Cue.Parser);

			private readonly RepeatedField<Types.Cue> cuesV2_ = new RepeatedField<Types.Cue>();

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Timeline> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Presentation.Descriptor.NestedTypes[2];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RepeatedField<Types.Cue> Cues => cues_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public double Duration
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
			public bool Loop
			{
				get
				{
					return loop_;
				}
				set
				{
					loop_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Action AudioAction
			{
				get
				{
					return audioAction_;
				}
				set
				{
					audioAction_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool TimecodeEnable
			{
				get
				{
					return timecodeEnable_;
				}
				set
				{
					timecodeEnable_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public double TimecodeOffset
			{
				get
				{
					return timecodeOffset_;
				}
				set
				{
					timecodeOffset_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RepeatedField<Types.Cue> CuesV2 => cuesV2_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Timeline()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Timeline(Timeline other)
				: this()
			{
				cues_ = other.cues_.Clone();
				duration_ = other.duration_;
				loop_ = other.loop_;
				audioAction_ = ((other.audioAction_ != null) ? other.audioAction_.Clone() : null);
				timecodeEnable_ = other.timecodeEnable_;
				timecodeOffset_ = other.timecodeOffset_;
				cuesV2_ = other.cuesV2_.Clone();
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Timeline Clone()
			{
				return new Timeline(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Timeline);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Timeline other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!cues_.Equals(other.cues_))
				{
					return false;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Duration, other.Duration))
				{
					return false;
				}
				if (Loop != other.Loop)
				{
					return false;
				}
				if (!object.Equals(AudioAction, other.AudioAction))
				{
					return false;
				}
				if (TimecodeEnable != other.TimecodeEnable)
				{
					return false;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(TimecodeOffset, other.TimecodeOffset))
				{
					return false;
				}
				if (!cuesV2_.Equals(other.cuesV2_))
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
				num ^= cues_.GetHashCode();
				if (Duration != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Duration);
				}
				if (Loop)
				{
					num ^= Loop.GetHashCode();
				}
				if (audioAction_ != null)
				{
					num ^= AudioAction.GetHashCode();
				}
				if (TimecodeEnable)
				{
					num ^= TimecodeEnable.GetHashCode();
				}
				if (TimecodeOffset != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(TimecodeOffset);
				}
				num ^= cuesV2_.GetHashCode();
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
				cues_.WriteTo(output, _repeated_cues_codec);
				if (Duration != 0.0)
				{
					output.WriteRawTag(41);
					output.WriteDouble(Duration);
				}
				if (Loop)
				{
					output.WriteRawTag(48);
					output.WriteBool(Loop);
				}
				if (audioAction_ != null)
				{
					output.WriteRawTag(66);
					output.WriteMessage(AudioAction);
				}
				if (TimecodeEnable)
				{
					output.WriteRawTag(72);
					output.WriteBool(TimecodeEnable);
				}
				if (TimecodeOffset != 0.0)
				{
					output.WriteRawTag(81);
					output.WriteDouble(TimecodeOffset);
				}
				cuesV2_.WriteTo(output, _repeated_cuesV2_codec);
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
				num += cues_.CalculateSize(_repeated_cues_codec);
				if (Duration != 0.0)
				{
					num += 9;
				}
				if (Loop)
				{
					num += 2;
				}
				if (audioAction_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(AudioAction);
				}
				if (TimecodeEnable)
				{
					num += 2;
				}
				if (TimecodeOffset != 0.0)
				{
					num += 9;
				}
				num += cuesV2_.CalculateSize(_repeated_cuesV2_codec);
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(Timeline other)
			{
				if (other == null)
				{
					return;
				}
				cues_.Add(other.cues_);
				if (other.Duration != 0.0)
				{
					Duration = other.Duration;
				}
				if (other.Loop)
				{
					Loop = other.Loop;
				}
				if (other.audioAction_ != null)
				{
					if (audioAction_ == null)
					{
						AudioAction = new Action();
					}
					AudioAction.MergeFrom(other.AudioAction);
				}
				if (other.TimecodeEnable)
				{
					TimecodeEnable = other.TimecodeEnable;
				}
				if (other.TimecodeOffset != 0.0)
				{
					TimecodeOffset = other.TimecodeOffset;
				}
				cuesV2_.Add(other.cuesV2_);
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
						cues_.AddEntriesFrom(input, _repeated_cues_codec);
						break;
					case 41u:
						Duration = input.ReadDouble();
						break;
					case 48u:
						Loop = input.ReadBool();
						break;
					case 66u:
						if (audioAction_ == null)
						{
							AudioAction = new Action();
						}
						input.ReadMessage(AudioAction);
						break;
					case 72u:
						TimecodeEnable = input.ReadBool();
						break;
					case 81u:
						TimecodeOffset = input.ReadDouble();
						break;
					case 90u:
						cuesV2_.AddEntriesFrom(input, _repeated_cuesV2_codec);
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Arrangement : IMessage<Arrangement>, IMessage, IEquatable<Arrangement>, IDeepCloneable<Arrangement>
		{
			private static readonly MessageParser<Arrangement> _parser = new MessageParser<Arrangement>(() => new Arrangement());

			private UnknownFieldSet _unknownFields;

			public const int UuidFieldNumber = 1;

			private UUID uuid_;

			public const int NameFieldNumber = 2;

			private string name_ = "";

			public const int GroupIdentifiersFieldNumber = 3;

			private static readonly FieldCodec<UUID> _repeated_groupIdentifiers_codec = FieldCodec.ForMessage(26u, UUID.Parser);

			private readonly RepeatedField<UUID> groupIdentifiers_ = new RepeatedField<UUID>();

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Arrangement> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Presentation.Descriptor.NestedTypes[3];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public UUID Uuid
			{
				get
				{
					return uuid_;
				}
				set
				{
					uuid_ = value;
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
			public RepeatedField<UUID> GroupIdentifiers => groupIdentifiers_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Arrangement()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Arrangement(Arrangement other)
				: this()
			{
				uuid_ = ((other.uuid_ != null) ? other.uuid_.Clone() : null);
				name_ = other.name_;
				groupIdentifiers_ = other.groupIdentifiers_.Clone();
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Arrangement Clone()
			{
				return new Arrangement(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Arrangement);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Arrangement other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(Uuid, other.Uuid))
				{
					return false;
				}
				if (Name != other.Name)
				{
					return false;
				}
				if (!groupIdentifiers_.Equals(other.groupIdentifiers_))
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
				if (uuid_ != null)
				{
					num ^= Uuid.GetHashCode();
				}
				if (Name.Length != 0)
				{
					num ^= Name.GetHashCode();
				}
				num ^= groupIdentifiers_.GetHashCode();
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
				if (uuid_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Uuid);
				}
				if (Name.Length != 0)
				{
					output.WriteRawTag(18);
					output.WriteString(Name);
				}
				groupIdentifiers_.WriteTo(output, _repeated_groupIdentifiers_codec);
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
				if (uuid_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Uuid);
				}
				if (Name.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Name);
				}
				num += groupIdentifiers_.CalculateSize(_repeated_groupIdentifiers_codec);
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(Arrangement other)
			{
				if (other == null)
				{
					return;
				}
				if (other.uuid_ != null)
				{
					if (uuid_ == null)
					{
						Uuid = new UUID();
					}
					Uuid.MergeFrom(other.Uuid);
				}
				if (other.Name.Length != 0)
				{
					Name = other.Name;
				}
				groupIdentifiers_.Add(other.groupIdentifiers_);
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
						if (uuid_ == null)
						{
							Uuid = new UUID();
						}
						input.ReadMessage(Uuid);
						break;
					case 18u:
						Name = input.ReadString();
						break;
					case 26u:
						groupIdentifiers_.AddEntriesFrom(input, _repeated_groupIdentifiers_codec);
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class CueGroup : IMessage<CueGroup>, IMessage, IEquatable<CueGroup>, IDeepCloneable<CueGroup>
		{
			private static readonly MessageParser<CueGroup> _parser = new MessageParser<CueGroup>(() => new CueGroup());

			private UnknownFieldSet _unknownFields;

			public const int GroupFieldNumber = 1;

			private Group group_;

			public const int CueIdentifiersFieldNumber = 2;

			private static readonly FieldCodec<UUID> _repeated_cueIdentifiers_codec = FieldCodec.ForMessage(18u, UUID.Parser);

			private readonly RepeatedField<UUID> cueIdentifiers_ = new RepeatedField<UUID>();

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<CueGroup> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Presentation.Descriptor.NestedTypes[4];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Group Group
			{
				get
				{
					return group_;
				}
				set
				{
					group_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RepeatedField<UUID> CueIdentifiers => cueIdentifiers_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public CueGroup()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public CueGroup(CueGroup other)
				: this()
			{
				group_ = ((other.group_ != null) ? other.group_.Clone() : null);
				cueIdentifiers_ = other.cueIdentifiers_.Clone();
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public CueGroup Clone()
			{
				return new CueGroup(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as CueGroup);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(CueGroup other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(Group, other.Group))
				{
					return false;
				}
				if (!cueIdentifiers_.Equals(other.cueIdentifiers_))
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
				if (group_ != null)
				{
					num ^= Group.GetHashCode();
				}
				num ^= cueIdentifiers_.GetHashCode();
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
				if (group_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Group);
				}
				cueIdentifiers_.WriteTo(output, _repeated_cueIdentifiers_codec);
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
				if (group_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Group);
				}
				num += cueIdentifiers_.CalculateSize(_repeated_cueIdentifiers_codec);
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(CueGroup other)
			{
				if (other == null)
				{
					return;
				}
				if (other.group_ != null)
				{
					if (group_ == null)
					{
						Group = new Group();
					}
					Group.MergeFrom(other.Group);
				}
				cueIdentifiers_.Add(other.cueIdentifiers_);
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
						if (group_ == null)
						{
							Group = new Group();
						}
						input.ReadMessage(Group);
						break;
					case 18u:
						cueIdentifiers_.AddEntriesFrom(input, _repeated_cueIdentifiers_codec);
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class MultiTracksLicensing : IMessage<MultiTracksLicensing>, IMessage, IEquatable<MultiTracksLicensing>, IDeepCloneable<MultiTracksLicensing>
		{
			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				public enum Subscription
				{
					[OriginalName("SUBSCRIPTION_CHART_PRO")]
					ChartPro,
					[OriginalName("SUBSCRIPTION_SLIDE_PRO")]
					SlidePro
				}
			}

			private static readonly MessageParser<MultiTracksLicensing> _parser = new MessageParser<MultiTracksLicensing>(() => new MultiTracksLicensing());

			private UnknownFieldSet _unknownFields;

			public const int SongIdentifierFieldNumber = 1;

			private long songIdentifier_;

			public const int CustomerIdentifierFieldNumber = 2;

			private string customerIdentifier_ = "";

			public const int ExpirationDateFieldNumber = 3;

			private Timestamp expirationDate_;

			public const int LicenseExpirationFieldNumber = 4;

			private Timestamp licenseExpiration_;

			public const int SubscriptionFieldNumber = 5;

			private Types.Subscription subscription_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<MultiTracksLicensing> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Presentation.Descriptor.NestedTypes[5];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public long SongIdentifier
			{
				get
				{
					return songIdentifier_;
				}
				set
				{
					songIdentifier_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string CustomerIdentifier
			{
				get
				{
					return customerIdentifier_;
				}
				set
				{
					customerIdentifier_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Timestamp ExpirationDate
			{
				get
				{
					return expirationDate_;
				}
				set
				{
					expirationDate_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Timestamp LicenseExpiration
			{
				get
				{
					return licenseExpiration_;
				}
				set
				{
					licenseExpiration_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.Subscription Subscription
			{
				get
				{
					return subscription_;
				}
				set
				{
					subscription_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public MultiTracksLicensing()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public MultiTracksLicensing(MultiTracksLicensing other)
				: this()
			{
				songIdentifier_ = other.songIdentifier_;
				customerIdentifier_ = other.customerIdentifier_;
				expirationDate_ = ((other.expirationDate_ != null) ? other.expirationDate_.Clone() : null);
				licenseExpiration_ = ((other.licenseExpiration_ != null) ? other.licenseExpiration_.Clone() : null);
				subscription_ = other.subscription_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public MultiTracksLicensing Clone()
			{
				return new MultiTracksLicensing(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as MultiTracksLicensing);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(MultiTracksLicensing other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (SongIdentifier != other.SongIdentifier)
				{
					return false;
				}
				if (CustomerIdentifier != other.CustomerIdentifier)
				{
					return false;
				}
				if (!object.Equals(ExpirationDate, other.ExpirationDate))
				{
					return false;
				}
				if (!object.Equals(LicenseExpiration, other.LicenseExpiration))
				{
					return false;
				}
				if (Subscription != other.Subscription)
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
				if (SongIdentifier != 0L)
				{
					num ^= SongIdentifier.GetHashCode();
				}
				if (CustomerIdentifier.Length != 0)
				{
					num ^= CustomerIdentifier.GetHashCode();
				}
				if (expirationDate_ != null)
				{
					num ^= ExpirationDate.GetHashCode();
				}
				if (licenseExpiration_ != null)
				{
					num ^= LicenseExpiration.GetHashCode();
				}
				if (Subscription != 0)
				{
					num ^= Subscription.GetHashCode();
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
				if (SongIdentifier != 0L)
				{
					output.WriteRawTag(8);
					output.WriteInt64(SongIdentifier);
				}
				if (CustomerIdentifier.Length != 0)
				{
					output.WriteRawTag(18);
					output.WriteString(CustomerIdentifier);
				}
				if (expirationDate_ != null)
				{
					output.WriteRawTag(26);
					output.WriteMessage(ExpirationDate);
				}
				if (licenseExpiration_ != null)
				{
					output.WriteRawTag(34);
					output.WriteMessage(LicenseExpiration);
				}
				if (Subscription != 0)
				{
					output.WriteRawTag(40);
					output.WriteEnum((int)Subscription);
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
				if (SongIdentifier != 0L)
				{
					num += 1 + CodedOutputStream.ComputeInt64Size(SongIdentifier);
				}
				if (CustomerIdentifier.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(CustomerIdentifier);
				}
				if (expirationDate_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(ExpirationDate);
				}
				if (licenseExpiration_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(LicenseExpiration);
				}
				if (Subscription != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)Subscription);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(MultiTracksLicensing other)
			{
				if (other == null)
				{
					return;
				}
				if (other.SongIdentifier != 0L)
				{
					SongIdentifier = other.SongIdentifier;
				}
				if (other.CustomerIdentifier.Length != 0)
				{
					CustomerIdentifier = other.CustomerIdentifier;
				}
				if (other.expirationDate_ != null)
				{
					if (expirationDate_ == null)
					{
						ExpirationDate = new Timestamp();
					}
					ExpirationDate.MergeFrom(other.ExpirationDate);
				}
				if (other.licenseExpiration_ != null)
				{
					if (licenseExpiration_ == null)
					{
						LicenseExpiration = new Timestamp();
					}
					LicenseExpiration.MergeFrom(other.LicenseExpiration);
				}
				if (other.Subscription != 0)
				{
					Subscription = other.Subscription;
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
						SongIdentifier = input.ReadInt64();
						break;
					case 18u:
						CustomerIdentifier = input.ReadString();
						break;
					case 26u:
						if (expirationDate_ == null)
						{
							ExpirationDate = new Timestamp();
						}
						input.ReadMessage(ExpirationDate);
						break;
					case 34u:
						if (licenseExpiration_ == null)
						{
							LicenseExpiration = new Timestamp();
						}
						input.ReadMessage(LicenseExpiration);
						break;
					case 40u:
						Subscription = (Types.Subscription)input.ReadEnum();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Music : IMessage<Music>, IMessage, IEquatable<Music>, IDeepCloneable<Music>
		{
			private static readonly MessageParser<Music> _parser = new MessageParser<Music>(() => new Music());

			private UnknownFieldSet _unknownFields;

			public const int OriginalMusicKeyFieldNumber = 1;

			private string originalMusicKey_ = "";

			public const int UserMusicKeyFieldNumber = 2;

			private string userMusicKey_ = "";

			public const int OriginalFieldNumber = 3;

			private MusicKeyScale original_;

			public const int UserFieldNumber = 4;

			private MusicKeyScale user_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Music> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Presentation.Descriptor.NestedTypes[6];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[Obsolete]
			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string OriginalMusicKey
			{
				get
				{
					return originalMusicKey_;
				}
				set
				{
					originalMusicKey_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[Obsolete]
			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string UserMusicKey
			{
				get
				{
					return userMusicKey_;
				}
				set
				{
					userMusicKey_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public MusicKeyScale Original
			{
				get
				{
					return original_;
				}
				set
				{
					original_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public MusicKeyScale User
			{
				get
				{
					return user_;
				}
				set
				{
					user_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Music()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Music(Music other)
				: this()
			{
				originalMusicKey_ = other.originalMusicKey_;
				userMusicKey_ = other.userMusicKey_;
				original_ = ((other.original_ != null) ? other.original_.Clone() : null);
				user_ = ((other.user_ != null) ? other.user_.Clone() : null);
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Music Clone()
			{
				return new Music(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Music);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Music other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (OriginalMusicKey != other.OriginalMusicKey)
				{
					return false;
				}
				if (UserMusicKey != other.UserMusicKey)
				{
					return false;
				}
				if (!object.Equals(Original, other.Original))
				{
					return false;
				}
				if (!object.Equals(User, other.User))
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
				if (OriginalMusicKey.Length != 0)
				{
					num ^= OriginalMusicKey.GetHashCode();
				}
				if (UserMusicKey.Length != 0)
				{
					num ^= UserMusicKey.GetHashCode();
				}
				if (original_ != null)
				{
					num ^= Original.GetHashCode();
				}
				if (user_ != null)
				{
					num ^= User.GetHashCode();
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
				if (OriginalMusicKey.Length != 0)
				{
					output.WriteRawTag(10);
					output.WriteString(OriginalMusicKey);
				}
				if (UserMusicKey.Length != 0)
				{
					output.WriteRawTag(18);
					output.WriteString(UserMusicKey);
				}
				if (original_ != null)
				{
					output.WriteRawTag(26);
					output.WriteMessage(Original);
				}
				if (user_ != null)
				{
					output.WriteRawTag(34);
					output.WriteMessage(User);
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
				if (OriginalMusicKey.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(OriginalMusicKey);
				}
				if (UserMusicKey.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(UserMusicKey);
				}
				if (original_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Original);
				}
				if (user_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(User);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(Music other)
			{
				if (other == null)
				{
					return;
				}
				if (other.OriginalMusicKey.Length != 0)
				{
					OriginalMusicKey = other.OriginalMusicKey;
				}
				if (other.UserMusicKey.Length != 0)
				{
					UserMusicKey = other.UserMusicKey;
				}
				if (other.original_ != null)
				{
					if (original_ == null)
					{
						Original = new MusicKeyScale();
					}
					Original.MergeFrom(other.Original);
				}
				if (other.user_ != null)
				{
					if (user_ == null)
					{
						User = new MusicKeyScale();
					}
					User.MergeFrom(other.User);
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
						OriginalMusicKey = input.ReadString();
						break;
					case 18u:
						UserMusicKey = input.ReadString();
						break;
					case 26u:
						if (original_ == null)
						{
							Original = new MusicKeyScale();
						}
						input.ReadMessage(Original);
						break;
					case 34u:
						if (user_ == null)
						{
							User = new MusicKeyScale();
						}
						input.ReadMessage(User);
						break;
					}
				}
			}
		}
	}

	private static readonly MessageParser<Presentation> _parser = new MessageParser<Presentation>(() => new Presentation());

	private UnknownFieldSet _unknownFields;

	public const int ApplicationInfoFieldNumber = 1;

	private ApplicationInfo applicationInfo_;

	public const int UuidFieldNumber = 2;

	private UUID uuid_;

	public const int NameFieldNumber = 3;

	private string name_ = "";

	public const int LastDateUsedFieldNumber = 4;

	private Timestamp lastDateUsed_;

	public const int LastModifiedDateFieldNumber = 5;

	private Timestamp lastModifiedDate_;

	public const int CategoryFieldNumber = 6;

	private string category_ = "";

	public const int NotesFieldNumber = 7;

	private string notes_ = "";

	public const int BackgroundFieldNumber = 8;

	private Background background_;

	public const int ChordChartFieldNumber = 9;

	private URL chordChart_;

	public const int SelectedArrangementFieldNumber = 10;

	private UUID selectedArrangement_;

	public const int ArrangementsFieldNumber = 11;

	private static readonly FieldCodec<Types.Arrangement> _repeated_arrangements_codec = FieldCodec.ForMessage(90u, Types.Arrangement.Parser);

	private readonly RepeatedField<Types.Arrangement> arrangements_ = new RepeatedField<Types.Arrangement>();

	public const int CueGroupsFieldNumber = 12;

	private static readonly FieldCodec<Types.CueGroup> _repeated_cueGroups_codec = FieldCodec.ForMessage(98u, Types.CueGroup.Parser);

	private readonly RepeatedField<Types.CueGroup> cueGroups_ = new RepeatedField<Types.CueGroup>();

	public const int CuesFieldNumber = 13;

	private static readonly FieldCodec<Cue> _repeated_cues_codec = FieldCodec.ForMessage(106u, Cue.Parser);

	private readonly RepeatedField<Cue> cues_ = new RepeatedField<Cue>();

	public const int CcliFieldNumber = 14;

	private Types.CCLI ccli_;

	public const int BibleReferenceFieldNumber = 15;

	private Types.BibleReference bibleReference_;

	public const int TimelineFieldNumber = 17;

	private Types.Timeline timeline_;

	public const int TransitionFieldNumber = 18;

	private Transition transition_;

	public const int ContentDestinationFieldNumber = 19;

	private Action.Types.ContentDestination contentDestination_;

	public const int SlideShowDurationFieldNumber = 20;

	public const int MultiTracksLicensingFieldNumber = 21;

	private Types.MultiTracksLicensing multiTracksLicensing_;

	public const int MusicKeyFieldNumber = 22;

	private string musicKey_ = "";

	public const int MusicFieldNumber = 23;

	private Types.Music music_;

	private object slideShow_;

	private SlideShowOneofCase slideShowCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<Presentation> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => PresentationReflection.Descriptor.MessageTypes[0];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ApplicationInfo ApplicationInfo
	{
		get
		{
			return applicationInfo_;
		}
		set
		{
			applicationInfo_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public UUID Uuid
	{
		get
		{
			return uuid_;
		}
		set
		{
			uuid_ = value;
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
	public Timestamp LastDateUsed
	{
		get
		{
			return lastDateUsed_;
		}
		set
		{
			lastDateUsed_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Timestamp LastModifiedDate
	{
		get
		{
			return lastModifiedDate_;
		}
		set
		{
			lastModifiedDate_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string Category
	{
		get
		{
			return category_;
		}
		set
		{
			category_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string Notes
	{
		get
		{
			return notes_;
		}
		set
		{
			notes_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Background Background
	{
		get
		{
			return background_;
		}
		set
		{
			background_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public URL ChordChart
	{
		get
		{
			return chordChart_;
		}
		set
		{
			chordChart_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public UUID SelectedArrangement
	{
		get
		{
			return selectedArrangement_;
		}
		set
		{
			selectedArrangement_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<Types.Arrangement> Arrangements => arrangements_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<Types.CueGroup> CueGroups => cueGroups_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<Cue> Cues => cues_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.CCLI Ccli
	{
		get
		{
			return ccli_;
		}
		set
		{
			ccli_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.BibleReference BibleReference
	{
		get
		{
			return bibleReference_;
		}
		set
		{
			bibleReference_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Timeline Timeline
	{
		get
		{
			return timeline_;
		}
		set
		{
			timeline_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Transition Transition
	{
		get
		{
			return transition_;
		}
		set
		{
			transition_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Action.Types.ContentDestination ContentDestination
	{
		get
		{
			return contentDestination_;
		}
		set
		{
			contentDestination_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public double SlideShowDuration
	{
		get
		{
			if (!HasSlideShowDuration)
			{
				return 0.0;
			}
			return (double)slideShow_;
		}
		set
		{
			slideShow_ = value;
			slideShowCase_ = SlideShowOneofCase.SlideShowDuration;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool HasSlideShowDuration => slideShowCase_ == SlideShowOneofCase.SlideShowDuration;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.MultiTracksLicensing MultiTracksLicensing
	{
		get
		{
			return multiTracksLicensing_;
		}
		set
		{
			multiTracksLicensing_ = value;
		}
	}

	[Obsolete]
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string MusicKey
	{
		get
		{
			return musicKey_;
		}
		set
		{
			musicKey_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Music Music
	{
		get
		{
			return music_;
		}
		set
		{
			music_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public SlideShowOneofCase SlideShowCase => slideShowCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Presentation()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Presentation(Presentation other)
		: this()
	{
		applicationInfo_ = ((other.applicationInfo_ != null) ? other.applicationInfo_.Clone() : null);
		uuid_ = ((other.uuid_ != null) ? other.uuid_.Clone() : null);
		name_ = other.name_;
		lastDateUsed_ = ((other.lastDateUsed_ != null) ? other.lastDateUsed_.Clone() : null);
		lastModifiedDate_ = ((other.lastModifiedDate_ != null) ? other.lastModifiedDate_.Clone() : null);
		category_ = other.category_;
		notes_ = other.notes_;
		background_ = ((other.background_ != null) ? other.background_.Clone() : null);
		chordChart_ = ((other.chordChart_ != null) ? other.chordChart_.Clone() : null);
		selectedArrangement_ = ((other.selectedArrangement_ != null) ? other.selectedArrangement_.Clone() : null);
		arrangements_ = other.arrangements_.Clone();
		cueGroups_ = other.cueGroups_.Clone();
		cues_ = other.cues_.Clone();
		ccli_ = ((other.ccli_ != null) ? other.ccli_.Clone() : null);
		bibleReference_ = ((other.bibleReference_ != null) ? other.bibleReference_.Clone() : null);
		timeline_ = ((other.timeline_ != null) ? other.timeline_.Clone() : null);
		transition_ = ((other.transition_ != null) ? other.transition_.Clone() : null);
		contentDestination_ = other.contentDestination_;
		multiTracksLicensing_ = ((other.multiTracksLicensing_ != null) ? other.multiTracksLicensing_.Clone() : null);
		musicKey_ = other.musicKey_;
		music_ = ((other.music_ != null) ? other.music_.Clone() : null);
		if (other.SlideShowCase == SlideShowOneofCase.SlideShowDuration)
		{
			SlideShowDuration = other.SlideShowDuration;
		}
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Presentation Clone()
	{
		return new Presentation(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void ClearSlideShowDuration()
	{
		if (HasSlideShowDuration)
		{
			ClearSlideShow();
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void ClearSlideShow()
	{
		slideShowCase_ = SlideShowOneofCase.None;
		slideShow_ = null;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as Presentation);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(Presentation other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(ApplicationInfo, other.ApplicationInfo))
		{
			return false;
		}
		if (!object.Equals(Uuid, other.Uuid))
		{
			return false;
		}
		if (Name != other.Name)
		{
			return false;
		}
		if (!object.Equals(LastDateUsed, other.LastDateUsed))
		{
			return false;
		}
		if (!object.Equals(LastModifiedDate, other.LastModifiedDate))
		{
			return false;
		}
		if (Category != other.Category)
		{
			return false;
		}
		if (Notes != other.Notes)
		{
			return false;
		}
		if (!object.Equals(Background, other.Background))
		{
			return false;
		}
		if (!object.Equals(ChordChart, other.ChordChart))
		{
			return false;
		}
		if (!object.Equals(SelectedArrangement, other.SelectedArrangement))
		{
			return false;
		}
		if (!arrangements_.Equals(other.arrangements_))
		{
			return false;
		}
		if (!cueGroups_.Equals(other.cueGroups_))
		{
			return false;
		}
		if (!cues_.Equals(other.cues_))
		{
			return false;
		}
		if (!object.Equals(Ccli, other.Ccli))
		{
			return false;
		}
		if (!object.Equals(BibleReference, other.BibleReference))
		{
			return false;
		}
		if (!object.Equals(Timeline, other.Timeline))
		{
			return false;
		}
		if (!object.Equals(Transition, other.Transition))
		{
			return false;
		}
		if (ContentDestination != other.ContentDestination)
		{
			return false;
		}
		if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(SlideShowDuration, other.SlideShowDuration))
		{
			return false;
		}
		if (!object.Equals(MultiTracksLicensing, other.MultiTracksLicensing))
		{
			return false;
		}
		if (MusicKey != other.MusicKey)
		{
			return false;
		}
		if (!object.Equals(Music, other.Music))
		{
			return false;
		}
		if (SlideShowCase != other.SlideShowCase)
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
		if (applicationInfo_ != null)
		{
			num ^= ApplicationInfo.GetHashCode();
		}
		if (uuid_ != null)
		{
			num ^= Uuid.GetHashCode();
		}
		if (Name.Length != 0)
		{
			num ^= Name.GetHashCode();
		}
		if (lastDateUsed_ != null)
		{
			num ^= LastDateUsed.GetHashCode();
		}
		if (lastModifiedDate_ != null)
		{
			num ^= LastModifiedDate.GetHashCode();
		}
		if (Category.Length != 0)
		{
			num ^= Category.GetHashCode();
		}
		if (Notes.Length != 0)
		{
			num ^= Notes.GetHashCode();
		}
		if (background_ != null)
		{
			num ^= Background.GetHashCode();
		}
		if (chordChart_ != null)
		{
			num ^= ChordChart.GetHashCode();
		}
		if (selectedArrangement_ != null)
		{
			num ^= SelectedArrangement.GetHashCode();
		}
		num ^= arrangements_.GetHashCode();
		num ^= cueGroups_.GetHashCode();
		num ^= cues_.GetHashCode();
		if (ccli_ != null)
		{
			num ^= Ccli.GetHashCode();
		}
		if (bibleReference_ != null)
		{
			num ^= BibleReference.GetHashCode();
		}
		if (timeline_ != null)
		{
			num ^= Timeline.GetHashCode();
		}
		if (transition_ != null)
		{
			num ^= Transition.GetHashCode();
		}
		if (ContentDestination != 0)
		{
			num ^= ContentDestination.GetHashCode();
		}
		if (HasSlideShowDuration)
		{
			num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(SlideShowDuration);
		}
		if (multiTracksLicensing_ != null)
		{
			num ^= MultiTracksLicensing.GetHashCode();
		}
		if (MusicKey.Length != 0)
		{
			num ^= MusicKey.GetHashCode();
		}
		if (music_ != null)
		{
			num ^= Music.GetHashCode();
		}
		num ^= (int)slideShowCase_;
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
		if (applicationInfo_ != null)
		{
			output.WriteRawTag(10);
			output.WriteMessage(ApplicationInfo);
		}
		if (uuid_ != null)
		{
			output.WriteRawTag(18);
			output.WriteMessage(Uuid);
		}
		if (Name.Length != 0)
		{
			output.WriteRawTag(26);
			output.WriteString(Name);
		}
		if (lastDateUsed_ != null)
		{
			output.WriteRawTag(34);
			output.WriteMessage(LastDateUsed);
		}
		if (lastModifiedDate_ != null)
		{
			output.WriteRawTag(42);
			output.WriteMessage(LastModifiedDate);
		}
		if (Category.Length != 0)
		{
			output.WriteRawTag(50);
			output.WriteString(Category);
		}
		if (Notes.Length != 0)
		{
			output.WriteRawTag(58);
			output.WriteString(Notes);
		}
		if (background_ != null)
		{
			output.WriteRawTag(66);
			output.WriteMessage(Background);
		}
		if (chordChart_ != null)
		{
			output.WriteRawTag(74);
			output.WriteMessage(ChordChart);
		}
		if (selectedArrangement_ != null)
		{
			output.WriteRawTag(82);
			output.WriteMessage(SelectedArrangement);
		}
		arrangements_.WriteTo(output, _repeated_arrangements_codec);
		cueGroups_.WriteTo(output, _repeated_cueGroups_codec);
		cues_.WriteTo(output, _repeated_cues_codec);
		if (ccli_ != null)
		{
			output.WriteRawTag(114);
			output.WriteMessage(Ccli);
		}
		if (bibleReference_ != null)
		{
			output.WriteRawTag(122);
			output.WriteMessage(BibleReference);
		}
		if (timeline_ != null)
		{
			output.WriteRawTag(138, 1);
			output.WriteMessage(Timeline);
		}
		if (transition_ != null)
		{
			output.WriteRawTag(146, 1);
			output.WriteMessage(Transition);
		}
		if (ContentDestination != 0)
		{
			output.WriteRawTag(152, 1);
			output.WriteEnum((int)ContentDestination);
		}
		if (HasSlideShowDuration)
		{
			output.WriteRawTag(161, 1);
			output.WriteDouble(SlideShowDuration);
		}
		if (multiTracksLicensing_ != null)
		{
			output.WriteRawTag(170, 1);
			output.WriteMessage(MultiTracksLicensing);
		}
		if (MusicKey.Length != 0)
		{
			output.WriteRawTag(178, 1);
			output.WriteString(MusicKey);
		}
		if (music_ != null)
		{
			output.WriteRawTag(186, 1);
			output.WriteMessage(Music);
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
		if (applicationInfo_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(ApplicationInfo);
		}
		if (uuid_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Uuid);
		}
		if (Name.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Name);
		}
		if (lastDateUsed_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(LastDateUsed);
		}
		if (lastModifiedDate_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(LastModifiedDate);
		}
		if (Category.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Category);
		}
		if (Notes.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Notes);
		}
		if (background_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Background);
		}
		if (chordChart_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(ChordChart);
		}
		if (selectedArrangement_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(SelectedArrangement);
		}
		num += arrangements_.CalculateSize(_repeated_arrangements_codec);
		num += cueGroups_.CalculateSize(_repeated_cueGroups_codec);
		num += cues_.CalculateSize(_repeated_cues_codec);
		if (ccli_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Ccli);
		}
		if (bibleReference_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(BibleReference);
		}
		if (timeline_ != null)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(Timeline);
		}
		if (transition_ != null)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(Transition);
		}
		if (ContentDestination != 0)
		{
			num += 2 + CodedOutputStream.ComputeEnumSize((int)ContentDestination);
		}
		if (HasSlideShowDuration)
		{
			num += 10;
		}
		if (multiTracksLicensing_ != null)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(MultiTracksLicensing);
		}
		if (MusicKey.Length != 0)
		{
			num += 2 + CodedOutputStream.ComputeStringSize(MusicKey);
		}
		if (music_ != null)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(Music);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(Presentation other)
	{
		if (other == null)
		{
			return;
		}
		if (other.applicationInfo_ != null)
		{
			if (applicationInfo_ == null)
			{
				ApplicationInfo = new ApplicationInfo();
			}
			ApplicationInfo.MergeFrom(other.ApplicationInfo);
		}
		if (other.uuid_ != null)
		{
			if (uuid_ == null)
			{
				Uuid = new UUID();
			}
			Uuid.MergeFrom(other.Uuid);
		}
		if (other.Name.Length != 0)
		{
			Name = other.Name;
		}
		if (other.lastDateUsed_ != null)
		{
			if (lastDateUsed_ == null)
			{
				LastDateUsed = new Timestamp();
			}
			LastDateUsed.MergeFrom(other.LastDateUsed);
		}
		if (other.lastModifiedDate_ != null)
		{
			if (lastModifiedDate_ == null)
			{
				LastModifiedDate = new Timestamp();
			}
			LastModifiedDate.MergeFrom(other.LastModifiedDate);
		}
		if (other.Category.Length != 0)
		{
			Category = other.Category;
		}
		if (other.Notes.Length != 0)
		{
			Notes = other.Notes;
		}
		if (other.background_ != null)
		{
			if (background_ == null)
			{
				Background = new Background();
			}
			Background.MergeFrom(other.Background);
		}
		if (other.chordChart_ != null)
		{
			if (chordChart_ == null)
			{
				ChordChart = new URL();
			}
			ChordChart.MergeFrom(other.ChordChart);
		}
		if (other.selectedArrangement_ != null)
		{
			if (selectedArrangement_ == null)
			{
				SelectedArrangement = new UUID();
			}
			SelectedArrangement.MergeFrom(other.SelectedArrangement);
		}
		arrangements_.Add(other.arrangements_);
		cueGroups_.Add(other.cueGroups_);
		cues_.Add(other.cues_);
		if (other.ccli_ != null)
		{
			if (ccli_ == null)
			{
				Ccli = new Types.CCLI();
			}
			Ccli.MergeFrom(other.Ccli);
		}
		if (other.bibleReference_ != null)
		{
			if (bibleReference_ == null)
			{
				BibleReference = new Types.BibleReference();
			}
			BibleReference.MergeFrom(other.BibleReference);
		}
		if (other.timeline_ != null)
		{
			if (timeline_ == null)
			{
				Timeline = new Types.Timeline();
			}
			Timeline.MergeFrom(other.Timeline);
		}
		if (other.transition_ != null)
		{
			if (transition_ == null)
			{
				Transition = new Transition();
			}
			Transition.MergeFrom(other.Transition);
		}
		if (other.ContentDestination != 0)
		{
			ContentDestination = other.ContentDestination;
		}
		if (other.multiTracksLicensing_ != null)
		{
			if (multiTracksLicensing_ == null)
			{
				MultiTracksLicensing = new Types.MultiTracksLicensing();
			}
			MultiTracksLicensing.MergeFrom(other.MultiTracksLicensing);
		}
		if (other.MusicKey.Length != 0)
		{
			MusicKey = other.MusicKey;
		}
		if (other.music_ != null)
		{
			if (music_ == null)
			{
				Music = new Types.Music();
			}
			Music.MergeFrom(other.Music);
		}
		if (other.SlideShowCase == SlideShowOneofCase.SlideShowDuration)
		{
			SlideShowDuration = other.SlideShowDuration;
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
				if (applicationInfo_ == null)
				{
					ApplicationInfo = new ApplicationInfo();
				}
				input.ReadMessage(ApplicationInfo);
				break;
			case 18u:
				if (uuid_ == null)
				{
					Uuid = new UUID();
				}
				input.ReadMessage(Uuid);
				break;
			case 26u:
				Name = input.ReadString();
				break;
			case 34u:
				if (lastDateUsed_ == null)
				{
					LastDateUsed = new Timestamp();
				}
				input.ReadMessage(LastDateUsed);
				break;
			case 42u:
				if (lastModifiedDate_ == null)
				{
					LastModifiedDate = new Timestamp();
				}
				input.ReadMessage(LastModifiedDate);
				break;
			case 50u:
				Category = input.ReadString();
				break;
			case 58u:
				Notes = input.ReadString();
				break;
			case 66u:
				if (background_ == null)
				{
					Background = new Background();
				}
				input.ReadMessage(Background);
				break;
			case 74u:
				if (chordChart_ == null)
				{
					ChordChart = new URL();
				}
				input.ReadMessage(ChordChart);
				break;
			case 82u:
				if (selectedArrangement_ == null)
				{
					SelectedArrangement = new UUID();
				}
				input.ReadMessage(SelectedArrangement);
				break;
			case 90u:
				arrangements_.AddEntriesFrom(input, _repeated_arrangements_codec);
				break;
			case 98u:
				cueGroups_.AddEntriesFrom(input, _repeated_cueGroups_codec);
				break;
			case 106u:
				cues_.AddEntriesFrom(input, _repeated_cues_codec);
				break;
			case 114u:
				if (ccli_ == null)
				{
					Ccli = new Types.CCLI();
				}
				input.ReadMessage(Ccli);
				break;
			case 122u:
				if (bibleReference_ == null)
				{
					BibleReference = new Types.BibleReference();
				}
				input.ReadMessage(BibleReference);
				break;
			case 138u:
				if (timeline_ == null)
				{
					Timeline = new Types.Timeline();
				}
				input.ReadMessage(Timeline);
				break;
			case 146u:
				if (transition_ == null)
				{
					Transition = new Transition();
				}
				input.ReadMessage(Transition);
				break;
			case 152u:
				ContentDestination = (Action.Types.ContentDestination)input.ReadEnum();
				break;
			case 161u:
				SlideShowDuration = input.ReadDouble();
				break;
			case 170u:
				if (multiTracksLicensing_ == null)
				{
					MultiTracksLicensing = new Types.MultiTracksLicensing();
				}
				input.ReadMessage(MultiTracksLicensing);
				break;
			case 178u:
				MusicKey = input.ReadString();
				break;
			case 186u:
				if (music_ == null)
				{
					Music = new Types.Music();
				}
				input.ReadMessage(Music);
				break;
			}
		}
	}
}
