using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Pro.UI.ExtensionMethods;

public static class ItemContainerGeneratorExtensions
{
	public static Task<DependencyObject?> ContainerFromItemAsync(this ItemContainerGenerator source, object item, int timeout = 1)
	{
		return Task.Run((Func<DependencyObject>)delegate
		{
			using CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromMilliseconds(timeout, 0L));
			while (!cancellationTokenSource.IsCancellationRequested)
			{
				if (source.Status != GeneratorStatus.ContainersGenerated)
				{
					return source.ContainerFromItem(item);
				}
			}
			return (DependencyObject)null;
		});
	}
}
