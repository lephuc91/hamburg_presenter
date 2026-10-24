using System;
using Google.Protobuf;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.Entity;
using Pro.Serialization.Utility;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Presentation;

public class CCLIData : NotifyPropertyChangedBase
{
	private string _title = string.Empty;

	private string _artist = string.Empty;

	private string _author = string.Empty;

	private string _album = string.Empty;

	private string _publisher = string.Empty;

	private string _songNumber = string.Empty;

	private string _copyright = string.Empty;

	private byte[]? _artworkImageData;

	private bool _display;

	public string Title
	{
		get
		{
			return _title;
		}
		set
		{
			SetValue("Title", ref _title, value, OnPropertyChanged<string>(UndoActionTypes.CCLITitle, "Title"));
		}
	}

	public string Artist
	{
		get
		{
			return _artist;
		}
		set
		{
			SetValue("Artist", ref _artist, value, OnPropertyChanged<string>(UndoActionTypes.CCLIArtist, "Artist"));
		}
	}

	public string Author
	{
		get
		{
			return _author;
		}
		set
		{
			SetValue("Author", ref _author, value, OnPropertyChanged<string>(UndoActionTypes.CCLIAuthor, "Author"));
		}
	}

	public string Album
	{
		get
		{
			return _album;
		}
		set
		{
			SetValue("Album", ref _album, value, OnPropertyChanged<string>(UndoActionTypes.CCLIAuthor, "Album"));
		}
	}

	public string Publisher
	{
		get
		{
			return _publisher;
		}
		set
		{
			SetValue("Publisher", ref _publisher, value, OnPropertyChanged<string>(UndoActionTypes.CCLIPublisher, "Publisher"));
		}
	}

	public string SongNumber
	{
		get
		{
			return _songNumber;
		}
		set
		{
			SetValue("SongNumber", ref _songNumber, value, OnPropertyChanged<string>(UndoActionTypes.CCLISongNumber, "SongNumber"));
		}
	}

	public string Copyright
	{
		get
		{
			return _copyright;
		}
		set
		{
			SetValue("Copyright", ref _copyright, value, OnPropertyChanged<string>(UndoActionTypes.CCLICopyright, "Copyright"));
		}
	}

	public byte[]? ArtworkImageData
	{
		get
		{
			return _artworkImageData;
		}
		set
		{
			SetValue("ArtworkImageData", ref _artworkImageData, value, OnDataModified);
		}
	}

	public bool Display
	{
		get
		{
			return _display;
		}
		set
		{
			SetValue("Display", ref _display, value, OnPropertyChanged<bool>(UndoActionTypes.CCLIShow, "Display"));
		}
	}

	public UndoStack? UndoStack { get; set; }

	public event Action<CCLIData>? DataModified;

