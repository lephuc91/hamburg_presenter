using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.Mathematics;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.DO.Audio;
using Pro.DO.Effects.Descriptions;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.LiveVideo;
using ProPresenter.DO.Media.Properties;

namespace ProPresenter.DO.Media;

public class LiveVideoMedia : MediaBase, IDrawMedia, IAudioMedia, ILiveVideoMedia
{
	private const int DefaultAudioChannelCount = 16;

	private readonly ILiveVideoInputCollection _videoInputs;

	public override MediaType MediaType => MediaType.LiveVideo;

	public AudioProperties Audio { get; }

	public DrawingProperties Drawing { get; }

	public LiveVideoProperties LiveVideo { get; }

	public override bool IsValid
	{
		get
		{
			if (LiveVideo.Input != null)
			{
				ILiveVideoInputCollection videoInputs = _videoInputs;
				if (videoInputs != null && videoInputs.Any((LiveVideoInput v) => v.Index == LiveVideo.Input.Index))
				{
					return LiveVideo.Input.IsDeviceConnected;
				}
			}
			return false;
		}
	}

	public bool SupportsScaleAndBlur => true;

	public bool SupportsCustomScale => false;

	public override ObjectBinder<MediaBase, IMedia> CreateBinder(IUiScheduler scheduler, IEntityFactory entityFactory, IMedia right)
	{
		IMedia.Types.ITypeProperties.ILiveVideo liveVideo = right.TypeProperties.Value as IMedia.Types.ITypeProperties.ILiveVideo;
		if (liveVideo == null)
		{
			liveVideo = entityFactory.Create<IMedia.Types.ITypeProperties.ILiveVideo>();
			right.TypeProperties.Set(liveVideo);
		}
		ObjectBinder<LiveVideoMedia, IMedia.Types.ILiveVideoTypeProperties> liveVideoMediaBinder = new ObjectBinder<LiveVideoMedia, IMedia.Types.ILiveVideoTypeProperties>(this, liveVideo.Value);
		liveVideoMediaBinder.Bind((LiveVideoMedia l) => l.WhenPropertyChanges("Audio"), (IMedia.Types.ILiveVideoTypeProperties r) => r.Audio.WhenValueChanges, delegate(LiveVideoMedia l, IMedia.Types.ILiveVideoTypeProperties r)
		{
			r.Audio.Set(l.Audio.HandleAudioPropertiesModelChange(scheduler, entityFactory));
		}, delegate(IMedia.Types.ILiveVideoTypeProperties r, LiveVideoMedia l)
		{
			l.Audio.HandleAudioPropertiesCrdtChange(r.Audio.Value, scheduler, entityFactory);
		}).Bind((LiveVideoMedia l) => l.WhenPropertyChanges("Drawing"), (IMedia.Types.ILiveVideoTypeProperties r) => r.Drawing.WhenValueChanges, delegate(LiveVideoMedia l, IMedia.Types.ILiveVideoTypeProperties r)
		{
			r.Drawing.Set(l.Drawing.HandleDrawingPropertiesModelChange(scheduler, entityFactory));
		}, delegate(IMedia.Types.ILiveVideoTypeProperties r, LiveVideoMedia l)
		{
			l.Drawing.HandleDrawingPropertiesCrdtChange(r.Drawing.Value, scheduler, entityFactory);
		}).Bind((LiveVideoMedia l) => l.WhenPropertyChanges("LiveVideo"), (IMedia.Types.ILiveVideoTypeProperties r) => r.LiveVideo.WhenValueChanges, delegate(LiveVideoMedia l, IMedia.Types.ILiveVideoTypeProperties r)
		{
			IMedia.Types.ILiveVideoProperties liveVideoProperties = entityFactory.Create<IMedia.Types.ILiveVideoProperties>();
			r.LiveVideo.Set(liveVideoProperties);
			ObjectBinder<LiveVideoProperties, IMedia.Types.ILiveVideoProperties> objectBinder = LiveVideoProperties.CreateBinder(l.LiveVideo, liveVideoProperties);
			objectBinder.InitializeRightFromLeft();
			liveVideoProperties.RegisterLinkedDisposable(objectBinder);
		}, delegate(IMedia.Types.ILiveVideoTypeProperties r, LiveVideoMedia l)
		{
			ObjectBinder<LiveVideoProperties, IMedia.Types.ILiveVideoProperties> objectBinder2 = LiveVideoProperties.CreateBinder(l.LiveVideo, r.LiveVideo.Value);
			objectBinder2.InitializeLeftFromRight();
			r.LiveVideo.Value.RegisterLinkedDisposable(objectBinder2);
		});
		ObjectBinder<MediaBase, IMedia> objectBinder3 = base.CreateBinder(scheduler, entityFactory, right);
		objectBinder3.DoOnInitializeLeftFromRight(liveVideoMediaBinder.InitializeLeftFromRight).DoOnInitializeRightFromLeft(liveVideoMediaBinder.InitializeRightFromLeft).RegisterChildDisposable(() => liveVideoMediaBinder);
		return objectBinder3;
	}

	public LiveVideoMedia(ILiveVideoInputCollection videoInputs, IAudioSetup audioSetup, IReadOnlyList<EffectDescription> availableEffects)
		: this(videoInputs, new DrawingProperties(availableEffects), new AudioProperties(audioSetup), new LiveVideoProperties(videoInputs))
	{
	}

