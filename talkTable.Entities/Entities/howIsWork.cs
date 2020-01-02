namespace talkTable.Entities.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("howIsWork")]
    public partial class howIsWork
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public howIsWork()
        {
            howIsWorkPicture = new HashSet<howIsWorkPicture>();
            howIsWorkStep = new HashSet<howIsWorkStep>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(150)]
        public string captionText { get; set; }

        [Required]
        [StringLength(500)]
        public string InfoText { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<howIsWorkPicture> howIsWorkPicture { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<howIsWorkStep> howIsWorkStep { get; set; }
    }
}
