using Pro.Common.FileSystem;
using Pro.Interprocess;

namespace Pro.InstallHelper;

internal static class InstallHelper
{
	private static void Main(string[] args)
	{
		if (args.Length >= 2)
		{
			string source = args[0];
			string text = args[1];
			Messages<CommonAppMessages> messages = new Messages<CommonAppMessages>();
			messages.SendMessage(CommonAppMessages.InstallStarted);
			FileHelper.DeleteDirectory(text);
			FileHelper.CopyAll(source, text, overwrite: true);
			messages.SendMessage(CommonAppMessages.InstallFinished);
		}
	}
}
