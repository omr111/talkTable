namespace talkTable.Entities.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("validitySection")]
    public partial class validitySection
    {
        public int id { get; set; }

        [StringLength(100)]
        public string caption { get; set; }

        [StringLength(250)]
        public string infoText { get; set; }

        public int? validityId { get; set; }

        public virtual validity validity { get; set; }
    }
}
