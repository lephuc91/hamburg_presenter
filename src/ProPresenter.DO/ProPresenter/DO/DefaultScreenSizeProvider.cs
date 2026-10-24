using System.Linq;
using Pro.Common.Mathematics;
using ProPresenter.DO.OutputConfiguration;

namespace ProPresenter.DO;

public class DefaultScreenSizeProvider : ISizeProvider
{
	private static readonly Vector2<double> DefaultSize = new Vector2<double>(1920.0, 1080.0);

	private readonly IOutputConfiguration _outputConfiguration;

	public DefaultScreenSizeProvider(IOutputConfiguration outputConfiguration)
	{
		_outputConfiguration = outputConfiguration;
	}

	public Vector2<double> GetSize()
	{
		return _outputConfiguration.AudienceArrangementScreens.FirstOrDefault()?.TotalSize ?? DefaultSize;
	}
}
