using System;
using System.Windows.Media;

namespace ProPresenter.Registration.Services;

public interface IUserAvatarProvider : IObservable<ImageSource?>
{
}
