using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHSUniversities
{
    [Table("User")]
    public class User
    {
        [Key]
        public int Id { get; set; }


        [Column("Login")]
        public string Login { get; set; }

        [Column("Password")]
        public string Password { get; set; }

        [Column("E-mail")]
        public string Email { get; set; }
        [Column("Rights")]
        public bool Rights { get; set; }


        public User() { }

        public User(string login, string password, string email, bool rights)
        {
            Login = login;
            Password = password;
            Email = email;
            Rights = rights;
        }
    }


}

