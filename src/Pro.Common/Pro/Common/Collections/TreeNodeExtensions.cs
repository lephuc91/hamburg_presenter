using System;
using System.Collections.Generic;
using System.Linq;
using Pro.Common.Components;

namespace Pro.Common.Collections;

public static class TreeNodeExtensions
{
	public static void Iterate<T>(this IEnumerable<T> nodes, Predicate<T>? predicate, Action<T, int> callback, int depth = 1) where T : ITreeNode<T>, IIdentifiable
	{
		foreach (T node in nodes)
		{
			if (predicate == null || predicate(node))
			{
				callback(node, depth);
			}
			if (node.Children != null && node.Children.Any())
			{
				node.Children.Iterate(predicate, callback, depth++);
			}
		}
	}

	public static IEnumerable<T> Flatten<T>(this IEnumerable<T> nodes) where T : ITreeNode<T>, IIdentifiable
	{
		return nodes.Search(null);
	}

	public static IEnumerable<T> Search<T>(this IEnumerable<T> nodes, Predicate<T>? predicate) where T : ITreeNode<T>, IIdentifiable
	{
		List<T> found = new List<T>();
		nodes.Iterate(predicate, delegate(T playlist, int _)
		{
			found.Add(playlist);
		});
		return found;
	}
}
