using Pro.Entity;
using ProPresenter.DO.Slide.Custom.Elements;

namespace ProPresenter.DO.Slide.Custom;

public record ShapeShiftData(BezierPath OldLeft, BezierPath NewLeft, IGraphics.Types.IPath Right);
