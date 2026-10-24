using System;

namespace ProPresenter.Controller;

public interface ISettingsDataToCoreSender : IDisposable
{
	void SendSettingsToCore();
}
