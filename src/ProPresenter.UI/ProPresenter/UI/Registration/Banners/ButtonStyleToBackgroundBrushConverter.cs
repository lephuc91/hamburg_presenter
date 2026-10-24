using System;
using System.Globalization;
using System.Windows.Data;
using ProPresenter.UI.Theming;
using ProPresenter.UI.ViewModels.Registration.Banners;

namespace ProPresenter.UI.Registration.Banners;

internal class ButtonStyleToBackgroundBrushConverter : IValueConverter
{
	public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		return (value as BannerStyle?) switch
		{
			BannerStyle.LegacyRegistration => AppTheme.Active.PILLBUTTON_OPENREGISTRATION, 
			BannerStyle.LegacyAppUpdates => AppTheme.Active.PILLBUTTON_UPDATESAVAILABLE_LEGACY, 
			BannerStyle.LegacyInactiveSeat => AppTheme.Active.PILLBUTTON_INACTIVESEAT, 
			BannerStyle.LegacyRenewRegistration => AppTheme.Active.PILLBUTTON_RENEWREGISTRATION, 
			BannerStyle.Activate => AppTheme.Active.PILLBUTTON_ACTIVATE, 
			BannerStyle.UpdateAvailable => AppTheme.Active.PILLBUTTON_UPDATESAVAILABLE, 
			_ => AppTheme.Active.PILLBUTTON_OPENREGISTRATION, 
		};
	}

	public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		throw new NotImplementedException();
	}
}
