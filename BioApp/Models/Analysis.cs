using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BioApp.Models
{
    public enum Biosample
    {
        [Description("Периферическая кровь")]
        [Display(Name = "Периферическая кровь")]
        PeripheralBlood,
        [Description("Биопсия")]
        [Display(Name = "Биопсия")]
        Biopsy
    }
    public class Analysis
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }
        [Display(Name = "Врач")]
        public Guid DoctorId { get; set; }
        [Display(Name = "Врач")]
        public Doctor doctor { get; set; }
        [Display(Name = "Биоматериал")]
        public Biosample bioSample { get; set; }

        [Display(Name = "Дата сбора биоматериала")]
        public DateTime DateOfBiosampleCollecting { get; set; }

        [Display(Name = "Дата проведения анализа")]
        public DateTime DateOfAnalysis { get; set; }

        [Display(Name = "Пациент")]
        public Guid PatientId { get; set; }
        
        [Display(Name = "Пациент")]
        public Patient patient { get; set; }

        [Display(Name = "Причина проведения анализа")]
        public string AnalysisIsPerformedBy { get; set; }
        [Display(Name = "Профилактика")]
        public bool preventiveCare { get; set; }
        [Display(Name = "Ранние метастазы")]
        public bool earlyMetastasis { get; set; }
        [Display(Name = "Поздние метастазы")]
        public bool lateMetastasis { get; set; }
        [Display(Name = "Меланома диагностирована на ранней стадии")]
        public bool melanomaConfirmedEarlyStage { get; set; }

        [Display(Name = "Тип меланомы")]
        public Guid MelanomaTypeId { get; set; }
        [Display(Name = "Тип меланомы")]
        public MelanomaType melanomaType { get; set; }
        [Display(Name = "Маркеры")]
        public ICollection<KITMarker> kitMarkers { get; set; }
        [Display(Name = "Номер")]
        public string number { get; set; }
        [NotMapped]
        [Display(Name = "Данные  анализа")]
        public string AnalisString { get {
                return number+ " Пациент: " + patient.name + " Врач : " + doctor.name;
                } }
    }
}
