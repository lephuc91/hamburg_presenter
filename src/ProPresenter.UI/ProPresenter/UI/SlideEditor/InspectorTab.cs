using System;

namespace ProPresenter.UI.SlideEditor;

[Flags]
public enum InspectorTab
{
	None = 0,
	Document = 1,
	StageLayout = 2,
	PropSlide = 4,
	Mask = 8,
	Template = 0x10,
	Slide = 0x20,
	Shape = 0x40,
	Text = 0x80,
	Build = 0x100
}
