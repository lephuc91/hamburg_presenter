using System;
using System.Diagnostics;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using System.Reactive.Linq;

namespace Pro.Common.ObjectBinding;

[DebuggerDisplay("{Id} - {Tag} - {LeftType} - {LeftObservableType} - {RightType} - {RightObservableType}")]
internal sealed class SimpleBinding<LeftType, LeftObservableType, RightType, RightObservableType> : IBinding<LeftType, RightType>, IDisposable where LeftType : class where RightType : class
{
	private readonly Func<LeftType, IObservable<LeftObservableType>>? _leftObservable;

	private readonly Func<RightType, IObservable<RightObservableType>>? _rightObservable;

	private readonly Action<LeftType, RightType> _onLeftChanged;

	private readonly Action<RightType, LeftType> _onRightChanged;

	private readonly IScheduler? _scheduleRightUpdates;

	private readonly IScheduler? _scheduleLeftUpdates;

	private bool _isLeftChanging;

	private bool _isRightChanging;

	private bool _isInitializing;

	private LeftType? _left;

	private RightType? _right;

	private IDisposable? _leftSubscription;

	private IDisposable? _rightSubscription;

	public Guid Id { get; } = Guid.NewGuid();

	public string Tag { get; }

	public SimpleBinding(Func<LeftType, IObservable<LeftObservableType>>? leftObservable, Func<RightType, IObservable<RightObservableType>>? rightObservable, Action<LeftType, RightType> onLeftChanged, Action<RightType, LeftType> onRightChanged, LeftType? left, RightType? right, IScheduler? scheduleLeftUpdates = null, IScheduler? scheduleRightUpdates = null, string tag = "")
	{
		_leftObservable = leftObservable;
		_rightObservable = rightObservable;
		_onLeftChanged = onLeftChanged;
		_onRightChanged = onRightChanged;
		_left = left;
		_right = right;
		_scheduleLeftUpdates = scheduleLeftUpdates;
		_scheduleRightUpdates = scheduleRightUpdates;
		Tag = tag;
		_isInitializing = true;
		_leftSubscription = SubscribeLeft();
		_rightSubscription = SubscribeRight();
		_isInitializing = false;
	}

	public void Dispose()
	{
		_leftSubscription?.Dispose();
		_rightSubscription?.Dispose();
	}

	public void ReplaceLeft(LeftType? left)
	{
		if (_left != left)
		{
			_leftSubscription?.Dispose();
			_left = left;
			if (_left != null)
			{
				_isInitializing = true;
				_leftSubscription = SubscribeLeft();
				_isInitializing = false;
			}
		}
	}

	public void ReplaceRight(RightType? right)
	{
		if (_right != right)
		{
			_rightSubscription?.Dispose();
			_right = right;
			if (_right != null)
			{
				_isInitializing = true;
				_rightSubscription = SubscribeRight();
				_isInitializing = false;
			}
		}
	}

	public IDisposable SuspendSubscriptions()
	{
		_leftSubscription?.Dispose();
		_rightSubscription?.Dispose();
		_isInitializing = true;
		return Disposable.Create(delegate
		{
			_leftSubscription = SubscribeLeft();
			_rightSubscription = SubscribeRight();
			_isInitializing = false;
		});
	}

	public void ExecuteLeftChanged()
	{
		if (_left != null && _right != null)
		{
			_isLeftChanging = true;
			_onLeftChanged?.Invoke(_left, _right);
			_isLeftChanging = false;
		}
	}

	public void ExecuteRightChanged()
	{
		if (_left != null && _right != null)
		{
			_isRightChanging = true;
			_onRightChanged?.Invoke(_right, _left);
			_isRightChanging = false;
		}
	}

	private IDisposable? SubscribeLeft()
	{
		if (_left == null || _leftObservable == null)
		{
			return null;
		}
		IObservable<LeftObservableType> source = from _ in _leftObservable(_left)
			where !_isLeftChanging && !_isRightChanging && !_isInitializing
			select _;
		if (_scheduleLeftUpdates != null)
		{
			source = source.ObserveOn(_scheduleLeftUpdates);
		}
		return source.Subscribe(delegate
		{
			if (_right != null)
			{
				_isLeftChanging = true;
				_onLeftChanged(_left, _right);
				_isLeftChanging = false;
			}
		});
	}

	private IDisposable? SubscribeRight()
	{
		if (_right == null || _rightObservable == null)
		{
			return null;
		}
		IObservable<RightObservableType> source = from _ in _rightObservable(_right)
			where !_isLeftChanging && !_isRightChanging && !_isInitializing
			select _;
		if (_scheduleRightUpdates != null)
		{
			source = source.ObserveOn(_scheduleRightUpdates);
		}
		return source.Subscribe(delegate
		{
			if (_left != null)
			{
				_isRightChanging = true;
				_onRightChanged(_right, _left);
				_isRightChanging = false;
			}
		});
	}
}
