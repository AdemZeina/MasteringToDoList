using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace masteringToDoList.WPF.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Login : Window
    {
      

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("/Views/Register.xaml", UriKind.Absolute));
        }
    }
}
