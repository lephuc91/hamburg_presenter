using System;
using System.CodeDom.Compiler;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using Pro.Common.SourceGenerator.Attributes;
using Pro.DO.Utility;
using Pro.SerializationInterop.RVProtoData;
using ProPresenterCore.ProCore.Interop;
using ProPresenterCore.ProCore.Interop.SendDataHandlers;

namespace ProPresenter.SendData.Props;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "_propStatusChangedSubject" })]
public class PropAutoClearHandler : IPropAutoClearHandler, IPropAutoClearService, ISendDataResponseHandler, IDisposable
{
	private readonly Subject<PropStatus> _propStatusChangedSubject = new Subject<PropStatus>();

	private readonly IProCoreInstance _proCore;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public IObservable<PropStatus> WhenPropStatusChangedSubject => _propStatusChangedSubject;

	public PropAutoClearHandler(IProCoreInstance proCore)
	{
		_proCore = proCore;
	}

	public bool CanHandle(SendDataResponse.MessageTypeOneofCase sendDataResponseType)
	{
		return sendDataResponseType == SendDataResponse.MessageTypeOneofCase.PropPause;
	}

	public async Task Handle(SendDataResponse sendDataResponse)
	{
		PropPauseResponse propPause = sendDataResponse.PropPause;
		if (propPause?.Status != null)
		{
			_propStatusChangedSubject.OnNext(new PropStatus(propPause.PropId.ToGuid(), propPause.Status.TimeRemaining, propPause.Status.Paused, propPause.Status.PercentageComplete));
			await Task.CompletedTask;
		}
	}

	public void Play(Guid propId)
	{
		Pro.SerializationInterop.RVProtoData.SendData data = new Pro.SerializationInterop.RVProtoData.SendData
		{
			PropPause = new PropPauseRequest
			{
				PropId = propId.ToUUID(),
				Resume = new PropPauseRequest.Types.Resume()
			}
		};
		_proCore.SendData(data, out var _);
	}

	public void Pause(Guid propId)
	{
		Pro.SerializationInterop.RVProtoData.SendData data = new Pro.SerializationInterop.RVProtoData.SendData
		{
			PropPause = new PropPauseRequest
			{
				PropId = propId.ToUUID(),
				Pause = new PropPauseRequest.Types.Pause()
			}
		};
		_proCore.SendData(data, out var _);
	}

	public void GetStatus(Guid propId)
	{
		Pro.SerializationInterop.RVProtoData.SendData data = new Pro.SerializationInterop.RVProtoData.SendData
		{
			PropPause = new PropPauseRequest
			{
				PropId = propId.ToUUID(),
				Status = new PropPauseRequest.Types.Status()
			}
		};
		_proCore.SendData(data, out var _);
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	protected virtual void Dispose(bool disposing)
	{
		if (!_disposed && disposing)
		{
			_disposed = true;
			_propStatusChangedSubject.Dispose();
		}
	}
}
