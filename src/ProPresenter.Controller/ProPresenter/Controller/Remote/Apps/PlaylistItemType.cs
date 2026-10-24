using System.Runtime.Serialization;

namespace ProPresenter.Controller.Remote.Apps;

public enum PlaylistItemType
{
	[EnumMember(Value = "playlistItemTypePresentation")]
	Presentation,
	[EnumMember(Value = "playlistItemTypeHeader")]
	Header,
	[EnumMember(Value = "playlistItemTypeAudio")]
	Audio,
	[EnumMember(Value = "playlistItemTypeVideo")]
	Video
}
