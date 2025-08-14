using _2048.Common;
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
    public partial class FormResults : Form
    {
        private List<User> _users;
        public FormResults()
        {
            InitializeComponent();
        }

        private void FormResults_Load(object sender, EventArgs e)
        {
            _users = UsersScoreStorage.GetAll();
            foreach (var user in _users)
            {
                resultsDataGridView.Rows.Add(user.Name, user.Score);
            }
        }
    }
}
