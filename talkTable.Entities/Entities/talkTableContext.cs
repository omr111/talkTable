namespace talkTable.Entities.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class talkTableContext : DbContext
    {
        public talkTableContext()
            : base("name=talkTableContext")
        {
        }

        public virtual DbSet<advantage> advantage { get; set; }
        public virtual DbSet<advantageLine> advantageLine { get; set; }
        public virtual DbSet<areaInfo> areaInfo { get; set; }
        public virtual DbSet<banner> banner { get; set; }
        public virtual DbSet<bannerBoxInfo> bannerBoxInfo { get; set; }
        public virtual DbSet<howIsWork> howIsWork { get; set; }
        public virtual DbSet<howIsWorkIcon> howIsWorkIcon { get; set; }
        public virtual DbSet<howIsWorkPicture> howIsWorkPicture { get; set; }
        public virtual DbSet<howIsWorkStep> howIsWorkStep { get; set; }
        public virtual DbSet<sendMail> sendMail { get; set; }
        public virtual DbSet<siteInformation> siteInformation { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<talkTableTeam> talkTableTeam { get; set; }
        public virtual DbSet<teamMember> teamMember { get; set; }
        public virtual DbSet<validity> validity { get; set; }
        public virtual DbSet<validitySection> validitySection { get; set; }
        public virtual DbSet<whatIsAdvantage> whatIsAdvantage { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<banner>()
                .Property(e => e.onBannerText)
                .IsFixedLength();

            modelBuilder.Entity<whatIsAdvantage>()
                .HasMany(e => e.advantage)
                .WithOptional(e => e.whatIsAdvantage)
                .HasForeignKey(e => e.whatIsAdvantageId);

            modelBuilder.Entity<whatIsAdvantage>()
                .HasMany(e => e.advantage1)
                .WithOptional(e => e.whatIsAdvantage1)
                .HasForeignKey(e => e.whatIsAdvantageId);
        }
    }
}
