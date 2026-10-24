using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.Localization;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Media;
using ProPresenter.DO.Web;

namespace ProPresenter.DO.Slide.Custom.Elements.Fills;

public class HTMLFill : FillBase
{
	private BitmapSource? _bitmap;

	public override FillType Type => FillType.HTML;

	public override string DisplayName
	{
		get
		{
			try
			{
				return new Uri(WebMedia.Url).Host;
			}
			catch (Exception)
			{
				return string.Empty;
			}
		}
	}

	public BitmapSource? Bitmap
	{
		get
		{
			return _bitmap;
		}
		set
		{
			SetValue("Bitmap", ref _bitmap, value, (System.Action)delegate
			{
				OnVisualInvalidated();
			}, (Predicate<BitmapSource>?)null, referenceComparison: false);
		}
	}

	public WebMedia WebMedia { get; private set; }

	public string DisplayText => LocalizedStrings.Get("EDITOR_SHAPE_WEB_FILL_LINK_label", new object[1] { WebMedia.Url });

	public event Action<HTMLFill>? DrawWebPage;

	public static ObjectBinder<HTMLFill, IGraphics.Types.IFill.Types.IFillType.IMedia> CreateBinder(IUiScheduler scheduler, IEntityFactory entityFactory, HTMLFill left, IGraphics.Types.IFill.Types.IFillType.IMedia right)
	{
		ObjectBinder<HTMLFill, IGraphics.Types.IFill.Types.IFillType.IMedia> objectBinder = new ObjectBinder<HTMLFill, IGraphics.Types.IFill.Types.IFillType.IMedia>(left, right);
		objectBinder.Bind((HTMLFill l) => l.WhenPropertyChanges("WebMedia"), (IGraphics.Types.IFill.Types.IFillType.IMedia r) => r.WhenValueChanges, delegate(HTMLFill l, IGraphics.Types.IFill.Types.IFillType.IMedia r)
		{
			IMedia media = entityFactory.Create<IMedia>();
			r.Set(media);
			ObjectBinder<MediaBase, IMedia> objectBinder2 = left.WebMedia.CreateBinder(scheduler, entityFactory, media);
			objectBinder2.InitializeRightFromLeft();
			media.RegisterLinkedDisposable(objectBinder2);
		}, delegate(IGraphics.Types.IFill.Types.IFillType.IMedia r, HTMLFill l)
		{
			ObjectBinder<MediaBase, IMedia> objectBinder3 = left.WebMedia.CreateBinder(scheduler, entityFactory, r.Value);
			objectBinder3.InitializeLeftFromRight();
			r.Value.RegisterLinkedDisposable(objectBinder3);
		});
		return objectBinder;
	}

	public HTMLFill()
		: this(new WebMedia(WebSource.RenewedVision.ToString()))
	{
	}

	private HTMLFill(WebMedia webMedia)
	{
		WebMedia = webMedia;
		WebMedia.DataModified += WebMedia_DataModified;
		WebMedia.VisualInvalidated += base.OnVisualInvalidated;
	}

	public override bool RenderEquals([NotNullWhen(true)] IFill? other)
	{
		if (base.RenderEquals(other) && other is HTMLFill hTMLFill)
		{
			return WebMedia.Url == hTMLFill.WebMedia.Url;
		}
		return false;
	}

	public override int GetRenderHashCode()
	{
		return RenderHashCodeHelper.GenerateHashCode(base.GetRenderHashCode(), WebMedia.Url);
	}

	public override System.Windows.Media.Color Sample()
	{
		return Colors.LightGray;
	}

	public override IFill Clone()
	{
		HTMLFill hTMLFill = new HTMLFill((WebMedia)WebMedia.Clone());
		CopyProperties(hTMLFill);
		return hTMLFill;
	}

	protected override void OnSerialize(Graphics.Types.Fill protoFill)
	{
		protoFill.Media = WebMedia.ProtoSerialize();
	}

	protected override void OnDeserialize(Graphics.Types.Fill protoFill, string containerId)
	{
		Pro.SerializationInterop.RVProtoData.Media media = protoFill.Media;
		if (media != null)
		{
			WebMedia.DataModified -= WebMedia_DataModified;
			WebMedia.ProtoDeserialize(media);
			WebMedia.DataModified += WebMedia_DataModified;
		}
	}

	private void WebMedia_DataModified(MediaBase media)
	{
		OnDataModified();
		Bitmap = null;
		this.DrawWebPage?.Invoke(this);
	}

	protected override void OnUndoStackChanged(UndoStack? value)
	{
		WebMedia.UndoStack = value;
	}
}
