using System.Diagnostics.CodeAnalysis;
using Bugsnag;
using Bugsnag.Payload;

namespace Pro.Reporting.BugsnagInternal;

internal class NoStoreSessionTracker : ISessionTracker
{
	public Session? CurrentSession { get; private set; }

	[MemberNotNull("CurrentSession")]
	public void CreateSession()
	{
		if (CurrentSession == null)
		{
			Session session2 = (CurrentSession = new Session());
		}
	}
}
