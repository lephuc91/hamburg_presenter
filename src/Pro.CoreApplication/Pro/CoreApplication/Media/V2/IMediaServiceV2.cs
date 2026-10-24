using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pro.SerializationInterop.RVProtoData.MediaManagement.v2;
using Pro.SerializationInterop.RVProtoData.MediaService.v2;

namespace Pro.CoreApplication.Media.V2;

public interface IMediaServiceV2 : IMediaService
{
	Task<IMediaServiceResponse> UpdateWorkspacesAsync(IReadOnlyList<(Guid? Id, string Path)> workspaceInfos);

	Task<IMediaServiceResponse> AddProContentReference(AddProContentReference request);

	Task<IMediaServiceResponse> AddMediaReference(AddMediaReference request);

	Task<IMediaServiceResponse> ApplyTransformation(ApplyTransformation request);

	Task<IMediaServiceResponse> DuplicateMediaReference(DuplicateMediaReference request);

	Task<IMediaServiceResponse> GetMedia(RequestEnvelope.Types.GetMediaReference request);

	Task<IMediaServiceResponse> RemoveMediaReference(RemoveMediaReferences request);

	Task<IMediaServiceResponse> UpdateAvailableSmartPlaylists(IReadOnlySet<string> smartPlaylistPaths);

	Task<IMediaServiceResponse> SendTriggeredMedia(string containerId, string mediaReferenceId);
}
