using System;
using System.Diagnostics.CodeAnalysis;
using Pro.Common.Components.Reversibility;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.Entity;
using Pro.Localization;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Slide.Links;

public class PlaylistItemLinkedObject : LinkedTextObjectBase
{
	public PlaylistItemSource _playlistItemSource = PlaylistItemSource.Current;

	private bool _showArrangement;

	public override LinkedTextType LinkedTextType => LinkedTextType.PlaylistItem;

	public override string DisplayText => LocalizedStrings.Get(LinkedTextType) + " - " + LocalizedStrings.Get(PlaylistItemSource);

	public override FormattingType FormattingType => FormattingType.None;

	public PlaylistItemSource PlaylistItemSource
	{
		get
		{
			return _playlistItemSource;
		}
		set
		{
			SetValue("PlaylistItemSource", ref _playlistItemSource, value, delegate(PlaylistItemSource o, PlaylistItemSource n)
			{
				base.UndoStack?.Commit(UndoActionTypes.PlaylistItem.ToAction(), this, "PlaylistItemSource", o, n);
				OnDataModified();
			});
		}
	}

	public bool ShowArrangement
	{
		get
		{
			return _showArrangement;
		}
		set
		{
			SetValue("ShowArrangement", ref _showArrangement, value, delegate(bool o, bool n)
			{
				base.UndoStack?.Commit(UndoActionTypes.ShowArrangement.ToAction(), this, "ShowArrangement", o, n);
				OnDataModified();
			});
		}
	}

	public static ObjectBinder<PlaylistItemLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.IPlaylistItem> CreateBinder(PlaylistItemLinkedObject left, ISlide.Types.IElement.Types.IDataLink.Types.IPlaylistItem right)
	{
		ObjectBinder<PlaylistItemLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.IPlaylistItem> objectBinder = new ObjectBinder<PlaylistItemLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.IPlaylistItem>(left, right);
		objectBinder.Bind((PlaylistItemLinkedObject l) => l.WhenPropertyChanges("ShowArrangement"), (ISlide.Types.IElement.Types.IDataLink.Types.IPlaylistItem r) => r.ShowArrangement.WhenValueChanges, delegate(PlaylistItemLinkedObject l, ISlide.Types.IElement.Types.IDataLink.Types.IPlaylistItem r)
		{
			r.ShowArrangement.Set(l.ShowArrangement);
		}, delegate(ISlide.Types.IElement.Types.IDataLink.Types.IPlaylistItem r, PlaylistItemLinkedObject l)
		{
			l.ShowArrangement = r.ShowArrangement.Value;
		}).Bind((PlaylistItemLinkedObject l) => l.WhenPropertyChanges("PlaylistItemSource"), (ISlide.Types.IElement.Types.IDataLink.Types.IPlaylistItem r) => r.PlaylistItemSource.WhenValueChanges, delegate(PlaylistItemLinkedObject l, ISlide.Types.IElement.Types.IDataLink.Types.IPlaylistItem r)
		{
			r.PlaylistItemSource.Set(l.PlaylistItemSource.ToEntityPlaylistitemSource());
		}, delegate(ISlide.Types.IElement.Types.IDataLink.Types.IPlaylistItem r, PlaylistItemLinkedObject l)
		{
			l.PlaylistItemSource = r.PlaylistItemSource.Value.ToPlaylistItemSource();
		});
		return objectBinder;
	}

	public override bool RenderEquals([NotNullWhen(true)] ILinkedTextObject? other)
	{
		if (other is PlaylistItemLinkedObject playlistItemLinkedObject)
		{
			return _playlistItemSource == playlistItemLinkedObject._playlistItemSource;
		}
		return false;
	}

	public override int GetRenderHashCode()
	{
		return _playlistItemSource.GetHashCode();
	}

	public override ILinkedTextObject Clone()
	{
		return new PlaylistItemLinkedObject
		{
			PlaylistItemSource = PlaylistItemSource,
			ShowArrangement = ShowArrangement
		};
	}

	public override void Serialize(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink dataLink)
	{
		dataLink.PlaylistItem = new Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.PlaylistItem
		{
			PlaylistItemSource = PlaylistItemSource.ToProtoPlaylistItemSource(),
			ShowArrangement = ShowArrangement
		};
	}

	public static PlaylistItemLinkedObject Deserialize(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.PlaylistItem protoPlaylistItem)
	{
		return new PlaylistItemLinkedObject
		{
			PlaylistItemSource = protoPlaylistItem.PlaylistItemSource.ToPlaylistItemSource(),
			ShowArrangement = protoPlaylistItem.ShowArrangement
		};
	}

	public override string GetText(ILinkData? linkData)
	{
		IPlaylistItemInfo playlistItemInfo = linkData?.PlaylistItemInfo;
		return PlaylistItemSource switch
		{
			PlaylistItemSource.Current => getItemName(playlistItemInfo?.CurrentPlaylistItem ?? LocalizedStrings.Get("TEXT_LINK_PLAYLIST_ITEM_PLACEHOLDER_title"), playlistItemInfo?.CurrentPlaylistItemArrangement ?? string.Empty), 
			PlaylistItemSource.Next => getItemName(playlistItemInfo?.NextPlaylistItem ?? LocalizedStrings.Get("TEXT_LINK_PLAYLIST_ITEM_PLACEHOLDER_title"), playlistItemInfo?.NextPlaylistItemArrangement ?? string.Empty), 
			PlaylistItemSource.CurrentHeader => playlistItemInfo?.CurrentHeader ?? LocalizedStrings.Get("TEXT_LINK_PLAYLIST_HEADER_PLACEHOLDER_title"), 
			PlaylistItemSource.NextHeader => playlistItemInfo?.NextHeader ?? LocalizedStrings.Get("TEXT_LINK_PLAYLIST_HEADER_PLACEHOLDER_title"), 
			PlaylistItemSource.ParentPlaylist => playlistItemInfo?.Playlist ?? LocalizedStrings.Get("TEXT_LINK_PLAYLIST_ITEM_PARENT_PLAYLIST_PLACEHOLDER_title"), 
			_ => throw new NotSupportedException(), 
		};
		string getItemName(string itemName, string arrangementName)
		{
			if (!ShowArrangement || string.IsNullOrEmpty(itemName) || string.IsNullOrEmpty(arrangementName))
			{
				return itemName;
			}
			return itemName + " - [ " + arrangementName + " ]";
		}
	}
}
