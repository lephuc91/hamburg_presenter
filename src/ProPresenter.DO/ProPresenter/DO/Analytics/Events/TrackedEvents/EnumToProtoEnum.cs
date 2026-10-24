using System;
using Pro.Common.Utility;
using Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents;
using ProPresenter.DO.Capture;

namespace ProPresenter.DO.Analytics.Events.TrackedEvents;

public static class EnumToProtoEnum
{
	public static Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents.Codec TranslateCodec(ProPresenter.DO.Capture.Codec translateCodec)
	{
		return translateCodec switch
		{
			ProPresenter.DO.Capture.Codec.H264 => Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents.Codec.H264, 
			ProPresenter.DO.Capture.Codec.H264Software => Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents.Codec.H264Software, 
			ProPresenter.DO.Capture.Codec.H265 => Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents.Codec.H265, 
			ProPresenter.DO.Capture.Codec.H265Software => Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents.Codec.H265Software, 
			ProPresenter.DO.Capture.Codec.ProRes422Proxy => Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents.Codec.Prores422Proxy, 
			ProPresenter.DO.Capture.Codec.ProRes422LT => Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents.Codec.Prores422Lt, 
			ProPresenter.DO.Capture.Codec.ProRes422 => Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents.Codec.Prores422, 
			ProPresenter.DO.Capture.Codec.ProRes422HQ => Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents.Codec.Prores422Hq, 
			ProPresenter.DO.Capture.Codec.ProRes4444 => Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents.Codec.Prores4444, 
			ProPresenter.DO.Capture.Codec.ProRes4444XQ => Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents.Codec.Prores4444Xq, 
			ProPresenter.DO.Capture.Codec.HAP => Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents.Codec.Hap, 
			ProPresenter.DO.Capture.Codec.HAPAlpha => Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents.Codec.Hapalpha, 
			ProPresenter.DO.Capture.Codec.Notch => Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents.Codec.Notch, 
			ProPresenter.DO.Capture.Codec.Automatic => Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents.Codec.Automatic, 
			ProPresenter.DO.Capture.Codec.HAPQ => Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents.Codec.Hapq, 
			ProPresenter.DO.Capture.Codec.HAPQAlpha => Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents.Codec.Hapqalpha, 
			_ => throw new ArgumentException(translateCodec.GetEnumDescription() + " is not a recognized CODEC"), 
		};
	}

	public static Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents.FrameRate TranslateFrameRate(ProPresenter.DO.Capture.FrameRate translateFrameRate)
	{
		return translateFrameRate switch
		{
			ProPresenter.DO.Capture.FrameRate.Unknown => Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents.FrameRate.Unspecified, 
			ProPresenter.DO.Capture.FrameRate._24 => Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents.FrameRate._24Fps, 
			ProPresenter.DO.Capture.FrameRate._25 => Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents.FrameRate._25Fps, 
			ProPresenter.DO.Capture.FrameRate._2997 => Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents.FrameRate._2997Fps, 
			ProPresenter.DO.Capture.FrameRate._30 => Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents.FrameRate._30Fps, 
			ProPresenter.DO.Capture.FrameRate._50 => Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents.FrameRate._50Fps, 
			ProPresenter.DO.Capture.FrameRate._5994 => Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents.FrameRate._5994Fps, 
			ProPresenter.DO.Capture.FrameRate._60 => Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents.FrameRate._60Fps, 
			_ => throw new ArgumentException(translateFrameRate.GetEnumDescription() + " is not a recognized Frame Rate"), 
		};
	}
}
