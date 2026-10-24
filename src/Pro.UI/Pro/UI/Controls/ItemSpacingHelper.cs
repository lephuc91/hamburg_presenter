using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Pro.UI.Controls;

public class ItemSpacingHelper
{
	private const string ItemSpacing = "ItemSpacing";

	public static readonly DependencyProperty ItemSpacingProperty = DependencyProperty.RegisterAttached("ItemSpacing", typeof(double), typeof(ItemSpacingHelper), new PropertyMetadata(new PropertyChangedCallback(OnItemSpacingChanged)));

	private static readonly Dictionary<Panel, List<DependencyPropertyDescriptor>> _descriptorMap = new Dictionary<Panel, List<DependencyPropertyDescriptor>>();

	public static double GetItemSpacing(DependencyObject? target)
	{
		if (target == null)
		{
			throw new ArgumentNullException("target");
		}
		return (double)target.GetValue(ItemSpacingProperty);
	}

	public static void OnItemSpacingChanged(object? sender, DependencyPropertyChangedEventArgs e)
	{
		if (sender is StackPanel stackPanel)
		{
			stackPanel.Loaded += StackPanelOnLoaded;
			stackPanel.Unloaded += StackPanelOnUnloaded;
			UpdateStackPanelChildren(stackPanel);
		}
		else if (sender is UniformGrid uniformGrid)
		{
			uniformGrid.Loaded += UniformGridOnLoaded;
			uniformGrid.Unloaded += UniformGridOnUnloaded;
			UpdateUniformGridChildren(uniformGrid);
		}
	}

	public static void SetItemSpacing(DependencyObject? target, double value)
	{
		if (target == null)
		{
			throw new ArgumentNullException("target");
		}
		target.SetValue(ItemSpacingProperty, (object)value);
	}

	private static void StackPanelDescriptorChangedHandler(object? sender, EventArgs e)
	{
		UpdateStackPanelChildren(sender as StackPanel);
	}

	private static void StackPanelOnLoaded(object? sender, RoutedEventArgs e)
	{
		if (!(sender is StackPanel stackPanel))
		{
			throw new InvalidOperationException();
		}
		DependencyPropertyDescriptor val = DependencyPropertyDescriptor.FromProperty(StackPanel.OrientationProperty, typeof(StackPanel));
		((PropertyDescriptor)(object)val).AddValueChanged((object)stackPanel, (EventHandler)StackPanelDescriptorChangedHandler);
		if (!_descriptorMap.ContainsKey(stackPanel))
		{
			_descriptorMap.Add(stackPanel, new List<DependencyPropertyDescriptor>());
		}
		foreach (DependencyPropertyDescriptor item in _descriptorMap[stackPanel])
		{
			((PropertyDescriptor)(object)item).RemoveValueChanged((object)stackPanel, (EventHandler)StackPanelDescriptorChangedHandler);
		}
		_descriptorMap[stackPanel].Clear();
		_descriptorMap[stackPanel].Add(val);
		UpdateStackPanelChildren(stackPanel);
	}

	private static void StackPanelOnUnloaded(object? sender, RoutedEventArgs e)
	{
		if (!(sender is StackPanel stackPanel))
		{
			throw new InvalidOperationException();
		}
		if (!_descriptorMap.ContainsKey(stackPanel))
		{
			return;
		}
		foreach (DependencyPropertyDescriptor item in _descriptorMap[stackPanel])
		{
			((PropertyDescriptor)(object)item).RemoveValueChanged((object)stackPanel, (EventHandler)StackPanelDescriptorChangedHandler);
		}
		_descriptorMap[stackPanel].Clear();
		_descriptorMap.Remove(stackPanel);
	}

	private static void UniformGridDescriptorChangedHandler(object? sender, EventArgs e)
	{
		UpdateUniformGridChildren(sender as UniformGrid);
	}

