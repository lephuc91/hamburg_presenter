using System;
using System.ComponentModel;
using Pro.Common.Components.Reversibility;

namespace ProPresenter.DO.Communication;

public interface IDevice : INotifyPropertyChanged
{
	DeviceType Type { get; }

	Guid ID { get; }

	string Status { get; }

	string Label { get; set; }

	bool IsConnected { get; }

	UndoStack? UndoStack { get; set; }

	void Connect();

	void Disconnect();
}
