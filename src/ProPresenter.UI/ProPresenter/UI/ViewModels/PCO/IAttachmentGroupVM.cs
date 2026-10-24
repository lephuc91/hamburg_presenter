using System.ComponentModel;
using Pro.Common.Collections;
using ProPresenter.DO.PCO;

namespace ProPresenter.UI.ViewModels.PCO;

public interface IAttachmentGroupVM : INotifyPropertyChanged
{
	string Name { get; }

	PCOObject? ReferenceObject { get; }

	INotifyEnumerableChanged<IAttachmentVM>? AllAttachments { get; }

	INotifyEnumerableChanged<IAttachmentVM>? FilteredAttachments { get; }

	string FilterText { get; set; }
}
