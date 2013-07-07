using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace QBfinance_auto
{
    public class ProxyException : Exception
    {
        public string Proxy { get; set; }

        public ProxyException() { }

        public ProxyException(string proxy)
        {
            Proxy = proxy;
        }
    }

    public class ProxyService
    {
        [DllImport("wininet.dll")]
        static extern bool InternetSetOption(IntPtr hInternet, int dwOption, IntPtr lpBuffer, int dwBufferLength);
        const int INTERNET_OPTION_SETTINGS_CHANGED = 39;
        const int INTERNET_OPTION_REFRESH = 37;
        static bool settingsReturn, refreshReturn;

        private static bool RefreshSettings()
        {
            // These lines implement the Interface in the beginning of program 
            // They cause the OS to refresh the settings, causing IP to realy update
            settingsReturn = InternetSetOption(IntPtr.Zero, INTERNET_OPTION_SETTINGS_CHANGED, IntPtr.Zero, 0);
            refreshReturn = true;// InternetSetOption(IntPtr.Zero, INTERNET_OPTION_REFRESH, IntPtr.Zero, 0);
            return (settingsReturn && refreshReturn);
        }

        public static void SetProxy(string proxy)
        {
            RegistryKey registry = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings", true);
            registry.SetValue("ProxyEnable", 1);
            registry.SetValue("ProxyServer", proxy);

            if (!RefreshSettings())
            {
                throw new ProxyException(proxy);
            }
        }

        public static void DisableProxy()
        {
            RegistryKey registry = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings", true);
            registry.SetValue("ProxyEnable", 0);

            if (!RefreshSettings())
            {
                throw new ProxyException();
            }
        }
    }
}
