using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Pro.DO.Triggering;
using Pro.UI.Components;
using ProPresenter.DO.Capture;

namespace ProPresenter.UI.ActionsMenu.Capture;

public partial class EditCaptureMenuItem : MenuItem, IComponentConnector
{
	public static readonly DependencyProperty CapturePresetsProperty = DependencyProperty.Register("CapturePresets", typeof(ICapturePresetCollection), typeof(EditCaptureMenuItem));

	public static readonly DependencyProperty AssignActionDataCommandProperty = DependencyProperty.Register("AssignActionDataCommand", typeof(ICommand<ActionDataParameter>), typeof(EditCaptureMenuItem));

	public static readonly DependencyProperty EditActionProperty = DependencyProperty.Register("EditAction", typeof(ActionBase), typeof(EditCaptureMenuItem));

	public static readonly DependencyProperty RefreshActionDataProperty = DependencyProperty.Register("RefreshActionData", typeof(bool), typeof(EditCaptureMenuItem));

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

	public ICommand<ActionDataParameter> AssignActionDataCommand
	{
		get
		{
			return (ICommand<ActionDataParameter>)((DependencyObject)this).GetValue(AssignActionDataCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AssignActionDataCommandProperty, (object)value);
		}
	}

	public ActionBase EditAction
	{
		get
		{
			return (ActionBase)((DependencyObject)this).GetValue(EditActionProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(EditActionProperty, (object)value);
		}
	}

	public bool RefreshActionData
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(RefreshActionDataProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(RefreshActionDataProperty, (object)value);
		}
	}

	public EditCaptureMenuItem()
	{
		InitializeComponent();
	}
}
