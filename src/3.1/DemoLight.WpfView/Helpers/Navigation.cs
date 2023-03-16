using System;
using System.Windows.Controls;
using DemoLight.WpfView.Pages;

namespace DemoLight.WpfView.Helpers
{
    internal static class Navigation
    {
        internal static bool Navigate(NavigateTo target, DemoLightWin win) =>
            win.MainFrame.Navigate(GetPage(target));

        internal static bool Navigate(NavigateTo target, Page page) =>
            page.NavigationService!.Navigate(GetPage(target));

        private static Page GetPage(NavigateTo target) => target switch
        {
            NavigateTo.Start => new Start(),
            NavigateTo.Login => new Login(),
            //NavigateTo.Registration => new RegistrationPage(),
            //NavigateTo.AdminArea => new AdminPage(),
            //NavigateTo.UserArea => new UserPage(),
            _ => throw new NotImplementedException()
        };
    }
}