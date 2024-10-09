using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHSUniversities
{
    [Table("University")]
    public class University
    {
        [Key]
        public int Id { get; set; }


        [Column("NameU")]
        public string NameU { get; set; }

        [Column("DescriptionU")]
        public string DescriptionU { get; set; }

        [Column("Link")]
        public string Link { get; set; }

        [Column("Photo")]
        public string Photo { get; set; }

        [Column("Dormitory")]
        public bool Dormitory { get; set; }


        public University() { }

        public University(string nameU, string descriptionU, string link, string photo, bool dormitory)
        {
            NameU = nameU;
            DescriptionU = descriptionU;
            Link = link;
            Photo = photo;
            Dormitory = dormitory;
        }
    }


}

