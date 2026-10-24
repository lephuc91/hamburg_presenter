using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.ErrorReporting;
using Pro.Common.Mathematics;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.DO.Triggering;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.Entity.Merged.Entities;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.OutputConfiguration;

public abstract class ScreenArrangementBase : NotifyPropertyChangedBase, ITriggerable, IIdentifiable
{
	private string _name = string.Empty;

	private Screen[] _screens = Array.Empty<Screen>();

	private bool _hasConflictingScreens;

	private bool _backgroundEnabled;

	private System.Windows.Media.Color? _backgroundColor;

	private Vector2<double> _totalSize;

	public Guid ID { get; private set; } = Guid.NewGuid();

	public abstract ScreenArrangementType ArrangementType { get; }

	public ScreenTargetType ScreenTargetType { get; }

	public string Name
	{
		get
		{
			return _name;
		}
		set
		{
			SetValue("Name", ref _name, value, OnArrangementChanged);
		}
	}

	public Screen[] Screens => _screens;

	public Vector2<double> TotalSize
	{
		get
		{
			return _totalSize;
		}
		protected set
		{
			SetValue("TotalSize", ref _totalSize, value.Round(2), (System.Action)delegate
			{
				OnPropertyChanged("AspectRatio");
				OnArrangementChanged();
			}, (Predicate<Vector2<double>>?)null, referenceComparison: false);
		}
	}

	public double AspectRatio
	{
		get
		{
			if (!(TotalSize.Y > 0.0))
			{
				return 1.0;
			}
			return TotalSize.X / TotalSize.Y;
		}
	}

	public bool HasConflictingScreens
	{
		get
		{
			return _hasConflictingScreens;
		}
		internal set
		{
			SetValue("HasConflictingScreens", ref _hasConflictingScreens, value);
		}
	}

	public bool BackgroundEnabled
	{
		get
		{
			return _backgroundEnabled;
		}
		set
		{
			SetValue("BackgroundEnabled", ref _backgroundEnabled, value, OnArrangementChanged);
		}
	}

	public System.Windows.Media.Color? BackgroundColor
	{
		get
		{
			return _backgroundColor;
		}
		set
		{
			SetValue("BackgroundColor", ref _backgroundColor, value, OnArrangementChanged);
		}
	}

	public bool SupportsHdr => (from h in _screens.SelectMany((Screen s) => s.HardwareRectangles)
		select h.OutputDevice).NonNull().Any((IDevice h) => h.SupportsHdrRendering && h.SelectedHdrFormat.IsAnyOf(HdrFormats.Rec2100PQ, HdrFormats.Rec2100HLG));

	public event Action<ScreenArrangementBase>? ArrangementChanged;

