using System;
using Pro.Localization;

namespace Pro.UI.DialogService;

[Flags]
public enum ForceQuitButton
{
	[LocalizedString("GLOBAL_CANCEL_BUTTON_title")]
	Cancel = 1,
	[LocalizedString("APP_QUIT_IMMEDIATELY_BUTTON_title")]
	QuitImmediately = 2,
	[LocalizedString("APP_QUIT_RESI_STREAM_ACTIVE_STOP_AND_UPLOAD_BUTTON_title")]
	StopStreamCompleteUpload = 4,
	[LocalizedString("APP_QUIT_AFTER_RESI_FILES_UPLOAD_BUTTON_title")]
	QuitAfterUploadCompletes = 8,
	[LocalizedString("APP_QUIT_ANYWAYS_BUTTON_title")]
	Continue = 0x10
}
