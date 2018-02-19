using BRBF.Mobile.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BRBF.Mobile.ViewModels
{
    public class BusinessDetailsPageViewModel
    {
        public string NAIC { get; set; }
        public bool OpenedStatus { get; set; }
        public string Name{ get; set; }
        public string ABCStatus { get; set; }
        public OwnershipType OwnershipType { get; set; }
    }
}
