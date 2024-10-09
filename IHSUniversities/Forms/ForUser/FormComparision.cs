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
using Microsoft.EntityFrameworkCore.Internal;

namespace IHSUniversities
{
    public partial class FormComparision : Form
    {
        User User;
        List<Speciality> ListForComparison = new List<Speciality>();

        int Y = 127;

        public FormComparision()
        {
            InitializeComponent();
        }
        public FormComparision(User user)
        {
            InitializeComponent();
            User = user;

        }
        // Для списка ВУЗов
        private void Form1_Load(object sender, EventArgs e)
        {
            panelMain.AutoScroll = false;
            panelMain.HorizontalScroll.Enabled = false;
            panelMain.HorizontalScroll.Visible = false;
            panelMain.HorizontalScroll.Maximum = 0;
            panelMain.AutoScroll = true;
            using(Datab context = new Datab())
            {
                List<int> listIdsUserSp = context.UsersSpecialitys.Where(userSp => userSp.IdUser == User.Id).Select(userSp => userSp.IdSpeciality).ToList();
                foreach (int idS in listIdsUserSp)
                {
                    ListForComparison.Add(context.Specialities.First(sp => sp.Id == idS));
                }
            }
            


            loadSpecialities();
        }

        private void loadSpecialities()
        {
            if (ListForComparison.Count == 0)
            {
                panelMain.Visible = false;
                return;
            }

            int minPoints = ListForComparison.Select(sp => sp.Points).Min(); 

            #region Список специальностей
            foreach (Speciality speciality in ListForComparison)
            {
                int maxHeight;
                labelNS = new Label()
                {
                    AutoSize = true,
                    Font = new System.Drawing.Font("MS Reference Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204))),
                    BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(88)))), ((int)(((byte)(130))))),
                    ForeColor = System.Drawing.Color.White,
                    Location = new System.Drawing.Point(442, Y),
                    Text = transfer(speciality.NameS, 25)
                };
                panelMain.Controls.Add(labelNS);
                maxHeight = labelNS.Height;

                labelP = new Label()
                {
                    AutoSize = true,
                    Font = new System.Drawing.Font("MS Reference Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204))),
                    BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(88)))), ((int)(((byte)(130))))),
                    ForeColor = System.Drawing.Color.White,
                    Location = new System.Drawing.Point(921, Y),
                    Text = speciality.Points.ToString()
                };
                if (speciality.Points == minPoints) labelP.ForeColor = Color.LightGreen;
                panelMain.Controls.Add(labelP);
                labelP.Location = new Point(1037 - labelP.Width / 2, Y);

                labelEx1 = new Label()
                {
                    AutoSize = true,
                    Font = new System.Drawing.Font("MS Reference Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204))),
                    BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(88)))), ((int)(((byte)(130))))),
                    ForeColor = System.Drawing.Color.White,
                    TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                    Location = new System.Drawing.Point(1165, Y),
                    Text = transfer(speciality.Exam1, 11)
                };
                panelMain.Controls.Add(labelEx1);
                labelEx1.Location = new Point(1255 - labelEx1.Width / 2, Y);

                if (maxHeight < labelEx1.Height) maxHeight = labelEx1.Height;
                labelEx2 = new Label()
                {
                    AutoSize = true,
                    Font = new System.Drawing.Font("MS Reference Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204))),
                    BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(88)))), ((int)(((byte)(130))))),
                    ForeColor = System.Drawing.Color.White,
                    TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                    Location = new System.Drawing.Point(1402, Y),
                    Text = transfer(speciality.Exam2, 11)
                };
                panelMain.Controls.Add(labelEx2);
                labelEx2.Location = new Point(1495 - labelEx2.Width / 2, Y);
                if (maxHeight < labelEx2.Height) maxHeight = labelEx2.Height;

                labelEx3 = new Label()
                {
                    AutoSize = true,
                    Font = new System.Drawing.Font("MS Reference Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204))),
                    BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(88)))), ((int)(((byte)(130))))),
                    ForeColor = System.Drawing.Color.White,
                    TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                    Location = new System.Drawing.Point(1652, Y),
                    Text = transfer(speciality.Exam3, 11)
                };
                panelMain.Controls.Add(labelEx3);
                labelEx3.Location = new Point(1745 - labelEx3.Width / 2, Y);
                if (maxHeight < labelEx3.Height) maxHeight = labelEx3.Height;

                int idU = (new Datab()).Faculties.First(f => f.Id == speciality.IdF).IdU;
                University un = (new Datab()).Universities.First(u => u.Id == idU);
                labelD = new Label()
                {
                    AutoSize = true,
                    Font = new System.Drawing.Font("MS Reference Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204))),
                    BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(88)))), ((int)(((byte)(130))))),
                    ForeColor = System.Drawing.Color.White,
                    Location = new System.Drawing.Point(1938, Y),
                    Text = un.Dormitory ? "Есть" : "Нету"
                };
                panelMain.Controls.Add(labelD);

                labelUn = new Label()
                {
                    AutoSize = true,
                    BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(88)))), ((int)(((byte)(130))))),
                    Font = new System.Drawing.Font("MS Reference Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204))),
                    ForeColor = System.Drawing.Color.White,
                    Location = new System.Drawing.Point(26, Y),
                    Text = transfer(un.NameU, 20)
                };
                panelMain.Controls.Add(labelUn);
                if (maxHeight < labelUn.Height) maxHeight = labelUn.Height;

                pictureBox3 = new PictureBox()
                {
                    BackColor = System.Drawing.Color.Gray,
                    Size = new System.Drawing.Size(2131, 2),
                    Location = new System.Drawing.Point(3, Y + maxHeight + 30)
                };
                panelMain.Controls.Add(pictureBox3);



                Y = pictureBox3.Location.Y + 30;
                
            #endregion

            };
        }


        public static string transfer(string buff, int l = 55)
        {
            StringBuilder result = new StringBuilder();
            string[] words = buff.Split(' ');
            int remainingLength = l;

            foreach (string word in words)
            {
                if (word.Length <= remainingLength)
                {
                    result.Append(word);
                    remainingLength -= word.Length;

                    // Проверка, можем ли добавить следующий пробел
                    if (remainingLength > 0)
                    {
                        result.Append(" ");
                        remainingLength--;
                    }
                }
                else
                {
                    // Если слово больше лимита, разбиваем его на части
                    if (word.Length > l)
                    {
                        string buufWord = word;
                        while (buufWord.Length > l)
                        {
                            result.Append(buufWord.Substring(0, l));
                            result.Append("\n");
                            buufWord = buufWord.Substring(l);
                        }

                        result.Append(buufWord);
                        remainingLength = l - buufWord.Length - 1;

                        if (remainingLength > 0)
                        {
                            result.Append(" ");
                        }
                    }
                    else
                    {
                        // Если слово не помещается в оставшееся пространство, начинаем новую строку
                        result.Append("\n");
                        result.Append(word);
                        remainingLength = l - word.Length - 1;

                        if (remainingLength > 0)
                        {
                            result.Append(" ");
                        }
                    }
                }
            }

            // Убираем лишний пробел в конце строки, если он есть
            return result.ToString().TrimEnd();
        }

    }
}










