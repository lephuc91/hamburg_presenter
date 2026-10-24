using Jab;
using Pro.Common.DataFlow;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.SendData.Props;
using ProPresenterCore.ProCore.Interop;
using ProPresenterCore.ProCore.Interop.SendDataHandlers;

namespace ProPresenter.SendData.DependencyInjection;

[Jab.ServiceProviderModule]
[Jab.Singleton<PropAutoClearHandler>]
[Jab.Singleton<IPropAutoClearHandler>(Factory = "GetPropAutoClearHandler")]
[Jab.Singleton<IPropAutoClearService>(Factory = "GetPropAutoClearHandler")]
[Jab.Singleton<ISendDataResponseHandlerProvider, SendDataResponseHandlerProvider>]
[Jab.Singleton<IDataProcessor<SendDataResponse>, ProCoreSendDataProcessor>]
internal interface ISendDataServiceProviderModule
{
	static PropAutoClearHandler GetPropAutoClearHandler(PropAutoClearHandler handler)
	{
		return handler;
	}
}
