namespace ProPresenter.DO.Registration.State.ProPresenter;

public record SeatInformation(bool IsActive, int TotalSeats = -1, int AvailableSeats = -1)
{
	public bool HasSeatData => TotalSeats >= 0;
}
