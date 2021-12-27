using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Final_Project_DotNet_Lasalle_College.Models
{
    [MetadataType(typeof(BookInfoMetaData))]

    public partial class BookInfo
    {
        public class BookInfoMetaData
        {
            [DisplayName("BookName:")]
            public string b_name { get; set; }
            [DisplayName("Pages:")]
            public Nullable<int> pages { get; set; }

        }
    }
}