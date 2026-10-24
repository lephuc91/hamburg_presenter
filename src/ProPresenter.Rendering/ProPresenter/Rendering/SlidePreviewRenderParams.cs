using System.Windows.Media;
using Pro.Common.Mathematics;
using ProPresenter.DO.Slide.Custom.Elements;

namespace ProPresenter.Rendering;

public record struct SlidePreviewRenderParams(Vector2<int> PreviewSize, bool IncludeBackground, bool IncludeBackgroundMedia, Color SecondaryBackground, ElementsRenderOption ElementsRenderOption = ElementsRenderOption.None, SlideElementBase[]? SlideElements = null, bool IncludeTextPlaceholder = false, bool UseFullSizeMedia = false, bool UseScreenScalar = true, bool IncludeLinkIndicator = true, bool ForceBackgroundColorDraw = false);
