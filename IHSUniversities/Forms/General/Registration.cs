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

namespace IHSUniversities
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox2.Text.Equals("") || textBox3.Text.Equals("") || textBox1.Text.Equals("") || textBox1.Text.Contains(" ") || (!new Regex(@"@gmail\.com").IsMatch(textBox1.Text)))
            {
                MessageBox.Show("Заполните все поля!", "Некоректные данные", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            User user = new User(textBox2.Text, textBox3.Text, textBox1.Text, false);
            using(Datab context = new Datab())
            {
                
                if (context.Users.Select(us => us.Email).Contains(user.Email))
                {
                    MessageBox.Show("Пользователь с такой почтой\nуже зарегстрирован!", "Проверка пользователей", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (context.Users.Select(us => us.Login).Contains(user.Login))
                {
                    MessageBox.Show("Такой логин занят другим\nпользователем!", "Проверка пользователей", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                context.Users.Add(user);
                context.SaveChanges();
            }
            MessageBox.Show("Пользователь суспешно создан!", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            UserMainForm f = new UserMainForm(user);
            Hide();
            f.ShowDialog();
            Close();
        }

        private void label5_MouseMove(object sender, MouseEventArgs e) => label5.ForeColor= System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(136)))), ((int)(((byte)(193)))));
        private void label5_MouseLeave(object sender, EventArgs e) => label5.ForeColor = System.Drawing.Color.White;

        private void label6_MouseMove(object sender, MouseEventArgs e) => label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(136)))), ((int)(((byte)(193)))));
        private void label6_MouseLeave(object sender, EventArgs e) => label6.ForeColor = System.Drawing.Color.White;

        private void label5_Click(object sender, EventArgs e)
        {
            Authorization a = new Authorization();
            Hide();
            a.ShowDialog();
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
