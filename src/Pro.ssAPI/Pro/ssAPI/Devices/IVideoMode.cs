using Pro.Common.Mathematics;

namespace Pro.ssAPI.Devices;

public interface IVideoMode
{
	string Name { get; }

	Vector2<int> Size { get; }

	float Frequency { get; }

	int ModeIndex { get; }

	bool Interlaced { get; }
}
