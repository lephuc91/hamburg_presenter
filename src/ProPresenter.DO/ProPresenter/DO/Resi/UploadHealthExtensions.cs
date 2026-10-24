using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.DO.Resi;

public static class UploadHealthExtensions
{
	public static UploadHealth ToUploadHealth(this ProResiUploadHealth proResiUploadHealth)
	{
		return proResiUploadHealth switch
		{
			ProResiUploadHealth.Healthy => UploadHealth.Healthy, 
			ProResiUploadHealth.Warning => UploadHealth.Warning, 
			ProResiUploadHealth.Error => UploadHealth.Error, 
			_ => UploadHealth.Unknown, 
		};
	}
}
