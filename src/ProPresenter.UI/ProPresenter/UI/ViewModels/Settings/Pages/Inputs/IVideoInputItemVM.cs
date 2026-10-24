using System.ComponentModel;
using ProPresenter.DO.Audio;

namespace ProPresenter.UI.ViewModels.Settings.Pages.Inputs;

public interface IVideoInputItemVM : INotifyPropertyChanged
{
	string Name { get; }

	bool IsLinked { get; set; }

	IAudioInput? AudioInput { get; set; }
}
