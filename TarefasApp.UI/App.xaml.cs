namespace TarefasApp.UI;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		// Definindo a MainPage
		MainPage = new AppShell();
	}
}
