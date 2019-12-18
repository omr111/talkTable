namespace talkTable.Entities.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("howIsWorkStep")]
    public partial class howIsWorkStep
    {
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string stepText { get; set; }

        public int? howIsWorkId { get; set; }

        public virtual howIsWork howIsWork { get; set; }
    }
}
