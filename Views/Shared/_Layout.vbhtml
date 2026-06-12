<!DOCTYPE html>
<html lang="zh-TW">
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>@ViewBag.Title - Wish Estate 許園</title>
    @Styles.Render("~/Content/css")
    @Scripts.Render("~/bundles/modernizr")
</head>
<body>
    <header>
        <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
            <div class="container">
                @Html.ActionLink("Wish Estate 許園", "Index", "Home", Nothing, New With {.class = "navbar-brand"})
                <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse" id="navbarNav">
                    <ul class="navbar-nav me-auto">
                        <li class="nav-item">
                            @Html.ActionLink("首頁", "Index", "Home", Nothing, New With {.class = "nav-link"})
                        </li>
                        <li class="nav-item">
                            @Html.ActionLink("商品", "Index", "Product", Nothing, New With {.class = "nav-link"})
                        </li>
                        <li class="nav-item">
                            @Html.ActionLink("部落格", "Index", "Blog", Nothing, New With {.class = "nav-link"})
                        </li>
                        <li class="nav-item">
                            @Html.ActionLink("關於我們", "About", "Home", Nothing, New With {.class = "nav-link"})
                        </li>
                        <li class="nav-item">
                            @Html.ActionLink("聯絡我們", "Contact", "Home", Nothing, New With {.class = "nav-link"})
                        </li>
                    </ul>
                    <ul class="navbar-nav">
                        <li class="nav-item">
                            @Html.ActionLink("購物車", "Index", "Cart", Nothing, New With {.class = "nav-link"})
                        </li>
                        @If Request.IsAuthenticated Then
                            @<li class="nav-item dropdown">
                                <a class="nav-link dropdown-toggle" href="#" data-bs-toggle="dropdown">@Session("MemberName")</a>
                                <ul class="dropdown-menu dropdown-menu-end">
                                    <li>@Html.ActionLink("我的訂單", "Index", "Order", Nothing, New With {.class = "dropdown-item"})</li>
                                    <li>@Html.ActionLink("會員資料", "Profile", "Account", Nothing, New With {.class = "dropdown-item"})</li>
                                    <li><hr class="dropdown-divider" /></li>
                                    <li>@Html.ActionLink("登出", "Logout", "Account", Nothing, New With {.class = "dropdown-item"})</li>
                                </ul>
                            </li>
                        Else
                            @<li class="nav-item">@Html.ActionLink("登入", "Login", "Account", Nothing, New With {.class = "nav-link"})</li>
                            @<li class="nav-item">@Html.ActionLink("註冊", "Register", "Account", Nothing, New With {.class = "nav-link"})</li>
                        End If
                    </ul>
                </div>
            </div>
        </nav>
    </header>

    <main class="container mt-4">
        @RenderBody()
    </main>

    <footer class="bg-dark text-light mt-5 py-4">
        <div class="container text-center">
            <p class="mb-1">&copy; @DateTime.Now.Year Wish Estate 許園股份有限公司</p>
            <p class="mb-0 small">
                @Html.ActionLink("隱私政策", "Privacy", "Home", Nothing, New With {.class = "text-light"}) |
                @Html.ActionLink("聯絡我們", "Contact", "Home", Nothing, New With {.class = "text-light"})
            </p>
        </div>
    </footer>

    @Scripts.Render("~/bundles/jquery")
    @Scripts.Render("~/bundles/bootstrap")
    @Scripts.Render("~/bundles/site")
    @RenderSection("scripts", required:=False)
</body>
</html>