	public virtual ObjectBinder<ScreenArrangementBase, IMergedScreen> Bind(IEntityFactory entityFactory, IMergedScreen entity, IErrorReporter errorReporter)
	{
		ObjectBinder<ScreenArrangementBase, IMergedScreen> objectBinder = new ObjectBinder<ScreenArrangementBase, IMergedScreen>(this, entity);
		objectBinder.Bind((ScreenArrangementBase l) => l.WhenPropertyChanges("Name"), (IMergedScreen r) => r.Name.WhenValueChanges, delegate(ScreenArrangementBase l, IMergedScreen r)
		{
			r.Name.Set(l.Name);
		}, delegate(IMergedScreen r, ScreenArrangementBase l)
		{
			l.Name = r.Name.Value;
		}).Bind((ScreenArrangementBase l) => l.WhenPropertyChanges("ID"), (IMergedScreen r) => r.Uuid.WhenValueChanges, delegate(ScreenArrangementBase l, IMergedScreen r)
		{
			r.Uuid.Set(l.ID);
		}, delegate(IMergedScreen r, ScreenArrangementBase l)
		{
			l.ID = r.Uuid.Value;
		}).Bind((ScreenArrangementBase l) => l.WhenPropertyChanges("ScreenTargetType"), (IMergedScreen r) => r.ScreenType.WhenValueChanges, delegate(ScreenArrangementBase l, IMergedScreen r)
		{
			r.ScreenType.Set(l.ScreenTargetType.ToEntityScreenType());
		}, delegate(IMergedScreen r, ScreenArrangementBase l)
		{
			if (l.ScreenTargetType != r.ScreenType.Value.ToScreenTargetType())
			{
				errorReporter.Error("Moving a screen between audience and stage output is not currently supported");
			}
		})
			.Bind((ScreenArrangementBase l) => l.WhenPropertyChanges("TotalSize"), (IMergedScreen r) => r.Size.WhenValueChanges, delegate(ScreenArrangementBase l, IMergedScreen r)
			{
				r.Size.Set(l.TotalSize.ToSize());
			}, delegate(IMergedScreen r, ScreenArrangementBase l)
			{
				l.UpdateTotalSize(r.Size.Value.ToVector2d());
			})
			.Bind((ScreenArrangementBase l) => l.WhenPropertyChanges("BackgroundEnabled"), (IMergedScreen r) => r.BackgroundColorEnabled.WhenValueChanges, delegate(ScreenArrangementBase l, IMergedScreen r)
			{
				r.BackgroundColorEnabled.Set(l.BackgroundEnabled);
			}, delegate(IMergedScreen r, ScreenArrangementBase l)
			{
				l.BackgroundEnabled = r.BackgroundColorEnabled.Value;
			})
			.Bind((ScreenArrangementBase l) => l.WhenPropertyChanges("BackgroundColor"), (IMergedScreen r) => r.BackgroundColor.WhenValueChanges, delegate(ScreenArrangementBase l, IMergedScreen r)
			{
				r.BackgroundColor.Set((l.BackgroundColor ?? Colors.Transparent).ToEntityColor());
			}, delegate(IMergedScreen r, ScreenArrangementBase l)
			{
				l.BackgroundColor = r.BackgroundColor.ToColor();
			});
		return objectBinder;
	}

	protected ScreenArrangementBase(ScreenTargetType screenTargetType, Guid? screenID = null)
	{
		if (screenID.HasValue)
		{
			ID = screenID.Value;
		}
		ScreenTargetType = screenTargetType;
	}

	protected abstract void UpdateScreenRects();

	protected virtual void ChangeScreenCount(int newCount, bool update = true, Screen[]? oldScreens = null)
	{
		int num = _screens.Length;
		for (int i = newCount; i < num; i++)
		{
			_screens[i].MainOutputSizeChanged -= UpdateScreenRects;
			_screens[i].ScreenChanged -= OnScreenChanged;
		}
		Array.Resize(ref _screens, newCount);
		for (int j = num; j < newCount; j++)
		{
			Screen screen = ((oldScreens != null && oldScreens.Length > j) ? oldScreens[j].Clone() : new Screen());
			if (screen != null)
			{
				_screens[j] = screen;
				_screens[j].MainOutputSizeChanged += UpdateScreenRects;
				_screens[j].ScreenChanged += OnScreenChanged;
			}
		}
		if (update)
		{
			OnScreensChanged();
		}
	}

	public virtual ProPresenterScreen Serialize()
	{
		return new ProPresenterScreen
		{
			Uuid = ID.ToUUID(),
			Name = Name,
			ScreenType = ScreenTargetType.ToProtoScreenType(),
			BackgroundColorEnabled = BackgroundEnabled,
			BackgroundColor = BackgroundColor?.ToProtoColor()
		};
	}

	public virtual void Deserialize(ProPresenterScreen screen)
	{
		if (screen != null)
		{
			if (screen.Uuid != null)
			{
				ID = screen.Uuid.ToGuid();
			}
			Name = screen.Name;
			BackgroundEnabled = screen.BackgroundColorEnabled;
			BackgroundColor = screen.BackgroundColor.ToColor();
		}
	}

