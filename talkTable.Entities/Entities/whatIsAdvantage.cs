namespace talkTable.Entities.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("whatIsAdvantage")]
    public partial class whatIsAdvantage
    {
        public int id { get; set; }

        [StringLength(150)]
        public string advantageCaption { get; set; }

        [StringLength(250)]
        public string advantageInfoText { get; set; }
    }
}
