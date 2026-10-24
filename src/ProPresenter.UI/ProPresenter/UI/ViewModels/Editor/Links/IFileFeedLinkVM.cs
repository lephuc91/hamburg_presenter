using System.ComponentModel;
using System.Windows.Input;
using Pro.DO.Storage;

namespace ProPresenter.UI.ViewModels.Editor.Links;

public interface IFileFeedLinkVM : INotifyPropertyChanged
{
	RelativePath SourceFile { get; }

	ICommand OpenFileLocationCommand { get; }

	ICommand AddFileSourceCommand { get; }

	ICommand OpenFileCommand { get; }
}
