using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BioApp.Models
{
    public class Doctor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }
        [Display(Name = "ФИО доктора")]
        public string name { get; set; }
        [Display(Name = "Специализация")]
        public Guid DoctorSpecializationId { get; set; }
        [Display(Name = "Специализация")]
        public DoctorSpecialization doctorSpecialization { get; set; }
    }
}