	private static void UniformGridOnLoaded(object? sender, RoutedEventArgs e)
	{
		if (!(sender is UniformGrid uniformGrid))
		{
			throw new InvalidOperationException();
		}
		DependencyPropertyDescriptor val = DependencyPropertyDescriptor.FromProperty(UniformGrid.ColumnsProperty, typeof(UniformGrid));
		((PropertyDescriptor)(object)val).AddValueChanged((object)uniformGrid, (EventHandler)UniformGridDescriptorChangedHandler);
		DependencyPropertyDescriptor val2 = DependencyPropertyDescriptor.FromProperty(UniformGrid.RowsProperty, typeof(UniformGrid));
		((PropertyDescriptor)(object)val2).AddValueChanged((object)uniformGrid, (EventHandler)UniformGridDescriptorChangedHandler);
		if (!_descriptorMap.ContainsKey(uniformGrid))
		{
			_descriptorMap.Add(uniformGrid, new List<DependencyPropertyDescriptor>());
		}
		foreach (DependencyPropertyDescriptor item in _descriptorMap[uniformGrid])
		{
			((PropertyDescriptor)(object)item).RemoveValueChanged((object)uniformGrid, (EventHandler)UniformGridDescriptorChangedHandler);
		}
		_descriptorMap[uniformGrid].Clear();
		_descriptorMap[uniformGrid].Add(val);
		_descriptorMap[uniformGrid].Add(val2);
		UpdateUniformGridChildren(uniformGrid);
	}

	private static void UniformGridOnUnloaded(object? sender, RoutedEventArgs e)
	{
		if (!(sender is UniformGrid uniformGrid))
		{
			throw new InvalidOperationException();
		}
		if (!_descriptorMap.ContainsKey(uniformGrid))
		{
			return;
		}
		foreach (DependencyPropertyDescriptor item in _descriptorMap[uniformGrid])
		{
			((PropertyDescriptor)(object)item).RemoveValueChanged((object)uniformGrid, (EventHandler)UniformGridDescriptorChangedHandler);
		}
		_descriptorMap[uniformGrid].Clear();
		_descriptorMap.Remove(uniformGrid);
	}

	private static void UpdateStackPanelChildren(StackPanel? stackPanel)
	{
		if (stackPanel == null || stackPanel.Children.Count <= 1)
		{
			return;
		}
		int num = 0;
		int count = stackPanel.Children.Count;
		double num2 = GetItemSpacing((DependencyObject?)(object)stackPanel) / 2.0;
		foreach (UIElement child in stackPanel.Children)
		{
			bool flag = false;
			bool flag2 = false;
			if (num == 0)
			{
				flag = true;
			}
			if (num >= count - 1)
			{
				flag2 = true;
			}
			num++;
			if (!(child is FrameworkElement frameworkElement))
			{
				continue;
			}
			switch (stackPanel.Orientation)
			{
			case Orientation.Horizontal:
				if (flag)
				{
					frameworkElement.Margin = new Thickness(0.0, 0.0, num2, 0.0);
				}
				else if (flag2)
				{
					frameworkElement.Margin = new Thickness(num2, 0.0, 0.0, 0.0);
				}
				else
				{
					frameworkElement.Margin = new Thickness(num2, 0.0, num2, 0.0);
				}
				break;
			case Orientation.Vertical:
				if (flag)
				{
					frameworkElement.Margin = new Thickness(0.0, 0.0, 0.0, num2);
				}
				else if (flag2)
				{
					frameworkElement.Margin = new Thickness(0.0, num2, 0.0, 0.0);
				}
				else
				{
					frameworkElement.Margin = new Thickness(0.0, num2, 0.0, num2);
				}
				break;
			}
		}
	}

	private static void UpdateUniformGridChildren(UniformGrid? uniformGrid)
	{
		if (uniformGrid == null || uniformGrid.Children.Count <= 1)
		{
			return;
		}
		double num = GetItemSpacing((DependencyObject?)(object)uniformGrid) / 2.0;
		for (int i = 0; i < uniformGrid.Rows; i++)
		{
			int num2 = ((uniformGrid.Columns == 0) ? uniformGrid.Children.Count : uniformGrid.Columns);
			for (int j = 0; j < num2; j++)
			{
				int num3 = uniformGrid.Columns * i + j;
				double left = 0.0;
				double top = 0.0;
				double right = 0.0;
				double bottom = 0.0;
				if (j != 0)
				{
					left = num;
				}
				if (j >= uniformGrid.Columns - 1)
				{
					right = num;
				}
				if (i != 0)
				{
					top = num;
				}
				if (i >= uniformGrid.Rows - 1)
				{
					bottom = num;
				}
				if (num3 < uniformGrid.Children.Count && uniformGrid.Children[num3] is FrameworkElement frameworkElement)
				{
					frameworkElement.Margin = new Thickness(left, top, right, bottom);
				}
			}
		}
	}
}
