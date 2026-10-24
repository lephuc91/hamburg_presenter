using Pro.Common.Dispatcher;
using Pro.Common.Utility;
using ProPresenter.Controller.Triggering;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Chords;
using ProPresenter.DO.Slide.Links;

namespace ProPresenter.Controller.Links;

public class KeyInformation : IKeyInformation
{
	private sealed record KeyData(Key? BaseKey, Key? TargetKey);

	private readonly ISlideCueInfo? _cueInfo;

	private readonly IUiDispatcher _dispatcher;

	private readonly Optional<KeyData> _data = new Optional<KeyData>();

	private KeyData Data
	{
		get
		{
			lock (_data)
			{
				if (!_data.HasValue)
				{
					_dispatcher.Invoke(LoadKeys);
				}
			}
			return _data.Value;
		}
	}

	public Key? BaseKey => Data?.BaseKey;

	public Key? TargetKey => Data?.TargetKey;

	public KeyInformation(IUiDispatcher dispatcher, ISlideCueInfo? cueInfo)
	{
		_dispatcher = dispatcher;
		_cueInfo = cueInfo;
	}

	private void LoadKeys()
	{
		IDocumentAction documentAction = _cueInfo?.OriginalDocumentCue?.DocumentAction;
		_data.Value = new KeyData(documentAction?.Presentation?.BaseKey?.Clone(), documentAction?.TargetKey?.Clone());
	}
}
