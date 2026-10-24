using System.ComponentModel;
using System.Windows.Input;
using Pro.UI.Components;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Arrangements;
using ProPresenter.UI.ArrangementView;

namespace ProPresenter.UI.ViewModels;

public interface IArrangementVM : INotifyPropertyChanged
{
	CueGroup? ActiveGroup { get; }

	ICommand AddArrangementCommand { get; }

	DocumentAction? DocumentAction { get; set; }

	ICommand<Arrangement> DuplicateArrangementCommand { get; }

	ICommand<ArrangementDragCommandParameters> MoveGroupCommand { get; }

	ICommand OpenArrangementManagerCommand { get; }

	string PresentationName { get; }

	ICommand<Arrangement> RemoveArrangementCommand { get; }

	ICommand<CueGroup> RemoveGroupCommand { get; }

	ICommand<Arrangement> SelectArrangementCommand { get; }
}
