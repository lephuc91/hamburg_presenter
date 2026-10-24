using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Markup;
using Pro.UI.Components;
using Pro.UI.Utility;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.Slide.Links;
using ProPresenter.DO.Timer;

namespace ProPresenter.UI.SlideEditor.Inspectors;

public partial class LinkedTextTypeSelector : UserControl, IComponentConnector, IStyleConnector
{
	private sealed class LinkedTextTypeStyleSelector : StyleSelector
	{
		private const string ParentOnlyStyle = "ParentOnlyStyle";

		private const string TimerStyle = "TimerStyle";

		private const string ElementStyle = "ElementStyle";

		private readonly ResourceDictionary _resources;

		public LinkedTextTypeStyleSelector(ResourceDictionary resources)
		{
			_resources = resources;
		}

		public override Style SelectStyle(object item, DependencyObject container)
		{
			if (!(item is LinkedTextType) || (LinkedTextType)item == LinkedTextType.Timer || (LinkedTextType)item == LinkedTextType.Element)
			{
				if (!(item is LinkedTextType) || (LinkedTextType)item != LinkedTextType.Timer)
				{
					if (!(item is LinkedTextType) || (LinkedTextType)item != LinkedTextType.Element)
					{
						return base.SelectStyle(item, container);
					}
					return (Style)_resources["ElementStyle"];
				}
				return (Style)_resources["TimerStyle"];
			}
			return (Style)_resources["ParentOnlyStyle"];
		}
	}

	public static readonly DependencyProperty LinkedTextTypeProperty = DependencyProperty.Register("LinkedTextType", typeof(LinkedTextType), typeof(LinkedTextTypeSelector));

	public static readonly DependencyProperty AvailableLinkedTextTypesProperty = DependencyProperty.Register("AvailableLinkedTextTypes", typeof(CompositeCollection), typeof(LinkedTextTypeSelector));

	public static readonly DependencyProperty AvailableElementsCollectionProperty = DependencyProperty.Register("AvailableElementsCollection", typeof(IEnumerable<ClosedBezierPath>), typeof(LinkedTextTypeSelector));

	public static readonly DependencyProperty AvailableTimerCollectionProperty = DependencyProperty.Register("AvailableTimerCollection", typeof(TimerCollection), typeof(LinkedTextTypeSelector));

	public static readonly DependencyProperty SlideTargetSourceModeProperty = DependencyProperty.Register("SlideTargetSourceMode", typeof(SlideTargetSourceMode), typeof(LinkedTextTypeSelector));

	public static readonly DependencyProperty SlideTextSourceModeProperty = DependencyProperty.Register("SlideTextSourceMode", typeof(SlideTextSourceMode), typeof(LinkedTextTypeSelector));

	public static readonly DependencyProperty TimerTextLinkCommandProperty = DependencyProperty.Register("TimerTextLinkCommand", typeof(ICommand), typeof(LinkedTextTypeSelector));

	public static readonly DependencyProperty ElementTextLinkCommandProperty = DependencyProperty.Register("ElementTextLinkCommand", typeof(ICommand<ClosedBezierPath>), typeof(LinkedTextTypeSelector));

	public static readonly DependencyProperty TextLinkCommandProperty = DependencyProperty.Register("TextLinkCommand", typeof(ICommand<LinkedTextType>), typeof(LinkedTextTypeSelector));

