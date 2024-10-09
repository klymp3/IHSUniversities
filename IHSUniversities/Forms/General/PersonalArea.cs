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
    public partial class PersonalArea : Form
    {
        public User User;

        public PersonalArea(User user)
        {
            InitializeComponent();
            User = user;
        }

        private void PersonalArea_Load(object sender, EventArgs e)
        {
            labelLogin.Text = "Логин: " + User.Login;
            labelPassword.Text = "Пароль: " + User.Password;
            labelEmail.Text = "Email: " + User.Email;
            Update();

            if (User.Rights)
            {
                pictureBox5.Visible = false;
                label4.Visible = false;
                Size = new Size(1045, 714);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            PersonalAreaNewData pa = new PersonalAreaNewData(User, "login");
            pa.ShowDialog();
            PersonalArea_Load(sender, e);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            PersonalAreaNewData pa = new PersonalAreaNewData(User, "password");
            pa.ShowDialog();
            PersonalArea_Load(sender, e);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            PersonalAreaNewData pa = new PersonalAreaNewData(User, "email");
            pa.ShowDialog();
            PersonalArea_Load(sender, e);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            FormComparision f = new FormComparision(User);
            f.ShowDialog();
            PersonalArea_Load(sender, e);
        }
    }
}
