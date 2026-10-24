using Pro.Common.Components;

namespace Pro.DO.Transitions;

public abstract class TransitionBase : NotifyPropertyChangedBase
{
	public abstract TransitionType TransitionType { get; }

	public TransitionPreset Preset { get; private set; }

	protected TransitionBase(TransitionPreset preset)
	{
		Preset = preset;
	}

	protected void UpdatePreset(TransitionPreset preset)
	{
		Preset = preset;
		OnPropertyChanged("Preset");
	}

	public abstract TransitionParameters LoadParameters();

	protected internal virtual void SaveChanges(TransitionParameters parameters)
	{
	}
}
