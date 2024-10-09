using IHSUniversities.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;
using System.Text.RegularExpressions;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Security.Policy;
using System.Diagnostics;

namespace IHSUniversities
{
    public partial class AdminMainForm : Form
    {
        Datab context = new Datab();

        List<University> Universities;
        List<Faculty> Faculties;
        List<Speciality> Specialities;

        List<Speciality> ListForComparison = new List<Speciality>();


        public User User = null;

        List<int> idChangedRows = new List<int>();
        List<int> newRows = new List<int>();
        List<int> delitedId = new List<int>();
        List<(int, int)> cellsWithException = new List<(int, int)>();

        DataGridViewRow previouslySelectedRow = null;
        int lastId;

        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserMainForm));

        public AdminMainForm()
        {
            InitializeComponent();
            updateDB();
        }
        public AdminMainForm(User user)
        {
            InitializeComponent();
            User = user;
            updateDB();
        }
        // Для списка ВУЗов
        private void Form1_Load(object sender, EventArgs e)
        {
            //временно
            #region временно
            #endregion

            comboBox1.SelectedIndex = 0;

            #region Добавления нужных функций

            #endregion
            dataGridView1.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridView1.ForeColor = Color.White;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.DefaultCellStyle.BackColor = Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(136)))), ((int)(((byte)(193)))));
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(136)))), ((int)(((byte)(193)))));

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(136)))), ((int)(((byte)(193)))));
            dataGridView1.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(136)))), ((int)(((byte)(193)))));

            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(193)))), ((int)(((byte)(250)))));
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;

            dataGridView1.CellValueChanged += DataGridView1_CellValueChanged;
            dataGridView1.AllowUserToAddRows = true;
            dataGridView1.MouseDown += DataGridView1_CellMouseClick;
            удалитьToolStripMenuItem.Click += ToolStripMenuItemDelete_Click;

            label2.Click += (s, args) => saveData();
            pictureBox3.Click += (s, args) => saveData();

        }


        private void updateDB()
        {
            Universities = context.Universities.ToList();
            Faculties = context.Faculties.ToList();
            Specialities = context.Specialities.ToList();
        }

        private void updateDB(string text)
        {
            int id;
            if (int.TryParse(textBox1.Text, out id))
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    List<University> unL = context.Universities.Where(un => un.Id == id).ToList();
                    if (unL.Count == 0) MessageBox.Show("Нету подходящих вариантов", "Ошибка при поиске", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else Universities = unL;
                }
                else if (comboBox1.SelectedIndex == 1)
                {
                    List<Faculty> fL = context.Faculties.Where(f => f.Id == id).ToList();
                    if (fL.Count == 0) MessageBox.Show("Нету подходящих вариантов", "Ошибка при поиске", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else Faculties = fL;
                }
                else if (comboBox1.SelectedIndex == 2)
                {
                    List<Speciality> spL = context.Specialities.Where(s => s.Id == id).ToList();
                    if (spL.Count == 0) MessageBox.Show("Нету подходящих вариантов", "Ошибка при поиске", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else Specialities = spL;
                }
            }
            else if (text.Equals("")) updateDB();
            else
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    List<University> unL = context.Universities.Where(un => un.NameU.ToLower().Contains(text.ToLower())).ToList();
                    if (unL.Count == 0) MessageBox.Show("Нету подходящих вариантов", "Ошибка при поиске", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else Universities = unL;
                }
                else if (comboBox1.SelectedIndex == 1)
                {
                    List<Faculty> fL = context.Faculties.Where(f => f.NameF.ToLower().Contains(text.ToLower())).ToList();
                    if (fL.Count == 0) MessageBox.Show("Нету подходящих вариантов", "Ошибка при поиске", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else Faculties = fL;
                }
                else if (comboBox1.SelectedIndex == 2)
                {
                    List<Speciality> spL = context.Specialities.Where(s => s.NameS.ToLower().Contains(text.ToLower())).ToList();
                    if (spL.Count == 0) MessageBox.Show("Нету подходящих вариантов", "Ошибка при поиске", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else Specialities = spL;
                }
            }
        }

        private void DataGridView1_CellMouseClick(object sender, MouseEventArgs e)
        {
            if (previouslySelectedRow != null)
            {
                previouslySelectedRow.DefaultCellStyle.BackColor = Color.FromArgb(137, 136, 193);
                previouslySelectedRow = null;
            }
            if (e.Button == MouseButtons.Right)
            {
                // Проверяем, что индекс строки корректный
                if (dataGridView1.HitTest(e.X, e.Y).RowIndex >= 0)
                {
                    // Выбираем строку, на которую был клик
                    dataGridView1.ClearSelection();

                    // Меняем цвет фона строки
                    dataGridView1.Rows[dataGridView1.HitTest(e.X, e.Y).RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(182, 193, 250);
                    previouslySelectedRow = dataGridView1.Rows[dataGridView1.HitTest(e.X, e.Y).RowIndex];

                }
            }
        }
        private void ToolStripMenuItemDelete_Click(object sender, EventArgs e)
        {
            // Удаляем выделенную строку
            if (previouslySelectedRow != null)
            {
                delitedId.Add(previouslySelectedRow.Index + 1);
                dataGridView1.Rows.Remove(previouslySelectedRow);
                previouslySelectedRow = null;
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == null || textBox1.Text == "")
            {
                updateDB();
            }
            updateDB(textBox1.Text);
            comboBox1_SelectedIndexChanged(sender, e);
        }



        private void pictureBoxPersonalArea_Click(object sender, EventArgs e)
        {
            PersonalArea pa = new PersonalArea(User);
            pa.ShowDialog();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label2.Visible = true;
            pictureBox3.Visible = true;
            loadData();
        }

        private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewCell cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];

                if (dataGridView1.Rows[e.RowIndex].Cells[0].Value == null)
                {
                    if (dataGridView1.Rows[e.RowIndex + 1].IsNewRow && !newRows.Contains(e.RowIndex))
                    {
                        newRows.Add(e.RowIndex);
                        dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.DarkRed;
                    }
                }

                ValidateAndColorCell(cell, e.RowIndex, e.ColumnIndex, comboBox1.SelectedIndex);

                if (cellsWithException.Count != 0)
                {
                    label2.Visible = false;
                    pictureBox3.Visible = false;
                }
                else
                {
                    label2.Visible = true;
                    pictureBox3.Visible = true;
                }
            }


        }

        private void ValidateAndColorCell(DataGridViewCell cell, int rowIndex, int columnIndex, int selectTable)
        {
            switch (selectTable)
            {
                case 0:
                    {
                        var row = dataGridView1.Rows[rowIndex];

                        if (string.IsNullOrWhiteSpace(cell.Value?.ToString()))
                        {
                            cell.Style.BackColor = Color.DarkRed;
                            cellsWithException.Add((rowIndex, columnIndex));
                            return;
                        }

                        var university = context.Universities.FirstOrDefault(un => un.Id == (rowIndex + 1));
                        bool repl = true;

                        if (columnIndex == 1 && university?.NameU.Equals(cell.Value) == true ||
                            columnIndex == 2 && university?.DescriptionU.Equals(cell.Value) == true ||
                            columnIndex == 3 && university?.Link.Equals(cell.Value) == true ||
                            columnIndex == 4 && university?.Photo.Equals(cell.Value) == true ||
                            columnIndex == 5 && university != null && university.Dormitory.Equals(cell.Value.ToString().Equals(cell.Value)))
                        {
                            cell.Style.BackColor = Color.FromArgb(137, 136, 193);
                            repl = false;
                        }
                        else if (columnIndex == 5)
                        {
                            if (!(cell.Value.Equals("True") || cell.Value.Equals("False")))
                            {
                                cell.Style.BackColor = Color.DarkRed;
                                cellsWithException.Add((rowIndex, columnIndex));
                                break;
                            }
                            string sfd = cell.Value.ToString();
                        }


                        if (repl) cell.Style.BackColor = Color.FromArgb(149, 183, 114);
                        idChangedRows.Add(rowIndex);
                        cellsWithException.Remove((rowIndex, columnIndex));


                        //если это новая строчка, то проверяем на все ли данные в ней корректны
                        if (newRows.Contains(rowIndex) &&
                            row.Cells[1].Style.BackColor == Color.FromArgb(149, 183, 114) &&
                            row.Cells[2].Style.BackColor == Color.FromArgb(149, 183, 114) &&
                            row.Cells[3].Style.BackColor == Color.FromArgb(149, 183, 114) &&
                            row.Cells[4].Style.BackColor == Color.FromArgb(149, 183, 114) &&
                            row.Cells[5].Style.BackColor == Color.FromArgb(149, 183, 114) &&
                            row.Cells[0].Value == null)
                        {
                            row.DefaultCellStyle.BackColor = Color.FromArgb(149, 183, 114);
                            row.Cells[0].Value = lastId + 1;
                            lastId++;
                        }

                        break;
                    }
                case 1:
                    {
                        var row = dataGridView1.Rows[rowIndex];
                        if (string.IsNullOrWhiteSpace(cell.Value?.ToString()))
                        {
                            cell.Style.BackColor = Color.DarkRed;
                            cellsWithException.Add((rowIndex, columnIndex));
                            return;
                        }

                        var faculty = context.Faculties.FirstOrDefault(un => un.Id == (rowIndex + 1));
                        bool repl = true;

                        if (columnIndex == 1 && faculty?.NameF.Equals(cell.Value) == true ||
                            columnIndex == 2 && faculty?.DescriptionF.Equals(cell.Value) == true)
                        {
                            cell.Style.BackColor = Color.FromArgb(137, 136, 193);
                        }
                        else if (columnIndex == 3)
                        {
                            int buff;
                            if (!int.TryParse(cell.Value.ToString(), out buff))
                            {
                                cell.Style.BackColor = Color.DarkRed;
                                cellsWithException.Add((rowIndex, columnIndex));
                                break;
                            }
                            if (context.Universities.FirstOrDefault(un => un.Id == buff) == null)
                            {
                                cell.Style.BackColor = Color.DarkRed;
                                cellsWithException.Add((rowIndex, columnIndex));
                                break;
                            }
                            if (faculty != null && faculty.IdU.Equals(cell.Value.ToString()))
                            {
                                cell.Style.BackColor = Color.FromArgb(137, 136, 193);
                                repl = false;
                            }
                        }

                        if (repl) cell.Style.BackColor = Color.FromArgb(149, 183, 114);
                        idChangedRows.Add(rowIndex);
                        cellsWithException.Remove((rowIndex, columnIndex));


                        //если это новая строчка, то проверяем на все ли данные в ней корректны
                        if (newRows.Contains(rowIndex) &&
                            row.Cells[1].Style.BackColor == Color.FromArgb(149, 183, 114) &&
                            row.Cells[2].Style.BackColor == Color.FromArgb(149, 183, 114) &&
                            row.Cells[3].Style.BackColor == Color.FromArgb(149, 183, 114) &&
                            row.Cells[0].Value == null)
                        {
                            row.DefaultCellStyle.BackColor = Color.FromArgb(149, 183, 114);
                            row.Cells[0].Value = lastId + 1;
                            lastId++;
                        }

                        break;
                    }
                case 2:
                    {
                        var row = dataGridView1.Rows[rowIndex];
                        bool repl = true;
                        if (string.IsNullOrWhiteSpace(cell.Value?.ToString()))
                        {
                            cell.Style.BackColor = Color.DarkRed;
                            cellsWithException.Add((rowIndex, columnIndex));
                            return;
                        }

                        var speciality = context.Specialities.FirstOrDefault(un => un.Id == (rowIndex + 1));

                        if (columnIndex == 1 && speciality?.NameS.Equals(cell.Value) == true ||
                            columnIndex == 2 && speciality?.DescriptionS.Equals(cell.Value) == true ||
                            columnIndex == 4 && speciality?.Exam1.Equals(cell.Value) == true ||
                            columnIndex == 5 && speciality?.Exam1.Equals(cell.Value) == true ||
                            columnIndex == 6 && speciality?.Exam2.Equals(cell.Value) == true)
                        {
                            cell.Style.BackColor = Color.FromArgb(137, 136, 193);
                            repl = false;
                        }
                        else if (columnIndex == 4)
                        {
                            List<string> ex = new List<string>()
                            {
                                "Не имеет значения",
                                "Русский язык",
                                "Белорусский язык"
                            };
                            if (!ex.Contains(cell.Value))
                            {
                                cell.Style.BackColor = Color.DarkRed;
                                cellsWithException.Add((rowIndex, columnIndex));
                                break;
                            }
                        }
                        else if (columnIndex == 5 || columnIndex == 6)
                        {
                            List<string> ex = new List<string>()
                            {
                                "Химия",
                                "Физика",
                                "Биология",
                                "География",
                                "Математика",
                                "Обществоведение",
                                "Иностранный язык",
                                "История Беларуси",
                                "Всемирная история",
                                "Не имеет значения"
                            };
                            if (!ex.Contains(cell.Value))
                            {
                                cell.Style.BackColor = Color.DarkRed;
                                cellsWithException.Add((rowIndex, columnIndex));
                                break;
                            }
                        }
                        else if (columnIndex == 3)
                        {
                            int buff;
                            if (!int.TryParse(cell.Value.ToString(), out buff))
                            {
                                cell.Style.BackColor = Color.DarkRed;
                                cellsWithException.Add((rowIndex, columnIndex));
                                break;
                            }
                            if (buff < 0 || buff > 400)
                            {
                                cell.Style.BackColor = Color.DarkRed;
                                cellsWithException.Add((rowIndex, columnIndex));
                                break;
                            }
                            if (speciality != null && speciality.Points.Equals(buff))
                            {
                                cell.Style.BackColor = Color.FromArgb(137, 136, 193);
                                repl = false;
                            }
                        }
                        else if (columnIndex == 7)
                        {
                            int buff;
                            if (!int.TryParse(cell.Value.ToString(), out buff))
                            {
                                cell.Style.BackColor = Color.DarkRed;
                                cellsWithException.Add((rowIndex, columnIndex));
                                break;
                            }
                            if (context.Faculties.FirstOrDefault(f => f.Id == buff) == null)
                            {
                                cell.Style.BackColor = Color.DarkRed;
                                cellsWithException.Add((rowIndex, columnIndex));
                                break;
                            }
                            if (speciality != null && speciality.IdF.Equals(cell.Value.ToString()))
                            {
                                cell.Style.BackColor = Color.FromArgb(137, 136, 193);
                                repl = false;
                            }
                        }


                        if (repl) cell.Style.BackColor = Color.FromArgb(149, 183, 114);
                        idChangedRows.Add(rowIndex);
                        cellsWithException.Remove((rowIndex, columnIndex));


                        //если это новая строчка, то проверяем на все ли данные в ней корректны
                        if (newRows.Contains(rowIndex) &&
                            row.Cells[1].Style.BackColor == Color.FromArgb(149, 183, 114) &&
                            row.Cells[2].Style.BackColor == Color.FromArgb(149, 183, 114) &&
                            row.Cells[3].Style.BackColor == Color.FromArgb(149, 183, 114) &&
                            row.Cells[4].Style.BackColor == Color.FromArgb(149, 183, 114) &&
                            row.Cells[5].Style.BackColor == Color.FromArgb(149, 183, 114) &&
                            row.Cells[5].Style.BackColor == Color.FromArgb(149, 183, 114) &&
                            row.Cells[7].Style.BackColor == Color.FromArgb(149, 183, 114) &&
                            row.Cells[0].Value == null)
                        {
                            row.DefaultCellStyle.BackColor = Color.FromArgb(149, 183, 114);
                            row.Cells[0].Value = lastId + 1;
                            lastId++;
                        }

                        break;
                    }
            }

        }






        private void loadData()
        {
            dataGridView1.Rows.Clear();
            if (comboBox1.SelectedIndex == 0)
            {
                dataGridView1.ColumnCount = 6;
                dataGridView1.Columns[0].Name = "Id";
                dataGridView1.Columns[1].Name = "Название";
                dataGridView1.Columns[2].Name = "Описание";
                dataGridView1.Columns[3].Name = "Ссылка сайта";
                dataGridView1.Columns[4].Name = "Ссылка фото";
                dataGridView1.Columns[5].Name = "Общежиие";
                foreach (University un in Universities) dataGridView1.Rows.Add(un.Id, un.NameU, un.DescriptionU, un.Link, un.Photo, un.Dormitory);
                lastId = Universities.Select(un => un.Id).ToList().Last();
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                dataGridView1.ColumnCount = 4;
                dataGridView1.Columns[0].Name = "Id";
                dataGridView1.Columns[1].Name = "Название";
                dataGridView1.Columns[2].Name = "Описание";
                dataGridView1.Columns[3].Name = "Id ВУЗа";
                foreach (Faculty f in Faculties) dataGridView1.Rows.Add(f.Id, f.NameF, f.DescriptionF, f.IdU);
                lastId = Faculties.Select(f => f.Id).ToList().Last();
            }
            else
            {
                dataGridView1.ColumnCount = 8;
                dataGridView1.Columns[0].Name = "Id";
                dataGridView1.Columns[1].Name = "Название";
                dataGridView1.Columns[2].Name = "Описание";
                dataGridView1.Columns[3].Name = "Количество баллов";
                dataGridView1.Columns[4].Name = "1 экзамен";
                dataGridView1.Columns[5].Name = "2 экзамен";
                dataGridView1.Columns[6].Name = "3 экзамен";
                dataGridView1.Columns[7].Name = "Id\nфакультета";
                foreach (Speciality s in Specialities) dataGridView1.Rows.Add(s.Id, s.NameS, s.DescriptionS, s.Points, s.Exam1, s.Exam2, s.Exam3, s.IdF);
                lastId = Specialities.Select(sp => sp.Id).ToList().Last();
            }
            dataGridView1.Columns["Id"].ReadOnly = true;
            cellsWithException.Clear();
            idChangedRows.Clear();
        }

        private void saveData()
        {
            if (cellsWithException.Count != 0)
            {
                MessageBox.Show("В некоторых срочках есть ошибки", "Ошибка при сохранении", MessageBoxButtons.OK);
                return;
            }
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    {
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if (row.IsNewRow) continue;
                            if (!idChangedRows.Contains(row.Index)) continue;

                            int id = Convert.ToInt32(row.Cells["Id"].Value);
                            if (id == 36)
                            { }
                            var un = context.Universities.FirstOrDefault(u => u.Id == id);

                            if (un != null)
                            {
                                un.NameU = row.Cells["Название"].Value?.ToString();
                                un.DescriptionU = row.Cells["Описание"].Value?.ToString();
                                un.Link = row.Cells["Ссылка сайта"].Value?.ToString();
                                un.Photo = row.Cells["Ссылка фото"].Value?.ToString();
                                un.Dormitory = Convert.ToBoolean(row.Cells["Общежиие"].Value?.ToString());
                            }
                            else
                            {
                                un = new University
                                {
                                    Id = id,
                                    NameU = row.Cells["Название"].Value?.ToString(),
                                    DescriptionU = row.Cells["Описание"].Value?.ToString(),
                                    Link = row.Cells["Ссылка сайта"].Value?.ToString(),
                                    Photo = row.Cells["Ссылка фото"].Value?.ToString(),
                                    Dormitory = Convert.ToBoolean(row.Cells["Общежиие"].Value?.ToString())
                                };
                                context.Universities.Add(un);
                            }
                        }
                        if (delitedId.Count > 0)
                        {
                            foreach (int idD in delitedId)
                            {
                                var buff = context.Universities.FirstOrDefault(un => un.Id == idD);
                                if (buff != null) context.Universities.Remove(buff);
                            }
                        }
                        delitedId.Clear();
                        context.SaveChanges();
                        break;
                    }
                case 1:
                    {
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if (row.IsNewRow) continue;
                            if (!idChangedRows.Contains(row.Index)) continue;

                            int id = Convert.ToInt32(row.Cells["Id"].Value);
                            var f = context.Faculties.FirstOrDefault(u => u.Id == id);

                            if (f != null)
                            {
                                f.NameF = row.Cells["Название"].Value?.ToString();
                                f.DescriptionF = row.Cells["Описание"].Value?.ToString();
                                f.IdU = Convert.ToInt32(row.Cells["Id ВУЗа"].Value?.ToString());
                            }
                            else
                            {
                                f = new Faculty
                                {
                                    Id = id,
                                    NameF = row.Cells["Название"].Value?.ToString(),
                                    DescriptionF = row.Cells["Описание"].Value?.ToString(),
                                    IdU = Convert.ToInt32(row.Cells["Id ВУЗа"].Value?.ToString())
                                };
                                context.Faculties.Add(f);
                            }
                        }
                        if (delitedId.Count > 0)
                        {
                            foreach (int idD in delitedId)
                            {
                                var buff = context.Faculties.FirstOrDefault(un => un.Id == idD);
                                if (buff != null) context.Faculties.Remove(buff);
                            }
                        }

                        context.SaveChanges();
                        break;
                    }
                case 2:
                    {
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if (row.IsNewRow) continue;
                            if (!idChangedRows.Contains(row.Index)) continue;

                            int id = Convert.ToInt32(row.Cells["Id"].Value);
                            var sp = context.Specialities.FirstOrDefault(s => s.Id == id);

                            if (sp != null)
                            {
                                sp.NameS = row.Cells["Название"].Value?.ToString();
                                sp.DescriptionS = row.Cells["Описание"].Value?.ToString();
                                sp.Points = Convert.ToInt32(row.Cells["Количество баллов"].Value?.ToString());
                                sp.Exam1 = row.Cells["1 экзамен"].Value?.ToString();
                                sp.Exam2 = row.Cells["2 экзамен"].Value?.ToString();
                                sp.Exam3 = row.Cells["3 экзамен"].Value?.ToString();
                                sp.IdF = Convert.ToInt32(row.Cells["Id\nфакультета"].Value?.ToString());
                            }
                            else
                            {
                                sp = new Speciality
                                {
                                    Id = id,
                                    NameS = row.Cells["Название"].Value?.ToString(),
                                    DescriptionS = row.Cells["Описание"].Value?.ToString(),
                                    Points = Convert.ToInt32(row.Cells["Количество баллов"].Value?.ToString()),
                                    Exam1 = row.Cells["1 экзамен"].Value?.ToString(),
                                    Exam2 = row.Cells["2 экзамен"].Value?.ToString(),
                                    Exam3 = row.Cells["3 экзамен"].Value?.ToString(),
                                    IdF = Convert.ToInt32(row.Cells["Id\nфакультета"].Value?.ToString())
                                };
                                context.Specialities.Add(sp);
                            }
                        }
                        if (delitedId.Count > 0)
                        {
                            foreach (int idD in delitedId)
                            {
                                var buff = context.Specialities.FirstOrDefault(un => un.Id == idD);
                                if (buff != null) context.Specialities.Remove(buff);
                            }
                        }

                        context.SaveChanges();
                        break;
                    }
            }
            MessageBox.Show("Данные успешно сохранены", "Уведомление", MessageBoxButtons.OK);
            updateDB();
            loadData();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Process.Start(@"..\..\Forms\ForAdministrator\HelpForAdmin\index.htm");
        }
    }
}










