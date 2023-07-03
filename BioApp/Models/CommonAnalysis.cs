using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BioApp.Models
{

    public enum AnalysisType
    {
        [Description("Общий анализ крови")]
        [Display(Name = "Общий анализ крови")]
        CommonBloodAnalysis,
        [Description("Генетический анализ")]
        [Display(Name = "Генетический анализ")]
        GeneticAnalysis

    }
    public class CommonAnalysis
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }

        [Display(Name = "Врач")]
        public Guid DoctorId { get; set; }

        [Display(Name = "Врач")]
        public Doctor doctor { get; set; }

        [Display(Name = "Пациент")]
        public Guid PatientId { get; set; }

        [Display(Name = "Пациент")]
        public Patient patient { get; set; }

        [Display(Name = "Дата сбора биоматериала")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBiosampleCollecting { get; set; }

        [Display(Name = "Дата проведения анализа")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime DateOfAnalysis { get; set; }

        [Display(Name = "Причина проведения анализа")]
        public string AnalysisIsPerformedBy { get; set; }
    
        [Display(Name = "Тип анализа")]
        public AnalysisType analysisType { get; set; }
    }
}
