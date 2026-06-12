@ModelType My.Models.Product
@Code
    ViewBag.Title = If(Model IsNot Nothing, Model.Name, "商品詳細")
End Code

@If Model IsNot Nothing Then
    @<div class="row">
        <div class="col-md-5">
            <img src="@If(String.IsNullOrEmpty(Model.ImagePath), "/Content/images/no-image.png", Model.ImagePath)" class="img-fluid" alt="@Model.Name" />
        </div>
        <div class="col-md-7">
            <h2>@Model.Name</h2>
            <p class="text-muted">@Model.Description</p>
            <h4 class="text-danger">NT$ @Model.Price.ToString("N0")</h4>

            @Using Html.BeginForm("Add", "Cart", FormMethod.Post)
                @Html.AntiForgeryToken()
                @<input type="hidden" name="productId" value="@Model.Id" />
                @<div class="d-flex align-items-center mb-3">
                    <label class="me-2">數量：</label>
                    <input type="number" name="qty" value="1" min="1" max="99" class="form-control" style="width:80px" />
                </div>
                @<button type="submit" class="btn btn-dark btn-lg">加入購物車</button>
            End Using
        </div>
    </div>
    @<hr />
    @<div class="mt-4">
        <h5>商品介紹</h5>
        @Html.Raw(Model.Content)
    </div>
Else
    @<p>找不到此商品</p>
End If
