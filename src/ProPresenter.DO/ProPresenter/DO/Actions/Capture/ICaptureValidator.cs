using System;

namespace ProPresenter.DO.Actions.Capture;

public interface ICaptureValidator
{
	event Action IsValidInvalidated;

	bool GetIsValid(ICapture capture);
}
