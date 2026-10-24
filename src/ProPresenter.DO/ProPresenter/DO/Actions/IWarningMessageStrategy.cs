using Pro.DO.Triggering;
using ProPresenter.DO.Actions.Capture;

namespace ProPresenter.DO.Actions;

public interface IWarningMessageStrategy
{
	string AudioInput();

	string Playlist();

	string Media(string name);

	string MediaFill(string? name);

	string Stage();

	string Timer();

	string Look(string name);

	string Communication();

	string Prop();

	string Message();

	string Default(ActionType actionType);

	string Macro();

	string ClearGroup();

	string Capture(ICapture capture);
}
