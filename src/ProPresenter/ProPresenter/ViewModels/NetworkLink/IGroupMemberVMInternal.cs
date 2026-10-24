using ProPresenter.DO.NetworkLink;
using ProPresenter.UI.ViewModels;

namespace ProPresenter.ViewModels.NetworkLink;

public interface IGroupMemberVMInternal : IGroupMemberVM
{
	GroupMember Item { get; }
}
