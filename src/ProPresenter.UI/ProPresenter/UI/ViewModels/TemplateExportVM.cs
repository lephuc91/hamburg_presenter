using System.Collections.Generic;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Components;
using ProPresenter.DO;
using ProPresenter.DO.Themes;

namespace ProPresenter.UI.ViewModels;

public class TemplateExportVM : NotifyPropertyChangedBase
{
	public class ThemeKey : NotifyPropertyChangedBase
	{
		private bool _canExport = true;

		public Theme Theme { get; }

		public bool CanExport
		{
			get
			{
				return _canExport;
			}
			set
			{
				SetValue("CanExport", ref _canExport, value);
			}
		}

		public ThemeKey(Theme template)
		{
			Theme = template;
		}
	}

	public IEnumerable<ThemeKey> ThemeKeys { get; }

	public IEnumerable<Theme> ThemesToExport => from t in ThemeKeys
		where t.CanExport
		select t.Theme;

	public bool AllSelected
	{
		get
		{
			return ThemeKeys.All((ThemeKey t) => t.CanExport);
		}
		set
		{
			ThemeKeys.ForEach(delegate(ThemeKey t)
			{
				t.CanExport = value;
			});
		}
	}

	public TemplateExportVM()
	{
		ThemeKeys = DataVault.Themes.Select((Theme t) => new ThemeKey(t)).ToArray();
		ThemeKeys.ForEach(delegate(ThemeKey t)
		{
			t.PropertyChanged += delegate
			{
				OnPropertyChanged("AllSelected");
				OnPropertyChanged("ThemesToExport");
			};
		});
	}
}
