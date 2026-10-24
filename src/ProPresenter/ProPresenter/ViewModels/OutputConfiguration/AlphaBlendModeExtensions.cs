using ProPresenter.DO.OutputConfiguration;
using ProPresenter.UI.ViewModels.OutputConfiguration;

namespace ProPresenter.ViewModels.OutputConfiguration;

public static class AlphaBlendModeExtensions
{
	public static ProPresenter.UI.ViewModels.OutputConfiguration.AlphaBlendMode ToViewModelValue(this ProPresenter.DO.OutputConfiguration.AlphaBlendMode mode)
	{
		return mode switch
		{
			ProPresenter.DO.OutputConfiguration.AlphaBlendMode.Premultiplied => ProPresenter.UI.ViewModels.OutputConfiguration.AlphaBlendMode.Premultiplied, 
			ProPresenter.DO.OutputConfiguration.AlphaBlendMode.Straight => ProPresenter.UI.ViewModels.OutputConfiguration.AlphaBlendMode.Straight, 
			_ => ProPresenter.UI.ViewModels.OutputConfiguration.AlphaBlendMode.None, 
		};
	}

	public static ProPresenter.DO.OutputConfiguration.AlphaBlendMode ToDataObjectValue(this ProPresenter.UI.ViewModels.OutputConfiguration.AlphaBlendMode mode)
	{
		return mode switch
		{
			ProPresenter.UI.ViewModels.OutputConfiguration.AlphaBlendMode.Premultiplied => ProPresenter.DO.OutputConfiguration.AlphaBlendMode.Premultiplied, 
			ProPresenter.UI.ViewModels.OutputConfiguration.AlphaBlendMode.Straight => ProPresenter.DO.OutputConfiguration.AlphaBlendMode.Straight, 
			_ => ProPresenter.DO.OutputConfiguration.AlphaBlendMode.None, 
		};
	}
}
