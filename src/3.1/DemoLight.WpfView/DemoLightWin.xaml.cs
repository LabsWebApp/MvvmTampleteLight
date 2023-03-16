using System.Windows;
using DemoLight.WpfView.Helpers;

namespace DemoLight.WpfView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class DemoLightWin : Window
    {
        public DemoLightWin()
        {
            InitializeComponent();
            Navigation.Navigate(NavigateTo.Start, this);
        }
    }
}
