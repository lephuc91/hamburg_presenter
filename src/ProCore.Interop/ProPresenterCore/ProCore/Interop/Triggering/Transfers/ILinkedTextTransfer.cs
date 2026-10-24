using System;
using Pro.SerializationInterop.RVProtoData;
using ProPresenterCore.ProCore.Interop.Triggering.Types;

namespace ProPresenterCore.ProCore.Interop.Triggering.Transfers;

public interface ILinkedTextTransfer
{
	string StageMessage { get; }

	TimeSpan PresentationVideoTimeRemaining { get; }

	TimeSpan AnnouncementVideoTimeRemaining { get; }

	TimeSpan AudioTimeRemaining { get; }

	bool PresentationVideoLooping { get; }

	bool AnnouncementVideoLooping { get; }

	bool AudioLooping { get; }

	ResourceAddress SlideLink { get; }

	ResourceAddress ActivePlaylistItemLink { get; }

	TriggerTransferRenderState? RenderState { get; }
}
