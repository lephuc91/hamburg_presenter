using System;
using Pro.Common.Mathematics;
using Pro.DO.Audio;

namespace ProPresenter.DO.Capture;

public class StreamAudioChannel : DeviceChannel
{
	public override string Name
	{
		get
		{
			if (!base.Index.IsOdd())
			{
				return "L";
			}
			return "R";
		}
		set
		{
			throw new NotSupportedException();
		}
	}
}
