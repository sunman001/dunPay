namespace DunxPay.Core
{
    /// <summary>
    /// 随机字符串生成器基类
    /// </summary>
    public abstract class RandomBuilder
    {
        public abstract string Build { get; }
    }
    /// <summary>
    /// 模块标识码生成器
    /// </summary>
    public class ModuleIdentifyCodeBuilder : RandomBuilder
    {
        #region Overrides of RandomBuilder

        public override string Build { get {return "m" + RandomHelper.GetRandomizer(9, true, false, true, true); } }

        #endregion
    }

    /// <summary>
    /// 权限标识码生成器
    /// </summary>
    public class PermissionIdentifyCodeBuilder : RandomBuilder
    {
        #region Overrides of RandomBuilder

        public override string Build { get { return "p" + RandomHelper.GetRandomizer(9, true, false, true, true); } }

        #endregion
    }

    /// <summary>
    /// 角色标识码生成器
    /// </summary>
    public class RoleIdentifyCodeBuilder : RandomBuilder
    {
        #region Overrides of RandomBuilder

        public override string Build { get { return "r" + RandomHelper.GetRandomizer(9, true, false, true, true); } }

        #endregion
    }

}
