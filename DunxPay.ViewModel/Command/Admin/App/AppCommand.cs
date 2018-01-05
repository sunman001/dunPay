using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DunxPay.ViewModel.Command.Admin.App
{
   public  class AppCommand:CommandBase
    {
       public string Paytype { get; set; }
       public string Rid { get; set; }
        public string Platformid { get; set; }
        public string Auditstate { get; set; }
        public string SeaName { get; set; }
        public string  Type { get; set; }
        public string  SelectState { get; set; }
        public string AppType { get; set; }
          
    }
}
