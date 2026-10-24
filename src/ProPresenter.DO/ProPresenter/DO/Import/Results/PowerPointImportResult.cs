using System.Collections.Generic;
using System.IO;
using Pro.Common.Dispatcher;
using Pro.Common.Mathematics;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Import.Requests;
using ProPresenter.DO.Librarian;
using ProPresenter.DO.Media;
using ProPresenter.DO.PowerPoint;
using ProPresenter.DO.Presentation;

namespace ProPresenter.DO.Import.Results;

public class PowerPointImportResult : IImportResult
{
	private readonly IEnumerable<PowerPointSlideImportData> _importData;

	private readonly IPresentationFactory _presentationFactory;

	private readonly IPowerPointImageLoader _imageLoader;

	private readonly Vector2<double> _slideSize;

	public PowerPointImportResult(IEnumerable<PowerPointSlideImportData> importData, IPresentationFactory presentationFactory, IPowerPointImageLoader imageLoader, Vector2<double> slideSize)
	{
		_importData = importData;
		_presentationFactory = presentationFactory;
		_imageLoader = imageLoader;
		_slideSize = slideSize;
	}

	public string GetTargetFilename(IImportRequest request)
	{
		if (request is FileImportRequest fileImportRequest)
		{
			return fileImportRequest.FullName;
		}
		return string.Empty;
	}

	public void CompleteImport(IImportProcess process, IImportRequest request, string name, bool overwrite, IUiDispatcher dispatcher, string containerId)
	{
		dispatcher.InvokeAsync(processData);
		static void onImageLoaded(CustomPresentation presentation, MediaBase media, PowerPointSlideImportData data)
		{
			SlideCue slideCue = presentation.AddCue();
			slideCue.AddMediaElement(media, userInitiated: true);
			slideCue.SlideAction?.Slide.Note?.InsertTextAndParagraphs(0, data.Notes);
		}
		void processData()
		{
			ILibrary library = process.SelectedLibrary;
			if (library != null)
			{
				CustomPresentation presentation2 = _presentationFactory.CreateCustom();
				presentation2.Name = Path.GetFileNameWithoutExtension(name);
				_imageLoader.Load(_importData, delegate(MediaBase m, PowerPointSlideImportData d)
				{
					onImageLoaded(presentation2, m, d);
				}, delegate
				{
					presentation2.ChangeSize(_slideSize);
					if (overwrite && library.DoesPresentationExist(presentation2.Name))
					{
						library.Remove(LibraryCollection.FindDocument(library, presentation2.Name));
					}
					DocumentCue documentCue = library.Add(presentation2, userInitiated: true);
					if (process.SelectedPlaylist != null)
					{
						ImportPrompt.AddToPlaylist(documentCue, process.SelectedPlaylist);
					}
				}, containerId);
			}
		}
	}
}
