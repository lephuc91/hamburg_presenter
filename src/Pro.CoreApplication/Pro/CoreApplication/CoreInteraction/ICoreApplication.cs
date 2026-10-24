using System;
using System.Threading.Tasks;
using CoreApplication;
using Pro.CoreApplication.Document.CoreInteraction;
using Pro.CoreApplication.FeatureFlag.CoreInteraction;
using Pro.CoreApplication.Media.V1.CoreInteraction;
using Pro.CoreApplication.Media.V2.CoreInteraction;
using Pro.CoreApplication.Registration.CoreInteraction;
using Pro.CoreApplication.Workspace.CoreInteraction;
using Pro.SerializationInterop.RVProtoData.Application;

namespace Pro.CoreApplication.CoreInteraction;

public interface ICoreApplication
{
	void Start(ApplicationStartParams @params, IApplicationFailureMessageService applicationFailureMessageService, Action quit, Action update);

	Task<ServiceResult<ICoreMediaServiceV1>> GetMediaServiceV1Async();

	Task<ServiceResult<ICoreMediaServiceV2>> GetMediaServiceV2Async();

	Task<ServiceResult<ICoreFeatureFlagService?>> GetFeatureFlagServiceAsync();

	Task<ServiceResult<ICoreCloudWorkspaceService?>> GetCoreCloudWorkspaceServiceAsync();

	Task<ServiceResult<ICoreCloudDocumentService?>> GetCoreCloudDocumentServiceAsync();

	Task<ServiceResult<ICoreRegistrationService?>> GetRegistrationServiceAsync(byte[] config, IManagedNativeCallbackReceiver receiver);
}
