using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;
using Pro.Common.Mathematics;
using Pro.DO.Transitions;
using Pro.DO.Transitions.Favorite;
using Pro.DO.Transitions.Recent;
using Pro.DO.Transitions.Standard;
using Pro.UI.Utility;
using ProPresenter.Controller.Outputs;
using ProPresenter.DO.Analytics.Events.TrackedEvents;

namespace ProPresenter.UI.Transitions;

public partial class SelectorControl : UserControl, IComponentConnector, IStyleConnector
{
	private readonly List<TransitionBase> _categorizedList = new List<TransitionBase>();

	private bool _ignoreTransitionChange;

	private DateTime _becameVisibleTime;

	public static readonly DependencyProperty OutputControllerProperty = DependencyProperty.Register("OutputController", typeof(ssAPIOutput), typeof(SelectorControl));

	public static readonly DependencyProperty TransitionHandlerProperty = DependencyProperty.Register("TransitionHandler", typeof(TransitionHandler), typeof(SelectorControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnTransitionHandlerPropertyChanged)));

	public static readonly DependencyProperty SelectedFavoriteProperty = DependencyProperty.Register("SelectedFavorite", typeof(FavoriteTransition), typeof(SelectorControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnSelectedTransitionPropertyChanged)));

	public static readonly DependencyProperty SelectedRecentProperty = DependencyProperty.Register("SelectedRecent", typeof(RecentTransition), typeof(SelectorControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnSelectedTransitionPropertyChanged)));

	public static readonly DependencyProperty SelectedStandardProperty = DependencyProperty.Register("SelectedStandard", typeof(StandardTransition), typeof(SelectorControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnSelectedTransitionPropertyChanged)));

	public static readonly DependencyProperty SelectedCategorizedProperty = DependencyProperty.Register("SelectedCategorized", typeof(TransitionBase), typeof(SelectorControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnSelectedTransitionPropertyChanged)));

	public static readonly DependencyProperty FavoriteTransitionsProperty = DependencyProperty.Register("FavoriteTransitions", typeof(ICollectionView), typeof(SelectorControl));

	public static readonly DependencyProperty RecentTransitionsProperty = DependencyProperty.Register("RecentTransitions", typeof(ICollectionView), typeof(SelectorControl));

	public static readonly DependencyProperty StandardTransitionsProperty = DependencyProperty.Register("StandardTransitions", typeof(ICollectionView), typeof(SelectorControl));

	public static readonly DependencyProperty SearchTextProperty = DependencyProperty.Register("SearchText", typeof(string), typeof(SelectorControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnSearchTextPropertyChanged)));

	public static readonly DependencyProperty IsSearchingProperty = DependencyProperty.Register("IsSearching", typeof(bool), typeof(SelectorControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false));

	public static readonly DependencyProperty CategoryProperty = DependencyProperty.Register("Category", typeof(TransitionCategory), typeof(SelectorControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)TransitionCategory.All, new PropertyChangedCallback(OnCategoryPropertyChanged)));

	public static readonly DependencyProperty IsHeaderVisibleProperty = DependencyProperty.Register("IsHeaderVisible", typeof(bool), typeof(SelectorControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));

	public static readonly DependencyProperty IsCategorizedListVisibleProperty = DependencyProperty.Register("IsCategorizedListVisible", typeof(bool), typeof(SelectorControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false));

	public static readonly DependencyProperty IsGlobalAllowedProperty = DependencyProperty.Register("IsGlobalAllowed", typeof(bool), typeof(SelectorControl));

	public ssAPIOutput? OutputController
	{
		get
		{
			return (ssAPIOutput)((DependencyObject)this).GetValue(OutputControllerProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(OutputControllerProperty, (object)value);
		}
	}

	public TransitionHandler? TransitionHandler
	{
		get
		{
			return (TransitionHandler)((DependencyObject)this).GetValue(TransitionHandlerProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TransitionHandlerProperty, (object)value);
		}
	}

	private FavoriteTransition? SelectedFavorite
	{
		get
		{
			return (FavoriteTransition)((DependencyObject)this).GetValue(SelectedFavoriteProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedFavoriteProperty, (object)value);
		}
	}

	private RecentTransition? SelectedRecent
	{
		get
		{
			return (RecentTransition)((DependencyObject)this).GetValue(SelectedRecentProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedRecentProperty, (object)value);
		}
	}

	private StandardTransition? SelectedStandard
	{
		get
		{
			return (StandardTransition)((DependencyObject)this).GetValue(SelectedStandardProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedStandardProperty, (object)value);
		}
	}

	private TransitionBase? SelectedCategorized
	{
		get
		{
			return (TransitionBase)((DependencyObject)this).GetValue(SelectedCategorizedProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedCategorizedProperty, (object)value);
		}
	}

	public ICollectionView? FavoriteTransitions
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected O, but got Unknown
			return (ICollectionView)((DependencyObject)this).GetValue(FavoriteTransitionsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(FavoriteTransitionsProperty, (object)value);
		}
	}

	public ICollectionView? RecentTransitions
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected O, but got Unknown
			return (ICollectionView)((DependencyObject)this).GetValue(RecentTransitionsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(RecentTransitionsProperty, (object)value);
		}
	}

	public ICollectionView? StandardTransitions
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected O, but got Unknown
			return (ICollectionView)((DependencyObject)this).GetValue(StandardTransitionsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(StandardTransitionsProperty, (object)value);
		}
	}

	public string SearchText
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(SearchTextProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SearchTextProperty, (object)value);
		}
	}

	public bool IsSearching
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsSearchingProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsSearchingProperty, (object)value);
		}
	}

	public TransitionCategory Category
	{
		get
		{
			return (TransitionCategory)((DependencyObject)this).GetValue(CategoryProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CategoryProperty, (object)value);
		}
	}

	public bool IsHeaderVisible
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsHeaderVisibleProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsHeaderVisibleProperty, (object)value);
		}
	}

	public bool IsCategorizedListVisible
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsCategorizedListVisibleProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsCategorizedListVisibleProperty, (object)value);
		}
	}

	public bool IsGlobalAllowed
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsGlobalAllowedProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsGlobalAllowedProperty, (object)value);
		}
	}

	private IEnumerable<TransitionListBox> TransitionListBoxes => new List<TransitionListBox> { StandardListBox, FavoriteListBox, RecentListBox };

	private static void OnTransitionHandlerPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		(d as SelectorControl)?.OnTransitionHandlerChanged((TransitionHandler)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (TransitionHandler)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	private static void OnSelectedTransitionPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		(d as SelectorControl)?.OnSelectedTransitionChanged((TransitionBase)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	private static void OnSearchTextPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		(d as SelectorControl)?.OnSearchTextChanged();
	}

	private static void OnCategoryPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		(d as SelectorControl)?.OnCategoryChanged((TransitionCategory)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	public SelectorControl()
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		InitializeComponent();
		LoadCategoryFilterItems();
		base.Loaded += SelectorControl_Loaded;
		base.IsVisibleChanged += new DependencyPropertyChangedEventHandler(SelectorControl_IsVisibleChanged);
	}

	private void LoadCategoryFilterItems()
	{
		TransitionCategory[] values = Enum.GetValues<TransitionCategory>();
		foreach (TransitionCategory transitionCategory in values)
		{
			if (transitionCategory == TransitionCategory.Wipes)
			{
				CategoryComboBox.Items.Add(new Separator());
				CategoryComboBox.Items.Add(transitionCategory);
			}
			else
			{
				CategoryComboBox.Items.Add(transitionCategory);
			}
		}
	}

	private void SelectorControl_Loaded(object? sender, RoutedEventArgs e)
	{
		UpdateSelectedTransition();
		ScrollTransitionIntoView(TransitionHandler?.ActiveTransition);
	}

	private void SelectorControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
	{
		object newValue = ((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
		if (newValue is bool)
		{
			if ((bool)newValue)
			{
				_becameVisibleTime = DateTime.Now;
			}
			else if (_becameVisibleTime != default(DateTime))
			{
				TransitionUsedEvent.Publish(DateTime.Now.Subtract(_becameVisibleTime));
			}
		}
	}

	private void OnTransitionHandlerChanged(TransitionHandler oldTransitionHandler, TransitionHandler newTransitionHandler)
	{
		if (oldTransitionHandler != null)
		{
			oldTransitionHandler.PropertyChanged -= TransitionHandler_PropertyChanged;
			FavoriteTransitions = null;
			RecentTransitions = null;
			StandardTransitions = null;
		}
		if (newTransitionHandler != null)
		{
			newTransitionHandler.PropertyChanged += TransitionHandler_PropertyChanged;
			FavoriteTransitions = new CollectionViewSource
			{
				Source = newTransitionHandler.Set.FavoriteTransitions
			}.View;
			RecentTransitions = new CollectionViewSource
			{
				Source = newTransitionHandler.Set.RecentTransitions
			}.View;
			StandardTransitions = new CollectionViewSource
			{
				Source = newTransitionHandler.Set.StandardTransitions
			}.View;
			FavoriteTransitions.Filter = (object i) => FilterTransition((TransitionBase)i);
			RecentTransitions.Filter = (object i) => FilterTransition((TransitionBase)i);
			StandardTransitions.Filter = (object i) => FilterTransition((TransitionBase)i);
		}
	}

	private void TransitionHandler_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "ActiveTransition")
		{
			if (IsCategorizedListVisible)
			{
				RefreshCategorizedItems(Category);
			}
			UpdateSelectedTransition();
			ScrollTransitionIntoView(TransitionHandler.ActiveTransition);
		}
	}

	private void OnSelectedTransitionChanged(TransitionBase transition)
	{
		if (TransitionHandler != null && transition != null && !_ignoreTransitionChange)
		{
			TransitionHandler.ActivateTransition(transition);
		}
		if (TransitionHandler != null && TransitionHandler.IsActive)
		{
			ScrollTransitionIntoView(TransitionHandler.ActiveTransition);
		}
	}

	private void UpdateSelectedTransition()
	{
		_ignoreTransitionChange = true;
		((DependencyObject)this).SetCurrentValue(SelectedFavoriteProperty, (object)(TransitionHandler?.ActiveTransition as FavoriteTransition));
		((DependencyObject)this).SetCurrentValue(SelectedRecentProperty, (object)(TransitionHandler?.ActiveTransition as RecentTransition));
		((DependencyObject)this).SetCurrentValue(SelectedStandardProperty, (object)(TransitionHandler?.ActiveTransition as StandardTransition));
		((DependencyObject)this).SetCurrentValue(SelectedCategorizedProperty, (object)TransitionHandler?.ActiveTransition);
		_ignoreTransitionChange = false;
	}

	private void OnSearchTextChanged()
	{
		((DependencyObject)this).SetCurrentValue(IsSearchingProperty, (object)(!string.IsNullOrWhiteSpace(SearchText)));
		if (TransitionHandler != null)
		{
			ICollectionView? favoriteTransitions = FavoriteTransitions;
			if (favoriteTransitions != null)
			{
				favoriteTransitions.Refresh();
			}
			ICollectionView? standardTransitions = StandardTransitions;
			if (standardTransitions != null)
			{
				standardTransitions.Refresh();
			}
			ICollectionView? recentTransitions = RecentTransitions;
			if (recentTransitions != null)
			{
				recentTransitions.Refresh();
			}
			RefreshCategorizedItems(Category);
			TransitionSearchTextBox.Focus();
		}
	}

	private bool FilterTransition(TransitionBase transition)
	{
		if (string.IsNullOrWhiteSpace(SearchText))
		{
			return true;
		}
		return transition.Preset.Name.ToLowerInvariant().Contains(SearchText.ToLowerInvariant());
	}

	private void OnCategoryChanged(TransitionCategory category)
	{
		switch (category)
		{
		case TransitionCategory.All:
			FavoriteListBox.Visibility = Visibility.Visible;
			RecentListBox.Visibility = Visibility.Visible;
			StandardListBox.Visibility = Visibility.Visible;
			IsHeaderVisible = true;
			IsCategorizedListVisible = false;
			break;
		case TransitionCategory.Favorite:
			FavoriteListBox.Visibility = Visibility.Visible;
			RecentListBox.Visibility = Visibility.Collapsed;
			StandardListBox.Visibility = Visibility.Collapsed;
			IsHeaderVisible = false;
			IsCategorizedListVisible = false;
			break;
		case TransitionCategory.Recent:
			FavoriteListBox.Visibility = Visibility.Collapsed;
			RecentListBox.Visibility = Visibility.Visible;
			StandardListBox.Visibility = Visibility.Collapsed;
			IsHeaderVisible = false;
			IsCategorizedListVisible = false;
			break;
		case TransitionCategory.Wipes:
		case TransitionCategory.Color:
		case TransitionCategory.Objects:
		case TransitionCategory.None:
		case TransitionCategory.Blurs:
		case TransitionCategory.Dissolves:
		case TransitionCategory.Movements:
			IsCategorizedListVisible = true;
			RefreshCategorizedItems(category);
			break;
		default:
			throw new NotSupportedException("Unknown Transition Category");
		}
	}

	private void RefreshCategorizedItems(TransitionCategory category)
	{
		_categorizedList.Clear();
		CategorizedTransitions.ItemsSource = null;
		ICollectionView? favoriteTransitions = FavoriteTransitions;
		IEnumerable<FavoriteTransition> enumerable = (((favoriteTransitions != null) ? favoriteTransitions.SourceCollection : null) as FavoriteTransitionCollection)?.Where((FavoriteTransition t) => t.Preset.Parameters?.TransitionDescription?.Category == category.ToString());
		ICollectionView? standardTransitions = StandardTransitions;
		IEnumerable<StandardTransition> enumerable2 = (((standardTransitions != null) ? standardTransitions.SourceCollection : null) as StandardTransitionCollection)?.Where((StandardTransition t) => t.Preset.Parameters?.TransitionDescription?.Category == category.ToString());
		if (!string.IsNullOrWhiteSpace(SearchText))
		{
			enumerable = enumerable?.Where((FavoriteTransition t) => t.Preset.Name.ToLowerInvariant().Contains(SearchText.ToLowerInvariant())).ToList();
			enumerable2 = enumerable2?.Where((StandardTransition t) => t.Preset.Name.ToLowerInvariant().Contains(SearchText.ToLowerInvariant())).ToList();
		}
		if (enumerable != null)
		{
			_categorizedList.AddRange(enumerable);
		}
		if (enumerable2 != null)
		{
			_categorizedList.AddRange(enumerable2);
		}
		if (_categorizedList.Any())
		{
			CategorizedTransitions.ItemsSource = _categorizedList;
			CategorizedTransitions.ItemsPanel = FindResource("ListBoxWrapTemplate") as ItemsPanelTemplate;
		}
		else
		{
			CategorizedTransitions.ItemsSource = FindResource("defaultEmptyItemValue") as IEnumerable<string>;
			CategorizedTransitions.ItemsPanel = FindResource("ListBoxStackPanelTemplate") as ItemsPanelTemplate;
			CategorizedTransitions.SelectedItem = null;
		}
		UpdateSelectedTransition();
	}

	private void ScrollTransitionIntoView(TransitionBase? transition)
	{
		if (transition != null)
		{
			TransitionListBox listBoxItemFromTransition = GetListBoxItemFromTransition(transition);
			ListBoxItem listBoxItem = ((DependencyObject)(object)listBoxItemFromTransition)?.FindVisualChild((ListBoxItem l) => ((l.DataContext as TransitionBase)?.Preset.ID ?? Guid.Empty) == transition.Preset.ID);
			if (listBoxItemFromTransition != null && listBoxItem != null)
			{
				ScrollItemIntoView(listBoxItem, listBoxItemFromTransition);
			}
		}
	}

	private void ScrollItemIntoView(ListBoxItem listBoxItem, ListBox listBox)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		TransitionsFloatingHeaderControl transitionFloatingHeader = TransitionFloatingHeader;
		Point val = listBoxItem.TranslatePoint(Vector2<double>.Zero, listBox);
		transitionFloatingHeader.ScrollIntoView(listBox, ((Point)(ref val)).Y, listBoxItem.ActualHeight);
	}

	private TransitionListBox? GetListBoxItemFromTransition(TransitionBase transition)
	{
		foreach (TransitionListBox transitionListBox in TransitionListBoxes)
		{
			if (transitionListBox.Items.OfType<TransitionBase>().Any((TransitionBase t) => t.Preset.ID == transition.Preset.ID))
			{
				return transitionListBox;
			}
		}
		return null;
	}

	private void ClearRecentTransitions(object? sender, RoutedEventArgs e)
	{
		TransitionHandler?.ClearRecentList();
	}

	private void GlobalTransitionOn(object? sender, RoutedEventArgs e)
	{
		TransitionHandler?.RemoveTransition();
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
