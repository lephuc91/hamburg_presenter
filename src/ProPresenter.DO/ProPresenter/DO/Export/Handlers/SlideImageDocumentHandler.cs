using System;
using System.Collections.Generic;
using System.IO.Abstractions;
using System.Linq;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Pro.Common.Utility;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Export.Requests;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.Slide.Custom;

namespace ProPresenter.DO.Export.Handlers;

public class SlideImageDocumentHandler : IRequestHandler
{
	private readonly IFileSystem _fileSystem;

	public SlideImageDocumentHandler(IFileSystem fileSystem)
	{
		_fileSystem = fileSystem;
	}

	public bool CanHandle(IExportRequest request)
	{
		return request is SlideImageExportRequest;
	}

	public void Handle(IExportProcess process, IExportRequest request, UpdateStatusDelegate updateStatus, ResolveConflictDelegate resolveConflict)
	{
		SlideImageExportRequest slideImageExportRequest = request as SlideImageExportRequest;
		IEnumerable<IPresentation> enumerable = slideImageExportRequest?.Documents;
		IExportImageSettings exportImageSettings = slideImageExportRequest?.ImageOptions;
		string text = ((exportImageSettings != null) ? _fileSystem.Path.Combine(exportImageSettings.Directory, exportImageSettings.ExportName) : string.Empty);
		if (!_fileSystem.Directory.Exists(text))
		{
			_fileSystem.Directory.CreateDirectory(text);
		}
		foreach (IPresentation item in enumerable ?? Enumerable.Empty<PresentationBase>())
		{
			if (slideImageExportRequest != null)
			{
				slideImageExportRequest.CurrentItemName = item.Name;
			}
			updateStatus(request);
			string text2 = (((enumerable?.Count() ?? 0) > 1) ? _fileSystem.Path.Combine(text, item.Name) : text);
			if (!_fileSystem.Directory.Exists(text2))
			{
				_fileSystem.Directory.CreateDirectory(text2);
			}
			int num = 1;
			foreach (SlideCue item2 in item.ArrangementGroups.SelectMany((CueGroup g) => g.Cues).OfType<SlideCue>())
			{
				bool flag = item2.GetIncludeBackground();
				if (flag && exportImageSettings != null && exportImageSettings.ImageExportExtension == ImageExportExtension.PNG)
				{
					flag = false;
				}
				if (item2.SlideAction?.Slide is CustomSlide slide)
				{
					BitmapSource bitmapSource = ExportPrompt.RenderImage(slide, item.UseBackgroundColor ? item.BackgroundColor : Colors.Transparent, flag, exportImageSettings?.IncludeMedia ?? false);
					if (bitmapSource != null && exportImageSettings != null)
					{
						SaveImage(bitmapSource, _fileSystem.Path.Combine(text2, num++ + exportImageSettings?.ImageExportExtension.GetEnumDescription()), GetEncoder(exportImageSettings.ImageExportExtension));
					}
				}
			}
		}
	}

	private static BitmapEncoder GetEncoder(ImageExportExtension extension)
	{
		return extension switch
		{
			ImageExportExtension.JPG => new JpegBitmapEncoder
			{
				QualityLevel = 100
			}, 
			ImageExportExtension.PNG => new PngBitmapEncoder(), 
			_ => throw new NotSupportedException(), 
		};
	}

	private void SaveImage(BitmapSource bitmap, string filename, BitmapEncoder encoder)
	{
		encoder.Frames.Add(BitmapFrame.Create(bitmap));
		using FileSystemStream stream = _fileSystem.File.Create(filename);
		encoder.Save(stream);
	}
}
