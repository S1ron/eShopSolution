﻿using eShopData.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopData.Entities
{
    public class Transaction
    {
        public int Id { set; get;}
        public DateTime TransactionDate { set; get;}
        public string ExternalTransactionId { set; get;}
        public decimal Amount { set; get;}
        public decimal Fee { set; get;}
        public string Result { set; get;}
        public string Message { set; get;}
        public TransactionStatus Status { set; get;}
        public string Provider { set; get; }
        public Guid UserId { set; get; }
        public AppUser AppUser { set; get; }

    }
}
