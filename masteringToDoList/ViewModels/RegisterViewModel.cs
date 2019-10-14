using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using masteringToDoList.WPF.Helpers;
using masteringToDoList.WPF.Services;
using Prism.Mvvm;
using Prism.Regions;

namespace masteringToDoList.WPF.ViewModels
{
    public class RegisterViewModel : BindableBase, INavigationAware
    {
        private ApiServices _apiServices = new ApiServices();


        private string _firstName;
        public string FirstName
        {
            get => _firstName;
            set => SetProperty(ref _firstName, value);
        }

        private string _lastName;
        public string LastName
        {
            get => _lastName;
            set => SetProperty(ref _lastName, value);
        }

        private string _email;
        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        private string _password;
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }



        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            throw new System.NotImplementedException();
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