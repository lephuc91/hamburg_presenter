using System;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Cues;
using ProPresenter.DO.OutputConfiguration;

namespace ProPresenter.DO.Actions;

public class StageScreenAssignment : NotifyPropertyChangedBase, ICloneable<StageScreenAssignment>
{
	private Identifier _screen;

	private Identifier? _layout;

	private bool _canAssign = true;

	private bool _isValid = true;

	public Identifier Screen
	{
		get
		{
			return _screen;
		}
		set
		{
			SetValue("Screen", ref _screen, value, delegate(Identifier o, Identifier n)
			{
				if ((object)o != null)
				{
					o.DataModified -= OnDataModified;
				}
				if ((object)n != null)
				{
					n.DataModified += OnDataModified;
				}
				OnDataModified();
			});
		}
	}

	public Identifier? Layout
	{
		get
		{
			return _layout;
		}
		set
		{
			SetValue<Identifier>("Layout", ref _layout, value, delegate(Identifier o, Identifier n)
			{
				UndoStack?.Commit(UndoActionTypes.ActionSetStageLayout.ToAction(), this, "Layout", o, n);
				if ((object)o != null)
				{
					o.DataModified -= OnDataModified;
				}
				if ((object)n != null)
				{
					n.DataModified += OnDataModified;
				}
				OnDataModified();
			});
		}
	}

	public bool CanAssign
	{
		get
		{
			return _canAssign;
		}
		set
		{
			SetValue("CanAssign", ref _canAssign, value);
		}
	}

	public bool IsValid
	{
		get
		{
			return _isValid;
		}
		set
		{
			SetValue("IsValid", ref _isValid, value);
		}
	}

	public UndoStack? UndoStack { get; set; }

	public event System.Action? DataModified;

	public StageScreenAssignment(ScreenArrangementBase screen, SlideCue slide)
		: this(screen.ID, screen.Name, slide.ID, slide.Name)
	{
	}

	public StageScreenAssignment(Guid screenId, string screenName, Guid layoutId, string layoutName)
		: this(new Identifier(screenId, screenName), new Identifier(layoutId, layoutName))
	{
	}

	public StageScreenAssignment(Identifier screen, Identifier? layout)
	{
		_screen = screen;
		_layout = layout;
	}

	public Stage.Types.ScreenAssignment Serialize()
	{
		return new Stage.Types.ScreenAssignment
		{
			Screen = Screen.Serialize(),
			Layout = Layout?.Serialize()
		};
	}

	public void Deserialize(Stage.Types.ScreenAssignment protoStageScreenAssignment)
	{
		Screen = new Identifier(protoStageScreenAssignment.Screen);
		Layout = new Identifier(protoStageScreenAssignment.Layout);
	}

	private void OnDataModified()
	{
		this.DataModified?.Invoke();
	}

	public StageScreenAssignment Clone()
	{
		return new StageScreenAssignment(Screen.Clone(), Layout?.Clone());
	}
}
