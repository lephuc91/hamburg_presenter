using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Markup;
using Pro.Text;
using Pro.UI.Components;
using Pro.UI.Utility;
using ProPresenter.DO.Analytics;
using ProPresenter.DO.Cues;
using ProPresenter.DO.OutputConfiguration;
using ProPresenter.UI.SlideEditor.Inspectors;
using ProPresenter.UI.Stage;
using ProPresenter.UI.ViewModels;

namespace ProPresenter.UI;

public partial class MenuLayout : UserControl, IComponentConnector, IStyleConnector
{
	public static readonly DependencyProperty ScreenLayoutMapProperty = DependencyProperty.Register("ScreenLayoutMap", typeof(StageScreenLayoutMap), typeof(MenuLayout), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnScreenMapChanged)));

	public static readonly DependencyProperty ShowHoWProperty = DependencyProperty.Register("ShowHoW", typeof(bool), typeof(MenuLayout));

	private static readonly DependencyProperty EditorCommandTargetProperty = DependencyProperty.Register("EditorCommandTarget", typeof(object), typeof(MenuLayout));

	private static readonly DependencyProperty CapitalizationTypeProperty = DependencyProperty.Register("CapitalizationType", typeof(CapitalizationType), typeof(MenuLayout));

	private static readonly DependencyProperty LigaturesEnabledProperty = DependencyProperty.Register("LigaturesEnabled", typeof(bool), typeof(MenuLayout));

	private static readonly DependencyProperty ParagraphAlignmentProperty = DependencyProperty.Register("ParagraphAlignment", typeof(ParagraphAlignment), typeof(MenuLayout));

	private static readonly DependencyProperty DocumentAlignmentProperty = DependencyProperty.Register("DocumentAlignment", typeof(DocumentAlignment), typeof(MenuLayout));

	public static readonly DependencyProperty StageScreenToLayoutMapProperty = DependencyProperty.Register("StageScreenToLayoutMap", typeof(IEnumerable<KeyValuePair<ScreenArrangementBase, SlideCue>>), typeof(MenuLayout));

	public static readonly DependencyProperty SetStageCueCommandProperty = DependencyProperty.Register("SetStageCueCommand", typeof(ICommand<StageCueAssignmentParameter>), typeof(MenuLayout));

	public static readonly DependencyProperty MakeSelectedLookLiveCommandProperty = DependencyProperty.Register("MakeSelectedLookLiveCommand", typeof(ICommand), typeof(MenuLayout));

	public StageScreenLayoutMap ScreenLayoutMap
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

	private IMenuLayoutVM MenuLayoutVM => (base.DataContext as IMenuLayoutVM) ?? throw new InvalidOperationException();

	public bool ShowHoW
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowHoWProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowHoWProperty, (object)value);
		}
	}

	private object? EditorCommandTarget
	{
		get
		{
			return ((DependencyObject)this).GetValue(EditorCommandTargetProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(EditorCommandTargetProperty, value);
		}
	}

	private bool LigaturesEnabled
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(LigaturesEnabledProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(LigaturesEnabledProperty, (object)value);
		}
	}

	private CapitalizationType CapitalizationType
	{
		get
		{
			return (CapitalizationType)((DependencyObject)this).GetValue(CapitalizationTypeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CapitalizationTypeProperty, (object)value);
		}
	}

	private ParagraphAlignment ParagraphAlignment
	{
		get
		{
			return (ParagraphAlignment)((DependencyObject)this).GetValue(ParagraphAlignmentProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ParagraphAlignmentProperty, (object)value);
		}
	}

	private DocumentAlignment DocumentAlignment
	{
		get
		{
			return (DocumentAlignment)((DependencyObject)this).GetValue(DocumentAlignmentProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DocumentAlignmentProperty, (object)value);
		}
	}

	public IEnumerable<KeyValuePair<ScreenArrangementBase, SlideCue>>? StageScreenToLayoutMap
	{
		get
		{
			return (IEnumerable<KeyValuePair<ScreenArrangementBase, SlideCue>>)((DependencyObject)this).GetValue(StageScreenToLayoutMapProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(StageScreenToLayoutMapProperty, (object)value);
		}
	}

	public ICommand<StageCueAssignmentParameter>? SetStageCueCommand
	{
		get
		{
			return (ICommand<StageCueAssignmentParameter>)((DependencyObject)this).GetValue(SetStageCueCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SetStageCueCommandProperty, (object)value);
		}
	}

	public ICommand? MakeSelectedLookLiveCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(MakeSelectedLookLiveCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MakeSelectedLookLiveCommandProperty, (object)value);
		}
	}

	private static void OnScreenMapChanged(DependencyObject callerObject, DependencyPropertyChangedEventArgs e)
	{
		(callerObject as MenuLayout)?.ScreenMapChanged(((DependencyPropertyChangedEventArgs)(ref e)).OldValue as StageScreenLayoutMap, ((DependencyPropertyChangedEventArgs)(ref e)).NewValue as StageScreenLayoutMap);
	}

	public MenuLayout()
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Expected O, but got Unknown
		InitializeComponent();
		base.DataContextChanged += new DependencyPropertyChangedEventHandler(MenuLayout_DataContextChanged);
	}

	private void MenuLayout_DataContextChanged(object? sender, DependencyPropertyChangedEventArgs e)
	{
		if (((DependencyPropertyChangedEventArgs)(ref e)).OldValue is IMenuLayoutVM menuLayoutVM)
		{
			menuLayoutVM.PropertyChanged -= MenuLayoutVM_PropertyChanged;
		}
		if (((DependencyPropertyChangedEventArgs)(ref e)).NewValue is IMenuLayoutVM menuLayoutVM2)
		{
			menuLayoutVM2.PropertyChanged += MenuLayoutVM_PropertyChanged;
		}
	}

	private void MenuLayoutVM_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "EditorCommandTarget")
		{
			((DependencyObject)this).SetCurrentValue(EditorCommandTargetProperty, (object)CommandTargets.FindTarget(MenuLayoutVM.EditorCommandTarget));
		}
		if (e.PropertyName == "EditorTextCommandTarget")
		{
			TextInspector source = CommandTargets.FindTarget(MenuLayoutVM.EditorTextCommandTarget) as TextInspector;
			SetBinding(LigaturesEnabledProperty, new Binding("LigaturesEnabled")
			{
				Source = source
			});
			SetBinding(CapitalizationTypeProperty, new Binding("Capitalization")
			{
				Source = source
			});
			SetBinding(ParagraphAlignmentProperty, new Binding("ParagraphAlignment")
			{
				Source = source
			});
			SetBinding(DocumentAlignmentProperty, new Binding("DocumentAlignment")
			{
				Source = source
			});
		}
	}

	private void SelectStageDisplayCueClick(object? sender, RoutedEventArgs e)
	{
		SlideCue cue = (sender as MenuItem)?.DataContext as SlideCue;
		StageCueAssignmentParameter parameter = new StageCueAssignmentParameter((sender as MenuItem)?.CommandParameter as ScreenArrangementBase, cue);
		SetStageCueCommand?.Invoke(parameter);
	}

	private void ScreenMapChanged(StageScreenLayoutMap? oldMap, StageScreenLayoutMap? newMap)
	{
		if (oldMap != null)
		{
			oldMap.DataModified -= UpdateStageScreenMenuItems;
		}
		if (newMap != null)
		{
			newMap.DataModified += UpdateStageScreenMenuItems;
		}
		UpdateStageScreenMenuItems();
	}

	private void UpdateStageScreenMenuItems()
	{
		StageScreenToLayoutMap = ScreenLayoutMap.ToArray();
	}

	private void OnOpenQuickSearchClick(object? sender, RoutedEventArgs e)
	{
		QuickSearchShownEvent.Publish(QuickSearchShownSource.ApplicationMenu);
	}

	private void OnNewLibraryClick(object? sender, RoutedEventArgs e)
	{
		LibraryCreateEvent.Publish(LibraryCreateSource.ApplicationMenu);
	}

	private void OnNewGeneralPlaylistClick(object? sender, RoutedEventArgs e)
	{
		PlaylistCreateEvent.Publish(PlaylistCreateSource.ApplicationMenu, PlaylistCreateType.General);
	}

	private void OnNewPresentationClick(object? sender, RoutedEventArgs e)
	{
		PresentationCreateEvent.Publish(PresentationCreateSource.ApplicationMenu);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
