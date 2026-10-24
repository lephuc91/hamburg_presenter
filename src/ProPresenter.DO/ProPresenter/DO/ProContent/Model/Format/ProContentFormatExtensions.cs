using System.Collections.Generic;
using System.Linq;
using Pro.Common.Collections;

namespace ProPresenter.DO.ProContent.Model.Format;

public static class ProContentFormatExtensions
{
	public static IProContentFormat? FindFormat(this IEnumerable<IProContentFormat> availableFormats, IProContentFormat? lastSelected)
	{
		IProContentFormat[] array = availableFormats.ToArray();
		if (lastSelected == null)
		{
			return array.FirstOrDefault();
		}
		IProContentFormat proContentFormat = array.FirstOrDefault((IProContentFormat f) => f == lastSelected);
		if (proContentFormat == null)
		{
			proContentFormat = array.FirstOrDefaultBy((IProContentFormat p) => p.Name == lastSelected.Name, (IProContentFormat p) => p.Width == lastSelected.Width && p.Height == lastSelected.Height && p.Framerate == lastSelected.Framerate && p.Interlaced == lastSelected.Interlaced, (IProContentFormat p) => p.Width == lastSelected.Width && p.Height == lastSelected.Height && p.Framerate == lastSelected.Framerate, (IProContentFormat p) => p.Width == lastSelected.Width && p.Height == lastSelected.Height);
		}
		return proContentFormat ?? availableFormats.FirstOrDefault();
	}
}
