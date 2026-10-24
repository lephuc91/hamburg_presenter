using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Pro.Common.Mathematics;
using Pro.UI.Components;
using Pro.UI.Utility;
using ProPresenter.DO.OutputConfiguration;

namespace ProPresenter.UI.OutputConfiguration;

public partial class PlaceholderDeviceSource : MenuItem, IComponentConnector, IStyleConnector
{
	public class MenuItemContainerStyleSelector : StyleSelector
	{
		private const string DefaultSizeStyleKey = "defaultSizeStyle";

		private const string CustomSizeStyleKey = "customSizeStyle";

		private readonly ResourceDictionary _resources;

		public MenuItemContainerStyleSelector(ResourceDictionary resources)
		{
			_resources = resources;
		}

		public override Style SelectStyle(object item, DependencyObject container)
		{
			if (!(item is Vector2<int>))
			{
				return (Style)_resources["customSizeStyle"];
			}
			return (Style)_resources["defaultSizeStyle"];
		}
	}

	private readonly ObservableCollection<Vector2<int>> _defaultModes = new ObservableCollection<Vector2<int>>();

	public static readonly DependencyProperty PlacementTargetProperty = DependencyProperty.Register("PlacementTarget", typeof(UIElement), typeof(PlaceholderDeviceSource));

	public static readonly DependencyProperty AssignDeviceCommandProperty = DependencyProperty.Register("AssignDeviceCommand", typeof(ICommand<DeviceCommandParameter>), typeof(PlaceholderDeviceSource), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnCommandChanged)));

	public ReadOnlyObservableCollection<Vector2<int>> DefaultModes { get; private set; }

	public UIElement? PlacementTarget
	{
		get
		{
			return (UIElement)((DependencyObject)this).GetValue(PlacementTargetProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(PlacementTargetProperty, (object)value);
		}
	}

	public NewCustomDevice NewCustomDevice { get; } = new NewCustomDevice();

	public ICommand<DeviceCommandParameter?>? AssignDeviceCommand
	{
		get
		{
			return (ICommand<DeviceCommandParameter>)((DependencyObject)this).GetValue(AssignDeviceCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AssignDeviceCommandProperty, (object)value);
		}
	}

	private static void OnCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((PlaceholderDeviceSource)(object)d).NewCustomDevice.NewPlaceholderDeviceCommand = ((DependencyPropertyChangedEventArgs)(ref e)).NewValue as ICommand<DeviceCommandParameter>;
	}

	public PlaceholderDeviceSource()
	{
		foreach (var item in SoftDevice.AvailableNDIModes.Select((DeviceMode m) => new
		{
			Width = m.Size.X,
			Height = m.Size.Y
		}).Distinct())
		{
			_defaultModes.Add(new Vector2<int>(item.Width, item.Height));
		}
		DefaultModes = new ReadOnlyObservableCollection<Vector2<int>>(_defaultModes);
		InitializeComponent();
		base.ItemContainerStyleSelector = new MenuItemContainerStyleSelector(base.Resources);
	}

	private void DefaultSize_Click(object? sender, RoutedEventArgs e)
	{
		if (!(sender is MenuItem { DataContext: var dataContext }) || !(dataContext is Vector2<int> size))
		{
			return;
		}
		object obj = (PlacementTarget as FrameworkElement)?.DataContext;
		if (obj != null)
		{
			DeviceCommandParameter parameter = null;
			if (obj is ScreenTargetType value)
			{
				parameter = new DeviceCommandParameter(value, null, new PlaceholderDevice(size));
			}
			else if (obj is HardwareScreenRectangleOptions targetRectangle)
			{
				parameter = new DeviceCommandParameter(null, targetRectangle, new PlaceholderDevice(size));
			}
			else if (obj is Screen screen)
			{
				PlaceholderDevice placeholderDevice = new PlaceholderDevice(size);
				parameter = new DeviceCommandParameter(null, screen.MainOutput, placeholderDevice, placeholderDevice.PlaceholderDeviceMode);
			}
			AssignDeviceCommand?.Invoke<DeviceCommandParameter>(parameter);
		}
	}

	private void CustomSize_Click(object? sender, RoutedEventArgs e)
	{
		NewCustomDevice.Owner = Window.GetWindow((DependencyObject)(object)this);
		object obj = (PlacementTarget as FrameworkElement)?.DataContext;
		if (obj != null)
		{
			if (obj is ScreenTargetType value)
			{
				NewCustomDevice.ScreenTargetType = value;
			}
			else if (obj is HardwareScreenRectangleOptions hardwareRectangle)
			{
				NewCustomDevice.HardwareRectangle = hardwareRectangle;
			}
			else if (obj is Screen screen)
			{
				NewCustomDevice.HardwareRectangle = screen.MainOutput;
			}
			NewCustomDevice.ShowDialog();
		}
	}
}
