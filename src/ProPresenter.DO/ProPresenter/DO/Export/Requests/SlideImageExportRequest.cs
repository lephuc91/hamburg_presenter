using System.Collections.Generic;
using ProPresenter.DO.Presentation;

namespace ProPresenter.DO.Export.Requests;

internal class SlideImageExportRequest : DocumentExportRequest
{
	public IExportImageSettings ImageOptions { get; }

	public SlideImageExportRequest(IEnumerable<IPresentation> documents, IExportImageSettings imageOptions)
		: base(documents, DocumentExportOption.Image)
	{
		ImageOptions = imageOptions;
	}
}
