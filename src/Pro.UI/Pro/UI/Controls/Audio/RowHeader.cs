using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Pro.DO.Audio;

namespace Pro.UI.Controls.Audio;

public partial class RowHeader : UserControl, IComponentConnector
{
	public static readonly DependencyProperty ChannelsProperty = DependencyProperty.Register("Channels", typeof(IEnumerable<IChannel>), typeof(RowHeader));

	public static readonly DependencyProperty TemplateWidthProperty = DependencyProperty.Register("TemplateWidth", typeof(double), typeof(RowHeader));

	public static readonly DependencyProperty TemplateHeightProperty = DependencyProperty.Register("TemplateHeight", typeof(double), typeof(RowHeader));

	public static readonly DependencyProperty ShowChannelIndexProperty = DependencyProperty.Register("ShowChannelIndex", typeof(bool), typeof(RowHeader));

	public static readonly DependencyProperty ShowChannelControlsProperty = DependencyProperty.Register("ShowChannelControls", typeof(bool), typeof(RowHeader));

	public static readonly DependencyProperty ShowMuteControlsProperty = DependencyProperty.Register("ShowMuteControls", typeof(bool), typeof(RowHeader));

	public static readonly DependencyProperty ShowSoloControlsProperty = DependencyProperty.Register("ShowSoloControls", typeof(bool), typeof(RowHeader));

	public static readonly DependencyProperty ShowTestControlsProperty = DependencyProperty.Register("ShowTestControls", typeof(bool), typeof(RowHeader));

	public IEnumerable<IChannel>? Channels
	{
		get
		{
			return (IEnumerable<IChannel>)((DependencyObject)this).GetValue(ChannelsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ChannelsProperty, (object)value);
		}
	}

	public double TemplateWidth
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(TemplateWidthProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TemplateWidthProperty, (object)value);
		}
	}

	public double TemplateHeight
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(TemplateHeightProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TemplateHeightProperty, (object)value);
		}
	}

	public bool ShowChannelIndex
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowChannelIndexProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowChannelIndexProperty, (object)value);
		}
	}

	public bool ShowChannelControls
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowChannelControlsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowChannelControlsProperty, (object)value);
		}
	}

	public bool ShowMuteControls
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowMuteControlsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowMuteControlsProperty, (object)value);
		}
	}

	public bool ShowSoloControls
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowSoloControlsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowSoloControlsProperty, (object)value);
		}
	}

	public bool ShowTestControls
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowTestControlsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowTestControlsProperty, (object)value);
		}
	}

	public RowHeader()
	{
		InitializeComponent();
	}
}
