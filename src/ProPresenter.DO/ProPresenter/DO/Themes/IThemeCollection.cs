using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using Pro.Common.Collections;

namespace ProPresenter.DO.Themes;

public interface IThemeCollection : IImmutableObservableCollection<Theme>, IReadOnlyList<Theme>, IEnumerable<Theme>, IEnumerable, IReadOnlyCollection<Theme>, INotifyEnumerableChanged<Theme>, INotifyCollectionChanged, INotifyPropertyChanged
{
	ThemeContainer? ThemeTree { get; }

	Theme DefaultTheme { get; }

	event Action<Theme, TemplateSlide?>? ThemeDataModified;

	bool DoesTemplateSlideExist(Guid templateSlideID);

	bool DoesThemeExist(string name);

	TemplateSlide? FindTemplate(Guid id, string name = "", bool useDefault = true);
}
