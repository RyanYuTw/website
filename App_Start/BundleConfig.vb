Imports System.Web.Optimization

Namespace My
    Public Class BundleConfig
        Public Shared Sub RegisterBundles(bundles As BundleCollection)
            bundles.Add(New ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js"))

            bundles.Add(New ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate*"))

            bundles.Add(New ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"))

            bundles.Add(New ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.js"))

            bundles.Add(New ScriptBundle("~/bundles/site").Include(
                "~/Scripts/site.js"))

            bundles.Add(New StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.min.css",
                "~/Content/site.css"))
        End Sub
    End Class
End Namespace
