using System.Threading.Tasks;

namespace ProPresenter.DO.PCO.PcoUpdateOperation;

public interface IPcoUpdateOperation
{
	Task<PCOItem?> ExecuteAsync();
}
