using System;
using System.Runtime.CompilerServices;
using Pro.Common.Components;

namespace ProPresenter.Controller.NetworkAPI;

internal record ItemPacket<T> : Identification where T : IIdentifiable
{
	public T Item { get; init; }

	public ItemPacket(T Item, Guid ID, string Name, uint Index)
	{
		this.Item = Item;
		base._002Ector(ID, Name, Index);
	}

	[CompilerGenerated]
	public void Deconstruct(out T Item, out Guid ID, out string Name, out uint Index)
	{
		Item = this.Item;
		ID = base.ID;
		Name = base.Name;
		Index = base.Index;
	}
}
