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
        [Description("I – кельтский - молочно-белая кожа с веснушками. Рыжие или очень светлые волосы. Глаза голубые или зеленые")]
        [Display(Name = "I – кельтский - молочно-белая кожа с веснушками. Рыжие или очень светлые волосы. Глаза голубые или зеленые")]
        First,
        [Description("II – европейский светлокожий - кожа светлая, веснушек мало. Волосы русые, светло-каштановые. Глаза зеленые, голубые или серые")]
        [Display(Name = "II – европейский светлокожий - кожа светлая, веснушек мало. Волосы русые, светло-каштановые. Глаза зеленые, голубые или серые")]
        Second,
        [Description("III – европейский темнокожий - кожа светло-коричневая, без веснушек. Волосы каштановые. Глаза серые или карие")]
        [Display(Name = "III – европейский темнокожий - кожа светло-коричневая, без веснушек. Волосы каштановые. Глаза серые или карие")]
        Third,
        [Description("IV – средиземноморский - кожа смуглая. Глаза карие. Волосы темные")]
        [Display(Name = "IV – средиземноморский - кожа смуглая. Глаза карие. Волосы темные")]
        Fourth,
        [Description("V – индонезийский - кожа очень смуглая. Глаза темно-карие. Волосы черные")]
        [Display(Name = "V – индонезийский - кожа очень смуглая. Глаза темно-карие. Волосы черные")]
        Fifth,
        [Description("VI – афроамериканский - кожа очень темная. Глаза черно-карие. Волосы черные")]
        [Display(Name = "VI – афроамериканский - кожа очень темная. Глаза черно-карие. Волосы черные")]
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

    public enum HormonalChangesNew
    {
        [Description("Половое созревание")]
        [Display(Name = "Половое созревание")]
        Puberty,
        [Description("Прием гормональных контрацептивов")]
        [Display(Name = "Прием гормональных контрацептивов")]
        TakingHormonalContraceptives,
        [Description("Прием гормональных препаратов")]
        [Display(Name = "Прием гормональных препаратов")]
        TakingHormonalMedications,
        [Description("Беременность")]
        [Display(Name = "Беременность")]
        Pregnancy,
        [Description("Климактерический период")]
        [Display(Name = "Климактерический период")]
        Menopause

    }
    public enum GeneticAbnormalitiesInChromosomes
    {
        [Description("1")]
        [Display(Name = "1")]
        One,
        [Description("6")]
        [Display(Name = "6")]
        Six,
        [Description("7")]
        [Display(Name = "7")]
        Seven,
        [Description("9")]
        [Display(Name = "9")]
        Nine,
        [Description("10")]
        [Display(Name = "10")]
        Ten,
        [Description("11")]
        [Display(Name = "11")]
        Eleven

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
    public enum Melanoma
    {
        [Description("Поверхностная распространяющаяся меланома (SSM)")]
        [Display(Name = "Поверхностная распространяющаяся меланома (SSM)")]
        SSM,
        [Description("Узловая злокачественная меланома (NMM)")]
        [Display(Name = "Узловая злокачественная меланома (NMM)")]
        NMM,
        [Description("Меланома злокачественного лентиго (LMM)")]
        [Display(Name = "Меланома злокачественного лентиго (LMM)")]
        LMM,
        [Description("Акральная лентигинозная меланома (ALM)")]
        [Display(Name = "Акральная лентигинозная меланома (ALM)")]
        ALM,
        [Description("Лентигинозная меланома слизистых оболочек")]
        [Display(Name = "Лентигинозная меланома слизистых оболочек")]
        LentiginousMelanoma,
        [Description("Меланома сетчатки глаза (увеальная)")]
        [Display(Name = "Меланома сетчатки глаза (увеальная)")]
        Uveal,
        [Description("Десмопластическая меланома (малигнизированная меланома мягких тканей (malignant melanoma of soft parts или clear cell sarcoma)")]
        [Display(Name = "Десмопластическая меланома (малигнизированная меланома мягких тканей (malignant melanoma of soft parts или clear cell sarcoma) ")]
        MalignantMelanoma,
        [Description("Беспигментная (амеланотическая) меланома.")]
        [Display(Name = "Беспигментная (амеланотическая) меланома.")]
        PigmentlessMelanoma
    }
    public enum CompoundMelonoma
    {
        [Description("Эпителиоидные")]
        [Display(Name = "Эпителиоидные")]
        Epithelioid,
        [Description("Веретеноклеточные")]
        [Display(Name = "Веретеноклеточные")]
        SpindleCell,
        [Description("Невоидные")]
        [Display(Name = "Невоидные")]
        Nevoid,
        [Description("Смешанные")]
        [Display(Name = "Смешанные")]
        Mixed
    }

    public enum Parents
    {
        [Description("Отец")]
        [Display(Name = "Отец")]
        mum,
        [Description("Мать")]
        [Display(Name = "Мать")]
        dad

    }
    public enum Simba
    {
        [Description("Брат")]
        [Display(Name = "Брат")]
        brouther,
        [Description("Сестра")]
        [Display(Name = "Сестра")]
        sister

    }
    public enum Birthmarks
    {
        [Description("Более 5% поверхности кожного покрова")]
        [Display(Name = "Более 5% поверхности кожного покрова")]
        five,
        [Description("Размером более 20 см.")]
        [Display(Name = "Размером более 20 см.")]
        twenty

    }
    public enum UF
    {
        [Description("Нахождение под прямым воздействием солнечного света более 6 ч в день")]
        [Display(Name = "Нахождение под прямым воздействием солнечного света более 6 ч в день")]
        sun,
        [Description("Злоупотребление солярием")]
        [Display(Name = "Злоупотребление солярием")]
        solar

    }
    public enum Relatives
    {
        [Description("По мужской линии (оставить поле для заполнения)")]
        [Display(Name = "По мужской линии (оставить поле для заполнения)")]
        maleLine,
        [Description("По женской линии (оставить поле для заполнения)")]
        [Display(Name = "По женской линии (оставить поле для заполнения)")]
        femaleLine

    }
    public enum Nevus
    {
        [Description("Диспластические / атипичные невусы вероятность развития меланомы в течение жизни составляет 10-30% - размером более 6 мм, неправильной формы, от розового до коричневого цвета, часто с неровными краями")]
        [Display(Name = "Диспластические / атипичные невусы вероятность развития меланомы в течение жизни составляет 10-30% - размером более 6 мм, неправильной формы, от розового до коричневого цвета, часто с неровными краями")]
        AtypicalNevus,
        [Description("Межевой/пограничный (эпидермальный) невус")]
        [Display(Name = "Межевой/пограничный (эпидермальный) невус")]
        EpidermalNevus,
        [Description("Смешанный невус")]
        [Display(Name = "Смешанный невус")]
        MixedNevus,
        [Description("Внутридермальный невус")]
        [Display(Name = "Внутридермальный невус")]
        IntradermalNevus,
        [Description("Невус с пигментным компонентом")]
        [Display(Name = "Невус с пигментным компонентом")]
        NevusPigmentedComponent
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
        [Description("I степень – поражение самых поверхностных слоев кожи, проявляется в основном покраснением")]
        [Display(Name = "I степень – поражение самых поверхностных слоев кожи, проявляется в основном покраснением")]
        no,
        [Description("II степень – поражение кожи на всю ее глубину, с образованием волдырей с серозной или кровянистой жидкостью, появлением отеков, боли")]
        [Display(Name = "II степень – поражение кожи на всю ее глубину, с образованием волдырей с серозной или кровянистой жидкостью, появлением отеков, боли")]
        easy,
        [Description("III степень – некроз верхних или глубоких слоев кожи, вплоть до подкожно-жировой клетчатки, с образованием глубокой раны и волдырей")]
        [Display(Name = "III степень – некроз верхних или глубоких слоев кожи, вплоть до подкожно-жировой клетчатки, с образованием глубокой раны и волдырей")]
        middle,
        [Description("IV степень – некроз тканей на большую глубину, включая мышцы и кости, с их гибелью")]
        [Display(Name = "IV степень – некроз тканей на большую глубину, включая мышцы и кости, с их гибелью")]
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
    }
}
