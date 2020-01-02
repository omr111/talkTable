namespace talkTable.Entities.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("howIsWorkIcon")]
    public partial class howIsWorkIcon
    {
        public int id { get; set; }

        [StringLength(150)]
        public string iconPath { get; set; }

        [StringLength(150)]
        public string iconAlt { get; set; }

        [StringLength(50)]
        public string iconText { get; set; }

        public int? howIsworkPictureId { get; set; }

        public virtual howIsWorkPicture howIsWorkPicture { get; set; }
    }
}
