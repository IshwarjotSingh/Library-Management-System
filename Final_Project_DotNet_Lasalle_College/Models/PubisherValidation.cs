using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Final_Project_DotNet_Lasalle_College
{
    [MetadataType(typeof(publisherMetaData))]

    public partial class publisher
    {
        public class publisherMetaData
        {
            [DisplayName("Publisher Name:")]
            public string name { get; set; }
            [DisplayName("Publisher Address:")]
            public string address { get; set; }
            [DisplayName("Phone:")]
            public string phone { get; set; }
        }
    }
}