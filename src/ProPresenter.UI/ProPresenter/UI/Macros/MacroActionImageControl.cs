using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Pro.UI.DependencyInjection;
using ProPresenter.DO;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Macros;

namespace ProPresenter.UI.Macros;

public partial class MacroActionImageControl : UserControl, IComponentConnector
{
	private readonly IProPresenterResourceService _resources;

	private static readonly DependencyProperty ActionProperty = DependencyProperty.Register("Action", typeof(MacroAction), typeof(MacroActionImageControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, (PropertyChangedCallback)delegate(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		if (d is MacroActionImageControl macroActionImageControl)
		{
			macroActionImageControl.OnActionPropertyChanged(((DependencyPropertyChangedEventArgs)(ref e)).OldValue as MacroAction, ((DependencyPropertyChangedEventArgs)(ref e)).NewValue as MacroAction);
		}
	}));

	private static readonly DependencyProperty MacroProperty = DependencyProperty.Register("Macro", typeof(ProPresenterMacro), typeof(MacroActionImageControl));

	public MacroAction Action
	{
		get
		{
			return (MacroAction)((DependencyObject)this).GetValue(ActionProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ActionProperty, (object)value);
		}
	}

	public ProPresenterMacro Macro
	{
		get
		{
			return (ProPresenterMacro)((DependencyObject)this).GetValue(MacroProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MacroProperty, (object)value);
		}
	}

	public MacroActionImageControl()
	{
		_resources = UIServiceProvider.GetService<IProPresenterResourceService>();
		InitializeComponent();
	}

	private void OnActionPropertyChanged(MacroAction? oldMacroAction, MacroAction? newMacroAction)
	{
		TeardownMacroAction(oldMacroAction);
		SetupMacroAction(newMacroAction);
		OnMacroActionChanged();
	}

	private void SetupMacroAction(MacroAction? macroAction)
	{
		if (macroAction != null)
		{
			macroAction.PropertyChanged += MacroAction_PropertyChanged;
		}
	}

	private void TeardownMacroAction(MacroAction? macroAction)
	{
		if (macroAction != null)
		{
			macroAction.PropertyChanged -= MacroAction_PropertyChanged;
		}
	}

	private void OnMacroActionChanged()
	{
		if (Action != null)
		{
			ProPresenterMacro proPresenterMacro = _resources.MacroSource?.FindMacro(Action.MacroID, Action.MacroName, Action.MacroParentCollectionID, Action.MacroParentCollectionName);
			((DependencyObject)this).SetCurrentValue(MacroProperty, (object)proPresenterMacro);
		}
	}

	private void MacroAction_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		switch (e.PropertyName)
		{
		case "MacroID":
		case "MacroName":
		case "MacroParentCollectionID":
		case "MacroParentCollectionName":
			OnMacroActionChanged();
			break;
		}
	}
}
