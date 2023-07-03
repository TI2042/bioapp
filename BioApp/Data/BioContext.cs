using BioApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace BioApp.Data
{
    public class BioContext : IdentityDbContext<IdentityUser>
    {
        public BioContext(DbContextOptions<BioContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<BioFile> Files { get; set; }
        public DbSet<BioFileType> FileTypes { get; set; }
        public DbSet<MelanomaType> MelanomaTypes { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<BioApp.Models.DoctorSpecialization> DoctorSpecializations { get; set; }
        public DbSet<BioApp.Models.Doctor> Doctor { get; set; }
        public DbSet<BioApp.Models.Analysis> Analysis { get; set; }
        public DbSet<BioApp.Models.KITMarker> KITMarker { get; set; }
        public DbSet<BioApp.Models.KITType> KITType { get; set; }
        public DbSet<BioApp.Models.PatientGroup> PatientGroup { get; set; }
        public DbSet<BioApp.Models.AnalysisMarker> AnalysisMarker { get; set; }
        public DbSet<BioApp.Models.AnalysisMarkerNormValue> AnalysisMarkerNormValue { get; set; }
        public DbSet<BioApp.Models.AnalysisMarkerData> AnalysisMarkerData { get; set; }
        public DbSet<BioApp.Models.CommonAnalysis> CommonAnalysis { get; set; }
        public DbSet<BioApp.Models.MKBClassifier> MKBClassifier { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AnalysisMarkerData>().ToTable("AnalysisMarkerData");
            modelBuilder.Entity<BioFile>().ToTable("BioFile");
            modelBuilder.Entity<BioFileType>().ToTable("BioFileType");
            modelBuilder.Entity<MelanomaType>().ToTable("MelanomaType");
            modelBuilder.Entity<Patient>().ToTable("Patient");
            modelBuilder.Entity<Doctor>().ToTable("Doctor");
            modelBuilder.Entity<DoctorSpecialization>().ToTable("DoctorSpecialization");
            modelBuilder.Entity<Analysis>().ToTable("Analysis");
            modelBuilder.Entity<KITMarker>().ToTable("KITMarkers");
            modelBuilder.Entity<KITType>().ToTable("KITTypes");
            modelBuilder.Entity<CommonAnalysis>().ToTable("CommonAnalysis");
            modelBuilder.Entity<PatientGroup>().ToTable("PatientGroup");
            modelBuilder.Entity<AnalysisMarker>().ToTable("AnalysisMarker");
            modelBuilder.Entity<AnalysisMarkerNormValue>().ToTable("AnalysisMarkerNormValue");
            modelBuilder.Entity<AnalysisMarkerData>().ToTable("AnalysisMarkerData");
            modelBuilder.Entity<MKBClassifier>().ToTable("MKBClassifier");




        }


    }
}

