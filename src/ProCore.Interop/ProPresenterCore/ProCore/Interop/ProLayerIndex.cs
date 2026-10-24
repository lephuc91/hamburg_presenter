namespace ProPresenterCore.ProCore.Interop;

public enum ProLayerIndex
{
	Invalid = -1,
	UserLayerBegin = 0,
	VideoInput = 0,
	Live = 0,
	PresentationBackground = 1,
	Background = 1,
	PresentationForeground = 2,
	Slide = 2,
	AnnouncementsBackground = 3,
	AnnouncementsForeground = 4,
	Props = 5,
	Messages = 6,
	Music = 7,
	SoundEffects = 8,
	UserLayerEnd = 9,
	InternalLayerBegin = 9,
	LookMask = 9,
	StageDisplay = 10,
	Inspector = 11,
	Look = 12,
	Utility = 13,
	TestPattern = 14,
	VideoInputPreview = 15,
	ScreenIdentificationOverlay = 16,
	InternalLayerEnd = 17,
	LayerCount = 17,
	MaxValue = int.MaxValue
}
