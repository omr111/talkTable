namespace talkTable.Entities.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("usingArea")]
    public partial class usingArea
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public usingArea()
        {
            areaInfo = new HashSet<areaInfo>();
            usingAreaPicture = new HashSet<usingAreaPicture>();
        }

        public int id { get; set; }

        [StringLength(50)]
        public string areaCaption { get; set; }

        [StringLength(500)]
        public string areaDescription { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<areaInfo> areaInfo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<usingAreaPicture> usingAreaPicture { get; set; }
    }
}
