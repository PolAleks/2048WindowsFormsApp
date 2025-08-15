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
    public partial class FormMain : Form
    {
        private const int labelSize = 70;
        private const int labelPadding = 6;
        private const int marginLeft = 6;
        private const int marginUp = 70;

        private Label[,] _labelCells;
        private int _mapSize;

        private static Random rnd = new Random();
        private List<int> _emptyCells = new List<int>(); // Список пустых ячеек

        private int _bestScore = UsersScoreStorage.GetBestScore()?.Score ?? 0;
        private User _user;
        public FormMain(string name, int mapSize)
        {
            _user = new User(name);
            _mapSize = mapSize;
            InitializeComponent();
            ClientSize = new Size(marginLeft + (labelSize + labelPadding) * _mapSize, marginUp + (labelSize + labelPadding) * _mapSize);
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            InitMap();
            GenerateNumber();
        }

        private void WinGame()
        {
            UsersScoreStorage.Add(_user);

            var result = MessageBox.Show("Вы выиграли!\nПовторить", "Ура!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                Application.Restart();
            }
            Application.Exit();
        }

        private void EndGame()
        {
            UsersScoreStorage.Add(_user);

            var result = MessageBox.Show("Вы проиграли!\nПовторить", "Увы!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                Application.Restart();
            }
            Application.Exit();
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

                // Генерация чилса 2 или 4 в соотношении 75% на 25%
                var number = new int[] { 2, 2, 2, 4 }[rnd.Next(4)];

                _labelCells[rowIndex, columnIndex].BackColor = GetColor(number);
                _labelCells[rowIndex, columnIndex].Text = number.ToString();
            }
            else if (IsGameOver())
            {
                EndGame();
            }

            _bestScore = _user.Score > _bestScore ? _user.Score : _bestScore;

            ShowScore();
            ShowBestScore();
        }

        private Color GetColor(int number)
        {
            switch(number)
            {
                case 2: return Color.FromArgb(255, 165, 0);
                case 4: return Color.FromArgb(234, 151, 0);
                case 8: return Color.FromArgb(214, 138, 0);
                case 16: return Color.FromArgb(193, 125, 0);
                case 32: return Color.FromArgb(173, 112, 0);
                case 64: return Color.FromArgb(153, 99, 0);
                case 128: return Color.FromArgb(132, 85, 0);
                case 256: return Color.FromArgb(112, 72, 0);
                case 512: return Color.FromArgb(91, 59, 0);
                case 1024: return Color.FromArgb(71, 46, 0);
                case 2048: return Color.FromArgb(50, 32, 0);
                default: return Color.Orange;
            };
        }

        private bool IsGameOver()
        {
            for (int i = 0; i < _mapSize - 1; i++)
            {
                for (int j = 0; j < _mapSize - 1; j++)
                {
                    if (_labelCells[i, j].Text == _labelCells[i, j + 1].Text || _labelCells[i, j].Text == _labelCells[i + 1, j].Text)
                        return false;
                }
            }
            return true;
        }

        private void ShowScore() => labelScoreValue.Text = _user.Score.ToString();

        private void ShowBestScore() => labelBestValue.Text = _bestScore.ToString();

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
                        _labelCells[i, j].BackColor = Color.Orange;
                        int number = i * _mapSize + j;
                        list.Add(number);
                    }
                    else
                    {
                        int value = Convert.ToInt32(_labelCells[i, j].Text);
                        _labelCells[i,j].BackColor = GetColor(value);
                    }

                    if (_labelCells[i, j].Text == "2048")
                        WinGame();
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
            labelCell.BackColor = Color.Orange;
            labelCell.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
            labelCell.ForeColor = Color.White;
            labelCell.Size = new Size(labelSize, labelSize);
            labelCell.TextAlign = ContentAlignment.MiddleCenter;

            int x = marginLeft + indexColumn * (labelSize + labelPadding);
            int y = marginUp + indexRow * (labelSize + labelPadding);
            labelCell.Location = new Point(x, y);

            return labelCell;
        }

        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode != Keys.Right && e.KeyCode != Keys.Left && e.KeyCode != Keys.Up && e.KeyCode != Keys.Down) return;

            if (e.KeyCode == Keys.Right)
            {
                MoveRight();
            }

            if (e.KeyCode == Keys.Left)
            {
                MoveLeft();
            }

            if (e.KeyCode == Keys.Up)
            {
                MoveUp();
            }

            if (e.KeyCode == Keys.Down)
            {
                MoveDown();
            }
            GenerateNumber();
        }

        private void MoveDown()
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
                                    _user.Score += number;
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

        private void MoveUp()
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
                                    _user.Score += number;
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

        private void MoveLeft()
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
                                    _user.Score += number;
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

        private void MoveRight()
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
                                    _user.Score += number;
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

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UsersScoreStorage.Add(_user);
            Application.Restart();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UsersScoreStorage.Add(_user);
            Application.Exit();
        }

        private void rulesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var rules = new FormRule();
            rules.ShowDialog();
        }

        private void resultsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var results = new FormResults();
            results.ShowDialog();
        }
    }
}
