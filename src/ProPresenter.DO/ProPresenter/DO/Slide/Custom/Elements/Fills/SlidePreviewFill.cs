using System;
using System.Windows.Media;

namespace ProPresenter.DO.Slide.Custom.Elements.Fills;

public class SlidePreviewFill : FillBase
{
	public override FillType Type => FillType.SlidePreview;

	public override string DisplayName => string.Empty;

	public CustomSlide? TargetSlide { get; }

	public bool IncludeBackground { get; }

	public Color? SecondaryBackgroundColor { get; }

	public SlidePreviewFill(CustomSlide? targetSlide, bool includeBackground, Color? secondaryBackgroundColor)
	{
		TargetSlide = targetSlide;
		IncludeBackground = includeBackground;
		SecondaryBackgroundColor = secondaryBackgroundColor;
	}

	public override IFill Clone()
	{
		return new SlidePreviewFill(TargetSlide, IncludeBackground, SecondaryBackgroundColor);
	}

	public override Color Sample()
	{
		throw new NotSupportedException();
	}
}
