namespace Pro.MIDI;

internal static class Constants
{
	public const ulong StatusMask = 255uL;

	public const ulong D1Mask = 65280uL;

	public const ulong D2Mask = 16711680uL;

	public const int D1Shift = 8;

	public const int D2Shift = 16;

	public const byte NoteOffLowerBound = 128;

	public const byte NoteOffUpperBound = 143;

	public const byte NoteOnLowerBound = 144;

	public const byte NoteOnUpperBound = 159;

	public const byte NoteOffFlag = 128;

	public const byte NoteOnFlag = 144;

	public const byte ChannelMask = 15;

	public const byte NoteMask = 127;

	public const byte IntensityMask = 127;
}
