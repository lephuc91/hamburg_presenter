namespace ProPresenter.Rendering;

public static class RenderingModeExtensions
{
	public static bool IsOutputMode(this RenderingMode mode)
	{
		if (mode != 0 && mode != RenderingMode.OutputUnder && mode != RenderingMode.OutputContentMask && mode != RenderingMode.OutputStageFlash && mode != RenderingMode.OutputOver && mode != RenderingMode.OutputSegment)
		{
			return mode == RenderingMode.OutputTextLayer;
		}
		return true;
	}

	public static bool IsTextOnlyMode(this RenderingMode mode)
	{
		return mode == RenderingMode.OutputTextLayer;
	}

	public static bool IsEditor(this RenderingMode mode)
	{
		return mode == RenderingMode.Editor;
	}
}
