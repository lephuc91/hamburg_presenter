using System;
using System.Collections.Generic;
using Pro.Common.Components;
using Pro.DO.Storage;
using ProPresenter.DO;
using ProPresenter.DO.Slide.Custom.Elements;

namespace ProPresenter.Controller;

public interface IPasteStrategy
{
	EditMode EditMode { get; set; }

	bool CanPasteElements();

	bool CanPasteSlides<I>(Func<I, IEnumerable<SlideElementBase>> convert, Func<I, bool>? isPasteable = null) where I : ICloneable<I>;

	IEnumerable<(SlideElementBase Element, RelativePath? MediaPath)> GetPastableItems(string containerId);

	IEnumerable<I> PasteSlides<T, I>(T collection, int index, Func<I, bool>? isPasteable = null) where T : ICutPasteCollection<I> where I : ICloneable<I>;
}
