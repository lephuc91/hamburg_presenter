using Pro.Common.Collections;
using ProPresenter.DO.PCO;

namespace ProPresenter.ViewModels.PCO;

public class ItemAttachmentGroupVM : AttachmentGroupVMBase
{
	private readonly PCOItem _item;

	public override string Name => _item.Name ?? string.Empty;

	public override PCOObject ReferenceObject => _item;

	public ItemAttachmentGroupVM(IPCOConsumer consumer, PCOItem item)
		: base(consumer)
	{
		_item = item;
		base.SourceAttachments.AddRange(item.Attachments);
	}
}
