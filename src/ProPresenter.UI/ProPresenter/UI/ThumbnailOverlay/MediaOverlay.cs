using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Pro.Common.Effects;
using Pro.Common.FeatureFlag;
using Pro.Common.Mathematics;
using Pro.UI.DependencyInjection;
using ProPresenter.UI.ViewModels.Thumbnails;

namespace ProPresenter.UI.ThumbnailOverlay;

public partial class MediaOverlay : UserControl, IComponentConnector
{
	private sealed class MainContentTemplateSelector : DataTemplateSelector
	{
		private static readonly string IconOnlyTemplate = "IconOnlyTemplate";

		private static readonly string CloudMediaIconOnlyTemplate = "CloudMediaIconOnlyTemplate";

		private static readonly string MissingMediaTemplate = "MissingMediaTemplate";

		private static readonly string CloudMissingMediaTemplate = "CloudMissingMediaTemplate";

		private static readonly string MissingIconOnlyTemplate = "MissingIconOnlyTemplate";

		private readonly ResourceDictionary _resources;

		private readonly IFlagService _flagService;

		public MainContentTemplateSelector(ResourceDictionary resources, IFlagService flagService)
		{
			_resources = resources;
			_flagService = flagService;
		}

		public override DataTemplate SelectTemplate(object item, DependencyObject container)
		{
			if (item is IMediaOverlayVM { Type: var type })
			{
				return (DataTemplate)((type switch
				{
					OverlayType.CenterClickable => _flagService.IsFlagEnabled(Flag.Cloud) ? (_resources[CloudMissingMediaTemplate] as DataTemplate) : (_resources[MissingMediaTemplate] as DataTemplate), 
					OverlayType.MissingIconWithScrim => _resources[MissingIconOnlyTemplate] as DataTemplate, 
					_ => null, 
				}) ?? base.SelectTemplate(item, container));
			}
			return base.SelectTemplate(item, container);
		}
	}

	private readonly CircularBlurEffect _effect = new CircularBlurEffect();

	public static readonly DependencyProperty ShowTextProperty = DependencyProperty.Register("ShowText", typeof(bool), typeof(MediaOverlay), new PropertyMetadata((object)true));

	public static readonly DependencyProperty BackgroundControlProperty = DependencyProperty.Register("BackgroundControl", typeof(FrameworkElement), typeof(MediaOverlay), new PropertyMetadata((object)null, (PropertyChangedCallback)delegate(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		if (d is MediaOverlay mediaOverlay)
		{
			if (((DependencyPropertyChangedEventArgs)(ref e)).OldValue is FrameworkElement frameworkElement)
			{
				frameworkElement.SizeChanged -= mediaOverlay.BackgroundControl_SizeChanged;
				frameworkElement.Effect = null;
				mediaOverlay._effect.Target = null;
			}
			if (((DependencyPropertyChangedEventArgs)(ref e)).NewValue is FrameworkElement frameworkElement2)
			{
				frameworkElement2.SizeChanged += mediaOverlay.BackgroundControl_SizeChanged;
				frameworkElement2.Effect = ((mediaOverlay.DataContext != null) ? mediaOverlay._effect : null);
				mediaOverlay._effect.Target = frameworkElement2;
			}
			mediaOverlay.UpdateIconRect();
		}
	}));

	public static readonly DependencyProperty RingGridProperty = DependencyProperty.Register("RingGrid", typeof(FrameworkElement), typeof(MediaOverlay), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, (PropertyChangedCallback)delegate(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		if (d is MediaOverlay mediaOverlay2)
		{
			if (((DependencyPropertyChangedEventArgs)(ref e)).OldValue is FrameworkElement frameworkElement3)
			{
				frameworkElement3.SizeChanged -= mediaOverlay2.IconGrid_SizeChanged;
				frameworkElement3.Loaded -= mediaOverlay2.IconGrid_Loaded;
			}
			if (((DependencyPropertyChangedEventArgs)(ref e)).NewValue is FrameworkElement frameworkElement4)
			{
				frameworkElement4.SizeChanged += mediaOverlay2.IconGrid_SizeChanged;
				frameworkElement4.Loaded += mediaOverlay2.IconGrid_Loaded;
			}
			mediaOverlay2.UpdateIconRect();
		}
	}));

	public static readonly DependencyProperty RingSizeProperty = DependencyProperty.Register("RingSize", typeof(RingSize), typeof(MediaOverlay), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)RingSize.Large));

	public static readonly DependencyProperty AllowOpenVideoInputSetupProperty = DependencyProperty.Register("AllowOpenVideoInputSetup", typeof(bool), typeof(MediaOverlay), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));

	public bool ShowText
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowTextProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowTextProperty, (object)value);
		}
	}

	public FrameworkElement? BackgroundControl
	{
		get
		{
			return (FrameworkElement)((DependencyObject)this).GetValue(BackgroundControlProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(BackgroundControlProperty, (object)value);
		}
	}

	public FrameworkElement? RingGrid
	{
		get
		{
			return (FrameworkElement)((DependencyObject)this).GetValue(RingGridProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(RingGridProperty, (object)value);
		}
	}

	public RingSize RingSize
	{
		get
		{
			return (RingSize)((DependencyObject)this).GetValue(RingSizeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(RingSizeProperty, (object)value);
		}
	}

	public bool AllowOpenVideoInputSetup
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(AllowOpenVideoInputSetupProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AllowOpenVideoInputSetupProperty, (object)value);
		}
	}

	public MediaOverlay()
	{
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Expected O, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		InitializeComponent();
		base.Loaded += MediaOverlay_Loaded;
		base.IsVisibleChanged += new DependencyPropertyChangedEventHandler(MediaOverlay_IsVisibleChanged);
		MainContent.ContentTemplateSelector = new MainContentTemplateSelector(base.Resources, UIServiceProvider.GetService<IFlagService>());
		base.DataContextChanged += new DependencyPropertyChangedEventHandler(MediaOverlay_DataContextChanged);
	}

	private void MediaOverlay_DataContextChanged(object? sender, DependencyPropertyChangedEventArgs e)
	{
		if (BackgroundControl != null)
		{
			BackgroundControl.Effect = null;
			if (((DependencyPropertyChangedEventArgs)(ref e)).NewValue != null)
			{
				BackgroundControl.Effect = _effect;
			}
		}
	}

	private void MediaOverlay_Loaded(object? sender, RoutedEventArgs e)
	{
		UpdateIconRect();
	}

	private void MediaOverlay_IsVisibleChanged(object? sender, DependencyPropertyChangedEventArgs e)
	{
		UpdateIconRect();
	}

	private void IconGrid_SizeChanged(object? sender, SizeChangedEventArgs e)
	{
		UpdateIconRect();
	}

	private void IconGrid_Loaded(object? sender, RoutedEventArgs e)
	{
		UpdateIconRect();
	}

	private void BackgroundControl_SizeChanged(object? sender, SizeChangedEventArgs e)
	{
		UpdateIconRect();
	}

	private void UpdateIconRect()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		if (RingGrid != null)
		{
			Vector2<double> vector = ((BackgroundControl != null) ? ((Vector2<double>)RingGrid.TranslatePoint(Vector2<double>.Zero, BackgroundControl)) : Vector2<double>.Zero);
			_effect.Center = vector + (Vector2<double>)RingGrid.RenderSize / 2.0;
			_effect.Radius = RingGrid.ActualWidth / 2.0;
		}
	}
}
