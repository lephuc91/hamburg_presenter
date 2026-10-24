using System.Collections.Generic;
using System.Threading.Tasks;
using Pro.SerializationInterop.RVProtoData.MediaManagement.v1;
using Pro.SerializationInterop.RVProtoData.MediaService.v1;

namespace Pro.CoreApplication.Media.V1;

public interface IMediaServiceV1 : IMediaService
{
	Task<IMediaServiceResponse> ChangeShowDirectoryAsync(string path);

	Task<IMediaServiceResponse> UpdateWorkspacesAsync(IReadOnlyList<string> workspacePaths);

	Task<IMediaServiceResponse> AddMediaReference(AddMediaReference request);

	Task<IMediaServiceResponse> ApplyTransformation(ApplyTransformation request);

	Task<IMediaServiceResponse> DuplicateMediaReference(DuplicateMediaReference request);

	Task<IMediaServiceResponse> GetMedia(RequestEnvelope.Types.GetMediaReference request);

	Task<IMediaServiceResponse> RemoveMediaReference(RemoveMediaReferences request);

	Task<IMediaServiceResponse> PauseThumbnailGeneration(PauseGenerationOptions options);

	Task<IMediaServiceResponse> ResumeThumbnailGeneration();

	Task<IMediaServiceResponse> SendTriggeredMedia(string mediaId);
}
