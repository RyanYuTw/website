@ModelType My.Models.Order
@Code
    ViewBag.Title = "訂單詳細"
End Code

@If Model IsNot Nothing Then
    @<h2>訂單詳細 <small class="text-muted fs-5">@Model.OrderNo</small></h2>
    @<hr />
    @<div class="row">
        <div class="col-md-6">
            <h5>收件資訊</h5>
            <dl class="row">
                <dt class="col-sm-4">收件人</dt><dd class="col-sm-8">@Model.ReceiverName</dd>
                <dt class="col-sm-4">電話</dt><dd class="col-sm-8">@Model.ReceiverPhone</dd>
                <dt class="col-sm-4">地址</dt><dd class="col-sm-8">@Model.ReceiverAddress</dd>
                <dt class="col-sm-4">付款方式</dt><dd class="col-sm-8">@Model.PaymentMethod</dd>
                <dt class="col-sm-4">訂單狀態</dt><dd class="col-sm-8">@Model.Status</dd>
            </dl>
        </div>
    </div>
    @<table class="table mt-3">
        <thead>
            <tr><th>商品</th><th>單價</th><th>數量</th><th>小計</th></tr>
        </thead>
        <tbody>
            @If Model.Items IsNot Nothing Then
                For Each item In Model.Items
                    @<tr>
                        <td>@item.ProductName</td>
                        <td>NT$ @item.UnitPrice.ToString("N0")</td>
                        <td>@item.Quantity</td>
                        <td>NT$ @item.SubTotal.ToString("N0")</td>
                    </tr>
                Next
            End If
        </tbody>
        <tfoot>
            <tr><td colspan="3" class="text-end fw-bold">合計</td><td class="fw-bold text-danger">NT$ @Model.TotalAmount.ToString("N0")</td></tr>
        </tfoot>
    </table>
    @If Model.Status = "Pending" Then
        @Using Html.BeginForm("Cancel", "Order", New With {.id = Model.Id}, FormMethod.Post)
            @Html.AntiForgeryToken()
            @<button type="submit" class="btn btn-outline-danger" onclick="return confirm('確定要取消此訂單？')">取消訂單</button>
        End Using
    End If
    @<div class="mt-3">
        <a href="@Url.Action("Index")" class="btn btn-outline-dark">&larr; 返回列表</a>
    </div>
End If
