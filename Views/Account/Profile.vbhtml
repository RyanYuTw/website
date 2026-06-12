@Code
    ViewBag.Title = "會員資料"
End Code

<h2>會員資料</h2>
<hr />
<div class="row">
    <div class="col-md-6">
        <p class="text-muted">（會員資料從資料庫載入）</p>
        <a href="@Url.Action("ChangePassword")" class="btn btn-outline-dark">修改密碼</a>
    </div>
</div>
