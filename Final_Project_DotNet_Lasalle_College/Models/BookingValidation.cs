using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Final_Project_DotNet_Lasalle_College.Controllers
{
    public partial class BookingValidation
    {
        public class BookingValidationmetaData
        { 
            [DisplayName("Member Name:")]
            public Nullable<int> m_id { get; set; }

            [DisplayName("BookName:")]
            public Nullable<int> b_id { get; set; }
            public Nullable<System.DateTime> Date { get; set; }


        }
       
    }
}