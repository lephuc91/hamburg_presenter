using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.LiveVideo;

namespace ProPresenter.DO.Media.Properties;

public class LiveVideoProperties : NotifyPropertyChangedBase, ICloneable<LiveVideoProperties>
{
	private int _inputIndex = -1;

	private LiveVideoInput? _input;

	private readonly ILiveVideoInputCollection? _videoInputs;

	public LiveVideoInput? Input
	{
		get
		{
			if (_input == null)
			{
				_input = _videoInputs?.ElementAtOrDefault(_inputIndex);
				if (_input != null)
				{
					this.VideoInputChanged?.Invoke(null, _input);
					_input.PropertyChanged += _input_PropertyChanged;
				}
			}
			return _input;
		}
		set
		{
			SetValue<LiveVideoInput>("Input", ref _input, value, delegate(LiveVideoInput o, LiveVideoInput n)
			{
				UndoStack?.Commit(UndoActionTypes.ActionSetVideoInput.ToAction(), this, "Input", o, n);
				if (o != null)
				{
					o.PropertyChanged -= _input_PropertyChanged;
				}
				if (n != null)
				{
					n.UndoStack = UndoStack;
					n.PropertyChanged += _input_PropertyChanged;
				}
				_inputIndex = n?.Index ?? (-1);
				OnDataModified();
				this.VideoInputChanged?.Invoke(o, n);
			});
		}
	}

	public UndoStack? UndoStack { get; set; }

	public event System.Action? DataModified;

	public event Action<LiveVideoInput?, LiveVideoInput?>? VideoInputChanged;

	public event System.Action? DeviceConnectedChanged;

	public static ObjectBinder<LiveVideoProperties, IMedia.Types.ILiveVideoProperties> CreateBinder(LiveVideoProperties left, IMedia.Types.ILiveVideoProperties right)
	{
		ObjectBinder<LiveVideoProperties, IMedia.Types.ILiveVideoProperties> objectBinder = new ObjectBinder<LiveVideoProperties, IMedia.Types.ILiveVideoProperties>(left, right);
		objectBinder.Bind((LiveVideoProperties l) => l.WhenPropertyChanges("Input"), (IMedia.Types.ILiveVideoProperties r) => r.LiveVideoIndex.WhenValueChanges, delegate(LiveVideoProperties l, IMedia.Types.ILiveVideoProperties r)
		{
			r.LiveVideoIndex.Set(l.Input?.Index ?? l._inputIndex);
		}, delegate(IMedia.Types.ILiveVideoProperties r, LiveVideoProperties l)
		{
			if (l._input != null)
			{
				l._input.PropertyChanged -= l._input_PropertyChanged;
			}
			l._inputIndex = r.LiveVideoIndex.Value;
			l._input = null;
			l.OnPropertyChanged("Input");
			l.OnDataModified();
		});
		return objectBinder;
	}

	private void _input_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "IsDeviceConnected")
		{
			this.DeviceConnectedChanged?.Invoke();
		}
	}

	public LiveVideoProperties(ILiveVideoInputCollection? videoInputs)
	{
		_videoInputs = videoInputs;
		if (_videoInputs != null)
		{
			_videoInputs.CollectionChanged += AvailableLiveVideoInputs_CollectionChanged;
		}
	}

	private void AvailableLiveVideoInputs_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		if (sender is ILiveVideoInputCollection source)
		{
			LiveVideoInput input = _input;
			_input = source.ElementAtOrDefault(_inputIndex);
			if (input != _input)
			{
				OnPropertyChanged("Input");
				OnDataModified();
				this.VideoInputChanged?.Invoke(input, _input);
			}
		}
	}

	public LiveVideoProperties Clone()
	{
		return new LiveVideoProperties(_videoInputs)
		{
			_input = _input,
			_inputIndex = _inputIndex
		};
	}

	private void OnDataModified()
	{
		this.DataModified?.Invoke();
	}

	internal Pro.SerializationInterop.RVProtoData.Media.Types.LiveVideoProperties Serialize()
	{
		return new Pro.SerializationInterop.RVProtoData.Media.Types.LiveVideoProperties
		{
			LiveVideoIndex = _inputIndex
		};
	}

	internal void Deserialize(Pro.SerializationInterop.RVProtoData.Media.Types.LiveVideoProperties liveVideo)
	{
		if (liveVideo.LiveVideoIndex >= 0)
		{
			_input = null;
			_inputIndex = liveVideo.LiveVideoIndex;
		}
	}
}
