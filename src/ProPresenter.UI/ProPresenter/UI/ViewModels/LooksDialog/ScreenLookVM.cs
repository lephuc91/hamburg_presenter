using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using Pro.Common.SourceGenerator.Attributes;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Looks;
using ProPresenter.DO.Masks;
using ProPresenter.DO.OutputConfiguration;
using ProPresenter.DO.Themes;

namespace ProPresenter.UI.ViewModels.LooksDialog;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { })]
public class ScreenLookVM : ObservableObject, IDisposable
{
	private readonly IThemeCollection _themes;

	private readonly IMaskCollection _masks;

	private readonly AudienceScreenArrangementCollection _audienceScreens;

	[Pro.Common.SourceGenerator.Attributes.PropertyLink("MaskId", "Mask")]
	[Pro.Common.SourceGenerator.Attributes.PropertyLink("MessagesEnabled", "MessagesEnabled")]
	[Pro.Common.SourceGenerator.Attributes.PropertyLink("PropsEnabled", "PropsEnabled")]
	[Pro.Common.SourceGenerator.Attributes.PropertyLink("AnnouncementEnabled", "AnnouncementEnabled")]
	[Pro.Common.SourceGenerator.Attributes.PropertyLink("TemplateId", "Template")]
	[Pro.Common.SourceGenerator.Attributes.PropertyLink("ForegroundEnabled", "ForegroundEnabled")]
	[Pro.Common.SourceGenerator.Attributes.PropertyLink("BackgroundEnabled", "BackgroundEnabled")]
	[Pro.Common.SourceGenerator.Attributes.PropertyLink("LiveVideoEnabled", "LiveVideoEnabled")]
	[Pro.Common.SourceGenerator.Attributes.PropertyLink("ScreenId", "ScreenName")]
	private readonly ScreenLook _look;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public string? ScreenName => _audienceScreens.FirstOrDefault(delegate(ScreenArrangementBase x)
	{
		Guid iD = x.ID;
		Guid? screenId = _look.ScreenId;
		return iD == screenId;
	})?.Name;

	public SlideCue? Mask
	{
		get
		{
			if (_look.MaskId.HasValue)
			{
				return _masks.FirstOrDefault((SlideCue m) => m.SlideAction?.Slide.ID == _look.MaskId.Value);
			}
			return null;
		}
		set
		{
			_look.MaskId = value?.SlideAction?.Slide.ID;
		}
	}

	public bool MessagesEnabled
	{
		get
		{
			return _look.MessagesEnabled;
		}
		set
		{
			_look.MessagesEnabled = value;
		}
	}

	public bool PropsEnabled
	{
		get
		{
			return _look.PropsEnabled;
		}
		set
		{
			_look.PropsEnabled = value;
		}
	}

	public bool AnnouncementEnabled
	{
		get
		{
			return _look.AnnouncementEnabled;
		}
		set
		{
			_look.AnnouncementEnabled = value;
		}
	}

	public TemplateSlide? Template
	{
		get
		{
			if (_look.TemplateId.HasValue)
			{
				return _themes.FindTemplate(_look.TemplateId.Value, "", useDefault: false);
			}
			return null;
		}
		set
		{
			_look.UpdateTemplate(value);
		}
	}

	public bool ForegroundEnabled
	{
		get
		{
			return _look.ForegroundEnabled;
		}
		set
		{
			_look.ForegroundEnabled = value;
		}
	}

	public bool BackgroundEnabled
	{
		get
		{
			return _look.BackgroundEnabled;
		}
		set
		{
			_look.BackgroundEnabled = value;
		}
	}

	public bool LiveVideoEnabled
	{
		get
		{
			return _look.LiveVideoEnabled;
		}
		set
		{
			_look.LiveVideoEnabled = value;
		}
	}

	public ScreenLookVM(IThemeCollection themes, IMaskCollection masks, AudienceScreenArrangementCollection audienceScreens, ScreenLook look)
	{
		_themes = themes;
		_masks = masks;
		_audienceScreens = audienceScreens;
		_look = look;
		AddPropertyLinks();
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	protected virtual void Dispose(bool disposing)
	{
		if (!_disposed && disposing)
		{
			_disposed = true;
			OnDispose();
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void OnDispose()
	{
		RemovePropertyLinks();
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void _look_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		string propertyName = e.PropertyName;
		if (propertyName == null)
		{
			return;
		}
		switch (propertyName.Length)
		{
		case 17:
			switch (propertyName[0])
			{
			case 'F':
				if (propertyName == "ForegroundEnabled")
				{
					OnPropertyChanged("ForegroundEnabled");
				}
				break;
			case 'B':
				if (propertyName == "BackgroundEnabled")
				{
					OnPropertyChanged("BackgroundEnabled");
				}
				break;
			}
			break;
		case 6:
			if (propertyName == "MaskId")
			{
				OnPropertyChanged("Mask");
			}
			break;
		case 15:
			if (propertyName == "MessagesEnabled")
			{
				OnPropertyChanged("MessagesEnabled");
			}
			break;
		case 12:
			if (propertyName == "PropsEnabled")
			{
				OnPropertyChanged("PropsEnabled");
			}
			break;
		case 19:
			if (propertyName == "AnnouncementEnabled")
			{
				OnPropertyChanged("AnnouncementEnabled");
			}
			break;
		case 10:
			if (propertyName == "TemplateId")
			{
				OnPropertyChanged("Template");
			}
			break;
		case 16:
			if (propertyName == "LiveVideoEnabled")
			{
				OnPropertyChanged("LiveVideoEnabled");
			}
			break;
		case 8:
			if (propertyName == "ScreenId")
			{
				OnPropertyChanged("ScreenName");
			}
			break;
		case 7:
		case 9:
		case 11:
		case 13:
		case 14:
		case 18:
			break;
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void AddPropertyLinks()
	{
		_look.PropertyChanged += _look_PropertyChanged;
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void RemovePropertyLinks()
	{
		_look.PropertyChanged -= _look_PropertyChanged;
	}
}
