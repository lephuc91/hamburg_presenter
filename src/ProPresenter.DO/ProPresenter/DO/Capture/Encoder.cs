using System;
using System.Runtime.CompilerServices;
using Pro.Common.Mathematics;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Resi;

namespace ProPresenter.DO.Capture;

public record Encoder(uint VideoWidth = 0u, uint VideoHeight = 0u, FrameRate FrameRate = FrameRate._30, uint VideoBitrate = 0u, uint AudioBitrate = 128000u, bool IsInterlaced = false)
{
	public const int MAX_SCREEN_SIZE = 3840;

	private static readonly Vector2<uint> RESOLUTION_360 = new Vector2<uint>(480u, 360u);

	private static readonly Vector2<uint> RESOLUTION_480 = new Vector2<uint>(640u, 480u);

	private static readonly Vector2<uint> RESOLUTION_720 = new Vector2<uint>(1280u, 720u);

	private static readonly Vector2<uint> RESOLUTION_1080 = new Vector2<uint>(1920u, 1080u);

	public static readonly Encoder DiskDefault = new Encoder(RESOLUTION_720.X, RESOLUTION_720.Y, FrameRate._30, 10000000u);

	public static readonly Encoder[] DiskDefaults = new Encoder[8]
	{
		new Encoder(RESOLUTION_360.X, RESOLUTION_360.Y, FrameRate._30, 4000000u),
		new Encoder(RESOLUTION_480.X, RESOLUTION_480.Y, FrameRate._30, 4000000u),
		new Encoder(RESOLUTION_720.X, RESOLUTION_720.Y, FrameRate._30, 6000000u),
		DiskDefault,
		new Encoder(RESOLUTION_720.X, RESOLUTION_720.Y, FrameRate._30, 14000000u),
		new Encoder(RESOLUTION_720.X, RESOLUTION_720.Y, FrameRate._60, 16000000u),
		new Encoder(RESOLUTION_1080.X, RESOLUTION_1080.Y, FrameRate._30, 20000000u),
		new Encoder(RESOLUTION_1080.X, RESOLUTION_1080.Y, FrameRate._60, 24000000u)
	};

	public static readonly Encoder RtmpDefault = new Encoder(RESOLUTION_720.X, RESOLUTION_720.Y, FrameRate._30, 2500000u);

	public static readonly Encoder[] RtmpDefaults = new Encoder[8]
	{
		new Encoder(RESOLUTION_360.X, RESOLUTION_360.Y, FrameRate._30, 1000000u),
		new Encoder(RESOLUTION_480.X, RESOLUTION_480.Y, FrameRate._30, 2000000u),
		new Encoder(RESOLUTION_720.X, RESOLUTION_720.Y, FrameRate._30, 1500000u),
		RtmpDefault,
		new Encoder(RESOLUTION_720.X, RESOLUTION_720.Y, FrameRate._30, 4000000u),
		new Encoder(RESOLUTION_720.X, RESOLUTION_720.Y, FrameRate._60, 6000000u),
		new Encoder(RESOLUTION_1080.X, RESOLUTION_1080.Y, FrameRate._30, 6000000u),
		new Encoder(RESOLUTION_1080.X, RESOLUTION_1080.Y, FrameRate._60, 8000000u)
	};

	public Recording.Types.Stream.Types.Encoder Serialize()
	{
		return new Recording.Types.Stream.Types.Encoder
		{
			FrameRate = FrameRate.ToProtoFrameRate(),
			IsInterlaced = IsInterlaced,
			VideoWidth = VideoWidth,
			VideoHeight = VideoHeight,
			VideoBitrate = VideoBitrate,
			AudioBitrate = AudioBitrate
		};
	}

	public override string ToString()
	{
		string value = (IsInterlaced ? "i" : "p");
		string @string = FrameRate.GetString();
		string value2 = VideoBitrate.BitrateToString();
		string value3 = VideoHeight.ToString();
		if (!IsDefaultResolution())
		{
			value3 = $"{VideoWidth}x{VideoHeight}";
		}
		return $"{value3}{value}{@string} ({value2})";
	}

	private bool IsDefaultResolution()
	{
		Vector2<uint> vector = new Vector2<uint>(VideoWidth, VideoHeight);
		if (!(RESOLUTION_360 == vector) && !(RESOLUTION_480 == vector) && !(RESOLUTION_720 == vector))
		{
			return RESOLUTION_1080 == vector;
		}
		return true;
	}

	public static Encoder FromProto(Recording.Types.Stream.Types.Encoder protoEncoder)
	{
		uint videoWidth = Math.Min(3840u, protoEncoder.VideoWidth);
		uint videoHeight = Math.Min(3840u, protoEncoder.VideoHeight);
		FrameRate frameRate = protoEncoder.FrameRate.ToFrameRate();
		uint videoBitrate = protoEncoder.VideoBitrate;
		uint audioBitrate = protoEncoder.AudioBitrate;
		bool isInterlaced = protoEncoder.IsInterlaced;
		return new Encoder(videoWidth, videoHeight, frameRate, videoBitrate, audioBitrate, isInterlaced);
	}

	public static Encoder FromEncoderProfile(IEncoderProfile profile)
	{
		uint x = profile.Resolution.X;
		uint y = profile.Resolution.Y;
		FrameRate frameRate = profile.FrameRate;
		uint videoBitrate = (uint)(profile.VideoBitRate * 1000000.0);
		return new Encoder(x, y, frameRate, videoBitrate);
	}

	[CompilerGenerated]
	protected Encoder(Encoder original)
	{
		VideoWidth = original.VideoWidth;
		VideoHeight = original.VideoHeight;
		FrameRate = original.FrameRate;
		VideoBitrate = original.VideoBitrate;
		AudioBitrate = original.AudioBitrate;
		IsInterlaced = original.IsInterlaced;
	}
}
