using BioApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BioApp.Data
{
    public class DbInitializer
    {
        public static void Initialize(BioContext context)
        {
            context.Database.EnsureCreated();
            if (context.FileTypes.Any() && context.Patients.Any() && context.Files.Any() && context.MelanomaTypes.Any()
                && context.DoctorSpecializations.Any() && context.Doctor.Any() && context.Analysis.Any() && context.KITType.Any()
                && context.KITMarker.Any() && context.PatientGroup.Any() && context.PatientVisits.Any())
            {
                return;   // DB has been seeded
            }
            #region FillFileTypes
            var bioFileTypes = new BioFileType[]
            {
                new BioFileType{name="doc"},
                new BioFileType{name="jpg"},
                new BioFileType{name="scn"}
            //new Student{FirstMidName="Carson",LastName="Alexander",EnrollmentDate=DateTime.Parse("2005-09-01")},
            };
            foreach (BioFileType bft in bioFileTypes)
            {
                context.FileTypes.Add(bft);
            }
            context.SaveChanges();
            #endregion
            #region DocSpecs
            var docSpecializations = new DoctorSpecialization[]
            {
                new DoctorSpecialization{name="Хирург"},
                new DoctorSpecialization{name="Онколог"},
                new DoctorSpecialization{name="Дерматолог"},
                new DoctorSpecialization{name="Терапевт"}
            };
            foreach (DoctorSpecialization ds in docSpecializations)
            {
                context.DoctorSpecializations.Add(ds);
            }
            context.SaveChanges();
            #endregion
            #region Docs
            var doctors = new Doctor[]
            {
                new Doctor{name="Jesse Spencer", doctorSpecialization = docSpecializations[0]},
                new Doctor{name="Robert Sean Leonard",doctorSpecialization = docSpecializations[1]},
                new Doctor{name="Lisa Edelstein", doctorSpecialization = docSpecializations[2]},
                new Doctor{name="Hugh Laurie",doctorSpecialization = docSpecializations[3]}
            };
            foreach (Doctor d in doctors)
            {
                context.Doctor.Add(d);
            }
            context.SaveChanges();
            #endregion
            #region fillMelanomaTypes
            var melanomaTypes = new MelanomaType[]
            {
                new MelanomaType{ name = "Поверхностно-распространяющаяся меланома",
                                  nameEng = "Superficial spreading melanoma", nameLat="" },
                new MelanomaType{ name="Узловая меланома", nameEng= "Nodular melanoma", nameLat=""},
                new MelanomaType{ name="Акролентигинозная меланома", nameEng= "Acral lentiginous melanoma", nameLat="Acral Lentigo Maligna"},
                new MelanomaType{ name="Лентигинозная меланома", nameEng= "Lentigo maligna melanoma", nameLat="Lentigo Maligna"},
            //new Enrollment{StudentID=7,CourseID=3141,Grade=Grade.A},
            };
            foreach (MelanomaType m in melanomaTypes)
            {
                context.MelanomaTypes.Add(m);
            }
            context.SaveChanges();
            #endregion
            #region KITTypeTypes
            var KITTypeTypes = new KITType[]
            {
                new KITType{ name = "BRAF-V600E", description= "определяет чувствительность клеток к ингибиторам протеасом. Такая клеточная чувствительность к ингибиторам протеасомы зависит от наличия сигнала от B-Raf, поскольку блокировка BRAF V600E ингибитором PLX4720 возвращает клеточную чувствительность к анти-раковому препарату карфилзомибу в клетках колоректального рака, несущих мутацию BRAF V600E. Таким образом, ингибиторы протеасомы рассматриваются как возможная терапевтическая стратегия при этом раке с мутацией BRAF V600E."},
                new KITType{ name = "NRAS-Q61K", description= "is present in 0.59% of AACR GENIE cases, with melanoma, cutaneous melanoma, colon adenocarcinoma, colorectal adenocarcinoma, and melanoma of unknown primary having the greatest prevalence"},
                new KITType{ name = "KIT-K558R", description= "c-KIT activation has been shown to have oncogenic activity in gastrointestinal stromal tumors (GISTs), melanomas, lung cancer, and other tumor types. The targeted therapeutics nilotinib and sunitinib have shown efficacy in treating KIT overactive patients, and are in late-stage trials in melanoma and GIST. KIT overactivity can be the result of many genomic events from genomic amplification to overexpression to missense mutations. Missense mutations have been shown to be key players in mediating clinical response and acquired resistance in patients being treated with these targeted therapeutics."},
                new KITType{ name = "CDKN2A-G101W", description= "CDKN2A germline mutation frequency estimates are commonly based on families with several melanoma cases."},
                new KITType{ name = "MC1R-V60L", description= "Melanocortin-1-receptor (MC1R) is one of the major genes that determine skin pigmentation. MC1R variants were suggested to be associated with red hair, fair skin, and an increased risk of melanoma."},

            };
            foreach (KITType kit in KITTypeTypes)
            {
                context.KITType.Add(kit);
            }
            context.SaveChanges();
            #endregion
            #region fillPatients
            /*var patients = new Patient[]
            {
                new Patient{ name="Ivan Ivanovich Ivanov",INN="12345678912", OMSNumber="1234567890123456", gender=Gender.Male, birthDate=DateTime.Parse("1992-10-03"),
                passportNumber="443322",registrationDate=DateTime.Parse("2020-12-21")},
                new Patient{ name="Steven King", INN="23456789123", OMSNumber="2345678901234567", gender=Gender.Male, birthDate=DateTime.Parse("1947-09-21"),
                passportNumber="656788",registrationDate=DateTime.Parse("2020-11-19")},
                new Patient{ name="Margaret Thatcher", INN="34567891234", OMSNumber="3456789012345678", gender=Gender.Female, birthDate=DateTime.Parse("1925-10-13"),
                passportNumber="654455",registrationDate=DateTime.Parse("2020-12-25")}             
            };
            foreach (Patient p in patients)
            {
                context.Patients.Add(p);
            }*/
            context.SaveChanges();
            #endregion
            #region fillFiles
            /*var files = new BioFile[]
            {
                new BioFile{ name="Passport", createDate=DateTime.Parse("2005-09-01") , fileType = bioFileTypes[1] ,
                    path= "C:\\Files\\Patients\\Scans\\Pass00001.jpg", patient = patients[0]},
                new BioFile{ name="Scan 1", createDate=DateTime.Parse("2005-09-01") , fileType = bioFileTypes[2] ,
                    path= "C:\\Files\\Patients\\Scans\\Scan00001.scn", patient = patients[0]},
                new BioFile{ name="Medical history 1", createDate=DateTime.Parse("2005-09-01") , fileType = bioFileTypes[0] ,
                    path= "C:\\Files\\Patients\\Scans\\Story00001.doc", patient = patients[0]},

                new BioFile{ name="Passport", createDate=DateTime.Parse("2019-12-12") , fileType = bioFileTypes[1] ,
                    path= "C:\\Files\\Patients\\Scans\\Pass00002.jpg", patient = patients[1]},
                new BioFile{ name="Scan 2", createDate=DateTime.Parse("2020-03-04") , fileType = bioFileTypes[2] ,
                    path= "C:\\Files\\Patients\\Scans\\Scan00002.scn", patient = patients[1]},
                new BioFile{ name="Scan 3", createDate=DateTime.Parse("2020-05-04") , fileType = bioFileTypes[2] ,
                    path= "C:\\Files\\Patients\\Scans\\Scan00003.scn", patient = patients[1]},
                new BioFile{ name="Medical history 1", createDate=DateTime.Parse("2019-12-12") , fileType = bioFileTypes[0] ,
                    path= "C:\\Files\\Patients\\Scans\\Story00002.doc", patient = patients[1]}
            };

            foreach (BioFile f in files)
            {
                context.Files.Add(f);
            }*/
            context.SaveChanges();
            #endregion
            #region Analisis
           /* var analises = new Analysis[]
           {
                new Analysis{ patient = patients[0] , bioSample = Biosample.Biopsy, DateOfAnalysis = DateTime.Now,
                 DateOfBiosampleCollecting = DateTime.Parse("2005-09-01"), doctor = doctors[0], earlyMetastasis= true,
                 lateMetastasis = false, melanomaConfirmedEarlyStage = true, melanomaType = melanomaTypes[0],
                 preventiveCare = true, AnalysisIsPerformedBy = "Родинка на шее сильно увеличилась", number = "001"},
                new Analysis{ patient = patients[1] , bioSample = Biosample.PeripheralBlood, DateOfAnalysis = DateTime.Now,
                 DateOfBiosampleCollecting = DateTime.Parse("2020-03-01"), doctor = doctors[1], earlyMetastasis= false,
                 lateMetastasis = false, melanomaConfirmedEarlyStage = true, melanomaType = melanomaTypes[1],
                 preventiveCare = true, AnalysisIsPerformedBy = "Появилась новая родинка ", number = "002"},
                new Analysis{ patient = patients[2] , bioSample = Biosample.PeripheralBlood, DateOfAnalysis = DateTime.Now,
                 DateOfBiosampleCollecting = DateTime.Parse("2019-03-01"), doctor = doctors[2], earlyMetastasis= false,
                 lateMetastasis = false, melanomaConfirmedEarlyStage = true, melanomaType = melanomaTypes[2],
                 preventiveCare = true, AnalysisIsPerformedBy = "Увеличение родимого пятна ", number = "003"},
                new Analysis{ patient = patients[0] , bioSample = Biosample.Biopsy, DateOfAnalysis = DateTime.Now,
                 DateOfBiosampleCollecting = DateTime.Parse("2018-03-01"), doctor = doctors[3], earlyMetastasis= false,
                 lateMetastasis = false, melanomaConfirmedEarlyStage = true, melanomaType = melanomaTypes[3],
                 preventiveCare = true, AnalysisIsPerformedBy = "Увеличение родимого пятна вдвое ", number = "004"},
           };
            foreach (Analysis a in analises)
            {
                context.Analysis.Add(a);
            }*/
            context.SaveChanges();
            #endregion
            #region KITMakers
            /*var KITMakers = new KITMarker[]
            {
                new KITMarker{ name = "BRAF-V600E", analysis= analises[0], absent = true, heterozygosity = true, homozygosity = true, NA= true,
                    description= "In skin melanoma the mutations are observed in the genes BRAF (50 %), NRAS (20 %), and the mutations of NRAS are characteristics for melanoma of sun - exposed sites.Activated mutations of BRAF are observed in 30–60 % cases of melanoma skin(Thomaset al., 2015, Omholt et al., 2003).The mutations of BRAF are founded in 59 % cases of melanoma skin, that is not chronicsun - damaged, whereas chronic sun - damaged melanoma – 11 % m acral melanoma –23 %, nucosal melanoma – 11 % (Davies M.A., Samuels Y. 2010.Analysis of the genometo personalize therapy for melanoma.Oncogene 29(41): 5545–5555).It is important that mutations of the gene BRAF is founded in 70 % cases of nonpigmented melanoma, and in 89 % cases the tumor has thickness less than 1 mm.Patients with melanoma and mutations of the gene BRAF are statistically younger thanthe patients have mutations of the gene NRAS.Known important mutations of the gene: V600E / V600К(exon 15).",
                    type = KITTypeTypes[4]},
                new KITMarker{ name = "NRAS-Q61K", analysis= analises[0], absent = false, heterozygosity = false, homozygosity = false, NA= false,
                    description= "It is the second gene that often undergoes by mutations in melanoma (Mazurenko N.N. 2014. Genetic alterations and markers of melanoma. Advances in molecular oncology, 2: 26–35). The mutation of NRAS are revealed in 13 - 20 % cases of skin melanoma(Kelleher F.C.,    McArthur G.A. 2012.Targeting NRAS in melanoma.Cancer J. 18(2): 132–136; Thomas et al., 2015, Omholt et al., 2003).The mutations of third exon of NRAS are observed in the later stages of melanomadevelopment and supposedly they are involved in melanoma metastasis(FedorenkoI.V., Gibney G.T., Keiran S.M. 2013.NRAS mutant melanoma: biological behavior andfuture strategies for therapeutic management. Oncogene 32(25): 3009–3018).The mutations of NRAS present in melanoma that is connected with Chronic sundamaged(Curtin J. A., Fridlyand J., Kageshita T. et al. 2005.Distinct sets of geneticalterations in melanoma.N Engl J Med. 353(20): 2135–2147).Known important mutations of the gene: Q61K, Q61R / Q61H / Q61L(3 exon) and exon 2(codons 12 & 13)",
                    type = KITTypeTypes[3]},
                new KITMarker{ name = "KIT-K558R", analysis= analises[0], absent = false, heterozygosity = true, homozygosity = false, NA= false,
                    description= "The mutations of KIT are often observed in melanoma of skin that is under chronic UVradiation. The KIT mutations are not occurred together with genes NRAS and BRAF (that is why it is important to include this gene). Activate mutations of KIT are found in 2-6% cases of superficial melanoma, however the mutations and amplifications of KIT are observed in 23-36% cases in acral melanoma, 28% -sun-exposed melanoma (Curtin J. A., Busam K., Pinkel D., Bastian B.C. 2006. Somatic activation of KIT in distinct subtypes of melanoma. J. Clin. Oncol. 24 (26): 4340–6434; Beadling C., JacobsonDunlop E., Hodi F.S.et al. 2008.KIT gene mutations and copy number in melanoma subtypes.Clin.Cancer Res. 14(21): 6821–6828). Known important mutations of the gene: K558R, T574A, L576P, V559A, L576P.",
                    type = KITTypeTypes[2]},
                new KITMarker{ name = "CDKN2A-G101W", analysis= analises[1], absent = true, heterozygosity = false, homozygosity = false, NA= false,
                    description= "The CDKN2A mutations are observed in 20-40% cases of family melanoma. It is good and well-known marker. Known important mutation of the gene: G101W",
                    type = KITTypeTypes[1]},
                new KITMarker{ name = "MC1R-V60L", analysis= analises[2], absent = true, heterozygosity = false, homozygosity = false, NA= false,
                    description= "The presence of SNIP-variant of MC1R in addition to mutations of CDKN2A and significantly increase the risk of melanoma development, in comparison with presence of sole mutated CDKN2A. That is why it is important to include the pair of genes – CDNK2A and MC1R. The patients with mutated MC1R have the risk of melanoma development in 5-15 times larger together with mutation of BRAF and it not depends on UV-radiation (Fargnoli M.C., Gandini S., Peris K. et al. 2010. MC1R variants increase melanoma risk in families with CDKN2A mutations: a metaanalysis. Eur. J. Cancer 46 (8):1413–142). Known important mutations of the gene: V60L, D84E / R151C / R160W / R163Q",
                    type = KITTypeTypes[0]}
            };
            foreach (KITMarker kitmar in KITMakers)
            {
                context.KITMarker.Add(kitmar);
            }*/
            context.SaveChanges();
            #endregion
            #region PatientGroup
            var PatientGroup = new PatientGroup[]
            {
                new PatientGroup{ name = "Женщины"},
                new PatientGroup{ name = "Мужчины"},
                new PatientGroup{ name = "Дети 1 - 14 дней"},
                new PatientGroup{ name = "Дети 14 дней - 4,3 недели"},
                new PatientGroup{ name = "Дети 4,3 недели - 8,6 недели"},
                new PatientGroup{ name = "Дети 8,6 недели - 4 месяца"},
                new PatientGroup{ name = "Дети 4 месяца - 6 месяцев"},
                new PatientGroup{ name = "Дети 6 месяцев - 9 месяцев"},
                new PatientGroup{ name = "Дети 9 месяцев - 12 месяцев"},
                new PatientGroup{ name = "Дети 12 месяцев - 3 года"},
                new PatientGroup{ name = "Дети 3 года - 6 лет"},
                new PatientGroup{ name = "Дети 6 лет - 9 лет"},
                new PatientGroup{ name = "Дети 9 лет - 15 лет"},

            };
            foreach (PatientGroup patientgroup in PatientGroup)
            {
                context.PatientGroup.Add(patientgroup);
            }
            context.SaveChanges();
            #endregion
            #region AnalysisMarker
            var AnalysisMarker = new AnalysisMarker[]
            {
                new AnalysisMarker{probability = 0.1, orderRank = 1, name = "Гемоглобин", nameEn="Hemoglobin", measure= "г/дл", measureEn="g/dl", analysisType = AnalysisType.CommonBloodAnalysis},
                new AnalysisMarker{probability = 0.1, orderRank = 2, name = "Гематокрит", nameEn="Hematocrit", measure= "%", measureEn="%", analysisType = AnalysisType.CommonBloodAnalysis},                
                new AnalysisMarker{probability = 0.1, orderRank = 3, name = "Эритроциты", nameEn="Red blood cells", measure= "млн/мкл", measureEn="ppm", analysisType = AnalysisType.CommonBloodAnalysis},
                new AnalysisMarker{probability = 0.1, orderRank = 4, name = "Цветовой показатель", nameEn="Color indicator", measure= "", measureEn="", analysisType = AnalysisType.CommonBloodAnalysis},
                new AnalysisMarker{probability = 0.1, orderRank = 5, name = "Ретикулоциты", nameEn="Reticulocytes", measure= "%", measureEn="%", analysisType = AnalysisType.CommonBloodAnalysis},
                new AnalysisMarker{probability = 0.1, orderRank = 6, name = "Тромбоциты", nameEn="Platelets", measure= "тыс/мкл", measureEn="thousand/µl", analysisType = AnalysisType.CommonBloodAnalysis},
                new AnalysisMarker{probability = 0.1, orderRank = 7, name = "СОЭ", nameEn="ESR",  measure= "мм/ч", measureEn="mm/h", analysisType = AnalysisType.CommonBloodAnalysis},
                new AnalysisMarker{probability = 0.1, orderRank = 8, name = "Лейкоциты", nameEn="Leukocytes", measure= "тыс/мкл", measureEn="thousand/µl", analysisType = AnalysisType.CommonBloodAnalysis},
                new AnalysisMarker{probability = 0.1, orderRank = 9, name = "Палочкоядерные гранулоциты", nameEn="Band granulocytes", measure= "%", measureEn="%", analysisType = AnalysisType.CommonBloodAnalysis},
                new AnalysisMarker{probability = 0.1, orderRank = 10, name = "Сегментоядерные гранулоциты", nameEn="Segmented granulocytes", measure= "%", measureEn="%", analysisType = AnalysisType.CommonBloodAnalysis},
                new AnalysisMarker{probability = 0.1, orderRank = 11, name = "Эозинофилы", nameEn="Eosinophils", measure= "%", measureEn="%", analysisType = AnalysisType.CommonBloodAnalysis},
                new AnalysisMarker{probability = 0.1, orderRank = 12, name = "Базофилы", nameEn="Basophils", measure= "%", measureEn="%", analysisType = AnalysisType.CommonBloodAnalysis},
                new AnalysisMarker{probability = 0.1, orderRank = 13, name = "Лимфоциты", nameEn="Lymphocytes", measure= "%", measureEn="%", analysisType = AnalysisType.CommonBloodAnalysis},
                new AnalysisMarker{probability = 0.1, orderRank = 14, name = "Моноциты", nameEn="Monocytes", measure= "%", measureEn="%", analysisType = AnalysisType.CommonBloodAnalysis},
                new AnalysisMarker{probability = 0.1, orderRank = 15, name = "Метамиелоциты", nameEn="Metamyelocytes", measure= "", measureEn="", analysisType = AnalysisType.CommonBloodAnalysis, dataType=DataType.Bool},
                new AnalysisMarker{probability = 0.1, orderRank = 16, name = "Миелоциты", nameEn="Myelocytes", measure= "", measureEn="", analysisType = AnalysisType.CommonBloodAnalysis, dataType=DataType.Bool},
                
                
                new AnalysisMarker{probability = 0.3, orderRank = 1, name = "BRAF p.V600E (c.1799T>A)", nameEn="BRAF p.V600E (c.1799T>A)", measure= "", measureEn="", analysisType = AnalysisType.GeneticAnalysis, dataType=DataType.Bool},
                new AnalysisMarker{probability = 0.3, orderRank = 2, name = "NRAS p.Q61H (c.183R>Y)", nameEn="NRAS p.Q61H (c.183R>Y)", measure= "", measureEn="", analysisType = AnalysisType.GeneticAnalysis, dataType=DataType.Bool},
                new AnalysisMarker{probability = 0.3, orderRank = 3, name = "NRAS p.Q61R (c.182A>G)", nameEn="NRAS p.Q61R (c.182A>G)", measure= "", measureEn="", analysisType = AnalysisType.GeneticAnalysis, dataType=DataType.Bool},
                new AnalysisMarker{probability = 0.3, orderRank = 4, name = "NRAS p.Q61L (c.182A>T)", nameEn="NRAS p.Q61L (c.182A>T)", measure= "", measureEn="", analysisType = AnalysisType.GeneticAnalysis, dataType=DataType.Bool},
                new AnalysisMarker{probability = 0.5, orderRank = 5, name = "NRAS p.Q61K (c.181C>A)", nameEn="NRAS p.Q61K (c.181C>A)", measure= "", measureEn="", analysisType = AnalysisType.GeneticAnalysis, dataType=DataType.Bool},
                new AnalysisMarker{probability = 0.5, orderRank = 6, name = "NRAS p.G12D (c.35G>A)", nameEn="NRAS p.G12D (c.35G>A)", measure= "", measureEn="", analysisType = AnalysisType.GeneticAnalysis, dataType=DataType.Bool},
                new AnalysisMarker{probability = 0.5, orderRank = 7, name = "NRAS р.G12A (c.35G>C)", nameEn="NRAS р.G12A (c.35G>C)", measure= "", measureEn="", analysisType = AnalysisType.GeneticAnalysis, dataType=DataType.Bool},
                new AnalysisMarker{probability = 0.5, orderRank = 8, name = "NRAS р.G12V (c. 35G>T)", nameEn="NRAS р.G12V (c. 35G>T)", measure= "", measureEn="", analysisType = AnalysisType.GeneticAnalysis, dataType=DataType.Bool},
                new AnalysisMarker{probability = 0.5, orderRank = 9, name = "NRAS G12R (c.34G>C) C>A,G,T", nameEn="NRAS G12R (c.34G>C) C>A,G,T", measure= "", measureEn="", analysisType = AnalysisType.GeneticAnalysis, dataType=DataType.Bool},
                new AnalysisMarker{probability = 0.5, orderRank = 10, name = "NRAS G12S (c.34G>A) C>A,G,T", nameEn="NRAS G12S (c.34G>A) C>A,G,T", measure= "", measureEn="", analysisType = AnalysisType.GeneticAnalysis, dataType=DataType.Bool},
                new AnalysisMarker{probability = 0.5, orderRank = 11, name = "NRAS G12C (c.34G>T) C>A,G,T", nameEn="NRAS G12C (c.34G>T) C>A,G,T", measure= "", measureEn="", analysisType = AnalysisType.GeneticAnalysis, dataType=DataType.Bool},
                new AnalysisMarker{probability = 0.7, orderRank = 12, name = "KIT p.V560D (c.1679T>A)", nameEn="KIT p.V560D (c.1679T>A)", measure= "", measureEn="", analysisType = AnalysisType.GeneticAnalysis, dataType=DataType.Bool},
                new AnalysisMarker{probability = 0.7, orderRank = 13, name = "KIT p.L576P (c.1727T>C)", nameEn="KIT p.L576P (c.1727T>C)", measure= "", measureEn="", analysisType = AnalysisType.GeneticAnalysis, dataType=DataType.Bool},
                new AnalysisMarker{probability = 0.7, orderRank = 14, name = "KIT p.K642E (c.1924A>G)", nameEn="KIT p.K642E (c.1924A>G)", measure= "", measureEn="", analysisType = AnalysisType.GeneticAnalysis, dataType=DataType.Bool},
                new AnalysisMarker{probability = 0.7, orderRank = 15, name = "KIT p.D816H (c.2446G>C)", nameEn="KIT p.D816H (c.2446G>C)", measure= "", measureEn="", analysisType = AnalysisType.GeneticAnalysis, dataType=DataType.Bool},
                new AnalysisMarker{probability = 0.7, orderRank = 16, name = "KIT p.N822K (c.2466T>A)", nameEn="KIT p.N822K (c.2466T>A)", measure= "", measureEn="", analysisType = AnalysisType.GeneticAnalysis, dataType=DataType.Bool},
                new AnalysisMarker{probability = 0.7, orderRank = 17, name = "MC1R p.V60L (c.178G>C) и НЕ p.V60L/F (c.178G>T)", nameEn="MC1R p.V60L (c.178G>C) и НЕ p.V60L/F (c.178G>T)", measure= "", measureEn="", analysisType = AnalysisType.GeneticAnalysis, dataType=DataType.Bool},
                new AnalysisMarker{probability = 0.7, orderRank = 18, name = "MC1R p.D84E (c.252C>A)", nameEn="MC1R p.D84E (c.252C>A)", measure= "", measureEn="", analysisType = AnalysisType.GeneticAnalysis, dataType=DataType.Bool},
                new AnalysisMarker{probability = 0.7, orderRank = 19, name = "MC1R p.V92M (c.274G>A)", nameEn="MC1R p.V92M (c.274G>A)", measure= "", measureEn="", analysisType = AnalysisType.GeneticAnalysis, dataType=DataType.Bool},
                new AnalysisMarker{probability = 0.7, orderRank = 20, name = "MC1R p.R142H (c.425G>A)", nameEn="MC1R p.R142H (c.425G>A)", measure= "", measureEn="", analysisType = AnalysisType.GeneticAnalysis, dataType=DataType.Bool},
                new AnalysisMarker{probability = 0.7, orderRank = 21, name = "MC1R p.R151C (c.451C>T)", nameEn="MC1R p.R151C (c.451C>T)", measure= "", measureEn="", analysisType = AnalysisType.GeneticAnalysis, dataType=DataType.Bool},
                new AnalysisMarker{probability = 0.7, orderRank = 22, name = "MC1R p.I155T (c.464T>C)", nameEn="MC1R p.I155T (c.464T>C)", measure= "", measureEn="", analysisType = AnalysisType.GeneticAnalysis, dataType=DataType.Bool},
                new AnalysisMarker{probability = 0.7, orderRank = 23, name = "MC1R p.R160W/C/* (c.478C>T)", nameEn="MC1R p.R160W/C/* (c.478C>T)", measure= "", measureEn="", analysisType = AnalysisType.GeneticAnalysis, dataType=DataType.Bool},
                new AnalysisMarker{probability = 0.7, orderRank = 24, name = "MC1R p.R163Q (c.488G>A)", nameEn="MC1R p.R163Q (c.488G>A)", measure= "", measureEn="", analysisType = AnalysisType.GeneticAnalysis, dataType=DataType.Bool},
                new AnalysisMarker{probability = 0.7, orderRank = 25, name = "MC1R p.D294H (c.880G>C)", nameEn="MC1R p.D294H (c.880G>C)", measure= "", measureEn="", analysisType = AnalysisType.GeneticAnalysis, dataType=DataType.Bool},
                new AnalysisMarker{probability = 0.7, orderRank = 26, name = "MITF p.E318K (c.952G>A)изоформа 4", nameEn="MITFp.E318K (c.952G>A)изоформа 4", measure= "", measureEn="", analysisType = AnalysisType.GeneticAnalysis, dataType=DataType.Bool},
                new AnalysisMarker{probability = 0.7, orderRank = 27, name = "CDKN2A p.P114L (c.341C>T)", nameEn="CDKN2A p.P114L (c.341C>T)", measure= "", measureEn="", analysisType = AnalysisType.GeneticAnalysis, dataType=DataType.Bool},
                new AnalysisMarker{probability = 0.7, orderRank = 28, name = "CDKN2A p.W110* (c.330G>A)", nameEn="CDKN2A p.W110* (c.330G>A)", measure= "", measureEn="", analysisType = AnalysisType.GeneticAnalysis, dataType=DataType.Bool},
                new AnalysisMarker{probability = 0.7, orderRank = 29, name = "CDKN2A p.W110* (c.329G>A)", nameEn="CDKN2A p.W110* (c.329G>A)", measure= "", measureEn="", analysisType = AnalysisType.GeneticAnalysis, dataType=DataType.Bool},
                new AnalysisMarker{probability = 0.7, orderRank = 30, name = "CDKN2A p.R80* (c.238C>T)", nameEn="CDKN2A p.R80* (c.238C>T)", measure= "", measureEn="", analysisType = AnalysisType.GeneticAnalysis, dataType=DataType.Bool},
                new AnalysisMarker{probability = 0.7, orderRank = 31, name = "CDKN2A c.237_238 indel TT", nameEn="CDKN2A c.237_238 indel TT", measure= "", measureEn="", analysisType = AnalysisType.GeneticAnalysis, dataType=DataType.Bool},
                new AnalysisMarker{probability = 0.7, orderRank = 32, name = "CDKN2A p.R58* (c.172C>T)", nameEn="CDKN2A p.R58* (c.172C>T)", measure= "", measureEn="", analysisType = AnalysisType.GeneticAnalysis, dataType=DataType.Bool},
                new AnalysisMarker{probability = 0.7, orderRank = 33, name = "CDKN2A c.171_172 indel TT", nameEn="CDKN2A c.171_172 indel TT", measure= "", measureEn="", analysisType = AnalysisType.GeneticAnalysis, dataType=DataType.Bool},
                new AnalysisMarker{probability = 0.7, orderRank = 34, name = "CDKN2A p.Q50* (c.148C>T)", nameEn="CDKN2A p.Q50* (c.148C>T)", measure= "", measureEn="", analysisType = AnalysisType.GeneticAnalysis, dataType=DataType.Bool},
                new AnalysisMarker{probability = 0.7, orderRank = 35, name = "CDKN2A p.P48L (c.143C>T", nameEn="CDKN2A p.P48L (c.143C>T", measure= "", measureEn="", analysisType = AnalysisType.GeneticAnalysis, dataType=DataType.Bool},
                new AnalysisMarker{probability = 0.7, orderRank = 36, name = "NF1 p.E230K (c.688G>A)", nameEn="NF1 p.E230K (c.688G>A)", measure= "", measureEn="", analysisType = AnalysisType.GeneticAnalysis, dataType=DataType.Bool},
                new AnalysisMarker{probability = 0.7, orderRank = 37, name = "NF1 p.Q282* (c.844C>T)", nameEn="NF1 p.Q282* (c.844C>T)", measure= "", measureEn="", analysisType = AnalysisType.GeneticAnalysis, dataType=DataType.Bool},
                new AnalysisMarker{probability = 0.7, orderRank = 38, name = "NF1 p.R440* (c.1318C>T)", nameEn="NF1 p.R440* (c.1318C>T)", measure= "", measureEn="", analysisType = AnalysisType.GeneticAnalysis, dataType=DataType.Bool},
                new AnalysisMarker{probability = 0.7, orderRank = 39, name = "NF1 p.L844F (c.2530C>T)", nameEn="NF1 p.L844F (c.2530C>T)", measure= "", measureEn="", analysisType = AnalysisType.GeneticAnalysis, dataType=DataType.Bool},
                new AnalysisMarker{probability = 0.7, orderRank = 40, name = "NF1 R1362* (c.4084C>T)", nameEn="NF1 R1362* (c.4084C>T)", measure= "", measureEn="", analysisType = AnalysisType.GeneticAnalysis, dataType=DataType.Bool},
                new AnalysisMarker{probability = 0.7, orderRank = 41, name = "NF1 p.Q2239* (c.6715C>T) [c.6652C > T(p.Gln2218Ter)]", nameEn="NF1 p.Q2239* (c.6715C>T) [c.6652C > T(p.Gln2218Ter)]", measure= "", measureEn="", analysisType = AnalysisType.GeneticAnalysis, dataType=DataType.Bool},
                



                //new AnalysisMarker{ name = "Cредний объем эритроцитов", nameEn="Mean Cell volume MCV", measure= "млн/мкл", measureEn="ppm", analysisType = AnalysisType.CommonBloodAnalysis},
                //new AnalysisMarker{ name = "Ширина распределения эритроцитов", nameEn="Red cell Distribution Width RDW",
                //    measure= "%", measureEn="%", analysisType = AnalysisType.CommonBloodAnalysis},
                //new AnalysisMarker{ name = "Среднее содержание гемоглобина в эритроцитах", nameEn="Mean Cell Hemoglobin",
                //    measure= "пг", measureEn="pg", analysisType = AnalysisType.CommonBloodAnalysis},
                //new AnalysisMarker{ name = "Средняя концентрация гемоглобина в эритроцитах", nameEn="Mean Cell Hemoglobin Concentration",
                //    measure= "г/дл", measureEn="g/dl", analysisType = AnalysisType.CommonBloodAnalysis},                 
                // new AnalysisMarker{ name = "Нейтрофилы(общее число)", nameEn="Neutrophils (total)", measure= "%", measureEn="%", analysisType = AnalysisType.CommonBloodAnalysis},
                // new AnalysisMarker{ name = "Нейтрофилы, абс.", nameEn="Neutrophils abs",  measure= "тыс/мкл", measureEn="thousand/µl", analysisType = AnalysisType.CommonBloodAnalysis},
                // new AnalysisMarker{ name = "Лимфоциты, абс.", nameEn="Lymphocytes abs",  measure= "тыс/мкл", measureEn="thousand/µl", analysisType = AnalysisType.CommonBloodAnalysis},
                // new AnalysisMarker{ name = "Моноциты, абс.", nameEn="Monocytes abs",  measure= "тыс/мкл", measureEn="thousand/µl", analysisType = AnalysisType.CommonBloodAnalysis},
                // new AnalysisMarker{ name = "Эозинофилы, абс.", nameEn="Eosinophils abs",  measure= "тыс/мкл", measureEn="thousand/µl", analysisType = AnalysisType.CommonBloodAnalysis},
                // new AnalysisMarker{ name = "Базофилы, абс.", nameEn="Basophils abs",  measure= "тыс/мкл", measureEn="thousand/µl", analysisType = AnalysisType.CommonBloodAnalysis},
               
            };
            foreach (AnalysisMarker analysismarker in AnalysisMarker)
            {
                context.AnalysisMarker.Add(analysismarker);
            }
            context.SaveChanges();
            #endregion
            #region AnalysisMarkerNormValues
            var AnalysisMarkerNormValues = new AnalysisMarkerNormValue[]
            {
                new AnalysisMarkerNormValue{ PatientGroup = PatientGroup.FirstOrDefault(x => x.name == "Женщины"),
                    AnalysisMarker = AnalysisMarker.FirstOrDefault(x => x.name == "Гематокрит"), minValue = 36, maxValue = 42},
                new AnalysisMarkerNormValue{ PatientGroup = PatientGroup.FirstOrDefault(x => x.name == "Мужчины"),
                    AnalysisMarker = AnalysisMarker.FirstOrDefault(x => x.name == "Гематокрит"), minValue = 40, maxValue = 48},

                new AnalysisMarkerNormValue{ PatientGroup = PatientGroup.FirstOrDefault(x => x.name == "Женщины"),
                    AnalysisMarker = AnalysisMarker.FirstOrDefault(x => x.name == "Гемоглобин"), minValue = 120, maxValue = 140},
                new AnalysisMarkerNormValue{ PatientGroup = PatientGroup.FirstOrDefault(x => x.name == "Мужчины"),
                    AnalysisMarker = AnalysisMarker.FirstOrDefault(x => x.name == "Гемоглобин"), minValue = 135, maxValue = 160},

                new AnalysisMarkerNormValue{ PatientGroup = PatientGroup.FirstOrDefault(x => x.name == "Женщины"),
                    AnalysisMarker = AnalysisMarker.FirstOrDefault(x => x.name == "Эритроциты"), minValue = 3.9, maxValue = 4.7},
                new AnalysisMarkerNormValue{ PatientGroup = PatientGroup.FirstOrDefault(x => x.name == "Мужчины"),
                    AnalysisMarker = AnalysisMarker.FirstOrDefault(x => x.name == "Эритроциты"), minValue = 4, maxValue = 5},

                new AnalysisMarkerNormValue{ PatientGroup = PatientGroup.FirstOrDefault(x => x.name == "Женщины"),
                    AnalysisMarker = AnalysisMarker.FirstOrDefault(x => x.name == "Цветовой показатель"), minValue = 0.85, maxValue = 1.15},
                new AnalysisMarkerNormValue{ PatientGroup = PatientGroup.FirstOrDefault(x => x.name == "Мужчины"),
                    AnalysisMarker = AnalysisMarker.FirstOrDefault(x => x.name == "Цветовой показатель"), minValue = 0.85, maxValue = 1.15},

                new AnalysisMarkerNormValue{ PatientGroup = PatientGroup.FirstOrDefault(x => x.name == "Женщины"),
                    AnalysisMarker = AnalysisMarker.FirstOrDefault(x => x.name == "Ретикулоциты"), minValue = 0.2, maxValue = 1},
                new AnalysisMarkerNormValue{ PatientGroup = PatientGroup.FirstOrDefault(x => x.name == "Мужчины"),
                    AnalysisMarker = AnalysisMarker.FirstOrDefault(x => x.name == "Ретикулоциты"), minValue = 0.2, maxValue = 1},

                new AnalysisMarkerNormValue{ PatientGroup = PatientGroup.FirstOrDefault(x => x.name == "Женщины"),
                    AnalysisMarker = AnalysisMarker.FirstOrDefault(x => x.name == "Тромбоциты"), minValue = 180, maxValue = 320},
                new AnalysisMarkerNormValue{ PatientGroup = PatientGroup.FirstOrDefault(x => x.name == "Мужчины"),
                    AnalysisMarker = AnalysisMarker.FirstOrDefault(x => x.name == "Тромбоциты"), minValue = 180, maxValue = 320},

                new AnalysisMarkerNormValue{ PatientGroup = PatientGroup.FirstOrDefault(x => x.name == "Женщины"),
                    AnalysisMarker = AnalysisMarker.FirstOrDefault(x => x.name == "СОЭ"), minValue = 2, maxValue = 15},
                new AnalysisMarkerNormValue{ PatientGroup = PatientGroup.FirstOrDefault(x => x.name == "Мужчины"),
                    AnalysisMarker = AnalysisMarker.FirstOrDefault(x => x.name == "СОЭ"), minValue = 1, maxValue = 10},

                new AnalysisMarkerNormValue{ PatientGroup = PatientGroup.FirstOrDefault(x => x.name == "Женщины"),
                    AnalysisMarker = AnalysisMarker.FirstOrDefault(x => x.name == "Лейкоциты"), minValue = 4, maxValue = 9},
                new AnalysisMarkerNormValue{ PatientGroup = PatientGroup.FirstOrDefault(x => x.name == "Мужчины"),
                    AnalysisMarker = AnalysisMarker.FirstOrDefault(x => x.name == "Лейкоциты"), minValue = 4, maxValue = 9},

                new AnalysisMarkerNormValue{ PatientGroup = PatientGroup.FirstOrDefault(x => x.name == "Женщины"),
                    AnalysisMarker = AnalysisMarker.FirstOrDefault(x => x.name == "Палочкоядерные гранулоциты"), minValue = 1, maxValue = 6},
                new AnalysisMarkerNormValue{ PatientGroup = PatientGroup.FirstOrDefault(x => x.name == "Мужчины"),
                    AnalysisMarker = AnalysisMarker.FirstOrDefault(x => x.name == "Палочкоядерные гранулоциты"), minValue = 1, maxValue = 6},
                               
                new AnalysisMarkerNormValue{ PatientGroup = PatientGroup.FirstOrDefault(x => x.name == "Женщины"),
                    AnalysisMarker = AnalysisMarker.FirstOrDefault(x => x.name == "Сегментооядерные гранулоциты"), minValue = 47, maxValue = 72},
                new AnalysisMarkerNormValue{ PatientGroup = PatientGroup.FirstOrDefault(x => x.name == "Мужчины"),
                    AnalysisMarker = AnalysisMarker.FirstOrDefault(x => x.name == "Сегментооядерные гранулоциты"), minValue = 47, maxValue = 72},

                new AnalysisMarkerNormValue{ PatientGroup = PatientGroup.FirstOrDefault(x => x.name == "Женщины"),
                    AnalysisMarker = AnalysisMarker.FirstOrDefault(x => x.name == "Эозинофилы"), minValue = 0.5, maxValue = 5},
                new AnalysisMarkerNormValue{ PatientGroup = PatientGroup.FirstOrDefault(x => x.name == "Мужчины"),
                    AnalysisMarker = AnalysisMarker.FirstOrDefault(x => x.name == "Эозинофилы"), minValue = 0.5, maxValue = 5},

                new AnalysisMarkerNormValue{ PatientGroup = PatientGroup.FirstOrDefault(x => x.name == "Женщины"),
                    AnalysisMarker = AnalysisMarker.FirstOrDefault(x => x.name == "Базофилы"), minValue = 0, maxValue = 1},
                new AnalysisMarkerNormValue{ PatientGroup = PatientGroup.FirstOrDefault(x => x.name == "Мужчины"),
                    AnalysisMarker = AnalysisMarker.FirstOrDefault(x => x.name == "Базофилы"), minValue = 0, maxValue = 1},

                new AnalysisMarkerNormValue{ PatientGroup = PatientGroup.FirstOrDefault(x => x.name == "Женщины"),
                    AnalysisMarker = AnalysisMarker.FirstOrDefault(x => x.name == "Лимфоциты"), minValue = 18, maxValue = 40},
                new AnalysisMarkerNormValue{ PatientGroup = PatientGroup.FirstOrDefault(x => x.name == "Мужчины"),
                    AnalysisMarker = AnalysisMarker.FirstOrDefault(x => x.name == "Лимфоциты"), minValue = 18, maxValue = 40},

                new AnalysisMarkerNormValue{ PatientGroup = PatientGroup.FirstOrDefault(x => x.name == "Женщины"),
                    AnalysisMarker = AnalysisMarker.FirstOrDefault(x => x.name == "Моноциты"), minValue = 2, maxValue = 9},
                new AnalysisMarkerNormValue{ PatientGroup = PatientGroup.FirstOrDefault(x => x.name == "Мужчины"),
                    AnalysisMarker = AnalysisMarker.FirstOrDefault(x => x.name == "Моноциты"), minValue = 2, maxValue = 9},
                 new AnalysisMarkerNormValue{ PatientGroup = PatientGroup.FirstOrDefault(x => x.name == "Женщины"),
                    AnalysisMarker = AnalysisMarker.FirstOrDefault(x => x.name == "Метамиелоциты"), minValue = 0, maxValue = 1},
                new AnalysisMarkerNormValue{ PatientGroup = PatientGroup.FirstOrDefault(x => x.name == "Мужчины"),
                    AnalysisMarker = AnalysisMarker.FirstOrDefault(x => x.name == "Метамиелоциты"), minValue = 0, maxValue = 1},

                new AnalysisMarkerNormValue{ PatientGroup = PatientGroup.FirstOrDefault(x => x.name == "Женщины"),
                    AnalysisMarker = AnalysisMarker.FirstOrDefault(x => x.name == "Миелоциты"), minValue = 0, maxValue = 1},
                new AnalysisMarkerNormValue{ PatientGroup = PatientGroup.FirstOrDefault(x => x.name == "Мужчины"),
                    AnalysisMarker = AnalysisMarker.FirstOrDefault(x => x.name == "Миелоциты"), minValue = 0, maxValue = 1},


            };
            foreach (AnalysisMarkerNormValue norm in AnalysisMarkerNormValues)
            {
                context.AnalysisMarkerNormValue.Add(norm);
            }
            context.SaveChanges();
            #endregion
            //#region TypeAnalysis
            //TypeAnalysis commonBlood = new TypeAnalysis { Name = "Общий анализ крови", markers = AnalysisMarker.ToList() };
            //var TypeAnalysis = new TypeAnalysis[]
            //{
            //     commonBlood,
            //};
            //foreach (AnalysisMarker analysismarker in AnalysisMarker)
            //{
            //    context.AnalysisMarker.Add(analysismarker);
            //}

            //context.SaveChanges();
            //foreach (AnalysisMarker analysismarker in context.AnalysisMarker)
            //{
            //    analysismarker.typeAnalysis.Add(commonBlood);
            //}
            //context.SaveChanges();
            //#endregion
        }
    }
}

