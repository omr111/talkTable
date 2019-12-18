namespace talkTable.Entities.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("bannerBoxInfo")]
    public partial class bannerBoxInfo
    {
        public int id { get; set; }

        [StringLength(50)]
        public string boxIconPath { get; set; }

        [Required]
        [StringLength(250)]
        public string boxInText { get; set; }

        [Required]
        [StringLength(15)]
        public string boxOnButtonValue { get; set; }

        [StringLength(50)]
        public string IconAlt { get; set; }

        public int? bannerId { get; set; }

        public virtual banner banner { get; set; }
    }
}
