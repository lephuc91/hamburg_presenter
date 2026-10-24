using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Pro.Common.Collections;

namespace Pro.UI.Utility;

public static class ContextMenuHelper
{
	private class ContextMenuParameters
	{
		public bool IsOpen { get; set; }

		public bool OpenOnLeftClick { get; set; }

		public bool CenterMenu { get; set; }
	}

	private const string OpenOnLeftClick = "OpenOnLeftClick";

	private const string CenterMenu = "CenterMenu";

	private static readonly Dictionary<FrameworkElement, ContextMenuParameters> _elementDictionary = new Dictionary<FrameworkElement, ContextMenuParameters>();

	public static readonly DependencyProperty OpenOnLeftClickProperty = DependencyProperty.RegisterAttached("OpenOnLeftClick", typeof(bool), typeof(ContextMenuHelper), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false, new PropertyChangedCallback(OpenOnLeftClickChanged)));

	public static readonly DependencyProperty CenterMenuProperty = DependencyProperty.RegisterAttached("CenterMenu", typeof(bool), typeof(ContextMenuHelper), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false, new PropertyChangedCallback(CenterMenuChanged)));

	private static void OpenOnLeftClickChanged(DependencyObject callerObject, DependencyPropertyChangedEventArgs e)
	{
		OnOpenOnLeftClickChanged((FrameworkElement)(object)callerObject, (bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	private static void CenterMenuChanged(DependencyObject callerObject, DependencyPropertyChangedEventArgs e)
	{
		OnCenterMenuChanged((FrameworkElement)(object)callerObject, (bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	private static void OnOpenOnLeftClickChanged(FrameworkElement element, bool openOnLeftClick)
	{
		GetParameters(element).OpenOnLeftClick = openOnLeftClick;
		element.PreviewMouseDown += OnMouseDown;
		element.PreviewMouseUp += OnMouseUp;
	}

	private static void OnCenterMenuChanged(FrameworkElement element, bool centerMenu)
	{
		GetParameters(element).CenterMenu = centerMenu;
	}

	private static ContextMenuParameters GetParameters(FrameworkElement element)
	{
		if (_elementDictionary.TryGetValue(element, out ContextMenuParameters value))
		{
			return value;
		}
		ContextMenuParameters contextMenuParameters = new ContextMenuParameters();
		_elementDictionary.Add(element, contextMenuParameters);
		element.Loaded += ElementLoaded;
		return contextMenuParameters;
	}

	private static void ElementLoaded(object? sender, RoutedEventArgs e)
	{
		if (sender is FrameworkElement { ContextMenu: not null } frameworkElement)
		{
			frameworkElement.ContextMenu.Closed += ContextMenuClosed;
			if (_elementDictionary[frameworkElement].CenterMenu)
			{
				frameworkElement.ContextMenu.Opened += ContextMenuOpened;
			}
		}
	}

	private static void OnMouseDown(object? sender, MouseButtonEventArgs e)
	{
		if (sender is FrameworkElement { ContextMenu: not null } frameworkElement)
		{
			frameworkElement.ContextMenu.PlacementTarget = frameworkElement;
			ContextMenuParameters contextMenuParameters = _elementDictionary[frameworkElement];
			if (contextMenuParameters.OpenOnLeftClick && e.ChangedButton.IsAnyOf(MouseButton.Left, MouseButton.Right))
			{
				contextMenuParameters.IsOpen = !contextMenuParameters.IsOpen;
				frameworkElement.ContextMenu.IsOpen = contextMenuParameters.IsOpen;
				e.Handled = true;
			}
		}
	}

	private static void OnMouseUp(object? sender, MouseButtonEventArgs e)
	{
		e.Handled = sender is FrameworkElement { ContextMenu: not null } && _elementDictionary.TryGetValue((FrameworkElement)sender, out ContextMenuParameters value) && value.OpenOnLeftClick;
	}

	private static void ContextMenuOpened(object? sender, RoutedEventArgs e)
	{
		if (sender is ContextMenu { PlacementTarget: FrameworkElement placementTarget } contextMenu)
		{
			contextMenu.HorizontalOffset = (placementTarget.ActualWidth - contextMenu.ActualWidth) / 2.0;
		}
	}

	private static void ContextMenuClosed(object? sender, RoutedEventArgs e)
	{
		if ((sender as ContextMenu)?.PlacementTarget is FrameworkElement key && _elementDictionary.ContainsKey(key))
		{
			_elementDictionary[key].IsOpen = false;
		}
		Mouse.Captured?.ReleaseMouseCapture();
	}

	public static void SetOpenOnLeftClick(FrameworkElement element, bool value)
	{
		((DependencyObject)element).SetValue(OpenOnLeftClickProperty, (object)value);
	}

	public static bool GetOpenOnLeftClick(FrameworkElement element)
	{
		return (bool)((DependencyObject)element).GetValue(OpenOnLeftClickProperty);
	}

	public static void SetCenterMenu(FrameworkElement element, bool value)
	{
		((DependencyObject)element).SetValue(CenterMenuProperty, (object)value);
	}

	public static bool GetCenterMenu(FrameworkElement element)
	{
		return (bool)((DependencyObject)element).GetValue(CenterMenuProperty);
	}
}
