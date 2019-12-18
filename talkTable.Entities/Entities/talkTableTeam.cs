namespace talkTable.Entities.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("talkTableTeam")]
    public partial class talkTableTeam
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public talkTableTeam()
        {
            teamMember = new HashSet<teamMember>();
        }

        public int id { get; set; }

        [StringLength(200)]
        public string caption { get; set; }

        [StringLength(1000)]
        public string text { get; set; }

        [StringLength(50)]
        public string teamCaption { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<teamMember> teamMember { get; set; }
    }
}
