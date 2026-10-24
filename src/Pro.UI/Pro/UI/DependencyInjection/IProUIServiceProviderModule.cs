using Jab;
using Pro.UI.Controls;
using Pro.UI.DialogService;
using Pro.UI.Factories.LoginDialog;
using Pro.UI.Utility;

namespace Pro.UI.DependencyInjection;

[Jab.ServiceProviderModule]
[Jab.Transient<IFileSelectorService, FileSelectorService>]
[Jab.Transient<ISpellChecker, SpellChecker>]
[Jab.Transient<ILoginDialogFactory, LoginDialogFactory>]
[Jab.Transient<IMessageDialogService, MessageDialogServiceInstance>]
public interface IProUIServiceProviderModule
{
}
