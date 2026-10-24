using System.ComponentModel;
using Pro.Localization;

namespace ProPresenter.DO.Capture;

public enum Codec
{
	Automatic,
	[Description("H.264")]
	[LocalizedString("RECORDING_WINDOW_CODEC_H264_title")]
	H264,
	[Description("H.264 Software")]
	[LocalizedString("RECORDING_WINDOW_CODEC_H264_SOFTWARE_title")]
	H264Software,
	[Description("H.265")]
	[LocalizedString("RECORDING_WINDOW_CODEC_H265_title")]
	H265,
	[Description("H.265  Software")]
	[LocalizedString("RECORDING_WINDOW_CODEC_H265_SOFTWARE_title")]
	H265Software,
	[Description("ProRes 422 Proxy")]
	[LocalizedString("RECORDING_WINDOW_CODEC_PRORES_422_PROXY_title")]
	ProRes422Proxy,
	[Description("ProRes 422 LT")]
	[LocalizedString("RECORDING_WINDOW_CODEC_PRORES_422_LT_title")]
	ProRes422LT,
	[Description("ProRes 422")]
	[LocalizedString("RECORDING_WINDOW_CODEC_PRORES_422_title")]
	ProRes422,
	[Description("ProRes 422 HQ")]
	[LocalizedString("RECORDING_WINDOW_CODEC_PRORES_422_HQ_title")]
	ProRes422HQ,
	[Description("ProRes 4444")]
	[LocalizedString("RECORDING_WINDOW_CODEC_PRORES_4444_title")]
	ProRes4444,
	[Description("ProRes 4444 XQ")]
	[LocalizedString("RECORDING_WINDOW_CODEC_PRORES_4444_XQ_title")]
	ProRes4444XQ,
	[Description("HAP")]
	[LocalizedString("RECORDING_WINDOW_CODEC_HAP_title")]
	HAP,
	[Description("HAP Alpha")]
	[LocalizedString("RECORDING_WINDOW_CODEC_HAPAlpha_title")]
	HAPAlpha,
	[Description("HAP Q")]
	[LocalizedString("RECORDING_WINDOW_CODEC_HAPQ_title")]
	HAPQ,
	[Description("HAP Q Alpha")]
	[LocalizedString("RECORDING_WINDOW_CODEC_HAPQAlpha_title")]
	HAPQAlpha,
	[Description("NotchLC")]
	[LocalizedString("RECORDING_WINDOW_CODEC_NOTCHLC_title")]
	Notch
}
