using System;
using System.Diagnostics.CodeAnalysis;
using Pro.Common.Components.Reversibility;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.Entity;
using Pro.Localization;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Slide.Links;

public class PresentationNameLinkedObject : LinkedTextObjectBase
{
	private SourceType _source;

	public override LinkedTextType LinkedTextType => LinkedTextType.PresentationName;

	public override string DisplayText => LocalizedStrings.Get(LinkedTextType) + " - " + LocalizedStrings.Get(Source);

	public override FormattingType FormattingType => FormattingType.None;

	public SourceType Source
	{
		get
		{
			return _source;
		}
		set
		{
			SetValue("Source", ref _source, value, delegate(SourceType o, SourceType n)
			{
				base.UndoStack?.Commit(UndoActionTypes.PresentationSource.ToAction(), this, "Source", o, n);
				OnDataModified();
			});
		}
	}

	public static ObjectBinder<PresentationNameLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.IPresentation> CreateBinder(PresentationNameLinkedObject left, ISlide.Types.IElement.Types.IDataLink.Types.IPresentation right)
	{
		ObjectBinder<PresentationNameLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.IPresentation> objectBinder = new ObjectBinder<PresentationNameLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.IPresentation>(left, right);
		objectBinder.Bind((PresentationNameLinkedObject l) => l.WhenPropertyChanges("Source"), (ISlide.Types.IElement.Types.IDataLink.Types.IPresentation r) => r.PresentationSource.WhenValueChanges, delegate(PresentationNameLinkedObject l, ISlide.Types.IElement.Types.IDataLink.Types.IPresentation r)
		{
			r.PresentationSource.Set(l.Source.ToEntityPresentationSource());
		}, delegate(ISlide.Types.IElement.Types.IDataLink.Types.IPresentation r, PresentationNameLinkedObject l)
		{
			l.Source = r.PresentationSource.Value.ToSourceType();
		});
		return objectBinder;
	}

	public PresentationNameLinkedObject()
	{
	}

	public PresentationNameLinkedObject(SourceType source)
	{
		_source = source;
	}

	public override string GetText(ILinkData? linkData)
	{
		if (linkData == null)
		{
			return LocalizedStrings.Get("TEXT_LINK_CURRENT_PRESENTATION_PLACEHOLDER_title");
		}
		return Source switch
		{
			SourceType.Presentation => linkData.PresentationInfo?.PresentationName ?? string.Empty, 
			SourceType.Announcement => linkData.PresentationInfo?.AnnouncementName ?? string.Empty, 
			_ => throw new NotSupportedException(), 
		};
	}

	public override bool RenderEquals([NotNullWhen(true)] ILinkedTextObject? other)
	{
		if (other is PresentationNameLinkedObject presentationNameLinkedObject)
		{
			return presentationNameLinkedObject.Source == Source;
		}
		return false;
	}

	public override int GetRenderHashCode()
	{
		return RenderHashCodeHelper.GenerateHashCode(Source);
	}

	public override ILinkedTextObject Clone()
	{
		return new PresentationNameLinkedObject(_source);
	}

	public override void Serialize(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink dataLink)
	{
		dataLink.Presentation = new Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.Presentation
		{
			PresentationSource = _source.ToProtoPresentationSource()
		};
	}

	public static PresentationNameLinkedObject Deserialize(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.Presentation protoPresentation)
	{
		return new PresentationNameLinkedObject(protoPresentation.PresentationSource.ToSourceType());
	}
}
