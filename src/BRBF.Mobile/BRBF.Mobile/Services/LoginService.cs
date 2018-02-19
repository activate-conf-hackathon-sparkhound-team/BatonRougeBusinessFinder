using BRBF.Mobile.Interfaces;
using BRBF.Mobile.ViewModels;
using SimpleAuth.Providers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BRBF.Mobile.Services
{
    public class LoginService : ILoginService
    {
        private INavigationService _navigation;
        public LoginService(INavigationService navigation)
        {
            _navigation = navigation;
        }
        public Task CheckToken()
        {
            throw new NotImplementedException();
        }

        public Task GetToken()
        {
            throw new NotImplementedException();
        }

        public async Task LoginAsync(string provider)
        {
            var account = new SimpleAuth.Account();
            switch (provider)
            {
                case Constants.Providers.Google:
                    var clientId = Device.RuntimePlatform == Device.iOS ? Constants.ApiInfo.GoogleInfo.GoogleiOSClientId : Constants.ApiInfo.GoogleInfo.GoogleWebClientId;
                    var clientSecret = Device.RuntimePlatform == Device.iOS ? null : Constants.ApiInfo.GoogleInfo.GoogleClientSecret;
                    var googAuthenticator = new GoogleApi(Constants.Providers.Google, clientId, clientSecret) { Scopes = Constants.ApiInfo.GoogleInfo.GoogleScopes };
                    account = await googAuthenticator.Authenticate();
                    break;
                case Constants.Providers.Facebook:
                    var facebookAuthenticator = new FacebookApi(Constants.Providers.Facebook, Constants.ApiInfo.FacebookInfo.FacebookAppId, Constants.ApiInfo.FacebookInfo.FacebookSecret);
                    account = await facebookAuthenticator.Authenticate();
                    break;
                case Constants.Providers.Microsoft:
                    var microsoftAuthenticator = new MicrosoftLiveConnectApi(Constants.Providers.Microsoft, Constants.ApiInfo.MicrosoftInfo.MicrosoftAppId, Constants.ApiInfo.MicrosoftInfo.MicrosoftSecret)
                    { Scopes = Constants.ApiInfo.MicrosoftInfo.MicrosoftScopes };
                    account = await microsoftAuthenticator.Authenticate();
                    break;
                case Constants.Providers.Twitter:
                    var twitterAuthenticator = new TwitterApi(Constants.Providers.Twitter, Constants.ApiInfo.TwitterInfo.TwitterAppId, Constants.ApiInfo.TwitterInfo.TwitterSecret) { RedirectUrl = new Uri("https://mobile.twitter.com/home") };
                    account = await twitterAuthenticator.Authenticate();
                    break;
                case Constants.Providers.Local:
                    break;
                default:
                    break;
            }

            var oauthAccount = account as SimpleAuth.OAuthAccount;
            if (!string.IsNullOrEmpty(oauthAccount.Token))
            {
                await StoreToken(oauthAccount.Token);
                _navigation.NavigateToRoot<MainPageViewModel>(true, null);
            }
            return;
        }

        public Task LogOut()
        {
            throw new NotImplementedException();
        }

        public Task StoreToken(string token)
        {
            StorageService.SaveValue(Constants.Storage.Token, token);
            return Task.FromResult(0);
        }
    }
}
