using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using Pro.Common.Collections;

namespace Pro.Common.ObjectBinding;

public sealed class ObjectBinder<LeftType, RightType> : IReadOnlyObjectBinder<LeftType, RightType>, IReadOnlyObjectBinder, IDisposable where LeftType : class where RightType : class
{
	private readonly List<IBinding<LeftType, RightType>> _bindings = new List<IBinding<LeftType, RightType>>();

	private readonly List<Action> _doOnInitializeLeftFromRight = new List<Action>();

	private readonly List<Action> _doOnInitializeRightFromLeft = new List<Action>();

	private readonly CompositeDisposable _childDisposables = new CompositeDisposable();

	private readonly List<Action<LeftType?>> _doOnReplaceLeft = new List<Action<LeftType>>();

	private readonly List<Action<RightType?>> _doOnReplaceRight = new List<Action<RightType>>();

	private LeftType? _left;

	private RightType? _right;

	public LeftType? Left => _left;

	public RightType? Right => _right;

	public ObjectBinder(LeftType? left, RightType? right)
	{
		if (left != null)
		{
			ReplaceLeft(left);
		}
		if (right != null)
		{
			ReplaceRight(right);
		}
	}

	public void Dispose()
	{
		_bindings.ForEach(delegate(IBinding<LeftType, RightType> x)
		{
			x.Dispose();
		});
		_childDisposables.Dispose();
	}

	public bool ReplaceLeft(LeftType? left)
	{
		if (_left == left)
		{
			return false;
		}
		_left = left;
		_bindings.ForEach(delegate(IBinding<LeftType, RightType> b)
		{
			b.ReplaceLeft(left);
		});
		_doOnReplaceLeft.ForEach(delegate(Action<LeftType?> a)
		{
			a(left);
		});
		return true;
	}

	public bool ReplaceRight(RightType? right)
	{
		if (_right == right)
		{
			return false;
		}
		_right = right;
		_bindings.ForEach(delegate(IBinding<LeftType, RightType> b)
		{
			b.ReplaceRight(right);
		});
		_doOnReplaceRight.ForEach(delegate(Action<RightType?> a)
		{
			a(right);
		});
		return true;
	}

	public ObjectBinder<LeftType, RightType> Bind<LeftObservableType, RightObservableType>(Func<LeftType, IObservable<LeftObservableType>>? leftObservable, Func<RightType, IObservable<RightObservableType>>? rightObservable, Action<LeftType, RightType> onLeftChanged, Action<RightType, LeftType> onRightChanged, IScheduler? scheduleLeftUpdatesOn = null, IScheduler? scheduleRightUpdatesOn = null, string tag = "")
	{
		if (leftObservable == null && rightObservable == null)
		{
			throw new ArgumentException("leftObservable and rightObservable must not both be null.");
		}
		SimpleBinding<LeftType, LeftObservableType, RightType, RightObservableType> item = new SimpleBinding<LeftType, LeftObservableType, RightType, RightObservableType>(leftObservable, rightObservable, onLeftChanged, onRightChanged, _left, _right, scheduleLeftUpdatesOn, scheduleRightUpdatesOn, tag);
		_bindings.Add(item);
		return this;
	}

	public ObjectBinder<LeftType, RightType> RegisterChildDisposable(Func<IDisposable?> onDispose)
	{
		_childDisposables.Add(Disposable.Create(delegate
		{
			onDispose()?.Dispose();
		}));
		return this;
	}

	public ObjectBinder<LeftType, RightType> RegisterChildDisposable(Func<IEnumerable<IDisposable?>> onDispose)
	{
		_childDisposables.Add(Disposable.Create(delegate
		{
			onDispose().ForEach(delegate(IDisposable x)
			{
				x?.Dispose();
			});
		}));
		return this;
	}

	public ObjectBinder<LeftType, RightType> RegisterChildDisposable(CompositeDisposable disposable)
	{
		_childDisposables.Add(disposable);
		return this;
	}

	public void InitializeRightFromLeft()
	{
		if (_left == null || _right == null)
		{
			return;
		}
		using (new CompositeDisposable(_bindings.Select((IBinding<LeftType, RightType> x) => x.SuspendSubscriptions())))
		{
			_doOnInitializeRightFromLeft.ForEach(delegate(Action x)
			{
				x();
			});
			_bindings.ForEach(delegate(IBinding<LeftType, RightType> x)
			{
				x.ExecuteLeftChanged();
			});
		}
	}

	public void InitializeLeftFromRight()
	{
		if (_left == null || _right == null)
		{
			return;
		}
		using (new CompositeDisposable(_bindings.Select((IBinding<LeftType, RightType> x) => x.SuspendSubscriptions())))
		{
			_doOnInitializeLeftFromRight.ForEach(delegate(Action x)
			{
				x();
			});
			_bindings.ForEach(delegate(IBinding<LeftType, RightType> x)
			{
				x.ExecuteRightChanged();
			});
		}
	}

	public ObjectBinder<LeftType, RightType> DoOnInitializeLeftFromRight(Action toExecute)
	{
		_doOnInitializeLeftFromRight.Add(toExecute);
		return this;
	}

	public ObjectBinder<LeftType, RightType> DoOnInitializeRightFromLeft(Action toExecute)
	{
		_doOnInitializeRightFromLeft.Add(toExecute);
		return this;
	}

	public ObjectBinder<LeftType, RightType> DoOnReplaceLeft(Action<LeftType?> toExecute)
	{
		_doOnReplaceLeft.Add(toExecute);
		return this;
	}

	public ObjectBinder<LeftType, RightType> DoOnReplaceRight(Action<RightType?> toExecute)
	{
		_doOnReplaceRight.Add(toExecute);
		return this;
	}
}
