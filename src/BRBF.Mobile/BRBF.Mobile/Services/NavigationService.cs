using BRBF.Mobile.Interfaces;
using BRBF.Mobile.Ioc;
using BRBF.Mobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BRBF.Mobile.Services
{
    public class NavigationService : INavigationService
    {
        public NavigationService()
        {
            Registrations.OnDictionaryChanged += (s, e) =>
            {
                Container.Register(e.Key);
                Container.Register(e.Value);
            };
        }

        private NavigationPage _page = new NavigationPage();
        private CustomDictionary<Type, Type> dictionary = new CustomDictionary<Type, Type>();
        public CustomDictionary<Type, Type> Registrations => dictionary;

        public void NavigateToRoot<VM>(bool hasNavigationPage, object data = null) where VM : class, IViewModel
        {
            var page = GetPage<VM>(data);

            if (hasNavigationPage)
            {
                _page.PushAsync(page);

                Application.Current.MainPage = _page;
            }
            else
            {
                Application.Current.MainPage = page;
            }
        }

        public Task NavigateToAsync<VM>(object data = null) where VM : class, IViewModel
        {
            var page = GetPage<VM>(data);

            return PushPageAsync(page);
        }

        public Page GetPage<VM>(object data) where VM : class, IViewModel
        {
            var vmType = typeof(VM);
            var pageType = dictionary.FirstOrDefault(x => x.Value == vmType).Key;

            var page = Container.Resolve(pageType) as Page;

            var vm = Container.Resolve<VM>();

            if (data != null)
                vm.Initialize(data);

            page.BindingContext = vm;

            return page;
        }

        private Task PushPageAsync(Page page)
        {
            return _page.PushAsync(page);
        }
    }
}
