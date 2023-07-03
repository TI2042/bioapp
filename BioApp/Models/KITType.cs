using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BioApp.Models
{
    public class KITType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }
        [Display(Name = "Название")]
        public string name { get; set; }
        [Display(Name = "Описание")]
        public string description { get; set; }


    }
}
