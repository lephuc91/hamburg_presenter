using Pro.Common.Components;
using Pro.Common.Dispatcher;
using Pro.Common.ObjectBinding;
using Pro.DO.Application;
using Pro.DO.Triggering;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Cues;

public abstract class ProPresenterCue : Pro.DO.Triggering.Cue, ICloneable<ProPresenterCue>
{
	private bool _isHidden;

	public abstract CueType Type { get; }

	public bool IsHidden
	{
		get
		{
			return _isHidden;
		}
		set
		{
			SetValue("IsHidden", ref _isHidden, value, base.OnDataModified);
		}
	}

	protected ProPresenterCue(bool newID = true)
		: base(newID)
	{
	}

	ProPresenterCue ICloneable<ProPresenterCue>.Clone()
	{
		return (ProPresenterCue)Clone();
	}

	public void ProtoDeserialize(Pro.SerializationInterop.RVProtoData.Cue protoCue, ApplicationData? applicationData, string containerId)
	{
		Deserialize(protoCue, applicationData, containerId);
		OnDeserialize(protoCue);
	}

	protected virtual void OnDeserialize(Pro.SerializationInterop.RVProtoData.Cue data)
	{
	}

	public PlaylistItem ProtoSerializePlaylistItem()
	{
		PlaylistItem playlistItem = new PlaylistItem
		{
			Uuid = base.ID.ToUUID(),
			IsHidden = IsHidden,
			Name = Name
		};
		OnProtoSerializePlaylistItem(playlistItem);
		return playlistItem;
	}

	public void ProtoDeserializePlaylistItem(PlaylistItem playlistItem, ApplicationData? applicationData, string containerId)
	{
		base.ID = playlistItem.Uuid.ToGuid();
		IsHidden = playlistItem.IsHidden;
		OnProtoDeserializePlaylistItem(playlistItem, applicationData, containerId);
	}

	protected virtual void OnProtoSerializePlaylistItem(PlaylistItem playlistItem)
	{
	}

	protected virtual void OnProtoDeserializePlaylistItem(PlaylistItem playlistItem, ApplicationData? applicationData, string containerId)
	{
		Name = playlistItem.Name;
	}

	public abstract IReadOnlyObjectBinder<ProPresenterCue, IPlaylistItem> Bind(IUiScheduler scheduler, IEntityFactory entityFactory, IActionBinderFactory actionBinderFactory, IPlaylistItem right);
}
