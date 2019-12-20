using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Web;

namespace talkTable.MVCUI.App_Classes
{
    public class settings
    {
        public static Size bigLogo
        {
            get
            {
                Size sonuc = new Size();
                sonuc.Width = Convert.ToInt32(ConfigurationManager.AppSettings["bigLogoW"]);
                sonuc.Height = Convert.ToInt32(ConfigurationManager.AppSettings["bigLogoH"]);
                return sonuc;
            }

        }
        public static Size usingAreaPicture
        {
            get
            {
                Size sonuc = new Size();
                sonuc.Width = Convert.ToInt32(ConfigurationManager.AppSettings["usingAreaPictureW"]);
                sonuc.Height = Convert.ToInt32(ConfigurationManager.AppSettings["usingAreaPictureH"]);
                return sonuc;
            }

        }
    }
}