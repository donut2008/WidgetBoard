// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

using Microsoft.UI.Xaml;
using Microsoft.UI;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Windows.UI.ViewManagement;
using Microsoft.UI.Windowing;
using WinRT.Interop;

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
			SetCustomTitleBar();
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
		UISettings UISettings = new UISettings();
		private void SetCustomTitleBar()
		{
			var RootUI = (FrameworkElement)Content;
			if (AppWindowTitleBar.IsCustomizationSupported())
			{
				AppWindow appWindow =
					AppWindow.GetFromWindowId(Win32Interop.GetWindowIdFromWindow(WindowNative.GetWindowHandle(this)));
				var titleBar = appWindow.TitleBar;
				titleBar.ExtendsContentIntoTitleBar = true;

				void SetColor()
				{
					appWindow.Title = "MCInstaller";
					titleBar.ExtendsContentIntoTitleBar = true;
					titleBar.ButtonBackgroundColor = Colors.Transparent;
					titleBar.ButtonInactiveBackgroundColor = Colors.Transparent;
					titleBar.ButtonInactiveForegroundColor = UISettings.GetColorValue(UIColorType.Accent);
					titleBar.ButtonHoverBackgroundColor =
						((SolidColorBrush)App.Current.Resources.ThemeDictionaries[
							"SystemControlBackgroundListLowBrush"]).Color;
					titleBar.ButtonPressedBackgroundColor =
						((SolidColorBrush)App.Current.Resources.ThemeDictionaries[
							"SystemControlBackgroundListMediumBrush"]).Color;
				}

				RootUI.ActualThemeChanged += (_, _) => SetColor();
				SetColor();
			}
			else
			{
				ExtendsContentIntoTitleBar = true;
				SetTitleBar(AppTitleBar);
			}
		}
	}
}
