using System;
using System.Windows.Media;
using Pro.Common.Utility;
using ProPresenter.DO;
using ProPresenter.DO.Slide.Custom;

namespace ProPresenter.Rendering;

internal class SlidePreviewBitmapKey : IEquatable<SlidePreviewBitmapKey>
{
	private readonly CustomSlide _slide;

	private readonly bool _includeBackground;

	private readonly bool _includeBackgroundMedia;

	private readonly bool _useFullSizeMedia;

	private readonly Color _secondaryBackground;

	private readonly ElementsRenderOption _elementsRenderOption;

	private readonly bool _includeTextPlaceholder;

	private readonly int _hashCode;

	public SlidePreviewBitmapKey(CustomSlide slide, SlidePreviewRenderParams renderParams)
	{
		_slide = slide;
		_includeBackground = renderParams.IncludeBackground;
		_includeBackgroundMedia = renderParams.IncludeBackgroundMedia;
		_useFullSizeMedia = renderParams.UseFullSizeMedia;
		_secondaryBackground = renderParams.SecondaryBackground;
		_elementsRenderOption = renderParams.ElementsRenderOption;
		_includeTextPlaceholder = renderParams.IncludeTextPlaceholder;
		_hashCode = RenderHashCodeHelper.GenerateHashCode(_slide, _includeBackground, _includeBackgroundMedia, _useFullSizeMedia, _secondaryBackground, _elementsRenderOption, _includeTextPlaceholder);
	}

	public override int GetHashCode()
	{
		return _hashCode;
	}

	public override bool Equals(object? obj)
	{
		if (obj is SlidePreviewBitmapKey other)
		{
			return Equals(other);
		}
		return false;
	}

	public bool Equals(SlidePreviewBitmapKey? other)
	{
		if ((object)other != null && _slide.RenderEquals(other._slide) && _includeBackground == other._includeBackground && _includeBackgroundMedia == other._includeBackgroundMedia && _useFullSizeMedia == other._useFullSizeMedia && _secondaryBackground == other._secondaryBackground && _elementsRenderOption == other._elementsRenderOption)
		{
			return _includeTextPlaceholder == other._includeTextPlaceholder;
		}
		return false;
	}

	public static bool operator ==(SlidePreviewBitmapKey lhs, SlidePreviewBitmapKey rhs)
	{
		return lhs.NullableEquals<SlidePreviewBitmapKey>(rhs);
	}

	public static bool operator !=(SlidePreviewBitmapKey lhs, SlidePreviewBitmapKey rhs)
	{
		return !lhs.NullableEquals<SlidePreviewBitmapKey>(rhs);
	}
}
