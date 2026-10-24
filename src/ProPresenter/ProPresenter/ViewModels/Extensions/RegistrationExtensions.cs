using Pro.Localization.Services;
using ProPresenter.DO.Registration.State;
using ProPresenter.DO.Registration.State.ProPresenter;
using ProPresenter.DO.Registration.State.Subscription;

namespace ProPresenter.ViewModels.Extensions;

internal static class RegistrationExtensions
{
	public static string ToItemTitle(this IRegistrationStateProvider registrationStateProvider, ILocalization localization)
	{
		ISubscriptionState subscriptionState = registrationStateProvider.Registration.SubscriptionState;
		if (!(subscriptionState is ProPresenter.DO.Registration.State.Subscription.SubscribedState subscribedState))
		{
			if (subscriptionState is UnsubscribedState)
			{
				return (registrationStateProvider.Registration.ProPresenter is CodeState codeState) ? codeState.UserName : localization.Get("SETTINGS_ACCOUNT_ROW_SIGN_IN_label");
			}
			return string.Empty;
		}
		return subscribedState.OrganizationName;
	}

	public static string ToItemSubtitle(this IRegistrationStateProvider registrationStateProvider, ILocalization localization)
	{
		if (registrationStateProvider.Registration.ProPresenter is IRegisteredState registeredState)
		{
			if (!registeredState.SeatInfo.IsActive)
			{
				return localization.Get("SETTINGS_ACCOUNT_ROW_SEAT_INACTIVE_label");
			}
			return localization.Get("SETTINGS_ACCOUNT_ROW_SEAT_ACTIVE_label");
		}
		ISubscriptionState subscriptionState = registrationStateProvider.Registration.SubscriptionState;
		if (!(subscriptionState is ProPresenter.DO.Registration.State.Subscription.SubscribedState))
		{
			if (subscriptionState is UnsubscribedState)
			{
				return localization.Get("SETTINGS_ACCOUNT_ROW_ACTIVATE_PROPRESENTER_label");
			}
			return localization.Get("SETTINGS_ACCOUNT_ROW_AUTHORIZING_LICENSE_label");
		}
		return localization.Get("SETTINGS_ACCOUNT_ROW_SEAT_INACTIVE_label");
	}
}
