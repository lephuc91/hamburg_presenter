using System;

namespace ProPresenter.DO.Events;

public record PlaylistProtoRequest<T>(Action<T> Callback);
