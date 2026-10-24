using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.DO.Resi;

public static class AccountStatusExtensions
{
	public static AccountStatus ToAccountStatus(this ProResiAccountStatus proResiAccountStatus)
	{
		return proResiAccountStatus switch
		{
			ProResiAccountStatus.Active => AccountStatus.Active, 
			ProResiAccountStatus.InActive => AccountStatus.Inactive, 
			ProResiAccountStatus.InValid => AccountStatus.Invalid, 
			_ => AccountStatus.Unknown, 
		};
	}
}
