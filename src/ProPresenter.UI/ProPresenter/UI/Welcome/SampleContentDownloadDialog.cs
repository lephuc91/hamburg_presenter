using System;
using System.ComponentModel;
using System.Windows.Markup;
using System.Windows.Threading;
using Pro.UI.Controls.Windowing;
using ProPresenter.UI.ViewModels.Welcome;

namespace ProPresenter.UI.Welcome;

public partial class SampleContentDownloadDialog : ChromedWindow, IComponentConnector
{
	public SampleContentDownloadDialog(ISampleContentVM viewModel)
	{
		base.DataContext = viewModel;
		InitializeComponent();
		viewModel.PropertyChanged += OnViewModelPropertyChanged;
	}

	private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "IsDownloading" && base.DataContext is ISampleContentVM { IsDownloading: false })
		{
			((DispatcherObject)this).Dispatcher.BeginInvoke((Delegate)new Action(base.Close), Array.Empty<object>());
		}
	}

	protected override void OnClosed(EventArgs e)
	{
		if (base.DataContext is ISampleContentVM sampleContentVM)
		{
			sampleContentVM.PropertyChanged -= OnViewModelPropertyChanged;
			if (sampleContentVM.IsDownloading)
			{
				sampleContentVM.CancelDownloadCommand.Execute(null);
			}
		}
		base.OnClosed(e);
	}
}
