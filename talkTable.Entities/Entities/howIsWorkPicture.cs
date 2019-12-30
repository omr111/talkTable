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
        public int id { get; set; }

        [StringLength(150)]
        public string picturePath { get; set; }

        [StringLength(150)]
        public string pictureAlt { get; set; }

        public int? howIsWorkId { get; set; }

        [StringLength(250)]
        public string pictureText { get; set; }

        public virtual howIsWork howIsWork { get; set; }
    }
}
