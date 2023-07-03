using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BioApp.Models
{
    public class MKBClassifier
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [Required]
        [Display(Name = "Название")]
        public string name { get; set; }

        [Required]
        [Display(Name = "Код")]
        public string code { get; set; }

        public int? parentId { get; set; }
        [Display(Name = "Базовое заболевание")]
        public MKBClassifier? parent { get; set; }
        
        public string parentCode { get; set; }
        
        [Required]
        [Display(Name = "Количество узлов")]
        public int nodeCount { get; set; }
        [Display(Name ="Дополнительна инормация")]
        public string additionalInfo { get; set; }

        public List<Patient> Patients { get; set; } = new List<Patient>();

    }
}
