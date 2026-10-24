namespace ProPresenter.Controller;

public class CreateRenderViewParameters
{
	public RenderViewType RenderViewType { get; }

	public nint HostHandle { get; }

	public nint RenderViewHandle { get; set; }

	public CreateRenderViewParameters(RenderViewType type, nint hostHandle)
	{
		RenderViewType = type;
		HostHandle = hostHandle;
	}
}
