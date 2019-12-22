namespace talkTable.Entities.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("banner")]
    public partial class banner
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public banner()
        {
            bannerBoxInfo = new HashSet<bannerBoxInfo>();
        }

        public int id { get; set; }

        [StringLength(150)]
        public string bannerPath { get; set; }

        [StringLength(100)]
        public string onBannerCaption { get; set; }

        [StringLength(250)]
        public string onBannerText { get; set; }

        [StringLength(50)]
        public string bannerAlt { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<bannerBoxInfo> bannerBoxInfo { get; set; }
    }
}
