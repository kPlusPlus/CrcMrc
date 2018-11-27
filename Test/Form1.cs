using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Test();
        }

        public void Test()
        {
            Int32[] a = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
            Int32[] b = new int[] { 7, 8, 9, 10, 11, 12, 13, 14, 15 };

            bool hasCommonElements = a.Intersect(b).Count() > 0;
            Int32[] commonElements = a.Intersect(b).ToArray();

            MessageBox.Show(commonElements.Length.ToString());


        }
    }
}
