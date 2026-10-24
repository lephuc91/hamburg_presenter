using System;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.DO.Effects.Descriptions;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Media.Properties;

namespace ProPresenter.DO.Media;

public class WebMedia : MediaBase, IDrawMedia
{
	private string _url = string.Empty;

	public override MediaType MediaType => MediaType.Web;

	public string Url
	{
		get
		{
			return _url;
		}
		set
		{
			if (Uri.TryCreate(value, UriKind.RelativeOrAbsolute, out Uri result))
			{
				string text = result.OriginalString;
				if (!result.IsAbsoluteUri)
				{
					text = "http://" + text;
				}
				SetValue("Url", ref _url, text, delegate(string o, string n)
				{
					base.UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.WebMediaUrl), this, "Url", o, n);
					OnVisualInvalidated();
					OnDataModified();
				});
			}
		}
	}

	public DrawingProperties Drawing { get; private set; }

	public bool SupportsScaleAndBlur => false;

	public bool SupportsCustomScale => false;

	public override ObjectBinder<MediaBase, IMedia> CreateBinder(IUiScheduler scheduler, IEntityFactory entityFactory, IMedia right)
	{
		IMedia.Types.ITypeProperties.IWebContent webContent = right.TypeProperties.Value as IMedia.Types.ITypeProperties.IWebContent;
		if (webContent == null)
		{
			webContent = entityFactory.Create<IMedia.Types.ITypeProperties.IWebContent>();
			right.TypeProperties.Set(webContent);
		}
		ObjectBinder<DrawingProperties, IMedia.Types.IDrawingProperties> drawingPropertiesBinder = Drawing.CreateBinder(scheduler, entityFactory, webContent.Value.Drawing.Value);
		ObjectBinder<WebMedia, IMedia.Types.IWebContentTypeProperties> visualMediaBinder = new ObjectBinder<WebMedia, IMedia.Types.IWebContentTypeProperties>(this, webContent.Value);
		visualMediaBinder.Bind((WebMedia l) => l.WhenPropertyChanges("Drawing"), (IMedia.Types.IWebContentTypeProperties r) => r.Drawing.WhenValueChanges.ToUnit(), delegate(WebMedia l, IMedia.Types.IWebContentTypeProperties r)
		{
			r.Drawing.Set(l.Drawing.HandleDrawingPropertiesModelChange(scheduler, entityFactory));
		}, delegate(IMedia.Types.IWebContentTypeProperties r, WebMedia l)
		{
			l.Drawing.HandleDrawingPropertiesCrdtChange(r.Drawing.Value, scheduler, entityFactory);
		}).RegisterChildDisposable(() => drawingPropertiesBinder);
		ObjectBinder<MediaBase, IMedia> objectBinder = base.CreateBinder(scheduler, entityFactory, right);
		objectBinder.DoOnInitializeRightFromLeft(visualMediaBinder.InitializeRightFromLeft).DoOnInitializeLeftFromRight(visualMediaBinder.InitializeLeftFromRight).RegisterChildDisposable(() => visualMediaBinder);
		return objectBinder;
	}

	public WebMedia()
	{
		Drawing = new DrawingProperties(Array.Empty<EffectDescription>());
		Drawing.DataModified += Drawing_DataModified;
	}

	public WebMedia(string url)
		: this()
	{
		Url = url;
	}

	public override MediaBase Clone()
	{
		return CopyProperties(new WebMedia(Url));
	}

	protected override MediaBase CopyProperties(MediaBase newMedia)
	{
		WebMedia obj = (WebMedia)newMedia;
		obj._url = _url;
		obj.Drawing = Drawing.Clone();
		return base.CopyProperties(newMedia);
	}

	protected internal override Pro.SerializationInterop.RVProtoData.Media ProtoSerialize()
	{
		return new Pro.SerializationInterop.RVProtoData.Media
		{
			Uuid = base.ID.ToUUID(),
			WebContent = new Pro.SerializationInterop.RVProtoData.Media.Types.WebContentTypeProperties
			{
				Drawing = Drawing.Serialize(),
				Url = Url.WebURLToProtoURL()
			}
		};
	}

	protected internal override void ProtoDeserialize(Pro.SerializationInterop.RVProtoData.Media protoMedia)
	{
		Url = protoMedia.WebContent.Url?.ProtoURLToWebURL() ?? string.Empty;
		Drawing.DataModified -= Drawing_DataModified;
		Drawing.Deserialize(protoMedia.WebContent.Drawing);
		Drawing.DataModified += Drawing_DataModified;
		OnVisualInvalidated();
	}

	protected override void UndoStackChanged(UndoStack? undoStack)
	{
		Drawing.UndoStack = undoStack;
	}

	private void Drawing_DataModified()
	{
		OnVisualInvalidated();
		OnDataModified();
	}

	public override void TransposeProperties(MediaBase media)
	{
		throw new NotImplementedException();
	}
}
