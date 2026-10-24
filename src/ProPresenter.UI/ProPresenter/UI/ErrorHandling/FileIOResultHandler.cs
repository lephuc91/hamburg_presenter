using Pro.Common.FileSystem;
using Pro.Localization;
using Pro.UI.DialogService;

namespace ProPresenter.UI.ErrorHandling;

public static class FileIOResultHandler
{
	public static bool ShowDialog(FileIOResult result)
	{
		if (MessageDialogService.ShowDialog(LocalizedStrings.Get("FILEIO_ERROR_title"), GetFullDescription(result), DefaultButtons.CONTINUE | DefaultButtons.QUIT, DefaultButtons.QUIT) == DefaultButtons.QUIT)
		{
			return false;
		}
		return true;
	}

	private static string GetFullDescription(FileIOResult result)
	{
		return result.Status switch
		{
			IOResult.Success => "Success", 
			IOResult.TimedOut => LocalizedStrings.Get("FILEIO_ERROR_TIMEDOUT_message", new object[1] { result.FilePath }), 
			IOResult.NotFound => LocalizedStrings.Get("FILEIO_ERROR_NOT_FOUND_message", new object[1] { result.FilePath }), 
			IOResult.Unauthorized => LocalizedStrings.Get("FILEIO_ERROR_NOT_AUTHORIZED_message", new object[1] { result.FilePath }), 
			IOResult.InvalidArgument => LocalizedStrings.Get("FILEIO_ERROR_INVALID_ARG_message", new object[1] { result.FilePath }), 
			IOResult.InvalidOperation => LocalizedStrings.Get("FILEIO_ERROR_INVALID_OP_message", new object[1] { result.FilePath }), 
			IOResult.Error => LocalizedStrings.Get("FILEIO_ERROR_EXCEPTION_message", result.FilePath, result.Error), 
			_ => LocalizedStrings.Get("FILEIO_ERROR_GENERIC_message", new object[1] { result.FilePath }), 
		};
	}
}
