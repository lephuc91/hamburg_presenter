using System;
using Pro.Common.Utility;

namespace ProPresenter.DO.Notifications;

public sealed record Notification(Guid Id, string Header, string Body, string Url, string UrlDisplayText, DateTimeOffset CreatedAt, DateTimeOffset ExpiresAt, bool IsRead) : INotification
{
	public bool Equals(Notification? other)
	{
		if ((object)other == null)
		{
			return false;
		}
		return Id == other.Id;
	}

	public override int GetHashCode()
	{
		return HashCodeHelper.GenerateHashCode(Id);
	}
}
