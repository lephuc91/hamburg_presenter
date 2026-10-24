using System.Collections.Generic;
using ProPresenter.DO.Cues;
using ProPresenter.UI.Thumbnails;

namespace ProPresenter.UI.ViewModels.Props;

public record DropPropCommandParameter(IDocumentCue? Document, Thumbnail? TargetThumbnail, bool DroppedBefore, bool DroppedOutside, IEnumerable<IPropCueVM> Props);
