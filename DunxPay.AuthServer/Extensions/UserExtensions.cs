using DunxPay.AuthServer.Models.Util;
using DunxPay.Core;
using DunxPay.ViewModel;
using System.Web;

namespace DunxPay.AuthServer.Extensions
{
    public static class UserExtensions
    {
        /// <summary>
        /// 用户登录验证
        /// </summary>
        /// <param name="model">用户视图实体类</param>
        /// <param name="inputPassword">用户输入的密码</param>
        /// <returns></returns>
        public static ValidateResponseModel LoginValidator(this LocalUserViewModel model, string inputPassword, string clientId)
        {
            var response = ValidateResponseModelFactory.Instance;
            response.IsValid = true;
            if (model == null)
            {
                response.Message = "登录名不存在";
                return response;
            }
            if (model.State == 0)
            {
                response.Message = "用户已被锁定";
            }
            //TODO:处理密码

            if (DesEncrypt.Encrypt(inputPassword) != model.Password)
            {
                response.Message = "密码不正确";
            }
            //if (model.ClientId != clientId)
            //{
            //    response.Message = "无效的客户端应用ID";
            //}
            if (response.Message.Length > 0)
            {
                response.IsValid = false;
            }
            return response;
        }
        /// <summary>
        /// 获取客户端IP地址（无视代理）
        /// </summary>
        /// <returns>若失败则返回回送地址</returns>
        public static string GetHostAddress()
        {
            string userHostAddress = HttpContext.Current.Request.UserHostAddress;

            if (string.IsNullOrEmpty(userHostAddress))
            {
                userHostAddress = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }
            //最后判断获取是否成功，并检查IP地址的格式（检查其格式非常重要）
            if (!string.IsNullOrEmpty(userHostAddress) && IsIP(userHostAddress))
            {
                return userHostAddress;
            }
            return "127.0.0.1";
        }
        /// <summary>
        /// 检查IP地址格式
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool IsIP(string ip)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(ip, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$");
        }
    }
}