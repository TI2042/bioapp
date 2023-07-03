using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BioApp.Models
{
    public class DoctorSpecialization
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }
        [Display(Name = "Название специальности")]
        public string name { get; set; }
        public ICollection<Doctor> docs { get; set; }


    }
}
