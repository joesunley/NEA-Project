using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login_Visual
{
    public partial class FrmLoginLogin : Form
    {
        public FrmLoginLogin()
        {
            InitializeComponent();

            Handles();
        }

        /// <summary>
        /// Contains the actions for all events on the form
        /// </summary>
        public void Handles()
        {
            txtUsername.GotFocus += new EventHandler(HideUN);
            txtUsername.LostFocus += new EventHandler(ShowUN);
            txtPassword.GotFocus += new EventHandler(HidePW);
            txtPassword.LostFocus += new EventHandler(ShowPW);
            txtPassword.TextChanged += new EventHandler(PwChars);

            btnLogin.Click += new EventHandler(LoginPrsd);
            btnForgotPassword.Click += new EventHandler(FgtPwPrsd);

            btnClose.Click += new EventHandler(ClsFrm);

        }

        //  Hide.. : When the respective textbox gets focus and still contains the default text, it will clear that text
        //  Show.. : When the respective textbok loses focus and does not contain any text, it will change back to the default text
        private void HideUN(object sender, EventArgs e) { if(txtUsername.Text == "Username") { txtUsername.Text = ""; } }
        private void ShowUN(object sender, EventArgs e) { if (txtUsername.Text == "") { txtUsername.Text = "Username"; } }

        private void HidePW(object sender, EventArgs e) { if (txtPassword.Text == "Password") { txtPassword.Text = ""; } }
        private void ShowPW(object sender, EventArgs e) { if (txtPassword.Text == "") { txtPassword.Text = "Password"; } }
        /// <summary>
        /// When the user types something sets the chars to all asteriks
        /// </summary>
        private void PwChars(object sender, EventArgs e) { if (txtPassword.TextLength == 1) { txtPassword.PasswordChar = '*'; } }

        /// <summary>
        /// Closes the Form
        /// </summary>
        private void ClsFrm(object sender, EventArgs e) { this.Close(); }

        private void LoginPrsd(object sender, EventArgs e) { }
        private void FgtPwPrsd(object sender, EventArgs e) { }


    }
}
