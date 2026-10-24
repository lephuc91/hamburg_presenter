namespace ProPresenter.DO.Registration.State.Bible;

public record LicensingInfo(bool IsActiveLocally, int AvailableCopies, int TotalCopies, ActiveCopy[] OtherActiveCopies);
