using System.Windows;
using System.Windows.Markup;
using Pro.Common.Time;
using Pro.UI.Controls.Windowing;
using ProPresenter.DO.Analytics;
using ProPresenter.UI.ViewModels.WhatsNew;

namespace ProPresenter.UI.WhatsNew;

public partial class WhatsNewWindow : ChromedWindow, IComponentConnector
{
	private readonly Clock _watchClock = new Clock();

	public WhatsNewWindow()
	{
		InitializeComponent();
	}

	private void SendViewedAnalyticEvent()
	{
		string version = (base.DataContext as IWhatsNewV2VM)?.Version?.ToString() ?? string.Empty;
		int viewTime = (int)_watchClock.ElapsedTime.TotalSeconds;
		WhatsNewViewedEvent.Publish(version, viewTime);
	}

	private void WhatsNewWindow_OnIsVisibleChanged(object? sender, DependencyPropertyChangedEventArgs e)
	{
		if (base.IsVisible)
		{
			_watchClock.Start();
			return;
		}
		SendViewedAnalyticEvent();
		_watchClock.Stop();
	}
}
