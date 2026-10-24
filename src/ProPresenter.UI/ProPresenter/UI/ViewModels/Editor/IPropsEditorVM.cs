using System;
using System.Collections.Generic;
using System.ComponentModel;
using Pro.Common.Components.Reversibility;
using Pro.UI.Components;
using ProPresenter.DO.Props;

namespace ProPresenter.UI.ViewModels.Editor;

public interface IPropsEditorVM : ISlideEditorVM, INotifyPropertyChanged
{
	IPropGroup? SelectedPropGroup { get; set; }

	IPropCue? SelectedProp { get; set; }

	IEnumerable<IPropGroup> Groups { get; }

	ICommand<IPropGroup> SelectPropGroupCommand { get; }

	event Action<UndoStack?>? StackChanged;
}
