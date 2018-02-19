using BRBF.Mobile.Interfaces;
using BRBF.Mobile.Ioc;
using BRBF.Mobile.Pages;
using BRBF.Mobile.Services;
using BRBF.Mobile.ViewModels;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace BRBF.Mobile
{
	public partial class App : Application
	{

		public App ()
		{
            Container.Initialize();
            Pages();
            Container.Resolve<INavigationService>().NavigateToRoot<LoginPageViewModel>(false);

        }
        private void Pages()
        {
            Container.Register<INavigationService>(new NavigationService
            {
                Registrations =
                {
                    { typeof(LoginPage), typeof(LoginPageViewModel) },
                    { typeof(MainPage), typeof(MainPageViewModel) },
                    { typeof(NavigationMenuPage), typeof(NavigationMenuPageViewModel) },
                    { typeof(MainPageDetail), typeof(MainPageDetailViewModel) },
                    { typeof(BusinessListPage), typeof(BusinessListPageViewModel) },
                    { typeof(FavoritesPage), typeof(FavoritesPageViewModel) },
                    { typeof(BusinessDetailsPage), typeof(BusinessDetailsPageViewModel) },

                }
            });
        }


        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
