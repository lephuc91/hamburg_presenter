namespace ProPresenter.Rendering;

public struct BezierPathRenderParams
{
	public bool IncludeText { get; }

	public bool Highlight { get; }

	public bool IncludeRotation { get; }

	public bool IncludePosition { get; }

	public bool IncludeTextPlaceholder { get; }

	public double Scale { get; }

	public bool UseFullSizeMedia { get; }

	public RenderingMode RenderingMode { get; }

	public int TextIndex { get; }

	public bool IncludeLinkIndicator { get; }

	public BezierPathRenderParams(bool includeText, bool highlight, bool includeRotation, bool includePosition, bool includeTextPlaceholder, double scale, bool useFullsizeMedia, RenderingMode renderMode, int textIndex = 0, bool includeLinkIndicator = true)
	{
		IncludeText = includeText;
		Highlight = highlight;
		IncludeRotation = includeRotation;
		IncludePosition = includePosition;
		IncludeTextPlaceholder = includeTextPlaceholder;
		Scale = scale;
		UseFullSizeMedia = useFullsizeMedia;
		RenderingMode = renderMode;
		TextIndex = textIndex;
		IncludeLinkIndicator = includeLinkIndicator;
	}
}
