using System.ComponentModel;
using Pro.Common.Components;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Slide.Custom.Elements.Fills;

public abstract class BackgroundEffectFillBase : FillBase, IFill, INotifyPropertyChanged, IRenderEquatable<IFill>, IRenderHashable, ICloneable<IFill>, IHasMediaContainerId, ICanReceiveMediaContainerIdUpdates
{
	protected override void OnDeserialize(Graphics.Types.Fill protoFill, string containerId)
	{
		base.OnDeserialize(protoFill, containerId);
		_ = protoFill.BackgroundEffect;
	}

	protected override void OnSerialize(Graphics.Types.Fill protoFill)
	{
		base.OnSerialize(protoFill);
		protoFill.BackgroundEffect = new Graphics.Types.BackgroundEffect();
	}
}
