namespace talkTable.Entities.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("advantage")]
    public partial class advantage
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public advantage()
        {
            advantageLine = new HashSet<advantageLine>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string advantageCaption { get; set; }

        [StringLength(150)]
        public string advantagePictureUrl { get; set; }

        [StringLength(150)]
        public string pictureAlt { get; set; }

        public int? whatIsAdvantageId { get; set; }

        public virtual whatIsAdvantage whatIsAdvantage { get; set; }

        public virtual whatIsAdvantage whatIsAdvantage1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<advantageLine> advantageLine { get; set; }
    }
}
