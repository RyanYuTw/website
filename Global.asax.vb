Imports System.Web.Mvc
Imports System.Web.Routing
Imports System.Web.Optimization

Namespace My
    Public Class MvcApplication
        Inherits System.Web.HttpApplication

        Sub Application_Start()
            AreaRegistration.RegisterAllAreas()
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters)
            RouteConfig.RegisterRoutes(RouteTable.Routes)
            BundleConfig.RegisterBundles(BundleTable.Bundles)
        End Sub

        Sub Session_Start(sender As Object, e As EventArgs)
        End Sub

        Sub Application_Error(sender As Object, e As EventArgs)
            Dim ex As Exception = Server.GetLastError()
            ' 可在此加入錯誤日誌邏輯
        End Sub
    End Class
End Namespace
