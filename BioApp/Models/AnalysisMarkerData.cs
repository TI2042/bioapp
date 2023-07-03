using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BioApp.Models
{
    public class AnalysisMarkerData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }

        [Display(Name = "Анализ")]
        public Guid CommonAnalysisId { get; set; }
        public CommonAnalysis commonAnalysis { get; set; }

        [Display(Name = "Показатель")]
        public Guid AnalysisMarkerId { get; set; }
        public AnalysisMarker analysisMarker { get; set; }

        [Display(Name = "Значение показателя")]
        public double? doubleValue { get; set; }

        [Display(Name = "Значение показателя")]
        public bool? boolValue { get; set; }

        [Display(Name = "Значение показателя")]
        public string? stringValue { get; set; }

    }
}
