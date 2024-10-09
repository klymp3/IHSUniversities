using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace IHSUniversities
{
    public partial class Authorization : Form
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        //    textBox1.Text = "1";
        //    textBox2.Text = "1";

            if (textBox2.Text.Equals("") || textBox1.Text.Equals(""))
            {
                MessageBox.Show("Заполните все поля!", "Некоректные данные", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            using (Datab context = new Datab())
            {
                var user = context.Users.FirstOrDefault(us => us.Login == textBox1.Text);
                if(user == null || user.Password != textBox2.Text){
                    MessageBox.Show("Неверный логин или пароль!", "Проверка пользователей", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (user.Rights)
                {
                    AdminMainForm f = new AdminMainForm(user);
                    Hide();
                    f.ShowDialog();
                }
                else
                {
                    UserMainForm f = new UserMainForm(user);
                    Hide();
                    f.ShowDialog();
                }
                Close();
            }
        }

        private void label5_MouseMove(object sender, MouseEventArgs e) => label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(136)))), ((int)(((byte)(193)))));
        private void label5_MouseLeave(object sender, EventArgs e) => label5.ForeColor = System.Drawing.Color.White;

        private void label6_MouseMove(object sender, MouseEventArgs e) => label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(136)))), ((int)(((byte)(193)))));
        private void label6_MouseLeave(object sender, EventArgs e) => label6.ForeColor = System.Drawing.Color.White;

        private void label5_Click(object sender, EventArgs e)
        {
            Registration r = new Registration();
            Hide();
            r.ShowDialog();
            Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            UserMainForm f = new UserMainForm();
            Hide();
            f.ShowDialog();
            Close();
        }
    }
}
