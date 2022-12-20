﻿using eShopData.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopData.Entities
{
    public class Contact
    {
        public int ID {set; get;}
        public string Name {set; get;}
        public string Email {set; get;}
        public string PhoneNumber {set; get;}
        public string Message {set; get;}
        public Status Status { set; get; }

    }
}
