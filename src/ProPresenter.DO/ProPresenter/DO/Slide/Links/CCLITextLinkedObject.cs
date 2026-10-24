using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using Pro.Common.Collections;
using Pro.Localization;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.CCLI;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Slide.Custom;
using ProPresenter.DO.Slide.Custom.Elements;

namespace ProPresenter.DO.Slide.Links;

public class CCLITextLinkedObject : LinkedTextObjectBase
{
	private readonly IGeneral _general;

	public override LinkedTextType LinkedTextType { get; }

	public override string DisplayText { get; } = LocalizedStrings.Get("TEXT_LINK_CCLI_title");

	public override FormattingType FormattingType => FormattingType.None;

	public CCLITextLinkedObject(IGeneral general)
	{
		_general = general;
		LinkAction("Text", base.OnDataModified);
		CollectionChangedEventManager.AddHandler((INotifyCollectionChanged)_general.CCLILayoutData.Tokens, (EventHandler<NotifyCollectionChangedEventArgs>)OncliTokensCollectionChanged);
		PropertyChangedEventManager.AddHandler((INotifyPropertyChanged)_general.CCLILayoutData, (EventHandler<PropertyChangedEventArgs>)OnCcliTextChanged, "Text");
	}

	public override bool RenderEquals([NotNullWhen(true)] ILinkedTextObject? other)
	{
		return other is CCLITextLinkedObject;
	}

	public override int GetRenderHashCode()
	{
		return 0;
	}

	public override ILinkedTextObject Clone()
	{
		return new CCLITextLinkedObject(_general);
	}

	public override string? GetText(ILinkData? linkData)
	{
		if (linkData != null && !TriggeredSlideIsCCLI(linkData))
		{
			return null;
		}
		return CCLIHelper.GeneratePlaceholderText(_general);
	}

	public override void Serialize(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink dataLink)
	{
		dataLink.CcliText = new Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.CCLIText();
	}

	private static bool TriggeredSlideIsCCLI(ILinkData linkData)
	{
		return (linkData.CurrentSlide as CustomSlide)?.Elements.AnyOf((ClosedBezierPath e) => e.TextLink?.LinkedObject is CCLITextLinkedObject) ?? false;
	}

	private void OncliTokensCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		OnDataModified();
	}

	private void OnCcliTextChanged(object? sender, PropertyChangedEventArgs e)
	{
		OnDataModified();
	}
}
