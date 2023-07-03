using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BioApp.Models
{

    public class KITMarker
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }
        [Display(Name = "Название")]
        public string name { get; set; }
        [Display(Name = "Описание")]
        public string description { get; set; }
        //[Display(Name = "Тип")]
        //public string type { get; set; }
        [Display(Name = "Анализ")]
        public Guid AnalysisId { get; set; }
        [Display(Name = "Анализ")]
        public Analysis analysis { get; set; }
        [Display(Name = "Тип")]
        public Guid TypeId { get; set; }
        [Display(Name = "Тип")]
        public KITType type { get; set; }
        [Display(Name = "absent ??ОТСУТСТВУЕТ??")]
        public bool absent    { get; set; }
        [Display(Name = "гетерозиготность ?")]
        public bool heterozygosity { get; set; }
        [Display(Name = "гомозиготность ?")]
        public bool homozygosity { get; set; }
        [Display(Name = "Нет данных ")]
        public bool NA { get; set; }

    }
}
