﻿using System;
using System.Globalization;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;


namespace MyGame.Sources.ServerCore
{
    public class SleepMode
    {
        IPHostEntry entry ;
        
        [DllImport("Powrprof.dll", CharSet=CharSet.Auto, ExactSpelling=true)]
        private static extern bool SetSuspendState(bool hibernate, bool forceCritical, bool disableWakeEvent);

        public static void GoHibernateMode(ArgumentAction _)
        {
            SetSuspendState(true, true, true);
            // Hibernate for winforms
            // Application.SetSuspendState(PowerState.Hibernate, true, true);

        }
        public static void GoStandbyMode(ArgumentAction _)
        {
            SetSuspendState(false, true, true);
            // Standby for winforms
            // Application.SetSuspendState(PowerState.Suspend, true, true);
        }
        
        [DllImport("iphlpapi.dll", ExactSpelling = true)]
        public static extern int SendARP(int destIp, int srcIP, byte[] macAddr, ref uint physicalAddrLen);
        private void WakeFunction(string MAC_ADDRESS)
        {
            WOLClass client = new WOLClass();
            client.Connect(new IPAddress(0xffffffff), 0x2fff);
            client.SetClientToBrodcastMode();
            int counter = 0;
            //буфер для отправки
            byte[] bytes = new byte[1024];
            //Первые 6 бит 0xFF
            for (int y = 0; y < 6; y++)
                bytes[counter++] = 0xFF;
            //Повторим MAC адрес 16 раз
            for (int y = 0; y < 16; y++)
            {
                int i = 0;
                for (int z = 0; z < 6; z++)
                {
                    bytes[counter++] = byte.Parse(MAC_ADDRESS.Substring(i, 2), NumberStyles.HexNumber);
                    i += 2;
                }
            }

            //Отправляем полученный магический пакет
            int reterned_value = client.Send(bytes, 1024);
        }
        private class WOLClass : UdpClient
        {
            public WOLClass()
                : base()
            { }
            //Установим broadcast для отправки сообщений
            public void SetClientToBrodcastMode()
            {
                if (this.Active)
                    this.Client.SetSocketOption(SocketOptionLevel.Socket,SocketOptionName.Broadcast, 0);
            }
        }
        
        private void GetInform(string textName)
        {
            string IP_Address = "";
            string HostName = "";
            string MacAddress = "";

            try
            {
                //Проверяем существует ли IP
                entry = Dns.GetHostEntry(textName);
                foreach (IPAddress a in entry.AddressList)
                {
                    IP_Address = a.ToString();
                    break;
                }

                //Получаем HostName
                HostName = entry.HostName;

                //Получаем Mac-address
                IPAddress dst = IPAddress.Parse(textName); 

                byte[] macAddr = new byte[6];
                uint macAddrLen = (uint)macAddr.Length;

                if (SendARP(BitConverter.ToInt32(dst.GetAddressBytes(), 0), 0, macAddr, ref macAddrLen) != 0)
                    throw new InvalidOperationException("SendARP failed.");

                string[] str = new string[(int)macAddrLen];
                for (int i = 0; i < macAddrLen; i++)
                    str[i] = macAddr[i].ToString("x2");

                MacAddress = string.Join(":", str);

                
            }
            catch { }
           
        }
    }
}
