using Plugin.SecureStorage;
using System;
using System.Collections.Generic;
using System.Text;

namespace BRBF.Mobile.Services
{
    public class StorageService
    {
        public static void SaveValue(string name, string value)
        {
            CrossSecureStorage.Current.SetValue(name, value);
        }

        public static void GetValue(string name)
        {
            CrossSecureStorage.Current.GetValue(name);
        }

        public static void DeleteValue(string name)
        {
            CrossSecureStorage.Current.DeleteKey(name);
        }

        public static bool CheckKey(string name)
        {
            return CrossSecureStorage.Current.HasKey(name);
        }
    }
}
