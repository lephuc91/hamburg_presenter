using System;
using System.Collections.Generic;
using System.Windows.Media;

namespace ProPresenter.DO.WhatsNew;

public interface IWhatsNewContentProviderFromJson
{
	Version? Version { get; }

	Color AccentColor { get; }

	IEnumerable<IFeatureItem> GetFeatures();
}
