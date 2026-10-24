using System.Collections.Concurrent;
using ProPresenter.DO;

namespace ProPresenter.Controller;

public class SlideEnvironments
{
	private readonly ConcurrentDictionary<OutputDestination, SlideEnvironment> _environments = new ConcurrentDictionary<OutputDestination, SlideEnvironment>();

	public SlideEnvironment this[OutputDestination destination]
	{
		get
		{
			return _environments.GetOrAdd(destination, (OutputDestination _) => new SlideEnvironment());
		}
		set
		{
			_environments[destination] = value;
		}
	}
}
