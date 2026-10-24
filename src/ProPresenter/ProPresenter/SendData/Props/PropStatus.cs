using System;

namespace ProPresenter.SendData.Props;

public record PropStatus(Guid PropID, double TimeRemaining, bool IsPaused, double Progress);
