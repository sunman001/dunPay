using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DunxPay.ViewModel.EasyuiModel
{
   public   class ComboboxModel
    {
        /// <summary>
        /// EasyUI Combobox 组合框 model
        /// </summary>
        public ComboboxModel()
        {
            Selected = false;
        }
        /// <summary>
        ///valueField
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// textField
        /// </summary>
        public string  Text { get; set; }

        /// <summary>
        /// 是否选中
        /// </summary>
        public bool Selected { get; set; }
    }
}
