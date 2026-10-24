using System;

namespace ProPresenter.DO.MultiTracks;

public class MultiTracksAccountInfo
{
	public string UserID { get; }

	public string CustomerID { get; }

	public string FirstName { get; }

	public string LastName { get; }

	public string Organization { get; }

	public int RemainingChartProSongs { get; }

	public int RemainingSlideSongs { get; }

	public MultiTracksSubscriptionStatus ChartProStatus { get; }

	public DateTime ChartProSubscriptionDate { get; }

	public MultiTracksSubscriptionStatus SlideProStatus { get; }

	public DateTime SlideSubscriptionDate { get; }

	public MultiTracksAccountInfo(string userID, string customerID, string firstName, string lastName, string organization, int remainingChartProSongs, int remainingSlideSongs, MultiTracksSubscriptionStatus chartProStatus, DateTime chartProSubscriptionDate, MultiTracksSubscriptionStatus slideProStatus, DateTime slideSubscriptionDate)
	{
		UserID = userID;
		CustomerID = customerID;
		FirstName = firstName;
		LastName = lastName;
		Organization = organization;
		RemainingChartProSongs = remainingChartProSongs;
		RemainingSlideSongs = remainingSlideSongs;
		ChartProStatus = chartProStatus;
		ChartProSubscriptionDate = chartProSubscriptionDate;
		SlideProStatus = slideProStatus;
		SlideSubscriptionDate = slideSubscriptionDate;
	}
}
