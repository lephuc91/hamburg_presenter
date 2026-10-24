using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Pro.Common.Components.Reversibility;
using Pro.Common.HTTP;
using Pro.Common.Logging;
using Pro.Common.Nullability;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.DO.Storage;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.Localization;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Slide.Links.Text.RssFeed;

namespace ProPresenter.DO.Slide.Links;

public class RssFeedLinkedObject : LinkedTextObjectBase
{
	private string _url = string.Empty;

	private RssFeedContentMode _contentMode;

	private string? _textDelimiter;

	public override LinkedTextType LinkedTextType => LinkedTextType.RssFeed;

	public override FormattingType FormattingType => FormattingType.None;

	public override string DisplayText
	{
		get
		{
			if (!string.IsNullOrEmpty(Url))
			{
				return LocalizedStrings.Get("TEXT_LINK_TEXT_TICKER_RSS_SOURCE_title") + " " + RssFeedUtility.GetAbsoluteUri(Url);
			}
			return LocalizedStrings.Get("TEXT_TICKER_SOURCE_RSS_FEED_title");
		}
	}

	public string DisplayRssTextForLinkedObject
	{
		get
		{
			if (!string.IsNullOrEmpty(Url))
			{
				return LocalizedStrings.Get("TEXT_TICKER_SOURCE_RSS_FEED_title") + " " + RssFeedUtility.GetAbsoluteUri(Url);
			}
			return LocalizedStrings.Get("TEXT_TICKER_SOURCE_RSS_FEED_title");
		}
	}

	public string[]? Content { get; private set; }

	public bool IsValid => Content?.Any() ?? false;

	public string Url
	{
		get
		{
			return _url;
		}
		set
		{
			SetValue("Url", ref _url, value, OnUrlChanged);
		}
	}

	public RssFeedContentMode ContentMode
	{
		get
		{
			return _contentMode;
		}
		set
		{
			SetValue("ContentMode", ref _contentMode, value, OnContentModeChanged);
		}
	}

	public string? TextDelimiter
	{
		get
		{
			return _textDelimiter ?? string.Empty;
		}
		set
		{
			SetValue("TextDelimiter", ref _textDelimiter, value, OnTextDelimiterChanged);
		}
	}

	public static ObjectBinder<RssFeedLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.IRssFeed> CreateBinder(RssFeedLinkedObject left, ISlide.Types.IElement.Types.IDataLink.Types.IRssFeed right)
	{
		ObjectBinder<RssFeedLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.IRssFeed> objectBinder = new ObjectBinder<RssFeedLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.IRssFeed>(left, right);
		objectBinder.Bind((RssFeedLinkedObject l) => l.WhenPropertyChanges("Url"), (ISlide.Types.IElement.Types.IDataLink.Types.IRssFeed r) => r.Url.WhenValueChanges, delegate(RssFeedLinkedObject l, ISlide.Types.IElement.Types.IDataLink.Types.IRssFeed r)
		{
			r.Url.Set(RelativePath.CreateWeb(l.Url));
		}, delegate(ISlide.Types.IElement.Types.IDataLink.Types.IRssFeed r, RssFeedLinkedObject l)
		{
			l.Url = (r.Url.Value?.Storage as Url.Types.Storage.AbsoluteString)?._AbsoluteString ?? string.Empty;
		}).Bind((RssFeedLinkedObject l) => l.WhenPropertyChanges("ContentMode"), (ISlide.Types.IElement.Types.IDataLink.Types.IRssFeed r) => r.Content.WhenValueChanges, delegate(RssFeedLinkedObject l, ISlide.Types.IElement.Types.IDataLink.Types.IRssFeed r)
		{
			r.Content.Set(l.ContentMode.ToEntityRssContentType());
		}, delegate(ISlide.Types.IElement.Types.IDataLink.Types.IRssFeed r, RssFeedLinkedObject l)
		{
			l.ContentMode = r.Content.Value.ToRssFeedContentMode();
		}).Bind((RssFeedLinkedObject l) => l.WhenPropertyChanges("TextDelimiter"), (ISlide.Types.IElement.Types.IDataLink.Types.IRssFeed r) => r.TextDelimiter.WhenValueChanges, delegate(RssFeedLinkedObject l, ISlide.Types.IElement.Types.IDataLink.Types.IRssFeed r)
		{
			r.TextDelimiter.Set(l.TextDelimiter ?? string.Empty);
		}, delegate(ISlide.Types.IElement.Types.IDataLink.Types.IRssFeed r, RssFeedLinkedObject l)
		{
			l.TextDelimiter = r.TextDelimiter.Value;
		});
		return objectBinder;
	}

