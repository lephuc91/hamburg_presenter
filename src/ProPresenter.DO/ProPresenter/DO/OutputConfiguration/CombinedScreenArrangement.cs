using System;
using System.ComponentModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using Google.Protobuf.Collections;
using Pro.Common.ErrorReporting;
using Pro.Common.Mathematics;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.Entity.Merged.Entities;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.OutputConfiguration;

public class CombinedScreenArrangement : ScreenArrangementBase
{
	public static readonly int MaxRows = 4;

	public static readonly int MaxColumns = 4;

	private int _rowCount = 2;

	private int _columnCount = 2;

	public override ScreenArrangementType ArrangementType => ScreenArrangementType.Group;

	public int RowCount
	{
		get
		{
			return _rowCount;
		}
		set
		{
			SetValue("RowCount", ref _rowCount, value.Clamp(1, MaxRows), delegate(int o, int n)
			{
				ChangeScreenCount(n * ColumnCount);
			});
		}
	}

	public int ColumnCount
	{
		get
		{
			return _columnCount;
		}
		set
		{
			SetValue("ColumnCount", ref _columnCount, value.Clamp(1, MaxRows), delegate(int o, int n)
			{
				ChangeScreenCount(n * RowCount);
			});
		}
	}

	public override ObjectBinder<ScreenArrangementBase, IMergedScreen> Bind(IEntityFactory entityFactory, IMergedScreen right, IErrorReporter errorReporter)
	{
		IProPresenterScreen.Types.IArrangement.IArrangementCombined arrangementCombined = right.Arrangement.Value as IProPresenterScreen.Types.IArrangement.IArrangementCombined;
		if (arrangementCombined == null)
		{
			arrangementCombined = entityFactory.Create<IProPresenterScreen.Types.IArrangement.IArrangementCombined>();
			right.Arrangement.Set(arrangementCombined);
		}
		IReadOnlyObjectBinder arrangementBinder = CreateArrangementBinder(arrangementCombined.Value, entityFactory);
		return base.Bind(entityFactory, right, errorReporter).DoOnInitializeLeftFromRight(arrangementBinder.InitializeLeftFromRight).DoOnInitializeRightFromLeft(arrangementBinder.InitializeRightFromLeft)
			.RegisterChildDisposable(() => arrangementBinder);
	}

	private IReadOnlyObjectBinder CreateArrangementBinder(IProPresenterScreen.Types.ICombinedArrangement entity, IEntityFactory entityFactory)
	{
		ObjectBinder<CombinedScreenArrangement, IProPresenterScreen.Types.ICombinedArrangement> objectBinder = new ObjectBinder<CombinedScreenArrangement, IProPresenterScreen.Types.ICombinedArrangement>(this, entity);
		objectBinder.Bind((CombinedScreenArrangement l) => Observable.Merge<PropertyChangedEventArgs>(l.WhenPropertyChanges("RowCount"), l.WhenPropertyChanges("ColumnCount"), l.WhenPropertyChanges("Screens")), (IProPresenterScreen.Types.ICombinedArrangement r) => Observable.Merge<Unit>(r.Rows.WhenValueChanges.ToUnit(), r.Columns.WhenValueChanges.ToUnit(), r.Screens.WhenCollectionChanges.ToUnit()), delegate(CombinedScreenArrangement l, IProPresenterScreen.Types.ICombinedArrangement r)
		{
			if (l.RowCount * l.ColumnCount == l.Screens.Length)
			{
				r.Rows.Set((uint)l.RowCount);
				r.Columns.Set((uint)l.ColumnCount);
				r.Screens.SynchronizeFrom(l.Screens, (Screen m, IScreen e) => m.ID == e.Uuid.Value, delegate(Screen m)
				{
					IScreen screen = entityFactory.Create<IScreen>();
					ObjectBinder<Screen, IScreen> objectBinder2 = m.Bind(entityFactory, screen);
					screen.RegisterLinkedDisposable(objectBinder2);
					objectBinder2.InitializeRightFromLeft();
					return screen;
				});
			}
		}, delegate(IProPresenterScreen.Types.ICombinedArrangement r, CombinedScreenArrangement l)
		{
			if (r.Rows.Value * r.Columns.Value == r.Screens.Items.Count)
			{
				l.RowCount = Math.Max(1, (int)r.Rows.Value);
				l.ColumnCount = Math.Max(1, (int)r.Columns.Value);
				ChangeScreenCount(r.Screens.Items.Count, update: false);
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
			}
		});
		return objectBinder;
	}

	public CombinedScreenArrangement(ScreenTargetType screenTargetType, Screen[]? oldScreens = null, Guid? screenID = null)
		: base(screenTargetType, screenID)
	{
		if (oldScreens != null && oldScreens.Length > 1)
		{
			_rowCount = 1;
			_columnCount = oldScreens.Length.Clamp(1, MaxColumns);
		}
		ChangeScreenCount(RowCount * ColumnCount, update: true, oldScreens);
	}

	protected override void UpdateScreenRects()
	{
		Rect<double> subrect = base.Screens[0].MainOutput.Subrect;
		for (int i = 0; i < RowCount; i++)
		{
			for (int j = 0; j < ColumnCount; j++)
			{
				base.Screens[j + i * ColumnCount].Bounds = new Rect<double>(new Vector2<double>((double)j * subrect.Size.X, (double)i * subrect.Size.Y), subrect.Size);
			}
		}
		UpdateTotalSize();
	}

	protected override void UpdateTotalSize()
	{
		Vector2<double> size = base.Screens[0].MainOutput.Subrect.Size;
		base.TotalSize = new Vector2<double>(size.X * (double)ColumnCount, size.Y * (double)RowCount);
	}

	protected override void UpdateTotalSize(Vector2<double> newSize)
	{
		Vector2<double> size = new Vector2<double>(newSize.X / (double)ColumnCount, newSize.Y / (double)RowCount);
		Screen[] screens = base.Screens;
		foreach (Screen obj in screens)
		{
			Rect<double> subrect = obj.MainOutput.Subrect;
			subrect.Size = size;
			obj.MainOutput.Subrect = subrect;
		}
	}

	public override ProPresenterScreen Serialize()
	{
		ProPresenterScreen proPresenterScreen = base.Serialize();
		ProPresenterScreen.Types.CombinedArrangement combinedArrangement = new ProPresenterScreen.Types.CombinedArrangement
		{
			Columns = (uint)ColumnCount,
			Rows = (uint)RowCount
		};
		combinedArrangement.Screens.AddRange(base.Screens.Select((Screen s) => s.Serialize()));
		proPresenterScreen.ArrangementCombined = combinedArrangement;
		return proPresenterScreen;
	}

	public override void Deserialize(ProPresenterScreen screen)
	{
		base.Deserialize(screen);
		ProPresenterScreen.Types.CombinedArrangement arrangementCombined = screen.ArrangementCombined;
		if (arrangementCombined != null)
		{
			ColumnCount = (int)arrangementCombined.Columns;
			RowCount = (int)arrangementCombined.Rows;
			RepeatedField<Pro.SerializationInterop.RVProtoData.Screen> screens = arrangementCombined.Screens;
			if (screens != null && screens.Any())
			{
				DeserializeScreens(RowCount * ColumnCount, arrangementCombined.Screens);
			}
		}
	}
}
