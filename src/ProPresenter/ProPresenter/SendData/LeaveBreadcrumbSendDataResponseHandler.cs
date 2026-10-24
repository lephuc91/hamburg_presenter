using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bugsnag;
using Pro.Reporting;
using Pro.SerializationInterop.RVProtoData;
using ProPresenterCore.ProCore.Interop.SendDataHandlers;

namespace ProPresenter.SendData;

public class LeaveBreadcrumbSendDataResponseHandler : ISendDataResponseHandler
{
	private readonly Stargazer.LeaveBreadcrumbDelegate _leaveBreadcrumbDelegate;

	public LeaveBreadcrumbSendDataResponseHandler(Stargazer.LeaveBreadcrumbDelegate leaveBreadcrumbDelegate)
	{
		_leaveBreadcrumbDelegate = leaveBreadcrumbDelegate;
	}

	public bool CanHandle(SendDataResponse.MessageTypeOneofCase sendDataResponseType)
	{
		return sendDataResponseType == SendDataResponse.MessageTypeOneofCase.LeaveBreadcrumb;
	}

	public async Task Handle(SendDataResponse sendDataResponse)
	{
		if (sendDataResponse.LeaveBreadcrumb != null && _leaveBreadcrumbDelegate != null)
		{
			BreadcrumbType type = sendDataResponse.LeaveBreadcrumb.Type switch
			{
				LeaveBreadcrumb.Types.Type.Navigation => BreadcrumbType.Navigation, 
				LeaveBreadcrumb.Types.Type.Request => BreadcrumbType.Request, 
				LeaveBreadcrumb.Types.Type.Process => BreadcrumbType.Process, 
				LeaveBreadcrumb.Types.Type.Log => BreadcrumbType.Log, 
				LeaveBreadcrumb.Types.Type.User => BreadcrumbType.User, 
				LeaveBreadcrumb.Types.Type.State => BreadcrumbType.State, 
				LeaveBreadcrumb.Types.Type.Error => BreadcrumbType.Error, 
				LeaveBreadcrumb.Types.Type.Manual => BreadcrumbType.Manual, 
				_ => BreadcrumbType.Log, 
			};
			Dictionary<string, string> metadata = sendDataResponse.LeaveBreadcrumb.Metadata.ToDictionary((KeyValuePair<string, string> i) => i.Key, (KeyValuePair<string, string> i) => i.Value);
			_leaveBreadcrumbDelegate(sendDataResponse.LeaveBreadcrumb.Description, type, metadata);
			await Task.CompletedTask;
		}
	}
}
