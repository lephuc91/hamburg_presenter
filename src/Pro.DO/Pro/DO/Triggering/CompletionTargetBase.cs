using Pro.Common.Components;

namespace Pro.DO.Triggering;

public abstract class CompletionTargetBase : NotifyPropertyChangedBase
{
	public abstract CompletionTargetType Type { get; }
}
