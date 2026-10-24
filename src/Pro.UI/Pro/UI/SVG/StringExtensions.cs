using System;
using System.IO;
using System.Windows.Media;
using Pro.Common.Logging;
using SharpVectors.Converters;
using SharpVectors.Renderers.Wpf;
using SharpVectors.Runtime;

namespace Pro.UI.SVG;

public static class StringExtensions
{
	public static ImageSource? ToSvgImageSource(this string svgContent)
	{
		if (string.IsNullOrWhiteSpace(svgContent))
		{
			return null;
		}
		try
		{
			using FileSvgReader fileSvgReader = new FileSvgReader(new WpfDrawingSettings
			{
				IncludeRuntime = false,
				TextAsGeometry = true,
				OptimizePath = true,
				InteractiveMode = SvgInteractiveModes.None
			});
			using StringReader svgTextReader = new StringReader(svgContent);
			return new DrawingImage(fileSvgReader.Read((TextReader)svgTextReader));
		}
		catch (Exception ex)
		{
			Log.Info("Failed to convert {0} to a SVG image source. Failed with Exception {1}", svgContent, ex);
			return null;
		}
	}
}
