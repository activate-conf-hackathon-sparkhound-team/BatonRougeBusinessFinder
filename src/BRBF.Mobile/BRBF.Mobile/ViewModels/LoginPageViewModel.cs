using BRBF.Mobile.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BRBF.Mobile.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
    {
        readonly ILoginService _loginService;
        readonly INavigationService _navigationService;
        public LoginPageViewModel(ILoginService loginService, INavigationService navigationService)
        {
            _loginService = loginService;
            _navigationService = navigationService;
        }

        Command<string> loginCommand;
        public Command<string> LoginCommand => loginCommand ?? (loginCommand = new Command<string>(async (provider) => await ExecuteLoginCommand(provider).ConfigureAwait(false)));

        private async Task ExecuteLoginCommand(string provider)
        {
            try
            { 
                //await _loginService.LoginAsync(provider);
                _navigationService.NavigateToRoot<MainPageViewModel>(false,null);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                throw;
            }
        }
    }
}
