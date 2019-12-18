namespace talkTable.Entities.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("sendMail")]
    public partial class sendMail
    {
        public int id { get; set; }

        [Required]
        [StringLength(100)]
        public string nameSurname { get; set; }

        [Required]
        [StringLength(70)]
        public string mailAddress { get; set; }

        [Required]
        [StringLength(100)]
        public string companyName { get; set; }

        [Required]
        [StringLength(11)]
        public string phone { get; set; }

        [Required]
        public string mailText { get; set; }
    }
}
