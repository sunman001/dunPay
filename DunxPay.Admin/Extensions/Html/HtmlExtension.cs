using System.Text;
using System.Web;
using System.Web.Mvc;

namespace DunxPay.Admin.Extensions.Html
{
    public static class HtmlExtension
    {
        /// <summary>
        /// 生成工具栏按钮的静态扩展方法
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="text">按钮名称</param>
        /// <param name="actionCode">操作码</param>
        /// <param name="fnName">JS函数名称</param>
        /// <param name="iconCls">按钮图标类名</param>
        /// <param name="disabled">是否禁用按钮,默认值:true</param>
        /// <param name="options">data-options选项</param>
        /// <returns></returns>
        public static IHtmlString Button(this HtmlHelper htmlHelper, string text, string actionCode, string fnName, string iconCls, bool disabled = true, string options = "")
        {
            var opts = "disabled:" + disabled.ToString().ToLower();
            if (!string.IsNullOrEmpty(options))
            {
                opts += "," + options;
            }
            var sb = new StringBuilder();
            var routeData = htmlHelper.ViewContext.RouteData;
            var controller = routeData.Values["controller"].ToString().Trim().ToLower();
            var action = routeData.Values["action"].ToString().Trim().ToLower();
            var btnId = string.Format("id_{0}_{1}_{2}", controller, action, actionCode.ToLower());
            sb.AppendFormat(
                "<a id='{0}' class='easyui-linkbutton' data-action='{1}' iconCls='{2}' data-options=\"{5}\" onclick='{3}'>{4}</a>", btnId, actionCode, iconCls, fnName, text, opts);
            return new MvcHtmlString(sb.ToString());
        }
    }
}