using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHSUniversities
{
    [Table("Speciality")]
    public class Speciality
    {
        [Key]
        public int Id { get; set; }


        [Column("NameS")]
        public string NameS { get; set; }

        [Column("DescriptionS")]
        public string DescriptionS { get; set; }

        [Column("Points")]
        public int Points { get; set; }

        [Column("Exam1")]
        public string Exam1 { get; set; }

        [Column("Exam2")]
        public string Exam2 { get; set; }

        [Column("Exam3")]
        public string Exam3 { get; set; }

        [Column("IdF")]
        public int IdF { get; set; }


        public Speciality() { }

        public Speciality(string nameS, string descriptionS, string exam1, string exam2, string exam3, int idF)
        {
            NameS = nameS;
            DescriptionS = descriptionS;
            Exam1 = exam1;
            Exam2 = exam2;
            Exam3 = exam3;
            IdF = idF;
        }

    }


}

