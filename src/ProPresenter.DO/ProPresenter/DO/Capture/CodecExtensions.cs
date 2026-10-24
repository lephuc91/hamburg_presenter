using System;
using System.Collections.Generic;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;
using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.DO.Capture;

[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(Codec), typeof(IRecording.Types.IStream.Types.Codec), SourceToDestinationMethodName = "ToEntityCodec", DestinationToSourceMethodName = "ToCodec", SourceDefaultValue = "Automatic", DestinationDefaultValue = "Automatic", UnmatchedSourceNames = new string[] { "ProRes422Proxy", "ProRes422LT", "ProRes422", "ProRes422HQ", "ProRes4444", "ProRes4444XQ", "HAP", "HAPAlpha", "HAPQ", "HAPQAlpha" }, UnmatchedDestinationNames = new string[] { "Prores422Proxy", "Prores422Lt", "Prores422", "Prores422Hq", "Prores4444", "Prores4444Xq", "Hap", "HapAlpha", "HapQ", "HapQAlpha" })]
[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(Codec), typeof(Recording.Types.Stream.Types.Codec), SourceToDestinationMethodName = "ToProtoCodec", DestinationToSourceMethodName = "ToCodec", SourceDefaultValue = "Automatic", DestinationDefaultValue = "Automatic", UnmatchedSourceNames = new string[] { "ProRes422Proxy", "ProRes422LT", "ProRes422", "ProRes422HQ", "ProRes4444", "ProRes4444XQ", "HAP", "HAPAlpha", "HAPQ", "HAPQAlpha" }, UnmatchedDestinationNames = new string[] { "Prores422Proxy", "Prores422Lt", "Prores422", "Prores422Hq", "Prores4444", "Prores4444Xq", "Hap", "HapAlpha", "HapQ", "HapQAlpha" })]
public static class CodecExtensions
{
	public static Codec ToCodec(this ProScreenCaptureCodec proCodec)
	{
		return proCodec switch
		{
			ProScreenCaptureCodec.H264 => Codec.H264, 
			ProScreenCaptureCodec.H264Software => Codec.H264Software, 
			ProScreenCaptureCodec.H265 => Codec.H265, 
			ProScreenCaptureCodec.H265Software => Codec.H265Software, 
			ProScreenCaptureCodec.PRORES422PROXY => Codec.ProRes422Proxy, 
			ProScreenCaptureCodec.PRORES422LT => Codec.ProRes422LT, 
			ProScreenCaptureCodec.PRORES422 => Codec.ProRes422, 
			ProScreenCaptureCodec.PRORES422HQ => Codec.ProRes422HQ, 
			ProScreenCaptureCodec.PRORES4444 => Codec.ProRes4444, 
			ProScreenCaptureCodec.PRORES4444XQ => Codec.ProRes4444XQ, 
			ProScreenCaptureCodec.HAP => Codec.HAP, 
			ProScreenCaptureCodec.Notch => Codec.Notch, 
			ProScreenCaptureCodec.HAPAlpha => Codec.HAPAlpha, 
			ProScreenCaptureCodec.HAPQ => Codec.HAPQ, 
			ProScreenCaptureCodec.HAPQAlpha => Codec.HAPQAlpha, 
			_ => Codec.Automatic, 
		};
	}

	public static IEnumerable<Codec> AvailableFor(this IEnumerable<Codec> codecs, DestinationType destination)
	{
		switch (destination)
		{
		case DestinationType.Disk:
			return codecs;
		case DestinationType.RTMP:
		case DestinationType.Resi:
			return codecs.Where((Codec c) => c.IsAnyOf(Codec.H264, Codec.H264Software, Codec.H265, Codec.H265Software));
		default:
			throw new NotImplementedException();
		}
	}

	public static IRecording.Types.IStream.Types.Codec ToEntityCodec(this Codec source)
	{
		return source switch
		{
			Codec.Automatic => IRecording.Types.IStream.Types.Codec.Automatic, 
			Codec.H264 => IRecording.Types.IStream.Types.Codec.H264, 
			Codec.H264Software => IRecording.Types.IStream.Types.Codec.H264Software, 
			Codec.H265 => IRecording.Types.IStream.Types.Codec.H265, 
			Codec.H265Software => IRecording.Types.IStream.Types.Codec.H265Software, 
			Codec.ProRes422Proxy => IRecording.Types.IStream.Types.Codec.Prores422Proxy, 
			Codec.ProRes422LT => IRecording.Types.IStream.Types.Codec.Prores422Lt, 
			Codec.ProRes422 => IRecording.Types.IStream.Types.Codec.Prores422, 
			Codec.ProRes422HQ => IRecording.Types.IStream.Types.Codec.Prores422Hq, 
			Codec.ProRes4444 => IRecording.Types.IStream.Types.Codec.Prores4444, 
			Codec.ProRes4444XQ => IRecording.Types.IStream.Types.Codec.Prores4444Xq, 
			Codec.HAP => IRecording.Types.IStream.Types.Codec.Hap, 
			Codec.HAPAlpha => IRecording.Types.IStream.Types.Codec.HapAlpha, 
			Codec.HAPQ => IRecording.Types.IStream.Types.Codec.HapQ, 
			Codec.HAPQAlpha => IRecording.Types.IStream.Types.Codec.HapQAlpha, 
			Codec.Notch => IRecording.Types.IStream.Types.Codec.Notch, 
			_ => IRecording.Types.IStream.Types.Codec.Automatic, 
		};
	}