	protected void DeserializeScreens(int screenCount, IEnumerable<Pro.SerializationInterop.RVProtoData.Screen> protoScreens)
	{
		ChangeScreenCount(screenCount, update: false);
		Pro.SerializationInterop.RVProtoData.Screen[] array = protoScreens.ToArray();
		for (int i = 0; i < _screens.Length && i < array.Length; i++)
		{
			_screens[i].Deserialize(array[i]);
		}
		EnsureScreensValid();
	}

	private void EnsureScreensValid()
	{
		Screen screen = Screens.FirstOrDefault();
		if (screen != null)
		{
			screen.Bounds = new Rect<double>((screen.Bounds.Position != Vector2<double>.Zero) ? Vector2<double>.Zero : screen.Bounds.Position, (screen.Bounds.Size != screen.MainOutput.Subrect.Size) ? screen.MainOutput.Subrect.Size : screen.Bounds.Size);
			EnsureBoundsValid();
		}
	}

	protected virtual void EnsureBoundsValid()
	{
		UpdateScreenRects();
	}

	protected void OnScreensChanged()
	{
		UpdateScreenRects();
		OnPropertyChanged("Screens");
		OnArrangementChanged();
		OnPropertyChanged("TotalSize");
	}

	protected void OnArrangementChanged()
	{
		this.ArrangementChanged?.Invoke(this);
	}

	private void OnScreenChanged(Screen screen)
	{
		OnArrangementChanged();
		if (screen != null && Screens.Any() && Screens.FirstOrDefault() == screen)
		{
			UpdateScreenRects();
		}
		else
		{
			UpdateTotalSize();
		}
		OnPropertyChanged("SupportsHdr");
	}

	protected virtual void UpdateTotalSize()
	{
	}

	protected abstract void UpdateTotalSize(Vector2<double> newTotalSize);

	public void CheckForConflicts(IEnumerable<Screen> otherScreens)
	{
		HardwareScreenRectangleOptions[] array = (from r in Screens.SelectMany((Screen s) => s.HardwareRectangles)
			where r.IsConfigured
			select r).ToArray();
		IEnumerable<HardwareScreenRectangleOptions> enumerable = (from r in otherScreens?.SelectMany((Screen s) => s.HardwareRectangles)
			where r.IsConfigured
			select r) ?? Enumerable.Empty<HardwareScreenRectangleOptions>();
		HasConflictingScreens = false;
		array.ForEach(delegate(HardwareScreenRectangleOptions r)
		{
			r.IsConflicting = false;
		});
		for (int i = 0; i < array.Length; i++)
		{
			for (int j = i + 1; j < array.Length; j++)
			{
				HardwareScreenRectangleOptions hardwareScreenRectangleOptions = array[i];
				HardwareScreenRectangleOptions hardwareScreenRectangleOptions2 = array[j];
				if (hardwareScreenRectangleOptions.OutputDevice == hardwareScreenRectangleOptions2.OutputDevice && hardwareScreenRectangleOptions.Subrect.Intersects(hardwareScreenRectangleOptions2.Subrect))
				{
					hardwareScreenRectangleOptions.IsConflicting = true;
					hardwareScreenRectangleOptions2.IsConflicting = true;
					HasConflictingScreens = true;
				}
			}
		}
		foreach (HardwareScreenRectangleOptions item in enumerable)
		{
			HardwareScreenRectangleOptions[] array2 = array;
			foreach (HardwareScreenRectangleOptions hardwareScreenRectangleOptions3 in array2)
			{
				if (item.OutputDevice == hardwareScreenRectangleOptions3.OutputDevice && item.Subrect.Intersects(hardwareScreenRectangleOptions3.Subrect))
				{
					hardwareScreenRectangleOptions3.IsConflicting = true;
					HasConflictingScreens = true;
				}
			}
		}
	}
}
