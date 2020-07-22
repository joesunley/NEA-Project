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
    public partial class FrmLoginRegister : Form
    {
        public FrmLoginRegister()
        {
            InitializeComponent();

            Handles();
        }

        /// <summary>
        /// Contains the actions for all events on the form
        /// </summary>
        public void Handles()
        {
            txtEmail.GotFocus += new EventHandler(HideEM);
            txtEmail.LostFocus += new EventHandler(ShowEM);

            txtUsername.GotFocus += new EventHandler(HideUN);
            txtUsername.LostFocus += new EventHandler(ShowUN);

            txtPassword.GotFocus += new EventHandler(HidePW);
            txtPassword.LostFocus += new EventHandler(ShowPW);
            txtPassword.TextChanged += new EventHandler(PwChars);

            txtClub.GotFocus += new EventHandler(HideCL);
            txtClub.LostFocus += new EventHandler(ShowCL);

            txtCfUsername.GotFocus += new EventHandler(HideCF);
            txtCfUsername.LostFocus += new EventHandler(ShowCF);

            btnRegister.Click += new EventHandler(RegisterPrsd);

            btnClose.Click += new EventHandler(ClsFrm);
        }

        //  Hide.. : When the respective textbox gets focus and still contains the default text, it will clear that text
        //  Show.. : When the respective textbok loses focus and does not contain any text, it will change back to the default text
        private void HideEM(object sender, EventArgs e) { if (txtEmail.Text == "Email") { txtEmail.Text = ""; } }
        private void ShowEM(object sender, EventArgs e) { if (txtEmail.Text == "") { txtEmail.Text = "Email"; } }

        private void HideUN(object sender, EventArgs e) { if (txtUsername.Text == "Username") { txtUsername.Text = ""; } }
        private void ShowUN(object sender, EventArgs e) { if (txtUsername.Text == "") { txtUsername.Text = "Username"; } }

        private void HidePW(object sender, EventArgs e) { if (txtPassword.Text == "Password") { txtPassword.Text = ""; } }
        private void ShowPW(object sender, EventArgs e) { if (txtPassword.Text == "") { txtPassword.Text = "Password"; } }
        /// <summary>
        /// When the user types something sets the chars to all asteriks
        /// </summary>
        private void PwChars(object sender, EventArgs e) { if (txtPassword.TextLength == 1) { txtPassword.PasswordChar = '*'; } }

        private void HideCL(object sender, EventArgs e) { if (txtClub.Text == "Club") { txtClub.Text = ""; } }
        private void ShowCL(object sender, EventArgs e) { if (txtClub.Text == "") { txtClub.Text = "Club"; } }

        private void HideCF(object sender, EventArgs e) { if (txtCfUsername.Text == "CF Username") { txtCfUsername.Text = ""; } }
        private void ShowCF(object sender, EventArgs e) { if (txtCfUsername.Text == "") { txtCfUsername.Text = "CF Username"; } }

        private void RegisterPrsd(object sender, EventArgs e) { }
        
        /// <summary>
        /// Closes the form
        /// </summary>
        private void ClsFrm(object sender, EventArgs e) { this.Close(); }
    }
}
