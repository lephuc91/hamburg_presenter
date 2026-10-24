using System.Collections.Generic;
using System.Threading.Tasks;
using ProPresenter.DO.PCO.RemoteDataModel;
using ProPresenter.DO.PCO.RemoteDataModel.Services.PlanItem;

namespace ProPresenter.DO.PCO.PcoUpdateOperation.ItemCreator;

public interface IPcoItemFactory
{
	Task<PCOItem?> CreatePlanItemAsync(PlanItemData? item, IDictionary<string, PcoData>? inclusions, string? serviceTypeId);
}
