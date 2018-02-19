using BRBF.Mobile.Interfaces;
using BRBF.Mobile.Ioc;
using BRBF.Mobile.Services;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Text;

namespace BRBF.Shared
{
    public class Ioc : NinjectModule
    {
        public override void Load()
        {
            Container.Register<ILoginService, LoginService>();
        }
    }
}
