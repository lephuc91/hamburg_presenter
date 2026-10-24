using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Mathematics;
using Pro.Common.ObjectBinding;
using Pro.Common.Time;
using Pro.Common.Utility;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;
using Pro.ssAPI;

namespace ProPresenter.DO.Media.Properties;

public class VideoProperties : ObservableObject, ICloneable<VideoProperties>
{
	public const double DefaultPosition = -1.0;

	[ObservableProperty]
	private double _frameRate = 1.0;

	[ObservableProperty]
	private FieldType _fieldType;

	[ObservableProperty]
	private double _thumbnailPosition = -1.0;

	[ObservableProperty]
	private EndBehaviorType _endBehavior;

	[ObservableProperty]
	private bool _softLoop;

	[ObservableProperty]
	private TimeSlice _softLoopDuration = TimeSlice.Zero;

	[ObservableProperty]
	private HardwareDecodingBehaviorType _hardwareDecodingBehavior;

	public UndoStack? UndoStack { get; set; }

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public double FrameRate
	{
		get
		{
			return _frameRate;
		}
		set
		{
			if (!EqualityComparer<double>.Default.Equals(_frameRate, value))
			{
				double frameRate = _frameRate;
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.FrameRate);
				_frameRate = value;
				OnFrameRateChanged(frameRate, value);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.FrameRate);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public FieldType FieldType
	{
		get
		{
			return _fieldType;
		}
		set
		{
			if (!EqualityComparer<FieldType>.Default.Equals(_fieldType, value))
			{
				FieldType fieldType = _fieldType;
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.FieldType);
				_fieldType = value;
				OnFieldTypeChanged(fieldType, value);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.FieldType);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public double ThumbnailPosition
	{
		get
		{
			return _thumbnailPosition;
		}
		set
		{
			if (!EqualityComparer<double>.Default.Equals(_thumbnailPosition, value))
			{
				double thumbnailPosition = _thumbnailPosition;
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.ThumbnailPosition);
				_thumbnailPosition = value;
				OnThumbnailPositionChanged(thumbnailPosition, value);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.ThumbnailPosition);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public EndBehaviorType EndBehavior
	{
		get
		{
			return _endBehavior;
		}
		set
		{
			if (!EqualityComparer<EndBehaviorType>.Default.Equals(_endBehavior, value))
			{
				EndBehaviorType endBehavior = _endBehavior;
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.EndBehavior);
				_endBehavior = value;
				OnEndBehaviorChanged(endBehavior, value);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.EndBehavior);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool SoftLoop
	{
		get
		{
			return _softLoop;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_softLoop, value))
			{
				bool softLoop = _softLoop;
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.SoftLoop);
				_softLoop = value;
				OnSoftLoopChanged(softLoop, value);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.SoftLoop);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public TimeSlice SoftLoopDuration
	{
		get
		{
			return _softLoopDuration;
		}
		set
		{
			if (!EqualityComparer<TimeSlice>.Default.Equals(_softLoopDuration, value))
			{
				TimeSlice softLoopDuration = _softLoopDuration;
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.SoftLoopDuration);
				_softLoopDuration = value;
				OnSoftLoopDurationChanged(softLoopDuration, value);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.SoftLoopDuration);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public HardwareDecodingBehaviorType HardwareDecodingBehavior
	{
		get
		{
			return _hardwareDecodingBehavior;
		}
		set
		{
			if (!EqualityComparer<HardwareDecodingBehaviorType>.Default.Equals(_hardwareDecodingBehavior, value))
			{
				HardwareDecodingBehaviorType hardwareDecodingBehavior = _hardwareDecodingBehavior;
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.HardwareDecodingBehavior);
				_hardwareDecodingBehavior = value;
				OnHardwareDecodingBehaviorChanged(hardwareDecodingBehavior, value);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.HardwareDecodingBehavior);
			}
		}
	}

	public event System.Action? DataModified;

	public static ObjectBinder<VideoProperties, IMedia.Types.IVideoProperties> CreateBinder(VideoProperties left, IMedia.Types.IVideoProperties right)
	{
		ObjectBinder<VideoProperties, IMedia.Types.IVideoProperties> objectBinder = new ObjectBinder<VideoProperties, IMedia.Types.IVideoProperties>(left, right);
		objectBinder.Bind((VideoProperties l) => l.WhenPropertyChanges("FrameRate"), (IMedia.Types.IVideoProperties r) => r.FrameRate.WhenValueChanges, delegate(VideoProperties l, IMedia.Types.IVideoProperties r)
		{
			r.FrameRate.Set(l.FrameRate);
		}, delegate(IMedia.Types.IVideoProperties r, VideoProperties l)
		{
			l.FrameRate = r.FrameRate.Value;
		}).Bind((VideoProperties l) => l.WhenPropertyChanges("FieldType"), (IMedia.Types.IVideoProperties r) => r.FieldType.WhenValueChanges, delegate(VideoProperties l, IMedia.Types.IVideoProperties r)
		{
			r.FieldType.Set(l.FieldType.ToEntityVideoFieldType());
		}, delegate(IMedia.Types.IVideoProperties r, VideoProperties l)
		{
			l.FieldType = r.FieldType.Value.ToFieldType();
		}).Bind((VideoProperties l) => l.WhenPropertyChanges("ThumbnailPosition"), (IMedia.Types.IVideoProperties r) => r.ThumbnailPosition.WhenValueChanges, delegate(VideoProperties l, IMedia.Types.IVideoProperties r)
		{
			r.ThumbnailPosition.Set(l.ThumbnailPosition);
		}, delegate(IMedia.Types.IVideoProperties r, VideoProperties l)
		{
			l.ThumbnailPosition = r.ThumbnailPosition.Value;
		})
			.Bind((VideoProperties l) => l.WhenPropertyChanges("EndBehavior"), (IMedia.Types.IVideoProperties r) => r.EndBehavior.WhenValueChanges, delegate(VideoProperties l, IMedia.Types.IVideoProperties r)
			{
				r.EndBehavior.Set(l.EndBehavior.ToEntityEndBehavior());
			}, delegate(IMedia.Types.IVideoProperties r, VideoProperties l)
			{
				l.EndBehavior = r.EndBehavior.Value.ToEndBehaviorType();
			})
			.Bind((VideoProperties l) => l.WhenPropertyChanges("SoftLoop"), (IMedia.Types.IVideoProperties r) => r.SoftLoop.WhenValueChanges, delegate(VideoProperties l, IMedia.Types.IVideoProperties r)
			{
				r.SoftLoop.Set(l.SoftLoop);
			}, delegate(IMedia.Types.IVideoProperties r, VideoProperties l)
			{
				l.SoftLoop = r.SoftLoop.Value;
			})
			.Bind((VideoProperties l) => l.WhenPropertyChanges("SoftLoopDuration"), (IMedia.Types.IVideoProperties r) => r.SoftLoopDuration.WhenValueChanges, delegate(VideoProperties l, IMedia.Types.IVideoProperties r)
			{
				r.SoftLoopDuration.Set(l.SoftLoopDuration.TotalSeconds);
			}, delegate(IMedia.Types.IVideoProperties r, VideoProperties l)
			{
				l.SoftLoopDuration = TimeSlice.FromSeconds(r.SoftLoopDuration.Value);
			})
			.Bind((VideoProperties l) => l.WhenPropertyChanges("HardwareDecodingBehavior"), (IMedia.Types.IVideoProperties r) => r.HardwareDecoding.WhenValueChanges, delegate(VideoProperties l, IMedia.Types.IVideoProperties r)
			{
				r.HardwareDecoding.Set(l.HardwareDecodingBehavior.ToEntityVideoHardwareDecodingBehavior());
			}, delegate(IMedia.Types.IVideoProperties r, VideoProperties l)
			{
				l.HardwareDecodingBehavior = r.HardwareDecoding.Value.ToHardwareDecodingBehavior();
			});
		return objectBinder;
	}

	public void SerializeToEntity(IEntityFactory entityFactory, IMedia.Types.IVideoProperties video)
	{
		video.FrameRate.Set(FrameRate);
		video.FieldType.Set(FieldType.ToEntityVideoFieldType());
		video.ThumbnailPosition.Set(ThumbnailPosition);
		video.EndBehavior.Set(EndBehavior.ToEntityEndBehavior());
		video.SoftLoop.Set(SoftLoop);
		video.SoftLoopDuration.Set(SoftLoopDuration.TotalSeconds);
		video.HardwareDecoding.Set(HardwareDecodingBehavior.ToEntityVideoHardwareDecodingBehavior());
	}

	public void DeserializeEntity(IMedia.Types.IVideoProperties video)
	{
		FrameRate = video.FrameRate.Value;
		FieldType = video.FieldType.Value.ToFieldType();
		ThumbnailPosition = video.ThumbnailPosition.Value;
		EndBehavior = video.EndBehavior.Value.ToEndBehaviorType();
		SoftLoop = video.SoftLoop.Value;
		SoftLoopDuration = TimeSlice.FromSeconds(video.SoftLoopDuration.Value);
		HardwareDecodingBehavior = video.HardwareDecoding.Value.ToHardwareDecodingBehavior();
	}

	public VideoProperties Clone()
	{
		return new VideoProperties
		{
			FrameRate = FrameRate,
			FieldType = FieldType,
			ThumbnailPosition = ThumbnailPosition,
			EndBehavior = EndBehavior,
			SoftLoop = SoftLoop,
			SoftLoopDuration = SoftLoopDuration,
			HardwareDecodingBehavior = HardwareDecodingBehavior
		};
	}

	private void OnDataModified()
	{
		this.DataModified?.Invoke();
	}

	internal Pro.SerializationInterop.RVProtoData.Media.Types.VideoProperties Serialize()
	{
		return new Pro.SerializationInterop.RVProtoData.Media.Types.VideoProperties
		{
			FrameRate = FrameRate,
			FieldType = FieldType.ToProtoVideoFieldType(),
			ThumbnailPosition = ThumbnailPosition,
			EndBehavior = EndBehavior.GetProtoEndBehavior(),
			SoftLoop = SoftLoop,
			SoftLoopDuration = SoftLoopDuration.TotalSeconds,
			HardwareDecoding = HardwareDecodingBehavior.ToProtoVideoHardwareDecodingBehavior()
		};
	}

	public void Deserialize(Pro.SerializationInterop.RVProtoData.Media.Types.VideoProperties video)
	{
		if (video != null)
		{
			FrameRate = video.FrameRate;
			FieldType = video.FieldType.ToFieldType();
			ThumbnailPosition = video.ThumbnailPosition;
			EndBehavior = video.EndBehavior.GetEndBehaviorType();
			SoftLoop = video.SoftLoop;
			SoftLoopDuration = TimeSlice.FromSeconds(video.SoftLoopDuration);
			HardwareDecodingBehavior = video.HardwareDecoding.ToHardwareDecodingBehavior();
		}
	}

	internal void TransposeProperties(VideoProperties video, TimeSlice duration)
	{
		if (video != null)
		{
			FrameRate = video.FrameRate;
			FieldType = video.FieldType;
			ThumbnailPosition = video.ThumbnailPosition;
			EndBehavior = video.EndBehavior;
			SoftLoop = video.SoftLoop;
			SoftLoopDuration = video.SoftLoopDuration.Clamp(TimeSlice.Zero, duration);
			HardwareDecodingBehavior = video.HardwareDecodingBehavior;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnFrameRateChanged(double oldValue, double newValue)
	{
		OnDataModified();
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnFieldTypeChanged(FieldType oldValue, FieldType newValue)
	{
		OnDataModified();
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnThumbnailPositionChanged(double oldValue, double newValue)
	{
		OnDataModified();
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnEndBehaviorChanged(EndBehaviorType oldValue, EndBehaviorType newValue)
	{
		UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.EndBehaviorType), this, "EndBehavior", oldValue, newValue, null, null, autoFinalize: true);
		OnDataModified();
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnSoftLoopChanged(bool oldValue, bool newValue)
	{
		UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.VideoMediaSoftLoop), this, "SoftLoop", oldValue, newValue, null, null, autoFinalize: true);
		OnDataModified();
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnSoftLoopDurationChanged(TimeSlice oldValue, TimeSlice newValue)
	{
		OnDataModified();
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnHardwareDecodingBehaviorChanged(HardwareDecodingBehaviorType oldValue, HardwareDecodingBehaviorType newValue)
	{
		OnDataModified();
	}
}
