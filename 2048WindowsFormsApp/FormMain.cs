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
    public partial class FormMain : Form
    {
        private Label[,] _labelCells;
        private int _mapSize = 4;

        private static Random rnd = new Random();
        private List<int> _emptyCells = new List<int>(); // Список пустых ячеек

        private int _score;

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            InitMap();
            GenerateNumber();
        }

        /// <summary>
        /// Генерирует число в случайной пустой ячейки
        /// </summary>
        private void GenerateNumber()
        {
            _emptyCells.Clear();

            if (_labelCells.Length > 0)
                _emptyCells = GetEmptyCells();

            if (_emptyCells.Count != 0)
            {
                int indexEmptyCell = rnd.Next(_emptyCells.Count);
                int numberCell = _emptyCells[indexEmptyCell];

                int rowIndex = numberCell / _mapSize;
                int columnIndex = numberCell % _mapSize;

                _labelCells[rowIndex, columnIndex].Text = "2";
            }

            labelScoreValue.Text = _score.ToString();
        }

        /// <summary>
        /// Формирует список номеров незаполненных ячеек
        /// </summary>
        /// <returns>Возвращает список пустых ячеек</returns>
        private List<int> GetEmptyCells()
        {
            var list = new List<int>();
            for (int i = 0; i < _mapSize; i++)
            {
                for (int j = 0; j < _mapSize; j++)
                {
                    if (_labelCells[i, j].Text == string.Empty)
                    {
                        int number = i * _mapSize + j;
                        list.Add(number);
                    }
                }
            }
            return list;
        }

        private void InitMap()
        {
            _labelCells = new Label[_mapSize, _mapSize];

            for (int i = 0; i < _mapSize; i++)
            {
                for (int j = 0; j < _mapSize; j++)
                {
                    int numberCell = i * _mapSize + j;
                    var label = GetLabelCell(i, j);
                    Controls.Add(label);
                    _labelCells[i, j] = label;
                }
            }
        }

        private static Label GetLabelCell(int indexRow, int indexColumn)
        {
            var labelCell = new Label();
            labelCell.BackColor = Color.RosyBrown;
            labelCell.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
            labelCell.ForeColor = Color.White;
            labelCell.Size = new Size(70, 70);
            labelCell.TextAlign = ContentAlignment.MiddleCenter;

            int x = 30 + indexColumn * 76;
            int y = 70 + indexRow * 76;
            labelCell.Location = new Point(x, y);

            return labelCell;
        }

        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                for (int i = 0; i < _mapSize; i++)
                {
                    for (int j = _mapSize - 1; j >= 0; j--)
                    {
                        if (_labelCells[i, j].Text != string.Empty)
                        {
                            for (int k = j - 1; k >= 0; k--)
                            {
                                if (_labelCells[i, k].Text != string.Empty)
                                {
                                    if (_labelCells[i, j].Text == _labelCells[i, k].Text)
                                    {
                                        int number = Convert.ToInt32(_labelCells[i, j].Text) * 2;
                                        _score += number;
                                        _labelCells[i, j].Text = number.ToString();
                                        _labelCells[i, k].Text = string.Empty;
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }

                for (int i = 0; i < _mapSize; i++)
                {
                    for (int j = _mapSize - 1; j >= 0; j--)
                    {
                        if (_labelCells[i, j].Text == string.Empty)
                        {
                            for (int k = j - 1; k >= 0; k--)
                            {
                                if (_labelCells[i, k].Text != string.Empty)
                                {
                                    _labelCells[i, j].Text = _labelCells[i, k].Text;
                                    _labelCells[i, k].Text = string.Empty;
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            if (e.KeyCode == Keys.Left)
            {
                for (int i = 0; i < _mapSize; i++)
                {
                    for (int j = 0; j < _mapSize; j++)
                    {
                        if (_labelCells[i, j].Text != string.Empty)
                        {
                            for (int k = j + 1; k < _mapSize; k++)
                            {
                                if (_labelCells[i, k].Text != string.Empty)
                                {
                                    if (_labelCells[i, j].Text == _labelCells[i, k].Text)
                                    {
                                        int number = Convert.ToInt32(_labelCells[i, j].Text) * 2;
                                        _score += number;
                                        _labelCells[i, j].Text = number.ToString();
                                        _labelCells[i, k].Text = string.Empty;
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }
                for (int i = 0; i < _mapSize; i++)
                {
                    for (int j = 0; j < _mapSize; j++)
                    {
                        if (_labelCells[i, j].Text == string.Empty)
                        {
                            for (int k = j + 1; k < _mapSize; k++)
                            {
                                if (_labelCells[i, k].Text != string.Empty)
                                {
                                    _labelCells[i, j].Text = _labelCells[i, k].Text;
                                    _labelCells[i, k].Text = string.Empty;
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            if (e.KeyCode == Keys.Up)
            {
                for (int i = 0; i < _mapSize; i++)
                {
                    for (int j = 0; j < _mapSize; j++)
                    {
                        if (_labelCells[i, j].Text != string.Empty)
                        {
                            for (int k = i + 1; k < _mapSize; k++)
                            {
                                if (_labelCells[k, j].Text != string.Empty)
                                {
                                    if (_labelCells[i, j].Text == _labelCells[k, j].Text)
                                    {
                                        int number = Convert.ToInt32(_labelCells[i, j].Text) * 2;
                                        _score += number;
                                        _labelCells[i, j].Text = number.ToString();
                                        _labelCells[k, j].Text = string.Empty;
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }

                for (int i = 0; i < _mapSize; i++)
                {
                    for (int j = 0; j < _mapSize; j++)
                    {
                        if (_labelCells[i, j].Text == string.Empty)
                        {
                            for (int k = i + 1; k < _mapSize; k++)
                            {
                                if (_labelCells[k, j].Text != string.Empty)
                                {
                                    _labelCells[i, j].Text = _labelCells[k, j].Text;
                                    _labelCells[k, j].Text = string.Empty;
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            if (e.KeyCode == Keys.Down)
            {
                for (int i = _mapSize - 1; i >= 0; i--)
                {
                    for (int j = 0; j < _mapSize; j++)
                    {
                        if (_labelCells[i, j].Text != string.Empty)
                        {
                            for (int k = i - 1; k >= 0; k--)
                            {
                                if (_labelCells[k, j].Text != string.Empty)
                                {
                                    if (_labelCells[k, j].Text == _labelCells[i, j].Text)
                                    {
                                        int number = Convert.ToInt32(_labelCells[i, j].Text) * 2;
                                        _score += number;
                                        _labelCells[i, j].Text = number.ToString();
                                        _labelCells[k, j].Text = string.Empty;
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }

                for (int i = _mapSize - 1; i >= 0; i--)
                {
                    for (int j = 0; j < _mapSize; j++)
                    {
                        if (_labelCells[i, j].Text == string.Empty)
                        {
                            for (int k = i - 1; k >= 0; k--)
                            {
                                if (_labelCells[k, j].Text != string.Empty)
                                {
                                    _labelCells[i, j].Text = _labelCells[k, j].Text;
                                    _labelCells[k, j].Text = string.Empty;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            GenerateNumber();
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void rulesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var rules = new FormRule();
            rules.ShowDialog();
        }
    }
}
