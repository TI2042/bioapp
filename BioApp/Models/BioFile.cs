using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BioApp.Models
{
    public class BioFile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }
        [Display(Name = "Название")]
        public string name { get; set; }

        public string path { get; set; }
        [Display(Name = "Дата создания")]
        public DateTime createDate { get; set; }
        [Display(Name = "Тип файла")]
        public Guid BioFileTypeId { get; set; }
        [Display(Name = "Тип файла")]
        public BioFileType fileType { get; set; }
        
        [Display(Name = "Пациент")]
        public Guid PatientId { get; set; }
        [Display(Name = "Пациент")]

        public Patient patient { get; set; }

    }
}
