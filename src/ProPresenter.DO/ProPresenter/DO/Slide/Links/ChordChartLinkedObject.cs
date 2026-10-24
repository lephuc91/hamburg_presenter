using System.Diagnostics.CodeAnalysis;
using Pro.Common.Utility;
using Pro.Localization;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Slide.Custom;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.Slide.Custom.Elements.Fills;

namespace ProPresenter.DO.Slide.Links;

public class ChordChartLinkedObject : LinkedFillObjectBase
{
	public override LinkedFillType LinkedFillType => LinkedFillType.ChordChart;

	public override string DisplayText => LocalizedStrings.Get("FILL_LINK_CHORD_CHART_title");

	public override bool RenderEquals([NotNullWhen(true)] ILinkedFillObject? other)
	{
		return other is ChordChartLinkedObject;
	}

	public override int GetRenderHashCode()
	{
		return GetHashCode();
	}

	public override IFill? GetFill(ILinkData? linkData)
	{
		if (!(linkData?.CurrentSlide is CustomSlide customSlide))
		{
			return null;
		}
		return new BitmapFill(ImageHelper.LoadImage(customSlide.ChordChart));
	}

	public override ILinkedFillObject Clone()
	{
		return new ChordChartLinkedObject();
	}

	public override void Serialize(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink dataLink)
	{
		dataLink.ChordChart = new Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.ChordChart();
	}
}
