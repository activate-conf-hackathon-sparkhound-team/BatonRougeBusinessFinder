using Ninject;
using System;
using System.Collections.Generic;
using System.Text;

namespace BRBF.Mobile.Ioc
{
    public class Container
    {
        private static StandardKernel instance { get; set; }

        public static void Initialize()
        {
            var kernel = new StandardKernel();
            instance = kernel;
            instance.Load(new Shared.Ioc());

        }

        public static void Register<I, T>() where T : class, I where I : class
        {
            instance.Bind<I>().To<T>();
        }

        public static void Register<T>(T instanceName) where T : class
        {
            instance.Bind<T>().ToConstant(instanceName);
        }

        public static void Register(Type type)
        {
            instance.Bind(type).ToSelf();
        }


        public static T Resolve<T>() where T : class
        {
            return (T)Resolve(typeof(T));
        }

        public static object Resolve(Type type)
        {
            return instance.Get(type);
        }

    }
}
