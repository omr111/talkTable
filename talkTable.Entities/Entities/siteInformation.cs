namespace talkTable.Entities.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("siteInformation")]
    public partial class siteInformation
    {
        public int id { get; set; }

        [StringLength(100)]
        public string siteName { get; set; }

        [Required]
        [StringLength(500)]
        public string whatIsThisSiteText1 { get; set; }

        [Required]
        [StringLength(500)]
        public string whatIsThisSiteText2 { get; set; }

        [StringLength(50)]
        public string logoPath { get; set; }

        [Required]
        [StringLength(70)]
        public string emailAddress { get; set; }

        [Required]
        [StringLength(15)]
        public string emailPassword { get; set; }

        [StringLength(11)]
        public string phone { get; set; }

        [StringLength(100)]
        public string faceUrl { get; set; }

        [StringLength(100)]
        public string twitterUrl { get; set; }

        [StringLength(100)]
        public string instagramUrl { get; set; }

        [StringLength(200)]
        public string address { get; set; }

        [StringLength(50)]
        public string sendMailCaption { get; set; }

        [StringLength(250)]
        public string sendMailSubText { get; set; }
    }
}
