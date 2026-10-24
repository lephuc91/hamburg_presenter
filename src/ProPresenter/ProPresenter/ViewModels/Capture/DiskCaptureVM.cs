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

namespace ProPresenter.ViewModels.Capture;

public class DiskCaptureVM : LinkedNotifyPropertyChangedBase, IDiskCaptureVM, INotifyPropertyChanged
{
	[CompilerGenerated]
	private sealed class _003Cget_DefaultFolders_003Ed__11 : IEnumerable<RelativePath>, IEnumerable, IEnumerator<RelativePath>, IEnumerator, IDisposable
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
		public _003Cget_DefaultFolders_003Ed__11(int _003C_003E1__state)
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
			return new _003Cget_DefaultFolders_003Ed__11(0);
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<RelativePath>)this).GetEnumerator();
		}
	}

	[CompilerGenerated]
	private sealed class _003Cget_DefaultSaveToLocations_003Ed__16 : IEnumerable<RelativePath>, IEnumerable, IEnumerator<RelativePath>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private RelativePath _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		public DiskCaptureVM _003C_003E4__this;

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
		public _003Cget_DefaultSaveToLocations_003Ed__16(int _003C_003E1__state)
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
				DiskCaptureVM CS_0024_003C_003E8__locals5 = _003C_003E4__this;
				switch (num)
				{
				default:
					return false;
				case 0:
					_003C_003E1__state = -1;
					if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals5._customSaveLocation) && !CS_0024_003C_003E8__locals5.DefaultFolders.Any((RelativePath f) => f == CS_0024_003C_003E8__locals5._customSaveLocation))
					{
						_003C_003E2__current = CS_0024_003C_003E8__locals5._customSaveLocation;
						_003C_003E1__state = 1;
						return true;
					}
					goto IL_0077;
				case 1:
					_003C_003E1__state = -1;
					goto IL_0077;
				case 2:
					{
						_003C_003E1__state = -3;
						break;
					}
					IL_0077:
					_003C_003E7__wrap1 = CS_0024_003C_003E8__locals5.DefaultFolders.GetEnumerator();
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
			_003Cget_DefaultSaveToLocations_003Ed__16 result;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				result = this;
			}
			else
			{
				result = new _003Cget_DefaultSaveToLocations_003Ed__16(0)
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

	private readonly ICustomEncoderVM _customEncoderVM;

	private RelativePath _customSaveLocation;

	private RelativePath _saveToLocation = RelativePath.Empty();

	private Codec _lastUsedCodeccodec = Codec.H264;

	private Encoder _lastUsedEncoder = ProPresenter.DO.Capture.Encoder.DiskDefault;

	private IStream? Stream => _captureService.Stream;

	private DiskDestination? DiskDestination => Stream?.OfType<DiskDestination>().FirstOrDefault();

	private IEnumerable<RelativePath> DefaultFolders
	{
		[IteratorStateMachine(typeof(_003Cget_DefaultFolders_003Ed__11))]
		get
		{
			//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
			return new _003Cget_DefaultFolders_003Ed__11(-2);
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
		[IteratorStateMachine(typeof(_003Cget_DefaultSaveToLocations_003Ed__16))]
		get
		{
			//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
			return new _003Cget_DefaultSaveToLocations_003Ed__16(-2)
			{
				_003C_003E4__this = this
			};
		}
	}

	public Codec Codec
	{
		get
		{
			return Stream?.Encoder.Codec ?? Codec.Automatic;
		}
		set
		{
			if (Stream != null)
			{
				Stream.Encoder.Codec = value;
				_lastUsedCodeccodec = value;
			}
		}
	}

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

	public IEnumerable<Codec> Codecs => _captureService.GetAvailableCodecs(DestinationType.Disk);

	public AudioMap<Bus, StreamAudioChannel>? AudioOutputMap => Stream?.AudioOutputMap;

	public ICommand<RelativePath> SelectDefaultLocationCommand => new RelayCommand<RelativePath>(OnSelectDefaultLocationCommand);

	public ICommand SaveToOtherLocationCommand => new RelayCommand(OnSaveToLocationCommand);

	public ICommand<Encoder> SelectEncoderCommand => new RelayCommand<Encoder>(SelectEncoderCommandExecuted, (Encoder e) => e != null);

	public ICommand SelectCustomEncoderCommand => new RelayCommand(SelectCustomEncoderCommandExecuted);

	public DiskCaptureVM(ICaptureService captureService, ICustomEncoderVM customEncoderVM)
	{
		_captureService = captureService;
		_customEncoderVM = customEncoderVM;
		LinkAction("Stream", NotifyPropertyChanged);
		_captureService.PropertyChanged += base.RaiseLinkedValues;
		_captureService.StreamPropertyChanged += NotifyPropertyChanged;
		if (_captureService.Stream != null)
		{
			_captureService.Stream.DestinationChanged += OnDestinationTypeChanged;
		}
		if (DiskDestination != null && (DiskDestination.Location.IsEmpty || !DiskDestination.Location.IsValid))
		{
			DiskDestination.Location = new RelativePath(CommonPaths.VideosFolder, isDirectory: true);
		}
		_saveToLocation = DiskDestination?.Location ?? RelativePath.Empty();
		_customSaveLocation = _saveToLocation;
		IStream? stream = Stream;
		if (stream != null && stream.DestinationType == DestinationType.Disk)
		{
			_lastUsedCodeccodec = Codec;
			if ((object)Encoder != null)
			{
				_lastUsedEncoder = Encoder;
			}
		}
	}

	private void OnDestinationTypeChanged(DestinationType destinationType)
	{
		IStream? stream = Stream;
		if (stream != null && stream.DestinationType == DestinationType.Disk)
		{
			Codec = _lastUsedCodeccodec;
			Encoder = _lastUsedEncoder;
			if (string.IsNullOrEmpty(SaveToLocation))
			{
				RelativePath saveToLocation = _saveToLocation;
				SaveToLocation = (((object)saveToLocation != null && saveToLocation.IsValid) ? _saveToLocation : new RelativePath(CommonPaths.VideosFolder, isDirectory: true));
			}
		}
	}

	private void NotifyPropertyChanged()
	{
		OnPropertyChanged("SaveToLocation");
		OnPropertyChanged("DefaultSaveToLocations");
		OnPropertyChanged("Codec");
		OnPropertyChanged("Encoder");
	}

	private void OnSelectDefaultLocationCommand(RelativePath folder)
	{
		SaveToLocation = folder;
	}

	private void OnSaveToLocationCommand()
	{
		if (DialogHelper.SelectFolderPath(out string selectedPath))
		{
			SaveToLocation = new RelativePath(selectedPath, isDirectory: true);
		}
	}

	private void SelectEncoderCommandExecuted(Encoder encoder)
	{
		Encoder = encoder;
	}

	private void SelectCustomEncoderCommandExecuted()
	{
		if (_customEncoderVM.TryGetCustomEncoder(DestinationType.Disk, out Encoder encoder, Encoder))
		{
			Encoder = encoder;
		}
	}
}
