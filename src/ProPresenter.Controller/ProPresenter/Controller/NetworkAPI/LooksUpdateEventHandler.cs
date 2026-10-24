using System;
using System.Collections.Generic;
using System.Linq;
using Pro.Common.Collections;
using ProPresenter.DO.Events;
using ProPresenter.DO.Looks;

namespace ProPresenter.Controller.NetworkAPI;

internal class LooksUpdateEventHandler : DebouncedEventSender
{
	private class LookData : IEquatable<LookData>
	{
		public Guid Id { get; }

		public string Name { get; }

		public IEnumerable<ScreenLook> ScreenLooks { get; }

		public LookData(Guid id, string name, IEnumerable<ScreenLook> screenLooks)
		{
			Id = id;
			Name = name;
			ScreenLooks = screenLooks;
		}

		public override int GetHashCode()
		{
			return (Id, Name, ScreenLooks.Count()).GetHashCode();
		}

		public override bool Equals(object? obj)
		{
			if (obj is LookData other)
			{
				return Equals(other);
			}
			return false;
		}

		public bool Equals(LookData? other)
		{
			if (other != null && Id == other.Id && Name == other.Name)
			{
				return ScreenLooks.ContentsMatchExactly(other.ScreenLooks, (ScreenLook s1, ScreenLook s2) => s1.Equals(s2));
			}
			return false;
		}
	}

	private IEnumerable<LookData> _previous = Array.Empty<LookData>();

	private IEnumerable<LookData> _current = Array.Empty<LookData>();

	private readonly IEnumerable<AudienceLook> _looks;

	public LooksUpdateEventHandler(IEnumerable<AudienceLook> looks)
	{
		_looks = looks;
		ApplicationEventPublisher.AddHandler(this);
	}

	protected override EventResult OnEventReceived(IApplicationEvent @event)
	{
		EventResult result = EventResult.Continue;
		if (@event is LooksUpdated looksUpdated)
		{
			LookData[] array = looksUpdated.Looks.Select((AudienceLook l) => new LookData(l.ID, l.Name, l.ScreenLooks.Select((ScreenLook s) => s.Clone()).ToArray())).ToArray();
			if (!_current.ContentsMatchExactly(array))
			{
				_current = array;
				result = EventResult.Debounce;
			}
		}
		return result;
	}

	protected override void Publish()
	{
		if (!_previous.ContentsMatchExactly(_current))
		{
			OnSend(LookHandler.UpdateLooks(_looks));
		}
		_previous = _current;
	}
}
