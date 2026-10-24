namespace ProPresenter.DO.Updates;

public interface IAppInstallerFactory
{
	IAppInstaller Create(string fileName);
}
