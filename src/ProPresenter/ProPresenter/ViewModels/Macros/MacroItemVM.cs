using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Windows.Media;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.DO.Triggering;
using ProPresenter.DO;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Calendar;
using ProPresenter.DO.Macros;
using ProPresenter.DO.PanelSourcing;
using ProPresenter.UI.ViewModels.Macros;
using ProPresenter.UI.ViewModels.MediaLibrary;

namespace ProPresenter.ViewModels.Macros;

public class MacroItemVM : LinkedNotifyPropertyChangedBase, IMacroItemVM, ITriggerable, INotifyPropertyChanged, IUniformViewSource
{
	private string _warningToolTip = string.Empty;

	private readonly IActionValidator _actionValidator;

	private bool _isTriggering;

	private bool _isSelected;

	private bool _isListIconPopUpOpen;

	private bool _isGridIconPopUpOpen;

	private readonly IEventCalendar _events;

	public ProPresenterMacro Macro { get; }

	public string Name
	{
		get
		{
			return Macro.Name;
		}
		set
		{
			Macro.Name = value;
		}
	}

	public Color Color
	{
		get
		{
			return Macro.Color;
		}
		set
		{
			Macro.Color = value;
		}
	}

	public IMacroGroupVM? Parent { get; }

	public bool TriggerOnStartup => Macro.TriggerOnStartup;

	public bool IsValid => Macro.IsValid;

	public string WarningMessage
	{
		get
		{
			return _warningToolTip;
		}
		private set
		{
			SetValue("WarningMessage", ref _warningToolTip, value);
		}
	}

	public bool IsTriggering
	{
		get
		{
			return _isTriggering;
		}
		set
		{
			SetValue("IsTriggering", ref _isTriggering, value);
		}
	}

	public bool IsSelected
	{
		get
		{
			return _isSelected;
		}
		set
		{
			SetValue("IsSelected", ref _isSelected, value);
		}
	}

	public bool IsListIconPopUpOpen
	{
		get
		{
			return _isListIconPopUpOpen;
		}
		set
		{
			SetValue("IsListIconPopUpOpen", ref _isListIconPopUpOpen, value);
		}
	}

	public bool IsGridIconPopUpOpen
	{
		get
		{
			return _isGridIconPopUpOpen;
		}
		set
		{
			SetValue("IsGridIconPopUpOpen", ref _isGridIconPopUpOpen, value);
		}
	}

	public IEnumerable<IScrimSource> ScrimItems => Macro.Actions.OfType<IScrimSource>();

	public bool IsSetToTriggerInCalendar => _events?.Any((EventCollection m) => m.Main?.EventAction is MacroAction macroAction && macroAction.MacroID == Macro.ID) ?? false;

	public IMediaCueThumbnailOverlayVM OverlayVM { get; }

	public ImageType ImageType
	{
		get
		{
			return Macro.ImageType;
		}
		set
		{
			Macro.ImageType = value;
		}
	}

	public double ThumbnailAspectRatio => 1.0;

	public int Index => 0;

	public MacroItemVM(ProPresenterMacro macro, IMacroGroupVM? parent, IMediaCueThumbnailOverlayVMFactory overlayVMFactory, IActionValidator actionValidator, IEventCalendar events)
	{
		Macro = macro;
		Parent = parent;
		Macro.Actions.CollectionChanged += delegate(object? _, NotifyCollectionChangedEventArgs e)
		{
			OnPropertyChanged("ScrimItems");
			e.NewItems?.OfType<MediaAction>().ForEach(delegate(MediaAction m)
			{
				m.FileMedia?.StartObservingSourceFile();
			});
			e.OldItems?.OfType<MediaAction>().ForEach(delegate(MediaAction m)
			{
				m.FileMedia?.StopObservingSourceFile();
			});
		};
		Macro.Actions.OfType<MediaAction>().ForEach(delegate(MediaAction m)
		{
			m.FileMedia?.StartObservingSourceFile();
		});
		_actionValidator = actionValidator;
		_events = events;
		LinkProperties("Name", "Name");
		LinkProperties("Color", "Color");
		LinkProperties("EventAction", "IsSetToTriggerInCalendar");
		LinkProperties("TriggerOnStartup", "TriggerOnStartup");
		LinkProperties("ImageType", "ImageType");
		LinkAction("IsValid", delegate
		{
			UpdateWarningMessage();
			OnPropertyChanged("IsValid");
		});
		Macro.PropertyChanged += base.RaiseLinkedValues;
		UpdateWarningMessage();
		_events.CollectionChanged += delegate(object? _, NotifyCollectionChangedEventArgs e)
		{
			e.OldItems?.OfType<EventCollection>().ForEach(delegate(EventCollection m)
			{
				m.Main.PropertyChanged -= base.RaiseLinkedValues;
			});
			e.NewItems?.OfType<EventCollection>().ForEach(delegate(EventCollection m)
			{
				m.Main.PropertyChanged += base.RaiseLinkedValues;
			});
			OnPropertyChanged("IsSetToTriggerInCalendar");
		};
		_events.ForEach(delegate(EventCollection m)
		{
			m.Main.PropertyChanged += base.RaiseLinkedValues;
		});
		OverlayVM = overlayVMFactory.Create(macro);
	}

	private void UpdateWarningMessage()
	{
		_actionValidator.Validate(Macro.Actions, out string warningMessage);
		WarningMessage = warningMessage;
	}
}
