using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using talkTable.Entities.Entities;

namespace talkTable.MVCUI.Models
{
    public class bannerModels
    {
        public List<banner> banners { get; set; }
        public siteInformation site { get; set; }
    }
}