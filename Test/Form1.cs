using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data.MySqlClient;



namespace Test
{
    public partial class Form1 : Form
    {
        private DBConnect dbConnect;

        public Form1()
        {
            InitializeComponent();
            //Test();
            //TestIntersect();
            dbConnect = new DBConnect();
            MessageBox.Show(GetLocalIpAddress());

            //MessageBox.Show(dbConnect.connection.State.ToString());
        }


        public void Test()
        {
            Int32[] a = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
            Int32[] b = new int[] { 7, 8, 9, 10, 11, 12, 13, 14, 15, 7 };

            bool hasCommonElements = a.Intersect(b).Count() > 0;
            Int32[] commonElements = a.Intersect(b).ToArray();

            //MessageBox.Show(commonElements.Length.ToString());

        }

        public void TestIntersect()
        {
            Int32[] iHwnd = new Int32[] { 199576, 199576, 199576, 199576, 199576, 199576, 199576, 199576, 199576, 199576 };
            Int32[] lprozori = new Int32[] { 330488, 134094, 199576, 723984, 199726, 590452, 199580, 134052 };

            Int32[] commonElements = iHwnd.Intersect(lprozori).ToArray();
            Int32[] commonExept = iHwnd.Except(lprozori).ToArray();
        }
    

    

        private void button1_Click(object sender, EventArgs e)
        {
            //dbConnect.Select("process");
            //dbConnect.InsertProcess("DrEngel", 2212, DateTime.Now, "kreso", "kresimir", "192.168.1.101");

            DateTime dt;
            if (DateTime.TryParse("5.12.2018 10:00:09",out dt))
                MessageBox.Show(dbConnect.CheckProcess("DrEngel", 2212, dt, "kreso", "kresimir", "192.168.1.101").ToString());
        }

        private void Form1_Leave(object sender, EventArgs e)
        {
            
        }

        public string GetIPAddress()
        {
            IPHostEntry Host = default(IPHostEntry);
            string Hostname = null;
            string sIPAddress = null;
            //Hostname = System.Environment.MachineName;
            Hostname = Dns.GetHostName();
            Host = Dns.GetHostEntry(Hostname);            
            foreach (IPAddress IP in Host.AddressList)
            {
                if (IP.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    //IPAddress = Convert.ToString(IP);
                    sIPAddress = Convert.ToString(IP);
                    //return sIPAddress;
                }
            }

            return sIPAddress;
        }


        public string GetLocalIpAddress()
        {
            UnicastIPAddressInformation mostSuitableIp = null;

            var networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();

            foreach (var network in networkInterfaces)
            {
                if (network.OperationalStatus != OperationalStatus.Up)
                    continue;

                var properties = network.GetIPProperties();

                if (properties.GatewayAddresses.Count == 0)
                    continue;

                foreach (var address in properties.UnicastAddresses)
                {
                    if (address.Address.AddressFamily != AddressFamily.InterNetwork)
                        continue;

                    if (IPAddress.IsLoopback(address.Address))
                        continue;

                    if (!address.IsDnsEligible)
                    {
                        if (mostSuitableIp == null)
                            mostSuitableIp = address;
                        continue;
                    }

                    // The best IP is the IP got from DHCP server
                    if (address.PrefixOrigin != PrefixOrigin.Dhcp)
                    {
                        if (mostSuitableIp == null || !mostSuitableIp.IsDnsEligible)
                            mostSuitableIp = address;
                        continue;
                    }

                    return address.Address.ToString();
                }
            }

            return mostSuitableIp != null
                ? mostSuitableIp.Address.ToString()
                : "";
        }

    }
}
