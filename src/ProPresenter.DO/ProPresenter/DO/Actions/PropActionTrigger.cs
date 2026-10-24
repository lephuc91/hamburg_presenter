using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using Pro.Common.Components;
using Pro.Common.Time;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Actions;

public class PropActionTrigger : ObservableObject, IPropTrigger, ICloneable<IPropTrigger>, INotifyPropertyChanged
{
	[ObservableProperty]
	private bool _autoClearEnabled;

	[ObservableProperty]
	private TimeSlice _autoClearDuration = TimeSlice.Zero;

	[ObservableProperty]
	private bool _autoClearFollowsPropDuration = true;

	public PropTriggerType TriggerType => PropTriggerType.Trigger;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool AutoClearEnabled
	{
		get
		{
			return _autoClearEnabled;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_autoClearEnabled, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.AutoClearEnabled);
				_autoClearEnabled = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.AutoClearEnabled);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public TimeSlice AutoClearDuration
	{
		get
		{
			return _autoClearDuration;
		}
		set
		{
			if (!EqualityComparer<TimeSlice>.Default.Equals(_autoClearDuration, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.AutoClearDuration);
				_autoClearDuration = value;
				OnAutoClearDurationChanged(value);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.AutoClearDuration);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool AutoClearFollowsPropDuration
	{
		get
		{
			return _autoClearFollowsPropDuration;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_autoClearFollowsPropDuration, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.AutoClearFollowsPropDuration);
				_autoClearFollowsPropDuration = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.AutoClearFollowsPropDuration);
			}
		}
	}

	public IPropTrigger Clone()
	{
		return new PropActionTrigger
		{
			AutoClearEnabled = AutoClearEnabled,
			AutoClearDuration = AutoClearDuration,
			AutoClearFollowsPropDuration = AutoClearFollowsPropDuration
		};
	}

	public void Deserialize(Action protoAction)
	{
		Action.Types.PropType.Types.PropTrigger trigger = protoAction.Prop.Trigger;
		if (trigger != null)
		{
			AutoClearDuration = TimeSlice.FromSeconds(trigger.AutoClearDuration);
			AutoClearEnabled = trigger.AutoClearEnabled;
			AutoClearFollowsPropDuration = trigger.AutoClearFollowsPropDuration;
		}
	}

	public void Serialize(Action protoAction)
	{
		if (protoAction.Prop != null)
		{
			protoAction.Prop.Trigger = new Action.Types.PropType.Types.PropTrigger
			{
				AutoClearFollowsPropDuration = AutoClearFollowsPropDuration,
				AutoClearDuration = AutoClearDuration.TotalSeconds,
				AutoClearEnabled = AutoClearEnabled
			};
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnAutoClearDurationChanged(TimeSlice value)
	{
		AutoClearEnabled = value.TotalSeconds > 0.0;
	}
}
