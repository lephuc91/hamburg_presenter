namespace Pro.Common.Background;

public interface IBackgroundProcess
{
	string InProgressMessageTitleStringKey { get; }

	string InProgressMessageMessageStringKey { get; }

	bool IsBusy { get; }

	void Stop();
}
