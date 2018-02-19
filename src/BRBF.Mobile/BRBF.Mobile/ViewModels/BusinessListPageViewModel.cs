using BRBF.Mobile.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BRBF.Mobile.ViewModels
{
    public class BusinessListPageViewModel : BaseViewModel
    {
        public string SearchString { get; set; }
        public List<Business> Businesses { get; set; }
    }
}
