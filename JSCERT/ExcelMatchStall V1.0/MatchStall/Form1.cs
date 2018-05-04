using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary1;
using NPOI.HSSF.Record.PivotTable;

namespace MatchStall
{
  
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
     

        private void button1_Click(object sender, EventArgs e)
        {
           // MessageBox.Show(Class1.tvalue(8));
            Class1 class1=new Class1();
            class1.EvevtValue += new Class1.SetValue(class1_EvevtValue);
            class1.DoSomething(8);
        }

        void class1_EvevtValue(int i,string msg)
        {
            MessageBox.Show("事件返回值："+i.ToString()+msg);
        }
    }
}
