namespace ProPresenter.Controller;

public class DestroyRenderViewParameters
{
	public nint RenderViewHandle { get; }

	public DestroyRenderViewParameters(nint renderView)
	{
		RenderViewHandle = renderView;
	}
}
