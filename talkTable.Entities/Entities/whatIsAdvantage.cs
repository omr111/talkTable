namespace talkTable.Entities.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("whatIsAdvantage")]
    public partial class whatIsAdvantage
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public whatIsAdvantage()
        {
            advantage = new HashSet<advantage>();
            advantage1 = new HashSet<advantage>();
        }

        public int id { get; set; }

        [StringLength(150)]
        public string advantageCaption { get; set; }

        [StringLength(250)]
        public string advantageInfoText { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<advantage> advantage { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<advantage> advantage1 { get; set; }
    }
}
