using DunxPay.Domain.DunBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DunxPay.ViewModel.Command.Admin.App
{
 public    class AppRateSetupCommand
    {
        public AppRateSetupCommand()
        {
            AppRateList = new List<jmp_apprate>();
        }
        /// <summary>
        /// 应用ID
        /// </summary>
        public int Id { get; set; }
        public List<jmp_apprate> AppRateList { get; set; }

    }

   
}
