using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2048WindowsFormsApp
{
    public partial class FormWelcom : Form
    {
        public FormWelcom()
        {
            InitializeComponent();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            var name = textBoxUserName.Text;

            if (!string.IsNullOrEmpty(name))
            {
                var mainForm = new FormMain(name);
                mainForm.Show();
                mainForm.FormClosed += (s, arg) => this.Close();
                this.Hide();
            }
        }

        private void FormWelcom_Load(object sender, EventArgs e)
        {
            textBoxUserName.Focus();
        }

        private void textBoxUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonStart_Click(sender, e);
            }
        }
    }
}
