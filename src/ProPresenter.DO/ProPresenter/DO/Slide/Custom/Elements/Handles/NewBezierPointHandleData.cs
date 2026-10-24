using Pro.Editor.Canvas.Handles;

namespace ProPresenter.DO.Slide.Custom.Elements.Handles;

public class NewBezierPointHandleData : IHandleData
{
	public BezierPoint Endpoint { get; }

	public BezierPoint StartPoint { get; }

	public BezierPath Path { get; }

	public NewBezierPointHandleData(BezierPath path, BezierPoint startPoint, BezierPoint endpoint)
	{
		Path = path;
		StartPoint = startPoint;
		Endpoint = endpoint;
	}
}
