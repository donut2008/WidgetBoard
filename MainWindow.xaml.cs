// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

using Microsoft.UI.Xaml.Controls;

namespace WidgetBoard
{
	/// <summary>
	/// An empty window that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class MainWindow : WinUIEx.WindowEx
	{
        public MainWindow()
		{
			this.InitializeComponent();
		}

		private void NavView_SelectionChanged(Microsoft.UI.Xaml.Controls.NavigationView sender, Microsoft.UI.Xaml.Controls.NavigationViewSelectionChangedEventArgs args)
		{
			var slPage = (Microsoft.UI.Xaml.Controls.NavigationViewItem)args.SelectedItem;
			if (args.IsSettingsSelected)
				ContentFrame.Navigate(typeof(SettingsPage), null);
			else
			{
				switch (slPage.Tag.ToString())
				{
					case "WPan":
						ContentFrame.Navigate(typeof(WidgetsPanel), null);
						break;
					case "WSet":
						ContentFrame.Navigate(typeof(WidgetsSettings), null);
						break;
					default:
						ContentDialog NavFailure = new ContentDialog()
						{
							Title = "Navigation failed",
							Content = "Navigation failed due to internal error."
						};
						break;
				}
			}
		}
	}
}
