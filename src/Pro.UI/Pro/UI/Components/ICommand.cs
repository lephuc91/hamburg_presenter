using System.Windows.Input;

namespace Pro.UI.Components;

public interface ICommand<in T, in V> : ICommand
{
	void Execute(T parameter);

	bool CanExecute(V parameter);
}
public interface ICommand<in T> : ICommand<T, T>, ICommand
{
}
