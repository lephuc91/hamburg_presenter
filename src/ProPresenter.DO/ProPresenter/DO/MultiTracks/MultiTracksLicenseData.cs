using System;

namespace ProPresenter.DO.MultiTracks;

public class MultiTracksLicenseData
{
	public long SongID { get; }

	public string CustomerID { get; }

	public DateTime ExpirationDate { get; }

	public DateTime LicenseExpiration { get; }

	public MultiTracksSubscriptionLevel SubscriptionLevel { get; }

	public MultiTracksLicenseData(long songID, string customerID, DateTime expirationDate, DateTime licenseExpiration, MultiTracksSubscriptionLevel subscriptionLevel)
	{
		SongID = songID;
		CustomerID = customerID;
		ExpirationDate = expirationDate;
		LicenseExpiration = licenseExpiration;
		SubscriptionLevel = subscriptionLevel;
	}
}
