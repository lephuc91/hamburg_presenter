using ProPresenterCore.ProCore.Interop.Utility;

namespace ProPresenterCore.ProCore.Interop.Resi.Types;

public class EncoderProfile
{
	public string Id { get; }

	public string Format { get; }

	public uint Resolution { get; }

	public float FrameRate { get; }

	public bool Interlaced { get; }

	public float VideoBitRate { get; }

	public uint VideoBufSize { get; }

	public uint VideoMinRate { get; }

	public uint VideoMaxRate { get; }

	public uint Gop { get; }

	public uint SegmentSize { get; }

	public unsafe EncoderProfile(ProResiEncoderProfile.__Internal* encoderProfilePtr)
	{
		Id = StringMarshalling.StringFromCString(encoderProfilePtr->id);
		Format = StringMarshalling.StringFromCString(encoderProfilePtr->format);
		Resolution = encoderProfilePtr->resolution;
		FrameRate = encoderProfilePtr->frameRate;
		Interlaced = encoderProfilePtr->interlaced != 0;
		VideoBitRate = encoderProfilePtr->videoBitRate;
		VideoBufSize = encoderProfilePtr->videoBufSize;
		VideoMinRate = encoderProfilePtr->videoMinRate;
		VideoMaxRate = encoderProfilePtr->videoMaxRate;
		Gop = encoderProfilePtr->gop;
		SegmentSize = encoderProfilePtr->segmentSize;
	}
}
