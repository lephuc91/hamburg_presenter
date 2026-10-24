using System.Threading.Tasks;
using Pro.Common.Logging;
using Pro.SerializationInterop.RVProtoData.Service.Document.Call;

namespace Pro.CoreApplication.Document.CoreInteraction;

public interface ICoreCloudDocumentService
{
	Task<Load.Types.Result> LoadAsync(Load request);

	Task<Patch.Types.Result> PatchAsync(Patch request);

	Task<Add.Types.Result> AddAsync(Add request);

	Task<Relocate.Types.Result> RelocateAsync(Relocate request);

	Task<Remove.Types.Result> RemoveAsync(Remove request);

	ICoreCloudDocumentSubscription Subscribe(ILogger logger);
}
