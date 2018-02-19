using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BRBF.Mobile.Interfaces
{
    public interface INavigationService
    {
        void NavigateToRoot<TViewModel>(bool hasNavigationPage, object data = null) where TViewModel : class, IViewModel;
        Task NavigateToAsync<TViewModel>(object data = null) where TViewModel : class, IViewModel;
        Page GetPage<VM>(object data) where VM : class, IViewModel;
    }
}
