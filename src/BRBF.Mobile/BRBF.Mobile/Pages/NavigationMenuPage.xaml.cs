using BRBF.Mobile.Ioc;
using BRBF.Mobile.Models;
using BRBF.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BRBF.Mobile.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NavigationMenuPage : ContentPage
	{
        public ListView ListView { get { return listView; } }

        public NavigationMenuPage ()
		{
			InitializeComponent ();
		}

    

      
	}
}