using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Final_Project_DotNet_Lasalle_College.Models
{
    [MetadataType(typeof(membersMetaData))]


    public partial class MemberValidation
    {

        public class membersMetaData
        {
            [DisplayName("Member Name:")]
            public string name { get; set; }
            [DisplayName("Member Address")]
            public string address { get; set; }
            

        }
    }
}