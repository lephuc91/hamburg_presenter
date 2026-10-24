using ProPresenter.DO.Actions;
using ProPresenter.DO.Cues;
using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.Controller.Triggering;

public record MediaTriggeredParameters(MediaCue? OriginalMediaCue, MediaAction? MediaAction, ProLayerIndex Layer, ProResourceState ResourceState);
