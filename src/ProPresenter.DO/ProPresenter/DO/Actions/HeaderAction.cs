using System.Linq;
using System.Windows.Media;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.DO.Triggering;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Actions;

public class HeaderAction : ActionBase
{
	private System.Windows.Media.Color _color;

	private readonly TimerAction _timerAction;

	public override ActionType ActionType => ActionType.Header;

	public System.Windows.Media.Color Color
	{
		get
		{
			return _color;
		}
		set
		{
			SetValue("Color", ref _color, value, delegate(System.Windows.Media.Color o, System.Windows.Media.Color n)
			{
				base.UndoStack?.Commit(UndoActionTypes.HeaderColor.ToAction(), this, "Color", o, n);
				OnDataModified();
			});
		}
	}

	public TimerAction Timer => _timerAction;

	public static ObjectBinder<HeaderAction, IPlaylistItem.Types.IHeader> CreateBinder(IUiScheduler scheduler, IEntityFactory entityFactory, HeaderAction left, IPlaylistItem.Types.IHeader? right)
	{
		ObjectBinder<HeaderAction, IPlaylistItem.Types.IHeader> objectBinder = new ObjectBinder<HeaderAction, IPlaylistItem.Types.IHeader>(left, right);
		objectBinder.Bind((HeaderAction l) => l.WhenPropertyChanges("Color"), (IPlaylistItem.Types.IHeader r) => r.Color.WhenValueChanges, delegate(HeaderAction l, IPlaylistItem.Types.IHeader r)
		{
			r.Color.Set(l.Color.ToEntityColor());
		}, delegate(IPlaylistItem.Types.IHeader r, HeaderAction l)
		{
			l.Color = r.Color.Value.ToColor();
		}).Bind((HeaderAction l) => l.WhenPropertyChanges("Timer"), (IPlaylistItem.Types.IHeader r) => r.Actions.WhenCollectionChanges, delegate(HeaderAction l, IPlaylistItem.Types.IHeader r)
		{
			Pro.Entity.IAction action = entityFactory.Create<Pro.Entity.IAction>();
			Pro.Entity.IAction.Types.IActionTypeData.ITimer value = entityFactory.Create<Pro.Entity.IAction.Types.IActionTypeData.ITimer>();
			action.ActionTypeData.Set(value);
			r.Actions.Reset(new global::_003C_003Ez__ReadOnlySingleElementList<Pro.Entity.IAction>(action));
			ObjectBinder<Pro.DO.Triggering.IAction, Pro.Entity.IAction> objectBinder2 = TimerAction.CreateBinder(scheduler, entityFactory, l.Timer, action);
			objectBinder2.InitializeRightFromLeft();
			action.RegisterLinkedDisposable(objectBinder2);
		}, delegate(IPlaylistItem.Types.IHeader r, HeaderAction l)
		{
			Pro.Entity.IAction action2 = r.Actions.Items.FirstOrDefault((Pro.Entity.IAction a) => a.ActionTypeData.Value is Pro.Entity.IAction.Types.IActionTypeData.ITimer);
			if (action2 != null)
			{
				ObjectBinder<Pro.DO.Triggering.IAction, Pro.Entity.IAction> objectBinder3 = TimerAction.CreateBinder(scheduler, entityFactory, l.Timer, action2);
				objectBinder3.InitializeLeftFromRight();
				action2.RegisterLinkedDisposable(objectBinder3);
			}
		});
		return objectBinder;
	}

	public HeaderAction(string name, TimerAction? timerAction = null)
	{
		base.Name = name;
		_timerAction = timerAction ?? new TimerAction();
		_timerAction.DataModified += base.OnDataModified;
	}

	public HeaderAction()
		: this(string.Empty)
	{
	}

	public override Pro.DO.Triggering.IAction Clone()
	{
		return CopyProperties(new HeaderAction(base.Name, (TimerAction)_timerAction.Clone())
		{
			_color = _color
		});
	}

	internal PlaylistItem.Types.Header ProtoSerializePlaylistItemHeader()
	{
		return new PlaylistItem.Types.Header
		{
			Color = Color.ToProtoColor(),
			Actions = { _timerAction.Serialize() }
		};
	}

	internal void ProtoDeserializePlaylistItemHeader(PlaylistItem.Types.Header headerPlaylistItem)
	{
		Action action = headerPlaylistItem.Actions.FirstOrDefault();
		Color = headerPlaylistItem.Color.ToColor();
		if (action?.Timer.TimerConfiguration != null)
		{
			_timerAction.Deserialize(action, null, "");
		}
	}

	protected override void OnUndoStackChanged(UndoStack undoStack)
	{
		_timerAction.UndoStack = undoStack;
	}
}
