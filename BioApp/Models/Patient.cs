using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BioApp.Models
{
    public enum Gender
    {
        [Description("Мужской")]
        [Display(Name = "Мужской")]
        Male,
        [Description("Женский")]
        [Display(Name = "Женский")]
        Female
    }
    public enum SkinType
    {
        [Description("1-й Тип. Белая кожа")]
        [Display(Name = "1-й Тип. Белая кожа")]
        First,
        [Description("2-й Тип. Cветлая кожа")]
        [Display(Name = "2-й Тип. Cветлая кожа")]
        Second,
        [Description("3-й Тип. Промежуточный тип кожи")]
        [Display(Name = "3-й Тип. Промежуточный тип кожи")]
        Third,
        [Description("4-й Тип. Оливковая кожа")]
        [Display(Name = "4-й Тип. Оливковая кожа")]
        Fourth,
        [Description("5-й Тип. Коричневая кожа")]
        [Display(Name = "5-й Тип. Коричневая кожа")]
        Fifth,
        [Description("6-й Тип. Черная кожа")]
        [Display(Name = "6-й Тип. Черная кожа")]
        Six
    }
    public enum EyeType
    {
        [Description("1-й Тип. Темный. №1")]
        [Display(Name = "1-й Тип. Темный. №1")]
        Eye1,
        [Description("1-й Тип. Темный. №2")]
        [Display(Name = "1-й Тип. Темный. №2")]
        Eye2,
        [Description("1-й Тип. Темный. №3")]
        [Display(Name = "1-й Тип. Темный. №3")]
        Eye3,
        [Description("1-й Тип. Темный. №4")]
        [Display(Name = "1-й Тип. Темный. №4")]
        Eye4,
        [Description("2-й Тип. Смешанный. №5")]
        [Display(Name = "2-й Тип. Смешанный. №5")]
        Eye5,
        [Description("2-й Тип. Смешанный. №6")]
        [Display(Name = "2-й Тип. Смешанный. №6")]
        Eye6,
        [Description("2-й Тип. Смешанный. №7")]
        [Display(Name = "2-й Тип. Смешанный. №7")]
        Eye7,
        [Description("2-й Тип. Смешанный. №8")]
        [Display(Name = "2-й Тип. Смешанный. №8")]
        Eye8,
        [Description("3-й Тип. Свелый. №9")]
        [Display(Name = "3-й Тип. Светлый. №9")]
        Eye9,
        [Description("3-й Тип. Свелый. №10")]
        [Display(Name = "3-й Тип. Светлый. №10")]
        Eye10,
        [Description("3-й Тип. Свелый. №11")]
        [Display(Name = "3-й Тип. Светлый. №11")]
        Eye11,
        [Description("3-й Тип. Свелый. №12")]
        [Display(Name = "3-й Тип. Светлый. №12")]
        Eye12
    }
    public enum HairType
    {
        [Description("10-й Тип. Платиновый блондин")]
        [Display(Name = "10-й Тип. Платиновый блондин")]
        Hair10,
        [Description("9-й Тип. Яркий блондин")]
        [Display(Name = "9-й Тип. Яркий блондин")]
        Hair9,
        [Description("8-й Тип. Блондин")]
        [Display(Name = "8-й Тип. Блондин")]
        Hair8,
        [Description("7-й Тип. Светло-русый")]
        [Display(Name = "7-й Тип. Светло-русый")]
        Hair7,
        [Description("6-й Тип. Средне-русый")]
        [Display(Name = "6-й Тип. Средне-русый")]
        Hair6,
        [Description("5-й Тип. Темно-русый")]
        [Display(Name = "5-й Тип. Темно-русый")]
        Hair5,
        [Description("4-й Тип. Светло-коричневый")]
        [Display(Name = "4-й Тип. Светло-коричневый")]
        Hair4,
        [Description("3-й Тип. Средне-коричневый")]
        [Display(Name = "3-й Тип. Средне-коричневый")]
        Hair3,
        [Description("2-й Тип. Темно-коричневый")]
        [Display(Name = "2-й Тип. Темно-коричневый")]
        Hair2,
        [Description("1-й Тип. Черный")]
        [Display(Name = "1-й Тип. Черный")]
        Hair1,
    }

    public enum NevusType
    {
        [Description("Невусы отсутствуют")]
        [Display(Name = "Невусы отсутствуют")]
        No,
        [Description("Единичные невусы")]
        [Display(Name = "Единичные невусы")]
        Single,
        [Description("Множественные невусы(более 20)")]
        [Display(Name = "Множественные невусы(более 20)")]
        Set     
    }
    public enum UVInsolation
    {
        [Description("3 часа")]
        [Display(Name = "3 часа")]
        threeHours,
        [Description("6 часов")]
        [Display(Name = "6 часов")]
        sixHours,
        [Description("более 6 часов")]
        [Display(Name = " более 6 часов")]
        moreSixHours,
    }
    public enum Burns
    {
        [Description("Отсутствуют")]
        [Display(Name = "Отсутствуют")]
        no,
        [Description("Легкая стадия")]
        [Display(Name = "Легкая стадия")]
        easy,
        [Description("Средняя стадия")]
        [Display(Name = "Средняя стадия")]
        middle,
        [Description("Тяжелая стадия")]
        [Display(Name = "Тяжелая стадия")]
        hard,
    }

      
    public enum AgeGroup
    {
        [Description("до 18 лет")]
        [Display(Name = "до 18 лет")]
        before18,
        [Description("18-30 лет")]
        [Display(Name = "18-30 лет")]
        years1830,
        [Description("31-55 лет")]
        [Display(Name = "31-55 лет")]
        years3155,
        [Description("55+ лет")]
        [Display(Name = "55+ лет")]
        more55,
    }
    public class Patient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }
        [Display(Name = "Номер паспорта пациента")]
        [RegularExpression(@"^[0-9]{10,10}$", ErrorMessage = "Ошибка ввода. Необходимо ввести 10 цифр")]
        public string passportNumber { get; set; }
        

        [Display(Name = "ИНН")]
        [RegularExpression(@"^[0-9]{12,12}$", ErrorMessage = "Ошибка ввода. Необходимо ввести 12 цифр")]
        public string INN { get; set; }

        [Display(Name = "Номер полиса ОМС")]
        [RegularExpression(@"^[0-9]{16,16}$", ErrorMessage = "Ошибка ввода. Необходимо ввести 16 цифр")]
        public string OMSNumber { get; set; }

        [Display(Name = "ФИО пациента")]
        public string name { get; set; }
        [Display(Name = "Дата рождения")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime birthDate { get; set; }
        [Display(Name = "Пол")]
        public Gender gender { get; set; }
        [Display(Name = "Дата регистрация")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
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
        [Display(Name = "Ожоги")]
        public Burns burns { get; set; }

        [Display(Name = "Наличие заболеваний иммунной системы")]
        public bool immuneSystemDiseases { get; set; }

        [Display(Name = "Возрастная группа")]
        public AgeGroup ageGroup { get; set; }

        [Display(Name = "Тип кожи по Фитцпатрику")]
        public SkinType skinType { get; set; }

        [Display(Name = "Тип глаз")]
        public EyeType eyeType { get; set; }

        [Display(Name = "Тип волос")]
        public HairType hairType { get; set; }
    }
}
