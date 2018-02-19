using BRBF.Mobile.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BRBF.Mobile.ViewModels
{
    public class BaseViewModel : IViewModel
    {
        public string Title { get; set; }
        public bool IsBusy { get; set; }

        public BaseViewModel Initialize(object navigationData)
        {
            return this;
        }
        public virtual Task InitializeAsync(object navigationData)
        {
            return Task.FromResult(false);
        }

    }
}
