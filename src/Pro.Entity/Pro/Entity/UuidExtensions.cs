using System;
using Pro.Entity.Properties;

namespace Pro.Entity;

public static class UuidExtensions
{
	public static Guid ToGuidOrEmpty(this IObservableProperty<Guid?>? uuid)
	{
		return uuid?.Value ?? Guid.Empty;
	}
}
