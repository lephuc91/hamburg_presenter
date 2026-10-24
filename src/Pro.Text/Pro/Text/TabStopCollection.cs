using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Utility;
using Pro.Text.Reversibility;

namespace Pro.Text;

public class TabStopCollection : ImmutableObservableCollection<TabStop>, ICloneable<TabStopCollection>
{
	private const double DefaultStopSpacing = 80.0;

	private int? _hashCode;

	private UndoStack? _undoStack;

	public UndoStack? UndoStack
	{
		get
		{
			return _undoStack;
		}
		set
		{
			if (_undoStack != value)
			{
				_undoStack = value;
				base.Collection.ForEach(delegate(TabStop t)
				{
					t.UndoStack = _undoStack;
				});
			}
		}
	}

	public event Action<TabStopCollection>? TabStopsChanged;

	public override int GetHashCode()
	{
		if (!_hashCode.HasValue)
		{
			IEnumerable[] collections = new ObservableCollection<TabStop>[1] { base.Collection };
			_hashCode = HashCodeHelper.GenerateHashCode(collections);
		}
		return _hashCode.Value;
	}

	public void AddStopAtNextDefaultPosition()
	{
		if (base.Count == 0)
		{
			AddStop(80.0);
			return;
		}
		TabStop tabStop = this.OrderBy((TabStop s) => s.Position).LastOrDefault();
		if ((object)tabStop != null)
		{
			double position = tabStop.Position + 80.0;
			AddStop(position);
		}
	}

	public void AddStop(double position, TabStopType type = TabStopType.Left)
	{
		OnAddStop(position, type);
		OnTabStopsChanged();
	}

	public void AddStop(TabStop stop)
	{
		UndoStack?.Commit(UndoActionTypes.TextAddTabStop.ToAction(), delegate
		{
			RemoveStop(stop);
		}, delegate
		{
			AddStop(stop);
		}, null, null, autoFinalize: true);
		OnAddStop(stop);
	}

	private void OnAddStop(double position, TabStopType type = TabStopType.Left)
	{
		OnAddStop(new TabStop(position, type));
	}

	private void OnAddStop(TabStop stop)
	{
		stop.PropertyChanged += OnTabStopPropertyChanged;
		stop.UndoStack = _undoStack;
		base.Collection.Add(stop);
		OnTabStopsChanged();
	}

	public void RemoveStop(double position)
	{
		RemoveStop(this.FirstOrDefault((TabStop t) => t.Position == position));
	}

	public void RemoveStop(TabStop? stop)
	{
		if ((object)stop != null)
		{
			UndoStack?.Commit(UndoActionTypes.TextRemoveTabStop.ToAction(), delegate
			{
				AddStop(stop);
			}, delegate
			{
				RemoveStop(stop);
			});
			OnRemoveStop(stop);
			OnTabStopsChanged();
		}
	}

	private void OnRemoveStop(TabStop stop)
	{
		if ((object)stop != null)
		{
			stop.PropertyChanged -= OnTabStopPropertyChanged;
			base.Collection.Remove(stop);
		}
	}

	public void Clear()
	{
		this.ToArray().ForEach(OnRemoveStop);
		OnTabStopsChanged();
	}

	public double FindNextStopPosition(double position, out TabStopType type, bool allowDefault = true)
	{
		TabStop tabStop = this.OrderBy((TabStop s) => s.Position).FirstOrDefault((TabStop s) => s.Position > position);
		type = tabStop?.Type ?? TabStopType.Left;
		if ((object)tabStop == null)
		{
			if (!allowDefault)
			{
				return position;
			}
			return GetDefaultPosition(position, forward: true);
		}
		return tabStop.Position;
	}

	public double FindPreviousStopPosition(double position, out TabStopType type, bool allowDefault = true)
	{
		TabStop tabStop = this.OrderBy((TabStop s) => s.Position).FirstOrDefault((TabStop s) => s.Position < position);
		type = tabStop?.Type ?? TabStopType.Left;
		if ((object)tabStop == null)
		{
			if (!allowDefault)
			{
				return position;
			}
			return GetDefaultPosition(position, forward: false);
		}
		return tabStop.Position;
	}

	private double GetDefaultPosition(double position, bool forward)
	{
		if (position < 0.0)
		{
			forward = !forward;
		}
		double num = (forward ? Math.Ceiling(position / 80.0) : Math.Floor(position / 80.0)) * 80.0;
		if (num == position)
		{
			num = ((!forward) ? (num - 80.0) : (num + 80.0));
		}
		return num;
	}

	private void OnTabStopsChanged()
	{
		this.TabStopsChanged?.Invoke(this);
	}

	private void OnTabStopPropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		OnTabStopsChanged();
	}

	public TabStopCollection Clone()
	{
		TabStopCollection copy = new TabStopCollection();
		this.ForEach(delegate(TabStop s)
		{
			copy.AddStop(s.Position, s.Type);
		});
		copy.UndoStack = _undoStack;
		return copy;
	}
}
