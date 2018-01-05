using DunxPay.Global.Enums;
using System;
using System.Collections.Generic;

namespace DunxPay.AuthServer.Providers
{
    /// <summary>
    /// 平台验证字典
    /// </summary>
    public class PlatformValidatorDictionary
    {
        /// <summary>
        /// 平台验证字典
        /// </summary>
        private static readonly Dictionary<string, PlatformValidator> PlatformValidators = new Dictionary<string, PlatformValidator>();

        /// <summary>
        /// 向字典中添加新的平台验证器
        /// </summary>
        /// <param name="platfrom"></param>
        /// <param name="platformValidator"></param>
        public static void Add(string platfrom, PlatformValidator platformValidator)
        {
            if (!PlatformValidators.ContainsKey(platfrom))
            {
                PlatformValidators.Add(platfrom, platformValidator);
            }
        }

        /// <summary>
        /// 初始化平台验证字典
        /// </summary>
        public static void Init()
        {
            PlatformValidators.Add(((int)DxClient.Administrator).ToString(), new AdminPlatformValidator());
        }

        /// <summary>
        /// 获取所有实现了的平台验证器实体对象集合
        /// </summary>
        public static Dictionary<string, PlatformValidator> GetPlatformValidators
        {
            get
            {
                return PlatformValidators;
            }
        }

        /// <summary>
        /// 根据平台ID获取平台验证器实体对象
        /// </summary>
        /// <param name="platform"></param>
        /// <returns></returns>
        public static PlatformValidator GetPlatformValidator(string platform)
        {
            if (PlatformValidators.ContainsKey(platform))
            {
                return PlatformValidators[platform];
            }
            throw new NotSupportedException("平台用户信息验证组件未注册");
        }
    }
}