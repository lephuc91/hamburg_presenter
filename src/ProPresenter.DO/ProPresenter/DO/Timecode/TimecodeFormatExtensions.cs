using System;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Timecode;

public static class TimecodeFormatExtensions
{
	public static double ToDouble(this TimecodeFormat format)
	{
		return format switch
		{
			TimecodeFormat._24Fps => 24.0, 
			TimecodeFormat._25Fps => 25.0, 
			TimecodeFormat._2997Fps => 29.97, 
			TimecodeFormat._30Fps => 30.0, 
			_ => 60.0, 
		};
	}

	public static TimedPlayback.Types.Timing.Types.SMPTETimecode.Types.Format ToSMPTETimcodeFormat(this TimecodeFormat format)
	{
		return format switch
		{
			TimecodeFormat._24Fps => TimedPlayback.Types.Timing.Types.SMPTETimecode.Types.Format._24Fps, 
			TimecodeFormat._25Fps => TimedPlayback.Types.Timing.Types.SMPTETimecode.Types.Format._25Fps, 
			TimecodeFormat._2997Fps => TimedPlayback.Types.Timing.Types.SMPTETimecode.Types.Format._2997Fps, 
			TimecodeFormat._30Fps => TimedPlayback.Types.Timing.Types.SMPTETimecode.Types.Format._30Fps, 
			_ => throw new NotSupportedException(), 
		};
	}

	public static double ToFps(this TimecodeFormat format)
	{
		return 1.0 / format.ToDouble();
	}

	public static Pro.SerializationInterop.RVProtoData.TimecodeSettings.Types.Format ToProtoTimecodeFormat(this TimecodeFormat format)
	{
		return format switch
		{
			TimecodeFormat._24Fps => Pro.SerializationInterop.RVProtoData.TimecodeSettings.Types.Format._24Fps, 
			TimecodeFormat._25Fps => Pro.SerializationInterop.RVProtoData.TimecodeSettings.Types.Format._25Fps, 
			TimecodeFormat._2997Fps => Pro.SerializationInterop.RVProtoData.TimecodeSettings.Types.Format._2997Fps, 
			TimecodeFormat._30Fps => Pro.SerializationInterop.RVProtoData.TimecodeSettings.Types.Format._30Fps, 
			_ => throw new NotSupportedException(), 
		};
	}

	public static TimecodeFormat ToTimecodeFormat(this Pro.SerializationInterop.RVProtoData.TimecodeSettings.Types.Format format)
	{
		return format switch
		{
			Pro.SerializationInterop.RVProtoData.TimecodeSettings.Types.Format._24Fps => TimecodeFormat._24Fps, 
			Pro.SerializationInterop.RVProtoData.TimecodeSettings.Types.Format._25Fps => TimecodeFormat._25Fps, 
			Pro.SerializationInterop.RVProtoData.TimecodeSettings.Types.Format._2997Fps => TimecodeFormat._2997Fps, 
			Pro.SerializationInterop.RVProtoData.TimecodeSettings.Types.Format._30Fps => TimecodeFormat._30Fps, 
			_ => throw new NotSupportedException(), 
		};
	}
}
