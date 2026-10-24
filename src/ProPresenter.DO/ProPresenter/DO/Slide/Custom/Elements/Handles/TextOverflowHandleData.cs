using Pro.Common.Mathematics;
using Pro.Editor.Canvas.Handles;

namespace ProPresenter.DO.Slide.Custom.Elements.Handles;

public class TextOverflowHandleData : IHandleData
{
	public Vector2<double> Location => AttachedElement.Position;

	public ClosedBezierPath AttachedElement { get; }

	public TextOverflowHandleData(ClosedBezierPath attachedElement)
	{
		AttachedElement = attachedElement;
	}
}
