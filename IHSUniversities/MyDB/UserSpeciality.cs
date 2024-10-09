using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHSUniversities
{
    [Table("User-Speciality")]
    public class UserSpeciality
    {

        [Column("IdUser")]
        public int IdUser { get; set; }

        [Column("IdSpeciality")]
        public int IdSpeciality { get; set; }


        public UserSpeciality() { }

        public UserSpeciality(int idUser, int idSpeciality)
        {
            IdUser = idUser;
            IdSpeciality = idSpeciality;
        }
    }


}

