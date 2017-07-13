using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AbstractFactoryPatternExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            GetClientObject();
        }
        void GetClientObject()
        {
            PacknDelvFactory sf = new StandardFactory(); 
            Client standard = new Client(sf);
            label1.Text = standard.ClientPackaging.GetType().ToString();
            label2.Text = standard.ClientDocument.GetType().ToString();

            PacknDelvFactory df = new DelicateFactory(); 
            Client delicate = new Client(df);
            label3.Text = delicate.ClientPackaging.GetType().ToString();
            label4.Text = delicate.ClientDocument.GetType().ToString();      
        }    
    }
}
