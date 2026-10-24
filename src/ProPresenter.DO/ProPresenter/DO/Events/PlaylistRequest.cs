using System;

namespace ProPresenter.DO.Events;

public record PlaylistRequest<T>(Action<T> Callback);
