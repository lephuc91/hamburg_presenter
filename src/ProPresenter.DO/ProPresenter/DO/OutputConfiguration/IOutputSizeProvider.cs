using System.ComponentModel;
using Pro.Common.Mathematics;

namespace ProPresenter.DO.OutputConfiguration;

public interface IOutputSizeProvider : INotifyPropertyChanged
{
	Vector2<double> OutputSize { get; }
}
