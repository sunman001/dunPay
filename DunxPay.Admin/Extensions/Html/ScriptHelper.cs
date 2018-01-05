using System;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;

namespace DunxPay.Admin.Extensions.Html
{
    public static class ScriptHelper
    {
        public static IHtmlString InlineScripts(this HtmlHelper htmlHelper, string bundleVirtualPath)
        {
            //return htmlHelper.InlineBundle(bundleVirtualPath, "script");
            var sb = new StringBuilder();
            sb.AppendFormat("<script src='{0}?t={1}'><script>", bundleVirtualPath, Guid.NewGuid());
            return new HtmlString(sb.ToString());
        }

        public static IHtmlString InlineScripts(this HtmlHelper htmlHelper, params string[] bundleVirtualPaths)
        {

            var sb = new StringBuilder();
            var guid = Guid.NewGuid();
            foreach (var bundleVirtualPath in bundleVirtualPaths)
            {
                sb.AppendLine(string.Format("<script src='{0}?t={1}' />", UrlHelper.GenerateContentUrl(bundleVirtualPath, htmlHelper.ViewContext.HttpContext), guid));
            }
            return new HtmlString(sb.ToString());
            //return htmlHelper.InlineBundle(bundleVirtualPath, "style");
        }

        public static IHtmlString InlineStyles(this HtmlHelper htmlHelper, string bundleVirtualPath)
        {

            var sb = new StringBuilder();
            //sb.AppendFormat("<script src='{0}?t={1}'><script>", bundleVirtualPath, Guid.NewGuid());
            //<link href="/assets/easyui/themes/default/easyui.css" rel="stylesheet" />
            sb.AppendFormat("<link href='{0}?t={1}' rel='stylesheet' />", bundleVirtualPath, Guid.NewGuid());
            return new HtmlString(sb.ToString());
            //return htmlHelper.InlineBundle(bundleVirtualPath, "style");
        }

        public static IHtmlString InlineStyles(this HtmlHelper htmlHelper, params string[] bundleVirtualPaths)
        {

            var sb = new StringBuilder();
            var guid = Guid.NewGuid();
            foreach (var bundleVirtualPath in bundleVirtualPaths)
            {
                sb.AppendLine(string.Format("<link href='{0}?t={1}' rel='stylesheet' />", UrlHelper.GenerateContentUrl(bundleVirtualPath, htmlHelper.ViewContext.HttpContext), guid));
            }
            return new HtmlString(sb.ToString());
            //return htmlHelper.InlineBundle(bundleVirtualPath, "style");
        }

        private static IHtmlString InlineBundle(this HtmlHelper htmlHelper, string bundleVirtualPath, string htmlTagName)
        {
            var bundleContent = LoadBundleContent(htmlHelper.ViewContext.HttpContext, bundleVirtualPath);
            var htmlTag = string.Format("<{0}>{1}</{0}>", htmlTagName, bundleContent);

            return new HtmlString(htmlTag);
        }

        private static string LoadBundleContent(HttpContextBase httpContext, string bundleVirtualPath)
        {
            var bundleContext = new BundleContext(httpContext, BundleTable.Bundles, bundleVirtualPath);

            var bundle = BundleTable.Bundles.Single(b => b.Path == bundleVirtualPath);
            var bundleResponse = bundle.GenerateBundleResponse(bundleContext);

            return bundleResponse.Content;
        }

        /// <summary>
        /// 获取当前路由路径
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <returns></returns>
        public static string CurrentRoutePath(this HtmlHelper htmlHelper)
        {
            var routeData = htmlHelper.ViewContext.RouteData;
            var controller = routeData.Values["controller"].ToString().Trim().ToLower();
            var action = routeData.Values["action"].ToString().Trim().ToLower();
            return string.Format("{0}/{1}", controller, action);
        }
    }
}