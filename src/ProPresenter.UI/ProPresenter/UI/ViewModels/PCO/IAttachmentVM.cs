using System.ComponentModel;
using System.Windows.Media.Imaging;
using Pro.Common.Components;

namespace ProPresenter.UI.ViewModels.PCO;

public interface IAttachmentVM : INotifyPropertyChanged
{
	string Filename { get; }

	BitmapSource? Icon { get; }

	IRemoteFile RemoteFile { get; }
}
