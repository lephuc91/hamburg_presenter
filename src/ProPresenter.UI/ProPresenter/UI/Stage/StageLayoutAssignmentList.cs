using Pro.Common.Components;
using Pro.UI.Controls;
using ProPresenter.DO.OutputConfiguration;

namespace ProPresenter.UI.Stage;

public class StageLayoutAssignmentList : DragDropListBox<ScreenArrangementBase>
{
	protected override IDragDropCollection<ScreenArrangementBase>? SourceCollection => base.ItemsSource as IDragDropCollection<ScreenArrangementBase>;
}
