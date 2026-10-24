using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using Pro.Common.Collections;
using Pro.Common.Components.Reversibility;
using Pro.DO.Token;
using ProPresenter.DO.Timer;

namespace ProPresenter.DO.Slide.Links;

public class TimerTokenCollection : ImmutableObservableCollection<TokenBase>, ITokenCollection<TokenBase>, IEnumerable<TokenBase>, IEnumerable, INotifyCollectionChanged
{
	private TimerFormatData _timerFormatData;

	private PlaceholderToken _timerToken = new PlaceholderToken();

	private UndoStack? _undoStack;

	public TokenBase TimerToken => _timerToken;

	public UndoStack? UndoStack
	{
		get
		{
			return _undoStack;
		}
		set
		{
			UndoStack undoStack2 = (_timerToken.UndoStack = value);
			_undoStack = undoStack2;
		}
	}

	public event Action? CollectionModified;

	public TimerTokenCollection(TimerFormatData timerFormatData)
	{
		_timerFormatData = timerFormatData;
		_timerFormatData.DataModified += UpdateTimerToken;
		_timerToken.DataModified += OnCollectionModified;
		base.Collection.Add(_timerToken);
		UpdateTimerToken();
	}

	public bool Add(TokenBase token)
	{
		return true;
	}

	public bool Remove(TokenBase token)
	{
		return false;
	}

	public void SortTokens(IEnumerable<TokenBase> referenceItems)
	{
	}

	private void UpdateTimerToken()
	{
		_timerToken.PlaceholderContent = _timerFormatData.GetSampleText();
	}

	private void OnCollectionModified()
	{
		this.CollectionModified?.Invoke();
	}
}
