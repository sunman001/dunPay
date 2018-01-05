using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DunxPay.ViewModel.Command.Admin.User
{
   public  class ComboListSearchCommand:CommandBase
    {
        public string SearchType { get; set; }

        public string Keyword { get; set; }
    }
}
