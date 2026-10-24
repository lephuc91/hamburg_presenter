using System;

namespace ProPresenterCore.ProCore.Interop;

[Flags]
public enum ProScreenType : uint
{
	None = 0u,
	Audience = 1u,
	Stage = 2u,
	All = 3u,
	MaxValue = 0x7FFFFFFFu
}
