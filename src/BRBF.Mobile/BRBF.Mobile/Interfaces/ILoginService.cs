using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BRBF.Mobile.Interfaces
{
    public interface ILoginService
    {
        Task LoginAsync(string provider);
        Task LogOut();
        Task StoreToken(string token);
        Task GetToken();
        Task CheckToken();
    }
}
