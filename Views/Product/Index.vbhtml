@ModelType My.Models.ProductListViewModel
@Code
    ViewBag.Title = "商品列表"
End Code

<div class="row">
    <div class="col-md-3">
        <h5>商品分類</h5>
        <ul class="list-group mb-4">
            <li class="list-group-item @If Model.CurrentCategoryId Is Nothing Then @"active" End If">
                <a href="@Url.Action("Index")" class="text-decoration-none @If Model.CurrentCategoryId Is Nothing Then @"text-white" End If">全部商品</a>
            </li>
            @If Model.Categories IsNot Nothing Then
                For Each cat In Model.Categories
                    @<li class="list-group-item @If Model.CurrentCategoryId = cat.Id Then @"active" End If">
                        <a href="@Url.Action("Index", New With {.categoryId = cat.Id})" class="text-decoration-none">@cat.Name</a>
                    </li>
                Next
            End If
        </ul>
    </div>
    <div class="col-md-9">
        <div class="d-flex justify-content-between align-items-center mb-3">
            <h4>商品列表</h4>
            <form class="d-flex" method="get">
                <input type="text" name="keyword" value="@Model.SearchKeyword" class="form-control me-2" placeholder="搜尋商品..." />
                <button type="submit" class="btn btn-outline-dark">搜尋</button>
            </form>
        </div>

        <div class="row row-cols-1 row-cols-md-3 g-4">
            @If Model.Products IsNot Nothing Then
                For Each p In Model.Products
                    @<div class="col">
                        <div class="card h-100">
                            <img src="@If(String.IsNullOrEmpty(p.ImagePath), "/Content/images/no-image.png", p.ImagePath)" class="card-img-top" alt="@p.Name" />
                            <div class="card-body">
                                <h6 class="card-title">@p.Name</h6>
                                <p class="card-text text-muted small">@p.Description</p>
                                <p class="fw-bold">NT$ @p.Price.ToString("N0")</p>
                            </div>
                            <div class="card-footer">
                                <a href="@Url.Action("Detail", New With {.id = p.Id})" class="btn btn-dark btn-sm w-100">查看詳情</a>
                            </div>
                        </div>
                    </div>
                Next
            Else
                @<p class="text-muted">（商品資料載入中）</p>
            End If
        </div>
    </div>
</div>
