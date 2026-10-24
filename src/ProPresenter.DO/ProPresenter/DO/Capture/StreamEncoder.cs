using System;
using System.Reactive;
using System.Reactive.Linq;
using Pro.Common.Components;
using Pro.Common.Dispatcher;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Capture;

public class StreamEncoder : NotifyPropertyChangedBase
{
	private Codec _codec;

	private Encoder _encoding = new Encoder();

	public Codec Codec
	{
		get
		{
			return _codec;
		}
		set
		{
			SetValue("Codec", ref _codec, value, OnDataModified);
		}
	}

	public Encoder Encoding
	{
		get
		{
			return _encoding;
		}
		set
		{
			SetValue("Encoding", ref _encoding, value, OnDataModified);
		}
	}

	public event System.Action? DataModified;

	public static ObjectBinder<StreamEncoder, IRecording.Types.IStream.Types.IEncoder> CreateBinder(IUiScheduler scheduler, StreamEncoder left, IRecording.Types.IStream.Types.IEncoder right)
	{
		ObjectBinder<StreamEncoder, IRecording.Types.IStream.Types.IEncoder> objectBinder = new ObjectBinder<StreamEncoder, IRecording.Types.IStream.Types.IEncoder>(left, right);
		objectBinder.Bind((StreamEncoder l) => l.WhenPropertyChanges("Encoding"), (IRecording.Types.IStream.Types.IEncoder r) => Observable.Merge<Unit>(r.VideoWidth.WhenValueChanges.ToUnit(), r.VideoHeight.WhenValueChanges.ToUnit(), r.IsInterlaced.WhenValueChanges.ToUnit(), r.FrameRate.WhenValueChanges.ToUnit(), r.VideoBitrate.WhenValueChanges.ToUnit(), r.AudioBitrate.WhenValueChanges.ToUnit()), delegate(StreamEncoder l, IRecording.Types.IStream.Types.IEncoder r)
		{
			r.VideoWidth.Set(l.Encoding.VideoWidth);
			r.VideoHeight.Set(l.Encoding.VideoHeight);
			r.IsInterlaced.Set(l.Encoding.IsInterlaced);
			r.FrameRate.Set(l.Encoding.FrameRate.ToEntityFrameRate());
			r.VideoBitrate.Set(l.Encoding.VideoBitrate);
			r.AudioBitrate.Set(l.Encoding.AudioBitrate);
		}, delegate(IRecording.Types.IStream.Types.IEncoder r, StreamEncoder l)
		{
			l.Encoding = new Encoder(r.VideoWidth.Value, r.VideoHeight.Value, r.FrameRate.Value.ToFrameRate(), r.VideoBitrate.Value, r.AudioBitrate.Value, r.IsInterlaced.Value);
		}, null, scheduler.Scheduler).Bind((StreamEncoder l) => l.WhenPropertyChanges("Codec"), (IRecording.Types.IStream.Types.IEncoder r) => r.Codec.WhenValueChanges, delegate(StreamEncoder l, IRecording.Types.IStream.Types.IEncoder r)
		{
			r.Codec.Set(l.Codec.ToEntityCodec());
		}, delegate(IRecording.Types.IStream.Types.IEncoder r, StreamEncoder l)
		{
			l.Codec = r.Codec.Value.ToCodec();
		});
		return objectBinder;
	}

	private void OnDataModified()
	{
		this.DataModified?.Invoke();
	}

	public Recording.Types.Stream.Types.Encoder Serialize()
	{
		Recording.Types.Stream.Types.Encoder encoder = Encoding.Serialize();
		encoder.Codec = Codec.ToProtoCodec();
		return encoder;
	}

	public void Deserialize(Recording.Types.Stream.Types.Encoder protoEncoder)
	{
		if (protoEncoder != null)
		{
			Codec = protoEncoder.Codec.ToCodec();
			Encoding = Encoder.FromProto(protoEncoder);
		}
	}
}