	private LiveVideoMedia(ILiveVideoInputCollection videoInputs, DrawingProperties drawing, AudioProperties audio, LiveVideoProperties liveVideo)
	{
		Drawing = drawing;
		Audio = audio;
		LiveVideo = liveVideo;
		Drawing.DataModified += Drawing_DataModified;
		Drawing.PropertyChanged += Drawing_PropertyChanged;
		Audio.DataModified += OnDataModified;
		LiveVideo.DataModified += OnDataModified;
		LiveVideo.VideoInputChanged += LiveVideo_VideoInputChanged;
		LiveVideo.DeviceConnectedChanged += delegate
		{
			OnPropertyChanged("IsValid");
		};
		_videoInputs = videoInputs;
	}

	private void LiveVideo_VideoInputChanged(LiveVideoInput? oldValue, LiveVideoInput? newValue)
	{
		if (oldValue != null)
		{
			oldValue.PropertyChanged -= LiveVideoInput_PropertyChanged;
			oldValue.LongNameChanged -= base.OnUpdateActionName;
		}
		if (newValue != null)
		{
			newValue.PropertyChanged += LiveVideoInput_PropertyChanged;
			newValue.LongNameChanged += base.OnUpdateActionName;
		}
		if (oldValue != null && newValue != null)
		{
			OnUpdateActionName(oldValue.LongName, newValue.LongName);
		}
		if (newValue != null)
		{
			UpdateMetadata(newValue);
		}
		OnPropertyChanged("IsValid");
		OnVisualInvalidated();
	}

	private void LiveVideoInput_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		switch (e.PropertyName)
		{
		case "VideoDevice":
		case "VideoMode":
		case "AlphaType":
			if (sender is LiveVideoInput input)
			{
				UpdateMetadata(input);
			}
			break;
		}
		OnPropertyChanged("IsValid");
		OnVisualInvalidated();
	}

	private void LiveVideo_PropertyChanged(object sender, PropertyChangedEventArgs e)
	{
		string? propertyName = e.PropertyName;
		if (propertyName != null && propertyName.Equals("Input") && LiveVideo.Input != null)
		{
			UpdateMetadata(LiveVideo.Input);
		}
	}

	public override MediaBase Clone()
	{
		DrawingProperties drawing = Drawing.Clone();
		AudioProperties audio = Audio.Clone();
		LiveVideoProperties liveVideo = LiveVideo.Clone();
		return CopyProperties(new LiveVideoMedia(_videoInputs, drawing, audio, liveVideo));
	}

	protected internal override Pro.SerializationInterop.RVProtoData.Media ProtoSerialize()
	{
		return new Pro.SerializationInterop.RVProtoData.Media
		{
			Uuid = base.ID.ToUUID(),
			LiveVideo = new Pro.SerializationInterop.RVProtoData.Media.Types.LiveVideoTypeProperties
			{
				Audio = Audio.Serialize(),
				Drawing = Drawing.Serialize(),
				LiveVideo = LiveVideo.Serialize()
			}
		};
	}

	protected internal override void ProtoDeserialize(Pro.SerializationInterop.RVProtoData.Media protoMedia)
	{
		Audio.DataModified -= OnDataModified;
		Drawing.DataModified -= Drawing_DataModified;
		LiveVideo.DataModified -= OnDataModified;
		Audio.Deserialize(protoMedia.LiveVideo.Audio);
		Drawing.Deserialize(protoMedia.LiveVideo.Drawing);
		LiveVideo.Deserialize(protoMedia.LiveVideo.LiveVideo);
		if (LiveVideo.Input != null)
		{
			UpdateMetadata(LiveVideo.Input);
		}
		Audio.DataModified += OnDataModified;
		Drawing.DataModified += Drawing_DataModified;
		LiveVideo.DataModified += OnDataModified;
		OnVisualInvalidated();
	}

	public void Deserialize(Pro.SerializationInterop.RVProtoData.Media media)
	{
		ProtoDeserialize(media);
	}

	protected override void UndoStackChanged(UndoStack? undoStack)
	{
		Audio.UndoStack = undoStack;
		Drawing.UndoStack = undoStack;
		LiveVideo.UndoStack = undoStack;
	}

	private void UpdateMetadata(LiveVideoInput input)
	{
		if (input != null)
		{
			Vector2<int> naturalSize = input.VideoMode?.Size ?? Vector2<int>.Zero;
			Drawing.NaturalSize = naturalSize;
			Drawing.AlphaType = input.AlphaType;
			Audio.InputChannelSet.Resize(16);
		}
	}

	private void Drawing_DataModified()
	{
		OnVisualInvalidated();
		OnDataModified();
	}

	private void Drawing_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "AlphaType")
		{
			LiveVideoInput liveVideoInput = LiveVideo?.Input;
			if (liveVideoInput != null)
			{
				liveVideoInput.AlphaType = Drawing.AlphaType;
			}
		}
	}

	public override void TransposeProperties(MediaBase? media)
	{
		if (media is LiveVideoMedia liveVideoMedia)
		{
			Audio.TransposeProperties(liveVideoMedia.Audio);
			Drawing.TransposeProperties(liveVideoMedia.Drawing);
		}
		else if (media is VideoMedia videoMedia)
		{
			Audio.TransposeProperties(videoMedia.Audio);
			Drawing.TransposeProperties(videoMedia.Drawing);
		}
		else if (media is VisualMedia visualMedia)
		{
			Drawing.TransposeProperties(visualMedia.Drawing);
		}
	}
}
