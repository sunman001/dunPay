namespace DunxPay.Global
{
    /// <summary>
    /// 运营平台缓存键实体类
    /// </summary>
    public class PlatformUserCacheKey
    {
        /// <summary>
        /// 用户信息缓存键ck_{0}_user_model_{1},{0}:平台ID,{1}:用户登录名
        /// </summary>
        public static readonly string CacheKeyUserModel = "ck_{0}_user_model_{1}";
    }
}
