using System;
using System.ComponentModel;

namespace ProPresenter.DO.Actions;

public interface IPlaylistActionValidator : INotifyPropertyChanged
{
	bool IsValid { get; }

	event Action<string?> UpdateName;
}
