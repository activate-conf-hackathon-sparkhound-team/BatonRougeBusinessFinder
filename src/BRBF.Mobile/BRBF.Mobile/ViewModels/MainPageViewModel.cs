using BRBF.Mobile.Interfaces;
using BRBF.Mobile.Models;
using BRBF.Mobile.Pages;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace BRBF.Mobile.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private INavigationService _navigation;

        public ObservableRangeCollection<string> Results { get; set; }
        public MainPageViewModel(INavigationService navigation)
        {
            _navigation = navigation;
            
        }


        public Page GetPage(NavigationMenuItem page)
        {
            switch (page.Title)
            {
                case Constants.Pages.BusinessList:
                   return _navigation.GetPage<BusinessListPageViewModel>(null);
                case Constants.Pages.Favorites:
                    return _navigation.GetPage<FavoritesPageViewModel>(null);
                default:
                    break;
            }
            return null;
        }
    }
}
