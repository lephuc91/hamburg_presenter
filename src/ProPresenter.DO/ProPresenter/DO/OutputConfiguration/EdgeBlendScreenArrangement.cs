using System;
using System.Linq;
using System.Reactive.Disposables;
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

public class EdgeBlendScreenArrangement : ScreenArrangementBase
{
	public static readonly int MaxScreens = 5;

	private int _screenCount = 2;

	private EdgeBlendOptions[] _edgeBlends = Array.Empty<EdgeBlendOptions>();

	private Vector2<double> _totalSize = Vector2<double>.Zero;

	private bool _ignoreScreenChanges;

	public override ScreenArrangementType ArrangementType => ScreenArrangementType.EdgeBlend;

	public int ScreenCount
	{
		get
		{
			return _screenCount;
		}
		set
		{
			if (value < 2)
			{
				throw new ArgumentOutOfRangeException("ScreenCount");
			}
			SetValue("ScreenCount", ref _screenCount, value.Clamp(2, MaxScreens), delegate(int o, int n)
			{
				ChangeScreenCount(n);
			});
		}
	}

	public EdgeBlendOptions[] EdgeBlends
	{
		get
		{
			return _edgeBlends;
		}
		private set
		{
			SetValue("EdgeBlends", ref _edgeBlends, value);
		}
	}

	public override ObjectBinder<ScreenArrangementBase, IMergedScreen> Bind(IEntityFactory entityFactory, IMergedScreen right, IErrorReporter errorReporter)
	{
		IProPresenterScreen.Types.IArrangement.IArrangementEdgeBlend arrangementEdgeBlend = right.Arrangement.Value as IProPresenterScreen.Types.IArrangement.IArrangementEdgeBlend;
		if (arrangementEdgeBlend == null)
		{
			arrangementEdgeBlend = entityFactory.Create<IProPresenterScreen.Types.IArrangement.IArrangementEdgeBlend>();
			right.Arrangement.Set(arrangementEdgeBlend);
		}
		IReadOnlyObjectBinder readOnlyObjectBinder = CreateArrangementBinder(arrangementEdgeBlend.Value, entityFactory);
		return base.Bind(entityFactory, right, errorReporter).DoOnInitializeLeftFromRight(readOnlyObjectBinder.InitializeLeftFromRight).DoOnInitializeRightFromLeft(readOnlyObjectBinder.InitializeRightFromLeft)
			.RegisterChildDisposable(new CompositeDisposable { readOnlyObjectBinder });
	}

