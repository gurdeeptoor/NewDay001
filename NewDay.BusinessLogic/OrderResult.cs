﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewDay.BusinessLogic
{
    public class OrderResult
    {
        public string OrderId { get; set; }
        public int ItemsCount { get; set; }
        public double TotalPrice { get; set; }
    }
}