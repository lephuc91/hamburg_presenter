using ProPresenter.DO.Cues;

namespace ProPresenter.Controller;

public record TimelineStatus(IDocumentCue? Document, TimedPlaybackStatus Status, bool IsRecording);
