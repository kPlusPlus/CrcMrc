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
            Test();
            dbConnect = new DBConnect();

            //MessageBox.Show(dbConnect.connection.State.ToString());
        }
        

        public void Test()
        {
            Int32[] a = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
            Int32[] b = new int[] { 7, 8, 9, 10, 11, 12, 13, 14, 15 };

            bool hasCommonElements = a.Intersect(b).Count() > 0;
            Int32[] commonElements = a.Intersect(b).ToArray();

            //MessageBox.Show(commonElements.Length.ToString());

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //dbConnect.Select("process");
            //dbConnect.InsertProcess("DrEngel", 2212, DateTime.Now, "kreso", "kresimir", "192.168.1.101");

            DateTime dt;
            dt = DateTime.TryParse("5.12.2018 10:00:09");

            MessageBox.Show(dbConnect.CheckProcess("DrEngel", 2212, dt, "kreso", "kresimir", "192.168.1.101").ToString());
        }
    }
}
