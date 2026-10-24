using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Pro.Common.Collections;

namespace Pro.UI.Utility;

public static class CommandTargets
{
	private class CommandTarget
	{
		public object Key { get; }

		public IInputElement Target { get; }

		public CommandTarget(object key, IInputElement target)
		{
			Key = key;
			Target = target;
		}
	}

	private class CommandSource
	{
		public object Key { get; }

		public dynamic Source { get; }

		public CommandSource(object key, object source)
		{
			Key = key;
			Source = source;
		}
	}

	private const string Register = "Register";

	private const string Assign = "Assign";

	private const string Default = "Default";

	private static readonly List<CommandTarget> _targets = new List<CommandTarget>();

	private static readonly List<CommandSource> _sources = new List<CommandSource>();

	public static readonly DependencyProperty RegisterProperty = DependencyProperty.RegisterAttached("Register", typeof(object), typeof(CommandTargets), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(RegisterPropertyChanged)));

	public static readonly DependencyProperty AssignProperty = DependencyProperty.RegisterAttached("Assign", typeof(object), typeof(CommandTargets), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(AssignPropertyChanged)));

	public static readonly DependencyProperty DefaultProperty = DependencyProperty.RegisterAttached("Default", typeof(bool), typeof(CommandTargets), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(DefaultPropertyChanged)));

	private static void RegisterPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		CommandTarget commandTarget = new CommandTarget(((DependencyPropertyChangedEventArgs)(ref e)).NewValue, (IInputElement)d);
		if (_targets.Any((CommandTarget t) => t.Key.Equals(((DependencyPropertyChangedEventArgs)(ref e)).NewValue)))
		{
			throw new NotSupportedException("Target already registered");
		}
		_targets.Add(commandTarget);
		_sources.Where((CommandSource s) => s.Key.Equals(((DependencyPropertyChangedEventArgs)(ref e)).NewValue)).ForEach(delegate(CommandSource s)
		{
			s.Source.CommandTarget = commandTarget.Target;
		});
	}

	private static void AssignPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		if (_sources.None((CommandSource s) => s.Source.Equals(d)))
		{
			_sources.Add(new CommandSource(((DependencyPropertyChangedEventArgs)(ref e)).NewValue, d));
		}
		_sources.Where((CommandSource s) => s.Key.Equals(((DependencyPropertyChangedEventArgs)(ref e)).NewValue)).ForEach(delegate(CommandSource s)
		{
			s.Source.CommandTarget = _targets.FirstOrDefault((CommandTarget t) => t.Key.Equals(((DependencyPropertyChangedEventArgs)(ref e)).NewValue))?.Target;
		});
	}

	private static void DefaultPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		if (!(bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue)
		{
			return;
		}
		MenuItem menuItem = d as MenuItem;
		if (menuItem == null)
		{
			return;
		}
		menuItem.Loaded += delegate
		{
			if (((DependencyObject)(object)menuItem).FindVisualParent<ContextMenu>() != null)
			{
				menuItem.SetBinding(MenuItem.CommandTargetProperty, new Binding("PlacementTarget")
				{
					Source = ((DependencyObject)(object)menuItem).FindVisualParent<ContextMenu>()
				});
			}
		};
	}

	public static object GetRegister(DependencyObject d)
	{
		return d.GetValue(RegisterProperty);
	}

	public static void SetRegister(DependencyObject d, object value)
	{
		d.SetValue(RegisterProperty, value);
	}

	public static object GetAssign(DependencyObject d)
	{
		return d.GetValue(AssignProperty);
	}

	public static void SetAssign(DependencyObject d, object value)
	{
		d.SetValue(AssignProperty, value);
	}

	public static object GetDefault(DependencyObject d)
	{
		return d.GetValue(DefaultProperty);
	}

	public static void SetDefault(DependencyObject d, object value)
	{
		d.SetValue(DefaultProperty, value);
	}

	public static IInputElement? FindTarget(object? key)
	{
		return _targets.FirstOrDefault((CommandTarget t) => t.Key.Equals(key))?.Target;
	}
}
