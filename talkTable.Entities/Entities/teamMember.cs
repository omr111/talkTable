namespace talkTable.Entities.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("teamMember")]
    public partial class teamMember
    {
        public int id { get; set; }

        [Required]
        [StringLength(100)]
        public string name { get; set; }

        [Required]
        [StringLength(100)]
        public string job { get; set; }

      
        [StringLength(150)]
        public string picturePath { get; set; }

        [StringLength(150)]
        public string pictureAlt { get; set; }

        public int? talkTableTeamId { get; set; }

        public virtual talkTableTeam talkTableTeam { get; set; }
    }
}