	public static Codec ToCodec(this IRecording.Types.IStream.Types.Codec source)
	{
		return source switch
		{
			IRecording.Types.IStream.Types.Codec.Automatic => Codec.Automatic, 
			IRecording.Types.IStream.Types.Codec.H264 => Codec.H264, 
			IRecording.Types.IStream.Types.Codec.H265 => Codec.H265, 
			IRecording.Types.IStream.Types.Codec.Prores422Proxy => Codec.ProRes422Proxy, 
			IRecording.Types.IStream.Types.Codec.Prores422Lt => Codec.ProRes422LT, 
			IRecording.Types.IStream.Types.Codec.Prores422 => Codec.ProRes422, 
			IRecording.Types.IStream.Types.Codec.Prores422Hq => Codec.ProRes422HQ, 
			IRecording.Types.IStream.Types.Codec.Prores4444 => Codec.ProRes4444, 
			IRecording.Types.IStream.Types.Codec.Prores4444Xq => Codec.ProRes4444XQ, 
			IRecording.Types.IStream.Types.Codec.Hap => Codec.HAP, 
			IRecording.Types.IStream.Types.Codec.HapAlpha => Codec.HAPAlpha, 
			IRecording.Types.IStream.Types.Codec.HapQ => Codec.HAPQ, 
			IRecording.Types.IStream.Types.Codec.HapQAlpha => Codec.HAPQAlpha, 
			IRecording.Types.IStream.Types.Codec.Notch => Codec.Notch, 
			IRecording.Types.IStream.Types.Codec.H264Software => Codec.H264Software, 
			IRecording.Types.IStream.Types.Codec.H265Software => Codec.H265Software, 
			_ => Codec.Automatic, 
		};
	}

	public static Recording.Types.Stream.Types.Codec ToProtoCodec(this Codec source)
	{
		return source switch
		{
			Codec.Automatic => Recording.Types.Stream.Types.Codec.Automatic, 
			Codec.H264 => Recording.Types.Stream.Types.Codec.H264, 
			Codec.H264Software => Recording.Types.Stream.Types.Codec.H264Software, 
			Codec.H265 => Recording.Types.Stream.Types.Codec.H265, 
			Codec.H265Software => Recording.Types.Stream.Types.Codec.H265Software, 
			Codec.ProRes422Proxy => Recording.Types.Stream.Types.Codec.Prores422Proxy, 
			Codec.ProRes422LT => Recording.Types.Stream.Types.Codec.Prores422Lt, 
			Codec.ProRes422 => Recording.Types.Stream.Types.Codec.Prores422, 
			Codec.ProRes422HQ => Recording.Types.Stream.Types.Codec.Prores422Hq, 
			Codec.ProRes4444 => Recording.Types.Stream.Types.Codec.Prores4444, 
			Codec.ProRes4444XQ => Recording.Types.Stream.Types.Codec.Prores4444Xq, 
			Codec.HAP => Recording.Types.Stream.Types.Codec.Hap, 
			Codec.HAPAlpha => Recording.Types.Stream.Types.Codec.HapAlpha, 
			Codec.HAPQ => Recording.Types.Stream.Types.Codec.HapQ, 
			Codec.HAPQAlpha => Recording.Types.Stream.Types.Codec.HapQAlpha, 
			Codec.Notch => Recording.Types.Stream.Types.Codec.Notch, 
			_ => Recording.Types.Stream.Types.Codec.Automatic, 
		};
	}

	public static Codec ToCodec(this Recording.Types.Stream.Types.Codec source)
	{
		return source switch
		{
			Recording.Types.Stream.Types.Codec.Automatic => Codec.Automatic, 
			Recording.Types.Stream.Types.Codec.H264 => Codec.H264, 
			Recording.Types.Stream.Types.Codec.H265 => Codec.H265, 
			Recording.Types.Stream.Types.Codec.Prores422Proxy => Codec.ProRes422Proxy, 
			Recording.Types.Stream.Types.Codec.Prores422Lt => Codec.ProRes422LT, 
			Recording.Types.Stream.Types.Codec.Prores422 => Codec.ProRes422, 
			Recording.Types.Stream.Types.Codec.Prores422Hq => Codec.ProRes422HQ, 
			Recording.Types.Stream.Types.Codec.Prores4444 => Codec.ProRes4444, 
			Recording.Types.Stream.Types.Codec.Prores4444Xq => Codec.ProRes4444XQ, 
			Recording.Types.Stream.Types.Codec.Hap => Codec.HAP, 
			Recording.Types.Stream.Types.Codec.HapAlpha => Codec.HAPAlpha, 
			Recording.Types.Stream.Types.Codec.HapQ => Codec.HAPQ, 
			Recording.Types.Stream.Types.Codec.HapQAlpha => Codec.HAPQAlpha, 
			Recording.Types.Stream.Types.Codec.Notch => Codec.Notch, 
			Recording.Types.Stream.Types.Codec.H264Software => Codec.H264Software, 
			Recording.Types.Stream.Types.Codec.H265Software => Codec.H265Software, 
			_ => Codec.Automatic, 
		};
	}
}
