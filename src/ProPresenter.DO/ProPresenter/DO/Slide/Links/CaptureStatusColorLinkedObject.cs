using System.Diagnostics.CodeAnalysis;
using System.Windows.Media;
using Pro.Localization;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.Slide.Custom.Elements.Fills;

namespace ProPresenter.DO.Slide.Links;

public class CaptureStatusColorLinkedObject : LinkedFillObjectBase
{
	public override LinkedFillType LinkedFillType => LinkedFillType.CaptureStatusColor;

	public override string DisplayText => LocalizedStrings.Get(LinkedFillType);

	public override bool RenderEquals([NotNullWhen(true)] ILinkedFillObject? other)
	{
		return other is CaptureStatusColorLinkedObject;
	}

	public override int GetRenderHashCode()
	{
		return GetHashCode();
	}

	public override ILinkedFillObject Clone()
	{
		return new CaptureStatusColorLinkedObject();
	}

	public override IFill GetFill(ILinkData? linkData)
	{
		return new SolidColorFill
		{
			Color = (linkData?.CaptureInformation?.StatusColor ?? Colors.Transparent)
		};
	}

	public override void Serialize(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink dataLink)
	{
		dataLink.CaptureStatusColor = new Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.CaptureStatusColor();
	}
}
