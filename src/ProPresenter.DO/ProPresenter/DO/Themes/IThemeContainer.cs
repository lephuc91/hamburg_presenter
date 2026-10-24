using System;
using System.Collections.Generic;

namespace ProPresenter.DO.Themes;

public interface IThemeContainer
{
	IEnumerable<ThemeContainer> Children { get; }

	Guid ID { get; }

	string Name { get; set; }

	Theme? Theme { get; set; }
}
