using System.ComponentModel;

namespace Pro.DO.Audio;

public interface IChannel : INotifyPropertyChanged
{
	int Index { get; set; }

	string Name { get; }

	bool CanRename { get; }

	double Level { get; set; }

	bool MuteActive { get; set; }

	bool SoloActive { get; set; }

	bool TestActive { get; set; }
}
