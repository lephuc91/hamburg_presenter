using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using Pro.Common.Collections;
using Pro.Common.Components.Reversibility;
using Pro.DO.Token;
using ProPresenter.DO.Timer;

namespace ProPresenter.DO.Slide.Links;

public class ClockTokenCollection : ImmutableObservableCollection<TokenBase>, ITokenCollection<TokenBase>, IEnumerable<TokenBase>, IEnumerable, INotifyCollectionChanged
{
	private ClockData _clockData;

	private PlaceholderToken _clockToken = new PlaceholderToken();

	private UndoStack? _undoStack;

	public TokenBase ClockToken => _clockToken;

	public UndoStack? UndoStack
	{
		get
		{
			return _undoStack;
		}
		set
		{
			UndoStack undoStack2 = (_clockToken.UndoStack = value);
			_undoStack = undoStack2;
		}
	}

	public event Action? CollectionModified;

	public ClockTokenCollection(ClockData clockData)
	{
		_clockData = clockData;
		_clockData.DataModified += UpdateClockToken;
		base.Collection.Add(_clockToken);
		UpdateClockToken();
		_clockToken.DataModified += delegate
		{
			this.CollectionModified?.Invoke();
		};
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

	private void UpdateClockToken()
	{
		_clockToken.PlaceholderContent = _clockData.GetSampleText();
	}
}
