using System.Collections.Generic;
using System.IO.Abstractions;
using System.Linq;
using System.Threading.Tasks;
using ProPresenter.DO;
using ProPresenter.DO.Masks;
using ProPresenter.DO.Media;
using ProPresenter.DO.OutputConfiguration;
using ProPresenter.DO.Settings;

namespace ProPresenter.ViewModels.Settings.Pages.Media;

public class MediaFilesProvider : IMediaFilesProvider
{
	private readonly IProPresenterResourceService _resourceService;

	private readonly IFileSystem _fileSystem;

	private readonly IGeneral _general;

	private readonly IOutputConfiguration _outputConfiguration;

	private readonly IMaskCollection _masks;

	public MediaFilesProvider(IProPresenterResourceService resourceService, IFileSystem fileSystem, IGeneral general, IOutputConfiguration outputConfiguration, IMaskCollection masks)
	{
		_resourceService = resourceService;
		_fileSystem = fileSystem;
		_general = general;
		_outputConfiguration = outputConfiguration;
		_masks = masks;
	}

	public async Task<IEnumerable<string>> GetUnlinkedMediaFilesAsync()
	{
		IEnumerable<string> enumerable = await MediaHelper.GetUnlinkedMediaFilesAsync(_resourceService, _outputConfiguration.AudienceLooks, _fileSystem, _masks);
		if (_general.LogoFilename != null && enumerable.Contains(_general.LogoFilename))
		{
			return enumerable.Except(new global::_003C_003Ez__ReadOnlySingleElementList<string>(_general.LogoFilename));
		}
		return enumerable;
	}
}
