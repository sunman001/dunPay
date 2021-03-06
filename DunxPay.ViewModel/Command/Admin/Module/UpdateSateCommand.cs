﻿namespace DunxPay.ViewModel.Command.Admin.Module
{
    public class UpdateSateCommand 
    {
        /// <summary>
        /// 冻结启用状态
        /// </summary>
        public int SearchState { get; set; }

        /// <summary>
        /// ID字符串（用户批量操作）
        /// </summary>
        public string IdList { get; set; }
    }
}
