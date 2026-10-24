using System;
using System.Diagnostics.CodeAnalysis;
using Pro.Common.Components;
using Pro.Common.Mathematics;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Messages;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.Slide.Custom;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.Themes;
using ProPresenter.Rendering;

namespace ProPresenter.Controller.Triggering;

public interface ISlidePool
{
	Slide? AddAltTemplateSlide(CustomSlide? slide, TemplateSlide? templateSlide, Vector2<double> screenSize);

	Slide? AddCCLISlide(TemplateSlide? templateSlide, CCLIData data, Vector2<double> screenSize);

	Slide? AddMessageSlide(ProPresenter.DO.Messages.Message message, TemplateSlide? templateSlide);

	CustomSlide? AddSlide(CustomSlide? slide);

	void BeginRender(Guid slideID);

	bool DoesPathHaveText(Guid pathID, Action<BezierPath?> resolveLinkedData);

	void EndRender(Guid slideID);

	bool TryGetBitmap(Guid pathID, RenderingMode mode, int textIndex, Action<BezierPath> resolveLinkedData, [NotNullWhen(true)] out IBitmapHandle? bitmap);

	bool TryGetNonResolvedPath(Guid pathID, [NotNullWhen(true)] out BezierPath? path);

	bool TryGetSegments(Guid pathID, RenderingMode mode, Action<BezierPath> resolveLinkedData, out IBitmapHandle[] bitmaps, out bool isVertical);

	TextLayerInfo[] GetTextLayers(Guid pathID, Action<BezierPath> resolveLinkedData);
}
