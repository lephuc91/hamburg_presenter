using System.Diagnostics.CodeAnalysis;
using System.Windows.Media;
using Pro.Localization;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.Slide.Custom.Elements.Fills;

namespace ProPresenter.DO.Slide.Links;

public class TimecodeStatusColorLinkedObject : LinkedFillObjectBase
{
	public override LinkedFillType LinkedFillType => LinkedFillType.TimecodeStatusColor;

	public override string DisplayText => LocalizedStrings.Get(LinkedFillType) ?? "";

	public override ILinkedFillObject Clone()
	{
		return new TimecodeStatusColorLinkedObject();
	}

	public override IFill GetFill(ILinkData? linkData)
	{
		return new SolidColorFill
		{
			Color = (linkData?.Timecode?.StatusColor ?? Colors.Transparent)
		};
	}

	public override int GetRenderHashCode()
	{
		return GetHashCode();
	}

	public override bool RenderEquals([NotNullWhen(true)] ILinkedFillObject? other)
	{
		return other is TimecodeStatusColorLinkedObject;
	}

	public override void Serialize(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink dataLink)
	{
		dataLink.TimecodeStatus = new Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.TimecodeStatus();
	}
}
