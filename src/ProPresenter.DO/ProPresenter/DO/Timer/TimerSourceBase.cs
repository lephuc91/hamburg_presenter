using System;
using System.Diagnostics.CodeAnalysis;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;

namespace ProPresenter.DO.Timer;

public abstract class TimerSourceBase<T> : LinkedNotifyPropertyChangedBase where T : TimerBase
{
	private T _source;

	private T _active;

	public T Source
	{
		get
		{
			return _source;
		}
		[MemberNotNull("_source")]
		set
		{
			SetValue("Source", ref _source, value, delegate(T o, T n)
			{
				UndoStack?.Commit(UndoActionTypes.TimerType.ToAction(), this, "Source", o, n, null, null, autoFinalize: true);
				if (o != null)
				{
					o.DataModified -= OnDataModified;
					o.PropertyChanged -= base.RaiseLinkedValues;
				}
				n.DataModified += OnDataModified;
				n.PropertyChanged += base.RaiseLinkedValues;
				n.UndoStack = UndoStack;
				this.SourceChanged?.Invoke(o, n);
				OnDataModified();
			});
		}
	}

	public T Active
	{
		get
		{
			return _active;
		}
		[MemberNotNull("_active")]
		protected set
		{
			SetValue("Active", ref _active, value, delegate(T o, T n)
			{
				this.ActiveChanged?.Invoke(o, n);
			});
		}
	}

	public UndoStack? UndoStack { get; set; }

	public event Action<TimerSourceBase<T>>? DataModified;

	public event Action<T, T>? SourceChanged;

	public event Action<T, T>? ActiveChanged;

	protected TimerSourceBase(T timerSource)
	{
		Source = timerSource;
		Active = (T)timerSource.Clone();
	}

	protected void OnDataModified()
	{
		this.DataModified?.Invoke(this);
	}
}
