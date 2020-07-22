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
    public partial class FrmLoginMain : Form
    {
        public FrmLoginMain()
        {
            InitializeComponent();

            Handles();
        }

        /// <summary>
        /// Contains the actions for all events on the form
        /// </summary>
        public void Handles()
        {
            btnLogin.Click += new EventHandler(LoginPrsd);
            btnRegister.Click += new EventHandler(RegisterPrsd);
        }

        /// <summary>
        /// The currently shown form
        /// </summary>
        private Form activeForm = null;

        /// <summary>
        /// Opens the specified form (childForm) within the panel
        /// </summary>
        /// <param name="childForm">The form to open</param>
        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null) { activeForm.Close(); activeForm = null; }

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnForms.Controls.Add(childForm);
            pnForms.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void LoginPrsd(object sender, EventArgs e) { OpenChildForm(new FrmLoginLogin()); }
        private void RegisterPrsd(object sender, EventArgs e) { OpenChildForm(new FrmLoginRegister()); }
    }
}
