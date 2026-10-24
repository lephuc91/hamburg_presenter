using System;
using System.ComponentModel;
using ProPresenter.DO.Registration.State.Bible;

namespace ProPresenter.DO.Registration.State;

public interface IRegistrationStateProvider : INotifyPropertyChanged
{
	RegistrationState Registration { get; }

	Metadata[] FreeBibles { get; }

	Purchased[] PurchasedBibles { get; }

	OAuthToken? Token { get; }

	BannerMessage BannerMessage { get; }

	HardwareInfo HardwareInformation { get; }

	[Obsolete("Be very careful to only use the organization ID for logging purposes. The way we receive it is very fragile and can change any time.")]
	string OrganizationId { get; }

	event Action? PerformUpdateCheck;

	void UpdateToken(string accessToken, string refreshToken, DateTimeOffset dateTimeOffset);
}
