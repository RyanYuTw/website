@ModelType My.Models.ChangePasswordViewModel
@Code
    ViewBag.Title = "修改密碼"
End Code

<div class="row justify-content-center">
    <div class="col-md-5">
        <h2>修改密碼</h2>
        <hr />

        @If ViewBag.Message IsNot Nothing Then
            @<div class="alert alert-success">@ViewBag.Message</div>
        End If

        @Using Html.BeginForm()
            @Html.AntiForgeryToken()
            @Html.ValidationSummary(True, "", New With {.class = "alert alert-danger"})

            @<div class="mb-3">
                @Html.LabelFor(Function(m) m.OldPassword, "舊密碼", New With {.class = "form-label"})
                @Html.PasswordFor(Function(m) m.OldPassword, New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(m) m.OldPassword, "", New With {.class = "text-danger small"})
            </div>
            @<div class="mb-3">
                @Html.LabelFor(Function(m) m.NewPassword, "新密碼", New With {.class = "form-label"})
                @Html.PasswordFor(Function(m) m.NewPassword, New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(m) m.NewPassword, "", New With {.class = "text-danger small"})
            </div>
            @<div class="mb-3">
                @Html.LabelFor(Function(m) m.ConfirmPassword, "確認新密碼", New With {.class = "form-label"})
                @Html.PasswordFor(Function(m) m.ConfirmPassword, New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(m) m.ConfirmPassword, "", New With {.class = "text-danger small"})
            </div>
            @<button type="submit" class="btn btn-dark">更新密碼</button>
        End Using
    </div>
</div>
