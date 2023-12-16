using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;

namespace BioApp.Models
{
    public class PatientVisits
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }
        [Display(Name = "Номер паспорта пациента")]
        [RegularExpression(@"^[0-9]{10,10}$", ErrorMessage = "Ошибка ввода. Необходимо ввести 10 цифр")]
        public string passportNumber { get; set; }
        [Display(Name = "Серия")]
        [RegularExpression(@"^[0-9]{4,4}$", ErrorMessage = "Ошибка ввода. Необходимо ввести 4 цифры")]
        public string seriaPassport { get; set; }
        [Display(Name = "Номер")]
        [RegularExpression(@"^[0-9]{6,6}$", ErrorMessage = "Ошибка ввода. Необходимо ввести 6 цифры")]
        public string numberPassport { get; set; }
        [Display(Name = "Кем выдан")]
        public string issuedByPassport { get; set; }
        [Display(Name = "Когда выдан")]
        public DateTime datePassport { get; set; }
        [Display(Name = "Код подразделения")]
        [RegularExpression(@"^\d{3}-\d{3}$", ErrorMessage = "Ошибка ввода. Код подразделения должен быть формата: 111-111")]
        public string kodPassport { get; set; }

        [Display(Name = "Идентификационный номер")]
        public string IdNumber { get; set; }

        [Display(Name = "СНИЛС")]
        [RegularExpression(@"^\d{3}-\d{3}-\d{3}-\d{2}$", ErrorMessage = "Ошибка ввода. СНИЛС должен быть формата: 111-111-111-11")]
        public string SNILS { get; set; }

        [Display(Name = "Место рождения")]
        public string PlaceOfBirth { get; set; }

        [Display(Name = "Место проживания")]
        public string PlaceOfResidence { get; set; }

        [Display(Name = "Возраст")]
        public int Age { get; set; }

        [Display(Name = "ИНН")]
        [RegularExpression(@"^[0-9]{12,12}$", ErrorMessage = "Ошибка ввода. Необходимо ввести 12 цифр")]
        public string INN { get; set; }

        [Display(Name = "Номер полиса ОМС")]
        [RegularExpression(@"^[0-9]{16,16}$", ErrorMessage = "Ошибка ввода. Необходимо ввести 16 цифр")]
        public string OMSNumber { get; set; }

        [Display(Name = "ФИО пациента")]
        public string name { get; set; }
        [Display(Name = "Дата рождения")]
        public DateTime birthDate { get; set; }
        [Display(Name = "Пол")]
        public Gender gender { get; set; }
        [Display(Name = "Дата посещения")]
        public DateTime registrationDate { get; set; }
        [Display(Name = "Файлы")]
        public ICollection<BioFile> files { get; set; }

        public List<MKBClassifier> MKBClassifiers { get; set; } = new List<MKBClassifier>();

        //Эндогенные факторы
        [Display(Name = "Была ли ранее диагностирована меланома")]
        public bool previousMelanoma { get; set; }

        [Display(Name = "Была ли ранее диагностирована меланома в семье(семейный анамнез)")]
        public bool previousMelanomaInFamily { get; set; }

        [Display(Name = "Наличие невусов")]
        public NevusType nevusType { get; set; }

        [Display(Name = "Наличие веснушек")]
        public bool PresenceOfFreckles { get; set; }

        [Display(Name = "Наличие облигатных форм предрака")]
        public bool ObligateFormsOfPrecancer { get; set; }

        [Display(Name = "Гормональные изменения")]
        public bool HormonalChanges { get; set; }

        //Экзогенные  факторы        
        [Display(Name = "Солнечные ожоги кожного покрова")]
        public Burns burns { get; set; }

        [Display(Name = "Наличие заболеваний иммунной системы")]
        public bool immuneSystemDiseases { get; set; }

        [Display(Name = "Возрастная группа")]
        public AgeGroup ageGroup { get; set; }

        [Display(Name = "Тип кожи по Фитцпатрику")]
        public SkinType skinType { get; set; }

        [Display(Name = "Цвет глаз")]
        public EyeType eyeType { get; set; }

        [Display(Name = "Тип волос")]
        public HairType hairType { get; set; }

        [Display(Name = "Гормональные изменения")]
        public HormonalChangesNew hormonalChangesNew { get; set; }

        [Display(Name = "Генетические аномалии в хромосомах")]
        public GeneticAbnormalitiesInChromosomes geneticAbnormalitiesInChromosomes { get; set; }
        [Display(Name = "Меланома")]
        public Melanoma melanoma { get; set; }
        [Display(Name = "Клеточный состав меланом")]
        public CompoundMelonoma compoundMelonoma { get; set; }
        [Display(Name = "Родители")]
        public Parents parents { get; set; }
        [Display(Name = "Симбсы")]
        public Simba simba { get; set; }
        [Display(Name = "Другие родственники")]
        public Relatives relatives { get; set; }
        [Display(Name = "Более 50 родинок или наличие родинки диаметром более 2 см.")]
        public bool numberOfMoles { get; set; }
        [Display(Name = "Невусы - факультативные формы предрака")]
        public Nevus nevus { get; set; }
        [Display(Name = "Врожденные пигментные невусы / родимые пятна")]
        public Birthmarks birthmarks { get; set; }
        [Display(Name = "Воздействие УФ-облучения")]
        public UF uf { get; set; }
        [Display(Name = "Люди с ослабленной иммунной системой (как следствие заболевания или терапии)")]
        public bool immuneSystem { get; set; }
        [Display(Name = "Пигментная ксеродермия")]
        public bool XerodermaPigmentosum { get; set; }
        [Display(Name ="ID пациента")]
        public Guid? patientID { get; set; }
        public List<Patient> Patients { get; set; } = new List<Patient>();
    }
}
