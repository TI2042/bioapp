using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BioApp.Models
{
    public class MelanomaType
    {
        [Display(Name = "Название")]
        public string name { get; set; }
        [Display(Name = "Название на аглийском")]
        public string nameEng { get; set; }
        [Display(Name = "Название на латинском")]
        public string nameLat { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }
    }
}
