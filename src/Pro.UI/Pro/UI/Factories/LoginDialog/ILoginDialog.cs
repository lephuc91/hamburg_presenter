namespace Pro.UI.Factories.LoginDialog;

public interface ILoginDialog
{
	string FinalLoginUrl { get; }

	bool? ShowDialog();
}
