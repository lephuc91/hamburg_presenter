using Jab;
using ProPresenter.DO.TestPattern.Properties;
using ProPresenter.DO.TestPattern.State;

namespace ProPresenter.DO.TestPattern.DependencyInjection;

[Jab.ServiceProviderModule]
[Jab.Transient<ITestPatternPropertyFactory, TestPatternPropertyFactory>]
[Jab.Transient<ITestPatternDefinitionFactory, TestPatternDefinitionFactory>]
[Jab.Transient<ITestPatternStateFactory, TestPatternStateFactory>]
[Jab.Singleton<ITestPatternPersistence, TestPatternPersistence>]
[Jab.Singleton<ITestPatternService, TestPatternService>]
internal interface ITestPatternServiceProvicerModule
{
}
