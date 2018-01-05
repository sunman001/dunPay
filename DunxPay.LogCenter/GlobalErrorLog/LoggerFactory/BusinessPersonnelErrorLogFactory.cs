﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DunxPay.LogCenter.GlobalErrorLog.LoggerModel;

namespace DunxPay.LogCenter.GlobalErrorLog.LoggerFactory
{
   public  class BusinessPersonnelErrorLogFactory:IAbstractErrorLogFactory
    {
        public IErrorLogger CreateErrorLogger(int UserId)
        {
            return new BusinessPersonnelErrorLogger(UserId);
        }
    }
}
