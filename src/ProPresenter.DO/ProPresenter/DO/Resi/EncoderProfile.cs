using System;
using Pro.Common.Mathematics;
using ProPresenter.DO.Capture;

namespace ProPresenter.DO.Resi;

public class EncoderProfile : IEncoderProfile
{
	public Guid ID { get; } = Guid.NewGuid();

	public string Format { get; }

	public Vector2<uint> Resolution { get; }

	public FrameRate FrameRate { get; }

	public bool IsInterlaced { get; }

	public double VideoBitRate { get; }

	public uint VideoBufSize { get; }

	public uint VideoMinRate { get; }

	public uint VideoMaxRate { get; }

	public uint Gop { get; }

	public double SegmentSizeUs { get; }

	public EncoderProfile(Guid id, string format, Vector2<uint> resolution, FrameRate frameRate, bool isInterlaced, double videoBitRate, uint videoBufSize, uint videoMinRate, uint videoMaxRate, uint gop, uint segmentSizeUs)
	{
		ID = id;
		Format = format;
		Resolution = resolution;
		FrameRate = frameRate;
		IsInterlaced = isInterlaced;
		VideoBitRate = videoBitRate;
		VideoBufSize = videoBufSize;
		VideoMinRate = videoMinRate;
		VideoMaxRate = videoMaxRate;
		Gop = gop;
		SegmentSizeUs = segmentSizeUs;
	}
}
