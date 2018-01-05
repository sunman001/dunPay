using System.Configuration;

namespace DunxPay.Global
{
    /// <summary>
    /// 全局配置类
    /// </summary>
    public class Config
    {
        /// <summary>
        /// 基于Oauth 2 认证的登录地址
        /// </summary>
        public static string OauthLoginUrl
        {
            get { return ConfigurationManager.AppSettings["OauthLoginUrl"]; }
        }

        /// <summary>
        /// 当未登录或者登录超时跳转的地址
        /// </summary>
        public static string OauthGrantUrl
        {
            get { return ConfigurationManager.AppSettings["OauthGrantUrl"]; }
        }

        /// <summary>
        /// 基于Oauth 2 认证的回调地址
        /// </summary>
        public static string OauthCallbackUrl
        {
            get { return ConfigurationManager.AppSettings["OauthCallbackUrl"]; }
        }

        /// <summary>
        /// 从配置文件中读取分页大小集合
        /// </summary>
        private static string _pageSizeList = ConfigurationManager.AppSettings["PageSizeList"];
        /// <summary>
        /// 从配置文件中读取分页大小集合
        /// </summary>
        public static string PageSizeList
        {
            get { return _pageSizeList; }
        }
    }
}
