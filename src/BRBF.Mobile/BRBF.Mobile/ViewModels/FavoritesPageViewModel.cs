using BRBF.Mobile.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BRBF.Mobile.ViewModels
{
    public class FavoritesPageViewModel : BaseViewModel
    {
        public string NAIC { get; set; }
        public int LocationDistance { get; set; }
        public bool Open { get; set; }
        public bool Close { get; set; }
        public string ABCStatus { get; set; }
        public List<OwnershipType> OwnershipType { get; set; }
        public List<string> AnswerChoices => new List<string> {"Yes","No","NA"};
        public FavoritesPageViewModel()
        {

        }
    }
}
