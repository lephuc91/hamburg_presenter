using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;
using Pro.Editor.Canvas.Popovers;
using Pro.UI.Controls;

namespace Pro.Editor.Canvas.Controls;

public partial class PopoverControl : FixedControl, IComponentConnector
{
	private const double LabelPadding = 8.0;

	private const int LabelColumn = 0;

	private const int ControlColumn = 1;

	private IEnumerable<PopoverBase> _popovers;

	public static readonly DependencyProperty PopoverForegroundProperty = DependencyProperty.Register("PopoverForeground", typeof(Brush), typeof(PopoverControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)Brushes.Black));

	public Brush PopoverForeground
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(PopoverForegroundProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(PopoverForegroundProperty, (object)value);
		}
	}

	public PopoverControl(IEnumerable<PopoverBase>? popovers)
	{
		InitializeComponent();
		_popovers = popovers ?? Enumerable.Empty<PopoverBase>();
		SetupPopovers();
		base.Unloaded += delegate
		{
			PopoverGrid.Children.Clear();
		};
	}

	private void SetupPopovers()
	{
		CleanupPopovers();
		foreach (PopoverBase popover in _popovers)
		{
			int count = PopoverGrid.RowDefinitions.Count;
			PopoverGrid.RowDefinitions.Add(new RowDefinition());
			TextBlock textBlock = new TextBlock
			{
				Padding = new Thickness(8.0, 0.0, 8.0, 0.0),
				TextAlignment = TextAlignment.Left
			};
			textBlock.SetBinding(TextBlock.TextProperty, new Binding("Label")
			{
				Source = popover.DataContext
			});
			textBlock.VerticalAlignment = VerticalAlignment.Center;
			textBlock.SetBinding(TextBlock.ForegroundProperty, new Binding("PopoverForeground")
			{
				Source = this
			});
			Grid.SetRow(textBlock, count);
			Grid.SetRow(popover, count);
			Grid.SetColumn(textBlock, 0);
			Grid.SetColumn(popover, 1);
			PopoverGrid.Children.Add(textBlock);
			PopoverGrid.Children.Add(popover);
		}
	}

	public void CleanupPopovers()
	{
		PopoverGrid.Children.Clear();
		PopoverGrid.RowDefinitions.Clear();
	}
}
