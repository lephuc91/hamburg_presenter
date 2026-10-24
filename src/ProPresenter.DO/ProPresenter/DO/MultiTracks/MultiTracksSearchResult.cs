using System.Windows.Media.Imaging;
using Pro.Common.Components;
using Pro.Common.Utility;
using ProPresenter.DO.Chords;

namespace ProPresenter.DO.MultiTracks;

public class MultiTracksSearchResult : NotifyPropertyChangedBase, IMultiTracksSearchResult
{
	private BitmapSource? _image;

	private bool _isLoadingImage;

	public long ID { get; }

	public string Title { get; }

	public string Album { get; }

	public string Artist { get; }

	public string ImageURL { get; }

	public string LyricsPreview { get; }

	public Key? OriginalKey { get; }

	public bool HasLyrics { get; }

	public bool HasChords { get; }

	public bool HasAutomation { get; }

	public BitmapSource? Image
	{
		get
		{
			if (_image == null && !_isLoadingImage)
			{
				_isLoadingImage = true;
				if (!string.IsNullOrWhiteSpace(ImageURL))
				{
					ImageHelper.LoadImageFromURLAsync(ImageURL, delegate(BitmapSource? b)
					{
						_image = b;
						OnPropertyChanged("Image");
					});
				}
			}
			return _image;
		}
	}

	public MultiTracksSearchResult(long id, string title, string album, string artist, string imageURL, string lyricsPreview, Key? originalKey, bool slideProSubscriptionActive)
	{
		ID = id;
		Title = title;
		Album = album;
		Artist = artist;
		ImageURL = imageURL;
		LyricsPreview = lyricsPreview;
		OriginalKey = originalKey;
		HasLyrics = (lyricsPreview?.Length ?? 0) > 0;
		HasChords = slideProSubscriptionActive;
		HasAutomation = slideProSubscriptionActive;
	}
}
