using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Pro.UI.Components;
using ProPresenter.DO.Actions.Capture;
using ProPresenter.DO.Capture;

namespace ProPresenter.UI.ActionsMenu.Capture;

public partial class AddCaptureMenuItem : MenuItem, IComponentConnector
{
	public static readonly DependencyProperty CapturePresetsProperty = DependencyProperty.Register("CapturePresets", typeof(ICapturePresetCollection), typeof(AddCaptureMenuItem));

	public static readonly DependencyProperty AddCaptureActionCommandProperty = DependencyProperty.Register("AddCaptureActionCommand", typeof(ICommand<CaptureType>), typeof(AddCaptureMenuItem));

	public static readonly DependencyProperty AddCaptureActionWithPresetCommandProperty = DependencyProperty.Register("AddCaptureActionWithPresetCommand", typeof(ICommand<CapturePreset>), typeof(AddCaptureMenuItem));

	public ICapturePresetCollection CapturePresets
	{
		get
		{
			return (ICapturePresetCollection)((DependencyObject)this).GetValue(CapturePresetsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CapturePresetsProperty, (object)value);
		}
	}

	public ICommand<CaptureType> AddCaptureActionCommand
	{
		get
		{
			return (ICommand<CaptureType>)((DependencyObject)this).GetValue(AddCaptureActionCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AddCaptureActionCommandProperty, (object)value);
		}
	}

	public ICommand<CapturePreset> AddCaptureActionWithPresetCommand
	{
		get
		{
			return (ICommand<CapturePreset>)((DependencyObject)this).GetValue(AddCaptureActionWithPresetCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AddCaptureActionWithPresetCommandProperty, (object)value);
		}
	}

	public AddCaptureMenuItem()
	{
		InitializeComponent();
	}
}
