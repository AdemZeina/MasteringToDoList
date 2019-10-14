using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using masteringToDoList.WPF.Helpers;
using masteringToDoList.WPF.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace masteringToDoList.WPF.ViewModels
{
    public class LoginViewModel : BindableBase, INavigationAware
    {
        private readonly ApiServices _apiServices = new ApiServices();

        private string _emai;
        public string Email
        {
            get => _emai;
            set => SetProperty(ref _emai, value);
        }

        public string Password { get; set; }

        public ICommand LoginCommand => new DelegateCommand(HandleLogin);

        public async void HandleLogin()
        {
            MessageBox.Show("Login Invoked");
            var result=await _apiServices.LoginAsync(Email, Password); 
            //Email = "ADEM";
            
        }
      

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            Email = "adem@hotmail.com";
            Password = "Adem@123";
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            throw new System.NotImplementedException();
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            throw new System.NotImplementedException();
        }
    }
}