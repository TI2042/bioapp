using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BioApp.Models
{
    public class AnalysisMarkerNormValue
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }

        [Display(Name = "Показатель")]
        public Guid AnalysisMarkerId { get; set; }

        [Display(Name = "Показатель")]
        public AnalysisMarker AnalysisMarker { get; set; }

        [Display(Name = "Группа пациентов")]
        public Guid PatientGroupId { get; set; }

        [Display(Name = "Группа пациентов")]
        public PatientGroup PatientGroup { get; set; }

        [Display(Name = "Минимальное значение")]
        public double minValue { get; set; }

        [Display(Name = "Максимальное значение")]
        public double maxValue { get; set; }
        


    }
}
