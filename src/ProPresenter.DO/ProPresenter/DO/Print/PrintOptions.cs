using System.ComponentModel;
using Pro.Common.Components;
using ProPresenter.DO.Settings;

namespace ProPresenter.DO.Print;

public class PrintOptions : NotifyPropertyChangedBase
{
	private readonly IApp _app;

	public bool IsThumbnail
	{
		get
		{
			return _app.Print_IsThumbnail;
		}
		set
		{
			_app.Print_IsThumbnail = value;
		}
	}

	public bool IsOutline
	{
		get
		{
			return _app.Print_IsOutline;
		}
		set
		{
			_app.Print_IsOutline = value;
		}
	}

	public bool DisableSlides
	{
		get
		{
			return _app.Print_DisableSlides;
		}
		set
		{
			_app.Print_DisableSlides = value;
		}
	}

	public bool ShowCurrentDate
	{
		get
		{
			return _app.Print_ShowCurrentDate;
		}
		set
		{
			_app.Print_ShowCurrentDate = value;
		}
	}

	public bool ShowNotes
	{
		get
		{
			return _app.Print_ShowNotes;
		}
		set
		{
			_app.Print_ShowNotes = value;
		}
	}

	public bool ShowMetaData
	{
		get
		{
			return _app.Print_ShowMetaData;
		}
		set
		{
			_app.Print_ShowMetaData = value;
		}
	}

	public bool ShowSlideLabels
	{
		get
		{
			return _app.Print_ShowSlideLabels;
		}
		set
		{
			_app.Print_ShowSlideLabels = value;
		}
	}

	public bool ShowSlideNotes
	{
		get
		{
			return _app.Print_ShowSlideNotes;
		}
		set
		{
			_app.Print_ShowSlideNotes = value;
		}
	}

	public bool ShowSlideNumbers
	{
		get
		{
			return _app.Print_ShowSlideNumbers;
		}
		set
		{
			_app.Print_ShowSlideNumbers = value;
		}
	}

	public int PrintColumns
	{
		get
		{
			return _app.Print_ColumnCount;
		}
		set
		{
			_app.Print_ColumnCount = value;
		}
	}

	public PrintOptions(IApp app)
	{
		_app = app;
		_app.PropertyChanged += app_PropertyChanged;
	}

	private void app_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		string propertyName = e.PropertyName;
		if (propertyName == null)
		{
			return;
		}
		switch (propertyName.Length)
		{
		case 17:
			switch (propertyName[6])
			{
			case 'I':
				if (propertyName == "Print_IsThumbnail")
				{
					OnPropertyChanged("IsThumbnail");
				}
				break;
			case 'C':
				if (propertyName == "Print_ColumnCount")
				{
					OnPropertyChanged("PrintColumns");
				}
				break;
			}
			break;
		case 15:
			switch (propertyName[6])
			{
			case 'I':
				if (propertyName == "Print_IsOutline")
				{
					OnPropertyChanged("IsOutline");
				}
				break;
			case 'S':
				if (propertyName == "Print_ShowNotes")
				{
					OnPropertyChanged("ShowNotes");
				}
				break;
			}
			break;
		case 21:
			switch (propertyName[10])
			{
			case 'C':
				if (propertyName == "Print_ShowCurrentDate")
				{
					OnPropertyChanged("ShowCurrentDate");
				}
				break;
			case 'S':
				if (propertyName == "Print_ShowSlideLabels")
				{
					OnPropertyChanged("ShowSlideLabels");
				}
				break;
			}
			break;
		case 19:
			if (propertyName == "Print_DisableSlides")
			{
				OnPropertyChanged("DisableSlides");
			}
			break;
		case 18:
			if (propertyName == "Print_ShowMetaData")
			{
				OnPropertyChanged("ShowMetaData");
			}
			break;
		case 20:
			if (propertyName == "Print_ShowSlideNotes")
			{
				OnPropertyChanged("ShowSlideNotes");
			}
			break;
		case 22:
			if (propertyName == "Print_ShowSlideNumbers")
			{
				OnPropertyChanged("ShowSlideNumbers");
			}
			break;
		case 16:
			break;
		}
	}
}
