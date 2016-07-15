using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace MedicalDb.Helpers
{
    public class Constants
    {
    }
    public static class FormConstants
    {
        public static string field1_label
        {
            get { return ConfigurationManager.AppSettings["field1"].ToString(); }
        }
        public static string field2_label
        {
            get { return ConfigurationManager.AppSettings["field2"].ToString(); }
        }
        public static string field3_label
        {
            get { return ConfigurationManager.AppSettings["field3"].ToString(); }
        }

    }
    public static class AppConstants
    {
        public static string DocumentsFolder
        {
            get { return ConfigurationManager.AppSettings["UploadDocumentsFolder"].ToString(); }
        }
        public static string ExprortTempFolder
        {
            get { return ConfigurationManager.AppSettings["TempFolder"].ToString(); }
        }
        public static string field3_label
        {
            get { return ConfigurationManager.AppSettings["field3"].ToString(); }
        } 
    }
}