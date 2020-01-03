namespace talkTable.Entities.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("howIsWorkPicture")]
    public partial class howIsWorkPicture
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public howIsWorkPicture()
        {
            howIsWorkIcon = new HashSet<howIsWorkIcon>();
        }

        public int id { get; set; }

        [StringLength(150)]
        public string picturePath { get; set; }

        [StringLength(150)]
        public string pictureAlt { get; set; }

        public int? howIsWorkId { get; set; }

        [StringLength(250)]
        public string pictureText { get; set; }

        [StringLength(150)]
        public string stepText { get; set; }

        public virtual howIsWork howIsWork { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<howIsWorkIcon> howIsWorkIcon { get; set; }
    }
}
