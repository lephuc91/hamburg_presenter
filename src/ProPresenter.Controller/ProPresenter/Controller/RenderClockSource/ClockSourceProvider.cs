using System;
using System.Collections.Generic;
using Pro.Common.Dispatcher;
using Pro.SerializationInterop.RVProtoData;
using Pro.ssAPI.Devices;
using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.Controller.RenderClockSource;

public class ClockSourceProvider : IClockSourceProvider
{
	private readonly IProCoreInstance _proCore;

	private readonly IUiDispatcher _uiDispatcher;

	public event System.Action? SourceChanged;

	public ClockSourceProvider(IProCoreInstance proCore, IUiDispatcher uiDispatcher)
	{
		_proCore = proCore;
		_uiDispatcher = uiDispatcher;
		_proCore.AddClockSourceChangedCallback(RefreshClockSources);
	}

	public IEnumerable<ProClockSource> Get()
	{
		List<ProClockSource> list = new List<ProClockSource>();
		_proCore.EnumerateClockSources(list.Add);
		return list;
	}

	public void RefreshClockSources()
	{
		_uiDispatcher.Invoke(delegate
		{
			this.SourceChanged?.Invoke();
		});
	}
}
