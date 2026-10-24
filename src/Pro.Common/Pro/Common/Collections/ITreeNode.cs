using System.Collections.Generic;
using Pro.Common.Components;

namespace Pro.Common.Collections;

public interface ITreeNode<T> where T : ITreeNode<T>, IIdentifiable
{
	IEnumerable<T>? Children { get; }
}
