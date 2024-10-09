using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHSUniversities
{
    [Table("Faculty")]
    public class Faculty
    {
        [Key]
        public int Id { get; set; }


        [Column("NameF")]
        public string NameF { get; set; }

        [Column("DescriptionF")]
        public string DescriptionF { get; set; }

        [Column("IdU")]
        public int IdU { get; set; }


        public Faculty() { }

        public Faculty(string nameF, string descriptionF, int idU)
        {
            NameF = nameF;
            DescriptionF = descriptionF;
            IdU = idU;
        }
    }


}

