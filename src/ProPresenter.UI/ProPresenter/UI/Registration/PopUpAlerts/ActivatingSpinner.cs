using System;
using System.Windows.Markup;
using Pro.UI.Controls.Windowing;

namespace ProPresenter.UI.Registration.PopUpAlerts;

public sealed partial class ActivatingSpinner : ChromedWindow, IDisposable, IComponentConnector
{
	private bool _isDisposed;

	public ActivatingSpinner()
	{
		InitializeComponent();
	}

	public void Dispose()
	{
		if (!_isDisposed)
		{
			_isDisposed = true;
			Close();
		}
	}
}
