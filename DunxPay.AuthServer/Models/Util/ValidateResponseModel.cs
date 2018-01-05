using System.Collections.Generic;

namespace DunxPay.AuthServer.Models.Util
{
    /// <summary>
    /// 验证信息反馈实体类
    /// </summary>
    public class ValidateResponseModel
    {
        public ValidateResponseModel()
        {
            IsValid = false;
            Message = "";
            Messages = new List<string>();
        }
        /// <summary>
        /// 验证是否通过
        /// </summary>
        public bool IsValid { get; set; }
        /// <summary>
        /// 验证失败后的错误信息
        /// </summary>
        public string Message { get; set; }

        public List<string> Messages { get; set; }

        public void Invalid(string message)
        {
            IsValid = false;
            Messages.Add(message);
        }
    }
}