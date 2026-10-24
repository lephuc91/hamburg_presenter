using System.Threading.Tasks;
using System.Windows.Input;

namespace Pro.UI.Components;

public interface IAsyncCommand<T, V> : ICommand<T, V>, ICommand
{
	Task ExecuteAsync(T parameter);
}
public interface IAsyncCommand<T> : ICommand<T, T>, ICommand
{
	Task ExecuteAsync(T parameter);
}
