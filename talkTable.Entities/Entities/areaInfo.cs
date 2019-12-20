namespace talkTable.Entities.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("areaInfo")]
    public partial class areaInfo
    {
        public int id { get; set; }

        [Required]
        [StringLength(150)]
        public string areaInfoText { get; set; }

        public int usingAreaId { get; set; }

        public virtual usingArea usingArea { get; set; }
    }
}
