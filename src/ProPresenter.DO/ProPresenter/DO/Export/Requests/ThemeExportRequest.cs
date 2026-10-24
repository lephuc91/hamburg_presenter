using System.Collections.Generic;
using System.Linq;
using Pro.Common.Components;
using ProPresenter.DO.Themes;

namespace ProPresenter.DO.Export.Requests;

public class ThemeExportRequest : NotifyPropertyChangedBase, IExportRequest
{
	private string _currentItemName = string.Empty;

	private bool _archiving;

	public int ItemCount => Themes.Count();

	public IEnumerable<Theme> Themes { get; }

	public string CurrentItemName
	{
		get
		{
			return _currentItemName;
		}
		set
		{
			SetValue("CurrentItemName", ref _currentItemName, value);
		}
	}

	public bool Archiving
	{
		get
		{
			return _archiving;
		}
		set
		{
			SetValue("Archiving", ref _archiving, value);
		}
	}

	public ThemeExportRequest(IEnumerable<Theme> theme)
	{
		Themes = theme;
	}
}
