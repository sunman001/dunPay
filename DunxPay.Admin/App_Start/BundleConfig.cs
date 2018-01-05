using System.Web.Optimization;

namespace DunxPay.Admin
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/js/main")
                .Include(
                "~/Scripts/jquery-{version}.js"
                , "~/app/global.js"
                ));

            Bundle easyui = new ScriptBundle("~/js/easyui");
            easyui.Include(
                  "~/assets/easyui/jquery.easyui.min.js"
                , "~/assets/easyui/locale/easyui-lang-zh_CN.js"
                , "~/app/common/easyui.tabs.plugin.js"
                , "~/app/common/pagevalidate.js"
                , "~/app/common/jquery.ajax.submit.js");
            easyui.Transforms.Clear();
            bundles.Add(easyui);

            bundles.Add(new StyleBundle("~/css/mains")
                .Include(
                //"~/assets/easyui/themes/gray/easyui.css",
                 "~/css/base.css"
                , "~/css/easyui-override.css"));

            bundles.Add(new StyleBundle("~/css/home")
                .Include(
                    //"~/assets/easyui/themes/gray/easyui.css",
                    "~/css/base.css"
                    , "~/css/easyui-override.css"));

            BundleTable.EnableOptimizations = true;
        }
    }
}