using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Pro.Common.Components;
using Pro.DO.Audio;
using Pro.DO.Storage;
using Pro.UI.Components;
using Pro.UI.Utility;
using ProPresenter.DO;
using ProPresenter.DO.Capture;
using ProPresenter.UI.ViewModels;
using ProPresenter.UI.ViewModels.Capture;

namespace ProPresenter.ViewModels;

public class RtmpCaptureVM : LinkedNotifyPropertyChangedBase, IRtmpCaptureVM, INotifyPropertyChanged
{
	[CompilerGenerated]
	private sealed class _003Cget_DefaultFolders_003Ed__14 : IEnumerable<RelativePath>, IEnumerable, IEnumerator<RelativePath>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private RelativePath _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		RelativePath IEnumerator<RelativePath>.Current
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
		public _003Cget_DefaultFolders_003Ed__14(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
			_003C_003El__initialThreadId = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003C_003E2__current = new RelativePath(CommonPaths.DocumentsFolder, isDirectory: true);
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				_003C_003E2__current = new RelativePath(CommonPaths.DesktopFolder, isDirectory: true);
				_003C_003E1__state = 2;
				return true;
			case 2:
				_003C_003E1__state = -1;
				_003C_003E2__current = new RelativePath(CommonPaths.VideosFolder, isDirectory: true);
				_003C_003E1__state = 3;
				return true;
			case 3:
				_003C_003E1__state = -1;
				return false;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<RelativePath> IEnumerable<RelativePath>.GetEnumerator()
		{
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				return this;
			}
			return new _003Cget_DefaultFolders_003Ed__14(0);
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<RelativePath>)this).GetEnumerator();
		}
	}

	[CompilerGenerated]
	private sealed class _003Cget_DefaultSaveToLocations_003Ed__28 : IEnumerable<RelativePath>, IEnumerable, IEnumerator<RelativePath>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private RelativePath _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		public RtmpCaptureVM _003C_003E4__this;

		private IEnumerator<RelativePath> _003C_003E7__wrap1;

		RelativePath IEnumerator<RelativePath>.Current
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
		public _003Cget_DefaultSaveToLocations_003Ed__28(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
			_003C_003El__initialThreadId = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			int num = _003C_003E1__state;
			if (num == -3 || num == 2)
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
				RtmpCaptureVM CS_0024_003C_003E8__locals3 = _003C_003E4__this;
				switch (num)
				{
				default:
					return false;
				case 0:
					_003C_003E1__state = -1;
					if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals3._customSaveLocation) && !DefaultFolders.Any((RelativePath f) => f == CS_0024_003C_003E8__locals3._customSaveLocation))
					{
						_003C_003E2__current = CS_0024_003C_003E8__locals3._customSaveLocation;
						_003C_003E1__state = 1;
						return true;
					}
					goto IL_0076;
				case 1:
					_003C_003E1__state = -1;
					goto IL_0076;
				case 2:
					{
						_003C_003E1__state = -3;
						break;
					}
					IL_0076:
					_003C_003E7__wrap1 = DefaultFolders.GetEnumerator();
					_003C_003E1__state = -3;
					break;
				}
				if (_003C_003E7__wrap1.MoveNext())
				{
					RelativePath current = _003C_003E7__wrap1.Current;
					_003C_003E2__current = current;
					_003C_003E1__state = 2;
					return true;
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
		IEnumerator<RelativePath> IEnumerable<RelativePath>.GetEnumerator()
		{
			_003Cget_DefaultSaveToLocations_003Ed__28 result;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				result = this;
			}
			else
			{
				result = new _003Cget_DefaultSaveToLocations_003Ed__28(0)
				{
					_003C_003E4__this = _003C_003E4__this
				};
			}
			return result;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<RelativePath>)this).GetEnumerator();
		}
	}

	private readonly ICaptureService _captureService;

	private RelativePath _customSaveLocation;

	private RelativePath _saveToLocation;

	private string _lastUsedAddress = string.Empty;

	private string _lastUsedKey = string.Empty;

	private bool _lastSaveLocalCopyValue;

	private Encoder _lastUsedEncoder = ProPresenter.DO.Capture.Encoder.RtmpDefault;

	private IStream? Stream => _captureService.Stream;

	private RtmpDestination? RTMPDestination => Stream?.OfType<RtmpDestination>().FirstOrDefault();

	private DiskDestination? DiskDestination => Stream?.OfType<DiskDestination>().FirstOrDefault();

	private static IEnumerable<RelativePath> DefaultFolders
	{
		[IteratorStateMachine(typeof(_003Cget_DefaultFolders_003Ed__14))]
		get
		{
			//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
			return new _003Cget_DefaultFolders_003Ed__14(-2);
		}
	}

	public string Address
	{
		get
		{
			return RTMPDestination?.Address ?? string.Empty;
		}
		set
		{
			if (RTMPDestination != null)
			{
				RTMPDestination.Address = value;
				_lastUsedAddress = value;
			}
		}
	}

	public string Key
	{
		get
		{
			return RTMPDestination?.Key ?? string.Empty;
		}
		set
		{
			if (RTMPDestination != null)
			{
				RTMPDestination.Key = value;
				_lastUsedKey = value;
			}
		}
	}

	public bool SaveLocalCopy
	{
		get
		{
			if (RTMPDestination != null)
			{
				return DiskDestination != null;
			}
			return false;
		}
		set
		{
			if (RTMPDestination != null)
			{
				if (value)
				{
					DiskDestination diskDestination = new DiskDestination();
					RelativePath saveToLocation = _saveToLocation;
					diskDestination.Location = (((object)saveToLocation != null && saveToLocation.IsValid) ? _saveToLocation : new RelativePath(CommonPaths.VideosFolder, isDirectory: true));
					DiskDestination destination = diskDestination;
					Stream?.AddDestination(destination);
				}
				else if (DiskDestination != null)
				{
					Stream?.RemoveDestination(DiskDestination);
				}
				_lastSaveLocalCopyValue = value;
				if (!value)
				{
					_captureService.CaptureFile = RelativePath.Empty();
				}
			}
		}
	}

	public RelativePath SaveToLocation
	{
		get
		{
			object obj = DiskDestination?.Location;
			if (obj == null)
			{
				RelativePath saveToLocation = _saveToLocation;
				if ((object)saveToLocation == null || !saveToLocation.IsValid)
				{
					return RelativePath.Empty();
				}
				obj = _saveToLocation;
			}
			return (RelativePath)obj;
		}
		set
		{
			if (!DefaultFolders.Any((RelativePath f) => f == value))
			{
				_customSaveLocation = value;
			}
			if (DiskDestination != null)
			{
				DiskDestination.Location = value;
				_saveToLocation = value;
			}
		}
	}

	public IEnumerable<RelativePath> DefaultSaveToLocations
	{
		[IteratorStateMachine(typeof(_003Cget_DefaultSaveToLocations_003Ed__28))]
		get
		{
			//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
			return new _003Cget_DefaultSaveToLocations_003Ed__28(-2)
			{
				_003C_003E4__this = this
			};
		}
	}

	public AudioMap<Bus, StreamAudioChannel>? AudioOutputMap => Stream?.AudioOutputMap;

	public Encoder? Encoder
	{
		get
		{
			return Stream?.Encoder.Encoding;
		}
		[param: DisallowNull]
		set
		{
			if (Stream != null)
			{
				Stream.Encoder.Encoding = value;
				_lastUsedEncoder = value;
			}
		}
	}

	public ICustomEncoderVM CustomEncoderVM { get; }

	public ICommand SaveToOtherLocationCommand => new RelayCommand(OnSaveToLocationCommand);

	public ICommand<RelativePath> SelectDefaultLocationCommand => new RelayCommand<RelativePath>(OnSelectDefaultLocationCommand);

	public ICommand<Encoder> SelectEncoderCommand => new RelayCommand<Encoder>(SelectEncoderCommandExecuted, (Encoder e) => e != null);

	public ICommand SelectCustomEncoderCommand => new RelayCommand(SelectCustomEncoderCommandExecuted);

	public RtmpCaptureVM(ICaptureService captureService, ICustomEncoderVM customEncoderVM)
	{
		_captureService = captureService;
		CustomEncoderVM = customEncoderVM;
		LinkAction("Stream", NotifyPropertyChanged);
		LinkProperties("Encoding", "Encoder");
		_captureService.PropertyChanged += base.RaiseLinkedValues;
		_captureService.StreamPropertyChanged += NotifyPropertyChanged;
		if (_captureService.Stream != null)
		{
			_captureService.Stream.DestinationChanged += OnDestinationTypeChanged;
			_captureService.Stream.Encoder.PropertyChanged += base.RaiseLinkedValues;
		}
		if (DiskDestination != null && (DiskDestination.Location.IsEmpty || !DiskDestination.Location.IsValid))
		{
			DiskDestination.Location = new RelativePath(CommonPaths.VideosFolder, isDirectory: true);
		}
		_saveToLocation = DiskDestination?.Location ?? RelativePath.Empty();
		_customSaveLocation = _saveToLocation;
		IStream? stream = Stream;
		if (stream != null && stream.DestinationType == DestinationType.RTMP)
		{
			_lastUsedAddress = Address;
			_lastUsedKey = Key;
			_lastSaveLocalCopyValue = SaveLocalCopy;
			if ((object)Encoder != null)
			{
				_lastUsedEncoder = Encoder;
			}
		}
	}

	private void OnDestinationTypeChanged(DestinationType destinationType)
	{
		if (destinationType == DestinationType.RTMP)
		{
			Address = _lastUsedAddress;
			Key = _lastUsedKey;
			Encoder = _lastUsedEncoder;
			SaveLocalCopy = _lastSaveLocalCopyValue;
			if (string.IsNullOrEmpty(SaveToLocation))
			{
				RelativePath saveToLocation = _saveToLocation;
				SaveToLocation = (((object)saveToLocation != null && saveToLocation.IsValid) ? _saveToLocation : new RelativePath(CommonPaths.VideosFolder, isDirectory: true));
			}
		}
	}

	private void NotifyPropertyChanged()
	{
		OnPropertyChanged("Address");
		OnPropertyChanged("Key");
		OnPropertyChanged("Encoder");
		OnPropertyChanged("SaveLocalCopy");
		OnPropertyChanged("SaveToLocation");
		OnPropertyChanged("DefaultSaveToLocations");
	}

	private void OnSaveToLocationCommand()
	{
		if (DialogHelper.SelectFolderPath(out string selectedPath))
		{
			SaveToLocation = new RelativePath(selectedPath, isDirectory: true);
		}
	}

	private void OnSelectDefaultLocationCommand(RelativePath folder)
	{
		SaveToLocation = folder;
	}

	private void SelectEncoderCommandExecuted(Encoder encoder)
	{
		Encoder = encoder;
	}

	private void SelectCustomEncoderCommandExecuted()
	{
		if (CustomEncoderVM.TryGetCustomEncoder(DestinationType.RTMP, out Encoder encoder, Encoder))
		{
			Encoder = encoder;
		}
	}
}