	protected IReadOnlyObjectBinder CreateArrangementBinder(IProPresenterScreen.Types.IEdgeBlendArrangement entity, IEntityFactory entityFactory)
	{
		ObjectBinder<EdgeBlendScreenArrangement, IProPresenterScreen.Types.IEdgeBlendArrangement> objectBinder = new ObjectBinder<EdgeBlendScreenArrangement, IProPresenterScreen.Types.IEdgeBlendArrangement>(this, entity);
		objectBinder.Bind((EdgeBlendScreenArrangement l) => l.WhenPropertyChanges("ScreenCount"), (IProPresenterScreen.Types.IEdgeBlendArrangement r) => r.ScreenCount.WhenValueChanges, delegate(EdgeBlendScreenArrangement l, IProPresenterScreen.Types.IEdgeBlendArrangement r)
		{
			r.ScreenCount.Set((uint)l.ScreenCount);
		}, delegate(IProPresenterScreen.Types.IEdgeBlendArrangement r, EdgeBlendScreenArrangement l)
		{
			l.ChangeScreenCount((int)r.ScreenCount.Value, update: false);
		}).Bind((EdgeBlendScreenArrangement l) => l.WhenPropertyChanges("Screens").ToUnit().Merge(l.WhenPropertyChanges("EdgeBlends").ToUnit()), (IProPresenterScreen.Types.IEdgeBlendArrangement r) => r.EdgeBlends.WhenCollectionChanges.ToUnit().Merge(r.Screens.WhenCollectionChanges.ToUnit()), delegate(EdgeBlendScreenArrangement l, IProPresenterScreen.Types.IEdgeBlendArrangement r)
		{
			if (l.Screens.Length - 1 == l.EdgeBlends.Length)
			{
				r.Screens.SynchronizeFrom(l.Screens, (Screen m, IScreen e) => m.ID == e.Uuid.Value, delegate(Screen m)
				{
					IScreen screen = entityFactory.Create<IScreen>();
					ObjectBinder<Screen, IScreen> objectBinder2 = m.Bind(entityFactory, screen);
					screen.RegisterLinkedDisposable(objectBinder2);
					objectBinder2.InitializeRightFromLeft();
					return screen;
				});
				r.EdgeBlends.SynchronizeFrom(l.EdgeBlends, (EdgeBlendOptions m, IEdgeBlend e) => m.FirstScreen.Screen.ID == e.Uuid.Value, delegate(EdgeBlendOptions m)
				{
					IEdgeBlend edgeBlend = entityFactory.Create<IEdgeBlend>();
					ObjectBinder<EdgeBlendOptions, IEdgeBlend> objectBinder3 = m.Bind(entityFactory, edgeBlend);
					edgeBlend.RegisterLinkedDisposable(objectBinder3);
					objectBinder3.InitializeRightFromLeft();
					return edgeBlend;
				});
			}
		}, delegate(IProPresenterScreen.Types.IEdgeBlendArrangement r, EdgeBlendScreenArrangement l)
		{
			if (r.Screens.Items.Count - 1 == r.EdgeBlends.Items.Count)
			{
				ChangeScreenCount(r.Screens.Items.Count, update: false);
				r.Screens.Items.SynchronizeTo(l.Screens, (IScreen e, Screen m) => e.Uuid.Value == m.ID, delegate(IScreen e, int i)
				{
					ObjectBinder<Screen, IScreen> objectBinder4 = l.Screens[i].Bind(entityFactory, e);
					e.RegisterLinkedDisposable(objectBinder4);
					objectBinder4.InitializeLeftFromRight();
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
				r.EdgeBlends.Items.SynchronizeTo(l.EdgeBlends, (IEdgeBlend e, EdgeBlendOptions m) => e.Uuid.Value == m.FirstScreen.Screen.ID, delegate(IEdgeBlend e, int i)
				{
					ObjectBinder<EdgeBlendOptions, IEdgeBlend> objectBinder5 = l.EdgeBlends[i].Bind(entityFactory, e);
					e.RegisterLinkedDisposable(objectBinder5);
					objectBinder5.InitializeLeftFromRight();
				}, delegate(int from, int to)
				{
					if (from < to)
					{
						EdgeBlendOptions edgeBlendOptions = l.EdgeBlends[from];
						while (from < to)
						{
							l.EdgeBlends[from] = l.EdgeBlends[from + 1];
							from++;
						}
						l.EdgeBlends[to] = edgeBlendOptions;
					}
					else
					{
						EdgeBlendOptions edgeBlendOptions2 = l.EdgeBlends[from];
						while (from > to)
						{
							l.EdgeBlends[from] = l.EdgeBlends[from - 1];
							from--;
						}
						l.EdgeBlends[to] = edgeBlendOptions2;
					}
				}, delegate
				{
				});
			}
		});
		return objectBinder;
	}

	public EdgeBlendScreenArrangement(ScreenTargetType screenTargetType, Screen[]? oldScreens = null, Guid? screenID = null)
		: base(screenTargetType, screenID)
	{
		if (oldScreens != null && oldScreens.Length > 1)
		{
			_screenCount = oldScreens.Length;
		}
		ChangeScreenCount(ScreenCount, update: true, oldScreens);
	}

	protected override void ChangeScreenCount(int newCount, bool update = true, Screen[]? oldScreens = null)
	{
		int num = base.Screens.Length;
		newCount = newCount.Clamp(2, MaxScreens);
		_screenCount = newCount;
		base.ChangeScreenCount(newCount, update: false, oldScreens);
		for (int i = newCount - 1; i < Math.Max(num - 1, 0); i++)
		{
			_edgeBlends[i].WidthChanged -= UpdateScreenRects;
			_edgeBlends[i].EdgeBlendChanged -= OnBlendChanged;
		}
		Array.Resize(ref _edgeBlends, newCount - 1);
		for (int j = Math.Max(num - 1, 0); j < newCount - 1; j++)
		{
			_edgeBlends[j] = new EdgeBlendOptions(new BlendScreen(base.Screens[j]), new BlendScreen(base.Screens[j + 1]));
			_edgeBlends[j].WidthChanged += UpdateScreenRects;
			_edgeBlends[j].EdgeBlendChanged += OnBlendChanged;
		}
		if (update)
		{
			OnScreensChanged();
		}
	}

	protected override void UpdateScreenRects()
	{
		if (!_ignoreScreenChanges)
		{
			Vector2<double> size = base.Screens[0].MainOutput.Subrect.Size;
			Vector2<double> vector = new Vector2<double>(size.X, 0.0);
			base.Screens[0].Bounds = new Rect<double>(Vector2<double>.Zero, size);
			for (int i = 1; i < base.Screens.Length; i++)
			{
				Screen screen = base.Screens[i];
				EdgeBlendOptions edgeBlendOptions = _edgeBlends[i - 1];
				screen.Bounds = new Rect<double>(vector - new Vector2<double>(edgeBlendOptions.Width, 0.0), size);
				vector.X = screen.Bounds.Right;
			}
			UpdateTotalSize();
		}
	}

	protected override void UpdateTotalSize()
	{
		Vector2<double> size = base.Screens[0].MainOutput.Subrect.Size;
		base.TotalSize = new Vector2<double>(size.X * (double)base.Screens.Length - EdgeBlends.Sum((EdgeBlendOptions e) => e.Width), size.Y);
	}

	protected override void UpdateTotalSize(Vector2<double> newSize)
	{
		double num = base.Screens.Sum((Screen s) => s.MainOutput.Subrect.Size.X) - EdgeBlends.Sum((EdgeBlendOptions e) => e.Width);
		double num2 = (newSize.X - num) / (double)base.Screens.Length;
		Screen[] screens = base.Screens;
		foreach (Screen obj in screens)
		{
			Rect<double> subrect = obj.MainOutput.Subrect;
			subrect.Size = new Vector2<double>(subrect.Size.X + num2, newSize.Y);
			obj.MainOutput.Subrect = subrect;
		}
	}

	public override ProPresenterScreen Serialize()
	{
		ProPresenterScreen proPresenterScreen = base.Serialize();
		ProPresenterScreen.Types.EdgeBlendArrangement edgeBlendArrangement = new ProPresenterScreen.Types.EdgeBlendArrangement
		{
			ScreenCount = (uint)ScreenCount
		};
		edgeBlendArrangement.EdgeBlends.AddRange(_edgeBlends.Select((EdgeBlendOptions e) => e.Serialize()));
		edgeBlendArrangement.Screens.AddRange(base.Screens.Select((Screen s) => s.Serialize()));
		proPresenterScreen.ArrangementEdgeBlend = edgeBlendArrangement;
		return proPresenterScreen;
	}

	public override void Deserialize(ProPresenterScreen screen)
	{
		_ignoreScreenChanges = true;
		base.Deserialize(screen);
		ProPresenterScreen.Types.EdgeBlendArrangement arrangementEdgeBlend = screen.ArrangementEdgeBlend;
		if (arrangementEdgeBlend != null)
		{
			ScreenCount = (int)arrangementEdgeBlend.ScreenCount;
			RepeatedField<Pro.SerializationInterop.RVProtoData.Screen> screens = arrangementEdgeBlend.Screens;
			if (screens != null && screens.Any())
			{
				DeserializeScreens(ScreenCount, arrangementEdgeBlend.Screens);
			}
			RepeatedField<EdgeBlend> edgeBlends = arrangementEdgeBlend.EdgeBlends;
			if (edgeBlends != null && edgeBlends.Any())
			{
				DeserializeEdgeBlends(arrangementEdgeBlend.EdgeBlends.ToArray());
			}
			UpdateTotalSize();
			_ignoreScreenChanges = false;
		}
	}

	private void DeserializeEdgeBlends(EdgeBlend[] edgeBlends)
	{
		for (int i = 0; i < ScreenCount - 1; i++)
		{
			EdgeBlends[i].Deserialize(edgeBlends[i]);
			EdgeBlends[i].Width = EdgeBlends[i].FirstScreen.Screen.Bounds.Right - EdgeBlends[i].SecondScreen.Screen.Bounds.Left;
		}
	}

	private void OnBlendChanged(EdgeBlendOptions edgeBlend)
	{
		OnArrangementChanged();
	}

	protected override void EnsureBoundsValid()
	{
		Screen screen = base.Screens[0];
		if (screen.Bounds.Position != Vector2<double>.Zero)
		{
			screen.Bounds = new Rect<double>(Vector2<double>.Zero, screen.Bounds.Size);
		}
		double num = 0.0;
		double num2 = 0.0;
		for (int i = 1; i < base.Screens.Length; i++)
		{
			Screen screen2 = base.Screens[i];
			if (screen2.Bounds.Position.X > screen.Bounds.Size.X * (double)i)
			{
				num = screen2.OutputSize.X * (double)i - screen2.Bounds.Position.X - num;
				double num3 = screen.Bounds.Size.X * (double)i * num / (screen2.OutputSize.X * (double)i);
				screen2.Bounds = new Rect<double>(new Vector2<double>(screen.Bounds.Size.X * (double)i - num3 - num2, 0.0), screen.Bounds.Size);
				num2 += num3;
			}
		}
	}
}
