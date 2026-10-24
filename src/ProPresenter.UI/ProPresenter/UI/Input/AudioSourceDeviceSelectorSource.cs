using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Markup;
using CommunityToolkit.Mvvm.Input;
using Pro.Common.Collections;
using Pro.DO.Audio;
using Pro.UI.Components;
using Pro.ssAPI.Devices;
using ProPresenter.UI.LiveVideo;

namespace ProPresenter.UI.Input;

public partial class AudioSourceDeviceSelectorSource : FrameworkCollection, IComponentConnector
{
	[CompilerGenerated]
	private sealed class _003CGetFilterVideoDevices_003Ed__40 : IEnumerable<IVideoInputDevice>, IEnumerable, IEnumerator<IVideoInputDevice>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private IVideoInputDevice _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		public AudioSourceDeviceSelectorSource _003C_003E4__this;

		private IEnumerator<IVideoInputDevice> _003C_003E7__wrap1;

		IVideoInputDevice IEnumerator<IVideoInputDevice>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CGetFilterVideoDevices_003Ed__40(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
			_003C_003El__initialThreadId = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			int num = _003C_003E1__state;
			if (num == -3 || num == 1)
			{
				try
				{
				}
				finally
				{
					_003C_003Em__Finally1();
				}
			}
			_003C_003E7__wrap1 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			try
			{
				int num = _003C_003E1__state;
				AudioSourceDeviceSelectorSource audioSourceDeviceSelectorSource = _003C_003E4__this;
				switch (num)
				{
				default:
					return false;
				case 0:
					_003C_003E1__state = -1;
					_003C_003E7__wrap1 = (audioSourceDeviceSelectorSource.VideoDevices?.Where((IVideoInputDevice v) => v.SupportsAudio) ?? Array.Empty<IVideoInputDevice>()).GetEnumerator();
					_003C_003E1__state = -3;
					break;
				case 1:
					_003C_003E1__state = -3;
					break;
				}
				while (_003C_003E7__wrap1.MoveNext())
				{
					IVideoInputDevice current = _003C_003E7__wrap1.Current;
					if (current != audioSourceDeviceSelectorSource.DefaultVideoDevice)
					{
						_003C_003E2__current = current;
						_003C_003E1__state = 1;
						return true;
					}
				}
				_003C_003Em__Finally1();
				_003C_003E7__wrap1 = null;
				return false;
			}
			catch
			{
				//try-fault
				((IDisposable)this).Dispose();
				throw;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		private void _003C_003Em__Finally1()
		{
			_003C_003E1__state = -1;
			if (_003C_003E7__wrap1 != null)
			{
				_003C_003E7__wrap1.Dispose();
			}
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<IVideoInputDevice> IEnumerable<IVideoInputDevice>.GetEnumerator()
		{
			_003CGetFilterVideoDevices_003Ed__40 result;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				result = this;
			}
			else
			{
				result = new _003CGetFilterVideoDevices_003Ed__40(0)
				{
					_003C_003E4__this = _003C_003E4__this
				};
			}
			return result;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<IVideoInputDevice>)this).GetEnumerator();
		}
	}

	public static readonly DependencyProperty SourceProperty = DependencyProperty.Register("Source", typeof(AudioSource), typeof(AudioSourceDeviceSelectorSource));

	public static readonly DependencyProperty AudioDevicesProperty = DependencyProperty.Register("AudioDevices", typeof(INotifyEnumerableChanged<IAudioInputDevice>), typeof(AudioSourceDeviceSelectorSource));

	public static readonly DependencyProperty VideoDevicesProperty = DependencyProperty.Register("VideoDevices", typeof(INotifyEnumerableChanged<IVideoInputDevice>), typeof(AudioSourceDeviceSelectorSource), (PropertyMetadata)(object)new FrameworkPropertyMetadata((PropertyChangedCallback)delegate(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((AudioSourceDeviceSelectorSource)(object)d).VideoDevicesChanged(((DependencyPropertyChangedEventArgs)(ref e)).OldValue as INotifyEnumerableChanged<IVideoInputDevice>, ((DependencyPropertyChangedEventArgs)(ref e)).NewValue as INotifyEnumerableChanged<IVideoInputDevice>);
	}));

	public static readonly DependencyProperty FilteredVideoDevicesProperty = DependencyProperty.Register("FilteredVideoDevices", typeof(IEnumerable<IVideoInputDevice>), typeof(AudioSourceDeviceSelectorSource));

	public static readonly DependencyProperty DefaultVideoDeviceProperty = DependencyProperty.Register("DefaultVideoDevice", typeof(IVideoInputDevice), typeof(AudioSourceDeviceSelectorSource), (PropertyMetadata)(object)new FrameworkPropertyMetadata((PropertyChangedCallback)delegate(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((AudioSourceDeviceSelectorSource)(object)d).FilterVideoDevices();
	}));

	public static readonly DependencyProperty ClearDeviceCommandProperty = DependencyProperty.Register("ClearDeviceCommand", typeof(IRelayCommand), typeof(AudioSourceDeviceSelectorSource));

	public static readonly DependencyProperty SelectVideoDeviceCommandProperty = DependencyProperty.Register("SelectVideoDeviceCommand", typeof(IRelayCommand<SelectVideoDeviceCommandParameter>), typeof(AudioSourceDeviceSelectorSource));

	public static readonly DependencyProperty SelectAudioDeviceCommandProperty = DependencyProperty.Register("SelectAudioDeviceCommand", typeof(IRelayCommand<IAudioInputDevice>), typeof(AudioSourceDeviceSelectorSource));

	public static readonly DependencyProperty AddAirCastDeviceCommandProperty = DependencyProperty.Register("AddAirCastDeviceCommand", typeof(IRelayCommand<AudioSource>), typeof(AudioSourceDeviceSelectorSource));

	public AudioSource? Source
	{
		get
		{
			return (AudioSource)((DependencyObject)this).GetValue(SourceProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SourceProperty, (object)value);
		}
	}

	public INotifyEnumerableChanged<IAudioInputDevice>? AudioDevices
	{
		get
		{
			return (INotifyEnumerableChanged<IAudioInputDevice>)((DependencyObject)this).GetValue(AudioDevicesProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AudioDevicesProperty, (object)value);
		}
	}

	public INotifyEnumerableChanged<IVideoInputDevice>? VideoDevices
	{
		get
		{
			return (INotifyEnumerableChanged<IVideoInputDevice>)((DependencyObject)this).GetValue(VideoDevicesProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(VideoDevicesProperty, (object)value);
		}
	}

	private IEnumerable<IVideoInputDevice> FilteredVideoDevices
	{
		get
		{
			return (IEnumerable<IVideoInputDevice>)((DependencyObject)this).GetValue(FilteredVideoDevicesProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(FilteredVideoDevicesProperty, (object)value);
		}
	}

	public IVideoInputDevice? DefaultVideoDevice
	{
		get
		{
			return (IVideoInputDevice)((DependencyObject)this).GetValue(DefaultVideoDeviceProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DefaultVideoDeviceProperty, (object)value);
		}
	}

	public IRelayCommand? ClearDeviceCommand
	{
		get
		{
			return (IRelayCommand)((DependencyObject)this).GetValue(ClearDeviceCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ClearDeviceCommandProperty, (object)value);
		}
	}

	public IRelayCommand<SelectVideoDeviceCommandParameter?>? SelectVideoDeviceCommand
	{
		get
		{
			return (IRelayCommand<SelectVideoDeviceCommandParameter>)((DependencyObject)this).GetValue(SelectVideoDeviceCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectVideoDeviceCommandProperty, (object)value);
		}
	}

	public IRelayCommand<IAudioInputDevice>? SelectAudioDeviceCommand
	{
		get
		{
			return (IRelayCommand<IAudioInputDevice>)((DependencyObject)this).GetValue(SelectAudioDeviceCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectAudioDeviceCommandProperty, (object)value);
		}
	}

	public IRelayCommand<AudioSource?>? AddAirCastDeviceCommand
	{
		get
		{
			return (IRelayCommand<AudioSource>)((DependencyObject)this).GetValue(AddAirCastDeviceCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AddAirCastDeviceCommandProperty, (object)value);
		}
	}

	public AudioSourceDeviceSelectorSource()
	{
		InitializeComponent();
	}

	private void VideoDevicesChanged(INotifyEnumerableChanged<IVideoInputDevice>? oldDevices, INotifyEnumerableChanged<IVideoInputDevice>? newDevices)
	{
		if (oldDevices != null)
		{
			oldDevices.CollectionChanged -= Devices_CollectionChanged;
		}
		if (newDevices != null)
		{
			newDevices.CollectionChanged += Devices_CollectionChanged;
		}
		FilterVideoDevices();
	}

	private void Devices_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		FilterVideoDevices();
	}

	private void FilterVideoDevices()
	{
		((DependencyObject)this).SetCurrentValue(FilteredVideoDevicesProperty, (object)GetFilterVideoDevices().ToArray());
	}

	[IteratorStateMachine(typeof(_003CGetFilterVideoDevices_003Ed__40))]
	private IEnumerable<IVideoInputDevice> GetFilterVideoDevices()
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CGetFilterVideoDevices_003Ed__40(-2)
		{
			_003C_003E4__this = this
		};
	}
}
