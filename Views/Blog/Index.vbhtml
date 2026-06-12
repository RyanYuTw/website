@ModelType My.Models.BlogListViewModel
@Code
    ViewBag.Title = "部落格"
End Code

<h2>部落格</h2>
<hr />

<div class="row">
    <div class="col-md-9">
        <div class="row row-cols-1 row-cols-md-3 g-4">
            @If Model.Posts IsNot Nothing Then
                For Each post In Model.Posts
                    @<div class="col">
                        <div class="card h-100">
                            @If Not String.IsNullOrEmpty(post.ImagePath) Then
                                @<img src="@post.ImagePath" class="card-img-top" alt="@post.Title" />
                            End If
                            <div class="card-body">
                                <h6 class="card-title">@post.Title</h6>
                                <p class="card-text text-muted small">@post.Summary</p>
                                <small class="text-muted">@post.PublishedAt?.ToString("yyyy/MM/dd")</small>
                            </div>
                            <div class="card-footer">
                                <a href="@Url.Action("Post", New With {.id = post.Id})" class="btn btn-outline-dark btn-sm">閱讀更多</a>
                            </div>
                        </div>
                    </div>
                Next
            Else
                @<p class="text-muted">（文章將從資料庫載入）</p>
            End If
        </div>
    </div>
    <div class="col-md-3">
        <h5>文章分類</h5>
        <ul class="list-group">
            <li class="list-group-item">
                <a href="@Url.Action("Index")">全部文章</a>
            </li>
            @If Model.Categories IsNot Nothing Then
                For Each cat In Model.Categories
                    @<li class="list-group-item">
                        <a href="@Url.Action("Index", New With {.categoryId = cat.Id})">@cat.Name</a>
                    </li>
                Next
            End If
        </ul>
    </div>
</div>
