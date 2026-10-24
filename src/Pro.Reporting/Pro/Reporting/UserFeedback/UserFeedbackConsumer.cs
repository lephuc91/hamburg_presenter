using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Pro.Common.HTTP;
using Pro.Common.HTTP.Results;
using Pro.Common.Logging;
using Pro.Reporting.UserFeedback.AttachmentUpload.Model;
using Pro.Web.Services;
using RestSharp;
using RestSharp.Interceptors;

namespace Pro.Reporting.UserFeedback;

public class UserFeedbackConsumer : IUserFeedbackConsumer
{
	private sealed class LoggingInterceptor : Interceptor
	{
		private readonly ILogger _logger;

		private readonly string _format;

		public LoggingInterceptor(ILogger logger, string format)
		{
			_logger = logger;
			_format = format;
		}

		public override async ValueTask BeforeHttpRequest(HttpRequestMessage requestMessage, CancellationToken cancellationToken)
		{
			await base.BeforeHttpRequest(requestMessage, cancellationToken);
			ILogger logger = _logger;
			string format = _format;
			object obj = "UserFeedbackConsumer";
			string text = ((requestMessage.Content != null) ? (await requestMessage.Content.ReadAsStringAsync()) : string.Empty);
			logger.Info(format, obj, text);
		}
	}

	private const string POST_FEEDBACK_ENDPOINT = "/reports/feedback";

	private const string GET_FEEDBACK_ATTACHMENT_SETTINGS_ENDPOINT = "/reports/feedbackAttachmentSettings";

	private const string POST_CRASHREPORT_ENDPOINT = "/reports/crashreport";

	private const string GET_CRASHREPORT_ATTACHMENT_SETTINGS_ENDPOINT = "/reports/crashreportAttachmentSettings";

	private const string POST_CRASHREPORT_ATTACHMENT_SETTINGS_ENDPOINT = "/reports/createAttachmentUpload";

	private readonly ILogger _logger;

	private readonly IRestClientFactory _restClientFactory;

	private readonly Uri _baseUrl;

	public UserFeedbackConsumer(ILogger logger, IRestClientFactory restClientFactory, IApiService apiService)
	{
		_logger = logger;
		_restClientFactory = restClientFactory;
		_baseUrl = new Uri(apiService.GetTargetRedirectHost(includeProtocol: true));
	}

	public async Task<IRequestResult> PostFeedbackAsync(FeedbackReport report, CancellationToken cancellationToken = default(CancellationToken), IEnumerable<UploadHeader>? additionalHeaders = null)
	{
		RestRequest request = new RestRequest("/reports/feedback", RestSharp.Method.Post)
		{
			Interceptors = new List<Interceptor>(1)
			{
				new LoggingInterceptor(_logger, "[{0}] Sending Feedback: {1}")
			}
		};
		request.AddJsonBody(report);
		AttachAdditionalHeaders(request, additionalHeaders);
		return await ExecuteWithErrorHandlingAsync<bool>(request, cancellationToken);
	}

	public async Task<IRequestResult> GetFeedbackAttachmentSettingsAsync(CancellationToken cancellationToken = default(CancellationToken))
	{
		RestRequest request = new RestRequest("/reports/feedbackAttachmentSettings");
		return await ExecuteWithErrorHandlingAsync<AttachmentSettings>(request, cancellationToken);
	}

	public async Task<IRequestResult> PostCrashReportAsync(CrashReport report, CancellationToken cancellationToken = default(CancellationToken), IEnumerable<UploadHeader>? additionalHeaders = null)
	{
		RestRequest request = new RestRequest("/reports/crashreport", RestSharp.Method.Post)
		{
			Interceptors = new List<Interceptor>(1)
			{
				new LoggingInterceptor(_logger, "[{0}] Sending Crash: {1}")
			}
		};
		request.AddJsonBody(report);
		AttachAdditionalHeaders(request, additionalHeaders);
		return await ExecuteWithErrorHandlingAsync<bool>(request, cancellationToken);
	}

	public async Task<IRequestResult> GetCrashReportAttachmentSettingsAsync(CancellationToken cancellationToken = default(CancellationToken))
	{
		RestRequest request = new RestRequest("/reports/crashreportAttachmentSettings");
		return await ExecuteWithErrorHandlingAsync<AttachmentSettings>(request, cancellationToken);
	}

	public async Task<IRequestResult> PostCreateAttachmentUploadAsync(AttachmentUploadRequest uploadRequest, CancellationToken cancellationToken = default(CancellationToken), IEnumerable<UploadHeader>? additionalHeaders = null)
	{
		RestRequest request = new RestRequest("/reports/createAttachmentUpload", RestSharp.Method.Post)
		{
			Interceptors = new List<Interceptor>(1)
			{
				new LoggingInterceptor(_logger, "[{0}] Sending Create Attachment Upload: {1}")
			}
		};
		request.AddJsonBody(uploadRequest);
		AttachAdditionalHeaders(request, additionalHeaders);
		return await ExecuteWithErrorHandlingAsync<AttachmentUploadResponse>(request, cancellationToken);
	}

	private static void AttachAdditionalHeaders(RestRequest request, IEnumerable<UploadHeader>? additionalHeaders)
	{
		if (additionalHeaders == null || request == null)
		{
			return;
		}
		foreach (UploadHeader additionalHeader in additionalHeaders)
		{
			request.AddHeader(additionalHeader.Key, additionalHeader.Value);
		}
	}

	private IRestClient GetClient()
	{
		return _restClientFactory.Get(delegate(RestClientOptions options)
		{
			options.BaseUrl = _baseUrl;
		});
	}

	private async Task<IRequestResult> ExecuteWithErrorHandlingAsync<T>(RestRequest request, CancellationToken cancellationToken = default(CancellationToken)) where T : notnull
	{
		using IRestClient client = GetClient();
		try
		{
			RestResponse<T> restResponse = await client.ExecuteAsync<T>(request, cancellationToken);
			if (restResponse.IsSuccessful)
			{
				if (restResponse.Data != null)
				{
					return new SuccessResult<T>(restResponse.Data);
				}
			}
			else if (cancellationToken.IsCancellationRequested)
			{
				return new CancelledResult();
			}
			_logger.Warning("[{0}] Failed to {4} resource {1}. Returned status code: {2}, returned data: {3}", "UserFeedbackConsumer", request.Resource, restResponse.StatusCode, restResponse.Content, request.Method);
			return new ErrorResult();
		}
		catch (Exception ex)
		{
			_logger.Warning("[{0}] Failed to {3} resource {1}. Exception was thrown:{2}", "UserFeedbackConsumer", request.Resource, ex, request.Method);
			return new ErrorResult(ex);
		}
	}
}
