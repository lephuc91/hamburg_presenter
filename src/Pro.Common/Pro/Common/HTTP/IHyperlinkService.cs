using System;

namespace Pro.Common.HTTP;

public interface IHyperlinkService
{
	void Open(Uri link);

	void OpenLocal(Uri link);
}
