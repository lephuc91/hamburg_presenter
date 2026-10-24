using System.Collections.Generic;
using ProPresenter.DO.TestPattern.State;

namespace ProPresenter.DO.TestPattern;

public interface ITestPatternPersistence
{
	void Save(ITestPatternState state, IEnumerable<ITestPatternDefinition> testPatterns);

	void LoadTestPatterns(IEnumerable<ITestPatternDefinition> testPatterns);

	void LoadState(ITestPatternState state, IEnumerable<ITestPatternDefinition> testPatterns);
}
