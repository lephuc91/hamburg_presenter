using System.Threading.Tasks;
using Pro.Common.Logging;
using Pro.SerializationInterop.RVProtoData.Service.Workspace.Call;

namespace Pro.CoreApplication.Workspace.CoreInteraction;

public interface ICoreCloudWorkspaceService
{
	Task<OpenLocal.Types.Result> OpenLocalAsync(OpenLocal request);

	Task<OpenRemote.Types.Result> OpenRemoteAsync(OpenRemote request);

	Task<Publish.Types.Result> PublishAsync(Publish request);

	Task<Rename.Types.Result> RenameAsync(Rename request);

	Task<ConvertToLocal.Types.Result> ConvertToLocalAsync();

	Task<PauseSync.Types.Result> PauseSyncAsync(PauseSync request);

	Task<ResumeSync.Types.Result> ResumeSyncAsync();

	ICoreCloudWorkspaceSubscription Subscribe(ILogger logger);
}
