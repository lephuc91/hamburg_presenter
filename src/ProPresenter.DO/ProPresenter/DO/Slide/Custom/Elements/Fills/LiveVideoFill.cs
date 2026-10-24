using System.Diagnostics.CodeAnalysis;
using System.Windows.Media;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.Localization;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Media;

namespace ProPresenter.DO.Slide.Custom.Elements.Fills;

public class LiveVideoFill : FillBase
{
	private readonly IMediaFactory _mediaFactory;

	public override FillType Type => FillType.Live;

	public override string DisplayName => LiveVideo.LiveVideo.Input?.VideoDevice?.Name ?? LocalizedStrings.Get("GRAPHIC_FILL_VIDEO_INPUT_title");

	public LiveVideoMedia LiveVideo { get; private set; }

	public static ObjectBinder<LiveVideoFill, IGraphics.Types.IFill.Types.IFillType.IMedia> CreateBinder(IUiScheduler scheduler, IEntityFactory entityFactory, LiveVideoFill left, IGraphics.Types.IFill.Types.IFillType.IMedia right)
	{
		ObjectBinder<LiveVideoFill, IGraphics.Types.IFill.Types.IFillType.IMedia> objectBinder = new ObjectBinder<LiveVideoFill, IGraphics.Types.IFill.Types.IFillType.IMedia>(left, right);
		objectBinder.Bind((LiveVideoFill l) => l.WhenPropertyChanges("LiveVideo"), (IGraphics.Types.IFill.Types.IFillType.IMedia r) => r.WhenValueChanges, delegate(LiveVideoFill l, IGraphics.Types.IFill.Types.IFillType.IMedia r)
		{
			IMedia media = entityFactory.Create<IMedia>();
			r.Set(media);
			ObjectBinder<MediaBase, IMedia> objectBinder2 = left.LiveVideo.CreateBinder(scheduler, entityFactory, media);
			objectBinder2.InitializeRightFromLeft();
			media.RegisterLinkedDisposable(objectBinder2);
		}, delegate(IGraphics.Types.IFill.Types.IFillType.IMedia r, LiveVideoFill l)
		{
			ObjectBinder<MediaBase, IMedia> objectBinder3 = left.LiveVideo.CreateBinder(scheduler, entityFactory, r.Value);
			objectBinder3.InitializeLeftFromRight();
			r.Value.RegisterLinkedDisposable(objectBinder3);
		});
		return objectBinder;
	}

	public LiveVideoFill(IMediaFactory mediaFactory)
	{
		LiveVideo = mediaFactory.CreateLiveVideoMedia();
		LiveVideo.DataModified += LiveVideo_DataModified;
		_mediaFactory = mediaFactory;
	}

	public override bool RenderEquals([NotNullWhen(true)] IFill? other)
	{
		if (base.RenderEquals(other) && other is LiveVideoFill liveVideoFill)
		{
			return DisplayName == liveVideoFill.DisplayName;
		}
		return false;
	}

	public override int GetRenderHashCode()
	{
		return RenderHashCodeHelper.GenerateHashCode(base.GetRenderHashCode(), LiveVideo);
	}

	private void LiveVideo_DataModified(MediaBase media)
	{
		OnVisualInvalidated();
		OnDataModified();
	}

	public override System.Windows.Media.Color Sample()
	{
		return Colors.DarkGray;
	}

	public override IFill Clone()
	{
		LiveVideoFill liveVideoFill = new LiveVideoFill(_mediaFactory)
		{
			LiveVideo = (LiveVideoMedia)LiveVideo.Clone()
		};
		CopyProperties(liveVideoFill);
		return liveVideoFill;
	}

	protected override void OnSerialize(Graphics.Types.Fill protoFill)
	{
		protoFill.Media = LiveVideo.ProtoSerialize();
	}

	protected override void OnDeserialize(Graphics.Types.Fill protoFill, string containerId)
	{
		Pro.SerializationInterop.RVProtoData.Media media = protoFill.Media;
		if (media != null)
		{
			LiveVideo.DataModified -= LiveVideo_DataModified;
			LiveVideo.ProtoDeserialize(media);
			LiveVideo.DataModified += LiveVideo_DataModified;
		}
	}

	protected override void OnUndoStackChanged(UndoStack? value)
	{
		LiveVideo.UndoStack = value;
	}
}
