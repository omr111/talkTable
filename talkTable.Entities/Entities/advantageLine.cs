namespace talkTable.Entities.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("advantageLine")]
    public partial class advantageLine
    {
        public int id { get; set; }

        [Required]
        [StringLength(200)]
        public string advantageInfoText { get; set; }

        public int? advantageId { get; set; }

        public virtual advantage advantage { get; set; }
    }
}
