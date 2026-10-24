using System;

namespace Pro.DO.Triggering.CompletionTargets;

public class CueTarget : CompletionTargetBase
{
	public override CompletionTargetType Type => CompletionTargetType.Cue;

	public Guid ID { get; }

	public CueTarget(Cue cue)
		: this(cue.ID)
	{
	}

	internal CueTarget(Guid id)
	{
		ID = id;
	}
}
