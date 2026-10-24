using System.ComponentModel;
using Pro.Common.Components;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Actions;

public interface IPropTrigger : ICloneable<IPropTrigger>, INotifyPropertyChanged
{
	PropTriggerType TriggerType { get; }

	void Serialize(Action protoAction);

	void Deserialize(Action protoAction);
}
