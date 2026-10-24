using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Markup;
using Pro.Common.Collections;
using Pro.DO.Effects;
using Pro.DO.Effects.Descriptions;
using Pro.UI.Utility;
using ProPresenter.UI.ViewModels.CueInspector;

namespace ProPresenter.UI.CueInspector;

public partial class EffectControl : UserControl, IComponentConnector, IStyleConnector
{
	public class EffectParametersStyleSelector : StyleSelector
	{
		private const string EffectParamsStyle = "EffectParamsStyle";

		private readonly ResourceDictionary _resources;

		public EffectParametersStyleSelector(ResourceDictionary resources)
		{
			_resources = resources;
		}

		public override Style SelectStyle(object item, DependencyObject container)
		{
			if (item is EffectParameters)
			{
				return (Style)_resources["EffectParamsStyle"];
			}
			return base.SelectStyle(item, container);
		}
	}

	public static readonly DependencyProperty ContextMenuPlacementProperty = DependencyProperty.Register("ContextMenuPlacement", typeof(PlacementMode), typeof(EffectControl), new PropertyMetadata((object)PlacementMode.Bottom));

	private IEffectsVM? EffectsVM => base.DataContext as IEffectsVM;

	public EffectParametersStyleSelector EffectParamsStyleSelector { get; }

	public PlacementMode ContextMenuPlacement
	{
		get
		{
			return (PlacementMode)((DependencyObject)this).GetValue(ContextMenuPlacementProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ContextMenuPlacementProperty, (object)value);
		}
	}

	public EffectControl()
	{
		InitializeComponent();
		EffectParamsStyleSelector = new EffectParametersStyleSelector(base.Resources);
	}

	private void UpdateEffect(object? sender, RoutedEventArgs e)
	{
		MenuItem menuItem = sender as MenuItem;
		if (menuItem?.DataContext is EffectDescription newEffect)
		{
			EffectParameters effectParameters = (((DependencyObject)(object)menuItem).FindVisualParent<ContextMenu>()?.PlacementTarget as FrameworkElement)?.DataContext as EffectParameters;
			EffectsVM?.UpdateEffectCommand?.Invoke(new EffectCommandParameters(effectParameters, (object)effectParameters != null, newEffect));
		}
	}

	private void RemoveEffect(object? sender, RoutedEventArgs e)
	{
		if ((((DependencyObject)(object)(sender as MenuItem))?.FindVisualParent<ContextMenu>()?.PlacementTarget as FrameworkElement)?.DataContext is EffectParameters targetEffectParams)
		{
			EffectsVM?.RemoveEffectCommand?.Invoke(new EffectCommandParameters(targetEffectParams));
		}
	}

	private void EffectsList_RequestBringIntoView(object? sender, RequestBringIntoViewEventArgs e)
	{
		e.Handled = true;
	}

	private void RemoveAllEffects(object? sender, RoutedEventArgs e)
	{
		EffectsVM?.RemoveAllEffectsCommand?.Invoke();
	}

	private void SaveToSelectedEffectsPreset(object? sender, RoutedEventArgs e)
	{
		if (EffectsVM?.MediaEffects != null)
		{
			EffectsVM?.SaveEffectsPresetCommand?.Invoke();
		}
	}

	private void EffectsMenu_Opened(object? sender, RoutedEventArgs e)
	{
		if (!(sender is ContextMenu depObj))
		{
			return;
		}
		((DependencyObject)(object)depObj).FindVisualChildren<MenuItem>()?.Where(delegate(MenuItem m)
		{
			bool valueOrDefault = EffectsVM?.MediaEffects?.Select((EffectParameters i) => i.EffectDescription).Contains<EffectDescription>(m.DataContext as EffectDescription) == true;
			if (!valueOrDefault)
			{
				m.IsEnabled = true;
			}
			return valueOrDefault;
		}).ForEach(delegate(MenuItem m)
		{
			m.IsEnabled = false;
		});
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