	public override string GetText(ILinkData? linkData)
	{
		if (linkData == null)
		{
			if (string.IsNullOrEmpty(Url))
			{
				return LocalizedStrings.Get("TEXT_LINK_TEXT_TICKER_RSS_SOURCE_title");
			}
			return LocalizedStrings.Get("TEXT_LINK_TEXT_TICKER_RSS_SOURCE_title") + " " + RssFeedUtility.GetAbsoluteUri(Url);
		}
		LoadRssContent(linkData.RestClientFactory);
		if (Content != null)
		{
			return string.Join(TextDelimiter.NullableIsNullOrEmpty() ? " " : TextDelimiter, Content);
		}
		return string.Empty;
	}

	public override bool RenderEquals([NotNullWhen(true)] ILinkedTextObject? other)
	{
		if (other is RssFeedLinkedObject rssFeedLinkedObject && _url == rssFeedLinkedObject._url && _contentMode == rssFeedLinkedObject._contentMode)
		{
			return _textDelimiter == rssFeedLinkedObject._textDelimiter;
		}
		return false;
	}

	public override int GetRenderHashCode()
	{
		return RenderHashCodeHelper.GenerateHashCode(_url, _contentMode, _textDelimiter);
	}

	public override ILinkedTextObject Clone()
	{
		return new RssFeedLinkedObject
		{
			Content = Content,
			_url = _url,
			_contentMode = _contentMode,
			_textDelimiter = _textDelimiter
		};
	}

	public override void Serialize(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink dataLink)
	{
		dataLink.RssFeed = new Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.RSSFeed
		{
			Url = Url.WebURLToProtoURL(),
			Content = ContentMode.ToProtoRSSContentType(),
			TextDelimiter = (TextDelimiter ?? string.Empty)
		};
	}

	public static RssFeedLinkedObject Deserialize(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.RSSFeed rssFeed)
	{
		return new RssFeedLinkedObject
		{
			Url = (rssFeed.Url?.AbsoluteString ?? string.Empty),
			ContentMode = rssFeed.Content.ToRssFeedContentMode(),
			TextDelimiter = rssFeed.TextDelimiter
		};
	}

	private void LoadRssContent(IRestClientFactory restClientFactory)
	{
		if (!InternetAccessCheck.IsInternetAvailable())
		{
			return;
		}
		try
		{
			Content = RssFeedUtility.ParseFeed(RssFeedUtility.LoadFeed(Url, restClientFactory), ContentMode);
		}
		catch (Exception exception)
		{
			Log.Error(exception);
		}
	}

	private void OnUrlChanged(string o, string n)
	{
		OnChange(UndoActionTypes.TickerSourceRSSUrl, "Url", o, n);
	}

	private void OnContentModeChanged(RssFeedContentMode o, RssFeedContentMode n)
	{
		OnChange(UndoActionTypes.TickerSourceRSSContentMode, "ContentMode", o, n, autoFinalize: true);
	}

	private void OnTextDelimiterChanged(string o, string n)
	{
		OnChange(UndoActionTypes.TickerDelimiter, "TextDelimiter", o, n);
	}

	private void OnChange(UndoActionTypes undoAction, string propertyName, object o, object n, bool autoFinalize = false)
	{
		base.UndoStack?.Commit(undoAction.ToAction(), this, propertyName, o, n, null, null, autoFinalize);
		OnDataModified();
	}
}
