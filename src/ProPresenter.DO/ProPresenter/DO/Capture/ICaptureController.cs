using System.ComponentModel;

namespace ProPresenter.DO.Capture;

public interface ICaptureController : ICaptureService, INotifyPropertyChanged, IResiService, IResiRemote
{
}
