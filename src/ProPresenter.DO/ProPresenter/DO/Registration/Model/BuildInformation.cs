namespace ProPresenter.DO.Registration.Model;

public record BuildInformation(int BuildNumber, string Version, string MinOsVersion, string DownloadUrl, bool IsBeta, bool IsAvailable, bool IsDowngrade);
