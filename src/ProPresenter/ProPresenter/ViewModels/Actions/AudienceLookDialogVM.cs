using Pro.UI.Components;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Looks;

namespace ProPresenter.ViewModels.Actions;

public class AudienceLookDialogVM : ActionDialogContentVM
{
	public IAudienceLookCollection AudienceLooks { get; }

	public ICommand<AudienceLook> SelectAudienceLookCommand => new RelayCommand<AudienceLook>(OnSelectAudienceLookCommand, (AudienceLook l) => l != null);

	public AudienceLookDialogVM(IAudienceLookCollection looks)
	{
		AudienceLooks = looks;
	}

	private void OnSelectAudienceLookCommand(AudienceLook look)
	{
		((AudienceLookAction)base.Action).SetIdentifier(look.ID, look.Name);
	}
}
