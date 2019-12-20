namespace talkTable.Entities.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("validity")]
    public partial class validity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public validity()
        {
            validitySection = new HashSet<validitySection>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(250)]
        public string caption { get; set; }

        [Required]
        [StringLength(250)]
        public string infoText { get; set; }

        [StringLength(150)]
        public string validityPicturePath { get; set; }

        [StringLength(150)]
        public string pictureAlt { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<validitySection> validitySection { get; set; }
    }
}
