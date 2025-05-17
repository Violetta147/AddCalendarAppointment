using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AddCalendarAppointment.Services.Interfaces;
using AddCalendarAppointment.Forms;

namespace AddCalendarAppointment
{
    public partial class Login : Form
    {
        private readonly IUserService _userSvc;
        public Login(IUserService userSvc)
        {
            _userSvc = userSvc;
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var user = _userSvc.Authenticate(
                usernametxt.Text,
                passwordtxt.Text);

            if (user != null)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }

        private void btnGoToRegister_Click(object sender, EventArgs e)
        {
            using (var reg = new Register(_userSvc))
            {
                reg.ShowDialog();
            }
        }
    }
}
