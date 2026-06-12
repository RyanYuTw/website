@ModelType My.Models.RegisterViewModel
@Code
    ViewBag.Title = "會員註冊"
End Code

<div class="row justify-content-center">
    <div class="col-md-6">
        <h2>會員註冊</h2>
        <hr />

        @Using Html.BeginForm()
            @Html.AntiForgeryToken()
            @Html.ValidationSummary(True, "", New With {.class = "alert alert-danger"})

            @<div class="mb-3">
                @Html.LabelFor(Function(m) m.Account, "帳號", New With {.class = "form-label"})
                @Html.TextBoxFor(Function(m) m.Account, New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(m) m.Account, "", New With {.class = "text-danger small"})
            </div>
            @<div class="mb-3">
                @Html.LabelFor(Function(m) m.Name, "姓名", New With {.class = "form-label"})
                @Html.TextBoxFor(Function(m) m.Name, New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(m) m.Name, "", New With {.class = "text-danger small"})
            </div>
            @<div class="mb-3">
                @Html.LabelFor(Function(m) m.Email, "Email", New With {.class = "form-label"})
                @Html.TextBoxFor(Function(m) m.Email, New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(m) m.Email, "", New With {.class = "text-danger small"})
            </div>
            @<div class="mb-3">
                @Html.LabelFor(Function(m) m.Mobile, "手機", New With {.class = "form-label"})
                @Html.TextBoxFor(Function(m) m.Mobile, New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(m) m.Mobile, "", New With {.class = "text-danger small"})
            </div>
            @<div class="mb-3">
                @Html.LabelFor(Function(m) m.Password, "密碼", New With {.class = "form-label"})
                @Html.PasswordFor(Function(m) m.Password, New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(m) m.Password, "", New With {.class = "text-danger small"})
            </div>
            @<div class="mb-3">
                @Html.LabelFor(Function(m) m.ConfirmPassword, "確認密碼", New With {.class = "form-label"})
                @Html.PasswordFor(Function(m) m.ConfirmPassword, New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(m) m.ConfirmPassword, "", New With {.class = "text-danger small"})
            </div>
            @<button type="submit" class="btn btn-dark w-100">註冊</button>
        End Using

        <div class="mt-3 text-center">
            已有帳號？<a href="@Url.Action("Login")">立即登入</a>
        </div>
    </div>
</div>
