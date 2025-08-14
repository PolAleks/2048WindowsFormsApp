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
        private List<RadioButton> _radioButtons;
        public FormWelcom()
        {
            InitializeComponent();
            _radioButtons = new List<RadioButton>() { radioButtonSize4, radioButtonSize5, radioButtonSize6, radioButtonSize7 };
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            string name = textBoxUserName.Text;
            int mapSize = Convert.ToInt32(_radioButtons.Single(r => r.Checked).AccessibleName);

            if (!string.IsNullOrEmpty(name))
            {
                var mainForm = new FormMain(name, mapSize);
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
