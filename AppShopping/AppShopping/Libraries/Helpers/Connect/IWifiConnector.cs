using System;
using System.Collections.Generic;
using System.Text;

namespace AppShopping.Libraries.Helpers.Connect
{
    public interface IWifiConnector
    {
        //Nome do Wifi e Senha
        void ConnectToWifi(string ssid, string password);
    }
}
