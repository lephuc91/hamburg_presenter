namespace ProPresenterCore.ProCore.Interop;

public enum ProResiTransferType
{
	kProResiTransferProcessStart = 0,
	kProResiTransferProcessStop = 1,
	kProResiTransferStreamStart = 2,
	kProResiTransferStreamStop = 3,
	kProResiTransferEncoderProfiles = 4,
	kProResiTransferDestinationGroups = 5,
	kProResiTransferAboutInfo = 6,
	kProResiTransferEventStatus = 7,
	kProResiTransferBeginUpdateReady = 8,
	kProResiTransferPluginRemovalReady = 9,
	MaxValue = int.MaxValue
}
