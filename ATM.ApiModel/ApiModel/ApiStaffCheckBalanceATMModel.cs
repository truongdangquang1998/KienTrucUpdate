﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiModel
{
    public class ApiStaffCheckBalanceATMModel : ApiJsonResult
    {
        public double AvailableBalanceATM { get; set; }
    }
}
