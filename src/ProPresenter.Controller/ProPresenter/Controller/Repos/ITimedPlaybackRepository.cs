using System.Threading.Tasks;
using Pro.SerializationInterop.RVProtoData;
using ProPresenterCore.ProCore.Interop;
using ProPresenterCore.ProCore.Interop.Triggering.Types;

namespace ProPresenter.Controller.Repos;

public interface ITimedPlaybackRepository
{
	Task<TriggerHandle> CreateTimedPlaybackSessionAsync(TimedPlayback data);

	Task<ProResult> DestroyTimedPlaybackSessionAsync(TriggerHandle handle);

	Task UpdateTimedPlaybackSessionAsync(TriggerHandle handle, TimedPlayback.Types.Update update);

	Task<TimedPlaybackStatus> GetTimedPlaybackSessionStatusAsync(TriggerHandle? handle);
}
