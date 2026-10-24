using System;
using System.Linq;
using Pro.Common.ErrorReporting;
using Pro.Common.Mathematics;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.Entity.Merged.Entities;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.OutputConfiguration;

public class SingleScreenArrangement : ScreenArrangementBase
{
	public static readonly int MaxMirroredScreens = 5;

	private int _screenCount;

	public override ScreenArrangementType ArrangementType
	{
		get
		{
			if (ScreenCount != 1)
			{
				return ScreenArrangementType.Mirror;
			}
			return ScreenArrangementType.Single;
		}
	}

	public int ScreenCount
	{
		get
		{
			return _screenCount;
		}
		set
		{
			SetValue("ScreenCount", ref _screenCount, value.Clamp(1, MaxMirroredScreens), OnScreenCountChanged);
		}
	}

	public override ObjectBinder<ScreenArrangementBase, IMergedScreen> Bind(IEntityFactory entityFactory, IMergedScreen entity, IErrorReporter errorReporter)
	{
		IProPresenterScreen.Types.IArrangement.IArrangementSingle arrangementSingle = entity.Arrangement.Value as IProPresenterScreen.Types.IArrangement.IArrangementSingle;
		if (arrangementSingle == null)
		{
			arrangementSingle = entityFactory.Create<IProPresenterScreen.Types.IArrangement.IArrangementSingle>();
			entity.Arrangement.Set(arrangementSingle);
		}
		ObjectBinder<ScreenArrangementBase, IMergedScreen> objectBinder = base.Bind(entityFactory, entity, errorReporter);
		ObjectBinder<SingleScreenArrangement, IProPresenterScreen.Types.ISingleArrangement> arrangementBinder = new ObjectBinder<SingleScreenArrangement, IProPresenterScreen.Types.ISingleArrangement>(this, arrangementSingle.Value);
		arrangementBinder.Bind((SingleScreenArrangement l) => l.WhenPropertyChanges("Screens"), (IProPresenterScreen.Types.ISingleArrangement r) => r.Screens.WhenCollectionChanges, delegate(SingleScreenArrangement l, IProPresenterScreen.Types.ISingleArrangement r)
		{
			r.Screens.SynchronizeFrom(l.Screens, (Screen m, IScreen e) => m.ID == e.Uuid.Value, delegate(Screen m)
			{
				IScreen screen = entityFactory.Create<IScreen>();
				ObjectBinder<Screen, IScreen> objectBinder2 = m.Bind(entityFactory, screen);
				screen.RegisterLinkedDisposable(objectBinder2);
				objectBinder2.InitializeRightFromLeft();
				return screen;
			});
		}, delegate(IProPresenterScreen.Types.ISingleArrangement r, SingleScreenArrangement l)
		{
			int screenCount = Math.Max(1, r.Screens.Items.Count);
			l.ScreenCount = screenCount;
			r.Screens.Items.SynchronizeTo(l.Screens, (IScreen e, Screen m) => e.Uuid.Value == m.ID, delegate(IScreen e, int i)
			{
				ObjectBinder<Screen, IScreen> objectBinder3 = l.Screens[i].Bind(entityFactory, e);
				e.RegisterLinkedDisposable(objectBinder3);
				objectBinder3.InitializeLeftFromRight();
			}, delegate(int from, int to)
			{
				if (from < to)
				{
					Screen screen2 = l.Screens[from];
					while (from < to)
					{
						l.Screens[from] = l.Screens[from + 1];
						from++;
					}
					l.Screens[to] = screen2;
				}
				else
				{
					Screen screen3 = l.Screens[from];
					while (from > to)
					{
						l.Screens[from] = l.Screens[from - 1];
						from--;
					}
					l.Screens[to] = screen3;
				}
			}, delegate
			{
			});
		});
		objectBinder.DoOnInitializeLeftFromRight(arrangementBinder.InitializeLeftFromRight).DoOnInitializeRightFromLeft(arrangementBinder.InitializeRightFromLeft).RegisterChildDisposable(() => arrangementBinder);
		return objectBinder;
	}

	public SingleScreenArrangement(ScreenTargetType screenTargetType, Screen[]? oldScreens = null, int screenCount = 1, Guid? screenID = null)
		: base(screenTargetType, screenID)
	{
		_screenCount = screenCount.Clamp(1, MaxMirroredScreens);
		ChangeScreenCount(_screenCount, update: true, oldScreens);
	}

	protected override void UpdateScreenRects()
	{
		Rect<double> subrect = base.Screens[0].MainOutput.Subrect;
		Screen[] screens = base.Screens;
		for (int i = 0; i < screens.Length; i++)
		{
			screens[i].Bounds = new Rect<double>(Vector2<double>.Zero, subrect.Size);
		}
		UpdateTotalSize();
	}

	protected override void UpdateTotalSize()
	{
		base.TotalSize = base.Screens[0].MainOutput.Subrect.Size;
	}

	protected override void UpdateTotalSize(Vector2<double> newSize)
	{
		Rect<double> subrect = base.Screens[0].MainOutput.Subrect;
		subrect.Size = newSize;
		base.Screens[0].MainOutput.Subrect = subrect;
	}

	public override ProPresenterScreen Serialize()
	{
		ProPresenterScreen proPresenterScreen = base.Serialize();
		ProPresenterScreen.Types.SingleArrangement singleArrangement = new ProPresenterScreen.Types.SingleArrangement();
		singleArrangement.Screens.AddRange(base.Screens.Select((Screen s) => s.Serialize()));
		proPresenterScreen.ArrangementSingle = singleArrangement;
		return proPresenterScreen;
	}

	public override void Deserialize(ProPresenterScreen screen)
	{
		base.Deserialize(screen);
		ProPresenterScreen.Types.SingleArrangement arrangementSingle = screen.ArrangementSingle;
		if (arrangementSingle?.Screens?.Any() == true)
		{
			ScreenCount = arrangementSingle.Screens.Count;
			DeserializeScreens(ScreenCount, arrangementSingle.Screens);
		}
	}

	private void OnScreenCountChanged(int o, int n)
	{
		ChangeScreenCount(n);
		OnPropertyChanged("ArrangementType");
	}
}
