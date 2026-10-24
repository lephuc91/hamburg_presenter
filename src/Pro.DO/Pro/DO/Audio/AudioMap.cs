using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reactive.Linq;
using System.Runtime.CompilerServices;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Dispatcher;
using Pro.Common.ObjectBinding;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Common.Utility;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.SerializationInterop.RVProtoData;

namespace Pro.DO.Audio;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { })]
public class AudioMap<I, O> : NotifyPropertyChangedBase, IAudioMap<I, O>, IDisposable where I : IChannel, new() where O : IChannel, new()
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass1_0<S, D> where S : notnull, IChannel, new() where D : notnull, IChannel, new()
	{
		public Func<S, D, bool> isMapped;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass1_1<S, D> where S : notnull, IChannel, new() where D : notnull, IChannel, new()
	{
		public S sc;

		public _003C_003Ec__DisplayClass1_0<S, D> CS_0024_003C_003E8__locals1;

		internal bool _003CSerializeToEntity_003Eb__0(D dc)
		{
			return CS_0024_003C_003E8__locals1.isMapped(sc, dc);
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass45_0<S, D> where S : notnull, IChannel, new() where D : notnull, IChannel, new()
	{
		public Func<S, D, bool> isMapped;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass45_1<S, D> where S : notnull, IChannel, new() where D : notnull, IChannel, new()
	{
		public S sc;

		public _003C_003Ec__DisplayClass45_0<S, D> CS_0024_003C_003E8__locals1;

		internal bool _003CSerialize_003Eb__0(D dc)
		{
			return CS_0024_003C_003E8__locals1.isMapped(sc, dc);
		}
	}

	[CompilerGenerated]
	private sealed class _003CSerialize_003Ed__45<S, D> : IEnumerable<DigitalAudio.Types.Device.Types.Map>, IEnumerable, IEnumerator<DigitalAudio.Types.Device.Types.Map>, IEnumerator, IDisposable where S : notnull, IChannel, new() where D : notnull, IChannel, new()
	{
		private int _003C_003E1__state;

		private DigitalAudio.Types.Device.Types.Map _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private Func<S, D, bool> isMapped;

		public Func<S, D, bool> _003C_003E3__isMapped;

		private ChannelSet<S> source;

		public ChannelSet<S> _003C_003E3__source;

		private _003C_003Ec__DisplayClass45_0<S, D> _003C_003E8__1;

		private ChannelSet<D> destination;

		public ChannelSet<D> _003C_003E3__destination;

		private IEnumerator<S> _003C_003E7__wrap1;

		DigitalAudio.Types.Device.Types.Map IEnumerator<DigitalAudio.Types.Device.Types.Map>.Current
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
		public _003CSerialize_003Ed__45(int _003C_003E1__state)
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
			_003C_003E8__1 = null;
			_003C_003E7__wrap1 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			try
			{
				switch (_003C_003E1__state)
				{
				default:
					return false;
				case 0:
					_003C_003E1__state = -1;
					_003C_003E8__1 = new _003C_003Ec__DisplayClass45_0<S, D>();
					_003C_003E8__1.isMapped = isMapped;
					_003C_003E7__wrap1 = source.GetEnumerator();
					_003C_003E1__state = -3;
					break;
				case 1:
					_003C_003E1__state = -3;
					break;
				}
				while (_003C_003E7__wrap1.MoveNext())
				{
					_003C_003Ec__DisplayClass45_1<S, D> CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass45_1<S, D>
					{
						CS_0024_003C_003E8__locals1 = _003C_003E8__1,
						sc = _003C_003E7__wrap1.Current
					};
					IEnumerable<uint> values = from dc in destination
						where CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals1.isMapped(CS_0024_003C_003E8__locals3.sc, dc)
						select dc into c
						select (uint)c.Index;
					if (!values.Empty())
					{
						DigitalAudio.Types.Device.Types.Map map = new DigitalAudio.Types.Device.Types.Map
						{
							ChannelIndex = (uint)CS_0024_003C_003E8__locals3.sc.Index
						};
						map.MappedIndices.AddRange(values);
						_003C_003E2__current = map;
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
		IEnumerator<DigitalAudio.Types.Device.Types.Map> IEnumerable<DigitalAudio.Types.Device.Types.Map>.GetEnumerator()
		{
			_003CSerialize_003Ed__45<S, D> _003CSerialize_003Ed__;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				_003CSerialize_003Ed__ = this;
			}
			else
			{
				_003CSerialize_003Ed__ = new _003CSerialize_003Ed__45<S, D>(0);
			}
			_003CSerialize_003Ed__.source = _003C_003E3__source;
			_003CSerialize_003Ed__.destination = _003C_003E3__destination;
			_003CSerialize_003Ed__.isMapped = _003C_003E3__isMapped;
			return _003CSerialize_003Ed__;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<DigitalAudio.Types.Device.Types.Map>)this).GetEnumerator();
		}
	}

	[CompilerGenerated]
	private sealed class _003CSerializeToEntity_003Ed__1<S, D> : IEnumerable<IDigitalAudio.Types.IDevice.Types.IMap>, IEnumerable, IEnumerator<IDigitalAudio.Types.IDevice.Types.IMap>, IEnumerator, IDisposable where S : notnull, IChannel, new() where D : notnull, IChannel, new()
	{
		private int _003C_003E1__state;

		private IDigitalAudio.Types.IDevice.Types.IMap _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private Func<S, D, bool> isMapped;

		public Func<S, D, bool> _003C_003E3__isMapped;

		private ChannelSet<S> source;

		public ChannelSet<S> _003C_003E3__source;

		private _003C_003Ec__DisplayClass1_0<S, D> _003C_003E8__1;

		private ChannelSet<D> destination;

		public ChannelSet<D> _003C_003E3__destination;

		private IEntityFactory entityFactory;

		public IEntityFactory _003C_003E3__entityFactory;

		private IEnumerator<S> _003C_003E7__wrap1;

		IDigitalAudio.Types.IDevice.Types.IMap IEnumerator<IDigitalAudio.Types.IDevice.Types.IMap>.Current
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
		public _003CSerializeToEntity_003Ed__1(int _003C_003E1__state)
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
			_003C_003E8__1 = null;
			_003C_003E7__wrap1 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			try
			{
				switch (_003C_003E1__state)
				{
				default:
					return false;
				case 0:
					_003C_003E1__state = -1;
					_003C_003E8__1 = new _003C_003Ec__DisplayClass1_0<S, D>();
					_003C_003E8__1.isMapped = isMapped;
					_003C_003E7__wrap1 = source.GetEnumerator();
					_003C_003E1__state = -3;
					break;
				case 1:
					_003C_003E1__state = -3;
					break;
				}
				while (_003C_003E7__wrap1.MoveNext())
				{
					_003C_003Ec__DisplayClass1_1<S, D> CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass1_1<S, D>
					{
						CS_0024_003C_003E8__locals1 = _003C_003E8__1,
						sc = _003C_003E7__wrap1.Current
					};
					IEnumerable<uint> items = from dc in destination
						where CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals1.isMapped(CS_0024_003C_003E8__locals3.sc, dc)
						select dc into c
						select (uint)c.Index;
					if (items.Any())
					{
						IDigitalAudio.Types.IDevice.Types.IMap map = entityFactory.Create<IDigitalAudio.Types.IDevice.Types.IMap>();
						map.ChannelIndex.Set((uint)CS_0024_003C_003E8__locals3.sc.Index);
						map.MappedIndices.AddRange(items);
						_003C_003E2__current = map;
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
		IEnumerator<IDigitalAudio.Types.IDevice.Types.IMap> IEnumerable<IDigitalAudio.Types.IDevice.Types.IMap>.GetEnumerator()
		{
			_003CSerializeToEntity_003Ed__1<S, D> _003CSerializeToEntity_003Ed__;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				_003CSerializeToEntity_003Ed__ = this;
			}
			else
			{
				_003CSerializeToEntity_003Ed__ = new _003CSerializeToEntity_003Ed__1<S, D>(0);
			}
			_003CSerializeToEntity_003Ed__.entityFactory = _003C_003E3__entityFactory;
			_003CSerializeToEntity_003Ed__.source = _003C_003E3__source;
			_003CSerializeToEntity_003Ed__.destination = _003C_003E3__destination;
			_003CSerializeToEntity_003Ed__.isMapped = _003C_003E3__isMapped;
			return _003CSerializeToEntity_003Ed__;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<IDigitalAudio.Types.IDevice.Types.IMap>)this).GetEnumerator();
		}
	}

	private bool[,] _audioMap = new bool[0, 0];

	private bool _isCustomMap = true;

	private bool? _previousIsCustomMap;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public ChannelSet<I> InputSet { get; }

	public ChannelSet<O> OutputSet { get; }

	private IEnumerable<IChannel> AllChannels => InputSet.Cast<IChannel>().Concat(OutputSet.Cast<IChannel>());

	public bool MuteActive
	{
		get
		{
			return AllChannels.Any((IChannel c) => c.MuteActive);
		}
		set
		{
			AllChannels.ForEach(delegate(IChannel c)
			{
				c.MuteActive = value;
			});
			OnPropertyChanged("MuteActive");
		}
	}

	public bool SoloActive
	{
		get
		{
			return AllChannels.Any((IChannel c) => c.SoloActive);
		}
		set
		{
			AllChannels.ForEach(delegate(IChannel c)
			{
				c.SoloActive = value;
			});
			OnPropertyChanged("SoloActive");
		}
	}

	public bool IsCustomMap
	{
		get
		{
			return _isCustomMap;
		}
		private set
		{
			SetValue("IsCustomMap", ref _isCustomMap, value);
		}
	}

	public event System.Action? MapInvalidated;

	public event Action<bool>? IsCustomMapChanged;

	public static ObjectBinder<AudioMap<I, O>, IRecording.Types.IStream> CreateBinder(IUiScheduler scheduler, IEntityFactory entityFactory, AudioMap<I, O> left, IRecording.Types.IStream right, bool inputToOutput)
	{
		ObjectBinder<AudioMap<I, O>, IRecording.Types.IStream> objectBinder = new ObjectBinder<AudioMap<I, O>, IRecording.Types.IStream>(left, right);
		objectBinder.Bind((AudioMap<I, O> l) => Observable.FromEvent(delegate(System.Action h)
		{
			l.MapInvalidated += h;
		}, delegate(System.Action h)
		{
			l.MapInvalidated -= h;
		}), (IRecording.Types.IStream r) => r.AudioMap.WhenCollectionChanges.ToUnit().Merge(r.IsAudioCustomMapped.WhenValueChanges.ToUnit()), delegate(AudioMap<I, O> l, IRecording.Types.IStream r)
		{
			r.IsAudioCustomMapped.Set(l.IsCustomMap);
			if (inputToOutput)
			{
				r.AudioMap.Reset(SerializeToEntity(entityFactory, l.InputSet, l.OutputSet, (I sc, O dc) => l.IsMapped(sc, dc)));
			}
			else
			{
				r.AudioMap.Reset(SerializeToEntity(entityFactory, l.OutputSet, l.InputSet, (O sc, I dc) => l.IsMapped(dc, sc)));
			}
		}, delegate(IRecording.Types.IStream r, AudioMap<I, O> l)
		{
			l.ClearMap();
			if (r.IsAudioCustomMapped.Value)
			{
				if (inputToOutput)
				{
					Deserialize(r.AudioMap.Items, l.InputSet, l.OutputSet, l.ToggleOn);
				}
				else
				{
					Deserialize(r.AudioMap.Items, l.OutputSet, l.InputSet, delegate(O sc, I dc)
					{
						l.ToggleOn(dc, sc);
					});
				}
			}
			else
			{
				l.AutoMap();
			}
		}, null, scheduler.Scheduler);
		return objectBinder;
	}

	[IteratorStateMachine(typeof(_003CSerializeToEntity_003Ed__1<, >))]
	private static IEnumerable<IDigitalAudio.Types.IDevice.Types.IMap> SerializeToEntity<S, D>(IEntityFactory entityFactory, ChannelSet<S> source, ChannelSet<D> destination, Func<S, D, bool> isMapped) where S : IChannel, new() where D : IChannel, new()
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CSerializeToEntity_003Ed__1<S, D>(-2)
		{
			_003C_003E3__entityFactory = entityFactory,
			_003C_003E3__source = source,
			_003C_003E3__destination = destination,
			_003C_003E3__isMapped = isMapped
		};
	}

	private static void Deserialize<S, D>(IEnumerable<IDigitalAudio.Types.IDevice.Types.IMap> entityMaps, ChannelSet<S> source, ChannelSet<D> destination, Action<S, D> toggleOn) where S : IChannel, new() where D : IChannel, new()
	{
		foreach (IDigitalAudio.Types.IDevice.Types.IMap entityMap in entityMaps)
		{
			S val = source.ElementAtOrDefault((int)entityMap.ChannelIndex.Value);
			if (val == null)
			{
				continue;
			}
			foreach (uint item in entityMap.MappedIndices.Items)
			{
				D val2 = destination.ElementAtOrDefault((int)item);
				if (val2 != null)
				{
					toggleOn(val, val2);
				}
			}
		}
	}

	public AudioMap(ChannelSet<I> inputSet, ChannelSet<O> outputSet)
	{
		if (inputSet == null || outputSet == null)
		{
			throw new InvalidOperationException();
		}
		InputSet = inputSet;
		OutputSet = outputSet;
		CollectionChangedEventManager.AddHandler((INotifyCollectionChanged)InputSet, (EventHandler<NotifyCollectionChangedEventArgs>)InputOrOutput_CollectionChanged);
		CollectionChangedEventManager.AddHandler((INotifyCollectionChanged)OutputSet, (EventHandler<NotifyCollectionChangedEventArgs>)InputOrOutput_CollectionChanged);
		AutoMap();
		AllChannels.ForEach(AddPropertyLinks);
	}

	private void AddPropertyLinks(IChannel channel)
	{
		PropertyChangedEventManager.AddHandler((INotifyPropertyChanged)channel, (EventHandler<PropertyChangedEventArgs>)RaisePropertyChanged, "MuteActive");
		PropertyChangedEventManager.AddHandler((INotifyPropertyChanged)channel, (EventHandler<PropertyChangedEventArgs>)RaisePropertyChanged, "SoloActive");
	}

	private void RemovePropertyLinks(IChannel channel)
	{
		PropertyChangedEventManager.RemoveHandler((INotifyPropertyChanged)channel, (EventHandler<PropertyChangedEventArgs>)RaisePropertyChanged, "MuteActive");
		PropertyChangedEventManager.RemoveHandler((INotifyPropertyChanged)channel, (EventHandler<PropertyChangedEventArgs>)RaisePropertyChanged, "SoloActive");
	}

	private void RaisePropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		string propertyName = e.PropertyName;
		if (!(propertyName == "MuteActive"))
		{
			if (propertyName == "SoloActive")
			{
				OnPropertyChanged("SoloActive");
			}
		}
		else
		{
			OnPropertyChanged("MuteActive");
		}
	}

	private void StoreCustomMap()
	{
		if (_previousIsCustomMap.HasValue)
		{
			throw new InvalidOperationException();
		}
		_previousIsCustomMap = IsCustomMap;
	}

	private void InvalidateMap()
	{
		this.MapInvalidated?.Invoke();
		if (_previousIsCustomMap.HasValue && _previousIsCustomMap.HasValue != IsCustomMap)
		{
			this.IsCustomMapChanged?.Invoke(IsCustomMap);
		}
		_previousIsCustomMap = null;
	}

	public bool IsMapped(I input, O output)
	{
		if (!InputSet.Contains(input) || !OutputSet.Contains(output) || input.Index >= _audioMap?.GetLength(0) || output.Index >= _audioMap?.GetLength(1))
		{
			return false;
		}
		if (_audioMap != null)
		{
			return _audioMap[input.Index, output.Index];
		}
		return false;
	}

	public void Toggle(I input, O output)
	{
		Toggle(input, output, null);
	}

	public void ToggleOn(I input, O output)
	{
		Toggle(input, output, true);
	}

	public void ToggleOff(I input, O output)
	{
		Toggle(input, output, false);
	}

	public void AutoMap()
	{
		StoreCustomMap();
		_audioMap = new bool[InputSet.ChannelCount, OutputSet.ChannelCount];
		if (InputSet.ChannelCount > 0 && OutputSet.ChannelCount > 0)
		{
			if (InputSet.ChannelCount == 1)
			{
				for (int i = 0; i < Math.Min(OutputSet.ChannelCount, 2); i++)
				{
					_audioMap[0, i] = true;
				}
			}
			else
			{
				for (int j = 0; j < InputSet.ChannelCount; j++)
				{
					_audioMap[j, j % OutputSet.ChannelCount] = true;
				}
			}
		}
		IsCustomMap = false;
		InvalidateMap();
	}

	public void ClearMap()
	{
		StoreCustomMap();
		_audioMap = new bool[InputSet.ChannelCount, OutputSet.ChannelCount];
		IsCustomMap = true;
		InvalidateMap();
	}

	public void CopyFrom(IAudioMap<I, O>? sourceMap)
	{
		if (sourceMap is AudioMap<I, O> audioMap)
		{
			for (int i = 0; i < _audioMap.GetLength(0); i++)
			{
				if (i >= audioMap._audioMap.GetLength(0))
				{
					continue;
				}
				for (int j = 0; j < _audioMap.GetLength(1); j++)
				{
					if (j < audioMap._audioMap.GetLength(1))
					{
						_audioMap[i, j] = audioMap._audioMap[i, j];
					}
				}
			}
			IsCustomMap = audioMap.IsCustomMap;
		}
		InvalidateMap();
	}

	private void Toggle(I input, O output, bool? value)
	{
		StoreCustomMap();
		if (!InputSet.Contains(input) || !OutputSet.Contains(output))
		{
			throw new ArgumentException("input/output value must exist in the Input/Output set");
		}
		if (_audioMap != null)
		{
			_audioMap[input.Index, output.Index] = value ?? (!_audioMap[input.Index, output.Index]);
		}
		IsCustomMap = true;
		InvalidateMap();
	}

	private void InputOrOutput_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs args)
	{
		args.OldItems?.Cast<IChannel>().ForEach(RemovePropertyLinks);
		if (InputSet.ChannelCount == 0 || OutputSet.ChannelCount == 0)
		{
			return;
		}
		if (IsCustomMap)
		{
			bool[,] audioMap = _audioMap;
			ClearMap();
			if (_audioMap != null && audioMap != null)
			{
				for (int i = 0; i < Math.Min(_audioMap.GetLength(0), audioMap.GetLength(0)); i++)
				{
					for (int j = 0; j < Math.Min(_audioMap.GetLength(1), audioMap.GetLength(1)); j++)
					{
						_audioMap[i, j] = audioMap[i, j];
					}
				}
			}
		}
		else
		{
			AutoMap();
		}
		args.NewItems?.Cast<IChannel>().ForEach(AddPropertyLinks);
		InvalidateMap();
	}

	public IEnumerable<DigitalAudio.Types.Device.Types.Map> Serialize(bool inputToOutput)
	{
		if (inputToOutput)
		{
			return Serialize(InputSet, OutputSet, IsMapped);
		}
		return Serialize(OutputSet, InputSet, (O sc, I dc) => IsMapped(dc, sc));
	}

	[IteratorStateMachine(typeof(_003CSerialize_003Ed__45<, >))]
	private IEnumerable<DigitalAudio.Types.Device.Types.Map> Serialize<S, D>(ChannelSet<S> source, ChannelSet<D> destination, Func<S, D, bool> isMapped) where S : IChannel, new() where D : IChannel, new()
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CSerialize_003Ed__45<S, D>(-2)
		{
			_003C_003E3__source = source,
			_003C_003E3__destination = destination,
			_003C_003E3__isMapped = isMapped
		};
	}

	public void Deserialize(IEnumerable<DigitalAudio.Types.Device.Types.Map> protoMaps, bool isCustomMap, bool inputToOutput)
	{
		if (isCustomMap)
		{
			ClearMap();
			if (inputToOutput)
			{
				Deserialize(protoMaps, InputSet, OutputSet, ToggleOn);
				return;
			}
			Deserialize(protoMaps, OutputSet, InputSet, delegate(O sc, I dc)
			{
				ToggleOn(dc, sc);
			});
		}
		else
		{
			AutoMap();
		}
	}

	private static void Deserialize<S, D>(IEnumerable<DigitalAudio.Types.Device.Types.Map> protoMaps, ChannelSet<S> source, ChannelSet<D> destination, Action<S, D> toggleOn) where S : IChannel, new() where D : IChannel, new()
	{
		foreach (DigitalAudio.Types.Device.Types.Map protoMap in protoMaps)
		{
			S val = source.ElementAtOrDefault((int)protoMap.ChannelIndex);
			if (val == null)
			{
				continue;
			}
			foreach (uint mappedIndex in protoMap.MappedIndices)
			{
				D val2 = destination.ElementAtOrDefault((int)mappedIndex);
				if (val2 != null)
				{
					toggleOn(val, val2);
				}
			}
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	protected virtual void Dispose(bool disposing)
	{
		if (!_disposed && disposing)
		{
			_disposed = true;
			OnDispose();
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void OnDispose()
	{
		AllChannels.ForEach(delegate(IChannel c)
		{
			RemovePropertyLinks(c);
		});
	}
}