	public static ObjectBinder<CCLIData, Pro.Entity.IPresentation.Types.ICcli> CreateBinder(CCLIData left, Pro.Entity.IPresentation.Types.ICcli right)
	{
		ObjectBinder<CCLIData, Pro.Entity.IPresentation.Types.ICcli> objectBinder = new ObjectBinder<CCLIData, Pro.Entity.IPresentation.Types.ICcli>(left, right);
		objectBinder.Bind((CCLIData l) => l.WhenPropertyChanges("Author"), (Pro.Entity.IPresentation.Types.ICcli r) => r.Author.WhenValueChanges, delegate(CCLIData l, Pro.Entity.IPresentation.Types.ICcli r)
		{
			r.Author.Set(l.Author);
		}, delegate(Pro.Entity.IPresentation.Types.ICcli r, CCLIData l)
		{
			l.Author = r.Author.Value ?? string.Empty;
		}).Bind((CCLIData l) => l.WhenPropertyChanges("Album"), (Pro.Entity.IPresentation.Types.ICcli r) => r.Album.WhenValueChanges, delegate(CCLIData l, Pro.Entity.IPresentation.Types.ICcli r)
		{
			r.Album.Set(l.Album);
		}, delegate(Pro.Entity.IPresentation.Types.ICcli r, CCLIData l)
		{
			l.Album = r.Album.Value ?? string.Empty;
		}).Bind((CCLIData l) => l.WhenPropertyChanges("Artist"), (Pro.Entity.IPresentation.Types.ICcli r) => r.ArtistCredits.WhenValueChanges, delegate(CCLIData l, Pro.Entity.IPresentation.Types.ICcli r)
		{
			r.ArtistCredits.Set(l.Artist);
		}, delegate(Pro.Entity.IPresentation.Types.ICcli r, CCLIData l)
		{
			l.Artist = r.ArtistCredits.Value ?? string.Empty;
		})
			.Bind((CCLIData l) => l.WhenPropertyChanges("Title"), (Pro.Entity.IPresentation.Types.ICcli r) => r.SongTitle.WhenValueChanges, delegate(CCLIData l, Pro.Entity.IPresentation.Types.ICcli r)
			{
				r.SongTitle.Set(l.Title);
			}, delegate(Pro.Entity.IPresentation.Types.ICcli r, CCLIData l)
			{
				l.Title = r.SongTitle.Value ?? string.Empty;
			})
			.Bind((CCLIData l) => l.WhenPropertyChanges("Publisher"), (Pro.Entity.IPresentation.Types.ICcli r) => r.Publisher.WhenValueChanges, delegate(CCLIData l, Pro.Entity.IPresentation.Types.ICcli r)
			{
				r.Publisher.Set(l.Publisher);
			}, delegate(Pro.Entity.IPresentation.Types.ICcli r, CCLIData l)
			{
				l.Publisher = r.Publisher.Value ?? string.Empty;
			})
			.Bind((CCLIData l) => l.WhenPropertyChanges("Copyright"), (Pro.Entity.IPresentation.Types.ICcli r) => r.CopyrightYear.WhenValueChanges, delegate(CCLIData l, Pro.Entity.IPresentation.Types.ICcli r)
			{
				r.CopyrightYear.Set(uint.TryParse(l.Copyright, out var result) ? result : 0u);
			}, delegate(Pro.Entity.IPresentation.Types.ICcli r, CCLIData l)
			{
				l.Copyright = ((r.CopyrightYear.Value != 0) ? (r.CopyrightYear.Value.ToString() ?? string.Empty) : string.Empty);
			})
			.Bind((CCLIData l) => l.WhenPropertyChanges("SongNumber"), (Pro.Entity.IPresentation.Types.ICcli r) => r.SongNumber.WhenValueChanges, delegate(CCLIData l, Pro.Entity.IPresentation.Types.ICcli r)
			{
				r.SongNumber.Set(uint.TryParse(l.SongNumber, out var result2) ? result2 : 0u);
			}, delegate(Pro.Entity.IPresentation.Types.ICcli r, CCLIData l)
			{
				l.SongNumber = ((r.SongNumber.Value != 0) ? (r.SongNumber.Value.ToString() ?? string.Empty) : string.Empty);
			})
			.Bind((CCLIData l) => l.WhenPropertyChanges("ArtworkImageData"), (Pro.Entity.IPresentation.Types.ICcli r) => r.Artwork.WhenValueChanges, delegate(CCLIData l, Pro.Entity.IPresentation.Types.ICcli r)
			{
				r.Artwork.Set(l.ArtworkImageData ?? Array.Empty<byte>());
			}, delegate(Pro.Entity.IPresentation.Types.ICcli r, CCLIData l)
			{
				l.ArtworkImageData = r.Artwork.Value ?? Array.Empty<byte>();
			})
			.Bind((CCLIData l) => l.WhenPropertyChanges("Display"), (Pro.Entity.IPresentation.Types.ICcli r) => r.Display.WhenValueChanges, delegate(CCLIData l, Pro.Entity.IPresentation.Types.ICcli r)
			{
				r.Display.Set(l.Display);
			}, delegate(Pro.Entity.IPresentation.Types.ICcli r, CCLIData l)
			{
				l.Display = r.Display.Value;
			});
		return objectBinder;
	}

	internal Pro.SerializationInterop.RVProtoData.Presentation.Types.CCLI Serialize()
	{
		uint result;
		uint result2;
		return new Pro.SerializationInterop.RVProtoData.Presentation.Types.CCLI
		{
			Author = (Author ?? string.Empty),
			Album = (Album ?? string.Empty),
			ArtistCredits = (Artist ?? string.Empty),
			SongTitle = (Title ?? string.Empty),
			Publisher = (Publisher ?? string.Empty),
			CopyrightYear = (uint.TryParse(Copyright, out result) ? result : 0u),
			SongNumber = (uint.TryParse(SongNumber, out result2) ? result2 : 0u),
			Artwork = (ArtworkImageData?.ToByteString() ?? ByteString.Empty),
			Display = Display
		};
	}

	internal void Deserialize(Pro.SerializationInterop.RVProtoData.Presentation.Types.CCLI data)
	{
		if (data != null)
		{
			Author = data.Author ?? string.Empty;
			Album = data.Album ?? string.Empty;
			Artist = data.ArtistCredits ?? string.Empty;
			Title = data.SongTitle ?? string.Empty;
			Publisher = data.Publisher ?? string.Empty;
			Copyright = ((data.CopyrightYear != 0) ? data.CopyrightYear.ToString() : string.Empty);
			SongNumber = ((data.SongNumber != 0) ? data.SongNumber.ToString() : string.Empty);
			ArtworkImageData = data.Artwork?.ToByteArray();
			Display = data.Display;
		}
	}

	public void Copy(CCLIData data)
	{
		Author = data.Author;
		Album = data.Album;
		Artist = data.Artist;
		Title = data.Title;
		Publisher = data.Publisher;
		Copyright = data.Copyright;
		SongNumber = data.SongNumber;
		ArtworkImageData = data.ArtworkImageData;
		Display = data.Display;
	}

	private void OnDataModified()
	{
		this.DataModified?.Invoke(this);
	}

	private Action<T, T> OnPropertyChanged<T>(UndoActionTypes undoActionType, string name)
	{
		return delegate(T o, T n)
		{
			UndoStack?.Commit(undoActionType.ToAction(), this, name, o, n);
			OnDataModified();
		};
	}
}
