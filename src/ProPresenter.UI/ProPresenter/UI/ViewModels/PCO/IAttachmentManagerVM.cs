using System.ComponentModel;
using System.Windows.Input;
using Pro.Common.Collections;
using ProPresenter.DO.PCO;

namespace ProPresenter.UI.ViewModels.PCO;

public interface IAttachmentManagerVM : INotifyPropertyChanged
{
	PCOPlan? ActivePlan { get; set; }

	INotifyEnumerableChanged<IAttachmentGroupVM> AllAttachmentGroups { get; }

	INotifyEnumerableChanged<IAttachmentGroupVM> FilteredAttachmentGroups { get; }

	IAttachmentGroupVM? SelectedAttachmentGroup { get; set; }

	string FilterText { get; set; }

	ICommand RefreshAttachmentsCommand { get; }

	bool IsPCOBusy { get; }
}
