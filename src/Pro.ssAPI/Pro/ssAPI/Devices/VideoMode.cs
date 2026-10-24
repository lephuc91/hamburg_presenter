using System.Diagnostics;
using Pro.Common.Mathematics;
using ProPresenterCore.ProCore.Interop;

namespace Pro.ssAPI.Devices;

[DebuggerDisplay("{Name,nq}")]
internal class VideoMode : IVideoMode
{
	public string Name { get; }

	public Vector2<int> Size { get; }

	public float Frequency { get; }

	public int ModeIndex { get; }

	public bool Interlaced { get; }

	internal VideoMode(ProVideoMode mode, int modeIndex)
	{
		Size = new Vector2<int>(mode.Width, mode.Height);
		Frequency = mode.FrameRate;
		Interlaced = mode.Interlaced;
		ModeIndex = modeIndex;
		Name = mode.Name;
	}
}
