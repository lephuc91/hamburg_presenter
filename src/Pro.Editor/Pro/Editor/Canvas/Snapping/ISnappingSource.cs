using System.Collections.Generic;
using Pro.Common.Mathematics;

namespace Pro.Editor.Canvas.Snapping;

public interface ISnappingSource
{
	Rect<double> Bounds { get; }

	IEnumerable<ICanvasElement> Elements { get; }

	IEnumerable<ICanvasElement>? IgnoredElements { get; }

	bool IsTargetValid(ISnappingSource snappingSource);

	IEnumerable<ISnapLine> GenerateHorizontalSnapLines(ISnappingSource? targetSource);

	IEnumerable<ISnapLine> GenerateVerticalSnapLines(ISnappingSource? targetSource);

	void IgnoreElements(IEnumerable<ICanvasElement> elements);

	void UnignoreElements();
}
