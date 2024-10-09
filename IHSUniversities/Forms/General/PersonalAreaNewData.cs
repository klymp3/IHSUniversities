using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IHSUniversities
{
    public partial class PersonalAreaNewData : Form
    {
        User User;
        string LoginOrPasswordOrEmail;

        public PersonalAreaNewData(User user, string loginOrPasswordOrEmail)
        {
            InitializeComponent();
            User = user;
            LoginOrPasswordOrEmail = loginOrPasswordOrEmail;
        }


        private void label4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals("") || textBox2.Text.Equals(""))
            {
                MessageBox.Show("Заполните все поля!", "Некоректные данные", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (!textBox1.Text.Equals(textBox2.Text))
            {
                MessageBox.Show("Данные в полях не совпадают!", "Некоректные данные", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (LoginOrPasswordOrEmail.Equals("login"))
            {
                using (Datab context = new Datab())
                {
                    if (context.Users.FirstOrDefault(us => us.Login == textBox1.Text) != null)
                    {
                        MessageBox.Show("Логины занят другим пользователем!", "Проверка пользователей", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    User newUser = context.Users.FirstOrDefault(us => us == User);
                    newUser.Login = textBox1.Text;
                    context.SaveChanges();
                    PersonalArea pa = Application.OpenForms.OfType<PersonalArea>().FirstOrDefault();
                    pa.User = newUser;
                    UserMainForm f = Application.OpenForms.OfType<UserMainForm>().FirstOrDefault();
                    f.User = newUser;
                    MessageBox.Show("Логин успешно изменен!", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (LoginOrPasswordOrEmail.Equals("password"))
            {
                using (Datab context = new Datab())
                {
                    if (context.Users.FirstOrDefault(us => us.Password == textBox1.Text) != null)
                    {
                        MessageBox.Show("Пароль занят другим пользователем!", "Проверка пользователей", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    User newUser = context.Users.FirstOrDefault(us => us == User);
                    newUser.Password = textBox1.Text;
                    context.SaveChanges();
                    PersonalArea pa = Application.OpenForms.OfType<PersonalArea>().FirstOrDefault();
                    pa.User = newUser;
                    UserMainForm f = Application.OpenForms.OfType<UserMainForm>().FirstOrDefault();
                    f.User = newUser;
                    MessageBox.Show("Пароль успешно изменен!", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (LoginOrPasswordOrEmail.Equals("email"))
            {
                using (Datab context = new Datab())
                {
                    if (context.Users.FirstOrDefault(us => us.Email == textBox1.Text) != null)
                    {
                        MessageBox.Show("Email занят другим пользователем!", "Проверка пользователей", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    User newUser = context.Users.FirstOrDefault(us => us == User);
                    newUser.Email = textBox1.Text;
                    context.SaveChanges();
                    UserMainForm f = Application.OpenForms.OfType<UserMainForm>().FirstOrDefault();
                    f.User = newUser;
                    PersonalArea pa = Application.OpenForms.OfType<PersonalArea>().FirstOrDefault();
                    pa.User = newUser;
                    MessageBox.Show("Email успешно изменен!", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            Close();
        }

        private void PersonalAreaNewData_Load(object sender, EventArgs e)
        {
            if (LoginOrPasswordOrEmail.Equals("password"))
            {
                label1.Text = "Смена пароля";
                label.Text = "Пароль:";
                labelRepiat.Text = "Повторите пароль:";
                label4.Text = "Изменить пароль";
            }
            else if (LoginOrPasswordOrEmail.Equals("email"))
            {
                label1.Text = "Смена email";
                label.Text = "Email:";
                labelRepiat.Text = "Повторите email:";
                label4.Text = "Изменить email";
            }
        }
    }
}
