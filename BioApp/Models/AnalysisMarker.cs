using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BioApp.Models
{
    public enum DataType
    {
        [Description("Число")]
        [Display(Name = "Число")]
        Double,
        [Description("Да/Нет")]
        [Display(Name = "Да/Нет")]
        Bool,
        [Description("Строка")]
        [Display(Name = "Строка")]
        String,
    }
    public class AnalysisMarker
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }

        [Display(Name = "Название")]
        public string name { get; set; }

        [Display(Name = "Название на английском")]
        public string nameEn { get; set; }

        [Display(Name = "Единица измерения")]
        public string measure { get; set; }

        [Display(Name = "Единица измерения на английском")]
        public string measureEn { get; set; }

        [Display(Name = "Тип анализа ")]
        public AnalysisType analysisType { get; set; }

        public List<AnalysisMarkerNormValue> analysisMarkerNormValues { get; set; }

        public int orderRank { get; set; }

        public DataType dataType { get; set; }

        [Display(Name = "Риски ")]
        public double probability { get; set; }
    }
}
