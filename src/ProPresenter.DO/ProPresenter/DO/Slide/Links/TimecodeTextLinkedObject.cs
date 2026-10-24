using System.Diagnostics.CodeAnalysis;
using Pro.Common.Time;
using Pro.Localization;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Timer;

namespace ProPresenter.DO.Slide.Links;

public class TimecodeTextLinkedObject : LinkedTextObjectBase
{
	private TimerFormatData FormatData { get; }

	public override LinkedTextType LinkedTextType => LinkedTextType.TimecodeText;

	public override string DisplayText => LocalizedStrings.Get(LinkedTextType) ?? "";

	public override FormattingType FormattingType => FormattingType.None;

	public TimecodeTextLinkedObject()
	{
		FormatData = new TimerFormatData
		{
			HourFormat = TimerFormatStyle.Long,
			MinuteFormat = TimerFormatStyle.Long,
			SecondFormat = TimerFormatStyle.Long,
			MillisecondFormat = TimerFormatStyle.None
		};
	}

	public override string GetText(ILinkData? linkData)
	{
		if (linkData == null)
		{
			return "hh:mm:ss;ff";
		}
		if (!(linkData.Timecode?.ElapsedTime).HasValue)
		{
			return string.Empty;
		}
		TimeSlice value = linkData.Timecode.ElapsedTime.Value;
		double fps = linkData.Timecode.Fps;
		return value.FormatTime(fps, showSubSeconds: true, FormatData);
	}

	public override ILinkedTextObject Clone()
	{
		return new TimecodeTextLinkedObject();
	}

	public override int GetRenderHashCode()
	{
		return GetHashCode();
	}

	public override bool RenderEquals([NotNullWhen(true)] ILinkedTextObject? other)
	{
		return other is TimecodeTextLinkedObject;
	}

	public override void Serialize(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink dataLink)
	{
		dataLink.TimecodeText = new Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.TimecodeText();
	}
}
