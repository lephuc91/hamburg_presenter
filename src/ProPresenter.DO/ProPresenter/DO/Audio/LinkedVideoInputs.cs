using System;
using System.Collections.Generic;
using System.Linq;
using ProPresenter.DO.LiveVideo;

namespace ProPresenter.DO.Audio;

public class LinkedVideoInputs : ILinkedVideoInputs
{
	private readonly List<int> _linkedInputs = new List<int>();

	public int Count => _linkedInputs.Count;

	public bool this[LiveVideoInput videoInput]
	{
		get
		{
			return this[videoInput?.Index ?? (-1)];
		}
		set
		{
			this[videoInput?.Index ?? (-1)] = value;
		}
	}

	public bool this[int index]
	{
		get
		{
			return IsLinked(index);
		}
		set
		{
			if (value)
			{
				Link(index);
			}
			else
			{
				Unlink(index);
			}
		}
	}

	public event Action? DataModified;

	private void OnDataModified()
	{
		this.DataModified?.Invoke();
	}

	public void Clear()
	{
		if (Count > 0)
		{
			_linkedInputs.Clear();
			OnDataModified();
		}
	}

	public bool IsLinked(LiveVideoInput videoInput)
	{
		return IsLinked(videoInput?.Index ?? (-1));
	}

	public bool IsLinked(int index)
	{
		return _linkedInputs.Contains(index);
	}

	public void Link(LiveVideoInput videoInput)
	{
		Link(videoInput?.Index ?? (-1));
	}

	public void Link(int index)
	{
		if (index < 0)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		if (!_linkedInputs.Contains(index))
		{
			_linkedInputs.Add(index);
			OnDataModified();
		}
	}

	public void Unlink(LiveVideoInput videoInput)
	{
		Unlink(videoInput?.Index ?? (-1));
	}

	public void Unlink(int index)
	{
		if (index < 0)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		if (_linkedInputs.Contains(index))
		{
			_linkedInputs.RemoveAll((int i) => i == index);
			OnDataModified();
		}
	}

	public void ToggleLink(LiveVideoInput videoInput)
	{
		ToggleLink(videoInput?.Index ?? (-1));
	}

	public void ToggleLink(int index)
	{
		if (!IsLinked(index))
		{
			Link(index);
		}
		else
		{
			Unlink(index);
		}
	}

	public IEnumerable<uint> Serialize()
	{
		return _linkedInputs.Select((int i) => (uint)i);
	}

	public void Deserialize(IEnumerable<int>? inputs)
	{
		if (inputs != null)
		{
			_linkedInputs.Clear();
			_linkedInputs.AddRange(inputs);
		}
	}
}
