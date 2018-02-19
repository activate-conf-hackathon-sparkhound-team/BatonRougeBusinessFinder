using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BRBF.Mobile.Ioc;
using BRBF.Mobile.Models;
using BRBF.Mobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BRBF.Mobile.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MasterDetailPage
    {
        private MainPageViewModel vm;

        public MainPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            vm = Container.Resolve<MainPageViewModel>();
            NavigationMenuPage.ListView.ItemSelected += NavigateToPage;
            base.OnAppearing();
        }
        public void NavigateToPage(object s, EventArgs args)
        {
            var listView = s as ListView;

            var selectedNav = listView.SelectedItem as NavigationMenuItem;
            if (listView.SelectedItem != null)
                Detail = new NavigationPage(vm.GetPage(selectedNav));
            listView.SelectedItem = null;
        }
    }
}