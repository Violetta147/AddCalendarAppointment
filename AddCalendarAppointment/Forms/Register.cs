using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using AddCalendarAppointment.Services.Interfaces;

namespace AddCalendarAppointment.Forms
{
    public partial class Register : Form
    {   
        private readonly IUserService _userSvc;
        public Register(IUserService userSvc)
        {
            _userSvc = userSvc;
            InitializeComponent();
        }
        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (passwordtxt.Text != confirmpasswordtxt.Text)
            {
                MessageBox.Show("Passwords do not match.");
                return;
            }

            var success = _userSvc.Register(
                nametxt.Text,
                usernametxt.Text,
                passwordtxt.Text);

            MessageBox.Show(success
                ? "Registration successful! Please log in."
                : "Username already taken.");

            if (success)
                this.Close();
        }
    }
}
