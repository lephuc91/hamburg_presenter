using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Pro.UI.Components;
using Pro.UI.DialogService;
using ProPresenter.DO.OutputConfiguration;

namespace ProPresenter.UI.OutputConfiguration;

public partial class ScreenSelectionControl : UserControl, IComponentConnector
{
	public static readonly DependencyProperty SelectedAudienceScreenArrangementProperty = DependencyProperty.Register("SelectedAudienceScreenArrangement", typeof(ScreenArrangementBase), typeof(ScreenSelectionControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

	public static readonly DependencyProperty SelectedStageScreenArrangementProperty = DependencyProperty.Register("SelectedStageScreenArrangement", typeof(ScreenArrangementBase), typeof(ScreenSelectionControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

	public static readonly DependencyProperty AudienceArrangementScreensProperty = DependencyProperty.Register("AudienceArrangementScreens", typeof(AudienceScreenArrangementCollection), typeof(ScreenSelectionControl));

	public static readonly DependencyProperty StageArrangementScreensProperty = DependencyProperty.Register("StageArrangementScreens", typeof(StageScreenArrangementCollection), typeof(ScreenSelectionControl));

	public static readonly DependencyProperty RemoveScreenArrangementCommandProperty = DependencyProperty.Register("RemoveScreenArrangementCommand", typeof(ICommand<ScreenArrangementBase>), typeof(ScreenSelectionControl));

	public static readonly DependencyProperty DeviceSelectorProperty = DependencyProperty.Register("DeviceSelector", typeof(ContextMenu), typeof(ScreenSelectionControl));

	public static readonly DependencyProperty ActivateScreenArrangementCommandProperty = DependencyProperty.Register("ActivateScreenArrangementCommand", typeof(ICommand<ScreenArrangementBase>), typeof(ScreenSelectionControl));

	public static readonly DependencyProperty AudienceScreensVisibleProperty = DependencyProperty.Register("AudienceEnable", typeof(bool), typeof(ScreenSelectionControl), new PropertyMetadata((object)false));

	public static readonly DependencyProperty StageScreensVisibleProperty = DependencyProperty.Register("StageEnable", typeof(bool), typeof(ScreenSelectionControl), new PropertyMetadata((object)false));

	public static readonly DependencyProperty CanAddMoreScreensProperty = DependencyProperty.Register("CanAddMoreScreens", typeof(bool), typeof(ScreenSelectionControl), new PropertyMetadata((object)false));

	public ScreenArrangementBase? SelectedAudienceScreenArrangement
	{
		get
		{
			return (ScreenArrangementBase)((DependencyObject)this).GetValue(SelectedAudienceScreenArrangementProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedAudienceScreenArrangementProperty, (object)value);
		}
	}

	public ScreenArrangementBase? SelectedStageScreenArrangement
	{
		get
		{
			return (ScreenArrangementBase)((DependencyObject)this).GetValue(SelectedStageScreenArrangementProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedStageScreenArrangementProperty, (object)value);
		}
	}

	public AudienceScreenArrangementCollection? AudienceArrangementScreens
	{
		get
		{
			return (AudienceScreenArrangementCollection)((DependencyObject)this).GetValue(AudienceArrangementScreensProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AudienceArrangementScreensProperty, (object)value);
		}
	}

	public StageScreenArrangementCollection? StageArrangementScreens
	{
		get
		{
			return (StageScreenArrangementCollection)((DependencyObject)this).GetValue(StageArrangementScreensProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(StageArrangementScreensProperty, (object)value);
		}
	}

	public ICommand<ScreenArrangementBase>? RemoveScreenArrangementCommand
	{
		get
		{
			return (ICommand<ScreenArrangementBase>)((DependencyObject)this).GetValue(RemoveScreenArrangementCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(RemoveScreenArrangementCommandProperty, (object)value);
		}
	}

	public ContextMenu? DeviceSelector
	{
		get
		{
			return (ContextMenu)((DependencyObject)this).GetValue(DeviceSelectorProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DeviceSelectorProperty, (object)value);
		}
	}

	public ICommand<ScreenArrangementBase>? ActivateScreenArrangementCommand
	{
		get
		{
			return (ICommand<ScreenArrangementBase>)((DependencyObject)this).GetValue(ActivateScreenArrangementCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ActivateScreenArrangementCommandProperty, (object)value);
		}
	}

	public bool AudienceEnable
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(AudienceScreensVisibleProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AudienceScreensVisibleProperty, (object)value);
		}
	}

	public bool StageEnable
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(StageScreensVisibleProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(StageScreensVisibleProperty, (object)value);
		}
	}

	public bool CanAddMoreScreens
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(CanAddMoreScreensProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CanAddMoreScreensProperty, (object)value);
		}
	}

	public ScreenSelectionControl()
	{
		InitializeComponent();
	}

	public bool ShouldAllowSelectionChange(ScreenArrangementBase changeSelectionTo)
	{
		ScreenArrangementBase screenArrangementBase = SelectedAudienceScreenArrangement ?? SelectedStageScreenArrangement;
		if (screenArrangementBase != null && screenArrangementBase != changeSelectionTo)
		{
			Screen screen = Array.Find(screenArrangementBase.Screens, delegate(Screen x)
			{
				IDevice? mainOutputDevice = x.MainOutputDevice;
				if (mainOutputDevice == null || !mainOutputDevice.ValidationError.HasValue)
				{
					HardwareScreenRectangleOptions alphaOutput = x.AlphaOutput;
					if (alphaOutput == null)
					{
						return false;
					}
					return alphaOutput.OutputDevice?.ValidationError.HasValue ?? false;
				}
				return true;
			});
			if (screen != null)
			{
				(string, string)? tuple = screen.MainOutputDevice?.ValidationError ?? screen.AlphaOutput?.OutputDevice?.ValidationError;
				MessageDialogService.ShowAlert(tuple.Value.Item1, tuple.Value.Item2);
				return false;
			}
		}
		return true;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
