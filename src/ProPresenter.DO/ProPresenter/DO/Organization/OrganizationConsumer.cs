using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Pro.Common.AuthenticatingApiConsumer;
using Pro.Common.AuthenticatingApiConsumer.OAuth2;
using Pro.Common.FeatureFlag;
using Pro.Common.HTTP;
using Pro.Common.Logging;
using Pro.Common.OAuth.Authenticator;
using ProPresenter.DO.Organization.Avatar.Model;
using ProPresenter.DO.Organization.Avatar.RemoteModel;
using RestSharp;

namespace ProPresenter.DO.Organization;

public sealed class OrganizationConsumer : IOrganizationConsumer
{
	private static readonly Uri API_BASE_URL = new Uri("https://api.renewedvision.com");

	private static readonly Uri API_BASE_URL_STAGING = new Uri("https://api-staging.renewedvision.com");

	private static readonly Uri PRO_CONTENT_BASE_URL = new Uri("https://procontent.renewedvision.com");

	private static readonly Uri PRO_CONTENT_BASE_URL_STAGING = new Uri("https://procontent-staging.renewedvision.com");

	private const string AUTHORIZE_PATH = "/oauth/authorize";

	private const string GET_TOKEN_PATH = "/oauth/token";

	private const string AUTHORIZE_CALLBACK_URI = "https://renewedvision.com/oauth2/callback";

	private const string GET_AVATAR_URL_ENDPOINT = "/api/v1/organization/avatar-url";

	private readonly IAuthenticatingApiConsumer _apiConsumer;

	private readonly IRestClientFactory _restClientFactory;

	private readonly ILogger _logger;

	public OrganizationConsumer(IAuthenticatingApiConsumerFactory consumerFactory, IFlagService flagService, IOAuth2AuthorizationStore authorizationStorage, IOAuth2ClientInfoProvider clientInfoProvider, IRestClientFactory restClientFactory, ILogger logger)
	{
		_restClientFactory = restClientFactory;
		_logger = logger;
		bool num = flagService.IsFlagEnabled(Flag.StagingApiEndpoints);
		_apiConsumer = consumerFactory.CreateOAuth2ConsumerWithPkceFlow(authorizationStorage, clientInfoProvider, num ? API_BASE_URL_STAGING : API_BASE_URL, num ? PRO_CONTENT_BASE_URL_STAGING : PRO_CONTENT_BASE_URL, "/oauth/authorize", "/oauth/token", "https://renewedvision.com/oauth2/callback");
	}

	public async Task<IAvatarResult> GetAvatarAsync(DateTimeOffset cachedAvatarTimestamp, CancellationToken cancellationToken = default(CancellationToken))
	{
		_ = 1;
		try
		{
			RestRequest request = new RestRequest("/api/v1/organization/avatar-url");
			RestResponse<AvatarMetadata> restResponse = await _apiConsumer.ExecuteAsync<AvatarMetadata>(request, RestSharp.Method.Get, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			if (restResponse.StatusCode == HttpStatusCode.NotFound)
			{
				return new NoAvatar();
			}
			if (restResponse.IsSuccessful)
			{
				AvatarMetadata data = restResponse.Data;
				if (data != null)
				{
					AvatarMetadataResult result = data.Result;
					if (result != null && result.Success)
					{
						AvatarMetadataData data2 = data.Data;
						if (data2 != null)
						{
							string url = data2.Url;
							if (url != null)
							{
								DateTimeOffset avatarTimestamp = data2.LastModifiedAt ?? DateTimeOffset.MinValue;
								if (avatarTimestamp == cachedAvatarTimestamp)
								{
									return new UnchangedAvatar();
								}
								Stream stream = await DownloadImageAsync(url, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
								IAvatarResult result2;
								if (stream != null)
								{
									IAvatarResult avatarResult = new NewAvatar(new AvatarData(stream, avatarTimestamp));
									result2 = avatarResult;
								}
								else
								{
									IAvatarResult avatarResult = new UnchangedAvatar();
									result2 = avatarResult;
								}
								return result2;
							}
						}
					}
				}
			}
			_logger.Warning("[{0}] Failed to fetch avatar metadata. Returned status code: {1}, content: {2}", "OrganizationConsumer", restResponse.StatusCode, restResponse.Content);
			return new UnchangedAvatar();
		}
		catch (Exception ex)
		{
			_logger.Warning("[{0}] Failed to fetch avatar. Exception was thrown:{1}", "OrganizationConsumer", ex);
			return new UnchangedAvatar();
		}
	}

	private async Task<Stream?> DownloadImageAsync(string signedUrl, CancellationToken cancellationToken)
	{
		using IRestClient client = _restClientFactory.Get();
		Stream result;
		await using (Stream downloadStream = await client.DownloadStreamAsync(new RestRequest(new Uri(signedUrl)), cancellationToken).ConfigureAwait(continueOnCapturedContext: false))
		{
			if (downloadStream == null)
			{
				result = null;
			}
			else
			{
				MemoryStream memoryStream = new MemoryStream();
				await downloadStream.CopyToAsync(memoryStream, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				memoryStream.Seek(0L, SeekOrigin.Begin);
				result = memoryStream;
			}
		}
		return result;
	}
}
