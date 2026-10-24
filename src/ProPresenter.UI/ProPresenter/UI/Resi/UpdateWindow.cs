using System.Windows.Input;
using System.Windows.Markup;
using Pro.UI.Controls.Windowing;

namespace ProPresenter.UI.Resi;

public partial class UpdateWindow : ChromedWindow, IComponentConnector
{
	public UpdateWindow()
	{
		InitializeComponent();
		base.PreviewKeyDown += delegate(object s, KeyEventArgs e)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0008: Invalid comparison between Unknown and I4
			if ((int)e.Key == 13)
			{
				Close();
			}
		};
	}
}
