using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Pro.Common.Collections;
using ProPresenter.DO.Cues;

namespace ProPresenter.UI.AudioLibrary;

public partial class AudioItemTemplate : UserControl, IComponentConnector
{
	public static readonly DependencyProperty ActiveAudioItemsProperty = DependencyProperty.Register("ActiveAudioItems", typeof(ObservableDictionary<MediaCue, bool>), typeof(AudioItemTemplate), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnActiveAudioItemsChanged)));

	private static readonly DependencyProperty IsActiveProperty = DependencyProperty.Register("IsActive", typeof(bool), typeof(AudioItemTemplate), new PropertyMetadata((object)false));

	private static readonly DependencyProperty IsPlayingProperty = DependencyProperty.Register("IsPlaying", typeof(bool), typeof(AudioItemTemplate), new PropertyMetadata((object)false));

	public ObservableDictionary<MediaCue, bool>? ActiveAudioItems
	{
		get
		{
			return (ObservableDictionary<MediaCue, bool>)((DependencyObject)this).GetValue(ActiveAudioItemsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ActiveAudioItemsProperty, (object)value);
		}
	}

	private bool IsActive
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsActiveProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsActiveProperty, (object)value);
		}
	}

	private bool IsPlaying
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsPlayingProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsPlayingProperty, (object)value);
		}
	}

	private static void OnActiveAudioItemsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((AudioItemTemplate)(object)d).ActiveAudioItemsChanged(((DependencyPropertyChangedEventArgs)(ref e)).OldValue as ObservableDictionary<MediaCue, bool>, ((DependencyPropertyChangedEventArgs)(ref e)).NewValue as ObservableDictionary<MediaCue, bool>);
	}

	public AudioItemTemplate()
	{
		InitializeComponent();
	}

	private void ActiveAudioItemsChanged(ObservableDictionary<MediaCue, bool>? oldCollection, ObservableDictionary<MediaCue, bool>? newCollection)
	{
		if (oldCollection != null)
		{
			oldCollection.CollectionChanged -= ActiveAudioItems_CollectionChanged;
			oldCollection.PropertyChanged -= ActiveAudioItems_PropertyChanged;
		}
		if (newCollection != null)
		{
			newCollection.CollectionChanged += ActiveAudioItems_CollectionChanged;
			newCollection.PropertyChanged += ActiveAudioItems_PropertyChanged;
		}
		UpdateStatus();
	}

	private void ActiveAudioItems_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		UpdateStatus();
	}

	private void ActiveAudioItems_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		UpdateStatus();
	}

	private void UpdateStatus()
	{
		if (base.DataContext is MediaCue key)
		{
			bool value = false;
			((DependencyObject)this).SetCurrentValue(IsActiveProperty, (object)ActiveAudioItems?.TryGetValue(key, out value));
			((DependencyObject)this).SetCurrentValue(IsPlayingProperty, (object)value);
		}
	}
}
