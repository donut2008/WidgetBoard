// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Hosting;
using Microsoft.UI.Xaml.Media;
using Windows.UI;
using WidgetBoard.Widgets;

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

		private void WidgetGrid_Loaded(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            dbw.Visibility = Visibility.Collapsed;
            cw.Visibility = Visibility.Visible;
            aw.Visibility = Visibility.Visible;
            calw.Visibility = Visibility.Visible;
            fw.Visibility = Visibility.Visible;
        }
	}
}
