using System.Threading.Tasks;

namespace ProPresenter.Utility;

public interface IInstallFileExecutor
{
	Task DoInstallAsync(string sourceFile, string destination);
}
