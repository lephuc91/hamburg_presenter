using System;
using System.Collections.Generic;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Logging;
using Pro.Common.Mathematics;
using Pro.Common.Utility;

namespace Pro.PPT;

public static class PowerPointComHelper
{
	public static bool IsCOMAccessible()
	{
		return Type.GetTypeFromProgID("Powerpoint.Application") != null;
	}

	public static IEnumerable<SlideData> GetSlideData(string sourcePath, string targetDirectory, Vector2<double> imageSize)
	{
		try
		{
			Presentation presentation2 = new Presentation(sourcePath);
			try
			{
				return presentation2.Slides.Select((Slide s) => exportSlide(s, presentation2)).NonNull();
			}
			finally
			{
				if (presentation2 != null)
				{
					((IDisposable)presentation2).Dispose();
				}
			}
		}
		catch (Exception exception)
		{
			Log.Error(exception);
			return Enumerable.Empty<SlideData>();
		}
		SlideData? exportSlide(Slide slide, Presentation presentation)
		{
			try
			{
				return new SlideData(slide.Export(targetDirectory, presentation.Size.ScaleToFitSize(imageSize).Cast<int>()), slide.Notes?.AllText ?? string.Empty);
			}
			catch (Exception exception2)
			{
				Log.Error(exception2);
				return null;
			}
		}
	}
}
