using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Pro.Common.Components;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Actions;

public class PropActionClear : ObservableObject, IPropTrigger, ICloneable<IPropTrigger>, INotifyPropertyChanged
{
	public PropTriggerType TriggerType => PropTriggerType.Clear;

	public IPropTrigger Clone()
	{
		return new PropActionClear();
	}

	public void Deserialize(Action protoAction)
	{
	}

	public void Serialize(Action protoAction)
	{
		if (protoAction.Prop != null)
		{
			protoAction.Prop.Clear = new Action.Types.PropType.Types.PropClear();
		}
	}
}