	public static readonly DependencyProperty SelectedTimerTextLinkProperty = DependencyProperty.Register("SelectedTimerTextLink", typeof(TimerLinkedObject), typeof(LinkedTextTypeSelector), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnSelectedTimerTextLinkChanged)));

	public static readonly DependencyProperty SelectedElementTextLinkProperty = DependencyProperty.Register("SelectedElementTextLink", typeof(ElementTextLinkedObject), typeof(LinkedTextTypeSelector), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnSelectedElementTextLinkChanged)));

	private static readonly DependencyProperty SelectedTextLinkTimerNameProperty = DependencyProperty.Register("SelectedTextLinkTimerName", typeof(string), typeof(LinkedTextTypeSelector));

	private static readonly DependencyProperty SelectedTextLinkElementNameProperty = DependencyProperty.Register("SelectedTextLinkElementName", typeof(string), typeof(LinkedTextTypeSelector));

	public LinkedTextType LinkedTextType
	{
		get
		{
			return (LinkedTextType)((DependencyObject)this).GetValue(LinkedTextTypeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(LinkedTextTypeProperty, (object)value);
		}
	}

	public CompositeCollection? AvailableLinkedTextTypes
	{
		get
		{
			return (CompositeCollection)((DependencyObject)this).GetValue(AvailableLinkedTextTypesProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AvailableLinkedTextTypesProperty, (object)value);
		}
	}

	public IEnumerable<ClosedBezierPath>? AvailableElementsCollection
	{
		get
		{
			return (IEnumerable<ClosedBezierPath>)((DependencyObject)this).GetValue(AvailableElementsCollectionProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AvailableElementsCollectionProperty, (object)value);
		}
	}

	public TimerCollection? AvailableTimerCollection
	{
		get
		{
			return (TimerCollection)((DependencyObject)this).GetValue(AvailableTimerCollectionProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AvailableTimerCollectionProperty, (object)value);
		}
	}

	public SlideTargetSourceMode SlideTargetSourceMode
	{
		get
		{
			return (SlideTargetSourceMode)((DependencyObject)this).GetValue(SlideTargetSourceModeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SlideTargetSourceModeProperty, (object)value);
		}
	}

	public SlideTextSourceMode SlideTextSourceMode
	{
		get
		{
			return (SlideTextSourceMode)((DependencyObject)this).GetValue(SlideTextSourceModeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SlideTextSourceModeProperty, (object)value);
		}
	}

	public ICommand<TimerData>? TimerTextLinkCommand
	{
		get
		{
			return (ICommand<TimerData>)((DependencyObject)this).GetValue(TimerTextLinkCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TimerTextLinkCommandProperty, (object)value);
		}
	}

	public ICommand<ClosedBezierPath>? ElementTextLinkCommand
	{
		get
		{
			return (ICommand<ClosedBezierPath>)((DependencyObject)this).GetValue(ElementTextLinkCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ElementTextLinkCommandProperty, (object)value);
		}
	}

	public ICommand<LinkedTextType>? TextLinkCommand
	{
		get
		{
			return (ICommand<LinkedTextType>)((DependencyObject)this).GetValue(TextLinkCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TextLinkCommandProperty, (object)value);
		}
	}

	public TimerLinkedObject? SelectedTimerTextLink
	{
		get
		{
			return (TimerLinkedObject)((DependencyObject)this).GetValue(SelectedTimerTextLinkProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedTimerTextLinkProperty, (object)value);
		}
	}

	public ElementTextLinkedObject? SelectedElementTextLink
	{
		get
		{
			return (ElementTextLinkedObject)((DependencyObject)this).GetValue(SelectedElementTextLinkProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedElementTextLinkProperty, (object)value);
		}
	}

	private string? SelectedTextLinkTimerName
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(SelectedTextLinkTimerNameProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedTextLinkTimerNameProperty, (object)value);
		}
	}

	private string? SelectedTextLinkElementName
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(SelectedTextLinkElementNameProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedTextLinkElementNameProperty, (object)value);
		}
	}

	private static void OnSelectedTimerTextLinkChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((LinkedTextTypeSelector)(object)d).SelectedTimerTextLinkChanged(((DependencyPropertyChangedEventArgs)(ref e)).OldValue as TimerLinkedObject, ((DependencyPropertyChangedEventArgs)(ref e)).NewValue as TimerLinkedObject);
	}

	private static void OnSelectedElementTextLinkChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((LinkedTextTypeSelector)(object)d).SelectedElementTextLinkChanged(((DependencyPropertyChangedEventArgs)(ref e)).OldValue as ElementTextLinkedObject, ((DependencyPropertyChangedEventArgs)(ref e)).NewValue as ElementTextLinkedObject);
	}

	public LinkedTextTypeSelector()
	{
		InitializeComponent();
		LinkedTextTypeSelectorButton.ContextMenu.ItemContainerStyleSelector = new LinkedTextTypeStyleSelector(base.Resources);
	}

	private void MenuItem_Click(object? sender, RoutedEventArgs e)
	{
		object dataContext = ((FrameworkElement)e.OriginalSource).DataContext;
		if (dataContext is TimerData parameter)
		{
			TimerTextLinkCommand?.Invoke(parameter);
		}
		else if (dataContext is LinkedTextType && (LinkedTextType)dataContext != LinkedTextType.Element)
		{
			TextLinkCommand?.Invoke((LinkedTextType)dataContext);
		}
		else if (dataContext is ClosedBezierPath parameter2)
		{
			ElementTextLinkCommand?.Invoke(parameter2);
		}
	}

	private void SelectedElementTextLinkChanged(ElementTextLinkedObject? oldObject, ElementTextLinkedObject? newObject)
	{
		if (oldObject != null)
		{
			oldObject.PropertyChanged -= ElementTextLinkedObject_PropertyChanged;
		}
		if (newObject != null)
		{
			newObject.PropertyChanged += ElementTextLinkedObject_PropertyChanged;
		}
		((DependencyObject)this).SetCurrentValue(SelectedTextLinkElementNameProperty, (object)(SelectedElementTextLink?.Element?.Name ?? string.Empty));
	}

	private void ElementTextLinkedObject_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		string? propertyName = e.PropertyName;
		if (propertyName != null && propertyName.Equals("Element"))
		{
			((DependencyObject)this).SetCurrentValue(SelectedTextLinkElementNameProperty, (object)(SelectedElementTextLink?.Element?.Name ?? string.Empty));
		}
	}

	private void SelectedTimerTextLinkChanged(TimerLinkedObject? oldTimerLinkedObject, TimerLinkedObject? newTimerLinkedObject)
	{
		if (oldTimerLinkedObject != null)
		{
			oldTimerLinkedObject.PropertyChanged -= TimerLinkedObject_PropertyChanged;
		}
		if (newTimerLinkedObject != null)
		{
			newTimerLinkedObject.PropertyChanged += TimerLinkedObject_PropertyChanged;
		}
		((DependencyObject)this).SetCurrentValue(SelectedTextLinkTimerNameProperty, (object)(SelectedTimerTextLink?.TimerData?.Name ?? string.Empty));
	}

	private void TimerLinkedObject_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "TimerData")
		{
			((DependencyObject)this).SetCurrentValue(SelectedTextLinkTimerNameProperty, (object)(SelectedTimerTextLink?.TimerData?.Name ?? string.Empty));
		}
	}
}
