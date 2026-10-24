using System;

namespace Pro.Common.Components;

public interface IIdentifiable
{
	Guid ID { get; }

	string Name { get; set; }
}
