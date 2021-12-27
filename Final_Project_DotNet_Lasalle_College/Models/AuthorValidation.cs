using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Final_Project_DotNet_Lasalle_College
{
    [MetadataType(typeof(authorMetaData))]

    public partial class author
    {
        public class authorMetaData
        {
            [DisplayName("AuthorName:")]
            public string name { get; set; }
            [DisplayName("AuthorAddress:")]
            public string address { get; set; }
            [DisplayName("Phone:")]
            public string phone { get; set; }
        }
    }
}