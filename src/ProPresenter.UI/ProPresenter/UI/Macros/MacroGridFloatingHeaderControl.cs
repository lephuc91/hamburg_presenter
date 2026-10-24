using System.Windows;
using Pro.Common.Mathematics;
using ProPresenter.UI.FloatingHeaders;
using ProPresenter.UI.ViewModels.Macros;

namespace ProPresenter.UI.Macros;

public class MacroGridFloatingHeaderControl : FlatFloatingHeaderControl
{
	public static readonly DependencyProperty PanelProperty = DependencyProperty.Register("Panel", typeof(MacroGridPanel), typeof(MacroGridFloatingHeaderControl));

	public MacroGridPanel Panel
	{
		get
		{
			return (MacroGridPanel)((DependencyObject)this).GetValue(PanelProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(PanelProperty, (object)value);
		}
	}

	public MacroGridFloatingHeaderControl()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		base.DataContextChanged += new DependencyPropertyChangedEventHandler(MacroGridFloatingHeaderControl_DataContextChanged);
	}

	private void MacroGridFloatingHeaderControl_DataContextChanged(object? sender, DependencyPropertyChangedEventArgs e)
	{
		if (((DependencyPropertyChangedEventArgs)(ref e)).OldValue is IMacroGroupVM macroGroupVM)
		{
			macroGroupVM.NewMacroAdded -= OnNewMacroAdded;
		}
		if (((DependencyPropertyChangedEventArgs)(ref e)).NewValue is IMacroGroupVM macroGroupVM2)
		{
			macroGroupVM2.NewMacroAdded += OnNewMacroAdded;
		}
	}

	private void OnNewMacroAdded(IMacroItemVM item)
	{
		if (item != null)
		{
			UpdateLayout();
			Rect<double> thumbnailBounds = Panel.GetThumbnailBounds(item);
			CalculateOffsets(Panel, thumbnailBounds, out var topOffset, out var heightOffset);
			ScrollIntoView(Panel, topOffset, heightOffset);
			Panel.FocusAndRenameItem(item);
		}
	}
}
