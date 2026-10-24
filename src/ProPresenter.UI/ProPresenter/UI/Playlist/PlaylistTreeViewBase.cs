using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.UI;
using Pro.UI.Controls;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Playlists;

namespace ProPresenter.UI.Playlist;

public abstract class PlaylistTreeViewBase<T, C> : DragDropTreeViewBase<IPlaylist<T>, TreeViewItem> where T : ProPresenterCue where C : ImmutableObservableCollection<IPlaylist<T>>, IDragDropTreeCollection<IPlaylist<T>>
{
	[CompilerGenerated]
	private sealed class _003CFlattenGroup_003Ed__11 : IEnumerable<IPlaylist<T>>, IEnumerable, IEnumerator<IPlaylist<T>>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private IPlaylist<T> _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private IEnumerable<IPlaylist<T>> root;

		public IEnumerable<IPlaylist<T>> _003C_003E3__root;

		public PlaylistTreeViewBase<T, C> _003C_003E4__this;

		private IEnumerator<IPlaylist<T>> _003C_003E7__wrap1;

		private IPlaylist<T> _003Citem_003E5__3;

		private IEnumerator<IPlaylist<T>> _003C_003E7__wrap3;

		IPlaylist<T> IEnumerator<IPlaylist<T>>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CFlattenGroup_003Ed__11(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
			_003C_003El__initialThreadId = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			int num = _003C_003E1__state;
			if ((uint)(num - -4) <= 1u || (uint)(num - 1) <= 1u)
			{
				try
				{
					if (num == -4 || num == 2)
					{
						try
						{
						}
						finally
						{
							_003C_003Em__Finally2();
						}
					}
				}
				finally
				{
					_003C_003Em__Finally1();
				}
			}
			_003C_003E7__wrap1 = null;
			_003Citem_003E5__3 = null;
			_003C_003E7__wrap3 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			try
			{
				int num = _003C_003E1__state;
				PlaylistTreeViewBase<T, C> playlistTreeViewBase = _003C_003E4__this;
				switch (num)
				{
				default:
					return false;
				case 0:
					_003C_003E1__state = -1;
					_003C_003E7__wrap1 = root.GetEnumerator();
					_003C_003E1__state = -3;
					break;
				case 1:
					_003C_003E1__state = -3;
					if (_003Citem_003E5__3.Type == PlaylistType.Group && _003Citem_003E5__3.IsExpanded)
					{
						_003C_003E7__wrap3 = playlistTreeViewBase.FlattenGroup((GroupPlaylist<T>)_003Citem_003E5__3).GetEnumerator();
						_003C_003E1__state = -4;
						goto IL_00e6;
					}
					goto IL_0100;
				case 2:
					{
						_003C_003E1__state = -4;
						goto IL_00e6;
					}
					IL_0100:
					_003Citem_003E5__3 = null;
					break;
					IL_00e6:
					if (_003C_003E7__wrap3.MoveNext())
					{
						IPlaylist<T> current = _003C_003E7__wrap3.Current;
						_003C_003E2__current = current;
						_003C_003E1__state = 2;
						return true;
					}
					_003C_003Em__Finally2();
					_003C_003E7__wrap3 = null;
					goto IL_0100;
				}
				if (_003C_003E7__wrap1.MoveNext())
				{
					_003Citem_003E5__3 = _003C_003E7__wrap1.Current;
					_003C_003E2__current = _003Citem_003E5__3;
					_003C_003E1__state = 1;
					return true;
				}
				_003C_003Em__Finally1();
				_003C_003E7__wrap1 = null;
				return false;
			}
			catch
			{
				//try-fault
				((IDisposable)this).Dispose();
				throw;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		private void _003C_003Em__Finally1()
		{
			_003C_003E1__state = -1;
			if (_003C_003E7__wrap1 != null)
			{
				_003C_003E7__wrap1.Dispose();
			}
		}

		private void _003C_003Em__Finally2()
		{
			_003C_003E1__state = -3;
			if (_003C_003E7__wrap3 != null)
			{
				_003C_003E7__wrap3.Dispose();
			}
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<IPlaylist<T>> IEnumerable<IPlaylist<T>>.GetEnumerator()
		{
			_003CFlattenGroup_003Ed__11 _003CFlattenGroup_003Ed__;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				_003CFlattenGroup_003Ed__ = this;
			}
			else
			{
				_003CFlattenGroup_003Ed__ = new _003CFlattenGroup_003Ed__11(0)
				{
					_003C_003E4__this = _003C_003E4__this
				};
			}
			_003CFlattenGroup_003Ed__.root = _003C_003E3__root;
			return _003CFlattenGroup_003Ed__;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<IPlaylist<T>>)this).GetEnumerator();
		}
	}

	[CompilerGenerated]
	private sealed class _003CFlattenItemSource_003Ed__10 : IEnumerable<IPlaylist<T>>, IEnumerable, IEnumerator<IPlaylist<T>>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private IPlaylist<T> _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		public PlaylistTreeViewBase<T, C> _003C_003E4__this;

		private IEnumerator<IPlaylist<T>> _003C_003E7__wrap1;

		IPlaylist<T> IEnumerator<IPlaylist<T>>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CFlattenItemSource_003Ed__10(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
			_003C_003El__initialThreadId = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			int num = _003C_003E1__state;
			if (num == -3 || num == 1)
			{
				try
				{
				}
				finally
				{
					_003C_003Em__Finally1();
				}
			}
			_003C_003E7__wrap1 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			try
			{
				int num = _003C_003E1__state;
				PlaylistTreeViewBase<T, C> playlistTreeViewBase = _003C_003E4__this;
				switch (num)
				{
				default:
					return false;
				case 0:
				{
					_003C_003E1__state = -1;
					C val = (C)playlistTreeViewBase.ItemsSource;
					if (val == null)
					{
						return false;
					}
					_003C_003E7__wrap1 = playlistTreeViewBase.FlattenGroup(val).GetEnumerator();
					_003C_003E1__state = -3;
					break;
				}
				case 1:
					_003C_003E1__state = -3;
					break;
				}
				if (_003C_003E7__wrap1.MoveNext())
				{
					IPlaylist<T> current = _003C_003E7__wrap1.Current;
					_003C_003E2__current = current;
					_003C_003E1__state = 1;
					return true;
				}
				_003C_003Em__Finally1();
				_003C_003E7__wrap1 = null;
				return false;
			}
			catch
			{
				//try-fault
				((IDisposable)this).Dispose();
				throw;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		private void _003C_003Em__Finally1()
		{
			_003C_003E1__state = -1;
			if (_003C_003E7__wrap1 != null)
			{
				_003C_003E7__wrap1.Dispose();
			}
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<IPlaylist<T>> IEnumerable<IPlaylist<T>>.GetEnumerator()
		{
			_003CFlattenItemSource_003Ed__10 result;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				result = this;
			}
			else
			{
				result = new _003CFlattenItemSource_003Ed__10(0)
				{
					_003C_003E4__this = _003C_003E4__this
				};
			}
			return result;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<IPlaylist<T>>)this).GetEnumerator();
		}
	}

	protected override IDragDropTreeCollection<IPlaylist<T>> SourceTreeCollection => (C)base.ItemsSource;

	public PlaylistTreeViewBase()
	{
		AddDropType(CanInsertPlaylist);
	}

	protected override void OnItemsSourceChanged(IEnumerable oldValue, IEnumerable newValue)
	{
		SetupSourceCollectionChanged();
	}

	private void SetupSourceCollectionChanged()
	{
		SetGroupCollectionChanged((C)base.ItemsSource);
		((C)base.ItemsSource).CollectionChanged += OnItemsSourceCollectionChanged;
	}

	private void SetGroupCollectionChanged(IEnumerable<IPlaylist<T>> playlists)
	{
		foreach (GroupPlaylist<T> item in playlists.OfType<GroupPlaylist<T>>())
		{
			item.CollectionChanged += OnItemsSourceCollectionChanged;
			SetGroupCollectionChanged(item);
		}
	}

	private void OnItemsSourceCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		if (!(sender is IEnumerable<IPlaylist<T>> enumerable))
		{
			return;
		}
		IEnumerable<IPlaylist<T>> obj = e.OldItems?.Cast<IPlaylist<T>>();
		IEnumerable<IPlaylist<T>> enumerable2 = e.NewItems?.Cast<IPlaylist<T>>();
		obj?.OfType<GroupPlaylist<T>>().ForEach(delegate(GroupPlaylist<T> g)
		{
			g.CollectionChanged -= OnItemsSourceCollectionChanged;
		});
		enumerable2?.OfType<GroupPlaylist<T>>().ForEach(delegate(GroupPlaylist<T> g)
		{
			g.CollectionChanged += OnItemsSourceCollectionChanged;
		});
		switch (e.Action)
		{
		case NotifyCollectionChangedAction.Add:
			if (SetNewPlaylistActive())
			{
				SetSelection(enumerable2);
				((DependencyObject)this).SetCurrentValue(TreeViewBase<IPlaylist<T>, TreeViewItem>.ActiveItemProperty, (object)enumerable2?.LastOrDefault());
			}
			break;
		case NotifyCollectionChangedAction.Remove:
		{
			IPlaylist<T> playlist = enumerable.GetPlaylists().Take(e.OldStartingIndex).LastOrDefault((IPlaylist<T> p) => p.Type != PlaylistType.Group);
			((DependencyObject)this).SetCurrentValue(TreeViewBase<IPlaylist<T>, TreeViewItem>.ActiveItemProperty, (object)playlist);
			SetSelection(new IPlaylist<T>[1] { playlist });
			break;
		}
		case NotifyCollectionChangedAction.Reset:
			SetSelection(new IPlaylist<T>[1] { enumerable.FirstOrDefault() });
			break;
		case NotifyCollectionChangedAction.Replace:
		case NotifyCollectionChangedAction.Move:
			break;
		}
	}

	protected virtual bool SetNewPlaylistActive()
	{
		return true;
	}

	protected virtual bool CanInsertPlaylist(DraggedTreeItemsCollection<IPlaylist<T>> items, DragEventArgs e)
	{
		return true;
	}

	protected override bool AllowsDropInside(IPlaylist<T> item)
	{
		return item.Type == PlaylistType.Group;
	}

	[IteratorStateMachine(typeof(PlaylistTreeViewBase<, >._003CFlattenItemSource_003Ed__10))]
	protected override IEnumerable<IPlaylist<T>> FlattenItemSource()
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CFlattenItemSource_003Ed__10(-2)
		{
			_003C_003E4__this = this
		};
	}

	[IteratorStateMachine(typeof(PlaylistTreeViewBase<, >._003CFlattenGroup_003Ed__11))]
	private IEnumerable<IPlaylist<T>> FlattenGroup(IEnumerable<IPlaylist<T>> root)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CFlattenGroup_003Ed__11(-2)
		{
			_003C_003E4__this = this,
			_003C_003E3__root = root
		};
	}
}
