@ModelType My.Models.LoginViewModel
@Code
    ViewBag.Title = "登入"
End Code

<div class="row justify-content-center">
    <div class="col-md-5">
        <h2>會員登入</h2>
        <hr />

        @Using Html.BeginForm("Login", "Account", New With {.ReturnUrl = ViewBag.ReturnUrl}, FormMethod.Post)
            @Html.AntiForgeryToken()
            @Html.ValidationSummary(True, "", New With {.class = "alert alert-danger"})

            @<div class="mb-3">
                @Html.LabelFor(Function(m) m.Account, "帳號", New With {.class = "form-label"})
                @Html.TextBoxFor(Function(m) m.Account, New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(m) m.Account, "", New With {.class = "text-danger small"})
            </div>
            @<div class="mb-3">
                @Html.LabelFor(Function(m) m.Password, "密碼", New With {.class = "form-label"})
                @Html.PasswordFor(Function(m) m.Password, New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(m) m.Password, "", New With {.class = "text-danger small"})
            </div>
            @<div class="mb-3 form-check">
                @Html.CheckBoxFor(Function(m) m.RememberMe, New With {.class = "form-check-input"})
                @Html.LabelFor(Function(m) m.RememberMe, "記住我", New With {.class = "form-check-label"})
            </div>
            @<button type="submit" class="btn btn-dark w-100">登入</button>
        End Using

        <div class="mt-3 text-center">
            <a href="@Url.Action("ForgetPassword")">忘記密碼？</a>
            <span class="mx-2">|</span>
            <a href="@Url.Action("Register")">立即註冊</a>
        </div>
    </div>
</div>
