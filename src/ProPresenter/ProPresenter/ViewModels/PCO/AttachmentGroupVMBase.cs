using System.ComponentModel;
using Pro.Common.Collections;
using Pro.Common.Components;
using ProPresenter.DO.PCO;
using ProPresenter.DO.PCO.Items;
using ProPresenter.UI.ViewModels.PCO;

namespace ProPresenter.ViewModels.PCO;

public abstract class AttachmentGroupVMBase : NotifyPropertyChangedBase, IAttachmentGroupVM, INotifyPropertyChanged
{
	private string _filterText = string.Empty;

	private readonly PairedCollection<PCOAttachmentDetails, IAttachmentVM> _attachments;

	private readonly FilteredObservableCollection<IAttachmentVM> _filteredAttachments;

	protected NotifyObservableCollection<PCOAttachmentDetails> SourceAttachments { get; } = new NotifyObservableCollection<PCOAttachmentDetails>();

	public abstract string Name { get; }

	public abstract PCOObject ReferenceObject { get; }

	public INotifyEnumerableChanged<IAttachmentVM> AllAttachments => _attachments;

	public INotifyEnumerableChanged<IAttachmentVM> FilteredAttachments => _filteredAttachments;

	public string FilterText
	{
		get
		{
			return _filterText;
		}
		set
		{
			SetValue("FilterText", ref _filterText, value, _filteredAttachments.Refresh);
		}
	}

	protected AttachmentGroupVMBase(IPCOConsumer consumer)
	{
		_attachments = new PairedCollection<PCOAttachmentDetails, IAttachmentVM>(SourceAttachments, (PCOAttachmentDetails a) => new AttachmentVM(consumer, a));
		_filteredAttachments = new FilteredObservableCollection<IAttachmentVM>(_attachments, FilterAttachment);
	}

	private bool FilterAttachment(IAttachmentVM attachment)
	{
		if (!string.IsNullOrWhiteSpace(FilterText))
		{
			return attachment.Filename.ToLowerInvariant().Contains(FilterText.ToLowerInvariant());
		}
		return true;
	}
}
