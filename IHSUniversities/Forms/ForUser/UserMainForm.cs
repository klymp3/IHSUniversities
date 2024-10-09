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
using IronWord;
using IronWord.Models;
using SixLabors.Fonts;
using SixLabors.ImageSharp.Processing;
using System.Net.Http;
using System.Collections;
using System.Diagnostics;

namespace IHSUniversities
{
    public partial class UserMainForm : System.Windows.Forms.Form
    {
        Datab context = new Datab();

        List<University> Universities;
        List<Faculty> Faculties;
        List<Speciality> Specialities;
        Dictionary<int, System.Drawing.Image> images = new Dictionary<int, System.Drawing.Image>();
        List<int> ListForComparison;


        public User User = null;

        int YForU = 54;
        int scrolV = 0;
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserMainForm));

        public UserMainForm()
        {
            InitializeComponent();
            updateDB();
        }
        public UserMainForm(User user)
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
            panelFUniversity.Location = new Point(-3, -5);
            panelForF.Location = new Point(-3, -5);
            panelForS.Location = new Point(-3, -5);
            pictureBoxBuffF.Cursor = System.Windows.Forms.Cursors.Default;
            pictureBoxBuffS.Cursor = System.Windows.Forms.Cursors.Default;
            pictureBoxBuffDormitory.Cursor = System.Windows.Forms.Cursors.Default;
            pictureBoxBuffEx.Cursor = System.Windows.Forms.Cursors.Default;
            panel3.Visible = false;
            #endregion


            #region Добавления нужных функций
            labelNav.MouseMove += (s, args) => labelNav_MouseMove(labelNav);
            labelNav.MouseLeave += (s, args) => labelNav_MouseLeave(labelNav);
            labelNavU.MouseMove += (s, args) => labelNav_MouseMove(labelNavU);
            labelNavU.MouseLeave += (s, args) => labelNav_MouseLeave(labelNavU);
            labelNav2.MouseMove += (s, args) => labelNav_MouseMove(labelNav2);
            labelNav2.MouseLeave += (s, args) => labelNav_MouseLeave(labelNav2);
            labelNavU2.MouseMove += (s, args) => labelNav_MouseMove(labelNavU2);
            labelNavU2.MouseLeave += (s, args) => labelNav_MouseLeave(labelNavU2);
            labelNavF2.MouseMove += (s, args) => labelNav_MouseMove(labelNavF2);
            labelNavF2.MouseLeave += (s, args) => labelNav_MouseLeave(labelNavF2);
            labelNav3.MouseMove += (s, args) => labelNav_MouseMove(labelNav3);
            labelNav3.MouseLeave += (s, args) => labelNav_MouseLeave(labelNav3);
            labelNavU3.MouseMove += (s, args) => labelNav_MouseMove(labelNavU3);
            labelNavU3.MouseLeave += (s, args) => labelNav_MouseLeave(labelNavU3);
            labelNavF3.MouseMove += (s, args) => labelNav_MouseMove(labelNavF3);
            labelNavF3.MouseLeave += (s, args) => labelNav_MouseLeave(labelNavF3);
            labelNavS3.MouseMove += (s, args) => labelNav_MouseMove(labelNavS3);
            labelNavS3.MouseLeave += (s, args) => labelNav_MouseLeave(labelNavS3);

            #endregion

            if (User == null)
            {
                pictureBoxPersonalArea.Visible = false;
                textBox1.Size = new System.Drawing.Size(1274, 33);
                pictureBox1.Size = new System.Drawing.Size(1376, 69);
                pictureBoxSearch.Location = new System.Drawing.Point(1354, 40);
                pictureBoxReferenceSystem.Location = new System.Drawing.Point(1514, 25);
            }

            updatePanelUnList();
            
        }


        // Для окна ВУЗа
        private void cardUn_Click(int id)
        {
            University un = context.Universities.Find(id);
            #region Очистка панели + скрол картинки

            panelFUniversity.Controls.Clear();
            panelFUniversity.AutoScroll = false;
            panelFUniversity.HorizontalScroll.Enabled = false;
            panelFUniversity.HorizontalScroll.Visible = false;
            panelFUniversity.HorizontalScroll.Maximum = 0;
            panelFUniversity.AutoScroll = true;
            pictureBoxForUnP.Visible = true;
            labelNav.Location = new System.Drawing.Point(43, 30);
            panelFUniversity.Controls.Add(labelNav);
            labelNavU.Location = new System.Drawing.Point(320, 30);

            panelFUniversity.Controls.Add(labelNavU);
            panel3.Visible = true;

            #endregion

            {

                labelNameUn = new Label();
                labelNameUn.AutoSize = true;
                labelNameUn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(117)))), ((int)(((byte)(159)))));
                labelNameUn.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                labelNameUn.ForeColor = System.Drawing.Color.White;
                labelNameUn.Text = transfer(un.NameU, 35);
                labelNameUn.Location = new System.Drawing.Point(40, 89);
                labelNameUn.MouseMove += labelNameUn_MouseMove;
                labelNameUn.MouseLeave += labelNameUn_MouseLeave;
                labelNameUn.Click += (s, args) => System.Diagnostics.Process.Start(un.Link);
                panelFUniversity.Controls.Add(labelNameUn);

                labelDescriptionUn.Location = new Point(labelDescriptionUn.Location.X, labelNameUn.Location.Y + labelNameUn.Height + 30);
                labelDescriptionUn.Text = transfer(un.DescriptionU, 35);
                panelFUniversity.Controls.Add(labelDescriptionUn);


                pictureBoxBuffDormitory.Location = new Point(pictureBoxBuffDormitory.Location.X, labelDescriptionUn.Location.Y + labelDescriptionUn.Size.Height + 60);
                labelBuffDormitory.Location = new Point(pictureBoxBuffDormitory.Location.X + 16, pictureBoxBuffDormitory.Location.Y + 12);
                if (un.Dormitory) labelBuffDormitory.Text = "Общежитие предоставляется ";
                else labelBuffDormitory.Text = "Общежитие не предоставляется ";

                panelFUniversity.Controls.Add(labelBuffDormitory);
                panelFUniversity.Controls.Add(pictureBoxBuffDormitory);


                #region Список Факультетов
                pictureBoxBuffF.Location = new Point(pictureBoxBuffF.Location.X, pictureBoxBuffDormitory.Location.Y + pictureBoxBuffDormitory.Size.Height + 30);
                panelFUniversity.Controls.Add(labelBuffF);
                panelFUniversity.Controls.Add(pictureBoxBuffF);

                labelBuffF.Location = new Point(pictureBoxBuffF.Location.X + 16, pictureBoxBuffF.Location.Y + 12);

                int YForF = pictureBoxBuffF.Location.Y + 100;

                foreach (var control in panelFUniversity.Controls.OfType<Control>().Where(c => c.Name.Equals("f")).ToList())
                {
                    panelFUniversity.Controls.Remove(control);
                    control.Dispose();
                }
                panelFUniversity.Invalidate();

                if (Faculties.Where(f => f.IdU == id).Count() > 0)
                {
                    foreach (Faculty faculty in Faculties.Where(f => f.IdU == id))
                    {
                        labelForFIt = new Label()
                        {
                            AutoSize = true,
                            BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(107)))), ((int)(((byte)(158))))),
                            Font = new System.Drawing.Font("MS Reference Sans Serif", 9.900001F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204))),
                            ForeColor = System.Drawing.Color.White,
                            Name = "f"
                        };
                        labelForFIt.Click += (s, args) => cardF_Click(faculty.Id);

                        labelForFIt.Text = transfer(faculty.NameF, 25);
                        panelFUniversity.Controls.Add(labelForFIt);

                        pictureBoxForFIt = new PictureBox()
                        {
                            Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxForFIt.Image"))),
                            BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(117)))), ((int)(((byte)(159))))),
                            SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage,
                            Location = new Point(pictureBoxBuffF.Location.X + 30, YForF),
                            Name = "f",
                            Size = new Size(822, labelForFIt.Height + 50)
                        };

                        pictureBoxForFIt.Click += (s, args) => cardF_Click(faculty.Id);

                        labelForFIt.Location = new Point(pictureBoxForFIt.Location.X + 16, pictureBoxForFIt.Location.Y + 17);

                        panelFUniversity.Invalidate();
                        panelFUniversity.Controls.Add(pictureBoxForFIt);
                        YForF += pictureBoxForFIt.Size.Height + 20;
                    }

                    //для экспорта
                    YForF += 30;
                    pictureBoxForFIt = new PictureBox()
                    {
                        BackColor = System.Drawing.Color.FromArgb(125, 117, 159),
                        Image = global::IHSUniversities.Properties.Resources.Comparison,
                        Size = new System.Drawing.Size(850, 77),
                        SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage,
                        Name = "f",
                        Location = new Point(38, YForF + 20)
                    };
                    labelForFIt = new Label()
                    {
                        AutoSize = true,
                        BackColor = System.Drawing.Color.FromArgb(144, 106, 174),
                        Font = new System.Drawing.Font("MS Reference Sans Serif", 9.900001F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204))),
                        ForeColor = System.Drawing.Color.White,
                        Location = new Point(pictureBoxForFIt.Location.X + 16, pictureBoxForFIt.Location.Y + 12),
                        Name = "f",
                        Text = "Экспортировать данные в Word"
                    };
                    pictureBoxForFIt.Click += (s, args) => exportToWord(universities: new List<University>() { un });
                    labelForFIt.Click += (s, args) => exportToWord(universities: new List<University>() { un });
                    panelFUniversity.Controls.Add(labelForFIt);
                    panelFUniversity.Controls.Add(pictureBoxForFIt);


                }
                else
                {
                    labelForFIt = new Label()
                    {
                        AutoSize = true,
                        BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(107)))), ((int)(((byte)(158))))),
                        Font = new System.Drawing.Font("MS Reference Sans Serif", 9.900001F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204))),
                        ForeColor = System.Drawing.Color.White,
                        Name = "f",
                        Text = "Факультеты не найдены",
                    };

                    pictureBoxForFIt = new PictureBox()
                    {
                        Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxForFIt.Image"))),
                        BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(117)))), ((int)(((byte)(159))))),
                        SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage,
                        Location = new Point(pictureBoxBuffF.Location.X + 12, YForF),
                        Name = "f",
                        Size = new Size(822, labelForFIt.Height + 50)
                    };
                    labelForFIt.Location = new Point(pictureBoxForFIt.Location.X + 16, pictureBoxForFIt.Location.Y + 12);
                    panelFUniversity.Controls.Add(labelForFIt);
                    panelFUniversity.Controls.Add(pictureBoxForFIt);
                }
                #endregion
            }


            panelFUniversity.Visible = true;
            panelFUniversity.Update();

            new Thread(new ThreadStart(() =>
            {


                if (!images.ContainsKey(un.Id))
                {
                    System.Drawing.Image image = DownloadImage(un.Photo);
                    if (image == null) image = global::IHSUniversities.Properties.Resources.photo__1_;
                    if (panelForF.Visible || panelForS.Visible || panelFUniversity.Visible) images.Add(un.Id, image);
                }
                pictureBoxForUnP.BackgroundImage = images[un.Id];

            })).Start();
        }

        //для Факультета
        private void cardF_Click(int id)
        {
            #region Очистка панели + скрол картинки
            panelForF.Controls.Clear();
            panelForF.AutoScroll = false;
            panelForF.HorizontalScroll.Enabled = false;
            panelForF.HorizontalScroll.Visible = false;
            panelForF.HorizontalScroll.Maximum = 0;
            panelForF.AutoScroll = true;

            labelNav2.Location = new System.Drawing.Point(43, 30);
            panelForF.Controls.Add(labelNav2);
            labelNavU2.Location = new System.Drawing.Point(320, 30);
            panelForF.Controls.Add(labelNavU2);
            labelNavF2.Location = new System.Drawing.Point(432, 30);
            panelForF.Controls.Add(labelNavF2);
            #endregion


            {
                Faculty faculty = context.Faculties.Find(id);
                labelNameF.Text = transfer(faculty.NameF, 35);
                labelNameF.Location = new System.Drawing.Point(40, 89);
                panelForF.Controls.Add(labelNameF);

                labelDescriptionF.Location = new Point(labelDescriptionF.Location.X, labelNameF.Location.Y + labelNameF.Height + 30);
                labelDescriptionF.Text = transfer(faculty.DescriptionF, 35);
                panelForF.Controls.Add(labelDescriptionF);


                labelNav2.Click += label1_Click;
                labelNavU2.Click += labelNavU2_Click;

                #region Список Специальностей
                pictureBoxBuffS.Location = new Point(pictureBoxBuffS.Location.X, labelDescriptionF.Location.Y + labelDescriptionF.Size.Height + 60);
                panelForF.Controls.Add(labelBuffS);
                panelForF.Controls.Add(pictureBoxBuffS);
                labelBuffS.Location = new Point(pictureBoxBuffS.Location.X + 16, pictureBoxBuffS.Location.Y + 12);



                int YForF = pictureBoxBuffS.Location.Y + 100;

                foreach (var control in panelForF.Controls.OfType<Control>().Where(c => c.Name.Equals("s")).ToList())
                {
                    panelForF.Controls.Remove(control);
                    control.Dispose();
                }
                panelForF.Invalidate();

                if (Specialities.Where(spec => spec.IdF == faculty.Id).Count() > 0)
                {
                    foreach (Speciality speciality in Specialities.Where(spec => spec.IdF == faculty.Id))
                    {
                        labelForSIt = new Label()
                        {
                            AutoSize = true,
                            BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(107)))), ((int)(((byte)(158))))),
                            Font = new System.Drawing.Font("MS Reference Sans Serif", 9.900001F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204))),
                            ForeColor = System.Drawing.Color.White,
                            Name = "s"
                        };

                        labelForSIt.Text = transfer(speciality.NameS, 35);
                        labelForSIt.Click += (s, args) => cardS_Click(speciality.Id);
                        panelForF.Controls.Add(labelForSIt);

                        pictureBoxForSIt = new PictureBox()
                        {
                            Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxForFIt.Image"))),
                            BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(117)))), ((int)(((byte)(159))))),
                            SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage,
                            Location = new Point(pictureBoxBuffS.Location.X + 30, YForF),
                            Name = "s",
                            Size = new Size(822, labelForSIt.Height + 50)
                        };
                        pictureBoxForSIt.Click += (s, args) => cardS_Click(speciality.Id);


                        labelForSIt.Location = new Point(pictureBoxForSIt.Location.X + 16, pictureBoxForSIt.Location.Y + 17);

                        panelForF.Invalidate();
                        panelForF.Controls.Add(pictureBoxForSIt);
                        YForF += pictureBoxForSIt.Size.Height + 20;
                    }

                    //для экспорта
                    YForF += 30;
                    pictureBoxForSIt = new PictureBox()
                    {
                        BackColor = System.Drawing.Color.FromArgb(125, 117, 159),
                        Image = global::IHSUniversities.Properties.Resources.Comparison,
                        Size = new System.Drawing.Size(850, 77),
                        SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage,
                        Name = "s",
                        Location = new Point(38, YForF + 20)
                    };
                    labelForSIt = new Label()
                    {
                        AutoSize = true,
                        BackColor = System.Drawing.Color.FromArgb(144, 106, 174),
                        Font = new System.Drawing.Font("MS Reference Sans Serif", 9.900001F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204))),
                        ForeColor = System.Drawing.Color.White,
                        Location = new Point(pictureBoxForSIt.Location.X + 16, pictureBoxForSIt.Location.Y + 12),
                        Name = "s",
                        Text = "Экспортировать данные в Word"
                    };
                    pictureBoxForSIt.Click += (s, args) => exportToWord(faculties: new List<Faculty>() { faculty });
                    labelForSIt.Click += (s, args) => exportToWord(faculties: new List<Faculty>() { faculty });
                    panelForF.Controls.Add(labelForSIt);
                    panelForF.Controls.Add(pictureBoxForSIt);
                }
                else
                {
                    labelForSIt = new Label()
                    {
                        AutoSize = true,
                        BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(107)))), ((int)(((byte)(158))))),
                        Font = new System.Drawing.Font("MS Reference Sans Serif", 9.900001F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204))),
                        ForeColor = System.Drawing.Color.White,
                        Name = "s",
                        Text = "Специальности не найдены",
                    };

                    pictureBoxForSIt = new PictureBox()
                    {
                        Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxForFIt.Image"))),
                        BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(117)))), ((int)(((byte)(159))))),
                        SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage,
                        Location = new Point(pictureBoxBuffS.Location.X + 12, YForF),
                        Name = "s",
                        Size = new Size(822, labelForSIt.Height + 50)
                    };
                    labelForSIt.Location = new Point(pictureBoxForSIt.Location.X + 16, pictureBoxForSIt.Location.Y + 12);
                    panelForF.Controls.Add(labelForSIt);
                    panelForF.Controls.Add(pictureBoxForSIt);
                }
                #endregion
            }


            panelForF.Visible = true;
            panelForF.Update();
            panelFUniversity.Visible = false;
        }

        //для Специальности
        private void cardS_Click(int id)
        {
            #region Очистка панели + скрол картинки
            panelForS.Controls.Clear();
            panelForS.AutoScroll = false;
            panelForS.HorizontalScroll.Enabled = false;
            panelForS.HorizontalScroll.Visible = false;
            panelForS.HorizontalScroll.Maximum = 0;
            panelForS.AutoScroll = true;

            labelNav3.Location = new System.Drawing.Point(43, 30);
            panelForS.Controls.Add(labelNav3);
            labelNavU3.Location = new System.Drawing.Point(320, 30);
            panelForS.Controls.Add(labelNavU3);
            labelNavF3.Location = new System.Drawing.Point(432, 30);
            panelForS.Controls.Add(labelNavF3);
            labelNavS3.Location = new System.Drawing.Point(653, 30);
            panelForS.Controls.Add(labelNavS3);
            #endregion


            {
                Speciality speciality = context.Specialities.Find(id);
                labelNameS.Text = transfer(speciality.NameS, 35);
                labelNameS.Location = new System.Drawing.Point(40, 89);
                panelForS.Controls.Add(labelNameS);

                labelDescriptionS.Location = new Point(labelDescriptionS.Location.X, labelNameS.Location.Y + labelNameS.Height + 30);
                labelDescriptionS.Text = transfer(speciality.DescriptionS, 35);
                panelForS.Controls.Add(labelDescriptionS);


                labelNav3.Click += label1_Click;
                labelNavU3.Click += labelNavU2_Click;
                labelNavF3.Click += labelNavF3_Click;


                pictureBoxBuffPoint = new PictureBox()
                {
                    BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(117)))), ((int)(((byte)(159))))),
                    Image = global::IHSUniversities.Properties.Resources.Buff,
                    Size = new System.Drawing.Size(850, 75),
                    SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage,
                    Location = new Point(38, labelDescriptionS.Location.Y + labelDescriptionS.Size.Height + 60),
                };
                labelBuffPoint = new Label()
                {
                    AutoSize = true,
                    BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(88)))), ((int)(((byte)(130))))),
                    Font = new System.Drawing.Font("MS Reference Sans Serif", 9.900001F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204))),
                    ForeColor = System.Drawing.Color.White,
                    Location = new Point(pictureBoxBuffPoint.Location.X + 16, pictureBoxBuffPoint.Location.Y + 12),
                    Text = "Количество баллов: " + speciality.Points
                };
                panelForS.Controls.Add(labelBuffPoint);
                panelForS.Controls.Add(pictureBoxBuffPoint);


                #region Список Экзаменов
                pictureBoxBuffEx.Location = new Point(38, pictureBoxBuffPoint.Location.Y + pictureBoxBuffPoint.Size.Height + 30);
                panelForS.Controls.Add(labelBuffEx);
                panelForS.Controls.Add(pictureBoxBuffEx);
                labelBuffEx.Location = new Point(pictureBoxBuffEx.Location.X + 16, pictureBoxBuffEx.Location.Y + 12);


                int YForS = pictureBoxBuffEx.Location.Y + 100;

                foreach (var control in panelForF.Controls.OfType<Control>().Where(c => c.Name.Equals("ex")).ToList())
                {
                    panelForF.Controls.Remove(control);
                    control.Dispose();
                }
                panelForF.Invalidate();



                foreach (string ex in new string[] { (new System.Text.RegularExpressions.Regex("Не имеет значения").IsMatch(speciality.Exam1) ? "Русский/Белорусский язык" : speciality.Exam1), speciality.Exam2, speciality.Exam3})
                {
                    labelForExIt = new Label()
                    {
                        AutoSize = true,
                        BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(107)))), ((int)(((byte)(158))))),
                        Font = new System.Drawing.Font("MS Reference Sans Serif", 9.900001F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204))),
                        ForeColor = System.Drawing.Color.White,
                        Name = "ex"
                    };

                    labelForExIt.Text = transfer(ex, 25);
                    panelForS.Controls.Add(labelForExIt);

                    pictureBoxForExIt = new PictureBox()
                    {
                        Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxForFIt.Image"))),
                        BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(117)))), ((int)(((byte)(159))))),
                        SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage,
                        Location = new Point(pictureBoxBuffEx.Location.X + 30, YForS),
                        Name = "ex",
                        Size = new Size(822, labelForExIt.Height + 50)
                    };


                    labelForExIt.Location = new Point(pictureBoxForExIt.Location.X + 16, pictureBoxForExIt.Location.Y + 17);

                    panelForS.Invalidate();
                    panelForS.Controls.Add(pictureBoxForExIt);
                    YForS += pictureBoxForExIt.Size.Height + 20;
                }

                #endregion
                
                //для сравнеия
                if (User != null)
                {
                    pictureBoxBuffPoint = new PictureBox()
                    {
                        BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(117)))), ((int)(((byte)(159))))),
                        Image = global::IHSUniversities.Properties.Resources.Comparison,
                        Size = new System.Drawing.Size(850, 77),
                        SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage,
                        Location = new Point(38, YForS + 20)
                    };
                    labelBuffPoint = new Label()
                    {
                        AutoSize = true,
                        BackColor = System.Drawing.Color.FromArgb(144, 106, 174),
                        Font = new System.Drawing.Font("MS Reference Sans Serif", 9.900001F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204))),
                        ForeColor = System.Drawing.Color.White,
                        Location = new Point(pictureBoxBuffPoint.Location.X + 16, pictureBoxBuffPoint.Location.Y + 12)
                    };
                    pictureBoxBuffPoint.Click += (s, args) => checkSpeciality(speciality.Id);
                    labelBuffPoint.Click += (s, args) => checkSpeciality(speciality.Id);
                    if (!ListForComparison.Contains(speciality.Id)) labelBuffPoint.Text = "Добавить в сравение";
                    else labelBuffPoint.Text = "Убрать из сравения";

                    panelForS.Controls.Add(labelBuffPoint);
                    panelForS.Controls.Add(pictureBoxBuffPoint);
                    YForS = pictureBoxBuffPoint.Location.Y + 100;
                }

                //для экспорта
                YForS += 30;
                pictureBoxBuffPoint = new PictureBox()
                {
                    BackColor = System.Drawing.Color.FromArgb(125, 117, 159),
                    Image = global::IHSUniversities.Properties.Resources.Comparison,
                    Size = new System.Drawing.Size(850, 77),
                    SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage,
                    Location = new Point(38, YForS + 20)
                };
                labelBuffPoint = new Label()
                {
                    AutoSize = true,
                    BackColor = System.Drawing.Color.FromArgb(144, 106, 174),
                    Font = new System.Drawing.Font("MS Reference Sans Serif", 9.900001F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204))),
                    ForeColor = System.Drawing.Color.White,
                    Location = new Point(pictureBoxBuffPoint.Location.X + 16, pictureBoxBuffPoint.Location.Y + 12),
                    Text = "Экспортировать данные в Word"
                };
                pictureBoxBuffPoint.Click += (s, args) => exportToWord(specialities: new List<Speciality>() { speciality});
                labelBuffPoint.Click += (s, args) => exportToWord(specialities: new List<Speciality>() { speciality });
                panelForS.Controls.Add(labelBuffPoint);
                panelForS.Controls.Add(pictureBoxBuffPoint);
                


            }


            panelForS.Visible = true;
            panelFUniversity.Visible = false;
            panelForF.Visible = false;
            panelForS.Update();

        }






        // Для переноса текста
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

        private void label1_Click(object sender, EventArgs e)
        { 
            panelFUniversity.Visible = false;
            panelForF.Visible = false;
            panelForS.Visible = false;
            panel3.Visible = false;
            panelFUniversity.Update();
            panelForF.Update();
        }

        private void labelNavU2_Click(object sender, EventArgs e)
        {
            panelFUniversity.Visible = true;
            panelForF.Visible = false;
            panelForF.Update();
        }

        private void labelNavF3_Click(object sender, EventArgs e)
        {
            panelFUniversity.Visible = false;
            panelForF.Visible = true;
            panelForS.Visible = false;
            panelForS.Update();
        }

        private void pictureBoxForFIt_Click(object sender, EventArgs e)
        {
            panelForF.Visible = true;
        }




        private void labelNav_MouseMove(Control con) => con.ForeColor = System.Drawing.Color.White;
        private void labelNav_MouseLeave(Control con) => con.ForeColor = System.Drawing.Color.Gainsboro;

        private void labelNameUn_MouseMove(object sender, EventArgs e) => labelNameUn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(195)))), ((int)(((byte)(245)))));
        private void labelNameUn_MouseLeave(object sender, EventArgs e) => labelNameUn.ForeColor = System.Drawing.Color.White;

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBoxPoints.Text = "";
            textBoxPoints.ForeColor = Color.White;
            textBoxPoints.Click -= textBox2_TextChanged;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (panelFilters.Location == new Point(-440, -26)) { panelFilters.Location = new Point(0, -26);}
            else { panelFilters.Location = new Point(-440, -26); }
        }
        private void pictureBox2_Close(object sender, EventArgs e) => panelFilters.Location = new Point(-440, -26);
        

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            int points;

            #region Проверки
            if (textBoxPoints.Text.Equals("400  ") || !int.TryParse(textBoxPoints.Text, out points))
            {
                MessageBox.Show("Вы не ввели количество баллов\nнужных для поступления!", "Недопустимое значение баллов", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (!(points >= 0 && points <= 400))
            {
                MessageBox.Show("Количество баллов может быть\nтолько от 0 до 400!", "Недопустимое значение баллов", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (comboBox1.SelectedIndex == -1 || comboBox2.SelectedIndex == -1 || comboBox3.SelectedIndex == -1)
            {
                MessageBox.Show("Вы не выбрали предметы\nдля ЦЭ!", "Недопустимое значение предметов", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (comboBox2.SelectedIndex == comboBox3.SelectedIndex && comboBox3.SelectedIndex != 9)
            {
                MessageBox.Show("Предметы для ЦЭ не могут\nповторяться!", "Недопустимое значение предметов", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            #endregion
            
            updateDB(points, radioButton1.Checked, comboBox1.SelectedItem.ToString(), comboBox2.SelectedItem.ToString(), comboBox3.SelectedItem.ToString());
            pictureBox2_Click(sender, e);
            updatePanelUnList();
        }

        private void updateDB()
        {
            Universities = context.Universities.ToList();
            Faculties = context.Faculties.ToList();
            Specialities = context.Specialities.ToList();
            if(User != null) ListForComparison = context.UsersSpecialitys.Where(userSp => userSp.IdUser == User.Id).Select(userSp => userSp.IdSpeciality).ToList();
        }
        private void updateDB(int points, bool dorm, string ex1, string ex2, string ex3)
        {
            if(dorm) Universities = context.Universities.Where(un => un.Dormitory).ToList();
            else Universities = context.Universities.ToList();
            Faculties = context.Faculties.Where(f => Universities.Select(un => un.Id).Contains(f.IdU)).ToList();

            Specialities = context.Specialities.Where(sp => sp.Points <= points && Faculties.Select(f => f.Id).Contains(sp.IdF)).ToList();
            if(!ex1.Equals("Не имеет значения")) Specialities = Specialities.Where(
                sp => sp.Exam1.Equals("Не имеет значения") ? true : sp.Exam1.Equals(ex1)).ToList();
            if(!ex2.Equals("Не имеет значения")) Specialities = Specialities.Where(
                sp => sp.Exam2.Equals("Не имеет значения") ? true : sp.Exam2.Equals(ex2) || sp.Exam3.Equals(ex2)).ToList();
            if(!ex3.Equals("Не имеет значения")) Specialities = Specialities.Where(
                sp => sp.Exam2.Equals("Не имеет значения") ? true : sp.Exam2.Equals(ex3) || sp.Exam3.Equals(ex3)).ToList();

            List<int> idFInS = Specialities.Select(sp => sp.IdF).ToList();
            Faculties = Faculties.Where(f => idFInS.Contains(f.Id)).ToList();

            List<int> idUnInF = Faculties.Select(sp => sp.IdU).ToList();
            Universities = Universities.Where(un => idUnInF.Contains(un.Id)).ToList();
        }
        private void updateDB(string text)
        {
            Universities = context.Universities.Where(un => un.NameU.ToLower().Contains(text.ToLower())).ToList();
            List<int> idU = Universities.Select(un => un.Id).ToList();

            Faculties = context.Faculties.Where(f => idU.Contains(f.IdU)).ToList();
            List<int> idF = Faculties.Select(f => f.Id).ToList();

            Specialities = context.Specialities.Where(sp => idF.Contains(sp.IdF)).ToList();
        }


        private void updatePanelUnList()
        {

            YForU = 54;
            panelUnList.Controls.Clear();

            if (Universities.Count() == 0) {
                cardUn = new PictureBox();
                cardUn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(88)))), ((int)(((byte)(130)))));
                cardUn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                cardUn.Image = global::IHSUniversities.Properties.Resources.Rectangle_18;
                cardUn.Location = new System.Drawing.Point(31, YForU);
                cardUn.Size = new System.Drawing.Size(1387, 105);

                labelForNameU = new Label();
                labelForNameU.AutoSize = true;
                labelForNameU.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(117)))), ((int)(((byte)(159)))));
                labelForNameU.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                labelForNameU.ForeColor = System.Drawing.Color.White;
                labelForNameU.Location = new System.Drawing.Point(30, 50 - (labelForNameU.Height));
                labelForNameU.Size = new System.Drawing.Size(77, 38);
                labelForNameU.Text = "Нет подходящих вариантов";

                cardUn.Controls.Add(labelForNameU);
                panelUnList.Controls.Add(cardUn);
                return; 
            }

            foreach (University u in Universities)
            {
                /*основная карточка*/
                #region основная карточка
                cardUn = new PictureBox();
                cardUn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(88)))), ((int)(((byte)(130)))));
                cardUn.Image = global::IHSUniversities.Properties.Resources.Rectangle_18;
                cardUn.Location = new System.Drawing.Point(31, YForU);
                cardUn.Size = new System.Drawing.Size(1387, 225);
                cardUn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                cardUn.Click += (s, args) => cardUn_Click(u.Id);
                YForU += 267;
                #endregion


                /*изображение ВУЗа*/
                #region изображение ВУЗа
                //сама картинка
                imgU = new PictureBox();
                imgU.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(117)))), ((int)(((byte)(159)))));
                imgU.BackgroundImage = global::IHSUniversities.Properties.Resources.photo__1_;
                imgU.Name = u.Id.ToString();
                imgU.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                imgU.Image = global::IHSUniversities.Properties.Resources.Exclude;
                imgU.Location = new System.Drawing.Point(23, 18);
                imgU.Size = new System.Drawing.Size(168, 168);
                imgU.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                imgU.Click += (s, args) => cardUn_Click(u.Id);

                //края(низ, право)
                pictureBox7 = new PictureBox();
                pictureBox7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(117)))), ((int)(((byte)(159)))));
                pictureBox7.Location = new System.Drawing.Point(23, 185);
                pictureBox7.Size = new System.Drawing.Size(173, 10);
                pictureBox7.Click += (s, args) => cardUn_Click(u.Id);
                pictureBox5 = new PictureBox();
                pictureBox5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(117)))), ((int)(((byte)(159)))));
                pictureBox5.Location = new System.Drawing.Point(190, 18);
                pictureBox5.Size = new System.Drawing.Size(1, 168);
                pictureBox5.Click += (s, args) => cardUn_Click(u.Id);
                cardUn.Controls.Add(pictureBox7);
                cardUn.Controls.Add(pictureBox5);

                cardUn.Controls.Add(imgU);
                new Thread(new ThreadStart(() =>
                {

                    if (!images.ContainsKey(u.Id))
                    {
                        System.Drawing.Image image = DownloadImage(u.Photo);
                        if (image == null) image = global::IHSUniversities.Properties.Resources.photo__1_;
                        if (!images.ContainsKey(u.Id)) images.Add(u.Id, image);
                    }
                    if (panelUnList.Controls.Find(u.Id.ToString(), true).Count() != 0) panelUnList.Controls.Find(u.Id.ToString(), true)[0].BackgroundImage = images[u.Id];

                })).Start();
                #endregion


                /*название ВУЗа*/
                #region название ВУЗа
                labelForNameU = new Label();
                labelForNameU.AutoSize = true;
                labelForNameU.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(117)))), ((int)(((byte)(159)))));
                labelForNameU.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                labelForNameU.ForeColor = System.Drawing.Color.White;
                labelForNameU.Location = new System.Drawing.Point(258, 50 - (labelForNameU.Height));
                labelForNameU.Size = new System.Drawing.Size(77, 38);
                labelForNameU.Text = transfer(u.NameU);
                labelForNameU.Click += (s, args) => cardUn_Click(u.Id);
                cardUn.Controls.Add(labelForNameU);
                #endregion

                panelUnList.Controls.Add(cardUn);
            }

            YForU += 47;
            cardUn = new PictureBox()
            {
                BackColor = System.Drawing.Color.FromArgb(82, 88, 130),
                SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage,
                Image = global::IHSUniversities.Properties.Resources.Comparison,
                Location = new System.Drawing.Point(31, YForU),
                Size = new System.Drawing.Size(1387, 90)
            };
            cardUn.Click += (s, e) => exportToWord(Universities.ToList());
            labelForNameU = new Label()
            {
                AutoSize = true,
                BackColor = System.Drawing.Color.FromArgb(144, 106, 174),
                Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204))),
                ForeColor = System.Drawing.Color.White,
                Location = new System.Drawing.Point(1, 1),
                Text = "Экспортировать данные в Word"
            };
            labelForNameU.Click += (s, e) => exportToWord(Universities.ToList());
            YForU += 107;
            cardUn.Controls.Add(labelForNameU);
            panelUnList.Controls.Add(cardUn);
            labelForNameU.Location = new Point(cardUn.Size.Width/2 - labelForNameU.Width/2, cardUn.Size.Height / 2 - labelForNameU.Height / 2 - 9);


            labelForNameU = new Label();
            labelForNameU.Location = new Point(31, YForU - 20);
            panelUnList.Controls.Add(labelForNameU);


        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == null || textBox1.Text == "")
            {
                updateDB();
                updatePanelUnList();
                return;
            }
            updateDB(textBox1.Text);
            updatePanelUnList();
        }

        private void checkSpeciality(int iSspeciality)
        {
            if (!ListForComparison.Contains(iSspeciality))
            {
                panelForS.Controls[panelForS.Controls.Count - 4].Text = "Убрать из сравения";
                ListForComparison.Add(iSspeciality);
                context.UsersSpecialitys.Add(new UserSpeciality(User.Id, iSspeciality));
                context.SaveChanges();
            }
            else
            {
                panelForS.Controls[panelForS.Controls.Count - 4].Text = "Добавить в сравение";
                ListForComparison.Remove(iSspeciality);
                context.UsersSpecialitys.Remove(new UserSpeciality(User.Id, iSspeciality));
                context.SaveChanges();
            }
        }

        private void pictureBoxPersonalArea_Click(object sender, EventArgs e)
        {
            PersonalArea pa = new PersonalArea(User);
            pa.ShowDialog();
        }

        private void pictureBoxReferenceSystem_Click(object sender, EventArgs e)
        {
            if (User != null) Process.Start(@"..\..\Forms\ForUser\HelpForUser\index.htm");
            else Process.Start(@"..\..\Forms\ForUser\HelpForGuest\index.htm");
        }

        private void exportToWord(List<University> universities = null, List<Faculty> faculties = null, List<Speciality> specialities = null)
        {
            WordDocument doc = new WordDocument();

            bool unList = (universities == null), fList = (faculties == null), sList = (specialities == null);
            if (!sList)
            {
                faculties = new List<Faculty>() { context.Faculties.First(f => f.Id == specialities[0].IdF) };
                fList = !fList;
            }
            if (unList && !fList) universities = new List<University>() { context.Universities.First(un => un.Id == faculties[0].IdU) };

            foreach (University un in universities)
            {
                doc.AddParagraph(createParagraf(un.NameU + " (" + (un.Dormitory ? "Общежитие есть)" : "Общежития нету)"), 28, true));


                if (fList) faculties = Faculties.Where(f => f.IdU == un.Id).ToList();
                MultiLevelTextList facultiesList = new MultiLevelTextList();
                if (faculties.Count == 0)
                {
                    facultiesList.AddItem(new ListItem(createParagraf("Подходящих факультетов нет", 24)));
                    doc.AddMultiLevelTextList(facultiesList);
                    doc.AddParagraph(createParagraf("", 28));
                    continue;
                }
                    
                
                foreach (Faculty f in faculties)
                {
                    facultiesList.AddItem(new ListItem(createParagraf(f.NameF, 24)));

                    if(sList) specialities = Specialities.Where(s => s.IdF == f.Id).ToList();
                    MultiLevelTextList specialitiesList = new MultiLevelTextList();
                    specialitiesList.SymbolText = "-";
                    if (specialities.Count == 0)
                        specialitiesList.AddItem(new ListItem(createParagraf("Подходящих спецальностей нет", 24)));
                    foreach (Speciality s in specialities)
                    {
                        specialitiesList.AddItem(new ListItem(createParagraf(s.NameS + " (Кол-во баллов:" + s.Points + ", Предметы: " + s.Exam1 + ", " + s.Exam2 + ", " + s.Exam3 + ")", 20)));
                    }
                    facultiesList.AddItem(new ListItem(specialitiesList));
                }
                doc.AddMultiLevelTextList(facultiesList);
                doc.AddParagraph(createParagraf("", 28));

            }


            if (!File.Exists(@"D:\\Список ВУЗов & Факультетов & Специальностей.docx"))
            {
                doc.SaveAs(@"D:\\Список ВУЗов & Факультетов & Специальностей.docx");
                MessageBox.Show("Файл со списком был успешно сохранен\n" +
                    "Расположение: D:\\\n" +
                    "Название: Список ВУЗов & Факультетов & Специальностей.docx", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DialogResult result = MessageBox.Show("Данный файл уже существует, желаете ли\n" +
                    "ли вы его заменить?\n\n" +
                    "Расположение: D:\\\n" +
                    "Название: Список ВУЗов & Факультетов & Специальностей.docx", "Предупреждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if(result == DialogResult.OK)
                {
                    File.Delete(@"D:\\Список ВУЗов & Факультетов & Специальностей.docx");
                    doc.SaveAs(@"D:\\Список ВУЗов & Факультетов & Специальностей.docx");
                }
            }
        }

        private Paragraph createParagraf(string text, float fontSize, bool isBold = false)
        {
            Paragraph buffParagraph = new Paragraph();
            Text buffText = new Text()
            {
                Text = text,
                Style = new TextStyle()
                {
                    FontFamily = "Bahnschrift Light",
                    FontSize = fontSize,
                    IsBold = isBold
                },
                
            };

            buffParagraph.AddText(buffText);
            return buffParagraph;
        }

        static System.Drawing.Image DownloadImage(string url)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    byte[] imageBytes = client.GetByteArrayAsync(url).Result;

                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        return System.Drawing.Image.FromStream(ms);
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            DialogResult result = MessageBox.Show("Вы действительно хотите закрыть программу?", "Закрытие программы", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) e.Cancel = true; 
            else Environment.Exit(0);
        }
    }
}





