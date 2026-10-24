using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Pro.DO.Transitions;
using Pro.UI.DependencyInjection;
using ProPresenter.DO;
using ProPresenter.DO.PanelViewSettings;
using ProPresenter.DO.Settings;
using ProPresenter.UI.Transitions;

namespace ProPresenter.UI.PresentationView;

[ContentProperty("CustomContent")]
public partial class ViewerStatusBar : UserControl, IComponentConnector
{
	private bool _ignoreSelectionChanges;

	private IPanelViewSettings? _lastViewSettings;

	public static readonly DependencyProperty FillSliderWidthProperty = DependencyProperty.Register("FillSliderWidth", typeof(int), typeof(ViewerStatusBar), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)100));

	public static readonly DependencyProperty SelectedTransitionProperty = DependencyProperty.Register("SelectedTransition", typeof(TransitionParameters), typeof(ViewerStatusBar), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

	public static readonly DependencyProperty SelectedViewTypeProperty = DependencyProperty.Register("SelectedViewType", typeof(PanelViewType), typeof(ViewerStatusBar), (PropertyMetadata)(object)new FrameworkPropertyMetadata(PanelViewType.Thumbnail, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(SelectedViewTypePropertyChanged)));

	public static readonly DependencyProperty SelectedViewSettingsProperty = DependencyProperty.Register("SelectedViewSettings", typeof(IPanelViewSettings), typeof(ViewerStatusBar), (PropertyMetadata)(object)new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(SelectedViewSettingsPropertyChanged)));

	public static readonly DependencyProperty IsThumbnailViewAvailableProperty = DependencyProperty.Register("IsThumbnailViewAvailable", typeof(bool), typeof(ViewerStatusBar));

	public static readonly DependencyProperty IsThumbnailSettingsAvailableProperty = DependencyProperty.Register("IsThumbnailSettingsAvailable", typeof(bool), typeof(ViewerStatusBar));

	public static readonly DependencyProperty ThumbnailViewSettingsProperty = DependencyProperty.Register("ThumbnailViewSettings", typeof(ThumbnailViewSettings), typeof(ViewerStatusBar), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, new PropertyChangedCallback(AnySettingsPropertyChanged)));

	public static readonly DependencyProperty IsEasyViewAvailableProperty = DependencyProperty.Register("IsEasyViewAvailable", typeof(bool), typeof(ViewerStatusBar));

	public static readonly DependencyProperty IsEasySettingsAvailableProperty = DependencyProperty.Register("IsEasySettingsAvailable", typeof(bool), typeof(ViewerStatusBar));

	public static readonly DependencyProperty EasyViewSettingsProperty = DependencyProperty.Register("EasyViewSettings", typeof(EasyViewSettings), typeof(ViewerStatusBar), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, new PropertyChangedCallback(AnySettingsPropertyChanged)));

	public static readonly DependencyProperty IsListViewAvailableProperty = DependencyProperty.Register("IsListViewAvailable", typeof(bool), typeof(ViewerStatusBar));

	public static readonly DependencyProperty IsListSettingsAvailableProperty = DependencyProperty.Register("IsListSettingsAvailable", typeof(bool), typeof(ViewerStatusBar));

	public static readonly DependencyProperty IsViewOptionPopupAvailableProperty = DependencyProperty.Register("IsViewOptionPopupAvailable", typeof(bool), typeof(ViewerStatusBar));

	public static readonly DependencyProperty ListViewSettingsProperty = DependencyProperty.Register("ListViewSettings", typeof(ListViewSettings), typeof(ViewerStatusBar), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, new PropertyChangedCallback(AnySettingsPropertyChanged)));

	public static readonly DependencyProperty RowCapacityProperty = DependencyProperty.Register("RowCapacity", typeof(int), typeof(ViewerStatusBar), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)4, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

	public static readonly DependencyProperty CustomContentProperty = DependencyProperty.Register("CustomContent", typeof(FrameworkElement), typeof(ViewerStatusBar));

	public static readonly DependencyProperty TransitionDisplayModeProperty = DependencyProperty.Register("TransitionDisplayMode", typeof(SegmentedButton.ButtonDisplayMode), typeof(ViewerStatusBar), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)SegmentedButton.ButtonDisplayMode.Foreground));

	public static readonly DependencyProperty TransitionControlProperty = DependencyProperty.Register("TransitionControl", typeof(ITransitionControl), typeof(ViewerStatusBar), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnTransitionControlPropertyChanged)));

	public static readonly DependencyProperty IsSecondaryTransitionVisibleProperty = DependencyProperty.Register("IsSecondaryTransitionVisible", typeof(bool), typeof(ViewerStatusBar));

	public static readonly DependencyProperty MinRowCapacityProperty = DependencyProperty.Register("MinRowCapacity", typeof(int), typeof(ViewerStatusBar), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)2));

	public static readonly DependencyProperty MaxRowCapacityProperty = DependencyProperty.Register("MaxRowCapacity", typeof(int), typeof(ViewerStatusBar), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)8));

	public static readonly DependencyProperty ForceFlipViewProperty = DependencyProperty.Register("ForceFlipView", typeof(bool), typeof(ViewerStatusBar), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnForceFlipViewChanged)));

	public static readonly DependencyProperty SimplifiedTransitionsButtonsProperty = DependencyProperty.Register("SimplifiedTransitionsButtons", typeof(bool), typeof(ViewerStatusBar));

	public static readonly DependencyProperty CollapseControlWidthProperty = DependencyProperty.Register("CollapseControlWidth", typeof(int), typeof(ViewerStatusBar));

	public TransitionParameters SelectedTransition
	{
		get
		{
			return (TransitionParameters)((DependencyObject)this).GetValue(SelectedTransitionProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedTransitionProperty, (object)value);
		}
	}

	public PanelViewType SelectedViewType
	{
		get
		{
			return (PanelViewType)((DependencyObject)this).GetValue(SelectedViewTypeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedViewTypeProperty, (object)value);
		}
	}

	public IPanelViewSettings? SelectedViewSettings
	{
		get
		{
			return (IPanelViewSettings)((DependencyObject)this).GetValue(SelectedViewSettingsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedViewSettingsProperty, (object)value);
		}
	}

	public bool IsThumbnailViewAvailable
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsThumbnailViewAvailableProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsThumbnailViewAvailableProperty, (object)value);
		}
	}

	public bool IsThumbnailSettingsAvailable
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsThumbnailSettingsAvailableProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsThumbnailSettingsAvailableProperty, (object)value);
		}
	}

	public ThumbnailViewSettings? ThumbnailViewSettings
	{
		get
		{
			return (ThumbnailViewSettings)((DependencyObject)this).GetValue(ThumbnailViewSettingsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ThumbnailViewSettingsProperty, (object)value);
		}
	}

	public bool IsEasyViewAvailable
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsEasyViewAvailableProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsEasyViewAvailableProperty, (object)value);
		}
	}

	public bool IsEasySettingsAvailable
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsEasySettingsAvailableProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsEasySettingsAvailableProperty, (object)value);
		}
	}

	public EasyViewSettings? EasyViewSettings
	{
		get
		{
			return (EasyViewSettings)((DependencyObject)this).GetValue(EasyViewSettingsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(EasyViewSettingsProperty, (object)value);
		}
	}

	public bool IsListViewAvailable
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsListViewAvailableProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsListViewAvailableProperty, (object)value);
		}
	}

	public bool IsListSettingsAvailable
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsListSettingsAvailableProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsListSettingsAvailableProperty, (object)value);
		}
	}

	public bool IsViewOptionPopupAvailable
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsViewOptionPopupAvailableProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsViewOptionPopupAvailableProperty, (object)value);
		}
	}

	public ListViewSettings ListViewSettings
	{
		get
		{
			return (ListViewSettings)((DependencyObject)this).GetValue(ListViewSettingsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ListViewSettingsProperty, (object)value);
		}
	}

	public int RowCapacity
	{
		get
		{
			return (int)((DependencyObject)this).GetValue(RowCapacityProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(RowCapacityProperty, (object)value);
		}
	}

	public FrameworkElement CustomContent
	{
		get
		{
			return (FrameworkElement)((DependencyObject)this).GetValue(CustomContentProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CustomContentProperty, (object)value);
		}
	}

	public SegmentedButton.ButtonDisplayMode TransitionDisplayMode
	{
		get
		{
			return (SegmentedButton.ButtonDisplayMode)((DependencyObject)this).GetValue(TransitionDisplayModeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TransitionDisplayModeProperty, (object)value);
		}
	}

	public ITransitionControl TransitionControl
	{
		get
		{
			return (ITransitionControl)((DependencyObject)this).GetValue(TransitionControlProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TransitionControlProperty, (object)value);
		}
	}

	public bool IsSecondaryTransitionVisible
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsSecondaryTransitionVisibleProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsSecondaryTransitionVisibleProperty, (object)value);
		}
	}

	public int MinRowCapacity
	{
		get
		{
			return (int)((DependencyObject)this).GetValue(MinRowCapacityProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MinRowCapacityProperty, (object)value);
		}
	}

	public int MaxRowCapacity
	{
		get
		{
			return (int)((DependencyObject)this).GetValue(MaxRowCapacityProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MaxRowCapacityProperty, (object)value);
		}
	}

	public bool ForceFlipView
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ForceFlipViewProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ForceFlipViewProperty, (object)value);
		}
	}

	public int FillSliderWidth
	{
		get
		{
			return (int)((DependencyObject)this).GetValue(FillSliderWidthProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(FillSliderWidthProperty, (object)value);
		}
	}

	public bool SimplifiedTransitionsButtons
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(SimplifiedTransitionsButtonsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SimplifiedTransitionsButtonsProperty, (object)value);
		}
	}

	public int CollapseControlWidth
	{
		get
		{
			return (int)((DependencyObject)this).GetValue(CollapseControlWidthProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CollapseControlWidthProperty, (object)value);
		}
	}

	private static void SelectedViewTypePropertyChanged(DependencyObject callerObject, DependencyPropertyChangedEventArgs e)
	{
		((ViewerStatusBar)(object)callerObject).UpdateViewSettings();
	}

	private static void SelectedViewSettingsPropertyChanged(DependencyObject callerObject, DependencyPropertyChangedEventArgs e)
	{
		((ViewerStatusBar)(object)callerObject).UpdateViewType();
	}

	private static void AnySettingsPropertyChanged(DependencyObject callerObject, DependencyPropertyChangedEventArgs e)
	{
		((ViewerStatusBar)(object)callerObject).UpdateViewSettings();
	}

	private static void OnTransitionControlPropertyChanged(DependencyObject callerObject, DependencyPropertyChangedEventArgs e)
	{
		((ViewerStatusBar)(object)callerObject).TransitionControlPropertyChanged(((DependencyPropertyChangedEventArgs)(ref e)).OldValue as ITransitionControl, ((DependencyPropertyChangedEventArgs)(ref e)).NewValue as ITransitionControl);
	}

	private static void OnForceFlipViewChanged(DependencyObject callerObject, DependencyPropertyChangedEventArgs e)
	{
		((ViewerStatusBar)(object)callerObject).ForceFlipViewChanged((bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	public ViewerStatusBar()
	{
		InitializeComponent();
		IApp service = UIServiceProvider.GetService<IApp>();
		((DependencyObject)this).SetCurrentValue(ThumbnailViewSettingsProperty, (object)new ThumbnailViewSettings(service));
		((DependencyObject)this).SetCurrentValue(EasyViewSettingsProperty, (object)new EasyViewSettings(service));
		((DependencyObject)this).SetCurrentValue(ListViewSettingsProperty, (object)new ListViewSettings(service));
	}

	private void UpdateViewSettings()
	{
		if (!_ignoreSelectionChanges)
		{
			_ignoreSelectionChanges = true;
			switch (SelectedViewType)
			{
			case PanelViewType.Thumbnail:
				((DependencyObject)this).SetCurrentValue(SelectedViewSettingsProperty, (object)ThumbnailViewSettings);
				break;
			case PanelViewType.EasyView:
				((DependencyObject)this).SetCurrentValue(SelectedViewSettingsProperty, (object)EasyViewSettings);
				break;
			case PanelViewType.List:
				((DependencyObject)this).SetCurrentValue(SelectedViewSettingsProperty, (object)ListViewSettings);
				break;
			}
			_ignoreSelectionChanges = false;
		}
	}

	private void UpdateViewType()
	{
		if (!_ignoreSelectionChanges && SelectedViewSettings != null)
		{
			_ignoreSelectionChanges = true;
			((DependencyObject)this).SetCurrentValue(SelectedViewTypeProperty, (object)SelectedViewSettings.ViewType);
			switch (SelectedViewType)
			{
			case PanelViewType.Thumbnail:
				((DependencyObject)this).SetCurrentValue(ThumbnailViewSettingsProperty, (object)(ThumbnailViewSettings)SelectedViewSettings);
				break;
			case PanelViewType.EasyView:
				((DependencyObject)this).SetCurrentValue(EasyViewSettingsProperty, (object)(EasyViewSettings)SelectedViewSettings);
				break;
			case PanelViewType.List:
				((DependencyObject)this).SetCurrentValue(ListViewSettingsProperty, (object)(ListViewSettings)SelectedViewSettings);
				break;
			}
			_ignoreSelectionChanges = false;
		}
	}

	private void TransitionControlPropertyChanged(ITransitionControl? oldTransitionControl, ITransitionControl? newTransitionControl)
	{
		if (oldTransitionControl != null)
		{
			oldTransitionControl.TransitionHandler.Provider.PropertyChanged -= TransitionControlPropertyChanged;
		}
		if (newTransitionControl != null)
		{
			newTransitionControl.TransitionHandler.Provider.PropertyChanged += TransitionControlPropertyChanged;
		}
	}

	private void TransitionControlPropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "ActiveStoreType")
		{
			MainTransitionButton.RefreshCheckStatus();
			SecondaryTransitionButton.RefreshCheckStatus();
		}
	}

	private void OptionButton_Click(object? sender, RoutedEventArgs e)
	{
		PanelViewType? panelViewType = SelectedViewSettings?.ViewType;
		if (!panelViewType.HasValue)
		{
			return;
		}
		switch (panelViewType.GetValueOrDefault())
		{
		case PanelViewType.Thumbnail:
			if (IsThumbnailSettingsAvailable)
			{
				thumbnailSettingsPopup.IsOpen = true;
			}
			break;
		case PanelViewType.EasyView:
			if (IsEasySettingsAvailable)
			{
				easySettingsPopup.IsOpen = true;
			}
			break;
		case PanelViewType.List:
			if (IsListSettingsAvailable)
			{
				listSettingsPopup.IsOpen = true;
			}
			break;
		}
	}

	private void ForceFlipViewChanged(bool forceFlipView)
	{
		if (SelectedViewSettings == null || SelectedViewSettings.ViewType == PanelViewType.List)
		{
			return;
		}
		if (forceFlipView)
		{
			_ignoreSelectionChanges = true;
			_lastViewSettings = SelectedViewSettings;
			switch (_lastViewSettings.ViewType)
			{
			case PanelViewType.Thumbnail:
				((DependencyObject)this).SetCurrentValue(SelectedViewSettingsProperty, (object)EasyViewSettings);
				break;
			case PanelViewType.EasyView:
				((DependencyObject)this).SetCurrentValue(SelectedViewSettingsProperty, (object)ThumbnailViewSettings);
				break;
			}
			_ignoreSelectionChanges = false;
		}
		else
		{
			((DependencyObject)this).SetCurrentValue(SelectedViewSettingsProperty, (object)_lastViewSettings);
		}
		UpdateViewType();
	}

	public void DoTogglePresentationView()
	{
		if (SelectedViewSettings != null && SelectedViewSettings.ViewType != PanelViewType.List)
		{
			_ignoreSelectionChanges = true;
			switch (SelectedViewSettings.ViewType)
			{
			case PanelViewType.Thumbnail:
				((DependencyObject)this).SetCurrentValue(SelectedViewSettingsProperty, (object)EasyViewSettings);
				break;
			case PanelViewType.EasyView:
				((DependencyObject)this).SetCurrentValue(SelectedViewSettingsProperty, (object)ThumbnailViewSettings);
				break;
			}
			_ignoreSelectionChanges = false;
			UpdateViewType();
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
