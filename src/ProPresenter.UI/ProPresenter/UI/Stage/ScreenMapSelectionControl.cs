using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Pro.UI.Components;
using Pro.UI.Utility;
using ProPresenter.DO.Cues;
using ProPresenter.DO.OutputConfiguration;

namespace ProPresenter.UI.Stage;

public partial class ScreenMapSelectionControl : UserControl, IComponentConnector, IStyleConnector
{
	private bool _ignoreChange;

	public static readonly DependencyProperty ScreenLayoutMapProperty = DependencyProperty.Register("ScreenLayoutMap", typeof(StageScreenLayoutMap), typeof(ScreenMapSelectionControl), new PropertyMetadata((object)null, new PropertyChangedCallback(OnScreenLayoutMapChanged)));

	public static readonly DependencyProperty StageLayoutsProperty = DependencyProperty.Register("StageLayouts", typeof(IEnumerable<SlideCue>), typeof(ScreenMapSelectionControl));

	private static readonly DependencyProperty SelectedLayoutProperty = DependencyProperty.Register("SelectedLayout", typeof(SlideCue), typeof(ScreenMapSelectionControl));

	public static readonly DependencyProperty StageScreenProperty = DependencyProperty.Register("StageScreen", typeof(ScreenArrangementBase), typeof(ScreenMapSelectionControl), new PropertyMetadata((object)null, new PropertyChangedCallback(OnStageScreenChanged)));

	public static readonly DependencyProperty AddBlankItemProperty = DependencyProperty.Register("AddBlankItem", typeof(bool), typeof(ScreenMapSelectionControl));

	public static readonly DependencyProperty ChangeLayoutCommandProperty = DependencyProperty.Register("ChangeLayoutCommand", typeof(ICommand<StageCueAssignmentParameter>), typeof(ScreenMapSelectionControl));

	public static readonly DependencyProperty EditLayoutsCommandProperty = DependencyProperty.Register("EditLayoutsCommand", typeof(ICommand<ScreenArrangementBase>), typeof(ScreenMapSelectionControl));

	public StageScreenLayoutMap? ScreenLayoutMap
	{
		get
		{
			return (StageScreenLayoutMap)((DependencyObject)this).GetValue(ScreenLayoutMapProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ScreenLayoutMapProperty, (object)value);
		}
	}

	public IEnumerable<SlideCue> StageLayouts
	{
		get
		{
			return (IEnumerable<SlideCue>)((DependencyObject)this).GetValue(StageLayoutsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(StageLayoutsProperty, (object)value);
		}
	}

	private SlideCue? SelectedLayout
	{
		get
		{
			return (SlideCue)((DependencyObject)this).GetValue(SelectedLayoutProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedLayoutProperty, (object)value);
		}
	}

	public ScreenArrangementBase? StageScreen
	{
		get
		{
			return (ScreenArrangementBase)((DependencyObject)this).GetValue(StageScreenProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(StageScreenProperty, (object)value);
		}
	}

	public bool AddBlankItem
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(AddBlankItemProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AddBlankItemProperty, (object)value);
		}
	}

	public ICommand<StageCueAssignmentParameter>? ChangeLayoutCommand
	{
		get
		{
			return (ICommand<StageCueAssignmentParameter>)((DependencyObject)this).GetValue(ChangeLayoutCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ChangeLayoutCommandProperty, (object)value);
		}
	}

	public ICommand<ScreenArrangementBase> EditLayoutsCommand
	{
		get
		{
			return (ICommand<ScreenArrangementBase>)((DependencyObject)this).GetValue(EditLayoutsCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(EditLayoutsCommandProperty, (object)value);
		}
	}

	public ScreenMapSelectionControl()
	{
		InitializeComponent();
		base.Unloaded += ScreenMapSelectionControl_Unloaded;
	}

	private static void OnScreenLayoutMapChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
	{
		if (dependencyObject is ScreenMapSelectionControl screenMapSelectionControl)
		{
			screenMapSelectionControl.OnScreenLayoutMapChanged((StageScreenLayoutMap)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (StageScreenLayoutMap)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	private static void OnStageScreenChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
	{
		if (dependencyObject is ScreenMapSelectionControl screenMapSelectionControl)
		{
			screenMapSelectionControl.UpdateSelectedLayout();
		}
	}

	private void OnScreenLayoutMapChanged(StageScreenLayoutMap? oldValue, StageScreenLayoutMap? newValue)
	{
		if (oldValue != null)
		{
			oldValue.DataModified -= ScreenLayoutMap_DataModified;
		}
		if (newValue != null)
		{
			newValue.DataModified += ScreenLayoutMap_DataModified;
		}
		UpdateSelectedLayout();
	}

	private void ScreenMapSelectionControl_Unloaded(object sender, RoutedEventArgs e)
	{
		if (ScreenLayoutMap != null)
		{
			ScreenLayoutMap.DataModified -= ScreenLayoutMap_DataModified;
		}
	}

	private void UpdateSelectedLayout()
	{
		if (ScreenLayoutMap != null && StageScreen != null && ScreenLayoutMap.TryGetValue(StageScreen, out SlideCue value) && SelectedLayout != value)
		{
			((DependencyObject)this).SetCurrentValue(SelectedLayoutProperty, (object)value);
		}
	}

	private void ScreenLayoutMap_DataModified()
	{
		if (!_ignoreChange)
		{
			UpdateSelectedLayout();
		}
	}

	private void Select_Layout(object? sender, RoutedEventArgs e)
	{
		if (sender is MenuItem { DataContext: SlideCue dataContext })
		{
			_ignoreChange = true;
			ChangeLayoutCommand?.Invoke(new StageCueAssignmentParameter(StageScreen, dataContext));
			_ignoreChange = false;
		}
	}

	private void Clear_SelectedLayout(object? sender, RoutedEventArgs e)
	{
		ChangeLayoutCommand?.Invoke(new StageCueAssignmentParameter(StageScreen, null));
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
