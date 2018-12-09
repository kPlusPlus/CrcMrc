using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
            TestIntersect();
            dbConnect = new DBConnect();

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
    }
}
