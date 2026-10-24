using System;
using Pro.Common.Mathematics;
using ProPresenter.DO.Capture;

namespace ProPresenter.DO.Resi;

public interface IEncoderProfile
{
	string Format { get; }

	FrameRate FrameRate { get; }

	uint Gop { get; }

	Guid ID { get; }

	bool IsInterlaced { get; }

	Vector2<uint> Resolution { get; }

	double SegmentSizeUs { get; }

	double VideoBitRate { get; }

	uint VideoBufSize { get; }

	uint VideoMinRate { get; }

	uint VideoMaxRate { get; }
}
