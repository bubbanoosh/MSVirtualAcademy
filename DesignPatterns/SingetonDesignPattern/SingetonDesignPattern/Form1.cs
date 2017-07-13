using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SingetonDesignPattern
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            GetStateInfo();
        }
        void GetStateInfo()
        {
            ApplicationState state = ApplicationState.GetState();
            state.LoginId="Kanchan";
            state.RoleId= "Admin";
            
            ApplicationState state2 = ApplicationState.GetState();
            label3.Text = state2.LoginId;
            label5.Text = state2.RoleId;
            label6.Text = (state == state2).ToString();          
        }
    }
}
