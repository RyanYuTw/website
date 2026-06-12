@ModelType My.Models.BlogPost
@Code
    ViewBag.Title = If(Model IsNot Nothing, Model.Title, "文章")
End Code

@If Model IsNot Nothing Then
    @<article>
        <h1>@Model.Title</h1>
        <p class="text-muted small">
            @Model.PublishedAt?.ToString("yyyy/MM/dd") | @Model.Author
        </p>
        @If Not String.IsNullOrEmpty(Model.ImagePath) Then
            @<img src="@Model.ImagePath" class="img-fluid mb-4" alt="@Model.Title" />
        End If
        <hr />
        <div class="blog-content">
            @Html.Raw(Model.Content)
        </div>
    </article>
    @<div class="mt-4">
        <a href="@Url.Action("Index")" class="btn btn-outline-dark">&larr; 返回列表</a>
    </div>
Else
    @<p>找不到此文章</p>
End If
