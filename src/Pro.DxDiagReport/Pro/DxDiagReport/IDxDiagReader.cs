using System.Collections.Generic;

namespace Pro.DxDiagReport;

public interface IDxDiagReader
{
	IEnumerable<IDxDiagProperty> Read();
}
