using System.Windows.Controls;
using DemoLight.WpfView.Helpers;
using DemoLight.WpfView.ViewModels.Vms;

namespace DemoLight.WpfView.Pages
{
    /// <summary>
    /// Interaction logic for Start.xaml
    /// </summary>
    public partial class Start : Page
    {
        public Start()
        {
            InitializeComponent();
            if (DataContext is StartViewModel viewModel)
                viewModel.Ok = () => Navigate(NavigateTo.Login, this);
        }
    }
}
