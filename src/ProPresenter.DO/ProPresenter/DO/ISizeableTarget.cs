using System.ComponentModel;
using Pro.Common.Mathematics;

namespace ProPresenter.DO;

public interface ISizeableTarget : INotifyPropertyChanged
{
	Vector2<double> Size { get; }

	void ChangeSize(Vector2<double> size);
}
